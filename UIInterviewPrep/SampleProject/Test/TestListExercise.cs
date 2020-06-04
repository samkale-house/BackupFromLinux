using NUnit.Framework;
using SampleProject.Exercise;

namespace SampleProject.Test
{
    public class TestListExercise
    {

        [Test]
        public void TestInTrouble()
        {
            Assert.AreEqual(ListExercise.InTrouble(true,false), false);
            Assert.AreEqual(ListExercise.InTrouble(false, false), true);
            Assert.AreEqual(ListExercise.InTrouble(true, true), true);
        }


        [Test]
        public void testIn3050()
        {
            Assert.AreEqual(ListExercise.In3050(30, 40), true);
            Assert.AreEqual(ListExercise.In3050(30, 41), false);
            Assert.AreEqual(ListExercise.In3050(40, 50), true);
        }
    }
}