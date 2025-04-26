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
            Console.Clear();
            Console.Title = "SILENT HILL - ESCAPE ROOM GAME";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(3000);

            string[] TitelBild = new string[]
            {
                @"  ███████ ██ ██      ███████ ███    ██ ████████     ██   ██ ██ ██      ██       ",
                @"  ██      ██ ██      ██      ████   ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ██      █████   ██ ██  ██    ██        ███████ ██ ██      ██       ",
                @"       ██ ██ ██      ██      ██  ██ ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ███████ ███████ ██   ████    ██        ██   ██ ██ ███████ ███████  ",
                @"                                                                                ",
                @"E  S  C  A  P  E                  R  O  O  M                          G  A  M  E",
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

            foreach (string line in TitelBild)
            {
                Console.WriteLine(line);
                Thread.Sleep(120); // Grusel-Effekt
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n                                                                                ");
            Console.WriteLine("                      Drücke eine Taste, um fortzufahren...                     ");
            Console.WriteLine("\n                                                                                ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("  ███████ ██ ██      ███████ ███    ██ ████████     ██   ██ ██ ██      ██       ");
                Thread.Sleep(120);
                Console.WriteLine("  ██      ██ ██      ██      ████   ██    ██        ██   ██ ██ ██      ██       ");
                Thread.Sleep(120);
                Console.WriteLine("  ███████ ██ ██      █████   ██ ██  ██    ██        ███████ ██ ██      ██       ");
                Thread.Sleep(120);
                Console.WriteLine("       ██ ██ ██      ██      ██  ██ ██    ██        ██   ██ ██ ██      ██       ");
                Thread.Sleep(120);
                Console.WriteLine("  ███████ ██ ███████ ███████ ██   ████    ██        ██   ██ ██ ███████ ███████  ");
                Thread.Sleep(120);
                Console.WriteLine("\nE  S  C  A  P  E                  R  O  O  M                          G  A  M  E");
                Thread.Sleep(120);
                Console.WriteLine("\n\n\n\n1. SPIEL BEGINNEN");
                Thread.Sleep(120);
                Console.WriteLine("\n2. CREDITS");
                Thread.Sleep(120);
                Console.WriteLine("\n3. BEENDEN\n");

                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Werkstatt.Spielstart(); // <-- Achtung: Methode muss existieren!
                        break;
                    case "2":
                        Credits.CreditsAnzeigen();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}