using ConsoleAppEmpDataAccess;
using System.Diagnostics;

namespace ConsoleAppDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person.GetPersons();
            // Person.GetPersons("n");
            //Person.GetPersons();
            // Person.GetPerson(2);
            //Employee.GetEmployee();
            //Employee.GetEmployee(1);
            Person.Delete(1);
           #region add person
           /* Person newPerson = new Person();
            newPerson.Id = 3;
            newPerson.Firstname = "munna";
            newPerson.Lastname = "saleem";
            newPerson.Middlename = "kaleem";
            //newPerson.DateofBirth = DateTime.Now.AddYears(-20);
            newPerson.Phonenumber = 147258369;
            int addResult = Person.AddPerson(newPerson);
            if (addResult == 1)
                {
                Console.WriteLine("new person added");
            }
            else
            {
               Console.WriteLine("failure adding a new person");
           } */
           #endregion

        }
    }

}