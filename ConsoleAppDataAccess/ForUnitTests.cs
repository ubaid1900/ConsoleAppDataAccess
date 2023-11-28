namespace ConsoleAppDataAccess
{
    public enum Operations
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }
    public class ForUnitTests
    {
        public static int Operation(int n1, int n2, Operations operation)
        {
            switch (operation)
            {
                case Operations.Plus:
                    {
                        long l = (long)n1 + (long)n2;
                        if (l > int.MaxValue)
                        {
                            return int.MaxValue;
                        }
                        if (l < int.MinValue)
                        {
                            return int.MinValue;
                        }
                        return n1 + n2;
                    }
                case Operations.Minus:
                    return n1 - n2;
                case Operations.Multiply:
                    return n1 * n2;
                case Operations.Divide:
                    return Math.DivRem(n1, n2).Quotient;
                default:
                    throw new ArgumentException(nameof(operation));
            }
        }

        public int ANotherOperation()
        {
            return 0;
        }
    }

}