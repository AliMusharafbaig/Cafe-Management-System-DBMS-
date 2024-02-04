using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Signup
{
    public partial class customer_login : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");

        public customer_login()
        {
            InitializeComponent();
        }

        private void UpdateCustomerVisits(int userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True"))
                {
                    // Open the connection
                    connection.Open();

                    // Check if the user already exists in the LoyaltyTable
                    string checkUserQuery = "SELECT COUNT(*) FROM customer_visits WHERE UserID = @UserID";
                    using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@UserID", userID);

                        int userCount = (int)checkUserCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // User exists, update visits
                            string updateVisitsQuery = "UPDATE customer_visits SET Visits = Visits + 1 WHERE UserID = @UserID";
                            using (SqlCommand updateVisitsCommand = new SqlCommand(updateVisitsQuery, connection))
                            {
                                updateVisitsCommand.Parameters.AddWithValue("@UserID", userID);
                                updateVisitsCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // User doesn't exist, insert a new record
                            string insertUserQuery = "INSERT INTO customer_visits (UserID, Visits) VALUES (@UserID, 1)";
                            using (SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection))
                            {
                                insertUserCommand.Parameters.AddWithValue("@UserID", userID);
                                insertUserCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating visits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to check if the user is in LoyaltyTable
        private bool IsUserInLoyaltyTable(int userID)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True"))
            {
                connection.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM LoyaltyTable WHERE UserID = @UserID";
                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@UserID", userID);

                    int userCount = (int)checkUserCommand.ExecuteScalar();

                    return userCount > 0;
                }
            }
        }

        // Helper method to check if the user is in LoyaltyTable


        private int GetCurrentVisits(int userID)
        {
            // Get the current number of visits for the user from customer_visits
            using (SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True"))
            {
                connection.Open();
                string getCurrentVisitsQuery = "SELECT Visits FROM customer_visits WHERE UserID = @UserID";
                using (SqlCommand getCurrentVisitsCommand = new SqlCommand(getCurrentVisitsQuery, connection))
                {
                    getCurrentVisitsCommand.Parameters.AddWithValue("@UserID", userID);
                    return (int)getCurrentVisitsCommand.ExecuteScalar();
                }
            }
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True"))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command
                    string selectQuery = "SELECT UserID FROM UserTable12 WHERE Username = @Username AND Password = @Password AND Role = 'Customer'";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the command
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int userID = (int)result;
                            UpdateCustomerVisits(userID);

                            // Login successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the main menu form and pass the user ID
                            menu mainmenu = new menu();
                            mainmenu.get_current_id = userID;
                            mainmenu.Show();

                            // Hide the current form (login form)
                            this.Hide();
                        }
                        else
                        {
                            // Login failed
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 signupForm = new Form1();

            // Hide the current form (login form)
            this.Hide();

            // Show the signup form
            signupForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void customer_login_Load(object sender, EventArgs e)
        {

        }
    }
}
