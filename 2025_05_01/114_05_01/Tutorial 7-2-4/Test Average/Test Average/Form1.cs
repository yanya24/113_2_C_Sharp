// using 區塊
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>();
        // 修正 positionTextBox 的宣告類型  
        private TextBox positionTextBox;

        public Form1()
        {
            InitializeComponent();
        }

        // 計算平均值
        private double Average(List<int> scores)
        {
            int total = scores.Sum();
            return (double)total / scores.Count;
        }

        // 最高分
        private int Highest(List<int> scores)
        {
            return scores.Max();
        }

        // 最低分
        private int Lowest(List<int> scores)
        {
            return scores.Min();
        }

        // 讀檔案取得分數
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    StreamReader inputFile = File.OpenText(openFile.FileName);

                    testScores.Clear();
                    testScoresListBox.Items.Clear();

                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        testScoresListBox.Items.Add(score);
                    }

                    inputFile.Close();

                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 加入一筆分數（textBox1）
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                int score = int.Parse(textBox1.Text.Trim());
                testScores.Add(score);
                UpdateScoreList();
                UpdateStatistics();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請輸入正確的數字。\n" + ex.Message, "錯誤");
            }
        }

        // 插入分數到指定位置（textBox1 輸入分數，positionTextBox 輸入位置）
        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                int score = int.Parse(textBox1.Text.Trim());
                int position = int.Parse(positionTextBox.Text.Trim());

                if (position < 1 || position > testScores.Count + 1)
                {
                    MessageBox.Show("請輸入有效的位置（1 到 " + (testScores.Count + 1) + "）。", "錯誤");
                    return;
                }

                testScores.Insert(position - 1, score);
                UpdateScoreList();
                UpdateStatistics();
                textBox1.Clear();
                positionTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請輸入有效的分數與位置。\n" + ex.Message, "錯誤");
            }
        }

        // 排序分數（不輸入新分數）
        private void sortButton_Click(object sender, EventArgs e)
        {
            sortedScoresListBox.Items.Clear();

            List<int> sorted = new List<int>(testScores);
            sorted.Sort();

            foreach (int s in sorted)
            {
                sortedScoresListBox.Items.Add(s);
            }
        }

        // 刪除選中的分數
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (testScoresListBox.SelectedIndex != -1)
            {
                int index = testScoresListBox.SelectedIndex;
                testScores.RemoveAt(index);
                UpdateScoreList();
                UpdateStatistics();
            }
            else
            {
                MessageBox.Show("請選擇要刪除的分數。", "提示");
            }
        }

        // 更新原始分數 ListBox
        private void UpdateScoreList()
        {
            testScoresListBox.Items.Clear();
            foreach (int score in testScores)
            {
                testScoresListBox.Items.Add(score);
            }
        }

        // 更新統計欄位
        private void UpdateStatistics()
        {
            if (testScores.Count > 0)
            {
                averageScoreLabel.Text = Average(testScores).ToString("n1");
                highScoreLabel.Text = Highest(testScores).ToString();
                lowScoreLabel.Text = Lowest(testScores).ToString();
            }
            else
            {
                averageScoreLabel.Text = "";
                highScoreLabel.Text = "";
                lowScoreLabel.Text = "";
            }
        }
    }
}