//#define SISFAC     // todo comentado = Diboza
//#define DEBUGA     //Para hacer debug
//#define OLE12       //SISFAC 64 bits
//#define OLE4       
//#define ACE
//#define JET
//#define QUERYFAC
//#define DEBUGLOCAL
using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Data.OleDb;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

namespace FEControlador
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Class containing methods to retrieve specific file system paths.
    /// </summary>
    public static class KnownFolders
    {
        private static string[] _knownFolderGuids = new string[]
        {
        "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
        "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
        "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
        "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
        "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
        "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
        "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
        "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
        "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
        "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
        "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
        };

        /// <summary>
        /// Gets the current path to the specified known folder as currently configured. This does
        /// not require the folder to be existent.
        /// </summary>
        /// <param name="knownFolder">The known folder which current path will be returned.</param>
        /// <returns>The default path of the known folder.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
        ///     could not be retrieved.</exception>
        public static string GetPath(KnownFolder knownFolder)
        {
            return GetPath(knownFolder, false);
        }

        /// <summary>
        /// Gets the current path to the specified known folder as currently configured. This does
        /// not require the folder to be existent.
        /// </summary>
        /// <param name="knownFolder">The known folder which current path will be returned.</param>
        /// <param name="defaultUser">Specifies if the paths of the default user (user profile
        ///     template) will be used. This requires administrative rights.</param>
        /// <returns>The default path of the known folder.</returns>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
        ///     could not be retrieved.</exception>
        public static string GetPath(KnownFolder knownFolder, bool defaultUser)
        {
            return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
        }

        private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags,
            bool defaultUser)
        {
            int result = SHGetKnownFolderPath(new Guid(_knownFolderGuids[(int)knownFolder]),
                (uint)flags, new IntPtr(defaultUser ? -1 : 0), out IntPtr outPath);
            if (result >= 0)
            {
                string path = Marshal.PtrToStringUni(outPath);
                Marshal.FreeCoTaskMem(outPath);
                return path;
            }
            else
            {
                throw new ExternalException("Unable to retrieve the known folder path. It may not "
                    + "be available on this system.", result);
            }
        }

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken,
            out IntPtr ppszPath);

        [Flags]
        private enum KnownFolderFlags : uint
        {
            SimpleIDList = 0x00000100,
            NotParentRelative = 0x00000200,
            DefaultPath = 0x00000400,
            Init = 0x00000800,
            NoAlias = 0x00001000,
            DontUnexpand = 0x00002000,
            DontVerify = 0x00004000,
            Create = 0x00008000,
            NoAppcontainerRedirection = 0x00010000,
            AliasOnly = 0x80000000
        }
    }

    /// <summary>
    /// Standard folders registered with the system. These folders are installed with Windows Vista
    /// and later operating systems, and a computer will have only folders appropriate to it
    /// installed.
    /// </summary>
    public enum KnownFolder
    {
        Contacts,
        Desktop,
        Documents,
        Downloads,
        Favorites,
        Links,
        Music,
        Pictures,
        SavedGames,
        SavedSearches,
        Videos
    }
    public class item
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string value;
    }

    public class MensajeReceptor
    {
        private string clave = "0";
        private string numeroCedulaEmisor = "0";
        private string fechaEmisionDoc = "0";
        private string mensaje = "1";
        private string montoTotalImpuesto = "0";
        private string totalFactura = "0";
        private string numeroCedulaReceptor = "0";
        private string numeroConsecutivoReceptor = "0";
        private string nombreEmisor = "0";

        public string Clave { get => clave; set => clave = value; }
        public string NumeroCedulaEmisor { get => numeroCedulaEmisor; set => numeroCedulaEmisor = value; }
        public string FechaEmisionDoc { get => fechaEmisionDoc; set => fechaEmisionDoc = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string MontoTotalImpuesto { get => montoTotalImpuesto; set => montoTotalImpuesto = value; }
        public string TotalFactura { get => totalFactura; set => totalFactura = value; }
        public string NumeroCedulaReceptor { get => numeroCedulaReceptor; set => numeroCedulaReceptor = value; }
        public string NumeroConsecutivoReceptor { get => numeroConsecutivoReceptor; set => numeroConsecutivoReceptor = value; }
        public string NombreEmisor { get => nombreEmisor; set => nombreEmisor = value; }
    }
    public class compra
    {
        private string numero = "0";
        private string fecha = "0";
        private string hora = "00/00/00";
        private double descuentoM = 0;
        private double IVAm = 0;
        private double total = 0;
        private double totalGravado = 0;
        private double totalExento = 0;
        private int codigoEstado = 0;
        private int codigoTipo = 0;
        private int codigoFormaPago = 0;
        private int codigoMoneda = 1;
        private double subtotal = 0;
        private List<detalleCompra> detailList = new List<detalleCompra>();
        

        public string Numero { get => numero; set => numero = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public double DescuentoM { get => descuentoM; set => descuentoM = value; }
        public double IVAm1 { get => IVAm; set => IVAm = value; }
        public double Total { get => total; set => total = value; }
        public double TotalGravado { get => totalGravado; set => totalGravado = value; }
        public double TotalExento { get => totalExento; set => totalExento = value; }
        public int CodigoEstado { get => codigoEstado; set => codigoEstado = value; }
        public int CodigoTipo { get => codigoTipo; set => codigoTipo = value; }
        public int CodigoFormaPago { get => codigoFormaPago; set => codigoFormaPago = value; }
        public int CodigoMoneda { get => codigoMoneda; set => codigoMoneda = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public List<detalleCompra> DetailList { get => detailList; set => detailList = value; }
    }
    
    public class detalleCompra
    {
        private int numeroDetalle = 0, linea = 0; 
        private string nombre="",nombreUnidadMedida="";
        private double cantidad = 0,precioUnitario=0, descuentoP=0,
                           descuentoMDetalle=0, IVAp=0, IVAmDetalle=0, precioFinal=0;

        public int NumeroDetalle { get => numeroDetalle; set => numeroDetalle = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public string NombreUnidadMedida { get => nombreUnidadMedida; set => nombreUnidadMedida = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double DescuentoP { get => descuentoP; set => descuentoP = value; }
        public double DescuentoMDetalle { get => descuentoMDetalle; set => descuentoMDetalle = value; }
        public double IVAp1 { get => IVAp; set => IVAp = value; }
        public double IVAmDetalle1 { get => IVAmDetalle; set => IVAmDetalle = value; }
        public double PrecioFinal { get => precioFinal; set => precioFinal = value; }
        public int Linea { get => linea; set => linea = value; }
    }
    [ComVisible(true), Guid("7DEE7A79-C1C6-41E0-9989-582D97E0D9F4")]
    public class FEControladorLibrary
    {
        private string rutaBDLocal;
        private string rutaServidor;
        private string rutaComprasAceptar;
        private string rutaComprasRechazar;
        private string rutaComprasAceptadas;
        private string rutaComprasRechazadas;

        private string cedula;
        private string contrasena;
        private string direccion;
        private string email;
        private string fax;
        private string llaveCriptografica;
        private string nombre;
        private string numAfiliado1;
        private string pinLlaveCriptografica;
        private string telefono;
        private string usuarioHacienda;
        private string barrio;
        private string distrito;
        private string provincia;
        private string canton;
        private string sucursal;
        private string caja;
        private string codigoSeguridad;

        public FEControladorLibrary()
        {

        }
        private string numAfiliado;
        private void setNumAfiliado(string numAfiliado)
        {
            this.numAfiliado = numAfiliado;
        }
        private string getNumAfiliado()
        {
#if DEBUGLOCAL
              return "21";
#else
            //return this.demeNumeroDeAfiliadoLocal();
            return this.numAfiliado;
#endif
        }

        private Stream dataStream;
        private string getConnectionString()
        {
#if SISFAC
#if OLE12
#if JET
            return @"Provider=Microsoft.JET.OLEDB.12.0;" +
       @"Data source= " + RutaBDLocal;
        
#else   
#if DEBUGA
            MessageBox.Show(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source= " + RutaBDLocal);
#endif              
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data source= " + RutaBDLocal;
#endif
#else
#if ACE
            return @"Provider=Microsoft.ACE.OLEDB.4.0;" +
       @"Data source= " + RutaBDLocal;
#else
            return @"Provider=Microsoft.Jet.OLEDB.4.0;" +
       @"Data source= " + RutaBDLocal;
#endif
#endif
#else
#if DEBUGA
            MessageBox.Show("User=SYSDBA;" +
             "Password=masterkey;" +
             "Database=" + RutaBDLocal + ";" +
             "DataSource=localhost;" +
             "Port=3050;" +
             "Dialect=3;" +
             "Charset=NONE;" +
             "Role=;" +
             "Connection lifetime=15;" +
             "Pooling=true;" +
             "MinPoolSize=0;" +
             "MaxPoolSize=50;" +
             "Packet Size=8192;" +
             "ServerType=0");
#endif         
            return "User=SYSDBA;" +
             "Password=masterkey;" +
             "Database=" + RutaBDLocal + ";" +
             "DataSource=localhost;" +
             "Port=3050;" +
             "Dialect=3;" +
             "Charset=NONE;" +
             "Role=;" +
             "Connection lifetime=15;" +
             "Pooling=true;" +
             "MinPoolSize=0;" +
             "MaxPoolSize=50;" +
             "Packet Size=8192;" +
             "ServerType=0";
#endif
        }


        private string queryEmpresaYSucursalSysfac = "select VALOR AS RAZON_SOCIAL," +
                                               " VALOR AS NOMBRE" +
                                               " from PARAMETRO " +
                                               " where ID = 'NOMBRE'";

        private static readonly string[] parametrosSysfac = {"NOMBRE", "UBICACION_1", "UBICACION_2", "UBICACION_3", "UBICACION_4",
                                                        "LLAVE_CRIPTOGRAFICA","PIN_CRIPTOGRAFICA",
                                                        "USUARIO_HACIENDA", "CLAVE_HACIENDA","NOMBRE","TELEFONO",
                                                        "FAX", "DIRECCION", "EMAIL","CEDULA", "NUM_SUCURSAL","LIC_AFILIADO",
                                                        "ACTUALIZAR_FACTURAS_AUTO"};
        

        public string RutaBDLocal { get => rutaBDLocal; set => rutaBDLocal = value; }
        public string RutaServidor { get => rutaServidor; set => rutaServidor = value; }
        public string RutaComprasAceptar { get => rutaComprasAceptar; set => rutaComprasAceptar = value; }
        public string RutaComprasRechazar { get => rutaComprasRechazar; set => rutaComprasRechazar = value; }
        public string RutaComprasAceptadas { get => rutaComprasAceptadas; set => rutaComprasAceptadas = value; }
        public string RutaComprasRechazadas { get => rutaComprasRechazadas; set => rutaComprasRechazadas = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => Email1; set => Email1 = value; }
        public string Email1 { get => email; set => email = value; }
        public string Fax { get => fax; set => fax = value; }
        public string LlaveCriptografica { get => llaveCriptografica; set => llaveCriptografica = value; }
        public string Nombre { get => Nombre1; set => Nombre1 = value; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public string NumAfiliado { get => numAfiliado1; set => numAfiliado1 = value; }
        public string PinLlaveCriptografica { get => pinLlaveCriptografica; set => pinLlaveCriptografica = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string UsuarioHacienda { get => usuarioHacienda; set => usuarioHacienda = value; }
        public string Barrio { get => barrio; set => barrio = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Canton { get => canton; set => canton = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }
        public string Caja { get => caja; set => caja = value; }
        public string CodigoSeguridad { get => codigoSeguridad; set => codigoSeguridad = value; }

        private string demeQueryFacturasSysfacAuxiliar()
        {
            string tabla = "TB_FACTURASCLIENTESENCABEZADO";
            string whereEstatus = "CODIGOESTADO IN(2, 3, 4)";
#if SISFAC
            string query = "SELECT F.NUMERO, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CEDULA FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT DIRECCION FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS DIRECCION_CLIENTE, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS NOMBRE," +                   
                   " 4 as ESTATUS FROM " + tabla + " F WHERE CODIGO_CLOUD = -1 AND " +
            whereEstatus;
#else
            string query = "SELECT " +
                    "F.ID, " +
                    "F.NUMERO, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CODIGO FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS NOMBRE, 4 as ESTATUS FROM " + tabla + " F WHERE CODIGO_CLOUD = -1 AND " +
                                       whereEstatus;
#endif
#if QUERYFAC
            MessageBox.Show(query);

#endif
            return query;
        }
    
        private string demeQueryFacturasSysfac()
        {
            string tabla = "TB_FACTURASCLIENTESENCABEZADO";                        
            string whereEstatus = "CODIGOESTADO IN(2, 3, 4)";
#if SISFAC
            string query = "SELECT F.NUMERO, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CEDULA FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT DIRECCION FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS DIRECCION_CLIENTE, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS NOMBRE," +
                   " (SELECT DESCRIPCION1 FROM TB_FACTURASCLIENTESDETALLE WHERE NUMERO = F.NUMERO WHERE Len(DESCRIPCION1) > 0) AS DESCRIPCION1, " +
                   " (SELECT DESCRIPCION2 FROM TB_FACTURASCLIENTESDETALLE WHERE NUMERO = F.NUMERO WHERE Len(DESCRIPCION2) > 0) AS DESCRIPCION2 " +
                   " 4 as ESTATUS FROM " + tabla + " F WHERE CODIGO_CLOUD = -1 AND " +
            whereEstatus;
#else
            string query = "SELECT " +
                    "F.ID, " +
                    "F.NUMERO, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CODIGO FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE ID = F.IDCLIENTE), " +                   
                   " AS NOMBRE, " +
                   " (SELECT COALESCE(CLAVE, -1) FROM TB_DOCUMENTOSHACIENDA WHERE IDENCABEZADO = F.NUMERO) " +
                   " AS CLAVE, " +
                   " 4 as ESTATUS FROM " + tabla + " F WHERE F.CODIGO_CLOUD = -1 AND " +
                                       whereEstatus;
#endif
#if QUERYFAC
            MessageBox.Show(query);

#endif
            return query;
            
        }

        private string demeQueryNotasCreditoSysfac()
        {

#if SISFAC
            string tabla = "TB_FACTURASCLIENTESENCABEZADO";
            string query = "SELECT F.NUMERO, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CEDULA FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE CODIGO = F.CODIGOCLIENTE) " +
                   " AS NOMBRE, 1 as ESTATUS FROM " + tabla + " F WHERE CODIGOESTADO = 3  AND " +
                   " CODIGO_CLOUD <> -1 AND CODIGO_CLOUD_NC = -1";
#else
            string tabla = "TB_NOTASCREDITOENCABEZADO";
            string query = "SELECT F.NUMERODOCUMENTO AS NUMERO, F.NUMERO AS NUMEROR, F.FECHA, " +
                   " (SELECT EMAIL FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CORREO, " +
                   " (SELECT CEDULA FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS CEDULA, " +
                   " (SELECT NOMBRECOMPLETO FROM TB_CLIENTES WHERE ID = F.IDCLIENTE) " +
                   " AS NOMBRE, 1 as ESTATUS FROM " + tabla + " F WHERE CODIGO_CLOUD = -1";
#endif
            return query;

        }

       /* private actualizarDescuentoPorLinea()
        {
            string 
        }*/

        
        
        private string demeQueryDetalleSysfac(int doc, bool NC)
        {
            string tabla = "";
#if !SISFAC
            if (NC)
                tabla = "TB_NOTASCREDITODETALLE";
                        else
#endif

            tabla = "TB_FACTURASCLIENTESDETALLE";
#if SISFAC
            string query = "SELECT ID AS CODIGO, IVAP/100 AS IV, 0 AS IMP_SERV," +
                   " NOMBRE AS PRODUCTO, " +
                   " (PRECIOUNITARIOFINAL - IVAM) AS PRECIO_UNITARIO, CANTIDAD, " +
                   "SWITCH(det.descuentoP > 0, descuentoP, det.descuentoP = 0, (select descuentop from TB_FACTURASCLIENTESENCABEZADO" +
                   " WHERE NUMERO = " + doc +  " ))" +
                   " AS DESCUENTO " +
                   " FROM " + tabla + " DET " +
                   " WHERE NUMERO = " + doc + " ORDER BY ID DESC";
#else
            /*       CASE<expression>
          WHEN<exp1> THEN result1
          WHEN<exp2> THEN result2
         ...

         [ELSE defaultresult]
       END*/
#if SISFAC
            string query = "SELECT ID AS CODIGO, IVAP/100 AS IV, 0 AS IMP_SERV," +
                   " NOMBRE AS PRODUCTO, " +
                   " (PRECIOUNITARIOFINAL - IVAM) AS PRECIO_UNITARIO, CANTIDAD, " +
                   "(CASE WHEN det.descuentoP > 0 THEN descuentoP ELSE  (select descuentop from TB_FACTURASCLIENTESENCABEZADO" +
                   " WHERE NUMERO = " + doc + ") END" +
                   ") AS DESCUENTO " +
                   " FROM " + tabla + " DET " +
                   " WHERE NUMERO = " + doc + " ORDER BY ID DESC";
#else
            string query = "SELECT ID AS CODIGO, IVAP/ 100 AS IV, 0 AS IMP_SERV," +
                     "NOMBRE AS PRODUCTO," +
      "(PRECIOUNITARIOFINAL) AS PRECIO_UNITARIO, CANTIDAD," +
                    "(CASE WHEN det.descuentoP > 0 " +

                               "THEN descuentoP" +

                          " ELSE(select (descuentom/(SELECT SUM(PRECIOUNITARIOFINAL * CANTIDAD) FROM TB_FACTURASCLIENTESDETALLE" +
                          " WHERE NUMERO = " + doc +
                          ")) * 100  from TB_FACTURASCLIENTESENCABEZADO " +

                    " WHERE NUMERO = " + doc + ") END" +
                    " ) AS DESCUENTO " +
                    " FROM TB_FACTURASCLIENTESDETALLE det " +
                    " WHERE NUMERO = " + doc + " ORDER BY ID DESC";
#endif
#endif
#if DEBUGA
            MessageBox.Show(query);
#endif
            return query;
        }


        private string demeQueryTipoPagoSysfac(int factura)
        {

#if SISFAC
            string where = " WHERE NUMERO = " + factura;
            return "SELECT CODIGOFORMAPAGO AS TIPO_PAGO,TOTAL AS MONTO,NUMERO AS COD_FACTURA " +
                "FROM TB_FACTURASCLIENTESENCABEZADO" + where;
#else
            string where = " WHERE ID = " + factura;
            return "SELECT 1 AS TIPO_PAGO, EFECTIVO AS MONTO, ID AS COD_FACTURA FROM TB_FACTURASCLIENTESENCABEZADO " + where + " UNION " +
                   "SELECT 2 AS TIPO_PAGO, TARJETA AS MONTO, ID AS COD_FACTURA FROM TB_FACTURASCLIENTESENCABEZADO " + where + " UNION " +
                   "SELECT 4 AS TIPO_PAGO, TRANSFERENCIA AS MONTO, ID AS COD_FACTURA FROM TB_FACTURASCLIENTESENCABEZADO " + where + " UNION " +
                   "SELECT 3 AS TIPO_PAGO, CHEQUE AS MONTO, ID AS COD_FACTURA FROM TB_FACTURASCLIENTESENCABEZADO" + where;
#endif
        }


        public string enviar(String row, String action,bool xml= false)
        {
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(RutaServidor);
                req.Method = "POST";                
                string postData = "action=" + action + "&AFILIADO=" + this.NumAfiliado + "&" + row;
#if DEBUGA
                MessageBox.Show(postData);
#endif
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);


                // Set the ContentType property of the WebRequest.
                /*if (xml)
                  req.ContentType = "text/xml";
                else*/
                req.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.
                req.ContentLength = byteArray.Length;

                dataStream = req.GetRequestStream();

                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                dataStream.Close();

                // Get the original response.
                WebResponse response = req.GetResponse();

                //this.Status = ((HttpWebResponse)response).StatusDescription;

                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();
#if DEBUGA
                MessageBox.Show(responseFromServer);
#endif
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception ex)
            {
#if DEBUGA
                MessageBox.Show(ex.Message);
#endif
                return ex.Message.ToString();
            }
        }

        public void actualizarSucursalAbajo(string valor)
        {
            //
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {

#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
#else
                using (FbCommand cmd = connection.CreateCommand())
#endif
                {
                    cmd.CommandText = "DELETE FROM PARAMETRO WHERE ID = 'LIC_AFILIADO'";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    cmd.CommandText = "INSERT INTO PARAMETRO VALUES ('LIC_AFILIADO', @Valor) ";
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void enviarCompraANube(string filename, bool aceptada, string consecutivo)
        {
            
            XmlDocument docOrigen = new XmlDocument();
            string ruta = "";
            if (aceptada)
                ruta = KnownFolders.GetPath(KnownFolder.Downloads) + "\\Aceptar\\";
            else
                ruta = KnownFolders.GetPath(KnownFolder.Downloads) + "\\Rechazar\\";
            docOrigen.Load(ruta + filename);
            XmlElement docOrigenElement = docOrigen.DocumentElement;            
            XmlDocument docDestino = new XmlDocument();

            XmlSerializer xsSubmit = new XmlSerializer(typeof(MensajeReceptor));
            var mReceptor = new MensajeReceptor();
            mReceptor.Clave = docOrigenElement.GetElementsByTagName("Clave").Item(0).InnerText;
            mReceptor.FechaEmisionDoc = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss");            
            try
            {
                mReceptor.MontoTotalImpuesto = docOrigenElement.GetElementsByTagName("TotalImpuesto").Item(0).InnerText;
            }
            catch
            {
                mReceptor.MontoTotalImpuesto = "0.00000";
            }
            mReceptor.NumeroCedulaEmisor = docOrigenElement.GetElementsByTagName("Numero").Item(0).InnerText;
            mReceptor.NombreEmisor = docOrigenElement.GetElementsByTagName("Nombre").Item(0).InnerText;
            try
            {
                mReceptor.NumeroCedulaReceptor = docOrigen.GetElementsByTagName("Numero").Item(1).InnerText;
            }
            catch
            {
                MessageBox.Show("La aceptación o rechazo de la compra no se pueden procesar porque el XML recibido no contiene cédula del receptor");
            }
            mReceptor.NumeroConsecutivoReceptor = consecutivo; 
            mReceptor.TotalFactura = docOrigen.GetElementsByTagName("TotalComprobante").Item(0).InnerText;            
            //mReceptor.MontoTotalImpuesto = doc
            if (aceptada)
                mReceptor.Mensaje = "1";
            else
                mReceptor.Mensaje = "2";
                        
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, mReceptor);
                   
                    xml = sww.ToString().Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">", "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/mensajeReceptor\">").Replace("utf-16", "utf-8"); // Your XML
                    xml = xml.ToString().Replace("xmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns: xsd = \"http://www.w3.org/2001/XMLSchema\">", "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/mensajeReceptor\">").Replace("utf-16", "utf-8"); // Your XML
                    xml = xml.ToString().Replace("xmlns: ds = \"http://www.w3.org/2000/09/xmldsig#\" xmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\">", "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/mensajeReceptor\">").Replace("utf-16", "utf-8");
                }
            }            
            string valor = enviar("xml=" + xml + "&correo=" + docOrigenElement.GetElementsByTagName("CorreoElectronico").Item(0).InnerText,"firmarYEnviarCompra",true);
            try
            {
                //MessageBox.Show(valor);
                if (Int32.Parse(valor) == 5)
                    try {
                        File.Delete(ruta + filename);
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                    }
            }
                    catch (Exception e)
                    {
#if DEBUGA
                        //MessageBox.Show(e.Message);
#endif
                    }
            
        }

        public void insertarCompras(bool aceptada = true)
        {
#if DEBUGA
            MessageBox.Show("Ingresa a función insertando Compras");
#endif
            this.setNumAfiliado(this.demeNumeroDeAfiliadoLocal());
#if DEBUGA
            MessageBox.Show("Pasó por primera función de setear afiliado");
#endif
            this.NumAfiliado = this.demeNumeroDeAfiliadoLocal();
#if DEBUGA
            MessageBox.Show("Num AFiliado Asignado: " + this.NumAfiliado);
#endif        
            Directory.CreateDirectory(KnownFolders.GetPath(KnownFolder.Downloads) + "\\Aceptar");
            Directory.CreateDirectory(KnownFolders.GetPath(KnownFolder.Downloads) + "\\Rechazar");

            
            DirectoryInfo d = (aceptada) ? new DirectoryInfo(KnownFolders.GetPath(KnownFolder.Downloads) + "\\Aceptar") : new DirectoryInfo(KnownFolders.GetPath(KnownFolder.Downloads) + "\\Rechazar");            
            FileInfo[] Files = d.GetFiles("*.xml"); //Getting Text files                            
            foreach (FileInfo file in Files)
            {


                compra encabezado = new compra();
                encabezado.CodigoEstado = (aceptada) ? encabezado.CodigoEstado = 2 : encabezado.CodigoEstado = 3;                

                encabezado.Subtotal = 0;
#if SISFAC
                using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
                using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
                {                    
#if SISFAC
                    DataTable dt = demeDtConQuery("SELECT MAX(NUMERO) + 1 FROM TB_ENTRADASENCABEZADO");
#else
                    DataTable dt = demeDtConQuery("SELECT COALESCE (MAX(NUMERO),0) + 1 FROM TB_COMPRASENCABEZADO");
#endif
                    try
                    {
                        encabezado.Numero = dt.Rows[0][0].ToString();
                    }
                    catch
                    {
                        encabezado.Numero = "1";
                    }
                    string fileName = file.Name;
                    try
                    {
                        enviarCompraANube(fileName, aceptada, encabezado.Numero);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    string ruta = "";
                    if (aceptada)
                        ruta = KnownFolders.GetPath(KnownFolder.Downloads) + "\\Aceptar\\";
                    else
                        ruta = KnownFolders.GetPath(KnownFolder.Downloads) + "\\Rechazar\\"; ;
                    /*XmlTextReader reader = new XmlTextReader(ruta + fileName);
                    while (reader.Read())
                    {

                        if (reader.NodeType == XmlNodeType.Element) // The node is an element.
                            switch (reader.Name)
                            {
                                case "FechaEmision":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.Fecha = reader.Value.Substring(0, 10);
                                        encabezado.Hora = reader.Value.Substring(11, 8);
                                    }
                                    break;
                                case "TotalExento":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.Subtotal += float.Parse(reader.Value, CultureInfo.InvariantCulture.NumberFormat);
                                        encabezado.TotalExento = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case "TotalGravado":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.Subtotal += float.Parse(reader.Value, CultureInfo.InvariantCulture.NumberFormat);
                                        encabezado.TotalGravado = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case "TotalDescuentos":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.DescuentoM = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case "TotalImpuesto":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.IVAm1 = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case "TotalComprobante":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        encabezado.Total = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case "CondicionVenta":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        if (reader.Value == "02")
                                            encabezado.CodigoFormaPago = 5;
                                    }
                                    break;
                                case "MedioPago":
                                    reader.Read();
                                    if ((reader.NodeType == XmlNodeType.Text) && (encabezado.CodigoFormaPago != 5))
                                    {
                                        switch (reader.Value)
                                        {
                                            case "01":
                                                encabezado.CodigoFormaPago = 1;
                                                break;
                                            case "02":
                                                encabezado.CodigoFormaPago = 2;
                                                break;
                                            case "03":
                                                encabezado.CodigoFormaPago = 3;
                                                break;
                                        }

                                    }
                                    break;
                                case "CodigoMoneda":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        switch (reader.Value)
                                        {
                                            case "CRC":
                                                encabezado.CodigoMoneda = 1;
                                                break;
                                            case "USD":
                                                encabezado.CodigoMoneda = 2;
                                                break;
                                        }
                                    }
                                    break;                                
                                case "NumeroLinea":
                                    encabezado.DetailList.Add(new detalleCompra());
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                    {
                                        linea = Int32.Parse(reader.Value) - 1;
                                        encabezado.DetailList[linea].Linea = linea + 1;
                                        encabezado.DetailList[linea].NumeroDetalle = Int32.Parse(encabezado.Numero);
                                    }
                                    break;
                                case "Detalle":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].Nombre = reader.Value;
                                    break;
                                case "Cantidad":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].Cantidad = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "UnidadMedida":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].NombreUnidadMedida = reader.Value;
                                    break;
                                case "PrecioUnitario":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].PrecioUnitario = Convert.ToDouble(reader.Value,CultureInfo.InvariantCulture);
                                    break;
                                case "MontoDescuento":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].DescuentoMDetalle = Convert.ToDouble(reader.Value,CultureInfo.InvariantCulture);
                                    break;
                                case "Tarifa":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].IVAp1 = Convert.ToDouble(reader.Value,CultureInfo.InvariantCulture);
                                    break;
                                case "Monto":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].IVAmDetalle1 = Convert.ToDouble(reader.Value,CultureInfo.InvariantCulture);
                                    break;
                                case "MontoTotalLinea":
                                    reader.Read();
                                    if (reader.NodeType == XmlNodeType.Text)
                                        encabezado.DetailList[linea].PrecioFinal = Convert.ToDouble(reader.Value,CultureInfo.InvariantCulture);
                                    break;
                            }

                    }
                    reader.Close();*/
                }
#if SISFAC
                //insertarComprasEnBD(encabezado);
#endif
            }
        }

        public void moverCompras(DirectoryInfo d)
        {
            foreach (FileInfo file in d.GetFiles())
            {
                file.Delete();
            }
        }

        public void insertarDetalleComprasEnBD(List<detalleCompra> detallecompra)
        {
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {
#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
#else
                using (FbCommand cmd = connection.CreateCommand())
#endif
                {
                    foreach (detalleCompra detalle in detallecompra)
                    {
                        cmd.CommandText = "Insert into tb_entradasdetalle (precioUnitarioFinal,codigoUnidadMedida,codigoEmpresa, codigoSucursal,numero, nombre,cantidad,nombreUnidadMedida,precioUnitario," +
                            "DescuentoP, DescuentoM,IVAP, IVAM,PrecioFinal,Linea)" +
                                          "VALUES (@precioUnitarioFinal,@codigoUnidadMedida,@codigoEmpresa,@codigoSucursal,@numero, @nombre,@cantidad,@nombreUnidadMedida,@precioUnitario," +
                            "@DescuentoP, @DescuentoM,@IVAP, @IVAM,@PrecioFinal,@Linea)";
                        cmd.Parameters.AddWithValue("@precioUnitarioFinal", 0);
                        cmd.Parameters.AddWithValue("@codigoUnidadMedida", 0);
                        cmd.Parameters.AddWithValue("@codigoEmpresa", 0);
                        cmd.Parameters.AddWithValue("@codigoSucursal", 0);
                        cmd.Parameters.AddWithValue("@numero", detalle.NumeroDetalle);
                        cmd.Parameters.AddWithValue("@nombre", detalle.Nombre);
                        cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmd.Parameters.AddWithValue("@nombreUnidadMedida", detalle.NombreUnidadMedida);
                        cmd.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@DescuentoP", detalle.DescuentoP);
                        cmd.Parameters.AddWithValue("@DescuentoM", detalle.DescuentoMDetalle);
                        cmd.Parameters.AddWithValue("@IVAP", detalle.IVAp1);
                        cmd.Parameters.AddWithValue("@IVAM", detalle.IVAmDetalle1);
                        cmd.Parameters.AddWithValue("@PrecioFinal", detalle.PrecioFinal);
                        cmd.Parameters.AddWithValue("@Linea", detalle.Linea);
                        cmd.Connection.Close();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();                        
                        try
                        {
#if DEBUGA
                        MessageBox.Show(cmd.CommandText);
#endif

                        }
                        catch (Exception e)
                        {
#if DEBUGA
                        MessageBox.Show(e.Message);
#endif
                        }
                    }
                }
            }
        }

        public void insertarComprasEnBD(compra laCompra)
        {
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {
#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
#else
                using (FbCommand cmd = connection.CreateCommand())
#endif
                {
                    cmd.CommandText = "Insert into tb_entradasencabezado (codigoEmpresa,codigoSucursal,numero,numeroS, fecha,hora,subtotal,descuentoM,IVAM,Total," +
                                      " TotalGravado, TotalExcento, CodigoMoneda, CodigoTipo, CodigoEstado,CodigoFormaPago,CodigoImpresa)" +
                                      "VALUES (@codigoEmpresa,@codigoSucursal,@numero,@numeroS,@fecha,@hora,@subtotal,@descuentoM,@IVAM,@Total,@TotalGravado," +
                                      "@TotalExcento, @CodigoMoneda, @CodigoTipo, @CodigoEstado, @CodigoFormaPago,2)";
                    cmd.Parameters.AddWithValue("@codigoEmpresa", 0);
                    cmd.Parameters.AddWithValue("@codigoSucursal", 0);
                    cmd.Parameters.AddWithValue("@numero", laCompra.Numero);
                    cmd.Parameters.AddWithValue("@numeroS", laCompra.Numero);
                    cmd.Parameters.AddWithValue("@fecha", laCompra.Fecha);
                    cmd.Parameters.AddWithValue("@hora", laCompra.Hora);
                    cmd.Parameters.AddWithValue("@subtotal", laCompra.Subtotal);                    
                    cmd.Parameters.AddWithValue("@descuentoM", laCompra.DescuentoM);
                    cmd.Parameters.AddWithValue("@IVAM", laCompra.IVAm1);
                    cmd.Parameters.AddWithValue("@Total", laCompra.Total);
                    cmd.Parameters.AddWithValue("@TotalGravado", laCompra.TotalGravado);
                    cmd.Parameters.AddWithValue("@TotalExcento", laCompra.TotalExento);
                    cmd.Parameters.AddWithValue("@CodigoMoneda", laCompra.CodigoMoneda);                    
                    cmd.Parameters.AddWithValue("@CodigoTipo", 1);
                    cmd.Parameters.AddWithValue("@CodigoEstado", laCompra.CodigoEstado);
                    cmd.Parameters.AddWithValue("@CodigoFormaPago", laCompra.CodigoFormaPago);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    insertarDetalleComprasEnBD(laCompra.DetailList);
                    try
                    {
#if DEBUGA
                        MessageBox.Show(cmd.CommandText);
#endif

                    }
                    catch (Exception e)
                    {
#if DEBUGA
                        MessageBox.Show(e.Message);
#endif
                    }
                }
            }
        }

        public void actualizarParametro(string param, string valor = "")
        {            
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {
#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
#else
                using (FbCommand cmd = connection.CreateCommand())
#endif
                {
                    DataTable dt = new DataTable();
#if SISFAC
                    OleDbDataAdapter da = new OleDbDataAdapter("select VALOR from PARAMETRO WHERE ID = '" + param + "'",
                       getConnectionString());
#else
                    FbDataAdapter da = new FbDataAdapter("select VALOR from PARAMETRO WHERE ID = '" + param + "'",
                    getConnectionString());
#endif
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        if (valor == "")
                            valor = enviar("tipo=" + param + "&" + param + "=-1", "parametro");
                        cmd.CommandText = "INSERT INTO PARAMETRO VALUES (@ID, @Valor)";
                        cmd.Parameters.AddWithValue("@ID", param);
                        cmd.Parameters.AddWithValue("@Valor", valor);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (valor == "")
                            valor = enviar("tipo=" + param + "&" + param + "=" + Uri.EscapeDataString(dt.Rows[0]["VALOR"].ToString()), "parametro");
                        if (dt.Rows[0]["VALOR"].ToString() == "-1")
                        {
                            cmd.CommandText = "UPDATE PARAMETRO set valor = @Valor WHERE ID = '" + param + "'";
                            cmd.Parameters.AddWithValue("@Valor", valor);
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            }
        }

        public void crearTabla(string tabla, string columnas)
        {
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            DataTable dt = demeDtConQuery("select 1 from rdb$relations where rdb$relation_name = '" + tabla + "'");
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif


            {
#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT TOP 1 date FROM " + tabla;
                    connection.Open();
                    try
                    {
                        var x = cmd.ExecuteScalar();
                    }
                    catch 
                    { }
#else
                using (FbCommand cmd = connection.CreateCommand())
                {
#endif


#if SISFAC
                        using (OleDbCommand cmdAddTable = connection.CreateCommand())
#else
                    using (FbCommand cmdAddTable = connection.CreateCommand())
#endif
                    {
                        cmdAddTable.CommandText = "CREATE TABLE " + tabla + "" + columnas;
                        cmdAddTable.Connection.Open();
                        cmdAddTable.ExecuteNonQuery();
                    }                
                }
            }

        }

        public void insertarColumna(string tabla, string columna, string tipoDato)
        {             
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
DataTable dt = demeDtConQuery("select 1 from RDB$RELATION_FIELDS rf " +
                                          "where rf.RDB$RELATION_NAME = '" + tabla +
                                          "' and rf.RDB$FIELD_NAME = '" + columna + "'");
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {
#if !SISFAC
                using (FbCommand cmd = connection.CreateCommand())
#endif

                {
#if !SISFAC
                    if (dt.Rows.Count == 0)
#endif
                    {
#if SISFAC
                        using (OleDbCommand cmdAddColumn = connection.CreateCommand())
#else
            using (FbCommand cmdAddColumn = connection.CreateCommand())
#endif
                        {
                            try
                            {
                                cmdAddColumn.CommandText = "ALTER TABLE " + tabla + " ADD " + columna + " " + tipoDato; ;
                                cmdAddColumn.Connection.Open();
                                cmdAddColumn.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                string ex = e.Message;
                            }
                        }
                    }
                }
            }
        }

        public void actualizarColumna(string tabla, string columna, string valor, string where = "")
        {
#if SISFAC
            using (OleDbConnection connection = new OleDbConnection(getConnectionString()))
#else
            using (FbConnection connection = new FbConnection(getConnectionString()))
#endif
            {
#if SISFAC
                using (OleDbCommand cmd = connection.CreateCommand())
#else
                using (FbCommand cmd = connection.CreateCommand())
#endif
                {
                    cmd.CommandText = "UPDATE " + tabla + " set " + columna + " = @Valor";
                    if (where != "")
                    {
                        cmd.CommandText += where;
                    }
                    try
                    {
#if DEBUGA
                        MessageBox.Show(cmd.CommandText);
#endif
                        cmd.Parameters.AddWithValue("@Valor", valor);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
#if DEBUGA
                        MessageBox.Show(e.Message);
#endif
                    }
                }
            }
        }

        public string demeParametro(string ID)
        {
            DataTable dt = new DataTable();
            try
            {

#if SISFAC
                string query = "select VALOR from PARAMETRO WHERE ID = \"" + ID + "\"";
                OleDbDataAdapter da = new OleDbDataAdapter(query,
                  getConnectionString());
#if DEBUGA 
                MessageBox.Show("Query para buscar afiliado:" + query);
#endif            
#else
                FbDataAdapter da = new FbDataAdapter("select COALESCE(VALOR,'-1') from PARAMETRO WHERE ID = '" + ID + "'",
                  getConnectionString());
#if DEBUGA
                MessageBox.Show("Query para buscar afiliado:" + "select COALESCE(VALOR,'-1') from PARAMETRO WHERE ID = '" + ID + "'",
                  getConnectionString());
#endif 
#endif
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataColumn col = dt.Columns[0];
                    return dt.Rows[0][col].ToString();
                }
                else
                {
                    return "-1";
                }
            }
            catch (Exception e)
            {
#if DEBUGA
                MessageBox.Show("Error en deme parámetro:" + ID + " " + e.Message);
#endif
                return "-1";
            }
        }
        public string demeNumeroDeAfiliadoLocal()
        {
            try
            {

                return demeParametro("LIC_AFILIADO");
            }
            catch 
            {
                MessageBox.Show("Falta asignar el LIC_AFILIADO en PARAMETRO");
                return "-1";
            }
        }   

        public int demeCodigoDeSucursalEnCloud()
        {
            return Int32.Parse(demeParametro("ID_SUCURSAL_EN_CLOUD"));
        }

        public DataTable demeDtConQuery(string query,string queryAux = "")
        {            
            DataTable dt = new DataTable();

#if SISFAC
            OleDbDataAdapter da = new OleDbDataAdapter(query,
   getConnectionString());

#else
            
                FbDataAdapter da = new FbDataAdapter(query,
                   getConnectionString());
#endif
            try
            {
                da.Fill(dt);
            }
            catch (Exception e)
            {
#if SISFAC
                try
                {
                    da = new OleDbDataAdapter(queryAux,getConnectionString());
                    da.Fill(dt);
                }
                catch(Exception e2)
                {
#if DEBUGA
                    MessageBox.Show("Error en demeDtConQuery " + query + " ERROR: " + e2.Message);
#endif
                }
#if DEBUGA
                //MessageBox.Show("Error en demeDtConQuery" + e.Message);
#endif
#else
                try
                {
                    da = new FbDataAdapter(query, getConnectionString());
                    da.Fill(dt);
                }
                catch (Exception e2)
                {
#if DEBUGA
                    MessageBox.Show("Error en demeDtConQuery" + e2.Message);
#endif
                }
#endif
            }
            return dt;
        }
        public string uploadSingleDataRow(String query, String action)
        {
            DataTable dt = demeDtConQuery(query);
            if (dt.Rows.Count > 1)
            {
                //se esperaba una sola fila o 0
                return "-1";
            }
            else
            {
                if (dt.Rows.Count == 0)
                    return "-1";
                String row = "";
                foreach (DataColumn col in dt.Columns)
                {
                    row += col.ColumnName + '=' + dt.Rows[0][col].ToString() + "&";
                }
                return enviar(row, action);
            }
        }
        public string uploadParameter(string parameter)
        {
            string valorParam = demeParametro(parameter);
            return enviar(parameter + "=" + valorParam, parameter);
        }

        public void actualizarParametrosSysfac()
        {
            foreach (string param in parametrosSysfac)
            {
                actualizarParametro(param);
            }
        }      


        public string actualizarDetalleSysfac(int factura, bool NC)
        {
                                            
            DataTable dt = demeDtConQuery(demeQueryDetalleSysfac(factura, NC));
            string szRow = "[";            
            foreach (DataRow row in dt.Rows)
            {
                szRow += "{";
                foreach (DataColumn col in dt.Columns)
                {
                    szRow += "\"" + col.ColumnName + "\":\"" + row[col].ToString().Replace("\"","").Replace("\r", "").Replace("\n","") + "\",";
                }
                szRow = szRow.Substring(0, szRow.Length - 1) + "},";                
            }
            szRow = szRow.Substring(0, szRow.Length - 1) + "]";
#if DEBUGA
            MessageBox.Show(szRow);
#endif
            return szRow;
        }
        

        public string actualizarTipoPagoSysfac(int factura)
        {
            DataTable dt = demeDtConQuery(demeQueryTipoPagoSysfac(factura));
            string szRow = "[";
            foreach (DataRow row in dt.Rows)
            {
                szRow += "{";
                foreach (DataColumn col in dt.Columns)
                {
                    if (row["MONTO"].ToString() != "0.000")
                        szRow += "\"" + col.ColumnName + "\":\"" + row[col].ToString() + "\",";
                }
                szRow = szRow.Substring(0, szRow.Length - 1) + "},";                
            }
            szRow = szRow.Substring(0, szRow.Length - 1) + "]";
            return szRow;
        }       

        public void actualizarFacturasSysfac()
        {
            //facturas          
#if DEBUGA
            MessageBox.Show("2");
#endif
            insertarColumna("TB_FACTURASCLIENTESENCABEZADO", "CODIGO_CLOUD", "INTEGER DEFAULT -1 NOT NULL");
#if DEBUGA
            MessageBox.Show("3");
#endif
            DataTable dt = demeDtConQuery(demeQueryFacturasSysfac(), demeQueryFacturasSysfacAuxiliar());
#if DEBUGA
            MessageBox.Show(dt.Rows.Count.ToString());
#endif

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string szRow = "";
                    foreach (DataColumn col in dt.Columns)
                    {
                        szRow += col.ColumnName + '=' + row[col].ToString() + "&";
                    }
#if DEBUGA
                    MessageBox.Show("Encabezado:" + szRow);
#endif
                    szRow += "detalle=" + actualizarDetalleSysfac(Int32.Parse(row["NUMERO"].ToString()), false) + "&";
                    szRow += "tipoPago=" + actualizarTipoPagoSysfac(Int32.Parse(row["NUMERO"].ToString()));

                    string codFacturaCloud = enviar(szRow, "encabezadoFactura");

                    actualizarColumna("TB_FACTURASCLIENTESENCABEZADO", "CODIGO_CLOUD",
                                      codFacturaCloud, " WHERE CODIGO_CLOUD = -1 AND NUMERO = " + row["NUMERO"]);

                }
            }
        }


        //
    

        public void actualizarNCSysfac()
        {
#if SISFAC
            insertarColumna("TB_FACTURASCLIENTESENCABEZADO", "CODIGO_CLOUD_NC", "INTEGER DEFAULT -1 NOT NULL");
#else
            insertarColumna("TB_NOTASCREDITOENCABEZADO", "CODIGO_CLOUD", "INTEGER DEFAULT -1 NOT NULL");
#endif

#if DEBUGA
            MessageBox.Show("Subiendo NC");
#endif
            DataTable dt = demeDtConQuery(demeQueryNotasCreditoSysfac());

#if DEBUGA
            MessageBox.Show(dt.Rows.Count.ToString());
#endif

            foreach (DataRow row in dt.Rows)
            {
                string szRow = "";
                foreach (DataColumn col in dt.Columns)
                {
                    szRow += col.ColumnName + '=' + row[col].ToString() + "&";
                }
#if DEBUGA
                MessageBox.Show(szRow);
#endif

#if SISFAC 
                szRow += "detalle=" + actualizarDetalleSysfac(Int32.Parse(row["NUMERO"].ToString()), true) + "&";
#else
               szRow += "detalle=" + actualizarDetalleSysfac(Int32.Parse(row["NUMEROR"].ToString()),true) + "&";
#endif                



                //szRow += "tipoPago=" + actualizarTipoPagoNCSysfac(Int32.Parse(row["NUMERODOCUMENTO"].ToString()));
                string codFacturaCloud = enviar(szRow, "encabezadoFactura");
#if SISFAC
                actualizarColumna("TB_FACTURASCLIENTESENCABEZADO", "CODIGO_CLOUD_NC",
                                  codFacturaCloud, " WHERE CODIGO_CLOUD_NC = -1 AND NUMERO = " + row["NUMERO"]);
#else

                actualizarColumna("TB_NOTASCREDITOENCABEZADO", "CODIGO_CLOUD",
                                  codFacturaCloud, " WHERE CODIGO_CLOUD = -1 AND NUMERO = " + row["NUMEROR"]);
#endif
            }
        }

        


        [ComVisible(true)]
        public string uploadSubsidiarySysfac(string numAfiliado)
        {           
            string row = "";
            //row += "NUM_AFILIADO=" + this.numAfiliado + "&";
            row += "NOMBRE=" + this.nombre.Replace("&", "%26") + "&";
            row += "CEDULA=" + this.cedula + "&";
            row += "TELEFONO=" + this.telefono + "&";
            row += "FAX=" + this.fax + "&";
            row += "DIRECCION=" + this.direccion.Replace("&", "%26") + "&";
            row += "EMAIL=" + this.email + "&";
            row += "SUCURSAL=" + this.sucursal + "&";
            row += "CAJA=" + this.caja + "&";
            row += "PROVINCIA=" + this.provincia + "&";
            row += "CANTON=" + this.canton + "&";
            row += "DISTRITO=" + this.distrito + "&";
            row += "BARRIO=" + this.barrio + "&";
            row += "LLAVE_CRIPTOGRAFICA=" + this.llaveCriptografica + "&";
            row += "PIN_CRIPTOGRAFICA=" + this.pinLlaveCriptografica + "&";
            row += "USUARIO_HACIENDA=" + this.usuarioHacienda + "&";
            row += "CODIGO_SEGURIDAD=" + this.codigoSeguridad + "&";
            row += "CONTRASENA_HACIENDA=" + this.contrasena.Replace("&", "%26");
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\FacturacionElectronica.exe";
            //MessageBox.Show(path);
            if (IsProcessOpen("FacturacionElectronica") == false)                
                System.Diagnostics.Process.Start(path);
#if DEBUGA
            MessageBox.Show("LIC_AFILIADO = " + numAfiliado);
#endif        
            actualizarParametro("LIC_AFILIADO", numAfiliado);

            return enviar(row, "sucursal");
             
            //uploadSingleDataRow(queryEmpresaYSucursalSysfac, "sucursal");
           // actualizarParametrosSysfac();

        }

        [ComVisible(true)]
        public string downloadSubsidiaryData()
        {
            actualizarParametrosSysfac();
            return "nada";
        }
        public bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

        [ComVisible(true)]
        public string uploadFacturasSysfac()
        {
#if DEBUGA
            MessageBox.Show("1");
#endif
            this.setNumAfiliado(this.demeNumeroDeAfiliadoLocal());
            this.NumAfiliado = this.demeNumeroDeAfiliadoLocal();

            actualizarFacturasSysfac();
            actualizarNCSysfac();
#if DEBUGA
            MessageBox.Show("100");
#endif
            enviar("nada=nada","COMPLETADA");
            return "nada";
        }
    }
}

