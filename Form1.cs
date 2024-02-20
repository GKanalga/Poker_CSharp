namespace Poker
{
    public partial class Form1 : Form
    {
        Spieler player = new Spieler();
        game game = new game();
        gegner gegner = new gegner();
        Karten kartenn = new Karten();

        KartenWert kw = new KartenWert();
        List<int> wertspieler = new List<int>();
        List<int> farbespieler = new List<int>();
        List<int> farbegegner = new List<int>();
        List<int> farbemitte = new List<int>();
        List<int> wertmitte = new List<int>();
        List<int> wertgegner = new List<int>();
        List<Image> images = new List<Image>();
        public int roundcount = 0;
        public bool loop = false;
        public int runde = 1;

        public Form1()
        {
            InitializeComponent();

            
                gth_txt.Text = "Guthaben: " + player.Guthaben;
                pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
                Mitkommen.Visible = false;
                shuffelcards();
                checkhands();
                roundcount = 0;


        }
        public void spiel()
        {
            runde++;
            gth_txt.Text = "Guthaben: " + player.Guthaben;
            pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
            gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
            if(gegner.gegnerguthaben <= 0)
            {
                MessageBox.Show("Gratuliere du hast den Gegner besiegt");
                Application.Exit();
            }
            if(player.Guthaben <= 0)
            {
                MessageBox.Show("Du hast Verloren");
                Application.Exit();
            }
            Mitkommen.Visible = false;
            kw.newround();
            kartenn.newround();
            images.Clear();
            wertspieler.Clear();
            wertgegner.Clear(); 
            wertmitte.Clear();
            farbespieler.Clear();
            farbemitte.Clear();
            farbegegner.Clear();
            shuffelcards();
            checkhands();
            roundcount = 0;
            round_txt.Text = "Runde: " + runde;
        }
        public void shuffelcards()
        {
            for (int i = 1; i <= 9; i++)
            {
                images.Add(kartenn.kartenverteilen());


                if (i <= 2 && i > 0)
                {

                    wertspieler.Add(kartenn._wert1);
                    farbespieler.Add(kartenn._wert2);
                }

                if (i > 2 && i <= 7)
                {

                    wertmitte.Add(kartenn._wert1);
                    farbemitte.Add(kartenn._wert2);
                }

                if (i <= 9 && i > 7)
                {
                    wertgegner.Add(kartenn._wert1);
                    farbegegner.Add(kartenn._wert2);
                }


            }
            H1.Image = images[0];
            H2.Image = images[1];

            H3.Image = Image.FromFile(@"Karten\Back1.jpg");
            H4.Image = Image.FromFile(@"Karten\Back1.jpg");
            H5.Image = Image.FromFile(@"Karten\Back1.jpg");
            H6.Image = Image.FromFile(@"Karten\Back1.jpg");
            H7.Image = Image.FromFile(@"Karten\Back1.jpg");
            H8.Image = Image.FromFile(@"Karten\Back1.jpg");
            H9.Image = Image.FromFile(@"Karten\Back1.jpg");
          
           
            kw.getgegnerwert(wertgegner);
            kw.getspielerwertt(wertspieler);
            kw.getmittwert(wertmitte);
            kw.getfarbemitte(farbemitte);
            kw.getfarbespieler(farbespieler);
            kw.getfarbegegner(farbegegner);

        }
        public void checkhands()
        {


            kw.checkvierling();
            kw.checkflush();
            kw.checkstreet();
            kw.checkdrilling();
            kw.checkdoublepair();
            // kw.checkfullhouse();
            kw.checkpair();

        }
        private void erhohe_Click(object sender, EventArgs e)
        {
            bool ab = false;
            bool b = false;
            bool c = false;

            if (werter.Value > 0 && player.Guthaben >= werter.Value && gegner.gegnerguthaben >= werter.Value)
            {
                player.minusguthaben(Convert.ToInt32(werter.Value));
                game.plusmitte(Convert.ToInt32(werter.Value));

                gth_txt.Text = "Guthaben: " + player.Guthaben;
                pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                ab = true;
                Thread.Sleep(800);
            }

            else if(werter.Value ==0)
            {
                MessageBox.Show("Wert muss höcher als 0 sein");

            }
            else
            {
                MessageBox.Show("zu hoher wert");
                c = true;
            }

            if (c == false)
            {
                if (ab == true)
                {
                    if (gegner.kommemit(kw, Convert.ToInt32(werter.Value), player) == false)
                    {

                        MessageBox.Show("Gegner steigt aus :(");
                        player.Guthaben += game.Mitteeinsatz;
                        game.Mitteeinsatz = 0;
                        gth_txt.Text = "Guthaben: " + player.Guthaben;
                        pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                        gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
                        b = true;
                        Thread.Sleep(800);
                        spiel();
                    }
                    else
                    {
                        game.plusmitte(Convert.ToInt32(werter.Value));
                    }
                }

                if (b == false)
                {


                    pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                    gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;

                    if (roundcount == 0)
                    {
                        game.zweiterunde(H3, H4, H5, images);
                        roundcount++;

                    }
                    else if (roundcount == 1)
                    {
                        game.dritterunde(H6, images);
                        roundcount++;
                    }
                    else if (roundcount == 2)
                    {
                        game.vierterunde(H7, images);
                        roundcount++;
                    }
                    else if (roundcount == 3)
                    {
                        game.fuenfterunde(H8, H9, images);
                        Thread.Sleep(800);
                        kw.showdown(player, gegner, game, gegnerface, Stimmung);
                        gth_txt.Text = "Guthaben: " + player.Guthaben;
                        pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                        gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
                        spiel();
                    }
                }



            }
            
        }

        private void M4_Click(object sender, EventArgs e)
        {

        }

        private void UH1_Click(object sender, EventArgs e)
        {

        }

        private void UH2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void outt_Click(object sender, EventArgs e)
        {
            
            gegner.gegnerguthaben = gegner.gegnerguthaben + game.Mitteeinsatz;
            game.Mitteeinsatz = 0;
            erhohe.Visible = true;
            check.Visible = true;
            werter.Visible = true;
            pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
            gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
            spiel();
            

        }

        private void check_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            bool s = false;

            if (gegner.gegnerguthaben > 0 && player.Guthaben > 0)
            {
                if (gegner.ermittleoberhöhe(kw, player) == true && player.Guthaben >0)
                {
                    Mitkommen.Visible = true;
                    erhohe.Visible = false;
                    check.Visible = false;
                    werter.Visible = false;
                    game.Mitteeinsatz += gegner.gegnererhoehe;
                    gegner_gth.Text = "Gegnerguthaben:" + gegner.gegnerguthaben;
                    pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;


                }
                else
                {
                    s = true;
                }
            }
            else
            {
                s = true;
            }

                if (roundcount == 0 && s == true )
                {
                    game.zweiterunde(H3, H4, H5, images);
                    roundcount++;
                }
                else if (roundcount == 1 && s == true)
                {
                    game.dritterunde(H6, images);
                    roundcount++;
                }
                else if (roundcount == 2 && s == true)
                {
                    game.vierterunde(H7, images);
                    roundcount++;
                }
                else if (roundcount == 3 && s == true)
                {
                    game.fuenfterunde(H8, H9, images);
                    Thread.Sleep(800);
                    kw.showdown(player, gegner, game, gegnerface, Stimmung);
                    gth_txt.Text = "Guthaben: " + player.Guthaben;
                    pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                    gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;

                    spiel();

                }
            
        }

        private void Mitkommen_Click(object sender, EventArgs e)
        {
            Thread.Sleep(800);
            if (player.Guthaben >= gegner.gegnererhoehe)
            {
                Mitkommen.Visible = false;
                erhohe.Visible = true;
                check.Visible = true;
                werter.Visible = true;
                player.minusguthaben(gegner.gegnererhoehe);
                game.plusmitte(gegner.gegnererhoehe);
                gth_txt.Text = "Guthaben: " + player.Guthaben;
                pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;

            }
            if (roundcount == 0)
            {
                game.zweiterunde(H3, H4, H5, images);
                roundcount++;
            }
            else if (roundcount == 1)
            {
                game.dritterunde(H6, images);
                roundcount++;
                  
            }
            else if (roundcount == 2)
            {
                game.vierterunde(H7, images);
                roundcount++;
            }
            else if (roundcount == 3)
            {
                game.fuenfterunde(H8, H9, images);
                Thread.Sleep(800);
                kw.showdown(player, gegner, game, gegnerface, Stimmung);
                gth_txt.Text = "Guthaben: " + player.Guthaben;
                pot_txt.Text = "Mitte Einsatz: " + game.Mitteeinsatz;
                gegner_gth.Text = "Gegnerguthaben: " + gegner.gegnerguthaben;
                spiel();
            }


        }

        private void H8_Click(object sender, EventArgs e)
        {

        }

        private void Regeln_btn_Click(object sender, EventArgs e)
        {
            Regel r = new Regel();

            r.showregel();
        }
    }
}