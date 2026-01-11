using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRSystem.DAL;
using HRSystem.Entities;

namespace HRSystem.UI
{
    public partial class MainForm : Form
    {
        private int _userId;
        private string _role;
        private EmployeeRepository _empRepo = new EmployeeRepository();
        private Employee _currentEmployee;



        public MainForm(int userId, string role)
        {
            InitializeComponent();
            _userId = userId;
            _role = role;
          
        }
        private void HideAllSubMenus()
        {
            panelLeavesSubMenu.Visible = false;
            panelReportsSubMenu.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelLeavesSubMenu.Visible = false;
            panelReportsSubMenu.Visible = false;
            _currentEmployee = _empRepo.GetById(_userId);

            ShowWelcomeToast(_currentEmployee.FullName, _role);



            if (_role == "Employee")
            {
                btnEmployees.Visible = false;
                btnDepartments.Visible = false;
                btnSalaries.Visible = false;
                btnPerformance.Visible = false;

                btnReports.Visible = false;        
                panelReportsSubMenu.Visible = false;

                btnLeaveApprovals.Visible = false; 
            }

        }

        private void OpenForm(Form form)
        {
            foreach (Form f in this.MdiChildren)
                f.Close();

            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void ShowWelcomeToast(string name, string role)
        {
            lblToastTitle.Text = " 👋 Welcome ";
            lblToastMessage.Text = $"{name} - Logged in as {role}";
               labelMsg.Text=      $"Have a successful and productive work day";

            panelToast.Visible = true;
            panelToast.BringToFront();

            if (_role == "Admin")
                panelToast.BackColor = Color.FromArgb(231, 76, 60);
            else if (_role == "HR")
                panelToast.BackColor = Color.FromArgb(52, 152, 219);
            else
                panelToast.BackColor = Color.FromArgb(52, 152, 219);

            toastTimer.Start();
        }
        private void toastTimer_Tick(object sender, EventArgs e)
        {
            panelToast.Visible = false;
            toastTimer.Stop();
        }



        // ===== Main Buttons =====

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenForm(new EmployeeForm());
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            OpenForm(new DepartmentForm());
        }

        private void btnSalaries_Click(object sender, EventArgs e)
        {
            OpenForm(new SalaryForm());
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            OpenForm(new PerformanceForm());
        }

        // ===== Leaves =====

        private void btnLeaves_Click(object sender, EventArgs e)
        {
            panelLeavesSubMenu.Visible = !panelLeavesSubMenu.Visible;
            panelReportsSubMenu.Visible = false;
        }

        private void btnMyLeaves_Click(object sender, EventArgs e)
        {
            OpenForm(new LeaveForm(_userId));
        }

        private void btnLeaveApprovals_Click(object sender, EventArgs e)
        {
            OpenForm(new LeaveApprovalForm());
        }

        // ===== Reports =====

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelReportsSubMenu.Visible = !panelReportsSubMenu.Visible;
            panelLeavesSubMenu.Visible = false;
        }

        private void btnSalaryReport_Click(object sender, EventArgs e)
        {
            OpenForm(new SalaryReportForm());
        }

        private void btnLeaveReport_Click(object sender, EventArgs e)
        {
            OpenForm(new LeaveReportForm());
        }

        private void btnPerformanceReport_Click(object sender, EventArgs e)
        {
            OpenForm(new PerformanceReportForm());
        }

        // ===== Logout =====

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


    }

}
