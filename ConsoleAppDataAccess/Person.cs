using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppDataAccess
{
    public class Person
    {
        public static int AddPerson(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                //string strCommand = "Insert into Person values ('"
                //    + person.Firstname + "', '"
                //    + person.Lastname + "', '"
                //    + person.Middlename + "', '"
                //    + person.PhoneNumber + "', '"
                //    + person.DateofBirth + "')";

                //string strCommand_format = string.Format("Insert into Person values ('{0}', '{1}', '{2}', '{3}', '{4}')"
                //    ,person.Firstname
                //    ,person.Lastname
                //    ,person.Middlename
                //    ,person.PhoneNumber
                //    ,person.DateofBirth);

                string strCommand_interpolation = 
                    $"Insert into Person values ('{person.Firstname}', '{person.Lastname}', '{person.Middlename}', '{person.PhoneNumber}', '{person.DateofBirth}')";               

                SqlCommand sqlCommand = new SqlCommand(strCommand_interpolation, sqlConnection);



                Console.WriteLine("ExecuteNonQuery");
                int s = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                //sqlConnection.Dispose();
                return s;
            }
        }
        public static List<Person> GetPersons()
        {
            //SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");
            //using SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");

            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("select Id, Firstname, lastname from Person", sqlConnection);

                Console.WriteLine("ExecuteScalar");
                object s = sqlCommand.ExecuteScalar();
                Console.WriteLine(s);

                Console.WriteLine("ExecuteReader");
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.Id = reader.GetInt32(0);
                    p.Firstname = reader.GetString(1);
                    p.Lastname = reader.GetString(2);
                    list.Add(p);

                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));

                }

                sqlConnection.Close();
                //sqlConnection.Dispose();
            }

            Console.WriteLine();
            Console.WriteLine("From List");
            foreach (Person p in list)
            {
                Console.WriteLine("{0} {1}", p.Firstname, p.Lastname);
            }
            return list;
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateofBirth { get; set; }
    }

}