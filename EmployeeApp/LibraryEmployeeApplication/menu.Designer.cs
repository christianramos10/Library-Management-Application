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
            this.SuspendLayout();
            // 
            // rentedBooksBtn
            // 
            this.rentedBooksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentedBooksBtn.Location = new System.Drawing.Point(12, 30);
            this.rentedBooksBtn.Name = "rentedBooksBtn";
            this.rentedBooksBtn.Size = new System.Drawing.Size(346, 426);
            this.rentedBooksBtn.TabIndex = 0;
            this.rentedBooksBtn.Text = "Rented Books";
            this.rentedBooksBtn.UseVisualStyleBackColor = true;
            this.rentedBooksBtn.Click += new System.EventHandler(this.rentedBooksBtn_Click);
            // 
            // clientRegistryBtn
            // 
            this.clientRegistryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientRegistryBtn.Location = new System.Drawing.Point(388, 30);
            this.clientRegistryBtn.Name = "clientRegistryBtn";
            this.clientRegistryBtn.Size = new System.Drawing.Size(400, 199);
            this.clientRegistryBtn.TabIndex = 1;
            this.clientRegistryBtn.Text = "Client Registry";
            this.clientRegistryBtn.UseVisualStyleBackColor = true;
            this.clientRegistryBtn.Click += new System.EventHandler(this.clientRegistryBtn_Click);
            // 
            // booksdbBtn
            // 
            this.booksdbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksdbBtn.Location = new System.Drawing.Point(388, 257);
            this.booksdbBtn.Name = "booksdbBtn";
            this.booksdbBtn.Size = new System.Drawing.Size(400, 199);
            this.booksdbBtn.TabIndex = 2;
            this.booksdbBtn.Text = "Books Database";
            this.booksdbBtn.UseVisualStyleBackColor = true;
            this.booksdbBtn.Click += new System.EventHandler(this.booksdbBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(733, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log Out";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.booksdbBtn);
            this.Controls.Add(this.clientRegistryBtn);
            this.Controls.Add(this.rentedBooksBtn);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "menu";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rentedBooksBtn;
        private System.Windows.Forms.Button clientRegistryBtn;
        private System.Windows.Forms.Button booksdbBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}