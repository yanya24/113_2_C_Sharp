using System;
using System.Linq;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "台灣電話號碼格式還原器";
            unformatButton.Text = "移除格式";
            exitButton.Text = "退出";
        }

        /// <summary>
        /// 判斷是否為台灣格式 (0X) 或 (0XX)，外觀正確且數字總長為 10 碼
        /// </summary>
        private bool IsValidFormat(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            // 必須含有正確的括號與破折號
            if (!(str.StartsWith("(0") && str.Contains(")") && str.Contains("-")))
                return false;

            int closingParen = str.IndexOf(')');
            if (closingParen < 3 || closingParen > 4)
                return false; // 區碼長度 2 或 3 碼

            // 移除括號與破折號，必須是 10 位數字
            string digitsOnly = str.Replace("(", "").Replace(")", "").Replace("-", "");
            return digitsOnly.Length == 10 && digitsOnly.All(char.IsDigit);
        }

        /// <summary>
        /// 還原格式為純數字：例如 (02)1234-5678 → 0212345678
        /// </summary>
        private void Unformat(ref string str)
        {
            str = str.Replace("(", "")
                     .Replace(")", "")
                     .Replace("-", "");
        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text.Trim();

            if (IsValidFormat(input))
            {
                string raw = input.Replace("(", "").Replace(")", "").Replace("-", "");
                if (raw.Length == 10)
                {
                    Unformat(ref input);
                    numberTextBox.Text = input;
                    MessageBox.Show("格式已成功移除！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("格式正確，但總數字不等於 10 碼，請檢查號碼。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("請輸入正確格式，例如：(02)1234-5678 或 (037)123-4567。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
