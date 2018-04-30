using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using iListadoEmbarquePH.GUI;
using iListadoEmbarquePH.DAL;
using iListadoEmbarquePH.Utileria;
using SQLAccess;

namespace iListadoEmbarquePH.GUI
{
    public partial class fmPrincipal : Form
    {
        public static int idProveedor,
                   lenCB = 0, //se usa para regular el tamaño del CB
                   idsucursal = 0,
                   idcaja = 0;
        public string nombreProveedor;
        public Dictionary<int, string> idsuc = new Dictionary<int, string>();
        EmbarqueDAL edal = new EmbarqueDAL();
        public static string    dir,
                                vProveedor,
                                vTienda,
                                vPedido,
                                conection,
                                archivo,
                                cnx;

        public fmPrincipal()
        {
            InitializeComponent();
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ActualizaListaDeArchivos()
        {
            string[] files = Directory.GetFiles(dir);
            int c = 0;

            try
            {
                cbArchivo.Items.Clear();

                while (files[c] != null)
                {
                    cbArchivo.Items.Add(files[c].Substring(dir.Length, files[c].Length - dir.Length).ToUpper());
                    c++;
                }
            }
            catch (Exception)
            { }
        }

        /*-------------------------------------------		
		    Referencia:	2011001-2011090800(1)
		    App/Ver:	iListadoEmbarquePH 1.1.0.0
		    Fecha:		08-Sep-2011 
		    Modificó:	OG, RY
		    Motivo:		Se utilizan los parámetros de configuración 'Ruta.Trabajo' y 'IdProveedor'.
		 -------------------------------------------*/
        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                string strConexion = SQLAccess.SQLDataAccess.Instance.GetConnection();
                int intPswd = strConexion.IndexOf(";User");
                //2011001-2011090800(1)
                idProveedor = int.Parse(ConfigurationManager.AppSettings["idProveedor"].ToString());
                nombreProveedor = ConfigurationManager.AppSettings["Proveedor"].ToString();
                lenCB = int.Parse(ConfigurationManager.AppSettings["lenCB"].ToString());
                cnx = "Conexión: " + strConexion.Substring(0, intPswd);
                //2011001-2011090800(1)
                dir = ConfigurationManager.AppSettings["Ruta.Trabajo"].ToString();
                SetDir();
                string s = dir.Replace("\\\\", "\\");
                lbDir.Text = s;

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!Directory.Exists(dir + "PROCESADOS\\"))
                    Directory.CreateDirectory(dir + "PROCESADOS\\");
                if (!Directory.Exists(dir + "ERRORES\\"))
                    Directory.CreateDirectory(dir + "ERRORES\\");

                ActualizaListaDeArchivos();

                lbProveedor.Text = idProveedor.ToString() + " " + nombreProveedor;
                vProveedor = idProveedor.ToString() + " " + nombreProveedor;

                edal.SetSucursales(ref cbTienda, ref idsuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente Error: " + ex.Message, "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                try
                {
                    SQLAccess.SQLDataAccess.Instance.Trace(ex.Message);
                    SQLAccess.SQLDataAccess.Instance.Bitacora(3, Application.ProductName, "OnLoad(). " + ex.Message);
                    Close();
                }
                catch
                {
                    Close();
                }
            }
                       
        }

