using System.Drawing;

namespace ABC_Car_Traders.CustomerController
{
    partial class OrderCar
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
            this.dgvCar = new System.Windows.Forms.DataGridView();
            this.btnCarSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarSearchId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCarOrder = new System.Windows.Forms.DataGridView();
            this.btnCarOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCarId = new System.Windows.Forms.TextBox();
            this.txtCarQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCarBrand = new System.Windows.Forms.TextBox();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.txtCarFuelType = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCar
            // 
            this.dgvCar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCar.Location = new System.Drawing.Point(40, 98);
            this.dgvCar.Name = "dgvCar";
            this.dgvCar.RowHeadersWidth = 51;
            this.dgvCar.RowTemplate.Height = 24;
            this.dgvCar.Size = new System.Drawing.Size(938, 159);
            this.dgvCar.TabIndex = 37;
            this.dgvCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCar_CellClick);
            // 
            // btnCarSearch
            // 
            this.btnCarSearch.Location = new System.Drawing.Point(902, 54);
            this.btnCarSearch.Name = "btnCarSearch";
            this.btnCarSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarSearch.TabIndex = 36;
            this.btnCarSearch.Text = "Search";
            this.btnCarSearch.UseVisualStyleBackColor = true;
            this.btnCarSearch.Click += new System.EventHandler(this.btnCarSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Car ID";
            // 
            // txtCarSearchId
            // 
            this.txtCarSearchId.Location = new System.Drawing.Point(685, 56);
            this.txtCarSearchId.Name = "txtCarSearchId";
            this.txtCarSearchId.Size = new System.Drawing.Size(211, 22);
            this.txtCarSearchId.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Customer / Order Car";
            // 
            // dgvCarOrder
            // 
            this.dgvCarOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarOrder.Location = new System.Drawing.Point(40, 520);
            this.dgvCarOrder.Name = "dgvCarOrder";
            this.dgvCarOrder.RowHeadersWidth = 51;
            this.dgvCarOrder.RowTemplate.Height = 24;
            this.dgvCarOrder.Size = new System.Drawing.Size(938, 159);
            this.dgvCarOrder.TabIndex = 40;
            // 
            // btnCarOrder
            // 
            this.btnCarOrder.Location = new System.Drawing.Point(861, 463);
            this.btnCarOrder.Name = "btnCarOrder";
            this.btnCarOrder.Size = new System.Drawing.Size(117, 46);
            this.btnCarOrder.TabIndex = 51;
            this.btnCarOrder.Text = "+ Order Car";
            this.btnCarOrder.UseVisualStyleBackColor = true;
            this.btnCarOrder.Click += new System.EventHandler(this.btnCarOrder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "Customer ID";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(158, 298);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(187, 22);
            this.txtCustomerId.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(383, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Car ID";
            // 
            // txtCarId
            // 
            this.txtCarId.Location = new System.Drawing.Point(458, 298);
            this.txtCarId.Name = "txtCarId";
            this.txtCarId.ReadOnly = true;
            this.txtCarId.Size = new System.Drawing.Size(196, 22);
            this.txtCarId.TabIndex = 54;
            // 
            // txtCarQty
            // 
            this.txtCarQty.Location = new System.Drawing.Point(409, 400);
            this.txtCarQty.Name = "txtCarQty";
            this.txtCarQty.Size = new System.Drawing.Size(184, 22);
            this.txtCarQty.TabIndex = 65;
            this.txtCarQty.TextChanged += new System.EventHandler(this.txtCarQty_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 20);
            this.label7.TabIndex = 64;
            this.label7.Text = "Qty";
            // 
            // txtCarPrice
            // 
            this.txtCarPrice.Location = new System.Drawing.Point(409, 351);
            this.txtCarPrice.Name = "txtCarPrice";
            this.txtCarPrice.ReadOnly = true;
            this.txtCarPrice.Size = new System.Drawing.Size(184, 22);
            this.txtCarPrice.TabIndex = 63;
            this.txtCarPrice.TextChanged += new System.EventHandler(this.txtCarPrice_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 62;
            this.label8.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 61;
            this.label9.Text = "Fuel Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 60;
            this.label10.Text = "Brand";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 20);
            this.label11.TabIndex = 59;
            this.label11.Text = "Model";
            // 
            // txtCarBrand
            // 
            this.txtCarBrand.Location = new System.Drawing.Point(121, 449);
            this.txtCarBrand.Name = "txtCarBrand";
            this.txtCarBrand.ReadOnly = true;
            this.txtCarBrand.Size = new System.Drawing.Size(172, 22);
            this.txtCarBrand.TabIndex = 58;
            // 
            // txtCarModel
            // 
            this.txtCarModel.Location = new System.Drawing.Point(121, 349);
            this.txtCarModel.Name = "txtCarModel";
            this.txtCarModel.ReadOnly = true;
            this.txtCarModel.Size = new System.Drawing.Size(172, 22);
            this.txtCarModel.TabIndex = 57;
            // 
            // txtCarFuelType
            // 
            this.txtCarFuelType.Location = new System.Drawing.Point(121, 400);
            this.txtCarFuelType.Name = "txtCarFuelType";
            this.txtCarFuelType.ReadOnly = true;
            this.txtCarFuelType.Size = new System.Drawing.Size(172, 22);
            this.txtCarFuelType.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(623, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 118);
            this.panel1.TabIndex = 66;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Brown;
            this.label14.Location = new System.Drawing.Point(5, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 44);
            this.label14.TabIndex = 3;
            this.label14.Text = "Rs :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Brown;
            this.lblTotal.Location = new System.Drawing.Point(79, 58);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(92, 44);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 28F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 56);
            this.label13.TabIndex = 1;
            this.label13.Text = "Total";
            // 
            // OrderCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCarQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCarPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCarBrand);
            this.Controls.Add(this.txtCarModel);
            this.Controls.Add(this.txtCarFuelType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCarId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnCarOrder);
            this.Controls.Add(this.dgvCarOrder);
            this.Controls.Add(this.dgvCar);
            this.Controls.Add(this.btnCarSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarSearchId);
            this.Controls.Add(this.label1);
            this.Name = "OrderCar";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.OrderCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCar;
        private System.Windows.Forms.Button btnCarSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarSearchId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCarOrder;
        private System.Windows.Forms.Button btnCarOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCarId;
        private System.Windows.Forms.TextBox txtCarQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCarPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCarBrand;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.TextBox txtCarFuelType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label13;
    }
}
