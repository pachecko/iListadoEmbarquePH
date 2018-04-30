using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SQLAccess;
using iListadoEmbarquePH.Utileria;
using System.Diagnostics;
using System.IO;

namespace iListadoEmbarquePH.Utileria
{
    class Procesos
    {
        ReportDocument objReporte;

        public bool ReporteEmbarque(string Pedido, int IdCaja, int IdSucursal, string Tienda, string Proveedor, bool previo)
        {
            try
            {
                // obtiene información para el reporte
                DataSet dtsListado = new DAL.EmbarqueDAL().GetItemPrint(Pedido, IdCaja, IdSucursal);
                if (dtsListado.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                
                // crea instancia                
                objReporte = new ReportDocument();
                objReporte.Load(new Configuracion().RutaRPT + "\\crListadoEmbarque.rpt");
                objReporte.SetDataSource(dtsListado);

                // enviar parámetros
                objReporte.DataDefinition.FormulaFields["Proveedor"].Text = "'" + Proveedor + "'";
                objReporte.DataDefinition.FormulaFields["Tienda"].Text = "'" + Tienda + "'";
                objReporte.DataDefinition.FormulaFields["Pedido"].Text = "'" + Pedido + "'";                

                //New
                if (previo)
                {
                    string sPathPDF = new Configuracion().RutaTrabajo;
                    string strPathFile = sPathPDF + "Reporte_" + Tienda + "_" + Pedido + ".pdf";
                    //try
                    //{
                        if (!File.Exists(strPathFile))
                        {
                            File.Delete(strPathFile);
                        }

                        //objReporte.PrintOptions.

                        this.GeneraPDF(objReporte, strPathFile);
                        Process.Start(strPathFile);
                    //}
                    //catch 
                    //{ 
                    
                    //}

                    
                }
                else
                {
                    //original                                
                    objReporte.PrintOptions.PrinterName = new Configuracion().NombreImpresora;
                    objReporte.PrintToPrinter(new Configuracion().NoCopias, false, 0, 0);
                }
                                
                //original                                
                //objReporte.PrintOptions.PrinterName = new Configuracion().NombreImpresora;
                //objReporte.PrintToPrinter(new Configuracion().NoCopias, false, 0, 0);

                return true;
            }
            catch
            {
                throw;
            }

        }

        //Test
        private void GeneraPDF(ReportDocument objInforme, string pathFile)
        {
            string strMsgResul = string.Empty;

            try
            {

                //string strRutaArchivo = pathPDF + "Reporte_" + proveedor + "_" + tie + "_" + pedido + ".pdf";

                //DiskFileDestinationOptions diskDestination = new DiskFileDestinationOptions();
                //objInforme.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;//ExportDestinationType.DiskFile;
                //objInforme.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;//.CrystalReport; //.NoFormat; //.PortableDocFormat;//.RichText;// //ExportFormatType.PortableDocFormat;//ExportFormatType.CrystalReport;//                
                //diskDestination.DiskFileName = pathFile;
                //objInforme.ExportOptions.DestinationOptions = diskDestination;
                //objInforme.Export();

                DiskFileDestinationOptions diskDestination = new DiskFileDestinationOptions();
                objInforme.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                objInforme.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                diskDestination.DiskFileName = pathFile;
                objInforme.ExportOptions.DestinationOptions = diskDestination;
                objInforme.Export();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
