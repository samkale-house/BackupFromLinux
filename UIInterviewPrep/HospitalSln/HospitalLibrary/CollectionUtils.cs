using System.Collections.Generic;
namespace HospitalLibrary
{
    public class CollectionUtils
    {
        public static bool AreEqual(Person person1, Person person2){
            return person1.Equals(person2);
        }

        public static bool TestStringKeyForHashset(){
            HashSet<string> set = new HashSet<string>();
            bool result1 = set.Add("mahesh");
            bool result2 = set.Add("mahesh");
            System.Console.WriteLine("result 1 : "+result1);
            System.Console.WriteLine("result 2 : "+result2);
            return true;
        }

        public static bool TestCustomeTypeKeyForHashset(Person person1, Person person2){
            HashSet<Person> set = new HashSet<Person>();
            bool result1 = set.Add(person1);
            bool result2 = set.Add(person2);
            System.Console.WriteLine("result person1 : "+result1);
            System.Console.WriteLine("result person2 : "+result2);
            return true;
        }
        public static bool TestCustomeTypeKeyForDictionary(Person person1, Person person2){
            Person person3 = new Person{
                age = 6,
                name = "Chitraksh"
            };
            Dictionary<Person, string> personDict = new Dictionary<Person, string>();
            personDict.Add(person3, "This is person3 object");
            // personDict.Add(person2, "This is person2 object");
            personDict.Add(person1, "This is person1 obj");

            foreach (var item in personDict.Keys)
            {
             System.Console.WriteLine(item.name+ " " + item.age);   
            }
            return true;
        }        
    }
}