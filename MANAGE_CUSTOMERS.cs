using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Signup
{
    public partial class MANAGECUSTOMERS : Form
    {
        private string selectedRole;
        string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";

        public MANAGECUSTOMERS(string selectedRole)
        {
            InitializeComponent();
            this.selectedRole = selectedRole;
            LoadCustomers();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementation for DataGridView cell click event
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    
                        // Fetch customer information from the database
                        string query = $"SELECT UserID, Username, Name, Email, Password FROM UserTable12 WHERE Role='{selectedRole}'";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Display customer information in the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Username = textBox2.Text;
            string Password = textBox3.Text;
            string Email = textBox4.Text;
            

            // Validate input
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please enter all required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                   
                        // Insert new customer into the database
                        string insertQuery = "INSERT INTO UserTable12 (Username, Name, Password, Email, Role) VALUES (@Username, @Name, @Password, @Email, @Role)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Username", Username);
                            command.Parameters.AddWithValue("@Name", Name);
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@Email", Email);
                            command.Parameters.AddWithValue("@Role", selectedRole);

                            command.ExecuteNonQuery();

                            // Reload the customers in the DataGridView
                            LoadCustomers();

                            // Clear textboxes after adding a new customer
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                        }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Implementation for textBox1 TextChanged event
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Implementation for textBox2 TextChanged event
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Implementation for textBox3 TextChanged event
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Implementation for textBox4 TextChanged event
        }

        private void MANAGE_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Delete the selected customer from the database
                        string deleteQuery = "DELETE FROM UserTable12 WHERE UserID = @UserID";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", customerID);

                            command.ExecuteNonQuery();

                            // Reload the customers in the DataGridView
                            LoadCustomers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

                // Get updated information from textboxes
                string updatedName = textBox1.Text;
                string updatedUserName = textBox2.Text;
                string updatedPassword = textBox3.Text;
                string updatedEmail = textBox4.Text;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Update the selected customer in the database
                        string updateQuery = "UPDATE UserTable12 SET ";
                        bool needComma = false;

                        if (!string.IsNullOrWhiteSpace(updatedName))
                        {
                            updateQuery += "Name = @Name";
                            needComma = true;
                        }

                        if (!string.IsNullOrWhiteSpace(updatedUserName))
                        {
                            if (needComma)
                            {
                                updateQuery += ", ";
                            }
                            updateQuery += "UserName = @UserName";
                            needComma = true;
                        }

                        if (!string.IsNullOrWhiteSpace(updatedEmail))
                        {
                            if (needComma)
                            {
                                updateQuery += ", ";
                            }
                            updateQuery += "Email = @Email";
                            needComma = true;
                        }

                        if (!string.IsNullOrWhiteSpace(updatedPassword))
                        {
                            if (needComma)
                            {
                                updateQuery += ", ";
                            }
                            updateQuery += "Password = @Password";
                        }

                        updateQuery += " WHERE UserID = @UserID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            if (!string.IsNullOrWhiteSpace(updatedName))
                            {
                                command.Parameters.AddWithValue("@Name", updatedName);
                            }

                            if (!string.IsNullOrWhiteSpace(updatedUserName))
                            {
                                command.Parameters.AddWithValue("@UserName", updatedUserName);
                            }

                            if (!string.IsNullOrWhiteSpace(updatedEmail))
                            {
                                command.Parameters.AddWithValue("@Email", updatedEmail);
                            }

                            if (!string.IsNullOrWhiteSpace(updatedPassword))
                            {
                                command.Parameters.AddWithValue("@Password", updatedPassword);
                            }

                            command.Parameters.AddWithValue("@UserID", customerID);

                            command.ExecuteNonQuery();

                            // Reload the customers in the DataGridView
                            LoadCustomers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fd = new Form2();
            fd.Show();
            this.Hide();

        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            Form2 fd = new Form2();
            fd.Show();
            this.Hide();
        }
    }
    }
   
