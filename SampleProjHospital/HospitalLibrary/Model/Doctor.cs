using System;

namespace HospitalLibrary.Model
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //to do: make it foreign key
        public int Department_id { get; set; }

        //used for logging.
        public string ToString(){
           return("id:"+this.ID+" fname:"+this.FirstName
                   +" lname:"+this.LastName+" dept_id:"
                   +this.Department_id);
        }

    }
}
