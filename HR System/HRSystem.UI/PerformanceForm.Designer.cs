namespace HRSystem.UI
{
    partial class PerformanceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.dtpEvaluationDate = new System.Windows.Forms.DateTimePicker();
            this.numWorkQuality = new System.Windows.Forms.NumericUpDown();
            this.numAttendance = new System.Windows.Forms.NumericUpDown();
            this.numTeamwork = new System.Windows.Forms.NumericUpDown();
            this.txtFinalScore = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(132, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Performance Evaluation";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(52, 45);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(121, 24);
            this.cmbEmployee.TabIndex = 1;
            // 
            // dtpEvaluationDate
            // 
            this.dtpEvaluationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEvaluationDate.Location = new System.Drawing.Point(52, 91);
            this.dtpEvaluationDate.Name = "dtpEvaluationDate";
            this.dtpEvaluationDate.Size = new System.Drawing.Size(109, 22);
            this.dtpEvaluationDate.TabIndex = 2;
            // 
            // numWorkQuality
            // 
            this.numWorkQuality.Location = new System.Drawing.Point(105, 135);
            this.numWorkQuality.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numWorkQuality.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkQuality.Name = "numWorkQuality";
            this.numWorkQuality.Size = new System.Drawing.Size(56, 22);
            this.numWorkQuality.TabIndex = 3;
            this.numWorkQuality.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numAttendance
            // 
            this.numAttendance.Location = new System.Drawing.Point(105, 168);
            this.numAttendance.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAttendance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAttendance.Name = "numAttendance";
            this.numAttendance.Size = new System.Drawing.Size(56, 22);
            this.numAttendance.TabIndex = 4;
            this.numAttendance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTeamwork
            // 
            this.numTeamwork.Location = new System.Drawing.Point(105, 196);
            this.numTeamwork.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTeamwork.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTeamwork.Name = "numTeamwork";
            this.numTeamwork.Size = new System.Drawing.Size(56, 22);
            this.numTeamwork.TabIndex = 5;
            this.numTeamwork.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtFinalScore
            // 
            this.txtFinalScore.Location = new System.Drawing.Point(84, 224);
            this.txtFinalScore.Name = "txtFinalScore";
            this.txtFinalScore.ReadOnly = true;
            this.txtFinalScore.Size = new System.Drawing.Size(77, 22);
            this.txtFinalScore.TabIndex = 6;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(67, 252);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(131, 72);
            this.txtNotes.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(52, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformance.Location = new System.Drawing.Point(205, 73);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.RowHeadersWidth = 51;
            this.dgvPerformance.RowTemplate.Height = 24;
            this.dgvPerformance.Size = new System.Drawing.Size(596, 378);
            this.dgvPerformance.TabIndex = 9;
            this.dgvPerformance.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPerformance_RowPrePaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 79);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEmployee);
            this.groupBox1.Controls.Add(this.dtpEvaluationDate);
            this.groupBox1.Controls.Add(this.numWorkQuality);
            this.groupBox1.Controls.Add(this.txtFinalScore);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.numAttendance);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.numTeamwork);
            this.groupBox1.Location = new System.Drawing.Point(1, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 376);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performance values";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Notes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Score";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Teamwork";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Attendance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Work Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Employee :";
            // 
            // PerformanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPerformance);
            this.Name = "PerformanceForm";
            this.Text = "PerformanceForm";
            this.Load += new System.EventHandler(this.PerformanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWorkQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DateTimePicker dtpEvaluationDate;
        private System.Windows.Forms.NumericUpDown numWorkQuality;
        private System.Windows.Forms.NumericUpDown numAttendance;
        private System.Windows.Forms.NumericUpDown numTeamwork;
        private System.Windows.Forms.TextBox txtFinalScore;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPerformance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}