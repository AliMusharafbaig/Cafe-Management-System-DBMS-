using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Signup
{
    public partial class jazcasheasypaisa : Form
    {
        private decimal total_amount;
        public jazcasheasypaisa(decimal totalAmount)
        {
            InitializeComponent();
            this.total_amount = totalAmount;
            textBox2.Text = totalAmount.ToString("C");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accno = textBox1.Text;
            MessageBox.Show("Payment Successfull");
            exitform form21 = new exitform();
            form21.Show();
        }
    }
}
