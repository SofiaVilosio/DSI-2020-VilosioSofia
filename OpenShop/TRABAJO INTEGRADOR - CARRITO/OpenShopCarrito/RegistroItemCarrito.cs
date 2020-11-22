using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito
{
    public static class RegistroItemCarrito
    {
        public static List<ItemCarrito> itemsCarrito = new List<ItemCarrito>();

        public static void CargarDatosExistentes()
        {
            if (System.IO.File.Exists("ItemCarrito.json"))
            {
                string contenidoArchivoItemCarrito =System.IO.File.ReadAllText("ItemCarrito.json");
                List<ItemCarrito> itemCarritoEnArchivoJson = JsonConvert.DeserializeObject<List<ItemCarrito>>(contenidoArchivoItemCarrito);
                if (itemCarritoEnArchivoJson.Count != 0)
                {
                    itemsCarrito = itemCarritoEnArchivoJson;
                }
            }
        }

        public static void GuardarDatosEnJson()
        {
            var itemCarritoEnArchivoJson = JsonConvert.SerializeObject(itemsCarrito, Formatting.Indented);
            System.IO.File.WriteAllText("ItemCarrito.Json", itemCarritoEnArchivoJson);
        }
    }
}
