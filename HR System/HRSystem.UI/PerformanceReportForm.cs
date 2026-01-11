using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using HRSystem.BLL;
using HRSystem.Entities;
using System.IO;


namespace HRSystem.UI
{

    public partial class PerformanceReportForm : Form
    {
        private readonly PerformanceService _performanceService = new PerformanceService();
        private List<Performance> _allPerformances;

        public PerformanceReportForm()
        {
            InitializeComponent();
        }

        private void PerformanceReportForm_Load(object sender, EventArgs e)
        {
            _allPerformances = _performanceService.GetAllWithEmployeeAndDepartment();
            LoadDepartments();
            ApplyFilter();
        }
        private void LoadDepartments()
        {
            var departments = new List<Department>();

            
            departments.Add(new Department
            {
                DepartmentID = 0,
                DepartmentName = "All Departments"
            });

         
            foreach (var p in _allPerformances)
            {
                if (!departments.Any(d => d.DepartmentID == p.DepartmentID))
                {
                    departments.Add(new Department
                    {
                        DepartmentID = p.DepartmentID,
                        DepartmentName = p.DepartmentName
                    });
                }
            }

            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentID";
        }

        private void LoadData()
        {
            _allPerformances = _performanceService.GetAllWithEmployeeAndDepartment();
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            if (cmbDepartment.SelectedValue == null)
                return;

            int deptId;
            if (!int.TryParse(cmbDepartment.SelectedValue.ToString(), out deptId))
                return;

            var filtered = _allPerformances
                .Where(p => deptId == 0 || p.DepartmentID == deptId)
                .Select(p => new
                {
                    Employee = p.EmployeeName,
                    Department = p.DepartmentName,
                    Score = p.FinalScore,
                    Date = p.EvaluationDate.ToShortDateString(),
                    Notes = p.Notes
                })
                .ToList();

            dgvPerformance.DataSource = filtered;
            LoadKPIs(filtered);
        }

        private void LoadKPIs(IEnumerable<dynamic> data)
        {
            if (!data.Any())
            {
                lblTopEmployee.Text = "Top Performer: -";
                lblLowEmployee.Text = "Lowest Performer: -";
                lblAvgScore.Text = "Average Score: -";
                return;
            }

            var ordered = data.OrderByDescending(x => x.Score).ToList();

            lblTopEmployee.Text = ordered.First().Employee;
            lblLowEmployee.Text = ordered.Last().Employee;
            lblAvgScore.Text =    ordered.Average(x => (decimal)x.Score).ToString("0.0");
                
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_allPerformances != null)
            //    ApplyFilter();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvPerformance.Rows.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "Performance Report.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Performance Report");

                   
                    for (int i = 0; i < dgvPerformance.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value =
                            dgvPerformance.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvPerformance.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvPerformance.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value =
                                dgvPerformance.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file exported successfully ✅");
            }
        }

    }
}
