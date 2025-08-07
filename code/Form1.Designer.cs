namespace StokTakipUygulamasi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtAlisAdeti = new System.Windows.Forms.TextBox();
            this.txtSatisAdeti = new System.Windows.Forms.TextBox();
            this.txtKalanAdeti = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.lblAlisAdeti = new System.Windows.Forms.Label();
            this.lblSatisAdeti = new System.Windows.Forms.Label();
            this.lblKalanUrun = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrunAra = new System.Windows.Forms.TextBox();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunAra = new System.Windows.Forms.Button();
            this.btnExcelAktar = new System.Windows.Forms.Button();
            this.btnXmlAktar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUrunAlisYap = new System.Windows.Forms.Button();
            this.btnUrunSatisYap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(25, 31);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(200, 20);
            this.txtUrunAdi.TabIndex = 0;
            // 
            // txtAlisAdeti
            // 
            this.txtAlisAdeti.Location = new System.Drawing.Point(257, 31);
            this.txtAlisAdeti.Name = "txtAlisAdeti";
            this.txtAlisAdeti.Size = new System.Drawing.Size(100, 20);
            this.txtAlisAdeti.TabIndex = 1;
            // 
            // txtSatisAdeti
            // 
            this.txtSatisAdeti.Location = new System.Drawing.Point(386, 31);
            this.txtSatisAdeti.Name = "txtSatisAdeti";
            this.txtSatisAdeti.Size = new System.Drawing.Size(100, 20);
            this.txtSatisAdeti.TabIndex = 2;
            // 
            // txtKalanAdeti
            // 
            this.txtKalanAdeti.Location = new System.Drawing.Point(511, 31);
            this.txtKalanAdeti.Name = "txtKalanAdeti";
            this.txtKalanAdeti.Size = new System.Drawing.Size(100, 20);
            this.txtKalanAdeti.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(336, 139);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(0, 20);
            this.textBox4.TabIndex = 4;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(25, 12);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(48, 13);
            this.lblUrunAdi.TabIndex = 5;
            this.lblUrunAdi.Text = "Ürün Adı";
            // 
            // lblAlisAdeti
            // 
            this.lblAlisAdeti.AutoSize = true;
            this.lblAlisAdeti.Location = new System.Drawing.Point(254, 11);
            this.lblAlisAdeti.Name = "lblAlisAdeti";
            this.lblAlisAdeti.Size = new System.Drawing.Size(50, 13);
            this.lblAlisAdeti.TabIndex = 6;
            this.lblAlisAdeti.Text = "Alış Adeti";
            // 
            // lblSatisAdeti
            // 
            this.lblSatisAdeti.AutoSize = true;
            this.lblSatisAdeti.Location = new System.Drawing.Point(383, 11);
            this.lblSatisAdeti.Name = "lblSatisAdeti";
            this.lblSatisAdeti.Size = new System.Drawing.Size(57, 13);
            this.lblSatisAdeti.TabIndex = 7;
            this.lblSatisAdeti.Text = "Satış Adeti";
            // 
            // lblKalanUrun
            // 
            this.lblKalanUrun.AutoSize = true;
            this.lblKalanUrun.Location = new System.Drawing.Point(508, 11);
            this.lblKalanUrun.Name = "lblKalanUrun";
            this.lblKalanUrun.Size = new System.Drawing.Size(60, 13);
            this.lblKalanUrun.TabIndex = 8;
            this.lblKalanUrun.Text = "Kalan Ürün";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ürün Ara";
            // 
            // txtUrunAra
            // 
            this.txtUrunAra.Location = new System.Drawing.Point(645, 30);
            this.txtUrunAra.Name = "txtUrunAra";
            this.txtUrunAra.Size = new System.Drawing.Size(200, 20);
            this.txtUrunAra.TabIndex = 10;
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(25, 73);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(78, 23);
            this.btnUrunEkle.TabIndex = 11;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.Location = new System.Drawing.Point(132, 72);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(93, 23);
            this.btnUrunGuncelle.TabIndex = 12;
            this.btnUrunGuncelle.Text = "Ürün Güncelle";
            this.btnUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.Location = new System.Drawing.Point(257, 72);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(100, 23);
            this.btnUrunSil.TabIndex = 13;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = true;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunAra
            // 
            this.btnUrunAra.Location = new System.Drawing.Point(645, 73);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(200, 23);
            this.btnUrunAra.TabIndex = 14;
            this.btnUrunAra.Text = "Ürün Ara";
            this.btnUrunAra.UseVisualStyleBackColor = true;
            this.btnUrunAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.Location = new System.Drawing.Point(386, 72);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(100, 23);
            this.btnExcelAktar.TabIndex = 15;
            this.btnExcelAktar.Text = "Excel\'e Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = true;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // btnXmlAktar
            // 
            this.btnXmlAktar.Location = new System.Drawing.Point(511, 71);
            this.btnXmlAktar.Name = "btnXmlAktar";
            this.btnXmlAktar.Size = new System.Drawing.Size(100, 23);
            this.btnXmlAktar.TabIndex = 16;
            this.btnXmlAktar.Text = "XML\'e Aktar";
            this.btnXmlAktar.UseVisualStyleBackColor = true;
            this.btnXmlAktar.Click += new System.EventHandler(this.btnXmlAktar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(817, 276);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnUrunAlisYap
            // 
            this.btnUrunAlisYap.Location = new System.Drawing.Point(25, 103);
            this.btnUrunAlisYap.Name = "btnUrunAlisYap";
            this.btnUrunAlisYap.Size = new System.Drawing.Size(200, 23);
            this.btnUrunAlisYap.TabIndex = 18;
            this.btnUrunAlisYap.Text = "Ürün Alış Yap";
            this.btnUrunAlisYap.UseVisualStyleBackColor = true;
            this.btnUrunAlisYap.Click += new System.EventHandler(this.btnUrunAlisYap_Click);
            // 
            // btnUrunSatisYap
            // 
            this.btnUrunSatisYap.Location = new System.Drawing.Point(257, 102);
            this.btnUrunSatisYap.Name = "btnUrunSatisYap";
            this.btnUrunSatisYap.Size = new System.Drawing.Size(229, 23);
            this.btnUrunSatisYap.TabIndex = 19;
            this.btnUrunSatisYap.Text = "Ürün Satış Yap";
            this.btnUrunSatisYap.UseVisualStyleBackColor = true;
            this.btnUrunSatisYap.Click += new System.EventHandler(this.btnUrunSatisYap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.btnUrunSatisYap);
            this.Controls.Add(this.btnUrunAlisYap);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnXmlAktar);
            this.Controls.Add(this.btnExcelAktar);
            this.Controls.Add(this.btnUrunAra);
            this.Controls.Add(this.btnUrunSil);
            this.Controls.Add(this.btnUrunGuncelle);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.txtUrunAra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblKalanUrun);
            this.Controls.Add(this.lblSatisAdeti);
            this.Controls.Add(this.lblAlisAdeti);
            this.Controls.Add(this.lblUrunAdi);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtKalanAdeti);
            this.Controls.Add(this.txtSatisAdeti);
            this.Controls.Add(this.txtAlisAdeti);
            this.Controls.Add(this.txtUrunAdi);
            this.Name = "Form1";
            this.Text = "Stok Takip";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.TextBox txtAlisAdeti;
        private System.Windows.Forms.TextBox txtSatisAdeti;
        private System.Windows.Forms.TextBox txtKalanAdeti;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.Label lblAlisAdeti;
        private System.Windows.Forms.Label lblSatisAdeti;
        private System.Windows.Forms.Label lblKalanUrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrunAra;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunAra;
        private System.Windows.Forms.Button btnExcelAktar;
        private System.Windows.Forms.Button btnXmlAktar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUrunAlisYap;
        private System.Windows.Forms.Button btnUrunSatisYap;
    }
}

