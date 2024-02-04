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
    public partial class manageitems : Form
    {
        public int ItemID { get; set; }
        public int SelectedItemID { get; private set; }
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
        public manageitems()
        {
            InitializeComponent();
            //   private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
            LoadItems();
        }
        private void LoadItems()
        {
            try
            {
                // Fetch items from the database and display them in the DataGridView
                // Replace this with your actual SQL query
                string query = "SELECT I.ItemID, I.Name, I.Quantity, I.Threshold, M.Price, M.Description, M.Category " +
                       "FROM InventoryItemTable I " +
                       "INNER JOIN MenuItemTable M ON I.ItemID = M.Item_ID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable itemsDataTable = new DataTable();
                adapter.Fill(itemsDataTable);

                metroGrid2.DataSource = itemsDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteSelectedItem()
        {
            try
            {
                if (metroGrid2.SelectedRows.Count > 0)
                {
                    int selectedItemID = Convert.ToInt32(metroGrid2.SelectedRows[0].Cells["ItemID"].Value);

                    connection.Open();

                    // Retrieve corresponding Item_ID from InventoryItemTable
                    string getItemIDQuery = $"SELECT ItemID FROM InventoryItemTable WHERE ItemID = {selectedItemID}";
                    SqlCommand getItemIDCommand = new SqlCommand(getItemIDQuery, connection);
                    int menuID = Convert.ToInt32(getItemIDCommand.ExecuteScalar());

                    // Delete from InventoryItemTable
                    string deleteInventoryQuery = $"DELETE FROM InventoryItemTable WHERE ItemID = {selectedItemID}";
                    SqlCommand deleteInventoryCommand = new SqlCommand(deleteInventoryQuery, connection);
                    deleteInventoryCommand.ExecuteNonQuery();

                    // Delete from MenuItemTable
                    string deleteMenuQuery = $"DELETE FROM MenuItemTable WHERE Item_ID = {menuID}";
                    SqlCommand deleteMenuCommand = new SqlCommand(deleteMenuQuery, connection);
                    deleteMenuCommand.ExecuteNonQuery();

                    connection.Close();

                    // Reload the items after deletion
                    LoadItems();

                    MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                additem addMenuItemForm = new additem();
                this.Hide();

                addMenuItemForm.ShowDialog();


                // Refresh the DataGridView
                LoadItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();//Deleting the item
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modfiy form1 = new modfiy();
            form1.Show();
            this.Close();
            Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventory fom = new inventory();
            this.Hide();
            fom.Show();
            Dispose();
        }
    }
}
