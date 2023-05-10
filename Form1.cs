using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3Nowalski57295
{
    public partial class WizualizacjaBryłGeometrycznych : Form
    {
        public WizualizacjaBryłGeometrycznych()
        {
            InitializeComponent();
        }

        private void btnLabolatorium_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
                if (item.Name == "Labolatorium")
                {
                    Hide();
                    item.Show();
                    return;
                }
            
            Laboratorium QQQ = new Laboratorium();
            Hide();
            QQQ.Show();
        }

        private void btnProjektNr3_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "WizualizacjaZłożonychBrył")
                {
                    Hide();
                    item.Show();
                    return;
                }
            }
            WizualizacjaZłożonychBrył QQQ = new WizualizacjaZłożonychBrył();
            Hide();
            QQQ.Show();
        }

        private void WizualizacjaBryłGeometrycznych_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
