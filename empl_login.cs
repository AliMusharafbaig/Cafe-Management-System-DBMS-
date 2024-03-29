﻿using Microsoft.Data.SqlClient;
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
    public partial class empl_login : Form
    {
        public empl_login()
        {
            InitializeComponent();
        }

        private void sPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             string username = textBox1.Text;
               string password = textBox2.Text;

                // Validate input
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a connection string
                string connectionString = "Data Source=IBRAHIM\\SQLEXPRESS;Initial Catalog=signup1;Integrated Security=True;TrustServerCertificate=True";

                // Create a SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command
                    string selectQuery = "SELECT UserID FROM UserTable12 WHERE Username = @Username AND Password = @Password AND Role = 'Employee'";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the command
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int userID = (int)result;

                            // Login successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open the admin menu form and pass the user ID
                        cashier_cs new_form = new cashier_cs();
                        new_form.Show();

                       
                        this.Close();
                        Dispose();
                    }
                        else
                        {
                            // Login failed
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 as1 = new Form1();
            this.Hide();
            as1.Show();
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home DF = new Home();
            this.Hide();
            DF.Show();
            Dispose();
        }
    }
    }



