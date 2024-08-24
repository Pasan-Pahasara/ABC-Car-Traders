using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
                DataGridViewRow row = dgvCarPartOrderDetail.Rows[e.RowIndex];

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

        private void btnCarOrderUpdateStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarOrderId.Text) ||
             string.IsNullOrWhiteSpace(txtCarStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters                    
                    string sqlCommandText1 = "UPDATE CarOrder SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId";
                    string sqlCommandText2 = "UPDATE CarOrderDetails SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand1 = new SqlCommand(sqlCommandText1, dbConnection))
                    using (SqlCommand sqlCommand2 = new SqlCommand(sqlCommandText2, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand1.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar));
                        sqlCommand1.Parameters["@OrderId"].Value = txtCarOrderId.Text;

                        sqlCommand1.Parameters.Add(new SqlParameter("@OrderStatus", SqlDbType.VarChar));
                        sqlCommand1.Parameters["@OrderStatus"].Value = txtCarStatus.Text;

                        sqlCommand2.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar));
                        sqlCommand2.Parameters["@OrderId"].Value = txtCarOrderId.Text;

                        sqlCommand2.Parameters.Add(new SqlParameter("@OrderStatus", SqlDbType.VarChar));
                        sqlCommand2.Parameters["@OrderStatus"].Value = txtCarStatus.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result1 = sqlCommand1.ExecuteNonQuery();
                            int result2 = sqlCommand2.ExecuteNonQuery();
                            if (result1 > 0 && result2 > 0)
                            {
                                MessageBox.Show("Car order status updated successfully.");
                                ClearCarOrderFields();
                            }

                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            LoadCarOrderData();
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

        private void btnCarPartOrderUpdateStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartOrderId.Text) ||
            string.IsNullOrWhiteSpace(txtCarPartStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters  
                    string sqlCommandText1 = "UPDATE CarPartOrderDetails SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId";
                    string sqlCommandText2 = "UPDATE CarPartOrder SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand1 = new SqlCommand(sqlCommandText1, dbConnection))
                    using (SqlCommand sqlCommand2 = new SqlCommand(sqlCommandText2, dbConnection))
                    {
                        // Set Parameters for both commands
                        sqlCommand1.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar)).Value = txtCarPartOrderId.Text;
                        sqlCommand1.Parameters.Add(new SqlParameter("@OrderStatus", SqlDbType.VarChar)).Value = txtCarPartStatus.Text;

                        sqlCommand2.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.VarChar)).Value = txtCarPartOrderId.Text;
                        sqlCommand2.Parameters.Add(new SqlParameter("@OrderStatus", SqlDbType.VarChar)).Value = txtCarPartStatus.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute both commands
                            int result1 = sqlCommand1.ExecuteNonQuery();
                            int result2 = sqlCommand2.ExecuteNonQuery();

                            if (result1 > 0 && result2 > 0)
                            {
                                MessageBox.Show("Car part order status updated successfully.");
                                ClearCarPartOrderFields();
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            LoadCarPartOrderData();
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

        private void btnGenerateCarOrderDetailsReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        dbConnection.Open();
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable carOrderDetailsTable = new DataTable();
                        sqlAdapter.Fill(carOrderDetailsTable);

                        // Ensure EPPlus License is set using fully qualified name
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel file
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("CarOrderDetails");

                            // Load data from the DataTable to the worksheet
                            worksheet.Cells["A1"].LoadFromDataTable(carOrderDetailsTable, true);

                            // Determine the number of columns in the DataTable
                            int columnCount = carOrderDetailsTable.Columns.Count;

                            // Convert the column count to an Excel range (e.g., "A1:E1")
                            string endColumnLetter = GetExcelColumnName(columnCount);
                            string headerRange = $"A1:{endColumnLetter}1";

                            // Format the header
                            using (ExcelRange range = worksheet.Cells[headerRange])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                                range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }

                            // Auto-fit the columns
                            worksheet.Cells.AutoFitColumns();

                            // Define the file path to save the Excel file
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarOrderDetailsReport.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show("Car Order Details report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }

        private void btnGenerateCarPartOrderDetailsReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarPartOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        dbConnection.Open();
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable carPartOrderDetailsTable = new DataTable();
                        sqlAdapter.Fill(carPartOrderDetailsTable);

                        // Ensure EPPlus License is set using fully qualified name
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel file
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("CarPartOrderDetails");

                            // Load data from the DataTable to the worksheet
                            worksheet.Cells["A1"].LoadFromDataTable(carPartOrderDetailsTable, true);

                            // Determine the number of columns in the DataTable
                            int columnCount = carPartOrderDetailsTable.Columns.Count;

                            // Convert the column count to an Excel range (e.g., "A1:E1")
                            string endColumnLetter = GetExcelColumnName(columnCount);
                            string headerRange = $"A1:{endColumnLetter}1";

                            // Format the header
                            using (ExcelRange range = worksheet.Cells[headerRange])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                                range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }

                            // Auto-fit the columns
                            worksheet.Cells.AutoFitColumns();

                            // Define the file path to save the Excel file
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarPartOrderDetailsReport.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show("Car Part Order Details report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }

        private string GetExcelColumnName(int columnIndex)
        {
            const int lettersInAlphabet = 26;
            string columnName = string.Empty;

            while (columnIndex > 0)
            {
                int modulo = (columnIndex - 1) % lettersInAlphabet;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnIndex = (columnIndex - modulo) / lettersInAlphabet;
            }

            return columnName;
        }
    }
}
