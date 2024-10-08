﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders.CustomerController
{
    public partial class ManageOrderDetails : UserControl
    {
        private string _loggedInId;

        public ManageOrderDetails(string loggedInId)
        {
            InitializeComponent();
            _loggedInId = loggedInId;
        }

        private void ManageOrderDetails_Load(object sender, EventArgs e)
        {
            LoadCarOrderData();
            LoadCarPartOrderData();
        }

        private void LoadCarOrderData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarOrder table
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE cpo.CustomerId = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", _loggedInId);
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
                            // Set the datagrid view's datasource 
                            dgvCustomerCarOrderDetail.DataSource = carOrderDetailsTable;
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

        private void LoadCarPartOrderData()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(Properties.Settings.Default.ABC_Car_TradersConnectionString))
                {
                    // Command Text to select all data from the CarPartOrder table
                    string sqlCommandText = "SELECT cpo.*, c.Name AS CustomerName, c.Address AS CustomerAddress, c.Contact AS CustomerContact, c.NIC AS CustomerNIC FROM CarPartOrderDetails cpo INNER JOIN Customer c ON cpo.CustomerId = c.ID WHERE cpo.CustomerId = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandText, dbConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", _loggedInId);
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
                            // Set the datagrid view's datasource 
                            dgvCustomerCarPartOrderDetail.DataSource = carPartOrderDetailsTable;
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
