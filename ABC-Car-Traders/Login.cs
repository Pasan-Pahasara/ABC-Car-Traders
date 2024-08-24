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
