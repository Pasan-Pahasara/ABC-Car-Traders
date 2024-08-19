namespace ABC_Car_Traders
{
    partial class AdminDashboard
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
            this.btnManageCarPart = new System.Windows.Forms.Button();
            this.btnManageCar = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adminContainer = new System.Windows.Forms.Panel();
            this.btnManageOrderDetails = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnManageOrderDetails);
            this.panel1.Controls.Add(this.btnManageCarPart);
            this.panel1.Controls.Add(this.btnManageCar);
            this.panel1.Controls.Add(this.btnManageCustomer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 762);
            this.panel1.TabIndex = 0;
            // 
            // btnManageCarPart
            // 
            this.btnManageCarPart.Location = new System.Drawing.Point(27, 267);
            this.btnManageCarPart.Name = "btnManageCarPart";
            this.btnManageCarPart.Size = new System.Drawing.Size(184, 48);
            this.btnManageCarPart.TabIndex = 4;
            this.btnManageCarPart.Text = "Manage Car Parts";
            this.btnManageCarPart.UseVisualStyleBackColor = true;
            this.btnManageCarPart.Click += new System.EventHandler(this.btnManageCarPart_Click);
            // 
            // btnManageCar
            // 
            this.btnManageCar.Location = new System.Drawing.Point(27, 203);
            this.btnManageCar.Name = "btnManageCar";
            this.btnManageCar.Size = new System.Drawing.Size(184, 48);
            this.btnManageCar.TabIndex = 3;
            this.btnManageCar.Text = "Manage Cars";
            this.btnManageCar.UseVisualStyleBackColor = true;
            this.btnManageCar.Click += new System.EventHandler(this.btnManageCar_Click);
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(27, 140);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(184, 48);
            this.btnManageCustomer.TabIndex = 2;
            this.btnManageCustomer.Text = "Manage Customers";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABC Car Traders";
            // 
            // adminContainer
            // 
            this.adminContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminContainer.Location = new System.Drawing.Point(237, 0);
            this.adminContainer.Name = "adminContainer";
            this.adminContainer.Padding = new System.Windows.Forms.Padding(0, 25, 25, 25);
            this.adminContainer.Size = new System.Drawing.Size(1041, 762);
            this.adminContainer.TabIndex = 1;
            // 
            // btnManageOrderDetails
            // 
            this.btnManageOrderDetails.Location = new System.Drawing.Point(27, 331);
            this.btnManageOrderDetails.Name = "btnManageOrderDetails";
            this.btnManageOrderDetails.Size = new System.Drawing.Size(184, 48);
            this.btnManageOrderDetails.TabIndex = 5;
            this.btnManageOrderDetails.Text = "Manage Order Details";
            this.btnManageOrderDetails.UseVisualStyleBackColor = true;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1278, 762);
            this.Controls.Add(this.adminContainer);
            this.Controls.Add(this.panel1);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel adminContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageCustomer;
        private System.Windows.Forms.Button btnManageCar;
        private System.Windows.Forms.Button btnManageCarPart;
        private System.Windows.Forms.Button btnManageOrderDetails;
    }
}

