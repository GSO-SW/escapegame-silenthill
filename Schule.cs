using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExitGame
{
    public class Schule
    {

        public static bool ZurueckZumStartmenue { get; private set; } = false;
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Eine gespenstische Stille umgibt dich.");
            Thread.Sleep(3000);
            Console.WriteLine("\nAlles wirkt wie in der Zeit erstarrt.");
            Thread.Sleep(3000);
            Console.WriteLine("\nVerlassene Gänge.");
            Thread.Sleep(3000);
            Console.WriteLine("\nFlackernde Lichter tanzen an den Wänden.");
            Thread.Sleep(3000);
            Console.WriteLine("\nEine kalte Atmosphäre kriecht unter deine Haut.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDu suchst nach Hinweisen in dieser scheinbar eingefrorenen Szenerie.");
            Thread.Sleep(3000);

            Console.Clear();
            Console.WriteLine("Die schwere Eingangstür fällt mit einem dumpfen Knall hinter dir ins Schloss.");
            Thread.Sleep(3000);
            Console.WriteLine("\nEin Klicken verrät.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDu bist eingeschlossen.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDein Handy zeigt keinen Empfang.");
            Thread.Sleep(3000);
            Console.WriteLine("\nDu rüttelst an der Tür.");
            Thread.Sleep(3000);
            Console.WriteLine("\nAber sie ist fest verschlossen.");
            Thread.Sleep(3000);
            Console.WriteLine("\nEs gibt keinen Weg zurück.");
            Thread.Sleep(3000);
            Console.WriteLine("\nNur du und dieser unheimliche endlose Flur.");
            Thread.Sleep(3000);

            // Räume werden erstellt mit Name, Nummer, begehbar, Charakter anwesend?, Item vorhanden?
            Raum flur = new Raum("Flur", 1, true, true, false);
            Raum klassenraumA = new Raum("Klassenraum A", 2, true, false, true);
            Raum klassenraumB = new Raum("Klassenraum B", 3, false, false, false);
            Raum musikraum = new Raum("Musikraum", 4, false, false, false);
            Raum chemieraum = new Raum("Chemieraum", 5, false, false, false);
            Raum klassenraumC = new Raum("Klassenraum C", 6, true, false, false);
            Raum klassenraumD = new Raum("Klassenraum D", 7, true, false, false);
            Raum umkleide = new Raum("Umkleide", 8, true, false, true);
            Raum notausgang = new Raum("Notausgang", 9, false, false, false);

            // Verbindungen
            flur.Zugang.Add(klassenraumA);
            flur.Zugang.Add(klassenraumB);
            flur.Zugang.Add(klassenraumC);
            flur.Zugang.Add(klassenraumD);
            flur.Zugang.Add(musikraum);
            flur.Zugang.Add(chemieraum);
            flur.Zugang.Add(umkleide);

            klassenraumA.Zugang.Add(flur);
            klassenraumB.Zugang.Add(flur);
            klassenraumC.Zugang.Add(flur);
            klassenraumD.Zugang.Add(flur);

            musikraum.Zugang.Add(flur);

            chemieraum.Zugang.Add(flur);

            umkleide.Zugang.Add(flur);

            chemieraum.Zugang.Add(notausgang);

            bool levelBeendet = false;
            bool schliessfachGeloest = false;
            bool musikGeloest = false;
            bool chemieGeloest = false;
            bool tagebuchGeloest = false;

            string notausgangsCode = "73920518";

            Raum aktuellerRaum = flur;

            while (!levelBeendet)
            {
                Console.Clear();
                Console.WriteLine($"Du bist im {aktuellerRaum.Name}.");

                if (aktuellerRaum == klassenraumA && !schliessfachGeloest)
                {
                    Console.Clear();
                    Console.WriteLine("Ein Schließfach steht halb offen.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDoch das Schloss scheint blockiert.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu versuchst es zu öffnen, aber es hakt.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEin kleiner zerknitterter Zettel steckt zwischen Tür und Rahmen:");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Der Code ist das, was du nie vergisst – 4 Zahlen, eine Erinnerung“.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu grübelst über mögliche Erinnerungen nach.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n\nCode Eingeben:");
                    string schliessfacheingabe = Console.ReadLine();
                    if (schliessfacheingabe == "4815")
                    {
                        Console.WriteLine("\nDas Schließfach klickt leise und springt auf.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nIm Inneren liegt ein alter, rostige Schlüssel.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEr scheint zu einem anderen Raum zu passen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEine Erleichterung durchfährt dich.");
                        Thread.Sleep(3000);

                        klassenraumB.Begehbar = true;
                        schliessfachGeloest = true;
                        
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\nEin leises Klicken ist zu hören, aber das Schloss bleibt verriegelt.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Falscher Code.“");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu versuchst es erneut, die Zahlen im Kopf neu zu ordnen.");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                else if (aktuellerRaum == klassenraumB && !tagebuchGeloest)
                {
                    Console.WriteLine("\nInmitten umgestürzter Schulbänke liegt ein aufgeschlagenes Tagebuch.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu hebst es auf und liest.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEine Seite ist besonders auffällig.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Rot + Blau = ?“ Vielleicht im Chemieraum nachsehen?");
                    Thread.Sleep(3000);

                    tagebuchGeloest = true;
                    
                    Console.Clear();
                }
                else if (aktuellerRaum == musikraum && !chemieGeloest)
                {
                    Console.WriteLine("\nEin altes Tonbandgerät steht auf einem Klavier.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu drückst auf Play.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEs spielt eine kurze einfache Melodie in einer Endlosschleife.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu versuchst die Melodie zu summen und dir einzuprägen.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n\nSumme die Töne: (mit Bindestrich)");
                    string lied = Console.ReadLine();
                    if (lied.ToUpper() == "C-E-G-E") // Prüfe auf "C E G E" (Großschreibung)
                    {
                        Console.WriteLine("\nAls du die Melodie C-E-G-E summst.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nScheint ein leises Klicken aus dem Inneren des Klaviers zu kommen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu untersuchst es genauer und entdeckst einen kleinen, unscheinbaren Schlüssel.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEr könnte zum Chemieraum passen, denkst du.");
                        Thread.Sleep(3000);

                        chemieraum.Begehbar = true;
                        chemieGeloest = true;
                        
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\nDie Töne, die du von dir gibst, klingen schief und disharmonisch.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nNichts scheint zu reagieren.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nVersuche es noch einmal.");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                else if (aktuellerRaum == chemieraum && tagebuchGeloest && !notausgang.Begehbar)
                {
                    Console.WriteLine("\nVor dir die rote und blaue Flüssigkeit.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nTagebuch und Notiz deuten auf eine Mischung.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Was ergibt Rot und Blau?“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nFarbe Eingeben:");
                    string antwort = Console.ReadLine();
                    if (antwort.ToLower() == "lila") // Prüfe auf "lila" (Groß-/Kleinschreibung egal)
                    {
                        Console.Clear();
                        Console.WriteLine("Die lilane Flüssigkeit im Reagenzglas leuchtet nun schwach.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu entdeckst einen kleinen Zettel, der am Boden des Glases klebt.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nVorsichtig schüttelst du ihn heraus.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDarauf steht eine Zahlenfolge: „7 3 9 2 0 5 1 8.“");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDie Mischung der Farben hat die „Wahrheit“ enthüllt den Code für den Notausgang.");
                        Thread.Sleep(3000);

                        notausgang.Begehbar = true;
                        
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\nDu mischst die Flüssigkeiten.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nNichts scheint zu passieren.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDie Farbe bleibt unverändert.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Das war wohl nicht die Wahrheit.“");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                else if (aktuellerRaum == klassenraumC)
                {
                    Console.WriteLine("\nDu stöberst durch die verlassenen Schulbücher.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nIn einem alten, ledergebundenen Exemplar findest du eine eingeklebte Notiz.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDarauf steht in klarer Schrift: „Der Code ist 4815.“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n„Das könnte nützlich sein.“");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else if (aktuellerRaum == umkleide && !musikGeloest)
                {
                    Console.Clear();
                    Console.WriteLine("Zwischen alten Sportklamotten entdeckst du ein vergilbtes Notenblatt.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDarauf sind die Noten „C-E-G-E“ notiert.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDarunter steht in blasser Schrift: „Die Melodie öffnet den Weg zur Harmonie.“");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDu prägst dir die Notenfolge ein.");
                    Thread.Sleep(3000);

                    musikraum.Begehbar = true;
                    musikGeloest = true;

                    Console.Clear();
                }
                else if (aktuellerRaum == notausgang)
                {
                    Console.Clear();
                    Console.WriteLine("Vor dem digitalen Zahlenschloss des Notausgangs stehst du.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nAcht Ziffern sind gefordert.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDie lilane Flüssigkeit und der Zettel im Chemieraum haben dir geholfen.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDie „Mischung der Wahrheit“ ergab die Zahlenfolge:");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nSieben steht für die sieben Todsünden.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nDrei für die Dreifaltigkeit.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nNeun für die neun Kreise der Hölle.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nZwei für Gut und Böse");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nNull für die Leere");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nFünf für die fünf Sinne");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEins für den Anfang.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nAcht für die Unendlichkeit.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nEine makabre Kombination, aber sie ergibt Sinn in dieser alptraumhaften Schule.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n\nGib den Code ein:");
                    string code = Console.ReadLine();
                    if (code == notausgangsCode)
                    {
                        Console.Clear();
                        Console.WriteLine("Draußen ist es still.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDer Nebel scheint sich etwas gelichtet zu haben.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu atmest tief durch.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu denkst, die unheimliche Atmosphäre der Schule hinter dir gelassen zu haben.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDoch dann entdeckst du etwas am Boden ein kleines Stück Stoff.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu hebst es auf und es kommt dir bekannt vor.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nGenauer betrachtet erkennst du einen eingenähten Patch: „Brookhaven Hospital“.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin kalter Schauer läuft dir über den Rücken.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Sie lebt“, flüsterst du ungläubig und ballst die Faust.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDein nächstes Ziel steht fest.");
                        Thread.Sleep(3000);

                        levelBeendet = true;

                        Credits.CreditsAnzeigen();
                    }
                    else
                    {
                        Console.WriteLine("Das digitale Schloss blinkt rot und gibt einen kurzen, schrillen Piepton von sich.");
                        Thread.Sleep(3000);
                        Console.WriteLine("„Falsch.“");
                        Thread.Sleep(3000);
                        Console.WriteLine("Du versuchst es erneut, die Zahlen im Kopf neu zu ordnen.");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }

                Console.Clear();
                Console.WriteLine("Du bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌─────────────────────────────────┐");
                foreach (var raum in aktuellerRaum.Zugang.OrderBy(r => r.Nr))
                {
                    string raumName = !raum.Begehbar ? raum.Name + " (Verschlossen)" : raum.Name;
                    Console.WriteLine($"| {raum.Nr}. {raumName,-28} |");
                }
                Console.WriteLine("└─────────────────────────────────┘");

                Console.WriteLine("\n\nWohin möchtest du gehen? (Nummer eingeben) oder „exit“ zum Startmenü:");
                string eingabe = Console.ReadLine();

                if (eingabe.ToLower() == "exit") // Prüfe auf "exit" (Groß-/Kleinschreibung egal)
                {
                    Console.Clear();
                    ZurueckZumStartmenue = true;
                    Startmenue startmenue = new Startmenue();
                    startmenue.MenueAnzeigen(); // Rufe MenueAnzeigen() hier auf, bevor die Methode verlässt.
                    return; // Beendet die Methode hier, damit die Schleife nicht weiterläuft
                }
                if (int.TryParse(eingabe, out int wahl))
                {
                    Raum zielRaum = aktuellerRaum.Zugang.Find(r => r.Nr == wahl);
                    if (zielRaum != null && zielRaum.Begehbar)
                    {
                        aktuellerRaum = zielRaum;
                    }
                    else if (wahl == 3 && aktuellerRaum == flur && !schliessfachGeloest)
                    {
                        Console.Clear();
                        Console.WriteLine("Du versuchst, den Klassenraum B zu betreten, aber die Tür ist verriegelt.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDurch das Fenster siehst du umgestürzte Möbel und verstreute Blätter.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEs wirkt, als wäre hier etwas Eiliges oder Gewaltsames geschehen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEs gibt keinen offensichtlichen Hinweis, wie du die Tür öffnen könntest.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        continue;
                    }
                    else if (wahl == 4 && aktuellerRaum == flur && !musikGeloest)
                    {
                        Console.Clear();
                        Console.WriteLine("Du stehst vor der Tür zum Musikraum.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nSie ist verschlossen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDu versuchst die Klinke, aber sie lässt sich nicht bewegen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin Schild hängt an der Tür:");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Nur wer die Melodie der Harmonie kennt, findet Einlass.“");
                        Thread.Sleep(3000);
                        Console.Clear();
                        continue;
                    }
                    else if (wahl == 5 && aktuellerRaum == flur && !chemieGeloest)
                    {
                        Console.Clear();
                        Console.WriteLine("Die Tür zum Chemieraum ist verschlossen.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin unheimlicher Geruch.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEine Mischung aus Desinfektionsmittel und etwas Unbekanntem, dringt durch den Türspalt.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin handgeschriebener Zettel klebt an der Tür:");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Die Wahrheit liegt in der richtigen Mischung.“");
                        Thread.Sleep(3000);
                        Console.Clear();
                        continue;
                    }
                    else if (wahl == 9 && aktuellerRaum == chemieraum && !notausgang.Begehbar)
                    {
                        Console.Clear();
                        Console.WriteLine("Du stehst vor der Tür, die scheinbar zum Notausgang führt.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nDie Klinke lässt sich drücken.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nAber die Tür ist zusätzlich mit einem digitalen Zahlenschloss gesichert.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nEin kleines Display leuchtet rot.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n„Ein Code wird benötigt.“");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nVielleicht liegt die Lösung hier im Raum?");
                        Thread.Sleep(3000);
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nUngültige Eingabe.");
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("\nUngültige Eingabe.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if (ZurueckZumStartmenue)
            {
                ZurueckZumStartmenue = false;
                Startmenue startmenue = new Startmenue();
                startmenue.MenueAnzeigen();
            }
        }

        // Innere Klasse "Raum" definiert Struktur eines Raumes
        class Raum
        {

            // get = Damit kann man den aktuellen Wert abfragen (lesen)

            // set = Damit kann man einen neuen Wert zuweisen (schreiben)

            public string Name { get; set; } // Raumname
            public int Nr { get; set; } // Raum-Nummer zur Auswahl
            public bool Begehbar { get; set; } // Ist der Raum betretbar?
            public bool CharakterAnwesend { get; set; } // Ist ein Charakter im Raum?
            public bool ItemVorhanden { get; set; } // Ist ein Item im Raum?
            public List<Raum> Zugang { get; set; } // Liste erreichbarer Nachbarräume

            // Erstellt einen neuen Raum mit den angegebenen Werten
            public Raum(string name, int nr, bool begehbar, bool charakter, bool item)
            {
                Name = name;
                Nr = nr;
                Begehbar = begehbar;
                CharakterAnwesend = charakter;
                ItemVorhanden = item;
                Zugang = new List<Raum>();
            }
        }
    }
}