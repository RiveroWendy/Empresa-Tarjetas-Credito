namespace EmpresaTarjeta
{
    partial class Form1
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
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbTarjeta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListaCompras = new System.Windows.Forms.DataGridView();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnConfirmarCompra = new System.Windows.Forms.Button();
            this.cbTipoMoneda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaldoPesos = new System.Windows.Forms.Label();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMontoDepositar = new System.Windows.Forms.Button();
            this.lblSaldoDolares = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTitular = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblLimiteMaximo = new System.Windows.Forms.Label();
            this.lblLimiteCompra = new System.Windows.Forms.Label();
            this.txtMontoPesos = new System.Windows.Forms.TextBox();
            this.lblMontoPesos = new System.Windows.Forms.Label();
            this.txtMontoDolares = new System.Windows.Forms.TextBox();
            this.lblMontoDolares = new System.Windows.Forms.Label();
            this.btnLimpiarCompras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(25, 79);
            this.cbCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(199, 24);
            this.cbCliente.TabIndex = 0;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(24, 52);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(119, 16);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Seleccione Cliente";
            // 
            // cbTarjeta
            // 
            this.cbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTarjeta.FormattingEnabled = true;
            this.cbTarjeta.Location = new System.Drawing.Point(457, 79);
            this.cbTarjeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTarjeta.Name = "cbTarjeta";
            this.cbTarjeta.Size = new System.Drawing.Size(199, 24);
            this.cbTarjeta.TabIndex = 2;
            this.cbTarjeta.SelectedIndexChanged += new System.EventHandler(this.cbTarjeta_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione Tarjeta Asociada";
            // 
            // dgvListaCompras
            // 
            this.dgvListaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCompras.Location = new System.Drawing.Point(25, 198);
            this.dgvListaCompras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListaCompras.Name = "dgvListaCompras";
            this.dgvListaCompras.ReadOnly = true;
            this.dgvListaCompras.RowHeadersWidth = 51;
            this.dgvListaCompras.RowTemplate.Height = 24;
            this.dgvListaCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaCompras.Size = new System.Drawing.Size(712, 319);
            this.dgvListaCompras.TabIndex = 4;
            this.dgvListaCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCompras_CellContentClick);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(27, 149);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(193, 22);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(27, 126);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(92, 16);
            this.lblMonto.TabIndex = 6;
            this.lblMonto.Text = "Ingrese Monto";
            // 
            // btnCompra
            // 
            this.btnCompra.Location = new System.Drawing.Point(463, 146);
            this.btnCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(123, 31);
            this.btnCompra.TabIndex = 7;
            this.btnCompra.Text = "Agregar Compra";
            this.btnCompra.UseVisualStyleBackColor = true;
            this.btnCompra.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirmarCompra
            // 
            this.btnConfirmarCompra.Location = new System.Drawing.Point(604, 148);
            this.btnConfirmarCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmarCompra.Name = "btnConfirmarCompra";
            this.btnConfirmarCompra.Size = new System.Drawing.Size(133, 31);
            this.btnConfirmarCompra.TabIndex = 8;
            this.btnConfirmarCompra.Text = "Confirmar Compra";
            this.btnConfirmarCompra.UseVisualStyleBackColor = true;
            this.btnConfirmarCompra.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTipoMoneda
            // 
            this.cbTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMoneda.FormattingEnabled = true;
            this.cbTipoMoneda.Location = new System.Drawing.Point(241, 150);
            this.cbTipoMoneda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoMoneda.Name = "cbTipoMoneda";
            this.cbTipoMoneda.Size = new System.Drawing.Size(199, 24);
            this.cbTipoMoneda.TabIndex = 9;
            this.cbTipoMoneda.SelectedIndexChanged += new System.EventHandler(this.cbTipoMoneda_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo Moneda";
            // 
            // lblSaldoPesos
            // 
            this.lblSaldoPesos.AutoSize = true;
            this.lblSaldoPesos.Location = new System.Drawing.Point(223, 546);
            this.lblSaldoPesos.Name = "lblSaldoPesos";
            this.lblSaldoPesos.Size = new System.Drawing.Size(145, 16);
            this.lblSaldoPesos.TabIndex = 11;
            this.lblSaldoPesos.Text = "Saldo Restante Pesos:";
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.Location = new System.Drawing.Point(23, 546);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(103, 16);
            this.lblTipoTarjeta.TabIndex = 12;
            this.lblTipoTarjeta.Text = "Tipo de Tarjeta:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(747, 654);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 39);
            this.button3.TabIndex = 13;
            this.button3.Text = "Alta Tarjeta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMontoDepositar
            // 
            this.btnMontoDepositar.Location = new System.Drawing.Point(199, 670);
            this.btnMontoDepositar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMontoDepositar.Name = "btnMontoDepositar";
            this.btnMontoDepositar.Size = new System.Drawing.Size(131, 48);
            this.btnMontoDepositar.TabIndex = 14;
            this.btnMontoDepositar.Text = "Depositar";
            this.btnMontoDepositar.UseVisualStyleBackColor = true;
            this.btnMontoDepositar.Click += new System.EventHandler(this.btnMontoDepositar_Click);
            // 
            // lblSaldoDolares
            // 
            this.lblSaldoDolares.AutoSize = true;
            this.lblSaldoDolares.Location = new System.Drawing.Point(453, 546);
            this.lblSaldoDolares.Name = "lblSaldoDolares";
            this.lblSaldoDolares.Size = new System.Drawing.Size(154, 16);
            this.lblSaldoDolares.TabIndex = 15;
            this.lblSaldoDolares.Text = "Saldo Restante Dolares:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Seleccione titular";
            // 
            // cbTitular
            // 
            this.cbTitular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTitular.FormattingEnabled = true;
            this.cbTitular.Location = new System.Drawing.Point(239, 79);
            this.cbTitular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTitular.Name = "cbTitular";
            this.cbTitular.Size = new System.Drawing.Size(199, 24);
            this.cbTitular.TabIndex = 16;
            this.cbTitular.SelectedIndexChanged += new System.EventHandler(this.cbTitular_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(747, 711);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(216, 39);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblLimiteMaximo
            // 
            this.lblLimiteMaximo.AutoSize = true;
            this.lblLimiteMaximo.Location = new System.Drawing.Point(223, 598);
            this.lblLimiteMaximo.Name = "lblLimiteMaximo";
            this.lblLimiteMaximo.Size = new System.Drawing.Size(98, 16);
            this.lblLimiteMaximo.TabIndex = 19;
            this.lblLimiteMaximo.Text = "Límite máximo: ";
            // 
            // lblLimiteCompra
            // 
            this.lblLimiteCompra.AutoSize = true;
            this.lblLimiteCompra.Location = new System.Drawing.Point(27, 598);
            this.lblLimiteCompra.Name = "lblLimiteCompra";
            this.lblLimiteCompra.Size = new System.Drawing.Size(97, 16);
            this.lblLimiteCompra.TabIndex = 20;
            this.lblLimiteCompra.Text = "Límite compra: ";
            // 
            // txtMontoPesos
            // 
            this.txtMontoPesos.Location = new System.Drawing.Point(20, 670);
            this.txtMontoPesos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoPesos.Name = "txtMontoPesos";
            this.txtMontoPesos.Size = new System.Drawing.Size(152, 22);
            this.txtMontoPesos.TabIndex = 21;
            this.txtMontoPesos.TextChanged += new System.EventHandler(this.txtMontoPesos_TextChanged);
            this.txtMontoPesos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblMontoPesos
            // 
            this.lblMontoPesos.AutoSize = true;
            this.lblMontoPesos.Location = new System.Drawing.Point(21, 647);
            this.lblMontoPesos.Name = "lblMontoPesos";
            this.lblMontoPesos.Size = new System.Drawing.Size(134, 16);
            this.lblMontoPesos.TabIndex = 22;
            this.lblMontoPesos.Text = "Ingrese Monto Pesos";
            // 
            // txtMontoDolares
            // 
            this.txtMontoDolares.Location = new System.Drawing.Point(20, 720);
            this.txtMontoDolares.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoDolares.Name = "txtMontoDolares";
            this.txtMontoDolares.Size = new System.Drawing.Size(152, 22);
            this.txtMontoDolares.TabIndex = 23;
            this.txtMontoDolares.TextChanged += new System.EventHandler(this.txtMontoDolares_TextChanged);
            this.txtMontoDolares.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblMontoDolares
            // 
            this.lblMontoDolares.AutoSize = true;
            this.lblMontoDolares.Location = new System.Drawing.Point(21, 702);
            this.lblMontoDolares.Name = "lblMontoDolares";
            this.lblMontoDolares.Size = new System.Drawing.Size(143, 16);
            this.lblMontoDolares.TabIndex = 24;
            this.lblMontoDolares.Text = "Ingrese Monto Dolares";
            // 
            // btnLimpiarCompras
            // 
            this.btnLimpiarCompras.Location = new System.Drawing.Point(746, 480);
            this.btnLimpiarCompras.Name = "btnLimpiarCompras";
            this.btnLimpiarCompras.Size = new System.Drawing.Size(216, 36);
            this.btnLimpiarCompras.TabIndex = 25;
            this.btnLimpiarCompras.Text = "Vaciar Lista Compras";
            this.btnLimpiarCompras.UseVisualStyleBackColor = true;
            this.btnLimpiarCompras.Click += new System.EventHandler(this.btnLimpiarCompras_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 764);
            this.Controls.Add(this.btnLimpiarCompras);
            this.Controls.Add(this.lblMontoDolares);
            this.Controls.Add(this.txtMontoDolares);
            this.Controls.Add(this.lblMontoPesos);
            this.Controls.Add(this.txtMontoPesos);
            this.Controls.Add(this.lblLimiteCompra);
            this.Controls.Add(this.lblLimiteMaximo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTitular);
            this.Controls.Add(this.lblSaldoDolares);
            this.Controls.Add(this.btnMontoDepositar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblTipoTarjeta);
            this.Controls.Add(this.lblSaldoPesos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTipoMoneda);
            this.Controls.Add(this.btnConfirmarCompra);
            this.Controls.Add(this.btnCompra);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dgvListaCompras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTarjeta);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbCliente);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Sistema de tarjetas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaCompras;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnConfirmarCompra;
        private System.Windows.Forms.ComboBox cbTipoMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaldoPesos;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMontoDepositar;
        private System.Windows.Forms.Label lblSaldoDolares;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTitular;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblLimiteMaximo;
        private System.Windows.Forms.Label lblLimiteCompra;
        private System.Windows.Forms.TextBox txtMontoPesos;
        private System.Windows.Forms.Label lblMontoPesos;
        private System.Windows.Forms.TextBox txtMontoDolares;
        private System.Windows.Forms.Label lblMontoDolares;
        private System.Windows.Forms.Button btnLimpiarCompras;
    }
}

