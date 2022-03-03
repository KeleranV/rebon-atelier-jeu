using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_1
{
    internal class ZoneMenu
    {
        public static string Menu()
        {
            string input;
            string choix = "";
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════╗\n" +
                              "║              Zones               ║\n" +
                              "║                                  ║\n" +
                              "║     1 - Plains      Lvl 1-10     ║\n" +
                              "║     2 - Forest      Lvl 10-20    ║\n" +
                              "║     3 - Beach       Lvl 20-30    ║\n" +
                              "║     4 - Swamp       Lvl 30-40    ║\n" +
                              "║     5 - Dark Forest Lvl 40-50    ║\n" +
                              "║     6 - Aband. Town Lvl 50-60    ║\n" +
                              "║     7 - Crypt       Lvl 60-70    ║\n" +
                              "║     8 - Grotto      Lvl 70-80    ║\n" +
                              "║     9 - Mountains   Lvl 80-90    ║\n" +
                              "║    10 - Volcano     Lvl 90-100   ║\n" +
                              "║    11 - Hell        Lvl 100+     ║\n" +
                              "║                                  ║\n" +
                              "╚══════════════════════════════════╝\n");
            do
                input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9" && input != "10" && input != "11");
            switch (input)
            {
                case "1": choix = "Plains";break;
                case "2": choix = "Forest"; break;
                case "3": choix = "Beach"; break;
                case "4": choix = "Swamp"; break;
                case "5": choix = "Dark_Forest"; break;
                case "6": choix = "Aband_Town"; break;
                case "7": choix = "Crypt"; break;
                case "8": choix = "Grotto"; break;
                case "9": choix = "Mountains"; break;
                case "10": choix = "Volcano"; break;
                case "11": choix = "Hell"; break;
            }
            Console.Clear();
            return choix;
        }

        
    }
}
