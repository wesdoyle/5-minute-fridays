using System;
using NUnit.Framework;

namespace SampleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AddInts(3, 4);
            Console.WriteLine("Result: " + result);
            Console.Read();
        }

        public static int AddInts(int x, int y)
        {
            return x + y;
        }
    }

    [TestFixture]
    class ProgramTests
    {
        [TestCase(2, 4, 6)]
        [TestCase(1, 0, 1)]
        [TestCase(10, -2, 8)]
        public void Should_Return_Sum_Given_Ints(int x, int y, int z)
        {
            var result = Program.AddInts(x, y);
            Assert.AreEqual(z, result);
        }
    }
}
