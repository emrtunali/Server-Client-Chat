using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Bt_Login_Click(object sender, EventArgs e)
        {
            string username = tx_username.Text;

            // Dosya yolu (kullanıcı adları .txt dosyası)
            string filePath = "../../user-db.txt";

            // Dosya var mı diye kontrol et
            if (File.Exists(filePath))
            {
                // Dosyadaki tüm satırları oku
                string[] allUsernames = File.ReadAllLines(filePath);

                // Kullanıcı adı dosyada var mı diye kontrol et
                if (allUsernames.Contains(username))
                {
                    // Kullanıcı adı varsa, Form1'i göster
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string exePath = Path.Combine(currentDirectory, "client.exe");
                    System.Diagnostics.Process.Start(exePath);


                    // Mevcut giriş ekranını kapat
                    this.Close();
                }
                else
                {
                    // Kullanıcı adı yoksa, hata mesajı göster
                    MessageBox.Show("Kullanıcı adı bulunamadı. Lütfen tekrar deneyin.");
                }
            }
            else
            {
                // Dosya yoksa, hata mesajı göster
                MessageBox.Show("Kullanıcı adları dosyası bulunamadı.");
            }
        }
    }
}
