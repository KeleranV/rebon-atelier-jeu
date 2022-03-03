namespace Jeu_1
{
    public class Program
    {
<<<<<<< HEAD


        private static Player CreationPersonnage()
=======
        public static void Main(string[] args)
>>>>>>> parent of 0234e64 (Systeme de generation de monstre V2)
        {
            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Console.WriteLine("Dites nous votre genre");
            string genre = Console.ReadLine();
<<<<<<< HEAD


            return new Player(name, 100, 10, genre);
        }

        private static void GestionCombats(Player player, Monster firstMonster, int vieARegenerer)
        {
            Duel duel1 = new Duel(player, firstMonster, vieARegenerer);
            Monster monster = firstMonster;
=======
            Player player = new Player(name, 100, 10, genre);

           

            Monster monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
            //monster.Attack();

            int vieARegenerer = player.MaxHealth / 4;
            Duel duel1 = new Duel(player, monster, vieARegenerer);
>>>>>>> parent of 0234e64 (Systeme de generation de monstre V2)

            while (player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                {
                    monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
                    duel1 = new Duel(player, monster, vieARegenerer);
                }
            }
<<<<<<< HEAD
        }

        public static void Main(string[] args)
        {
            CreationPLayer();



            monster = Monster.GenerateMonster(Monster.RandomizeMonster("Plains"));
            //monster.Attack();

            InitializeCombat();
          

=======
>>>>>>> parent of 0234e64 (Systeme de generation de monstre V2)
            Console.WriteLine("Game Over");
        }
    }
}