namespace Jeu_1
{
    public class Player : Entity
    {
        private int _exp = 0;
        private int _lvl = 1;
        private int _expThreshold = 100;

        private int _healValue = 10;

        public int Exp { get { return _exp; } set { _exp = value; } }
        public int Lvl { get { return _lvl; } }

        //Le joueur monte de niveau tout les 100 points d'experience
        public void LvlUp()
        {
            _lvl += 1;
            Console.WriteLine($"Vous passez au niveau {_lvl} !");
            _maxHealth += 10;
            Health = MaxHealth;
            _damage += 1;
            Exp -= _expThreshold;
            _spellPower += 10;
        }

        public void TestLvlUp()
        {
            while(Exp > _expThreshold)
            {
                this.LvlUp();
            }
        }

        public Player(string name, int maxHealth, int damage) : base(name, maxHealth, damage)
        {
        }

        /**
public Player(string name, int maxHealth, int weaponDamage) : base(name, maxHealth)
{
   _weaponDamage = weaponDamage;
}
**/

        public override void Attack()
        {
            Enemy.Health -= Damage;
            Console.WriteLine($"{this.Name} attaque ! {this.Enemy.Name} reçoit {Damage} dégats");
        }

        public int ChooseAction()
        {
            bool isFormatOK = false;
            int choice = 0;
            while (!isFormatOK)
            {
                Console.WriteLine("1 : attaquer, 2 : se soigner");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                    {
                        isFormatOK = true;
                    }
                    else
                    {
                        Console.WriteLine("Saisie incorrecte.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Saisie incorrecte.");
                }
            }
            return choice;
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
            int amount = 0;

            if (_spellPower > 0)
                amount += _healValue + (_spellPower / 2);
            else
                amount += _healValue;

            Health += amount;
            Console.WriteLine($"{this.Name} se soigne et récupère {amount} PV");
        }
    }
}
