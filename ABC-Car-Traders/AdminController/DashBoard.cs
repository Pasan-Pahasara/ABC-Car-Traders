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

namespace ABC_Car_Traders.AdminController
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            CountAllCars();
            CountAllCustomers();
            CountAllCarParts();
            CountAllCarOrders();
            CountAllCarPartOrders();
            CountDailyCarOrders();
            CountDailyCarPartOrders();
        }

        private void CountAllCars()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count all cars
                    string sqlCommandText = "SELECT COUNT(*) AS TotalCars FROM Car";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int totalCars = (int)sqlCommand.ExecuteScalar();

                            // Show the total number of cars
                           lblTotalCars.Text = totalCars.ToString();
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

        private void CountAllCustomers()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count all customers
                    string sqlCommandText = "SELECT COUNT(*) AS TotalCustomers FROM Customer";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int totalCustomers = (int)sqlCommand.ExecuteScalar();

                            // Show the total number of customers
                            lblTotalCustomers.Text = totalCustomers.ToString();
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

        private void CountAllCarParts()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count all car parts
                    string sqlCommandText = "SELECT COUNT(*) AS TotalCarParts FROM CarPart";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int totalCarParts = (int)sqlCommand.ExecuteScalar();

                            // Show the total number of car parts
                            lblTotalCarParts.Text = totalCarParts.ToString();
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

        private void CountAllCarOrders()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count all car orders
                    string sqlCommandText = "SELECT COUNT(*) AS TotalCarOrders FROM CarOrder";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int totalCarOrders = (int)sqlCommand.ExecuteScalar();

                            // Show the total number of car orders
                            lblTotalCarOrders.Text = totalCarOrders.ToString();
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

        private void CountAllCarPartOrders()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count all car part orders
                    string sqlCommandText = "SELECT COUNT(*) AS TotalCarPartOrders FROM CarPartOrder";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int totalCarPartOrders = (int)sqlCommand.ExecuteScalar();

                            // Show the total number of car part orders
                            lblTotalCarPartOrders.Text = totalCarPartOrders.ToString();
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

        private void CountDailyCarOrders()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count daily orders
                    string sqlCommandText = "SELECT COUNT(*) AS DailyOrders FROM CarOrder WHERE OrderDate >= CAST(GETDATE() AS DATE) AND OrderDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int dailyCarOrders = (int)sqlCommand.ExecuteScalar();

                            // Show the daily number of orders
                            lblDailyCarOrders.Text = dailyCarOrders.ToString();
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

        private void CountDailyCarPartOrders()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // SQL query to count weekly orders
                    string sqlCommandText = "SELECT COUNT(*) AS DailyOrders FROM CarPartOrder WHERE OrderDate >= CAST(GETDATE() AS DATE) AND OrderDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        try
                        {
                            // Open database connection
                            dbConnection.Open();
                            // Execute the query and get the count
                            int dailyCarPartOrders = (int)sqlCommand.ExecuteScalar();

                            // Show the weekly number of orders
                            lblDailyCarPartOrders.Text = dailyCarPartOrders.ToString();
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

    }
}
