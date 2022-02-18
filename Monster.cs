namespace Jeu_1
{
    public class Monster : Entity
    {
        private int _reward;

        public int Reward { get { return _reward; } }

        public Monster(string name, int maxHealth, int damage, Entity enemy, int reward) : base(name, maxHealth, damage)
        {
            this.Enemy = enemy;
            this._reward = reward;
        }
        public static string RandomizeMonsterName()
        {
            string name = "";
            Random rand = new Random();
            int randomNumber = rand.Next(1, 13);
            switch (randomNumber)
            {
                case 1:
                    name = "Goblin";
                    break;
                case 2:
                    name = "Kobold";
                    break;
                case 3:
                    name = "Slime";
                    break;
                case 4:
                    name = "Fairy";
                    break;
                case 5:
                    name = "Orc";
                    break;
                case 6:
                    name = "Ogre";
                    break;
                case 7:
                    name = "Bandit";
                    break;
                case 8:
                    name = "Boar";
                    break;
                case 9:
                    name = "Bear";
                    break;
                case 10:
                    name = "Wolf";
                    break;
                case 11:
                    name = "Bat";
                    break;
                case 12:
                    name = "Ghost";
                    break;
            }
            return name;
        }
        public static int RandomizeMonsterMaxHealth()
        {
            int maxHealth = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(20, 71);
            maxHealth = randomNumber;
            return maxHealth;
        }
        public static int RandomizeMonsterDamage()
        {
            int damage = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(5, 15);
            damage = randomNumber;
            return damage;
        }
        public static int MonsterRewardCalculation(int maxHp, int attack)
        {
            int reward = 0;
            reward = (maxHp / 2) + attack;
            return reward;

        }

        public static Monster GenerateMonster(string name, int maxHealth, int damage, Entity enemy, int reward)
        {
            Monster monster = new Monster(name, maxHealth, damage, enemy, reward);
            return monster;
        }

        public int ChooseAction()
        {
            if(this.Health == this.MaxHealth)
                return 1;
            else
            {
                Random random = new Random();
                int choice = random.Next(1, 3);
                if(choice == 1)
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

    }
}
