using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using SRB_COMERCIALPDV.Controllers;
using SRB_COMERCIALPDV.Helpers;
using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace SRB_COMERCIALPDV.Views
{
    public partial class SrbFormProduto : Form
    {
        private SrbProdutoController produtoController;
        private SrbCategoriaController categoriaController;

        private NotaFiscalService notaFiscalService;


        public SrbFormProduto()
        {
            InitializeComponent();

            produtoController = new SrbProdutoController();
            categoriaController = new SrbCategoriaController();
            notaFiscalService = new NotaFiscalService();
            ConfigurarDataGridView();
            ConfigurarComboBoxCategorias();
            RecarregarProdutos();
            FormatarGrid();
            dataGridViewProdutos.AutoGenerateColumns = true;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnCadastrar.Enabled = false;
            btnCadastrar.BackColor = SystemColors.Control;

        }

        #region
        /* Métodos de operações dos registros */
        public void RecarregarProdutos()
        {
            dataGridViewProdutos.Rows.Clear();
            List<SrbProduto> produtos = produtoController.ObterProdutos();

            foreach (var produto in produtos)
            {
                dataGridViewProdutos.Rows.Add(produto.SrbID, produto.SrbCod, produto.SrbEan, produto.SrbNome, produto.SrbDescricao, produto.SrbPreco, produto.SrbQuantidade, produto.SrbValidade, produto.SrbNcm, produto.SrbCest, produto.SrbNomeCategoria);
            }

            dataGridViewProdutos.ClearSelection(); // Deseleciona todas as linhas após recarregar os dados
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnCadastrar.Enabled = true;
            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
        }       
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCampos(txtCod, txtEan, txtNome, txtDescricao, txtPreco, txtQuantidade, txtValidade, txtNcm, txtCest, cmbCategoria);

            if (!camposValidos)
            {
                return;
            }

            string cod = txtCod.Text;
            string ean = txtEan.Text;
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            decimal preco = Convert.ToDecimal(txtPreco.Text);
            int quantidade = Convert.ToInt32(txtQuantidade.Text);
            string validade = txtValidade.Text;
            string ncm = txtNcm.Text;
            string cest = txtCest.Text;
            int categoriaId = Convert.ToInt32(cmbCategoria.SelectedValue);

            SrbProduto produto = new SrbProduto
            {
                SrbCod = cod,
                SrbEan = ean,
                SrbNome = nome,
                SrbDescricao = descricao,
                SrbPreco = preco,
                SrbQuantidade = Convert.ToInt32(quantidade),
                SrbValidade = Convert.ToDateTime(validade),
                SrbNcm = ncm,
                SrbCest = cest,
                SrbCategoriaId = categoriaId
            };

            produtoController.AdicionarProduto(produto);
            MessageBox.Show("Registro salvo com sucesso", "Cadastro de produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RecarregarProdutos(); // Após salvar, recarrega os produtos na grid

            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;

            LimparCampos();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCampos(txtCod, txtEan, txtNome, txtDescricao, txtPreco, txtQuantidade, txtValidade, txtNcm, txtCest, cmbCategoria);

            if (!camposValidos)
            {
                return;
            }

            if (dataGridViewProdutos.SelectedRows.Count > 0)
            {
                int idProduto = Convert.ToInt32(txtId.Text);
                string cod = txtCod.Text;
                string ean = txtEan.Text;
                string nome = txtNome.Text;
                string descricao = txtDescricao.Text;
                decimal preco = Convert.ToDecimal(txtPreco.Text);
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                string validade = txtValidade.Text;
                string ncm = txtNcm.Text;
                string cest = txtCest.Text;
                int id = Convert.ToInt32(cmbCategoria.SelectedValue);

                SrbProduto produto = new SrbProduto
                {
                    SrbID = idProduto,
                    SrbCod = cod,
                    SrbEan = ean,
                    SrbNome = nome,
                    SrbDescricao = descricao,
                    SrbPreco = preco,
                    SrbQuantidade = Convert.ToInt32(quantidade),
                    SrbValidade = Convert.ToDateTime(validade),
                    SrbNcm = ncm,
                    SrbCest = cest,
                    SrbCategoriaId = id
                };

                produtoController.AtualizarProduto(produto);
                MessageBox.Show("Produto alterado com sucesso", "Cadastro de produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RecarregarProdutos();
                dataGridViewProdutos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Selecione um produto para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {

            if (dataGridViewProdutos.SelectedRows.Count > 0)
            {

                int idProduto = (int)dataGridViewProdutos.SelectedRows[0].Cells["SrbID"].Value;

                produtoController.RemoverProduto(idProduto);

                RecarregarProdutos();
            }
            else
            {
                MessageBox.Show("Selecione um produto para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      




        #endregion

        #region
        /* Métodos auxiliares e comandos de botões */
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;
            btnCadastrar.Enabled = false;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatarGrid()
        {
            dataGridViewProdutos.Columns[0].HeaderText = "ID";
            dataGridViewProdutos.Columns[1].HeaderText = "Codigo";
            dataGridViewProdutos.Columns[2].HeaderText = "Ean";
            dataGridViewProdutos.Columns[3].HeaderText = "Nome";
            dataGridViewProdutos.Columns[4].HeaderText = "Descrição";
            dataGridViewProdutos.Columns[5].HeaderText = "Preço";
            dataGridViewProdutos.Columns[6].HeaderText = "Quantidade";
            dataGridViewProdutos.Columns[7].HeaderText = "Validade";
            dataGridViewProdutos.Columns[8].HeaderText = "Ncm";
            dataGridViewProdutos.Columns[9].HeaderText = "Preço";
            dataGridViewProdutos.Columns[10].HeaderText = "Categoria";

            // Formatando a coluna de preço
            dataGridViewProdutos.Columns[5].DefaultCellStyle.Format = "c2";

            // Ocultando a coluna de ID
            dataGridViewProdutos.Columns[0].Visible = false;
        }
        private void LimparCampos()
        {
            txtCod.Text = "";
            txtEan.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            txtValidade.Text = "";
            txtNcm.Text = "";
            txtCest.Text = "";
            cmbCategoria.SelectedIndex = -1; // Limpa a seleção da ComboBox
        }
        private void ConfigurarComboBoxCategorias()
        {
            // Obtém as categorias do banco de dados
            List<SrbCategoria> categorias = categoriaController.ObterCategoria();

            // Define as categorias como fonte de dados do ComboBox
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "nomeCategoria"; // Exibe o nome da categoria no ComboBox
            cmbCategoria.ValueMember = "id"; // Usa o Id da categoria como valor selecionado
        }
        private void ConfigurarDataGridView()
        {
            dataGridViewProdutos.AutoGenerateColumns = false;
            dataGridViewProdutos.Columns.Add("SrbId", "ID");
            dataGridViewProdutos.Columns.Add("SrbCod", "Codigo");
            dataGridViewProdutos.Columns.Add("SrbEan", "EAN");
            dataGridViewProdutos.Columns.Add("SrbNome", "Nome");
            dataGridViewProdutos.Columns.Add("SrbDescricao", "Descrição");
            dataGridViewProdutos.Columns.Add("SrbPreco", "Preço");
            dataGridViewProdutos.Columns.Add("SrbQuantidade", "Quantidade");
            dataGridViewProdutos.Columns.Add("SrbValidade", "Validade");
            dataGridViewProdutos.Columns.Add("SrbNcm", "Ncm");
            dataGridViewProdutos.Columns.Add("SrbCest", "Cest");
            dataGridViewProdutos.Columns.Add("NomeCategoria", "Categoria");
        }
        private void PreencherCampos(SrbProduto produto)
        {
            txtId.Text = produto.SrbID.ToString();
            txtCod.Text = produto.SrbCod.ToString();
            txtEan.Text = produto.SrbEan;
            txtNome.Text = produto.SrbNome;
            txtDescricao.Text = produto.SrbDescricao;

            string precoText = produto.SrbPreco.ToString();
            precoText = precoText.Replace("$", "").Trim();

            decimal preco = Convert.ToDecimal(precoText);

            txtPreco.Text = preco.ToString();

            txtQuantidade.Text = produto.SrbQuantidade.ToString();

            txtValidade.Text = produto.SrbValidade.ToString("dd/MM/yyyy");
            txtNcm.Text = produto.SrbNcm;
            txtCest.Text = produto.SrbCest;
            cmbCategoria.SelectedItem = produto.SrbNomeCategoria;
        }
        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                txtId.Text = dataGridViewProdutos.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = dataGridViewProdutos.CurrentRow.Cells[1].Value.ToString();
                txtEan.Text = dataGridViewProdutos.CurrentRow.Cells[2].Value.ToString();
                txtNome.Text = dataGridViewProdutos.CurrentRow.Cells[3].Value.ToString();
                txtDescricao.Text = dataGridViewProdutos.CurrentRow.Cells[4].Value.ToString();
                txtPreco.Text = dataGridViewProdutos.CurrentRow.Cells[5].Value.ToString();
                txtQuantidade.Text = dataGridViewProdutos.CurrentRow.Cells[6].Value.ToString();
                txtValidade.Text = dataGridViewProdutos.CurrentRow.Cells[7].Value.ToString();
                txtNcm.Text = dataGridViewProdutos.CurrentRow.Cells[8].Value.ToString();
                txtCest.Text = dataGridViewProdutos.CurrentRow.Cells[9].Value.ToString();
                cmbCategoria.Text = dataGridViewProdutos.CurrentRow.Cells[10].Value.ToString();

            }
            else
            {
                return;
            }
        }
        #endregion

        #region
        /* Métodos de filtros dos registros */
        private void btnBuscarEan_Click(object sender, EventArgs e)
        {
            string ean = txtEan.Text.Trim();
            dataGridViewProdutos.Rows.Clear();

            List<SrbProduto> produtos = produtoController.BuscarProdutoPorEan(ean);

            foreach (var produto in produtos)
            {
                dataGridViewProdutos.Rows.Add(produto.SrbID, produto.SrbCod, produto.SrbEan, produto.SrbNome, produto.SrbDescricao, produto.SrbPreco, produto.SrbQuantidade, produto.SrbValidade, produto.SrbNcm, produto.SrbCest, produto.SrbNomeCategoria);
            }
            LimparCampos();

            FormatarGrid();

            if (produtos.Count > 0)
            {
                PreencherCampos(produtos[0]);
            }
        }
        private void btnBuscaNome_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            dataGridViewProdutos.Rows.Clear();

            List<SrbProduto> produtos = produtoController.BuscarProdutoPorNome(nome);

            foreach (var produto in produtos)
            {
                dataGridViewProdutos.Rows.Add(produto.SrbID, produto.SrbCod, produto.SrbEan, produto.SrbNome, produto.SrbDescricao, produto.SrbPreco, produto.SrbQuantidade, produto.SrbValidade, produto.SrbNcm, produto.SrbCest, produto.SrbNomeCategoria);
            }
            LimparCampos();

            FormatarGrid();

            if (produtos.Count > 0)
            {
                PreencherCampos(produtos[0]);
            }
        }
        private void btnBuscaCodigo_Click(object sender, EventArgs e)
        {
            int codigo;
            bool sucesso = int.TryParse(txtCod.Text.Trim(), out codigo);

            if (sucesso && codigo > 0)
            {
                dataGridViewProdutos.Rows.Clear();

                List<SrbProduto> produtos = produtoController.BuscarProdutoPorCodigo(codigo);

                foreach (var produto in produtos)
                {
                    dataGridViewProdutos.Rows.Add(produto.SrbID, produto.SrbCod, produto.SrbEan, produto.SrbNome, produto.SrbDescricao, produto.SrbPreco, produto.SrbQuantidade, produto.SrbValidade, produto.SrbNcm, produto.SrbCest, produto.SrbNomeCategoria);
                }
                LimparCampos();

                FormatarGrid();

                if (produtos.Count > 0)
                {
                    PreencherCampos(produtos[0]);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido.");
            }
        }
        #endregion

        private void btnImportarXml_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos XML|*.xml";
            openFileDialog.Title = "Selecione o XML da Nota Fiscal";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    notaFiscalService.ImportarProdutosDoXml(openFileDialog.FileName);

                    MessageBox.Show("Produtos importados com sucesso!", "Importação de XML", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RecarregarProdutos(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao importar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
