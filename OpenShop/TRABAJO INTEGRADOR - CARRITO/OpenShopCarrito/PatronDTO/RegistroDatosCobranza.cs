using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito.PatronDTO
{
    public static class RegistroDatosCobranza
    {
        public static List<DatosCobranza> datosCobranzas = new List<DatosCobranza>();

        public static void GuardarDatosEnJson()
        {
            var datosCobranzaEnArchivoJson = JsonConvert.SerializeObject(datosCobranzas, Formatting.Indented);
            System.IO.File.WriteAllText("Ventas.Json", datosCobranzaEnArchivoJson);
        }

        public static void CargarDatosExistentes()
        {
            if (System.IO.File.Exists("Ventas.json"))
            {
                string contenidoArchivoDatosCobranza = System.IO.File.ReadAllText("Ventas.json");
                List<DatosCobranza> datosCobranzaEnArchivoJson = JsonConvert.DeserializeObject<List<DatosCobranza>>(contenidoArchivoDatosCobranza);
                if (datosCobranzaEnArchivoJson.Count != 0)
                {
                    datosCobranzas = datosCobranzaEnArchivoJson;
                }
            }
        }
    }
}
