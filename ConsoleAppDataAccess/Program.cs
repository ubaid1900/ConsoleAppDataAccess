using System.Diagnostics;

namespace ConsoleAppDataAccess
{
    internal class Program
    {
        // One change for PR
        static void Main(string[] args)
        {
            //Person.GetPersons();
            Person.GetPersons("n");

            #region get person
            //Person person1 = Person.GetPerson(1);
            //if (person1 == null)
            //{
            //    Console.WriteLine("Person not found");
            //}
            //else
            //{
            //    Console.WriteLine("{0} {1}", person1.Firstname, person1.Lastname);
            //    Console.WriteLine("{1}, {0}", person1.Firstname, person1.Lastname);
            //}

            //Console.WriteLine();

            //Person person10 = Person.GetPerson(10);
            //if (person10 == null)
            //{
            //    Console.WriteLine("Person not found");
            //}
            //else
            //{
            //    Console.WriteLine("{0} {1}", person10.Firstname, person10.Lastname);
            //    Console.WriteLine("{1}, {0}", person10.Firstname, person10.Lastname);
            //}

            #endregion

            #region add person
            //Person newPerson = new Person();
            //newPerson.Firstname = "Test";
            //newPerson.Lastname = "Test";
            //newPerson.Middlename = "Test";
            //newPerson.PhoneNumber = 147258369;
            //newPerson.DateofBirth = DateTime.Now.AddYears(-20);
            //int addResult = Person.AddPerson(newPerson);
            //if (addResult == 1)
            //{
            //    Console.WriteLine("new person added");
            //}
            //else
            //{
            //    Console.WriteLine("failure adding a new person");
            //} 
            #endregion
        }
    }

}