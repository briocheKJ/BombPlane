namespace BombPlane
{
    partial class AITestForm
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
            this.TestProgressLbl = new System.Windows.Forms.Label();
            this.WinLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ExpectStepLbl = new System.Windows.Forms.Label();
            this.MaxStepLbl = new System.Windows.Forms.Label();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestProgressLbl
            // 
            this.TestProgressLbl.AutoSize = true;
            this.TestProgressLbl.Location = new System.Drawing.Point(65, 51);
            this.TestProgressLbl.Name = "TestProgressLbl";
            this.TestProgressLbl.Size = new System.Drawing.Size(148, 24);
            this.TestProgressLbl.TabIndex = 0;
            this.TestProgressLbl.Text = "已进行局数：0/0";
            // 
            // WinLbl
            // 
            this.WinLbl.AutoSize = true;
            this.WinLbl.Location = new System.Drawing.Point(65, 84);
            this.WinLbl.Name = "WinLbl";
            this.WinLbl.Size = new System.Drawing.Size(166, 24);
            this.WinLbl.TabIndex = 1;
            this.WinLbl.Text = "我方获胜次数：0/0";
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(65, 18);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(441, 24);
            this.TitleLbl.TabIndex = 2;
            this.TitleLbl.Text = "AI测试：我方（AI_Entropy）VS敌方（AI_Random）";
            // 
            // ExpectStepLbl
            // 
            this.ExpectStepLbl.AutoSize = true;
            this.ExpectStepLbl.Location = new System.Drawing.Point(65, 118);
            this.ExpectStepLbl.Name = "ExpectStepLbl";
            this.ExpectStepLbl.Size = new System.Drawing.Size(111, 24);
            this.ExpectStepLbl.TabIndex = 3;
            this.ExpectStepLbl.Text = "期望步数：0";
            // 
            // MaxStepLbl
            // 
            this.MaxStepLbl.AutoSize = true;
            this.MaxStepLbl.Location = new System.Drawing.Point(65, 151);
            this.MaxStepLbl.Name = "MaxStepLbl";
            this.MaxStepLbl.Size = new System.Drawing.Size(111, 24);
            this.MaxStepLbl.TabIndex = 4;
            this.MaxStepLbl.Text = "最大步数：0";
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Enabled = false;
            this.ReturnBtn.Location = new System.Drawing.Point(435, 177);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(78, 37);
            this.ReturnBtn.TabIndex = 5;
            this.ReturnBtn.Text = "返回";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // AITestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 225);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.MaxStepLbl);
            this.Controls.Add(this.ExpectStepLbl);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.WinLbl);
            this.Controls.Add(this.TestProgressLbl);
            this.Name = "AITestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TestProgressLbl;
        private Label WinLbl;
        private Label TitleLbl;
        private Label ExpectStepLbl;
        private Label MaxStepLbl;
        private Button ReturnBtn;
    }
}