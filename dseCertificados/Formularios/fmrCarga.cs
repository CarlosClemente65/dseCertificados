using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
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
        GestionarCertificados gestionCertificados = new GestionarCertificados();

        public X509Certificate2 certificadoSeleccionado { get; set; }

        //Variables para poder mover los formularios
        private bool mouseDown;
        private Point startPoint;

        //Permite mostrar un mensaje al pasar el curso por algun campo
        private ToolTip mensaje;


        public frmCarga()
        {
            InitializeComponent();

            //Mensaje a mostrar en la primera contraseña como una ayuda del contenido
            mensaje = new ToolTip();
            if (Program.certificadoSeleccionado != null)
            {
                txtClave1.Text = "Asignar constraseña al certificado";
                mensaje.SetToolTip(txtClave1, "Permite proteger el certificado con una contraseña");
                mensaje.SetToolTip(txtPassword1, "Permite proteger el certificado con una contraseña");
                btnBuscar.Enabled = false;
            }
            else
            {
                txtClave1.Text = "Constraseña de apertura del fichero";
                mensaje.SetToolTip(txtClave1, "Contraseña que protege el fichero del certificado");
                mensaje.SetToolTip(txtPassword1, "Contraseña que protege el fichero del certificado");

            }

        }

        public void CargarDatos()
        {
            if (Program.certificadoSeleccionado != null)
            {
                txtNombre.Text = Program.certificadoSeleccionado.FriendlyName ?? "Nombre del certificado no disponible";
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
                string mensajeSalida = string.Empty;
                string serieCertificado = string.Empty;

                //Si se ha cargado un certificado desde el lineal, el proceso cambia
                if (Program.certificadoSeleccionado == null)
                {
                    bool resultado = false;
                    //Se hace la lectura desde el fichero leido
                    (mensajeSalida, resultado) = gestionCertificados.leerCertificado(certificadoPath, password);
                    if (resultado)
                    {
                        serieCertificado = gestionCertificados.consultaPropiedades(GestionarCertificados.nombresPropiedades.serieCertificado);
                    }
                }
                else
                {
                    //Se cargan las propiedades del certificado que se pasa por parametro y luego se exportan.
                    gestionCertificados.cargarDatosCertificado(Program.certificadoSeleccionado, password);

                    //Comprueba si se ha podido cargar el numero de serie para que continue con el proceso
                    serieCertificado = gestionCertificados.consultaPropiedades(GestionarCertificados.nombresPropiedades.serieCertificado);
                }

                if (!string.IsNullOrEmpty(serieCertificado))
                {
                    //Se obtiene el certificado segun el numero de serie que se pasa por parametro
                    (X509Certificate2 certificado, bool resultadoExportarCertificado) = gestionCertificados.exportaCertificadoDigital(serieCertificado);

                    if (resultadoExportarCertificado)
                    {
                        try
                        {
                            //Es necesario un arreglo de bytes para marcar el certificado como exportable, y debe pasarse la contraseña para poder gestionarlo.
                            byte[] certificadoBytes = certificado.Export(X509ContentType.Pfx, password);
                            X509Certificate2 certificadoSalida = new X509Certificate2(certificadoBytes, password, X509KeyStorageFlags.Exportable);

                            //Una vez los datos del certificado preparados se genera otro arreglo de bytes para exportar el certificado
                            byte[] datosCertificado = certificadoSalida.Export(X509ContentType.Pfx, password);

                            //Se modifica la extension del fichero por seguridad
                            string salidaCertificado = Path.ChangeExtension(Program.ficheroSalida, "da1");
                            File.WriteAllBytes(salidaCertificado, datosCertificado);
                            Program.GrabarSalida("OK", Program.ficheroResultado);

                            //Si se han podido leer los certificados y las propiedades, se ajusta el Json recibido a la salida que se espera con letras en vez de nombres de propiedades
                            bool resultado = false;
                            (mensajeSalida, resultado) = gestionCertificados.exportarPropiedadesCertificados(true);
                            Program.GrabarSalida(mensajeSalida, Program.ficheroSalida);
                            Environment.Exit(0);
                        }
                        catch (CryptographicException ex)
                        {
                            MessageBox.Show("El certificado no es exportable. Debe estar instalado con la clave privada como exportable.", "Error de certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            //Se borran los certificados digitales cargados para que se vuelvan a leer del almacen (si no se hace solo muestra en el lineal el ultimo seleccionado)
                            gestionCertificados.limpiarCertificados();
                            button2.PerformClick();
                            //Program.GrabarSalida($"El certificado no es exportable.{Environment.NewLine}{ex}", Program.ficheroResultado);
                        }

                    }

                    else
                    {
                        Program.GrabarSalida("No se ha podido exportar el certificado digital", Program.ficheroResultado);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    MessageBox.Show(mensajeSalida, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Program.certificadoSeleccionado != null) Program.certificadoSeleccionado = null;
            Program.cambioFormulario(this, new frmSeleccion(gestionCertificados));
        }

        public void cargaCertificado(X509Certificate2 certificadoSeleccionado)
        {
            this.certificadoSeleccionado = certificadoSeleccionado;
        }

        private void mostrarPass1_Click(object sender, EventArgs e)
        {
            if (mostrarPass1.ImageIndex == 4)
            {
                mostrarPass1.ImageIndex = 5;
                txtPassword1.PasswordChar = '\0';
                txtPassword2.PasswordChar = '\0';
                txtPassword1.Focus();
            }
            else
            {
                mostrarPass1.ImageIndex = 4;
                txtPassword1.PasswordChar = '*';
                txtPassword2.PasswordChar = '*';
                txtPassword1.Focus();
            }

        }

        private void txtPassword1_Leave(object sender, EventArgs e)
        {
            if (txtPassword1.Text.Length > 0)
            {
                string patronPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
                bool chequeoPassword = Regex.IsMatch(txtPassword1.Text, patronPassword);
                if (!chequeoPassword)
                {
                    MessageBox.Show("La contraseña no es segura. Debe ser de al menos 8 caracteres y tener una letra minúscula, una mayúscula y un número", "Contraseña no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword1.Text = "";
                    txtPassword1.Focus();
                }
            }
        }
    }
}
