using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Decryption;

namespace Project2
{
    public partial class Form1 : Form
    {
        private string pass;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SA44Team02A_SportsDBEntities context = new SA44Team02A_SportsDBEntities();

            if (textBox1.Text != "" || textBox2.Text != "")
            {
                try
                {
                    StaffInformation staff = context.StaffInformations.Where(x => x.StaffID == textBox1.Text).First();
                    pass = Decryption.Class1.Decrypt(staff.Password.ToString());
                    Login();
                }
                catch (System.InvalidOperationException ee)
                {
                    HandleError();
                    
                }                
            }
            else
            {
                HandleError();
            }

        }

        private void Login()
        {
            if (textBox2.Text == pass)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
                toolStripStatusLabel1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                this.Show();
            }
            else
            {
                HandleError();
            }
        }

        private void HandleError()
        {
            toolStripStatusLabel1.Text = "StaffID or Password is incorrect. Please try again!";
            this.textBox1.Clear();
            this.textBox2.Clear();
            pass = "";
            this.textBox1.Focus();
        }

    }
}
