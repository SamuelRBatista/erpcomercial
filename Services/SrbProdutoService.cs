using MySql.Data.MySqlClient;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV.Services
{
    public class SrbProdutoService
    {
        private readonly string connectionString; 
        public SrbProdutoService()
        {
            // Inicializa a connectionString recuperando-a do arquivo de configuração
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }

        #region
        /* Metodos de manipulação de registros */

        // Método para obter produtos
        public List<SrbProduto> ObterProdutos()
        {
            List<SrbProduto> produtos = new List<SrbProduto>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.ID,p.Codigo, p.Ean, p.Nome, p.Descricao, p.Preco, p.Quantidade, p.Validade, p.Ncm, p.Cest, c.NomeCategoria AS NomeCategoria FROM produto p INNER JOIN categoria c ON  p.id_categoria = c.id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbProduto produto = new SrbProduto
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCod = reader.GetString("Codigo"),
                                    SrbEan = reader.GetString("Ean"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbDescricao = reader.GetString("Descricao"),
                                    SrbPreco = reader.GetDecimal("Preco"),
                                    SrbQuantidade = reader.GetInt32("Quantidade"),
                                    SrbValidade = reader.GetDateTime("Validade"),
                                    SrbNcm = reader.GetString("Ncm"),
                                    SrbCest = reader.GetString("Cest"),
                                    SrbNomeCategoria = reader.GetString("NomeCategoria")
                                };
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }
            return produtos;
        }
        // Método para adicionar produtos
        public void AdicionarProduto(SrbProduto produto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    string query = "INSERT INTO produto (Codigo,Ean,Nome,Descricao,Preco,Quantidade,Validade,Ncm,Cest,id_categoria, id_marca) VALUES (@Codigo, @Ean, @Nome, @Descricao, @Preco,@Quantidade, @Validade, @Ncm, @Cest, @CategoriaId, 3)";

                  
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Codigo", produto.SrbCod);
                    command.Parameters.AddWithValue("@Ean", produto.SrbEan);
                    command.Parameters.AddWithValue("@Nome", produto.SrbNome);
                    command.Parameters.AddWithValue("@Descricao", produto.SrbDescricao);
                    command.Parameters.AddWithValue("@Preco", produto.SrbPreco);
                    command.Parameters.AddWithValue("@Quantidade", produto.SrbQuantidade);
                    command.Parameters.AddWithValue("@Validade", produto.SrbValidade);
                    command.Parameters.AddWithValue("@Ncm", produto.SrbNcm);
                    command.Parameters.AddWithValue("@Cest", produto.SrbCest);
                    command.Parameters.AddWithValue("@CategoriaId", produto.SrbCategoriaId); 

                  
                    command.ExecuteNonQuery();

                    Console.WriteLine("Produto adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
                }
            }
        }

        //Método que atualizar o produto
        public void AtualizarProduto(SrbProduto produto)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE produto SET Codigo = @Codigo, Ean = @Ean, Nome = @Nome, Descricao = @Descricao, Preco = @Preco, Quantidade = @Quantidade, Validade = @Validade, Ncm = @Ncm, Cest = @Cest, id_categoria = @CategoriaId WHERE Id = @SrbID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SrbID", produto.SrbID);
                        command.Parameters.AddWithValue("@Codigo", produto.SrbCod);
                        command.Parameters.AddWithValue("@Ean", produto.SrbEan);
                        command.Parameters.AddWithValue("@Nome", produto.SrbNome);
                        command.Parameters.AddWithValue("@Descricao", produto.SrbDescricao);
                        command.Parameters.AddWithValue("@Preco", produto.SrbPreco);
                        command.Parameters.AddWithValue("@Quantidade", produto.SrbQuantidade);
                        command.Parameters.AddWithValue("@Validade", produto.SrbValidade);
                        command.Parameters.AddWithValue("@Ncm", produto.SrbNcm);
                        command.Parameters.AddWithValue("@Cest", produto.SrbCest);
                        command.Parameters.AddWithValue("@CategoriaId", produto.SrbCategoriaId); // Supondo que CategoriaID seja o ID da categoria associada ao produto


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        // Método que atualiza a quantidade de estoque
        public void AtualizarQuantidadeProduto(int id, int novaQuantidade)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE produto SET Quantidade = @novaQuantidade WHERE id = @id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@novaQuantidade", novaQuantidade);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar quantidade do produto: {ex.Message}");
            }
        }

        // Método para remover produtos
        public void RemoverProduto(int id)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro de Produtos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM produto WHERE Id = @Id";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Registro não pode ser excluido!", "Cadastro de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao remover produto: {ex.Message}");
                }
            }

           
        }
        #endregion

        #region
        /* Metodos de filtros de registros */

        //Metodo busca produto por Id
        public SrbProduto BuscarProdutoPorId(int id)
        {
            SrbProduto produto = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM produto WHERE id = @id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                produto = new SrbProduto
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCod = reader.GetString("Codigo"),
                                    SrbEan = reader.GetString("Ean"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbDescricao = reader.GetString("Descricao"),
                                    SrbPreco = reader.GetDecimal("Preco"),
                                    SrbQuantidade = reader.GetInt32("Quantidade"),
                                    SrbValidade = reader.GetDateTime("Validade"),
                                    SrbNcm = reader.GetString("Ncm"),
                                    SrbCest = reader.GetString("Cest"),
                                    SrbCategoriaId = reader.GetInt32("id_categoria"),
                                    SrbNomeCategoria = "" // Você pode carregar o nome da categoria, se necessário
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produto por código: {ex.Message}");
            }
            return produto;
        }
        //Metodo busca produto por Codigo
        public List<SrbProduto> BuscarProdutoPorCodigo(int codigo)
        {
            List<SrbProduto> produtos = new List<SrbProduto>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.ID, p.Codigo, p.Ean, p.Nome, p.Descricao, p.Preco, p.Quantidade, p.Validade, p.Ncm, p.Cest, c.NomeCategoria AS NomeCategoria " +
                                   "FROM produto p INNER JOIN categoria c ON p.id_categoria = c.id ";

                    if (codigo > 0)
                    {
                        query += "WHERE p.Codigo = @Codigo ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (codigo > 0)
                        {
                            command.Parameters.AddWithValue("@Codigo", codigo);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbProduto produto = new SrbProduto
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCod = reader.GetString("Codigo"),
                                    SrbEan = reader.GetString("Ean"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbDescricao = reader.GetString("Descricao"),
                                    SrbPreco = reader.GetDecimal("Preco"),
                                    SrbQuantidade = reader.GetInt32("Quantidade"),
                                    SrbValidade = reader.GetDateTime("Validade"),
                                    SrbNcm = reader.GetString("Ncm"),
                                    SrbCest = reader.GetString("Cest"),
                                    SrbNomeCategoria = reader.GetString("NomeCategoria")
                                };
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }
            return produtos;
        }
        //Metodo busca produto por EAN
        public List<SrbProduto> BuscarProdutoPorEan(string ean = null)
        {
            List<SrbProduto> produtos = new List<SrbProduto>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.ID, p.Codigo, p.Ean, p.Nome, p.Descricao, p.Preco, p.Quantidade, p.Validade, p.Ncm, p.Cest, c.NomeCategoria AS NomeCategoria " +
                                   "FROM produto p INNER JOIN categoria c ON p.id_categoria = c.id ";

                    if (!string.IsNullOrEmpty(ean))
                    {
                        query += "WHERE p.Ean = @Ean ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {

                        if (!string.IsNullOrEmpty(ean))
                        {
                            command.Parameters.AddWithValue("@Ean", ean);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbProduto produto = new SrbProduto
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCod = reader.GetString("Codigo"),
                                    SrbEan = reader.GetString("Ean"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbDescricao = reader.GetString("Descricao"),
                                    SrbPreco = reader.GetDecimal("Preco"),
                                    SrbQuantidade = reader.GetInt32("Quantidade"),
                                    SrbValidade = reader.GetDateTime("Validade"),
                                    SrbNcm = reader.GetString("Ncm"),
                                    SrbCest = reader.GetString("Cest"),
                                    SrbNomeCategoria = reader.GetString("NomeCategoria")
                                };
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return produtos;
        }

        //Metodo busca produto por Nome
        public List<SrbProduto> BuscarProdutoPorNome(string nome = null)
        {
            List<SrbProduto> produtos = new List<SrbProduto>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.ID, p.Codigo, p.Ean, p.Nome, p.Descricao, p.Preco, p.Quantidade, p.Validade, p.Ncm, p.Cest, c.NomeCategoria AS NomeCategoria " +
                                   "FROM produto p INNER JOIN categoria c ON p.id_categoria = c.id ";

                    if (!string.IsNullOrEmpty(nome))
                    {
                        query += "WHERE p.Nome = @Nome ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(nome))
                        {
                            command.Parameters.AddWithValue("@Nome", nome);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbProduto produto = new SrbProduto
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCod = reader.GetString("Codigo"),
                                    SrbEan = reader.GetString("Ean"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbDescricao = reader.GetString("Descricao"),
                                    SrbPreco = reader.GetDecimal("Preco"),
                                    SrbQuantidade = reader.GetInt32("Quantidade"),
                                    SrbValidade = reader.GetDateTime("Validade"),
                                    SrbNcm = reader.GetString("Ncm"),
                                    SrbCest = reader.GetString("Cest"),
                                    SrbNomeCategoria = reader.GetString("NomeCategoria")
                                };
                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }
            return produtos;
        }
        #endregion
    }
}
