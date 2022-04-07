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
    public partial class FrontEnd : Form
    {
        FoodReservation FR;
        public FrontEnd()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
            this.resEditButton.Visible = false;
            var months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
            comboMonth.DataSource = months;
            FR = new FoodReservation();

            int I = 1;
            while (I <= 31)
            {
                comboDay.Items.Add(I);
                I++;
            }

            I = 1;
            while (I <= 4)
            {
                comboNumOfGuests.Items.Add(I);
                I++;
            }
        
            I = 200;
            while (I <= 450)
            {
                if(hotelContext.Reservations.Any(h => h.RoomNumber == I.ToString()))
                {
                    lstOcc.Items.Add(I);

                }
                else
                {
                    comboRN.Items.Add(I);
                    lstRes.Items.Add(I);
                }
                I++;
            }
            comboRT.Items.Add("Single");
            comboRT.Items.Add("Double");
            comboRT.Items.Add("Suite");
            comboFloor.Items.Add("1");
            comboFloor.Items.Add("2");
            comboFloor.Items.Add("3");
            comboGender.Items.Add("M");
            comboGender.Items.Add("F");
            comboState.Items.Add("USA");
            comboState.Items.Add("AOE");
            comboState.Items.Add("UK");
        }
        private void FrontEnd_Load(object sender, EventArgs e)
        {
            hotelContext.Reservations.Load();
            grdViewLoad();

        }

        HotelContext hotelContext = new HotelContext();
        List<Reservation> resLst = new List<Reservation>();
        //Search ICON
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string str = txtSearch.Text.ToLower();

            resLst = (from P in hotelContext.Reservations
                      select P).ToList();


            if (resLst.Any(x => x.FirstName.ToLower().Contains(str)))
            {
                resLst = resLst.Where(x => x.FirstName.ToLower().Contains(str)).ToList();
                dataGridView1.Visible = true;
                dataGridView1.DataSource = resLst;


            }
            else if (resLst.Any(x => x.LastName.ToLower().Contains(str)))
            {
                resLst = resLst.Where(x => x.LastName.ToLower().Contains(str)).ToList();
                dataGridView1.Visible = true;
                dataGridView1.DataSource = resLst;

            }
            else
            {
                this.Warning.Text = "Sorry there is no data to be Displayed -_-";
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Warning.Text = "";
        }

        int foodBill = 0;
        int bfast = 0, Lnch = 0, di_ner = 0, coffee = 0;

        private void btnFoodAndMenu_Click(object sender, EventArgs e)
        {
            FR.Show();
           
   
        }
        private void calcFoodBill()
        {

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
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnDelete.Visible = true;
            this.btnUpdate.Visible = true;
            btnUpdate.Enabled = false;

            this.resEditButton.Visible = true;
            ComboBoxItemsFromDataBase();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
            this.resEditButton.Visible = false;
          
        }

       

        private void grdViewLoad()
        {
            grdView.DataSource = hotelContext.Reservations.Local.ToBindingList();
        }

        //FinButton
        int breakfast, lunch, dinner;
        string cleaning, towel, surprise;
        public string birthday = "";
        public Boolean taskFinder = false;
        public Boolean editClicked = false;
        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType = "Debit";
        public int totalAmount = 0;
        public int checkin = 0;

       

        private void comboRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRT.SelectedItem.Equals("Single"))
                comboFloor.SelectedItem = "1";
            else if (comboRT.SelectedItem.Equals("Double"))
                comboFloor.SelectedItem = "2";
            else
                comboFloor.SelectedItem = "3";
            
        }

        private void lstOcc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(resEditButton.Text.Substring(0, 2).Replace(" ", string.Empty));

            Reservation res = hotelContext.Reservations.FirstOrDefault(x => x.Id == ID);
            hotelContext.Reservations.Remove(res);
            hotelContext.SaveChanges();
            hotelContext.Reservations.Load();
            grdViewLoad();
            ComboBoxItemsFromDataBase();
            MessageBox.Show("Deleted");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(resEditButton.Text.Substring(0, 2).Replace(" ", string.Empty));

            Reservation result = hotelContext.Reservations.FirstOrDefault(x => x.Id == ID);
            result.AptSuite = this.txtApt.Text;
            result.FirstName = this.txtFN.Text;
            result.LastName = this.txtLN.Text;
            result.Dinner = dinner;
            result.EmailAddress = this.textEmail.Text;
            result.City = this.txtCity.Text;
            result.Gender = this.comboGender.Text;
            result.StreetAddress = this.txtStreet.Text;
            result.FoodBill = foodBill;
            result.TotalBill = totalAmount;
            hotelContext.SaveChanges();
            MessageBox.Show("Updated");
            hotelContext.Reservations.Load();
            grdViewLoad();
            ComboBoxItemsFromDataBase();
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           /* try
            {*/
                Reservation result = new Reservation();
                result.State = comboState.Text;
                result.AptSuite = this.txtApt.Text;
                result.FirstName = this.txtFN.Text;
                result.LastName = this.txtLN.Text;
                result.Dinner = dinner;
                result.EmailAddress = this.textEmail.Text;
                result.City = this.txtCity.Text;
                result.Gender = this.comboGender.Text;
                result.StreetAddress = this.txtStreet.Text;
                result.FoodBill = foodBill;
                result.TotalBill = totalAmount;
                result.BreakFast = breakfast;
                result.Lunch = lunch;
                result.CardNumber = paymentCardNumber;
                result.CardCvc = CVC_Of_Card;
                result.CardExp = "03/15";
                result.BirthDay = txtYear.Text + "/" + comboMonth.Text + "/" + comboDay.Text;
                result.ArrivalTime = dateTimeE.Value;
                result.LeavingTime = dateTimeD.Value;
                result.ZipCode = txtZC.Text;
                result.CardType = CardType;
                result.PaymentType = CardType;
                result.RoomNumber = comboRN.Text;
                result.RoomFloor = comboFloor.Text;
                result.RoomType = comboRT.Text;
                result.Cleaning = true;
                 result.PhoneNumber = txtPhone.Text;
                hotelContext.Reservations.Add(result);
                hotelContext.SaveChanges();
                MessageBox.Show("Added");
