using System;
using System.Text.RegularExpressions;

namespace SampleProject.Utility
{
    ///<summary>Validates user inputs</summary>
    public static class Validator
    {

        ///<summary>
        ///Validates <c>inputString</c> to allow letters only
        ///</summary>        
        /// <param name="inputString">input String from user</param>
        /// <returns>True if validation passes</returns>
        public static bool isvalidInputString(string inputString)
        {
            Console.WriteLine("You have entered: " + inputString);
            Regex regex = new Regex("^[a-zA-Z ]+$");

            return (!string.IsNullOrEmpty(inputString) && regex.IsMatch(inputString));
        }
    }
}