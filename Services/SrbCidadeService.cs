using MySql.Data.MySqlClient;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB_COMERCIALPDV.Services
{
    public class SrbCidadeService
    {
        private readonly string connectionString;

        public SrbCidadeService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }

        public List<SrbCidade> ObterCidades()
        {
            List<SrbCidade> cidades = new List<SrbCidade>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "Select id, nomeCidade from cidade";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCidade cidade = new SrbCidade()
                                {
                                    id = reader.GetInt32("id"),
                                    nomeCidade = reader.GetString("nomeCidade")
                                };
                                cidades.Add(cidade);
                            }
                        }
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter as cidades: {ex.Message}");
            }

            return cidades;

        }
    }
}