/*
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in adding new item." + ex.Message);
            }*/
        }

        public int foodStatus = 0;
        public Int32 primartyID = 0;
        public string food_menu = "";
        private void btnFin_Click(object sender, EventArgs e)
        {
            calcFoodBill();
            foodBill += (bfast + Lnch + di_ner + coffee);

            this.Text = foodBill.ToString();

            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
            {
             checkBox3.Checked = true;
            }

            btnUpdate.Enabled = true;

            FinalizeBill finalizebil = new FinalizeBill();
            if (comboRT.Text.Equals("Single"))
            {
                totalAmount = 149;
                comboFloor.SelectedItem = "1";
            }
            else if (comboRT.Text.Equals("Double"))
            {
                totalAmount = 249;
                comboFloor.SelectedItem = "2";
            }
            else
            {
                totalAmount = 349;
                comboFloor.SelectedItem = "3";
            }
            finalizebil.totalAmountFromFrontend = totalAmount;
            finalizebil.foodBill = foodBill;
            if (taskFinder)
            {
                finalizebil.comboPT.SelectedItem = FPayment.Replace(" ", string.Empty);
                finalizebil.txtPhone.Text = FCnumber;
                finalizebil.comboMonth.SelectedItem = FcardExpOne;
                finalizebil.comboYear.SelectedItem = FcardExpTwo;
                finalizebil.txtCVC.Text = FCardCVC;
            }

            finalizebil.ShowDialog();

            finalizedTotalAmount = finalizebil.FinalTotalFinalized;
            paymentType = finalizebil.PaymentType;
            paymentCardNumber = finalizebil.PaymentCardNumber;
            MM_YY_Of_Card = finalizebil.MM_YY_Of_Card;
            CVC_Of_Card = finalizebil.CVC_Of_Card;
            CardType = finalizebil.CardType;

            if (!editClicked)
            {
                btnSubmit.Visible = true;
            }
        }
        
       
        private void ComboBoxItemsFromDataBase()
        {
            resEditButton.Items.Clear();
            var resLst = (from P in hotelContext.Reservations
                          select P).ToList();
            for (int i = 0; i < resLst.Count; i++)
            {
                ID = resLst[i].Id;
                FN = resLst[i].FirstName.ToString();
                LN = resLst[i].LastName.ToString();
                phone = resLst[i].PhoneNumber.ToString();
                resEditButton.Items.Add(ID + "  | " + FN + "  " + LN + " | " + phone);
            }
        }
        int ID;
        string FN, LN, phone;

        private void resEditButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(resEditButton.Text.Substring(0, 2).Replace(" ", string.Empty));

            var res = hotelContext.Reservations.First(P=>P.Id == ID);
            if (hotelContext.Reservations.Any(P => P.Id == ID))
            {
                txtFN.Text = res.FirstName;
                txtLN.Text = res.LastName;
                //here
                txtYear.Text = res.BirthDay.Substring(0, 1).Replace(" ", string.Empty);
                txtPhone.Text = res.PhoneNumber;
                txtStreet.Text = res.EmailAddress;
                comboGender.Text = res.Gender.ToString();
                txtStreet.Text = res.StreetAddress.ToString();
                txtApt.Text = res.AptSuite.ToString();
                txtCity.Text = res.City.ToString();
                comboRN.Text = res.RoomNumber.ToString();
                comboRT.Text = res.RoomType.ToString();
                if(comboRT.Text == "Single")
                {
                    comboFloor.Text = "1";
                }
                else if (comboRT.Text == "Double")
                {
                    comboFloor.Text = "2";
                }
                else 
                {
                    comboFloor.Text = "3";
                }
                //HERE
                dateTimeE.Text = res.ArrivalTime.ToString();
                dateTimeD.Text = res.LeavingTime.ToString();

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
    }
 }

