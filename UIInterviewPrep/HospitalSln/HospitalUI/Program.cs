using System;
using HospitalLibrary;

namespace HospitalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DatabaseUtil.GetConnection();
            System.Console.WriteLine("Excuted Fine");

            System.Console.WriteLine("***** Starting Hashset****");
            Person person1 = new Person {
                age = 25,
                name = "Mahesh"
            };
            Person person2 = new Person {
                age = 25,
                name = "Mahesh"
            };            
            bool areTwoPersonEqual = CollectionUtils.AreEqual(person1, person2);
            System.Console.WriteLine("Are Two Person Equal: " + areTwoPersonEqual);
            System.Console.WriteLine("StringHashSet Check : " + CollectionUtils.TestStringKeyForHashset());
            System.Console.WriteLine("Custom HashSet Check : " + CollectionUtils.TestCustomeTypeKeyForHashset(person1, person2));
            System.Console.WriteLine("Custom Dictionary Check : " + CollectionUtils.TestCustomeTypeKeyForDictionary(person1, person2));
        }
    }
}
