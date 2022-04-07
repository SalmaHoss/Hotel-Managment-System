using EFTask2.context;
using EFTask2.Entities;
using Microsoft.EntityFrameworkCore;
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
    public partial class Kitchen : Form
    {
        public Kitchen()
        {
            InitializeComponent();
            CenterToScreen();

        }
        LoginManager Context = new LoginManager();
        HotelContext hotelContext = new HotelContext();

        private void kitchen_Load(object sender, EventArgs e)
        {
            hotelContext.Reservations.Load();
            grdViewLoad();
            lstFromDB();
        }
        string  FN, LN, phone;
        int ID;
        private void lstFromDB()
        {
            //How can we update?
            var reservations = (from P in hotelContext.Reservations
                                select P).ToList();
            for (int i = 0; i < reservations.Count; i++)
            {
                ID = reservations[i].Id;
                FN = reservations[i].FirstName.ToString();
                LN = reservations[i].LastName.ToString();
                phone = reservations[i].PhoneNumber.ToString();
                lstBox.Items.Add(ID + "  | " + FN + "  " + LN + " | " + phone);
            }
        }
        

        private void grdViewLoad()
        {
            grdView.DataSource = hotelContext.Reservations.Local.ToBindingList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            grdView.EndEdit();
            hotelContext.SaveChanges();
        }

        private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(lstBox.Text.Substring(0, 2).Replace(" ", string.Empty));
            var res = hotelContext.Reservations.First(P => P.Id == ID);
            //this.Text = ID.ToString();
         
            if (hotelContext.Reservations.Any(P => P.Id == ID))
            {
                txtFN.Text = res.FirstName;
                tstLN.Text = res.LastName;
                txtPhone.Text = res.PhoneNumber;
                txtBF.Text = res.BreakFast.ToString();
                txtDinner.Text = res.Dinner.ToString();
                txtLunch.Text = res.Lunch.ToString();
                txtRT.Text = res.RoomType.ToString();
                txtRoom.Text = res.RoomNumber.ToString();
                txtFloor.Text = res.RoomFloor.ToString();
                if (res.SupplyStatus)
                {
                    checkBox3.Checked = true;
                }
                if (res.Cleaning)
                {
                    checkBox3.Checked = true;
                }
                if (res.CheckIn)
                {
                    checkBox1.Checked = true;
                }
            }
        }

        //Save Updates button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Reservation R in hotelContext.Reservations.Where(u => u.Id == ID))
                {
                    bfast = Convert.ToInt32(txtBF?.Text);
                    Lnch = Convert.ToInt32(txtLunch?.Text);
                    di_ner = Convert.ToInt32(txtDinner?.Text);
                    R.FirstName = txtFN.Text;
                    R.LastName = tstLN.Text;
                    R.Gender = R.Gender.ToString();
                    R.PhoneNumber = txtPhone.Text;
                    R.Dinner = di_ner;
                    R.Lunch = Lnch;
                    R.BreakFast = bfast;
                    R.RoomType = txtRT.Text;
                    R.RoomNumber = txtRoom.Text;
                    R.RoomFloor = txtFloor.Text;
                    R.TotalBill = foodBill;
                }
                hotelContext.SaveChanges();
                MessageBox.Show("Updated");
                grdViewLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Updating! Please make sure that you enter the right data.");
            }
        }

        //Food Reservation Button
        int foodBill = 0;
        int bfast = 0, Lnch = 0, di_ner = 0, coffee = 0;
        FoodReservation FR;
        private void button2_Click(object sender, EventArgs e)
            {
            FR = new FoodReservation();
            FR.Show();
            if (FR.BreakfastQ > 0)
            {
                bfast = 7 * FR.BreakfastQ;
            }
            if (FR.LunchQ > 0)
            {
                Lnch = 15 * FR.LunchQ;
            }
            if (FR.DinnerQ > 0)
            {
                di_ner = 15 * FR.DinnerQ;
            }
            if (FR.CoffeeQ > 0)
            {
               coffee = 15 * FR.CoffeeQ;
            }
            foodBill += (bfast + Lnch + di_ner + coffee);
        }

        
    }
}
