﻿using ABC_Car_Traders.CustomerController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomerDashboard : Form
    {
        private string _loggedInEmail;

        public CustomerDashboard(string email)
        {
            InitializeComponent();
            _loggedInEmail = email;
            OrderCar orderCar = new OrderCar(_loggedInEmail);
            AddCustomerControl(orderCar);
        }

        private void AddCustomerControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            customerContainer.Controls.Clear();
            customerContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnOrderCar_Click(object sender, EventArgs e)
        {
            OrderCar orderCar = new OrderCar(_loggedInEmail);
            AddCustomerControl(orderCar);
        }

        private void btnOrderCarPart_Click(object sender, EventArgs e)
        {
            OrderCarPart orderCarPart = new OrderCarPart(_loggedInEmail);
            AddCustomerControl(orderCarPart);
        }

        private void btnManageOrderDetails_Click(object sender, EventArgs e)
        {
            ManageOrderDetails manageOrderDetails = new ManageOrderDetails(_loggedInEmail);
            AddCustomerControl(manageOrderDetails);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }
    }
}
