using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Spieler
    {
        
        private int _guthaben = 2000;
      
        public int Guthaben
        {
            get { return _guthaben; }
            set { _guthaben = value; }
        }

        public void minusguthaben(int abzug)
        {
            _guthaben = _guthaben - abzug;

        }

    }
}
