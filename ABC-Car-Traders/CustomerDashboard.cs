using ABC_Car_Traders.CustomerController;
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
        public CustomerDashboard()
        {
            InitializeComponent();
            OrderCar orderCar = new OrderCar();
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
            OrderCar orderCar = new OrderCar();
            AddCustomerControl(orderCar);
        }

        private void btnOrderCarPart_Click(object sender, EventArgs e)
        {
            OrderCarPart orderCarPart = new OrderCarPart();
            AddCustomerControl(orderCarPart);
        }

        private void btnManageOrderDetails_Click(object sender, EventArgs e)
        {
            ManageOrderDetails manageOrderDetails = new ManageOrderDetails();
            AddCustomerControl(manageOrderDetails);
        }
    }
}
