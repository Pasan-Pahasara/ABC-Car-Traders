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
    public partial class ManageVehicle : UserControl
    {
        public ManageVehicle()
        {
            InitializeComponent();
        }

        private void ManageVehicle_Load(object sender, EventArgs e)
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
                            DataTable vehicleTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(vehicleTable);
                            // set the datagrid view's datasource 
                            dgvVehicle.DataSource = vehicleTable;
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

        private void btnVehicleUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleModel.Text) ||
              string.IsNullOrWhiteSpace(txtVehicleBrand.Text) ||
              string.IsNullOrWhiteSpace(txtVehicleFuelType.Text) ||
              string.IsNullOrWhiteSpace(txtVehiclePrice.Text))
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
                        sqlCommand.Parameters["@ID"].Value = txtVehicleId.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtVehicleModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtVehicleBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtVehicleFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Price"].Value = txtVehiclePrice.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Vehicle updated successfully.");
                                ClearVehicleFields();
                            }

                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageVehicle_Load(sender, e);
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

        private void dgvVehicle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvVehicle.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtVehicleId.Text = row.Cells[0].Value.ToString();
                txtVehicleModel.Text = row.Cells[1].Value.ToString();
                txtVehicleBrand.Text = row.Cells[2].Value.ToString();
                txtVehicleFuelType.Text = row.Cells[3].Value.ToString();
                txtVehiclePrice.Text = row.Cells[4].Value.ToString();
            }
        }

        private void ClearVehicleFields()
        {
            txtVehicleId.Text = string.Empty;
            txtVehicleModel.Text = string.Empty;
            txtVehicleBrand.Text = string.Empty;
            txtVehicleFuelType.Text = string.Empty;
            txtVehiclePrice.Text = string.Empty;
        }

        private void btnVehicleDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM Vehicle WHERE ID=@ID";
                using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                    sqlCommand.Parameters["@ID"].Value = txtVehicleId.Text;

                    try
                    {
                        // Open database connection
                        dbConnection.Open();

                        // Execute the command
                        int result = sqlCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Vehicle deleted successfully.");
                            ClearVehicleFields();
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    finally
                    {
                        ManageVehicle_Load(sender, e);
                        dbConnection.Close();
                    }
                }
            }

        }

        private void btnVehicleAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleModel.Text) ||
             string.IsNullOrWhiteSpace(txtVehicleBrand.Text) ||
             string.IsNullOrWhiteSpace(txtVehicleFuelType.Text) ||
             string.IsNullOrWhiteSpace(txtVehiclePrice.Text))
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
                        sqlCommand.Parameters["@ID"].Value = txtVehicleId.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtVehicleModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtVehicleBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtVehicleFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Price"].Value = txtVehiclePrice.Text;

                        try
                        {
                            dbConnection.Open();
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Vehicle added successfully.");
                                ClearVehicleFields();
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageVehicle_Load(sender, e);
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

        private void btnVehicleSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleId.Text))
            {
                MessageBox.Show("Please enter a Vehicle ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sqlCommand.Parameters["@ID"].Value = txtVehicleId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtVehicleModel.Text = reader["Model"].ToString();
                                txtVehicleBrand.Text = reader["Brand"].ToString();
                                txtVehicleFuelType.Text = reader["FuelType"].ToString();
                                txtVehiclePrice.Text = reader["Price"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Vehicle ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearVehicleFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customer: " + ex.Message);
            }
        }
    }
}
