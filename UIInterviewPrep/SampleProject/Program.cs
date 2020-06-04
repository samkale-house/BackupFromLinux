using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Internal;
using SampleProject.Exercise;
using SampleProject.Utility;

namespace SampleProject
{
    class Program
    {
        static Logger logger=new Logger("Program",InternalTraceLevel.Info,null);
        static void Main(string[] args)
        {
            // ///<sumamry>Exercise 1
            // ///Find if your name have vowels<summary>
            // boolExercise1();

            // ///<summary>Exercise 2:know if I am sleeping</summary>
            // /*The parameter weekday is true if it is a weekday, and the parameter 
            // vacation is true if we are on vacation. We sleep in if it is not a weekday
            //   or we're on vacation. Return true if we sleep in.
            // sleepIn(false, false) → true
            // sleepIn(true, false) → false
            // sleepIn(false, true) → true
            // */
            // boolExercise2();

            // ///<summary>Exercise 3</summary>
            // /*We have two monkeys, a and b, and the parameters aSmile and bSmile indicate if each 
            // is smiling. We are in trouble if they are both smiling or if neither of them is smiling.
            //  Return true if we are in trouble.
            // monkeyTrouble(true, true) → true
            // monkeyTrouble(false, false) → true
            // monkeyTrouble(true, false) → false*/
            // boolExercise3();

            // ///<summary>Exercise 4</summary>
            // /*Given 2 int values, return true if they are both in the range 30..40 inclusive, or they 
            // are both in the range 40..50 inclusive.
            // in3050(30, 31) → true
            // in3050(30, 41) → false
            // in3050(40, 50) → true*/
            // intExercise1();            

            // ///<summary>Exercise 5</summary>

            // /*Given a string, if the string "del" appears starting at index 1,
            //  return a string where that "del" has been deleted. Otherwise, return the string 
            //  unchanged.
            //  delDel("adelbc") → "abc"
            //  delDel("adelHello") → "aHello"
            //  delDel("adedbc") → "adedbc"
            //  */
            // stringExercise1();

            // ///<summary>Exercise 6</summary>
            // /*
            // Return true if the given string begins with "mix", except the 'm' can be anything,
            // so "pix", "9ix" .. all count.
            // mixStart("mix snacks") → true
            // mixStart("pix snacks") → true
            // mixStart("piz snacks") → false
            // */
            // stringExercise2();

            // ///<summary>Exercise 8</summary>
            // /*Given 2 positive int values, return the larger value that is in the range 10..20 inclusive, 
            // or return 0 if neither is in that range.
            // max1020(11, 19) → 19
            // max1020(19, 11) → 19
            // max1020(11, 9) → 11                
            // */
            // intExercise2();

            // /*
            // Given two int values, return their sum. Unless the two values are the same, 
            // then return double their sum.
            // sumDouble(1, 2) → 3
            // sumDouble(3, 2) → 5
            // sumDouble(2, 2) → 8
            // */
            // intExercise3();

            // /*
            // Given 2 ints, a and b, return true if one if them is 10 or if their sum is 10.
            // makes10(9, 10) → true
            // makes10(9, 9) → false
            // makes10(1, 9) → true
            // */
            // intExercise4();

            // /*
            // We'll say that a number is "teen" if it is in the range 13..19 inclusive. Given 3 int values, 
            // return true if 1 or more of them are teen.
            // hasTeen(13, 20, 10) → true
            // hasTeen(20, 19, 10) → true
            // hasTeen(20, 10, 13) → true*/
            // intExercise5();

            // /*
            // Given a string, return a new string where "not " has been added to the front. 
            // However, if the string already begins with "not", return the string unchanged. 
            // Note: use .equals() to compare 2 strings.
            // notString("candy") → "not candy"
            // notString("x") → "not x"
            // notString("not bad") → "not bad"
            // */
            // stringExercise3();

            // /*
            // Return true if the given string contains between 1 and 3 'e' chars.
            // stringE("Hello") → true
            // stringE("Heelle") → true
            // stringE("Heelele") → false
            // */
            // stringExercise4();

            // /*
            // Given a string, return a new string where the first and last chars have 
            // been exchanged.
            // frontBack("code") → "eodc"
            // frontBack("a") → "a"
            // frontBack("ab") → "ba"
            // */
            // stringExercise5();

            // /*
            // Given a string, return a new string where the last 3 chars are now in upper case. 
            // If the string has less than 3 chars, uppercase whatever is there. Note that str.toUpperCase() returns the uppercase version of a string.
            // endUp("Hello") → "HeLLO"
            // endUp("hi there") → "hi thERE"
            // endUp("hi") → "HI"

            // abcde
            // 01234
            // */
            // stringExercise6();

            // /*Given a string and a non-negative int n, 
            // return a larger string that is n copies of the original string.
            // stringTimes("Hi", 2) → "HiHi"
            // stringTimes("Hi", 3) → "HiHiHi"
            // stringTimes("Hi", 1) → "Hi"
            // */
            // stringIntExercise1();

            // /*
            // Given an array of ints, return true if the sequence
            //  of numbers 1, 2, 3 appears in the array somewhere.
            //  array123([1, 1, 2, 3, 1]) → true
            //  array123([1, 1, 2, 4, 1]) → false
            //  array123([1, 1, 2, 1, 2, 3]) → true
            // */
            // arrayExercise1();

            // /*
            // Given an array of ints, return the number of 9's in the array.
            // arrayCount9([1, 2, 9]) → 1
            // arrayCount9([1, 9, 9]) → 2
            // arrayCount9([1, 9, 9, 3, 9]) → 3
            // */
            // arrayExercise2();

            // /*
            // Suppose the string "yak" is unlucky. Given a string, return a version 
            // where all the "yak" are removed, but the "a" can be any char. The "yak" strings will not overlap.
            // stringYak("yakpak") → "pak"
            // stringYak("pakyak") → "pak"
            // stringYak("yak123ya") → "123ya"
            // */
            // stringExercise7();

            // /*
            // Given a string, return a version where all the "x" have been removed. Except an
            // "x" at the very start or end should not be removed.
            // abcxxd-->abcd
            // stringX("xxHxix") → "xHix"
            // stringX("abxxxcd") → "abcd"
            // stringX("xabxxxcdx") → "xabcdx"*/
            // stringExercise8();

            // /*            
            // Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... 
            // so "kittens" yields "kien"'.
            // altPairs("kitten") → "kien"
            // altPairs("Chocolate") → "Chole"
            // altPairs("CodingHorror") → "Congrr"
            // */
            // stringExercise9();

            // arrayToList();

            // arrayToHashSet();

            // /*Find first duplicate char in string*/
            // //getFirstDuplicateChar("abbccde")-->b
            // //getFirstDuplicateChar("abcdef")-->not found any duplicates
            // //getFirstDuplicateChar("abcbdde")-->b
            // stringExercise10();

            // /*Find one missing number from 1 to 7*/
            // findMissingNumber();    

            /*Find the pair in array that sums the number*/
            //Q':are repeated numbers allowed?
            //findPair([3,4,5,1,2,6], 7)-->[3,4] ,[5,2],[6,1]
            //findPair[12,0,6,3],9-->[6,3]
            //result [num1,num2]
            logger.Error("I am error");
            getPairMatchToSum(new int[]{3, 4, 5, 1, 2, 6}, 7);

            // /*use linq:get the squares of numbers in between range if squares are even*/
            // //input: min=3 max=8 o/p:16,36,64            
            //  var inp=Enumerable.Range(3,10);// to create sequence from 3 upto 8 numbers            
            //  List<int> evenSquareList1=inp.Where(x=>(x*x)%2==0).Select(x=>x*x).ToList();
            //  foreach(int square in evenSquareList1)
            //  {
            //      Console.WriteLine(square);
            //  }

            // //int to float,
            // //float to int
            // //Math.Round
            // tryConversions();
            
            ////try,catch ,finally
            //Console.WriteLine("The value returned:"+ListExercise.ExceptionExercise());


            // SuperClass super=new SuperClass();
            // SubClass sub=new SubClass();
            // super.Display();
            // sub.Display();
            // Console.Write("---------------------\n");
            // super=new SubClass();
            // super.Display();
            // sub.Display();
            // Console.Write("---------------------\n");
            //  SuperClass.StaticDisp();
            // SubClass.StaticDisp();

        }

