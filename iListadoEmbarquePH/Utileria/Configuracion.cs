using System;
using System.Collections.Generic;
using System.Text;

namespace iListadoEmbarquePH.Utileria
{
    class Configuracion
    {
        public string NombreImpresora
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["Impresora.Nombre"]; }
        }

        public string RutaRPT
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["Ruta.RPT"]; }
        }

        public string Conexion
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["SQL.Conexion1"]; }
        }

        public int NoCopias
        {
            get { return System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Reporte.Copias"]); }
        }

        public string RutaTrabajo
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["Ruta.Trabajo"]; }
        }

        public bool PrevioPDF
        {
            get {
                return (System.Configuration.ConfigurationManager.AppSettings["Previo.PDF"] == "1"? true: false) ; 
            }
        }
    }
}
