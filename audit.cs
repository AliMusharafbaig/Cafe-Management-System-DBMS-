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
    public partial class audit : Form
    {
        string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
        public audit()
        {
            InitializeComponent();
            LoadAuditData();
        }
        private void LoadAuditData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    OT.OrderID, 
                    OT.UserID,
                    OT.Time AS OrderTime,
                    OIT.ItemName,
                    OIT.Quantity,
                    OIT.Price,
                    OIT.Quantity * OIT.Price AS Revenue
                FROM 
                    OrderTable OT
                JOIN 
                    OrderItemTable OIT ON OT.OrderID = OIT.OrderID
                ORDER BY 
                    OT.Time DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        metroGrid1.DataSource = dataTable;

                        // Calculate total revenue
                        decimal totalRevenue = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            totalRevenue += Convert.ToDecimal(row["Revenue"]);
                        }

                        // Display total revenue in a TextBox (assuming you have a TextBox named textBoxTotalRevenue)
                        textBoxTotalRevenue.Text = $"Total Revenue: {totalRevenue:C}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxTotalRevenue_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashier_cs SA = new cashier_cs();
            this.Hide();
            SA.Show();
        }
    }
}
