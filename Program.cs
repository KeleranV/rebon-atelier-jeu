namespace Jeu_1
{
    public class Program
    {
        static Player player;
        static Monster monster;
        public static string zone;
        public static void CreationPLayer()
        {
            Console.WriteLine("Entrez le nom de votre personnage :");
            string name = Console.ReadLine();
            Console.WriteLine("Dites nous votre genre");
            string genre = Console.ReadLine();
            player = new Player(name, 100, 1, 1, 10, genre);

        }
        public static void InitializeCombat()
        {
            int vieARegenerer = player.MaxHealth / 4;
            Duel duel1 = new Duel(player, monster, vieARegenerer);
            while (player.Health > 0)
            {
                duel1.LancerCombat();
                if (monster.Health == 0)
                {
                    monster = Monster.GenerateMonster(Monster.RandomizeMonster(zone));
                    duel1 = new Duel(player, monster, vieARegenerer);
                }
            }
        }
        public static void Main(string[] args)
        {
            CreationPLayer();
            zone = ZoneMenu.Menu();



            monster = Monster.GenerateMonster(Monster.RandomizeMonster(zone));
            //monster.Attack();

            InitializeCombat();

            Console.WriteLine("Game Over");
        }
    }
}