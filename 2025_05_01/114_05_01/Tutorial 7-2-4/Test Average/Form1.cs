namespace Test_Average
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.testScoresListBox = new System.Windows.Forms.ListBox();
            this.sortedScoresListBox = new System.Windows.Forms.ListBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testScoresListBox
            // 
            this.testScoresListBox.FormattingEnabled = true;
            this.testScoresListBox.ItemHeight = 12;
            this.testScoresListBox.Location = new System.Drawing.Point(12, 12);
            this.testScoresListBox.Name = "testScoresListBox";
            this.testScoresListBox.Size = new System.Drawing.Size(120, 88);
            this.testScoresListBox.TabIndex = 0;
            // 
            // sortedScoresListBox
            // 
            this.sortedScoresListBox.FormattingEnabled = true;
            this.sortedScoresListBox.ItemHeight = 12;
            this.sortedScoresListBox.Location = new System.Drawing.Point(12, 120);
            this.sortedScoresListBox.Name = "sortedScoresListBox";
            this.sortedScoresListBox.Size = new System.Drawing.Size(120, 88);
            this.sortedScoresListBox.TabIndex = 1;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(150, 120);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 2;
            this.sortButton.Text = "排序";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(150, 157);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "刪除";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.sortedScoresListBox);
            this.Controls.Add(this.testScoresListBox);
            this.Name = "Form1";
            this.Text = "測試平均分數";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testScoresListBox;
        private System.Windows.Forms.ListBox sortedScoresListBox;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
