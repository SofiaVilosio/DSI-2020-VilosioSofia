using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace OpenShopCarrito
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
            buttonRegistrarse.Enabled = false;
        }

        public void TextBoxNombre_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoNombre();
        }
        public void controlarTextoIngresadoNombre()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                errorProviderNombre.SetError(textBoxNombre, "Debe introducir su nombre");
            }
            else
            {
                if (!textBoxNombre.Text.All(x => char.IsLetter(x)))
                {
                    errorProviderNombre.SetError(textBoxNombre, "Debe introducir solo letras");
                }
                else
                {
                    buttonRegistrarse.Enabled = true;
                    errorProviderNombre.SetError(textBoxNombre, "");
                }
            }
        }

        public void TextBoxApellido_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoApellido();
        }
        public void controlarTextoIngresadoApellido()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
            {
                errorProviderApellido.SetError(textBoxApellido, "Debe introducir su Apellido");
            }
            else
            {
                if (!textBoxApellido.Text.All(x => char.IsLetter(x)))
                {
                    errorProviderApellido.SetError(textBoxApellido, "Debe introducir solo letras");
                }
                else
                {
                    buttonRegistrarse.Enabled = true;
                    errorProviderApellido.SetError(textBoxApellido, "");
                }
            }
        }

        public void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoEmail();
        }
        public void controlarTextoIngresadoEmail()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                errorProviderEmail.SetError(textBoxEmail, "Debe introducir su Email");
            }
            else
            {
                buttonRegistrarse.Enabled = true;
                errorProviderEmail.SetError(textBoxEmail, "");
            }
        }

        public void TextBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoUsuario();
        }
        public void controlarTextoIngresadoUsuario()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxUsuario.Text))
            {
                errorProviderUsuario.SetError(textBoxUsuario, "Debe introducir su Usuario");
            }
            else
            {
                if (RegistroCliente.clientes.Any(x => x.Usuario == textBoxUsuario.Text))
                {
                    errorProviderUsuario.SetError(textBoxUsuario, "El usuario ya existe. Elija otro");
                }
                else
                {
                    buttonRegistrarse.Enabled = true;
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
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxContraseña.Text))
            {
                errorProviderContraseña.SetError(textBoxContraseña, "Debe introducir su Contraseña");
            }
            else
            {
                if (textBoxContraseña.Text.Trim().Length < 8)
                {
                    errorProviderContraseña.SetError(textBoxContraseña, "Debe introducir más de 8 caracteres");
                }
                else
                {
                    buttonRegistrarse.Enabled = true;
                    errorProviderContraseña.SetError(textBoxContraseña, "");
                }
            }
        }

        public void TextBoxContraseña2_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoContraseña2();
        }
        public void controlarTextoIngresadoContraseña2()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxContraseña2.Text))
            {
                errorProviderContraseña2.SetError(textBoxContraseña2, "Debe validar su contraseña ingresandola nuevamente");
            }
            else
            {
                if (textBoxContraseña.Text != textBoxContraseña2.Text)
                {
                    errorProviderContraseña2.SetError(textBoxContraseña2, "La contraseña no es la misma");
                }
                else
                {
                    buttonRegistrarse.Enabled = true;
                    errorProviderContraseña2.SetError(textBoxContraseña2, "");
                }
            }
        }

        public void TextBoxDni_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoDni();
        }
        public void controlarTextoIngresadoDni()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxDni.Text))
            {
                errorProviderDni.SetError(textBoxDni, "Debe introducir el numero");
            }
            else
            {
                int dniIngresado;
                bool esDni = int.TryParse(textBoxDni.Text.Trim(), out dniIngresado);
                if (esDni == false)
                {
                    errorProviderDni.SetError(textBoxDni, "Deben ser solo numeros");
                }
                else
                {
                    if((RegistroCliente.clientes.Any(x => x.DNI == dniIngresado)))
                    {
                        errorProviderDni.SetError(textBoxDni, "Este DNI ya le corresponde a otro usuario. Probablemente usted ya tiene una cuenta existente");
                    }
                    else
                    {
                        buttonRegistrarse.Enabled = true;
                        errorProviderDni.SetError(textBoxDni, "");
                    }

                }
            }
        }

        public void TextBoxDomicilio_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoDomicilio();
        }
        public void controlarTextoIngresadoDomicilio()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text))
            {
                errorProviderDomicilio.SetError(textBoxDomicilio, "Debe introducir su Domicilio");
            }
            else
            {
                buttonRegistrarse.Enabled = true;
                errorProviderDomicilio.SetError(textBoxDomicilio, "");
            }
        }

        public void TextBoxProvincia_TextChanged(object sender, EventArgs e)
        {
            controlarTextoIngresadoProvincia();
        }
        public void controlarTextoIngresadoProvincia()
        {
            buttonRegistrarse.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBoxProvincia.Text))
            {
                errorProviderProvincia.SetError(textBoxProvincia, "Debe introducir su Provincia");
            }
            else
            {
                buttonRegistrarse.Enabled = true;
                errorProviderProvincia.SetError(textBoxProvincia, "");
            }
        }

        public void buttonRegistrarse_Click(object sender, EventArgs e)
        {
            RegistrarCliente();
        }

        public void RegistrarCliente()
        {
            Guid idCliente = Guid.NewGuid();
            var dni = int.Parse(textBoxDni.Text);
            
            DateTime fechaCreacionCarrito = DateTime.Now;
            DateTime fechaModificacionCarrito = DateTime.Now;
            Guid idCarrito= Guid.NewGuid();
            Carrito carrito = new Carrito(idCarrito,fechaCreacionCarrito,fechaModificacionCarrito);
            
            Cliente cliente = new Cliente(textBoxNombre.Text, textBoxApellido.Text, textBoxEmail.Text, textBoxUsuario.Text, textBoxContraseña.Text, dni, textBoxDomicilio.Text, textBoxProvincia.Text, idCliente, carrito);
            RegistroCliente.clientes.Add(cliente);
            var clienteEnArchivoJson = JsonConvert.SerializeObject(RegistroCliente.clientes, Formatting.Indented);
            System.IO.File.WriteAllText("clientes.Json", clienteEnArchivoJson);
        }

        private void buttonAtrás_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
