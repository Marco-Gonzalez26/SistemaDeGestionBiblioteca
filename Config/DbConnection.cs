


namespace SistemaDeGestionBiblioteca.Config
{
    using System.Data.SqlClient;
    public class DbConnection
    {
        private static readonly string server = "LAPTOP-L6SUJ856\\ALWAYSDEV";   
        private static readonly string database = "SistemaGestionBiblioteca";  
        private static readonly string username = "root";  
        private static readonly string password = "123456";  
     
        string connectionString = $"Server={server};Database={database};uid={username};pwd={password};TrustServerCertificate=True";

        public SqlConnection getConnection() { 
            return new SqlConnection(connectionString);
        }
    }
}
