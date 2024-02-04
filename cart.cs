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
    public partial class cart : Form
    {
        string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
        private int orderID;
        private int userID;

        public cart(int orderID, int userID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.userID = userID;

            // Load the cart items when the form is initialized
            LoadCartItems();
        }

      
        private void LoadCartItems()
        {
            try
            {
                string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * from ViewCart";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);
                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No items found in the cart.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable;
                            decimal totalAmount = CalculateTotalAmount(dataTable);
                            label1.Text = $"Total Amount: {totalAmount:C}";

                            // Add this line to automatically resize the column widths
                            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal CalculateTotalAmount(DataTable dataTable)
        {
            decimal totalAmount = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                totalAmount += quantity * price;
            }

            return totalAmount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Clear ViewCart
                    string clearViewCartQuery = "DELETE FROM ViewCart";

                    using (SqlCommand clearCommand = new SqlCommand(clearViewCartQuery, connection))
                    {
                        clearCommand.ExecuteNonQuery();
                    }

                    // Calculate total amount
                    DataTable cartDataTable = (DataTable)dataGridView1.DataSource;
                    decimal totalAmount = CalculateTotalAmount(cartDataTable);

                    // Check if the user is in the LoyaltyTable
                    string checkLoyaltyQuery = "SELECT COUNT(*) FROM LoyaltyTable WHERE UserID = @UserID";
                    using (SqlCommand checkLoyaltyCommand = new SqlCommand(checkLoyaltyQuery, connection))
                    {
                        checkLoyaltyCommand.Parameters.AddWithValue("@UserID", userID);

                        int userCount = (int)checkLoyaltyCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // User is in LoyaltyTable, apply discount
                            decimal discountPercentage = 10; // 10% discount (you can adjust this)
                            decimal discountAmount = totalAmount * (discountPercentage / 100);
                            totalAmount -= discountAmount;

                            MessageBox.Show($"Discount applied! Original Amount: {totalAmount + discountAmount:C}, Discount Amount: {discountAmount:C}", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // User is not in LoyaltyTable, proceed without discount
                            MessageBox.Show($"No discount applied. Amount: {totalAmount:C}", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Show PaymentOptionsForm without processing the payment at this point
                    payment paymentOptionsForm = new payment(totalAmount);
                    this.Hide();
                    paymentOptionsForm.ShowDialog();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DeleteItemFromCart(string itemName)
        {
            try
            {
                // Connect to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete the selected item from the ViewCart
                    string deleteItemQuery = "DELETE FROM ViewCart WHERE ItemName = @ItemName";

                    using (SqlCommand deleteItemCommand = new SqlCommand(deleteItemQuery, connection))
                    {
                        deleteItemCommand.Parameters.AddWithValue("@ItemName", itemName);
                        deleteItemCommand.ExecuteNonQuery();

                        // Reload the cart items after deletion
                        LoadCartItems();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected in the DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Get the ItemName of the selected row
                    string itemName = selectedRow.Cells["ItemName"].Value.ToString();

                    // Prompt the user for confirmation before deletion
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove '{itemName}' from the cart?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Perform the deletion
                        DeleteItemFromCart(itemName);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete from the cart.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}