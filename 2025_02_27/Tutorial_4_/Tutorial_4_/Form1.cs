namespace Tutorial_4_
{
    public partial class Form1 : Form
    {
        // Assuming averagelabel is a Label control, so changing its type to Label
        public Label averagelabel { get; private set; }
        public double distancelabel { get; private set; }
        public double gaslabel { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton1_Click(object sender, EventArgs e)
        {
            double distance, gas, average;

            // 確保距離是有效的數字
            if (double.TryParse(distancetextBox1.Text, out distance))
            {
                // 如果成功解析距離，顯示調試訊息
                MessageBox.Show($"Distance: {distance}");

                // 確保油量是有效的數字
                if (!double.TryParse(gastextBox2.Text, out gas))
                {
                    MessageBox.Show("請輸入有效的數字為油量");
                    gastextBox2.Focus();    //將游標移到gasTextBox2
                    gastextBox2.Text = "";  //清空
                }
                else
                {
                    // 如果成功解析油量，顯示調試訊息
                    MessageBox.Show($"Gas: {gas}");

                    // 檢查油量是否為零，避免除以零錯誤
                    if (gas == 0)
                    {
                        MessageBox.Show("油量不能為零");
                        gastextBox2.Focus();
                        gastextBox2.Text = "";  //清空
                    }
                    else
                    {
                        // 計算平均油耗
                        average = distance / gas;

                        // 正確地更新 Label 控件顯示計算結果
                        averagelabel.Text = $"{average:f2} 公里/公升"; // 修正拼接方式，格式化顯示

                        // 更新 loglistbox
                        loglistbox.Items.Add($"{average:f2} 公里/公升");

                        // 顯示計算結果（調試用）
                        MessageBox.Show($"計算結果: {average:f2} 公里/公升");
                    }
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的數字作為里程");
                distancetextBox1.Focus();    //將游標移到distancetextBox1
                distancetextBox1.Text = "";  //清空
            }
        }

        private void ExitButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistbox.Items.Clear();
            loglistbox.Items.Add("平均油耗紀錄：");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistbox.Items.Count > 1)
            {
                loglistbox.Items.Add("平均油耗紀錄：");
                for (int i = 1; i < loglistbox.Items.Count; i++)
                {
                    sum += double.Parse(loglistbox.Items[i].ToString().Replace("公里/公升", ""));
                }
                loglistbox.Items.Add($"平均油耗：{(sum / (loglistbox.Items.Count - 1)):f2} 公里/公升");
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
