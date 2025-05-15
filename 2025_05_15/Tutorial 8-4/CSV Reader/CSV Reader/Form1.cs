using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "CSV 讀取器";

            if (getScoresButton != null)
                getScoresButton.Text = "取得分數";
            if (exitButton != null)
                exitButton.Text = "離開";
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            averagesListBox.Items.Clear();

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "CSV 檔案 (*.csv)|*.csv|所有檔案 (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("選到檔案：" + openFile.FileName);

                    try
                    {
                        var students = new System.Collections.Generic.List<(string Name, double Average)>();

                        // 使用指定的編碼讀取檔案
                        using (StreamReader inputFile = new StreamReader(openFile.FileName, Encoding.GetEncoding("big5")))  // 若檔案是UTF-8，改為 Encoding.UTF8
                        {
                            string line;
                            char delim = ',';

                            while (!inputFile.EndOfStream)
                            {
                                line = inputFile.ReadLine().Trim();
                                string[] tokens = line.Split(':'); // 使用冒號分隔姓名和分數

                                if (tokens.Length < 2) continue;

                                string name = tokens[0];
                                string[] scores = tokens[1].Split(delim); // 分數用逗號分開

                                int total = 0, score;
                                int countScores = 0;

                                foreach (var token in scores)
                                {
                                    if (int.TryParse(token, out score))
                                    {
                                        total += score;
                                        countScores++;
                                    }
                                }

                                if (countScores > 0)
                                {
                                    double average = (double)total / countScores;
                                    students.Add((name, average));
                                }
                                else
                                {
                                    students.Add((name, 0)); // 若沒有有效分數，則平均為0
                                }
                            }
                        }

                        // 按平均分數排序
                        var sortedStudents = students.OrderByDescending(s => s.Average).ToList();

                        // 顯示排序後的學生資料，並顯示排名
                        int rank = 1; // 計算排名
                        foreach (var student in sortedStudents)
                        {
                            averagesListBox.Items.Add($"{rank} 位: {student.Name} 的平均分數為: {student.Average:F2}");
                            rank++;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("讀取檔案錯誤：" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("未選擇檔案");
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
