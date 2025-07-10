using Google.Protobuf.WellKnownTypes;
using SRB_COMERCIALPDV.Controllers;
using SRB_COMERCIALPDV.Helpers;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV.Views
{
    public partial class SrbFormVenda : Form
    {

        private SrbProdutoController produtoController;
        private SrbVendaController vendaController;
        private SrbCategoriaController categoriaController;
        private SrbFormProduto formProduto;

        public SrbFormVenda()
        {
            InitializeComponent();           
            produtoController = new SrbProdutoController();
            vendaController = new SrbVendaController();
            categoriaController = new SrbCategoriaController();
        }

        public SrbFormVenda(SrbFormProduto formProduto)
        {
            InitializeComponent();
            this.formProduto = formProduto;
        }

        private void SrbFormVenda_Load(object sender, EventArgs e)
        {
            ConfiguraGridViewVendas();
        }

        private void txtEan_TextChanged(object sender, EventArgs e)
        {
            string ean = txtEan.Text.Trim();

            List<SrbProduto> produtos = produtoController.BuscarProdutoPorEan(ean);

            if (produtos != null && produtos.Count > 0)
            {

                SrbProduto produto = produtos[0];
                if (produto.SrbQuantidade > 0)
                {
                    txtId.Text = produto.SrbID.ToString();
                    txtCod.Text = produto.SrbCod.ToString();
                    txtNome.Text = produto.SrbNome;
                    txtDescricao.Text = produto.SrbDescricao;
                    txtPreco.Text = produto.SrbPreco.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                }
                else
                {
                    MessageBox.Show("Estoque zerado não possui produto para venda", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCamposFormulario();
                    txtEan.Focus();
                    return;
                }               
            }
            else
            {
                LimparCamposFormulario();
            }
        }

        private void LimparCamposFormulario()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            lblTotalPagar.Text = "";
        }

        private decimal totalVendas = 0;

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCampos(txtCod, txtEan, txtNome, txtDescricao, txtPreco, txtQuantidade, null, null, null, null);

            if (!camposValidos)
            {
                return;
            }

            int id = int.Parse(txtId.Text);
            int codigo = int.Parse(txtCod.Text);
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;

            decimal preco = decimal.Parse(txtPreco.Text, NumberStyles.Currency);

            int quantidade = int.Parse(txtQuantidade.Text);

            decimal subtotal = preco * quantidade;

            dataGridViewVendas.Rows.Add(id, nome, descricao, preco.ToString("C2"), quantidade);

            // Acumula o valor da venda no total de vendas
            totalVendas += subtotal;
            lblTotalPagar.Text = totalVendas.ToString("C2");
        }

        private void ConfiguraGridViewVendas()
        {
            // Configurar as colunas da DataGridView
            dataGridViewVendas.ColumnCount = 5; // Número de colunas visíveis

            // Configurar o cabeçalho das colunas
            dataGridViewVendas.Columns[0].Name = "Id";
            dataGridViewVendas.Columns[1].Name = "Nome";
            dataGridViewVendas.Columns[2].Name = "Descrição";
            dataGridViewVendas.Columns[3].Name = "Preço";
            dataGridViewVendas.Columns[4].Name = "Quantidade";

            // Estilizar a DataGridView para parecer um cupom fiscal
            dataGridViewVendas.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridViewVendas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridViewVendas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewVendas.DefaultCellStyle.BackColor = Color.White;
            dataGridViewVendas.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewVendas.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            dataGridViewVendas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewVendas.EnableHeadersVisualStyles = false;
            dataGridViewVendas.RowHeadersVisible = false;

            dataGridViewVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewVendas.MultiSelect = false;
            dataGridViewVendas.AllowUserToAddRows = false;
            dataGridViewVendas.AllowUserToDeleteRows = false;
            dataGridViewVendas.AllowUserToResizeRows = false;
            dataGridViewVendas.AllowUserToResizeColumns = false;
            dataGridViewVendas.AllowUserToOrderColumns = false;

            dataGridViewVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVendas.BackgroundColor = Color.White;

            dataGridViewVendas.BorderStyle = BorderStyle.None;
            dataGridViewVendas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewVendas.GridColor = Color.White;

            dataGridViewVendas.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridViewVendas.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmaVenda_Click(object sender, EventArgs e)
        {
            string pagoStr = txtPago.Text;
            decimal pago;

            CultureInfo culture = new CultureInfo("pt-BR");
            pagoStr = pagoStr.Replace('.', ',');
            if (decimal.TryParse(pagoStr, NumberStyles.Currency, culture, out pago))
            {
                txtPago.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", pago);
                decimal totalPagar = totalVendas;
                decimal troco = pago - totalPagar;  // Calcula o troco aqui
                lblTroco.Text = troco.ToString("C2");

                SrbVendaController vendaController = new SrbVendaController();

                // Log dos nomes das colunas disponíveis
                foreach (DataGridViewColumn column in dataGridViewVendas.Columns)
                {
                    Console.WriteLine($"Column Name: {column.Name}");
                }

                foreach (DataGridViewRow row in dataGridViewVendas.Rows)
                {
                    if (row.Cells["Id"].Value != null) // Verifica se a linha não está vazia
                    {
                        int id;
                        int quantidadeVendida;
                        decimal precoUnitario;

                        // Validação e parsing dos valores das células
                        bool idValido = int.TryParse(row.Cells["Id"].Value.ToString(), out id);
                        bool quantidadeValida = int.TryParse(row.Cells["Quantidade"].Value.ToString(), out quantidadeVendida);
                        bool precoValido = decimal.TryParse(row.Cells["Preço"].Value.ToString().Replace('.', ','), NumberStyles.Currency, culture, out precoUnitario);

                        if (!idValido || !quantidadeValida || !precoValido)
                        {
                            MessageBox.Show("Erro ao processar os dados da venda. Verifique se todos os valores estão corretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SrbProduto produto = produtoController.BuscarProdutoPorId(id);
                        if (produto != null)
                        {
                            int novaQuantidade = produto.SrbQuantidade - quantidadeVendida;
                            produtoController.AtualizarQuantidadeProduto(id, novaQuantidade);

                            SrbVenda venda = new SrbVenda
                            {
                                SrbVendaId = id,
                                SrbQuantidade = quantidadeVendida,
                                SrbPrecoUnitario = precoUnitario,
                                SrbDataVenda = DateTime.Now,
                                SrbValorPago = pago,
                                SrbTroco = troco  // Usa o troco calculado
                            };

                            vendaController.AdicionarVenda(venda); // Salva os dados da venda no banco de dados
                            LimparCamposFormulario();
                        }
                    }
                }

                MessageBox.Show("Venda confirmada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewVendas.Rows.Clear();
                LimparCamposFormulario();
                formProduto?.RecarregarProdutos();
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor pago válido.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPago.Focus();
            }
        }





    }
}

