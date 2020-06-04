using System;
namespace SampleProject.Exercise
{
    public class SuperClass
    {        
      public virtual int Display()
      {         
          Console.WriteLine("From SuperClass");
          return 1;
      }
      public static void StaticDisp()
      {
          Console.WriteLine("From Super Class Static method");
      }
    }
    public class SubClass:SuperClass
    {
      public override int Display()
      {
          Console.WriteLine("From SubClass");
          return 2;
      }
      

      public static void StaticDisp()
      {
          Console.WriteLine("From Sub Class Static method");
      }
    }
}