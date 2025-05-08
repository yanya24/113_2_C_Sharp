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

            this.Text = "�x�W�q�ܸ��X�榡�٭쾹";
            unformatButton.Text = "�����榡";
            exitButton.Text = "�h�X";
        }

        /// <summary>
        /// �P�_�O�_���x�W�榡 (0X) �� (0XX)�A�~�[���T�B�Ʀr�`���� 10 �X
        /// </summary>
        private bool IsValidFormat(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            // �����t�����T���A���P�}�鸹
            if (!(str.StartsWith("(0") && str.Contains(")") && str.Contains("-")))
                return false;

            int closingParen = str.IndexOf(')');
            if (closingParen < 3 || closingParen > 4)
                return false; // �ϽX���� 2 �� 3 �X

            // �����A���P�}�鸹�A�����O 10 ��Ʀr
            string digitsOnly = str.Replace("(", "").Replace(")", "").Replace("-", "");
            return digitsOnly.Length == 10 && digitsOnly.All(char.IsDigit);
        }

        /// <summary>
        /// �٭�榡���¼Ʀr�G�Ҧp (02)1234-5678 �� 0212345678
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
                    MessageBox.Show("�榡�w���\�����I", "���\", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("�榡���T�A���`�Ʀr������ 10 �X�A���ˬd���X�C", "���~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("�п�J���T�榡�A�Ҧp�G(02)1234-5678 �� (037)123-4567�C", "�榡���~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
