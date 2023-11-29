using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppDataAccess.Tests
{
    [TestClass()]
    public class ForUnitTestsTests
    {
        [TestMethod()]
        [DataRow(1, 2, Operations.Plus, 3)]
        [DataRow(10, 20, Operations.Plus, 30)]
        [DataRow(-10, -20, Operations.Plus, -30)]
        [DataRow(45, 8800, Operations.Plus, 8845)]
        [DataRow(int.MaxValue, int.MaxValue, Operations.Plus, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue, Operations.Plus, int.MinValue)]
        public void OperationTest(int n1, int n2, Operations operation, int expected)
        {
            // Act
            int actual = ForUnitTests.Operation(n1, n2, operation);
            // Assert
            //Assert.AreEqual(expected, actual);
            expected.Should().Be(actual);
        }

        //[TestMethod()]
        public void ANotherOperationTest()
        {
            Assert.Fail();
        }
    }
}