using MySql.Data.MySqlClient;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Services
{
    public class SrbVendaService
    {
        private readonly string connectionString;

        public SrbVendaService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }

        public void AdicionarVenda(SrbVenda venda)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Vendas (VendaId, Quantidade, PrecoUnitario, DataVenda, ValorPago, Troco) " +
                      "VALUES (@VendaId, @Quantidade, @PrecoUnitario, @DataVenda, @ValorPago, @Troco)";


                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@VendaId", venda.SrbVendaId);                  
                    command.Parameters.AddWithValue("@Quantidade", venda.SrbQuantidade);
                    command.Parameters.AddWithValue("@PrecoUnitario", venda.SrbPrecoUnitario);
                    command.Parameters.AddWithValue("@DataVenda", venda.SrbDataVenda);
                    command.Parameters.AddWithValue("@ValorPago", venda.SrbValorPago);
                    command.Parameters.AddWithValue("@Troco", venda.SrbTroco);

                    
                    command.ExecuteNonQuery();
                    Console.WriteLine("Venda adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
                }
            }
        }
    }
}
