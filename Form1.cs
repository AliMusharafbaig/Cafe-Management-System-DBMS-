using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace Signup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = password1.Text;
            string confirmPassword = phoneno.Text;
            string name = name1.Text;
            string role = GetSelectedRole();
            string email = textBox1.Text;

            // Validate input (you may want to add more validation)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a connection string
            string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SQL command
                string insertQuery = "INSERT INTO UserTable12 (Username, Password, Email, Name, Role) VALUES (@Username, @Password, @Email, @Name, @Role)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Role", role);

                    // Execute the command
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Signup successful! User data has been stored in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home ss = new Home();
                        this.Hide();
                        ss.Show();
                        Dispose();
                    }

                    else
                    {
                        MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetSelectedRole()
        {
            if (radioButton1.Checked)
            {
                return "Admin";
            }
            else if (radioButton2.Checked)
            {
                return "Employee";
            }
            else if (radioButton3.Checked)
            {
                return "Customer";
            }
            else
            {
                return string.Empty;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void Email_Click(object sender, EventArgs e)
        {
            // Your code for the Email_Click event
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home form1 = new Home();
            this.Close();
            form1.Show();
            Dispose();
        }
    }
}
