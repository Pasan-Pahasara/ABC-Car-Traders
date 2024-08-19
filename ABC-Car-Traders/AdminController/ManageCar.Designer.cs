namespace ABC_Car_Traders.AdminController
{
    partial class ManageCar
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
            this.btnCarAdd = new System.Windows.Forms.Button();
            this.dgvCar = new System.Windows.Forms.DataGridView();
            this.btnCarDelete = new System.Windows.Forms.Button();
            this.btnCarUpdate = new System.Windows.Forms.Button();
            this.btnCarSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCarPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarBrand = new System.Windows.Forms.TextBox();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.txtCarId = new System.Windows.Forms.TextBox();
            this.txtCarFuelType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin / Manage Car";
            // 
            // btnCarAdd
            // 
            this.btnCarAdd.Location = new System.Drawing.Point(585, 283);
            this.btnCarAdd.Name = "btnCarAdd";
            this.btnCarAdd.Size = new System.Drawing.Size(120, 46);
            this.btnCarAdd.TabIndex = 33;
            this.btnCarAdd.Text = "+ Add Car";
            this.btnCarAdd.UseVisualStyleBackColor = true;
            this.btnCarAdd.Click += new System.EventHandler(this.btnCarAdd_Click);
            // 
            // dgvCar
            // 
            this.dgvCar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCar.Location = new System.Drawing.Point(40, 358);
            this.dgvCar.Name = "dgvCar";
            this.dgvCar.RowHeadersWidth = 51;
            this.dgvCar.RowTemplate.Height = 24;
            this.dgvCar.Size = new System.Drawing.Size(938, 313);
            this.dgvCar.TabIndex = 32;
            this.dgvCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCar_CellClick);
            // 
            // btnCarDelete
            // 
            this.btnCarDelete.Location = new System.Drawing.Point(858, 283);
            this.btnCarDelete.Name = "btnCarDelete";
            this.btnCarDelete.Size = new System.Drawing.Size(120, 46);
            this.btnCarDelete.TabIndex = 31;
            this.btnCarDelete.Text = "Delete Car";
            this.btnCarDelete.UseVisualStyleBackColor = true;
            this.btnCarDelete.Click += new System.EventHandler(this.btnCarDelete_Click);
            // 
            // btnCarUpdate
            // 
            this.btnCarUpdate.Location = new System.Drawing.Point(723, 283);
            this.btnCarUpdate.Name = "btnCarUpdate";
            this.btnCarUpdate.Size = new System.Drawing.Size(120, 46);
            this.btnCarUpdate.TabIndex = 30;
            this.btnCarUpdate.Text = "Update Car";
            this.btnCarUpdate.UseVisualStyleBackColor = true;
            this.btnCarUpdate.Click += new System.EventHandler(this.btnCarUpdate_Click);
            // 
            // btnCarSearch
            // 
            this.btnCarSearch.Location = new System.Drawing.Point(902, 114);
            this.btnCarSearch.Name = "btnCarSearch";
            this.btnCarSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarSearch.TabIndex = 29;
            this.btnCarSearch.Text = "Search";
            this.btnCarSearch.UseVisualStyleBackColor = true;
            this.btnCarSearch.Click += new System.EventHandler(this.btnCarSearch_Click);
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
            // txtCarPrice
            // 
            this.txtCarPrice.Location = new System.Drawing.Point(607, 234);
            this.txtCarPrice.Name = "txtCarPrice";
            this.txtCarPrice.Size = new System.Drawing.Size(371, 22);
            this.txtCarPrice.TabIndex = 27;
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
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Car ID";
            // 
            // txtCarBrand
            // 
            this.txtCarBrand.Location = new System.Drawing.Point(607, 183);
            this.txtCarBrand.Name = "txtCarBrand";
            this.txtCarBrand.Size = new System.Drawing.Size(371, 22);
            this.txtCarBrand.TabIndex = 21;
            // 
            // txtCarModel
            // 
            this.txtCarModel.Location = new System.Drawing.Point(111, 183);
            this.txtCarModel.Name = "txtCarModel";
            this.txtCarModel.Size = new System.Drawing.Size(371, 22);
            this.txtCarModel.TabIndex = 20;
            // 
            // txtCarId
            // 
            this.txtCarId.Location = new System.Drawing.Point(685, 116);
            this.txtCarId.Name = "txtCarId";
            this.txtCarId.Size = new System.Drawing.Size(211, 22);
            this.txtCarId.TabIndex = 19;
            // 
            // txtCarFuelType
            // 
            this.txtCarFuelType.Location = new System.Drawing.Point(111, 234);
            this.txtCarFuelType.Name = "txtCarFuelType";
            this.txtCarFuelType.Size = new System.Drawing.Size(371, 22);
            this.txtCarFuelType.TabIndex = 18;
            // 
            // ManageCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnCarAdd);
            this.Controls.Add(this.dgvCar);
            this.Controls.Add(this.btnCarDelete);
            this.Controls.Add(this.btnCarUpdate);
            this.Controls.Add(this.btnCarSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCarPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarBrand);
            this.Controls.Add(this.txtCarModel);
            this.Controls.Add(this.txtCarId);
            this.Controls.Add(this.txtCarFuelType);
            this.Controls.Add(this.label1);
            this.Name = "ManageCar";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.ManageCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCarAdd;
        private System.Windows.Forms.DataGridView dgvCar;
        private System.Windows.Forms.Button btnCarDelete;
        private System.Windows.Forms.Button btnCarUpdate;
        private System.Windows.Forms.Button btnCarSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCarPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarBrand;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.TextBox txtCarId;
        private System.Windows.Forms.TextBox txtCarFuelType;
    }
}
