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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageitems form = new  manageitems();
            form.Show();
            this.Close();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supplier f = new supplier();
            f.Show();
            this.Close();
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 as11 = new Form2();
            this.Hide();
            as11.Show();
            Dispose();
        }
    }
}
