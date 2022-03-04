using Newtonsoft.Json;

namespace Jeu_1
{
    public class Monster : Entity
    {   //Variables
        private int _reward;
        private int _lvl;
        private static Player player;

        //Getters / Setters
        public int Reward { get { return _reward; } }
        public int Lvl { get { return _lvl; } }

        //Constructor
        public Monster(string name, int maxHealth, int statStrength, int statVitality, int damage, int armor, Entity enemy, int reward, int level) : base(name, maxHealth, statStrength, statVitality, damage, armor)
        {

            this._reward = reward;
            this._lvl = level;
        }

        //Methods
        public static int RandomizeMonsterLvl(string zone)
        {
            Random rand = new Random();
            int randomNumber = 0;
            if (zone == "Plains")
            {
                randomNumber = rand.Next(1, 11);
            }
            if (zone == "Forest")
            {
                randomNumber = rand.Next(10, 21);
            }
            if (zone == "Beach")
            {
                randomNumber = rand.Next(20, 31);
            }
            if (zone == "Swamp")
            {
                randomNumber = rand.Next(30, 41);
            }
            if (zone == "Dark_Forest")
            {
                randomNumber = rand.Next(40, 51);
            }
            if (zone == "Aband_Town")
            {
                randomNumber = rand.Next(50, 61);
            }
            if (zone == "Swamp")
            {
                randomNumber = rand.Next(60, 71);
            }
            if (zone == "Grotto")
            {
                randomNumber = rand.Next(70, 81);
            }
            if (zone == "Mountains")
            {
                randomNumber = rand.Next(80, 91);
            }
            if (zone == "Volcano")
            {
                randomNumber = rand.Next(90, 101);
            }
            if (zone == "Hell")
            {
                randomNumber = rand.Next(100, 121);
            }
            return randomNumber;
        }
        public static int RandomizeMonster(string zone)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, 5);
            if (zone == "Plains")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Forest")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Beach")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Swamp")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Dark_Forest")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Aband_Town")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Crypt")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Grotto")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Mountains")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Volcano")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            if (zone == "Hell")
            {
                randomNumber = rand.Next(0, 5);
                return randomNumber;
            }
            return randomNumber;
        }
        public static int MonsterRewardCalculation(int maxHp, int attack)
        {
            int reward = 0;
            reward = (maxHp / 2) + attack;
            return reward;
        }
        public static int MonsterGoldRewardCalculation(int level)
        {
            int goldReward = level;
            return goldReward;
        }
        public static string FetchMonsterData(int x)
        {
            string path = "";
            path = $@"\MonsterData{Program.zoneList[x].Name}.json";
            return path;
        }
        public static Monster GenerateMonster(int x, List<Monster> liste)
        { 
            Monster monster = new Monster(
                liste[x].Name,
                liste[x].MaxHealth,
                liste[x].StatStrength,
                liste[x].StatVitality,
                liste[x].Damage,
                liste[x].Armor,
                player,   //enemy
                MonsterRewardCalculation(liste[x].MaxHealth, liste[x].Damage),  //reward
                RandomizeMonsterLvl(Program.zone.Name));  // lvl
            return monster;
        }
        public static List<Monster> GetMonsterData()
        {
            var CurrentDirectory = Environment.CurrentDirectory;
            string path = FetchMonsterData(Program.zone.Position);
            string fullPath = CurrentDirectory + path;
            StreamReader r = new StreamReader(fullPath);
            string jsonString = r.ReadToEnd();
            List<Monster> monsterList = JsonConvert.DeserializeObject<List<Monster>>(jsonString);
            return monsterList;
        }
        public int ChooseAction()
        {
            if (this.Health == this.MaxHealth)
                return 1;
            else
            {
                Random random = new Random();
                int choice = random.Next(1, 3);
                if (choice == 1)
                    return 1;
                else
                    return 2;
            }
        }
        public void ExecuteAction(int action)
        {
            switch (action)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Heal();
                    break;
            }
        }
        public override void Heal()
        {
            Health += 5;
        }

        public override void Attack()
        {
            Attack(Damage);
        }
    }
}
