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
    }
}
