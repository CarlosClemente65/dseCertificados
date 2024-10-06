using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using GestionCertificadosDigitales;

namespace dseCertificados
{
    public partial class frmCarga : Form
    {
        //Ruta de carga del certificado
        string certificadoPath = string.Empty;

        string password = string.Empty;
        GestionarCertificados gestion = new GestionarCertificados();

        private bool mouseDown;
        private Point startPoint;

        public frmCarga()
        {
            InitializeComponent();
            panelDatos.MouseDown += panelMouseDown;
            panelDatos.MouseUp += panelMouseUp;
            panelDatos.MouseUp += panelMouseMove;
            panelTitulo.MouseDown += panelMouseDown;
            panelTitulo.MouseUp += panelMouseUp;
            panelTitulo.MouseUp += panelMouseMove;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";

            //Dialogo de seleccion del fichero
            OpenFileDialog ofdSelection = new OpenFileDialog();
            ofdSeleccion.FileName = ofdSelection.FileName;
            if (ofdSeleccion.ShowDialog() == DialogResult.OK)
            {
                // Obtiene la ruta completa del archivo seleccionado
                certificadoPath = ofdSeleccion.FileName;

                // Actualiza el contenido del TextBox con la ruta del archivo
                txtNombre.Text = certificadoPath;
                txtPassword1.Enabled = true;
                txtPassword2.Enabled = true;
                txtPassword1.Focus();
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (txtPassword1.Text != txtPassword2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword1.Text = "";
                txtPassword2.Text = "";
                txtPassword1.Focus();
                btnCargar.Enabled = false;
            }
            else
            {
                password = txtPassword1.Text;
                (string mensaje1, bool resultado1) = gestion.leerCertificado(certificadoPath, password);
                if (resultado1)
                {
                    //Si la lectura del certificado es correcta, se leen las propiedades
                    (string propiedadesCertificados, bool resultado2) = gestion.exportarPropiedadesCertificados();
                    
                    if (resultado2)
                    {
                    //Si se han podido leer las propiedades, se ajusta el Json recibido a la salida que se espera con letras en vez de nombres de propiedades
                        gestionCertificados gestionCertificados = new gestionCertificados();
                        propiedadesCertificados = gestionCertificados.ajusteSalida(propiedadesCertificados);
                        Program.GrabarSalida(propiedadesCertificados, Program.ficheroSalida);

                        //Se obtiene el nº de serie y se exporta una copia del certificado con extension .da1
                        string serieCertificado = gestion.consultaPropiedades(GestionarCertificados.nombresPropiedades.serieCertificado);
                        (X509Certificate2 certificado, bool resultado3) = gestion.exportaCertificadoDigital(serieCertificado);
                        if (resultado3)
                        {
                            byte[] datosCertificado = certificado.Export(X509ContentType.Pfx, password);
                            string salidaCertificado = Path.ChangeExtension(Program.ficheroSalida, "da1");
                            File.WriteAllBytes(salidaCertificado, datosCertificado);
                            Program.GrabarSalida("OK", Program.ficheroResultado);
                        }

                        else
                        {
                            Program.GrabarSalida("No se ha podido exportar el certificado digital", Program.ficheroResultado);
                        }
                    }

                    Environment.Exit(0);
                }

                else
                {
                    MessageBox.Show(mensaje1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Environment.Exit(0);
                    txtPassword1.Text = "";
                    txtPassword2.Text = "";
                    txtPassword1.Focus();
                    btnCargar.Enabled = false;
                }
            }

        }

        private void txtPassword2_Enter(object sender, EventArgs e)
        {
            btnCargar.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string mensaje = $"Proceso cancelado por el usuario.";
            Program.GrabarSalida(mensaje, Program.ficheroResultado);
            Environment.Exit(0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panelMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    this.Location.X - startPoint.X + e.X, this.Location.Y - startPoint.Y + e.Y);

                this.Update();
            }
        }

        private void panelMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
