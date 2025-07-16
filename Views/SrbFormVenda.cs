using Google.Protobuf.WellKnownTypes;
using SRB_COMERCIALPDV.Controllers;
using SRB_COMERCIALPDV.Helpers;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRB_COMERCIALPDV.Controls;

namespace SRB_COMERCIALPDV.Views
{
    public partial class SrbFormVenda : Form
    {
        private SrbProdutoController produtoController;
        private SrbVendaController vendaController;
        private SrbCategoriaController categoriaController;
        private SrbFormProduto formProduto;

        private decimal totalVendas = 0;
        private string cupomConteudo = string.Empty;
        private PrintDialog printDialog;
        private PrintPreviewDialog printPreview;

        public SrbFormVenda()
        {
            InitializeComponent();
      
            produtoController = new SrbProdutoController();
            vendaController = new SrbVendaController();
            categoriaController = new SrbCategoriaController();
            this.txtEan.KeyDown += new KeyEventHandler(this.txtEan_KeyDown);
        }

        public SrbFormVenda(SrbFormProduto formProduto) : this()
        {
            this.formProduto = formProduto;
        }

        private void SrbFormVenda_Load(object sender, EventArgs e)
        {
            ConfiguraGridViewVendas();
        }

    



        private void LimparCamposFormulario()
        {
            txtEan.Text = "";
            txtCod.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCampos(txtEan, txtCod, txtNome, txtDescricao, txtPreco, txtQuantidade, null, null, null, null);

            if (!camposValidos)
                return;

            int id = int.Parse(txtId.Text);
            string codigo = txtCod.Text;
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            decimal preco = decimal.Parse(txtPreco.Text, NumberStyles.Currency);
            int quantidade = int.Parse(txtQuantidade.Text);

            decimal subtotal = preco * quantidade;

            dataGridViewVendas.Rows.Add(id, codigo, nome, descricao, preco.ToString("C2"), quantidade);

            totalVendas += subtotal;
            txtTotal.Text = totalVendas.ToString("C2");
        }

        private void ConfiguraGridViewVendas()
        {
            dataGridViewVendas.ColumnCount = 6;

            dataGridViewVendas.Columns[0].Name = "Id";
            dataGridViewVendas.Columns[1].Name = "Código";
            dataGridViewVendas.Columns[2].Name = "Nome";
            dataGridViewVendas.Columns[3].Name = "Descrição";
            dataGridViewVendas.Columns[4].Name = "Preço";
            dataGridViewVendas.Columns[5].Name = "Quantidade";

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

            pagoStr = pagoStr.Replace(".", "");
            if (decimal.TryParse(pagoStr, NumberStyles.Currency, culture, out pago))
            {
                txtPago.Text = string.Format(culture, "{0:C}", pago);

                decimal totalPagar = totalVendas;
                decimal troco = pago - totalPagar;
                lblTroco.Text = troco.ToString("C2", culture);

                foreach (DataGridViewRow row in dataGridViewVendas.Rows)
                {
                    if (row.Cells["Id"].Value != null)
                    {
                        int id;
                        int quantidadeVendida;
                        decimal precoUnitario;

                        bool idValido = int.TryParse(row.Cells["Id"].Value.ToString(), out id);
                        bool quantidadeValida = int.TryParse(row.Cells["Quantidade"].Value.ToString(), out quantidadeVendida);
                        string precoTexto = row.Cells["Preço"].Value.ToString().Trim();

                        precoTexto = precoTexto.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
                        bool precoValido = decimal.TryParse(precoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out precoUnitario);

                        if (!idValido || !quantidadeValida || !precoValido)
                        {
                            MessageBox.Show("Erro ao processar os dados da venda. Verifique os valores.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                SrbTroco = troco
                            };

                            vendaController.AdicionarVenda(venda);
                        }
                    }
                }

                StringBuilder cupom = new StringBuilder();
                cupom.AppendLine("         SRB COMERCIAL - CUPOM FISCAL");
                cupom.AppendLine("============================================");
                cupom.AppendLine($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}");
                cupom.AppendLine("--------------------------------------------");
                cupom.AppendLine("PRODUTO         QTD  VL.UNIT   SUBTOTAL");

                foreach (DataGridViewRow row in dataGridViewVendas.Rows)
                {
                    if (row.Cells["Id"].Value != null)
                    {
                        string nome = row.Cells["Nome"].Value?.ToString() ?? "";
                        int quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString());
                        string precoStr = row.Cells["Preço"].Value.ToString().Trim();

                        precoStr = precoStr.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
                        decimal preco = decimal.Parse(precoStr, CultureInfo.InvariantCulture);
                        decimal subtotal = quantidade * preco;

                        string linha = $"{nome.PadRight(15).Substring(0, 15)} {quantidade.ToString().PadLeft(3)}  {preco.ToString("C", culture).PadLeft(8)} {subtotal.ToString("C", culture).PadLeft(9)}";
                        cupom.AppendLine(linha);
                    }
                }

                cupom.AppendLine("--------------------------------------------");
                cupom.AppendLine($"TOTAL: {totalVendas.ToString("C2", culture)}");
                cupom.AppendLine($"PAGO : {pago.ToString("C2", culture)}");
                cupom.AppendLine($"TROCO: {troco.ToString("C2", culture)}");
                cupom.AppendLine("============================================");
                cupom.AppendLine("      Obrigado pela sua preferência!");

                cupomConteudo = cupom.ToString();
                ImprimirCupom();

                MessageBox.Show("Venda confirmada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridViewVendas.Rows.Clear();
                LimparCamposFormulario();
                txtTotal.Text = "";
                totalVendas = 0;
                formProduto?.RecarregarProdutos();
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor pago válido.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPago.Focus();
            }
        }

