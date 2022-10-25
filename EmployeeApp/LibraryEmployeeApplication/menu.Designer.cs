namespace LibraryEmployeeApplication
{
    partial class menu
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
            this.rentedBooksBtn = new System.Windows.Forms.Button();
            this.clientRegistryBtn = new System.Windows.Forms.Button();
            this.booksdbBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bookOrdersBtn = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.employeeDbBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rentedBooksBtn
            // 
            this.rentedBooksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentedBooksBtn.Location = new System.Drawing.Point(12, 58);
            this.rentedBooksBtn.Name = "rentedBooksBtn";
            this.rentedBooksBtn.Size = new System.Drawing.Size(346, 199);
            this.rentedBooksBtn.TabIndex = 0;
            this.rentedBooksBtn.Text = "Rented Books";
            this.rentedBooksBtn.UseVisualStyleBackColor = true;
            this.rentedBooksBtn.Click += new System.EventHandler(this.rentedBooksBtn_Click);
            // 
            // clientRegistryBtn
            // 
            this.clientRegistryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientRegistryBtn.Location = new System.Drawing.Point(388, 58);
            this.clientRegistryBtn.Name = "clientRegistryBtn";
            this.clientRegistryBtn.Size = new System.Drawing.Size(400, 96);
            this.clientRegistryBtn.TabIndex = 1;
            this.clientRegistryBtn.Text = "Client Registry";
            this.clientRegistryBtn.UseVisualStyleBackColor = true;
            this.clientRegistryBtn.Click += new System.EventHandler(this.clientRegistryBtn_Click);
            // 
            // booksdbBtn
            // 
            this.booksdbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksdbBtn.Location = new System.Drawing.Point(388, 285);
            this.booksdbBtn.Name = "booksdbBtn";
            this.booksdbBtn.Size = new System.Drawing.Size(400, 199);
            this.booksdbBtn.TabIndex = 2;
            this.booksdbBtn.Text = "Book Database";
            this.booksdbBtn.UseVisualStyleBackColor = true;
            this.booksdbBtn.Click += new System.EventHandler(this.booksdbBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(735, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log Out";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // bookOrdersBtn
            // 
            this.bookOrdersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookOrdersBtn.Location = new System.Drawing.Point(12, 285);
            this.bookOrdersBtn.Name = "bookOrdersBtn";
            this.bookOrdersBtn.Size = new System.Drawing.Size(346, 199);
            this.bookOrdersBtn.TabIndex = 4;
            this.bookOrdersBtn.Text = "Book Orders";
            this.bookOrdersBtn.UseVisualStyleBackColor = true;
            this.bookOrdersBtn.Click += new System.EventHandler(this.bookOrdersBtn_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(292, 14);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(98, 24);
            this.welcomeLabel.TabIndex = 8;
            this.welcomeLabel.Text = "Welcome";
            // 
            // employeeDbBtn
            // 
            this.employeeDbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeDbBtn.Location = new System.Drawing.Point(388, 160);
            this.employeeDbBtn.Name = "employeeDbBtn";
            this.employeeDbBtn.Size = new System.Drawing.Size(400, 96);
            this.employeeDbBtn.TabIndex = 9;
            this.employeeDbBtn.Text = "Employee Database";
            this.employeeDbBtn.UseVisualStyleBackColor = true;
            this.employeeDbBtn.Click += new System.EventHandler(this.employeeDbBtn_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.employeeDbBtn);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.bookOrdersBtn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.booksdbBtn);
            this.Controls.Add(this.clientRegistryBtn);
            this.Controls.Add(this.rentedBooksBtn);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Library";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rentedBooksBtn;
        private System.Windows.Forms.Button clientRegistryBtn;
        private System.Windows.Forms.Button booksdbBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button bookOrdersBtn;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button employeeDbBtn;
    }
}