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
    public partial class OrderCarPart : UserControl
    {
        private string _loggedInId;

        public OrderCarPart(string loggedInId)
        {
            InitializeComponent();
            txtCustomerId.Text = loggedInId;
            _loggedInId = loggedInId;
        }

        private void txtCarPartPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateAndSetTotal();
        }

        private void txtCarPartQty_TextChanged(object sender, EventArgs e)
        {
            CalculateAndSetTotal();
        }

        private void CalculateAndSetTotal()
        {
            if (decimal.TryParse(txtCarPartPrice.Text, out decimal carPrice) && int.TryParse(txtCarPartQty.Text, out int carQty))
            {
                decimal total = carPrice * carQty;
                lblTotal.Text = total.ToString();
            }
            else
            {
                lblTotal.Text = "0.00";
            }
        }

        private void OrderCarPart_Load(object sender, EventArgs e)
        {
            LoadCarPartData();
            LoadCarPartOrderData();
        }

        private void LoadCarPartData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarPart table
                    string sqlCommandText = "SELECT * FROM CarPart";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carPartTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carPartTable);
                            // Set the datagrid view's datasource 
                            dgvCarPart.DataSource = carPartTable;
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

        private void LoadCarPartOrderData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarPartOrder table
                    string sqlCommandText = "SELECT * FROM CarPartOrder WHERE CustomerId = @CustomerId";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@CustomerId", _loggedInId);

                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carPartOrderTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carPartOrderTable);
                            // Set the datagrid view's datasource 
                            dgvCarPartOrder.DataSource = carPartOrderTable;
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

        private void dgvCarPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCarPart.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtCarPartId.Text = row.Cells[0].Value.ToString();
                txtCarPartName.Text = row.Cells[1].Value.ToString();
                txtCarPartDescription.Text = row.Cells[2].Value.ToString();
                txtCarPartType.Text = row.Cells[3].Value.ToString();
                txtCarPartPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void ClearCarPartFields()
        {
            txtCarPartId.Text = string.Empty;
            txtCarPartName.Text = string.Empty;
            txtCarPartDescription.Text = string.Empty;
            txtCarPartType.Text = string.Empty;
            txtCarPartQty.Text = string.Empty;
            txtCarPartPrice.Text = string.Empty;
        }

        private void btnCarPartSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartSearchId.Text))
            {
                MessageBox.Show("Please enter a Car Part ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM CarPart WHERE ID = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCarPartSearchId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCarPartId.Text = reader["ID"].ToString();
                                txtCarPartName.Text = reader["Name"].ToString();
                                txtCarPartDescription.Text = reader["Description"].ToString();
                                txtCarPartType.Text = reader["Type"].ToString();
                                txtCarPartPrice.Text = reader["Price"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Car Part ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCarPartFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching car part: " + ex.Message);
            }
        }

        private void btnCarPartOrder_Click(object sender, EventArgs e)
        {
            // Validate that all necessary fields are filled out
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                string.IsNullOrWhiteSpace(txtCarPartId.Text) ||
                string.IsNullOrWhiteSpace(txtCarPartQty.Text))
            {
                MessageBox.Show("Please fill in all fields before placing the order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string carPartOrderId = GenerateCarPartOrderId();

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();
                    SqlTransaction transaction = dbConnection.BeginTransaction();

                    try
                    {
                        // Insert the order into the Orders table
                        string sqlCommandOrderText = "INSERT INTO CarPartOrder (OrderId, CustomerId, CarPartId, Quantity, OrderDate, OrderStatus, Total) VALUES (@OrderId, @CustomerId, @CarPartId, @Quantity, @OrderDate, @OrderStatus, @Total)";

                        using (SqlCommand sqlOrderCommand = new SqlCommand(sqlCommandOrderText, dbConnection, transaction))
                        {
                            sqlOrderCommand.Parameters.AddWithValue("@OrderId", carPartOrderId);
                            sqlOrderCommand.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CarPartId", txtCarPartId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Quantity", int.Parse(txtCarPartQty.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            sqlOrderCommand.Parameters.AddWithValue("@OrderStatus", "Pending"); // Or any status you want to set
                            sqlOrderCommand.Parameters.AddWithValue("@Total", decimal.Parse(lblTotal.Text));

                            sqlOrderCommand.ExecuteNonQuery();
                        }

                        // Insert the order into the Orders table
                        string sqlCommandOrderDetailsText = "INSERT INTO CarPartOrderDetails (OrderId, CustomerId, CarPartId, Name, Description, Type, Price, Quantity, OrderDate, OrderStatus) VALUES (@OrderId, @CustomerId, @CarPartId, @Name, @Description, @Type, @Price, @Quantity, @OrderDate, @OrderStatus)";

                        using (SqlCommand sqlOrderCommand = new SqlCommand(sqlCommandOrderDetailsText, dbConnection, transaction))
                        {
                            sqlOrderCommand.Parameters.AddWithValue("@OrderId", carPartOrderId);
                            sqlOrderCommand.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@CarPartId", txtCarPartId.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Name", txtCarPartName.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Description", txtCarPartDescription.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Type", txtCarPartType.Text);
                            sqlOrderCommand.Parameters.AddWithValue("@Price", decimal.Parse(txtCarPartPrice.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@Quantity", int.Parse(txtCarPartQty.Text));
                            sqlOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            sqlOrderCommand.Parameters.AddWithValue("@OrderStatus", "Pending"); // Or any status you want to set

                            sqlOrderCommand.ExecuteNonQuery();
                        }


                        // Commit the transaction
                        transaction.Commit();

                        MessageBox.Show("Order placed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCarPartOrderData();

                        // Clear the fields after successful order
                        ClearCarPartFields();
                        txtCustomerId.Text = string.Empty;
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

        private string GenerateCarPartOrderId()
        {
            string newId = "R001";
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();

                    // Get the last carPartOrder ID
                    string sqlCommandText = "SELECT TOP 1 OrderId FROM CarPartOrder ORDER BY OrderId DESC";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString();
                            int numericPart = int.Parse(lastId.Substring(1)) + 1;
                            newId = "R" + numericPart.ToString("D3");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newId;
        }
    }
}
