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
    public partial class supplyorder : Form
    {
        private List<supplier_managment> suppliers;
        private List<manageitems> items;
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
        public supplyorder()
        {
            InitializeComponent();
            LoadData();

        }
        private int GetNextOrderID()
        {
            int nextOrderID = 1; // Default value if no orders exist

            try
            {
                connection.Open();

                // Query to get the maximum OrderID from OrderTable
                string query = "SELECT ISNULL(MAX(OrderID), 0) + 1 FROM OrderTable";
                SqlCommand command = new SqlCommand(query, connection);

                // ExecuteScalar is used to get a single value from the query result
                object result = command.ExecuteScalar();

                // Check if the result is not null and is a valid integer
                if (result != null && int.TryParse(result.ToString(), out nextOrderID))
                {
                    // The nextOrderID is successfully retrieved from the database
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching the next OrderID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return nextOrderID;
        }

        private DataTable GetSupplyOrdersFromDatabase()
        {
            DataTable supplyOrdersTable = new DataTable();

            try
            {
                connection.Open();

                string query = "SELECT SupplyOrderTable.Order_ID, " +
                 "SupplierTable.SupplierID, SupplierTable.Name AS SupplierName, " +
                 "InventoryItemTable.ItemID, InventoryItemTable.Name AS ItemName, " +
                 "SupplyOrderTable.Quantity, SupplyOrderTable.Date " +
                 "FROM SupplyOrderTable " +
                 "INNER JOIN SupplierTable ON SupplyOrderTable.SupplierID = SupplierTable.SupplierID " +
                 "INNER JOIN InventoryItemTable ON SupplyOrderTable.ItemID = InventoryItemTable.ItemID";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    supplyOrdersTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return supplyOrdersTable;
        }



        private void LoadSupplyOrdersIntoGrid()
        {
            DataTable supplyOrdersTable = GetSupplyOrdersFromDatabase();
            metroGrid1.DataSource = supplyOrdersTable;
        }
        private void LoadData()
        {
            DataTable suppliersTable = GetSuppliersFromDatabase();
          DataTable  items = GetItemsFromDatabase();

            comboBox1.DataSource = suppliersTable;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "SupplierID";

            comboBox2.DataSource = items;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ItemID";
            LoadSupplyOrdersIntoGrid();
        }
            private DataTable GetSuppliersFromDatabase()
        {
            DataTable suppliersTable = new DataTable();

            try
            {
                connection.Open();
                string query = "SELECT SupplierID, Name FROM SupplierTable";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(suppliersTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return suppliersTable;
        }

        private DataTable GetItemsFromDatabase()
        {
            DataTable itemsTable = new DataTable();

            try
            {
                connection.Open();
                string query = "SELECT ItemID, Name FROM InventoryItemTable";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(itemsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return itemsTable;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

       
            try
            {
                int supplierID = Convert.ToInt32(comboBox1.SelectedValue);
                int itemID = Convert.ToInt32(comboBox2.SelectedValue);
                int quantity = Convert.ToInt32(textBox1.Text);
                DateTime date = dateTimePicker1.Value;

                // Insert the supply order into the database
                string insertOrderQuery = "INSERT INTO SupplyOrderTable (SupplierID, ItemID, Quantity, Date) " +
                              "VALUES (@SupplierID, @ItemID, @Quantity, @Date)";

                SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection);
                insertOrderCommand.Parameters.AddWithValue("@SupplierID", supplierID);
                insertOrderCommand.Parameters.AddWithValue("@ItemID", itemID);
                insertOrderCommand.Parameters.AddWithValue("@Quantity", quantity);
                insertOrderCommand.Parameters.AddWithValue("@Date", date);
              
                connection.Open();
                insertOrderCommand.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Supply order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSupplyOrdersIntoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete order
            try
            {
                // Assuming you have a DataGridView named metroGrid1
                if (metroGrid1.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = metroGrid1.SelectedRows[0].Index;
                    int orderID = Convert.ToInt32(metroGrid1.Rows[selectedRowIndex].Cells["Order_ID"].Value);

                    connection.Open();

                    // Delete the supply order from the database
                    string deleteOrderQuery = "DELETE FROM SupplyOrderTable WHERE Order_ID = @OrderID";
                    SqlCommand deleteOrderCommand = new SqlCommand(deleteOrderQuery, connection);
                    deleteOrderCommand.Parameters.AddWithValue("@OrderID", orderID);
                    deleteOrderCommand.ExecuteNonQuery();

                    connection.Close();

                    // Refresh the grid after deletion
                    LoadSupplyOrdersIntoGrid();

                    MessageBox.Show("Supply order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a supply order to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supplier d = new supplier();
            d.Show();
            this.Close();
            Dispose();
        }
    }
    
}
