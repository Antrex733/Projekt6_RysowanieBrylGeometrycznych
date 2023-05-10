using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
//using static BryłyGeometryczne.Klasy;//////////////////////
using static Projekt3Nowalski57295.KlasyBryłGeometrycznych;

namespace Projekt3Nowalski57295
{
    public partial class Laboratorium : Form
    {
        Graphics anRysownica, anPowierzchniaGragicznaWziernikaLinii;
        Pen anPióro;
        List<BryłaAbstrakcyjna> anLBG = new List<BryłaAbstrakcyjna>();
        //deklaracja pomocniczej zmeinnej dla rzechowania współrzędnych wybranego munktu rysownicy
        Point anPunktLokalizaacjiBryły = new Point(-1, 1);
        public Laboratorium()
        {
            InitializeComponent();
            //ustalenie lokalizacji i rozmiarów pbRysownica
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);

            //utworzenie egzemplarza Rysownicy
            anRysownica = Graphics.FromImage(pbRysownica.Image);

            //sformatowanie Pióra
            anPióro = new Pen(Color.Black, 1f);
            anPióro.DashStyle = DashStyle.Solid;

            //sformatowanie Wzierników
            pbWziernikKoloruWypełnienia.BorderStyle = BorderStyle.Fixed3D;
            pbWziernikKoloruWypełnienia.BackColor = pbRysownica.BackColor;
            pbWziernikLinii.Image = new Bitmap(Width, Height);
            anPowierzchniaGragicznaWziernikaLinii = Graphics.FromImage(pbWziernikLinii.Image);

            //wykreślenie domyślnego wzorca linii
            WykreślenieWziernikaLinii();
            //Rozmiar i ustawienie formularza

            
        }
        //deklaracja metody pomocniczej
        void WykreślenieWziernikaLinii()
        {
            const int anOdstęp = 5;
            //wyczyszczenie powierzchni graficznej
            anPowierzchniaGragicznaWziernikaLinii.Clear(pbWziernikLinii.BackColor);
            //wykreślenie linii "wzorcowej
            anPowierzchniaGragicznaWziernikaLinii.DrawLine(
                anPióro, anOdstęp, pbWziernikLinii.Height / 2, pbWziernikLinii.Width - 2 * anOdstęp, pbWziernikLinii.Height / 2);
            //odSwierzenie powierzchni graficznej
            pbWziernikLinii.Refresh();
        }

        private void btnPowrót_Click(object sender, EventArgs e)
        {
            foreach (Form anitem in Application.OpenForms)
            {
                if (anitem.Name == "Form1")
                {
                    Hide();
                    anitem.Show();
                    return;
                }
            }
            WizualizacjaBryłGeometrycznych nowy = new WizualizacjaBryłGeometrycznych();
            Hide();
            nowy.Show();
            
        }

