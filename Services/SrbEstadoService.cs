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
    public class SrbEstadoService
    {
        private readonly string connectionString;

        public SrbEstadoService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }

        public List<SrbEstado> ObterEstados()
        {
            List<SrbEstado> estados = new List<SrbEstado>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "Select id,nomeEstado,uf from estado";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbEstado estado = new SrbEstado()
                                {
                                    id = reader.GetInt32("id"),
                                    uf = reader.GetString("uf")
                                };
                                estados.Add(estado);
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
                Console.WriteLine($"Erro ao obter os estados: {ex.Message}");
            }

            return estados;

        }
    }
}
