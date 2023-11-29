using ConsoleAppDataAccess;

namespace ConsoleAppDataAccessxUnitTests
{
    public class ForUnitTestsxUnitTests
    {
        [Theory]
        [InlineData(1, 2, Operations.Plus, 3)]
        [InlineData(10, 20, Operations.Plus, 30)]
        [InlineData(-10, -20, Operations.Plus, -30)]
        [InlineData(45, 8800, Operations.Plus, 8845)]
        [InlineData(int.MaxValue, int.MaxValue, Operations.Plus, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, Operations.Plus, int.MinValue)]
        public void OperationTest(int n1, int n2, Operations operation, int expected)
        {
            // Arrange

            // Act
            int r = ForUnitTests.Operation(n1, n2, operation);
            // Assert
            Assert.Equal(expected, r);
        }
    }
}