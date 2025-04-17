using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        // 定義座位價格的二維陣列        
        public Form1()
        {
            InitializeComponent();
        }

        // 當使用者點擊顯示價格按鈕時觸發的事件處理方法
        // 此方法應包含顯示座位價格的邏輯
        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            decimal[,] prices = {
            {450m, 450m, 450m, 450m},
            {425m, 425m, 425m, 425m},
            {400m, 400m, 400m, 400m},
            {375m, 375m, 375m, 375m},
            {375m, 375m, 375m, 375m},
            {350m, 350m, 350m, 350m}
                                 };
            // TODO: 在此處添加顯示座位價格的邏輯
        }

        // 當使用者點擊退出按鈕時觸發的事件處理方法
        // 此方法會關閉目前的表單
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單
            this.Close();
        }

        private void airplanePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void rowTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
