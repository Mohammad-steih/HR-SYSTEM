using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRSystem.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HRSystem.UI
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService = new UserService();
        string selectedRole = "";

        public LoginForm()
        {
            InitializeComponent();
            MakeCircle(panelAdminCircle);
            MakeCircle(panelHrCircle);
            MakeCircle(panelEmployeeCircle);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            var user = _userService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            MainForm f = new MainForm(user.EmployeeID, user.Role);

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role");
                return;
            }

            if (user.Role != selectedRole)
            {
                MessageBox.Show("Role mismatch");
                return;
            }

            f.Show();
            this.Hide();

        }

        private void MakeCircle(Panel p)
        {
            p.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, p.Width - 1, p.Height - 1);
                p.Region = new Region(gp);
            };
        }
        private void SelectRole(string role)
        {
            selectedRole = role;

            panelAdminCircle.BackColor = Color.LightGray;
            panelHrCircle.BackColor = Color.LightGray;
            panelEmployeeCircle.BackColor = Color.LightGray;

            if (role == "Admin")
                panelAdminCircle.BackColor = Color.Green;
            else if (role == "HR")
                panelHrCircle.BackColor = Color.Green;
            else
                panelEmployeeCircle.BackColor = Color.Green;
        }

        private void panelAdminCircle_Click(object sender, EventArgs e)
        {
            SelectRole("Admin");
        }
        private void panelHrCircle_Click(object sender, EventArgs e)
        {
            SelectRole("HR");
        }
        private void panelEmployeeCircle_Click(object sender, EventArgs e)
        {
            SelectRole("Employee");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
