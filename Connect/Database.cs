using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public class Database
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public Database()
    {
        Initialize();
    }

    private void Initialize()
    {
        server = "localhost";
        database = "srbcomercial";
        uid = "root";
        password = "samuka.201232";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    // Métodos para abrir, fechar conexão e executar consultas no banco de dados
}