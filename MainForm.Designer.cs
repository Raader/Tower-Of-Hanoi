namespace Tower_Of_Hanoi
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.tower3 = new System.Windows.Forms.Panel();
            this.tower2 = new System.Windows.Forms.Panel();
            this.tower1 = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Controls.Add(this.tower3);
            this.gamePanel.Controls.Add(this.tower2);
            this.gamePanel.Controls.Add(this.tower1);
            this.gamePanel.Location = new System.Drawing.Point(25, 15);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(584, 552);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // tower3
            // 
            this.tower3.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower3.Location = new System.Drawing.Point(473, 48);
            this.tower3.Name = "tower3";
            this.tower3.Size = new System.Drawing.Size(25, 465);
            this.tower3.TabIndex = 2;
            // 
            // tower2
            // 
            this.tower2.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower2.Location = new System.Drawing.Point(273, 48);
            this.tower2.Name = "tower2";
            this.tower2.Size = new System.Drawing.Size(25, 465);
            this.tower2.TabIndex = 1;
            // 
            // tower1
            // 
            this.tower1.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower1.Location = new System.Drawing.Point(73, 48);
            this.tower1.Name = "tower1";
            this.tower1.Size = new System.Drawing.Size(25, 465);
            this.tower1.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.Location = new System.Drawing.Point(660, 15);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 552);
            this.sidePanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 594);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.gamePanel);
            this.Name = "MainForm";
            this.Text = "Tower Of Hanoi";
            this.gamePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel tower1;
        private System.Windows.Forms.Panel tower3;
        private System.Windows.Forms.Panel tower2;
    }
}

