using System;
using System.Collections.Generic;

namespace AppointmentMgmtLibrary.Model
{ 
    public class Patient
    {
        public string MRN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

 //       public List<Appointment> Appointments {get;set;}

    //     public Patient()
    //     {
    //         appointments=new List<Appointment>();
    //     }
    // 
    }
}