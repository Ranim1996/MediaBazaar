using System.Collections.Generic;

namespace Media_Bazaar
{
    public interface ISchedule
    {
        string Attendance { get; }
        string Date { get; }
        int EmployeeId { get; }
        string Shift { get; }
        int ShiftId { get; }
        string Status { get; }

        void GetAllSchedules();
    }
}