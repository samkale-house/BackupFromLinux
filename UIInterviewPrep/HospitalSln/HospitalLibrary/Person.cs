using System;
namespace HospitalLibrary
{
    public class Person : IEquatable<Object>
    {
        public int age { get; set; }
        public string name { get; set; }

        // override object.Equals
        public override bool Equals(Object obj)
        {            
            Person person = (Person) obj;
            if (person == null || GetType() != person.GetType())
            {
                return false;
            }
            
            // TODO: write your implementation of Equals() here
            return (this.age == person.age && this.name.Equals(person.name));
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return 31*5+71*2;
        }

        
    }
}