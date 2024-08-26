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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            // Close the previous form when the new one is closed
            adminDashboard.FormClosed += (s, args) => this.Close();
            adminDashboard.Show();
            this.Hide();

            /* string passPhrase = "customerpass";
             try
             {
                 // Create the connection object
                 using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                 {
                     // Command Text with parameters
                     string sqlCommandText = "SELECT Email FROM Customer WHERE CONVERT(varchar,DecryptByPassphrase(@Passphrase, Password))=@Password AND Email = @Email";
                     using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                     {
                         // Set Parameters of the sql Command text
                             sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                             sqlCommand.Parameters["@Email"].Value = txtUserEmail.Text;

                             sqlCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                             sqlCommand.Parameters["@Password"].Value = txtPassword.Text;

                             sqlCommand.Parameters.Add(new SqlParameter("@Passphrase", SqlDbType.VarChar));
                             sqlCommand.Parameters["@Passphrase"].Value = passPhrase;

                         try
                         {
                             // Open database connection
                             dbConnection.Open();
                             // SQL adapter 
                             SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                             // Datatable
                             DataTable dataTable = new DataTable();
                             // Fill the datatable by executing the command
                             sqlAdapter.Fill(dataTable);
                             // Check the number of rows in the result datatable of the sql command
                             if (dataTable.Rows.Count == 1)
                             {
                                 // Open the User Home 
                                 AdminDashboard adminDashboard = new AdminDashboard();
                                 // Close the previous form when the new one is closed
                                 adminDashboard.FormClosed += (s, args) => this.Close();
                                 adminDashboard.Show();
                                 this.Hide();
                             }
                             else
                             {
                                 MessageBox.Show("UserEmail or Password is incorrect!");
                             }
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
             }*/
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.FormClosed += (s, args) => this.Close();
            register.Show();
            this.Hide();
        }
    }
}
