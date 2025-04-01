using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    internal class Werkstatt
    {
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Sie haben die Werkstatt betreten");
            Console.WriteLine("Sie befinden sich im Werkstattraum");

            // Räume definieren (Name, Nr, Betreten, Charakter, Items)
            Raum werkstattraum = new Raum("Werkstattraum", 1, true, true, false);
            Raum buero = new Raum("Büro", 2, true, false, true);
            Raum toilette = new Raum("Toilette", 3, true, false, false);
            Raum lager = new Raum("Lager", 4, false, false, true);

            // Zugänge definieren
            werkstattraum.Zugang.Add(buero);
            werkstattraum.Zugang.Add(toilette);
            werkstattraum.Zugang.Add(lager);

            buero.Zugang.Add(werkstattraum);
            toilette.Zugang.Add(werkstattraum);
            lager.Zugang.Add(werkstattraum);

            // Startwerte
            Raum aktuellerRaum = werkstattraum;
            bool levelBeendet = false;
            bool schluesselGefunden = false;

            // Spiel-Loop
            while (!levelBeendet)
            {
                Console.Clear(); // Bildschirm löschen
                Console.WriteLine("Du bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌────────────────────┐");
                foreach (var raum in aktuellerRaum.Zugang)
                {
                    Console.WriteLine($"| {raum.Nr}. {raum.Name,-15} |");
                }
                Console.WriteLine("└────────────────────┘");

                if (aktuellerRaum == buero && !schluesselGefunden)
                {
                    Console.WriteLine("\nDu hast den Schlüssel für das Lager gefunden!");
                    schluesselGefunden = true;
                }

                if (aktuellerRaum == toilette && !schluesselGefunden)
                {
                    Console.WriteLine("\nEin verletzter, obdachloser alter Mann flüstert: 'Die Reifen... sie sind im Lager...'");
                }

                if (aktuellerRaum == lager && !schluesselGefunden)
                {
                    Console.WriteLine("\nDas Lager ist verschlossen! Du brauchst einen Schlüssel.");
                }

                // Spieler bewegt sich
                Console.WriteLine("\nWohin möchtest du gehen? (Gib die Zahl des Raumes ein)");
                string eingabe = Console.ReadLine();
                if (!int.TryParse(eingabe, out int raumNr))
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte gib eine Zahl ein.");
                    continue;
                }

                Raum neuerRaum = BewegeSpieler(aktuellerRaum, raumNr, schluesselGefunden);
                if (neuerRaum == null)
                {
                    Console.WriteLine("Ungültiger Raum! Bitte wähle eine gültige Zahl.");
                    continue;
                }
                aktuellerRaum = neuerRaum;

                // Spiel beenden, wenn das Lager erreicht wurde und der Schlüssel vorhanden ist
                if (aktuellerRaum == lager && schluesselGefunden)
                {
                    Console.Clear();
                    Console.WriteLine("Sie haben das Lager betreten, die Reifen geholt und gehen nun zum Auto.");
                    Console.WriteLine("\n(Beliebige Taste drücken!)");
                    Console.ReadKey();

                    levelBeendet = true;

                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    System.Threading.Thread.Sleep(3000); // 3 Sekunden Wartezeit für den Übergang
                    Schule.Spielstart();
                }
            }
        }

        // Methode zum Bewegen des Spielers
        static Raum BewegeSpieler(Raum aktuellerRaum, int raumNr, bool schluesselGefunden)
        {
            foreach (var raum in aktuellerRaum.Zugang)
            {
                if (raum.Nr == raumNr)
                {
                    if (raum == raum.Zugang.Find(r => r.Nr == 4) && !schluesselGefunden)
                    {
                        Console.WriteLine("Das Lager ist verschlossen! Du benötigst einen Schlüssel.");
                        return aktuellerRaum;
                    }
                    return raum;
                }
            }
            return null;
        }

        // Raum-Klasse
        class Raum
        {
            public string Name { get; set; }
            public int Nr { get; set; }
            public bool Access { get; set; }
            public bool CharAnwesend { get; set; }
            public bool ItemVorhanden { get; set; }
            public List<Raum> Zugang { get; set; }

            public Raum(string name, int nr, bool access, bool charAnwesend, bool itemVorhanden)
            {
                Name = name;
                Nr = nr;
                Access = access;
                CharAnwesend = charAnwesend;
                ItemVorhanden = itemVorhanden;
                Zugang = new List<Raum>();
            }
        }
    }
}