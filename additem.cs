using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Signup
{
    public partial class additem : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");

        private void sPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Your paint logic here
        }

        private void additem_Load(object sender, EventArgs e)
        {
            // Your load logic here
        }

        public additem()
        {
            InitializeComponent();
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = textBox4.Text.Trim();
                string category = textBox5.Text.Trim();
                decimal price = Convert.ToDecimal(textBox1.Text.Trim());
                string description = textBox6.Text.Trim();
                int quantity = Convert.ToInt32(textBox2.Text.Trim());
                int threshold = Convert.ToInt32(textBox3.Text.Trim());

                // Insert into MenuItemTable
                string insertMenuQuery = $"INSERT INTO MenuItemTable (Item_Name, Category, Price, Description) " +
                                         $"VALUES (@ItemName, @Category, @Price, @Description); " +
                                         "SELECT SCOPE_IDENTITY();";

                SqlCommand menuCommand = new SqlCommand(insertMenuQuery, connection);
                menuCommand.Parameters.AddWithValue("@ItemName", itemName);
                menuCommand.Parameters.AddWithValue("@Category", category);
                menuCommand.Parameters.AddWithValue("@Price", price);
                menuCommand.Parameters.AddWithValue("@Description", description);

                connection.Open();
                int menuItemID = Convert.ToInt32(menuCommand.ExecuteScalar());
                connection.Close();

                string enableIdentityInsertQuery = "SET IDENTITY_INSERT InventoryItemTable ON";
                SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertQuery, connection);
                connection.Open();
                enableIdentityInsertCommand.ExecuteNonQuery();

                // Insert into InventoryItemTable using the obtained Item_ID
                string insertInventoryQuery = $"INSERT INTO InventoryItemTable (ItemID, Name, Quantity, Threshold) " +
                                              $"VALUES ({menuItemID}, '{itemName}', {quantity}, {threshold})";

                SqlCommand inventoryCommand = new SqlCommand(insertInventoryQuery, connection);
                inventoryCommand.Parameters.AddWithValue("@ItemID", menuItemID);
                inventoryCommand.Parameters.AddWithValue("@Name", itemName);
                inventoryCommand.Parameters.AddWithValue("@Quantity", quantity);
                inventoryCommand.Parameters.AddWithValue("@Threshold", threshold);

                inventoryCommand.ExecuteNonQuery();

                string disableIdentityInsertQuery = "SET IDENTITY_INSERT InventoryItemTable OFF";
                SqlCommand disableIdentityInsertCommand = new SqlCommand(disableIdentityInsertQuery, connection);
                disableIdentityInsertCommand.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Item added to the menu and inventory successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for price, quantity, and threshold.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sTextBox1__TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageitems as1 = new manageitems();
            this.Hide();
            as1.Show();
            this.Hide();
        }
    }
}
