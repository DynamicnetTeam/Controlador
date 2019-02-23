namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCodigoSeguridad = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRutaBDLocal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSubirSucursal = new System.Windows.Forms.Button();
            this.txtContrasenaHacienda = new System.Windows.Forms.TextBox();
            this.txtUsuarioHacienda = new System.Windows.Forms.TextBox();
            this.txtPinLlaveCriptografica = new System.Windows.Forms.TextBox();
            this.txtLlaveCriptografica = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbBarrio = new System.Windows.Forms.ComboBox();
            this.cmbDistrito = new System.Windows.Forms.ComboBox();
            this.cmbCanton = new System.Windows.Forms.ComboBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.cmbNumSucursal = new System.Windows.Forms.ComboBox();
            this.cmbEsCasaMatriz = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRutaServidor = new System.Windows.Forms.TabPage();
            this.lblCodigoSeguridad = new System.Windows.Forms.Label();
            this.txtClientesPermitidos = new System.Windows.Forms.TextBox();
            this.lblClientesPermitidos = new System.Windows.Forms.Label();
            this.btnAsignarRutaServidor = new System.Windows.Forms.Button();
            this.txtRutaServidor = new System.Windows.Forms.TextBox();
            this.lblRutaServidor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.subirProdsYFact = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtNumAfiliado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbRutaServidor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(900, 284);
            this.panel1.TabIndex = 2;
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tabPage1);
            this.tbControl.Controls.Add(this.tbRutaServidor);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(8, 8);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(884, 268);
            this.tbControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNumAfiliado);
            this.tabPage1.Controls.Add(this.txtCodigoSeguridad);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.txtRutaBDLocal);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.btnSubirSucursal);
            this.tabPage1.Controls.Add(this.txtContrasenaHacienda);
            this.tabPage1.Controls.Add(this.txtUsuarioHacienda);
            this.tabPage1.Controls.Add(this.txtPinLlaveCriptografica);
            this.tabPage1.Controls.Add(this.txtLlaveCriptografica);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtDireccion);
            this.tabPage1.Controls.Add(this.txtFax);
            this.tabPage1.Controls.Add(this.txtTelefono);
            this.tabPage1.Controls.Add(this.txtCedula);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.cmbBarrio);
            this.tabPage1.Controls.Add(this.cmbDistrito);
            this.tabPage1.Controls.Add(this.cmbCanton);
            this.tabPage1.Controls.Add(this.cmbProvincia);
            this.tabPage1.Controls.Add(this.cmbNumSucursal);
            this.tabPage1.Controls.Add(this.cmbEsCasaMatriz);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empresa";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // txtCodigoSeguridad
            // 
            this.txtCodigoSeguridad.Location = new System.Drawing.Point(535, 153);
            this.txtCodigoSeguridad.Name = "txtCodigoSeguridad";
            this.txtCodigoSeguridad.Size = new System.Drawing.Size(265, 20);
            this.txtCodigoSeguridad.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(437, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "Codigo Seguridad";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(806, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtRutaBDLocal
            // 
            this.txtRutaBDLocal.Location = new System.Drawing.Point(535, 125);
            this.txtRutaBDLocal.Name = "txtRutaBDLocal";
            this.txtRutaBDLocal.Size = new System.Drawing.Size(265, 20);
            this.txtRutaBDLocal.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(400, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Ruta Base de Datos Local";
            // 
            // btnSubirSucursal
            // 
            this.btnSubirSucursal.Location = new System.Drawing.Point(463, 192);
            this.btnSubirSucursal.Name = "btnSubirSucursal";
            this.btnSubirSucursal.Size = new System.Drawing.Size(219, 38);
            this.btnSubirSucursal.TabIndex = 36;
            this.btnSubirSucursal.Text = "Subir Sucursal";
            this.btnSubirSucursal.UseVisualStyleBackColor = true;
            this.btnSubirSucursal.Click += new System.EventHandler(this.btnSubirSucursal_Click);
            // 
            // txtContrasenaHacienda
            // 
            this.txtContrasenaHacienda.Location = new System.Drawing.Point(535, 99);
            this.txtContrasenaHacienda.Name = "txtContrasenaHacienda";
            this.txtContrasenaHacienda.Size = new System.Drawing.Size(140, 20);
            this.txtContrasenaHacienda.TabIndex = 33;
            // 
            // txtUsuarioHacienda
            // 
            this.txtUsuarioHacienda.Location = new System.Drawing.Point(535, 73);
            this.txtUsuarioHacienda.Name = "txtUsuarioHacienda";
            this.txtUsuarioHacienda.Size = new System.Drawing.Size(140, 20);
            this.txtUsuarioHacienda.TabIndex = 32;
            // 
            // txtPinLlaveCriptografica
            // 
            this.txtPinLlaveCriptografica.Location = new System.Drawing.Point(535, 43);
            this.txtPinLlaveCriptografica.Name = "txtPinLlaveCriptografica";
            this.txtPinLlaveCriptografica.Size = new System.Drawing.Size(140, 20);
            this.txtPinLlaveCriptografica.TabIndex = 31;
            // 
            // txtLlaveCriptografica
            // 
            this.txtLlaveCriptografica.Location = new System.Drawing.Point(535, 13);
            this.txtLlaveCriptografica.Name = "txtLlaveCriptografica";
            this.txtLlaveCriptografica.Size = new System.Drawing.Size(140, 20);
            this.txtLlaveCriptografica.TabIndex = 30;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 202);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(140, 20);
            this.txtEmail.TabIndex = 22;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(88, 173);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(140, 20);
            this.txtDireccion.TabIndex = 21;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(88, 147);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(140, 20);
            this.txtFax.TabIndex = 20;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(88, 117);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(140, 20);
            this.txtTelefono.TabIndex = 19;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(88, 90);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(140, 20);
            this.txtCedula.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(140, 20);
            this.txtNombre.TabIndex = 17;
            // 
            // cmbBarrio
            // 
            this.cmbBarrio.FormattingEnabled = true;
            this.cmbBarrio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86"});
            this.cmbBarrio.Location = new System.Drawing.Point(337, 158);
            this.cmbBarrio.Name = "cmbBarrio";
            this.cmbBarrio.Size = new System.Drawing.Size(40, 21);
            this.cmbBarrio.TabIndex = 29;
            // 
            // cmbDistrito
            // 
            this.cmbDistrito.FormattingEnabled = true;
            this.cmbDistrito.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cmbDistrito.Location = new System.Drawing.Point(337, 128);
            this.cmbDistrito.Name = "cmbDistrito";
            this.cmbDistrito.Size = new System.Drawing.Size(40, 21);
            this.cmbDistrito.TabIndex = 28;
            // 
            // cmbCanton
            // 
            this.cmbCanton.FormattingEnabled = true;
            this.cmbCanton.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbCanton.Location = new System.Drawing.Point(337, 101);
            this.cmbCanton.Name = "cmbCanton";
            this.cmbCanton.Size = new System.Drawing.Size(40, 21);
            this.cmbCanton.TabIndex = 27;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbProvincia.Location = new System.Drawing.Point(337, 75);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(40, 21);
            this.cmbProvincia.TabIndex = 26;
            // 
            // cmbNumSucursal
            // 
            this.cmbNumSucursal.FormattingEnabled = true;
            this.cmbNumSucursal.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbNumSucursal.Location = new System.Drawing.Point(337, 42);
            this.cmbNumSucursal.Name = "cmbNumSucursal";
            this.cmbNumSucursal.Size = new System.Drawing.Size(40, 21);
            this.cmbNumSucursal.TabIndex = 25;
            this.cmbNumSucursal.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbEsCasaMatriz
            // 
            this.cmbEsCasaMatriz.FormattingEnabled = true;
            this.cmbEsCasaMatriz.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbEsCasaMatriz.Location = new System.Drawing.Point(337, 11);
            this.cmbEsCasaMatriz.Name = "cmbEsCasaMatriz";
            this.cmbEsCasaMatriz.Size = new System.Drawing.Size(40, 21);
            this.cmbEsCasaMatriz.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(422, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Contraseña Hacienda";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(437, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Usuario Hacienda";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(419, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Pin Llave Criptográfica";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(437, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Llave Criptográfica";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(295, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Barrio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Distrito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Cantón";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Provincia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Caja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sucursal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dirección";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Teléfono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cédula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // tbRutaServidor
            // 
            this.tbRutaServidor.Controls.Add(this.lblCodigoSeguridad);
            this.tbRutaServidor.Controls.Add(this.txtClientesPermitidos);
            this.tbRutaServidor.Controls.Add(this.lblClientesPermitidos);
            this.tbRutaServidor.Controls.Add(this.btnAsignarRutaServidor);
            this.tbRutaServidor.Controls.Add(this.txtRutaServidor);
            this.tbRutaServidor.Controls.Add(this.lblRutaServidor);
            this.tbRutaServidor.Controls.Add(this.panel2);
            this.tbRutaServidor.Location = new System.Drawing.Point(4, 22);
            this.tbRutaServidor.Name = "tbRutaServidor";
            this.tbRutaServidor.Padding = new System.Windows.Forms.Padding(3);
            this.tbRutaServidor.Size = new System.Drawing.Size(876, 242);
            this.tbRutaServidor.TabIndex = 1;
            this.tbRutaServidor.Text = "Servidor";
            this.tbRutaServidor.UseVisualStyleBackColor = true;
            this.tbRutaServidor.Click += new System.EventHandler(this.tbRutaServidor_Click);
            // 
            // lblCodigoSeguridad
            // 
            this.lblCodigoSeguridad.AutoSize = true;
            this.lblCodigoSeguridad.Location = new System.Drawing.Point(310, 204);
            this.lblCodigoSeguridad.Name = "lblCodigoSeguridad";
            this.lblCodigoSeguridad.Size = new System.Drawing.Size(0, 13);
            this.lblCodigoSeguridad.TabIndex = 45;
            this.lblCodigoSeguridad.Visible = false;
            // 
            // txtClientesPermitidos
            // 
            this.txtClientesPermitidos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientesPermitidos.Location = new System.Drawing.Point(194, 197);
            this.txtClientesPermitidos.Name = "txtClientesPermitidos";
            this.txtClientesPermitidos.Size = new System.Drawing.Size(25, 20);
            this.txtClientesPermitidos.TabIndex = 44;
            this.txtClientesPermitidos.Text = "1";
            this.txtClientesPermitidos.Visible = false;
            // 
            // lblClientesPermitidos
            // 
            this.lblClientesPermitidos.AutoSize = true;
            this.lblClientesPermitidos.Location = new System.Drawing.Point(92, 200);
            this.lblClientesPermitidos.Name = "lblClientesPermitidos";
            this.lblClientesPermitidos.Size = new System.Drawing.Size(95, 13);
            this.lblClientesPermitidos.TabIndex = 43;
            this.lblClientesPermitidos.Text = "Clientes Permitidos";
            this.lblClientesPermitidos.Visible = false;
            // 
            // btnAsignarRutaServidor
            // 
            this.btnAsignarRutaServidor.Location = new System.Drawing.Point(520, 162);
            this.btnAsignarRutaServidor.Name = "btnAsignarRutaServidor";
            this.btnAsignarRutaServidor.Size = new System.Drawing.Size(135, 23);
            this.btnAsignarRutaServidor.TabIndex = 3;
            this.btnAsignarRutaServidor.Text = "Asignar Ruta";
            this.btnAsignarRutaServidor.UseVisualStyleBackColor = true;
            this.btnAsignarRutaServidor.Visible = false;
            this.btnAsignarRutaServidor.Click += new System.EventHandler(this.btnAsignarRutaServidor_Click);
            // 
            // txtRutaServidor
            // 
            this.txtRutaServidor.Location = new System.Drawing.Point(170, 164);
            this.txtRutaServidor.Name = "txtRutaServidor";
            this.txtRutaServidor.Size = new System.Drawing.Size(328, 20);
            this.txtRutaServidor.TabIndex = 42;
            this.txtRutaServidor.Visible = false;
            // 
            // lblRutaServidor
            // 
            this.lblRutaServidor.AutoSize = true;
            this.lblRutaServidor.Location = new System.Drawing.Point(92, 167);
            this.lblRutaServidor.Name = "lblRutaServidor";
            this.lblRutaServidor.Size = new System.Drawing.Size(72, 13);
            this.lblRutaServidor.TabIndex = 41;
            this.lblRutaServidor.Text = "Ruta Servidor";
            this.lblRutaServidor.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Location = new System.Drawing.Point(42, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 103);
            this.panel2.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(181, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Ingrese el password de administrador";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(23, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(590, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // subirProdsYFact
            // 
            this.subirProdsYFact.Interval = 10000;
            this.subirProdsYFact.Tick += new System.EventHandler(this.subirProdsYFact_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtNumAfiliado
            // 
            this.txtNumAfiliado.Location = new System.Drawing.Point(88, 13);
            this.txtNumAfiliado.Name = "txtNumAfiliado";
            this.txtNumAfiliado.Size = new System.Drawing.Size(140, 20);
            this.txtNumAfiliado.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Afiliado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 281);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Crear Sucursal en la Nube ";
            this.Activated += new System.EventHandler(this.Form1_Enter);
            this.Deactivate += new System.EventHandler(this.Form1_Leave);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.panel1.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tbRutaServidor.ResumeLayout(false);
            this.tbRutaServidor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer subirProdsYFact;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtRutaBDLocal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSubirSucursal;
        private System.Windows.Forms.TextBox txtContrasenaHacienda;
        private System.Windows.Forms.TextBox txtUsuarioHacienda;
        private System.Windows.Forms.TextBox txtPinLlaveCriptografica;
        private System.Windows.Forms.TextBox txtLlaveCriptografica;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbBarrio;
        private System.Windows.Forms.ComboBox cmbDistrito;
        private System.Windows.Forms.ComboBox cmbCanton;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.ComboBox cmbNumSucursal;
        private System.Windows.Forms.ComboBox cmbEsCasaMatriz;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbRutaServidor;
        private System.Windows.Forms.TextBox txtRutaServidor;
        private System.Windows.Forms.Label lblRutaServidor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAsignarRutaServidor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtCodigoSeguridad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCodigoSeguridad;
        private System.Windows.Forms.TextBox txtClientesPermitidos;
        private System.Windows.Forms.Label lblClientesPermitidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumAfiliado;
    }
}

