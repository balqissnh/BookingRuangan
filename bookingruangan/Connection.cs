using MySql.Data.MySqlClient;

namespace bookingruangan
{
    public class Connection
    {
        private static string connectionString = "server=localhost;database=bookingruang;user=root;password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
