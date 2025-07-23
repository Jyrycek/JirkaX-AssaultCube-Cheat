using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.LoginManager
{
    public class DatabaseOperations
    {
        private static string HashString(string passwordString, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Kombinujeme heslo s solí a hashujeme
                byte[] combinedBytes = Encoding.UTF8.GetBytes(passwordString + salt);
                byte[] hashedBytes = sha256.ComputeHash(combinedBytes);

                // Převedeme hash na base64 řetězec
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static string GenerateSalt()
        {
            // Generování náhodné soli
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private static bool VerifyPassword(string inputPassword, string salt, string hashedPassword)
        {
            string inputHashedPassword = HashString(inputPassword, salt);
            return inputHashedPassword == hashedPassword;
        }

        public static bool ProcessRegister(string username, string password, MySqlConnection connection)
        {
            if (IsUsernameTaken(username, connection))
            {
                return false;
            }

            string salt = GenerateSalt();
            string hashedPassword = HashString(password, salt);

            string query = "INSERT INTO cheat_login (Username, PasswordHash, Salt) VALUES (@Username, @PasswordHash, @Salt)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@Salt", salt);

                command.ExecuteNonQuery();
            }
            return true;
        }
        private static bool IsUsernameTaken(string username, MySqlConnection connection)
        {
            // Metoda pro kontrolu, zda uživatelské jméno již existuje v databázi
            string query = $"SELECT COUNT(*) FROM cheat_login WHERE Username = @Username";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        public static bool ProcessLogin(string username, string password, MySqlConnection connection) 
        {
            string query = "SELECT Salt, PasswordHash FROM cheat_login WHERE Username = @Username";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string salt = reader.GetString(0);
                        string storedHashedPassword = reader.GetString(1);

                        bool isPasswordCorrect = VerifyPassword(password, salt, storedHashedPassword);

                        return isPasswordCorrect;
                    }
                }
            }
            return false;
        }
    }
}
