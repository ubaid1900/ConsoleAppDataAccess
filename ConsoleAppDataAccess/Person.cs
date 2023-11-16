using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;


namespace ConsoleAppDataAccess
{
    public class Person
    {
        public static int AddPerson(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
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
                    $"Insert into Person values ('{person.Id}','{person.Firstname}', '{person.Lastname}', '{person.Middlename}', '{person.Phonenumber}')";

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
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("select Id, Firstname,Middlename, lastname,Phonenumber from Person", sqlConnection);

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

                    Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));


                }
                return list;
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
        public static List<Person> GetPersons(string name)
        {
            //SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");
            //using SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");

            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new(
                    $"select Id, Firstname,Middlename, lastname,Phonenumber from Person where firstname like '%{name}%' or lastname like '%{name}%'"
                    , sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.Id = reader.GetInt32(0);
                    p.Firstname = reader.GetString(1);
                    p.Lastname = reader.GetString(2);
                    list.Add(p);
                }

                sqlConnection.Close();
            }

            Console.WriteLine();
            Console.WriteLine("From List");
            foreach (Person p in list)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", p.Id, p.Firstname, p.Middlename, p.Lastname, p.Phonenumber);
            }
            return list;
        }

        public static Person GetPerson(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"select Id, Firstname, Middlename, lastname, Phonenumber from Person where Id ={id}", sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();




                if (reader.Read())
                {
                    Person p = new Person();

                    p.Id = reader.GetInt32(0);
                    p.Firstname = reader.GetString(1);
                    p.Middlename = reader.GetString(2);
                    p.Lastname = reader.GetString(3);
                    p.Phonenumber = reader.GetInt32(4);

                    Console.WriteLine("{0} {1} {2} {3} {4} ", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));

                    sqlConnection.Close();

                    return p;
                }
                sqlConnection.Close();
            }

            return null;
        }

        public static int DeletePerson(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE= TESTING1");
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"Delete from person where Id={id}", sqlConnection);
                int s = sqlCommand.ExecuteNonQuery();

                if (s > 0)
                {
                    Console.WriteLine("One person deleted");

                }
                else
                {
                    Console.WriteLine("person not deleted");
                }
                sqlConnection.Close();
                return s;
            }
        }

        public static int UpdatePerson(Person person, int id, bool T)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"SERVER=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE= TESTING1"))
            {

                sqlConnection.Open();
                int s =1;
                string command = "Update Person SET";
                if (T)
                {
                    if (!String.IsNullOrWhiteSpace(person.Firstname))
                    {
                        string sqlCommand1 = command + $" Firstname=('{person.Firstname}') Where Id={id}";
                        SqlCommand sqlCommand2 = new SqlCommand(sqlCommand1, sqlConnection);
                        int s1 = sqlCommand2.ExecuteNonQuery();
                        //Console.WriteLine(s1);
                        //return s1;
                    }

                    if (!String.IsNullOrWhiteSpace(person.Middlename))
                    {
                        string sqlCommand1 = command + $" Middlename=('{person.Middlename}') Where Id={id}";
                        SqlCommand sqlCommand2 = new SqlCommand(sqlCommand1, sqlConnection);
                       int s2 = sqlCommand2.ExecuteNonQuery();
                       // Console.WriteLine(s2);
                        //return s2;
                    }

                    if (!String.IsNullOrWhiteSpace(person.Lastname))
                    {
                        string sqlCommand1 = command + $" Lastname=('{person.Lastname}') Where Id= {id}";
                        SqlCommand sqlCommand2 = new SqlCommand(sqlCommand1, sqlConnection);
                       int s3 = sqlCommand2.ExecuteNonQuery();
                       // Console.WriteLine(s3);
                       // return s3;
                    }
                    if (int.IsPositive(person.Phonenumber))
                    {
                        string sqlCommand1 = command + $" Phonenumber=('{person.Phonenumber}') Where Id={id}";
                        SqlCommand sqlCommand2 = new SqlCommand(sqlCommand1, sqlConnection);
                        int s3 = sqlCommand2.ExecuteNonQuery();
                       // Console.WriteLine(s3);
                        // return s3;
                    }



                }
                else
                {
                    string sqlCommand_interpolation = $"Update Person SET Firstname='{person.Firstname}', Middlename='{person.Middlename}', Lastname='{person.Lastname}', Phonenumber='{person.Phonenumber}' Where Id={id}";
                    SqlCommand sqlCommand = new SqlCommand(sqlCommand_interpolation, sqlConnection);
                    int s1 = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine(s);
                    return s1;

                }
                return s;


                sqlConnection.Close();

            }
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int Phonenumber { get; set; }
        //  public DateTime DateofBirth { get; set; }
    }

}