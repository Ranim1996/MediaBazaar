using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public class AssignShiftManagment
    {
        DataAccess db = new DataAccess();
        ScheduleBase schedule = new ScheduleBase();
        List<ScheduleBase> dbSchedules = null;
        public void ShowComboBox(DateTime date, ComboBox weekDay, ComboBox saturday, ComboBox sunday)
        {
            if(date.DayOfWeek == DayOfWeek.Sunday)
            {
                sunday.Visible = true;
                saturday.Visible = false;
                weekDay.Visible = false;
            }
            else
            {
                if(date.DayOfWeek == DayOfWeek.Saturday)
                {
                    saturday.Visible = true;
                    sunday.Visible = false;
                    weekDay.Visible = false;
                }
                else
                {
                    weekDay.Visible = true;
                    sunday.Visible = false;
                    saturday.Visible = false;
                }
            }
        }

        public void UpdateList(ListBox lbShifts, DateTime shiftDate, string status)
        {
            lbShifts.Items.Clear();
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;
            if(dbSchedules == null)
            {
                MessageBox.Show("Cannot open shift for the selected day. Try again!");
            }
            else
            {
                foreach (ScheduleBase sch in dbSchedules)
                {
                    string firstNameOfEmployee = db.GetFirstNameOfEmployeeById(sch.EmployeeId);
                    if (sch.Date == shiftDate.ToString("dd/MM/yyyy") && sch.Status == status)
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
            
        }
        public bool AssignWorkShift(int employeeId, string date, string shift)
        {
            List<EmployeeBase> empl = db.GetDBNotFiredEmployeeByID(employeeId);
            if(empl.Count != 0)
            {
                db.AddSchedule(employeeId, date, shift);
                return true;
            }
            return false;
        }

        public void AddAttendance(string attendance, DateTime shiftDate, ListBox lbShifts)
        {
            string holder = "";
            string date = shiftDate.ToString("dd/MM/yyyy");
            schedule.GetAllSchedules();
            dbSchedules = schedule.allSchedules;

            if(lbShifts.SelectedItem != null)
            {
                holder = lbShifts.SelectedItem.ToString();
                foreach (ScheduleBase sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        db.AddAttendanceForEmployeeByIdAndShift(sch.EmployeeId, attendance, sch.Shift, date);
                        break;
                    }
                }
            }
        }

        public bool DeleteAttendance(ListBox lbShifts, DateTime shiftDate)
        {
            string holder = "";
            string status = "Assigned";
            string date = shiftDate.ToString("dd/MM/yyyy");

            if (lbShifts.SelectedItem != null)
            {
                holder = lbShifts.SelectedItem.ToString();
                foreach (ScheduleBase sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Are you sure that you want to delete this shift? ID({sch.EmployeeId}): {sch.Shift}", "Warning!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.DeleteAttendanceByIdAndShift(sch.EmployeeId, sch.Shift, date, status);
                            MessageBox.Show("Shift has been successfully removed!");
                            //UpdateList();
                            return true;
                        }
                        else //if(dialogResult == DialogResult.No)
                        {
                            //do nothing 
                        }
                        break;
                    }
                }
            }
            return false;
        }

        public bool AssignSelectedShift(ListBox lbShiftPreferences, DateTime shiftDate)
        {
            string holder = "";
            string date = shiftDate.ToString("dd/MM/yyyy");

            if (lbShiftPreferences.SelectedItem != null)
            {
                holder = lbShiftPreferences.SelectedItem.ToString();
                foreach (ScheduleBase sch in dbSchedules)
                {
                    if (holder.Contains(sch.EmployeeId.ToString()) && holder.Contains(sch.Shift))
                    {
                        DialogResult dialogResult = MessageBox.Show($"Are you sure that you want to assign this shift? ID({sch.EmployeeId}): {sch.Shift}", "Warning!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.AssignShift(sch.EmployeeId, sch.Shift, date);
                            MessageBox.Show("Shift has been successfully assigned!");
                            return true;
                        }
                        else //if(dialogResult == DialogResult.No)
                        {
                            //do nothing 
                        }
                        break;
                    }
                }
            }
            return false;
        }
       
    }
}
