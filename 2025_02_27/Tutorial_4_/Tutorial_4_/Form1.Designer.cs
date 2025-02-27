
namespace Tutorial_4_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distancetextBox1 = new TextBox();
            gastextBox2 = new TextBox();
            averagelabel4 = new Label();
            callculatebutton1 = new Button();
            exitbutton1 = new Button();
            loglistbox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F);
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛公里數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F);
            label2.Location = new Point(12, 113);
            label2.Name = "label2";
            label2.Size = new Size(152, 25);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 15F);
            label3.Location = new Point(12, 195);
            label3.Name = "label3";
            label3.Size = new Size(132, 25);
            label3.TabIndex = 2;
            label3.Text = "您的平均油耗";
            // 
            // distancetextBox1
            // 
            distancetextBox1.Font = new Font("Microsoft JhengHei UI", 14F);
            distancetextBox1.Location = new Point(263, 32);
            distancetextBox1.Name = "distancetextBox1";
            distancetextBox1.Size = new Size(143, 31);
            distancetextBox1.TabIndex = 3;
            // 
            // gastextBox2
            // 
            gastextBox2.Font = new Font("Microsoft JhengHei UI", 14F);
            gastextBox2.Location = new Point(263, 107);
            gastextBox2.Name = "gastextBox2";
            gastextBox2.Size = new Size(143, 31);
            gastextBox2.TabIndex = 4;
            // 
            // averagelabel4
            // 
            averagelabel4.BackColor = SystemColors.ActiveCaption;
            averagelabel4.Font = new Font("Microsoft JhengHei UI", 20F);
            averagelabel4.ForeColor = SystemColors.Desktop;
            averagelabel4.Location = new Point(263, 195);
            averagelabel4.Name = "averagelabel4";
            averagelabel4.Size = new Size(143, 23);
            averagelabel4.TabIndex = 5;
            // 
            // callculatebutton1
            // 
            callculatebutton1.Font = new Font("Microsoft JhengHei UI", 15F);
            callculatebutton1.Location = new Point(33, 273);
            callculatebutton1.Name = "callculatebutton1";
            callculatebutton1.Size = new Size(162, 57);
            callculatebutton1.TabIndex = 6;
            callculatebutton1.Text = "計算";
            callculatebutton1.UseVisualStyleBackColor = true;
            callculatebutton1.Click += callculatebutton1_Click;
            // 
            // exitbutton1
            // 
            exitbutton1.Font = new Font("Microsoft JhengHei UI", 15F);
            exitbutton1.Location = new Point(306, 273);
            exitbutton1.Name = "exitbutton1";
            exitbutton1.Size = new Size(162, 57);
            exitbutton1.TabIndex = 7;
            exitbutton1.Text = "離開";
            exitbutton1.UseVisualStyleBackColor = true;
            exitbutton1.Click += exitbutton1_Click;
            // 
            // loglistbox
            // 
            loglistbox.FormattingEnabled = true;
            loglistbox.ItemHeight = 15;
            loglistbox.Location = new Point(547, 6);
            loglistbox.Name = "loglistbox";
            loglistbox.Size = new Size(189, 244);
            loglistbox.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 15F);
            button1.Location = new Point(561, 273);
            button1.Name = "button1";
            button1.Size = new Size(162, 57);
            button1.TabIndex = 9;
            button1.Text = "計算總平均";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 356);
            Controls.Add(button1);
            Controls.Add(loglistbox);
            Controls.Add(exitbutton1);
            Controls.Add(callculatebutton1);
            Controls.Add(averagelabel4);
            Controls.Add(gastextBox2);
            Controls.Add(distancetextBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void exitbutton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void callculatebutton1_Click(object sender, EventArgs e)
        {
            // Implement the calculation logic here
            MessageBox.Show("Calculation logic not yet implemented.");
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distancetextBox1;
        private TextBox gastextBox2;
        private Label averagelabel4;
        private Button callculatebutton1;
        private Button exitbutton1;
        private ListBox loglistbox;
        private Button button1;
    }
}
