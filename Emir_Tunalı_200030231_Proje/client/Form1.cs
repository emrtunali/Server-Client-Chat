using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace client
{
    public partial class Form1 : Form
    {
        private int sentMessageCount = 0;
        private bool isMyFriend = false;


        private bool terminating = false;

        private bool connected = false;
        private bool disconnectPressed = false;
        private string clientUsername = "";

        private Socket clientSocket;


        public DateTime nowTime;

        public string GetTime()
        {
            nowTime = DateTime.Now;
            return nowTime.ToString("HH:mm");
        }

        //private System.ComponentModel.IContainer components = null;




        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Form1_Closing);
            this.InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string text1 = this.txIP.Text;
            int result;
            if (int.TryParse(this.txPort.Text, out result))
            {
                string text2 = this.txUsername.Text;
                if (text2 == "")
                    this.clientLog.AppendText("Lütfen kullanıcı adı girin.\n");
                else if (text1 == "")
                {
                    this.clientLog.AppendText("Lütfen bir IP adresi girin.\n");
                }
                else
                {
                    try
                    {
                        this.clientSocket.Connect(text1, result);
                        try
                        {
                            this.clientSocket.Send(Encoding.Default.GetBytes(text2));
                            try
                            {
                                byte[] numArray = new byte[64];
                                this.clientSocket.Receive(numArray);
                                switch (Encoding.Default.GetString(numArray).Trim(new char[1]))
                                {
                                    case "NOT_FOUND":
                                        this.clientLog.AppendText("Lütfen geçerli bir kullanıcı adı girin.\n");
                                        break;
                                    case "Already_Connected":
                                        this.clientLog.AppendText("Bu kullanıcı sunucuya bağlı durumda.\n");
                                        break;
                                    case "SUCCESS":
                                        this.bt_connect.Enabled = false;
                                        this.Bt_SendPost.Enabled = true;
                                        this.bt_disconnect.Enabled = true;
                                        this.Bt_All_Posts.Enabled = true;
                                        this.tx_post.Enabled = true;
                                        this.disconnectPressed = false;
                                        this.connected = true;
                                        this.clientUsername = text2;
                                        this.clientLog.AppendText(text2 + " olarak sunucuya bağlandınız. \n");
                                        new Thread(new ThreadStart(this.Receive)).Start();
                                        break;
                                }
                            }
                            catch
                            {
                                this.clientLog.AppendText("There was a problem receiving response.\n");
                            }
                        }
                        catch
                        {
                            this.clientLog.AppendText("Problem occured while username is sent.\n");
                        }
                    }
                    catch
                    {
                        this.clientLog.AppendText("Could not connect to the server.\n");
                    }
                }
            }
            else
                this.clientLog.AppendText("Port numarasını kontrol edin.\n");
        }


        private void Bt_SendPost_Click(object sender, EventArgs e)
        {
            if (isMyFriend == true)
            {
                string s = "SEND_POSTS" + this.tx_post.Text;
                this.tx_post.Text = "";
                if (!(s != "") || s.Length > 64)
                    return;
                byte[] bytes = Encoding.Default.GetBytes(s);
                try
                {
                    this.clientSocket.Send(bytes);
                    this.clientLog.AppendText(this.clientUsername + " : " + GetTime() + "\n");
                    this.clientLog.AppendText(s.Substring(10) + " \n\n");
                }
                catch
                {
                    this.clientLog.AppendText("There was a problem sending the post to the server.\n");
                }
            }
            else if (sentMessageCount < 3)
            {
                string s = "SEND_POSTS" + this.tx_post.Text;
                this.tx_post.Text = "";
                if (!(s != "") || s.Length > 64)
                    return;
                byte[] bytes = Encoding.Default.GetBytes(s);
                try
                {
                    this.clientSocket.Send(bytes);
                    this.clientLog.AppendText(this.clientUsername + " : " + GetTime() + "\n");
                    this.clientLog.AppendText(s.Substring(10) + " \n\n");
                    sentMessageCount++;
                    label1.Text = $"Kalan Mesaj Hakkınız : {3 - sentMessageCount}";
                }
                catch
                {
                    this.clientLog.AppendText("There was a problem sending the post to the server.\n");
                }
            }
            else
            {
                Bt_SendPost.Enabled = false;
                addFriend.Enabled = true;
                addFriendLabel.Visible = true;
            }
            
        }

        private void Bt_All_Posts_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("SHOW_POSTS");
            try
            {
                this.clientLog.AppendText("\nBütün istemci mesajları : \n");
                this.clientSocket.Send(bytes);
            }
            catch
            {
                this.clientLog.AppendText("There was a problem in the request of reaching posts page to server.\n");
            }

        }
        private void Receive()
        {
            while (this.connected)
            {
                try
                {
                    byte[] numArray = new byte[64];
                    this.clientSocket.Receive(numArray);
                    this.clientSocket.Send(Encoding.Default.GetBytes("receivedinfo"));
                    string str1 = Encoding.Default.GetString(numArray);
                    string str2 = str1.Substring(0, str1.IndexOf("\0"));
                    if (str2.Substring(0, 10) == "SHOW_POSTS")
                        this.clientLog.AppendText(str2.Substring(10) + "\n");
                }
                catch
                {
                    if (!this.terminating && !this.disconnectPressed)
                    {
                        this.clientLog.AppendText("Server bağlantısı kesildi.\n");
                        this.bt_connect.Enabled = true;
                        this.tx_post.Enabled = false;
                        this.Bt_SendPost.Enabled = false;
                        this.bt_disconnect.Enabled = false;
                        this.Bt_All_Posts.Enabled = false;
                    }
                    this.clientSocket.Close();
                    this.connected = false;
                }
            }
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            this.connected = false;
            this.terminating = true;
            Environment.Exit(0);
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("DISCONNECT");
            try
            {
                this.clientSocket.Send(bytes);
                this.disconnectPressed = true;
                this.bt_connect.Enabled = true;
                this.tx_post.Enabled = false;
                this.Bt_SendPost.Enabled = false;
                this.bt_disconnect.Enabled = false;
                this.Bt_All_Posts.Enabled = false;
                this.clientSocket.Close();
                this.connected = false;
                this.clientLog.AppendText("Sunucu ile bağlantıyı kestiniz.\n");
            }
            catch
            {
                this.clientLog.AppendText("There was a problem sending disconnect request to server.\n");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void addFriend_Click(object sender, EventArgs e)
        {
            Bt_SendPost.Enabled = true;
            addFriend.Enabled = false;
            label1.Visible = false;
            addFriendLabel.Visible = false;
            isMyFriend = true;
            this.clientLog.AppendText(clientUsername + " Arkadaş olarak eklendi. \n\n");
        }
    }
}