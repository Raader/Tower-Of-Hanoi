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
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.scrollForward = new System.Windows.Forms.Button();
            this.scrollBack = new System.Windows.Forms.Button();
            this.scrollIndicator = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.blockCountInputField = new System.Windows.Forms.NumericUpDown();
            this.gamePanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blockCountInputField)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.gamePanel.Controls.Add(this.tower3);
            this.gamePanel.Controls.Add(this.tower2);
            this.gamePanel.Controls.Add(this.tower1);
            this.gamePanel.Location = new System.Drawing.Point(12, 12);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(829, 628);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // tower3
            // 
            this.tower3.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower3.Location = new System.Drawing.Point(646, 53);
            this.tower3.Name = "tower3";
            this.tower3.Size = new System.Drawing.Size(30, 525);
            this.tower3.TabIndex = 2;
            // 
            // tower2
            // 
            this.tower2.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower2.Location = new System.Drawing.Point(396, 53);
            this.tower2.Name = "tower2";
            this.tower2.Size = new System.Drawing.Size(30, 525);
            this.tower2.TabIndex = 1;
            // 
            // tower1
            // 
            this.tower1.BackColor = System.Drawing.SystemColors.GrayText;
            this.tower1.Location = new System.Drawing.Point(146, 53);
            this.tower1.Name = "tower1";
            this.tower1.Size = new System.Drawing.Size(30, 525);
            this.tower1.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sidePanel.Controls.Add(this.scrollPanel);
            this.sidePanel.Controls.Add(this.solveButton);
            this.sidePanel.Controls.Add(this.restartButton);
            this.sidePanel.Controls.Add(this.blockCountInputField);
            this.sidePanel.Location = new System.Drawing.Point(847, 15);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(217, 625);
            this.sidePanel.TabIndex = 1;
            this.sidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sidePanel_Paint);
            // 
            // scrollPanel
            // 
            this.scrollPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scrollPanel.Controls.Add(this.scrollForward);
            this.scrollPanel.Controls.Add(this.scrollBack);
            this.scrollPanel.Controls.Add(this.scrollIndicator);
            this.scrollPanel.Location = new System.Drawing.Point(43, 346);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(120, 169);
            this.scrollPanel.TabIndex = 3;
            // 
            // scrollForward
            // 
            this.scrollForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scrollForward.Location = new System.Drawing.Point(83, 32);
            this.scrollForward.Name = "scrollForward";
            this.scrollForward.Size = new System.Drawing.Size(34, 23);
            this.scrollForward.TabIndex = 2;
            this.scrollForward.Text = ">>";
            this.scrollForward.UseVisualStyleBackColor = true;
            // 
            // scrollBack
            // 
            this.scrollBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scrollBack.Location = new System.Drawing.Point(3, 32);
            this.scrollBack.Name = "scrollBack";
            this.scrollBack.Size = new System.Drawing.Size(34, 23);
            this.scrollBack.TabIndex = 1;
            this.scrollBack.Text = "<<";
            this.scrollBack.UseVisualStyleBackColor = true;
            // 
            // scrollIndicator
            // 
            this.scrollIndicator.AutoSize = true;
            this.scrollIndicator.Location = new System.Drawing.Point(43, 37);
            this.scrollIndicator.Name = "scrollIndicator";
            this.scrollIndicator.Size = new System.Drawing.Size(24, 13);
            this.scrollIndicator.TabIndex = 0;
            this.scrollIndicator.Text = "0/0";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(43, 198);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(120, 33);
            this.solveButton.TabIndex = 2;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(43, 124);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(120, 33);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // blockCountInputField
            // 
            this.blockCountInputField.Location = new System.Drawing.Point(43, 50);
            this.blockCountInputField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blockCountInputField.Name = "blockCountInputField";
            this.blockCountInputField.Size = new System.Drawing.Size(120, 20);
            this.blockCountInputField.TabIndex = 0;
            this.blockCountInputField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 652);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.gamePanel);
            this.Name = "MainForm";
            this.Text = "Tower Of Hanoi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gamePanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blockCountInputField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel tower1;
        private System.Windows.Forms.Panel tower3;
        private System.Windows.Forms.Panel tower2;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.Button scrollForward;
        private System.Windows.Forms.Button scrollBack;
        private System.Windows.Forms.Label scrollIndicator;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.NumericUpDown blockCountInputField;
    }
}

