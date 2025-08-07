using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace StokTakipUygulamasi
{
    public partial class Form1 : Form
    {
        private List<Urun> urunler = new List<Urun>();
        private string dosyaYolu = Path.Combine(Application.StartupPath, "stokdata.xml");

        public Form1()
        {
            try
            {
                InitializeComponent();

                // ApplicationData klasörüne kaydet (en güvenli ve standart yol)
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appFolder = Path.Combine(appDataPath, "StokTakipUygulamasi");

                Directory.CreateDirectory(appFolder); // Klasör yoksa oluştur
                dosyaYolu = Path.Combine(appFolder, "stokdata.xml");


                // Form constructor'ında veya InitializeComponent() sonrasında
                dataGridView1.ReadOnly = true;  // Tüm satır ve hücreler salt okunur olur
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                VerileriYukle();
                UrunListesiniGuncelle();

                txtAlisAdeti.TextChanged += (s, e) => HesaplaKalanAdet();
                txtSatisAdeti.TextChanged += (s, e) => HesaplaKalanAdet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yüklenirken hata oluştu: {ex.Message}");
                this.Close(); // Formu kapat
            }
        }

        [Serializable]
        public class Urun
        {
            public string UrunAdi { get; set; }
            public int AlisAdet { get; set; }
            public int SatisAdet { get; set; }
            public int KalanAdet { get; set; }
        }

        private void VerileriYukle()
        {
            if (File.Exists(dosyaYolu))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Urun>));
                    using (FileStream stream = new FileStream(dosyaYolu, FileMode.Open))
                    {
                        urunler = (List<Urun>)serializer.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void VerileriKaydet()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Urun>));
                using (FileStream stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    serializer.Serialize(stream, urunler);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri kaydedilirken hata oluştu: " + ex.Message);
            }
        }

        private void UrunListesiniGuncelle()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = urunler;

            // Sütun başlıkları
            dataGridView1.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dataGridView1.Columns["AlisAdet"].HeaderText = "Alış Adeti";
            dataGridView1.Columns["SatisAdet"].HeaderText = "Satış Adeti";
            dataGridView1.Columns["KalanAdet"].HeaderText = "Kalan Adet";

            // Görsel iyileştirmeler
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void txtUrunAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnUrunGuncelle.Enabled)
            {
                btnUrunGuncelle.PerformClick();
                e.SuppressKeyPress = true; // Enter sesini engelle
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Aynı isimden ürün olamaz  ---
            string yeniUrunAdi = txtUrunAdi.Text.Trim();
            if (urunler.Any(u => u.UrunAdi.Equals(yeniUrunAdi, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Bu ürün zaten listede mevcut! Lütfen farklı bir ürün adı girin veya mevcut ürünü güncelleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrunAdi.Focus();
                return;
            }

            // Alış ve satış adetleri için varsayılan değerler (0)
            int alisAdet = 0;
            int satisAdet = 0;

            // Eğer değer girilmişse oku, girilmemişse 0 olarak kalacak
            int.TryParse(txtAlisAdeti.Text, out alisAdet);
            int.TryParse(txtSatisAdeti.Text, out satisAdet);

            // Negatif değer kontrolü
            if (alisAdet < 0 || satisAdet < 0)
            {
                MessageBox.Show("Alış ve satış adetleri negatif olamaz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kalan adet hesaplama
            int kalanAdet = alisAdet - satisAdet;
            if (kalanAdet < 0)
            {
                MessageBox.Show("Kalan adet negatif olamaz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Urun yeniUrun = new Urun
            {
                UrunAdi = txtUrunAdi.Text.Trim(),
                AlisAdet = alisAdet,
                SatisAdet = satisAdet,
                KalanAdet = kalanAdet
            };

            urunler.Add(yeniUrun);
            VerileriKaydet();
            UrunListesiniGuncelle();
            Temizle();

            MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz ürünü seçiniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seciliUrun = (Urun)dataGridView1.SelectedRows[0].DataBoundItem;

            // Sadece ürün adı zorunlu
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUrunAdi.Focus();
                return;
            }

            // Diğer alanlar için esnek kontrol
            int yeniAlisAdet, yeniSatisAdet;
            if (!int.TryParse(txtAlisAdeti.Text, out yeniAlisAdet) || yeniAlisAdet < 0)
                yeniAlisAdet = seciliUrun.AlisAdet;

            if (!int.TryParse(txtSatisAdeti.Text, out yeniSatisAdet) || yeniSatisAdet < 0)
                yeniSatisAdet = seciliUrun.SatisAdet;

            int yeniKalanAdet = yeniAlisAdet - yeniSatisAdet;
            if (yeniKalanAdet < 0)
            {
                MessageBox.Show("Kalan adet negatif olamaz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Güncelleme işlemi
            seciliUrun.UrunAdi = txtUrunAdi.Text.Trim();
            seciliUrun.AlisAdet = yeniAlisAdet;
            seciliUrun.SatisAdet = yeniSatisAdet;
            seciliUrun.KalanAdet = yeniKalanAdet;

            VerileriKaydet();
            UrunListesiniGuncelle();

            MessageBox.Show("Ürün başarıyla güncellendi!", "Başarılı",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir ürün seçin!");
                return;
            }

            var seciliUrun = (Urun)dataGridView1.SelectedRows[0].DataBoundItem;
            urunler.Remove(seciliUrun);
            VerileriKaydet();
            UrunListesiniGuncelle();
            Temizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtUrunAra.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(aramaKelimesi))
            {
                UrunListesiniGuncelle();
                return;
            }

            var filtrelenmisUrunler = urunler.Where(u => u.UrunAdi.ToLower().Contains(aramaKelimesi)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrelenmisUrunler;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliUrun = (Urun)dataGridView1.SelectedRows[0].DataBoundItem;

                // TextBox'lara verileri yükle
                txtUrunAdi.Text = seciliUrun.UrunAdi;
                txtAlisAdeti.Text = seciliUrun.AlisAdet.ToString();
                txtSatisAdeti.Text = seciliUrun.SatisAdet.ToString();
                txtKalanAdeti.Text = seciliUrun.KalanAdet.ToString();

                // Güncelle butonunu aktif et
                btnUrunGuncelle.Enabled = true;
                btnUrunSil.Enabled = true;
            }
            else
            {
                // Seçili ürün yoksa butonları pasif yap
                btnUrunGuncelle.Enabled = false;
                btnUrunSil.Enabled = false;
            }
        }

        private void Temizle()
        {
            // Sadece yeni ürün eklerken temizleme yap
            if (dataGridView1.SelectedRows.Count == 0)
            {
                txtUrunAdi.Clear();
                txtAlisAdeti.Clear();
                txtSatisAdeti.Clear();
                txtKalanAdeti.Clear();
                txtUrunAra.Clear();
            }
        }

        private void HesaplaKalanAdet()
        {
            // Sadece yeni ürün eklerken otomatik hesaplama yap
            if (dataGridView1.SelectedRows.Count == 0)
            {
                int alis = string.IsNullOrEmpty(txtAlisAdeti.Text) ? 0 : int.Parse(txtAlisAdeti.Text);
                int satis = string.IsNullOrEmpty(txtSatisAdeti.Text) ? 0 : int.Parse(txtSatisAdeti.Text);

                int kalan = alis - satis;
                txtKalanAdeti.Text = kalan >= 0 ? kalan.ToString() : "0";
            }
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            if (urunler.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri yok!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            saveFileDialog.Title = "Excel'e Aktar";
            saveFileDialog.FileName = "StokListesi_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                    Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    // Başlıklar
                    excelWorksheet.Cells[1, 1] = "Ürün Adı";
                    excelWorksheet.Cells[1, 2] = "Alış Adet";
                    excelWorksheet.Cells[1, 3] = "Satış Adet";
                    excelWorksheet.Cells[1, 4] = "Kalan Adet";

                    // Veriler
                    for (int i = 0; i < urunler.Count; i++)
                    {
                        excelWorksheet.Cells[i + 2, 1] = urunler[i].UrunAdi;
                        excelWorksheet.Cells[i + 2, 2] = urunler[i].AlisAdet;
                        excelWorksheet.Cells[i + 2, 3] = urunler[i].SatisAdet;
                        excelWorksheet.Cells[i + 2, 4] = urunler[i].KalanAdet;
                    }

                    // Formatlama
                    Excel.Range range = excelWorksheet.Range["A1:D1"];
                    range.Font.Bold = true;
                    range.EntireColumn.AutoFit();

                    excelWorkbook.SaveAs(saveFileDialog.FileName);
                    excelWorkbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Excel dosyası başarıyla oluşturuldu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel aktarımı sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnXmlAktar_Click(object sender, EventArgs e)
        {
            if (urunler.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri yok!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Dosyası|*.xml";
            saveFileDialog.Title = "XML'e Aktar";
            saveFileDialog.FileName = "StokListesi_" + DateTime.Now.ToString("yyyyMMdd") + ".xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Urun>));
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(stream, urunler);
                    }
                    MessageBox.Show("XML dosyası başarıyla oluşturuldu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("XML aktarımı sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnUrunAlisYap_Click(object sender, EventArgs e)
        {
            // Seçili ürün kontrolü
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Alış yapmak için bir ürün seçiniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Alış miktarı kontrolü
            if (string.IsNullOrWhiteSpace(txtAlisAdeti.Text))
            {
                MessageBox.Show("Alış miktarı giriniz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlisAdeti.Focus();
                return;
            }

            if (!int.TryParse(txtAlisAdeti.Text, out int alisMiktari) || alisMiktari <= 0)
            {
                MessageBox.Show("Geçerli bir alış miktarı giriniz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlisAdeti.Focus();
                return;
            }

            var seciliUrun = (Urun)dataGridView1.SelectedRows[0].DataBoundItem;

            // Alış işlemi
            seciliUrun.AlisAdet += alisMiktari;
            seciliUrun.KalanAdet = seciliUrun.AlisAdet - seciliUrun.SatisAdet;

            VerileriKaydet();
            UrunListesiniGuncelle();
            Temizle();

            MessageBox.Show($"{alisMiktari} adet alış işlemi başarıyla tamamlandı.\n" +
                           $"Yeni stok: {seciliUrun.KalanAdet}", "Başarılı",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUrunSatisYap_Click(object sender, EventArgs e)
        {
            // Seçili ürün kontrolü
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Satış yapmak için bir ürün seçiniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Satış miktarı kontrolü
            if (string.IsNullOrWhiteSpace(txtSatisAdeti.Text))
            {
                MessageBox.Show("Satış miktarı giriniz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSatisAdeti.Focus();
                return;
            }

            if (!int.TryParse(txtSatisAdeti.Text, out int satisMiktari) || satisMiktari <= 0)
            {
                MessageBox.Show("Geçerli bir satış miktarı giriniz!", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSatisAdeti.Focus();
                return;
            }

            var seciliUrun = (Urun)dataGridView1.SelectedRows[0].DataBoundItem;

            // Stok kontrolü
            if (seciliUrun.KalanAdet < satisMiktari)
            {
                MessageBox.Show($"Yetersiz stok! Kalan adet: {seciliUrun.KalanAdet}", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Satış işlemi
            seciliUrun.SatisAdet += satisMiktari;
            seciliUrun.KalanAdet = seciliUrun.AlisAdet - seciliUrun.SatisAdet;

            VerileriKaydet();
            UrunListesiniGuncelle();
            Temizle();

            MessageBox.Show($"{satisMiktari} adet satış işlemi başarıyla tamamlandı.\n" +
                           $"Yeni stok: {seciliUrun.KalanAdet}", "Başarılı",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Çift tıklamayı engelle
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlık satırına tıklamayı engelle
            if (e.RowIndex == -1) return;

            // Seçili satırı vurgula
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}