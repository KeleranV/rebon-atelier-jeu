namespace Jeu_1
{
    public class Player : Entity
    {
        private int _exp = 0;
        private int _lvl = 1;
        private int _expThreshold = 100;
        private string _genre;

        public int Exp { get { return _exp; } set { _exp = value; } }
        public int Lvl { get { return _lvl; } }
        public string Genre { get { return _genre; } set { _genre = value;} }


        //Le joueur monte de niveau tout les 100 points d'experience
        public void LvlUp()
        {
            _lvl += 1;
            Console.WriteLine($"Vous passez au niveau {_lvl} !");
            _maxHealth += 10;
            Health = MaxHealth;
            _damage += 1;
            Exp -= _expThreshold;
        }

        public void TestLvlUp()
        {
            while(Exp > _expThreshold)
            {
                this.LvlUp();
            }
        }

        public Player(string name, int maxHealth, int damage, string genre) : base(name, maxHealth, damage, 5)
        {
            _genre = genre;
        }

        /**
public Player(string name, int maxHealth, int weaponDamage) : base(name, maxHealth)
{
   _weaponDamage = weaponDamage;
}
**/

        public override void Attack()
        {
            base.Attack(Damage);
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

    }
}
