namespace Jeu_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10);
            //player.Attack();

            Console.WriteLine(player.Name);
            Console.WriteLine(player.MaxHealth);
            Console.WriteLine(player.Damage);

            Monster monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
            //monster.Attack();


            Duel duel1 = new Duel(player, monster);

            while (player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                {
                    monster = Monster.GenerateMonster(Monster.RandomizeMonsterName(), Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage(), player, Monster.MonsterRewardCalculation(Monster.RandomizeMonsterMaxHealth(), Monster.RandomizeMonsterDamage()));
                    duel1 = new Duel(player, monster);
                }
            }
            Console.WriteLine("Game Over");

        }
    }
}