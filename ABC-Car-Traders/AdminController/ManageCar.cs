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

namespace ABC_Car_Traders.AdminController
{
    public partial class ManageCar : UserControl
    {
        public ManageCar()
        {
            InitializeComponent();
        }

        private void ManageCar_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with to select * data from the database table
                    string sqlCommandText = "SELECT * FROM Vehicle";
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

        private void btnCarUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarModel.Text) ||
              string.IsNullOrWhiteSpace(txtCarBrand.Text) ||
              string.IsNullOrWhiteSpace(txtCarFuelType.Text) ||
              string.IsNullOrWhiteSpace(txtCarPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters                    
                    string sqlCommandText = "UPDATE Vehicle SET Model = @Model, Brand = @Brand, FuelType = @FuelType, Price = @Price WHERE ID = @ID";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCarId.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtCarModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtCarBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtCarFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Price"].Value = txtCarPrice.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Car updated successfully.");
                                ClearCarFields();
                            }

                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCar_Load(sender, e);
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
                txtCarPrice.Text = row.Cells[4].Value.ToString();
            }
        }

        private void ClearCarFields()
        {
            txtCarId.Text = string.Empty;
            txtCarModel.Text = string.Empty;
            txtCarBrand.Text = string.Empty;
            txtCarFuelType.Text = string.Empty;
            txtCarPrice.Text = string.Empty;
        }

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM Vehicle WHERE ID=@ID";
                using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                    sqlCommand.Parameters["@ID"].Value = txtCarId.Text;

                    try
                    {
                        // Open database connection
                        dbConnection.Open();

                        // Execute the command
                        int result = sqlCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Car deleted successfully.");
                            ClearCarFields();
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    finally
                    {
                        ManageCar_Load(sender, e);
                        dbConnection.Close();
                    }
                }
            }

        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarModel.Text) ||
             string.IsNullOrWhiteSpace(txtCarBrand.Text) ||
             string.IsNullOrWhiteSpace(txtCarFuelType.Text) ||
             string.IsNullOrWhiteSpace(txtCarPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "INSERT INTO Vehicle (ID, Model, Brand, FuelType, Price) VALUES (@ID, @Model, @Brand, @FuelType, @Price)";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCarId.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtCarModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtCarBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtCarFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Price"].Value = txtCarPrice.Text;

                        try
                        {
                            dbConnection.Open();
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Car added successfully.");
                                ClearCarFields();
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCar_Load(sender, e);
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

        private void btnCarSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarId.Text))
            {
                MessageBox.Show("Please enter a Car ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM Vehicle WHERE ID = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCarId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
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
