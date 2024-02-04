namespace Signup
{
    partial class MANAGECUSTOMERS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Name1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.sButton1 = new Sipaa.Framework.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.sPanel1 = new Sipaa.Framework.SPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.sPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(461, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 367);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(505, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(25, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "ADD USER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(189, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "DELETE USER";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(343, 496);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "MODIFY USER";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Name1.Location = new System.Drawing.Point(37, 150);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(52, 40);
            this.Name1.TabIndex = 4;
            this.Name1.Text = "NAME\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(33, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(31, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "PASSWORD";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(137, 283);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 9;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "EMAIL";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(137, 361);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 11;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // sButton1
            // 
            this.sButton1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sButton1.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.sButton1.BorderRadius = 6;
            this.sButton1.BorderSize = 0;
            this.sButton1.FlatAppearance.BorderSize = 0;
            this.sButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sButton1.ForeColor = System.Drawing.Color.White;
            this.sButton1.Location = new System.Drawing.Point(907, 640);
            this.sButton1.Name = "sButton1";
            this.sButton1.Size = new System.Drawing.Size(150, 37);
            this.sButton1.TabIndex = 14;
            this.sButton1.Text = "BACK";
            this.sButton1.UseVisualStyleBackColor = false;
            this.sButton1.Click += new System.EventHandler(this.sButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(202, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(700, 33);
            this.label4.TabIndex = 15;
            this.label4.Text = "WELCOME TO USER MANAGMENT DASHBOARD";
            // 
            // sPanel1
            // 
            this.sPanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.sPanel1.BorderRadius = 6;
            this.sPanel1.BorderSize = 0;
            this.sPanel1.Controls.Add(this.label4);
            this.sPanel1.ForeColor = System.Drawing.Color.White;
            this.sPanel1.Location = new System.Drawing.Point(-2, 12);
            this.sPanel1.Name = "sPanel1";
            this.sPanel1.Size = new System.Drawing.Size(1075, 58);
            this.sPanel1.TabIndex = 16;
            // 
            // MANAGECUSTOMERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1069, 673);
            this.Controls.Add(this.sPanel1);
            this.Controls.Add(this.sButton1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "MANAGECUSTOMERS";
            this.Text = "MANAGE_CUSTOMERS";
            this.Load += new System.EventHandler(this.MANAGE_CUSTOMERS_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.sPanel1.ResumeLayout(false);
            this.sPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label Name1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox4;
        private Sipaa.Framework.SButton sButton1;
        private Label label4;
        private Sipaa.Framework.SPanel sPanel1;
    }
}