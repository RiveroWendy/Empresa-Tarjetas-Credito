using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace EmpresaTarjeta
{
    public partial class Form1 : Form
    {
        Compra compra = new Compra();
        private List<Cliente> clientes;
        private List<Titular> titulares;
        private List<Tarjeta> tarjetas;
        private bool esPrimeraVezSeleccionadaMoneda = true;
        private bool esPrimeraVezSeleccionadaCliente = true;
        private bool esPrimeraVezSeleccionadaTarjeta = true;
        private bool esPrimeraVezSeleccionadaTitular = true;
        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            InicializarDatos();
            CargarClientes();

        }

        private void InicializarDatos()
        {
            // Inicialización de titulares
            titulares = new List<Titular>
            {
                new Titular { Nombre = "Juan", Apellido = "Fuentes", Documento = 12345678 },
                new Titular { Nombre = "Juan", Apellido = "Martínez", Documento = 12345678 },
                new Titular { Nombre = "Marta", Apellido = "Gómez", Documento = 23456789 },
                new Titular { Nombre = "María", Apellido = "Campos", Documento = 23456789 },
                new Titular { Nombre = "Carlos", Apellido = "López", Documento = 34567891 },
                new Titular { Nombre = "Carlos", Apellido = "Aguero", Documento = 12345678 },
                new Titular { Nombre = "Tomás", Apellido = "Flores", Documento = 45678912 },
                new Titular { Nombre = "Camila", Apellido = "Romero", Documento = 56789123 },
                new Titular { Nombre = "Teresa", Apellido = "Molina", Documento = 678912345 }
            };

            // Inicialización de tarjetas
            tarjetas = new List<Tarjeta>
            {
                new Tarjeta(1545564851547954, 7000, -15000, 3000, 1000),
                new Tarjeta(7789544562044485, 2500,  -2000,  10000),
                new Tarjeta(4657774310115451, 6750, -12000, 10000),
                new Tarjeta(8676345345348087, 5000, -7000, 10000)
            };

            // Inicialización de clientes
            clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nombre = "Juan",
                    Apellido = "Fuentes",
                    Documento = 12345678,
                    Titulares = { titulares[0], titulares[1], titulares[2] },
                    Tarjetas = { tarjetas[0] }
                },
                new Cliente
                {
                    Nombre = "María",
                    Apellido = "Campos",
                    Documento = 23456789,
                    Titulares = { titulares[3], titulares[4] },
                    Tarjetas = { tarjetas[1] }
                },
                new Cliente
                {
                    Nombre = "Carlos",
                    Apellido = "Aguero",
                    Documento = 34567891,
                    Titulares = { titulares[5], titulares[6], titulares[7], titulares[8] },
                    Tarjetas = { tarjetas[2], tarjetas[3] }
                }
            };
        }

        private void CargarClientes()
        {
            cbCliente.Items.Clear();
            foreach (var cliente in clientes)
            {
                cbCliente.Items.Add(cliente.Nombre);
            }
            if (cbCliente.Items.Count > 0)
            {
                cbCliente.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTitular.SelectedItem != null && cbTipoMoneda.SelectedItem != null && cbTarjeta.SelectedItem != null)
                {
                    string cliente = cbTitular.SelectedItem.ToString();
                    string tipoMoneda = cbTipoMoneda.SelectedItem.ToString();
                    string tarjetaCbox = cbTarjeta.SelectedItem.ToString();

                    if (decimal.TryParse(txtMonto.Text, out decimal monto))
                    {
                        if (long.TryParse(tarjetaCbox, out long numeroTarjeta))
                        {
                            Tarjeta tarjetaSeleccionada = tarjetas.Find(x => x.NumeroTarjeta.Equals(numeroTarjeta));

                            if (tarjetaSeleccionada == null)
                            {
                                MessageBox.Show("Tarjeta no encontrada.");
                                return;
                            }

                            decimal montoValidacion = monto;

                            // Verificar límites antes de realizar la compra
                            tarjetaSeleccionada.VerificarLimiteCompra(montoValidacion);
                            tarjetaSeleccionada.VerificarLimiteMaximo(montoValidacion, tipoMoneda);

                            // Si pasa las verificaciones, realizar la compra
                            compra.RecibirCompra(monto);
                            dgvListaCompras.Rows.Add(cliente, numeroTarjeta, monto, tipoMoneda);
                        }
                        else
                        {
                            MessageBox.Show("Tarjeta no válida.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un monto válido.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un cliente, tipo de moneda y tarjeta.");
                }
            }
            catch (ExcepcionMensaje ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtMonto.Text = "";
        }


        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (!esPrimeraVezSeleccionadaCliente && dgvListaCompras.Rows.Count > 1)
            {
                var result = MessageBox.Show("Si cambia el cliente, se limpiará la lista de compras. ¿Desea continuar?", "Confirmar cambio de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvListaCompras.Rows.Clear();
                    compra.Monto = 0;
                }        
            }
            else
            {
                esPrimeraVezSeleccionadaCliente = false;
            }


            if (cbCliente.SelectedItem is string selectedClienteNombre)
            {
                Cliente clienteSeleccionado = clientes.Find(x=> x.Nombre.Equals(selectedClienteNombre));
                compra.Monto = 0;
                cbTipoMoneda.Items.Clear();
                cbTarjeta.Items.Clear();
                cbTitular.Items.Clear();

                foreach (Titular titular in clienteSeleccionado.Titulares)
                {
                    cbTitular.Items.Add(titular.Nombre + " " + titular.Apellido);
                }

                foreach (Tarjeta tarjeta in clienteSeleccionado.Tarjetas)
                {
                    cbTarjeta.Items.Add(tarjeta.NumeroTarjeta);
                }

                if (cbTitular.Items.Count > 0)
                {
                    cbTitular.SelectedIndex = 0;
                }

                if (cbTarjeta.Items.Count > 0)
                {
                    cbTarjeta.SelectedIndex = 0;
                }
            }

            string tarjetaCbox = cbTarjeta.SelectedItem.ToString();

            if (long.TryParse(tarjetaCbox, out long tarjetaCliente))
            {
                Tarjeta tarjetaSeleccionada = tarjetas.Find(x => x.NumeroTarjeta.Equals(tarjetaCliente));
                if (tarjetaSeleccionada.TipoDeTarjeta.NombreTarjeta == "Platinum")
                {
                    lblMontoDolares.Hide();
                    txtMontoDolares.Hide();
                }
                else
                {
                    lblMontoDolares.Show();
                    txtMontoDolares.Show();
                }
            }
        }

        private void dgvListaCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell clienteCell = dgvListaCompras.Rows[e.RowIndex].Cells["Cliente"];
                if (clienteCell != null && clienteCell.Value != null)
                {
                    string cliente = clienteCell.Value.ToString();
                    MessageBox.Show($"Cliente seleccionado: {cliente}");
                }
            }
        }

        private void cbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!esPrimeraVezSeleccionadaTarjeta && dgvListaCompras.Rows.Count > 1)
            {
                var result = MessageBox.Show("Si cambia la tarjeta, se limpiará la lista de compras. ¿Desea continuar?", "Confirmar cambio de tarjeta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvListaCompras.Rows.Clear();
                    compra.Monto = 0;
                }
            }
            else
            {
                esPrimeraVezSeleccionadaTarjeta = false;
            }

            if (cbTarjeta.SelectedItem != null)
            {
                string numeroTarjeta = cbTarjeta.SelectedItem.ToString();
           
                Cliente clienteSeleccionado = clientes.Find(x => x.Nombre.Equals(cbCliente.SelectedItem.ToString()));

                

                // Buscar la tarjeta seleccionada en el cliente
                foreach (Tarjeta tarjeta in clienteSeleccionado.Tarjetas)
                {
                    if (tarjeta.NumeroTarjeta.ToString() == numeroTarjeta)
                    {
                        lblLimiteCompra.Text = $"Límite compra: {tarjeta.LimiteCompra}";
                        lblLimiteMaximo.Text = $"Límite máximo: {tarjeta.LimiteMaximo}";
                        switch (tarjeta.TipoDeTarjeta)
                        {
                            case Black blackTarjeta:
                                lblSaldoPesos.Text = $"Saldo en pesos: {tarjeta.SaldoPesos}";
                                lblSaldoDolares.Text = $"Saldo en dólares: {tarjeta.SaldoDolares}";
                                lblTipoTarjeta.Text = $"Tipo de Tarjeta: Black";
                                cbTipoMoneda.Items.Clear();
                                cbTipoMoneda.Items.Add("Peso");
                                cbTipoMoneda.Items.Add("Dólar");
                                break;
                            case Platinum platinumTarjeta:
                                lblSaldoPesos.Text = $"Saldo en pesos: {tarjeta.SaldoPesos}";
                                lblSaldoDolares.Text = "";
                                lblTipoTarjeta.Text = $"Tipo de Tarjeta: Platinum";
                                cbTipoMoneda.Items.Clear();
                                cbTipoMoneda.Items.Add("Peso");


                                break;
                            default:
                                lblSaldoPesos.Text = "";
                                lblSaldoDolares.Text = "";
                                lblTipoTarjeta.Text = "";
                                break;
                        }

                        break;

                     
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (compra.Monto == 0)
                {
                    MessageBox.Show("Para confirmar las compras estas se deben agregar primero.");
                }
                else
                {

                    if (cbTarjeta.SelectedItem != null)
                    {
                        string numeroTarjeta = cbTarjeta.SelectedItem.ToString();
                        Cliente clienteSeleccionado = clientes.Find(x => x.Nombre.Equals(cbCliente.SelectedItem.ToString()));

                        // Buscar la tarjeta seleccionada en el cliente
                        foreach (Tarjeta tarjeta in clienteSeleccionado.Tarjetas)
                        {
                            if (tarjeta.NumeroTarjeta.ToString() == numeroTarjeta)
                            {
                                string tipoMoneda = cbTipoMoneda.SelectedItem.ToString();
                                decimal gastosAdministrativos = tarjeta.CalcularGastosAdministrativos(compra.Monto, tarjeta.TipoDeTarjeta);
                                decimal totalCompra = gastosAdministrativos + compra.Monto;

                                string message = "El subtotal es: " + compra.Monto.ToString() + "\n";
                                message += "Los gastos administrativos son: " + gastosAdministrativos.ToString() + ".\n";
                                message += "El total de la compra es: " + totalCompra.ToString() + ".";

                                DialogResult result = MessageBox.Show(message, "Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    if (tarjeta.VerificarLimiteCompra(compra.Monto) || tarjeta.VerificarLimiteMaximo(compra.Monto, tipoMoneda))
                                    {
                                        compra.ConfirmarCompra(totalCompra, tipoMoneda, tarjeta);
                                        compra.Monto = 0;
                                        lblSaldoPesos.Text = $"Saldo en pesos: {tarjeta.SaldoPesos}";
                                        if (tarjeta.TipoDeTarjeta.NombreTarjeta == "Black")
                                        {
                                            lblSaldoDolares.Text = $"Saldo en dólares: {tarjeta.SaldoDolares}";
                                        }
                                    }
                                    else
                                    {
                                        compra.Monto = 0;
                                    }
                                
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }

            }
            catch (ExcepcionMensaje ex)
            {
                MessageBox.Show(ex.Message, "Error de compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvListaCompras.Rows.Clear();
            compra.Monto = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvListaCompras.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colCliente = new DataGridViewTextBoxColumn();
            colCliente.Name = "Titular";
            colCliente.HeaderText = "Titular";
            dgvListaCompras.Columns.Add(colCliente);

            DataGridViewTextBoxColumn colTarjeta = new DataGridViewTextBoxColumn();
            colTarjeta.Name = "Tarjeta";
            colTarjeta.HeaderText = "Tarjeta";
            dgvListaCompras.Columns.Add(colTarjeta);

            DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
            colMonto.Name = "Monto";
            colMonto.HeaderText = "Monto";
            dgvListaCompras.Columns.Add(colMonto);

            DataGridViewTextBoxColumn colMoneda = new DataGridViewTextBoxColumn();
            colMoneda.Name = "Moneda";
            colMoneda.HeaderText = "Moneda";
            dgvListaCompras.Columns.Add(colMoneda);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            if (!esPrimeraVezSeleccionadaMoneda && dgvListaCompras.Rows.Count > 1)
            {
                var result = MessageBox.Show("Si cambia la moneda, se limpiará la lista de compras. ¿Desea continuar?", "Confirmar cambio de moneda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvListaCompras.Rows.Clear();
                    compra.Monto = 0;
                }    
            }
            else
            {
                esPrimeraVezSeleccionadaMoneda = false;
            }
        }

        private void cbTitular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!esPrimeraVezSeleccionadaTitular && dgvListaCompras.Rows.Count > 1)
            {
                var result = MessageBox.Show("Si cambia el titular, se limpiará la lista de compras. ¿Desea continuar?", "Confirmar cambio de titular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvListaCompras.Rows.Clear();
                    compra.Monto = 0;
                }
            }
            else
            {
                esPrimeraVezSeleccionadaTitular = false;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void btnMontoDepositar_Click(object sender, EventArgs e)
        {
            string depositoPesosText = txtMontoPesos.Text;
            string depositoDolaresText = txtMontoDolares.Text;

            string tarjetaCbox = cbTarjeta.SelectedItem?.ToString();

            if (tarjetaCbox == null)
            {
                MessageBox.Show("Por favor, seleccione una tarjeta.");
                return;
            }

            if (decimal.TryParse(depositoPesosText, out decimal depositoPesos) && depositoPesos > 0)
            {
                if (long.TryParse(tarjetaCbox, out long tarjetaCliente))
                {
                    Tarjeta tarjetaSeleccionada = tarjetas.Find(x => x.NumeroTarjeta.Equals(tarjetaCliente));
                    decimal calculoImpuestos = tarjetaSeleccionada.CalcularImpuestos(depositoPesos);
                    decimal totalConImpuestos = depositoPesos - calculoImpuestos;
                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea depositar en la tarjeta?" +
                        $"\nValor a ingresar: {depositoPesos}" +
                        $"\nImpuestos a cobrar(%5):{calculoImpuestos}" +
                        $"\nTotal con impuestos:{totalConImpuestos}", "Confirmar Depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                       
                        tarjetaSeleccionada.DepositarPesosTarjeta(totalConImpuestos);
                        lblSaldoPesos.Text = $"Saldo en pesos: {tarjetaSeleccionada.SaldoPesos}";
                        txtMontoPesos.Text = "";
                        MessageBox.Show("Se ha pagado el saldo en pesos de la tarjeta correctamente");
                    }
                }
            }

            if (decimal.TryParse(depositoDolaresText, out decimal depositoDolares) && depositoDolares > 0)
            {
                if (long.TryParse(tarjetaCbox, out long tarjetaCliente))
                {
                    Tarjeta tarjetaSeleccionada = tarjetas.Find(x => x.NumeroTarjeta.Equals(tarjetaCliente));
                    decimal calculoImpuestos = tarjetaSeleccionada.CalcularImpuestos(depositoDolares);
                    decimal totalConImpuestos = depositoDolares - calculoImpuestos;

                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea depositar en la tarjeta?" +
                        $"\nValor a ingresar: {depositoDolares}" +
                        $"\nImpuestos a cobrar(%5):{calculoImpuestos}" +
                        $"\nTotal con impuestos:{totalConImpuestos}", "Confirmar Depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {                                       
                        tarjetaSeleccionada.DepositarDolaresTarjeta(totalConImpuestos);
                        lblSaldoDolares.Text = $"Saldo en dólares: {tarjetaSeleccionada.SaldoDolares}";
                        txtMontoDolares.Text = "";
                        MessageBox.Show("Se ha pagado el saldo en dólares de la tarjeta correctamente");
                    }
                }
            }

            if (long.TryParse(tarjetaCbox, out long tarjetaClienteSeleccionada))
            {
                Tarjeta tarjetaSeleccionada = tarjetas.Find(x => x.NumeroTarjeta.Equals(tarjetaClienteSeleccionada));
                if (tarjetaSeleccionada.TipoDeTarjeta.NombreTarjeta == "Platinum")
                {
                    lblMontoDolares.Hide();
                    txtMontoDolares.Hide();
                }
                else
                {
                    lblMontoDolares.Show();
                    txtMontoDolares.Show();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se ha implementado esta función");

        }

        private void txtMontoPesos_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMontoPesos.Text))
            {
                lblMontoDolares.Hide();
                txtMontoDolares.Hide();
            }
            else
            {
                lblMontoDolares.Show();
                txtMontoDolares.Show();
            }
               
        }

        private void txtMontoDolares_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMontoDolares.Text))
            {
                lblMontoPesos.Hide();
                txtMontoPesos.Hide();
            }
            else
            {
                lblMontoPesos.Show();
                txtMontoPesos.Show();
            }
        }


        private void btnLimpiarCompras_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres vaciar la lista de compras?", "Confirmar vaciado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dgvListaCompras.Rows.Count > 1)
                    {
                        MessageBox.Show("La lista de compras se ha vaciado correctamente");
                        dgvListaCompras.Rows.Clear();
                        compra.Monto = 0;
                    }
                    else
                    {
                        MessageBox.Show("La lista de compras está vacía, no se puede borrar nada");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar la lista de compras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
