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
using HRSystem.DAL;


using static System.Collections.Specialized.BitVector32;

namespace HRSystem.UI
{
    public partial class LeaveForm : Form
    {
        private readonly LeaveService _leaveService = new LeaveService();
        private readonly EmployeeRepository _empRepo = new EmployeeRepository();
        private int _employeeId;

   
        public LeaveForm(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }

        private void LeaveForm_Load(object sender, EventArgs e)
        {
            var emp = _empRepo.GetAll().Find(x => x.ID == _employeeId);
            lblEmployeeName.Text = emp.FullName;
            LoadMyLeaves();
        }

        private void btnRequestLeave_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("End date must be after start date");
                return;
            }

            int totalDays =
                (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;
            

            try
            {
                var leave = new Leave
                {
                    EmployeeID = _employeeId,
                    StartDate = dtpStartDate.Value.Date,
                    EndDate = dtpEndDate.Value.Date,
                    Reason = txtReason.Text.Trim(),
                    TotalDays = totalDays,
                    Status = "Pending"
                };


                _leaveService.RequestLeave(leave);

                MessageBox.Show("Leave request submitted successfully");

                LoadMyLeaves();
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvMyLeaves_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvMyLeaves.Rows[e.RowIndex];
            string status = row.Cells["Status"].Value?.ToString();

            if (status == "Approved")
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            else if (status == "Rejected")
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else if (status == "Pending")
                row.DefaultCellStyle.BackColor = Color.Khaki;
        }


        private void LoadMyLeaves()
        {
            var data = _leaveService.GetMyLeaves(_employeeId)
               .Select(l => new
               {
                From = l.StartDate.ToShortDateString(),
                To = l.EndDate.ToShortDateString(),
                Days = l.TotalDays,
                Reason = l.Reason,
                Status = l.Status,        
                AppliedAt = l.CreatedDate
               })
                .ToList();

            dgvMyLeaves.AutoGenerateColumns = true;
            dgvMyLeaves.DataSource = data;

        }
    }
}
