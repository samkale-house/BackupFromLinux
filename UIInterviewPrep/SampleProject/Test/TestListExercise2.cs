using NUnit.Framework;
using SampleProject.Exercise;

namespace SampleProject.Test
{
    public class TestListExercise2
    {
        [Test]
        public void testSum()
        {
         Assert.AreEqual(ListExercise.getFirstDuplicateChar("abbccde").Equals("Duplicate char is b"), true);
        }
    }
}