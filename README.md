[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/j9ERfv8e)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=18387704&assignment_repo_type=AssignmentRepo)



using System;
using System.Collections.Generic;
 
namespace ExitGame
{
    internal class Schule
    {
        public static void Spielstart()
        {
            Console.Clear();
            Console.WriteLine("Sie haben die Schule betreten");
            Console.WriteLine("\nSie befinden sich im Flur");
 
            // Räume definieren (Name, Nr, Betreten, Charakter, Items)
            Raum flur = new Raum("Flur", 1, true, false, false);
            Raum klassenraumA = new Raum("Klassenraum A", 2, true, false, false);
            Raum klassenraumB = new Raum("Klassenraum B", 3, true, false, false);
            Raum klassenraumC = new Raum("Klassenraum C", 4, true, false, false);
            Raum klassenraumD = new Raum("Klassenraum D", 5, true, false, false);
            Raum musikraum = new Raum("Musikraum", 6, true, false, false);
            Raum umkleide = new Raum("Umkleide", 7, true, false, false);
            Raum chemieraum = new Raum("Chemieraum", 8, true, false, false);
            Raum buero = new Raum("Büro", 9, true, true, false); // Büro mit Charakter
            Raum toilette = new Raum("Toilette", 10, true, false, false);
            Raum lager = new Raum("Lager", 11, false, false, false); // Lager ist zunächst verschlossen
 
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
            buero.Zugang.Add(flur);
            toilette.Zugang.Add(flur);
            lager.Zugang.Add(flur);
 
            // Rätsel-Status
            bool schluesselGefunden = false;
            bool codeGefunden = false;
            bool musikGespielt = false;
            bool chemieGelöst = false;
            bool tagebuchGefunden = false;
 
            // Startwerte
            Raum aktuellerRaum = flur;
            bool levelBeendet = false;
 
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
 
                // Interaktionen mit bestimmten Räumen
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
 
                if (aktuellerRaum == musikraum && !musikGespielt)
                {
                    Console.WriteLine("\nDu musst ein bestimmtes Lied in der richtigen Reihenfolge spielen. Höre genau hin!");
                    // Musikrätsel
                    musikGespielt = SpieleMusikRätsel();
                }
 
                if (aktuellerRaum == chemieraum && !chemieGelöst)
                {
                    Console.WriteLine("\nIm Chemieraum gibt es ein Experiment mit Flüssigkeiten. Du musst die richtigen Chemikalien kombinieren!");
                    // Chemie-Experiment
                    chemieGelöst = ChemieExperiment();
                }
 
                if (aktuellerRaum == klassenraumB && !codeGefunden)
                {
                    Console.WriteLine("\nDu findest ein Buch mit einer Zahlenkombination: 4783. Du kannst es für das Schließfach verwenden.");
                    codeGefunden = true;
                }
 
                if (aktuellerRaum == klassenraumD && !tagebuchGefunden)
                {
                    Console.WriteLine("\nDu findest Seiten eines Tagebuchs, die Hinweise auf eine geheime Tür enthalten.");
                    tagebuchGefunden = true;
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
                    // Check if moving to Lager without key
                    if (raum == lager && !schluesselGefunden)
                    {
                        Console.WriteLine("Das Lager ist verschlossen! Du benötigst einen Schlüssel.");
                        return aktuellerRaum;
                    }
                    return raum;
                }
            }
            return null;
        }
 
        // Rätsel für das Musikrätsel
        static bool SpieleMusikRätsel()
        {
            Console.WriteLine("Du musst das Lied in der richtigen Reihenfolge spielen.");
            Console.WriteLine("Drücke 1 für die erste Note, 2 für die zweite, usw. (1-4): ");
            string eingabe = Console.ReadLine();
            if (eingabe == "1 2 3 4")
            {
                Console.WriteLine("Das Lied wurde korrekt gespielt!");
                return true;
            }
            else
            {
                Console.WriteLine("Das Lied war falsch. Versuch es noch einmal.");
                return false;
            }
        }
 
        // Chemie-Experiment
        static bool ChemieExperiment()
        {
            Console.WriteLine("Wähle die richtigen Chemikalien, um das Experiment zu lösen.");
            Console.WriteLine("Gib die Chemikalien ein (z.B. A, B, C): ");
            string eingabe = Console.ReadLine();
            if (eingabe == "A B C")
            {
                Console.WriteLine("Das Experiment ist erfolgreich!");
                return true;
            }
            else
            {
                Console.WriteLine("Falsche Chemikalienkombination! Rauch steigt auf.");
                return false;
            }
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
