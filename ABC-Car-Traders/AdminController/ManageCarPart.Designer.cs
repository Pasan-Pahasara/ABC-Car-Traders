namespace ABC_Car_Traders.AdminController
{
    partial class ManageCarPartPart
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
            this.btnCarPartAdd = new System.Windows.Forms.Button();
            this.dgvCarPart = new System.Windows.Forms.DataGridView();
            this.btnCarPartDelete = new System.Windows.Forms.Button();
            this.btnCarPartUpdate = new System.Windows.Forms.Button();
            this.btnCarPartSearch = new System.Windows.Forms.Button();
            this.btnGenerateCarPartReport = new System.Windows.Forms.Button();
            this.txtCarPartQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarPartDescription = new System.Windows.Forms.TextBox();
            this.txtCarPartName = new System.Windows.Forms.TextBox();
            this.txtCarPartId = new System.Windows.Forms.TextBox();
            this.txtCarPartType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCarPartPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCarPartAdd
            // 
            this.btnCarPartAdd.Location = new System.Drawing.Point(573, 283);
            this.btnCarPartAdd.Name = "btnCarPartAdd";
            this.btnCarPartAdd.Size = new System.Drawing.Size(120, 46);
            this.btnCarPartAdd.TabIndex = 50;
            this.btnCarPartAdd.Text = "+ Add Car Part";
            this.btnCarPartAdd.UseVisualStyleBackColor = true;
            this.btnCarPartAdd.Click += new System.EventHandler(this.btnCarPartAdd_Click);
            // 
            // dgvCarPart
            // 
            this.dgvCarPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPart.Location = new System.Drawing.Point(40, 358);
            this.dgvCarPart.Name = "dgvCarPart";
            this.dgvCarPart.RowHeadersWidth = 51;
            this.dgvCarPart.RowTemplate.Height = 24;
            this.dgvCarPart.Size = new System.Drawing.Size(938, 313);
            this.dgvCarPart.TabIndex = 49;
            this.dgvCarPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarPart_CellClick);
            // 
            // btnCarPartDelete
            // 
            this.btnCarPartDelete.Location = new System.Drawing.Point(858, 283);
            this.btnCarPartDelete.Name = "btnCarPartDelete";
            this.btnCarPartDelete.Size = new System.Drawing.Size(120, 46);
            this.btnCarPartDelete.TabIndex = 48;
            this.btnCarPartDelete.Text = "Delete Car Part";
            this.btnCarPartDelete.UseVisualStyleBackColor = true;
            this.btnCarPartDelete.Click += new System.EventHandler(this.btnCarPartDelete_Click);
            // 
            // btnCarPartUpdate
            // 
            this.btnCarPartUpdate.Location = new System.Drawing.Point(711, 283);
            this.btnCarPartUpdate.Name = "btnCarPartUpdate";
            this.btnCarPartUpdate.Size = new System.Drawing.Size(132, 46);
            this.btnCarPartUpdate.TabIndex = 47;
            this.btnCarPartUpdate.Text = "Update Car Part";
            this.btnCarPartUpdate.UseVisualStyleBackColor = true;
            this.btnCarPartUpdate.Click += new System.EventHandler(this.btnCarPartUpdate_Click);
            // 
            // btnCarPartSearch
            // 
            this.btnCarPartSearch.Location = new System.Drawing.Point(902, 114);
            this.btnCarPartSearch.Name = "btnCarPartSearch";
            this.btnCarPartSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarPartSearch.TabIndex = 46;
            this.btnCarPartSearch.Text = "Search";
            this.btnCarPartSearch.UseVisualStyleBackColor = true;
            this.btnCarPartSearch.Click += new System.EventHandler(this.btnCarPartSearch_Click);
            // 
            // btnGenerateCarPartReport
            // 
            this.btnGenerateCarPartReport.Location = new System.Drawing.Point(829, 28);
            this.btnGenerateCarPartReport.Name = "btnGenerateCarPartReport";
            this.btnGenerateCarPartReport.Size = new System.Drawing.Size(162, 46);
            this.btnGenerateCarPartReport.TabIndex = 45;
            this.btnGenerateCarPartReport.Text = "Generate Report";
            this.btnGenerateCarPartReport.UseVisualStyleBackColor = true;
            this.btnGenerateCarPartReport.Click += new System.EventHandler(this.btnGenerateCarPartReport_Click);
            // 
            // txtCarPartQty
            // 
            this.txtCarPartQty.Location = new System.Drawing.Point(634, 234);
            this.txtCarPartQty.Name = "txtCarPartQty";
            this.txtCarPartQty.Size = new System.Drawing.Size(344, 22);
            this.txtCarPartQty.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(525, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Available Qty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(570, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Car Part ID";
            // 
            // txtCarPartDescription
            // 
            this.txtCarPartDescription.Location = new System.Drawing.Point(634, 183);
            this.txtCarPartDescription.Name = "txtCarPartDescription";
            this.txtCarPartDescription.Size = new System.Drawing.Size(344, 22);
            this.txtCarPartDescription.TabIndex = 38;
            // 
            // txtCarPartName
            // 
            this.txtCarPartName.Location = new System.Drawing.Point(111, 183);
            this.txtCarPartName.Name = "txtCarPartName";
            this.txtCarPartName.Size = new System.Drawing.Size(371, 22);
            this.txtCarPartName.TabIndex = 37;
            // 
            // txtCarPartId
            // 
            this.txtCarPartId.Location = new System.Drawing.Point(685, 116);
            this.txtCarPartId.Name = "txtCarPartId";
            this.txtCarPartId.Size = new System.Drawing.Size(211, 22);
            this.txtCarPartId.TabIndex = 36;
            // 
            // txtCarPartType
            // 
            this.txtCarPartType.Location = new System.Drawing.Point(111, 234);
            this.txtCarPartType.Name = "txtCarPartType";
            this.txtCarPartType.Size = new System.Drawing.Size(371, 22);
            this.txtCarPartType.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Admin / Manage Car Part";
            // 
            // txtCarPartPrice
            // 
            this.txtCarPartPrice.Location = new System.Drawing.Point(111, 291);
            this.txtCarPartPrice.Name = "txtCarPartPrice";
            this.txtCarPartPrice.Size = new System.Drawing.Size(371, 22);
            this.txtCarPartPrice.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Price";
            // 
            // ManageCarPartPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtCarPartPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCarPartAdd);
            this.Controls.Add(this.dgvCarPart);
            this.Controls.Add(this.btnCarPartDelete);
            this.Controls.Add(this.btnCarPartUpdate);
            this.Controls.Add(this.btnCarPartSearch);
            this.Controls.Add(this.btnGenerateCarPartReport);
            this.Controls.Add(this.txtCarPartQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarPartDescription);
            this.Controls.Add(this.txtCarPartName);
            this.Controls.Add(this.txtCarPartId);
            this.Controls.Add(this.txtCarPartType);
            this.Controls.Add(this.label1);
            this.Name = "ManageCarPartPart";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.ManageCarPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarPartAdd;
        private System.Windows.Forms.DataGridView dgvCarPart;
        private System.Windows.Forms.Button btnCarPartDelete;
        private System.Windows.Forms.Button btnCarPartUpdate;
        private System.Windows.Forms.Button btnCarPartSearch;
        private System.Windows.Forms.Button btnGenerateCarPartReport;
        private System.Windows.Forms.TextBox txtCarPartQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarPartDescription;
        private System.Windows.Forms.TextBox txtCarPartName;
        private System.Windows.Forms.TextBox txtCarPartId;
        private System.Windows.Forms.TextBox txtCarPartType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarPartPrice;
        private System.Windows.Forms.Label label7;
    }
}
