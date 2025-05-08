using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定按鈕文字為中文
            formatButton.Text = "格式化";
            exitButton.Text = "退出";
        }

        /// <summary>
        /// 檢查是否為 10 位數字的合法電話
        /// </summary>
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10; // 定義有效長度
            if (str.Length == VALID_LENGTH)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i])) // 若不是數字
                        return false;
                }
                return true; // 所有字元皆為數字
            }
            return false;
        }

        /// <summary>
        /// 將電話號碼格式化為 (XXX) XXX-XXXX
        /// </summary>
        private void TelephoneFormat(ref string str)
        {
            str = $"({str.Substring(0, 2)}) {str.Substring(2, 2)}-{str.Substring(6)}";
        }

        /// <summary>
        /// 按下格式化按鈕事件
        /// </summary>
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;

            if (IsValidNumber(input))
            {
                TelephoneFormat(ref input);
                MessageBox.Show(input, "格式化結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入 10 位數字的電話號碼。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 離開按鈕事件
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉視窗
        }

        private void instructionLabel_Click(object sender, EventArgs e)
        {
            // 可留空
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 可留空
        }
    }
}
