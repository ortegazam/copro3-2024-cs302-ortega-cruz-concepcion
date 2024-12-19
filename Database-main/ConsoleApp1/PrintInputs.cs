using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreation;


namespace CharacterCreation
{
    public class PrintInputs
    {
        public Options op { get; set; }
        public UserFeatures ft { get; set; }
        public PrintInputs cs { get; set; }


        public static void PrintAll(CharacterClass horrorCharacter)
        {
            SaveToDatabase(horrorCharacter);

            try
            {

                Console.WriteLine("\nGo back to main menu?");
                Console.WriteLine("(1) YES");
                Console.WriteLine("(2) NO");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Menu.MainMenu(horrorCharacter);
                        break;
                    case 2:
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public static void SaveToDatabase(CharacterClass horrorCharacter)
        {
           
                try
                {
                    
                    Console.Clear();
                    Console.WriteLine($"\nCharacter Information:");
                    Console.WriteLine($"Name: {horrorCharacter.gs.playerName}");
                    Console.WriteLine($"Age: {horrorCharacter.gs.playerAge}");
                    Console.WriteLine($"Gender: {horrorCharacter.gs.playerGender}");
                    Console.WriteLine($"{horrorCharacter.ft.TeamType}\n");

                    Console.WriteLine($"Clothes: ");
                    Console.WriteLine($"Top: {horrorCharacter.ft.PlayerTop}");
                    Console.WriteLine($"Pants: {horrorCharacter.ft.PlayerPants}\n");

                    Console.WriteLine($"Physical Traits: ");
                    Console.WriteLine($"Face Shape: {horrorCharacter.ft.FaceShape}");
                    Console.WriteLine($"Hair Color: {horrorCharacter.ft.HairColor}");
                    Console.WriteLine($"Hairstyle: {horrorCharacter.ft.HairStyle}");
                    Console.WriteLine($"Skin Color: {horrorCharacter.ft.SkinColor}");
                    Console.WriteLine($"Eye Color: {horrorCharacter.ft.EyeColor}");
                    Console.WriteLine($"Height: {horrorCharacter.ft.Height}");
                    Console.WriteLine($"Weight: {horrorCharacter.ft.Weight}\n");

                    Console.WriteLine("Accessories: " + horrorCharacter.ft.accessories);
                    Console.WriteLine($"Hat: {UserFeatures.Hat}");
                    Console.WriteLine($"Glasses: {UserFeatures.Glasses}");
                    Console.WriteLine($"Necklace: {UserFeatures.Necklace}");
                    Console.WriteLine($"Bracelet: {UserFeatures.Bracelet}");
                    Console.WriteLine($"Anklet: {UserFeatures.Anklet}\n");

                    Console.WriteLine($"Character's Unique Traits: ");
                    Console.WriteLine($"Hunter Skill: {horrorCharacter.ft.HunterSkill}");
                    Console.WriteLine($"Survivor Skill: {horrorCharacter.ft.SurvivorSkill}");
                    Console.WriteLine($"Weapon: {horrorCharacter.ft.Weapon}");
                    Console.WriteLine($"Ability: {horrorCharacter.ft.Ability}");
                    Console.WriteLine($"Buff: {horrorCharacter.ft.Buff}");
                    Console.WriteLine($"Scar: {horrorCharacter.ft.Scar}\n");

                    Console.WriteLine("\nCharacter's Stats:");
                    Console.WriteLine($"Health: {horrorCharacter.ft.Health}");
                    Console.WriteLine($"Strength: {horrorCharacter.ft.Strength}");
                    Console.WriteLine($"Stamina: {horrorCharacter.ft.Stamina}");
                    Console.WriteLine($"Speed: {horrorCharacter.ft.Speed}");
                    Console.WriteLine($"Energy: {horrorCharacter.ft.Energy}");


                try
                {
                    string databaseConnecshun = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emmanuel\Downloads\Database-main\ConsoleApp1\Database1.mdf;Integrated Security=True";

                    using (SqlConnection sqlConnectNiyo = new SqlConnection(databaseConnecshun))
                    {
                        sqlConnectNiyo.Open();

                        string insertQuery = @"
                            INSERT INTO dbo.HorrorGame (
                                PlayerName, PlayerAge, PlayerGender, TeamType, [Top], Pants, FaceShape, HairColor, HairStyle, EyeColor, SkinColor, 
                                [Height], [Weight], Accessories, Hat, Glasses, Necklace, Bracelet, Anklet, HunterSkill, SurvivorSkill, Weapon, Ability, 
                                Scar, Health, Strength, Stamina, Speed, Energy
                            ) VALUES (
                                @PlayerName, @PlayerAge, @PlayerGender, @TeamType, @Top, @Pants, @FaceShape, @HairColor, @HairStyle, @EyeColor, @SkinColor,
                                @Height, @Weight, @Accessories, @Hat, @Glasses, @Necklace, @Bracelet, @Anklet, @HunterSkill, @SurvivorSkill, @Weapon, @Ability,
                                @Scar, @Health, @Strength, @Stamina, @Speed, @Energy
                            )";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, sqlConnectNiyo))
                        {
                            cmd.Parameters.AddWithValue("@PlayerName", horrorCharacter.gs.playerName ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@PlayerAge", horrorCharacter.gs.playerAge ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@PlayerGender", horrorCharacter.gs.playerGender ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@TeamType", horrorCharacter.ft.TeamType ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Top", horrorCharacter.ft.PlayerTop ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Pants", horrorCharacter.ft.PlayerPants ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@FaceShape", horrorCharacter.ft.FaceShape ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@HairColor", horrorCharacter.ft.HairColor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@HairStyle", horrorCharacter.ft.HairStyle ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@EyeColor", horrorCharacter.ft.EyeColor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@SkinColor", horrorCharacter.ft.SkinColor ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Height", horrorCharacter.ft.Height ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Weight", horrorCharacter.ft.Weight ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Accessories", horrorCharacter.ft.accessories);
                            cmd.Parameters.AddWithValue("@Hat", UserFeatures.Hat ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Glasses", UserFeatures.Glasses ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Necklace", UserFeatures.Necklace ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Bracelet", UserFeatures.Bracelet ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Anklet", UserFeatures.Anklet ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@HunterSkill", horrorCharacter.ft.HunterSkill ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@SurvivorSkill", horrorCharacter.ft.SurvivorSkill ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Weapon", horrorCharacter.ft.Weapon ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Ability", horrorCharacter.ft.Ability ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Scar", horrorCharacter.ft.Scar ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@Health", horrorCharacter.ft.Health);
                            cmd.Parameters.AddWithValue("@Energy", horrorCharacter.ft.Energy);
                            cmd.Parameters.AddWithValue("@Speed", horrorCharacter.ft.Speed);
                            cmd.Parameters.AddWithValue("@Strength", horrorCharacter.ft.Strength);
                            cmd.Parameters.AddWithValue("@Stamina", horrorCharacter.ft.Stamina);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("Character Saved!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }

