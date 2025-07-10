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
    public partial class SrbFormCliente : Form
    {
        private SrbClienteController clienteController;
        private SrbEstadoController estadoController;
        private SrbCidadeController cidadeController;
        public SrbFormCliente()
        {
            InitializeComponent();
           
            clienteController = new SrbClienteController();
            estadoController = new SrbEstadoController();
            cidadeController = new SrbCidadeController();
            ConfigurarDataGridView();
            ConfigurarComboBoxEstado();
            ConfigurarComboBoxCidade();
            RecarregarCliente();
            FormatarGrid();
            dataGridViewCliente.AutoGenerateColumns = true;
            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnCadastrar.Enabled = false;
            btnCadastrar.BackColor = SystemColors.Control;
        }

        // Método para adicionar produtos
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool camposValidos = ValidacaoHelper.ValidaCamposCliente(txtCpf, txtNome, txtEndereco, txtBairro, txtCep, txtTelefone, txtCelular, txtEmail, cmbEstado, cmbCidade);

            if (!camposValidos)
            {
                return;
            }

            string cpf = txtCpf.Text; 
            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string bairro = txtBairro.Text;
            string cep = txtCep.Text;
            string telefone = txtTelefone.Text;
            string celular = txtCelular.Text;
            string email = txtEmail.Text;
            int estadoId = Convert.ToInt32(cmbEstado.SelectedValue);
            int cidadeId = Convert.ToInt32(cmbCidade.SelectedValue);

            SrbCliente cliente = new SrbCliente
            {
                SrbCpf = cpf,
                SrbNome = nome,             
                SrbEndereco = endereco,
                SrbBairro = bairro,
                SrbCep = cep,
                SrbTelefone = telefone,
                SrbCelular = celular,
                SrbEmail = email,
                SrbEstadoId = estadoId,
                SrbCidadeId = cidadeId

            };

            clienteController.AdicionarCliente(cliente);
            MessageBox.Show("Registro salvo com sucesso", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RecarregarCliente();

        }
        private void RecarregarCliente()
        {            
            dataGridViewCliente.Rows.Clear();
            
            List<SrbCliente> clientes = clienteController.ObterCliente();
            
            foreach (var cliente in clientes)
            {
                dataGridViewCliente.Rows.Add(
                    cliente.SrbID,
                    cliente.SrbCpf,
                    cliente.SrbNome,                    
                    cliente.SrbEndereco,
                    cliente.SrbBairro,
                    cliente.SrbCep,
                    cliente.SrbTelefone,
                    cliente.SrbCelular,
                    cliente.SrbEmail,
                    cliente.SrbNomeCidade,
                    cliente.SrbNomeEstado
                    );
            }
        }
        private void ConfigurarComboBoxEstado()
        {
            // Obtém os estados do banco de dados
            List<SrbEstado> estados = estadoController.ObterEstado();

            // Define os estados como fonte de dados do ComboBox
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "uf"; // Exibe o nome do estado no ComboBox
            cmbEstado.ValueMember = "id"; // Usa o Id estado como valor selecionado
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
            dataGridViewCliente.AutoGenerateColumns = false;
            dataGridViewCliente.Columns.Add("SrbId", "ID");
            dataGridViewCliente.Columns.Add("SrbCpf", "Cpf");
            dataGridViewCliente.Columns.Add("SrbNome", "Nome");           
            dataGridViewCliente.Columns.Add("SrbEndereco", "Endereço");
            dataGridViewCliente.Columns.Add("SrbBairro", "Bairro");
            dataGridViewCliente.Columns.Add("SrbCep", "Cep");
            dataGridViewCliente.Columns.Add("SrbTelefone", "Telefone");
            dataGridViewCliente.Columns.Add("SrbCelular", "Celular");
            dataGridViewCliente.Columns.Add("SrbEmail", "Email");
            dataGridViewCliente.Columns.Add(" SrbNomeCidade", "Cidade");
            dataGridViewCliente.Columns.Add("SrbNomeEstado", "Uf");


        }
        private void FormatarGrid()
        {
            // Verificar se o DataGridView possui pelo menos 10 colunas antes de acessar
            if (dataGridViewCliente.Columns.Count >= 10)
            {
                dataGridViewCliente.Columns[0].HeaderText = "ID";
                dataGridViewCliente.Columns[1].HeaderText = "Cpf";
                dataGridViewCliente.Columns[2].HeaderText = "Nome";
                dataGridViewCliente.Columns[3].HeaderText = "Endereço";
                dataGridViewCliente.Columns[4].HeaderText = "Bairro";
                dataGridViewCliente.Columns[5].HeaderText = "Cep";
                dataGridViewCliente.Columns[6].HeaderText = "Telefone";
                dataGridViewCliente.Columns[7].HeaderText = "Celular";
                dataGridViewCliente.Columns[8].HeaderText = "Email";
                dataGridViewCliente.Columns[9].HeaderText = "Cidade";
                dataGridViewCliente.Columns[10].HeaderText = "Uf";

                dataGridViewCliente.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("O DataGridView não possui pelo menos 12 colunas.", "Erro de Formatação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada na grid
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                // Obtém os dados do produto a partir dos campos do formulário
                int idCliente = Convert.ToInt32(txtId.Text);
                string cpf = txtCpf.Text;
                string nome = txtNome.Text;              
                string endereco = txtEndereco.Text;
                string bairro = txtBairro.Text;
                string cep = txtCep.Text;
                string telefone = txtTelefone.Text;
                string celular = txtCelular.Text;
                string email = txtEmail.Text;

                int idCid = Convert.ToInt32(cmbCidade.SelectedValue);
                int id = Convert.ToInt32(cmbEstado.SelectedValue);

                SrbCliente cliente = new SrbCliente
                {
                    SrbID = idCliente,
                    SrbCpf = cpf,
                    SrbNome = nome,                  
                    SrbEndereco = endereco,
                    SrbBairro = bairro,
                    SrbCep = cep,
                    SrbTelefone = telefone,
                    SrbCelular = celular,
                    SrbEmail = email,
                    SrbCidadeId = idCid,
                    SrbEstadoId = id,

                };
                
                clienteController.AtualizarCliente(cliente);
                MessageBox.Show("Cliente alterado com sucesso", "Cadastro de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                RecarregarCliente();             

            }
            else
            {
                MessageBox.Show("Selecione um cliente para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada na grid
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                // Obtém o ID do fornecedor selecionado na grid
                int idCliente = (int)dataGridViewCliente.SelectedRows[0].Cells["SrbID"].Value;

                // Chama o método para remover o produto
                clienteController.RemoverCliente(idCliente);

                // Atualiza a grid de produtos
                RecarregarCliente();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnCadastrar.Enabled = true;
            btnEditar.Enabled = false;
            btnDeletar.Enabled = false;
        }     
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

        

        private void PreencherCampos(SrbCliente cliente)
        {
            txtId.Text = cliente.SrbID.ToString();
            txtCpf.Text = cliente.SrbCpf.ToString();
            txtNome.Text = cliente.SrbNome;
            txtEndereco.Text = cliente.SrbEndereco;
            txtBairro.Text = cliente.SrbBairro;
            txtCep.Text = cliente.SrbCep;
            cmbEstado.SelectedItem = cliente.SrbNomeEstado;
            cmbCidade.SelectedItem = cliente.SrbNomeCidade; 
            txtTelefone.Text = cliente.SrbTelefone;
            txtCelular.Text = cliente.SrbCelular;
            txtEmail.Text = cliente.SrbEmail;
        }
        private void btnBuscaCpf_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text.Trim();
            dataGridViewCliente.Rows.Clear();

            List<SrbCliente> clientes = clienteController.BuscarClientePorCpf(cpf);

            foreach (var cliente in clientes)
            {
                dataGridViewCliente.Rows.Add(cliente.SrbID,
                    cliente.SrbCpf,
                    cliente.SrbNome,
                    cliente.SrbEndereco,
                    cliente.SrbBairro,
                    cliente.SrbCep,
                    cliente.SrbTelefone,
                    cliente.SrbCelular,
                    cliente.SrbEmail,
                    cliente.SrbNomeCidade,
                    cliente.SrbNomeEstado
                    );
            }

            LimparCampos();

            FormatarGrid();

            if (clientes.Count > 0)
            {
                PreencherCampos(clientes[0]);
            }
        }
        private void btnBuscaNome_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            dataGridViewCliente.Rows.Clear();

            List<SrbCliente> clientes = clienteController.BuscarClientePorNome(nome);

            foreach (var cliente in clientes)
            {
                dataGridViewCliente.Rows.Add(cliente.SrbID,
                    cliente.SrbCpf,
                    cliente.SrbNome,
                    cliente.SrbEndereco,
                    cliente.SrbBairro,
                    cliente.SrbCep,
                    cliente.SrbTelefone,
                    cliente.SrbCelular,
                    cliente.SrbEmail,
                    cliente.SrbNomeCidade,
                    cliente.SrbNomeEstado
                    );
            }

            LimparCampos();

            FormatarGrid();

            if (clientes.Count > 0)
            {
                PreencherCampos(clientes[0]);
            }

        }
        private void btnCep_Click(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim();
            dataGridViewCliente.Rows.Clear();

            List<SrbCliente> clientes = clienteController.BuscarClientePorCep(cep);

            foreach (var cliente in clientes)
            {
                dataGridViewCliente.Rows.Add(cliente.SrbID,
                    cliente.SrbCpf,
                    cliente.SrbNome,
                    cliente.SrbEndereco,
                    cliente.SrbBairro,
                    cliente.SrbCep,
                    cliente.SrbTelefone,
                    cliente.SrbCelular,
                    cliente.SrbEmail,
                    cliente.SrbNomeCidade,
                    cliente.SrbNomeEstado
                    );
            }

            LimparCampos();

            FormatarGrid();

            if (clientes.Count > 0)
            {
                PreencherCampos(clientes[0]);
            }
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtCpf.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCep.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            cmbCidade.Text = "";
            cmbEstado.Text = "";
        }

        private void dataGridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                //btnEditar.Enabled = true;
                //btnExcluir.Enabled = true;
                //btnSalvar.Enabled = false;
                //btnNovo.Enabled = false;

                txtId.Text = dataGridViewCliente.CurrentRow.Cells[0].Value.ToString();
                txtCpf.Text = dataGridViewCliente.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = dataGridViewCliente.CurrentRow.Cells[2].Value.ToString();
                txtEndereco.Text = dataGridViewCliente.CurrentRow.Cells[3].Value.ToString();
                txtBairro.Text = dataGridViewCliente.CurrentRow.Cells[4].Value.ToString();
                txtCep.Text = dataGridViewCliente.CurrentRow.Cells[5].Value.ToString();
                txtTelefone.Text = dataGridViewCliente.CurrentRow.Cells[6].Value.ToString();
                txtCelular.Text = dataGridViewCliente.CurrentRow.Cells[7].Value.ToString();
                txtEmail.Text = dataGridViewCliente.CurrentRow.Cells[8].Value.ToString();
                cmbCidade.Text = dataGridViewCliente.CurrentRow.Cells[9].Value.ToString();
                cmbEstado.Text = dataGridViewCliente.CurrentRow.Cells[10].Value.ToString();
            }
            else
            {
                return;

            }
        }
    }
}
