using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class gegner
    {

        private int _gegnererhoehe;
        public int gegnererhoehe { get { return _gegnererhoehe; } set { _gegnererhoehe = value; } }
        private int _gegnerguthaben = 2000;
        public int gegnerguthaben { get { return _gegnerguthaben; } set { _gegnerguthaben = value; } }
        public void erhoehe(int wert, Spieler player)
        {
            if (player.Guthaben > 0)
            {
                MessageBox.Show("Gegner erhöht um: " + wert);
            }
            _gegnererhoehe = wert;
            _gegnerguthaben -= _gegnererhoehe;
        }

        public int mitkommen(int spielereinsatz)
        {
            _gegnerguthaben -= spielereinsatz;
            MessageBox.Show("Gegner kommt mit");
            return spielereinsatz;
        }


        public bool ermittleoberhöhe(KartenWert kw, Spieler player)
        {
            Random zf = new Random();
            int wahrscheinlichkeit = zf.Next(100) + 1;
            int erho = zf.Next(350) + 1;
            int irrationaleentscheidung = zf.Next(15);
            int zufall = zf.Next(15);

            if(player.Guthaben < erho)
            {
                erho = player.Guthaben;
            }
            if(zufall == irrationaleentscheidung)
            {
                erhoehe(erho, player);
                return true;
            }
            else if (kw._gegnervierling == true)
            {
                if (wahrscheinlichkeit <= 90)
                {
                    if (_gegnerguthaben >= erho + 50)
                    {
                        erhoehe(erho + 50, player);
                        return true;
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }

                }
            }
            else if (kw._gegnerfullhouse == true)
            {
                if (wahrscheinlichkeit <= 85)
                {
                    if (_gegnerguthaben >= erho + 45)
                    {
                        erhoehe(erho + 45, player);
                        return true;
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }
                }
            }
            else if(kw._gegnerflush == true)
            {
                if (wahrscheinlichkeit <= 80)
                {
                    if (_gegnerguthaben >= erho + 25)
                    {
                        erhoehe(erho + 25, player);
                        return true;
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }
                }
            }else if(kw._gegnerstreett == true)
            {
                if (wahrscheinlichkeit <= 70)
                {
                    if (_gegnerguthaben >= erho )
                    {
                        erhoehe(erho , player);
                        return true;
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }
                    
                }
            }else if (kw._gegnerdrilling==true)
            {
                if (wahrscheinlichkeit <= 60)
                {
                    if (_gegnerguthaben >= erho -20)
                    {
                        if (erho - 20 < 0)
                        {
                            erhoehe(erho, player);
                            return true;
                        }
                        else
                        {
                            erhoehe(erho - 20, player);
                            return true;
                        }
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }
                  
                }
            }
            else if (kw._gegnerdoublepair == true)
            {
                if (wahrscheinlichkeit <= 50)
                {
                    if (_gegnerguthaben >= erho - 30)
                    {
                        if (erho - 50 < 0)
                        {
                            erhoehe(erho, player);
                            return true;
                        }
                        else
                        {
                            erhoehe(erho - 30, player);
                            return true;
                        }
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }
                
                
            }
            }else if(kw._gegnerpair == true)
            {
                if(wahrscheinlichkeit <= 40)
                {
                    if (_gegnerguthaben >= erho - 50)
                    {
                        if (erho - 100 < 0)
                        {
                            erhoehe(erho, player);
                            return true;
                        }
                        else
                        {
                            erhoehe(erho - 50, player);
                            return true;
                        }
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                        return true;
                    }

                }
            
            }
            else
            {  if (_gegnerguthaben >= erho -100)
                    {
                        if (erho - 120 < 0)
                        {
                            erhoehe(erho, player);
                        return true;
                    }
                        else
                        {
                            erhoehe(erho - 100, player);
                        return true;
                    }
                    }
                    else
                    {
                        erhoehe(_gegnerguthaben, player);
                    return true;
                    }
                 
                }

            return false;
        }
        public bool kommemit(KartenWert kw,int spielerwert,Spieler play)
        {
            Random zf = new Random();
            int wahrscheinlichkeit = zf.Next(100) + 1;
            int irrationaleentscheidung = zf.Next(15);
            int zufall =zf.Next(15);
            if(_gegnerguthaben <= spielerwert)
            {
                int a = spielerwert - _gegnerguthaben;
                play.Guthaben += a;
                spielerwert = _gegnerguthaben;

            }
            
            if(irrationaleentscheidung == zufall)
            {
                mitkommen(spielerwert);
                return true;
            }
            else if (kw._gegnervierling == true)
            {
                if (wahrscheinlichkeit <= 100)
                {
                    mitkommen(spielerwert);
                    return true;
                }
            }
            else if (kw._gegnerfullhouse == true)
            {
                if (wahrscheinlichkeit <= 97)
                {
                    mitkommen(spielerwert);
                    return true;
                }
            }
            else if (kw._gegnerflush == true)
            {
                if (wahrscheinlichkeit <= 95)
                {
                    mitkommen(spielerwert);
                    return true;
                }
            }
            else if (kw._gegnerstreett == true)
            {
                if (spielerwert < 400 && wahrscheinlichkeit <=92)
                {
                   
                        mitkommen(spielerwert);
                        return true;
                    
                }else if (spielerwert > 1000 && wahrscheinlichkeit <=70)
                {
                    mitkommen(spielerwert);
                    return true;
                }
                else
                {
                    if (wahrscheinlichkeit <= 85)
                    {
                        mitkommen(spielerwert);
                        return true;
                    }
                }
            }
            else if (kw._gegnerdrilling == true)
            {

                if (spielerwert < 200 && wahrscheinlichkeit <=83)
                {

                    mitkommen(spielerwert);
                    return true;

                }
                else if (spielerwert > 800 && wahrscheinlichkeit <= 55)
                {
                    mitkommen(spielerwert);
                    return true;
                }
                else
                {
                    if (wahrscheinlichkeit <= 75)
                    {
                        mitkommen(spielerwert);
                        return true;
                    }
                }
            }
            else if (kw._gegnerdoublepair == true)
            { 
                if (spielerwert < 300 && wahrscheinlichkeit <=75)
                {
                   
                        mitkommen(spielerwert);
                        return true;
                    
                }
                else if (spielerwert > 600 && wahrscheinlichkeit <= 53)
                {
                    mitkommen(spielerwert);
                    return true;
                }
                else
                {
                    if (wahrscheinlichkeit <= 65)
                    {
                        mitkommen(spielerwert);
                        return true;
                    }
                }
            }
            else if (kw._gegnerpair == true)
            {
                if (spielerwert < 130 && wahrscheinlichkeit <=70)
                {

                    mitkommen(spielerwert);
                    return true;

                }
                else if (spielerwert > 500 && wahrscheinlichkeit <= 50)
                {
                    mitkommen(spielerwert);
                    return true;
                }
                else
                {
                    if (wahrscheinlichkeit <= 60)
                    {
                        mitkommen(spielerwert);
                        return true;
                    }
                }
            }
            else
            {
                if (spielerwert < 100 && wahrscheinlichkeit <=50)
                {

                    mitkommen(spielerwert);
                    return true;

                }
                else if (spielerwert > 300 && wahrscheinlichkeit <= 15)
                {
                    mitkommen(spielerwert);
                    return true;
                }
                else
                {
                    if (wahrscheinlichkeit <= 25)
                    {
                        mitkommen(spielerwert);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
