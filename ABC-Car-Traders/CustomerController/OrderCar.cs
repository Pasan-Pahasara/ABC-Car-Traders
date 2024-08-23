using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders.CustomerController
{
    public partial class OrderCar : UserControl
    {
        public OrderCar()
        {
            InitializeComponent();
        }

        private void OrderCar_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with to select * data from the database table
                    string sqlCommandText = "SELECT * FROM Car";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carTable);
                            // set the datagrid view's datasource 
                            dgvCar.DataSource = carTable;
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            dbConnection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCar.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtCarId.Text = row.Cells[0].Value.ToString();
                txtCarModel.Text = row.Cells[1].Value.ToString();
                txtCarBrand.Text = row.Cells[2].Value.ToString();
                txtCarFuelType.Text = row.Cells[3].Value.ToString();
                txtCarPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void ClearCarFields()
        {
            txtCarId.Text = string.Empty;
            txtCarModel.Text = string.Empty;
            txtCarBrand.Text = string.Empty;
            txtCarFuelType.Text = string.Empty;
            txtCarQty.Text = string.Empty;
            txtCarPrice.Text = string.Empty;
        }

        private void btnCarSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarSearchId.Text))
            {
                MessageBox.Show("Please enter a Car ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM Car WHERE ID = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCarSearchId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCarId.Text = reader["ID"].ToString();
                                txtCarModel.Text = reader["Model"].ToString();
                                txtCarBrand.Text = reader["Brand"].ToString();
                                txtCarFuelType.Text = reader["FuelType"].ToString();
                                txtCarPrice.Text = reader["Price"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Car ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCarFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching car: " + ex.Message);
            }
        }
    }
}
