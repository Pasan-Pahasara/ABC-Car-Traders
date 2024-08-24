using ABC_Car_Traders.AdminController;
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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            DashBoard dashBoard = new DashBoard();
            AddAdminControl(dashBoard);
        }

        private void AddAdminControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            adminContainer.Controls.Clear();
            adminContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer();
            AddAdminControl(manageCustomer);
        }

        private void btnManageCar_Click(object sender, EventArgs e)
        {
            ManageCar manageCar = new ManageCar();
            AddAdminControl(manageCar);
        }

        private void btnManageCarPart_Click(object sender, EventArgs e)
        {
            ManageCarPartPart manageCarPart = new ManageCarPartPart();
            AddAdminControl(manageCarPart);
        }

        private void btnManageOrderDetails_Click(object sender, EventArgs e)
        {
            ManageOrderDetails manageOrderDetails = new ManageOrderDetails();
            AddAdminControl(manageOrderDetails);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            AddAdminControl(dashBoard);
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
