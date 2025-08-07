# Stok Takip Uygulaması

## 📌 Proje Hakkında
Bu uygulama, ürün stoklarını takip etmek için geliştirilmiş bir Windows Forms uygulamasıdır. Ürün ekleme, güncelleme, silme, alış/satış işlemleri yapabilir ve verileri Excel/XML formatında dışa aktarabilirsiniz.

## ✨ Özellikler
- Ürün ekleme, güncelleme ve silme
- Alış ve satış işlemleri yapma
- Otomatik stok miktarı hesaplama
- Ürün arama özelliği
- Verileri Excel ve XML formatında dışa aktarma
- Verilerin otomatik kaydedilmesi (XML formatında)
- Kullanıcı dostu arayüz

## 🛠 Kurulum
1. Projeyi klonlayın veya ZIP olarak indirin.
2. Visual Studio ile `StokTakipUygulamasi.sln` dosyasını açın.
3. Gerekli NuGet paketlerini yükleyin (Microsoft.Office.Interop.Excel).
4. Projeyi derleyin ve çalıştırın.

## 📊 Veri Yapısı
Uygulama verileri XML formatında kaydeder. Veri dosyası konumu:
```
%AppData%\StokTakipUygulamasi\stokdata.xml
```

## 📋 Örnek Veri Yapısı
```xml
<ArrayOfUrun>
  <Urun>
    <UrunAdi>SEMBOL ULTRA ŞEFFAF SU YALI.</UrunAdi>
    <AlisAdet>78</AlisAdet>
    <SatisAdet>0</SatisAdet>
    <KalanAdet>78</KalanAdet>
  </Urun>
</ArrayOfUrun>
```

## 📝 Kullanım
1. Yeni ürün eklemek için ürün adı ve miktarları girip "Ürün Ekle" butonuna basın.
2. Mevcut bir ürünü güncellemek için listeden seçip bilgileri değiştirin ve "Ürün Güncelle" butonuna basın.
3. Alış/Satış yapmak için ürünü seçip miktarı girerek ilgili butona basın.
4. Verileri dışa aktarmak için "Excel'e Aktar" veya "XML'e Aktar" butonlarını kullanın.

## 📦 Bağımlılıklar
- .NET Framework 4.7.2 veya üzeri
- Microsoft Excel (Excel aktarımı için)

## 📜 Lisans
Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.

---

> **Not:** Bu uygulama geliştirme aşamasındadır. Öneri ve katkılarınız için Issues bölümünü kullanabilirsiniz.
