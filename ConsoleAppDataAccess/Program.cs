using ConsoleAppEmpDataAccess;
using System.Diagnostics;

namespace ConsoleAppDataAccess
{
    internal class Program
    {
        static void  Main(string[] args)
        {

            // Another change 
            // Person.GetPersons("munna");
            var persons= Person_withSqlAdapters.GetPersons_withDataAdapter("munna").GetAwaiter().GetResult();
            // var persons = Person.GetPersons("munna").GetAwaiter().GetResult();
           // var persons = Person.GetPersons_WithDataAdapter("munna").GetAwaiter().GetResult();

            // Person_withSqlAdapters.GetPersons_withDataAdapter();
            // Person_withSqlAdapters.GetPerson_withDataAdapter(2);
            // Employee.GetEmployees();
            //Employee.GetEmployee(1);
            //Person_withSqlAdapters.DeletePerson_withDataAdapter(1);
            // Employee.DeleteEmployee(2);
            #region add person
            //Person newPerson = new Person();
            //newPerson.Id = 4;
            //newPerson.Firstname = "faheem";
            //newPerson.Lastname = "saleem";
            //newPerson.Middlename = "kaleem";
            ////newPerson.DateofBirth = DateTime.Now.AddYears(-20);
            //newPerson.Phonenumber = 147258369;
            //int addResult = Person_withSqlAdapters.AddPerson_withDataAdapter(newPerson);
            //if (addResult == 1)
            //{
            //    Console.WriteLine("new person added");
            //}
            //else
            //{
            //    Console.WriteLine("failure adding a new person");
            //}
            #endregion
            #region update person
            //Person newperson = new Person();
            //newperson.Id = 2;
            //newperson.Firstname = "pasha";
            //newperson.Middlename = "mohd";
            //newperson.Lastname = "khan";
            //newperson.Phonenumber = 111;

            //int addResult = Person.UpdatePerson(newperson, newperson.Id, false).GetAwaiter().GetResult();
            //if (addResult == 1)
            //{
            //    Console.WriteLine("Preson updated");

            //}
            //else
            //{
            //    Console.WriteLine("person not updated");
            //}

            #endregion
            #region add employee
            /*Employee employee = new Employee();
            employee.Id = 10;
            employee.Firstname = "abdullah";
            employee.Middlename = "mohd";
            employee.Lastname = "khan";
            employee.Phonenumber = 878787;

            int addresult = Employee.AddEmployee(employee);
            if (addresult == 1)
            {
                Console.WriteLine("new Employee added");
            }
            else
            {
                Console.WriteLine("failure of adding new employee");
            }*/
            #endregion;

            #region update Employee;
            //Employee employee = new Employee();
            //employee.Id = 9;
            //employee.Firstname = "salman";
            //employee.Middlename = "khan";
            //employee.Lastname = "khan";
            //employee.Phonenumber = 878787;

            // int addresult = Employee.UpdateEmployee(employee.Id, employee,true).GetAwaiter().GetResult();
            //if (addresult == 1)
            //{
            //    Console.WriteLine($"Employee Id={ employee.Id} Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Failure to Update employee");
            //}

            #endregion


        }
    }

}