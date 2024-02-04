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
    public partial class supplier : Form
    {
        public supplier()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            supplier_managment form1 = new supplier_managment();
            form1.Show();
            this.Close();
            Dispose();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            supplyorder cs = new supplyorder();
            cs.Show();
            this.Close();
            Dispose()
;        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 df = new Form2();
            df.Show();
            this.Hide();
            Dispose();
        }
    }
}
