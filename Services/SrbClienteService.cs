
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public class SrbClienteService
    {
        private readonly string connectionString;

        public SrbClienteService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }

        // Método para obter clientes
        public List<SrbCliente> ObterCliente()
        {
            List<SrbCliente> clientes = new List<SrbCliente>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT cl.ID,cl.Cpf, cl.Nome, cl.Endereco, cl.Bairro, cl.Cep, cl.Telefone, cl.Celular, cl.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf FROM cliente cl INNER JOIN estado e ON  cl.id_estado = e.id INNER JOIN cidade c ON cl.id_estado = c.id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCliente cliente = new SrbCliente
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCpf = reader.GetString("Cpf"),
                                    SrbNome = reader.GetString("Nome"),                                    
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular= reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                   
                                };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter clientes: {ex.Message}");
            }

            return clientes;
        }

        public void AdicionarCliente(SrbCliente cliente)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Comando SQL para inserir um novo cliente
                    string query = "INSERT INTO cliente (Cpf,Nome,Endereco,Bairro,Cep,Telefone,Celular,Email,id_cidade,id_estado) VALUES (@Cpf,@Nome, @Endereco,@Bairro,@Cep,@Telefone,@Celular,@Email,@CidadeId,@EstadoId)";

                    // Criação do comando SQL e associação dos parâmetros
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cpf", cliente.SrbCpf);
                    command.Parameters.AddWithValue("@Nome", cliente.SrbNome);                   
                    command.Parameters.AddWithValue("@Endereco", cliente.SrbEndereco);
                    command.Parameters.AddWithValue("@Bairro", cliente.SrbBairro);
                    command.Parameters.AddWithValue("@Cep", cliente.SrbCep);
                    command.Parameters.AddWithValue("@Telefone", cliente.SrbTelefone);
                    command.Parameters.AddWithValue("@Celular", cliente.SrbCelular);
                    command.Parameters.AddWithValue("@Email", cliente.SrbEmail);
                    command.Parameters.AddWithValue("@CidadeId", cliente.SrbCidadeId);
                    command.Parameters.AddWithValue("@EstadoId", cliente.SrbEstadoId);


                    // Executa o comando SQL
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao adicionar cliente: {ex.Message}");
                }
            }
        }

        //Atualizar
        public void AtualizarCliente(SrbCliente cliente)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE cliente SET Cpf = @Cpf, Nome = @Nome, Endereco = @Endereco, Bairro = @Bairro, Cep = @Cep, Telefone = @Telefone, Celular = @Celular, Email = @Email, id_estado = @EstadoId, id_cidade = @CidadeId WHERE Id = @SrbID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SrbID", cliente.SrbID);
                        command.Parameters.AddWithValue("@Cpf", cliente.SrbCpf);
                        command.Parameters.AddWithValue("@Nome", cliente.SrbNome);                       
                        command.Parameters.AddWithValue("@Endereco", cliente.SrbEndereco);
                        command.Parameters.AddWithValue("@Bairro", cliente.SrbBairro);
                        command.Parameters.AddWithValue("@Cep", cliente.SrbCep);
                        command.Parameters.AddWithValue("@Telefone", cliente.SrbTelefone);
                        command.Parameters.AddWithValue("@Celular", cliente.SrbCelular);
                        command.Parameters.AddWithValue("@Email", cliente.SrbEmail);
                        command.Parameters.AddWithValue("@EstadoId", cliente.SrbEstadoId);
                        command.Parameters.AddWithValue("@CidadeId", cliente.SrbCidadeId);

                        command.ExecuteNonQuery();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        // Método para remover fornecedor
        public void RemoverCliente(int id)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM cliente WHERE Id = @Id";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Registro não pode ser excluido!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao remover cliente: {ex.Message}");
                }
            }


        }

        public List<SrbCliente> BuscarClientePorCpf(string cpf = null)
        {
            List<SrbCliente> clientes = new List<SrbCliente>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT cl.ID,cl.Cpf, cl.Nome, cl.Endereco, cl.Bairro, cl.Cep, cl.Telefone, cl.Celular, cl.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf FROM cliente cl INNER JOIN estado e ON  cl.id_estado = e.id INNER JOIN cidade c ON cl.id_estado = c.id ";

                    if (!string.IsNullOrEmpty(cpf))
                    {
                        query += "WHERE cl.Cpf = @Cpf ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {

                        if (!string.IsNullOrEmpty(cpf))
                        {
                            command.Parameters.AddWithValue("@Cpf", cpf);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCliente cliente = new SrbCliente
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCpf = reader.GetString("Cpf"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return clientes;
        }

        public List<SrbCliente> BuscarClientePorNome(string nome = null)
        {
            List<SrbCliente> clientes = new List<SrbCliente>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT cl.ID,cl.Cpf, cl.Nome, cl.Endereco, cl.Bairro, cl.Cep, cl.Telefone, cl.Celular, cl.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf FROM cliente cl INNER JOIN estado e ON  cl.id_estado = e.id INNER JOIN cidade c ON cl.id_estado = c.id ";

                    if (!string.IsNullOrEmpty(nome))
                    {
                        query += "WHERE cl.Nome LIKE @Nome ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {

                        if (!string.IsNullOrEmpty(nome))
                        {
                            command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCliente cliente = new SrbCliente
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCpf = reader.GetString("Cpf"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return clientes;
        }

        public List<SrbCliente> BuscarClientePorCep(string cep = null)
        {
            List<SrbCliente> clientes = new List<SrbCliente>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT cl.ID,cl.Cpf, cl.Nome, cl.Endereco, cl.Bairro, cl.Cep, cl.Telefone, cl.Celular, cl.Email, c.NomeCidade AS NomeCidade, e.Uf AS Uf FROM cliente cl INNER JOIN estado e ON  cl.id_estado = e.id INNER JOIN cidade c ON cl.id_estado = c.id ";

                    if (!string.IsNullOrEmpty(cep))
                    {
                        query += "WHERE cl.Cep = @Cep ";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {

                        if (!string.IsNullOrEmpty(cep))
                        {
                            command.Parameters.AddWithValue("@Cep", cep);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCliente cliente = new SrbCliente
                                {
                                    SrbID = reader.GetInt32("ID"),
                                    SrbCpf = reader.GetString("Cpf"),
                                    SrbNome = reader.GetString("Nome"),
                                    SrbEndereco = reader.GetString("Endereco"),
                                    SrbBairro = reader.GetString("Bairro"),
                                    SrbCep = reader.GetString("Cep"),
                                    SrbTelefone = reader.GetString("Telefone"),
                                    SrbCelular = reader.GetString("Celular"),
                                    SrbEmail = reader.GetString("Email"),
                                    SrbNomeCidade = reader.GetString("NomeCidade"),
                                    SrbNomeEstado = reader.GetString("Uf")
                                };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
            }

            return clientes;
        }
    }


    
}
