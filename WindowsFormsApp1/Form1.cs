//#define BISTRO
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            //FEControl.uploadData();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void inicializar()
        {
            cmbProvincia.SelectedValue = 1;
            cmbCanton.SelectedValue = 1;
            cmbDistrito.SelectedValue = 1;
            cmbBarrio.SelectedValue = 1;
            cmbEsCasaMatriz.SelectedValue = 1;
            cmbNumSucursal.SelectedValue = 1;
            txtCedula.Text = "";
            txtContrasenaHacienda.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtLlaveCriptografica.Text = "";
            txtNombre.Text = "";
            txtNumAfiliado.Text = "";
            txtPinLlaveCriptografica.Text = "";
            txtTelefono.Text = "";
            txtUsuarioHacienda.Text = "";
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();            
            //txtRutaBDLocal.Text = getRutaBDLocal();
            txtRutaServidor.Text = getRutaServidor();
        }
        public string getRutaServidor()
        {
            try
            {

                string path = @"rutaServidor.txt";
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            return s;
                        }
                    }
                }
                else
                {
                    return "";
                }
                return "";

            }

            catch
            {
                return "";
            }
        }
        public void setRutaServidor(string rutaServidor)
        {
            string path = @"rutaServidor.txt";

            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(path);
                }
                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(rutaServidor);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public string getRutaBDLocal()
        {
            try
            {

                string path = @"rutaBDLocal.txt";
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            return s;
                        }
                    }
                }
                else
                {
                    return "";
                }
                return "";
                
            }

            catch 
            {
                return "";
            }
        }
        public void setRutaBDLocal(string rutaBDLocal)
        { 
            string path = @"rutaBDLocal.txt";

            try
            {

                // Delete the file if it exists.

                // Create the file.
                using (StreamWriter sw = File.AppendText(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(rutaBDLocal + ";");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void agregarWireCrypt()
        {
             string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
             string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
             string agregar = "WireCrypt = Enabled";
             if (Directory.Exists(programFiles + "\\Firebird\\Firebird_3_0"))
             {
                 using (StreamWriter sw = File.AppendText(programFiles + "\\Firebird\\Firebird_3_0\\firebird.conf")) 
                 {
                     sw.WriteLine(agregar);
                 }
             }


             if (Directory.Exists(programFilesX86 + "\\Firebird\\Firebird_3_0"))
             {                 
                 using (StreamWriter sw = File.AppendText(programFilesX86 + "\\Firebird\\Firebird_3_0\\firebird.conf")) 
                 {
                     sw.WriteLine(agregar);
                 }
             }

        }

        private void btnSubirSucursal_Click(object sender, EventArgs e)
        {
            agregarWireCrypt();

            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            setRutaBDLocal(txtRutaBDLocal.Text);
            setRutaServidor(txtRutaServidor.Text);
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            FEControl.RutaServidor = txtRutaServidor.Text;
            FEControl.Cedula = txtCedula.Text;
            FEControl.Contrasena = txtContrasenaHacienda.Text;
            FEControl.Direccion = txtDireccion.Text;
            FEControl.Email = txtEmail.Text;
            FEControl.Fax = txtFax.Text;
            FEControl.LlaveCriptografica = txtLlaveCriptografica.Text;
            FEControl.Nombre = txtNombre.Text;
            FEControl.NumAfiliado = txtNumAfiliado.Text;
            FEControl.PinLlaveCriptografica = txtPinLlaveCriptografica.Text;
            FEControl.Telefono = txtTelefono.Text;
            FEControl.UsuarioHacienda = txtUsuarioHacienda.Text;
            FEControl.Barrio = cmbBarrio.Text;
            FEControl.Distrito = cmbDistrito.Text;
            FEControl.Provincia = cmbProvincia.Text;
            FEControl.Canton = cmbCanton.Text;
            //Los 2 nombres siguientes parecen no coincidir, pero lo que está malo es el nombre
            FEControl.Sucursal = cmbEsCasaMatriz.Text;
            FEControl.Caja = cmbNumSucursal.Text;
            FEControl.CodigoSeguridad = txtCodigoSeguridad.Text;
            FEControl.NumAfiliado = txtNumAfiliado.Text;
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            //
            try
            {
                FEControl.crearTabla("PARAMETRO", " (ID VARCHAR(30),VALOR VARCHAR(80))");
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
            string suc = FEControl.uploadSubsidiarySysfac(txtNumAfiliado.Text);
            try
            {
                Int32.Parse(suc);
                MessageBox.Show("Datos cargados con éxito en " + txtRutaServidor.Text);
            }
            catch
            {
                MessageBox.Show(suc);
            }
            
            //inicializar();
            }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            
        }

        private void subirProdsYFact_Tick(object sender, EventArgs e)
        {
            
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            FEControl.RutaServidor = txtRutaServidor.Text;
            try
            {
                //if (FEControl.demeParametro("ACTUALIZAR_FACTURAS_AUTO") == "1")
                {
                    //FEControl.uploadFacturasSysfac();
                }
            }
            finally
            {

            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            //subirProdsYFact.Enabled = false;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            //subirProdsYFact.Enabled = true;
        }

        private void btnSubirProductos_Click(object sender, EventArgs e)
        {
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            FEControl.RutaServidor = txtRutaServidor.Text;
            //FEControl.uploadProductsSysfac();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            FEControl.RutaServidor = txtRutaServidor.Text;
            //FEControl.uploadFacturasSysfac();
            //FEControl.actualizarColumna("PARAMETRO", "VALOR", "1", " WHERE ID = 'ENVIAR_FACTURAS_AUTO'");
            MessageBox.Show("Facturas cargadas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FEControlador.FEControladorLibrary FEControl = new FEControlador.FEControladorLibrary();
            FEControl.RutaBDLocal = txtRutaBDLocal.Text;
            FEControl.RutaServidor = txtRutaServidor.Text;
            FEControl.crearTabla("PARAMETRO", " (ID VARCHAR(30),VALOR VARCHAR(80))");
            //FEControl.actualizarColumna("PARAMETRO", "VALOR", txtNumAfiliado.Text, " WHERE ID = 'LIC_AFILIADO'");
        }

        private void tbRutaServidor_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (txtPassword.Text == "D1b02A2019*")
            {
                btnAsignarRutaServidor.Visible = true;
                txtRutaServidor.Visible = true;
                lblRutaServidor.Visible = true;
                txtClientesPermitidos.Visible = true;
                lblClientesPermitidos.Visible = true;
            }
            else
            {

            }
        }

        private void btnAsignarRutaServidor_Click(object sender, EventArgs e)
        {
            setRutaServidor(txtRutaServidor.Text);
            MessageBox.Show("Texto Asignado");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtRutaBDLocal.Text = openFileDialog1.FileName;
        }
    }
}
