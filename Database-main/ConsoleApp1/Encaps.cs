using Mysqlx.Notice;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using Org.BouncyCastle.Utilities.Collections;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CharacterCreation
{

    public struct GameStruc
    {
        public string playerName { get; set; }
        public string playerAge { get; set; }
        public string playerGender { get; set; }

        public GameStruc(string playerName, string playerAge, string playerGender)
        {
            this.playerName = playerName;
            this.playerAge = playerAge;
            this.playerGender = playerGender;
        }
    }
    public class UserFeatures
    {

        public string PlayerName { get; set; }
        public string PlayerAge { get; set; }
        public string PlayerGender { get; set; }
        public string TeamType { get; set; }
        public string HunterSkill { get; set; }
        public string SurvivorSkill { get; set; }
        public string Weapon { get; set; }
        public string Ability { get; set; }
        public string HairStyle { get; set; }
        public string Scar { get; set; }
        public string FaceShape { get; set; }
        public string FaceExpression { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string PlayerTop { get; set; }
        public string PlayerPants { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Buff { get; set; }
        public static string Hat { get; set; }
        public static string Glasses { get; set; }
        public static string Necklace { get; set; }
        public static string Bracelet { get; set; }
        public static string Anklet { get; set; }
        public string Armor { get; set; }
        public string Attitude { get; set; }
        public int Stats { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Energy { get; set; }
        public bool accessories { get; set; }


        public UserFeatures(string name, string gender, string age, int stats, string armor,
            string anklet, string team, string hunter, string survivor, string weapon, string ability, bool accessories,
            int health, int speed, int energy, int stamina, string attitude, string lace,
            string bracelet, string top, string glasses, int strength,
            string scar, string style, string shape, string expression, string hat, string color, string skin,
            string eyes, string height, string weight)
        {
            this.PlayerName = name;
            this.PlayerAge = age;
            this.PlayerGender = gender;
            this.TeamType = team;
            this.SurvivorSkill = survivor;
            this.HunterSkill = hunter;
            this.Weapon = weapon;
            this.Ability = ability;
            this.HairStyle = style;
            this.HairColor = color;
            this.Scar = scar;
            this.FaceShape = shape;
            this.FaceExpression = expression;
            this.SkinColor = skin;
            this.EyeColor = eyes;
            this.PlayerTop = top;
            this.Height = height;
            this.Weight = weight;
            UserFeatures.Hat = hat;
            UserFeatures.Glasses = glasses;
            UserFeatures.Necklace = lace;
            UserFeatures.Bracelet = bracelet;
            UserFeatures.Anklet = anklet;
            this.Armor = armor;
            this.Attitude = attitude;
            this.Stats = stats;
            this.Health = health;
            this.Strength = strength;
            this.Stamina = stamina;
            this.Speed = speed;
            this.Energy = energy;
            this.accessories = accessories;


        }

        public UserFeatures()
        {
        }

        public static string[] gameStory = new string[]
        {
        /*"After the continuous disappearance of people who passed by the Mortis Manor, the police investigated the mansion." +
        " \nHowever, this investigation met a dead end. You, a known believer of ‘to see is to believe,’ didn’t care about these ‘baseless rumors’ and still drove around the manor. " +
        " Perhaps the rumors were false because, despite multiple drives around the street, none of the ghosts of those who disappeared appeared before you. But what comes around, goes around. " +
        "After a mysterious accident occurs to you, a strange and sanguine lobby meets you with a palpable stench in every crook. The air seems thick with dread, and every creaking sound echoes ominously through the hallways." + 
         " \r\n\r\nOnly then it dawns upon you that it is true. The horror stories surrounding the manor are real, as they slowly unfold in front of you. The eerie presence of the lost souls seems to hover around you, " +
        "a constant reminder of the mansion's sinister history. But the deities still have hope to defeat the devil—using you. How’d you know? They told you in your dream before you wake up. "
        +"The dream was vivid, almost too real to be dismissed, and you couldn't shake off the feeling that your fate was intertwined with something far darker than you ever imagined. " +
         "As you stand in the lobby, a heavy realization begins to sink in, " +
         "tightening around your chest like an iron grip. The curiosity that once led you here has shifted into something far darker—a desperate fight for your life. " +
         "You can almost hear the whispers of unseen voices, their words faint but clear, brushing against your mind like a ghostly caress. " +
         "The air grows uncomfortably cold. \r\n\r\nThe great walls that once were full of historical elegance now feel like an oppressive cage, slowly closing in upon you. " +
         "You try to move forward, but with each step, it is as if something invisible tugs at your very being, trying to keep you trapped in place. " +
         "The strange, reddish light flickers; long, twisted shadows are cast around the room, sending a chill through every sense." +
         "It’s unmistakable now—the manor is alive, watching, waiting, and it seems to be feeding on your fear, eager to see what you’ll do next." + "Now, you must find the strength to confront what lurks within Mortis Manor."
    */

            "After the continuous disappearance of people who passed by the Mortis Mansion, the police investigated the manor. " +
            "However, this investigation met a dead end. You, a firm believer of 'to see is to believe', didn't care about this rumors. " 
            + "Perhaps the rumors were false and baseless because, despite multiple drives around the streets, the horrors and ghosts didn't appear. "
            + "But what comes around, goes around. After a mysterious accident occurs to you, a strange and sanguine lobby meets you with a palpable stench in every crook. "
            + "\r\n\r\n Only then it dawns upon you that it is true, real in the flesh. The horror stories surrounding the manor are real. It is what you observed as they slowly unfolds in front of you. "
            + "But the deities still have hope to defeat it through you. You have come into terms with this idea when they appeared in your dream. "
            + "Hereinafter, a mission is bestowed upon you as secrets slowly seep through the cracked windows and bare ceilings of the mansion. "
            + "The remnants of the lost souls begs and hope that you will avenge their brutal deaths. "
            + "\r\n\r\n While your feet slowly firm its stand against the ground, your eyes grew still and brave as the manor's sanguine secrets unfolds. "
            + "The beads of stars turns bloody as they stare back at you through the bloodied holes of the mansion. Herewith, may it be by fate or taken by force that you somehow ended up in the mansion, "
            + "the deities' note is for you to be firm and not lose yourself as you wander around the mansion. Until then, may the odds be in your favor."
        };
    }
}

        
    



 