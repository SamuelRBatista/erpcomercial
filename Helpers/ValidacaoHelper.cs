using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV.Helpers
{
    public class ValidacaoHelper
    {

        public static bool ValidaCampos(TextBox txtCod, TextBox txtEan, TextBox txtNome, TextBox txtDescricao, TextBox txtPreco, TextBox txtQuantidade, TextBox txtValidade, TextBox txtNcm, TextBox txtCest, ComboBox cmbCategoria)
        {
            if (txtCod != null && string.IsNullOrWhiteSpace(txtCod.Text))
            {
                MessageBox.Show("Por favor, insira o código do produto.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCod.Focus();
                return false;
            }

            //if (txtEan != null && (string.IsNullOrWhiteSpace(txtEan.Text) || !Regex.IsMatch(txtEan.Text, @"^\d{13}$")))
            //{
            //    MessageBox.Show("Por favor, insira um EAN válido com 13 dígitos numéricos.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtEan.Focus();
            //    return false;
            //}

            if (txtNome != null && (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length > 100))
            {
                MessageBox.Show("O nome do produto não pode ter mais de 100 caracteres.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }

            if (txtDescricao != null && (string.IsNullOrWhiteSpace(txtDescricao.Text) || txtDescricao.Text.Length > 150))
            {
                MessageBox.Show("A descrição não pode ter mais de 150 caracteres.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
                return false;
            }

            if (txtPreco != null && string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                MessageBox.Show("Por favor, insira um preço válido.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPreco.Focus();
                return false;
            }

            if (txtQuantidade != null)
            {
                int quantidade;
                if (!int.TryParse(txtQuantidade.Text, out quantidade))
                {
                    MessageBox.Show("Por favor, inclua uma quantidade válida.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                    return false;
                }
            }

            if (txtValidade != null && string.IsNullOrWhiteSpace(txtValidade.Text))
            {
                MessageBox.Show("Por favor, insira a validade do produto.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValidade.Focus();
                return false;
            }

            if (txtNcm != null && (string.IsNullOrWhiteSpace(txtNcm.Text) || txtNcm.Text.Length != 8 || !txtNcm.Text.All(char.IsDigit)))
            {
                MessageBox.Show("O NCM inserido é inválido. Por favor, insira um valor numérico de 8 dígitos.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNcm.Focus();
                return false;
            }

            if (txtCest != null && (string.IsNullOrWhiteSpace(txtCest.Text) || txtCest.Text.Length != 7 || !txtCest.Text.All(char.IsDigit)))
            {
                MessageBox.Show("O CEST inserido é inválido. Por favor, insira um valor numérico de 7 dígitos.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCest.Focus();
                return false;
            }

            if (cmbCategoria != null && string.IsNullOrWhiteSpace(cmbCategoria.Text))
            {
                MessageBox.Show("Por favor, insira a categoria do produto.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        public static bool ValidaCamposCliente(TextBox txtCpf, TextBox txtNome, TextBox txtEndereco, TextBox txtBairro, TextBox txtCep, TextBox txtTelefone, TextBox txtCelular, TextBox txtEmail, ComboBox cmbEstado, ComboBox cmbCidade)
        {   
            if (string.IsNullOrWhiteSpace(txtCpf.Text) || !Regex.IsMatch(txtCpf.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Por favor, insira o cpf do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text) || !Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o nome do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEndereco.Text)||!Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o endereço do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndereco.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBairro.Text) || !Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o bairro do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBairro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCep.Text) && Regex.IsMatch(txtCep.Text, @"^\d{8}$"))
            {
                MessageBox.Show("Por favor, insira o cep do cliente", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCep.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Por favor, insira o telefone do clinete.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Por favor, insira o celular do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCelular.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, insira o e-mail do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Por favor, insira o estado do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCidade.Text))
            {
                MessageBox.Show("Por favor, insira a cidade do cliente.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCidade.Focus();
                return false;
            }
            return true;

        }

        public static bool ValidaCamposFornecedor(TextBox txtCnpj, TextBox txtNome, TextBox txtRazaoSocial, TextBox txtEndereco, TextBox txtBairro, TextBox txtCep, TextBox txtTelefone, TextBox txtCelular, TextBox txtEmail, ComboBox cmbEstado, ComboBox cmbCidade)
        {
            if (string.IsNullOrWhiteSpace(txtCnpj.Text) || !Regex.IsMatch(txtCnpj.Text, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$|^\d{14}$"))
            {
                MessageBox.Show("Por favor, insira um CNPJ válido do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCnpj.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNome.Text) || !Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o nome do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text) || !Regex.IsMatch(txtRazaoSocial.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira a razão social do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazaoSocial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEndereco.Text) || !Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o endereço do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndereco.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBairro.Text) || !Regex.IsMatch(txtNome.Text, "^[a-zA-ZÀ-ú ]+$"))
            {
                MessageBox.Show("Por favor, insira o bairro do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBairro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCep.Text) && !Regex.IsMatch(txtCep.Text, @"^\d{8}$"))
            {
                MessageBox.Show("Por favor, insira o cep do fornecedor", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCep.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Por favor, insira o telefone do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Por favor, insira o celular do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCelular.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, insira o e-mail do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Por favor, insira o estado do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCidade.Text))
            {
                MessageBox.Show("Por favor, insira a cidade do fornecedor.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCidade.Focus();
                return false;
            }
            return true;

        }
    }
}
