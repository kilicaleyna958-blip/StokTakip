namespace StokTakip
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUrunAdi = new TextBox();
            txtStok = new TextBox();
            label2 = new Label();
            btnUrunEkle = new Button();
            dataGridView1 = new DataGridView();
            cmbUrunler = new ComboBox();
            txtMiktar = new TextBox();
            btnCikis = new Button();
            btnGiris = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 34);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı";
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Location = new Point(432, 26);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(100, 23);
            txtUrunAdi.TabIndex = 1;
            // 
            // txtStok
            // 
            txtStok.Location = new Point(432, 71);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(100, 23);
            txtStok.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 79);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 3;
            label2.Text = "Başlangıç Stok";
            // 
            // btnUrunEkle
            // 
            btnUrunEkle.Location = new Point(368, 112);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(75, 23);
            btnUrunEkle.TabIndex = 4;
            btnUrunEkle.Text = "Ürün Ekle";
            btnUrunEkle.UseVisualStyleBackColor = true;
            btnUrunEkle.Click += btnUrunEkle_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(299, 231);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 5;
            // 
            // cmbUrunler
            // 
            cmbUrunler.FormattingEnabled = true;
            cmbUrunler.Location = new Point(345, 141);
            cmbUrunler.Name = "cmbUrunler";
            cmbUrunler.Size = new Size(121, 23);
            cmbUrunler.TabIndex = 6;
            // 
            // txtMiktar
            // 
            txtMiktar.Location = new Point(345, 170);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(100, 23);
            txtMiktar.TabIndex = 7;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(432, 202);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 9;
            btnCikis.Text = "Stok Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // btnGiris
            // 
            btnGiris.Location = new Point(330, 202);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(75, 23);
            btnGiris.TabIndex = 10;
            btnGiris.Text = "Stok Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 393);
            Controls.Add(btnGiris);
            Controls.Add(btnCikis);
            Controls.Add(txtMiktar);
            Controls.Add(cmbUrunler);
            Controls.Add(dataGridView1);
            Controls.Add(btnUrunEkle);
            Controls.Add(label2);
            Controls.Add(txtStok);
            Controls.Add(txtUrunAdi);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrunAdi;
        private TextBox txtStok;
        private Label label2;
        private Button btnUrunEkle;
        private DataGridView dataGridView1;
        private ComboBox cmbUrunler;
        private TextBox txtMiktar;
        private Button btnCikis;
        private Button btnGiris;
    }
}