        private void ImprimirCupom()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

            printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            printDialog.UseEXDialog = true;

            printPreview = new PrintPreviewDialog();
            printPreview.Document = printDoc;
            printPreview.Width = 800;
            printPreview.Height = 600;

            DialogResult result = MessageBox.Show("Deseja visualizar o cupom antes de imprimir?", "Impressão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                printPreview.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            else if (result == DialogResult.Cancel)
            {
                DialogResult salvarPdf = MessageBox.Show("Deseja salvar o cupom em PDF?", "Salvar PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (salvarPdf == DialogResult.Yes)
                {
                    SalvarCupomComoPdf();
                }
            }
        }

        private void SalvarCupomComoPdf()
        {
            PrintDocument pdfDoc = new PrintDocument();
            pdfDoc.PrintPage += new PrintPageEventHandler(PrintPage);

            pdfDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Filter = "PDF Files|*.pdf";
            salvar.Title = "Salvar cupom como PDF";
            salvar.FileName = "CupomFiscal.pdf";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                pdfDoc.PrinterSettings.PrintToFile = true;
                pdfDoc.PrinterSettings.PrintFileName = salvar.FileName;

                try
                {
                    pdfDoc.Print();
                    MessageBox.Show("Cupom salvo em PDF com sucesso!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fonte = new Font("Courier New", 10);
            float linhaY = 10;

            foreach (string linha in cupomConteudo.Split('\n'))
            {
                e.Graphics.DrawString(linha, fonte, Brushes.Black, 10, linhaY);
                linhaY += 20;
            }
        }

        private void txtEan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string ean = txtEan.Text.Trim();

                if (string.IsNullOrWhiteSpace(ean))
                    return;

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

                        // Quantidade padrão como 1
                        txtQuantidade.Text = "1";

                        // Adicionar automaticamente à venda
                        btnAdicionar.PerformClick();

                        // Limpar para próximo EAN
                        txtEan.Clear();
                        txtEan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Estoque zerado, não há produto para venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparCamposFormulario();
                        txtEan.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimparCamposFormulario();
                    txtEan.Focus();
                }

                e.SuppressKeyPress = true; // evita beep do Enter
            }
        }
    }
}
