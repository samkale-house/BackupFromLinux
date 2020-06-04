
using NUnit.Framework;
using SampleProject.Utility;

namespace SampleProject.Test
{
    public class ValidatorTest
    {
        [Test]
        public void Test1()
        {

            Assert.AreEqual(Validator.isvalidInputString("sam"), true);
            Assert.AreEqual(Validator.isvalidInputString("sam12"), false);
            Assert.AreEqual(Validator.isvalidInputString("sam@3"), false);
            Assert.AreEqual(Validator.isvalidInputString(""), false);

        }
    }
}

