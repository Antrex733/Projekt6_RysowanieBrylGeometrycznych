namespace Projekt3Nowalski57295
{
    partial class WizualizacjaZłożonychBrył
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListaBrył = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trbKątNachylenia = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStopieńWielokąta = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trbPromieńBryły = new System.Windows.Forms.TrackBar();
            this.trbWysokośćBryły = new System.Windows.Forms.TrackBar();
            this.btnPowrót = new System.Windows.Forms.Button();
            this.btnUsuń = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUsuńWszystkie = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUsuńWybraną = new System.Windows.Forms.Button();
            this.btnUsuńOstatnią = new System.Windows.Forms.Button();
            this.btnUsuńPierwszą = new System.Windows.Forms.Button();
            this.nudUsuńWybraną = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbKątNachylenia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopieńWielokąta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPromieńBryły)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWysokośćBryły)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsuńWybraną)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.Color.LightYellow;
            this.pbRysownica.Location = new System.Drawing.Point(205, 83);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(833, 492);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybierz Typ Figury";
            // 
            // cmbListaBrył
            // 
            this.cmbListaBrył.FormattingEnabled = true;
            this.cmbListaBrył.Items.AddRange(new object[] {
            "Walec",
            "Stożek",
            "Stożek Pochylony",
            "Podwójny Stożek",
            "Graniastosłup"});
            this.cmbListaBrył.Location = new System.Drawing.Point(12, 99);
            this.cmbListaBrył.Name = "cmbListaBrył";
            this.cmbListaBrył.Size = new System.Drawing.Size(187, 21);
            this.cmbListaBrył.TabIndex = 2;
            this.cmbListaBrył.Text = "Nie wybrałeś jeszcze żadnej bryły";
            this.cmbListaBrył.SelectedIndexChanged += new System.EventHandler(this.cmbListaBrył_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trbKątNachylenia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudStopieńWielokąta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trbPromieńBryły);
            this.groupBox1.Controls.Add(this.trbWysokośćBryły);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 289);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cechy nowej figury";
            // 
            // trbKątNachylenia
            // 
            this.trbKątNachylenia.Enabled = false;
            this.trbKątNachylenia.Location = new System.Drawing.Point(6, 178);
            this.trbKątNachylenia.Maximum = 160;
            this.trbKątNachylenia.Minimum = 20;
            this.trbKątNachylenia.Name = "trbKątNachylenia";
            this.trbKątNachylenia.Size = new System.Drawing.Size(175, 45);
            this.trbKątNachylenia.TabIndex = 10;
            this.trbKątNachylenia.Value = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Stopień wielokąta";
            // 
            // nudStopieńWielokąta
            // 
            this.nudStopieńWielokąta.Enabled = false;
            this.nudStopieńWielokąta.Location = new System.Drawing.Point(65, 245);
            this.nudStopieńWielokąta.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudStopieńWielokąta.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudStopieńWielokąta.Name = "nudStopieńWielokąta";
            this.nudStopieńWielokąta.Size = new System.Drawing.Size(48, 20);
            this.nudStopieńWielokąta.TabIndex = 7;
            this.nudStopieńWielokąta.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Wysokość bryły";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Promień bryły";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kąt nachylenia";
            // 
            // trbPromieńBryły
            // 
            this.trbPromieńBryły.Enabled = false;
            this.trbPromieńBryły.Location = new System.Drawing.Point(6, 114);
            this.trbPromieńBryły.Maximum = 100;
            this.trbPromieńBryły.Minimum = 10;
            this.trbPromieńBryły.Name = "trbPromieńBryły";
            this.trbPromieńBryły.Size = new System.Drawing.Size(175, 45);
            this.trbPromieńBryły.TabIndex = 1;
            this.trbPromieńBryły.Value = 50;
            // 
            // trbWysokośćBryły
            // 
            this.trbWysokośćBryły.Enabled = false;
            this.trbWysokośćBryły.Location = new System.Drawing.Point(6, 44);
            this.trbWysokośćBryły.Maximum = 100;
            this.trbWysokośćBryły.Minimum = 10;
            this.trbWysokośćBryły.Name = "trbWysokośćBryły";
            this.trbWysokośćBryły.Size = new System.Drawing.Size(175, 45);
            this.trbWysokośćBryły.TabIndex = 0;
            this.trbWysokośćBryły.Value = 70;
            // 
            // btnPowrót
            // 
            this.btnPowrót.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPowrót.Location = new System.Drawing.Point(1067, 80);
            this.btnPowrót.Name = "btnPowrót";
            this.btnPowrót.Size = new System.Drawing.Size(170, 55);
            this.btnPowrót.TabIndex = 4;
            this.btnPowrót.Text = "Powrót do \r\nformularza głównego";
            this.btnPowrót.UseVisualStyleBackColor = true;
            this.btnPowrót.Click += new System.EventHandler(this.btnPowrót_Click);
            // 
            // btnUsuń
            // 
            this.btnUsuń.Enabled = false;
            this.btnUsuń.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsuń.Location = new System.Drawing.Point(115, 459);
            this.btnUsuń.Name = "btnUsuń";
            this.btnUsuń.Size = new System.Drawing.Size(84, 49);
            this.btnUsuń.TabIndex = 5;
            this.btnUsuń.Text = "Usuń figurę";
            this.btnUsuń.UseVisualStyleBackColor = true;
            this.btnUsuń.Click += new System.EventHandler(this.btnUsuń_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Enabled = false;
            this.btnDodaj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(12, 459);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(84, 49);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj figurę";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUsuńWszystkie
            // 
            this.btnUsuńWszystkie.Enabled = false;
            this.btnUsuńWszystkie.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsuńWszystkie.Location = new System.Drawing.Point(12, 530);
            this.btnUsuńWszystkie.Name = "btnUsuńWszystkie";
            this.btnUsuńWszystkie.Size = new System.Drawing.Size(187, 45);
            this.btnUsuńWszystkie.TabIndex = 7;
            this.btnUsuńWszystkie.Text = "Usuń wszystkie figury";
            this.btnUsuńWszystkie.UseVisualStyleBackColor = true;
            this.btnUsuńWszystkie.Click += new System.EventHandler(this.btnUsuńWszystkie_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnUsuńWybraną
            // 
            this.btnUsuńWybraną.Enabled = false;
            this.btnUsuńWybraną.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsuńWybraną.Location = new System.Drawing.Point(522, 581);
            this.btnUsuńWybraną.Name = "btnUsuńWybraną";
            this.btnUsuńWybraną.Size = new System.Drawing.Size(103, 44);
            this.btnUsuńWybraną.TabIndex = 8;
            this.btnUsuńWybraną.Text = "Usuń Wybraną Bryłę";
            this.btnUsuńWybraną.UseVisualStyleBackColor = true;
            this.btnUsuńWybraną.Click += new System.EventHandler(this.btnUsuńWybraną_Click);
            // 
            // btnUsuńOstatnią
            // 
            this.btnUsuńOstatnią.Enabled = false;
            this.btnUsuńOstatnią.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsuńOstatnią.Location = new System.Drawing.Point(362, 581);
            this.btnUsuńOstatnią.Name = "btnUsuńOstatnią";
            this.btnUsuńOstatnią.Size = new System.Drawing.Size(103, 44);
            this.btnUsuńOstatnią.TabIndex = 9;
            this.btnUsuńOstatnią.Text = "Usuń Ostatnią Bryłę";
            this.btnUsuńOstatnią.UseVisualStyleBackColor = true;
            this.btnUsuńOstatnią.Click += new System.EventHandler(this.btnUsuńOstatnią_Click);
            // 
            // btnUsuńPierwszą
            // 
            this.btnUsuńPierwszą.Enabled = false;
            this.btnUsuńPierwszą.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsuńPierwszą.Location = new System.Drawing.Point(205, 581);
            this.btnUsuńPierwszą.Name = "btnUsuńPierwszą";
            this.btnUsuńPierwszą.Size = new System.Drawing.Size(93, 44);
            this.btnUsuńPierwszą.TabIndex = 10;
            this.btnUsuńPierwszą.Text = "Usuń Pierwszą Bryłę";
            this.btnUsuńPierwszą.UseVisualStyleBackColor = true;
            this.btnUsuńPierwszą.Click += new System.EventHandler(this.btnUsuńPierwszą_Click);
            // 
            // nudUsuńWybraną
            // 
            this.nudUsuńWybraną.Enabled = false;
            this.nudUsuńWybraną.Location = new System.Drawing.Point(643, 595);
            this.nudUsuńWybraną.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudUsuńWybraną.Name = "nudUsuńWybraną";
            this.nudUsuńWybraną.Size = new System.Drawing.Size(48, 20);
            this.nudUsuńWybraną.TabIndex = 11;
            this.nudUsuńWybraną.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // WizualizacjaZłożonychBrył
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 666);
            this.Controls.Add(this.nudUsuńWybraną);
            this.Controls.Add(this.btnUsuńPierwszą);
            this.Controls.Add(this.btnUsuńOstatnią);
            this.Controls.Add(this.btnUsuńWybraną);
            this.Controls.Add(this.btnUsuńWszystkie);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnUsuń);
            this.Controls.Add(this.btnPowrót);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbListaBrył);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbRysownica);
            this.Name = "WizualizacjaZłożonychBrył";
            this.Text = "Wizualizacjazłożonych brył geometrycznych";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WizualizacjaZłożonychBrył_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizualizacjaZłożonychBrył_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbKątNachylenia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopieńWielokąta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPromieńBryły)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWysokośćBryły)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsuńWybraną)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbListaBrył;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trbPromieńBryły;
        private System.Windows.Forms.TrackBar trbWysokośćBryły;
        private System.Windows.Forms.NumericUpDown nudStopieńWielokąta;
        private System.Windows.Forms.Button btnPowrót;
        private System.Windows.Forms.Button btnUsuń;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trbKątNachylenia;
        private System.Windows.Forms.Button btnUsuńWszystkie;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown nudUsuńWybraną;
        private System.Windows.Forms.Button btnUsuńPierwszą;
        private System.Windows.Forms.Button btnUsuńOstatnią;
        private System.Windows.Forms.Button btnUsuńWybraną;
    }
}