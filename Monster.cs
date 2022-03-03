using Newtonsoft.Json;

namespace Jeu_1
{
    public class Monster : Entity
    {
        private int _reward;
        private int _goldReward;
        private int _lvl;
        private static Player player;

        public int Reward { get { return _reward; } }
        public int GoldReward { get { return _goldReward; } }
        public int Lvl { get { return _lvl; } }

        public Monster(string name, int maxHealth, int statStrength, int statVitality, int damage, int armor, Entity enemy, int reward, int level) : base(name, maxHealth, statStrength, statVitality, damage, armor)
        {

            this._reward = reward;
            this._lvl = level;
        }
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

        /*public static int RandomizeMonsterMaxHealth()
        {
            int maxHealth = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(20, 71);
            maxHealth = randomNumber;
            return maxHealth;
        }*/
        /*public static int RandomizeMonsterDamage()
        {
            int damage = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(5, 15);
            damage = randomNumber;
            return damage;
        }*/
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
        public static string FetchMonsterData(string zone)
        {
            string path = "";
            if (zone == "Plains")
            {
                path = @"\MonsterDataPlains.json";
                return path;
            }
            if (zone == "Forest")
            {
                path = @"\MonsterDataForest.json";
                return path;
            }
            if (zone == "Beach")
            {
                path = @"\MonsterDataBeach.json";
                return path;
            }
            if (zone == "Swamp")
            {
                path = @"\MonsterDataSwamp.json";
                return path;
            }
            if (zone == "Dark_Forest")
            {
                path = @"\MonsterDataDarkForest.json";
                return path;
            }
            if (zone == "Aband_Town")
            {
                path = @"\MonsterDataAbandTown.json";
                return path;
            }
            if (zone == "Crypt")
            {
                path = @"\MonsterDataCrypt.json";
                return path;
            }
            if (zone == "Grotto")
            {
                path = @"\MonsterDataGrotto.json";
                return path;
            }
            if (zone == "Mountains")
            {
                path = @"\MonsterDataMountains.json";
                return path;
            }
            if (zone == "Volcano")
            {
                path = @"\MonsterDataVolcano.json";
                return path;
            }
            if (zone == "Hell")
            {
                path = @"\MonsterDataHell.json";
                return path;
            }
            return path;
        }
        public static Monster GenerateMonster(int x)
        {
            var CurrentDirectory = Environment.CurrentDirectory;
            string path = FetchMonsterData("Plains");
            string fullPath = CurrentDirectory + path;
            StreamReader r = new StreamReader(fullPath);
            string jsonString = r.ReadToEnd();
            List<Monster> monsterList = JsonConvert.DeserializeObject<List<Monster>>(jsonString);
            Monster monster = new Monster(
                monsterList[x].Name,
                monsterList[x].MaxHealth,
                monsterList[x].StatStrength,
                monsterList[x].StatVitality,
                monsterList[x].Damage,
                monsterList[x].Armor,
                player,   //enemy
                MonsterRewardCalculation(monsterList[x].MaxHealth, monsterList[x].Damage),  //reward
                RandomizeMonsterLvl("Plains"));  // lvl
            return monster;
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
            base.Attack(10);
        }
    }
}
