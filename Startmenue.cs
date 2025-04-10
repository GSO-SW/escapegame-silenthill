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
            Console.Title = "SILENT HILL - ESCAPE ROOM GAME";
            Console.ForegroundColor = ConsoleColor.DarkRed;

            string[] titleArt = new string[]
            {
                @"  ███████ ██ ██      ███████ ███    ██ ████████     ██   ██ ██ ██      ██       ",
                @"  ██      ██ ██      ██      ████   ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ██      █████   ██ ██  ██    ██        ███████ ██ ██      ██       ",
                @"       ██ ██ ██      ██      ██  ██ ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ███████ ███████ ██   ████    ██        ██   ██ ██ ███████ ███████  ",
                @"                                                                                ",
                @"                             WELCOME TO SILENT HILL                             ",
                @"                         A TEXT-BASED HORROR EXPERIENCE                         ",
                @"                                                                                ",
                @"                                  PRODUCED BY:                                  ",
                @"                                  Daniel Jung                                   ",
                @"                                Philipp Jedamzik                                ",
                @"                                  Kevin Köster                                  ",
                @"                                   Nico Feil                                    ",
            };

            foreach (string line in titleArt)
            {
                Console.WriteLine(line);
                Thread.Sleep(120); // Grusel-Effekt
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n                                                                                ");
            Console.WriteLine("     (Produziert von Daniel J. Philipp J. Kevin K. und Nico F.)");
            Console.WriteLine("\n             Drücke eine Taste, um fortzufahren...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("  ███████ ██ ██      ███████ ███    ██ ████████     ██   ██ ██ ██      ██       ");
                Console.WriteLine("  ██      ██ ██      ██      ████   ██    ██        ██   ██ ██ ██      ██       ");
                Console.WriteLine("  ███████ ██ ██      █████   ██ ██  ██    ██        ███████ ██ ██      ██       ");
                Console.WriteLine("       ██ ██ ██      ██      ██  ██ ██    ██        ██   ██ ██ ██      ██       ");
                Console.WriteLine("  ███████ ██ ███████ ███████ ██   ████    ██        ██   ██ ██ ███████ ███████  ");
                Console.WriteLine("\nE  S  C  A  P  E                     R  O  O  M                       G  A  M  E");
                Console.WriteLine();
                Console.WriteLine("1. Spiel beginnen");
                Console.WriteLine("2. Beenden");
                Console.WriteLine();

                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Werkstatt.Spielstart(); // <-- Achtung: Methode muss existieren!
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}