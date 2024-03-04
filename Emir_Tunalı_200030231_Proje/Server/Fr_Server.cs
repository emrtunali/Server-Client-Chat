using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Fr_Server : Form
    {
        private int lineCount = System.IO.File.ReadLines("../../user-db.txt").Count<string>();
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> clientSockets = new List<Socket>();
        private List<string> clusername = new List<string>();
        private int postCount = Fr_Server.CountPost();
        private bool terminating = false;
        private bool list = false;
        //private IContainer components = (IContainer)null;
       private Label label_port;
     
       
        public Fr_Server()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Btn_List_Click(object sender, EventArgs e)
        {


            int result;
            if (int.TryParse(this.txt_port.Text, out result))
            {
                serverSocket.Bind((EndPoint)new IPEndPoint(IPAddress.Any, result));
                serverSocket.Listen(3);
                list = true;
                Btn_List.Enabled = false;
                new Thread(new ThreadStart(this.Accept)).Start();
                this.rct_serverLog.AppendText("Bağlantı noktasında başlatılan liste: " + (object)result + "\n");
                this.Btn_List.BackColor = Color.Green;
            }
            else
                this.rct_serverLog.AppendText("Lütfen port numarasını kontrol edin. \n");
        }

        private void Accept()
        {
            while (this.list)
            {
                try
                {
                    Socket newClient = this.serverSocket.Accept();
                    new Thread((ThreadStart)(() => this.usernameCheck(newClient))).Start();
                }
                catch
                {
                    if (this.terminating)
                        this.list = false;
                    else
                        this.rct_serverLog.AppendText("Soket programı çalışmayı durdurdu.\n");
                }
            }
        }
        private void usernameCheck(Socket thisClient)
        {
            string s = "NOT_FOUND";
            try
            {
                byte[] numArray = new byte[1000000];
                thisClient.Receive(numArray);
                string username = Encoding.Default.GetString(numArray);
                username = username.Substring(0, username.IndexOf("\0"));
                if (this.clusername.Contains(username))
                {
                    this.rct_serverLog.AppendText(username + " başka bir istemciden bağlanmaya çalıştı!\n");
                    s = "Already_Connected";
                }
                else
                {
                    foreach (string readLine in System.IO.File.ReadLines("../../user-db.txt"))
                    {
                        if (readLine == username)
                        {
                            this.clientSockets.Add(thisClient);
                            this.clusername.Add(username);
                            s = "SUCCESS";
                            this.rct_serverLog.AppendText(username + " bağlandı.\n");
                            new Thread((ThreadStart)(() => this.Receive(thisClient, username))).Start();
                        }
                    }
                }
                if (s == "NOT_FOUND")
                    this.rct_serverLog.AppendText(username + " sunucuya bağlanmaya çalıştı ancak bağlanamıyor!\n");
                try
                {
                    thisClient.Send(Encoding.Default.GetBytes(s));
                }
                catch
                {
                   rct_serverLog.AppendText("Kullanıcı adı yanıtı istemciye gönderilirken bir sorun oluştu.\n");
                }
            }
            catch
            {
                rct_serverLog.AppendText("Kullanıcı adı alma sorunu.\n");
            }
        }
        private void Receive(Socket thisClient, string username)
        {
            bool flag = true;
            while (flag && !this.terminating)
            {
                try
                {
                    byte[] numArray = new byte[1000000];
                    thisClient.Receive(numArray);
                    string str = Encoding.Default.GetString(numArray).Trim(new char[1]);
                    if (str.Substring(0, 10) == "DISCONNECT")
                    {
                        thisClient.Close();
                        clientSockets.Remove(thisClient);
                        clusername.Remove(username);
                        flag = false;
                        rct_serverLog.AppendText(username + " bağlantısı kesildi.\n");
                    }
                    else if (str.Substring(0, 10) == "SHOW_POSTS") 
                    {
                        this.allposts(thisClient, username);

                    }
                       
                    else if (str.Substring(0, 10) == "SEND_POSTS")
                    {
                        string post = str.Substring(10);
                        ++this.postCount;
                        postToLog(username, (object)this.postCount, post);
                    }
                }
                catch
                {
                    if (!this.terminating)
                        this.rct_serverLog.AppendText(username + " bağlantı kesildi.\n");
                    thisClient.Close();
                    this.clientSockets.Remove(thisClient);
                    this.clusername.Remove(username);
                    flag = false;
                }
            }
        }

        //private void BroadcastMessage(string message)
        //{
        //    byte[] buffer = Encoding.Default.GetBytes(message);

        //    // clientSockets listesindeki her bir client için döngü oluşturur
        //    foreach (Socket client in clientSockets)
        //    {
        //        try
        //        {
        //            if (client != null && client.Connected)
        //            {
        //                client.Send(buffer); // Buffer'ı (mesajı) mevcut client'a gönderir
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Gönderme işlemi sırasında bir hata oluşursa burada işlenir
        //            // Hata mesajını yazdırabilirsiniz veya loglayabilirsiniz
        //            Console.WriteLine("Hata: " + ex.Message);

        //            // İsteğe bağlı olarak, hata veren client'ı listeden çıkarabilirsiniz
        //            client.Close();
        //            clientSockets.Remove(client);
        //        }
        //    }
        //}


        private void postToLog(string username, object postID, string post)
        {
            
            string str = DateTime.Now.ToString("s");
            using (StreamWriter streamWriter = new StreamWriter("../../posts.txt", true))
            streamWriter.WriteLine(str + " /" + username + "/" + postID.ToString() + "/" + post + "/");
            rct_serverLog.AppendText(username + " bir mesaj gönderdi:\n" + post + "\n");

            byte[] bytes1 = Encoding.Default.GetBytes("bir mesaj gönderdi " + username + ": " + post);
            foreach (Socket clientSocket in clientSockets)
            {
                try
                {
                    clientSocket.Send(bytes1);
                    rct_serverLog.AppendText("Herkese gönderilddi");
                }
                catch (Exception ex)
                {

                    rct_serverLog.AppendText("Hata:"+ ex);
                }
               
            }
        }

        private string GetTime()
        {
                                    string str = DateTime.Now.ToString("s");
            return str.Substring(0, str.Length - 3);
        }

        private void allposts(Socket thisClient, string username)
        {
            string input = System.IO.File.ReadAllText("../../posts.txt");
            string pattern = "\\d\\d\\d\\d[-]\\d\\d[-]\\d\\d[T]\\d\\d[:]\\d\\d[:]\\d\\d";
            string[] strArray = new Regex(pattern).Split(input);
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            for (int index = 1; index < strArray.Length; index++)
            {
                int num1 = strArray[index].IndexOf("/", 2);
                int num2 = strArray[index].IndexOf("/", num1 + 1);
                string str1 = strArray[index].Substring(2, num1 - 2);
                string str2 = strArray[index].Substring(num1 + 1, num2 - num1 - 1);
                string str3 = strArray[index].Substring(num2 + 1, strArray[index].Length - 4 - num2);
              

                    byte[] bytes1 = Encoding.Default.GetBytes("SHOW_POSTSUsername: " + str1);

                    thisClient.Send(bytes1);
                    byte[] numArray1 = new byte[5000000];
                    thisClient.Receive(numArray1);
                    Encoding.Default.GetString(numArray1);
                    byte[] bytes2 = Encoding.Default.GetBytes("SHOW_POSTSPostID: " + str2);

                    thisClient.Send(bytes2);
                    byte[] numArray2 = new byte[5000000];
                    thisClient.Receive(numArray1);
                    Encoding.Default.GetString(numArray1);
                    byte[] bytes3 = Encoding.Default.GetBytes("SHOW_POSTSPost: " + str3);

                    thisClient.Send(bytes3);
                    byte[] numArray3 = new byte[5000];
                    thisClient.Receive(numArray1);
                    Encoding.Default.GetString(numArray1);
                    byte[] bytes4 = Encoding.Default.GetBytes("SHOW_POSTSTime: " + (object)matchCollection[index - 1] + "\n");

                    thisClient.Send(bytes4);
                    byte[] numArray4 = new byte[5000000];
                    thisClient.Receive(numArray1);
                    Encoding.Default.GetString(numArray1);


                
            }
            rct_serverLog.AppendText("Showed all posts for " + username + ".\n");
        }
        private static int CountPost()
        {

            if (!System.IO.File.Exists("../../posts.log"))
                System.IO.File.Create("../../posts.log").Dispose();
            string input = System.IO.File.ReadAllText("../../posts.log");
            if (input == "")
                return 0;
            string[] strArray = new Regex("\\d\\d\\d\\d[-]\\d\\d[-]\\d\\d[T]\\d\\d[:]\\d\\d[:]\\d\\d").Split(input);
            int num1 = strArray[strArray.Length - 1].IndexOf("/", 2);
            int num2 = strArray[strArray.Length - 1].IndexOf("/", num1 + 1);
            return int.Parse(strArray[strArray.Length - 1].Substring(num1 + 1, num2 - num1 - 1));
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

        private void koyuTemaToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            list= false;
            terminating = true;
           
            Environment.Exit(0);
          
        }

      
















    }
}
