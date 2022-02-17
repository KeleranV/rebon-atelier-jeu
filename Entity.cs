namespace Jeu_1
{
    public abstract class Entity
    {
        protected int _maxHealth;
        private int _health;
        private Entity _enemy;
        private string _name;
        protected int _armor = 0;
        protected int _damage = 0;


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
            set { _armor = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
        }

        public Entity Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }

        public string Name
        {
            get { return _name; }
        }

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

        public Entity(string name, int maxHealth, int damage)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = _maxHealth;
            _damage = damage;

        }


        public virtual void Attack()
        {
            Console.WriteLine($"{this.Name} attaque ! {this.Enemy.Name} reçoit 10 dégats");
            _enemy.Health -= 10;
        }

        public abstract void Heal();
    }
}


