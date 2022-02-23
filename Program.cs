namespace Jeu_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "World of Console";

            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Console.WriteLine("Dites nous votre genre");
            string genre = Console.ReadLine();
            Player player = new Player(name, 100, 10, genre);
            
            
            
            Monster monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
            //monster.Attack();
            
            int vieARegenerer = player.MaxHealth / 4;
            Duel duel1 = new Duel(player, monster, vieARegenerer);
            
            while (player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                {
                    monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
                    duel1 = new Duel(player, monster, vieARegenerer);
                }
            }
            Console.WriteLine("Game Over");
        }
    }
}