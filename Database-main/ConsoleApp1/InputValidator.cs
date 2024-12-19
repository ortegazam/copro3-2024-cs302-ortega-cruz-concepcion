using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CharacterCreation
{
    public class InputValidator
    {
        public static string Validation(string input) {
            while (true)
            {
                try
                {
                    if ((Regex.IsMatch(input, @"^[A-Za-z0-9]+$")) && (input.Length <= 20) && (input.Length >= 7))
                    {
                        return input;
 
                    }
                    else { 
                        throw new ArgumentException("Invalid input. Try again!");
                      
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Please enter your name (Alphanumeric, max 20 characters): ");

                    input = Console.ReadLine();
                }
            }
        }
        public bool CheckIfNameExists(string playerName)
        {
            bool nameExists = false;
            string databaseConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConnection))
                {
                    string query = "SELECT COUNT(1) FROM dbo.HorrorGame WHERE PlayerName = @PlayerName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PlayerName", playerName);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();
                    nameExists = count > 0; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking name in database: " + ex.Message);
            }

            return nameExists;
        }
    }
}

