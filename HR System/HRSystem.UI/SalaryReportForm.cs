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
using ClosedXML.Excel;
using System.IO;



namespace HRSystem.UI
{
    public partial class SalaryReportForm : Form
    {
        private readonly SalaryService _salaryService = new SalaryService();
        private readonly EmployeeService _employeeService = new EmployeeService();

        public SalaryReportForm()
        {
            InitializeComponent();
        }

        private void SalaryReportForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadReport();
            dgvSalaryReport.AutoGenerateColumns = true;

        }

        private void LoadEmployees()
        {
            cmbEmployee.DataSource = _employeeService.GetAllEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "ID";
            cmbEmployee.SelectedIndex = -1;
        }

        private void LoadReport(int? employeeId = null)
        {
            var data = _salaryService.GetSalaryReport(employeeId);

            dgvSalaryReport.AutoGenerateColumns = false;
            dgvSalaryReport.DataSource = null;
            dgvSalaryReport.DataSource = data;
            



            CalculateSummary(data);
        }

        private void CalculateSummary(List<SalaryReportDTO> data)
        {
            if (data.Count == 0)
            {
                txtTotalNet.Text = "0";
                txtAvgNet.Text = "0";
                return;
            }

            txtTotalNet.Text = data.Sum(x => x.NetSalary).ToString("0.00");
            txtAvgNet.Text = data.Average(x => x.NetSalary).ToString("0.00");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedItem == null)
                LoadReport();
            else
                LoadReport((int)cmbEmployee.SelectedValue);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            LoadReport();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvSalaryReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "Salary Report.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Salary Report");

                    for (int i = 0; i < dgvSalaryReport.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value =
                            dgvSalaryReport.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvSalaryReport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSalaryReport.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value =
                                dgvSalaryReport.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file exported successfully ✅");
            }
        }



    }
}
