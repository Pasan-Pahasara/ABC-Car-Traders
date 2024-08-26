using OfficeOpenXml.Style;
using OfficeOpenXml;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ABC_Car_Traders.AdminController
{
    public partial class ManageCar : UserControl
    {
        private string idValue;
        public ManageCar()
        {
            InitializeComponent();
            idValue = "";
        }

        private void ManageCar_Load(object sender, EventArgs e)
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
                    string sqlCommandText = "UPDATE Car SET Model = @Model, Brand = @Brand, FuelType = @FuelType, Qty = @Qty, Price = @Price WHERE ID = @ID";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = idValue;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtCarModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtCarBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtCarFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                        sqlCommand.Parameters["@Qty"].Value = txtCarQty.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
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
                idValue = row.Cells[0].Value.ToString();
                txtCarModel.Text = row.Cells[1].Value.ToString();
                txtCarBrand.Text = row.Cells[2].Value.ToString();
                txtCarFuelType.Text = row.Cells[3].Value.ToString();
                txtCarQty.Text = row.Cells[4].Value.ToString();
                txtCarPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void ClearCarFields()
        {
            idValue = string.Empty;
            txtCarId.Text = string.Empty;
            txtCarModel.Text = string.Empty;
            txtCarBrand.Text = string.Empty;
            txtCarFuelType.Text = string.Empty;
            txtCarQty.Text = string.Empty;
            txtCarPrice.Text = string.Empty;
        }

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM Car WHERE ID=@ID";
                using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                    sqlCommand.Parameters["@ID"].Value = idValue;

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
            string carId = GenerateCarId();

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "INSERT INTO Car (ID, Model, Brand, FuelType, Qty, Price) VALUES (@ID, @Model, @Brand, @FuelType, @Qty, @Price)";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = carId;

                        sqlCommand.Parameters.Add(new SqlParameter("@Model", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Model"].Value = txtCarModel.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Brand", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Brand"].Value = txtCarBrand.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@FuelType", SqlDbType.VarChar));
                        sqlCommand.Parameters["@FuelType"].Value = txtCarFuelType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                        sqlCommand.Parameters["@Qty"].Value = txtCarQty.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
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
                    string sqlCommandText = "SELECT * FROM Car WHERE ID = @ID";
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
                                txtCarQty.Text = reader["Qty"].ToString();
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
                ClearCarFields();
            }
        }

        private void btnGenerateCarReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM Car";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        dbConnection.Open();
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable carTable = new DataTable();
                        sqlAdapter.Fill(carTable);

                        // Ensure EPPlus License is set using fully qualified name
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel file
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Cars");

                            // Load data from the DataTable to the worksheet
                            worksheet.Cells["A1"].LoadFromDataTable(carTable, true);


                            // Determine the number of columns in the DataTable
                            int columnCount = carTable.Columns.Count;

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
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarsReport.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show("Cars report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string GenerateCarId()
        {
            string newId = "CR001";
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();

                    // Get the last customer ID
                    string sqlCommandText = "SELECT TOP 1 ID FROM Car ORDER BY ID DESC";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString();
                            int numericPart = int.Parse(lastId.Substring(2)) + 1;
                            newId = "CR" + numericPart.ToString("D3");
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
