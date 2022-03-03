namespace Jeu_1
{
    public class Player : Entity
    {
        private Inventory _inventory;
        private Equipment _equipment;

        private int _exp = 0;
        private int _lvl = 1;
        private int _expThreshold = 100;
        private string _genre;


        //Stats de base du joueur v1
        private int _statVitality = 1;
        private int _statStrength = 1;
        private int _statMagic = 1;

      
        private int _healValue = 10;
        public int StatVitality { get { return _statVitality; } set { _statVitality = value;} }
        public int StatStrength { get { return _statStrength; } set { _statStrength = value;} }
        public int StatMagic { get { return _statMagic; } set { _statMagic = value;} }
        public int Exp { get { return _exp; } set { _exp = value; } }
        public int Lvl { get { return _lvl; } }
        public string Genre { get { return _genre; } set { _genre = value;} }

        public Inventory Inventory { get { return _inventory; } }
        public Equipment Equipment { get { return _equipment; } }


        //Le joueur monte de niveau tout les 100 points d'experience
        public void LvlUp()
        {
            _lvl += 1;
            Console.WriteLine($"Vous passez au niveau {_lvl} !");
            _maxHealth += 10;
            Health = MaxHealth;

            //Récompense par lvl up sujet au changement
            _damage += 1;

            _statMagic += 5;
            _statStrength += 1;
            _statVitality += 1;

            Exp -= _expThreshold; //A changer
        }

        public void TestLvlUp()
        {
            while(Exp > (_lvl*_expThreshold)) //Le level du joueur multiplie le threshold, le threshold change a chaque level.
            {
                this.LvlUp();
            }
        }

        public Player(string name, int maxHealth, int damage, string genre) : base(name, maxHealth, damage, 5)
        {
            _genre = genre;

            _inventory = new Inventory();
            _equipment = new Equipment(ref _inventory);

            // Test equipment
            EquipableItem bronzeSword = new EquipableItem(10, "Bronze Sword", EQuality.Poor, EEquipableType.MainHand,
                new int[] { 0, 0, 5, 5, 0, 1, 10 });
            EquipableItem woodenShield = new EquipableItem(10, "Wooden Shield", EQuality.Poor, EEquipableType.OffHand,
                new int[] { 10, 0, 0, 0, 0, 0, 0 });
            _equipment.EquipItems(new EquipableItem[] { bronzeSword, woodenShield });
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

        public override void Heal()
        {
            int amount = 0;

            if (_statMagic > 0)
                amount += _healValue + (_statMagic / 2);
            else
                amount += _healValue;

            Health += amount;
            Console.WriteLine($"{this.Name} se soigne et récupère {amount} PV");
        }
    }
}
