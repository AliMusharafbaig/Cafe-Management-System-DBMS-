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
    public partial class supplier_managment : Form
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        private SqlConnection connection = new SqlConnection("Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True");
        public supplier_managment()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                // Fetch suppliers from the database and display them in the DataGridView
                string query = "SELECT * FROM SupplierTable";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable suppliersDataTable = new DataTable();
                adapter.Fill(suppliersDataTable);

                metroGrid1.DataSource = suppliersDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Insert the new supplier into the database
                string insertSupplierQuery = "INSERT INTO SupplierTable (Name, ContactInfo) VALUES (@Name, @ContactInfo)";
                SqlCommand insertSupplierCommand = new SqlCommand(insertSupplierQuery, connection);
                insertSupplierCommand.Parameters.AddWithValue("@Name", textBox2.Text);
                insertSupplierCommand.Parameters.AddWithValue("@ContactInfo", textBox3.Text);
                insertSupplierCommand.ExecuteNonQuery();

                connection.Close();

                // Refresh the DataGridView after insertion
                LoadSuppliers();

                MessageBox.Show("Supplier added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    

        private void button2_Click(object sender, EventArgs e)
        {
            //delete 
            if (metroGrid1.SelectedRows.Count > 0)
            {
                int selectedSupplierID = Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["SupplierID"].Value);

                try
                {
                    connection.Open();

                    // Delete the selected supplier from the database
                    string deleteSupplierQuery = "DELETE FROM SupplierTable WHERE SupplierID = @SupplierID";
                    SqlCommand deleteSupplierCommand = new SqlCommand(deleteSupplierQuery, connection);
                    deleteSupplierCommand.Parameters.AddWithValue("@SupplierID", selectedSupplierID);
                    deleteSupplierCommand.ExecuteNonQuery();

                    connection.Close();

                    // Refresh the DataGridView after deletion
                    LoadSuppliers();

                    MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Add functionality to modify the selected supplier
            if (metroGrid1.SelectedRows.Count > 0)
            {
                try
                {
                    connection.Open();

                    // Update the selected supplier in the database
                    string updateSupplierQuery = "UPDATE SupplierTable SET Name = @Name, ContactInfo = @ContactInfo WHERE SupplierID = @SupplierID";
                    SqlCommand updateSupplierCommand = new SqlCommand(updateSupplierQuery, connection);
                    updateSupplierCommand.Parameters.AddWithValue("@Name", textBox2.Text);
                    updateSupplierCommand.Parameters.AddWithValue("@ContactInfo", textBox3.Text);
                    updateSupplierCommand.Parameters.AddWithValue("@SupplierID", Convert.ToInt32(metroGrid1.SelectedRows[0].Cells["SupplierID"].Value));
                    updateSupplierCommand.ExecuteNonQuery();

                    connection.Close();

                    // Refresh the DataGridView after modification
                    LoadSuppliers();

                    MessageBox.Show("Supplier modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Please select a supplier to modify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


            private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplier form1 = new supplier();
            this.Hide();
            form1.Show();
            Dispose();
        }
    }
}
