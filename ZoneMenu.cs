using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_1
{
    internal class ZoneMenu
    {
        //Methods
        public static Zone Menu()
        {
            int input = 0;
            int index = 1;
            bool isFormatOK = false;
            string menuString = "";
            menuString += "╔══════════════════════════════════╗\n" +
                          "║              Zones               ║\n" +
                          "║                                  ║\n";
            foreach (Zone zone in Program.zoneList)
            {
                
                menuString += String.Format("║ {0,-2} - {1,-12} Lvl {2,3}-{3,-3}    ║\n", index,zone.Name,zone.MinLvl,zone.MaxLvl);
                index++;
            }              
             menuString +="║                                  ║\n" +
                          "╚══════════════════════════════════╝\n";
            Console.WriteLine(menuString);
            while (!isFormatOK)
            {
                Console.WriteLine("Choisir une destination:");
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2 || input == 3 || input == 4 || input == 5 || input == 6 || input == 7 || input == 8 || input == 9 || input == 10 || input == 11)
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
            return Program.zoneList[input - 1];
        }
    }
}
