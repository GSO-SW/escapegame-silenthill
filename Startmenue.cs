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

            Console.Title = "SILENT HILL - ESCAPE ROOM GAME"; // Konsole Titel vergebung

            Console.ForegroundColor = ConsoleColor.DarkRed; // Setzt die Schriftfarbe auf Dunkelrot

            Thread.Sleep(3000); // 3 Sekunden Timer

            string[] TitelbildMenue = new string[] // Definiert das ASCII-Art für die Startmenü Titelseite
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

            foreach (string line in TitelbildMenue)
            {
                Console.WriteLine(line); // Gibt die ASCII-Art Zeile für Zeile aus
                Thread.Sleep(120);
            }

            Console.ForegroundColor = ConsoleColor.White; // Setzt die Schriftfarbe auf Weiß

            Console.WriteLine("\n\n                      Drücke eine Taste, um fortzufahren...                     \n\n");

            Console.ResetColor(); // Schriftfarbe wird zurückgesetzt

            Console.ReadKey(); // Wartet auf eine Benutzereingabe, bevor das Programm weitergeht

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
                        Werkstatt.Spielstart();
                        break;
                    case "2":
                        Credits.CreditsAnzeigen();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}