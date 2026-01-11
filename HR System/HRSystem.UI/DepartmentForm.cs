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
    public partial class DepartmentForm : Form
    {
       
        private DepartmentService _service = new DepartmentService();

        public DepartmentForm()
        {
            InitializeComponent();
            _service = new DepartmentService();
            LoadDepartments();
            

        }

        private void LoadDepartments()
        {
            dgvDepartments.DataSource = null;
            dgvDepartments.AutoGenerateColumns = true;
            dgvDepartments.DataSource = _service.GetAll();


            dgvDepartments.Columns["DepartmentID"].Visible = false;
            dgvDepartments.Columns["CreatedDate"].Visible = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked");

            if (string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("Please enter department name");
                return;
            }

            Department d = new Department
            {
                DepartmentName = txtDeptName.Text.Trim()
            };

            _service.Add(d);

            LoadDepartments();
            txtDeptName.Clear();
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDepartments.Rows[e.RowIndex];

            txtDeptName.Text = row.Cells["DepartmentName"].Value.ToString();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["ID"].Value);
            _service.Update(new Department { ID = id, DepartmentName = txtDeptName.Text });
            LoadDepartments();
            MessageBox.Show("Department Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["ID"].Value);
            _service.Delete(id);
            LoadDepartments();
            MessageBox.Show("Department Deleted");
        }
    
        private void DepartmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
