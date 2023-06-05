namespace inventoryLab
{
    partial class FormMenu
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
            panel1 = new Panel();
            buttonpgn = new Button();
            panel2 = new Panel();
            button7 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            buttonbrg = new Button();
            buttonaslab = new Button();
            panelTampil = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Peru;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(963, 58);
            panel1.TabIndex = 0;
            // 
            // buttonpgn
            // 
            buttonpgn.FlatStyle = FlatStyle.Flat;
            buttonpgn.ForeColor = SystemColors.Control;
            buttonpgn.Image = Properties.Resources.icons_pengguna;
            buttonpgn.ImageAlign = ContentAlignment.MiddleLeft;
            buttonpgn.Location = new Point(0, 0);
            buttonpgn.Name = "buttonpgn";
            buttonpgn.Size = new Size(169, 50);
            buttonpgn.TabIndex = 2;
            buttonpgn.Text = " Pengguna";
            buttonpgn.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonpgn.UseVisualStyleBackColor = true;
            buttonpgn.Click += buttonpgn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Tan;
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(buttonbrg);
            panel2.Controls.Add(buttonaslab);
            panel2.Controls.Add(buttonpgn);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 484);
            panel2.TabIndex = 1;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.Control;
            button7.Image = Properties.Resources.icons_laporan;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(0, 311);
            button7.Name = "button7";
            button7.Size = new Size(169, 50);
            button7.TabIndex = 8;
            button7.Text = " Report";
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.Control;
            button4.Image = Properties.Resources.icons_keluar;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 260);
            button4.Name = "button4";
            button4.Size = new Size(169, 50);
            button4.TabIndex = 7;
            button4.Text = " Pengembalian";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.Control;
            button5.Image = Properties.Resources.icons_pinjem;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(0, 208);
            button5.Name = "button5";
            button5.Size = new Size(169, 50);
            button5.TabIndex = 6;
            button5.Text = " Peminjaman";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.Control;
            button6.Image = Properties.Resources.icons_rack;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(0, 156);
            button6.Name = "button6";
            button6.Size = new Size(169, 50);
            button6.TabIndex = 5;
            button6.Text = " Rak";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // buttonbrg
            // 
            buttonbrg.FlatStyle = FlatStyle.Flat;
            buttonbrg.ForeColor = SystemColors.Control;
            buttonbrg.Image = Properties.Resources.icons_barang;
            buttonbrg.ImageAlign = ContentAlignment.MiddleLeft;
            buttonbrg.Location = new Point(0, 104);
            buttonbrg.Name = "buttonbrg";
            buttonbrg.Size = new Size(169, 50);
            buttonbrg.TabIndex = 4;
            buttonbrg.Text = " Barang";
            buttonbrg.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonbrg.UseVisualStyleBackColor = true;
            buttonbrg.Click += buttonbrg_Click;
            // 
            // buttonaslab
            // 
            buttonaslab.FlatStyle = FlatStyle.Flat;
            buttonaslab.ForeColor = SystemColors.Control;
            buttonaslab.Image = Properties.Resources.icons_aslab;
            buttonaslab.ImageAlign = ContentAlignment.MiddleLeft;
            buttonaslab.Location = new Point(0, 52);
            buttonaslab.Name = "buttonaslab";
            buttonaslab.Size = new Size(169, 50);
            buttonaslab.TabIndex = 3;
            buttonaslab.Text = " Aslab";
            buttonaslab.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonaslab.UseVisualStyleBackColor = true;
            buttonaslab.Click += buttonaslab_Click;
            // 
            // panelTampil
            // 
            panelTampil.BackColor = Color.Transparent;
            panelTampil.Dock = DockStyle.Fill;
            panelTampil.Location = new Point(169, 58);
            panelTampil.Name = "panelTampil";
            panelTampil.Size = new Size(794, 484);
            panelTampil.TabIndex = 2;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 542);
            Controls.Add(panelTampil);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Utama | InventoryLab";
            Load += FormMenu_Load;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonpgn;
        private Panel panel2;
        private Button button7;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button buttonbrg;
        private Button buttonaslab;
        private Panel panelTampil;
    }
}