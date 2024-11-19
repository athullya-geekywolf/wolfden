﻿using WolfDen.Domain.Enums;

namespace WolfDen.Domain.Entity
{
    public class DailyAttendence
    {
        public int Id { get;private set; }
        public int EmployeeId { get; private set; }
        public DateOnly Date {  get;private set; }
        public DateTime ArrivalTime { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public int InsideDuration { get;private set; }
        public int OutsideDuration { get;private set; }
        public string MissedPunch {  get;private set; }
        public AttendanceStatus AttendanceStatusId { get; set; }
        
        private DailyAttendence()
        {
            
        }
        public DailyAttendence(int employeeId, DateOnly date, DateTime arrivalTime, DateTime departureTime, int insideDuration, int outsideDuration, string missedPunch, AttendanceStatus attendanceStatusId )
        {
            EmployeeId = employeeId;
            Date = date;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            InsideDuration = insideDuration;
            OutsideDuration = outsideDuration;
            MissedPunch = missedPunch;
            AttendanceStatusId = attendanceStatusId;
            
        }


    }
}
