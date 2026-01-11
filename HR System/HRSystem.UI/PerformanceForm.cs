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
    public partial class PerformanceForm : Form
    {
        private readonly PerformanceService _performanceService = new PerformanceService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        private PerformanceService _service = new PerformanceService();
        public PerformanceForm()
        {
            InitializeComponent();
        }
        private void PerformanceForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadPerformance();
            numWorkQuality.ValueChanged += CalculateFinalScore;
            numAttendance.ValueChanged += CalculateFinalScore;
            numTeamwork.ValueChanged += CalculateFinalScore;
        }
        private void LoadEmployees()
        {
            cmbEmployee.DataSource = _employeeService.GetAllEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "ID";
        }
        private void num_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void CalculateFinalScore(object sender, EventArgs e)
        {

            decimal avg =
                (numWorkQuality.Value +
                 numAttendance.Value +
                 numTeamwork.Value) / 3;

            txtFinalScore.Text = avg.ToString("0.0");
        }
        private void ClearForm()
        {
            numWorkQuality.Value = 3;
            numAttendance.Value = 3;
            numTeamwork.Value = 3;
            txtNotes.Clear();
            txtFinalScore.Clear();
        }
        private void LoadPerformance()
        {
            var data = _performanceService.GetAllWithEmployeeAndDepartment()
                .Select(p => new
                {
                    EmployeeName = p.EmployeeName,
                    WorkQuality = p.WorkQuality,
                    Attendance = p.Attendance,
                    Teamwork = p.Teamwork,
                    FinalScore = p.FinalScore,
                    Notes = p.Notes,
                    EvaluationDate = p.EvaluationDate.ToString("yyyy-MM-dd")
                })
                .ToList();

            dgvPerformance.DataSource = data;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee");
                return;
            }

            try
            {
                var performance = new Performance
                {
                    EmployeeID = (int)cmbEmployee.SelectedValue,
                    WorkQuality = (int)numWorkQuality.Value,
                    Attendance = (int)numAttendance.Value,
                    Teamwork = (int)numTeamwork.Value,
                    FinalScore = decimal.Parse(txtFinalScore.Text),
                    Notes = txtNotes.Text.Trim(),
                    EvaluationDate = dtpEvaluationDate.Value.Date
                };

                _performanceService.AddPerformance(performance);

                MessageBox.Show("Performance saved successfully");

                LoadPerformance();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dgvPerformance_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            decimal score = Convert.ToDecimal(
                dgvPerformance.Rows[e.RowIndex].Cells["FinalScore"].Value);

            if (score >= 4)
                dgvPerformance.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            else if (score >= 2.5m)
                dgvPerformance.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            else
                dgvPerformance.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
        }
    }
}