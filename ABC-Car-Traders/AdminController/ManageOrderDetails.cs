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
    public partial class ManageOrderDetails : UserControl
    {
        public ManageOrderDetails()
        {
            InitializeComponent();
        }

        private void ManageOrderDetails_Load(object sender, EventArgs e)
        {
            LoadCarOrderData();
            LoadCarPartOrderData();
        }

        private void LoadCarOrderData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarOrder table
                    //string sqlCommandText = "SELECT * FROM CarOrderDetails";
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carOrderDetailsTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carOrderDetailsTable);
                            // Set the datagrid view's datasource 
                            dgvCarOrderDetail.DataSource = carOrderDetailsTable;
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
                    //string sqlCommandText = "SELECT * FROM CarPartOrderDetails";
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarPartOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable carPartOrderDetailsTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(carPartOrderDetailsTable);
                            // Set the datagrid view's datasource 
                            dgvCarPartOrderDetail.DataSource = carPartOrderDetailsTable;
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

        private void dgvCarOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCarOrderDetail.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtCarOrderId.Text = row.Cells[0].Value.ToString();
                txtCarStatus.Text = row.Cells[9].Value.ToString();
            }
        }

        private void dgvCarPartOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCarOrderDetail.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtCarPartOrderId.Text = row.Cells[0].Value.ToString();
                txtCarPartStatus.Text = row.Cells[9].Value.ToString();
            }
        }

        private void ClearCarOrderFields()
        {
            txtCarOrderId.Text = string.Empty;
            txtCarStatus.Text = string.Empty;
        }

        private void btnCarSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarOrderId.Text))
            {
                MessageBox.Show("Please enter a Car Order ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM CarOrderDetails WHERE OrderId = @OrderId";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar));
                        sqlCommand.Parameters["@OrderId"].Value = txtCarOrderId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCarStatus.Text = reader["OrderStatus"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Car Order ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCarOrderFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching car order: " + ex.Message);
            }
        }

        private void ClearCarPartOrderFields()
        {
            txtCarPartOrderId.Text = string.Empty;
            txtCarPartStatus.Text = string.Empty;
        }

        private void btnCarOrderPartSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartOrderId.Text))
            {
                MessageBox.Show("Please enter a Car Part Order ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM CarPartOrderDetails WHERE OrderId = @OrderId";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar));
                        sqlCommand.Parameters["@OrderId"].Value = txtCarPartOrderId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCarPartStatus.Text = reader["OrderStatus"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Car Part Order ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCarPartOrderFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching car part order: " + ex.Message);
            }
        }
    }
}
