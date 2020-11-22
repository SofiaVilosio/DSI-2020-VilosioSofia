namespace OpenShopCarrito
{
    partial class RegistroUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxContraseña2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.textBoxDomicilio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonRegistrarse = new System.Windows.Forms.Button();
            this.buttonAtrás = new System.Windows.Forms.Button();
            this.errorProviderNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderApellido = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderContraseña = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderContraseña2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDni = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDomicilio = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxProvincia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProviderProvincia = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDomicilio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProvincia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMPLETA TUS DATOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOMBRE:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(396, 38);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(181, 20);
            this.textBoxNombre.TabIndex = 2;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.TextBoxNombre_TextChanged);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(396, 81);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(181, 20);
            this.textBoxApellido.TabIndex = 4;
            this.textBoxApellido.TextChanged += new System.EventHandler(this.TextBoxApellido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "APELLIDO:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(396, 124);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(181, 20);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.TextBoxEmail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "EMAIL:";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(396, 165);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(181, 20);
            this.textBoxUsuario.TabIndex = 8;
            this.textBoxUsuario.TextChanged += new System.EventHandler(this.TextBoxUsuario_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "USUARIO:";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(396, 208);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(181, 20);
            this.textBoxContraseña.TabIndex = 10;
            this.textBoxContraseña.TextChanged += new System.EventHandler(this.TextBoxContraseña_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "CONTRASEÑA:";
            // 
            // textBoxContraseña2
            // 
            this.textBoxContraseña2.Location = new System.Drawing.Point(396, 246);
            this.textBoxContraseña2.Name = "textBoxContraseña2";
            this.textBoxContraseña2.Size = new System.Drawing.Size(181, 20);
            this.textBoxContraseña2.TabIndex = 12;
            this.textBoxContraseña2.TextChanged += new System.EventHandler(this.TextBoxContraseña2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "INGRESE NUEVAMENTE LA CONSTRASEÑA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "DNI:";
            // 
            // textBoxDni
            // 
            this.textBoxDni.Location = new System.Drawing.Point(396, 286);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(181, 20);
            this.textBoxDni.TabIndex = 14;
            this.textBoxDni.Validated += new System.EventHandler(this.TextBoxDni_TextChanged);
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Location = new System.Drawing.Point(396, 323);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(181, 20);
            this.textBoxDomicilio.TabIndex = 16;
            this.textBoxDomicilio.TextChanged += new System.EventHandler(this.TextBoxDomicilio_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(316, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "DOMICILIO:";
            // 
            // buttonRegistrarse
            // 
            this.buttonRegistrarse.Location = new System.Drawing.Point(436, 401);
            this.buttonRegistrarse.Name = "buttonRegistrarse";
            this.buttonRegistrarse.Size = new System.Drawing.Size(90, 31);
            this.buttonRegistrarse.TabIndex = 17;
            this.buttonRegistrarse.Text = "Registrarse";
            this.buttonRegistrarse.UseVisualStyleBackColor = true;
            this.buttonRegistrarse.Click += new System.EventHandler(this.buttonRegistrarse_Click);
            // 
            // buttonAtrás
            // 
            this.buttonAtrás.Location = new System.Drawing.Point(32, 401);
            this.buttonAtrás.Name = "buttonAtrás";
            this.buttonAtrás.Size = new System.Drawing.Size(90, 31);
            this.buttonAtrás.TabIndex = 18;
            this.buttonAtrás.Text = "Atrás";
            this.buttonAtrás.UseVisualStyleBackColor = true;
            this.buttonAtrás.Click += new System.EventHandler(this.buttonAtrás_Click);
            // 
            // errorProviderNombre
            // 
            this.errorProviderNombre.ContainerControl = this;
            // 
            // errorProviderApellido
            // 
            this.errorProviderApellido.ContainerControl = this;
            // 
            // errorProviderContraseña
            // 
            this.errorProviderContraseña.ContainerControl = this;
            // 
            // errorProviderContraseña2
            // 
            this.errorProviderContraseña2.ContainerControl = this;
            // 
            // errorProviderDni
            // 
            this.errorProviderDni.ContainerControl = this;
            // 
            // errorProviderEmail
            // 
            this.errorProviderEmail.ContainerControl = this;
            // 
            // errorProviderUsuario
            // 
            this.errorProviderUsuario.ContainerControl = this;
            // 
            // errorProviderDomicilio
            // 
            this.errorProviderDomicilio.ContainerControl = this;
            // 
            // textBoxProvincia
            // 
            this.textBoxProvincia.Location = new System.Drawing.Point(396, 358);
            this.textBoxProvincia.Name = "textBoxProvincia";
            this.textBoxProvincia.Size = new System.Drawing.Size(181, 20);
            this.textBoxProvincia.TabIndex = 20;
            this.textBoxProvincia.TextChanged += new System.EventHandler(this.TextBoxProvincia_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(316, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "PROVINCIA:";
            // 
            // errorProviderProvincia
            // 
            this.errorProviderProvincia.ContainerControl = this;
            // 
            // RegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(808, 465);
            this.Controls.Add(this.textBoxProvincia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonAtrás);
            this.Controls.Add(this.buttonRegistrarse);
            this.Controls.Add(this.textBoxDomicilio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxContraseña2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistroUsuario";
            this.Text = "Registro de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDomicilio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProvincia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxContraseña2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.TextBox textBoxDomicilio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonRegistrarse;
        private System.Windows.Forms.Button buttonAtrás;
        private System.Windows.Forms.ErrorProvider errorProviderNombre;
        private System.Windows.Forms.ErrorProvider errorProviderApellido;
        private System.Windows.Forms.ErrorProvider errorProviderContraseña;
        private System.Windows.Forms.ErrorProvider errorProviderContraseña2;
        private System.Windows.Forms.ErrorProvider errorProviderDni;
        private System.Windows.Forms.ErrorProvider errorProviderEmail;
        private System.Windows.Forms.ErrorProvider errorProviderUsuario;
        private System.Windows.Forms.ErrorProvider errorProviderDomicilio;
        private System.Windows.Forms.TextBox textBoxProvincia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProviderProvincia;
    }
}