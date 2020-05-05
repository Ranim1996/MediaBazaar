using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar.Classes;

namespace Media_Bazaar
{
    public partial class AssignShift : Form
    {
        DataAccess db;
        Schedule schedule = new Schedule();
        List<Schedule> dbSchedules = null;
        DateTime shiftDate;

        public AssignShift(DateTime date, MainAdmin main)
        {
            InitializeComponent();
            shiftDate = date;
            db = new DataAccess();
       
            tbDate.Text = $"{date.Day}/{date.Month}/{date.Year}, {date.DayOfWeek}";
            this.Text = $"Assign shift on date: {tbDate.Text}";

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                cmbBxWorkShiftSunday.Visible = true;
                cmbBxWorkShiftSaturday.Visible = false;
                cmbBxWorkShiftWeekDay.Visible = false;
            }
            else
            {
                if(date.DayOfWeek == DayOfWeek.Saturday)
                {
                    cmbBxWorkShiftSaturday.Visible = true;
                    cmbBxWorkShiftSunday.Visible = false;
                    cmbBxWorkShiftWeekDay.Visible = false;
                }
                else
                {
                    cmbBxWorkShiftWeekDay.Visible = true;
                    cmbBxWorkShiftSaturday.Visible = false;
                    cmbBxWorkShiftSunday.Visible = false;
                }
            }
        }
        private void AssignShift_Load(object sender, EventArgs e)
        {
            UpdateList();
            UpdatePreferencesList();
            UpdateAbsenceList();
        }
        private void UpdateList()
        {
            lbShifts.Items.Clear();
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;
            foreach (Schedule sch in dbSchedules)
            {
                string firstNameOfEmployee = db.GetFirstNameOfEmployeeById(sch.EmployeeId);
                if(sch.Date == shiftDate.ToString("dd/MM/yyyy") && sch.Status == "Assigned")
                {
                    if (sch.Attendance != null)
                    {
                        lbShifts.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift} -> {sch.Attendance}");
                    }
                    else
                    {
                        lbShifts.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift}");
                    }
                }         
            }
        }
        private void UpdatePreferencesList()
        {
            lbShiftPreferences.Items.Clear();
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;
            foreach (Schedule sch in dbSchedules)
            {
                string firstNameOfEmployee = db.GetFirstNameOfEmployeeById(sch.EmployeeId);
                if (sch.Date == shiftDate.ToString("dd/MM/yyyy") && sch.Status == "Selected")
                {
                    if (sch.Attendance != null)
                    {
                        lbShiftPreferences.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift} -> {sch.Attendance}");
                    }
                    else
                    {
                        lbShiftPreferences.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift}");
                    }
                }
            }
        }
        private void btnAssignWorkShift_Click(object sender, EventArgs e)
        {
            int employeeId = -1;
            string date = "";
            string shift = "";
            if (tbEmployeeIdAssignShift.Text != "" && (cmbBxWorkShiftSaturday.SelectedItem != null || cmbBxWorkShiftSunday.SelectedItem != null || cmbBxWorkShiftWeekDay.SelectedItem != null))
            {
                employeeId = Convert.ToInt32(tbEmployeeIdAssignShift.Text);
                date = shiftDate.ToString("dd/MM/yyyy");
                if (shiftDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    shift = "12:00-18:00";
                }
                else
                {
                    if (shiftDate.DayOfWeek == DayOfWeek.Saturday && cmbBxWorkShiftSaturday.SelectedItem.ToString() == "Morning -> 09:00-15:00")
                    {
                        shift = "09:00-15:00";
                    }
                    else
                    {
                        if (shiftDate.DayOfWeek == DayOfWeek.Saturday && cmbBxWorkShiftSaturday.SelectedItem.ToString() == "Afternoon -> 15:00-18:00")
                        {
                            shift = "15:00-18:00";
                        }
                        else
                        {
                            if (cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Morning -> 07:00-12:00")
                            {
                                shift = "07:00-12:00";
                            }
                            else
                            {
                                if (cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Afternoon -> 12:00-17:00")
                                {
                                    shift = "12:00-17:00";
                                }
                                else
                                {
                                    if (cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Evening -> 17:00-22:00")
                                    {
                                        shift = "17:00-22:00";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (employeeId != -1 && date != "" && shift != "")
            {
                db = new DataAccess();
                List<IEmployeeModel> empl = db.GetDBNotFiredEmployeeByID(employeeId);
                if (empl.Count != 0)
                {
                    //inserting in the db
                    db.AddSchedule(employeeId, date, shift);
                    UpdateList();
                }
                else
                {
                    MessageBox.Show("No employee found with the specified ID. He may be fired.");
                }

            }
        }

        private void AddAttendance(string attendance)
        {
            string holder = "";
            string date = shiftDate.ToString("dd/MM/yyyy");
            db = new DataAccess();
            schedule = new Schedule();
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;
            if (lbShifts.SelectedItem != null)
            {
                holder = lbShifts.SelectedItem.ToString();
                foreach (Schedule sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        db.AddAttendanceForEmployeeByIdAndShift(sch.EmployeeId, attendance, sch.Shift, date);
                        UpdateList();
                        break;
                    }
                }
            }
        }
        private void btnPresent_Click(object sender, EventArgs e)
        {
            string attendance = "PRESENT";
            AddAttendance(attendance);
        }

        private void btnLate_Click(object sender, EventArgs e)
        {
            string attendance = "LATE";
            AddAttendance(attendance);
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            string attendance = "ABSENT";
            AddAttendance(attendance);
        }

        private void lbItem_DoubleClick(object sender, EventArgs e)
        {
            string holder = "";
            string status = "Assigned";
            string date = shiftDate.ToString("dd/MM/yyyy");

            //schedule.GetAllSchedules();
            //dbSchedules = schedule.allSchedules;

            if (lbShifts.SelectedItem != null)
            {
                holder = lbShifts.SelectedItem.ToString();
                foreach(Schedule sch in dbSchedules)
                {
                    if(holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Are you sure that you want to delete this shift? ID({sch.EmployeeId}): {sch.Shift}", "Warning!", MessageBoxButtons.YesNo);
                        if(dialogResult == DialogResult.Yes)
                        {
                            db.DeleteAttendanceByIdAndShift(sch.EmployeeId, sch.Shift, date, status);
                            MessageBox.Show("Shift has been successfully removed!");
                            UpdateList();
                        }
                        else //if(dialogResult == DialogResult.No)
                        {
                            //do nothing 
                        }
                        break;
                    }
                }
            }
        }

        private void lbShiftPreferences_DoubleClick(object sender, EventArgs e)
        {
            string holder = "";
            string status = "Selected";
            string date = shiftDate.ToString("dd/MM/yyyy");

            //schedule.GetAllSchedules();
            //dbSchedules = schedule.allSchedules;

            if (lbShiftPreferences.SelectedItem != null)
            {
                holder = lbShiftPreferences.SelectedItem.ToString();
                foreach (Schedule sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Are you sure that you want to delete this shift? ID({sch.EmployeeId}): {sch.Shift}", "Warning!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.DeleteAttendanceByIdAndShift(sch.EmployeeId, sch.Shift, date, status);
                            MessageBox.Show("Shift has been successfully removed!");
                            UpdatePreferencesList();
                        }
                        else //if(dialogResult == DialogResult.No)
                        {
                            //do nothing 
                        }
                        break;
                    }
                }
            }
        }

        private void btnAssignSelectedShift_Click(object sender, EventArgs e)
        {
            string holder = "";
            string date = shiftDate.ToString("dd/MM/yyyy");

            if (lbShiftPreferences.SelectedItem != null)
            {
                holder = lbShiftPreferences.SelectedItem.ToString();
                foreach (Schedule sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Are you sure that you want to assign this shift? ID({sch.EmployeeId}): {sch.Shift}", "Warning!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.AssignShift(sch.EmployeeId, sch.Shift, date);
                            MessageBox.Show("Shift has been successfully assigned!");
                            UpdatePreferencesList();
                            UpdateList();
                        }
                        else //if(dialogResult == DialogResult.No)
                        {
                            //do nothing 
                        }
                        break;
                    }
                }
            }
        }

        private void UpdateAbsenceList()
        {
            this.lbxAbsenceRecods.Items.Clear();
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;
            foreach (Schedule sch in dbSchedules)
            {
                string firstNameOfEmployee = db.GetFirstNameOfEmployeeById(sch.EmployeeId);
                if (sch.Date == shiftDate.ToString("dd/MM/yyyy") && sch.Status == "Cancelled")
                {
                    if (sch.Attendance != null)
                    {
                        this.lbxAbsenceRecods.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift} -> {sch.Attendance}");
                    }
                    else
                    {
                        this.lbxAbsenceRecods.Items.Add($"{firstNameOfEmployee} - ID({sch.EmployeeId}):{sch.Shift}");
                    }
                }
            }
        }
    }
}
