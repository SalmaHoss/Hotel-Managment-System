using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFTask2_1
{
    public partial class FoodReservation : Form
    {
        public FoodReservation()
        {
            InitializeComponent();
        }
        private int lunchQ = 0;

        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }
        private int breakfastQ = 0;

        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }
        private int dinnerQ = 0;

        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }
        private int coffeeQ = 0;

        public int CoffeeQ
        {
            get { return coffeeQ; }
            set { coffeeQ = value; }
        }

        private void txt1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt1.Enabled = true;
            }
        }

        private void txt2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt2.Enabled = true;
            }
        }

        private void txt3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                txt3.Enabled = true;
            }
        }

        private void txt4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                txt4.Enabled = true;
            }
        }
       
        private void nextButton_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BreakfastQ = Convert.ToInt32(txt1.Text);
            }
            if (checkBox2.Checked)
            {
                LunchQ = Convert.ToInt32(txt2.Text);
            }
            if (checkBox3.Checked)
            {
                DinnerQ = Convert.ToInt32(txt3.Text);
            }
            if (checkBox4.Checked)
            {
                CoffeeQ = Convert.ToInt32(txt4.Text);
            }
            this.Hide();
        }
    }
}
