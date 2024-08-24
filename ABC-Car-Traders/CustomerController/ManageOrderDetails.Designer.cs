namespace ABC_Car_Traders.CustomerController
{
    partial class ManageOrderDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomerCarPartOrderDetail = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCustomerCarOrderDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCarPartOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCarOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomerCarPartOrderDetail
            // 
            this.dgvCustomerCarPartOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerCarPartOrderDetail.Location = new System.Drawing.Point(40, 443);
            this.dgvCustomerCarPartOrderDetail.Name = "dgvCustomerCarPartOrderDetail";
            this.dgvCustomerCarPartOrderDetail.RowHeadersWidth = 51;
            this.dgvCustomerCarPartOrderDetail.RowTemplate.Height = 24;
            this.dgvCustomerCarPartOrderDetail.Size = new System.Drawing.Size(938, 234);
            this.dgvCustomerCarPartOrderDetail.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(36, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(422, 23);
            this.label6.TabIndex = 74;
            this.label6.Text = "Customer / Manage Car Part Order Details";
            // 
            // dgvCustomerCarOrderDetail
            // 
            this.dgvCustomerCarOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerCarOrderDetail.Location = new System.Drawing.Point(40, 88);
            this.dgvCustomerCarOrderDetail.Name = "dgvCustomerCarOrderDetail";
            this.dgvCustomerCarOrderDetail.RowHeadersWidth = 51;
            this.dgvCustomerCarOrderDetail.RowTemplate.Height = 24;
            this.dgvCustomerCarOrderDetail.Size = new System.Drawing.Size(938, 234);
            this.dgvCustomerCarOrderDetail.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 23);
            this.label1.TabIndex = 66;
            this.label1.Text = "Customer / Manage Car Order Details";
            // 
            // ManageOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCustomerCarPartOrderDetail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvCustomerCarOrderDetail);
            this.Controls.Add(this.label1);
            this.Name = "ManageOrderDetails";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.ManageOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCarPartOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCarOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomerCarPartOrderDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvCustomerCarOrderDetail;
        private System.Windows.Forms.Label label1;
    }
}
