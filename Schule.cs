using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    internal class Schule
    {
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Sie haben die Schule betreten");
            Console.WriteLine("\nSie befinden sich im Flur");
            Console.ReadKey();
        }
            /*
            // Räume definieren (Name, Nr, Betreten, Charakter, Items)
            Raum flur = new Raum("Flur", 1, true, true, false);
            Raum klassenraumA = new Raum("Klassenraum A", 2, true, false, false);
            Raum klassenraumB = new Raum("Klassenraum B", 3, true, false, false);
            Raum klassenraumC = new Raum("Klassenraum C", 4, true, false, false);
            Raum klassenraumD = new Raum("Klassenraum D", 5, true, false, false);
            Raum musikraum = new Raum("Musikraum", 6, true, false, false);
            Raum umkleide = new Raum("Umkleide", 7, true, false, false);
            Raum chemieraum = new Raum("Chemieraum", 8, true, false, false);

            // Zugänge definieren
            flur.Zugang.Add(klassenraumA);
            flur.Zugang.Add(klassenraumB);
            flur.Zugang.Add(klassenraumC);
            flur.Zugang.Add(klassenraumD);
            flur.Zugang.Add(musikraum);
            flur.Zugang.Add(umkleide);
            flur.Zugang.Add(chemieraum);

            klassenraumA.Zugang.Add(flur);

            klassenraumB.Zugang.Add(flur);

            klassenraumC.Zugang.Add(flur);

            klassenraumD.Zugang.Add(flur);

            musikraum.Zugang.Add(flur);

            umkleide.Zugang.Add(flur);

            chemieraum.Zugang.Add(flur);

            // Startwerte
            Raum aktuellerRaum = flur;
            bool levelBeendet = false;
            bool schluesselGefunden = false;

            // Spiel-Loop
            while (!levelBeendet)
            {
                Console.Clear(); // Bildschirm löschen
                Console.WriteLine("\nDu bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌────────────────────┐");
                foreach (var raum in aktuellerRaum.Zugang)
                {
                    Console.WriteLine($"| {raum.Nr}. {raum.Name,-15} |");
                }
                Console.WriteLine("└────────────────────┘");

                if (aktuellerRaum == buero && !schluesselGefunden)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Du hast den Schlüssel für das Lager gefunden!");
                    schluesselGefunden = true;
                }

                if (aktuellerRaum == toilette && !schluesselGefunden)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ein verletzter, obdachloser alter Mann flüstert: 'Die Reifen... sie sind im Lager...'");
                }

                if (aktuellerRaum == lager && !schluesselGefunden)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Das Lager ist verschlossen! Du brauchst einen Schlüssel.");
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
                    levelBeendet = true;
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
        */
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
