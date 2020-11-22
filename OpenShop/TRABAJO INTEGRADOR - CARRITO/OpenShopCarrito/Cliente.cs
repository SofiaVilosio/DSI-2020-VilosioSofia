using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenShopCarrito
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int DNI { get; set; }
        public string Domicilio { get; set; }
        public string Provincia { get; set; }
        public Guid IdCliente { get; set; }

        public Carrito Carrito { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nombre, string apellido, string email, string usuario, string contraseña, int dni, string domicilio, string provincia, Guid idCliente, Carrito carrito)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Usuario = usuario;
            Contraseña = contraseña;
            DNI = dni;
            Domicilio = domicilio;
            Provincia = provincia;
            IdCliente = idCliente;
            Carrito = carrito;
        }

    }
}
