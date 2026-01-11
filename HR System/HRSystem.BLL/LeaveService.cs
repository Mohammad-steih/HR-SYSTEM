using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.Entities;
using MySqlX.XDevAPI;

namespace HRSystem.BLL
{
    public class LeaveService
    {
        private LeaveRepository _leaveRepo = new LeaveRepository();
        private EmployeeRepository _empRepo = new EmployeeRepository();

        // ======================
        // Employee side
        // ======================
        public List<LeaveApprovalDTO> GetLeavesForApproval()
        {
            return _leaveRepo.GetLeavesForApproval();
        }

        public void Approve(int leaveId, int employeeId, int days)
        {
            _leaveRepo.UpdateStatus(leaveId, "Approved");

            var emp = _empRepo.GetById(employeeId);
            emp.RemainingLeaveDays -= days;
            _empRepo.Update(emp);
        }

        public void Reject(int leaveId)
        {
            _leaveRepo.UpdateStatus(leaveId, "Rejected");
        }


        public void ApproveLeave(int leaveId, int employeeId, int days)
        {
            var leave = _leaveRepo.GetAll().First(l => l.ID == leaveId);

            if (leave.Status != "Pending")
                throw new Exception("This request is already processed");

            _leaveRepo.UpdateStatus(leaveId, "Approved");

            var emp = _empRepo.GetAll().First(e => e.ID == employeeId);
            emp.RemainingLeaveDays -= days;

            _empRepo.Update(emp);
        }

        public void RejectLeave(int leaveId)
        {
            var leave = _leaveRepo.GetAll().First(l => l.ID == leaveId);

            if (leave.Status != "Pending")
                throw new Exception("This request is already processed");

            _leaveRepo.UpdateStatus(leaveId, "Rejected");
        }


        public List<Leave> GetMyLeaves(int employeeId)
        {
            return _leaveRepo.GetByEmployee(employeeId);
        }
        public void RequestLeave(Leave l)
        {
            if (string.IsNullOrWhiteSpace(l.Reason))
                throw new Exception("Leave reason is required");

            l.TotalDays = (l.EndDate - l.StartDate).Days + 1;
            l.Status = "Pending";

            _leaveRepo.Add(l);
        }

        // ======================
        // Admin / HR side
        // ======================
        private readonly LeaveRepository _repo = new LeaveRepository();

        public List<Leave> GetAllLeaves()
        {
            return _leaveRepo.GetAll();
        }

        

        public List<Leave> GetAll()
        {
            return _repo.GetAll();
        }

        public int GetTotalLeaves()
        {
            return _repo.GetAll().Count;
        }

        public int GetTotalLeaveDays()
        {
            return _repo.GetAll()
                        .Sum(l => (l.StartDate - l.EndDate).Days + 1);
        }
        public List<LeaveReportDTO> GetLeaveReport()
        {
            return _leaveRepo.GetLeaveReport();
        }

        public List<LeaveReportDTO> FilterLeaveReport(
            int departmentId,
            string status,
            DateTime from,
            DateTime to)
        {
            var data = _leaveRepo.GetLeaveReport();

            if (departmentId != 0)
                data = data.Where(x => x.DepartmentID == departmentId).ToList();

            if (status != "All")
                data = data.Where(x => x.Status == status).ToList();

            data = data.Where(x =>
                x.FromDate.Date >= from.Date &&
                x.ToDate.Date <= to.Date).ToList();

            return data;
        }
    }


}

