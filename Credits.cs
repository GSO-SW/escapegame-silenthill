using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    class Credits
    {
        public static void CreditsAnzeigen()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed; // Setzt die Schriftfarbe auf Dunkelrot

            Thread.Sleep(3000); // Wartet 3 Sekunden, bevor die Credits angezeigt werden

            string[] TitelbildCredits = new string[] // Definiert das ASCII-Art für die Credits Titelseite
            {
                @"  ███████ ██ ██      ███████ ███    ██ ████████     ██   ██ ██ ██      ██       ",
                @"  ██      ██ ██      ██      ████   ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ██      █████   ██ ██  ██    ██        ███████ ██ ██      ██       ",
                @"       ██ ██ ██      ██      ██  ██ ██    ██        ██   ██ ██ ██      ██       ",
                @"  ███████ ██ ███████ ███████ ██   ████    ██        ██   ██ ██ ███████ ███████  ",
                @"                                                                                ",
                @"E  S  C  A  P  E                  R  O  O  M                          G  A  M  E",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                               GAME DEVELOPMENT                                 ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                LEAD DEVELOPER:                                 ",
                @"                                  Daniel Jung                                   ",
                @"                                                                                ",
                @"                                CONCEPT & IDEA:                                 ",
                @"                                  Daniel Jung                                   ",
                @"                                Philipp Jedamzik                                ",
                @"                                  Kevin Köster                                  ",
                @"                                   Nico Feil                                    ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                  LEVEL DESIGN                                  ",
                @"                                                                                ",
                @"                                                                                ",
                @"                        ROOM LAYOUT & PUZZLE CREATION:                          ",
                @"                                  Daniel Jung                                   ",
                @"                                Philipp Jedamzik                                ",
                @"                                  Kevin Köster                                  ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                  PROGRAMMING                                   ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                GAME MECHANICS:                                 ",
                @"                                  Daniel Jung                                   ",
                @"                                Philipp Jedamzik                                ",
                @"                                                                                ",
                @"                             DEBUGGING & TESTING:                               ",
                @"                                  Daniel Jung                                   ",
                @"                                Philipp Jedamzik                                ",
                @"                                  Kevin Köster                                  ",
                @"                                   Nico Feil                                    ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                USED RESOURCES                                  ",
                @"                                                                                ",
                @"                                DEVELOPED WITH:                                 ",
                @"                         C# – .NET CONSOLE APPLICATION                          ",
                @"                                                                                ",
                @"                                    TOOLS:                                      ",
                @"                              VISUAL STUDIO 2022                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                   COPYRIGHT                                    ",
                @"                                                                                ",
                @"                                                                                ",
                @"                        © 2025 DPKN INTERACTIVE STUDIOS                         ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
                @"                                                                                ",
            };

            foreach (string line in TitelbildCredits) // Gibt die ASCII-Art Zeile für Zeile aus
            {
                Console.WriteLine(line); // Gibt jede Zeile der ASCII-Art aus
                Thread.Sleep(400);
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White; // Setzt die Schriftfarbe auf Weiß

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n                             THANK YOU FOR PLAYING                              ");

            Thread.Sleep(3000);

            Console.ForegroundColor = ConsoleColor.DarkRed; // Setzt die Schriftfarbe auf Dunkelrot

            Console.WriteLine("\n                       THE NIGHTMARE IS NOT OVER YET...                         ");

            Thread.Sleep(5000);

            Console.ResetColor(); // Schriftfarbe wird zurückgesetzt

            Console.Clear();

            Program.Main(); //Startet das Spiel wieder von Anfang an
        }
    }
}
