using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito
{
    public static class RegistroProducto
    {
        public static List<Producto> productos = new List<Producto>();
        public static void CargarDatosExistentes()
        {
            if (System.IO.File.Exists("catalogo.json"))
            {
                string contenidoArchivoCatalogo = System.IO.File.ReadAllText("catalogo.json");
                List<Producto> catalogoEnArchivoJson = JsonConvert.DeserializeObject<List<Producto>>(contenidoArchivoCatalogo);
                if (catalogoEnArchivoJson.Count != 0)
                {
                    productos = catalogoEnArchivoJson;
                }
            }
        }


    }

}
