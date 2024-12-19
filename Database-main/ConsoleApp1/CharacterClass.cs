using System;

namespace CharacterCreation
{
    public class CharacterClass : Characters
    {
        public Options op { get; set; }
        public UserFeatures ft { get; set; }
        public PrintInputs cs { get; set; }

        public CharacterClass()
        {
            this.op = new Options();
            this.ft = new UserFeatures();
            this.cs = new PrintInputs();
        }


        public override void Introduction()
        {
     
            Console.Clear();
            string intro = "REACHING DEATH!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (intro.Length / 2)) + "}", intro));
           
            
            Console.WriteLine("\n(1) New Game");
            Console.WriteLine("(2) Load Game");
            Console.WriteLine("(3) Campaign Mode");
            Console.WriteLine("(4) Credits");
            Console.WriteLine("(5) Exit");
        }
        }
    }
