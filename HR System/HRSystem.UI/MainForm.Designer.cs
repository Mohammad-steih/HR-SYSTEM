namespace HRSystem.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLeaves = new System.Windows.Forms.Button();
            this.btnPerformance = new System.Windows.Forms.Button();
            this.btnSalaries = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelLeavesSubMenu = new System.Windows.Forms.Panel();
            this.btnMyLeaves = new System.Windows.Forms.Button();
            this.btnLeaveApprovals = new System.Windows.Forms.Button();
            this.panelReportsSubMenu = new System.Windows.Forms.Panel();
            this.btnSalaryReport = new System.Windows.Forms.Button();
            this.btnPerformanceReport = new System.Windows.Forms.Button();
            this.btnLeaveReport = new System.Windows.Forms.Button();
            this.panelToast = new System.Windows.Forms.Panel();
            this.lblToastMessage = new System.Windows.Forms.Label();
            this.lblToastTitle = new System.Windows.Forms.Label();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.labelMsg = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelLeavesSubMenu.SuspendLayout();
            this.panelReportsSubMenu.SuspendLayout();
            this.panelToast.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnDepartments);
            this.panelMenu.Controls.Add(this.btnReports);
            this.panelMenu.Controls.Add(this.btnLeaves);
            this.panelMenu.Controls.Add(this.btnPerformance);
            this.panelMenu.Controls.Add(this.btnSalaries);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 642);
            this.panelMenu.TabIndex = 1;
            // 
            // btnEmployees
            // 
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEmployees.ImageKey = "(none)";
            this.btnEmployees.Location = new System.Drawing.Point(30, 118);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(132, 33);
            this.btnEmployees.TabIndex = 4;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.RosyBrown;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(30, 597);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(132, 33);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDepartments
            // 
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDepartments.Location = new System.Drawing.Point(30, 200);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(132, 33);
            this.btnDepartments.TabIndex = 5;
            this.btnDepartments.Text = "Departments";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReports.Location = new System.Drawing.Point(30, 523);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(132, 33);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLeaves
            // 
            this.btnLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaves.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLeaves.Location = new System.Drawing.Point(30, 285);
            this.btnLeaves.Name = "btnLeaves";
            this.btnLeaves.Size = new System.Drawing.Size(132, 33);
            this.btnLeaves.TabIndex = 6;
            this.btnLeaves.Text = "Leaves";
            this.btnLeaves.UseVisualStyleBackColor = true;
            this.btnLeaves.Click += new System.EventHandler(this.btnLeaves_Click);
            // 
            // btnPerformance
            // 
            this.btnPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPerformance.Location = new System.Drawing.Point(30, 442);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(132, 33);
            this.btnPerformance.TabIndex = 8;
            this.btnPerformance.Text = "Performance";
            this.btnPerformance.UseVisualStyleBackColor = true;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            // 
            // btnSalaries
            // 
            this.btnSalaries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalaries.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalaries.Location = new System.Drawing.Point(30, 364);
            this.btnSalaries.Name = "btnSalaries";
            this.btnSalaries.Size = new System.Drawing.Size(132, 33);
            this.btnSalaries.TabIndex = 7;
            this.btnSalaries.Text = "Salaries";
            this.btnSalaries.UseVisualStyleBackColor = true;
            this.btnSalaries.Click += new System.EventHandler(this.btnSalaries_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblAppName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1168, 100);
            this.panelHeader.TabIndex = 2;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Bodoni MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(740, 14);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(237, 48);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "HR SYSTEM";
            // 
            // panelLeavesSubMenu
            // 
            this.panelLeavesSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelLeavesSubMenu.Controls.Add(this.btnMyLeaves);
            this.panelLeavesSubMenu.Controls.Add(this.btnLeaveApprovals);
            this.panelLeavesSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeavesSubMenu.Location = new System.Drawing.Point(200, 100);
            this.panelLeavesSubMenu.Name = "panelLeavesSubMenu";
            this.panelLeavesSubMenu.Size = new System.Drawing.Size(1168, 100);
            this.panelLeavesSubMenu.TabIndex = 3;
            this.panelLeavesSubMenu.Visible = false;
            // 
            // btnMyLeaves
            // 
            this.btnMyLeaves.Location = new System.Drawing.Point(146, 41);
            this.btnMyLeaves.Name = "btnMyLeaves";
            this.btnMyLeaves.Size = new System.Drawing.Size(101, 30);
            this.btnMyLeaves.TabIndex = 11;
            this.btnMyLeaves.Text = "My Leave";
            this.btnMyLeaves.UseVisualStyleBackColor = true;
            this.btnMyLeaves.Click += new System.EventHandler(this.btnMyLeaves_Click);
            // 
            // btnLeaveApprovals
            // 
            this.btnLeaveApprovals.Location = new System.Drawing.Point(355, 41);
            this.btnLeaveApprovals.Name = "btnLeaveApprovals";
            this.btnLeaveApprovals.Size = new System.Drawing.Size(115, 30);
            this.btnLeaveApprovals.TabIndex = 12;
            this.btnLeaveApprovals.Text = "Leave Approval";
            this.btnLeaveApprovals.UseVisualStyleBackColor = true;
            this.btnLeaveApprovals.Click += new System.EventHandler(this.btnLeaveApprovals_Click);
            // 
            // panelReportsSubMenu
            // 
            this.panelReportsSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelReportsSubMenu.Controls.Add(this.btnSalaryReport);
            this.panelReportsSubMenu.Controls.Add(this.btnPerformanceReport);
            this.panelReportsSubMenu.Controls.Add(this.btnLeaveReport);
            this.panelReportsSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReportsSubMenu.Location = new System.Drawing.Point(200, 200);
            this.panelReportsSubMenu.Name = "panelReportsSubMenu";
            this.panelReportsSubMenu.Size = new System.Drawing.Size(1168, 100);
            this.panelReportsSubMenu.TabIndex = 4;
            this.panelReportsSubMenu.Visible = false;
            // 
            // btnSalaryReport
            // 
            this.btnSalaryReport.Location = new System.Drawing.Point(69, 36);
            this.btnSalaryReport.Name = "btnSalaryReport";
            this.btnSalaryReport.Size = new System.Drawing.Size(106, 30);
            this.btnSalaryReport.TabIndex = 13;
            this.btnSalaryReport.Text = "Salary Report";
            this.btnSalaryReport.UseVisualStyleBackColor = true;
            this.btnSalaryReport.Click += new System.EventHandler(this.btnSalaryReport_Click);
            // 
            // btnPerformanceReport
            // 
            this.btnPerformanceReport.Location = new System.Drawing.Point(245, 36);
            this.btnPerformanceReport.Name = "btnPerformanceReport";
            this.btnPerformanceReport.Size = new System.Drawing.Size(136, 30);
            this.btnPerformanceReport.TabIndex = 14;
            this.btnPerformanceReport.Text = "Performance Report";
            this.btnPerformanceReport.UseVisualStyleBackColor = true;
            this.btnPerformanceReport.Click += new System.EventHandler(this.btnPerformanceReport_Click);
            // 
            // btnLeaveReport
            // 
            this.btnLeaveReport.Location = new System.Drawing.Point(442, 36);
            this.btnLeaveReport.Name = "btnLeaveReport";
            this.btnLeaveReport.Size = new System.Drawing.Size(122, 30);
            this.btnLeaveReport.TabIndex = 15;
            this.btnLeaveReport.Text = "Leave Report";
            this.btnLeaveReport.UseVisualStyleBackColor = true;
            this.btnLeaveReport.Click += new System.EventHandler(this.btnLeaveReport_Click);
            // 
            // panelToast
            // 
            this.panelToast.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelToast.Controls.Add(this.labelMsg);
            this.panelToast.Controls.Add(this.lblToastMessage);
            this.panelToast.Controls.Add(this.lblToastTitle);
            this.panelToast.Location = new System.Drawing.Point(884, 395);
            this.panelToast.Name = "panelToast";
            this.panelToast.Size = new System.Drawing.Size(377, 90);
            this.panelToast.TabIndex = 6;
            // 
            // lblToastMessage
            // 
            this.lblToastMessage.AutoSize = true;
            this.lblToastMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblToastMessage.ForeColor = System.Drawing.Color.White;
            this.lblToastMessage.Location = new System.Drawing.Point(95, 30);
            this.lblToastMessage.Name = "lblToastMessage";
            this.lblToastMessage.Size = new System.Drawing.Size(39, 17);
            this.lblToastMessage.TabIndex = 1;
            this.lblToastMessage.Text = "MSG";
            // 
            // lblToastTitle
            // 
            this.lblToastTitle.AutoSize = true;
            this.lblToastTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblToastTitle.ForeColor = System.Drawing.Color.White;
            this.lblToastTitle.Location = new System.Drawing.Point(23, 30);
            this.lblToastTitle.Name = "lblToastTitle";
            this.lblToastTitle.Size = new System.Drawing.Size(66, 17);
            this.lblToastTitle.TabIndex = 0;
            this.lblToastTitle.Text = "Welcome";
            // 
            // toastTimer
            // 
            this.toastTimer.Interval = 3000;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.ForeColor = System.Drawing.Color.White;
            this.labelMsg.Location = new System.Drawing.Point(35, 64);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(37, 16);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = "MSG";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 642);
            this.Controls.Add(this.panelToast);
            this.Controls.Add(this.panelReportsSubMenu);
            this.Controls.Add(this.panelLeavesSubMenu);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeavesSubMenu.ResumeLayout(false);
            this.panelReportsSubMenu.ResumeLayout(false);
            this.panelToast.ResumeLayout(false);
            this.panelToast.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Panel panelLeavesSubMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLeaves;
        private System.Windows.Forms.Button btnPerformance;
        private System.Windows.Forms.Button btnSalaries;
        private System.Windows.Forms.Button btnMyLeaves;
        private System.Windows.Forms.Button btnLeaveApprovals;
        private System.Windows.Forms.Panel panelReportsSubMenu;
        private System.Windows.Forms.Button btnSalaryReport;
        private System.Windows.Forms.Button btnPerformanceReport;
        private System.Windows.Forms.Button btnLeaveReport;
        private System.Windows.Forms.Panel panelToast;
        private System.Windows.Forms.Label lblToastTitle;
        private System.Windows.Forms.Label lblToastMessage;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Label labelMsg;
    }
}