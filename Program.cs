namespace Jeu_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Console.WriteLine("Dites nous votre genre");
            string genre = Console.ReadLine();
            Player player = new Player(name, 100, 10, genre);

           

            Monster monster = new Monster("blob", 100, 5, player, 20);
            //monster.Attack();


            Duel duel1 = new Duel(player, monster, 20);
            
            while(player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                { 
                    monster = new Monster("blob2", 100, 5, player, 40);
                    duel1 = new Duel(player, monster, 50);
                }
            }
            Console.WriteLine("Game Over");
        }
    }
}