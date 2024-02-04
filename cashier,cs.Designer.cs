namespace Signup
{
    partial class cashier_cs
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
            this.sPanel1 = new Sipaa.Framework.SPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.sPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sPanel1
            // 
            this.sPanel1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.sPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.sPanel1.BorderRadius = 6;
            this.sPanel1.BorderSize = 0;
            this.sPanel1.Controls.Add(this.button4);
            this.sPanel1.Controls.Add(this.button3);
            this.sPanel1.Controls.Add(this.button2);
            this.sPanel1.Controls.Add(this.button1);
            this.sPanel1.ForeColor = System.Drawing.Color.White;
            this.sPanel1.Location = new System.Drawing.Point(93, 62);
            this.sPanel1.Name = "sPanel1";
            this.sPanel1.Size = new System.Drawing.Size(548, 300);
            this.sPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(54, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "WELCOME TO INSIGHTS REPORTS DASHBOARD";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(178, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "REVENUE INSIGHTS REPORTS";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(326, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "SEE INSIGHTS ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(44, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "ADD LOYAL CUSTOMERS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(470, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "BACK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cashier_cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sPanel1);
            this.Name = "cashier_cs";
            this.Text = "cashier_cs";
            this.sPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sipaa.Framework.SPanel sPanel1;
        private Button button2;
        private Button button1;
        private Button button3;
        private Label label1;
        private Button button4;
    }
}