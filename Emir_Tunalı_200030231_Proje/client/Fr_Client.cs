using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace client
{
    public partial class Fr_Client : Form
    {
        private bool terminate = false;

        private bool connected = false;
        private bool discontPress = false;
        private string cl_username = "";
        private Socket clSocket;

        //private System.ComponentModel.IContainer components = null;




        public Fr_Client(string username)
        {// Bu ayar, kontrol özelliklerine farklı iş parçacıklarından erişimi izin verir.
         // Ancak, bu kullanım yarış koşulları gibi eşzamanlılık sorunlarına yol açabilir.
            Control.CheckForIllegalCrossThreadCalls = false;

            // Form kapanırken tetiklenecek olay işleyicisini ekler.
            // Bu, form kapanmadan önce yapılması gereken özel işlemleri tanımlamak için kullanılır.
            this.FormClosing += new FormClosingEventHandler(this.Form1_Closing);

            this.InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            // TCP soketi oluşturuluyor.
            this.clSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // IP adresi ve port bilgisi alınıyor.
            string text1 = this.txIP.Text;
            int result;
            // Port numarasının doğru formatta olduğunu kontrol ediyor.
            if (int.TryParse(this.txPort.Text, out result))
            { // Kullanıcı adı ve IP adresi boş mu diye kontrol ediyor.
                string text2 = this.txUsername.Text;
                if (text2 == "")
                    this.clientLog.AppendText("Lütfen kullancı Adınızı Giriniz.\n");
                else if (text1 == "")
                { // Sunucuya bağlanıyor.
                    clientLog.AppendText("Lütfen IP Adresinizi Giriniz.\n");
                }
                else
                {
                    try
                    {
                        clSocket.Connect(text1, result);// Kullanıcı adını sunucuya gönderiyor.
                        try
                        {
                            clSocket.Send(Encoding.Default.GetBytes(text2));// Sunucudan gelen yanıtı bekliyor.
                            try
                            {
                                byte[] numArray = new byte[64];
                                clSocket.Receive(numArray);
                                switch (Encoding.Default.GetString(numArray).Trim(new char[1])) // Sunucudan gelen yanıta göre eylemler.
                                {
                                    case "NOT_FOUND":
                                        this.clientLog.AppendText("Lütfen Kullanıcı Adınızı Kontrol Edin\n");
                                        break;
                                    case "Already_Connected":
                                        this.clientLog.AppendText("Bu kullanıcı zaten bağlı.\n");
                                        break;
                                    case "SUCCESS":
                                        // Bağlantı başarılı ise arayüzde değişiklikler yapılıyor.
                                        bt_connect.Enabled = false;
                                        Bt_SendPost.Enabled = true;
                                        bt_disconnect.Enabled = true;
                                        Bt_All_Posts.Enabled = true;
                                        tx_post.Enabled = true;
                                        discontPress = false;
                                        connected = true;
                                        cl_username = text2;
                                        clientLog.AppendText("Merhaba " + text2 + "! Sunucuya bağlandınız.\n");
                                        // Diğer değişiklikler...
                                        new Thread(new ThreadStart(this.Receive)).Start();
                                        bt_connect.BackColor = Color.Green;
                                        bt_disconnect.BackColor = Color.White;
                                        break;
                                }
                            }
                            catch
                            {
                                // Yanıt alınırken hata oluştu.
                                clientLog.AppendText("Yanıt alırken bir sorun oluştu.\n");
                            }
                        }
                        catch
                        {
                            // Kullanıcı adı gönderilirken hata oluştu.

                            clientLog.AppendText("Kullanıcı adı gönderilirken sorun oluştu.\n");
                        }
                    }
                    catch
                    {
                        clientLog.AppendText("Sunucuya bağlanılamadı.\n");
                    }
                }
            }
            else
               clientLog.AppendText("Bağlantı noktasını kontrol edin.\n");// Port numarası doğru değil.
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter tuşuna basıldığında Bt_SendPost_Click metodunu çağır.
            if (e.KeyCode == Keys.Enter)
            {
                Bt_SendPost_Click(this, new EventArgs());
            }
        }

        // Formunuzun yüklenme olayı içerisinde, KeyDown olayını atayın.



        private void Bt_SendPost_Click(object sender, EventArgs e)
        {
            // tx_post.Text'in boş olup olmadığını kontrol ediyor
            if (string.IsNullOrEmpty(this.tx_post.Text))
            {
                clientLog.AppendText("Lütfen bir mesaj giriniz.\n"); // Uyarı mesajı
                return; // Fonksiyonu burada sonlandırıyor
            }

            // Gönderilecek mesajı, "SEND_POSTS" öneki ile metin kutusundaki metni birleştirerek oluşturuyor.
            string s = "SEND_POSTS" + this.tx_post.Text;
            // Metin kutusu temizleniyor.
            this.tx_post.Text = "";
            // Eğer mesaj boş değilse ve 64 karakterden uzunsa, işlemi durdur.
            if (!(s != "") || s.Length > 1000000)
                return;
            byte[] bytes = Encoding.Default.GetBytes(s); // Mesajı byte dizisine çeviriyor.
            try
            {
                clSocket.Send(bytes); // Sunucuya byte dizisini gönderiyor.
                clientLog.AppendText("Başarıyla bir gönderi gönderdiniz!\n"); // Kullanıcı arayüzüne gönderim başarılı olduğuna dair bilgi ekleniyor.
                clientLog.AppendText(this.cl_username + ": " + s.Substring(10) + " \n"); // Kullanıcı adı ve gönderilen mesajı kullanıcı arayüzüne ekliyor.
            }
            catch
            {
                clientLog.AppendText("Gönderinin sunucuya gönderilmesinde bir sorun oluştu.\n"); // Mesaj gönderilirken bir hata oluştuğunda kullanıcıya bilgi veriliyor.
            }
        }

        private void Bt_All_Posts_Click(object sender, EventArgs e)
        {/// "SHOW_POSTS" komutunu byte dizisine çeviriyor.
            byte[] bytes = Encoding.Default.GetBytes("SHOW_POSTS");
            try
            {
                clientLog.AppendText("\nShowing all posts from clients: \n");
                clSocket.Send(bytes);
            }
            catch
            {
                clientLog.AppendText("There was a problem in the request of reaching posts page to server.\n");
            }

        }
        private void Receive()
        {
            while (connected)// Bağlantı devam ettiği sürece bu döngü çalışır.
            {
                try
                {
                    byte[] numArray = new byte[1000000];// Sunucudan gelen mesaj için byte dizisi oluşturuluyor.
                    this.clSocket.Receive(numArray);// Sunucudan mesaj alınıyor.
                    this.clSocket.Send(Encoding.Default.GetBytes("receivedinfo"));// Sunucuya alındığına dair bilgi gönderiliyor.
                    string str1 = Encoding.Default.GetString(numArray);// Byte dizisini string'e çeviriliyor.
                    string str2 = str1.Substring(0, str1.IndexOf("\0"));// Null karakterine kadar olan kısmı alarak temiz bir string elde ediliyor.
                    if (str2.Substring(0, 10) == "SHOW_POSTS")
                    {// Eğer mesaj "SHOW_POSTS" ile başlıyorsa, bu mesajı kullanıcı arayüzüne ekliyor.
                        this.clientLog.AppendText(str2.Substring(10) + "\n");
                    }

                    else if (str2.Substring(0, 10) == "bir mesaj ")
                    {
                        clientLog.AppendText(str2 + "\n");
                    }




                }
                catch
                {
                    if (!this.terminate && !this.discontPress)// Bağlantıda bir sorun oluştuysa veya sunucu bağlantıyı keserse bu blok çalışır.
                    {
                        clientLog.AppendText("Sunucu bağlantısı kesildi.\n");// Kullanıcı arayüzünde sunucunun bağlantıyı kestiğine dair bilgi gösteriliyor.
                        bt_connect.Enabled = true;
                        // Arayüz elemanlarının durumları güncelleniyor
                        tx_post.Enabled = false;
                        Bt_SendPost.Enabled = false;
                        bt_disconnect.Enabled = false;
                        Bt_All_Posts.Enabled = false;
                    }
                    // Soket kapatılıyor ve bağlantı durumu güncelleniyor.
                    clSocket.Close();
                    connected = false;
                }
            }
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            terminate = true;
            Environment.Exit(0);
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        { // "DISCONNECT" komutunu byte dizisine çeviriyor.
            byte[] bytes = Encoding.Default.GetBytes("DISCONNECT");

            try
            {
                // Sunucuya disconnect komutunu gönderiyor.
                clSocket.Send(bytes);

                // disconnect butonuna basıldığını belirten bir flag ayarlanıyor.
                discontPress = true;

                // Arayüzdeki bağlantı durumuna göre buton ve metin kutularının durumlarını güncelliyor.
                bt_connect.Enabled = true;
                tx_post.Enabled = false;
                Bt_SendPost.Enabled = false;
                bt_disconnect.Enabled = false;
                Bt_All_Posts.Enabled = false;

                // Soketi kapatıyor ve bağlantı durumunu güncelliyor.
                clSocket.Close();
                connected = false;

                // Buton renklerini güncelliyor.
                bt_disconnect.BackColor = Color.Red;
                bt_connect.BackColor = Color.White;

                // Kullanıcı arayüzünde başarılı bir şekilde bağlantının kesildiğine dair bilgi veriyor.
                clientLog.AppendText("Bağlantı başarıyla kesildi.\n");
            }
            catch
            {
                // Disconnect isteği gönderilirken bir sorun oluşursa, kullanıcıya bilgi veriliyor.
                clientLog.AppendText("Sunucuya bağlantı kesme isteği gönderirken bir sorun oluştu.\n");
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void koyuTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(45, 45, 48); // Karanlık mod rengi

            // Kullanıcıya bir uyarı mesajı gösterin
            MessageBox.Show("Koyu tema etkinleştirildi.", "Tema Değişikliği", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor = Color.White;
                }
            }

        }

        private void acikTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
            // Varsayılan sistem rengi veya istediğiniz bir açık renk

            // Kullanıcıya bir uyarı mesajı gösterin
            MessageBox.Show("Açık tema etkinleştirildi.", "Tema Değişikliği", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor = SystemColors.ControlText; // Veya başka bir önceden belirlenmiş renk
                }
            }
        }

        private void bt_ekle_Click(object sender, EventArgs e)
        {
            Fr_Login login = new Fr_Login();
            login.Show();
        }

        private void atYarışıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Fr_atyarisi"] == null)
            {
                Fr_atyarisi atyarisi = new Fr_atyarisi();
                atyarisi.Show();
            }
            else
            {
                Application.OpenForms["Fr_atyarisi"].Focus();
                MessageBox.Show("BU Uygulama zaten açık...");
            }
        }
    }
}
