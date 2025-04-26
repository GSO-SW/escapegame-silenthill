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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(3000);

            string[] titleArt = new string[]
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

            foreach (string line in titleArt)
            {
                Console.WriteLine(line);
                Thread.Sleep(500);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                                                                ");
            Console.WriteLine("                             THANK YOU FOR PLAYING                              ");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                                                                                ");
            Console.WriteLine("                       THE NIGHTMARE IS NOT OVER YET...                         ");
            Thread.Sleep(5000);
            Console.ResetColor();
            Console.Clear();

            Program.Main();
        }
    }
}
