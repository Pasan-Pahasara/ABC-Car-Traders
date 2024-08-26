using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABC_Car_Traders.AdminController
{
    public partial class ManageCustomer : UserControl
    {
        private string idValue; 

        public ManageCustomer()
        {
            InitializeComponent();
            idValue = "";
        }

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string passPhrase = "customerpass";

                    // Updated SQL command to decrypt the password
                    string sqlCommandText = "SELECT ID, Name, Address, Contact, NIC, Email, CONVERT(VARCHAR(255), DecryptByPassPhrase(@Passphrase, Password)) AS DecryptedPassword FROM Customer";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@Passphrase", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Passphrase"].Value = passPhrase;

                        try
                        {
                           // Open database connection
                            dbConnection.Open();
                            // SQL adapter 
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                            // Datatable
                            DataTable customerTable = new DataTable();
                            // Fill the datatable by executing the command
                            sqlAdapter.Fill(customerTable);

                            // Rename the decrypted password column
                            customerTable.Columns["DecryptedPassword"].ColumnName = "Password";

                            // set the datagrid view's datasource 
                            dgvCustomer.DataSource = customerTable;
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

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
              string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
              string.IsNullOrWhiteSpace(txtCustomerContact.Text) ||
              string.IsNullOrWhiteSpace(txtCustomerNIC.Text) ||
              string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
              string.IsNullOrWhiteSpace(txtCustomerPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string passPhrase = "customerpass";

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters                    
                    string sqlCommandText = "UPDATE Customer SET Name = @Name, Address = @Address, Contact = @Contact, NIC = @NIC, Email = @Email, Password = EncryptByPassPhrase(@Passphrase, @Password)  WHERE ID = @ID";
                    // Set Parameters of the sql Command text
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = idValue;

                        sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Name"].Value = txtCustomerName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Address"].Value = txtCustomerAddress.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Contact"].Value = txtCustomerContact.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar));
                        sqlCommand.Parameters["@NIC"].Value = txtCustomerNIC.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Email"].Value = txtCustomerEmail.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Password"].Value = txtCustomerPassword.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@passphrase", SqlDbType.VarChar));
                        sqlCommand.Parameters["@passphrase"].Value = passPhrase;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Customer updated successfully.");
                                ClearCustomerFields();
                            }

                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCustomer_Load(sender, e);
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

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                idValue = row.Cells[0].Value.ToString();
                txtCustomerName.Text = row.Cells[1].Value.ToString();
                txtCustomerAddress.Text = row.Cells[2].Value.ToString();
                txtCustomerContact.Text = row.Cells[3].Value.ToString();
                txtCustomerNIC.Text = row.Cells[4].Value.ToString();
                txtCustomerEmail.Text = row.Cells[5].Value.ToString();
                txtCustomerPassword.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                string sqlCommandText = "DELETE FROM Customer WHERE ID=@ID";
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
                            MessageBox.Show("Customer deleted successfully.");
                            ClearCustomerFields();
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    finally
                    {
                        ManageCustomer_Load(sender, e);
                        dbConnection.Close();
                    }
                }
            }

        }

        private void ClearCustomerFields()
        {
            idValue = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerContact.Text = string.Empty;
            txtCustomerNIC.Text = string.Empty;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerPassword.Text = string.Empty;
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerContact.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerNIC.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string passPhrase = "customerpass";
            string customerId = GenerateCustomerId();

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "INSERT INTO Customer (ID, Name, Address, Contact, NIC, Email, Password) VALUES (@ID, @Name, @Address, @Contact, @NIC, @Email, EncryptByPassPhrase(@passphrase, @Password))";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = customerId;

                        sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Name"].Value = txtCustomerName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Address"].Value = txtCustomerAddress.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Contact"].Value = txtCustomerContact.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar));
                        sqlCommand.Parameters["@NIC"].Value = txtCustomerNIC.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Email"].Value = txtCustomerEmail.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Password"].Value = txtCustomerPassword.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@passphrase", SqlDbType.VarChar));
                        sqlCommand.Parameters["@passphrase"].Value = passPhrase;

                        try
                        {
                            dbConnection.Open();
                            int result = sqlCommand.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Customer added successfully.");
                                ClearCustomerFields();
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            MessageBox.Show(sqlEx.Message);
                        }
                        finally
                        {
                            ManageCustomer_Load(sender, e);
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

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Please enter a Customer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM Customer WHERE ID = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCustomerId.Text;

                        dbConnection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the text fields with the data
                                txtCustomerName.Text = reader["Name"].ToString();
                                txtCustomerAddress.Text = reader["Address"].ToString();
                                txtCustomerContact.Text = reader["Contact"].ToString();
                                txtCustomerNIC.Text = reader["NIC"].ToString();
                                txtCustomerEmail.Text = reader["Email"].ToString();
                                txtCustomerPassword.Text = reader["Password"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Customer ID not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCustomerFields();
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

        private void btnGenerateCustomerReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    string sqlCommandText = "SELECT * FROM Customer";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        dbConnection.Open();
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable customerTable = new DataTable();
                        sqlAdapter.Fill(customerTable);

                        // Ensure EPPlus License is set using fully qualified name
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel file
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Customers");

                            // Load data from the DataTable to the worksheet
                            worksheet.Cells["A1"].LoadFromDataTable(customerTable, true);


                            // Determine the number of columns in the DataTable
                            int columnCount = customerTable.Columns.Count;

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
                            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CustomerReport.xlsx");

                            // Save the file
                            File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());

                            // Open the file
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });

                            MessageBox.Show("Customer report generated and opened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string GenerateCustomerId()
        {
            string newId = "C001";
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    dbConnection.Open();

                    // Get the last customer ID
                    string sqlCommandText = "SELECT TOP 1 ID FROM Customer ORDER BY ID DESC";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString();
                            int numericPart = int.Parse(lastId.Substring(1)) + 1;
                            newId = "C" + numericPart.ToString("D3");
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
