using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    class Startmenue
    {
        public void MenueAnzeigen()
        {
            while (true)
            {
                Console.WriteLine("Silent Hill: Escape Room Game");
                Console.WriteLine("(Produziert von Daniel J. Philipp J. Kevin K. und Nico F.)");
                Console.WriteLine("");
                Console.WriteLine("1. Spiel beginnen");
                Console.WriteLine("2. Beenden");
                Console.WriteLine("");

                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Werkstatt.Spielstart();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}