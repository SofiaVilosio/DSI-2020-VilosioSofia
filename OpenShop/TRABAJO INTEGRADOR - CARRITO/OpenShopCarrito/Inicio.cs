using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenShopCarrito
{
    public partial class Inicio : Form
    {
        public Cliente cliente = new Cliente();
        public Inicio()
        {
            InitializeComponent();
            buttonIniciaSesion.Enabled = false;
        }

        public void labelRegistroUsuario_Click(object sender, EventArgs e)
        {
            RegistroUsuario ventanaRegistroUsuario = new RegistroUsuario();
            ventanaRegistroUsuario.ShowDialog();
        }

        public void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TextBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoUsuario();
        }
        public void controlarTextoIngresadoUsuario()
        {
            buttonIniciaSesion.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxUsuario.Text))
            {
                errorProviderUsuario.SetError(textBoxUsuario, "Debe introducir el usuario");
            }
            else
            {
                if (!RegistroCliente.clientes.Any(x => x.Usuario == textBoxUsuario.Text))
                {
                    errorProviderUsuario.SetError(textBoxUsuario, "El usuario no existe");
                }
                else
                {
                    buttonIniciaSesion.Enabled = true;
                    errorProviderUsuario.SetError(textBoxUsuario, "");
                }
            }
        }

        public void TextBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoContraseña();
        }
        public void controlarTextoIngresadoContraseña()
        {
            
            buttonIniciaSesion.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxContraseña.Text))
            {
                errorProviderContraseña.SetError(textBoxContraseña, "Debe introducir el usuario");
            }
            else
            {
                cliente = RegistroCliente.clientes.First(x => x.Usuario == textBoxUsuario.Text);
                if (cliente.Contraseña != textBoxContraseña.Text)
                {
                    errorProviderContraseña.SetError(textBoxContraseña, "La contraseña es incorrecta");
                }
                else
                {
                    buttonIniciaSesion.Enabled = true;
                    errorProviderContraseña.SetError(textBoxContraseña, "");
                }
            }
        }

        public void buttonIniciaSesion_Click(object sender, EventArgs e)
        {   
            RegistroCliente.clienteLogueado= RegistroCliente.clientes.First(x => x.Usuario == textBoxUsuario.Text);
            
            Catalogo ventanaCatalogo = new Catalogo();
            ventanaCatalogo.ShowDialog();
        }
    }
}
