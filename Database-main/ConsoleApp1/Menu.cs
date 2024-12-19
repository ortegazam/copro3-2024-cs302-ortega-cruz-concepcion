using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CharacterCreation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CharacterCreation
{
    public class Menu
    {
        public static SqlConnection con;
        public static void Main(string[] args)
        {
            try
            {
                CharacterClass horrorCharacter = new CharacterClass();
                MainMenu(horrorCharacter);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }    
        public static void MainMenu(CharacterClass horrorCharacter) {
            CharacSheets characInfo = new CharacSheets();
            Choices choices = new Choices();

            bool placeholder = false;

            while (!placeholder)
            {
                
                horrorCharacter.Introduction();
                

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            choices.NewGame();
                            break;
                        case 2:
                            Console.Clear();
                            choices.CurrentGame();
                            break;
                        case 3:
                            Console.Clear();
                            choices.CampaignMode();
                            break;
                        case 4:
                            Console.Clear();
                            choices.Credits();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Press any key to confirm exit: ");
                            Console.ReadKey();
                            Environment.Exit(0);
                            placeholder = true;
                            break;
                        default:
                            Console.Clear();
                            throw new Exception("Invalid input. Please try again!");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Error: " + "Invalid input. Please try again!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

    }
}
     
