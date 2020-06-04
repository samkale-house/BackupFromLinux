using System;
using System.Text;
using System.Collections.Generic;

namespace SampleProject.Exercise
{
    public class ListExercise
    {

        public static bool doesContainVowels(string inputName)
        {
            if (inputName.Contains('a') || inputName.Contains('e') || inputName.Contains('i') || inputName.Contains('o') || inputName.Contains('u'))
            { return true; }
            return false;
        }
        public static bool sleepin(bool weekday, bool vacation)
        {
            return (!weekday || vacation);
        }
        internal static string getFirstDuplicateChar(string inputString)
        {
            //convert to array            
            char[] inputStringArr = inputString.ToCharArray();

            //hashset to determine duplicates            
            HashSet<Char> HSinputString = new HashSet<char>();

            //get the duplicate by trying add to hashet 
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!HSinputString.Add(inputStringArr[i]))
                    return ("Duplicate char is " + inputStringArr[i]);
            }

            return "not found any duplicate chars";
        }
        public static bool InTrouble(bool asmiling, bool bsmiling)
        {
            return (asmiling == bsmiling);
        }
        public static bool In3050(int start, int end)
        {
            return ((start >= 30 && end <= 40) || (start >= 40 && end <= 50));
        }

        public static string RemovedelAtIndex1(string inputString)
        {
            if (inputString.Substring(1, 3).Equals("del"))
            {
                StringBuilder stringBuilder = new StringBuilder(inputString.Substring(0, 1));
                stringBuilder.Append(inputString.Substring(4));
                return (stringBuilder.ToString());
                //Console.WriteLine(inputString.Substring(0,0)+inputString.Substring(4,inputString.Length-1));
            }
            return inputString;
        }

        public static bool mixStart(string inputString)
        {
            string ixSubString = (inputString.Substring(1, 2).ToUpper());
            return (ixSubString.Equals("IX"));
        }

        public static int max1020(int num1, int num2)
        {
            if (num1 > num2)
                return (num1 >= 10 && num1 <= 20) ? num1 : 0;
            else
                return (num2 >= 10 && num2 <= 20) ? num2 : 0;
        }
        public static int SumDouble(int num1, int num2)
        {
            if (num1 == num2)
                return (num1 + num2) * 2;

            return (num1 + num2);
        }

        public static bool Makes10(int num1, int num2)
        {
            if (num1 == 10 || num2 == 10 || num1 + num2 == 10)
                return true;

            return false;
        }
        public static bool HasTeen(int num1, int num2, int num3)
        {
            if (inrange1319(num1) || inrange1319(num2) || inrange1319(num3))
                return true;

            return false;
        }
        private static bool inrange1319(int num)
        {
            if (num >= 13 && num <= 19)
                return true;

            return false;
        }
        public static string NotString(string inputString)
        {
            if (inputString.Length >= 3 && (inputString.Substring(0, 3).ToUpper()).Equals("NOT"))
                return inputString;

            return ("not " + inputString);
        }
        public static bool Array123(int[] arrInt)
        {
            if (arrInt.Length >= 3)
                for (int i = 1; i < arrInt.Length; i++)
                {
                    if (arrInt[arrInt.Length - i] == 3 && arrInt[arrInt.Length - 1 - i] == 2 && arrInt[arrInt.Length - 2 - i] == 1)
                        return true;
                }
            return false;
        }
        public static string Endup(string inputString)
        {
            if (inputString.Length > 3)
                return (inputString.Substring(0, inputString.Length - 3) + (inputString.Substring(inputString.Length - 3, 3)).ToUpper());

            return inputString.ToUpper();
        }
        public static bool StringE(string inputString)
        {
            int count = 0;
            foreach (char ch in inputString.ToCharArray())
            {
                if (ch == 'e')
                    count++;
            }
            return (count >= 1 && count <= 3) ? true : false;
        }

        internal static string FrontBack(string inputString)
        {

            string revereseString = inputString.Substring(inputString.Length - 1) +
            inputString.Substring(1, inputString.Length - 2) +
            inputString.Substring(0, 1);
            return revereseString;

            // char[] charray=inputString.ToCharArray();
            // char temp=charray[0];
            // charray[0]=charray[inputString.Length-1];
            // charray[inputString.Length-1]=temp;
            // return new string(charray);
        }

        internal static int arayCount9(int[] arrInt)
        {
            int count = 0;
            for (int index = 0; index < arrInt.Length; index++)
            {
                if (arrInt[index] == 9)
                    count++;
            }
            return count;
        }

        internal static int ExceptionExercise()
        {
            try
            {
                Console.WriteLine("in try");
                return 2;
            }
            catch (Exception ex)
            { Console.WriteLine("ohhh..its here \n" + ex.GetType().Name); }
            finally { Console.WriteLine("In finally"); }
            return 5;
        }
    }
 

}