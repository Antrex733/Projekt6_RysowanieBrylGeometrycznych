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
    public partial class WizualizacjaZłożonychBrył : Form
    {
        Graphics anRysownica, anPowierzchniaGragicznaWziernikaLinii;
        Pen anPióro;
        List<BryłaAbstrakcyjna> anLBG = new List<BryłaAbstrakcyjna>();
        //deklaracja pomocniczej zmeinnej dla rzechowania współrzędnych wybranego munktu rysownicy
        Point anPunktLokalizacjiBryły = new Point(-1, 1);
        public WizualizacjaZłożonychBrył()
        {
            InitializeComponent();
            //ustalenie lokalizacji i rozmiarów pbRysownica
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);

            //utworzenie egzemplarza Rysownicy
            anRysownica = Graphics.FromImage(pbRysownica.Image);

            //sformatowanie Pióra
            anPióro = new Pen(Color.Green, 2f);
            anPióro.DashStyle = DashStyle.Solid;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //wymazanie 'kropki' lokalizacji nowej bryły
            using (SolidBrush anPędzel = new SolidBrush(pbRysownica.BackColor))
            {
                //wymazanie ustalonego wcześniej położenia bryły
                anRysownica.FillEllipse(anPędzel, anPunktLokalizacjiBryły.X - 3,
                                              anPunktLokalizacjiBryły.Y - 3,
                                              6, 6);
            }
            //pobieranie atrybutów ustawionych dla wybranej bryły
            int anWysokośćBryły = trbWysokośćBryły.Value;
            int anPromieńBryły = trbPromieńBryły.Value;
            int anStopieńWielokąta = (int)nudStopieńWielokąta.Value;
            float anKątPochylenia = trbKątNachylenia.Value;
            int anXsP = anPunktLokalizacjiBryły.X;
            int anYsP = anPunktLokalizacjiBryły.Y;
            //rozpoznanie wybranej bryły
            switch (cmbListaBrył.SelectedItem)
            {
                case "Walec":
                    Walec anwalec =
                        new Walec(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                  anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, true);
                    anwalec.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anwalec);
                    break;
                case "Stożek":
                    Stożek anstożek =
                        new Stożek(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                   anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, true);
                    anstożek.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anstożek);
                    break;
                case "Stożek Pochylony":
                    Stożek anstożekpochylony =
                        new StożekPochylony(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta, anKątPochylenia,
                                            anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, true);
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
                case "Podwójny Stożek":
                    StożekPodwójny anstożekpodwójny =
                        new StożekPodwójny(anPromieńBryły, anWysokośćBryły, anStopieńWielokąta,
                                   anXsP, anYsP, anPióro.Color, anPióro.DashStyle, anPióro.Width, true);
                    anstożekpodwójny.Wykreśl(anRysownica);
                    //dodanie egzemplarza Walca do losty LBG
                    anLBG.Add(anstożekpodwójny);
                    break;
                default:
                    break;
            }
            pbRysownica.Refresh();
        }

        private void WizualizacjaZłożonychBrył_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult anwynik = MessageBox.Show("Czy na pewno chcesz zamknąć formularz?", this.Text,
                                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (anwynik != DialogResult.OK)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void WizualizacjaZłożonychBrył_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbListaBrył_SelectedIndexChanged(object sender, EventArgs e)
        {
            trbWysokośćBryły.Enabled = false;
            trbPromieńBryły.Enabled = false;
            nudStopieńWielokąta.Enabled = false;
            trbKątNachylenia.Enabled = false;
            MessageBox.Show("Pamiętaj, że po wyborze bryły geometrycznej i ustawieniu jej " +
                "atrybutów geometrycznych i graficznych 'musisz' ustalić miejsce (lokalizację) " +
                "wykreślenia tej bryły" + " ,a następnie kliknij przycisk: 'Dodaj Nową Bryłę'");
            if (cmbListaBrył.SelectedItem == "Walec" || cmbListaBrył.SelectedItem == "Stożek" || cmbListaBrył.SelectedItem == "Podwójny Stożek") 
            {
                //uaktywniwnie kontrolek dla ustawienia atrybutów geometrycznych
                trbWysokośćBryły.Enabled = true;
                trbPromieńBryły.Enabled = true;
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
                trbKątNachylenia.Enabled = true;
            }
        }

        private void pbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            //zaznaczony punkt wykreślamy o możliwie małych rozmiarach
            using (SolidBrush anPędzel = new SolidBrush(Color.Red))
            {
                if (anPunktLokalizacjiBryły.X != -1)
                {
                    anPędzel.Color = pbRysownica.BackColor;
                    //wymazanie ustalonego wcześniej położenia bryły
                    anRysownica.FillEllipse(anPędzel, anPunktLokalizacjiBryły.X - 3,
                                                  anPunktLokalizacjiBryły.Y - 3,
                                                  6, 6);
                    //przywrócenie pierwotnego koloru pdzla
                    anPędzel.Color = Color.Red;
                }
                //przechowanie współrzędnych miejsca kliknięcia lewym przyciskiem myszy
                anPunktLokalizacjiBryły = e.Location;
                //wykreślenie punktu 'kontrolnego'
                anRysownica.FillEllipse(anPędzel, anPunktLokalizacjiBryły.X - 3,
                                              anPunktLokalizacjiBryły.Y - 3,
                                              6, 6);
                //uaktywnienie przycisku Dodaj Nową Bryłę
                btnDodaj.Enabled = true;
                btnUsuń.Enabled = true;
                btnUsuńWszystkie.Enabled = true;
                btnUsuńPierwszą.Enabled = true;
                btnUsuńWybraną.Enabled = true;
                btnUsuńOstatnią.Enabled = true;
                nudUsuńWybraną.Enabled = true;
                pbRysownica.Refresh();
            }
        }

        private void btnUsuń_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLBG.Count == 0)
            {
                errorProvider1.SetError(btnUsuń, "Rysownica jest pusta!");
                return;
            }

            anLBG[anLBG.Count - 1].Wymaż(pbRysownica, anRysownica);
            anLBG.RemoveAt(anLBG.Count - 1);
            pbRysownica.Refresh();
        }

        private void btnUsuńWszystkie_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLBG.Count == 0)
            {
                errorProvider1.SetError(btnUsuńWszystkie, "Rysownica jest pusta!");
                return;
            }
            for (int i = 0; i < anLBG.Count; i++)
                anLBG[i].Wymaż(pbRysownica, anRysownica);
            anLBG.Clear();
            pbRysownica.Refresh();
        }

        private void btnUsuńPierwszą_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLBG.Count == 0)
            {
                errorProvider1.SetError(btnUsuńPierwszą, "Rysownica jest pusta!");
                return;
            }
            anLBG[0].Wymaż(pbRysownica, anRysownica);
            anLBG.RemoveAt(0);
            pbRysownica.Refresh();
        }

        private void btnUsuńOstatnią_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLBG.Count == 0)
            {
                errorProvider1.SetError(btnUsuńOstatnią, "Rysownica jest pusta!");
                return;
            }
            anLBG[anLBG.Count - 1].Wymaż(pbRysownica, anRysownica);
            anLBG.RemoveAt(anLBG.Count - 1);
            pbRysownica.Refresh();
        }

        private void btnUsuńWybraną_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLBG.Count < nudUsuńWybraną.Value)
            {
                errorProvider1.SetError(btnUsuńWybraną, "Nie wykreśliłeś " + nudUsuńWybraną.Value + " brył!");
                return;
            }
            anLBG[(int)nudUsuńWybraną.Value - 1].Wymaż(pbRysownica, anRysownica);
            anLBG.RemoveAt((int)nudUsuńWybraną.Value - 1);
            pbRysownica.Refresh();
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

       

       
    }
}
