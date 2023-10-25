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
            newPerson.Firstname = "Test";
            newPerson.Lastname = "Test";
            newPerson.Middlename = "Test";
            newPerson.PhoneNumber = 147258369;
            newPerson.DateofBirth = DateTime.Now.AddYears(-20);
            int addResult = Person.AddPerson(newPerson);
            if (addResult == 1)
            {
                Console.WriteLine("new person added");
            }
            else
            {
                Console.WriteLine("failure adding a new person");
            }
        }
    }

}