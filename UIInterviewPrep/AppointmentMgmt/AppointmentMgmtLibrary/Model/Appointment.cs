using System;

namespace AppointmentMgmtLibrary.Model
{ 
    public class Appointment
    {
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string PatientMRN { get; set; }
        public string PhysicianID { get; set; }
        
        public string AttendantNurseID {get;set;}
    }
}