using HospitalServices.Model;
using System;

namespace UserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor=new Doctor{ID=1,FirstName="Sonja",LastName="Scott",Department_id=4};
            Console.WriteLine($"we are with doctor:{doctor.ToString()}");


        }
    }
}
