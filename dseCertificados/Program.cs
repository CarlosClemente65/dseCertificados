﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GestionCertificadosDigitales;

namespace dseCertificados
{
    internal class Program
    {
        static int tipo;
        public static string ficheroSalida = string.Empty;
        public static string ficheroResultado = "errores.sal";
        public static string ficheroCertificado = string.Empty;
        public static string passwordCertificado = string.Empty;
        static string mensaje = string.Empty;


        [STAThread] //Atributo necesario para que la aplicacion pueda abrir el formulario de carga de certificado
        static void Main(string[] argumentos)
        {
            string dsClave = string.Empty;
            try
            {
                if (argumentos.Length < 3)
                {
                    if (argumentos.Length > 0 && (argumentos[0] == "-h" || argumentos[0] == "?"))
                    {
                        SalirAplicacion(mensaje);
                    }
                    else
                    {
                        mensaje += $"Son necesarios 3 parametros: dsclave, tipo de proceso y fichero de salida";
                        SalirAplicacion(mensaje);
                    }

                }
                else
                {
                    dsClave = argumentos[0];
                    if (dsClave != "ds123456")
                    {
                        mensaje += "Clave de ejecucion incorrecta";
                        SalirAplicacion(mensaje);
                    }
                    tipo = Convert.ToInt32(argumentos[1]);

                    switch (tipo)
                    {
                        case 1:
                        case 2:
                            ficheroSalida = argumentos[2];
                            ficheroResultado = Path.ChangeExtension(ficheroSalida, "sal");

                            break;

                        case 3:
                            ficheroCertificado = argumentos[2];
                            ficheroSalida = Path.ChangeExtension(ficheroCertificado, "b64");
                            ficheroResultado = Path.ChangeExtension(ficheroCertificado, "sal");
                            if (argumentos.Length > 3)
                            {
                                passwordCertificado = argumentos[3];
                            }

                            break;
                    }
                }
                EjecutaProceso();
            }

            catch (Exception ex)
            {
                mensaje = $"Error en el proceso {ex.Message}";
                if (ex.InnerException != null)
                {
                    mensaje += ex.InnerException.Message;
                }
                File.WriteAllText(ficheroResultado, mensaje);
            }

        }

        public static void EjecutaProceso()
        {
            GestionarCertificados gestion = new GestionarCertificados();

            try
            {
                switch (tipo)
                {
                    case 1:
                        ////Obtiene datos de los certificados instalados en el equipo
                        gestion.cargarCertificadosAlmacen();
                        (string mensajeSalida, bool resultadoExportaDatos) = gestion.exportarPropiedadesCertificados();
                        if (resultadoExportaDatos)
                        {
                            gestionCertificados gestionCertificados = new gestionCertificados();
                            mensajeSalida = gestionCertificados.ajusteSalida(mensajeSalida);
                        }
                        GrabarSalida(mensajeSalida, ficheroSalida);
                        GrabarSalida("OK", ficheroResultado);
                        SalirAplicacion("");
                        break;

                    case 2:
                        //Obtiene los datos de un certificado en fichero
                        // Inicializa la aplicación de Windows Forms para mostrar el cuadro de seleccion
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        using (frmCarga frmCarga = new frmCarga())
                        {
                            frmCarga.ShowDialog();
                        }
                        break;

                    case 3:
                        //Transforma a un fichero en base64 un certificado pasado como fichero
                        (string textoExportacion, bool resultadoExportaB64) = gestion.exportaCertificadoB64(ficheroCertificado, passwordCertificado);
                        if (resultadoExportaB64)
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

            catch (Exception ex)
            {
                mensaje += $"Se ha producido un error en la ejecucion. {ex}";
                SalirAplicacion(mensaje);
            }
        }

        public static void SalirAplicacion(string mensaje)
        {
            //Si hay algun texto de error en el log, lo graba en un fichero
            if (!string.IsNullOrEmpty(mensaje))
            {
                File.WriteAllText(ficheroResultado, mensaje);
            }
            Environment.Exit(0);
        }

        public static void MostrarAyuda()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine("");
            mensaje.AppendLine(@"Uso de la aplicacion: dse_certificados.exe clave tipo salida.json");
            mensaje.AppendLine("\nParametros:");
            mensaje.AppendLine(@"  clave            Clave de ejecucion del programa");
            mensaje.AppendLine(@"  tipo             Tipo de proceso a ejecutar segun la siguiente lista:");
            mensaje.AppendLine(@"                       1 = Obtener datos de certificados instalados en el equipo (salida en .json)");
            mensaje.AppendLine(@"                       2 = Grabar datos certificado desde fichero (salida en .json)");
            mensaje.AppendLine(@"                       3 = Exportar certificado digital a base64");
            mensaje.AppendLine(@"  salida.json      Nombre del fichero donde se grabara la salida");
            mensaje.AppendLine(@"  certificado.pfx: Nombre del fichero con el certificado a exportar (solo para el tipo 3)");
            mensaje.AppendLine(@"  password:        contraseña del certificado digital a exportar (solo para el tipo 3)");
            mensaje.AppendLine("\nPulse una tecla para continuar");

            string texto = mensaje.ToString();
            Console.WriteLine(mensaje.ToString());
        }

        public static void GrabarSalida(string mensajeSalida, string ficheroSalida)
        {
            File.WriteAllText(ficheroSalida, mensajeSalida);
        }
    }
}
