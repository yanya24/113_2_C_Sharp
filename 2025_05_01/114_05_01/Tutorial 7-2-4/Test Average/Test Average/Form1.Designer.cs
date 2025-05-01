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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>(); // 儲存測試分數的清單
        private TextBox txtInputScores; // 將 txtInputScores 定義為 TextBox 類型

        public Form1()
        {
            InitializeComponent();
            txtInputScores = new TextBox(); // 初始化 txtInputScores
        }

        // Average 方法接受一個 List<int> 參數
        // 並返回該清單中所有值的平均值。
        private double Average(List<int> scores)
        {
            int total = 0;
            // 遍歷清單中的每個分數，並將其加到總和中
            foreach (int score in scores)
            {
                total += score;
            }
            // 返回總和除以分數數量的平均值
            return (double)total / scores.Count;
        }

        // Highest 方法接受一個 List<int> 參數
        // 並返回該清單中的最高值。
        private int Highest(List<int> scores)
        {
            int highest = scores[0];
            // 遍歷清單中的每個分數，並找出最高的分數
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            // 返回最高的分數
            return highest;
        }

        // Lowest 方法接受一個 List<int> 參數
        // 並返回該清單中的最低值。
        private int Lowest(List<int> scores)
        {
            int lowest = scores[0];
            // 遍歷清單中的每個分數，並找出最低的分數
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            // 返回最低的分數
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開文件。
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空 ListBox 和清單。
                    testScoresListBox.Items.Clear();
                    testScores.Clear();
                    // 從文件中讀取測試分數。
                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        // 將分數添加到 ListBox 中。
                        testScoresListBox.Items.Add(score);
                    }
                    inputFile.Close();  // 關閉文件。
                                        // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);
                    // 顯示結果。
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSortedScores.Text))
                {
                    int score = int.Parse(txtSortedScores.Text.Trim());
                    testScores.Add(score); // 加進清單
                }

                // 清空排序 ListBox
                sortedScoresListBox.Items.Clear();

                // 排序整個清單
                List<int> sorted = new List<int>(testScores);
                sorted.Sort();

                // 顯示在 ListBox
                foreach (int s in sorted)
                {
                    sortedScoresListBox.Items.Add(s);
                }

                // 清空輸入框（✦ 這行是你真正想要的）
                txtSortedScores.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請輸入正確的數字再排序。\n" + ex.Message, "錯誤");
            }
        }



        //    private void deleteButton_Click(object sender, EventArgs e)
        //    {
        //        // 確認是否有選擇項目
        //        if (testScoresListBox.SelectedIndex != -1)
        //        {
        //            // 取得選中的分數
        //            int selectedScore = (int)testScoresListBox.SelectedItem;

        //            // 從清單中移除該分數
        //            testScores.Remove(selectedScore);

        //            // 更新 testScoresListBox
        //            testScoresListBox.Items.Clear();
        //            foreach (int score in testScores)
        //            {
        //                testScoresListBox.Items.Add(score);
        //            }

        //            // 更新 sortedScoresListBox
        //            sortedScoresListBox.Items.Clear();
        //            List<int> sortedScores = new List<int>(testScores);
        //            sortedScores.Sort();
        //            foreach (int score in sortedScores)
        //            {
        //                sortedScoresListBox.Items.Add(score);
        //            }

        //            // 更新平均分數、最高分數和最低分數
        //            if (testScores.Count > 0)
        //            {
        //                averageScoreLabel.Text = Average(testScores).ToString("n1");
        //                highScoreLabel.Text = Highest(testScores).ToString();
        //                lowScoreLabel.Text = Lowest(testScores).ToString();
        //            }
        //            else
        //            {
        //                averageScoreLabel.Text = string.Empty;
        //                highScoreLabel.Text = string.Empty;
        //                lowScoreLabel.Text = string.Empty;
        //            }
        //        }
        //        else
        //        {
        //            // 如果沒有選擇項目，顯示提示訊息
        //            MessageBox.Show("請選擇要刪除的分數。", "提示");
        //        }
        //    }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確認是否有選擇項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得選中的索引
                int selectedIndex = testScoresListBox.SelectedIndex;

                // 從清單中移除該索引位置的分數
                testScores.RemoveAt(selectedIndex);

                // 更新 testScoresListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新 sortedScoresListBox
                sortedScoresListBox.Items.Clear();
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 更新平均分數、最高分數和最低分數
                if (testScores.Count > 0)
                {
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
                else
                {
                    averageScoreLabel.Text = string.Empty;
                    highScoreLabel.Text = string.Empty;
                    lowScoreLabel.Text = string.Empty;
                }
            }
            else
            {
                // 如果沒有選擇項目，顯示提示訊息
                MessageBox.Show("請選擇要刪除的分數。", "提示");
            }
        }
        private void addScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 從 txtInputScores 取得輸入的分數
                string input = txtInputScores.Text;
                List<int> newScores = input.Split(',')
                                           .Select(s => int.Parse(s.Trim()))
                                           .ToList();

                // 將新分數加入到 testScores 中
                testScores.AddRange(newScores);

                // 更新 testScoresListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 清空輸入框
                txtInputScores.Clear();

                // 更新平均分數、最高分數和最低分數
                averageScoreLabel.Text = Average(testScores).ToString("n1");
                highScoreLabel.Text = Highest(testScores).ToString();
                lowScoreLabel.Text = Lowest(testScores).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請輸入有效的分數（以逗號分隔）。\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int score = int.Parse(textBox1.Text.Trim());

                    // 加入到原始清單
                    testScores.Add(score);

                    // 更新 ListBox 顯示
                    testScoresListBox.Items.Clear();
                    foreach (int s in testScores)
                    {
                        testScoresListBox.Items.Add(s);
                    }

                    // 更新統計
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();

                    textBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請輸入正確的數字。\n" + ex.Message, "錯誤");
                }

            }
        }

        private void txtSortedScores_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 確保位置輸入是有效的數字
                if (!int.TryParse(txtSortedScores.Text.Trim(), out int position))
                {
                    return; // 如果位置無效，直接返回
                }

                // 確保數字輸入是有效的數字
                if (!int.TryParse(textBox1.Text.Trim(), out int newScore))
                {
                    MessageBox.Show("請在數字欄位中輸入有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 確保位置在有效範圍內
                if (position < 1 || position > testScores.Count + 1)
                {
                    MessageBox.Show("請輸入有效的位置（1 到 " + (testScores.Count + 1) + "）。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 插入數字到指定位置（位置是 1 基數，轉換為 0 基數）
                testScores.Insert(position - 1, newScore);

                // 更新 sortedScoresListBox 顯示
                sortedScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 清空輸入框
                txtSortedScores.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 確保位置輸入是有效的數字
                if (!int.TryParse(txtSortedScores.Text.Trim(), out int position))
                {
                    MessageBox.Show("請在位置欄位中輸入有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 確保數字輸入是有效的數字
                if (!int.TryParse(textBox1.Text.Trim(), out int newScore))
                {
                    MessageBox.Show("請在數字欄位中輸入有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 確保位置在有效範圍內
                if (position < 1 || position > testScores.Count + 1)
                {
                    MessageBox.Show("請輸入有效的位置（1 到 " + (testScores.Count + 1) + "）。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 插入數字到指定位置（位置是 1 基數，轉換為 0 基數）
                testScores.Insert(position - 1, newScore);

                // 更新 sortedScoresListBox 顯示
                sortedScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 清空輸入框
                txtSortedScores.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}