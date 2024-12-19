using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace CharacterCreation
{

    public class CharacSheets
    {
        UserFeatures ft = new UserFeatures();
        public void PlayerName(CharacterClass horrorCharacter)
        {
            bool ph = false;
            InputValidator validator = new InputValidator();

            while (!ph)
            { 
                Console.WriteLine("Please enter your name (Alphanumeric, minimum of 7 characters and maximum of 20 characters): ");
                string name = Console.ReadLine();
                horrorCharacter.ft.PlayerName = InputValidator.Validation(name);

                if (validator.CheckIfNameExists(horrorCharacter.ft.PlayerName))
                {
                    Console.WriteLine("This name is already taken. Please choose a different name.");
                }
                else
                {
                    ph = true;
                    Console.WriteLine($"\nWelcome, {horrorCharacter.ft.PlayerName}! You're reaching your death.\n");
                    Age(horrorCharacter);
                }
            }
        }
        public void Age(CharacterClass horrorCharacter)
        {
            bool ph = false;
            while (!ph)
            {
                try
                {
                    Console.WriteLine("Please enter your age: ");
                    Options.Age();

                    horrorCharacter.ft.PlayerAge = Console.ReadLine();

                    switch (horrorCharacter.ft.PlayerAge)
                    {
                        case "1":
                            horrorCharacter.ft.PlayerAge = "Child";
                            Gender(horrorCharacter);
                            ph = true;
                            break;

                        case "2":
                            horrorCharacter.ft.PlayerAge = "Teenager";
                            Gender(horrorCharacter);
                            ph = true;
                            break;

                        case "3":
                            horrorCharacter.ft.PlayerAge = "Adult";
                            Gender(horrorCharacter);
                            ph = true;
                            break;

                        case "4":
                            horrorCharacter.ft.PlayerAge = "Middle";
                            Gender(horrorCharacter);
                            ph = true;
                            break;

                        case "5":
                            horrorCharacter.ft.PlayerAge = "Old";
                            Gender(horrorCharacter);
                            ph = true;
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Please try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
      
        public void Gender(CharacterClass horrorCharacter)
        {
            bool placeholder = false;

            while (!placeholder)
            {
                try
                {
                    Console.WriteLine("\nPlease choose the gender you identified with: \n");
                    Options.Gender();

                    horrorCharacter.ft.PlayerGender = Console.ReadLine();

                    switch (horrorCharacter.ft.PlayerGender)
                    {
                        case "1":
                            horrorCharacter.ft.PlayerGender = "Female";
                            GameType(horrorCharacter);
                            placeholder = true;
                            break;
                        case "2":
                            horrorCharacter.ft.PlayerGender = "Male";
                            GameType(horrorCharacter);
                            placeholder = true;
                            break;
                        case "3":
                            horrorCharacter.ft.PlayerGender = "Nonbinary";
                            GameType(horrorCharacter);
                            placeholder = true;
                            break;
                        case "4":
                            horrorCharacter.ft.PlayerGender = "Prefer not to say";
                            GameType(horrorCharacter);
                            placeholder = true;
                            break;
                        case "5":
                            horrorCharacter.ft.PlayerGender = "Others";
                            GameType(horrorCharacter);
                            placeholder = true;
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void GameType(CharacterClass horrorCharacter)
        {
            horrorCharacter.gs = new GameStruc(horrorCharacter.ft.PlayerName, horrorCharacter.ft.PlayerAge, horrorCharacter.ft.PlayerGender);

            bool placeholder = false;

            while (!placeholder)
            {
                try
                {
                    Console.WriteLine($"Please choose your TEAM TYPE, {horrorCharacter.ft.PlayerName}!");
                    Console.WriteLine($"{"[1]",-5} | Hunter: Hunters are known for eating their prey, claws gritting against their prey’s skin.");
                    Console.WriteLine($"{"[2]",-5} | Survivor: You will search for clues regarding the mysterious accident, undiscovered by the enemy.\n");

                    char choice = Convert.ToChar(Console.ReadLine());

                    switch (choice)
                    {
                        case '1':
                           
                                horrorCharacter.ft.TeamType = "Team Type: Hunter";
                                horrorCharacter.ft.SurvivorSkill = "None";
                            
                            HunterSkills(horrorCharacter);
                            placeholder = true;
                            break;

                        case '2':
                            horrorCharacter.ft.TeamType = "Team Type: Survivor";
                            horrorCharacter.ft.HunterSkill = "None";
                            SurvivorSkills(horrorCharacter);

                            placeholder = true;
                            break;

                        default:
                            throw new FormatException("Invalid input. Please try again!\n");
                    }

                    
                    if (choice == '2')
                    {

                        horrorCharacter.ft.TeamType = "Team Type: Survivor";
                        horrorCharacter.ft.TeamType = "Team Type: None";
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        
        public void HunterSkills(CharacterClass horrorCharacter)
        {
            bool ph = false;

            while (!ph)
            {
               
                try
                {
                    Console.WriteLine("\nPlease choose your skill:\n");
                    Options.HunterSkills();

                    string choices = Console.ReadLine();

                    switch (choices)
                    {
                        case "1":
                            horrorCharacter.ft.HunterSkill = "Doppelganger";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "2":
                            horrorCharacter.ft.HunterSkill = "Poltergeist";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "3":
                            horrorCharacter.ft.HunterSkill = "Trickster";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "4":
                            horrorCharacter.ft.HunterSkill = "Phantom";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "5":
                            horrorCharacter.ft.HunterSkill = "Assassin";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void SurvivorSkills(CharacterClass horrorCharacter)
        {
            bool ph = false;

            while (!ph)
            {
                
                try
                {
                   
                    Console.WriteLine("\nPlease choose your skill:\n");
                    Options.SurvivorSkills();

                    horrorCharacter.ft.SurvivorSkill = Console.ReadLine();


                    switch (horrorCharacter.ft.SurvivorSkill)
                    {
                        case "1":
                            horrorCharacter.ft.SurvivorSkill = "Ace in the Hole";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "2":
                            horrorCharacter.ft.SurvivorSkill = "Blood Pact";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "3":
                            horrorCharacter.ft.SurvivorSkill = "Circle of Healing";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "4":
                            horrorCharacter.ft.SurvivorSkill = "Borrowed Time";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        case "5":
                            horrorCharacter.ft.SurvivorSkill = "Critical Thinking";
                            Weapon(horrorCharacter);
                            ph = true;
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void Weapon(CharacterClass horrorCharacter)
        {
            
            bool ph = false;

            while (!ph)
            {

                try
                {
                    Console.WriteLine("\nPlease choose your weapon:");
                    Options.Weapon();

                    horrorCharacter.ft.Weapon = Console.ReadLine();

                    switch (horrorCharacter.ft.Weapon)
                    {
                        case "1":
                            horrorCharacter.ft.Weapon = "Rifle";
                            Abilities(horrorCharacter);
                            ph = true;
                            break;
                        case "2":
                            horrorCharacter.ft.Weapon = "Machete";
                            Abilities(horrorCharacter);
                            ph = true;
                            break;
                        case "3":
                            horrorCharacter.ft.Weapon = "Axe";
                            Abilities(horrorCharacter);
                            ph = true;
                            break;
                        case "4":
                            horrorCharacter.ft.Weapon = "Pistol";
                            Abilities(horrorCharacter);
                            ph = true;
                            break;
                        case "5":
                            horrorCharacter.ft.Weapon = "Bow and Arrow";
                            Abilities(horrorCharacter);
                            ph = true;
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
        public void Abilities(CharacterClass horrorCharacter)
        {
     
            bool ph = false;

            while (!ph)
            {

                try
                {
                    Console.WriteLine("\nPlease choose your ability:\n");
                    Options.Ability();

                    horrorCharacter.ft.Ability = Console.ReadLine();

                    switch (horrorCharacter.ft.Ability)
                    {
                        case "1":
                            horrorCharacter.ft.Ability = "Healing";
                            Stats(horrorCharacter);
                            ph = true;
                            break;
                        case "2":
                            horrorCharacter.ft.Ability = "Sword Wielder";
                            Stats(horrorCharacter);
                            ph = true;
                            break;
                        case "3":
                            horrorCharacter.ft.Ability = "Marksman";
                            Stats(horrorCharacter);
                            ph = true;
                            break;
                        case "4":
                            horrorCharacter.ft.Ability = "Clairvoyance";
                            Stats(horrorCharacter);
                            ph = true;
                            break;
                        case "5":
                            horrorCharacter.ft.Ability = "Silent Steps";
                            Stats(horrorCharacter);
                            ph = true;
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
        public void Stats(CharacterClass horrorCharacter)
        {
            horrorCharacter.ft.Health = 120;
            horrorCharacter.ft.Strength = 10;
            horrorCharacter.ft.Stamina = 10;
            horrorCharacter.ft.Speed = 10;
            horrorCharacter.ft.Energy = 10;
            horrorCharacter.ft.Stats = 5;
            bool ph = false;
            int statsallo = 5;

            while (!ph)
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (statsallo == 0) { break; }
                        Console.Write($"\nYou have free {statsallo} stat points. Which stat do you wish to increase? ");
                        Console.WriteLine("\n[1] Health, +15 HP permanently.");
                        Console.WriteLine("[2] Strength, +5 XP permanently.");
                        Console.WriteLine("[3] Stamina, +4 XP permanently.");
                        Console.WriteLine("[4] Speed, +2 XP permanently.");
                        Console.WriteLine("[5] Energy, +2 XP permanently.");

                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                horrorCharacter.ft.Health += 15;
                                Console.WriteLine("You added 15 points to HEALTH.\n");
                                statsallo--;
                                break;
                            case 2:
                                horrorCharacter.ft.Strength += 5;
                                Console.WriteLine("You added 5 points to STRENGTH.\n");
                                statsallo--;
                                break;
                            case 3:
                                horrorCharacter.ft.Stamina += 4;
                                Console.WriteLine("You added 4 points to STAMINA.\n");
                                statsallo--;
                                break;
                            case 4:
                                horrorCharacter.ft.Speed += 2;
                                Console.WriteLine("You added 2 points to SPEED.\n");
                                statsallo--;
                                break;
                            case 5:
                                horrorCharacter.ft.Energy += 2;
                                Console.WriteLine("You added 2 points to ENERGY.\n");
                                statsallo--;
                                break;
                            default:
                                throw new ArgumentException("Invalid input. Try again!");
                        }
                    }
                    PhysicalTraits(horrorCharacter);
                    ph = true;
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
            }
        }
        public void PhysicalTraits(CharacterClass horrorCharacter)
        {

            bool ph = false;
            while (!ph)
            {
                try
                {
                    
                    Console.WriteLine("\nPlease choose your hairstyle:\n");
                    Options.HairStyle();

                    horrorCharacter.ft.HairStyle = Console.ReadLine();

                    switch (horrorCharacter.ft.HairStyle)
                    {
                        case "1":
                            horrorCharacter.ft.HairStyle = "Clean Cut";
                            break;

                        case "2":
                            horrorCharacter.ft.HairStyle = "Buzz Cut";                      
                            break;

                        case "3":
                            horrorCharacter.ft.HairStyle = "Fade Cut";                       
                            break;

                        case "4":
                            horrorCharacter.ft.HairStyle = "Wolf Cut";               
                            break;

                        case "5":
                            horrorCharacter.ft.HairStyle = "Long Hair";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your hair color:\n");
                    Options.HairColor();

                    horrorCharacter.ft.HairColor = Console.ReadLine();

                    switch (horrorCharacter.ft.HairColor)
                    {
                        case "1":
                            horrorCharacter.ft.HairColor = "Red";
                            break;

                        case "2":
                            horrorCharacter.ft.HairColor = "Black";
                            break;

                        case "3":
                            horrorCharacter.ft.HairColor = "Brown";
                            break;

                        case "4":
                            horrorCharacter.ft.HairColor = "Orange";
                            break;

                        case "5":
                            horrorCharacter.ft.HairColor = "Blonde";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your skin color:");
                    Options.SkinColor();

                    horrorCharacter.ft.SkinColor = Console.ReadLine();

                    switch (horrorCharacter.ft.SkinColor)
                    {
                        case "1":
                            horrorCharacter.ft.SkinColor = "Brown";
                            break;

                        case "2":
                            horrorCharacter.ft.SkinColor = "Black";
                            break;

                        case "3":
                            horrorCharacter.ft.SkinColor = "White";
                            break;

                        case "4":
                            horrorCharacter.ft.SkinColor = "Yellow";
                            break;

                        case "5":
                            horrorCharacter.ft.SkinColor = "Porcelain";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                    Console.WriteLine("\nPlease choose your eye color:");
                    Options.EyeColor();

                    horrorCharacter.ft.EyeColor = Console.ReadLine();

                    switch (horrorCharacter.ft.EyeColor)
                    {
                        case "1":
                            horrorCharacter.ft.EyeColor = "Brown";
                            break;

                        case "2":
                            horrorCharacter.ft.EyeColor = "Black";
                            break;

                        case "3":
                            horrorCharacter.ft.EyeColor = "Red";
                            break;

                        case "4":
                            horrorCharacter.ft.EyeColor = "Blue";
                            break;

                        case "5":
                            horrorCharacter.ft.EyeColor = "Green";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your scar:\n");
                    Options.Scar();

                    horrorCharacter.ft.Scar = Console.ReadLine();

                    switch (horrorCharacter.ft.Scar)
                    {
                        case "1":
                            horrorCharacter.ft.Scar = "Eye Scar";
                            break;

                        case "2":
                            horrorCharacter.ft.Scar = "Leg Scar";
                            break;

                        case "3":
                            horrorCharacter.ft.Scar = "Arm Scar";
                            break;

                        case "4":
                            horrorCharacter.ft.Scar = "Chest Scar";
                            break;

                        case "5":
                            horrorCharacter.ft.Scar = "Shoulder Scar";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                  
                    Console.WriteLine("\nPlease choose your face shape:\n");
                    Options.Shape();

                    horrorCharacter.ft.FaceShape = Console.ReadLine();

                    switch (horrorCharacter.ft.FaceShape)
                    {
                        case "1":
                            horrorCharacter.ft.FaceShape = "Triangular";
                            break;
                        case "2":
                            horrorCharacter.ft.FaceShape = "Oval";
                            break;
                        case "3":
                            horrorCharacter.ft.FaceShape = "Circle";
                            break;
                        case "4":
                            horrorCharacter.ft.FaceShape = "Square";
                            break;
                        case "5":
                            horrorCharacter.ft.FaceShape = "Diamond";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your expression:\n");
                    Options.Expression();
                    horrorCharacter.ft.FaceExpression = Console.ReadLine();

                    switch (horrorCharacter.ft.FaceExpression)
                    {
                        case "1":
                            horrorCharacter.ft.FaceExpression = "Angry";
                            break;
                        case "2":
                            horrorCharacter.ft.FaceExpression = "Sad";
                            break;
                        case "3":
                            horrorCharacter.ft.FaceExpression = "Smile";
                            break;
                        case "4":
                            horrorCharacter.ft.FaceExpression = "Calm";
                            break;
                        case "5":
                            horrorCharacter.ft.FaceExpression = "Confused";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your height:\n");
                    Options.Heights();
                    horrorCharacter.ft.Height = Console.ReadLine();

                    switch (horrorCharacter.ft.Height)
                    {
                        case "1":
                            horrorCharacter.ft.Height = "Short";
                            break;
                        case "2":
                            horrorCharacter.ft.Height = "Average";
                            break;
                        case "3":
                            horrorCharacter.ft.Height = "Tall";
                            break;
                        case "4":
                            horrorCharacter.ft.Height = "Dwarf";
                            break;
                        case "5":
                            horrorCharacter.ft.Height = "Giant";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your weight:\n");
                    Options.Weights();
                    horrorCharacter.ft.Weight = Console.ReadLine();

                    switch (horrorCharacter.ft.Weight)
                    {
                        case "1":
                            horrorCharacter.ft.Weight = "Skinny";
                            break;
                        case "2":
                            horrorCharacter.ft.Weight = "Slim";
                            break;
                        case "3":
                            horrorCharacter.ft.Weight = "Fit";
                            break;
                        case "4":
                            horrorCharacter.ft.Weight = "Plump";
                            break;
                        case "5":
                            horrorCharacter.ft.Weight = "Fat";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Clothing(horrorCharacter);

                    ph = true;
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }
        public void Clothing(CharacterClass horrorCharacter)
        {
            bool ph = false;
            while (!ph)
            {
                try
                {
                    Console.WriteLine("\nPlease choose your clothes:\n");
                    Options.TopClothes();
                    horrorCharacter.ft.PlayerTop = Console.ReadLine();

                    switch (horrorCharacter.ft.PlayerTop)
                    {
                        case "1":
                            horrorCharacter.ft.PlayerTop = "Shirt";
                            break;
                        case "2":
                            horrorCharacter.ft.PlayerTop = "Jacket";
                            break;
                        case "3":
                            horrorCharacter.ft.PlayerTop = "Long Sleeves";
                            break;
                        case "4":
                            horrorCharacter.ft.PlayerTop = "Dress";
                            break;
                        case "5":
                            horrorCharacter.ft.PlayerTop = "Coat";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                    Options.PantsClothes();
                    horrorCharacter.ft.PlayerPants = Console.ReadLine();

                    switch (horrorCharacter.ft.PlayerPants)
                    {
                        case "1":
                            horrorCharacter.ft.PlayerPants = "Cargo";
                            break;
                        case "2":
                            horrorCharacter.ft.PlayerPants = "Shorts";
                            break;
                        case "3":
                            horrorCharacter.ft.PlayerPants = "Jeans";
                            break;
                        case "4":
                            horrorCharacter.ft.PlayerPants = "Leather Pants";
                            break;
                        case "5":
                            horrorCharacter.ft.PlayerPants = "Khaki Pants";
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }
                    Accessories(horrorCharacter);
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }
        public static void Accessories(CharacterClass horrorCharacter)
        {

            bool ph = false;

            while (!ph)
            {
                try
                {
                    Console.WriteLine("\nDo you wish to have accessories?");
                    Console.WriteLine("[1] YES");
                    Console.WriteLine("[2] NO");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice != 1 && choice != 2)
                    {
                        Console.WriteLine("Invalid input. Please try again!");
                        continue;  
                    }

                    horrorCharacter.ft.accessories = (choice == 1) ? true : false;

                    if (horrorCharacter.ft.accessories == true)
                    {
                        AccessoriesTwo(horrorCharacter);
                    }
                    if (horrorCharacter.ft.accessories == false)
                    {
                        UserFeatures.Hat = "None";
                        UserFeatures.Glasses = "None";
                        UserFeatures.Necklace = "None";
                        UserFeatures.Bracelet = "None";
                        UserFeatures.Anklet = "None";

                        Armor(horrorCharacter);
                        
                    }
                }

                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }
        public static void AccessoriesTwo(CharacterClass horrorCharacter)
        {

            bool ph = false;

            while (!ph)
            {
                try
                {
                    Console.WriteLine("\nPlease choose your hat:");
                    Options.Hats();

                    UserFeatures.Hat = Console.ReadLine();

                    switch (UserFeatures.Hat)
                    {
                        case "1":
                            UserFeatures.Hat = "Baseball Cap";
                            break;

                        case "2":
                            UserFeatures.Hat = "Cowboy Hat";
                            break;

                        case "3":
                            UserFeatures.Hat = "Fedora";
                            break;

                        case "4":
                            UserFeatures.Hat = "Bucket Hat";
                            break;

                        case "5":
                            UserFeatures.Hat = "None";
                            break;

                        default:
                            throw new ArgumentException("Invalid input. Try again!");
                    }

                    Console.WriteLine("\nPlease choose your glasses:");
                    Options.Glasses();

                    UserFeatures.Glasses = Console.ReadLine();

                    switch (UserFeatures.Glasses)
                    {
                        case "1":
                            UserFeatures.Glasses = "Square";
                            break;
                        case "2":
                            UserFeatures.Glasses = "Round";
                            break;
                        case "3":
                            UserFeatures.Glasses = "Oval";
                            break;
                        case "4":
                            UserFeatures.Glasses = "Sunglasses";
                            break;
                        case "5":
                            UserFeatures.Glasses = "None";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }

                    Console.WriteLine("\nPlease choose your necklace:");
                    Options.Necklaces();

                    UserFeatures.Necklace = Console.ReadLine();

                    switch (UserFeatures.Necklace)
                    {
                        case "1":
                            UserFeatures.Necklace = "Gold";
                            break;
                        case "2":
                            UserFeatures.Necklace = "Silver";
                            break;
                        case "3":
                            UserFeatures.Necklace = "Chain";
                            break;
                        case "4":
                            UserFeatures.Necklace = "Diamond";
                            break;
                        case "5":
                            UserFeatures.Necklace = "None";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }

                    Console.WriteLine("\nPlease choose your bracelet:");
                    Options.Bracelet();

                    UserFeatures.Bracelet = Console.ReadLine();

                    switch (UserFeatures.Bracelet)
                    {
                        case "1":
                            UserFeatures.Bracelet = "Gold";
                            break;
                        case "2":
                            UserFeatures.Bracelet = "Silver";
                            break;
                        case "3":
                            UserFeatures.Bracelet = "Chain";
                            break;
                        case "4":
                            UserFeatures.Bracelet = "Diamond";
                            break;
                        case "5":
                            UserFeatures.Bracelet = "None";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }

                    Console.WriteLine("\nPlease choose your anklet:");
                    Options.Anklets();

                    UserFeatures.Anklet = Console.ReadLine();

                    switch (UserFeatures.Anklet)
                    {
                        case "1":
                            UserFeatures.Anklet = "Charm Anklet";
                            break;
                        case "2":
                            UserFeatures.Anklet = "Gold Anklet";
                            break;
                        case "3":
                            UserFeatures.Anklet = "Beaded Anklet";
                            break;
                        case "4":
                            UserFeatures.Anklet = "Chain Anklet";
                            break;
                        case "5":
                            UserFeatures.Anklet = "None";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }
                    ph = true;
                    Armor(horrorCharacter);
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }
        public static void Armor(CharacterClass horrorCharacter)
        {

            bool ph = false;
            while (!ph)
            {
                try
                {
                    Console.WriteLine("\nPlease choose your armor:");
                    Options.Armors();
                    horrorCharacter.ft.Armor = Console.ReadLine();

                    switch (horrorCharacter.ft.Armor)
                    {
                        case "1":
                            horrorCharacter.ft.Armor = "Sturdy Armor";
                            break;
                        case "2":
                            horrorCharacter.ft.Armor = "Leather Armor";
                            break;
                        case "3":
                            horrorCharacter.ft.Armor = "Iron Armor";
                            break;
                        case "4":
                            horrorCharacter.ft.Armor = "Chain Armor";
                            break;
                        case "5":
                            horrorCharacter.ft.Armor = "Cloth Armor";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }
                    Buffs(horrorCharacter);
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }

            }

        }
        public static void Buffs(CharacterClass horrorCharacter)
        {
            bool ph = false;

            while (!ph)
            {
                try
                {
                    Console.WriteLine("\nPlease choose your buff: ");
                    Options.Buffs();

                    horrorCharacter.ft.Buff = Console.ReadLine();

                    switch (horrorCharacter.ft.Buff)
                    {
                        case "1":
                            horrorCharacter.ft.Buff = "Enhanced Healing";
                            break;
                        case "2":
                            horrorCharacter.ft.Buff = "Increased Attack Speed";
                            break;
                        case "3":
                            horrorCharacter.ft.Buff = "Tough Defense";
                            break;
                        case "4":
                            horrorCharacter.ft.Buff = "Increased Stealth";
                            break;
                        case "5":
                            horrorCharacter.ft.Buff = "Increased Stamina";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }
                    Attitude(horrorCharacter);
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
            }
        }
        public static void Attitude(CharacterClass horrorCharacter)
        {
            bool ph = false;
            while (!ph)
            {
                try {
                    Console.WriteLine("\nPlease choose your character's attitude: ");
                    Options.Attitudes();

                    horrorCharacter.ft.Attitude = Console.ReadLine();

                    switch (horrorCharacter.ft.Attitude)
                    {
                        case "1":
                            horrorCharacter.ft.Attitude = "Wistful";
                            break;
                        case "2":
                            horrorCharacter.ft.Attitude = "Enthusiastic";
                            break;
                        case "3":
                            horrorCharacter.ft.Attitude = "Calm";
                            break;
                        case "4":
                            horrorCharacter.ft.Attitude = "Scared";
                            break;
                        case "5":
                            horrorCharacter.ft.Attitude = "Blank";
                            break;
                        default:
                            throw new ArgumentException("Invalid input! Please try again.");
                    }
                    PrintInputs.PrintAll(horrorCharacter);
                }
                catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
            }
        }
    }
}
//bool ph = false;

//while (!ph) {
//    try
//    {

//    }

//    catch (ArgumentException ex) { } }