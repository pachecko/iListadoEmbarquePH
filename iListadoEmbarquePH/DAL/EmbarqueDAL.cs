using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SQLAccess;

namespace iListadoEmbarquePH.DAL
{
    class EmbarqueDAL
    {
        public int GetItemsIdCaja(string Pedido, int IdSucursal)
        {
            try
            {
                int intResult = 0;

                SqlParameter[] arrParam = new SqlParameter[3];
                SqlParameter objParam;

                objParam = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
                objParam.Direction = ParameterDirection.ReturnValue;
                arrParam[0] = objParam;

                objParam = new SqlParameter("@Pedido", SqlDbType.NVarChar, 10);
                objParam.Value = Pedido;
                arrParam[1] = objParam;

                objParam = new SqlParameter("@IdSucursalPH", SqlDbType.Int);
                objParam.Value = IdSucursal;
                arrParam[2] = objParam;

                intResult = SQLDataAccess.Instance.ExecuteNonQuery("dbo.EmbarquePHIdCajaSPS", arrParam);

                return (intResult);
            }
            catch
            {
                throw;
            }
        }

        public void SetSucursales(ref ComboBox cbTienda, ref Dictionary<int, string> idsuc)
        {
            try
            {
                DataSet ds = SQLDataAccess.Instance.GetDataSet("SucursalPHSPDTs", "Tiendas");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cbTienda.Items.Add(dr[1] + " " + dr[2]);
                    idsuc.Add(int.Parse(dr[0].ToString()), dr[1] + " " + dr[2]);
                }
            }
            catch 
            {
                throw;
            }
        }

        public int Add(SqlConnection cnx, SqlTransaction trn, string Pedido, int idSucursal, int idCaja, int idProveedor, string CB, int lenSKU)
        {
            try
            {
                int result = 0;

                SqlParameter[] arrParam = new SqlParameter[6];
                SqlParameter objParam;

                objParam = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
                objParam.Direction = ParameterDirection.ReturnValue;
                arrParam[0] = objParam;

                objParam = new SqlParameter("@Pedido", SqlDbType.NVarChar, 10);
                objParam.Value = Pedido;
                arrParam[1] = objParam;

                objParam = new SqlParameter("@IdSucursalPH", SqlDbType.Int);
                objParam.Value = idSucursal;
                arrParam[2] = objParam;

                objParam = new SqlParameter("@IdCaja", SqlDbType.Int);
                objParam.Value = idCaja;
                arrParam[3] = objParam;

                objParam = new SqlParameter("@ClaveProveedorPH", SqlDbType.Int);
                objParam.Value = idProveedor;
                arrParam[4] = objParam;

                objParam = new SqlParameter("@CodigoBarras", SqlDbType.NVarChar, lenSKU);
                objParam.Value = CB;
                arrParam[5] = objParam;

                result = SQLDataAccess.Instance.ExecuteNonQueryTransaction(cnx, trn, "EmbarquePHSPI", arrParam);

                return result;
            }
            catch //(Exception ex)
            {
                throw;
            }
        }

        public int VerificaSKU(SqlConnection cnx, SqlTransaction trn, string SKU, int lenSKU)
        {
            try
            {
                int result = 0;

                SqlParameter[] arrParam = new SqlParameter[2];
                SqlParameter objParam;

                objParam = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
                objParam.Direction = ParameterDirection.ReturnValue;
                arrParam[0] = objParam;

                objParam = new SqlParameter("@CodigoBarras", SqlDbType.NVarChar, lenSKU);
                objParam.Value = SKU;
                arrParam[1] = objParam;

                result = SQLDataAccess.Instance.ExecuteNonQueryTransaction(cnx, trn, "EmbarquePHValidaSKUSP", arrParam);

                return result;
            }
            catch //(Exception ex)
            {
                throw;
            }
        }

        public DataSet GetItemPrint(string Pedido, int IdCaja, int IdSucursal)
        {
            try
            {
                SqlParameter[] arrParam = new SqlParameter[4];
                SqlParameter objParam;

                objParam = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
                objParam.Direction = ParameterDirection.ReturnValue;
                arrParam[0] = objParam;

                objParam = new SqlParameter("@IdSucursalPH", SqlDbType.Int);
                objParam.Value = IdSucursal;
                arrParam[1] = objParam;

                objParam = new SqlParameter("@IdCaja", SqlDbType.Int);
                objParam.Value = IdCaja;
                arrParam[2] = objParam;

                objParam = new SqlParameter("@Pedido", SqlDbType.VarChar, 10);
                objParam.Value = Pedido;
                arrParam[3] = objParam;

                DataSet dtsReporte = SQLDataAccess.Instance.GetDataSet("dbo.ReporteEmbarquePHSPDts", "ListadoEmbarque", arrParam);

                return dtsReporte;
            }
            catch
            {
                throw;
            }

        }
    }
}
