using System;
using System.Data.SqlClient;
using System.Threading;
using CharacterCreation;

namespace CharacterCreation
{
    public class Choices
    {
        CharacterClass horrorCharacter = new CharacterClass();

        public void NewGame()
        {
            Console.Clear();
            Menu menu = new Menu();
            CharacSheets character = new CharacSheets();
            CharacterClass horrorCharac = new CharacterClass();

            bool placeholder = false;

            while (!placeholder)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("You have reached death! WELCOME to 'Reaching Death'!");
                    Console.WriteLine("(1) Create New Character");
                    Console.WriteLine("(2) Return");

                    int choice = int.Parse(Console.ReadLine()); 

                    if (choice == 1)
                    {
                        character.PlayerName(horrorCharac);
                        placeholder = true;
                    }
                    else if (choice == 2)
                    {
                        Menu.MainMenu(horrorCharac);
                        placeholder = true;
                    }
                    else
                    {
                        Console.Clear();
                        throw new ArgumentException("Invalid input. Please enter 1 or 2.");
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Input must be a valid number (1 or 2).");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        public void CampaignMode()
        {
            Console.Clear();
            string campaign = "CAMPAIGN MODE!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (campaign.Length / 2)) + "}", campaign));
            bool ph = false;

            while (!ph)
            {
                foreach (string paragraph in UserFeatures.gameStory)
                {
                    char[] charParagraph = paragraph.ToCharArray();
                    foreach (char characters in charParagraph)
                    {
                        Console.Write(characters);
                        Thread.Sleep(10);
                    }
                    Console.WriteLine("\n");
                }

                try
                {
                    CharacterClass horrorCharacter = new CharacterClass();
                    bool validChoice = false;

                    while (!validChoice)
                    {
                        Console.WriteLine("\nGo back to main menu?");
                        Console.WriteLine("(1) YES");
                        Console.WriteLine("(2) NO");

                        try
                        {
                            string choice = Console.ReadLine();

                            if (choice == "1")
                            {
                                Menu.MainMenu(horrorCharacter);
                                validChoice = true;
                                ph = true;
                            }
                            else if (choice == "2")
                            {
                                Console.WriteLine("\nPress any key to confirm exit: ");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid input. Please enter '1' or '2'.");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine("Please enter '1' or '2'.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        public void Credits()
        {
            Console.Clear();
            string credits = "CREDITS!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (credits.Length / 2)) + "}", credits));

            Console.WriteLine("Zam Ortega: Leader, programmer, pabuhat");
            Console.WriteLine("Jomar Cruz: Documentation");
            Console.WriteLine("Ethan Raphael Concepcion: Documentation");
            Console.WriteLine("Luis Rivera: Pancit Canton");
            Console.WriteLine("Reyn Penus: Certified Pancit Canton");
            Console.WriteLine("Raven Villanueva: Simpleng tao");
            Console.WriteLine("Emmanuel Caraig: Laptop");

            bool validChoice = false;

            while (!validChoice)
            {

                Console.WriteLine("\nGo back to main menu?");
                Console.WriteLine("(1) YES");
                Console.WriteLine("(2) NO");

                try
                {
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Menu.MainMenu(horrorCharacter);
                        validChoice = true;
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("\nPress any key to confirm exit: ");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        throw new ArgumentException("\nInvalid input. Please enter '1' or '2'.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void CurrentGame()
        {
            Console.Clear();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                string loadGameTitle = "LOAD GAME!";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (loadGameTitle.Length / 2)) + "}", loadGameTitle));
                Console.WriteLine("[1] View all characters");
                Console.WriteLine("[2] View a specific character");
                Console.WriteLine("[3] Delete a character");
                Console.WriteLine("[4] Go back to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ViewAllCharacters();
                        break;
                    case "2":
                        Console.Clear();
                        ViewSpecificCharacter();
                        break;
                    case "3":
                        Console.Clear();
                        DeletePlayer();
                        break;
                    case "4":
                        Console.Clear();
                        Menu.MainMenu(new CharacterClass());
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public void ViewSpecificCharacter()
        {
            Console.Clear();
            bool ph = false;

            while (!ph)
            {
                string filePath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";
                string query = "SELECT PlayerID, PlayerName FROM HorrorGame";

                SqlConnection connection = new SqlConnection(filePath);
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.HasRows)
                        {
                            Console.Clear();
                            string title = "VIEW A SPECIFIC PLAYER!";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));

                            Console.WriteLine("\nAvailable Players:");
                            while (reader.Read())
                            {
                                int playerID = reader.GetInt32(0);
                                string playerName = reader.GetString(1);
                                Console.WriteLine($"Player ID: {playerID} {"",-5} {"|",-5} {playerName}");
                            }

                            Console.WriteLine("\nEnter the Player ID to view details:");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out int playerId))
                            {
                                ViewPlayerDetails(playerId);
                                ph = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Player ID. Please enter a numeric value.");
                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo entries found. The database has no saved characters.");
                            Console.WriteLine("[1] Go back to load game");
                            string input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.Clear();
                                    CurrentGame();
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid option. Please try again.");
                                    break;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }


        public void ViewAllCharacters()
        {
            string filePath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";
            string query = "SELECT PlayerID, PlayerName FROM HorrorGame";

            SqlConnection connection = new SqlConnection(filePath);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo entries found. The database has no saved characters.");
                        Console.WriteLine("[1] Go back to load game");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.Clear();
                                CurrentGame();
                                break;
                            default:
                                Console.WriteLine("\nInvalid option. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        string viewAll = "VIEW ALL CHARACTER!";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (viewAll.Length / 2)) + "}", viewAll));

                        Console.WriteLine("Available Players:");

                        while (reader.Read())
                        {
                            string details = "CHARACTER DETAILS!";
                            int spacesBeforeDetails = (Console.WindowWidth - details.Length) / 2;
                            Console.WriteLine(new string(' ', spacesBeforeDetails) + details);

                            int playerId = reader.GetInt32(0);
                            string playerName = reader.GetString(1);

                            Console.WriteLine($"\nPlayer ID: {playerId} - {playerName}\n");

                            DisplayCharacterInfo(playerId);
                        }
                        Console.WriteLine("\nPress any key to go back.");
                        Console.ReadKey();
                        Console.Clear();
                        CurrentGame();
                        }
                    }
                }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }


        public void ViewPlayerDetails(int playerId)
        {
            try
            {
                string databaseConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";

                using (SqlConnection sqlConnect = new SqlConnection(databaseConnection))
                {
                    sqlConnect.Open();

                    string selectQuery = @"
                            SELECT PlayerName, PlayerAge, PlayerGender, TeamType, [Top], Pants, FaceShape, HairColor, HairStyle, EyeColor, SkinColor, 
                                    [Height], [Weight], Accessories, Hat, Glasses, Necklace, Bracelet, Anklet, HunterSkill, SurvivorSkill, Weapon, Ability, 
                                    Scar, Health, Strength, Stamina, Speed, Energy
                            FROM dbo.HorrorGame
                            WHERE PlayerID = @PlayerID";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, sqlConnect))
                    {
                        cmd.Parameters.AddWithValue("@PlayerID", playerId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        { 
                            while (reader.Read())
                            {                                
                                Console.WriteLine("\n{0,-20}| {1}", "Player Name", reader["PlayerName"]);
                                Console.WriteLine("{0,-20}| {1}", "Player Age", reader["PlayerAge"]);
                                Console.WriteLine("{0,-20}| {1}", "Player Gender", reader["PlayerGender"]);
                                Console.WriteLine("{0,-20}| {1}", "Team Type", reader["TeamType"]);
                                Console.WriteLine("{0,-20}| {1}", "Top", reader["Top"]);
                                Console.WriteLine("{0,-20}| {1}", "Pants", reader["Pants"]);
                                Console.WriteLine("{0,-20}| {1}", "Face Shape", reader["FaceShape"]);
                                Console.WriteLine("{0,-20}| {1}", "Hair Color", reader["HairColor"]);
                                Console.WriteLine("{0,-20}| {1}", "Hair Style", reader["HairStyle"]);
                                Console.WriteLine("{0,-20}| {1}", "Eye Color", reader["EyeColor"]);
                                Console.WriteLine("{0,-20}| {1}", "Skin Color", reader["SkinColor"]);
                                Console.WriteLine("{0,-20}| {1}", "Height", reader["Height"]);
                                Console.WriteLine("{0,-20}| {1}", "Weight", reader["Weight"]);
                                Console.WriteLine("{0,-20}| {1}", "Accessories", reader["Accessories"]);
                                Console.WriteLine("{0,-20}| {1}", "Hat", reader["Hat"]);
                                Console.WriteLine("{0,-20}| {1}", "Glasses", reader["Glasses"]);
                                Console.WriteLine("{0,-20}| {1}", "Necklace", reader["Necklace"]);
                                Console.WriteLine("{0,-20}| {1}", "Bracelet", reader["Bracelet"]);
                                Console.WriteLine("{0,-20}| {1}", "Anklet", reader["Anklet"]);
                                Console.WriteLine("{0,-20}| {1}", "Hunter Skill", reader["HunterSkill"]);
                                Console.WriteLine("{0,-20}| {1}", "Survivor Skill", reader["SurvivorSkill"]);
                                Console.WriteLine("{0,-20}| {1}", "Weapon", reader["Weapon"]);
                                Console.WriteLine("{0,-20}| {1}", "Ability", reader["Ability"]);
                                Console.WriteLine("{0,-20}| {1}", "Scar", reader["Scar"]);
                                Console.WriteLine("{0,-20}| {1}", "Health", reader["Health"]);
                                Console.WriteLine("{0,-20}| {1}", "Strength", reader["Strength"]);
                                Console.WriteLine("{0,-20}| {1}", "Stamina", reader["Stamina"]);
                                Console.WriteLine("{0,-20}| {1}", "Speed", reader["Speed"]);
                                Console.WriteLine("{0,-20}| {1}", "Energy", reader["Energy"]);
                            }

                            Console.WriteLine("\nPress any key to go back.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nNo details found for the specified Player ID.");
                            Console.WriteLine("\nPress any key to return to Player Management.");
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while viewing player details: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while viewing player details: " + ex.Message);
            }
        }

        public void DisplayCharacterInfo(int playerId)
        {
            string filePath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";
            string selectQuery = @"
                SELECT PlayerName, PlayerAge, PlayerGender, TeamType, [Top], Pants, FaceShape, HairColor, HairStyle, EyeColor, SkinColor, 
                       [Height], [Weight], Accessories, Hat, Glasses, Necklace, Bracelet, Anklet, HunterSkill, SurvivorSkill, Weapon, Ability, 
                       Scar, Health, Strength, Stamina, Speed, Energy
                FROM dbo.HorrorGame
                WHERE PlayerID = @PlayerID";

            using (SqlConnection sqlConnect = new SqlConnection(filePath))
            {
                sqlConnect.Open();
                using (SqlCommand cmd = new SqlCommand(selectQuery, sqlConnect))
                {
                    cmd.Parameters.AddWithValue("@PlayerID", playerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0,-20}| {1}", "Player Name", reader["PlayerName"]);
                            Console.WriteLine("{0,-20}| {1}", "Player Age", reader["PlayerAge"]);
                            Console.WriteLine("{0,-20}| {1}", "Player Gender", reader["PlayerGender"]);
                            Console.WriteLine("{0,-20}| {1}", "Team Type", reader["TeamType"]);
                            Console.WriteLine("{0,-20}| {1}", "Top", reader["Top"]);
                            Console.WriteLine("{0,-20}| {1}", "Pants", reader["Pants"]);
                            Console.WriteLine("{0,-20}| {1}", "Face Shape", reader["FaceShape"]);
                            Console.WriteLine("{0,-20}| {1}", "Hair Color", reader["HairColor"]);
                            Console.WriteLine("{0,-20}| {1}", "Hair Style", reader["HairStyle"]);
                            Console.WriteLine("{0,-20}| {1}", "Eye Color", reader["EyeColor"]);
                            Console.WriteLine("{0,-20}| {1}", "Skin Color", reader["SkinColor"]);
                            Console.WriteLine("{0,-20}| {1}", "Height", reader["Height"]);
                            Console.WriteLine("{0,-20}| {1}", "Weight", reader["Weight"]);
                            Console.WriteLine("{0,-20}| {1}", "Accessories", reader["Accessories"]);
                            Console.WriteLine("{0,-20}| {1}", "Hat", reader["Hat"]);
                            Console.WriteLine("{0,-20}| {1}", "Glasses", reader["Glasses"]);
                            Console.WriteLine("{0,-20}| {1}", "Necklace", reader["Necklace"]);
                            Console.WriteLine("{0,-20}| {1}", "Bracelet", reader["Bracelet"]);
                            Console.WriteLine("{0,-20}| {1}", "Anklet", reader["Anklet"]);
                            Console.WriteLine("{0,-20}| {1}", "Hunter Skill", reader["HunterSkill"]);
                            Console.WriteLine("{0,-20}| {1}", "Survivor Skill", reader["SurvivorSkill"]);
                            Console.WriteLine("{0,-20}| {1}", "Weapon", reader["Weapon"]);
                            Console.WriteLine("{0,-20}| {1}", "Ability", reader["Ability"]);
                            Console.WriteLine("{0,-20}| {1}", "Scar", reader["Scar"]);
                            Console.WriteLine("{0,-20}| {1}", "Health", reader["Health"]);
                            Console.WriteLine("{0,-20}| {1}", "Strength", reader["Strength"]);
                            Console.WriteLine("{0,-20}| {1}", "Stamina", reader["Stamina"]);
                            Console.WriteLine("{0,-20}| {1}", "Speed", reader["Speed"]);
                            Console.WriteLine("{0,-20}| {1}", "Energy", reader["Energy"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No details found for PlayerID: " + playerId);
                    }
                }
            }
        }

        public void DeletePlayer()
        {
            string filePath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";
            string query = "SELECT PlayerID, PlayerName FROM HorrorGame";

            SqlConnection connection = new SqlConnection(filePath);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.Clear();
                        string title = "DELETE CHARACTER!";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
                        Console.WriteLine("Available Players:");

                        while (reader.Read())
                        {
                            int playeriD = reader.GetInt32(0);
                            string playerName = reader.GetString(1);
                            Console.WriteLine($"Player ID: {playeriD} - {playerName}");
                        }

                        reader.Close();

                        Console.WriteLine("\nEnter the Player ID to delete:");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out int playerId))
                        {
                            string fetchNameQuery = "SELECT PlayerName FROM HorrorGame WHERE PlayerID = @PlayerID";
                            SqlCommand fetchCommand = new SqlCommand(fetchNameQuery, connection);
                            fetchCommand.Parameters.AddWithValue("@PlayerID", playerId);

                            string playerName = null;

                            using (SqlDataReader nameReader = fetchCommand.ExecuteReader())
                            {
                                if (nameReader.Read())
                                {
                                    playerName = nameReader.GetString(0);
                                }
                            }

                            if (playerName != null)
                            {
                                Console.WriteLine($"\nAre you sure to delete character: {playerName} (ID: {playerId})? (y/n):");
                                string confirmation = Console.ReadLine().ToLower();

                                if (confirmation == "y")
                                {
                                    string deleteQuery = "DELETE FROM dbo.HorrorGame WHERE PlayerID = @PlayerID";
                                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@PlayerID", playerId);

                                        int rowsAffected = cmd.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            Console.WriteLine($"Player with ID {playerId} and Name {playerName} successfully deleted.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"No player found with ID {playerId}.");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Deletion canceled.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No player found with ID {playerId}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Player ID. Please enter to try again, please input a numeric value.");
                            Console.ReadKey();
                            DeletePlayer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No players available to delete.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while deleting player: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            Console.WriteLine("\nReturning to Load Game...");
            Console.ReadKey();
            Console.Clear();
            CurrentGame();
        }

    }
}