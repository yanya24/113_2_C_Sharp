using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;    // 廠牌
        public int year;       // 年份
        public double mileage; // 里程數
    }

    public partial class Form1 : Form
    {
        // 建立汽車清單
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // 取得使用者輸入資料
        private void GetData(ref Automobile auto)
        {
            try
            {
                auto.make = makeTextBox.Text;
                auto.year = int.Parse(yearTextBox.Text);
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("請確認資料正確：" + ex.Message);
            }
        }

        // 新增汽車並立即顯示
        private void addButton_Click(object sender, EventArgs e)
        {
            Automobile car = new Automobile();
            GetData(ref car);
            carList.Add(car);

            makeTextBox.Clear();
            yearTextBox.Clear();
            mileageTextBox.Clear();
            makeTextBox.Focus();

            // 立即顯示
            UpdateListBox();
        }

        // 更新 ListBox 內容
        private void UpdateListBox()
        {
            carListBox.Items.Clear();

            foreach (Automobile aCar in carList)
            {
                string output = aCar.year + " " + aCar.make + " with " + aCar.mileage + " miles.";
                carListBox.Items.Add(output);
            }
        }

        // 點擊顯示清單按鈕
        private void displayButton_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }
    }
}
