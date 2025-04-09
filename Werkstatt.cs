using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    // Interne Klasse "Werkstatt", enthält die Spiellogik für dieses Level
    internal class Werkstatt
    {
        // Startpunkt des Werkstatt-Levels
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Sie haben die Werkstatt betreten");
            Console.WriteLine("Sie befinden sich im Werkstattraum");

            // Räume werden erstellt mit Name, Nummer, begehbar, Charakter anwesend?, Item vorhanden?
            Raum werkstattraum = new Raum("Werkstattraum", 1, true, true, false);
            Raum buero = new Raum("Büro", 2, true, false, true);
            Raum toilette = new Raum("Toilette", 3, true, false, false);
            Raum lager = new Raum("Lager", 4, false, false, true); // Lager ist am Anfang verschlossen

            // Zugänge von Werkstattraum zu anderen Räumen
            werkstattraum.Zugang.Add(buero);
            werkstattraum.Zugang.Add(toilette);
            werkstattraum.Zugang.Add(lager);

            // Gegenzugänge von Büro, Toilette, Lager zur Werkstatt
            buero.Zugang.Add(werkstattraum);
            toilette.Zugang.Add(werkstattraum);
            lager.Zugang.Add(werkstattraum);

            // Aktueller Raum ist zu Beginn der Werkstattraum
            Raum aktuellerRaum = werkstattraum;
            bool levelBeendet = false;
            bool schluesselGefunden = false;

            // Spielschleife läuft, bis das Level beendet ist
            while (!levelBeendet)
            {
                Console.Clear();
                Console.WriteLine("Du bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌──────────────────────────────┐");

                // Liste verfügbarer Räume ausgeben – Lager wird als „verschlossen“ markiert, wenn kein Schlüssel
                foreach (var raum in aktuellerRaum.Zugang)
                {
                    string raumName = raum == lager && !schluesselGefunden ? $"{raum.Name} (Verschlossen)" : raum.Name;
                    Console.WriteLine($"| {raum.Nr}. {raumName,-25} |");
                }
                Console.WriteLine("└──────────────────────────────┘");

                // Rätsel erscheint im Büro, wenn Schlüssel noch nicht gefunden
                if (aktuellerRaum == buero && !schluesselGefunden)
                {
                    Console.WriteLine("\nRätsel: Entschlüssle 'YPMADIR'");
                    if (LoeseRaetsel("PYRAMID")) // Richtige Lösung: "PYRAMID"
                    {
                        schluesselGefunden = true;
                    }
                }

                // Textausgabe beim Betreten der Toilette
                if (aktuellerRaum == toilette)
                {
                    Console.WriteLine("\nEin verletzter, obdachloser alter Mann flüstert: 'Die Reifen... sie sind im Lager...'");
                }

                // Wenn man im Lager ist und Schlüssel hat → Spiel beenden
                if (aktuellerRaum == lager && schluesselGefunden)
                {
                    Console.Clear();
                    Console.WriteLine("Sie haben das Lager betreten und die Reifen geholt!");
                    Console.WriteLine("(Beliebige Taste drücken)");
                    Console.ReadKey();
                    levelBeendet = true;

                    // Ladeanimation fürs nächste Level
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen..");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    System.Threading.Thread.Sleep(1000);

                    // Starte das nächste Level (Schule)
                    Schule.Spielstart();
                }

                // Raumwechsel-Abfrage
                Console.WriteLine("\nWohin möchtest du gehen? (Nummer eingeben)");
                if (int.TryParse(Console.ReadLine(), out int raumNr))
                {
                    // Wenn Lager ausgewählt wird, aber kein Schlüssel vorhanden → blockieren
                    if (raumNr == 4 && aktuellerRaum == werkstattraum && !schluesselGefunden)
                    {
                        Console.WriteLine("\nDas Lager ist verschlossen! Du benötigst einen Schlüssel.");
                        Console.ReadKey();
                        continue;
                    }

                    // Raumwechsel durchführen
                    Raum neuerRaum = BewegeSpieler(aktuellerRaum, raumNr, lager, schluesselGefunden);
                    if (neuerRaum != null)
                    {
                        aktuellerRaum = neuerRaum;
                    }
                    else
                    {
                        Console.WriteLine("\nUngültige Auswahl! Versuche es erneut.");
                        Console.WriteLine("(Beliebige Taste drücken)");
                        Console.ReadKey();
                    }
                }
            }
        }

        // Methode zur Lösung des Rätsels
        static bool LoeseRaetsel(string loesung)
        {
            while (true)
            {
                Console.WriteLine("\nGib die Lösung ein:");
                if (Console.ReadLine().ToUpper() == loesung)
                {
                    Console.WriteLine("\nRichtig! Schlüssel erhalten.");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nFalsch. Versuche es erneut.");
                }
            }
        }

        // Methode für Raumwechsel
        static Raum BewegeSpieler(Raum aktuellerRaum, int raumNr, Raum lager, bool schluesselGefunden)
        {
            foreach (var raum in aktuellerRaum.Zugang)
            {
                if (raum.Nr == raumNr)
                {
                    // Lager darf nur mit Schlüssel betreten werden
                    if (raum == lager && !schluesselGefunden)
                    {
                        return aktuellerRaum;
                    }
                    return raum;
                }
            }
            return null;
        }

        // Innere Klasse "Raum" definiert Struktur eines Raumes
        class Raum
        {
            public string Name { get; set; }               // Raumname
            public int Nr { get; set; }                    // Raum-Nummer zur Auswahl
            public bool Access { get; set; }               // Ist der Raum betretbar?
            public bool CharAnwesend { get; set; }         // Ist ein Charakter im Raum?
            public bool ItemVorhanden { get; set; }        // Ist ein Item im Raum?
            public List<Raum> Zugang { get; set; }         // Liste erreichbarer Nachbarräume

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