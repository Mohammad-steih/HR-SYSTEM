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
    public partial class LeaveReportForm : Form
    {
        private LeaveService _leaveService = new LeaveService();
        private DepartmentRepository _deptRepo = new DepartmentRepository();
        private List<LeaveReportDTO> _allLeaves;



        public LeaveReportForm()
        {
            InitializeComponent();
        }
        private void LoadReport()
        {
            _allLeaves = _leaveService.GetLeaveReport();
            dgvLeaveReport.DataSource = _allLeaves;
        }


        private void LeaveReportForm_Load(object sender, EventArgs e)
        {
            LoadReport();
            LoadDepartments();

            
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Approved");
            cmbStatus.Items.Add("Rejected");
            cmbStatus.Items.Add("Pending");
            cmbStatus.SelectedIndex = 0;

        }
        private void dgvLeaveReport_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvLeaveReport.Rows[e.RowIndex];
            string status = row.Cells["Status"].Value.ToString();

            if (status == "Approved")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            else if (status == "Rejected")
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else if (status == "Pending")
                row.DefaultCellStyle.BackColor = Color.Khaki;
        }
        private void LoadDepartments()
        {
            var departments = _deptRepo.GetAll();

            
            departments.Insert(0, new Department
            {
                ID = 0,
                DepartmentName = "All"
            });

            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (_allLeaves == null || _allLeaves.Count == 0)
                return;

            int deptId = (int)cmbDepartment.SelectedValue;
            string status = cmbStatus.SelectedItem.ToString();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            var query = _allLeaves.AsEnumerable();

            if (deptId != 0)
                query = query.Where(x => x.DepartmentID == deptId);

            if (status != "All")
                query = query.Where(x => x.Status == status);

            query = query.Where(x =>
                x.FromDate.Date >= from &&
                x.ToDate.Date <= to);

            var result = query.ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("No records found for selected filters");
                return;
            }

            dgvLeaveReport.DataSource = result;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvLeaveReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "Leave Report.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("LeaveReport");

                    for (int i = 0; i < dgvLeaveReport.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value =
                            dgvLeaveReport.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvLeaveReport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvLeaveReport.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value =
                                dgvLeaveReport.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file exported successfully ✅");
            }
        }


    }
}
