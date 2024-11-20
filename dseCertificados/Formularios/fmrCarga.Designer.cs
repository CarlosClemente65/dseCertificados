namespace dseCertificados
{
    partial class frmCarga
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarga));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave1 = new System.Windows.Forms.Label();
            this.txtClave2 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ofdSeleccion = new System.Windows.Forms.OpenFileDialog();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.mostrarPass1 = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinimiza = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtProceso = new System.Windows.Forms.Label();
            this.panelDatos.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre certificado";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(10, 32);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(540, 24);
            this.txtNombre.TabIndex = 1;
            // 
            // txtClave1
            // 
            this.txtClave1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave1.Location = new System.Drawing.Point(12, 76);
            this.txtClave1.Name = "txtClave1";
            this.txtClave1.Size = new System.Drawing.Size(191, 21);
            this.txtClave1.TabIndex = 2;
            this.txtClave1.Text = "Contraseña del fichero";
            this.txtClave1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClave2
            // 
            this.txtClave2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave2.Location = new System.Drawing.Point(245, 76);
            this.txtClave2.Name = "txtClave2";
            this.txtClave2.Size = new System.Drawing.Size(201, 21);
            this.txtClave2.TabIndex = 3;
            this.txtClave2.Text = "Repetir contraseña";
            this.txtClave2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword1
            // 
            this.txtPassword1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassword1.Enabled = false;
            this.txtPassword1.Location = new System.Drawing.Point(10, 102);
            this.txtPassword1.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(193, 24);
            this.txtPassword1.TabIndex = 4;
            this.txtPassword1.Leave += new System.EventHandler(this.txtPassword1_Leave);
            // 
            // txtPassword2
            // 
            this.txtPassword2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassword2.Enabled = false;
            this.txtPassword2.Location = new System.Drawing.Point(248, 102);
            this.txtPassword2.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(198, 24);
            this.txtPassword2.TabIndex = 5;
            this.txtPassword2.Enter += new System.EventHandler(this.txtPassword2_Enter);
            // 
            // btnCargar
            // 
            this.btnCargar.AutoSize = true;
            this.btnCargar.BackColor = System.Drawing.Color.Transparent;
            this.btnCargar.Enabled = false;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ImageIndex = 0;
            this.btnCargar.ImageList = this.imageList2;
            this.btnCargar.Location = new System.Drawing.Point(462, 78);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(120, 48);
            this.btnCargar.TabIndex = 6;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "cargar.png");
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Lavender;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ImageIndex = 0;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(552, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 25);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "buscar.png");
            this.imageList1.Images.SetKeyName(1, "cargar.png");
            this.imageList1.Images.SetKeyName(2, "cerrar.png");
            this.imageList1.Images.SetKeyName(3, "minimizar.png");
            this.imageList1.Images.SetKeyName(4, "visible.png");
            this.imageList1.Images.SetKeyName(5, "novisible.png");
            // 
            // ofdSeleccion
            // 
            this.ofdSeleccion.FileName = "openFileDialog1";
            this.ofdSeleccion.Filter = "(fichero.pfx)|*.pfx|(fichero.p12)|*.p12";
            this.ofdSeleccion.Title = "Seleccionar fichero a importar";
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.Color.Lavender;
            this.panelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatos.Controls.Add(this.mostrarPass1);
            this.panelDatos.Controls.Add(this.txtPassword1);
            this.panelDatos.Controls.Add(this.btnBuscar);
            this.panelDatos.Controls.Add(this.txtClave1);
            this.panelDatos.Controls.Add(this.txtNombre);
            this.panelDatos.Controls.Add(this.label1);
            this.panelDatos.Controls.Add(this.btnCargar);
            this.panelDatos.Controls.Add(this.txtClave2);
            this.panelDatos.Controls.Add(this.txtPassword2);
            this.panelDatos.Location = new System.Drawing.Point(9, 85);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Padding = new System.Windows.Forms.Padding(5);
            this.panelDatos.Size = new System.Drawing.Size(592, 143);
            this.panelDatos.TabIndex = 8;
            this.panelDatos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMouseDown);
            this.panelDatos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMouseMove);
            this.panelDatos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMouseUp);
            // 
            // mostrarPass1
            // 
            this.mostrarPass1.BackColor = System.Drawing.Color.Lavender;
            this.mostrarPass1.FlatAppearance.BorderSize = 0;
            this.mostrarPass1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.mostrarPass1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mostrarPass1.ImageIndex = 4;
            this.mostrarPass1.ImageList = this.imageList1;
            this.mostrarPass1.Location = new System.Drawing.Point(211, 103);
            this.mostrarPass1.Name = "mostrarPass1";
            this.mostrarPass1.Size = new System.Drawing.Size(25, 20);
            this.mostrarPass1.TabIndex = 8;
            this.mostrarPass1.UseVisualStyleBackColor = false;
            this.mostrarPass1.Click += new System.EventHandler(this.mostrarPass1_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelTitulo.Controls.Add(this.button1);
            this.panelTitulo.Controls.Add(this.btnMinimiza);
            this.panelTitulo.Controls.Add(this.btnCerrar);
            this.panelTitulo.Controls.Add(this.Titulo);
            this.panelTitulo.Controls.Add(this.btnMinimizar);
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.panelTitulo.Size = new System.Drawing.Size(609, 48);
            this.panelTitulo.TabIndex = 14;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMouseDown);
            this.panelTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMouseMove);
            this.panelTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(571, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimiza
            // 
            this.btnMinimiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimiza.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMinimiza.FlatAppearance.BorderSize = 0;
            this.btnMinimiza.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnMinimiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimiza.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimiza.ImageIndex = 3;
            this.btnMinimiza.ImageList = this.imageList1;
            this.btnMinimiza.Location = new System.Drawing.Point(535, 8);
            this.btnMinimiza.Name = "btnMinimiza";
            this.btnMinimiza.Size = new System.Drawing.Size(30, 30);
            this.btnMinimiza.TabIndex = 13;
            this.btnMinimiza.UseVisualStyleBackColor = false;
            this.btnMinimiza.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageIndex = 2;
            this.btnCerrar.Location = new System.Drawing.Point(552, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.Color.White;
            this.Titulo.Location = new System.Drawing.Point(8, 14);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(189, 18);
            this.Titulo.TabIndex = 9;
            this.Titulo.Text = "Seleccionar certificado";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ImageIndex = 3;
            this.btnMinimizar.Location = new System.Drawing.Point(516, 5);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.TabIndex = 11;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(489, 55);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "Leer almacén";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProceso
            // 
            this.txtProceso.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProceso.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtProceso.Location = new System.Drawing.Point(8, 57);
            this.txtProceso.Name = "txtProceso";
            this.txtProceso.Size = new System.Drawing.Size(473, 18);
            this.txtProceso.TabIndex = 14;
            this.txtProceso.Text = "SSS";
            this.txtProceso.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(609, 236);
            this.Controls.Add(this.txtProceso);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelDatos);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmCarga";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar certificado";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMouseUp);
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label txtClave1;
        private System.Windows.Forms.Label txtClave2;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog ofdSeleccion;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMinimiza;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button mostrarPass1;
        private System.Windows.Forms.Label txtProceso;
    }
}