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
using HRSystem.Entities;

namespace HRSystem.UI
{
    public partial class SalaryForm : Form
    {
        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly SalaryService _salaryService = new SalaryService();

        public SalaryForm()
        {
            InitializeComponent();
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;

        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {
            var employees = _employeeService.GetAllEmployees();

            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "ID";

            cmbEmployee.SelectedIndex = -1;   
            LoadEmployees();
            LoadSalaries();
        }

        private void LoadEmployees()
        {
            cmbEmployee.DataSource = _employeeService.GetAllEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "ID";
            cmbEmployee.SelectedIndex = 0;
        }

        private void LoadSalaries()
        {
            dgvSalary.DataSource = null;
            dgvSalary.DataSource = _salaryService.GetAll();
        }
        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedItem == null)
                return;

            Employee emp = cmbEmployee.SelectedItem as Employee;

            if (emp == null)
                return;

            txtBaseSalary.Text = emp.Salary.ToString("0.00");

            CalculateSalary();
        }


        private void txtBonus_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void txtDeduction_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            if (cmbEmployee.SelectedIndex == -1)
            {
                txtBaseSalary.Text = "";
                txtNetSalary.Text = "";
                return;
            }

            var emp = cmbEmployee.SelectedItem as Employee;
            if (emp == null) return;


            decimal baseSalary = 0;
            decimal bonus = 0;
            decimal deduction = 0;

            decimal.TryParse(txtBonus.Text, out bonus);
            decimal.TryParse(txtDeduction.Text, out deduction);

            txtBaseSalary.Text = emp.Salary.ToString("0.00");
            txtNetSalary.Text = (emp.Salary + bonus - deduction).ToString("0.00");

            this.txtBonus.TextChanged += SalaryFields_TextChanged;
            this.txtDeduction.TextChanged += SalaryFields_TextChanged;

            
            

            decimal.TryParse(txtBaseSalary.Text, out baseSalary);
            decimal.TryParse(txtBonus.Text, out bonus);
            decimal.TryParse(txtDeduction.Text, out deduction);

            txtNetSalary.Text = (baseSalary + bonus - deduction).ToString("0.00");
        }

        private void SalaryFields_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee");
                return;
            }

            var emp = cmbEmployee.SelectedItem as Employee;

            var salary = new Salary
            {
                EmployeeID = emp.ID,
                BaseSalary = emp.Salary,
                Bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : decimal.Parse(txtBonus.Text),
                Deduction = string.IsNullOrEmpty(txtDeduction.Text) ? 0 : decimal.Parse(txtDeduction.Text),
                NetSalary = decimal.Parse(txtNetSalary.Text)
            };

            try
            {
                _salaryService.AddSalary(salary);
                MessageBox.Show("Salary added successfully");
                ClearForm();
                LoadSalaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ClearForm()
        {
            cmbEmployee.SelectedIndex = -1;
            txtBaseSalary.Text = "";
            txtBonus.Text = "";
            txtDeduction.Text = "";
            txtNetSalary.Text = "";
        }
    
        
    }
}
