namespace Jeu_1
{
    public abstract class Entity
    {
        private string _name;
        protected int _maxHealth;
        private int _statStrength = 1;
        private int _statVitality = 1;
        protected int _armor = 0;
        protected int _damage = 0;
        private int _statMagic = 1;
        private int _health;
        private Entity _enemy;

        public string Name { get { return _name; } set { _name = value; } }
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        public int StatStrength { get { return _statStrength; } set { _statStrength = value; } }
        public int StatVitality { get { return _statVitality; } set { _statVitality = value; } }
        public int StatMagic { get { return _statMagic; } set { _statMagic = value; } }
        public int Damage
        {
            get { return _damage; }
            set {
                if (value < 1)
                {
                    _damage = 1;
                }
                else
                {
                    _damage = value;
                }
            }
        }
        public int Armor
        {
            get { return _armor; }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                } 
                _armor = value; 
            }
            
        }
        public Entity Enemy { get { return _enemy; } set { _enemy = value; } }
        public int Health
        {
            get { return _health; }
            set
            { 
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > _maxHealth)
                {
                    _health = _maxHealth;
                }
                else
                {
                    _health = value;
                }
            }
        }

        public Entity(string name, int maxHealth,int statStrength,int statVitality, int damage, int armor)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = _maxHealth;
            _statStrength = statStrength;
            _statVitality = statVitality;
            _damage = damage;
            _armor = armor;
        }

        public abstract void Attack();

        protected void Attack(int damage)
        {
            //Console.WriteLine($"{this.Name} attaque ! {this.Enemy.Name} reçoit 10 dégats");
            this._enemy.Health -= damage - this._enemy._armor;
        }

        public abstract void Heal();
    }
}


