using GestionCertificadosDigitales;
using gestionesAEAT.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dseCertificados.Formularios
{
    public partial class frmPrincipal : Form
    {
        public GestionarCertificados instanciaCertificados;

        private bool mouseDown;
        private Point startPoint;

        public frmPrincipal(GestionarCertificados instanciaCertificados)
        {
            this.instanciaCertificados = instanciaCertificados;
            InitializeComponent();
            panelDatos.MouseDown += panelMouseDown;
            panelDatos.MouseUp += panelMouseUp;
            panelDatos.MouseUp += panelMouseMove;
            panelTitulo.MouseDown += panelMouseDown;
            panelTitulo.MouseUp += panelMouseUp;
            panelTitulo.MouseUp += panelMouseMove;

        }

        // Método para cargar formularios en el panel
        private void CargarFormularioEnPanel(Form formulario)
        {
            // Limpiar el contenido actual del panel
            panelDatos.Controls.Clear();

            // Ajustar el formulario al panel
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.None;

            // Añadir el formulario al panel
            panelDatos.Controls.Add(formulario);
            panelDatos.Tag = formulario;


            // Ajustar el tamaño del formulario principal según el tamaño del formulario cargado
            this.Size = new Size(formulario.Width + panelDatos.Margin.Left + panelDatos.Margin.Right,
                                 formulario.Height + panelDatos.Margin.Top + panelDatos.Margin.Bottom + 85);

            // Mostrar el formulario
            formulario.Show();

            formulario.SendToBack();

        }

        private void btnMostrarSeleccion_Click(object sender, EventArgs e)
        {
            frmCarga formulario1 = new frmCarga(); // Instancias tu primer formulario
            CargarFormularioEnPanel(formulario1);
        }

        private void btnMostrarAlmacen_Click(object sender, EventArgs e)
        {
            frmSeleccion formulario2 = new frmSeleccion(instanciaCertificados); // Instancias tu segundo formulario
            CargarFormularioEnPanel(formulario2);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarFormularioEnPanel(new frmCarga());
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
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                startPoint = new Point(e.X, e.Y);
                // Desactiva la captura de eventos del control
                this.Capture = false;
            }
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
    }
}
