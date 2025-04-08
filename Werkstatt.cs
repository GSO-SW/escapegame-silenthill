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

            Raum werkstattraum = new Raum("Werkstattraum", 1, true, true, false);
            Raum buero = new Raum("Büro", 2, true, false, true);
            Raum toilette = new Raum("Toilette", 3, true, false, false);
            Raum lager = new Raum("Lager", 4, false, false, true);

            

            werkstattraum.Zugang.Add(buero);
            werkstattraum.Zugang.Add(toilette);
            werkstattraum.Zugang.Add(lager);

            buero.Zugang.Add(werkstattraum);
            toilette.Zugang.Add(werkstattraum);
            lager.Zugang.Add(werkstattraum);

            Raum aktuellerRaum = werkstattraum;
            bool levelBeendet = false;
            bool schluesselGefunden = false;

            while (!levelBeendet)
            {
                Console.Clear();
                Console.WriteLine("Du bist im " + aktuellerRaum.Name + ".");
                Console.WriteLine("\nVerfügbare Räume:");
                Console.WriteLine("┌──────────────────────────────┐");
                foreach (var raum in aktuellerRaum.Zugang)
                {
                    string raumName = raum == lager && !schluesselGefunden ? $"{raum.Name} (Verschlossen)" : raum.Name;
                    Console.WriteLine($"| {raum.Nr}. {raumName,-25} |");
                }
                Console.WriteLine("└──────────────────────────────┘");

                if (aktuellerRaum == buero && !schluesselGefunden)
                {
                    Console.WriteLine("\nRätsel: Entschlüssle 'YPMADIR'");
                    if (LoeseRaetsel("PYRAMID"))
                    {
                        schluesselGefunden = true;
                    }
                }

                if (aktuellerRaum == toilette)
                {
                    Console.WriteLine("\nEin verletzter, obdachloser alter Mann flüstert: 'Die Reifen... sie sind im Lager...'");
                }

                if (aktuellerRaum == lager && schluesselGefunden)
                {
                    Console.Clear();
                    Console.WriteLine("Sie haben das Lager betreten und die Reifen geholt!");
                    Console.WriteLine("(Beliebige Taste drücken)");
                    Console.ReadKey();
                    levelBeendet = true;
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen..");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Nächstes Level wird geladen...");
                    System.Threading.Thread.Sleep(1000);
                    Schule.Spielstart();
                }

                Console.WriteLine("\nWohin möchtest du gehen? (Nummer eingeben)");
                if (int.TryParse(Console.ReadLine(), out int raumNr))
                {
                    if (raumNr == 4 && !schluesselGefunden)
                    {
                        Console.WriteLine("\nDas Lager ist verschlossen! Du benötigst einen Schlüssel.");
                        Console.ReadKey();
                        continue;
                    }

                    Raum neuerRaum = BewegeSpieler(aktuellerRaum, raumNr, lager, schluesselGefunden);
                    if (neuerRaum != null)
                    {
                        aktuellerRaum = neuerRaum;
                    }
                    else
                    {
                        Console.WriteLine("\nUngültige Auswahl! Versuche es erneut.");
                        Console.ReadKey();
                    }
                }
            }
        }

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

        static Raum BewegeSpieler(Raum aktuellerRaum, int raumNr, Raum lager, bool schluesselGefunden)
        {
            foreach (var raum in aktuellerRaum.Zugang)
            {
                if (raum.Nr == raumNr)
                {
                    if (raum == lager && !schluesselGefunden)
                    {
                        return aktuellerRaum;
                    }
                    return raum;
                }
            }
            return null;
        }

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