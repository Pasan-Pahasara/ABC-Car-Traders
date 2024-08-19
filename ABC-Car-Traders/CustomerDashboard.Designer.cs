namespace ABC_Car_Traders
{
    partial class CustomerDashboard
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManageOrderDetails = new System.Windows.Forms.Button();
            this.btnOrderCarPart = new System.Windows.Forms.Button();
            this.btnOrderCar = new System.Windows.Forms.Button();
            this.customerContainer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnManageOrderDetails);
            this.panel1.Controls.Add(this.btnOrderCarPart);
            this.panel1.Controls.Add(this.btnOrderCar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 762);
            this.panel1.TabIndex = 1;
            // 
            // btnManageOrderDetails
            // 
            this.btnManageOrderDetails.Location = new System.Drawing.Point(27, 267);
            this.btnManageOrderDetails.Name = "btnManageOrderDetails";
            this.btnManageOrderDetails.Size = new System.Drawing.Size(184, 48);
            this.btnManageOrderDetails.TabIndex = 4;
            this.btnManageOrderDetails.Text = "Manage Order Details";
            this.btnManageOrderDetails.UseVisualStyleBackColor = true;
            // 
            // btnOrderCarPart
            // 
            this.btnOrderCarPart.Location = new System.Drawing.Point(27, 204);
            this.btnOrderCarPart.Name = "btnOrderCarPart";
            this.btnOrderCarPart.Size = new System.Drawing.Size(184, 48);
            this.btnOrderCarPart.TabIndex = 3;
            this.btnOrderCarPart.Text = "Order Car Parts";
            this.btnOrderCarPart.UseVisualStyleBackColor = true;
            // 
            // btnOrderCar
            // 
            this.btnOrderCar.Location = new System.Drawing.Point(27, 140);
            this.btnOrderCar.Name = "btnOrderCar";
            this.btnOrderCar.Size = new System.Drawing.Size(184, 48);
            this.btnOrderCar.TabIndex = 2;
            this.btnOrderCar.Text = "Order Cars";
            this.btnOrderCar.UseVisualStyleBackColor = true;
            // 
            // customerContainer
            // 
            this.customerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerContainer.Location = new System.Drawing.Point(237, 0);
            this.customerContainer.Name = "customerContainer";
            this.customerContainer.Size = new System.Drawing.Size(1041, 762);
            this.customerContainer.TabIndex = 2;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1278, 762);
            this.Controls.Add(this.customerContainer);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnManageOrderDetails;
        private System.Windows.Forms.Button btnOrderCarPart;
        private System.Windows.Forms.Button btnOrderCar;
        private System.Windows.Forms.Panel customerContainer;
    }
}