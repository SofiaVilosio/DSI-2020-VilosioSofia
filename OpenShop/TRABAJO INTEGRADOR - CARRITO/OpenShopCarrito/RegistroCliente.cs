using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito
{
    public static class RegistroCliente
    {
        public static List<Cliente> clientes = new List<Cliente>();
        public static Cliente clienteLogueado;

        static RegistroCliente()
        {
            if (System.IO.File.Exists("clientes.json"))
            {
                string contenidoArchivoClientes = System.IO.File.ReadAllText("clientes.json");
                List<Cliente> clientesEnArchivoJson = JsonConvert.DeserializeObject<List<Cliente>>(contenidoArchivoClientes);
                if (clientesEnArchivoJson.Count != 0)
                {
                    clientes = clientesEnArchivoJson;
                }
            }
        }
    }
}
