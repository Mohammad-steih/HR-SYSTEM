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
    public partial class LeaveApprovalForm : Form
    {
        private LeaveService _service = new LeaveService();
        private LeaveService _leaveService = new LeaveService();


        private void LeaveApprovalForm_Load(object sender, EventArgs e)
        {
            LoadLeaves();
            dgvAllLeaves.Columns["LeaveID"].Visible = false;
            dgvAllLeaves.Columns["EmployeeID"].Visible = false;

            dgvAllLeaves.EnableHeadersVisualStyles = false;
            dgvAllLeaves.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvAllLeaves.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }

        public LeaveApprovalForm()
        {
            InitializeComponent();
        }

        private void LoadLeaves()
        {
            var data = _service.GetLeavesForApproval();
            dgvAllLeaves.DataSource = data;


        }
        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvAllLeaves.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();

                if (status == "Approved")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Rejected")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
        }


        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvAllLeaves.SelectedRows.Count == 0)
                return;

            var row = (LeaveApprovalDTO)dgvAllLeaves.SelectedRows[0].DataBoundItem;

            if (row.Status != "Pending")
            {
                MessageBox.Show(
                    "This request has already been processed and cannot be changed.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            _service.Approve(row.LeaveID, row.EmployeeID, row.TotalDays);
            LoadLeaves();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvAllLeaves.SelectedRows.Count == 0)
                return;

            var row = (LeaveApprovalDTO)dgvAllLeaves.SelectedRows[0].DataBoundItem;

            if (row.Status != "Pending")
            {
                MessageBox.Show(
                    "This request has already been processed and cannot be changed.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            _leaveService.RejectLeave(row.LeaveID);
            LoadLeaves();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaves();
        }

        private void dgvAllLeaves_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAllLeaves.Columns[e.ColumnIndex].Name == "Status")
            {
                string status = e.Value?.ToString();

                if (status == "Approved")
                {
                    e.CellStyle.BackColor = Color.FromArgb(46, 204, 113);
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (status == "Rejected")
                {
                    e.CellStyle.BackColor = Color.FromArgb(231, 76, 60);
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (status == "Pending")
                {
                    e.CellStyle.BackColor = Color.FromArgb(241, 196, 15);
                    e.CellStyle.ForeColor = Color.Black;
                }
            }


        }
    }
}
