namespace OpenShopCarrito
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonIniciaSesion = new System.Windows.Forms.Button();
            this.labelRegistroUsuario = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.errorProviderUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderContraseña = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenShopCarrito.Properties.Resources.OPEN_SHOP__1_;
            this.pictureBox1.InitialImage = global::OpenShopCarrito.Properties.Resources.OPEN_SHOP__1_;
            this.pictureBox1.Location = new System.Drawing.Point(328, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(269, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido a Open Shop";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hola, para seguir ingrese su usuario y contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "USUARIO:";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(328, 274);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(229, 20);
            this.textBoxUsuario.TabIndex = 4;
            this.textBoxUsuario.TextChanged += new System.EventHandler(this.TextBoxUsuario_TextChanged);
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(328, 316);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(229, 20);
            this.textBoxContraseña.TabIndex = 6;
            this.textBoxContraseña.TextChanged += new System.EventHandler(this.TextBoxContraseña_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "CONTRASEÑA:";
            // 
            // buttonIniciaSesion
            // 
            this.buttonIniciaSesion.Location = new System.Drawing.Point(346, 354);
            this.buttonIniciaSesion.Name = "buttonIniciaSesion";
            this.buttonIniciaSesion.Size = new System.Drawing.Size(108, 23);
            this.buttonIniciaSesion.TabIndex = 7;
            this.buttonIniciaSesion.Text = "Inicia Sesión";
            this.buttonIniciaSesion.UseVisualStyleBackColor = true;
            this.buttonIniciaSesion.Click += new System.EventHandler(this.buttonIniciaSesion_Click);
            // 
            // labelRegistroUsuario
            // 
            this.labelRegistroUsuario.AutoSize = true;
            this.labelRegistroUsuario.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelRegistroUsuario.Location = new System.Drawing.Point(353, 390);
            this.labelRegistroUsuario.Name = "labelRegistroUsuario";
            this.labelRegistroUsuario.Size = new System.Drawing.Size(87, 13);
            this.labelRegistroUsuario.TabIndex = 8;
            this.labelRegistroUsuario.Text = "Crea una Cuenta";
            this.labelRegistroUsuario.Click += new System.EventHandler(this.labelRegistroUsuario_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(49, 410);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(108, 23);
            this.buttonSalir.TabIndex = 9;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // errorProviderUsuario
            // 
            this.errorProviderUsuario.ContainerControl = this;
            // 
            // errorProviderContraseña
            // 
            this.errorProviderContraseña.ContainerControl = this;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.labelRegistroUsuario);
            this.Controls.Add(this.buttonIniciaSesion);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.Text = "Open Shop";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderContraseña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonIniciaSesion;
        private System.Windows.Forms.Label labelRegistroUsuario;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.ErrorProvider errorProviderUsuario;
        private System.Windows.Forms.ErrorProvider errorProviderContraseña;
    }
}