        private void kolorLiniiBryłyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog anPaletaKolorów = new ColorDialog();
            anPaletaKolorów.Color = anPióro.Color;
            if (anPaletaKolorów.ShowDialog() == DialogResult.OK)
                anPióro.Color = anPaletaKolorów.Color;
            //uaktualnienie WziernikaLinii
            WykreślenieWziernikaLinii();
            //zwolnienie okna dialogowego
            anPaletaKolorów.Dispose();
        }
        public bool KierunekObrotu()
        {
            if(rbtnLewo.Checked)
                return true;
            return false;
        }
        private void btnDodajNowąBryłę_Click(object sender, EventArgs e)
        {
            //wymazanie 'kropki' lokalizacji nowej bryły
            using (SolidBrush Pędzel = new SolidBrush(pbRysownica.BackColor))
            {
                //wymazanie ustalonego wcześniej położenia bryły
                anRysownica.FillEllipse(Pędzel, anPunktLokalizaacjiBryły.X - 3,
                                              anPunktLokalizaacjiBryły.Y - 3,
                                              6, 6);
            }   
            //pobieranie atrybutów ustawionych dla wybranej bryły
            int anWysokośćBryły = trbWysokośćBryły.Value;
            int anPromieńBryły = trbPromieńBryły.Value;
            int anStopieńWielokąta = (int)nudStopieńWielokąta.Value;
            float anKątPochylenia = trbKątPochyleniaBryły.Value;
            int anXsP = anPunktLokalizaacjiBryły.X;
            int anYsP = anPunktLokalizaacjiBryły.Y;
            //rozpoznanie wybranej bryły
            switch (cmbListaBrył.SelectedItem)
            {
                case "Walec":
                    Walec anwalec = 
                        new Walec(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                  anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, KierunekObrotu());
                    anwalec.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anwalec);
                    break;
                case "Stożek":
                    Stożek anstożek = 
                        new Stożek(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                   anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, KierunekObrotu());
                    anstożek.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anstożek);
                    break;
                case "Stożek Pochylony":
                    Stożek anstożekpochylony = 
                        new StożekPochylony(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta, anKątPochylenia,
                                            anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, KierunekObrotu());
                    anstożekpochylony.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anstożekpochylony);
                    break;
                case "Graniastosłup":
                    Graniastosłup angraniastosłup =
                        new Graniastosłup(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                   anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width);
                    angraniastosłup.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(angraniastosłup);
                    break;
                default:
                    break;
            }
            ZegarObrotu.Enabled = true;
            pbRysownica.Refresh();



        }

        private void ZegarObrotu_Tick(object sender, EventArgs e)
        {
            const float anKątObrotu = 5f;
            //obracamy wszystkie bryły w LBG o kąt obrotu
            for (int i = 0; i < anLBG.Count; i++)
                anLBG[i].Obróć_i_Wykreśl(pbRysownica, anRysownica, anKątObrotu);
            pbRysownica.Refresh();
        }

        private void kolorWypełnieniaBryłyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog anKolor = new ColorDialog();
            anKolor.Color = anPióro.Color;
            if (anKolor.ShowDialog() == DialogResult.OK)
                pbWziernikKoloruWypełnienia.BackColor = anKolor.Color;
            //uaktualnienie WziernikaLinii
            WykreślenieWziernikaLinii();
            anKolor.Dispose();
        }
        //Styl Linii
        private void kropkowaDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anPióro.DashStyle = DashStyle.Dot;
            WykreślenieWziernikaLinii();
        }
        private void kreskowokropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anPióro.DashStyle = DashStyle.DashDot;
            WykreślenieWziernikaLinii();
        }
        private void kreskowoKropkowoKropkowaDashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anPióro.DashStyle = DashStyle.DashDotDot;
            WykreślenieWziernikaLinii();
        }
        private void liniaCągłaSolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anPióro.DashStyle = DashStyle.Solid;
            WykreślenieWziernikaLinii();
        }
        private void kreskowaDashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anPióro.DashStyle = DashStyle.Dash;
            WykreślenieWziernikaLinii();
        }

        
        //menu strip grubość linii
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            anPióro.Width = 1f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            anPióro.Width = 2f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            anPióro.Width = 3f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            anPióro.Width = 4f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            anPióro.Width = 5f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            anPióro.Width = 6f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            anPióro.Width = 7f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            anPióro.Width = 8f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            anPióro.Width = 9f;
            WykreślenieWziernikaLinii();
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            anPióro.Width = 10f;
            WykreślenieWziernikaLinii();
        }

        //zamknięcie programu
        private void Laboratorium_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Laboratorium_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zamknąć formularz?", this.Text,
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (wynik != DialogResult.OK)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void cmbListaBrył_SelectedIndexChanged(object sender, EventArgs e)
        {
            trbWysokośćBryły.Enabled = false;
            trbPromieńBryły.Enabled = false;
            nudStopieńWielokąta.Enabled = false;
            rbtnLewo.Enabled = false;
            rbtnPrawo.Enabled = false;
            trbKątPochyleniaBryły.Enabled = false;
            MessageBox.Show("Pamiętaj, że po wyborze bryły geometrycznej i ustawieniu jej " + 
                "atrybutów geometrycznych i graficznych 'musisz' ustalić miejsce (lokalizację) "+
                "wykreślenia tej bryły"+ " ,a następnie kliknij przycisk: 'Dodaj Nową Bryłę'");
            if (cmbListaBrył.SelectedItem == "Walec" || cmbListaBrył.SelectedItem == "Stożek")
            {
                //uaktywniwnie kontrolek dla ustawienia atrybutów geometrycznych
                trbWysokośćBryły.Enabled = true;
                trbPromieńBryły.Enabled = true;
                rbtnLewo.Enabled = true;
                rbtnPrawo.Enabled = true;
            }
            else
                if (cmbListaBrył.SelectedItem == "Graniastosłup")
                {
                //uaktywniwnie kontrolek dla ustawienia atrybutów geometrycznych
                trbWysokośćBryły.Enabled = true;
                trbPromieńBryły.Enabled = true;
                nudStopieńWielokąta.Enabled = true;
                }
            else
            if (cmbListaBrył.SelectedItem == "Stożek Pochylony")
            {
                trbWysokośćBryły.Enabled = true;
                trbPromieńBryły.Enabled = true;
                trbKątPochyleniaBryły.Enabled = true;
                rbtnLewo.Enabled = true;
                rbtnPrawo.Enabled = true;
            }
        }


        private void pbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            //zaznaczony punkt wykreślamy o możliwie małych rozmiarach
            using (SolidBrush anPędzel = new SolidBrush(Color.Red))
            {
                if (anPunktLokalizaacjiBryły.X != -1)
                {
                    anPędzel.Color = pbRysownica.BackColor;
                    //wymazanie ustalonego wcześniej położenia bryły
                    anRysownica.FillEllipse(anPędzel, anPunktLokalizaacjiBryły.X - 3,
                                                  anPunktLokalizaacjiBryły.Y - 3,
                                                  6, 6);
                    //przywrócenie pierwotnego koloru pdzla
                    anPędzel.Color = Color.Red;
                }
                //przechowanie współrzędnych miejsca kliknięcia lewym przyciskiem myszy
                anPunktLokalizaacjiBryły = e.Location;
                //wykreślenie punktu 'kontrolnego'
                anRysownica.FillEllipse(anPędzel, anPunktLokalizaacjiBryły.X - 3, 
                                              anPunktLokalizaacjiBryły.Y - 3,
                                              6, 6);
                //uaktywnienie przycisku Dodaj Nową Bryłę
                btnDodajNowąBryłę.Enabled = true;
                btnUsuńBryłę.Enabled = true;
                pbRysownica.Refresh();
            }
        }

        private void btnUsuńBryłę_Click(object sender, EventArgs e)
        {
            if (anLBG.Count == 0)
            {
                errorProvider1.SetError(btnUsuńBryłę, "Rysownica jest pusta!");
                return;
            }

            anLBG[anLBG.Count - 1].Wymaż(pbRysownica, anRysownica);
            anLBG.RemoveAt(anLBG.Count - 1);
        }


        //zmiana koloru pbRysownicy
        private void kolorTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog Kolor = new ColorDialog();
            if (Kolor.ShowDialog() == DialogResult.OK)
            {
                pbRysownica.BackColor = Kolor.Color;
                WykreślenieWziernikaLinii();
            }
            Kolor.Dispose();
        }

       

        

    }
}
