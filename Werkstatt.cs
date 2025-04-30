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

        public static bool ZurueckZumStartmenue { get; private set; } = false;
        // Startpunkt des Werkstatt-Levels
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Die Reifen deines Wagens sind hin.");
            Thread.Sleep(3000);
            Console.WriteLine("\nMit letzter Kraft hast du es zu einer verlassenen Werkstatt geschafft.");
            Thread.Sleep(3000);
            Console.WriteLine("\nRost nagt am Metall.");
            Thread.Sleep(3000);
            Console.WriteLine("\nStille liegt in der Luft.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDoch der Nebel draußen wird dichter und bedrohlicher.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDu musst Ersatzreifen finden und zwar schnell.");
            Thread.Sleep(3000);

            Console.Clear();
            Console.WriteLine("Du stehst inmitten der Werkstatt.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDer Geruch von altem Öl und Gummi steigt dir in die Nase.");
            Thread.Sleep(3000);
            Console.WriteLine("\nWerkzeuge liegen verstreut.");
            Thread.Sleep(3000);
            Console.WriteLine("\nScheinbar wahllos.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDu suchst den Raum ab.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDoch Reifen sind nirgends zu sehen.");
            Thread.Sleep(3000);
            Console.Clear();

            // Räume werden erstellt mit Name, Nummer, begehbar, Charakter anwesend?, Item vorhanden?
            Raum werkstattraum = new Raum("Werkstattraum", 1, true, true, false);
            Raum toilette = new Raum("Toilette", 2, true, false, false);
            Raum buero = new Raum("Büro", 3, true, false, true);
            Raum lager = new Raum("Lager", 4, false, false, true); // Lager ist am Anfang verschlossen

            // Zugänge von Werkstattraum zu anderen Räumen
            werkstattraum.Zugang.Add(toilette);
            werkstattraum.Zugang.Add(buero);
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
                Console.WriteLine("┌─────────────────────────────────┐");

                // Liste verfügbarer Räume ausgeben (Lager wird als „verschlossen“ markiert, wenn kein Schlüssel)
                foreach (var raum in aktuellerRaum.Zugang)
                {
                    string raumName = raum == lager && !schluesselGefunden ? $"{raum.Name} (Verschlossen)" : raum.Name;
                    Console.WriteLine($"| {raum.Nr}. {raumName,-28} |");
                }
                Console.WriteLine("└─────────────────────────────────┘");

                // Rätsel erscheint im Büro, wenn Schlüssel noch nicht gefunden
                if (aktuellerRaum == buero && !schluesselGefunden)
                {
                    if (LoeseRaetsel("PYRAMID")) // Richtige Lösung: "PYRAMID"
                    {
                        schluesselGefunden = true;
                        Console.Clear();
                        continue;
                    }
                }

                static bool LoeseRaetsel(string loesung)
                {
                    while (true)
                    {
                        Console.WriteLine("\nStaub liegt wie ein Leichentuch über den Möbeln.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nIn einem der Regale entdeckst du ein Notizbuch.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEine einzelne Seite ist beschrieben: „YPMADIR“.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDarunter steht: „Die Antwort liegt in der Form der Macht.“");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n\nGib die Lösung ein:");
                        string eingabe = Console.ReadLine().ToUpper();

                        if (eingabe == loesung)
                        {
                            Console.Clear();
                            Console.WriteLine("Der Schlüssel den du gefunden hast glänzt matt in deiner Hand.");
                            Thread.Sleep(3000);
                            Console.WriteLine("\nDie Lösung des Anagramms „YPMADIR“ hat den Mechanismus ausgelöst.");
                            Thread.Sleep(3000);
                            Console.WriteLine("\nEr muss zum Lager passen.");
                            Thread.Sleep(3000);     
                            Console.Clear();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("\nFalsch. Versuche es erneut...");
                            Thread.Sleep(1500);
                            return false;
                        }
                    }
                }


                // Textausgabe beim Betreten der Toilette
                if (aktuellerRaum == toilette)
                {
                    Console.WriteLine("\n\nDie Wände sind über und über mit seltsamen Malereien bedeckt.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nÜberall scheinen stilisierte Pyramiden in verschiedenen Größen und Formen aufgemalt zu sein.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEin verletzter obdachloser alter Mann kauert in einer Ecke und flüstert mit heiserer Stimme.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Die Reifen... sie sind... im Lager...“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDie Pyramidenmuster scheinen sich in dein Gedächtnis einzuprägen.");
                    Thread.Sleep(3000);
                }

                // Wenn man im Lager ist und Schlüssel hat
                if (aktuellerRaum == lager && schluesselGefunden)
                {
                    Console.Clear();
                    Console.WriteLine("Das Tor quietscht widerwillig als du den Schlüssel ins Schloss steckst und es aufschließt.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nZwischen hohen verstaubten Regalen entdeckst du endlich die gesuchten Reifen.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nErleichterung macht sich in dir breit.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu packst sie.");
                    Thread.Sleep(3000);

                    Console.Clear();
                    Console.WriteLine("Die neuen Reifen sind montiert.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu steigst ins Auto.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDoch gerade als du den Motor starten willst schlägt etwas Hartes gegen die Windschutzscheibe.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu zuckst zusammen und fährst mit der Hand über die Scheibe.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDraußen ist niemand.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nNur eine einzelne blutige Handspur zieht sich über das Glas.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu startest den Motor.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEin ungutes Gefühl beschleicht dich.");
                    Thread.Sleep(3000);

                    levelBeendet = true;

                    Console.Clear();
                    Console.WriteLine("Die Fahrt durch den dichten grauen Schleier ist beunruhigend still.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nPlötzlich verstummt das Radio.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nNur ein unheilvolles Rauschen ist zu hören.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDann wie aus dem Nichts eine verzerrte Stimme.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Sie... sie war zuletzt... in der alten Schule...“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDeine Schwester.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nSeit Tagen schon ist sie verschwunden.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEine vage Hoffnung keimt auf.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Vielleicht... vielleicht ist sie wirklich dort?“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu lenkst den Wagen in die Richtung die die Stimme angedeutet hat.");
                    Thread.Sleep(3000);

                    // Ladeanimation fürs nächste Level
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    Thread.Sleep(1500);

                    // Starte das nächste Level (Schule)
                    Schule.Spielstart();
                }

                // Raumwechsel-Abfrage
                Console.WriteLine("\n\nWohin möchtest du gehen? (Nummer eingeben) oder „exit“ zum Startmenü:");
                string eingabe = Console.ReadLine();

                if (eingabe.ToLower() == "exit") // Prüfe auf "exit" (Groß-/Kleinschreibung egal)
                {
                    Console.Clear();
                    ZurueckZumStartmenue = true;
                    Startmenue startmenue = new Startmenue();
                    startmenue.MenueAnzeigen(); // Rufe MenueAnzeigen() hier auf, bevor die Methode verlässt
                    return; // Beendet die Methode hier, damit die Schleife nicht weiterläuft
                }
                if (int.TryParse(eingabe, out int raumNr))
                {
                    // Wenn Lager ausgewählt wird, aber kein Schlüssel vorhanden ist
                    if (raumNr == 4 && aktuellerRaum == werkstattraum && !schluesselGefunden)
                    {
                        Console.Clear();
                        Console.WriteLine("Die schwere Tür zum Lager ist verschlossen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin massives Schlossriegel schiebt sich vor.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu rüttelst daran.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nAber es bewegt sich nicht.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nIch brauche wohl einen Schlüssel dafür.");
                        Thread.Sleep(3000);
                        Console.Clear();
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
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
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

            // get = Damit kann man den aktuellen Wert abfragen (lesen)

            // set = Damit kann man einen neuen Wert zuweisen (schreiben)

            public string Name { get; set; } // Raumname
            public int Nr { get; set; } // Raum-Nummer zur Auswahl
            public bool Access { get; set; } // Ist der Raum betretbar?
            public bool CharAnwesend { get; set; } // Ist ein Charakter im Raum?
            public bool ItemVorhanden { get; set; } // Ist ein Item im Raum?
            public List<Raum> Zugang { get; set; } // Liste erreichbarer Nachbarräume

            // Erstellt einen neuen Raum mit den angegebenen Werten
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