using System;
using System.Collections.Generic;

namespace AngularAndMvcApp.Models
{
    public class StudentViewModel
    {
        public string Student_Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Location { get; set; }

        public StudentViewModel(string student_id,string student_name,string student_location)
        {
            Student_Id=student_id;
            Student_Name=student_name;
            Student_Location=student_location;
        }
    }
}
