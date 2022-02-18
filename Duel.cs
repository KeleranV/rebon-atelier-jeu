namespace Jeu_1
{
    public class Duel
    {

        private Player _player;
        private Monster _monster;

        private int _nbTours = 0;
        private int _playerDamageToMonster = 0;
        private int _monsterDamageToPlayer = 0;

        public Player Player
        {
            get { return _player; }
        }

        public Monster Monster
        {
            get { return _monster; }
        }

        public int NbTours
        {
            get { return _nbTours; }
        }

        public int PlayerDamageToMonster
        {
            get { return _playerDamageToMonster; }
        }

        public int MonsterDamageToPlayer
        {
            get { return _monsterDamageToPlayer; }
        }

        public Duel(Player player, Monster monster)
        {
            _player = player;
            _monster = monster;
            player.Enemy = monster;
        }

        public void AfficherStatistiques()
        {
            Console.WriteLine(
                $"Nombre de tours : {NbTours}\n" +
                $"Dommages totaux causés au monstre : {PlayerDamageToMonster}\n" +
                $"Dommages totaux causés au joueur : {MonsterDamageToPlayer}"
                );
        }

        public void LancerCombat()
        {
            while(_player.Health > 0 && _monster.Health > 0)
            {
                _nbTours++;

                Console.Clear();
                Console.WriteLine($"{_player.Name} - Genre: {_player.Genre}: {_player.Health}pv Armor:{_player.Armor}");
                Console.WriteLine($"{_monster.Name}: {_monster.Health}pv");
                Console.WriteLine();
                AfficherStatistiques();

                TourPlayer();
                if (_monster.Health <= 0)
                    continue;
                TourMonster();
            }

            if (_player.Health <= 0)
                Console.WriteLine("Défaite, le monstre a gagné !");
            else
            {
                Console.WriteLine($"Victoire ! Vous remportez {_monster.Reward} exp !");
                _player.Exp =+ _monster.Reward;
                _player.TestLvlUp();
            }
        }

        private void TourPlayer()
        {
            int action = _player.ChooseAction();
            _player.ExecuteAction(action);
            if(action == 1)
                _playerDamageToMonster += _player.Damage;
        }
        private void TourMonster()
        {
            int action = _monster.ChooseAction();
            _monster.ExecuteAction(action);
            if (action == 1)
                _monsterDamageToPlayer += _monster.Damage;
        }

    }
}
