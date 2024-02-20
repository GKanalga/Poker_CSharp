using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class game
    {
        private int _mitteeinsatz = 0;
        public int Mitteeinsatz { get { return _mitteeinsatz; } set { _mitteeinsatz = value; } }



        public void plusmitte(int erhoehung)
        {
            _mitteeinsatz = _mitteeinsatz + erhoehung;

        }
        public void  zweiterunde(PictureBox h1, PictureBox h2, PictureBox h3, List<Image> images)
        {
            h1.Image = images[2];
            h2.Image = images[3];
            h3.Image = images[4];

        }

        public void dritterunde(PictureBox h4, List<Image> images) { 
            h4.Image = images[5];
}

        public void vierterunde(PictureBox h5, List<Image> images)
        {
            h5.Image = images[6];
        }

        public void fuenfterunde(PictureBox h6,PictureBox h7,List<Image> images)
        {
            h6.Image = images[7];
            h7.Image = images[8];
        }







    }
}
