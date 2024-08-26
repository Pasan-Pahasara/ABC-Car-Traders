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

namespace ABC_Car_Traders
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
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
                            ClearCustomerFields();
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

        private void ClearCustomerFields()
        {
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerContact.Text = string.Empty;
            txtCustomerNIC.Text = string.Empty;
            txtCustomerEmail.Text = string.Empty;
            txtCustomerPassword.Text = string.Empty;
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
