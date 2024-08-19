namespace ABC_Car_Traders.AdminController
{
    partial class ManageVehicle
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVehicleAdd = new System.Windows.Forms.Button();
            this.dgvVehicle = new System.Windows.Forms.DataGridView();
            this.btnVehicleDelete = new System.Windows.Forms.Button();
            this.btnVehicleUpdate = new System.Windows.Forms.Button();
            this.btnVehicleSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtVehiclePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVehicleBrand = new System.Windows.Forms.TextBox();
            this.txtVehicleModel = new System.Windows.Forms.TextBox();
            this.txtVehicleId = new System.Windows.Forms.TextBox();
            this.txtVehicleFuelType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin / Manage Vehicle";
            // 
            // btnVehicleAdd
            // 
            this.btnVehicleAdd.Location = new System.Drawing.Point(585, 283);
            this.btnVehicleAdd.Name = "btnVehicleAdd";
            this.btnVehicleAdd.Size = new System.Drawing.Size(120, 46);
            this.btnVehicleAdd.TabIndex = 33;
            this.btnVehicleAdd.Text = "+ Add Vehicle";
            this.btnVehicleAdd.UseVisualStyleBackColor = true;
            this.btnVehicleAdd.Click += new System.EventHandler(this.btnVehicleAdd_Click);
            // 
            // dgvVehicle
            // 
            this.dgvVehicle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicle.Location = new System.Drawing.Point(40, 358);
            this.dgvVehicle.Name = "dgvVehicle";
            this.dgvVehicle.RowHeadersWidth = 51;
            this.dgvVehicle.RowTemplate.Height = 24;
            this.dgvVehicle.Size = new System.Drawing.Size(938, 313);
            this.dgvVehicle.TabIndex = 32;
            this.dgvVehicle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicle_CellClick);
            // 
            // btnVehicleDelete
            // 
            this.btnVehicleDelete.Location = new System.Drawing.Point(858, 283);
            this.btnVehicleDelete.Name = "btnVehicleDelete";
            this.btnVehicleDelete.Size = new System.Drawing.Size(120, 46);
            this.btnVehicleDelete.TabIndex = 31;
            this.btnVehicleDelete.Text = "Delete Vehicle";
            this.btnVehicleDelete.UseVisualStyleBackColor = true;
            this.btnVehicleDelete.Click += new System.EventHandler(this.btnVehicleDelete_Click);
            // 
            // btnVehicleUpdate
            // 
            this.btnVehicleUpdate.Location = new System.Drawing.Point(723, 283);
            this.btnVehicleUpdate.Name = "btnVehicleUpdate";
            this.btnVehicleUpdate.Size = new System.Drawing.Size(120, 46);
            this.btnVehicleUpdate.TabIndex = 30;
            this.btnVehicleUpdate.Text = "Update Vehicle";
            this.btnVehicleUpdate.UseVisualStyleBackColor = true;
            this.btnVehicleUpdate.Click += new System.EventHandler(this.btnVehicleUpdate_Click);
            // 
            // btnVehicleSearch
            // 
            this.btnVehicleSearch.Location = new System.Drawing.Point(902, 114);
            this.btnVehicleSearch.Name = "btnVehicleSearch";
            this.btnVehicleSearch.Size = new System.Drawing.Size(75, 27);
            this.btnVehicleSearch.TabIndex = 29;
            this.btnVehicleSearch.Text = "Search";
            this.btnVehicleSearch.UseVisualStyleBackColor = true;
            this.btnVehicleSearch.Click += new System.EventHandler(this.btnVehicleSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(829, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 46);
            this.button1.TabIndex = 28;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtVehiclePrice
            // 
            this.txtVehiclePrice.Location = new System.Drawing.Point(607, 234);
            this.txtVehiclePrice.Name = "txtVehiclePrice";
            this.txtVehiclePrice.Size = new System.Drawing.Size(371, 22);
            this.txtVehiclePrice.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(525, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fuel Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(570, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Vehicle ID";
            // 
            // txtVehicleBrand
            // 
            this.txtVehicleBrand.Location = new System.Drawing.Point(607, 183);
            this.txtVehicleBrand.Name = "txtVehicleBrand";
            this.txtVehicleBrand.Size = new System.Drawing.Size(371, 22);
            this.txtVehicleBrand.TabIndex = 21;
            // 
            // txtVehicleModel
            // 
            this.txtVehicleModel.Location = new System.Drawing.Point(111, 183);
            this.txtVehicleModel.Name = "txtVehicleModel";
            this.txtVehicleModel.Size = new System.Drawing.Size(371, 22);
            this.txtVehicleModel.TabIndex = 20;
            // 
            // txtVehicleId
            // 
            this.txtVehicleId.Location = new System.Drawing.Point(685, 116);
            this.txtVehicleId.Name = "txtVehicleId";
            this.txtVehicleId.Size = new System.Drawing.Size(211, 22);
            this.txtVehicleId.TabIndex = 19;
            // 
            // txtVehicleFuelType
            // 
            this.txtVehicleFuelType.Location = new System.Drawing.Point(111, 234);
            this.txtVehicleFuelType.Name = "txtVehicleFuelType";
            this.txtVehicleFuelType.Size = new System.Drawing.Size(371, 22);
            this.txtVehicleFuelType.TabIndex = 18;
            // 
            // ManageVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnVehicleAdd);
            this.Controls.Add(this.dgvVehicle);
            this.Controls.Add(this.btnVehicleDelete);
            this.Controls.Add(this.btnVehicleUpdate);
            this.Controls.Add(this.btnVehicleSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtVehiclePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicleBrand);
            this.Controls.Add(this.txtVehicleModel);
            this.Controls.Add(this.txtVehicleId);
            this.Controls.Add(this.txtVehicleFuelType);
            this.Controls.Add(this.label1);
            this.Name = "ManageVehicle";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.ManageVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVehicleAdd;
        private System.Windows.Forms.DataGridView dgvVehicle;
        private System.Windows.Forms.Button btnVehicleDelete;
        private System.Windows.Forms.Button btnVehicleUpdate;
        private System.Windows.Forms.Button btnVehicleSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtVehiclePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVehicleBrand;
        private System.Windows.Forms.TextBox txtVehicleModel;
        private System.Windows.Forms.TextBox txtVehicleId;
        private System.Windows.Forms.TextBox txtVehicleFuelType;
    }
}
