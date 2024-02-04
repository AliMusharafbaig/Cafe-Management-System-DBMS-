using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signup
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            admin_login login1 = new admin_login();
            this.Hide();
            login1.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            customer_login LOGINForm = new customer_login();

            // Hide the current form (login form)
            this.Hide();

            // Show the signup form
            LOGINForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            empl_login new_form = new empl_login();
            this.Hide();
            
            new_form.Show();
           // Dispose();
           
           

        }
    }
    }

