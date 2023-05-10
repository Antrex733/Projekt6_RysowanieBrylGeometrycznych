using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//dodanie przestrzeni nazw
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Projekt3Nowalski57295
{
    public class KlasyBryłGeometrycznych //internal???
    {
        const float anKątProsty = 90.0f;
        //deklaracja klasy abstrakcyjnej
        public abstract class BryłaAbstrakcyjna
        {//deklaracja typu wyliczeniowego, którego elementy będą "znacznikami" wpisywanymi w egzemplarzu każdej bryły do pola RodzajBryły

            public enum anTypyBrył
            { anBG_Walec, anBG_Stożek, anBG_Kula, anBG_Ostrosłup, anBG_Graniastosłup, anBG_Sześcian, anBG_StożekPochylony };
            //deklaracja zmiennych dla wspólnych atrybutów geometrycznych
            protected int anXsP, anYsP;
            protected int anWysokośćBryły;
            protected float anKątPochylenia = 90.0f;
            protected bool anWidoczny;
            //deklaracja zmiennych dla wspólnych atrybutów graficznych
            protected Color anKolor_Linii;
            protected DashStyle anStyl_Linii;
            protected float anGrubość_Linii;
            //deklaracja zmiennych dla implementacji przyszłych funkcjalności
            public anTypyBrył anRodzajBryły;
            protected bool anKierunekObrotu; // false: w prawo, true: w lewo;
            protected float anPowierzchniaBryły;
            protected float anObjętośćBryły;
            //deklaracja konstruktora
            public BryłaAbstrakcyjna(Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii)
            {
                anKolor_Linii = anKolorLinii;
                anStyl_Linii = anStylLinii;
                anGrubość_Linii = anGrubośćLinii;
                anKątPochylenia = anKątProsty;
            }
            //deklaracja meto abstrakcyjnych (dla których nie jesteśmy w stanie zapisać ich implementacji)
            public abstract void Wykreśl(Graphics anRysownica);
            public abstract void Wymaż(Control anKontrolka, Graphics anRysownica);
            public abstract void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu);
            public abstract void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY);
            //deklaracja metod publicznych z ich pełną implementacją
            public void UstalAtrybutyGraficzne(Color anKolorLinii, DashStyle anStylLinii, int anGrubośćLinii)
            {
                anKolor_Linii = anKolorLinii;
                anStyl_Linii = anStylLinii;
                anGrubość_Linii = anGrubośćLinii;
            }

        }//od klasy BryłaAbstrakcyjna
        //deklaracja klasy Bryły Obrotowe
        public class BryłyObrotowe: BryłaAbstrakcyjna
        {
            protected int anPromieńBryły;
            //deklaracja konstruktora
            public BryłyObrotowe(int anR, Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii):
                base(anKolorLinii, anStylLinii, anGrubośćLinii)
            {
                //zapisanie (przechowanie) promienia r
                anPromieńBryły = anR;
            }
            //naddpisanie WSZYSTKICH metod abstrakcyjnych z klasy BryłaAbstrakcyjna
            public override void Wykreśl(Graphics anRysownica)
            {

            }
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                
            }
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                
            }
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                
            }

        }//od BryłyObrotowe
        //deklaracja klasy potomnej Walec
        public class Walec: BryłyObrotowe
        {
            //deklaracje uzupełniające dla bryły Walec
            Point[] anWielokątPodłogi; // podastawy Walca
            Point[] anWielokątSufitu; //druga podstawa Walca
            int anXsS, anYsS;
            //stopień wielokątapodstawy i sufitu Walca
            ////...////// 
            int anStopieńWielokątaPodstawy;
            float anOś_duża, anOś_mała;
            //kąt środkowy między wierzchołkami wielokąta podstawy
            float anKątMiędzyWierzchołkami;
            //kąt położenia pierwszego wierzchołka wielokąta podstawy
            float anKątPołożenia;
            //wektor przesunięcia środka sufitu pochylonego Walca
            int anWektorPrzesunięciaŚrodkaSufituWalca;
            //deklaracja konstruktora
            public Walec(int anR, int anWysokośćWalca, int anStopieńWielokątaPodstawy,
                        int anXsP, int anYsP, Color anKolorLinii,
                        DashStyle anStylLinii, float anGrubośćLinii, bool anKierunekObrotu):
                base(anR, anKolorLinii, anStylLinii, anGrubośćLinii)
            {//ustawienie roddzaju bryły
                anRodzajBryły = anTypyBrył. anBG_Walec;
                anWidoczny = false;
                this.anKierunekObrotu = anKierunekObrotu;
                anWysokośćBryły = anWysokośćWalca;
                this.anXsP = anXsP; this.anYsP = anYsP;
                this.anStopieńWielokątaPodstawy = anStopieńWielokątaPodstawy;

                //wyznaczenie osi elipsy wykreślanej w "podłoddze" i  "suficie" Walca
                anOś_duża = anR * 2; 
                anOś_mała = anR / 2;

                anXsS = anXsP;//??????
                /*
                //sprawdzenie pochylenia Walca 
                if (KątPochylenia == KątProsty)
                    XsS = base.XsP;
                else
                    MessageBox.Show("Sory: pracuję nad tą możliwością");
                */

                //wyznaczenie pozostałych współrzędnych środka sufitu Walca
                anYsS = anYsP - anWysokośćWalca;

                //wyznaczenie kąta kątów położenia
                anKątMiędzyWierzchołkami = 360 / anStopieńWielokątaPodstawy;
                anKątPołożenia = 0f;
                //wyznaczenie współrzędnych punktów w "podłoddze" i "suficie"
                //dla wykreślania prążków na ścianie bocznej Walca
                anWielokątPodłogi = new Point[anStopieńWielokątaPodstawy + 1];
                anWielokątSufitu = new Point[anStopieńWielokątaPodstawy + 1];
                //utworzenie egzemplarzy punktów w "podłoddze" i "suficie"
                //oraz wpisanie do nich wyznaczonych współrzędnych na obwodzie Elipsy
                for (int i = 0; i < anStopieńWielokątaPodstawy; i++)
                {
                    anWielokątPodłogi[i] = new Point();
                    anWielokątSufitu[i] = new Point();
                    // "podłoga" Walca:
                    //Równanie parametryczne okręgu: Xi == Xs + R*cos(Pi), Yi = Ys + R*sin(Pi)
                    //Równanie parametryczne elipsy: Xi == Xs + Oś_Duża/2*cos(Pi), Yi = Ys + Oś_Mała/2*sin(Pi)
                    anWielokątPodłogi[i].X = (int)(base.anXsP + anOś_duża / 2 
                        * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) /180f));
                    anWielokątPodłogi[i].Y = (int)(base.anYsP + anOś_mała / 2
                        * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                    // "sufit" Walca:
                    anWielokątSufitu[i].X = (int)(anXsS + anOś_duża/2 
                        * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));
                    anWielokątSufitu[i].Y = (int)(base.anYsP + anOś_mała / 2
                        * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                }// od for
                //obliczenie powierzchni Walca
                //....
                //obliczenie objętości Walca
                //....

            }//od konstruktora Walca
            //nadpisanie metod abstrakcyjnych zadeklarowanych w klasie abstrakcyjnej
            public override void Wykreśl(Graphics anRysownica)
            {
                anWidoczny = true;
                using(Pen Pióro = new Pen(anKolor_Linii, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //wykreślanie "podłogi" Walca
                    anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2, anOś_duża, anOś_mała);
                    //wykreślanie "sufitu" Walca
                    anRysownica.DrawEllipse(Pióro, anXsS - anOś_duża / 2, anYsS - anOś_mała / 2, anOś_duża, anOś_mała);
                    //wykreślenie próżków na ścuanie bocznej Walca
                    using (Pen PióroPrążków = new Pen(anKolor_Linii, 1))
                    {
                        PióroPrążków.DashStyle = DashStyle.Dot;
                        //wykreślenie prążków na ścianie bocznej Walca
                        for (int i = 0; i < anStopieńWielokątaPodstawy; i++)
                            anRysownica.DrawLine(PióroPrążków, anWielokątPodłogi[i], anWielokątSufitu[i]);

                    }//od using PióroPrążków

                    //wykreślenie lewej krawędzi bocznej Walca
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS - anOś_duża/2, anYsS);
                    //wykreślenie prawej krawędzi bocznej Walca
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS + anOś_duża/2, anYsS);
                    
                }//od using Pióro
            }
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen Pióro = new Pen(anKontrolka.BackColor, anGrubość_Linii))
                    {
                        Pióro.DashStyle = anStyl_Linii;
                        //wykreślanie "podłogi" Walca
                        anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2, anOś_duża, anOś_mała);
                        //wykreślanie "sufitu" Walca
                        anRysownica.DrawEllipse(Pióro, anXsS - anOś_duża / 2, anYsS - anOś_mała / 2, anOś_duża, anOś_mała);
                        //wykreślenie próżków na ścuanie bocznej Walca
                        using (Pen PióroPrążków = new Pen(anKontrolka.BackColor, 0.5f))
                        {
                            PióroPrążków.DashStyle = DashStyle.Dot;
                            //wykreślenie prążków na ścianie bocznej Walca
                            for (int i = 0; i < anStopieńWielokątaPodstawy; i++)
                                anRysownica.DrawLine(PióroPrążków, anWielokątPodłogi[i], anWielokątSufitu[i]);

                        }//od using PióroPrążków

                        //wykreślenie lewej krawędzi bocznej Walca
                        anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS - anOś_duża / 2, anYsS);
                        //wykreślenie prawej krawędzi bocznej Walca
                        anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS + anOś_duża / 2, anYsS);
                    }
                }
            }//od Wymaż
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                //obracamy tylko bryłę, która jest wykreślona, czyli widoczna
                if(anWidoczny)
                {
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczenie nowego położenia pierwszego wierzchołka wielokoąta wpisanego w elipsę "podłogi"
                    if (anKierunekObrotu)
                        anKątPołożenia -= anKątObrotu;
                    else
                        anKątPołożenia += anKątObrotu;
                    //wyznaczenie nowych wartości dla współrzędnych wszystkich wierzchołków wielokąta "podłogi"
                    for (int i = 0; i < anStopieńWielokątaPodstawy; i++)
                    {
                        
                        // "podłoga" Walca:
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2
                            * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2
                            * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                        // "sufit" Walca:
                        anWielokątSufitu[i].X = (int)(anXsS + anOś_duża / 2
                            * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));
                        anWielokątSufitu[i].Y = (int)(anYsS + anOś_mała / 2
                            * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                    }// od for
                    //wykreślenie Walca po obrocie
                    Wykreśl(anRysownica);
                }//od if
            }//od Obróć_i_Wykreśl
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                //przesuwamy tylko bryłę, która jest wykreślona, czyli widoczna
                if (anWidoczny)
                {
                    //deklaracja zmiennych pomocniczych dla wyznaczenia wektora przesunięcia
                    int dX, dY;
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczenie wektora przesunięcia
                    dX = anXsP < anX ? anX - anXsP : -(anXsP - anX);
                    dY = anYsP < anY ? anY - anYsP : -(anYsP - anY);
                    //wyznaczamy nowe położenie dla środka 'podłogi' oraz 'sufitu'
                    anXsP = anXsP + dX;
                    anYsP = anYsP + dY;
                    anXsS = anXsS + dX;
                    anYsS = anYsS + dY;

                    //wyznaczenie nowych wartości dla współrzędnych wszystkich wierzchołków wielokąta "podłogi"
                    for (int i = 0; i < anStopieńWielokątaPodstawy; i++)
                    {

                        // "podłoga" Walca:
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2
                            * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2
                            * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                        // "sufit" Walca:
                        anWielokątSufitu[i].X = (int)(anXsS + anOś_duża / 2
                            * Math.Cos(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));
                        anWielokątSufitu[i].Y = (int)(anYsP + anOś_mała / 2
                            * Math.Sin(Math.PI * (anKątPołożenia + i * anKątMiędzyWierzchołkami) / 180f));

                    }// od for
                    //wykreślenie Walca po obrocie
                    Wykreśl(anRysownica);

                }//od if(Widoczny)

            }// od PrzesuńDoNowegoXY

        }// od Walca
        public class Stożek: BryłyObrotowe
        {
            //deklaracje uzupełniające dla bryły Stożek
            protected int anXsS, anYsS;//wierzchołek Stożka
            protected int anStopienWielokataPodstawy;
            protected int anOś_duża, anOś_mała;
            protected float anKątŚrodkowyMiędzyWierzchołkami;
            protected float anKątPołożeniaPierwszegoWierzchołka;
            //int KątPołożenia; // pierwszego wierzchołka wielokąta podstawy Stożka
            //deklaracja tablicy dla przechowania referancji do egzemplarzy wierzchołków wielokąta podstawy Stożka
            Point[] anWielokątPodłogi;
            //deklaracja konstruktora klasy Stożek
            public Stożek(int anR, int anWysokośćStożka, int anStopienWielokata,
                int anXsP, int anYsP, Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii, bool anKierunekObrotu)
                :base(anR, anKolorLinii, anStylLinii, anGrubośćLinii)
            {
                anRodzajBryły = anTypyBrył.anBG_Stożek;
                anWidoczny = false;
                this.anKierunekObrotu = anKierunekObrotu;
                anWysokośćBryły = anWysokośćStożka;
                this.anStopienWielokataPodstawy = anStopienWielokata;
                anOś_duża = anR * 2;
                anOś_mała = anR / 2;
                this.anXsP = anXsP;
                this.anYsP = anYsP;
                //wyznaczenie współrzędnych wierzchołka Stożka
                anXsS = anXsP;
                anYsS = anYsP - anWysokośćStożka;
                anOś_duża = 2 * anR;
                anOś_mała = anR / 2;
                anKątPołożeniaPierwszegoWierzchołka = 0f;
                //KątPołożenia = 2;
                anKątŚrodkowyMiędzyWierzchołkami = 360 / anStopienWielokata;//Stopień Wielokąta???
                anWielokątPodłogi = new Point[anStopienWielokataPodstawy];
                //wyznaczenie współrzędnych wierzchołków wielokąta podstawy Stożka
                for (int i = 0; i < anStopienWielokataPodstawy; i++)
                {
                    anWielokątPodłogi[i] = new Point();
                    //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                    //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                    //                                   Yi = YsP+ Oś_mała * sin(Fi)
                    anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI * 
                        (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI * 
                        (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                }
                //obliczenie pola powierzchni stożka
                //.  .  .

                //obliczenia objętośći stożka
                //.  .  . 

            }//od konstruktora Stożka
            //nadpisanie metod abstrakcyjnych, które zostały zadeklarowane w głównej klasie bazowej
            public override void Wykreśl(Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKolor_Linii, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //wykreślenie podstawy Stożka
                    anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                 anOś_duża, anOś_mała);
                    //wykreślenie "prążków" (lini)
                    using (Pen PióroPróążków = new Pen(Pióro.Color, Pióro.Width / 3))
                    {
                        for (int i = 0; i < anStopienWielokataPodstawy; i++)
                            anRysownica.DrawLine(PióroPróążków, anWielokątPodłogi[i], new Point(anXsS, anYsS));
                        
                    }// koniec using PióroPrążków
                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża/2, anYsP, anXsS, anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża/2, anYsP, anXsS, anYsS);

                    anWidoczny = true;
                }// koniec using Pióro
            }// od Wykreśl
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen Pióro = new Pen(anKontrolka.BackColor, anGrubość_Linii))
                    {
                        Pióro.DashStyle = anStyl_Linii;
                        //wykreślenie podstawy Stożka
                        anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                     anOś_duża, anOś_mała);
                        //wykreślenie "prążków" (lini)
                        using (Pen PióroPróążków = new Pen(Pióro.Color, Pióro.Width / 3))
                        {
                            for (int i = 0; i < anStopienWielokataPodstawy; i++)
                                anRysownica.DrawLine(PióroPróążków, anWielokątPodłogi[i], new Point(anXsS, anYsS));

                        }// koniec using PióroPrążków
                         //wykreślenie lewej krawędzi bocznej
                        anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsS);
                        //wykreślenie prawej krawędzi bocznej
                        anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsS);

                        anWidoczny = true;
                    }// koniec using Pióro
                }
            }//od Wymaż
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                if (anWidoczny)
                {
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczenie nowego kąta położenia wierzchołka wielokąta podstawy
                    if (anKierunekObrotu)
                        anKątŚrodkowyMiędzyWierzchołkami -= anKątObrotu;
                    else
                        anKątŚrodkowyMiędzyWierzchołkami += anKątObrotu;
                    //wyznaczenie nowych współrzędnych dla wierzchołków wielokąta podstawy
                    for (int i = 0; i < anStopienWielokataPodstawy; i++)
                    {
                        //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                        //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                        //                                   Yi = YsP+ Oś_mała * sin(Fi)
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                         (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    }
                    //wykreślenie Stożka po obrocie
                    Wykreśl(anRysownica);
                }
            }// od Obróć_i_Wykreśl
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                if (anWidoczny)
                {
                    int dX, dY;
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczanie przyrostów zmian dX i dY
                    dX = anXsP < anX? anX - anXsP : - (anXsP - anX);
                    dY = anYsP < anY? anY - anYsP : - (anYsP - anY);
                    // ustalenie nowych współrzędnych dla środka podstawy Stożka i jego wierzchołka
                    anXsP = anXsP + dX;
                    anYsP = anYsP + dY;
                    anXsS = anXsS + dX;
                    anYsS = anYsS + dY;
                    //wyznaczenie nowego położenia dla wszystkich wierzvhołków wielokąta podstawy
                    for (int i = 0; i < anStopienWielokataPodstawy; i++)
                    {
                        anWielokątPodłogi[i] = new Point();
                        //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                        //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                        //                                   Yi = YsP+ Oś_mała * sin(Fi)
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    }
                    Wykreśl(anRysownica);

                }// od if

            }// od PrzesuńDoNowegoXY

        }// od Stożka
        public class StożekPochylony : Stożek
        {
 
            //int KątPołożenia; // pierwszego wierzchołka wielokąta podstawy Stożka
            //deklaracja tablicy dla przechowania referancji do egzemplarzy wierzchołków wielokąta podstawy Stożka
            Point[] anWielokątPodłogi;
            //deklaracja konstruktora klasy Stożek
            public StożekPochylony(int anR, int anWysokośćStożka, int anStopienWielokata, float anKątPochyleniaStożka,
                int anXsP, int anYsP, Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii, bool anKierunekObrotu)
                : base(anR, anWysokośćStożka, anStopienWielokata,
                       anXsP, anYsP, anKolorLinii, anStylLinii, anGrubośćLinii, anKierunekObrotu)
            {
                anRodzajBryły = anTypyBrył.anBG_StożekPochylony ;
                anWidoczny = false;

                //wyznaczenie współrzędnych wierzchołka Stożka przesuniętego względem środka 'podłogi' Stożka
                anXsS = anXsP + (int)(anWysokośćStożka / Math.Tan(Math.PI * anKątPochyleniaStożka/180f));
                anYsS = anYsP - anWysokośćStożka;
                anOś_duża = 2 * anR;
                anOś_mała = anR / 2;
                anKątPołożeniaPierwszegoWierzchołka = 0f;
                //KątPołożenia = 2;
                anKątŚrodkowyMiędzyWierzchołkami = 360 / anStopienWielokata;//Stopień Wielokąta???
                anWielokątPodłogi = new Point[anStopienWielokataPodstawy];
                //wyznaczenie współrzędnych wierzchołków wielokąta podstawy Stożka
                for (int i = 0; i < anStopienWielokataPodstawy; i++)
                {
                    anWielokątPodłogi[i] = new Point();
                    //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                    //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                    //                                   Yi = YsP+ Oś_mała * sin(Fi)
                    anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                        (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                        (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                }
                //obliczenie pola powierzchni stożka
                //.  .  .

                //obliczenia objętośći stożka
                //.  .  . 

            }//od konstruktora Stożka
            //nadpisanie metod abstrakcyjnych, które zostały zadeklarowane w głównej klasie bazowej
            public override void Wykreśl(Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKolor_Linii, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //wykreślenie podstawy Stożka
                    anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                 anOś_duża, anOś_mała);
                    //wykreślenie "prążków" (lini)
                    using (Pen PióroPróążków = new Pen(Pióro.Color, Pióro.Width / 3))
                    {
                        for (int i = 0; i < anStopienWielokataPodstawy; i++)
                            anRysownica.DrawLine(PióroPróążków, anWielokątPodłogi[i], new Point(anXsS, anYsS));

                    }// koniec using PióroPrążków
                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsS);

                    anWidoczny = true;
                }// koniec using Pióro
            }// od Wykreśl
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen Pióro = new Pen(anKontrolka.BackColor, anGrubość_Linii))
                    {
                        Pióro.DashStyle = anStyl_Linii;
                        //wykreślenie podstawy Stożka
                        anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                     anOś_duża, anOś_mała);
                        //wykreślenie "prążków" (lini)
                        using (Pen PióroPróążków = new Pen(Pióro.Color, Pióro.Width / 3))
                        {
                            for (int i = 0; i < anStopienWielokataPodstawy; i++)
                                anRysownica.DrawLine(PióroPróążków, anWielokątPodłogi[i], new Point(anXsS, anYsS));

                        }// koniec using PióroPrążków
                         //wykreślenie lewej krawędzi bocznej
                        anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsS);
                        //wykreślenie prawej krawędzi bocznej
                        anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsS);

                        anWidoczny = true;
                    }// koniec using Pióro
                }
            }//od Wymaż
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                if (anWidoczny)
                {
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczenie nowego kąta położenia wierzchołka wielokąta podstawy
                    if (anKierunekObrotu)
                        anKątŚrodkowyMiędzyWierzchołkami -= anKątObrotu;
                    else
                        anKątŚrodkowyMiędzyWierzchołkami += anKątObrotu;
                    //wyznaczenie nowych współrzędnych dla wierzchołków wielokąta podstawy
                    for (int i = 0; i < anStopienWielokataPodstawy; i++)
                    {
                        //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                        //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                        //                                   Yi = YsP+ Oś_mała * sin(Fi)
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                         (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    }
                    //wykreślenie Stożka po obrocie
                    Wykreśl(anRysownica);
                }
            }// od Obróć_i_Wykreśl
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                if (anWidoczny)
                {
                    int dX, dY;
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczanie przyrostów zmian dX i dY
                    dX = anXsP < anX ? anX - anXsP : -(anXsP - anX);
                    dY = anYsP < anY ? anY - anYsP : -(anYsP - anY);
                    // ustalenie nowych współrzędnych dla środka podstawy Stożka i jego wierzchołka
                    anXsP = anXsP + dX;
                    anYsP = anYsP + dY;
                    anXsS = anXsS + dX;
                    anYsS = anYsS + dY;
                    //wyznaczenie nowego położenia dla wszystkich wierzvhołków wielokąta podstawy
                    for (int i = 0; i < anStopienWielokataPodstawy; i++)
                    {
                        anWielokątPodłogi[i] = new Point();
                        //wyznaczenie wartości współrzędnych i-tego wierzchołka wielokąta
                        //z równania parametrycznego elipsy: Xi = XsP + Oś_duża/2 * cos(Fi)
                        //                                   Yi = YsP+ Oś_mała * sin(Fi)
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołka + i * anKątŚrodkowyMiędzyWierzchołkami) / 180));
                    }
                    Wykreśl(anRysownica);

                }// od if

            }// od PrzesuńDoNowegoXY
        }// od Stożka
        public class StożekPodwójny: Stożek
        {
            Point[] anWielokątPodłogi;
            public StożekPodwójny(int anR, int anWysokośćStożka, int anStopienWielokata,
                int anXsP, int anYsP, Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii, bool anKierunekObrotu)
                :base(anR, anWysokośćStożka, anStopienWielokata, anXsP, anYsP, anKolorLinii,  anStylLinii, anGrubośćLinii, anKierunekObrotu)
            {

            }
            public override void Wykreśl(Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKolor_Linii, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //Góra
                    //wykreślenie podstawy Stożka
                    anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                 anOś_duża, anOś_mała);
                    
                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsS);

                    //Dół
                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsP + anYsP - anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsP + anYsP - anYsS);
                    anWidoczny = true;
                }// koniec using Pióro
            }
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKontrolka.BackColor, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //Góra
                    //wykreślenie podstawy Stożka
                    anRysownica.DrawEllipse(Pióro, anXsP - anOś_duża / 2, anYsP - anOś_mała / 2,
                                                 anOś_duża, anOś_mała);

                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsS);

                    //Dół
                    //wykreślenie lewej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP - anOś_duża / 2, anYsP, anXsS, anYsP + anYsP - anYsS);
                    //wykreślenie prawej krawędzi bocznej
                    anRysownica.DrawLine(Pióro, anXsP + anOś_duża / 2, anYsP, anXsS, anYsP + anYsP - anYsS);
                    anWidoczny = true;
                }// koniec using Pióro
            }
        }
        public class Wielościany:BryłaAbstrakcyjna
        {
            protected Point[] anWielokątPodłogi;
            protected int anStopieńWielokątaPodłogi;
            protected int anXsS, anYsS;
            protected int anPromieńBryły;
            //deklaracja konstruktora
            public Wielościany(int anR, int anStopieńWieloikąta, Color anKolorLinii, DashStyle anStylLinii,
                float anGrubośćLinii):base(anKolorLinii, anStylLinii, anGrubośćLinii)
            {
                anPromieńBryły = anR;
                anStopieńWielokątaPodłogi = anStopieńWieloikąta;
            }
            //nadpisanie metod abstarcyjnych zadeklarowanych w klasie bazowej (abstrakcyjnej)
            public override void Wykreśl(Graphics anRysownica)
            {
                throw new NotImplementedException();
            }
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                throw new NotImplementedException();
            }
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                throw new NotImplementedException();
            }
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                throw new NotImplementedException();
            }
        }// od Wielościanu
        public class Graniastosłup: Wielościany
        {
            //deklaracje uzupełniające
            Point[] anWielokątSufitu;
            float anKątŚrodkowyMiędzyWierzchołkamiWielokąta;
            float anKątPołożeniaPierwszegoWierzchołkaWielokąta;
            float anOś_duża, anOś_mała;
            //deklaracja konstruktora
            public Graniastosłup(int anR, int anWysokośćGraniastosłupa, int anStopieńWielokąta,int anXsP,
                int anYsP, Color anKolorLinii, DashStyle anStylLinii, float anGrubośćLinii):base(anR, anStopieńWielokąta, anKolorLinii, anStylLinii, anGrubośćLinii)
            {
                anRodzajBryły = anTypyBrył.anBG_Graniastosłup;
                anWidoczny = false;
                anKierunekObrotu = false;
                anWysokośćBryły = anWysokośćGraniastosłupa;
                //wyznaczenie wartośći dla pozostałych atrybutów (zmiennych) Graniastosłupa
                this.anXsP = anXsP;
                this.anYsP = anYsP;
                anXsS = anXsP;
                anYsS = anYsP - anWysokośćGraniastosłupa;
                anOś_duża = 2 * anR;
                anOś_mała = anR / 2;
                anKątŚrodkowyMiędzyWierzchołkamiWielokąta = 360 / anStopieńWielokąta;
                anKątPołożeniaPierwszegoWierzchołkaWielokąta = 0f;
                //utworzenie egzemplarzy tablic dla wpisania wspólnych wierzchołkąt wielokąta "podługi" oraz "sufitu"
                anWielokątPodłogi = new Point[anStopieńWielokąta + 1];
                anWielokątSufitu = new Point[anStopieńWielokąta + 1];
                //utworzenie egzemplarzy klasy Point dla każdego wierzchołka wielokąta
                //podłogi oraz sufitu, a nastęnie wpisanie do nich współrzędnych wierzchołka
                for (int i = 0; i < anStopieńWielokąta + 1; i++)
                {
                    anWielokątPodłogi[i] = new Point();
                    anWielokątSufitu[i] = new Point();
                    //wuznaczenie współrzędnych dla i-tego wierzchołka wielokąta "podłogi"
                    anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI * 
                        (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                    anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                        (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                    //sufit
                    anWielokątSufitu[i].X = anWielokątPodłogi[i].X;
                    anWielokątSufitu[i].Y = anWielokątPodłogi[i].Y - anWysokośćGraniastosłupa;
                }
                //obliczenie pola powierzchni oraz objętości Graniastosłupa
                // . . .
            }//od Konstruktora Graniastosłupa
            //nadpisanie metod abstrakcyjnych klasy BryłaAbstrakcyjna
            public override void Wykreśl(Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKolor_Linii, anGrubość_Linii))
                {
                    Pióro.DashStyle = anStyl_Linii;
                    //wykreślenie "podłogi" Graniastosłupa
                    for (int i = 0; i < anWielokątPodłogi.Length - 1; i++)
                        anRysownica.DrawLine(Pióro, anWielokątPodłogi[i], anWielokątPodłogi[i + 1]);
                    //wykreślenie "sufitu" Graniastosłupa
                    for (int i = 0; i < anWielokątSufitu.Length - 1; i++)
                        anRysownica.DrawLine(Pióro, anWielokątSufitu[i], anWielokątSufitu[i + 1]);

                    //wykreślenie krawędzi bocznych 
                    for (int i = 0; i < anStopieńWielokątaPodłogi + 1; i++)
                        anRysownica.DrawLine(Pióro, anWielokątPodłogi[i], anWielokątSufitu[i]);

                    anWidoczny = true;
                }//koniec using Pióro
            }//od metody Wykreśl
            public override void Wymaż(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen Pióro = new Pen(anKontrolka.BackColor, anGrubość_Linii))
                    {
                        Pióro.DashStyle = anStyl_Linii;
                        //wykreślenie "podłogi" Graniastosłupa
                        for (int i = 0; i < anWielokątPodłogi.Length - 1; i++)
                            anRysownica.DrawLine(Pióro, anWielokątPodłogi[i], anWielokątPodłogi[i + 1]);
                        //wykreślenie "sufitu" Graniastosłupa
                        for (int i = 0; i < anWielokątSufitu.Length - 1; i++)
                            anRysownica.DrawLine(Pióro, anWielokątSufitu[i], anWielokątSufitu[i + 1]);

                        //wykreślenie krawędzi bocznych 
                        for (int i = 0; i < anStopieńWielokątaPodłogi + 1; i++)
                            anRysownica.DrawLine(Pióro, anWielokątPodłogi[i], anWielokątSufitu[i]);

                        anWidoczny = false;
                    }//koniec using Pióro
                }//if
            }//od Wymaż
            public override void Obróć_i_Wykreśl(Control anKontrolka, Graphics anRysownica, float anKątObrotu)
            {
                if (anWidoczny)
                {
                    //wymazanie
                    Wymaż(anKontrolka, anRysownica);
                    //wyznaczenie nowego położenia pierwszego wierzchołka wielokąta
                    if (anKierunekObrotu)
                        anKątPołożeniaPierwszegoWierzchołkaWielokąta -= anKątObrotu;
                    else
                        anKątPołożeniaPierwszegoWierzchołkaWielokąta += anKątObrotu;
                    //wyznaczenie nowych współrzędnych wielokąta po obrocie 
                    for (int i = 0; i < anStopieńWielokątaPodłogi + 1; i++)
                    {
                        //wuznaczenie współrzędnych dla i-tego wierzchołka wielokąta "podłogi"
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                        //sufit
                        anWielokątSufitu[i].X = anWielokątPodłogi[i].X;
                        anWielokątSufitu[i].Y = anWielokątPodłogi[i].Y - anWysokośćBryły;
                    }
                    Wykreśl(anRysownica);
                }
            }// od Obróć_i_Wykreśl
            public override void PrzesuńDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anX, int anY)
            {
                if (anWidoczny)
                {
                    Wymaż(anKontrolka, anRysownica);
                    //przesunięcie do punktu: (X, Y) 
                    anXsP = anX;
                    anYsP = anY;
                    anXsS = anXsP;
                    anYsS = anYsP - anWysokośćBryły;
                    // wyznaczenie nowych współrzędnych wierzchołków wielokątów po przesunięciu
                    for (int i = 0; i < anStopieńWielokątaPodłogi + 1; i++)
                    {
                        //wuznaczenie współrzędnych dla i-tego wierzchołka wielokąta "podłogi"
                        anWielokątPodłogi[i].X = (int)(anXsP + anOś_duża / 2 * Math.Cos(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                        anWielokątPodłogi[i].Y = (int)(anYsP + anOś_mała / 2 * Math.Sin(Math.PI *
                            (anKątPołożeniaPierwszegoWierzchołkaWielokąta + i * anKątŚrodkowyMiędzyWierzchołkamiWielokąta) / 180));
                        //sufit
                        anWielokątSufitu[i].X = anWielokątPodłogi[i].X;
                        anWielokątSufitu[i].Y = anWielokątPodłogi[i].Y - anWysokośćBryły;
                    }
                    Wykreśl(anRysownica);
                }
            }//od PrzesuńDoNowegoXY
        }


    }
}
