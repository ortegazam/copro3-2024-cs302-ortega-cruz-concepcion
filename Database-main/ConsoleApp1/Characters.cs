using System;

namespace CharacterCreation
{
    public abstract class Characters : saveOrEdit
    {
        public Options op { get; set; }
        public UserFeatures ft { get; set; }
        public PrintInputs cs { get; set; }
        public GameStruc gs { get; set; }

        public Characters()
        {
            this.op = new Options();
            this.ft = new UserFeatures();
        }

        public abstract void Introduction();

        public void Save()
        {
            Console.WriteLine("Save character?");
        }

        public void Edit()
        {
            Console.WriteLine("Edit character?");
        }
    }
}