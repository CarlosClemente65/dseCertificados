using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using GestionCertificadosDigitales;
using gestionesAEAT.Formularios;

namespace dseCertificados
{
    public partial class frmCarga : Form
    {
        //Ruta de carga del certificado
        string certificadoPath = string.Empty;

        string password = string.Empty;
        GestionarCertificados gestion = new GestionarCertificados();

        public X509Certificate2 certificadoSeleccionado { get; set; }

        //Variables para poder mover los formularios
        private bool mouseDown;
        private Point startPoint;

        public frmCarga()
        {
            InitializeComponent();
        }

        public void CargarDatos(X509Certificate2 certificadoSeleccionado)
        {
            if (certificadoSeleccionado != null)
            {
                txtNombre.Text = certificadoSeleccionado.FriendlyName ?? "Nombre del certificado no disponible";
                txtPassword1.Enabled = true;
                txtPassword2.Enabled = true;
                txtPassword1.Focus();
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            if (Program.certificadoSeleccionado != null)
            {
                Program.certificadoSeleccionado = null;
            }

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
                string mensaje1 = string.Empty;
                bool resultado = false;

                //Si se ha cargado un certificado desde el lineal, el proceso cambia
                if (Program.certificadoSeleccionado == null)
                {
                    //Se hace la lectura desde el fichero leido
                    (mensaje1, resultado) = gestion.leerCertificado(certificadoPath, password);
                }
                else
                {
                    //Se cargan las propiedades del certificado que se pasa por parametro y luego se exportan.
                    gestion.cargarDatosCertificado(Program.certificadoSeleccionado, password);
                    (mensaje1, resultado) = gestion.exportarPropiedadesCertificados(true);
                }

                if (resultado)
                {
                    //Si se han podido leer las propiedades, se ajusta el Json recibido a la salida que se espera con letras en vez de nombres de propiedades
                    (string mensajeSalida, bool resultadoExportaDatos) = gestion.exportarPropiedadesCertificados(true);

                    //Se obtiene el nº de serie del certificado cargado para pasarlo al metodo de exportacion
                    string serieCertificado = gestion.consultaPropiedades(GestionarCertificados.nombresPropiedades.serieCertificado);

                    (X509Certificate2 certificado, bool resultado3) = gestion.exportaCertificadoDigital(serieCertificado);
                    if (resultado3)
                    {
                        Program.GrabarSalida(mensajeSalida, Program.ficheroSalida);
                        //Es necesario un arreglo de bytes para marcar el certificado como exportable, y debe pasarse la contraseña para poder gestionarlo.
                        byte[] certificadoBytes = certificado.Export(X509ContentType.Pfx, password);
                        X509Certificate2 certificadoSalida = new X509Certificate2(certificadoBytes, password, X509KeyStorageFlags.Exportable);

                        //Una vez los datos del certificado preparados se genera otro arreglo de bytes para exportar el certificado
                        byte[] datosCertificado = certificadoSalida.Export(X509ContentType.Pfx, password);

                        //Se modifica la extension del fichero por seguridad
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
                    this.Location.X - startPoint.X + e.X,
                    this.Location.Y - startPoint.Y + e.Y);

                this.Update();
            }
        }

        private void panelMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.cambioFormulario(this, new frmSeleccion(gestion));
        }

        public void cargaCertificado(X509Certificate2 certificadoSeleccionado)
        {
            this.certificadoSeleccionado = certificadoSeleccionado;
        }
    }
}
