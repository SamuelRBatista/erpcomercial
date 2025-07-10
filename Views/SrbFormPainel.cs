using SRB_COMERCIALPDV.Models;
using SRB_COMERCIALPDV.Views;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV
{
    public partial class SrbFormPainel : Form
    {
        private Panel painelConteudo;

        public SrbFormPainel()
        {
            InitializeComponent();
            InicializarPainelConteudo();
        }

        private void InicializarPainelConteudo()
        {
            painelConteudo = new Panel();
            painelConteudo.Dock = DockStyle.Fill;
            painelConteudo.Name = "painelConteudo";
            painelConteudo.BackColor = Color.White;
            this.Controls.Add(painelConteudo);
            this.WindowState = FormWindowState.Maximized;
        }

        // Método para abrir forms independentes, sobrepostos ao painel
        private void AbrirFormSeparado<Forms>() where Forms : Form, new()
        {
            Forms formulario = new Forms();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog(this); // Abre modal, bloqueia até fechar
            // Se preferir não modal, use formulario.Show();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            AbrirFormSeparado<SrbFormProduto>();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            AbrirFormSeparado<SrbFormFornecedor>();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormSeparado<SrbFormCliente>();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            AbrirFormSeparado<SrbFormVenda>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
