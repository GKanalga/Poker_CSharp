using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class KartenWert
    {
       
        public List<int> _mittewert;
        public List<int> _spielerwert;
        public List<int> _gegnerwert;
        public List<int> _farbespieler;
        public List<int> _farbemitte;
        public List<int> _farbegegner;


        //Werte welche den höheren bestimmen falls beide das gleiche haben 
        // Legende S = spieler Buchstabe danach kürzt die hand ab zbs s = street und h bedeutet höhe
        // G= gegner
        //FLush
        public int sflh = 0;
        public int gflh = 0;
        //Vierling
        public int svh = 0;
        public int gvh = 0;
        //Street
        public int ssh = 0;
        public int gsh = 0;
        //Double pair && fulhouse
        public int sdph1 = 0;
        public int sdph2 = 0;
        public int gdph1 = 0;
        public int gdph2 = 0;
        //pair
        public int sph = 0;
        public int gph = 0;
        //drilling 
        public int sdh = 0;
        public int gdh = 0;
        


        //bool zum checken welche hand man hat
        public bool _gegnerpair =false;
        public bool _spielerpair = false;
        public bool _gegnerdrilling = false;
        public bool _spielerdrilling = false;
        public bool _spielervierling = false;
        public bool _gegnervierling = false;
        public bool _spielerstreett = false;
        public bool _gegnerstreett = false;
        public bool _spielerdoublepair = false;
        public bool _gegnerdoublepair = false;
        public bool _spielerfullhouse = false;
        public bool _gegnerfullhouse = false;
        public bool _gegnerflush = false;
        public bool _spielerflush = false;
       public int gh = 0;
        public int sh = 0;

        public Image imagepfad(String a)
        {
            Image b = Image.FromFile(a);

          

            return b;
        }
        public void newround()
        {
            _mittewert.Clear();
            _spielerwert.Clear();
            _gegnerwert.Clear();
            _farbespieler.Clear();
            _farbemitte.Clear();
            _farbegegner.Clear();
              _gegnerpair = false;
        _spielerpair = false;
        _gegnerdrilling = false;
         _spielerdrilling = false;
        _spielervierling = false;
        _gegnervierling = false;
         _spielerstreett = false;
        _gegnerstreett = false;
         _spielerdoublepair = false;
         _gegnerdoublepair = false;
        _spielerfullhouse = false;
       _gegnerfullhouse = false;
         _gegnerflush = false;
       _spielerflush = false;
            gh = 0;
            sh = 0;

    }
        
        public void getmittwert(List<int> mittewertt)
        {
            _mittewert = mittewertt;

        }
        public void getspielerwertt(List<int> spielerwertt)
        {
            _spielerwert = spielerwertt;

        }
        public void getgegnerwert(List<int> gegnerwertt)
        {
            _gegnerwert = gegnerwertt;

        }
        public void getfarbespieler(List<int> farbespieler)
        {
            _farbespieler = farbespieler;
        }
        public void getfarbegegner(List<int> farbegegner)
        {
            _farbegegner = farbegegner;
        }
        public void getfarbemitte(List<int> farbemitte)
        {
            _farbemitte = farbemitte;
        }
      
        public void checkflush()
        {
            List<int> _spielerflushs = new List<int>();
            List<int> _gegnerflushs = new List<int>();

            foreach(int a in _farbemitte)
            {
                _spielerflushs.Add(a);
                _gegnerflushs.Add(a);
            }
            foreach(int a in _farbespieler)
            {
                _spielerflushs.Add(a);
            }
            foreach(int a in _farbegegner)
            {
                _gegnerflushs.Add(a);
            }
            _gegnerflushs.Sort();
            _spielerflushs.Sort();


            for(int i =0; i <= 2; i++)
            {
                if (_spielerflushs[i] == _spielerflushs[i+1] && _spielerflushs[i] == _spielerflushs[i+2]&& _spielerflushs[i]== _spielerflushs[i+3]&& _spielerflushs[i] == _spielerflushs[i + 4])
                {
                    _spielerflush = true;
                     sflh = _spielerflushs[i + 4];
                }

                if (_gegnerflushs[i] == _gegnerflushs[i+1]&& _gegnerflushs[i]== _gegnerflushs[i+2]&& _gegnerflushs[i]== _gegnerflushs[i+3]&& _gegnerflushs[i]== _gegnerflushs[i + 4])
                {
                    _gegnerflush = true;
                     gflh = _gegnerflushs[i + 4];
                }
                
            }

            if(_spielerflush==true&& _spielervierling == false)
            {
               // MessageBox.Show("Spieler hat Flush");
            }
            if(_gegnerflush == true && _gegnervierling == false)
            {
               // MessageBox.Show("Gegner hat Flush");
            }
        }
        public void checkpair()
        {
            if (_spielerwert[0] == _spielerwert[1])
            {
                _spielerpair = true;
            }

            if (_gegnerwert[0] == _gegnerwert[1])
            {
                _gegnerpair = true;
            }
           

            foreach(int pair in _mittewert)
            {
                int countpair = 0;
                if(pair == _spielerwert[0]||pair== _spielerwert[1])
                {
                    _spielerpair = true;
                    sph = pair;
                   
                }
                if(pair == _gegnerwert[0] || pair== _gegnerwert[1])
                {
                    _gegnerpair = true;
                    gph = pair;
                }
                for(int i = 0; i <= 4; i++)
                {
                    if(pair == _mittewert[i])
                    {
                        countpair++;
                        if(countpair == 2)
                        {
                            sph = pair;
                            gph = pair;
                        }
                    }
                }
                if(countpair == 2)
                {
                    _gegnerpair = true;
                    _spielerpair = true;
                }
               
            }

            if (_spielerpair == true && _spielerdrilling == false && _spielervierling == false && _spielerstreett == false && _spielerdoublepair == false && _spielerfullhouse==false&& _spielerflush==false)
            {
               // MessageBox.Show("spieler hat ein pair");
            }

            if (_gegnerpair == true && _gegnerdrilling == false && _gegnervierling ==false && _gegnerstreett==false &&_gegnerdoublepair ==false && _gegnerfullhouse == false&&_gegnerflush==false)
            {
               // MessageBox.Show("gegner hat ein pair");
            }

        }

        
        public void checkdoublepair()
        {
         
            List<int> _spielerdoublepaircheck = new List<int>();
            List<int> _gegnerdoublepaircheck = new List<int>();
            int _spielerpaircount = 0;
            int _gegnerpaircount = 0;
            
            foreach (int a in _mittewert)
            {
                _spielerdoublepaircheck.Add(a);
               
            }
            foreach(int b in _spielerwert)
            {
                _spielerdoublepaircheck.Add(b);
            }

            foreach(int b in _gegnerwert)
            {
                _gegnerdoublepaircheck.Add(b);
            }
            foreach(int a in _mittewert)
            {
                _gegnerdoublepaircheck.Add(a);
            }
            
            /*
            _spielerdoublepaircheck.Add(1);
            _spielerdoublepaircheck.Add(3);
            _spielerdoublepaircheck.Add(3);
            _spielerdoublepaircheck.Add(4);
            _spielerdoublepaircheck.Add(5);
            _spielerdoublepaircheck.Add(5);
            _spielerdoublepaircheck.Add(5);
            */
            _gegnerdoublepaircheck.Sort();
            _spielerdoublepaircheck.Sort();

            foreach(int a in _spielerdoublepaircheck)
            {
               
                int inde = _spielerdoublepaircheck.IndexOf(a);
            
                for(int i = 0; i <=6; i++)
                {
                    if(a == _spielerdoublepaircheck[i]&& i!= inde)
                    {
                        _spielerpaircount++;
                        if(_spielerpaircount <= 2 )
                        {
                            sdph1 = _spielerdoublepaircheck[i];
                        }else if(_spielerpaircount > 2)
                        {
                            sdph2 = _spielerdoublepaircheck[i];
                        }
                    }
                }
            }
            
            foreach (int a in _gegnerdoublepaircheck)
            {

                int inde = _gegnerdoublepaircheck.IndexOf(a);

                for (int i = 0; i <= 6; i++)
                {
                    if (a == _gegnerdoublepaircheck[i] && i != inde)
                    {
                        _gegnerpaircount++;
                        if(_gegnerpaircount <= 2)
                        {
                            gdph1 = _gegnerdoublepaircheck[i];
                        }else if(_gegnerpaircount > 2)
                        {
                            gdph2 = _gegnerdoublepaircheck[i];
                        }
                    }
                }

            }


            if (_spielerpaircount == 8)
            {
                _spielerfullhouse = true;
               // MessageBox.Show("Spieler hat einen Fullhouse");
               
            }
            else if (_spielerpaircount < 8 && _spielerpaircount >3)
            {
                _spielerdoublepair = true;
               // MessageBox.Show("Spieler hat einen doublepair");
            }

            if(_gegnerpaircount == 8)
            {
                _gegnerfullhouse = true;
               // MessageBox.Show("Gegner hat einen Fullhouse");
            }
            else if( _gegnerpaircount < 8 && _gegnerpaircount >3)
            {
                _gegnerdoublepair = true;
               // MessageBox.Show("Gegner hat einen doublepair");
               
            }


           
        }
        /*
        public void checkfullhouse()
        {
            if(_spielerdoublepair == true && _spielerdrilling == true)
            {
                _spielerfullhouse = true;
                MessageBox.Show("Spieler hat einen Fullhouse");
            }else if(_spielerdrilling == true && _spielerdoublepair == false && _spielervierling ==false && _spielerstreett == false)
            {
                MessageBox.Show("Spieler hat einen drilling");
            }
            else if (_spielerdrilling == false && _spielerdoublepair == true&& _spielervierling == false && _spielerstreett == false)
            {
                MessageBox.Show("Spieler hat doublepair");
            }

              
            if (_gegnerdoublepair == true && _gegnerdrilling == true)
            {
                _gegnerfullhouse = true;
                MessageBox.Show("Gegner hat einen Fullhouse");
            }else if(_gegnerdrilling == true && _gegnerdoublepair == false && _gegnervierling == false && _gegnerstreett == false)
                {
                    MessageBox.Show("Gegner hat einen drilling");
                }
                else if (_gegnerdrilling == false && _gegnerdoublepair == true && _gegnervierling == false && _gegnerstreett == false)
                {
                    MessageBox.Show("Gegner hat einen doublepair");
                }



        }*/
        public void checkdrilling()
        {

            
            int _count3 = 0;
            int _wert=0;
          
            foreach (int drilling in _mittewert)
            {
                _wert = 0;
                _count3 = 0;
            for(int i = 0; i < _mittewert.Count; i++)
                {
                    if(drilling == _mittewert[i])
                    {
                        _count3++;
                    }
                    if(_count3 == 2)
                    {
                        _wert = 2 ;
                        
                    }
                    if(_count3 == 3)
                    {
                        _wert = 3;
                        _count3 = 0;
                    }
                }
                if (_spielerwert[0] == _spielerwert[1] && drilling == _spielerwert[1])
                {
                    _spielerdrilling = true;
                    sdh = drilling;
                }

                if (_gegnerwert[0] == _gegnerwert[1] && drilling == _gegnerwert[1])
                {
                    _gegnerdrilling = true;
                    gdh = drilling;

                }

                

                if(_wert == 2 && drilling == _spielerwert[0] || _spielerwert[1] == drilling && _wert ==2 || _wert==3)
                {
                    _spielerdrilling = true;
                    sdh=drilling;
                   
                }


                if (_wert == 2 && drilling == _gegnerwert[0] || _gegnerwert[1] == drilling && _wert == 2 || _wert == 3)
                {
                    _gegnerdrilling = true;
                    gdh =drilling;
                  
                }


            }
            if(_spielerdrilling == true && _spielervierling == false && _spielerstreett == false && _spielerflush ==false)
            {
                //MessageBox.Show("Spieler hat einen drilling");
            }
            
            if(_gegnerdrilling == true && _gegnervierling == false && _gegnerstreett == false && _gegnerflush==false)
            {
               // MessageBox.Show("Gegner hat einen drilling");
            }
            
        }

        public void checkvierling()
        {
            int _count3 = 0;
            int _wert = 0;
            foreach (int a in _mittewert)
            {
                _wert = 0;
                _count3 = 0;
                for (int i = 0; i < _mittewert.Count; i++)
                {
                    if (a == _mittewert[i])
                    {
                        _count3++;
                    }
                    if (_count3 == 2)
                    {
                        _wert = 2;

                    }
                    if (_count3 == 3)
                    {
                        _wert = 3;
                        _count3 = 0;
                    }
                }
                if(_wert == 3 && _spielerwert[0] == a || _wert == 3 && _spielerwert[1] == a||_wert ==4|| _spielerwert[0] == _spielerwert[1] && _spielerwert[0] == a && _wert == 2)
                {
                    _spielervierling = true;
                    svh = a;
                }
                if (_wert == 3 && _gegnerwert[0] == a || _wert == 3 && _gegnerwert[1] == a || _wert == 4 || _gegnerwert[0] == _gegnerwert[1] && _gegnerwert[0] == a && _wert == 2)
                {
                    _gegnervierling = true;
                    gvh =a;
                }



            }
            if (_spielervierling == true)
            {
               // MessageBox.Show("Spieler hat ein vierling");
            }
            if (_gegnervierling == true)
            {
               // MessageBox.Show("Gegner hagt ein vierling");
            }


        }

        public void checkstreet()
        {
            List<int> _spielerstreet = new List<int>();

            List<int> _gegnerstreet = new List<int>();


          
            
           foreach(int i in _spielerwert)
            {
                _spielerstreet.Add(i);
            }

           foreach(int i in _gegnerwert)
            {
                _gegnerstreet.Add(i);
            }
           foreach(int i in _mittewert){
                _spielerstreet.Add(i);
               _gegnerstreet.Add(i);
            }
            

            _spielerstreet.Sort();
            _gegnerstreet.Sort();

            foreach (int b in _spielerstreet)
            {

               

                int index = _spielerstreet.IndexOf(b);
                if (index < 3)
                {
                    for (int ab = index; ab <= 2; ab++)
                    {
                        if (b + 1 == _spielerstreet[ab+1] && b + 2 == _spielerstreet[ab + 2] && b + 3 == _spielerstreet[ab + 3] && b + 4 == _spielerstreet[ab + 4] )
                        {
                            _spielerstreett = true;
                            ssh = _spielerstreet[ab + 4];
                        }
                    }
                }

                
            }
            foreach (int b in _gegnerstreet)
            {

                
                int index = _gegnerstreet.IndexOf(b);
                if (index < 3)
                {
                    for (int ab = index; ab <= 2; ab++)
                    {
                        if (b + 1 == _gegnerstreet[ab + 1] && b + 2 == _gegnerstreet[ab + 2] && b + 3 == _gegnerstreet[ab + 3] && b + 4 == _gegnerstreet[ab + 4])
                        {
                            _gegnerstreett = true;
                            gsh = _gegnerstreet[ab + 4];
                        }
                    }
                }


            }


            if (_spielerstreett == true && _spielervierling ==false && _spielerfullhouse ==false)
            {
               // MessageBox.Show("spieler hat street");
            }
            if(_gegnerstreett == true&& _gegnervierling == false && _gegnerfullhouse== false)
            {
                //MessageBox.Show("gegner hat street");
            }
           
        }

        public void showdown(Spieler spieler, gegner gegner, game game, PictureBox gegnerface, Label stimmung)
        { 
         
            int splitpot = 0;
            String gegnerhand = " ";
            String spielerhand = " ";

            if (_gegnervierling == true)
            {
                gh = 8;
                gegnerhand = " Vierling ";
            }else if(_gegnerfullhouse == true)
            {
                gh = 7;
                gegnerhand = " Fullhouse ";
            }
            else if(_gegnerflush == true)
            {
                gh = 6;
                gegnerhand = " Flush ";

            }
            else if(_gegnerstreett == true)
            {
                gh = 5;
                gegnerhand = " Street ";

            }
            else if(_gegnerdrilling == true)
            {
                gh = 4;
                gegnerhand = " Drilling ";

            }
            else if(_gegnerdoublepair == true)
            {
                gegnerhand = " Double Pair ";
                gh = 3;
            }else if(_gegnerpair == true)
            {
                gh = 2;
                gegnerhand = " Pair ";

            }
            else
            {
                gh = 1;
                gegnerhand = " Highcard ";

            }



            


            if (_spielervierling == true)
            {
                sh = 8;
                spielerhand = " Vierling ";
            }
            else if (_spielerfullhouse == true)
            {
                sh = 7;
                spielerhand = " Fullhouse ";

            }
            else if (_spielerflush == true)
            {
                sh = 6;
                spielerhand = " FLush ";

            }
            else if (_spielerstreett == true)
            {
                sh = 5;
                spielerhand = " Street ";

            }
            else if (_spielerdrilling == true)
            {
                sh = 4;
                spielerhand = " Drilling ";

            }
            else if (_spielerdoublepair == true)
            {
                sh = 3;
                spielerhand = " Double Pair ";

            }
            else if (_spielerpair == true)
            {
                sh = 2;
                spielerhand = " Pair ";

            }
            else
            {
                sh = 1;
                spielerhand = " Highcard ";

            }

            MessageBox.Show("Du hast ein:" + spielerhand + "\n" + "Dein Gegner hat ein:" + gegnerhand);

            if (sh == gh )
            {
                if (checkwhohigher(sh) == 1)
                {
                    Thread.Sleep(1000);
                    MessageBox.Show("Du hast gewonnen du bekommst: " + game.Mitteeinsatz);
                    spieler.Guthaben += game.Mitteeinsatz;
                    game.Mitteeinsatz = 0;
                    gegnerface.Image = Image.FromFile((@"Karten\Gegner.png"));
                    stimmung.Text = "Mood: Wütend";
                }
                else if (checkwhohigher(sh) == 2)
                {
                    Thread.Sleep(1000);
                    MessageBox.Show("Gegner hat gewonnen er bekommt: " + game.Mitteeinsatz);
                    gegner.gegnerguthaben += game.Mitteeinsatz;
                    game.Mitteeinsatz = 0;
                    gegnerface.Image = Image.FromFile((@"Karten\Gegnerhappy.jpg"));
                    stimmung.Text = "Mood: Glücklich";
                }
                else
                {
                    Thread.Sleep(1000);
                    splitpot = game.Mitteeinsatz / 2;
                    game.Mitteeinsatz = 0;
                    MessageBox.Show("Unentschieden Splitpot beide bekommen: " + splitpot);
                    gegner.gegnerguthaben += splitpot;
                    spieler.Guthaben += splitpot;
                    gegnerface.Image = Image.FromFile((@"Karten\Mittel.png"));
                    stimmung.Text = "Mood: Angespannt";
                }

            }
            else if(sh< gh)
            {
                Thread.Sleep(1000);
                MessageBox.Show("Gegner hat gewonnen er bekommt: " + game.Mitteeinsatz);
                gegner.gegnerguthaben += game.Mitteeinsatz;
                game.Mitteeinsatz = 0;
                gegnerface.Image = Image.FromFile((@"Karten\Gegnerhappy.jpg"));
                stimmung.Text = "Mood: Glücklich";

            }
            else if(sh > gh)
            {
                Thread.Sleep(1000);
                MessageBox.Show("Du hast gewonnen du bekommst: " + game.Mitteeinsatz);
                spieler.Guthaben += game.Mitteeinsatz;
                game.Mitteeinsatz = 0;
                gegnerface.Image = Image.FromFile((@"Karten\Gegner.png"));
                stimmung.Text = "Mood: Wütend";
            }

        }
        public int checkwhohigher(int hand)
        {
            int rw = 0;


            if (hand == 1) {
                _spielerwert.Sort();
                _gegnerwert.Sort();
                if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                {
                    rw = 3;
                }else if (_gegnerwert[0] == 1)
                {
                    rw = 2;
                }else if (_spielerwert[0] == 1)
                {
                    rw = 1;
                }
                else if (_gegnerwert[1] == _spielerwert[1])
                {
                    rw = 3;
                } else if (_gegnerwert[1] < _spielerwert[1])
                {
                    rw = 1;
                }
                else
                {
                    rw = 2;
                  
                }
            }

            if (hand == 2) {
                if (sph == gph)
                {
                    _spielerwert.Sort();
                    _gegnerwert.Sort();
                    if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                    {
                        rw = 3;
                    }
                    else if (_gegnerwert[0] == 1)
                    {
                        rw = 2;
                    }
                    else if (_spielerwert[0] == 1)
                    {
                        rw = 1;
                    }
                    else if (_gegnerwert[1] == _spielerwert[1])
                    {
                        rw = 3;
                    }
                    else if (_gegnerwert[1] < _spielerwert[1])
                    {
                        rw = 1;
                    }
                    else
                    {
                        rw = 2;

                    }
                    
                    
                }
                else if (sph > gph)
                {
                    rw = 1;
                    
                }
                else
                {
                    rw = 2;

                } }

            if (hand == 3) {

                if (gdph1 >= gdph2)
                {

                    if (sdph1 >= sdph2)
                    {

                        if (sdph1 > gdph1)
                        {

                            rw = 1;
                            
                        }
                        else if (gdph1 > sdph1)
                        {

                            rw = 2;
                            
                        }
                        else if (gdph1 == sdph1)
                        {
                            _spielerwert.Sort();
                            _gegnerwert.Sort();
                            if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[0] == 1)
                            {
                                rw = 2;
                            }
                            else if (_spielerwert[0] == 1)
                            {
                                rw = 1;
                            }
                            else if (_gegnerwert[1] == _spielerwert[1])
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[1] < _spielerwert[1])
                            {
                                rw = 1;
                            }
                            else
                            {
                                rw = 2;

                            }

                        }
                    }
                    else
                    {
                        if (sdph2 > gdph1)
                        {

                            rw = 1;
                            
                        }
                        else if (gdph1 > sdph2)
                        {

                            rw = 2;
                            

                        }
                        else if (gdph1 == sdph2)
                        {
                            _spielerwert.Sort();
                            _gegnerwert.Sort();
                            if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[0] == 1)
                            {
                                rw = 2;
                            }
                            else if (_spielerwert[0] == 1)
                            {
                                rw = 1;
                            }
                            else if (_gegnerwert[1] == _spielerwert[1])
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[1] < _spielerwert[1])
                            {
                                rw = 1;
                            }
                            else
                            {
                                rw = 2;

                            }

                        }
                    }
                }
                else
                {

                    if (sdph1 >= sdph2)
                    {

                        if (sdph1 > gdph2)
                        {

                            rw = 1;
                        }
                        else if (gdph2 > sdph1)
                        {

                            rw = 2;

                        }
                        else if (gdph2 == sdph1)
                        {
                            _spielerwert.Sort();
                            _gegnerwert.Sort();
                            if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[0] == 1)
                            {
                                rw = 2;
                            }
                            else if (_spielerwert[0] == 1)
                            {
                                rw = 1;
                            }
                            else if (_gegnerwert[1] == _spielerwert[1])
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[1] < _spielerwert[1])
                            {
                                rw = 1;
                            }
                            else
                            {
                                rw = 2;

                            }
                        }
                    }
                    else
                    {
                        if (sdph2 > gdph2)
                        {

                            rw = 1;
                        }
                        else if (gdph2 > sdph2)
                        {

                            rw = 2;
                        }
                        else if (gdph2 == sdph2)
                        {
                            _spielerwert.Sort();
                            _gegnerwert.Sort();
                            if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[0] == 1)
                            {
                                rw = 2;
                            }
                            else if (_spielerwert[0] == 1)
                            {
                                rw = 1;
                            }
                            else if (_gegnerwert[1] == _spielerwert[1])
                            {
                                rw = 3;
                            }
                            else if (_gegnerwert[1] < _spielerwert[1])
                            {
                                rw = 1;
                            }
                            else
                            {
                                rw = 2;

                            }


                        }
                    }
                } }
                   
            if(hand == 4)
            {
                if(sdh == gdh)
                {
                    _spielerwert.Sort();
                    _gegnerwert.Sort();
                    if (_gegnerwert[0] == 1 && _spielerwert[0] == 1)
                    {
                        rw = 3;
                    }
                    else if (_gegnerwert[0] == 1)
                    {
                        rw = 2;
                    }
                    else if (_spielerwert[0] == 1)
                    {
                        rw = 1;
                    }
                    else if (_gegnerwert[1] == _spielerwert[1])
                    {
                        rw = 3;
                    }
                    else if (_gegnerwert[1] < _spielerwert[1])
                    {
                        rw = 1;
                    }
                    else
                    {
                        rw = 2;

                    }
                }
                else if (sdh < gdh)
                {
                    rw= 2;
                }
                else
                {
                    rw = 1;
                }
            }

                     if(hand == 5)
            {
                if (ssh == gsh)
                {
                    rw = 3;
                }else if(ssh> gsh)
                {
                    rw = 1;
                }
                else
                {
                    rw = 2;
                }
            }
                     if(hand == 6)
            {
                if (sflh == gflh)
                {
                    rw = 3;
                }
                else if (sflh > gflh)
                {
                    rw = 1;
                }
                else
                {
                    rw = 2;
                }
            }

            if (hand == 7) {
                rw = 3;
            }
            if(hand ==8) {
                if (svh == gvh)
                {
                    rw = 3;
                }
                else if (svh > gvh)
                {
                    rw = 1;
                }
                else
                {
                    rw = 2;
                }
            }
                
            return rw;

        }
    }
}
