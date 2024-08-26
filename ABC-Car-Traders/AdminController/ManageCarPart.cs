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
    public partial class ManageCarPartPart : UserControl
    {
        private string idValue;

        public ManageCarPartPart()
        {
            InitializeComponent();
            idValue = "";
        }

        private void ManageCarPart_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with to select * data from the database table
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
                            // set the datagrid view's datasource 
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

        private void btnCarPartUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartName.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartDescription.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartType.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartQty.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters                    
                    string sqlCommandText = "UPDATE CarPart SET Name = @Name, Description = @Description, Type = @Type, Qty = @Qty, Price = @Price WHERE ID = @ID";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = idValue;

                        sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Name"].Value = txtCarPartName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Description"].Value = txtCarPartDescription.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Type"].Value = txtCarPartType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                        sqlCommand.Parameters["@Qty"].Value = txtCarPartQty.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
                        sqlCommand.Parameters["@Price"].Value = txtCarPartPrice.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Car Part updated successfully.");
                                ClearCarPartFields();
                            }

                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCarPart_Load(sender, e);
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
                idValue = row.Cells[0].Value.ToString();
                txtCarPartName.Text = row.Cells[1].Value.ToString();
                txtCarPartDescription.Text = row.Cells[2].Value.ToString();
                txtCarPartType.Text = row.Cells[3].Value.ToString();
                txtCarPartQty.Text = row.Cells[4].Value.ToString();
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

        private void btnCarPartDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM CarPart WHERE ID=@ID";
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
                            MessageBox.Show("Car Part deleted successfully.");
                            ClearCarPartFields();
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    finally
                    {
                        ManageCarPart_Load(sender, e);
                        dbConnection.Close();
                    }
                }
            }

        }

        private void btnCarPartAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartName.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartDescription.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartType.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartQty.Text) ||
              string.IsNullOrWhiteSpace(txtCarPartPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string carPartId = GenerateCarPartId();

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "INSERT INTO CarPart (ID, Name, Description, Type, Qty, Price) VALUES (@ID, @Name, @Description, @Type, @Qty, @Price)";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = carPartId;

                        sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Name"].Value = txtCarPartName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Description"].Value = txtCarPartDescription.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Type"].Value = txtCarPartType.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                        sqlCommand.Parameters["@Qty"].Value = txtCarPartQty.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int));
                        sqlCommand.Parameters["@Price"].Value = txtCarPartPrice.Text;

                        try
                        {
                            dbConnection.Open();
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Car Part added successfully.");
                                ClearCarPartFields();
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCarPart_Load(sender, e);
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

        private void btnCarPartSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarPartId.Text))
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
                        sqlCommand.Parameters["@ID"].Value = txtCarPartId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCarPartName.Text = reader["Name"].ToString();
                                txtCarPartDescription.Text = reader["Description"].ToString();
                                txtCarPartType.Text = reader["Type"].ToString();
                                txtCarPartQty.Text = reader["Qty"].ToString();
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
                ClearCarPartFields();
            }
        }

        private void btnGenerateCarPartReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM CarPart";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        dbConnection.Open();
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable carPartTable = new DataTable();
                        sqlAdapter.Fill(carPartTable);

                        // Ensure EPPlus License is set using fully qualified name
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel file
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("CarParts");

                            // Load data from the DataTable to the worksheet
                            worksheet.Cells["A1"].LoadFromDataTable(carPartTable, true);


                            // Determine the number of columns in the DataTable
                            int columnCount = carPartTable.Columns.Count;

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
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarPartsReport.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show("Car Parts report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string GenerateCarPartId()
        {
            string newId = "CP001";
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();

                    // Get the last customer ID
                    string sqlCommandText = "SELECT TOP 1 ID FROM CarPart ORDER BY ID DESC";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString();
                            int numericPart = int.Parse(lastId.Substring(2)) + 1;
                            newId = "CP" + numericPart.ToString("D3");
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
