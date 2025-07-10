
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class SrbFornecedorService
    {
        private readonly string connectionString;

        public SrbFornecedorService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }
        
        public List<SrbFornecedor> ObterFornecedor()
        {
            List<SrbFornecedor> fornecedores = new List<SrbFornecedor>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT f.ID,f.Cnpj, f.Nome, f.RazaoSocial, f.Endereco, f.Bairro, f.Cep, f.Telefone, f.Celular, f.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf FROM fornecedor f INNER JOIN estado e ON  f.id_estado = e.id INNER JOIN cidade c ON f.id_estado = c.id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbFornecedor fornecedor = new SrbFornecedor
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCnpj = reader.GetString("Cnpj"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbRazaoSocial = reader.GetString("RazaoSocial"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular= reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                   
                                };
                                fornecedores.Add(fornecedor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return fornecedores;
        }
        public void AdicionarFornecedor(SrbFornecedor fornecedor)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                    string query = "INSERT INTO fornecedor (Cnpj,Nome,RazaoSocial,Endereco,Bairro,Cep,Telefone,Celular,Email,id_cidade,id_estado) VALUES (@Cnpj,@Nome,@RazaoSocial,@Endereco,@Bairro,@Cep,@Telefone,@Celular,@Email,@CidadeId,@EstadoId)";
                                       
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cnpj", fornecedor.SrbCnpj);
                    command.Parameters.AddWithValue("@Nome", fornecedor.SrbNome);
                    command.Parameters.AddWithValue("@RazaoSocial", fornecedor.SrbRazaoSocial);
                    command.Parameters.AddWithValue("@Endereco", fornecedor.SrbEndereco);
                    command.Parameters.AddWithValue("@Bairro", fornecedor.SrbBairro);
                    command.Parameters.AddWithValue("@Cep", fornecedor.SrbCep);
                    command.Parameters.AddWithValue("@Telefone", fornecedor.SrbTelefone);
                    command.Parameters.AddWithValue("@Celular", fornecedor.SrbCelular);
                    command.Parameters.AddWithValue("@Email", fornecedor.SrbEmail);
                    command.Parameters.AddWithValue("@CidadeId", fornecedor.SrbCidadeId);
                    command.Parameters.AddWithValue("@EstadoId", fornecedor.SrbEstadoId);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao adicionar fornecedor: {ex.Message}");
                }
            }
        }       
        public void AtualizarFornecedor(SrbFornecedor fornecedor)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE fornecedor SET Cnpj = @Cnpj, Nome = @Nome, RazaoSocial = @RazaoSocial, Endereco = @Endereco, Bairro = @Bairro, Cep = @Cep, Telefone = @Telefone, Celular = @Celular, Email = @Email, id_estado = @EstadoId, id_cidade = @CidadeId WHERE Id = @SrbID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SrbID", fornecedor.SrbID);
                        command.Parameters.AddWithValue("@Cnpj", fornecedor.SrbCnpj);
                        command.Parameters.AddWithValue("@Nome", fornecedor.SrbNome);
                        command.Parameters.AddWithValue("@RazaoSocial", fornecedor.SrbRazaoSocial);
                        command.Parameters.AddWithValue("@Endereco", fornecedor.SrbEndereco);
                        command.Parameters.AddWithValue("@Bairro", fornecedor.SrbBairro);
                        command.Parameters.AddWithValue("@Cep", fornecedor.SrbCep);
                        command.Parameters.AddWithValue("@Telefone", fornecedor.SrbTelefone);
                        command.Parameters.AddWithValue("@Celular", fornecedor.SrbCelular);
                        command.Parameters.AddWithValue("@Email", fornecedor.SrbEmail);
                        command.Parameters.AddWithValue("@EstadoId", fornecedor.SrbEstadoId);  
                        command.Parameters.AddWithValue("@CidadeId", fornecedor.SrbCidadeId); 

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar fornecedor: {ex.Message}");
            }
        }        
        public void RemoverFornecedor(int id)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro de Fornecedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM fornecedor WHERE Id = @Id";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro de Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Registro não pode ser excluido!", "Cadastro de Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao remover fornecedor: {ex.Message}");
                }
            }


        }

        public List<SrbFornecedor> BuscarFornecedorPorCnpj(string cnpj = null)
        {
            List<SrbFornecedor> fornecedores = new List<SrbFornecedor>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT f.ID, f.Cnpj, f.Nome, f.RazaoSocial, f.Endereco, f.Bairro, f.Cep, f.Telefone, f.Celular, f.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf " +
                                   "FROM fornecedor f INNER JOIN estado e ON f.id_estado = e.id INNER JOIN cidade c ON f.id_cidade = c.id";

                    if (!string.IsNullOrEmpty(cnpj))
                    {
                        query += " WHERE f.Cnpj = @Cnpj";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(cnpj))
                        {
                            command.Parameters.AddWithValue("@Cnpj", cnpj);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbFornecedor fornecedor = new SrbFornecedor
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCnpj = reader.GetString("Cnpj"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbRazaoSocial = reader.GetString("RazaoSocial"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                fornecedores.Add(fornecedor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter fornecedores: {ex.Message}");
            }

            return fornecedores;
        }
        public List<SrbFornecedor> BuscaFornecedorPorNome(string nome = null)
        {
            List<SrbFornecedor> fornecedores = new List<SrbFornecedor>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT f.ID, f.Cnpj, f.Nome, f.RazaoSocial, f.Endereco, f.Bairro, f.Cep, f.Telefone, f.Celular, f.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf " +
                                   "FROM fornecedor f INNER JOIN estado e ON f.id_estado = e.id INNER JOIN cidade c ON f.id_cidade = c.id";

                    if (!string.IsNullOrEmpty(nome))
                    {
                        query += " Where f.Nome = @Nome";                        
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
                                SrbFornecedor fornecedor = new SrbFornecedor
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCnpj = reader.GetString("Cnpj"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbRazaoSocial = reader.GetString("RazaoSocial"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                fornecedores.Add(fornecedor);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao obter fornecedores: {ex.Message}");
            }

            return fornecedores;
        }
        public List<SrbFornecedor> BuscaFornecedorPorRazaoSocial(string nomeRazao = null)
        {
            List<SrbFornecedor> fornecedores = new List<SrbFornecedor>();

            try
            {
                using(var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT f.ID, f.Cnpj, f.Nome, f.RazaoSocial, f.Endereco, f.Bairro, f.Cep, f.Telefone, f.Celular, f.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf " +
                                   "FROM fornecedor f INNER JOIN estado e ON f.id_estado = e.id INNER JOIN cidade c ON f.id_cidade = c.id";

                    if(!string.IsNullOrEmpty(nomeRazao))
                    {
                        query += " Where f.RazaoSocial = @RazaoSocial";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if(!string.IsNullOrEmpty (nomeRazao))
                        {
                            command.Parameters.AddWithValue("@RazaoSocial",nomeRazao);
                        }

                        using(var reader = command.ExecuteReader()) 
                        {
                            while(reader.Read())
                            {
                                SrbFornecedor  fornecedor = new SrbFornecedor
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCnpj = reader.GetString("Cnpj"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbRazaoSocial = reader.GetString("RazaoSocial"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                fornecedores.Add(fornecedor);
                            }  
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao obter fornecedores: {ex.Message}");
            }

            return fornecedores;
        }
    }
   
}
