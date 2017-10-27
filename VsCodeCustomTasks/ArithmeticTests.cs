using NUnit.Framework;

namespace VsCodeCustomTasks
{
    [TestFixture]
    public class ArithmeticTests
    {
        [Test]
        public void Add_Should_Return_Sum_Given_Input_Ints()
        {
            var output = Arithmetic.AddInt(3, 2);
            Assert.AreEqual(output, 5);
        }


        [Test]
        public void Subtract_Should_Return_Difference_Given_Input_Ints()
        {
            var output = Arithmetic.SubtractInt(10, 3);
            Assert.AreEqual(output, 7);
        }
    }

}