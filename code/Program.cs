using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipUygulamasi
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                MessageBox.Show($"Uygulama başlatılırken bir hata oluştu:\n\n{ex.Message}",
                              "Kritik Hata",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                // Hata detaylarını logla (isteğe bağlı)
                System.IO.File.WriteAllText("error_log.txt",
                    $"[{DateTime.Now}] Hata: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }
    }
}