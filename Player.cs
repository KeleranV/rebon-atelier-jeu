namespace Jeu_1
{
    public class Player : Entity
    {   //Variables
        private Inventory _inventory;
        private Equipment _equipment;
        private int _exp = 0;
        private int _lvl = 1;
        private int _expThreshold = 100;
        private string _genre;
        private int _healValue = 10;

        //Getters / Setters
        public int Exp { get { return _exp; } set { _exp = value; } }
        public int Lvl { get { return _lvl; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public Inventory Inventory { get { return _inventory; } }
        public Equipment Equipment { get { return _equipment; } }
        
        //Constructor
        public Player(string name, int maxHealth, int statStrength, int statVitality, int damage, string genre) : base(name, maxHealth, statStrength, statVitality, damage, 0)
        {
            _genre = genre;

            _inventory = new Inventory();
            _equipment = new Equipment(ref _inventory);
        }
            
        //Methods
        public void LvlUp()
        {
            _lvl += 1;
            _maxHealth += 10;
            Health = MaxHealth;

            //Récompense par lvl up sujet au changement
            _damage += 1;

            StatMagic += 5;
            StatStrength += 1;
            StatVitality += 1;

            Exp -= _expThreshold; //A changer
        } //Le joueur monte de niveau tout les 100 points d'experience
        public void TestLvlUp()
        {
            while (Exp > (_lvl * _expThreshold)) //Le level du joueur multiplie le threshold, le threshold change a chaque level.
            {
                this.LvlUp();
            }
        }
        public override void Attack()
        {
            Attack(Damage);
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

            if (StatMagic > 0)
                amount += _healValue + (StatMagic / 2);
            else
                amount += _healValue;

            Health += amount;
            Console.WriteLine($"{this.Name} se soigne et récupère {amount} PV");
        }
    }
}
