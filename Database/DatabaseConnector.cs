using System.Data;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using Exceptions;
using Exceptions.DatabaseExceptions;

namespace Database
{
    public class DatabaseConnector : IDisposable
    {
        private readonly string connectionString;
        private MySqlConnection connection;

        public DatabaseConnector(string server, string database, string uid, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            throw new CannotConnectException("Cannot connect to server. Contact administrator");
                        case 1045:
                            throw new InvalidCredentialsException("Invalid username/password, please try again");
                        case 1042:
                            throw new HostnameResolveException("Cannot resolve ip address to hostname");
                    }
                }
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}