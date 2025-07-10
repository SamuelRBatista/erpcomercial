using MySqlX.XDevAPI;
using SRB_COMERCIALPDV.Controllers;
using SRB_COMERCIALPDV.Helpers;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV.Views
{
    public partial class SrbFormFornecedor : Form
    {
        private SrbFornecedorController fornecedorController;
        private SrbEstadoController estadoController;
        private SrbCidadeController cidadeController;
        public SrbFormFornecedor()
        {
            InitializeComponent();
           
            ConfigurarDataGridView();
            fornecedorController = new SrbFornecedorController();
            estadoController = new SrbEstadoController();
            cidadeController = new SrbCidadeController();
            ConfigurarComboBoxEstado();
            ConfigurarComboBoxCidade();
            RecarregarFornecedor();
            dataGridViewFornecedor.AutoGenerateColumns = true;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnCadastrar.Enabled = false;
            btnCadastrar.BackColor = SystemColors.Control;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCamposFornecedor(txtCnpj, txtNome, txtRazaoSocial, txtEndereco, txtBairro, txtCep, txtTelefone, txtCelular, txtEmail, cmbEstado, cmbCidade);

            if (!camposValidos)
            {
                return;
            }

            string cnpj = txtCnpj.Text;
            string nome = txtNome.Text;
            string razaosocial = txtRazaoSocial.Text;
            string endereco = txtEndereco.Text;
            string bairro = txtBairro.Text;
            string cep = txtCep.Text;
            string telefone = txtTelefone.Text;
            string celular = txtCelular.Text;
            string email = txtEmail.Text;
            int estadoId = Convert.ToInt32(cmbEstado.SelectedValue);
            int cidadeId = Convert.ToInt32(cmbCidade.SelectedValue);

            SrbFornecedor fornecedor = new SrbFornecedor
            {
                SrbCnpj = cnpj,
                SrbNome = nome,
                SrbRazaoSocial = razaosocial,
                SrbEndereco = endereco,
                SrbBairro = bairro,
                SrbCep = cep,
                SrbTelefone = telefone,
                SrbCelular = celular,
                SrbEmail = email,
                SrbEstadoId = estadoId,
                SrbCidadeId = cidadeId
            };
            fornecedorController.AdicionarFornecedor(fornecedor);
            MessageBox.Show("Registro salvo com sucesso", "Cadastro de fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RecarregarFornecedor();
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;
            btnCadastrar.Enabled = false;
            LimparCampos();
        } 
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
               
                int idFornecedor = Convert.ToInt32(txtId.Text);
                string cnpj = txtCnpj.Text;
                string nome = txtNome.Text;
                string razaosocial = txtRazaoSocial.Text;
                string endereco = txtEndereco.Text;
                string bairro = txtBairro.Text;
                string cep = txtCep.Text;
                string telefone = txtTelefone.Text;
                string celular = txtCelular.Text;
                string email = txtEmail.Text;

                int idCid = Convert.ToInt32(cmbCidade.SelectedValue);
                int id = Convert.ToInt32(cmbEstado.SelectedValue);

                SrbFornecedor fornecedor = new SrbFornecedor
                {
                    SrbID = idFornecedor,
                    SrbCnpj = cnpj,
                    SrbNome = nome,
                    SrbRazaoSocial = razaosocial,
                    SrbEndereco = endereco,
                    SrbBairro = bairro,
                    SrbCep = cep,
                    SrbTelefone = telefone,
                    SrbCelular = celular,
                    SrbEmail = email,
                    SrbCidadeId = idCid,
                    SrbEstadoId = id,
                   
                };
          
                fornecedorController.AtualizarFornecedor(fornecedor);
                MessageBox.Show("Fornecedor alterado com sucesso", "Cadastro de fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                btnEditar.Enabled = true;
                btnDeletar.Enabled = true;
                btnCadastrar.Enabled = false;

                LimparCampos();

                RecarregarFornecedor();             

            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {            
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {              
                int idFornecedor = (int)dataGridViewFornecedor.SelectedRows[0].Cells["SrbID"].Value;

                fornecedorController.RemoverFornecedor(idFornecedor);

                RecarregarFornecedor();
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LimparCampos()
        {
            txtCnpj.Text = "";
            txtNome.Text = "";
            txtRazaoSocial.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            cmbCidade.SelectedIndex = -1; // Limpa a seleção da ComboBox
            cmbEstado.SelectedIndex = -1; // Limpa a seleção da ComboBox
           
           
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnEditar.Enabled = true;
            btnDeletar.Enabled = true;
            btnCadastrar.Enabled = false;
        } 
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnCadastrar.Enabled = true;
            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
        }
        private void dataGridViewFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {

                //btnEditar.Enabled = true;
                //btnExcluir.Enabled = true;
                //btnSalvar.Enabled = false;
                //btnNovo.Enabled = false;

                txtId.Text = dataGridViewFornecedor.CurrentRow.Cells[0].Value.ToString();
                txtCnpj.Text = dataGridViewFornecedor.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = dataGridViewFornecedor.CurrentRow.Cells[2].Value.ToString();
                txtRazaoSocial.Text = dataGridViewFornecedor.CurrentRow.Cells[3].Value.ToString();
                txtEndereco.Text = dataGridViewFornecedor.CurrentRow.Cells[4].Value.ToString();
                txtBairro.Text = dataGridViewFornecedor.CurrentRow.Cells[5].Value.ToString();
                txtCep.Text = dataGridViewFornecedor.CurrentRow.Cells[6].Value.ToString();
                txtTelefone.Text = dataGridViewFornecedor.CurrentRow.Cells[7].Value.ToString();
                txtCelular.Text = dataGridViewFornecedor.CurrentRow.Cells[8].Value.ToString();
                txtEmail.Text = dataGridViewFornecedor.CurrentRow.Cells[9].Value.ToString();
                cmbCidade.Text = dataGridViewFornecedor.CurrentRow.Cells[10].Value.ToString();
                cmbEstado.Text = dataGridViewFornecedor.CurrentRow.Cells[11].Value.ToString();

            }
            else
            {
                return;

            }

        }
        private void RecarregarFornecedor()
        {         
            dataGridViewFornecedor.Rows.Clear();
            
            List<SrbFornecedor> fornecedores = fornecedorController.ObterFornecedor();

            foreach (var fornecedor in fornecedores)
            {
                dataGridViewFornecedor.Rows.Add(
                    fornecedor.SrbID,
                    fornecedor.SrbCnpj,
                    fornecedor.SrbNome,
                    fornecedor.SrbRazaoSocial,
                    fornecedor.SrbEndereco,
                    fornecedor.SrbBairro,
                    fornecedor.SrbCep,
                    fornecedor.SrbTelefone,
                    fornecedor.SrbCelular,
                    fornecedor.SrbEmail,
                     fornecedor.SrbNomeCidade,
                    fornecedor.SrbNomeEstado

                    );
            }
        }
        private void ConfigurarComboBoxEstado()
        {            
            List<SrbEstado> estados = estadoController.ObterEstado();           
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "uf"; 
            cmbEstado.ValueMember = "id";
        }
        private void ConfigurarComboBoxCidade()
        {
            // Obtém os estados do banco de dados
            List<SrbCidade> cidades = cidadeController.ObterCidade();

            // Define os estados como fonte de dados do ComboBox
            cmbCidade.DataSource = cidades;
            cmbCidade.DisplayMember = "nomeCidade"; // Exibe o nome do estado no ComboBox
            cmbCidade.ValueMember = "id"; // Usa o Id estado como valor selecionado
        }
        private void ConfigurarDataGridView()
        {
            dataGridViewFornecedor.AutoGenerateColumns = false;
            dataGridViewFornecedor.Columns.Add("SrbId", "ID");
            dataGridViewFornecedor.Columns.Add("SrbCnpj", "Cnpj");
            dataGridViewFornecedor.Columns.Add("SrbNome", "Nome");
            dataGridViewFornecedor.Columns.Add("SrbRazaoSocial", "Razão Social");
            dataGridViewFornecedor.Columns.Add("SrbEndereco", "Endereço");
            dataGridViewFornecedor.Columns.Add("SrbBairro", "Bairro");
            dataGridViewFornecedor.Columns.Add("SrbCep", "Cep");
            dataGridViewFornecedor.Columns.Add("SrbTelefone", "Telefone");
            dataGridViewFornecedor.Columns.Add("SrbCelular", "Celular");
            dataGridViewFornecedor.Columns.Add("SrbEmail", "Email");
            dataGridViewFornecedor.Columns.Add(" SrbNomeCidade", "Cidade");
            dataGridViewFornecedor.Columns.Add("SrbNomeEstado", "Uf");


        }
        private void FormatarGrid()
        {
            dataGridViewFornecedor.Columns[0].HeaderText = "ID";
            dataGridViewFornecedor.Columns[1].HeaderText = "Cnpj";
            dataGridViewFornecedor.Columns[2].HeaderText = "Nome";
            dataGridViewFornecedor.Columns[3].HeaderText = "Razão Social";
            dataGridViewFornecedor.Columns[4].HeaderText = "Endereço";
            dataGridViewFornecedor.Columns[5].HeaderText = "Bairro";
            dataGridViewFornecedor.Columns[6].HeaderText = "Cep";
            dataGridViewFornecedor.Columns[7].HeaderText = "Telefone";
            dataGridViewFornecedor.Columns[8].HeaderText = "Celular";
            dataGridViewFornecedor.Columns[9].HeaderText = "Email";
            dataGridViewFornecedor.Columns[10].HeaderText = "Cidade";
            dataGridViewFornecedor.Columns[11].HeaderText = "Uf";


            //gridum.Width[2] = "300";
            //formatar coluna  moeda

            //grid.Columns[10].DefaultCellStyle.Format = "c2";
            //grid.Columns[11].DefaultCellStyle.Format = "c2";
            //grid.Columns[12].DefaultCellStyle.Format = "c2";
            dataGridViewFornecedor.Columns[0].Visible = false;
            //grid.Columns[11].Visible = false;
            //grid.Columns[7].Visible = false;
        }


        private void btnBuscaCnpj_Click(object sender, EventArgs e)
        {
            string cnpj = txtCnpj.Text.Trim();
            dataGridViewFornecedor.Rows.Clear();

            List<SrbFornecedor> fornecedores = fornecedorController.BuscarFornecedorPorCnpj(cnpj);

            foreach (var fornecedor in fornecedores)
            {
                dataGridViewFornecedor.Rows.Add(
                     fornecedor.SrbID,
                     fornecedor.SrbCnpj,
                     fornecedor.SrbNome,
                     fornecedor.SrbRazaoSocial,
                     fornecedor.SrbEndereco,
                     fornecedor.SrbBairro,
                     fornecedor.SrbCep,
                     fornecedor.SrbTelefone,
                     fornecedor.SrbCelular,
                     fornecedor.SrbEmail,
                      fornecedor.SrbNomeCidade,
                     fornecedor.SrbNomeEstado

                     );
            }
            LimparCampos();

            FormatarGrid();

            if (fornecedores.Count > 0)
            {
                PreencherCampos(fornecedores[0]);
            }
        }       
        private void PreencherCampos(SrbFornecedor fornecedor)
        {
            txtId.Text = fornecedor.SrbID.ToString();
            txtCnpj.Text = fornecedor.SrbCnpj.ToString();
            txtNome.Text = fornecedor.SrbNome;
            txtRazaoSocial.Text = fornecedor.SrbRazaoSocial;
            txtEndereco.Text = fornecedor.SrbEndereco;
            txtBairro.Text = fornecedor.SrbBairro;
            txtCep.Text = fornecedor.SrbCep;
            cmbEstado.SelectedItem = fornecedor.SrbNomeEstado;
            cmbCidade.SelectedItem = fornecedor.SrbNomeCidade;
            txtTelefone.Text = fornecedor.SrbTelefone;
            txtCelular.Text = fornecedor.SrbCelular;
            txtEmail.Text = fornecedor.SrbEmail;
        }
        private void btnBuscaNome_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            dataGridViewFornecedor.Rows.Clear();

            List<SrbFornecedor> fornecedores = fornecedorController.BuscaFornecedorPorNome(nome);

            foreach (var fornecedor in fornecedores)
            {
                dataGridViewFornecedor.Rows.Add(
                     fornecedor.SrbID,
                     fornecedor.SrbCnpj,
                     fornecedor.SrbNome,
                     fornecedor.SrbRazaoSocial,
                     fornecedor.SrbEndereco,
                     fornecedor.SrbBairro,
                     fornecedor.SrbCep,
                     fornecedor.SrbTelefone,
                     fornecedor.SrbCelular,
                     fornecedor.SrbEmail,
                      fornecedor.SrbNomeCidade,
                     fornecedor.SrbNomeEstado

                     );
            }
            LimparCampos();

            FormatarGrid();

            if (fornecedores.Count > 0)
            {
                PreencherCampos(fornecedores[0]);
            }

        }
        private void btnBuscaRazaoSocial_Click(object sender, EventArgs e)
        {
            string nomeRazao = txtRazaoSocial.Text.Trim();

            dataGridViewFornecedor.Rows.Clear();

            List<SrbFornecedor> fornecedores = fornecedorController.BuscarFornecedorPorRazaoSocial(nomeRazao);

            foreach (var fornecedor in fornecedores)
            {
                dataGridViewFornecedor.Rows.Add(
                     fornecedor.SrbID,
                     fornecedor.SrbCnpj,
                     fornecedor.SrbNome,
                     fornecedor.SrbRazaoSocial,
                     fornecedor.SrbEndereco,
                     fornecedor.SrbBairro,
                     fornecedor.SrbCep,
                     fornecedor.SrbTelefone,
                     fornecedor.SrbCelular,
                     fornecedor.SrbEmail,
                      fornecedor.SrbNomeCidade,
                     fornecedor.SrbNomeEstado

                     );
            }
            LimparCampos();

            FormatarGrid();

            if (fornecedores.Count > 0)
            {
                PreencherCampos(fornecedores[0]);
            }
        }
    }
}
