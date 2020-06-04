using System;
using System.Collections.Generic;
using AppointmentMgmtLibrary.Model;
namespace AppointmentMgmtLibrary.RepositoryStore
{
    public interface IPatientRepo{
       Patient getPatient(string fname,string lname,DateTime dob);        
     //  List<Appointment> getApptSchedule(string mrn);                

    }
}