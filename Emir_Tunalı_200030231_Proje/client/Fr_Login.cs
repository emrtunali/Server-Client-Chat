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

namespace client
{
    public partial class Fr_Login : Form
    {
        public Fr_Login()
        {
            InitializeComponent();
        }

        private bool IsUsernameValid(string username)
        {
            try
            {
                // Kullanıcı adlarını içeren dosya okunuyor
                string filePath = Path.Combine(Application.StartupPath, "../../user-db.txt");
                string[] validUsernames = File.ReadAllLines(filePath);

                return validUsernames.Contains(username);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading from file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        

        private void Bt_Login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text; // Kullanıcı adı girişi

            if (IsUsernameValid(username))
            {
                // Kullanıcı adı geçerli ise Fr_Client formunu aç
                Fr_Client clientForm = new Fr_Client(username);
                this.Hide();
                clientForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fr_Login_Load(object sender, EventArgs e)
        {

        }

        private void Bt_Signup_Click(object sender, EventArgs e)
        {
            string textToSave = txt_signup.Text; // TextBox'tan metni al
            string filePath = "../../user-db.txt"; // Dosya yolu

            try
            {
                // Metni dosyaya yaz
                File.AppendAllText(filePath, textToSave + Environment.NewLine);

                // Kayıt başarılı mesajı
                MessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
