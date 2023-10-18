using System.Diagnostics;

namespace ConsoleAppDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! {0}");
            Person.GetPersons();

            Person newPerson = new Person();
            newPerson.DateofBirth = DateTime.Now.AddYears(-20);

        }
    }

}