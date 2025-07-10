using MySql.Data.MySqlClient;
using SRB_COMERCIALPDV.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRB_COMERCIALPDV.Services
{
    public class SrbCategoriaService
    {
        private readonly string connectionString;

        public SrbCategoriaService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SrbDatabasePdv"].ConnectionString;
        }
        public void AdicionarCategoria(SrbCategoria categoria)
        {
            // Lógica para adicionar a categoria ao banco de dados
        }

        public List<SrbCategoria> ObterCategorias()
        {
            List<SrbCategoria> categorias = new List<SrbCategoria>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "Select id,nomeCategoria from categoria";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SrbCategoria categoria = new SrbCategoria()
                                {
                                    id = reader.GetInt32("id"),
                                    nomeCategoria = reader.GetString("nomeCategoria")
                                };
                                categorias.Add(categoria);                              
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
                Console.WriteLine($"Erro ao obter catgorias: {ex.Message}");
            }

            return categorias;

        }        
    }
}
