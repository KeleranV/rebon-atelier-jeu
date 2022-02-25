namespace Jeu_1
{
    public class Program
    {

        private static Player CreationPersonnage()
        {
            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Console.WriteLine("Dites nous votre genre");
            string genre = Console.ReadLine();

            return new Player(name, 100, 10, genre);
        }

        private static void GestionCombats(Player player, Monster firstMonster, int vieARegenerer)
        {
            Duel duel1 = new Duel(player, firstMonster, vieARegenerer);
            Monster monster = firstMonster;
            while (player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                {
                    monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
                    duel1 = new Duel(player, monster, vieARegenerer);
                }
            }
        }

        public static void Main(string[] args)
        {

            Player player = CreationPersonnage();

            Monster monster = Monster.GenerateMonster(
                Monster.RandomizeMonsterName(),
                Monster.RandomizeMonsterMaxHealth(),
                Monster.RandomizeMonsterDamage(),
                player,
                Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage())
                );

            int vieARegenerer = player.MaxHealth / 4;


            GestionCombats(player, monster, vieARegenerer);


            Console.WriteLine("Game Over");
        }
    }
}