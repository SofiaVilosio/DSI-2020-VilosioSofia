namespace OpenShopCarrito
{
    partial class CarritoVisualizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarritoVisualizacion));
            this.dataGridViewCarrito = new System.Windows.Forms.DataGridView();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.buttonAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPrecioTotalProductos = new System.Windows.Forms.Label();
            this.labelPrecioEnvio = new System.Windows.Forms.Label();
            this.labelTotalConEnvio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBorrarProducto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCantidadABorrar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProviderCantidadABorrar = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCantidadAAgregar = new System.Windows.Forms.TextBox();
            this.buttonAgregarCantidad = new System.Windows.Forms.Button();
            this.errorProviderCantidadAAgregar = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCantidadABorrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCantidadAAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCarrito
            // 
            this.dataGridViewCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCarrito.Location = new System.Drawing.Point(12, 46);
            this.dataGridViewCarrito.Name = "dataGridViewCarrito";
            this.dataGridViewCarrito.Size = new System.Drawing.Size(694, 289);
            this.dataGridViewCarrito.TabIndex = 0;
            // 
            // buttonComprar
            // 
            this.buttonComprar.ForeColor = System.Drawing.Color.Black;
            this.buttonComprar.Location = new System.Drawing.Point(713, 467);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(108, 23);
            this.buttonComprar.TabIndex = 13;
            this.buttonComprar.Text = "COMPRAR";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // buttonAtras
            // 
            this.buttonAtras.ForeColor = System.Drawing.Color.Black;
            this.buttonAtras.Location = new System.Drawing.Point(34, 467);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.Size = new System.Drawing.Size(108, 23);
            this.buttonAtras.TabIndex = 14;
            this.buttonAtras.Text = "ATRÁS";
            this.buttonAtras.UseVisualStyleBackColor = true;
            this.buttonAtras.Click += new System.EventHandler(this.buttonAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 12F);
            this.label1.Location = new System.Drawing.Point(233, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "ENVIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 12F);
            this.label2.Location = new System.Drawing.Point(233, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "TOTAL CON ENVÍO:";
            // 
            // labelPrecioTotalProductos
            // 
            this.labelPrecioTotalProductos.AutoSize = true;
            this.labelPrecioTotalProductos.Location = new System.Drawing.Point(481, 364);
            this.labelPrecioTotalProductos.Name = "labelPrecioTotalProductos";
            this.labelPrecioTotalProductos.Size = new System.Drawing.Size(88, 13);
            this.labelPrecioTotalProductos.TabIndex = 17;
            this.labelPrecioTotalProductos.Text = "$Total Productos";
            // 
            // labelPrecioEnvio
            // 
            this.labelPrecioEnvio.AutoSize = true;
            this.labelPrecioEnvio.Location = new System.Drawing.Point(481, 396);
            this.labelPrecioEnvio.Name = "labelPrecioEnvio";
            this.labelPrecioEnvio.Size = new System.Drawing.Size(40, 13);
            this.labelPrecioEnvio.TabIndex = 18;
            this.labelPrecioEnvio.Text = "$Envio";
            // 
            // labelTotalConEnvio
            // 
            this.labelTotalConEnvio.AutoSize = true;
            this.labelTotalConEnvio.Location = new System.Drawing.Point(481, 441);
            this.labelTotalConEnvio.Name = "labelTotalConEnvio";
            this.labelTotalConEnvio.Size = new System.Drawing.Size(88, 13);
            this.labelTotalConEnvio.TabIndex = 19;
            this.labelTotalConEnvio.Text = "$Total con Envio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "__________________________________________________________";
            // 
            // buttonBorrarProducto
            // 
            this.buttonBorrarProducto.ForeColor = System.Drawing.Color.Black;
            this.buttonBorrarProducto.Location = new System.Drawing.Point(712, 254);
            this.buttonBorrarProducto.Name = "buttonBorrarProducto";
            this.buttonBorrarProducto.Size = new System.Drawing.Size(108, 23);
            this.buttonBorrarProducto.TabIndex = 21;
            this.buttonBorrarProducto.Text = "BORRAR";
            this.buttonBorrarProducto.UseVisualStyleBackColor = true;
            this.buttonBorrarProducto.Click += new System.EventHandler(this.buttonBorrarProducto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 34);
            this.label4.TabIndex = 22;
            this.label4.Text = "TU CARRITO:";
            // 
            // textBoxCantidadABorrar
            // 
            this.textBoxCantidadABorrar.Location = new System.Drawing.Point(713, 219);
            this.textBoxCantidadABorrar.Name = "textBoxCantidadABorrar";
            this.textBoxCantidadABorrar.Size = new System.Drawing.Size(77, 20);
            this.textBoxCantidadABorrar.TabIndex = 23;
            this.textBoxCantidadABorrar.TextChanged += new System.EventHandler(this.textBoxCantidadABorrar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(712, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Cantidad que desea borrar:";
            // 
            // errorProviderCantidadABorrar
            // 
            this.errorProviderCantidadABorrar.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(712, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Candad que desea agregar:";
            // 
            // textBoxCantidadAAgregar
            // 
            this.textBoxCantidadAAgregar.Location = new System.Drawing.Point(713, 107);
            this.textBoxCantidadAAgregar.Name = "textBoxCantidadAAgregar";
            this.textBoxCantidadAAgregar.Size = new System.Drawing.Size(77, 20);
            this.textBoxCantidadAAgregar.TabIndex = 26;
            this.textBoxCantidadAAgregar.TextChanged += new System.EventHandler(this.textBoxCambiarCantidad_TextChanged);
            // 
            // buttonAgregarCantidad
            // 
            this.buttonAgregarCantidad.ForeColor = System.Drawing.Color.Black;
            this.buttonAgregarCantidad.Location = new System.Drawing.Point(712, 133);
            this.buttonAgregarCantidad.Name = "buttonAgregarCantidad";
            this.buttonAgregarCantidad.Size = new System.Drawing.Size(108, 23);
            this.buttonAgregarCantidad.TabIndex = 25;
            this.buttonAgregarCantidad.Text = "AGREGAR";
            this.buttonAgregarCantidad.UseVisualStyleBackColor = true;
            this.buttonAgregarCantidad.Click += new System.EventHandler(this.buttonCambiarCantidad_Click);
            // 
            // errorProviderCantidadAAgregar
            // 
            this.errorProviderCantidadAAgregar.ContainerControl = this;
            // 
            // CarritoVisualizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(853, 502);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCantidadAAgregar);
            this.Controls.Add(this.buttonAgregarCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCantidadABorrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBorrarProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTotalConEnvio);
            this.Controls.Add(this.labelPrecioEnvio);
            this.Controls.Add(this.labelPrecioTotalProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAtras);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.dataGridViewCarrito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CarritoVisualizacion";
            this.Text = "Comprar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCantidadABorrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCantidadAAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCarrito;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Button buttonAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPrecioTotalProductos;
        private System.Windows.Forms.Label labelPrecioEnvio;
        private System.Windows.Forms.Label labelTotalConEnvio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBorrarProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCantidadABorrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProviderCantidadABorrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCantidadAAgregar;
        private System.Windows.Forms.Button buttonAgregarCantidad;
        private System.Windows.Forms.ErrorProvider errorProviderCantidadAAgregar;
    }
}