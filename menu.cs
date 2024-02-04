using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Signup
{
    public partial class menu : Form
    {
        public int get_current_id { get; set; }
        private SqlConnection connection;
        string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
        public menu()
        {
            InitializeComponent();
            // FetchItems(); // Uncomment if needed
        }

        private void FetchItemsByCategory(string category)
        {
            try
            {
                string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Item_ID, Item_Name, Category, Price, Description FROM MenuItemTable WHERE Category = @Category";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsSufficientInventory(SqlConnection connection, string itemName, int quantity)
        {
            string query = "SELECT Quantity FROM InventoryItemTable WHERE Name = @ItemName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ItemName", itemName);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int availableQuantity))
                {
                    return availableQuantity >= quantity;
                }

                return false;
            }
        }


        private void UpdateInventoryQuantitybyname(SqlConnection connection, string itemname, int quantity)
        {
            string updateQuery = "UPDATE InventoryItemTable SET Quantity = Quantity - @Quantity WHERE Name = @itemname";
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@itemname", itemname);
                command.Parameters.AddWithValue("@Quantity", quantity);

                command.ExecuteNonQuery();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem.ToString();
            FetchItemsByCategory(selectedCategory);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementation if needed
        }

        private void menu_Load(object sender, EventArgs e)
        {
            // Implementation if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

            int itemID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            string itemName = dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
            decimal price = Convert.ToDecimal(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);

            int quantity = (int)numericUpDown1.Value;

            if (itemID <= 0 || quantity <= 0)
            {
                MessageBox.Show("Invalid item or quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if there is enough inventory
                if (!IsSufficientInventory(connection, itemName, quantity))
                {
                    MessageBox.Show($"Insufficient inventory for item '{itemName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int orderID = GetOpenOrderID(connection);

                if (orderID == 0)
                {
                    orderID = CreateOrder(connection);
                }

                string insertQuery = "INSERT INTO OrderItemTable (OrderID, Item_ID, ItemName, Quantity, Price) VALUES (@OrderID, @Item_ID, @ItemName, @Quantity, @Price)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@Item_ID", itemID);
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price); // Use the original price without discount

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Item '{itemName}' added to cart with price {price:C}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update inventory quantity based on item name
                        UpdateInventoryQuantitybyname(connection, itemName, quantity);

                        UpdateOrderTotalAmount(connection, orderID);
                        UpdateOrderItemNames(connection, orderID); // Update item names after adding items
                    }
                    else
                    {
                        MessageBox.Show("Failed to add item to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int GetCurrentUserID(SqlConnection connection, string username)
        {
            string query = "SELECT UserID FROM UserTable WHERE Username = @Username";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetOpenOrderID(SqlConnection connection)
        {
            try
            {
                string query = "SELECT OrderID FROM OrderTable WHERE UserID = @UserID ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", get_current_id);

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int orderId))
                    {
                        return orderId;
                    }

                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetOpenOrderID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        private int CreateOrder(SqlConnection connection)
        {
            string insertQuery = "INSERT INTO OrderTable (UserID, Time, TotalAmount) VALUES (@UserID, @Time, @TotalAmount); SELECT SCOPE_IDENTITY()";
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@UserID", get_current_id);
                command.Parameters.AddWithValue("@Time", DateTime.Now);

                decimal totalAmount = 0.0m; // Initially, the total amount is zero
                command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private string GetItemNamesForOrder(SqlConnection connection, int orderID)
        {
            string query = "SELECT MIT.Item_Name " +
                           "FROM OrderItemTable OIT " +
                           "JOIN MenuItemTable MIT ON OIT.Item_ID = MIT.Item_ID " +
                           "WHERE OIT.OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", orderID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> itemNames = new List<string>();

                    while (reader.Read())
                    {
                        itemNames.Add(reader["Item_Name"].ToString());
                    }

                    return string.Join(", ", itemNames);
                }
            }
        }

        private decimal CalculateTotalAmount(SqlConnection connection, int orderID)
        {
            string query = "SELECT SUM(OIT.Quantity * MIT.Price) " +
                           "FROM OrderItemTable OIT " +
                           "JOIN MenuItemTable MIT ON OIT.Item_ID = MIT.Item_ID " +
                           "WHERE OIT.OrderID = @OrderID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", orderID);

                object result = command.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0.0m;
            }
        }

        private void UpdateOrderTotalAmount(SqlConnection connection, int orderID)
        {
            try
            {
                string updateQuery = "UPDATE OrderTable SET TotalAmount = @TotalAmount WHERE OrderID = @OrderID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    decimal totalAmount = CalculateTotalAmount(connection, orderID);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    command.ExecuteNonQuery();
                    MessageBox.Show($"Order total amount updated: {totalAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order total amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderItemNames(SqlConnection connection, int orderID)
        {
            try
            {
                string itemNames = GetItemNamesForOrder(connection, orderID);

                string updateQuery = "UPDATE OrderTable SET Itemname = @Itemname WHERE OrderID = @OrderID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Itemname", itemNames);
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    command.ExecuteNonQuery();
                    MessageBox.Show($"Order item names updated: {itemNames}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order item names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int orderID = GetOpenOrderID(connection);
                    if (orderID > 0)
                    {
                        // Insert data from OrderTable and OrderItemTable into ViewCart table
                        string insertQuery = @"
                           INSERT INTO ViewCart (ItemName, Order_ID, UserID, Price, TotalAmount, Quantity)
                      SELECT
    OIT.ItemName,
    OT.OrderID,
    OT.UserID,
    OIT.Price,
    OIT.Quantity * OIT.Price AS TotalAmount,
    OIT.Quantity
FROM
    OrderTable OT
JOIN
    OrderItemTable OIT ON OT.OrderID = OIT.OrderID
WHERE
    OT.OrderID = @OrderID AND OT.UserID = @UserID";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OrderID", orderID);
                            command.Parameters.AddWithValue("@UserID", get_current_id);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                cart viewCartForm = new cart(orderID, get_current_id);
                                this.Hide();
                                viewCartForm.ShowDialog();
                                Dispose();
                            }
                            else
                            {
                                MessageBox.Show("No items in the cart to proceed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No open orders found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        

        private void CreateViewCartTable(SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE TABLE  ViewCart (Order_ID INT, UserID INT, ItemName NVARCHAR(200), Price MONEY, TotalAmount MONEY, Quantity INT)", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the ViewCart table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDataIntoViewCart(SqlConnection connection, int orderID, int userID)
        {
            try
            {
                
                // Insert data from OrderTable and OrderItemTable into ViewCart table
                string insertQuery = @"
            INSERT INTO ViewCart (ItemName, Order_ID, UserID, Price, TotalAmount, Quantity)
            SELECT
                OIT.ItemName,
                OT.OrderID,
                OT.UserID,
                OIT.Price,
                OT.TotalAmount,
                OIT.Quantity
            FROM
                OrderTable OT
            JOIN
                OrderItemTable OIT ON OT.OrderID = OIT.OrderID
            WHERE
                OT.OrderID = @OrderID AND OT.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@UserID", userID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while inserting data into the ViewCart table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin_login form1 = new admin_login();
            this.Hide();
            form1.Show();
            Dispose();
        }
    }
}

/*private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"
                INSERT INTO ViewOrder (Order_ID, Name, Quantity, Price, Total_Price)
                SELECT 
                    O.Order_ID,
                    CONCAT(U.First_name, ' ', U.Last_Name) AS Name,
                    O.Quantity,
                    I.Price AS ItemPrice,
                    O.Total_Price
                FROM OrderItem O
                JOIN Users U ON O.User_ID = U.User_ID
                JOIN Items I ON O.Item_ID = I.Item_ID;
            ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            OrderCheck OC = new OrderCheck();
                            OC.Show();

                            Dispose();


                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data into ViewOrder.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




















            //OrderCheck OC = new OrderCheck();
            // OC.Show();
            // Dispose();






        }*/