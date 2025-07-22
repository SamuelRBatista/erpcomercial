namespace SRB_COMERCIALPDV.Views
{
    partial class SrbFormProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SrbFormProduto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEan = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtEan = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.dataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtNcm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.lblCest = new System.Windows.Forms.Label();
            this.txtCest = new System.Windows.Forms.TextBox();
            this.lblVal = new System.Windows.Forms.Label();
            this.txtValidade = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscaNome = new System.Windows.Forms.Button();
            this.btnBuscarEan = new System.Windows.Forms.Button();
            this.btnBuscaCodigo = new System.Windows.Forms.Button();
            this.btnImportarXml_Click = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 72);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(345, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cadastro de Produtos";
            // 
            // lblEan
            // 
            this.lblEan.AutoSize = true;
            this.lblEan.Location = new System.Drawing.Point(214, 86);
            this.lblEan.Name = "lblEan";
            this.lblEan.Size = new System.Drawing.Size(29, 13);
            this.lblEan.TabIndex = 1;
            this.lblEan.Text = "Ean:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(507, 83);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(782, 90);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(20, 123);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(38, 13);
            this.lblPreco.TabIndex = 4;
            this.lblPreco.Text = "Preço:";
            // 
            // txtEan
            // 
            this.txtEan.Location = new System.Drawing.Point(217, 102);
            this.txtEan.Name = "txtEan";
            this.txtEan.Size = new System.Drawing.Size(234, 20);
            this.txtEan.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(510, 104);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(232, 20);
            this.txtNome.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(785, 106);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(331, 20);
            this.txtDescricao.TabIndex = 4;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(23, 139);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(131, 20);
            this.txtPreco.TabIndex = 5;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(785, 129);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 10;
            this.lblCategoria.Text = "Categoria:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnCadastrar.Location = new System.Drawing.Point(197, 489);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(179, 23);
            this.btnCadastrar.TabIndex = 11;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(785, 145);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(331, 21);
            this.cmbCategoria.TabIndex = 10;
            // 
            // dataGridViewProdutos
            // 
            this.dataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdutos.Location = new System.Drawing.Point(14, 205);
            this.dataGridViewProdutos.Name = "dataGridViewProdutos";
            this.dataGridViewProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProdutos.Size = new System.Drawing.Size(1102, 253);
            this.dataGridViewProdutos.TabIndex = 13;
            this.dataGridViewProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProdutos_CellContentClick);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(752, 489);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(179, 23);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtId
            // 
            this.txtId.CausesValidation = false;
            this.txtId.Location = new System.Drawing.Point(1101, 225);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(10, 20);
            this.txtId.TabIndex = 15;
            this.txtId.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(382, 489);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(179, 23);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Alterar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(567, 489);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(179, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(937, 489);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(179, 23);
            this.btnFechar.TabIndex = 18;
            this.btnFechar.Text = "Sair";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtNcm
            // 
            this.txtNcm.Location = new System.Drawing.Point(510, 141);
            this.txtNcm.Name = "txtNcm";
            this.txtNcm.Size = new System.Drawing.Size(111, 20);
            this.txtNcm.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ncm:";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(23, 99);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(131, 20);
            this.txtCod.TabIndex = 1;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(20, 83);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(29, 13);
            this.lblCod.TabIndex = 22;
            this.lblCod.Text = "Cod:";
            // 
            // lblCest
            // 
            this.lblCest.AutoSize = true;
            this.lblCest.Location = new System.Drawing.Point(642, 125);
            this.lblCest.Name = "lblCest";
            this.lblCest.Size = new System.Drawing.Size(31, 13);
            this.lblCest.TabIndex = 24;
            this.lblCest.Text = "Cest:";
            // 
            // txtCest
            // 
            this.txtCest.Location = new System.Drawing.Point(631, 141);
            this.txtCest.Name = "txtCest";
            this.txtCest.Size = new System.Drawing.Size(111, 20);
            this.txtCest.TabIndex = 9;
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.Location = new System.Drawing.Point(337, 124);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(51, 13);
            this.lblVal.TabIndex = 26;
            this.lblVal.Text = "Validade:";
            // 
            // txtValidade
            // 
            this.txtValidade.Location = new System.Drawing.Point(340, 141);
            this.txtValidade.Name = "txtValidade";
            this.txtValidade.Size = new System.Drawing.Size(111, 20);
            this.txtValidade.TabIndex = 7;
            // 
            // btnNovo
            // 
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnNovo.Location = new System.Drawing.Point(12, 489);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(179, 23);
            this.btnNovo.TabIndex = 27;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(217, 141);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(111, 20);
            this.txtQuantidade.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Qtd Disp:";
            // 
            // btnBuscaNome
            // 
            this.btnBuscaNome.AutoSize = true;
            this.btnBuscaNome.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaNome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscaNome.FlatAppearance.BorderSize = 0;
            this.btnBuscaNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaNome.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscaNome.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaNome.Image")));
            this.btnBuscaNome.Location = new System.Drawing.Point(748, 104);
            this.btnBuscaNome.Name = "btnBuscaNome";
            this.btnBuscaNome.Size = new System.Drawing.Size(31, 22);
            this.btnBuscaNome.TabIndex = 6;
            this.btnBuscaNome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscaNome.UseVisualStyleBackColor = false;
            this.btnBuscaNome.Click += new System.EventHandler(this.btnBuscaNome_Click);
            // 
            // btnBuscarEan
            // 
            this.btnBuscarEan.AutoSize = true;
            this.btnBuscarEan.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarEan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscarEan.FlatAppearance.BorderSize = 0;
            this.btnBuscarEan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEan.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscarEan.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEan.Image")));
            this.btnBuscarEan.Location = new System.Drawing.Point(457, 102);
            this.btnBuscarEan.Name = "btnBuscarEan";
            this.btnBuscarEan.Size = new System.Drawing.Size(31, 22);
            this.btnBuscarEan.TabIndex = 1;
            this.btnBuscarEan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscarEan.UseVisualStyleBackColor = false;
            this.btnBuscarEan.Click += new System.EventHandler(this.btnBuscarEan_Click);
            // 
            // btnBuscaCodigo
            // 
            this.btnBuscaCodigo.AutoSize = true;
            this.btnBuscaCodigo.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscaCodigo.FlatAppearance.BorderSize = 0;
            this.btnBuscaCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaCodigo.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscaCodigo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaCodigo.Image")));
            this.btnBuscaCodigo.Location = new System.Drawing.Point(160, 100);
            this.btnBuscaCodigo.Name = "btnBuscaCodigo";
            this.btnBuscaCodigo.Size = new System.Drawing.Size(31, 22);
            this.btnBuscaCodigo.TabIndex = 5;
            this.btnBuscaCodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscaCodigo.UseVisualStyleBackColor = false;
            this.btnBuscaCodigo.Click += new System.EventHandler(this.btnBuscaCodigo_Click);
            // 
            // btnImportarXml_Click
            // 
            this.btnImportarXml_Click.Location = new System.Drawing.Point(23, 176);
            this.btnImportarXml_Click.Name = "btnImportarXml_Click";
            this.btnImportarXml_Click.Size = new System.Drawing.Size(75, 23);
            this.btnImportarXml_Click.TabIndex = 30;
            this.btnImportarXml_Click.Text = "Importar Xml";
            this.btnImportarXml_Click.UseVisualStyleBackColor = true;
            this.btnImportarXml_Click.Click += new System.EventHandler(this.btnImportarXml_Click_Click);
            // 
            // SrbFormProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 545);
            this.Controls.Add(this.btnImportarXml_Click);
            this.Controls.Add(this.btnBuscaNome);
            this.Controls.Add(this.txtCest);
            this.Controls.Add(this.btnBuscarEan);
            this.Controls.Add(this.btnBuscaCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblVal);
            this.Controls.Add(this.txtValidade);
            this.Controls.Add(this.lblCest);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNcm);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.dataGridViewProdutos);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEan);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEan);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SrbFormProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEan;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtEan;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox txtNcm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Label lblCest;
        private System.Windows.Forms.TextBox txtCest;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.TextBox txtValidade;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarEan;
        private System.Windows.Forms.Button btnBuscaNome;
        private System.Windows.Forms.Button btnBuscaCodigo;
        private System.Windows.Forms.Button btnImportarXml_Click;
    }
}