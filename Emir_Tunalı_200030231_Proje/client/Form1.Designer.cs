namespace client
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
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tx_post = new System.Windows.Forms.TextBox();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.Bt_SendPost = new System.Windows.Forms.Button();
            this.Bt_All_Posts = new System.Windows.Forms.Button();
            this.clientLog = new System.Windows.Forms.RichTextBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_usernm = new System.Windows.Forms.Label();
            this.txIP = new System.Windows.Forms.TextBox();
            this.txPort = new System.Windows.Forms.TextBox();
            this.txUsername = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.addFriend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addFriendLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tx_post
            // 
            this.tx_post.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tx_post.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tx_post.Location = new System.Drawing.Point(312, 507);
            this.tx_post.Margin = new System.Windows.Forms.Padding(0);
            this.tx_post.Multiline = true;
            this.tx_post.Name = "tx_post";
            this.tx_post.Size = new System.Drawing.Size(291, 39);
            this.tx_post.TabIndex = 6;
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bt_disconnect.Location = new System.Drawing.Point(216, 46);
            this.bt_disconnect.Margin = new System.Windows.Forms.Padding(0);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(72, 32);
            this.bt_disconnect.TabIndex = 9;
            this.bt_disconnect.Text = "Disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // Bt_SendPost
            // 
            this.Bt_SendPost.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bt_SendPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bt_SendPost.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_SendPost.Location = new System.Drawing.Point(603, 507);
            this.Bt_SendPost.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_SendPost.Name = "Bt_SendPost";
            this.Bt_SendPost.Size = new System.Drawing.Size(108, 39);
            this.Bt_SendPost.TabIndex = 10;
            this.Bt_SendPost.Text = "Gönder";
            this.Bt_SendPost.UseVisualStyleBackColor = false;
            this.Bt_SendPost.Click += new System.EventHandler(this.Bt_SendPost_Click);
            // 
            // Bt_All_Posts
            // 
            this.Bt_All_Posts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bt_All_Posts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bt_All_Posts.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_All_Posts.Location = new System.Drawing.Point(189, 507);
            this.Bt_All_Posts.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_All_Posts.Name = "Bt_All_Posts";
            this.Bt_All_Posts.Size = new System.Drawing.Size(120, 39);
            this.Bt_All_Posts.TabIndex = 11;
            this.Bt_All_Posts.Text = "Tüm Mesajlar";
            this.Bt_All_Posts.UseVisualStyleBackColor = false;
            this.Bt_All_Posts.Click += new System.EventHandler(this.Bt_All_Posts_Click);
            // 
            // clientLog
            // 
            this.clientLog.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.clientLog.Location = new System.Drawing.Point(312, 6);
            this.clientLog.Margin = new System.Windows.Forms.Padding(0);
            this.clientLog.Name = "clientLog";
            this.clientLog.Size = new System.Drawing.Size(399, 492);
            this.clientLog.TabIndex = 12;
            this.clientLog.Text = "";
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(12, 13);
            this.lb_IP.Margin = new System.Windows.Forms.Padding(0);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(23, 13);
            this.lb_IP.TabIndex = 0;
            this.lb_IP.Text = "IP :";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(12, 32);
            this.lb_port.Margin = new System.Windows.Forms.Padding(0);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(29, 13);
            this.lb_port.TabIndex = 1;
            this.lb_port.Text = "Port:";
            // 
            // lb_usernm
            // 
            this.lb_usernm.AutoSize = true;
            this.lb_usernm.Location = new System.Drawing.Point(12, 58);
            this.lb_usernm.Margin = new System.Windows.Forms.Padding(0);
            this.lb_usernm.Name = "lb_usernm";
            this.lb_usernm.Size = new System.Drawing.Size(61, 13);
            this.lb_usernm.TabIndex = 2;
            this.lb_usernm.Text = "Username :";
            // 
            // txIP
            // 
            this.txIP.Location = new System.Drawing.Point(84, 6);
            this.txIP.Margin = new System.Windows.Forms.Padding(0);
            this.txIP.Name = "txIP";
            this.txIP.Size = new System.Drawing.Size(118, 20);
            this.txIP.TabIndex = 3;
            // 
            // txPort
            // 
            this.txPort.Location = new System.Drawing.Point(84, 32);
            this.txPort.Margin = new System.Windows.Forms.Padding(0);
            this.txPort.Name = "txPort";
            this.txPort.Size = new System.Drawing.Size(118, 20);
            this.txPort.TabIndex = 4;
            // 
            // txUsername
            // 
            this.txUsername.Location = new System.Drawing.Point(84, 58);
            this.txUsername.Margin = new System.Windows.Forms.Padding(0);
            this.txUsername.Name = "txUsername";
            this.txUsername.Size = new System.Drawing.Size(118, 20);
            this.txUsername.TabIndex = 5;
            // 
            // bt_connect
            // 
            this.bt_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bt_connect.Location = new System.Drawing.Point(216, 13);
            this.bt_connect.Margin = new System.Windows.Forms.Padding(0);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(72, 32);
            this.bt_connect.TabIndex = 8;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // addFriend
            // 
            this.addFriend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addFriend.Enabled = false;
            this.addFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addFriend.ForeColor = System.Drawing.SystemColors.Control;
            this.addFriend.Location = new System.Drawing.Point(2, 507);
            this.addFriend.Margin = new System.Windows.Forms.Padding(0);
            this.addFriend.Name = "addFriend";
            this.addFriend.Size = new System.Drawing.Size(185, 39);
            this.addFriend.TabIndex = 13;
            this.addFriend.Text = "Arkadaş Ekle";
            this.addFriend.UseVisualStyleBackColor = false;
            this.addFriend.Click += new System.EventHandler(this.addFriend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Kalan Mesaj Hakkınız : 3";
            // 
            // addFriendLabel
            // 
            this.addFriendLabel.AutoSize = true;
            this.addFriendLabel.Location = new System.Drawing.Point(4, 485);
            this.addFriendLabel.Name = "addFriendLabel";
            this.addFriendLabel.Size = new System.Drawing.Size(224, 13);
            this.addFriendLabel.TabIndex = 15;
            this.addFriendLabel.Text = "Daha fazla sohbet için arkadaş olarak ekleyin.";
            this.addFriendLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(720, 552);
            this.Controls.Add(this.addFriendLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addFriend);
            this.Controls.Add(this.clientLog);
            this.Controls.Add(this.Bt_All_Posts);
            this.Controls.Add(this.Bt_SendPost);
            this.Controls.Add(this.bt_disconnect);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.tx_post);
            this.Controls.Add(this.txUsername);
            this.Controls.Add(this.txPort);
            this.Controls.Add(this.txIP);
            this.Controls.Add(this.lb_usernm);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_IP);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tx_post;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Button Bt_SendPost;
        private System.Windows.Forms.Button Bt_All_Posts;
        private System.Windows.Forms.RichTextBox clientLog;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_usernm;
        private System.Windows.Forms.TextBox txIP;
        private System.Windows.Forms.TextBox txPort;
        private System.Windows.Forms.TextBox txUsername;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button addFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addFriendLabel;
    }
}

