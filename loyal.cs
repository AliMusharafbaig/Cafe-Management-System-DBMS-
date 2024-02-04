using Microsoft.Data.SqlClient;
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
    public partial class loyal : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
        public loyal()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                
                    connection.Open();

                    // Query to get user information and visits
                    string query = "SELECT UserTable12.UserID, UserTable12.Username, customer_visits.Visits " +
                                   "FROM UserTable12 " +
                                   "JOIN customer_visits ON UserTable12.UserID = customer_visits.UserID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the DataGridView
                    metroGrid1.DataSource = dataTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                // Extract user information from the selected row
                int userID = Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["UserID"].Value);
                string username = metroGrid1.SelectedRows[0].Cells["Username"].Value.ToString();
                int visits = Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["Visits"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        connection.Open();

                        // Add the user to the LoyaltyTable
                        string addToLoyaltyQuery = "INSERT INTO LoyaltyTable (UserID, Username, Visits) VALUES (@UserID, @Username, @Visits)";
                        using (SqlCommand addToLoyaltyCommand = new SqlCommand(addToLoyaltyQuery, connection))
                        {
                            addToLoyaltyCommand.Parameters.AddWithValue("@UserID", userID);
                            addToLoyaltyCommand.Parameters.AddWithValue("@Username", username);
                            addToLoyaltyCommand.Parameters.AddWithValue("@Visits", visits);

                            addToLoyaltyCommand.ExecuteNonQuery();

                            MessageBox.Show("User added to LoyaltyTable successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Refresh the DataGridView
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to add to LoyaltyTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cashier_cs ass = new cashier_cs();
            this.Hide();
            ass.Show();
            Dispose();
        }
    }
}