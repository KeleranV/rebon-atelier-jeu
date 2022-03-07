using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_1
{
    internal class Town
    {
        public static void Menu()
        {
            bool isFormatOK = false;
            int input = 0;
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗\n" +
                              "║         Town           ║\n" +
                              "║                        ║\n" +
                              "║    1 - Forgeron        ║\n" +
                              "║    2 - Alchimiste      ║\n" +
                              "║    3 - Auberge         ║\n" +
                              "║    4 - Aventure        ║\n" +
                              "║                        ║\n" +
                              "╚════════════════════════╝\n");
            while (!isFormatOK)
            {
                Console.WriteLine("Choisir une destination:");
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2 || input == 3 || input == 4)
                        isFormatOK = true;
                    else
                        Console.WriteLine("Saisie incorrecte.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Saisie incorrecte.");
                }
            }
            Console.Clear();
            switch (input)
            {
                case 1:
                    Program.zone = ZoneMenu.Menu();
                    
                    break;
                case 2:
                    Program.zone = ZoneMenu.Menu();
                    break;
                case 3:
                    Program.zone = ZoneMenu.Menu();
                    break;
                case 4:
                    Program.zone = ZoneMenu.Menu();
                    Program.monsterList = Monster.GetMonsterData();
                    //
                    //Program.InitializeCombat();
                    break;
            }
        }
    }
}
