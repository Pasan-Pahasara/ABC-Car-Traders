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

        private void txtCarPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateAndSetTotal();
        }

        private void txtCarQty_TextChanged(object sender, EventArgs e)
        {
            CalculateAndSetTotal();
        }

        private void CalculateAndSetTotal()
        {
            if (decimal.TryParse(txtCarPrice.Text, out decimal carPrice) && int.TryParse(txtCarQty.Text, out int carQty))
            {
                decimal total = carPrice * carQty;
                lblTotal.Text = total.ToString();
            }
            else
            {
                lblTotal.Text = "0.00";
            }
        }

        private void OrderCar_Load(object sender, EventArgs e)
        {
            // Load data from both the Car and CarOrder tables on form load
            LoadCarData();
            LoadCarOrderData();
        }

        private void LoadCarData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the Car table
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
                            // Set the datagrid view's datasource 
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

        private void LoadCarOrderData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarOrder table
                    string sqlCommandText = "SELECT * FROM CarOrder";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carOrderTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carOrderTable);
                            // Set the datagrid view's datasource 
                            dgvCarOrder.DataSource = carOrderTable;
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

        private void btnCarOrder_Click(object sender, EventArgs e)
        {
            // Validate that all necessary fields are filled out
            if (string.IsNullOrWhiteSpace(txtOrderId.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                string.IsNullOrWhiteSpace(txtCarId.Text) ||
                string.IsNullOrWhiteSpace(txtCarQty.Text))
            {
                MessageBox.Show("Please fill in all fields before placing the order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();
                    SqlTransaction transaction = dbConnection.BeginTransaction();

                    try
                    {
                        // Insert the order into the Orders table
                        string sqlCommandOrderText = "INSERT INTO CarOrder (OrderId, CustomerId, CarId, Quantity, OrderDate, OrderStatus, Total) VALUES (@OrderId, @CustomerId, @CarId, @Quantity, @OrderDate, @OrderStatus, @Total)";

                        using (SqlCommand sqlOrderCommand = new SqlCommand(sqlCommandOrderText, dbConnection, transaction))
                        {
                            sqlOrderCommand.Parameters.AddWithValue("@OrderId", txtOrderId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CarId", txtCarId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Quantity", int.Parse(txtCarQty.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            sqlOrderCommand.Parameters.AddWithValue("@OrderStatus", "Pending"); // Or any status you want to set
                            sqlOrderCommand.Parameters.AddWithValue("@Total", decimal.Parse(lblTotal.Text));

                            sqlOrderCommand.ExecuteNonQuery();
                        }

                        // Insert the order into the Orders table
                        string sqlCommandOrderDetailsText = "INSERT INTO CarOrderDetails (OrderId, CustomerId, CarId, Model, Brand, FuelType, Price, Quantity, OrderDate, OrderStatus) VALUES (@OrderId, @CustomerId, @CarId, @Model, @Brand, @FuelType, @Price, @Quantity, @OrderDate, @OrderStatus)";

                        using (SqlCommand sqlOrderCommand = new SqlCommand(sqlCommandOrderDetailsText, dbConnection, transaction))
                        {
                            sqlOrderCommand.Parameters.AddWithValue("@OrderId", txtOrderId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CarId", txtCarId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Model", txtCarModel.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Brand", txtCarBrand.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@FuelType", txtCarFuelType.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Price", decimal.Parse(txtCarPrice.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@Quantity", int.Parse(txtCarQty.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            sqlOrderCommand.Parameters.AddWithValue("@OrderStatus", "Pending"); // Or any status you want to set

                            sqlOrderCommand.ExecuteNonQuery();
                        }


                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("Order placed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCarOrderData();

                        // Clear the fields after successful order
                        ClearCarFields();
                        txtCustomerId.Text = string.Empty;
                        txtOrderId.Text = string.Empty;
                        lblTotal.Text = "0.00";
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction if there was an error
                        transaction.Rollback();
                        MessageBox.Show("Error placing order: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
        }
    }
}
