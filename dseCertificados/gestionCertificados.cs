using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace dseCertificados
{
    internal class gestionCertificados
    {
        public string ajusteSalida(string json)
        {
            // Deserializar el JSON en la clase original
            var certificadosEntrada = JsonConvert.DeserializeObject<Certificados>(json);

            var certificadosSalida = new CertificadosSalida();

            // Mapear las propiedades
            foreach (var propiedad in certificadosEntrada.propiedadesCertificado)
            {
                var propiedadSalida = new PropiedadesCertificadosSalida
                {
                    nifCertificado = propiedad.nifCertificado,
                    titularCertificado = propiedad.titularCertificado,
                    serieCertificado = propiedad.serieCertificado,
                    fechaEmision = propiedad.fechaEmision,
                    fechaValidez = propiedad.fechaValidez,
                    nifRepresentante = propiedad.nifRepresentante,
                    nombreRepresentante = propiedad.nombreRepresentante,
                    nombreCertificado = propiedad.nombreCertificado,
                    huellaCertificado = propiedad.huellaCertificado,
                    passwordCertificado = propiedad.passwordCertificado
                };

                certificadosSalida.propiedadesCertificadoSalida.Add(propiedadSalida);
            }

            JsonSerializerSettings opciones = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, // Aplica indentación
                StringEscapeHandling = StringEscapeHandling.EscapeHtml, // Evita caracteres especiales
                //DateFormatString = "dd/MM/yyyy" //Formato de fecha
            };
            string jsonSalida = JsonConvert.SerializeObject(certificadosSalida,opciones);
            return jsonSalida;

        }

        public class CertificadosSalida
        {
            //Clase que engloba las propiedades de los certificados
            public List<PropiedadesCertificadosSalida> propiedadesCertificadoSalida { get; set; }

            public CertificadosSalida()
            {
                propiedadesCertificadoSalida = new List<PropiedadesCertificadosSalida>();
            }
        }
        public class PropiedadesCertificadosSalida
        {
            //Clase que representa las propiedades de los certificados que necesitamos
            //Se ponen como propiedades del Json con una letra para facilitar la lectura en la salida

            [JsonProperty("A")]
            public string nifCertificado { get; set; }

            [JsonProperty("B")]
            public string titularCertificado { get; set; }

            [JsonProperty("C")]
            public string serieCertificado { get; set; }

            private DateTime _fechaEmision;

            [JsonProperty("D")]
            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime fechaEmision
            {
                get => _fechaEmision.Date;
                set => _fechaEmision = value.Date;
            }

            private DateTime _fechaValidez;

            [JsonProperty("E")]
            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime fechaValidez
            {
                get => _fechaValidez.Date;
                set => _fechaValidez = value.Date;
            }

            [JsonProperty("F")]
            public string nifRepresentante { get; set; }

            [JsonProperty("G")]
            public string nombreRepresentante { get; set; }

            [JsonProperty("H")]
            public string nombreCertificado { get; set; }

            [JsonProperty("I")]
            public string huellaCertificado { get; set; }

            [JsonProperty("J")]
            public string passwordCertificado { get; set; }

            public PropiedadesCertificadosSalida()
            {
                nifCertificado = string.Empty;
                titularCertificado = string.Empty;
                serieCertificado = string.Empty;
                fechaEmision = DateTime.MinValue;
                fechaValidez = DateTime.MinValue;
                nifRepresentante = string.Empty;
                nombreRepresentante = string.Empty;
                nombreCertificado = string.Empty;
                passwordCertificado = string.Empty;
                huellaCertificado = string.Empty;
            }
        }

        public class Certificados
        {
            //Clase que engloba las propiedades de los certificados
            public List<PropiedadesCertificados> propiedadesCertificado { get; set; }

            public Certificados()
            {
                propiedadesCertificado = new List<PropiedadesCertificados>();
            }
        }
        public class PropiedadesCertificados
        {
            //Clase que representa las propiedades de los certificados que necesitamos

            public string nifCertificado { get; set; }

            public string titularCertificado { get; set; }

            public string serieCertificado { get; set; }

            private DateTime _fechaEmision;

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime fechaEmision
            {
                get => _fechaEmision.Date;
                set => _fechaEmision = value.Date;
            }

            private DateTime _fechaValidez;

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime fechaValidez
            {
                get => _fechaValidez.Date;
                set => _fechaValidez = value.Date;
            }

            public string nifRepresentante { get; set; }

            public string nombreRepresentante { get; set; }

            public string nombreCertificado { get; set; }

            public string huellaCertificado { get; set; }

            public string passwordCertificado { get; set; }

            public PropiedadesCertificados()
            {
                nifCertificado = string.Empty;
                titularCertificado = string.Empty;
                serieCertificado = string.Empty;
                fechaEmision = DateTime.MinValue;
                fechaValidez = DateTime.MinValue;
                nifRepresentante = string.Empty;
                nombreRepresentante = string.Empty;
                nombreCertificado = string.Empty;
                passwordCertificado = string.Empty;
                huellaCertificado = string.Empty;
            }
        }

        public class CustomDateTimeConverter : JsonConverter
        {
            // Define que este convertidor se aplicará a propiedades de tipo DateTime
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value is DateTime dateTime)
                {
                    writer.WriteValue(dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string dateString = (string)reader.Value;

                // Verificamos si el valor es nulo o vacío
                if (string.IsNullOrWhiteSpace(dateString))
                    return DateTime.MinValue; // o manejarlo de otra manera según tu lógica

                // Convertir la cadena de fecha a DateTime
                return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
    }
}
