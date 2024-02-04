using MetroFramework.Controls;
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
    public partial class modfiy : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
        public modfiy()
        {
            InitializeComponent();
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

                metroGrid1.DataSource = itemsDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*   private void ModifySelectedItem()
           {
              // int modifiedQuantity = Convert.ToInt32(textBox4.Text);
              // int modifiedThreshold = Convert.ToInt32(textBox5.Text);
               try
               {
                   if (metroGrid1.SelectedRows.Count > 0)
                   {
                       int selectedItemID = Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["ItemID"].Value);

                       connection.Open();

                       // Modify in MenuItemTable
                       string updateMenuQuery = "UPDATE MenuItemTable SET ";
                       if (!string.IsNullOrWhiteSpace(textBox1.Text))
                       {
                           updateMenuQuery += "Item_Name = @ModifiedName, ";
                       }

                       if (!string.IsNullOrWhiteSpace(textBox2.Text))
                       {
                           updateMenuQuery += "Category = @ModifiedCategory, ";
                       }

                       if (!string.IsNullOrWhiteSpace(textBox3.Text))
                       {
                           updateMenuQuery += "Price = @ModifiedPrice, ";
                       }

                       if (!string.IsNullOrWhiteSpace(textBox6.Text))
                       {
                           updateMenuQuery += "Description = @ModifiedDescription, ";
                       }

                       // Remove the trailing comma
                       updateMenuQuery = updateMenuQuery.TrimEnd(',', ' ');

                       updateMenuQuery += $" WHERE Item_ID = {selectedItemID}";

                       SqlCommand updateMenuCommand = new SqlCommand(updateMenuQuery, connection);
                       if (!string.IsNullOrWhiteSpace(textBox1.Text))
                       {
                           updateMenuCommand.Parameters.AddWithValue("@ModifiedName", textBox1.Text.Trim());
                       }

                       if (!string.IsNullOrWhiteSpace(textBox2.Text))
                       {
                           updateMenuCommand.Parameters.AddWithValue("@ModifiedCategory", textBox2.Text.Trim());
                       }

                       if (!string.IsNullOrWhiteSpace(textBox3.Text))
                       {
                           updateMenuCommand.Parameters.AddWithValue("@ModifiedPrice", Convert.ToDecimal(textBox3.Text.Trim()));
                       }

                       if (!string.IsNullOrWhiteSpace(textBox6.Text))
                       {
                           updateMenuCommand.Parameters.AddWithValue("@ModifiedDescription", textBox6.Text.Trim());
                       }

                       updateMenuCommand.ExecuteNonQuery();

                       // Modify in InventoryItemTable
                       if (!string.IsNullOrWhiteSpace(textBox4.Text))
                       {
                           if (int.TryParse(textBox4.Text.Trim(), out int modifiedQuantity))
                           {
                               string updateInventoryQuery = $"UPDATE InventoryItemTable SET Quantity = @modifiedQuantity WHERE ItemID = {selectedItemID}";
                               SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection);
                               updateInventoryCommand.Parameters.AddWithValue("@modifiedQuantity", modifiedQuantity);
                               updateInventoryCommand.ExecuteNonQuery();
                           }
                           else
                           {
                               // Handle the case where the input is not a valid integer
                               MessageBox.Show("Please enter a valid integer value for Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           }
                       }

                       // Similarly, do the same for modifiedThreshold
                       if (!string.IsNullOrWhiteSpace(textBox5.Text))
                       {
                           if (int.TryParse(textBox5.Text.Trim(), out int  modifiedThreshold))
                           {
                               string updateInventoryQuery = $"UPDATE InventoryItemTable SET Threshold = @modifiedThreshold WHERE ItemID = {selectedItemID}";
                               SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection);
                               updateInventoryCommand.Parameters.AddWithValue("@modifiedThreshold", modifiedThreshold);
                               updateInventoryCommand.ExecuteNonQuery();
                           }
                           else
                           {
                               // Handle the case where the input is not a valid integer
                               MessageBox.Show("Please enter a valid integer value for Threshold.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           }
                       }

                       connection.Close();

                       // Reload the items after modification
                       LoadItems();

                       MessageBox.Show("Item modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else
                   {
                       MessageBox.Show("Please select an item to modify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

           */

        private void ModifySelectedItem()
        {
            try
            {
                if (metroGrid1.SelectedRows.Count > 0)
                {
                    int selectedItemID = Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["ItemID"].Value);
                    connection.Open();

                    bool isMenuItemUpdated = false;
                    string updateMenuQuery = "UPDATE MenuItemTable SET ";

                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        updateMenuQuery += "Item_Name = @ModifiedName, ";
                        isMenuItemUpdated = true;
                    }

                    if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        updateMenuQuery += "Category = @ModifiedCategory, ";
                        isMenuItemUpdated = true;
                    }

                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        updateMenuQuery += "Price = @ModifiedPrice, ";
                        isMenuItemUpdated = true;
                    }

                    if (!string.IsNullOrWhiteSpace(textBox6.Text))
                    {
                        updateMenuQuery += "Description = @ModifiedDescription, ";
                        isMenuItemUpdated = true;
                    }

                    if (isMenuItemUpdated)
                    {
                        updateMenuQuery = updateMenuQuery.TrimEnd(',', ' ');
                        updateMenuQuery += $" WHERE Item_ID = {selectedItemID}";

                        SqlCommand updateMenuCommand = new SqlCommand(updateMenuQuery, connection);

                        if (!string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            updateMenuCommand.Parameters.AddWithValue("@ModifiedName", textBox1.Text.Trim());
                        }

                        if (!string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            updateMenuCommand.Parameters.AddWithValue("@ModifiedCategory", textBox2.Text.Trim());
                        }

                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                        {
                            updateMenuCommand.Parameters.AddWithValue("@ModifiedPrice", Convert.ToDecimal(textBox3.Text.Trim()));
                        }

                        if (!string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            updateMenuCommand.Parameters.AddWithValue("@ModifiedDescription", textBox6.Text.Trim());
                        }

                        updateMenuCommand.ExecuteNonQuery();
                    }

                    // Modify in InventoryItemTable
                    if (!string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        if (int.TryParse(textBox4.Text.Trim(), out int modifiedQuantity))
                        {
                            string updateInventoryQuery = $"UPDATE InventoryItemTable SET Quantity = @ModifiedQuantity WHERE ItemID = {selectedItemID}";
                            SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection);
                            updateInventoryCommand.Parameters.AddWithValue("@ModifiedQuantity", modifiedQuantity);
                            updateInventoryCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid integer value for Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        if (int.TryParse(textBox5.Text.Trim(), out int modifiedThreshold))
                        {
                            string updateInventoryQuery = $"UPDATE InventoryItemTable SET Threshold = @ModifiedThreshold WHERE ItemID = {selectedItemID}";
                            SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection);
                            updateInventoryCommand.Parameters.AddWithValue("@ModifiedThreshold", modifiedThreshold);
                            updateInventoryCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid integer value for Threshold.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        
                            string updateInventoryQuery = $"UPDATE InventoryItemTable SET NAME = @Modifiedname WHERE ItemID = {selectedItemID}";
                            SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection);
                            updateInventoryCommand.Parameters.AddWithValue("@Modifiedname", textBox1.Text);
                            updateInventoryCommand.ExecuteNonQuery();
                        }
                       
                    

                    connection.Close();

                    // Reload the items after modification
                    LoadItems();

                    MessageBox.Show("Item modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select an item to modify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModifySelectedItem();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
