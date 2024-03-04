namespace client
{
    partial class Fr_Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fr_Client));
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_usernm = new System.Windows.Forms.Label();
            this.txIP = new System.Windows.Forms.TextBox();
            this.txPort = new System.Windows.Forms.TextBox();
            this.txUsername = new System.Windows.Forms.TextBox();
            this.tx_post = new System.Windows.Forms.TextBox();
            this.lb_post = new System.Windows.Forms.Label();
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.Bt_SendPost = new System.Windows.Forms.Button();
            this.Bt_All_Posts = new System.Windows.Forms.Button();
            this.clientLog = new System.Windows.Forms.RichTextBox();
            this.ch_mode = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acikTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koyuTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oyunlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atYarışıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_ekle = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_IP
            // 
            resources.ApplyResources(this.lb_IP, "lb_IP");
            this.lb_IP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_IP.Name = "lb_IP";
            // 
            // lb_port
            // 
            resources.ApplyResources(this.lb_port, "lb_port");
            this.lb_port.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_port.Name = "lb_port";
            // 
            // lb_usernm
            // 
            resources.ApplyResources(this.lb_usernm, "lb_usernm");
            this.lb_usernm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_usernm.Name = "lb_usernm";
            // 
            // txIP
            // 
            this.txIP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txIP, "txIP");
            this.txIP.Name = "txIP";
            // 
            // txPort
            // 
            this.txPort.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txPort, "txPort");
            this.txPort.Name = "txPort";
            // 
            // txUsername
            // 
            this.txUsername.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txUsername, "txUsername");
            this.txUsername.Name = "txUsername";
            // 
            // tx_post
            // 
            this.tx_post.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tx_post.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tx_post, "tx_post");
            this.tx_post.Name = "tx_post";
            // 
            // lb_post
            // 
            resources.ApplyResources(this.lb_post, "lb_post");
            this.lb_post.Name = "lb_post";
            // 
            // bt_connect
            // 
            this.bt_connect.BackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.bt_connect, "bt_connect");
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.UseVisualStyleBackColor = false;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.BackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.bt_disconnect, "bt_disconnect");
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = false;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // Bt_SendPost
            // 
            this.Bt_SendPost.BackColor = System.Drawing.Color.SeaGreen;
            resources.ApplyResources(this.Bt_SendPost, "Bt_SendPost");
            this.Bt_SendPost.Name = "Bt_SendPost";
            this.Bt_SendPost.UseVisualStyleBackColor = false;
            this.Bt_SendPost.Click += new System.EventHandler(this.Bt_SendPost_Click);
            // 
            // Bt_All_Posts
            // 
            this.Bt_All_Posts.BackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.Bt_All_Posts, "Bt_All_Posts");
            this.Bt_All_Posts.Name = "Bt_All_Posts";
            this.Bt_All_Posts.UseVisualStyleBackColor = false;
            this.Bt_All_Posts.Click += new System.EventHandler(this.Bt_All_Posts_Click);
            // 
            // clientLog
            // 
            this.clientLog.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clientLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.clientLog, "clientLog");
            this.clientLog.Name = "clientLog";
            // 
            // ch_mode
            // 
            resources.ApplyResources(this.ch_mode, "ch_mode");
            this.ch_mode.Name = "ch_mode";
            this.ch_mode.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaToolStripMenuItem,
            this.oyunlarToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acikTemaToolStripMenuItem,
            this.koyuTemaToolStripMenuItem});
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            resources.ApplyResources(this.temaToolStripMenuItem, "temaToolStripMenuItem");
            // 
            // acikTemaToolStripMenuItem
            // 
            this.acikTemaToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.acikTemaToolStripMenuItem.Name = "acikTemaToolStripMenuItem";
            resources.ApplyResources(this.acikTemaToolStripMenuItem, "acikTemaToolStripMenuItem");
            this.acikTemaToolStripMenuItem.Click += new System.EventHandler(this.acikTemaToolStripMenuItem_Click);
            // 
            // koyuTemaToolStripMenuItem
            // 
            this.koyuTemaToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.koyuTemaToolStripMenuItem.Name = "koyuTemaToolStripMenuItem";
            resources.ApplyResources(this.koyuTemaToolStripMenuItem, "koyuTemaToolStripMenuItem");
            this.koyuTemaToolStripMenuItem.Click += new System.EventHandler(this.koyuTemaToolStripMenuItem_Click);
            // 
            // oyunlarToolStripMenuItem
            // 
            this.oyunlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atYarışıToolStripMenuItem});
            this.oyunlarToolStripMenuItem.Name = "oyunlarToolStripMenuItem";
            resources.ApplyResources(this.oyunlarToolStripMenuItem, "oyunlarToolStripMenuItem");
            // 
            // atYarışıToolStripMenuItem
            // 
            this.atYarışıToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.atYarışıToolStripMenuItem.Name = "atYarışıToolStripMenuItem";
            resources.ApplyResources(this.atYarışıToolStripMenuItem, "atYarışıToolStripMenuItem");
            this.atYarışıToolStripMenuItem.Click += new System.EventHandler(this.atYarışıToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txIP);
            this.groupBox1.Controls.Add(this.lb_IP);
            this.groupBox1.Controls.Add(this.lb_port);
            this.groupBox1.Controls.Add(this.lb_usernm);
            this.groupBox1.Controls.Add(this.txPort);
            this.groupBox1.Controls.Add(this.txUsername);
            this.groupBox1.Controls.Add(this.bt_connect);
            this.groupBox1.Controls.Add(this.bt_disconnect);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // bt_ekle
            // 
            this.bt_ekle.BackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.bt_ekle, "bt_ekle");
            this.bt_ekle.Name = "bt_ekle";
            this.bt_ekle.UseVisualStyleBackColor = false;
            this.bt_ekle.Click += new System.EventHandler(this.bt_ekle_Click);
            // 
            // Fr_Client
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Controls.Add(this.bt_ekle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ch_mode);
            this.Controls.Add(this.clientLog);
            this.Controls.Add(this.Bt_All_Posts);
            this.Controls.Add(this.Bt_SendPost);
            this.Controls.Add(this.lb_post);
            this.Controls.Add(this.tx_post);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Fr_Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_usernm;
        private System.Windows.Forms.TextBox txIP;
        private System.Windows.Forms.TextBox txPort;
        private System.Windows.Forms.TextBox txUsername;
        private System.Windows.Forms.TextBox tx_post;
        private System.Windows.Forms.Label lb_post;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Button Bt_SendPost;
        private System.Windows.Forms.Button Bt_All_Posts;
        private System.Windows.Forms.RichTextBox clientLog;
        private System.Windows.Forms.CheckBox ch_mode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acikTemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koyuTemaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_ekle;
        private System.Windows.Forms.ToolStripMenuItem oyunlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atYarışıToolStripMenuItem;
    }
}

