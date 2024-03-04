using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace client
{
    public partial class Fr_atyarisi : Form
    {
        public Fr_atyarisi()
        {
            InitializeComponent();
        }
        // Ses oynatıcı nesnesi tanımlanıyor
        public SoundPlayer player = new SoundPlayer();

        // Başlat butonuna tıklandığında çalışacak metot
        private void bt_st_Click(object sender, EventArgs e)
        {
            string path = "../../sound/atsesi.wav";// Ses dosyasının yolu
            player.SoundLocation = path;// Ses oynatıcısının konumunu ayarla
            player.Play();// Ses dosyasını oynat
            timer1.Start();// Zamanlayıcıyı başlatarak yarışı başlat
        }

        // Oyunu sıfırlamak için kullanılan metot
        private void ResetGame()
        {
            // Atların pozisyonlarını sıfırla
            pc_at_1.Left = 0; // Başlangıç pozisyonunuza göre ayarlayın
            pc_at_2.Left = 0; // Başlangıç pozisyonunuza göre ayarlayın
            pc_at_3.Left = 0; // Başlangıç pozisyonunuza göre ayarlayın

            // Devre dışı bırakılan kontrolleri etkinleştir
            pc_at_1.Enabled = true;
            pc_at_2.Enabled = true;
            pc_at_3.Enabled = true;
        }

       

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Her at için rastgele ilerleme değeri üret ve atları hareket ettir
            Random rst = new Random();
            int at1 = rst.Next(1, 20);
            pc_at_1.Left += at1;

            int at2 = rst.Next(1, 20);
            pc_at_2.Left += at2;

            int at3 = rst.Next(1, 20);
            pc_at_3.Left += at3;

            if (pc_at_1.Left + pc_at_1.Width > pc_finish.Left)
            { // Oyunu durdur, kazananı ilan et ve oyunu sıfırla
                player.Stop();
                timer1.Stop();

                pc_at_1.Enabled = false;
                pc_at_2.Enabled = false;
                pc_at_3.Enabled = false;
                MessageBox.Show("1. At kazandı");
                ResetGame();
            }

            if (pc_at_2.Left + pc_at_2.Width > pc_finish.Left)
            { // Oyunu durdur, kazananı ilan et ve oyunu sıfırla
                player.Stop();
                timer1.Stop();

                pc_at_1.Enabled = false;
                pc_at_2.Enabled = false;
                pc_at_3.Enabled = false;
                MessageBox.Show("2. At kazandı");
                ResetGame();
            }

            if (pc_at_3.Left + pc_at_3.Width > pc_finish.Left)

            { // Oyunu durdur, kazananı ilan et ve oyunu sıfırla
                player.Stop();
                timer1.Stop();

                pc_at_1.Enabled = false;
                pc_at_2.Enabled = false;
                pc_at_3.Enabled = false;
                MessageBox.Show("3. At kazandı");
                ResetGame();

            }
        }

        private void Fr_atyarisi_Load_1(object sender, EventArgs e)
        {
            player.Stop();// Oyun başlangıcında sesi durdur
            ResetGame(); // Oyunu sıfırla
        }
    }
}
