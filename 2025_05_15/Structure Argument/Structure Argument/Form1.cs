using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義一個汽車 (Automobile) 結構，包含廠牌、年份與里程數
    struct Automobile
    {
        public string make;    // 汽車廠牌
        public int year;       // 汽車年份
        public double mileage; // 汽車里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 顯示汽車資訊的方法，接受一個 Automobile 結構
        private void DisplayAuto(Automobile auto)
        {
            MessageBox.Show(auto.year + " " + auto.make +
                " with " + auto.mileage + " miles.");
        }

        private void auto1Button_Click(object sender, EventArgs e)
        {
            Automobile sportsCar = new Automobile();
            sportsCar.make = "Chevy Corvette";
            sportsCar.year = 1970;
            sportsCar.mileage = 50000.0;
            DisplayAuto(sportsCar);
        }

        private void auto2Button_Click(object sender, EventArgs e)
        {
            Automobile pickupTruck = new Automobile();
            pickupTruck.make = "Ford Ranger";
            pickupTruck.year = 1985;
            pickupTruck.mileage = 75000.0;
            DisplayAuto(pickupTruck);
        }

        private void auto3Button_Click(object sender, EventArgs e)
        {
            Automobile sedan = new Automobile();
            sedan.make = "Honda Accord";
            sedan.year = 2000;
            sedan.mileage = 80000.0;
            DisplayAuto(sedan);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 可以在這裡加入初始化程式
        }
    }
}
