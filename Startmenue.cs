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
            Raum Werkstattraum = new Raum();
            Werkstattraum.Name = "Werkstattraum";
            Werkstattraum.Nr = 1;
            Werkstattraum.Access = true;
            Werkstattraum.CharAnwesend = true;
            Werkstattraum.ItemVorhanden = false;
            Werkstattraum.Zugang[0] = 2;
            Werkstattraum.Zugang[1] = 3;
            Werkstattraum.Zugang[2] = 4;

            Raum Buero = new Raum();
            Buero.Name = "Buero";
            Buero.Nr = 2;
            Buero.Access = true;
            Buero.CharAnwesend = false;
            Buero.ItemVorhanden = true;
            Buero.Gegenstaende[0] = "Schluessel";
            Buero.Zugang[0] = 1;

            Raum Toilette = new Raum();
            Toilette.Name = "Toilette";
            Toilette.Nr = 3;
            Toilette.Access = true;
            Toilette.CharAnwesend = false;
            Toilette.ItemVorhanden = false;
            Toilette.Zugang[0] = 1;

            Raum Lager = new Raum();
            Lager.Name = "Lager";
            Lager.Nr = 4;
            Lager.Access = false;
            Lager.CharAnwesend = false;
            Lager.ItemVorhanden = true;
            Lager.Gegenstaende[0] = "Reifen";
            Lager.Zugang[0] = 1;

            while (true)
            {
                Console.WriteLine("");
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
                        Spiel.Spielstart();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        break;
                }
            }
        }
    }
}