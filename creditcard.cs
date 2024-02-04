using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stripe;
namespace Signup
{

    public partial class creditcard : Form
    {
        private decimal totalAmount;
        public creditcard(decimal totalAmount)
        {
            InitializeComponent();
            this.totalAmount = totalAmount;
            textBox5.Text = totalAmount.ToString("C");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cardNumber = textBox1.Text;
            int expMonth = Convert.ToInt32(textBox2.Text);
            int expYear = Convert.ToInt32(textBox3.Text);
            string cvc = textBox4.Text;
            int amountInCents = 1000; // Example amount in cents (replace with your actual amount)

            try
            {
                // Process the payment
                if (!IsValidCreditCard(cardNumber, expMonth, expYear, cvc))
                {
                    MessageBox.Show("Invalid credit card information. Please check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Optionally, show a success message or navigate to the next step
                MessageBox.Show("Payment successful!");
                exitform form21 = new exitform();
                form21.Show();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Payment failed. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidCreditCard(string cardNumber, int expMonth, int expYear, string cvc)
        {
          // Simple Luhn algorithm check for credit card number validity
            if (!LuhnAlgorithmCheck(cardNumber))
            {
                return false;
            }

            // Additional checks based on your requirements can be added here

            return true;
        }

        private bool LuhnAlgorithmCheck(string cardNumber)
        {
            int[] digits = cardNumber.Reverse()
                                      .Select(c => Convert.ToInt32(c.ToString()))
                                      .ToArray();

            int sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                int digit = digits[i];

                if (i % 2 == 1)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
            }

            return sum % 10 == 0;
        }

        
    }

}
  
    



