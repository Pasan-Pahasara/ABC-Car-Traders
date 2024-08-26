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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.FormClosed += (s, args) => this.Close();
            register.Show();
            this.Hide();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUserEmail.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                if (ValidateCustomerCredentials(email, password))
                {
                    OpenCustomerDashboard();
                }
                else if (ValidateAdminCredentials(email, password))
                {
                    OpenAdminDashboard();
                }
                else
                {
                    MessageBox.Show("Email or Password is incorrect!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing your request.\n\nDetails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCustomerCredentials(string email, string password)
        {
            string passPhrase = "customerpass";

            string sqlCommandText = "SELECT Email FROM Customer WHERE CONVERT(varchar,DecryptByPassphrase(@Passphrase, Password))=@Password AND Email = @Email";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                sqlCommand.Parameters["@Email"].Value = txtUserEmail.Text;

                sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                sqlCommand.Parameters["@Password"].Value = txtPassword.Text;

                sqlCommand.Parameters.Add(new SqlParameter("@Passphrase", SqlDbType.VarChar));
                sqlCommand.Parameters["@Passphrase"].Value = passPhrase;

                connection.Open();
                object result = sqlCommand.ExecuteScalar();
                return result != null;
            }
        }

        private bool ValidateAdminCredentials(string email, string password)
        {
            string sqlCommandText = "SELECT Email FROM Admin WHERE Password = @Password AND Email = @Email";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
            using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                sqlCommand.Parameters["@Email"].Value = txtUserEmail.Text;

                sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                sqlCommand.Parameters["@Password"].Value = txtPassword.Text;

                connection.Open();
                object result = sqlCommand.ExecuteScalar();
                return result != null;
            }
        }

        private void OpenCustomerDashboard()
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.FormClosed += (s, args) => this.Close();
            customerDashboard.Show();
            this.Hide();
        }

        private void OpenAdminDashboard()
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.FormClosed += (s, args) => this.Close();
            adminDashboard.Show();
            this.Hide();
        }
    }
}
