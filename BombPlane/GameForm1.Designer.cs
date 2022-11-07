namespace BombPlane
{
    partial class GameForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.GameTable = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UndoButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.GameTable, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 547);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // GameTable
            // 
            this.GameTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.GameTable.ColumnCount = 10;
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.Location = new System.Drawing.Point(3, 3);
            this.GameTable.Name = "GameTable";
            this.GameTable.RowCount = 10;
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GameTable.Size = new System.Drawing.Size(498, 458);
            this.GameTable.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(507, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 83);
            this.label2.TabIndex = 1;
            this.label2.Text = "返回";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.UndoButton);
            this.flowLayoutPanel1.Controls.Add(this.FinishButton);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(507, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(163, 458);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // UndoButton
            // 
            this.UndoButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UndoButton.Location = new System.Drawing.Point(3, 3);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(163, 79);
            this.UndoButton.TabIndex = 2;
            this.UndoButton.Text = "撤销";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FinishButton.Location = new System.Drawing.Point(3, 88);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(160, 80);
            this.FinishButton.TabIndex = 3;
            this.FinishButton.Text = "完成";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("方正粗雅宋_GBK", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 256);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "提示";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("方正粗雅宋_GBK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 243);
            this.label1.TabIndex = 4;
            this.label1.Text = "右键切换方向\r\n左键放下飞机\r\n只能放下三个\r\n放错可点撤销\r\n放完点击完成\r\n适度游戏益脑\r\n沉迷游戏伤身\r\n合理安排时间\r\n享受健康生活";
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(673, 547);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Location = new System.Drawing.Point(100, 200);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "放置飞机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel GameTable;
        private System.Windows.Forms.Label label2;
        private Button UndoButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button FinishButton;
        private Label label1;
        private GroupBox groupBox1;
    }
}