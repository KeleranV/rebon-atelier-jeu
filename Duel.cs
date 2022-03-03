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
            monster.Enemy = player;
            _nbDeVieARegenerer = NbDeVieARegenerer;
        }

        public void AfficherStatistiques()
        {
            /*string nbTours = String.Format("{0,-50}", $"Nombre de tours : {NbTours}");
            string playerDamageToMonster = String.Format("{0,-50}", $"Dommages totaux causés au monstre : {PlayerDamageToMonster}");
            string monsterDamageToPlayer = String.Format("{0,-50}", $"Dommages totaux causés au joueur : {MonsterDamageToPlayer}");
            string regenVie = String.Format("{0,-50}", $"Nombre de vie a regenerer : {NbDeVieARegenerer}");
            string espace = String.Format("{0,-50}", "");
            string smallspace = String.Format("{0,10}", "");

            Console.WriteLine($"{nbTours} Genre: {_player.Genre}\n" +
                $"{playerDamageToMonster} Niveau joueur: {_player.Lvl}\n" +
                $"{monsterDamageToPlayer} Experience: {_player.Exp}\n" +
                $"{regenVie} Armor: {_player.Armor}\n" +
                $"{espace} Strength: {_player.StatStrength}\n" +
                $"{espace} Vitality: {_player.StatVitality}\n" +
                $"{espace} Magic: {_player.StatMagic}       \n");*/

            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", $"Nombre de tours : {NbTours}", $"Nom: { _player.Name}", ""));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", $"Dommages totaux causés au monstre : {PlayerDamageToMonster}", $"Genre: { _player.Genre}", ""));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", $"Dommages totaux causés au joueur : {MonsterDamageToPlayer}", $"Level: { _player.Lvl}", $"Nom: {_monster.Name}"));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", $"Nombre de vie a regenerer : {NbDeVieARegenerer}", $"Exp: { _player.Exp}", $"Level: {_monster.Lvl}"));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", $"Total pièces d'or: ", $"Strength: { _player.StatStrength}", $"Strength: {_monster.StatStrength}"));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", "", $"Vitality: { _player.StatVitality}", $"Vitality: {_monster.StatVitality}"));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", "", $"Damage: { _player.Damage}", $"Damage: {_monster.Damage}"));
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,5}", "", $"Armor: { _player.Armor}", $"Armor: {_monster.Armor}"));
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        


        public void LancerCombat()
        {
            
            while (_player.Health > 0 && _monster.Health > 0)
            {
                _nbTours++;

                Console.Clear();
                Console.WriteLine($"{_player.Name}:{_player.Health}/{_player.MaxHealth}pv");
                Console.WriteLine($"{_monster.Name}: {_monster.Health}/{_monster.MaxHealth}pv");
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
