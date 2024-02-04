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
    public partial class Form2 : Form
    {
        public bool flag=true;
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MANAGECUSTOMERS new_form = new MANAGECUSTOMERS("Customer");
            new_form.Show();
            Dispose();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void sToggleButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MANAGECUSTOMERS new_form = new MANAGECUSTOMERS("EMPLOYEE");
            new_form.Show();
            Dispose();
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            inventory as1 = new inventory();
            as1.Show();
            this.Close();
            Dispose();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_login sd = new admin_login();
            this.Close();
            sd.Show();
            Dispose();
        }
    }
}
