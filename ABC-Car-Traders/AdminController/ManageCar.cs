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
                        sqlCommand.Parameters["@ID"].Value = txtCarId.Text;

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
                txtCarId.Text = row.Cells[0].Value.ToString();
                txtCarModel.Text = row.Cells[1].Value.ToString();
                txtCarBrand.Text = row.Cells[2].Value.ToString();
                txtCarFuelType.Text = row.Cells[3].Value.ToString();
                txtCarQty.Text = row.Cells[4].Value.ToString();
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

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM Car WHERE ID=@ID";
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
                    string sqlCommandText = "INSERT INTO Car (ID, Model, Brand, FuelType, Qty, Price) VALUES (@ID, @Model, @Brand, @FuelType, @Qty, @Price)";
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
            }
        }

        /*        private void btnGenerateCarReport_Click(object sender, EventArgs e)
                {
                    try
                    {
                        // Set the PDF file path
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CarReport.pdf");

                        // Check if the file exists and is in use
                        if (File.Exists(filePath))
                        {
                            try
                            {
                                // Attempt to delete the file to check if it's in use
                                File.Delete(filePath);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("The file is currently in use. Please close the file and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Create a new PDF document
                        PdfDocument document = new PdfDocument();
                        document.Info.Title = "Car Details Report";

                        // Create an empty page
                        PdfPage page = document.AddPage();

                        // Get an XGraphics object for drawing
                        XGraphics gfx = XGraphics.FromPdfPage(page);

                        // Create fonts
                        XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Bold);
                        XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
                        XFont cellFont = new XFont("Verdana", 12, XFontStyleEx.Regular);


                        // Draw the title on the PDF page
                        gfx.DrawString("Car Details Report", titleFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);

                        // Define starting points for the table
                        int yPoint = 60;
                        int xPoint = 40;
                        int cellHeight = 20;

                        // Draw table headers
                        gfx.DrawString("Car ID", headerFont, XBrushes.Black, new XRect(xPoint, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                        gfx.DrawString("Model", headerFont, XBrushes.Black, new XRect(xPoint + 100, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                        gfx.DrawString("Year", headerFont, XBrushes.Black, new XRect(xPoint + 200, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                        gfx.DrawString("Price", headerFont, XBrushes.Black, new XRect(xPoint + 300, yPoint, page.Width, page.Height), XStringFormats.TopLeft);

                        yPoint += cellHeight; // Move down for the first row of data

                        // Add data from DataGridView (example)
                        foreach (DataGridViewRow row in dgvCar.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                gfx.DrawString(row.Cells[0].Value?.ToString() ?? "N/A", cellFont, XBrushes.Black, new XRect(xPoint, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                                gfx.DrawString(row.Cells[1].Value?.ToString() ?? "N/A", cellFont, XBrushes.Black, new XRect(xPoint + 100, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                                gfx.DrawString(row.Cells[2].Value?.ToString() ?? "N/A", cellFont, XBrushes.Black, new XRect(xPoint + 200, yPoint, page.Width, page.Height), XStringFormats.TopLeft);
                                gfx.DrawString(row.Cells[3].Value?.ToString() ?? "N/A", cellFont, XBrushes.Black, new XRect(xPoint + 300, yPoint, page.Width, page.Height), XStringFormats.TopLeft);

                                yPoint += cellHeight; // Move down for the next row of data
                            }
                        }

                        // Save the document
                        document.Save(filePath);

                        // Open the PDF document using the default PDF viewer
                        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                        MessageBox.Show("PDF report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Access to the path is denied: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("I/O error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating PDF report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        */

        private void btnGenerateCarReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Set the PDF file path
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CarReport.pdf");

                // Check if the file exists and is in use
                if (File.Exists(filePath))
                {
                    try
                    {
                        // Attempt to delete the file to check if it's in use
                        File.Delete(filePath);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("The file is currently in use. Please close the file and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Create a new PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Car Details Report";

                // Create an empty page
                PdfPage page = document.AddPage();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create fonts
                XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Bold);
                XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
                XFont cellFont = new XFont("Verdana", 12, XFontStyleEx.Regular);

                // Define a top margin for the title
                int titleTopMargin = 40;

                // Draw the title on the PDF page
                gfx.DrawString("Car Details Report", titleFont, XBrushes.Black, new XRect(0, titleTopMargin, page.Width, page.Height), XStringFormats.TopCenter);

                // Define starting points for the table
                int cellHeight = 20;
                int yPoint = titleTopMargin + 40; // Adjust starting Y point after the title
                int columnCount = dgvCar.Columns.Count;
                int tableWidth = 100 * columnCount; // Assuming each column is 100 units wide
                int xPoint = (int)((page.Width - tableWidth) / 2); // Center the table

                // Draw table headers
                for (int i = 0; i < columnCount; i++)
                {
                    // Draw header text
                    gfx.DrawString(dgvCar.Columns[i].HeaderText, headerFont, XBrushes.Black, new XRect(xPoint, yPoint, 100, cellHeight), XStringFormats.Center);

                    // Draw header border
                    gfx.DrawRectangle(XPens.Black, xPoint, yPoint, 100, cellHeight);

                    xPoint += 100;
                }

                yPoint += cellHeight; // Move down for the first row of data
                xPoint = (int)((page.Width - tableWidth) / 2); // Reset xPoint for the data rows

                // Add data from DataGridView (example)
                foreach (DataGridViewRow row in dgvCar.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            string cellValue = row.Cells[i].Value?.ToString() ?? "N/A";

                            // Draw cell text
                            gfx.DrawString(cellValue, cellFont, XBrushes.Black, new XRect(xPoint, yPoint, 100, cellHeight), XStringFormats.Center);

                            // Draw cell border
                            gfx.DrawRectangle(XPens.Black, xPoint, yPoint, 100, cellHeight);

                            xPoint += 100;
                        }

                        yPoint += cellHeight; // Move down for the next row of data
                        xPoint = (int)((page.Width - tableWidth) / 2); // Reset xPoint for the next row
                    }
                }

                // Save the document
                document.Save(filePath);

                // Open the PDF document using the default PDF viewer
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                MessageBox.Show("PDF report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access to the path is denied: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("I/O error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
