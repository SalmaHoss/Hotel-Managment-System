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
    public partial class FinalizeBill : Form
    {
        public FinalizeBill()
        {
            InitializeComponent();
            CenterToParent();
            int I = 1;
            while (I <= 12)
            {
                comboMonth.Items.Add(I);
                I++;
            }

            I = 2000;
            while (I <= 2025)
            {
                comboYear.Items.Add(I);
                I++;
            }
            comboPT.Items.Add("Credit");
            comboPT.Items.Add("Cash");

        }

        public int totalAmountFromFrontend = 0;
        public int foodBill = 0;
        private double finalTotalFinalized = 0.0;
        private string paymentType;


        public double FinalTotalFinalized        //to be initialized
        {
            get { return finalTotalFinalized; }
            set { finalTotalFinalized = value; }
        }
        public string PaymentType { get; set; }

        public string PaymentCardNumber { get; set; }

        public string MM_YY_Of_Card { get; set; }

        public string CVC_Of_Card { get; set; }

        public string CardType { get; set; }

        private void FinalizeBill_Load(object sender, EventArgs e)
        {

              double totalWithTax = Convert.ToDouble(totalAmountFromFrontend) * 0.07;
              double FinalTotal = Convert.ToDouble(totalAmountFromFrontend) + totalWithTax + foodBill;
              CurrenyMoney.Text = "$" + Convert.ToString(totalAmountFromFrontend) + " USD";
              FoodMoney.Text = "$" + Convert.ToString(foodBill) + " USD";
              label5.Text = "$" + Convert.ToString(totalWithTax) + " USD";
              label9.Text = "$" + Convert.ToString(FinalTotal) + " USD";
              FinalTotalFinalized = FinalTotal;

        }

        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentType = comboPT.Text;
                PaymentCardNumber = txtPhone.Text;
                MM_YY_Of_Card = comboYear.SelectedItem.ToString() + "/" + comboMonth.SelectedItem.ToString();
                CVC_Of_Card = txtCVC.Text;
                CardType = comboPT.Text;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please fill all fields.");
            }
         
        }
    


       private void phoneNComboBox_Leave(object sender, EventArgs e)
        {
           long getphn = Convert.ToInt64(txtPhone.Text);
           string formatString = String.Format("{0:0000-0000-0000-0000}", getphn);
           txtPhone.Text = formatString;
        }

        private void comboPT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}