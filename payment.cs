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
    public partial class payment : Form
    {
        private decimal totalAmount;

        public payment(decimal totalAmount)
        {
            InitializeComponent();
            this.totalAmount = totalAmount;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // User selected Cash option, show CashForm
                cash cashForm = new cash(totalAmount);
                this.Hide();
                cashForm.ShowDialog();
                Dispose();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // User selected Cash option, show CashForm
                creditcard credit_card_Form = new creditcard(totalAmount);
                this.Hide();
                credit_card_Form.ShowDialog();
                Dispose();
            }
        }
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                // User selected Cash option, show CashForm
                jazcasheasypaisa Form1 = new jazcasheasypaisa(totalAmount);
                this.Hide();
                Form1.ShowDialog();
                Dispose();
            }
        }

        private void payment_Load(object sender, EventArgs e)
        {

        }
    }
}
