namespace Jeu_1
{
    public class Program
    {   //Variables
        static Player player;
        static Monster monster;
        public static Zone zone;
        public static List<Monster> monsterList;
        public static List<Zone> zoneList;

        //Controller
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
                    monster = Monster.GenerateMonster(Monster.RandomizeMonster(zone.Name),monsterList);
                    duel1 = new Duel(player, monster, vieARegenerer);
                }
            }
        }

        //Main Program
        public static void Main(string[] args)
        {
            CreationPLayer();
            zoneList = Zone.GetZoneData();
            zone = ZoneMenu.Menu();
            monsterList = Monster.GetMonsterData();
            monster = Monster.GenerateMonster(Monster.RandomizeMonster(zone.Name),monsterList);
            InitializeCombat();
            Console.WriteLine("Game Over");
        }
    }
}