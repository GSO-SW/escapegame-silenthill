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
        // Einstiegspunkt des Spiels
        public static void Spielstart()
        {
            Console.Clear(); // Bildschirm löschen
            Console.WriteLine("Sie haben die Schule betreten");
            Console.WriteLine("\nSie befinden sich im Flur");
            Console.ReadKey();
        }
    }
} // Spieler muss Taste drücken, um fortzufahren
            /*
            // Räume im Spiel werden erstellt (Name, Raumnummer, Zugänglich?, Charakter vorhanden?, Item vorhanden?)
            Raum flur = new Raum("Flur", 1, true, true, false);
            Raum klassenraumA = new Raum("Klassenraum A", 2, true, false, false);
            Raum klassenraumB = new Raum("Klassenraum B", 3, true, false, false);
            Raum klassenraumC = new Raum("Klassenraum C", 4, true, false, false);
            Raum klassenraumD = new Raum("Klassenraum D", 5, true, false, false);
            Raum musikraum = new Raum("Musikraum", 6, true, false, false);
            Raum umkleide = new Raum("Umkleide", 7, true, false, false);
            Raum chemieraum = new Raum("Chemieraum", 8, true, false, false);

            // Verbindungen zwischen den Räumen herstellen (Zugänge)
            flur.Zugang.Add(klassenraumA);
            flur.Zugang.Add(klassenraumB);
            flur.Zugang.Add(klassenraumC);
            flur.Zugang.Add(klassenraumD);
            flur.Zugang.Add(musikraum);
            flur.Zugang.Add(umkleide);
            flur.Zugang.Add(chemieraum);

            // Jeder Raum führt zurück zum Flur
            klassenraumA.Zugang.Add(flur);
            klassenraumB.Zugang.Add(flur);
            klassenraumC.Zugang.Add(flur);
            klassenraumD.Zugang.Add(flur);
            musikraum.Zugang.Add(flur);
            umkleide.Zugang.Add(flur);
            chemieraum.Zugang.Add(flur);

            Raum aktuellerRaum = flur; // Der Spieler startet im Flur
            bool levelBeendet = false; // Das Spiel ist noch nicht beendet
            
            bool klassenraumBschluesselGefunden = false;
            bool klassenraumCschluesselGefunden = false;
            bool klassenraumDschluesselGefunden = false;
            bool musikraumschluesselGefunden = false;
            bool chemieraumBschluesselGefunden = false;
            
            // Haupt-Spiel-Loop: läuft so lange, bis das Level beendet wird
            while (!levelBeendet)
            {
                Console.Clear(); // Bildschirm leeren
                Console.WriteLine("Du bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌──────────────────────────────┐");

                // Zeige alle Räume an, die vom aktuellen Raum aus erreichbar sind
                foreach (var raum in aktuellerRaum.Zugang)
                    foreach (var raum in aktuellerRaum.Zugang)
                    {
                          string raumName = raum == lager && !schluesselGefunden ? $"{raum.Name} (Verschlossen)" : raum.Name;
                           Console.WriteLine($"| {raum.Nr}. {raumName,-25} |");
                    }

                Console.WriteLine("└──────────────────────────────┘");

                // Spieler gibt die Zahl des nächsten Raumes ein
                Console.WriteLine("\nWohin möchtest du gehen? (Gib die Zahl des Raumes ein)");
                string eingabe = Console.ReadLine();

                // Prüfen, ob Eingabe eine gültige Zahl ist
                if (!int.TryParse(eingabe, out int raumNr))
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte gib eine Zahl ein.");
                    Console.WriteLine("(Beliebige Taste drücken)");
                    Console.ReadKey(); // Warte auf Tastendruck
                    continue; // Zurück zum Anfang der Schleife
                }

                // Versuche, den Spieler in einen neuen Raum zu bewegen
                Raum neuerRaum = BewegeSpieler(aktuellerRaum, raumNr);
                if (neuerRaum == null)
                {
                    Console.WriteLine("Ungültiger Raum! Bitte wähle eine gültige Zahl.");
                    Console.WriteLine("(Beliebige Taste drücken)");
                    Console.ReadKey();
                    continue; // Zurück zur Auswahl
                }

                // Wenn alles passt, bewege den Spieler in den neuen Raum
                aktuellerRaum = neuerRaum;
            }
        }

        // Methode zur Bewegung in einen neuen Raum anhand der Raumnummer
        static Raum BewegeSpieler(Raum aktuellerRaum, int raumNr)
        {
            foreach (var raum in aktuellerRaum.Zugang)
            {
                // Wenn Raumnummer stimmt, gib den Raum zurück
                if (raum.Nr == raumNr)
                {
                    return raum;
                }
            }

            // Wenn kein passender Raum gefunden wurde, gib null zurück
            return null;
        }

        // Die Klasse "Raum" beschreibt einen Raum im Spiel
        class Raum
        {
            public string Name { get; set; }            // Name des Raums (z. B. "Musikraum")
            public int Nr { get; set; }                 // Nummer zur Identifizierung im Spiel
            public bool Access { get; set; }            // Ist der Raum betretbar?
            public bool CharAnwesend { get; set; }      // Ist eine Spielfigur/NPC im Raum?
            public bool ItemVorhanden { get; set; }     // Gibt es ein Item im Raum?
            public List<Raum> Zugang { get; set; }      // Liste der erreichbaren Räume von hier aus

            // Konstruktor: erstellt einen Raum mit seinen Eigenschaften
            public Raum(string name, int nr, bool access, bool charAnwesend, bool itemVorhanden)
            {
                Name = name;
                Nr = nr;
                Access = access;
                CharAnwesend = charAnwesend;
                ItemVorhanden = itemVorhanden;
                Zugang = new List<Raum>(); // Initialisiere leere Liste für Zugänge
            }
        }
    }
}*/