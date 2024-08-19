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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABC_Car_Traders.AdminController
{
    public partial class ManageCustomer : UserControl
    {
        public ManageCustomer()
        {
            InitializeComponent();
        }

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with to select * data from the database table
                    string sqlCommandText = "SELECT * FROM Customer";
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
                            dgvCustomer.DataSource = vehicleTable;
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
            using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            {
                // UPDATE QUERY
                // Command Text with parameters                    
                // string sqlCommandText = "INSERT INTO Book (BookId,ISBN,Title,Author,Genre,PublishedYear) VALUES (@BookId,@ISBN,@Title,@Author,@Genre,@PublishedYear)";
                string sqlCommandText = "UPDATE Customer SET Name = @Name, Address = @Address, Contact = @Contact, NIC = @NIC WHERE ID = @ID";
                // Set Parameters of the sql Command text
                using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                {
                    // Set Parameters of the sql Command text
                    sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                    sqlCommand.Parameters["@ID"].Value = txtCustomerId.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    sqlCommand.Parameters["@Name"].Value = txtCustomerName.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                    sqlCommand.Parameters["@Address"].Value = txtCustomerAddress.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.VarChar));
                    sqlCommand.Parameters["@Contact"].Value = txtCustomerContact.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar));
                    sqlCommand.Parameters["@NIC"].Value = txtCustomerNIC.Text;

                    try
                    {
                        // Open database connection
                        dbConnection.Open();

                        // Execute the command
                        int result = sqlCommand.ExecuteNonQuery();

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

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicks on a cell that is not a header
            if (e.RowIndex >= 0)
            {
                // Get the current row
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                // Assign the cell values to the text fields
                txtCustomerId.Text = row.Cells[0].Value.ToString();
                txtCustomerName.Text = row.Cells[1].Value.ToString();
                txtCustomerAddress.Text = row.Cells[2].Value.ToString();
                txtCustomerContact.Text = row.Cells[3].Value.ToString();
                txtCustomerNIC.Text = row.Cells[3].Value.ToString();
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
                    sqlCommand.Parameters["@ID"].Value = txtCustomerId.Text;

                    try
                    {
                        // Open database connection
                        dbConnection.Open();

                        // Execute the command
                        int result = sqlCommand.ExecuteNonQuery();

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

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Create the connection object
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text with parameters                    
                    string sqlCommandText = "INSERT INTO Customer (ID,Name,Address,Contact,NIC) VALUES (@ID,@Name,@Address,@Contact,@NIC)";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        // Set Parameters of the sql Command text
                        sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar));
                        sqlCommand.Parameters["@ID"].Value = txtCustomerId.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Name"].Value = txtCustomerName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Address"].Value = txtCustomerAddress.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.VarChar));
                        sqlCommand.Parameters["@Contact"].Value = txtCustomerContact.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@NIC", SqlDbType.VarChar));
                        sqlCommand.Parameters["@NIC"].Value = txtCustomerNIC.Text;

                        try
                        {
                            // Open database connection
                            dbConnection.Open();

                            // Execute the command
                            int result = sqlCommand.ExecuteNonQuery();

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
    }
}
