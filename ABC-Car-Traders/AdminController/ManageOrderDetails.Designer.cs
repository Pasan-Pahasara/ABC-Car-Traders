namespace ABC_Car_Traders.AdminController
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
            this.dgvCarOrderDetail = new System.Windows.Forms.DataGridView();
            this.btnCarOrderSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarStatus = new System.Windows.Forms.TextBox();
            this.txtCarOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCarPartOrderDetail = new System.Windows.Forms.DataGridView();
            this.btnCarOrderPartSearch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarPartStatus = new System.Windows.Forms.TextBox();
            this.txtCarPartOrderId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCarOrderDetail
            // 
            this.dgvCarOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarOrderDetail.Location = new System.Drawing.Point(40, 132);
            this.dgvCarOrderDetail.Name = "dgvCarOrderDetail";
            this.dgvCarOrderDetail.RowHeadersWidth = 51;
            this.dgvCarOrderDetail.RowTemplate.Height = 24;
            this.dgvCarOrderDetail.Size = new System.Drawing.Size(938, 190);
            this.dgvCarOrderDetail.TabIndex = 57;
            this.dgvCarOrderDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarOrderDetail_CellClick);
            // 
            // btnCarOrderSearch
            // 
            this.btnCarOrderSearch.Location = new System.Drawing.Point(902, 88);
            this.btnCarOrderSearch.Name = "btnCarOrderSearch";
            this.btnCarOrderSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarOrderSearch.TabIndex = 56;
            this.btnCarOrderSearch.Text = "Search";
            this.btnCarOrderSearch.UseVisualStyleBackColor = true;
            this.btnCarOrderSearch.Click += new System.EventHandler(this.btnCarSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(829, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 46);
            this.button1.TabIndex = 55;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(573, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Car Order ID";
            // 
            // txtCarStatus
            // 
            this.txtCarStatus.Location = new System.Drawing.Point(111, 90);
            this.txtCarStatus.Name = "txtCarStatus";
            this.txtCarStatus.Size = new System.Drawing.Size(371, 22);
            this.txtCarStatus.TabIndex = 52;
            // 
            // txtCarOrderId
            // 
            this.txtCarOrderId.Location = new System.Drawing.Point(685, 90);
            this.txtCarOrderId.Name = "txtCarOrderId";
            this.txtCarOrderId.Size = new System.Drawing.Size(211, 22);
            this.txtCarOrderId.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 23);
            this.label1.TabIndex = 50;
            this.label1.Text = "Admin / Manage Car Order Details";
            // 
            // dgvCarPartOrderDetail
            // 
            this.dgvCarPartOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPartOrderDetail.Location = new System.Drawing.Point(40, 482);
            this.dgvCarPartOrderDetail.Name = "dgvCarPartOrderDetail";
            this.dgvCarPartOrderDetail.RowHeadersWidth = 51;
            this.dgvCarPartOrderDetail.RowTemplate.Height = 24;
            this.dgvCarPartOrderDetail.Size = new System.Drawing.Size(938, 190);
            this.dgvCarPartOrderDetail.TabIndex = 65;
            this.dgvCarPartOrderDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarPartOrderDetail_CellClick);
            // 
            // btnCarOrderPartSearch
            // 
            this.btnCarOrderPartSearch.Location = new System.Drawing.Point(902, 439);
            this.btnCarOrderPartSearch.Name = "btnCarOrderPartSearch";
            this.btnCarOrderPartSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarOrderPartSearch.TabIndex = 64;
            this.btnCarOrderPartSearch.Text = "Search";
            this.btnCarOrderPartSearch.UseVisualStyleBackColor = true;
            this.btnCarOrderPartSearch.Click += new System.EventHandler(this.btnCarOrderPartSearch_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(829, 379);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 46);
            this.button3.TabIndex = 63;
            this.button3.Text = "Generate Report";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(544, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Car Order Part ID";
            // 
            // txtCarPartStatus
            // 
            this.txtCarPartStatus.Location = new System.Drawing.Point(111, 440);
            this.txtCarPartStatus.Name = "txtCarPartStatus";
            this.txtCarPartStatus.Size = new System.Drawing.Size(371, 22);
            this.txtCarPartStatus.TabIndex = 60;
            // 
            // txtCarPartOrderId
            // 
            this.txtCarPartOrderId.Location = new System.Drawing.Point(685, 441);
            this.txtCarPartOrderId.Name = "txtCarPartOrderId";
            this.txtCarPartOrderId.Size = new System.Drawing.Size(211, 22);
            this.txtCarPartOrderId.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(36, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(392, 23);
            this.label6.TabIndex = 58;
            this.label6.Text = "Admin / Manage Car Part Order Details";
            // 
            // ManageOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCarPartOrderDetail);
            this.Controls.Add(this.btnCarOrderPartSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCarPartStatus);
            this.Controls.Add(this.txtCarPartOrderId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvCarOrderDetail);
            this.Controls.Add(this.btnCarOrderSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarStatus);
            this.Controls.Add(this.txtCarOrderId);
            this.Controls.Add(this.label1);
            this.Name = "ManageOrderDetails";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.ManageOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarOrderDetail;
        private System.Windows.Forms.Button btnCarOrderSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarStatus;
        private System.Windows.Forms.TextBox txtCarOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCarPartOrderDetail;
        private System.Windows.Forms.Button btnCarOrderPartSearch;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCarPartStatus;
        private System.Windows.Forms.TextBox txtCarPartOrderId;
        private System.Windows.Forms.Label label6;
    }
}
