using System.Data;
using Microsoft.Data.Sqlite;
namespace StokTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS Urunler (
            UrunID INTEGER PRIMARY KEY AUTOINCREMENT,
            UrunAdi TEXT NOT NULL,
            StokMiktari INTEGER NOT NULL
        );";

                cmd.ExecuteNonQuery();
            }
            Listele();
            UrunleriDoldur();

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            // Basit kontrol
            if (txtUrunAdi.Text == "" || txtStok.Text == "")
            {
                MessageBox.Show("Boş alan bırakma");
                return;
            }

            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                "INSERT INTO Urunler (UrunAdi, StokMiktari) VALUES (@ad, @stok)";

                cmd.Parameters.AddWithValue("@ad", txtUrunAdi.Text);
                cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Ürün eklendi");

            txtUrunAdi.Clear();
            txtStok.Clear();

            Listele();
            UrunleriDoldur();
        }
        void Listele()
        {
            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Urunler";

                var dt = new DataTable();
                dt.Columns.Add("UrunID");
                dt.Columns.Add("UrunAdi");
                dt.Columns.Add("StokMiktari");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader["UrunID"],
                            reader["UrunAdi"],
                            reader["StokMiktari"]
                        );
                    }
                }

                dataGridView1.DataSource = dt;
            }
        }
        void UrunleriDoldur()
        {
            cmbUrunler.Items.Clear();

            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UrunID, UrunAdi FROM Urunler";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbUrunler.Items.Add(
                            new ComboBoxItem
                            {
                                Text = reader["UrunAdi"].ToString(),
                                Value = reader["UrunID"]
                            }
                        );
                    }
                }
            }
        }



        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedItem == null || txtMiktar.Text == "")
            {
                MessageBox.Show("Ürün ve miktar seç");
                return;
            }

            var secilen = (ComboBoxItem)cmbUrunler.SelectedItem;
            int miktar = int.Parse(txtMiktar.Text);

            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText =
                "UPDATE Urunler SET StokMiktari = StokMiktari + @m WHERE UrunID = @id";

                cmd.Parameters.AddWithValue("@m", miktar);
                cmd.Parameters.AddWithValue("@id", secilen.Value);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Stok girişi yapıldı");

            txtMiktar.Clear();
            Listele();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedItem == null || txtMiktar.Text == "")
            {
                MessageBox.Show("Ürün ve miktar seç");
                return;
            }

            ComboBoxItem secilen = (ComboBoxItem)cmbUrunler.SelectedItem;
            int miktar = int.Parse(txtMiktar.Text);

            int mevcutStok;

            using (var con = new SqliteConnection("Data Source=stok.db"))
            {
                con.Open();

                // Mevcut stok al
                var cmdStok = con.CreateCommand();
                cmdStok.CommandText =
                    "SELECT StokMiktari FROM Urunler WHERE UrunID = @id";
                cmdStok.Parameters.AddWithValue("@id", secilen.Value);

                mevcutStok = Convert.ToInt32(cmdStok.ExecuteScalar());

                // ❌ Eksiye düşme kuralı
                if (mevcutStok < miktar)
                {
                    MessageBox.Show("Yetersiz stok! Mevcut: " + mevcutStok);
                    return;
                }

                // Stoktan düş
                var cmd = con.CreateCommand();
                cmd.CommandText =
                    "UPDATE Urunler SET StokMiktari = StokMiktari - @m WHERE UrunID = @id";
                cmd.Parameters.AddWithValue("@m", miktar);
                cmd.Parameters.AddWithValue("@id", secilen.Value);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Stok çıkışı yapıldı");

            txtMiktar.Clear();
            Listele();
        }
    }
    class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

