namespace BombPlane
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.HelpPageTitle = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelpPageTitle
            // 
            this.HelpPageTitle.AutoSize = true;
            this.HelpPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.HelpPageTitle.Font = new System.Drawing.Font("华文中宋", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelpPageTitle.Location = new System.Drawing.Point(364, 68);
            this.HelpPageTitle.Name = "HelpPageTitle";
            this.HelpPageTitle.Size = new System.Drawing.Size(131, 60);
            this.HelpPageTitle.TabIndex = 0;
            this.HelpPageTitle.Text = "帮助";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReturnButton.Location = new System.Drawing.Point(342, 397);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(176, 88);
            this.ReturnButton.TabIndex = 1;
            this.ReturnButton.Text = "返回";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(205, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 224);
            this.label1.TabIndex = 2;
            this.label1.Text = "       每个人在各自10×10的格子中放3个飞机，之后轮流在对方格子中选点爆破，先炸到对方3个机头的一方获胜。\r\n\r\n       实在看不懂玩两把就会了。" +
    "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(896, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.HelpPageTitle);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HelpForm";
            this.Text = "HelpPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HelpForm_FormClosed);
            this.Load += new System.EventHandler(this.HelpPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelpPageTitle;
        private System.Windows.Forms.Button ReturnButton;
        private Label label1;
    }
}