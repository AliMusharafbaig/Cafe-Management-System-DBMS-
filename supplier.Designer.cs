namespace Signup
{
    partial class supplier
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
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.sPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sPanel1
            // 
            this.sPanel1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.sPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.sPanel1.BorderRadius = 6;
            this.sPanel1.BorderSize = 0;
            this.sPanel1.Controls.Add(this.button1);
            this.sPanel1.Controls.Add(this.label1);
            this.sPanel1.Controls.Add(this.radioButton2);
            this.sPanel1.Controls.Add(this.radioButton1);
            this.sPanel1.ForeColor = System.Drawing.Color.White;
            this.sPanel1.Location = new System.Drawing.Point(57, 80);
            this.sPanel1.Name = "sPanel1";
            this.sPanel1.Size = new System.Drawing.Size(677, 268);
            this.sPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(51, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "WELCOME TO VENDOR MANAGEMENT DASHBOARD";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(329, 111);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(315, 34);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "SUPPLY ORDER MANAGMENT";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(51, 111);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(260, 34);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "SUPPLIER MANAGMENT";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(578, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 424);
            this.Controls.Add(this.sPanel1);
            this.Name = "supplier";
            this.Text = "supplier";
            this.sPanel1.ResumeLayout(false);
            this.sPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sipaa.Framework.SPanel sPanel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label1;
        private Button button1;
    }
}