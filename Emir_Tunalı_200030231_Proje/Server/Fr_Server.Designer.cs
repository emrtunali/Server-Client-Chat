namespace Server
{
    partial class Fr_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fr_Server));
            this.lb_port = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.rct_serverLog = new System.Windows.Forms.RichTextBox();
            this.Btn_List = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acikTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koyuTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_port.Location = new System.Drawing.Point(15, 62);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(44, 18);
            this.lb_port.TabIndex = 0;
            this.lb_port.Text = "Port :";
            // 
            // txt_port
            // 
            this.txt_port.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_port.Location = new System.Drawing.Point(75, 62);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 22);
            this.txt_port.TabIndex = 1;
            // 
            // rct_serverLog
            // 
            this.rct_serverLog.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rct_serverLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rct_serverLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rct_serverLog.Location = new System.Drawing.Point(21, 103);
            this.rct_serverLog.Name = "rct_serverLog";
            this.rct_serverLog.Size = new System.Drawing.Size(320, 351);
            this.rct_serverLog.TabIndex = 2;
            this.rct_serverLog.Text = "";
            // 
            // Btn_List
            // 
            this.Btn_List.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Btn_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_List.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_List.Location = new System.Drawing.Point(191, 62);
            this.Btn_List.Name = "Btn_List";
            this.Btn_List.Size = new System.Drawing.Size(96, 22);
            this.Btn_List.TabIndex = 3;
            this.Btn_List.Text = "Listen";
            this.Btn_List.UseVisualStyleBackColor = true;
            this.Btn_List.Click += new System.EventHandler(this.Btn_List_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acikTemaToolStripMenuItem,
            this.koyuTemaToolStripMenuItem});
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.temaToolStripMenuItem.Text = "Tema";
            // 
            // acikTemaToolStripMenuItem
            // 
            this.acikTemaToolStripMenuItem.Name = "acikTemaToolStripMenuItem";
            this.acikTemaToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.acikTemaToolStripMenuItem.Text = "Açık Tema";
            this.acikTemaToolStripMenuItem.Click += new System.EventHandler(this.acikTemaToolStripMenuItem_Click);
            // 
            // koyuTemaToolStripMenuItem
            // 
            this.koyuTemaToolStripMenuItem.Name = "koyuTemaToolStripMenuItem";
            this.koyuTemaToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.koyuTemaToolStripMenuItem.Text = "Koyu Tema";
            this.koyuTemaToolStripMenuItem.Click += new System.EventHandler(this.koyuTemaToolStripMenuItem_Click_1);
            // 
            // Fr_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(708, 508);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Btn_List);
            this.Controls.Add(this.rct_serverLog);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lb_port);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fr_Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.RichTextBox rct_serverLog;
        private System.Windows.Forms.Button Btn_List;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acikTemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koyuTemaToolStripMenuItem;
    }
}

