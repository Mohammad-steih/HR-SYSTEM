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
using HRSystem.DAL;
using HRSystem.Entities;
using ClosedXML.Excel;
using System.IO;


namespace HRSystem.UI
{
    public partial class EmployeeForm : Form
    {
        private EmployeeService _employeeService;
        private DepartmentService _departmentService;
        private EmployeeService _service = new EmployeeService();
        private EmployeeRepository _employeeRepo = new EmployeeRepository();
        private UserRepository _userRepo = new UserRepository();
        private int selectedEmployeeId = 0;



        public EmployeeForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            LoadDepartments();
            LoadEmployees();
        }

        private void LoadDepartments()
        {
            cmbDepartment.DataSource = _departmentService.GetAllDepartments();
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
        }

        private void LoadEmployees()
        {
            dgvEmployees.Columns.Clear();
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _service.GetAllEmployees();
            dgvEmployees.Columns["DepartmentID"].Visible = false;
            dgvEmployees.Columns["FullName"].Visible = false;

        }
        private void ClearForm()
        {
            txtNationalId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtSalary.Clear();
            txtLeaveDays.Clear();
            cmbDepartment.SelectedIndex = -1;
            selectedEmployeeId = 0;
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee
                {
                    NationalID = txtNationalId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    DepartmentID = (int)cmbDepartment.SelectedValue,
                    DepartmentName = cmbDepartment.Text, // ⭐ مهم
                    Salary = decimal.Parse(txtSalary.Text),
                    RemainingLeaveDays = int.Parse(txtLeaveDays.Text)
                };

                _employeeService.AddEmployee(emp);
                LoadEmployees();

                MessageBox.Show("Employee added successfully\nPassword: 123");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["ID"].Value);

                Employee emp = new Employee
                {
                    ID = selectedId,
                    NationalID = txtNationalId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    DepartmentID = (int)cmbDepartment.SelectedValue,
                    Salary = decimal.Parse(txtSalary.Text),
                    RemainingLeaveDays = int.Parse(txtLeaveDays.Text)
                };

                _employeeService.UpdateEmployee(emp);
                LoadEmployees();
                MessageBox.Show("Employee Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["ID"].Value);
                _employeeService.DeleteEmployee(id);
                LoadEmployees();
                MessageBox.Show("Employee Deleted");
            }
            var result = MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.Rows.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "Employee Report.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Employee Report");

                    for (int i = 0; i < dgvEmployees.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value =
                            dgvEmployees.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvEmployees.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value =
                                dgvEmployees.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file exported successfully ✅");
            }
        }


        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var emp = dgvEmployees.Rows[e.RowIndex].DataBoundItem as Employee;

            if (emp == null) return;

            selectedEmployeeId = emp.ID;

            txtNationalId.Text = emp.NationalID;
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.Phone;
            txtSalary.Text = emp.Salary.ToString();
            txtLeaveDays.Text = emp.RemainingLeaveDays.ToString();

            cmbDepartment.SelectedValue = emp.DepartmentID;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            
            dgvEmployees.AutoGenerateColumns = true;
            LoadEmployees();
        }

    }
}
