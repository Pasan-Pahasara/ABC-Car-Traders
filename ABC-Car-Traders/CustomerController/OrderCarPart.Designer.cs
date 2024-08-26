namespace ABC_Car_Traders.CustomerController
{
    partial class OrderCarPart
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
            this.dgvCarPart = new System.Windows.Forms.DataGridView();
            this.btnCarPartSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarPartSearchId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCarPartQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarPartDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCarPartPrice = new System.Windows.Forms.TextBox();
            this.txtCarPartName = new System.Windows.Forms.TextBox();
            this.txtCarPartType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCarPartId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.btnCarPartOrder = new System.Windows.Forms.Button();
            this.dgvCarPartOrder = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCarPart
            // 
            this.dgvCarPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPart.Location = new System.Drawing.Point(40, 98);
            this.dgvCarPart.Name = "dgvCarPart";
            this.dgvCarPart.RowHeadersWidth = 51;
            this.dgvCarPart.RowTemplate.Height = 24;
            this.dgvCarPart.Size = new System.Drawing.Size(938, 159);
            this.dgvCarPart.TabIndex = 54;
            this.dgvCarPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarPart_CellClick);
            // 
            // btnCarPartSearch
            // 
            this.btnCarPartSearch.Location = new System.Drawing.Point(902, 54);
            this.btnCarPartSearch.Name = "btnCarPartSearch";
            this.btnCarPartSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarPartSearch.TabIndex = 53;
            this.btnCarPartSearch.Text = "Search";
            this.btnCarPartSearch.UseVisualStyleBackColor = true;
            this.btnCarPartSearch.Click += new System.EventHandler(this.btnCarPartSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Car Part ID";
            // 
            // txtCarPartSearchId
            // 
            this.txtCarPartSearchId.Location = new System.Drawing.Point(685, 56);
            this.txtCarPartSearchId.Name = "txtCarPartSearchId";
            this.txtCarPartSearchId.Size = new System.Drawing.Size(211, 22);
            this.txtCarPartSearchId.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 23);
            this.label1.TabIndex = 50;
            this.label1.Text = "Customer / Order Car Part";
            // 
            // txtCarPartQty
            // 
            this.txtCarPartQty.Location = new System.Drawing.Point(421, 400);
            this.txtCarPartQty.Name = "txtCarPartQty";
            this.txtCarPartQty.Size = new System.Drawing.Size(222, 22);
            this.txtCarPartQty.TabIndex = 84;
            this.txtCarPartQty.TextChanged += new System.EventHandler(this.txtCarPartQty_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(309, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 20);
            this.label7.TabIndex = 83;
            this.label7.Text = "Qty";
            // 
            // txtCarPartDescription
            // 
            this.txtCarPartDescription.Location = new System.Drawing.Point(421, 351);
            this.txtCarPartDescription.Name = "txtCarPartDescription";
            this.txtCarPartDescription.ReadOnly = true;
            this.txtCarPartDescription.Size = new System.Drawing.Size(227, 22);
            this.txtCarPartDescription.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(309, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 80;
            this.label9.Text = "Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 79;
            this.label10.Text = "Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 78;
            this.label11.Text = "Name";
            // 
            // txtCarPartPrice
            // 
            this.txtCarPartPrice.Location = new System.Drawing.Point(121, 449);
            this.txtCarPartPrice.Name = "txtCarPartPrice";
            this.txtCarPartPrice.ReadOnly = true;
            this.txtCarPartPrice.Size = new System.Drawing.Size(158, 22);
            this.txtCarPartPrice.TabIndex = 77;
            this.txtCarPartPrice.TextChanged += new System.EventHandler(this.txtCarPartPrice_TextChanged);
            // 
            // txtCarPartName
            // 
            this.txtCarPartName.Location = new System.Drawing.Point(121, 349);
            this.txtCarPartName.Name = "txtCarPartName";
            this.txtCarPartName.ReadOnly = true;
            this.txtCarPartName.Size = new System.Drawing.Size(158, 22);
            this.txtCarPartName.TabIndex = 76;
            // 
            // txtCarPartType
            // 
            this.txtCarPartType.Location = new System.Drawing.Point(121, 400);
            this.txtCarPartType.Name = "txtCarPartType";
            this.txtCarPartType.ReadOnly = true;
            this.txtCarPartType.Size = new System.Drawing.Size(158, 22);
            this.txtCarPartType.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(403, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 74;
            this.label6.Text = "Car Part ID";
            // 
            // txtCarPartId
            // 
            this.txtCarPartId.Location = new System.Drawing.Point(508, 298);
            this.txtCarPartId.Name = "txtCarPartId";
            this.txtCarPartId.ReadOnly = true;
            this.txtCarPartId.Size = new System.Drawing.Size(204, 22);
            this.txtCarPartId.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 72;
            this.label5.Text = "Customer ID";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(163, 298);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(197, 22);
            this.txtCustomerId.TabIndex = 71;
            // 
            // btnCarPartOrder
            // 
            this.btnCarPartOrder.Location = new System.Drawing.Point(847, 464);
            this.btnCarPartOrder.Name = "btnCarPartOrder";
            this.btnCarPartOrder.Size = new System.Drawing.Size(131, 46);
            this.btnCarPartOrder.TabIndex = 70;
            this.btnCarPartOrder.Text = "+ Order Car Part";
            this.btnCarPartOrder.UseVisualStyleBackColor = true;
            this.btnCarPartOrder.Click += new System.EventHandler(this.btnCarPartOrder_Click);
            // 
            // dgvCarPartOrder
            // 
            this.dgvCarPartOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarPartOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPartOrder.Location = new System.Drawing.Point(40, 520);
            this.dgvCarPartOrder.Name = "dgvCarPartOrder";
            this.dgvCarPartOrder.RowHeadersWidth = 51;
            this.dgvCarPartOrder.RowTemplate.Height = 24;
            this.dgvCarPartOrder.Size = new System.Drawing.Size(938, 159);
            this.dgvCarPartOrder.TabIndex = 67;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(668, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 118);
            this.panel1.TabIndex = 85;
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
            // OrderCarPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCarPartQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCarPartDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCarPartPrice);
            this.Controls.Add(this.txtCarPartName);
            this.Controls.Add(this.txtCarPartType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCarPartId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnCarPartOrder);
            this.Controls.Add(this.dgvCarPartOrder);
            this.Controls.Add(this.dgvCarPart);
            this.Controls.Add(this.btnCarPartSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarPartSearchId);
            this.Controls.Add(this.label1);
            this.Name = "OrderCarPart";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.OrderCarPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarPart;
        private System.Windows.Forms.Button btnCarPartSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarPartSearchId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCarPartQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCarPartDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCarPartPrice;
        private System.Windows.Forms.TextBox txtCarPartName;
        private System.Windows.Forms.TextBox txtCarPartType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCarPartId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Button btnCarPartOrder;
        private System.Windows.Forms.DataGridView dgvCarPartOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label13;
    }
}
