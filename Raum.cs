using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGame;

namespace ExitGame
{
    internal class Raum
    {
        

            public string Name;
            public int Nr;
            public bool Access;
            public bool CharAnwesend;
            public bool ItemVorhanden;
            public string[] Gegenstaende = new string[2];
            public int[] Zugang = new int[3];  

        
    }
}
