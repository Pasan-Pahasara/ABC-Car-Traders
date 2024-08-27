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
    public partial class GenerateReports : UserControl
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void btnGenerateCarOrderDetailsDailyReport_Click(object sender, EventArgs e)
        {
            GenerateCarDailyReport();
        }

        private void GenerateCarDailyReport()
        {
            GenerateCarReport("CONVERT(date, cpo.OrderDate) = CONVERT(date, GETDATE())", "Daily");
        }

        private void GenerateCarReport(string dateFilter, string reportType)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = $"SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE {dateFilter}";
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
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add($"CarOrder{reportType}Details");

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
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"CarOrderDetails{reportType}Report.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show($"Car Order Details {reportType} report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }

        private void GenerateCarReportView(string dateFilter, string reportType, DataGridView reportDataGridView)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = $"SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE {dateFilter}";
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
                            // Set the data source for the DataGridView
                            reportDataGridView.DataSource = carOrderDetailsTable;
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

        private void btnGenerateCarOrderDetailsMonthlyReport_Click(object sender, EventArgs e)
        {
            GenerateCarMonthlyReport();
        }

        private void GenerateCarMonthlyReport()
        {
            GenerateCarReport("YEAR(cpo.OrderDate) = YEAR(GETDATE()) AND MONTH(cpo.OrderDate) = MONTH(GETDATE())", "Monthly");
        }

        private void btnGenerateCarOrderDetailsYearlyReport_Click(object sender, EventArgs e)
        {
            GenerateCarYearlyReport();
        }

        private void GenerateCarYearlyReport()
        {
            GenerateCarReport("YEAR(cpo.OrderDate) = YEAR(GETDATE())", "Yearly");
        }

        private void btnGenerateCarPartOrderDetailsDailyReport_Click(object sender, EventArgs e)
        {
            GenerateCarPartDailyReport();
        }

        private void GenerateCarPartDailyReport()
        {
            GenerateCarPartReport("CONVERT(date, cpo.OrderDate) = CONVERT(date, GETDATE())", "Daily");
        }

        private void GenerateCarPartReport(string dateFilter, string reportType)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = $"SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarPartOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE {dateFilter}";
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
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add($"CarPartOrder{reportType}Details");

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
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"CarPartOrderDetails{reportType}Report.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show($"Car Part Order Details {reportType} report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }

        private void GenerateCarPartReportView(string dateFilter, string reportType, DataGridView reportDataGridView)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = $"SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarPartOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE {dateFilter}";
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
                            // Set the data source for the DataGridView
                            reportDataGridView.DataSource = carPartOrderDetailsTable;
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
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }

        private void btnGenerateCarPartOrderDetailsMonthlyReport_Click(object sender, EventArgs e)
        {
            GenerateCarPartMonthlyReport();
        }

        private void GenerateCarPartMonthlyReport()
        {
            GenerateCarPartReport("YEAR(cpo.OrderDate) = YEAR(GETDATE()) AND MONTH(cpo.OrderDate) = MONTH(GETDATE())", "Monthly");
        }

        private void btnGenerateCarPartOrderDetailsYearlyReport_Click(object sender, EventArgs e)
        {
            GenerateCarPartYearlyReport();
        }

        private void GenerateCarPartYearlyReport()
        {
            GenerateCarPartReport("YEAR(cpo.OrderDate) = YEAR(GETDATE())", "Yearly");
        }

        private void GenerateReports_Load(object sender, EventArgs e)
        {
            GenerateCarReportView("CONVERT(date, cpo.OrderDate) = CONVERT(date, GETDATE())", "Daily", dgvCarDailyOrderDetails);
            GenerateCarReportView("YEAR(cpo.OrderDate) = YEAR(GETDATE()) AND MONTH(cpo.OrderDate) = MONTH(GETDATE())", "Monthly", dgvCarMonthlyOrderDetails);
            GenerateCarReportView("YEAR(cpo.OrderDate) = YEAR(GETDATE())", "Yearly", dgvCarYearlyOrderDetails);
            GenerateCarPartReportView("CONVERT(date, cpo.OrderDate) = CONVERT(date, GETDATE())", "Daily", dgvCarPartDailyOrderDetails);
            GenerateCarPartReportView("YEAR(cpo.OrderDate) = YEAR(GETDATE()) AND MONTH(cpo.OrderDate) = MONTH(GETDATE())", "Monthly", dgvCarPartMonthlyOrderDetails);
            GenerateCarPartReportView("YEAR(cpo.OrderDate) = YEAR(GETDATE())", "Yearly", dgvCarPartYearlyOrderDetails);
        }
    }
}



