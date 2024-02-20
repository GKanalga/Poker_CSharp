using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Karten
    {
        private List<string> art = new List<string> { "H", "D", "K", "B" };
       
        private List<String> kartenbilder = new List<String>();
        KartenWert kartenwert = new KartenWert();

        public int _wert1 { get; set; }
        public int _wert2 { get; set; }

        

      /*  public void kartenmischen()
        {
            for(int i = 1; i > 14; i++)
            {
                foreach(string a in art) 
                {
                    String abcd = i + a;
                    Image karte = Image.FromFile((@"Karten\"+i+a+".png"));
                    kartenbilder.Add(karte);
                }
               
            }
        }

      */

        public void newround()
        {
            kartenbilder.Clear();
        }
        public Image kartenverteilen()
        {
            int wert1;
            int wert2;
            Image a;
            Random rnd = new Random();
            int random = rnd.Next(52) ;
            string ab = "";
            
            double asd =random / 4 + 1;
            wert1 = Convert.ToInt32(Math.Floor(asd));
           
            if(random % 4 == 0)
            {
                wert2 = 4;
                ab = wert1 + art[wert2 - 1];
                a = Image.FromFile((@"Karten\"+ab+".png"));

              
            }else if(random % 3 == 0 )
            {
                wert2 = 3;
                ab = wert1 + art[wert2 - 1];
                a = Image.FromFile((@"Karten\" + ab + ".png"));
               
            }
            else if(random%2 == 0 )
            {
                wert2 = 2;
                ab = wert1 + art[wert2 - 1];
                a = Image.FromFile((@"Karten\" + ab + ".png"));
                
            }
            else 
            {
                wert2 = 1;
                ab = @"Karten\" + wert1 + art[wert2 - 1] +".png";
                a = kartenwert.imagepfad(ab);
               
            }
            
            _wert1 = wert1;
            _wert2 = wert2;
            if (kartenbilder.Contains(ab))
            {
                return kartenverteilen();
            }
            else
            {
                kartenbilder.Add(ab);

                return a;
            }
           

        }
        



    }
}