        private static void tryConversions()
        {
            int intVar = 7;
            float floatVar = intVar;//implicit conversion (float32bit,int32bit)
            
            Console.WriteLine("--------------int to float-----------------");
            Console.WriteLine($"intValue:{intVar} floatValue:{floatVar}");
            Console.WriteLine("--------------float to int-----------------");
            floatVar = 5.8f;
            intVar = (int)floatVar;//explicit conversion-mention explicitly
            Console.WriteLine($"floatValue:{floatVar} intValue:{intVar}");

            Console.WriteLine("--------------Sum of Int and float-----------------");
            //int intVarsumIntFlot=intVar+floatVar;//compile error
            intVar=3;
            floatVar=5.8f;
            float floatVarsumIntFloat=intVar+floatVar;
            Console.WriteLine("float result for int 3+ float 5.8f= "+floatVarsumIntFloat);
            int intVarsumIntFlot=(intVar+(int)floatVar);
            Console.WriteLine("int result for int 3+ (int)float 5.8f= "+intVarsumIntFlot);

            Console.WriteLine("--------------Math.Round-----------------");
            Console.WriteLine("Round(17.2) :" + Math.Round(17.2) + " | Round(17.5) :" + Math.Round(17.5) + " | Round(17.7) :" + Math.Round(17.7));
            Console.WriteLine("Round(10.2) :" + Math.Round(10.2) + " | Round(10.5) :" + Math.Round(10.5) + " | Round(10.7) :" + Math.Round(10.7));
            Console.WriteLine("because .5 rounds to nearest even number.");
            
            Console.WriteLine("--------------Double,float,decimal-----------------");
            double doubleVar = 23.6548839573775757575;
            floatVar = 23.6548839573775757575f;
            decimal decVar = 23.6548839573775757575m;
            Console.WriteLine($"23.6548839573775757575 \n double:{doubleVar} | float:{floatVar} | decimal:{decVar}");
            Console.WriteLine("double:15 digits after decimal point \n float:6 after decimal point \n decimal: as much digit you want after decimal point");
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrInt"></param>
        /// <param name="matchSum"></param>
        private static void getPairMatchToSum(int[] arrInt, int matchSum)
        {
            //sort ascending
            arrInt = arrInt.OrderBy(x => x).ToArray();            
            //Hashset to store pairs
            HashSet<int[,]> pairHashset = new HashSet<int[,]>();
            //2d array represents pair
            int[,] pair = new int[,] { { 0, 0 } };
            //traverse from high to mid
            
            for (int high = arrInt.Length - 1; high >= (arrInt.Length - 1) / 2; high--)
            {
                if (arrInt[high] < matchSum)
                {//traverese from low to mid
                    for (int low = 0; low < high; low++)
                    {
                        //check for match to sum and store pair in hashset
                        if (arrInt[high] + arrInt[low] == matchSum)
                        {
                            pair = new int[,] { { arrInt[high], arrInt[low] } };
                            pairHashset.Add(pair);
                        }
                    }
                }
            }
            //try using linq

            foreach (int[,] resultpair in pairHashset)
            {
                Console.WriteLine($"Pair:[{resultpair[0, 0]},{resultpair[0, 1]}]");
            }
        }

        private static void findMissingNumber()
        {
            int[] arrint = new int[] { 1, 2, 3, 4, 5, 7 };
            int sum = new List<int>(arrint).Sum(x => x);
            Console.Write((7 + 6 + 5 + 4 + 3 + 2 + 1) - sum);

        }
        private static void stringExercise10()
        {
            var result = ListExercise.getFirstDuplicateChar("abcbdde");
            Console.WriteLine($"{result}");
        }

        private static void arrayToHashSet()
        {
            System.Console.WriteLine("Array of String to HashSet....");
            string[] stringarr = new string[] { "abc", "def", "pqr", "def" };
            HashSet<string> stringHashset = new HashSet<string>(stringarr);
            foreach (var item in stringHashset)
            {
                System.Console.WriteLine("Item: " + item);
            }
        }

        private static void arrayToList()
        {
            string[] stringarr = new string[] { "abc", "def", "pqr" };
            List<string> stringlst = new List<string>(stringarr);
            foreach (string str in stringlst) { Console.WriteLine(str); }
        }
        private static void stringExercise9()
        {
            string inputString = "Chocolate";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < inputString.Length - 1; i += 4)
            {
                if (i == inputString.Length - 1)
                {
                    stringBuilder.Append(inputString.Substring(i, 1));
                }
                else
                {
                    stringBuilder.Append(inputString.Substring(i, 2));
                    i = i + 2;
                    int n = i;
                    if (i > inputString.Length) { stringBuilder.Append(inputString.Substring(n, 1)); }
                }
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        private static void stringExercise8()
        {
            string inputString = "xxHxix";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == 'x')
                {
                    if (i == 0 || i == inputString.Length - 1) { stringBuilder.Append(inputString[i]); }
                }
                else { stringBuilder.Append(inputString[i]); }
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        private static void stringExercise7()
        {
            string inputString = "yak123ya";
            Char[] chArray = inputString.ToCharArray();
            Char[] luckyChArray = new Char[inputString.Length];

            for (int i = 0; i < chArray.Length; i++)
            {
                if (checkYAKPattern(chArray, i))
                {
                    i = i + 2;
                }
                else
                {
                    luckyChArray[i] = chArray[i];
                }
            }
            Console.WriteLine(new string(luckyChArray));
        }

        private static bool checkYAKPattern(char[] chArray, int i)
        {
            return i != chArray.Length - 2 && (chArray[i] == 'y' && chArray[i + 1] == 'a' && chArray[i + 2] == 'k');
        }

        private static void arrayExercise2()
        {
            int[] arrInt = new int[] { 1, 2, 9, 9, 3, 2, 9 };

            Console.WriteLine("Count of 9: " + ListExercise.arayCount9(arrInt));
        }
        private static void arrayExercise1()
        {
            int[] arrInt = new int[] { 1, 1, 2, 4, 1 };

            Console.WriteLine(ListExercise.Array123(arrInt));
        }
        private static void stringIntExercise1()
        {
            int repeatation = 2;
            string inputString = "Hi";
            StringBuilder stringBuilder = new StringBuilder("");
            for (int i = 1; i <= repeatation; i++)
            {
                stringBuilder.Append(inputString);
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        private static void stringExercise6()
        {
            System.Console.WriteLine("Enter your name");
            string inputString = Console.ReadLine();

            Console.WriteLine(ListExercise.Endup(inputString));
        }
        private static void stringExercise5()
        {
            Console.Write("String user input:");
            string inputString = Console.ReadLine();
            Console.WriteLine(ListExercise.FrontBack(inputString));
        }
        private static void stringExercise4()
        {
            Console.Write("String user input:");
            string inputString = Console.ReadLine();
            Console.WriteLine(ListExercise.StringE(inputString));
        }
        private static void stringExercise3()
        {
            Console.Write("String user input:");
            string inputString = Console.ReadLine();
            Console.WriteLine(ListExercise.NotString(inputString));
        }
        private static void intExercise5()
        {
            Console.WriteLine("Enter ages for Students");
            Console.Write("Student1:");
            int age1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Student2 :");
            int age2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Student3 :");
            int age3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ListExercise.HasTeen(age1, age2, age3));

        }

        private static void intExercise4()
        {
            Console.Write("Enter number1 :");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number2 :");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ListExercise.Makes10(num1, num2));
        }
        private static void intExercise3()
        {
            Console.Write("Enter number1 :");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number2 :");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ListExercise.SumDouble(num1, num2));
        }
        private static void intExercise2()
        {
            Console.Write("Enter number1 :");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number2 :");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ListExercise.max1020(num1, num2));
        }
        private static void boolExercise1()
        {
            Console.WriteLine("Enter name");
            string userInput = Console.ReadLine();
            if (Validator.isvalidInputString(userInput))
            {
                var result = ListExercise.doesContainVowels(userInput);
                string outputMessage = result == true ? "Your Name have vowel" : "That's unique Name";
                Console.WriteLine(outputMessage);
            }
            else
                Console.WriteLine("Input not correct");
            //todo: ask again and run agan
        }

        private static void boolExercise2()
        {
            try
            {
                Console.WriteLine("Is it a week day? true or false");
                bool weekday = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Are you on Vacation? true or false");
                bool vacation = Convert.ToBoolean(Console.ReadLine());
                Console.Write("We sleep ? :" + (ListExercise.sleepin(weekday, vacation) ? "Yes" : "No"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input must be true or false :" + ex.Message);
            }
            finally { Console.Read(); }
        }

        private static void boolExercise3()
        {
            try
            {
                Console.WriteLine("Is monkey A smiling? true or false");
                bool asmiling = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Is monkey B smiling? true or false");
                bool bsmiling = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Are we in trouble ? :" + (ListExercise.InTrouble(asmiling, bsmiling) ? "Yes" : "No"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input must be true or false : " + ex.Message);
            }
            finally { Console.Read(); }
        }

        private static void intExercise1()
        {
            try
            {
                Console.WriteLine("Enter 1st number");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter 2nd number");
                int num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ListExercise.In3050(num1, num2) ? "yes in range" : "no not");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input must be a number : " + ex.Message);
            }
        }

        private static void stringExercise1()
        {
            Console.WriteLine("Enter a Word or sentence");
            string inputString = Console.ReadLine();
            Console.WriteLine(ListExercise.RemovedelAtIndex1(inputString));
        }

        private static void stringExercise2()
        {
            Console.WriteLine("Enter a Word or sentence");
            string inputString = Console.ReadLine();
            Console.WriteLine(ListExercise.mixStart(inputString));
        }
        
    }

}
