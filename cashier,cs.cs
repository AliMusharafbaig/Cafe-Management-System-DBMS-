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
    public partial class cashier_cs : Form
    {
        public cashier_cs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loyal form1 = new loyal();
            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hotselling_prod as1= new hotselling_prod();
            as1.Show();
            this.Close();
            Dispose();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            audit cs1 = new audit();
            this.Hide();
            cs1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            empl_login asd = new empl_login();
            this.Hide();
            asd.Show();
            Dispose();
        }
    }
}
