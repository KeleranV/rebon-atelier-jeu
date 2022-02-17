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
