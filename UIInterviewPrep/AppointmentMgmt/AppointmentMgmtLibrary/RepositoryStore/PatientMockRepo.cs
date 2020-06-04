using System;
using System.Collections.Generic;
using AppointmentMgmtLibrary.Model;
using System.Linq;

namespace AppointmentMgmtLibrary.RepositoryStore
{
    public class PatientMockRepo : IPatientRepo
    {
        public List<Patient> patients;
        public PatientMockRepo()
        {
            patients= new List<Patient>();
            patients.Add(new Patient() { MRN= "125",FirstName= "Smith",LastName= "Scott",DOB= new DateTime(1986, 11, 28) });
            patients.Add(new Patient() { MRN="124",FirstName= "Sham",LastName= "Charles", DOB=new DateTime(1986, 11, 28) });
            patients.Add(new Patient() { MRN="123",FirstName= "Heera",LastName= "Mahalle", DOB=new DateTime(1986, 11, 28) });
            patients.Add(new Patient() { MRN="122",FirstName= "Neha", LastName="Mahalle", DOB=new DateTime(1986, 11, 28) });
        }

        public Patient getPatient(string fname, string lname, DateTime dob)
        {
            return patients.Where(patient => (patient.FirstName).Equals(fname) &&
                                            (patient.LastName).Equals(lname) &&
                                            patient.DOB == dob
                                            )
                            .FirstOrDefault();

        }
        // public List<Appointment> getApptSchedule(string mrn)
        // {
        //     throw new NotImplementedException();
        //     return new List<Appointment>();
        // }
    }
}