        private void btCargaDatos_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(SQLAccess.SQLDataAccess.Instance.GetConnection()))
            {
                // Start a local transaction.
                con.Open();
                SqlTransaction sqlTran = con.BeginTransaction(IsolationLevel.ReadCommitted, "insertaTXT");

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    archivo = cbArchivo.Text;

                    string line;
                    bool errores = false;

                    foreach (KeyValuePair<int, string> k in idsuc)
                    {
                        if (k.Value == cbTienda.Text)
                            idsucursal = int.Parse(k.Key.ToString());
                    }

                    ////OBTENER IDCAJA

                    idcaja = edal.GetItemsIdCaja(tbPedido.Text.Trim(), idsucursal);

                    //INSERTAR EMBARQUE

                    int intResultAdd = 0;
                    int lines = 0;

                    using (StreamReader srd = new StreamReader(dir + archivo))
                    {
                        if ((idcaja > 0) && (!errores))
                        {
                            progressBar.Visible = true;
                            int c = 1; //contador de avance del progressbar
                            int LINE_LENGTH = 0;

                            while ((line = srd.ReadLine()) != null)
                            {
                                if (line.Trim() != string.Empty)// && (line.Trim().Length == lenCB))
                                {
                                    intResultAdd = edal.Add(
                                            con,
                                            sqlTran,
                                            tbPedido.Text.Trim(),
                                            idsucursal,
                                            idcaja,
                                            idProveedor,
                                            line.Trim(),
                                            lenCB
                                            );
                                    
                                    lines++;

                                    // si falló al agregar o no encontro su relación con PH, envia mensaje y termina el proceso
                                    if (intResultAdd <= 0)
                                    {
                                        progressBar.Visible = false;
                                        sqlTran.Rollback();
                                        con.Close();

                                        string strRutaConfig = new Configuracion().RutaTrabajo;
                                        string filename = strRutaConfig + @"ERRORES\ERR_" + System.DateTime.Today.ToString("ddMMyyyy") + "_" + System.DateTime.Now.ToString("HHmmss") + ".TXT";

                                        try
                                        {
                                            //MessageBox.Show(Directory.GetCurrentDirectory() + "\\ERRORES\\ERR_" + System.DateTime.Today.ToString("ddMMyyyy") + "_" + System.DateTime.Now.ToString("HHmmss") + ".TXT");
                                            SQLAccess.SQLDataAccess.Instance.TraceError(line.Trim(), filename);
                                        }
                                        catch
                                        { }
                                        
                                        MessageBox.Show("Algunos artículos que intenta procesar no tienen información de Palacio de Hierro. " +
                                                        "Para continuar, debe asociar los artículos." +
                                                        "\n\n" +
                                                        "El archivo: " + filename + 
                                                        "contiene los detalles del código sin referencia en el catálogo de Palacio de Hierro."
                                                        , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        return;
                                    }
                                    else
                                    {
                                        if (LINE_LENGTH == 0)
                                        {
                                            LINE_LENGTH = line.Trim().Length;
                                            System.IO.FileInfo f = new System.IO.FileInfo(dir + archivo);
                                            progressBar.Maximum = Convert.ToInt32(f.Length / LINE_LENGTH);  //calcula cantidad de lineas del txt
                                        }

                                        progressBar.Value = c++;
                                        progressBar.Refresh();
                                    }
                                }
                                //else
                                //{
                                //    if ((line.Trim() != string.Empty) && (line.Trim().Length != lenCB))
                                //        errores = true;
                                //}
                            }

                            progressBar.Visible = false;
                        }
                        else
                        {
                            progressBar.Visible = false;
                            MessageBox.Show("Algunos datos no fueron procesados debido a datos inconsistentes en el archivo. Los datos guardados están listos para imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        sqlTran.Commit();
                        con.Close();

                        //if (errores)
                        //{
                        //    MessageBox.Show("Algunos datos no fueron procesados debido a datos inconsistentes en el archivo. Los datos guardados están listos para imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{

                        progressBar.Visible = false;
                        MessageBox.Show(lines.ToString() + " registros se han guardado correctamente. Estan listos para su impresión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbArchivo.Enabled = false;
                        btCargaDatos.Enabled = false;
                        btImprimir.Enabled = true;
                        btCancelar.Enabled = true;
                        
                        //}

                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    progressBar.Visible = false;
                    sqlTran.Rollback();
                    con.Close();

                    Cursor.Current = Cursors.Default;

                    string msg = "Ha ocurrido el siguiente Error: \n" + ex.Message;
                    MessageBox.Show(msg, "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error); try

                    {
                        SQLAccess.SQLDataAccess.Instance.Trace(msg);
                        SQLAccess.SQLDataAccess.Instance.Bitacora(3, Application.ProductName, "CargaDatos_Click(). " + ex.Message);
                        Close();
                    }
                    catch
                    { }

                }
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            bool previoPDF = new Configuracion().PrevioPDF;
            bool previo = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (previoPDF)
                {
                    if (MessageBox.Show("¿Desea ver previo o solo imprimir?", "Lista de Embarque", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        previo = true;
                    }
                }
                

                bool blnReporte = new Utileria.Procesos().ReporteEmbarque(vPedido, idcaja, idsucursal, vTienda, vProveedor, previo);

                if (blnReporte == true)
                {
                    if (!previo)
                        MessageBox.Show("La impresión termino exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un problema con la impresión del documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                    return;
                }
                Cursor.Current = Cursors.Default;
                                
                
                btImprimir.Enabled = true;
                //cbArchivo.Text = string.Empty;
                cbArchivo.Enabled = true;
                btCancelar.Enabled = true;

                if (!previo)
                {
                    //original
                    btImprimir.Enabled = false;
                    cbArchivo.Text = string.Empty;                    
                    btCancelar.Enabled = false;
                    tbPedido.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema con la impresión del documento." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            if (!previo)
            {
                //ELIMINAR ARCHIVO PROCESADO DE LA CARPETA DE TRABAJO
                try
                {
                    if (File.Exists(dir + "PROCESADOS\\" + archivo))
                        File.Delete(dir + "PROCESADOS\\" + archivo);

                    File.Copy(dir + archivo, dir + "PROCESADOS\\" + archivo);

                    if (File.Exists(dir + archivo))
                        File.Delete(dir + archivo);

                    cbArchivo.Items.Remove(cbArchivo.SelectedItem);
                    cbArchivo.Enabled = true;

                    Cursor.Current = Cursors.Default;
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar el archivo de datos de escaneo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
            }
            
        }

        private void tbPedido_TextChanged(object sender, EventArgs e)
        {
            if ((tbPedido.Text.Trim() != string.Empty) && 
                (cbTienda.Text.Trim() != string.Empty) && 
                (cbArchivo.Text.Trim() != string.Empty) &&
                (cbArchivo.Enabled))
                btCargaDatos.Enabled = true;
            else
                btCargaDatos.Enabled = false;

            if (tbPedido.Text.Trim() != string.Empty)
                vPedido = tbPedido.Text.Trim();

            if (cbTienda.Text.Trim() != string.Empty)
                vTienda = cbTienda.Text.Trim();
        }

        private void cbTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(0);
        }

        private void cbArchivo_DropDown(object sender, EventArgs e)
        {
            if (cbArchivo.Items.Count == 0)
                MessageBox.Show("No existen archivos en el directorio de trabajo. Agréguelos y presione el botón de actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void imgPicture_Click(object sender, EventArgs e)
        {

        }

        private void cbTienda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizaListaDeArchivos();
        }

        private void SetCnx()
        {
            lblConexion.Text = cnx;
            lblConexion.Refresh();
        }

        private void SetDir()
        {
            lblConexion.Text = "Directorio: " + dir + "                    Impresora: " + new Configuracion().NombreImpresora;
            lblConexion.Refresh();
        }

        private void fmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
                SetCnx();
        }

        private void fmPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
                SetDir();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            cbArchivo.Enabled = true;
            cbArchivo.Text = "";
            tbPedido_TextChanged(sender, e);
            btCancelar.Enabled = false;
        }

        private void cbArchivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}