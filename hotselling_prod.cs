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
    public partial class hotselling_prod : Form
    {
        string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";
        public hotselling_prod()
        {
            InitializeComponent();
            LoadHotSellingItems();
            Loadsales();
            Loadmostsold();
            LoadHotSellingItemsWithRevenue();
        }
        private void LoadHotSellingItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    OIT.ItemName, 
                    MIT.Category,
                    COUNT(*) AS SalesCount 
                FROM 
                    OrderItemTable OIT
                JOIN 
                    MenuItemTable MIT ON OIT.Item_ID = MIT.Item_ID
                GROUP BY 
                    OIT.ItemName, MIT.Category
                ORDER BY 
                    SalesCount DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        metroGrid1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Loadsales()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT * 
                  
                FROM 
                    OrderItemTable";
               

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        metroGrid2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Loadmostsold()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT TOP 1
                    OIT.ItemName, 
                    MIT.Category,
                    COUNT(*) AS SalesCount,
                    COUNT(DISTINCT OIT.OrderID) AS TotalOrders
                FROM 
                    OrderItemTable OIT
                JOIN 
                    MenuItemTable MIT ON OIT.Item_ID = MIT.Item_ID
                GROUP BY 
                    OIT.ItemName, MIT.Category
                ORDER BY 
                    SalesCount DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        metroGrid3.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHotSellingItemsWithRevenue()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    OIT.ItemName, 
                    MIT.Category,
                    COUNT(*) AS SalesCount,
                    SUM(OIT.Quantity * MIT.Price) AS TotalRevenue
                FROM 
                    OrderItemTable OIT
                JOIN 
                    MenuItemTable MIT ON OIT.Item_ID = MIT.Item_ID
                GROUP BY 
                    OIT.ItemName, MIT.Category
                ORDER BY 
                    SalesCount DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        metroGrid4.DataSource = dataTable;
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

        private void sPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashier_cs aaa = new cashier_cs();
            this.Hide();
            aaa.Show();
            Dispose();
        }
    }
}
