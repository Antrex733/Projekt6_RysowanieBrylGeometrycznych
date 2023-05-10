namespace Projekt3Nowalski57295
{
    partial class WizualizacjaBryłGeometrycznych
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLabolatorium = new System.Windows.Forms.Button();
            this.btnProjektNr3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLabolatorium
            // 
            this.btnLabolatorium.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLabolatorium.Location = new System.Drawing.Point(350, 269);
            this.btnLabolatorium.Name = "btnLabolatorium";
            this.btnLabolatorium.Size = new System.Drawing.Size(240, 99);
            this.btnLabolatorium.TabIndex = 0;
            this.btnLabolatorium.Text = "Laboratorium\r\nwybrane bryły regularne\r\n";
            this.btnLabolatorium.UseVisualStyleBackColor = true;
            this.btnLabolatorium.Click += new System.EventHandler(this.btnLabolatorium_Click);
            // 
            // btnProjektNr3
            // 
            this.btnProjektNr3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProjektNr3.Location = new System.Drawing.Point(712, 269);
            this.btnProjektNr3.Name = "btnProjektNr3";
            this.btnProjektNr3.Size = new System.Drawing.Size(240, 99);
            this.btnProjektNr3.TabIndex = 1;
            this.btnProjektNr3.Text = "Projekt Nr 3\r\nwybrane bryły złożone";
            this.btnProjektNr3.UseVisualStyleBackColor = true;
            this.btnProjektNr3.Click += new System.EventHandler(this.btnProjektNr3_Click);
            // 
            // WizualizacjaBryłGeometrycznych
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1296, 658);
            this.Controls.Add(this.btnProjektNr3);
            this.Controls.Add(this.btnLabolatorium);
            this.Name = "WizualizacjaBryłGeometrycznych";
            this.Text = "Wizualizacja brył geometrycznych";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizualizacjaBryłGeometrycznych_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLabolatorium;
        private System.Windows.Forms.Button btnProjektNr3;
    }
}

