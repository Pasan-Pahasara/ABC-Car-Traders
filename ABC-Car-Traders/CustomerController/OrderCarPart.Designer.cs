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
            this.txtCarPartId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).BeginInit();
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
            this.dgvCarPart.Size = new System.Drawing.Size(938, 144);
            this.dgvCarPart.TabIndex = 54;
            // 
            // btnCarPartSearch
            // 
            this.btnCarPartSearch.Location = new System.Drawing.Point(902, 54);
            this.btnCarPartSearch.Name = "btnCarPartSearch";
            this.btnCarPartSearch.Size = new System.Drawing.Size(75, 27);
            this.btnCarPartSearch.TabIndex = 53;
            this.btnCarPartSearch.Text = "Search";
            this.btnCarPartSearch.UseVisualStyleBackColor = true;
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
            // txtCarPartId
            // 
            this.txtCarPartId.Location = new System.Drawing.Point(685, 56);
            this.txtCarPartId.Name = "txtCarPartId";
            this.txtCarPartId.Size = new System.Drawing.Size(211, 22);
            this.txtCarPartId.TabIndex = 51;
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
            // OrderCarPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCarPart);
            this.Controls.Add(this.btnCarPartSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarPartId);
            this.Controls.Add(this.label1);
            this.Name = "OrderCarPart";
            this.Size = new System.Drawing.Size(1041, 762);
            this.Load += new System.EventHandler(this.OrderCarPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarPart;
        private System.Windows.Forms.Button btnCarPartSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarPartId;
        private System.Windows.Forms.Label label1;
    }
}
