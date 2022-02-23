namespace Jeu_1
{
    public class Duel
    {

        private Player _player;
        private Monster _monster;

        private int _nbTours = 0;
        private int _nbDeVieARegenerer;
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

        public int NbDeVieARegenerer
        {
            get { return _nbDeVieARegenerer; }
        }
        public int PlayerDamageToMonster
        {
            get { return _playerDamageToMonster; }
        }

        public int MonsterDamageToPlayer
        {
            get { return _monsterDamageToPlayer; }
        }


        public Duel(Player player, Monster monster, int NbDeVieARegenerer)
        {
            _player = player;
            _monster = monster;
            player.Enemy = monster;
            _nbDeVieARegenerer = NbDeVieARegenerer;
        }

        public void AfficherStatistiques()
        {
            string nbTours = String.Format("{0,-50}", $"Nombre de tours : {NbTours}");
            string playerDamageToMonster = String.Format("{0,-50}", $"Dommages totaux causés au monstre : {PlayerDamageToMonster}");
            string monsterDamageToPlayer = String.Format("{0,-50}", $"Dommages totaux causés au joueur : {MonsterDamageToPlayer}");
            string regenVie = String.Format("{0,-50}", $"Nombre de vie a regenerer : {NbDeVieARegenerer}");
            string espace = String.Format("{0,-50}", "");

            Console.WriteLine($"{nbTours} Genre: {_player.Genre}\n" +
                $"{playerDamageToMonster} Niveau joueur: {_player.Lvl}\n" +
                $"{monsterDamageToPlayer} Experience: {_player.Exp}\n" +
                $"{regenVie} Armor: {_player.Armor}\n" +
                $"{espace} Strength: {_player.StatStrength}\n" +
                $"{espace} Vitality: {_player.StatVitality}\n" +
                $"{espace} Magic: {_player.StatMagic}       \n"
                );
        }

        public void LancerCombat()
        {
            
            while (_player.Health > 0 && _monster.Health > 0)
            {
                _nbTours++;

                Console.Clear();
                Console.WriteLine($"{_player.Name}:{_player.Health}pv");
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
                _player.Exp += _monster.Reward;
                _player.TestLvlUp();
                RegenererVieJoueur();
            }
        }
        private void TourPlayer()
        {
            int action = _player.ChooseAction();
            _player.ExecuteAction(action);
            if (action == 1)
                _playerDamageToMonster += _player.Damage;
        }
        private void TourMonster()
        {
            int action = _monster.ChooseAction();
            _monster.ExecuteAction(action);
            if (action == 1)
                _monsterDamageToPlayer += _monster.Damage;
        }

        private void RegenererVieJoueur()
        {
            _player.Health += NbDeVieARegenerer;



        }
    }
}
