using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using GestionCertificadosDigitales;
using gestionesAEAT.Formularios;

namespace dseCertificados
{
    internal class Program
    {
        static int tipo;
        public static string ficheroSalida = string.Empty;
        public static string ficheroResultado = "errores.sal";
        public static string ficheroCertificado = string.Empty;
        public static string passwordCertificado = string.Empty;
        public static X509Certificate2 certificadoSeleccionado;
        static string mensaje = string.Empty;


        [STAThread] //Atributo necesario para que la aplicacion pueda abrir el formulario de carga de certificado
        static void Main(string[] argumentos)
        {
            string dsClave = string.Empty;
            try
            {
                if(argumentos.Length < 2)
                {
                    if(argumentos.Length > 0 && (argumentos[0] == "-h" || argumentos[0] == "?"))
                    {
                        SalirAplicacion(mensaje);
                    }
                    else
                    {
                        mensaje += $"Son necesarios 2 parametros: dsclave, y fichero con el guion";
                        SalirAplicacion(mensaje);
                    }

                }

                else
                {
                    dsClave = argumentos[0];
                    if(dsClave != "ds123456")
                    {
                        mensaje += "Clave de ejecucion incorrecta";
                        SalirAplicacion(mensaje);
                    }

                    CargarGuion(argumentos[1]);

                }

                //Si el guion se ha cargado correctamente, se sale de la aplicacion
                if(string.IsNullOrEmpty(mensaje))
                {
                    EjecutaProceso();
                }
                else
                {
                    File.WriteAllText(ficheroResultado, mensaje);
                }
            }

            catch(Exception ex)
            {
                mensaje = $"Error en el proceso {ex.Message}";
                if(ex.InnerException != null)
                {
                    mensaje += ex.InnerException.Message;
                }
                File.WriteAllText(ficheroResultado, mensaje);
            }

        }

        private static string CargarGuion(string guion)
        {
            string mensaje = string.Empty;
            try
            {
                string[] lineas = File.ReadAllLines(guion);
                foreach(string linea in lineas)
                {
                    string[] partes = linea.Split('=');
                    string clave = partes[0].ToUpper();
                    string valor = partes[1];
                    switch(clave)
                    {
                        case "TIPO":
                            tipo = Convert.ToInt32(valor);
                            break;

                        case "FICHERO":
                            ficheroCertificado = valor;
                            break;

                        case "CLAVE":
                            passwordCertificado = valor;
                            break;

                        case "SALIDA":
                            ficheroSalida = valor;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error al cargar el guion {ex.Message}");

            }

            switch(tipo)
            {
                case 1:
                case 2:
                    ficheroResultado = Path.ChangeExtension(ficheroSalida, "sal");
                    controlFicheros(ficheroSalida);
                    controlFicheros(ficheroResultado);
                    controlFicheros(Path.ChangeExtension(Program.ficheroSalida, "da1"));

                    break;

                case 3:
                    ficheroSalida = Path.ChangeExtension(ficheroCertificado, "b64");
                    ficheroResultado = Path.ChangeExtension(ficheroCertificado, "sal");
                    controlFicheros(ficheroSalida);
                    controlFicheros(ficheroResultado);

                    break;
            }
            return mensaje;

        }

        public static void EjecutaProceso()
        {
            GestionarCertificados gestion = new GestionarCertificados();

            try
            {
                switch(tipo)
                {
                    case 1:
                        //Obtiene datos de los certificados instalados en el equipo
                        gestion.cargarCertificadosAlmacen();
                        (string mensajeSalida, bool resultadoExportaDatos) = gestion.exportarPropiedadesCertificados(true);
                        GrabarSalida(mensajeSalida, ficheroSalida);
                        GrabarSalida("OK", ficheroResultado);
                        SalirAplicacion("");
                        break;

                    case 2:
                        //Obtiene los datos de un certificado en fichero
                        // Inicializa la aplicación de Windows Forms para mostrar el cuadro de seleccion
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        //Abre el formulario de seleccion de certificados por defecto
                        Application.Run(new frmSeleccion(gestion));

                        break;

                    case 3:
                        //Transforma a un fichero en base64 un certificado pasado como fichero
                        (string textoExportacion, bool resultadoExportaB64) = gestion.exportaCertificadoB64(ficheroCertificado, passwordCertificado);
                        if(resultadoExportaB64)
                        {
                            GrabarSalida(textoExportacion, ficheroSalida);
                            GrabarSalida("OK", ficheroResultado);
                        }

                        else
                        {
                            GrabarSalida(textoExportacion, ficheroResultado);
                        }
                        SalirAplicacion("");
                        break;

                    default:
                        mensaje += "Tipo de ejecucion incorrecto";
                        SalirAplicacion(mensaje);
                        break;

                }
            }

            catch(Exception ex)
            {
                mensaje += $"Se ha producido un error en la ejecucion. {ex}";
                SalirAplicacion(mensaje);
            }
        }

        public static void SalirAplicacion(string mensaje)
        {
            //Si hay algun texto de error en el log, lo graba en un fichero
            if(!string.IsNullOrEmpty(mensaje))
            {
                File.WriteAllText(ficheroResultado, mensaje);
            }
            Environment.Exit(0);
        }

        public static void MostrarAyuda()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine("");
            mensaje.AppendLine(@"Uso de la aplicacion: dse_certificados.exe clave tipo [salida.json | certificado.pfx password]");
            mensaje.AppendLine("\nParametros:");
            mensaje.AppendLine(@"  clave            Clave de ejecucion del programa");
            mensaje.AppendLine(@"  tipo             Tipo de proceso a ejecutar segun la siguiente lista:");
            mensaje.AppendLine(@"                       1 = Obtener las propiedades de los certificados instalados en el equipo (salida en .json)");
            mensaje.AppendLine(@"                       2 = Exporta certificado seleccionado por pantalla y sus propiedades)");
            mensaje.AppendLine(@"                       3 = Exporta certificado pasado por fichero a base64");
            mensaje.AppendLine(@"  salida.json      Nombre del fichero donde se grabara la salida");
            mensaje.AppendLine(@"  certificado.pfx: Nombre del fichero con el certificado a exportar)");
            mensaje.AppendLine(@"  password:        contraseña del certificado digital a exportar)");
            mensaje.AppendLine("\nPulse una tecla para continuar");

            string texto = mensaje.ToString();
            Console.WriteLine(mensaje.ToString());
        }

        public static void GrabarSalida(string mensajeSalida, string ficheroSalida)
        {
            File.WriteAllText(ficheroSalida, mensajeSalida, Encoding.GetEncoding(1252));
        }

        public static void cambioFormulario(Form formularioActual, Form nuevoFormulario)
        {
            //Mostrar el nuevo formulario
            nuevoFormulario.Show();

            //Cerrar el formulario actual
            formularioActual.Hide();
        }

        public static void controlFicheros(string fichero)
        {
            if(File.Exists(fichero))
            {
                File.Delete(fichero);
            }
        }
    }
}
