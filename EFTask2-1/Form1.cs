using EFTask2.context;
using System.Diagnostics;

namespace EFTask2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private bool Verify(string tName,string userName,string passWord)
        {
            this.Warning.Text = "";

            LoginManager Context = new();                                   //1.Use it to connect to db 
            if(tName == "Kitchen")
            {
                if (Context.Kitchens.Any(P => ((P.UserName == userName) && P.PassWord == passWord))){
                    return true;

                }
                this.Warning.Text = "Please enter valid data";
                return false;
            }
            else
            {
                if (Context.Frontends.Any(P => P.UserName == userName &&  P.PassWord == passWord)){
                    return true;
                }
                this.Warning.Text = "Please enter valid data";

                return false;
            }
           
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if(Verify("Kitchen", txtUser.Text, txtPass.Text))
            {
                this.Hide();
                Kitchen kitchen_management = new Kitchen();
                kitchen_management.Show();
            }
            else if(Verify("FrontEnd",txtUser.Text, txtPass.Text))
            {
                this.Hide();
                FrontEnd hotel_management = new FrontEnd();
                hotel_management.Show();
            }
            else
            {

            }
           
        }
    }
}