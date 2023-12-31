﻿using ConsoleAppDataAccess.Common;
using System.Collections.Generic;
using System.Data;
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
        public async static Task<List<Person>> GetPersons(string name)
        {
            foreach (string item in Constants.BlackList)
            {
                if (name.ToLower().Contains(item.ToLower()))
                {
                    throw new ArgumentException("Invalid value for name");
                }
            }            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                await sqlConnection.OpenAsync();

                SqlCommand sqlCommand = new(
                    $"select Id, Firstname,Middlename, lastname,Phonenumber from Person where firstname like '%{name}%' or lastname like '%{name}%'"
                    , sqlConnection);

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync())
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
        public async static Task<List<Person>> GetPersons_WithDataAdapter(string firstname)
        {
            foreach (string item in Constants.BlackList)
            {
                if (firstname.ToLower().Contains(item.ToLower()))
                {
                    throw new ArgumentException($"Invalid value for {nameof(firstname)}");
                }
            }
            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {
                await sqlConnection.OpenAsync();

                string cmdText = $"select Id, Firstname as fn,Middlename, lastname,Phonenumber from Person where firstname = '{firstname}'";
                SqlCommand command = new(cmdText, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new();
                sqlDataAdapter.SelectCommand = command;

                DataSet ds = new();
                sqlDataAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataRowCollection rows = ds.Tables[0].Rows;
                    foreach (DataRow row in rows)
                    {
                        Person p = new();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["fn"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);
                        list.Add(p);
                    }
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
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=TRUE; Database=TESTING1;"))
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

        public static async Task<int> UpdatePerson(Person person, int id, bool partialUpdate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"SERVER=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE= TESTING1"))
            {
                await sqlConnection.OpenAsync();
                int s = 1;
                List<string> commandParts = new();
                string command = "Update Person SET ";
                if (partialUpdate)
                {
                    if (!String.IsNullOrWhiteSpace(person.Firstname))
                    {
                        commandParts.Add($"Firstname = '{person.Firstname}'");
                    }

                    if (!String.IsNullOrWhiteSpace(person.Middlename))
                    {
                        commandParts.Add($"Middlename = '{person.Middlename}'");
                    }

                    if (!String.IsNullOrWhiteSpace(person.Lastname))
                    {
                        commandParts.Add($"Lastname = '{person.Lastname}'");
                    }
                    if (person.Phonenumber > 0)
                    {
                        commandParts.Add($"Phonenumber = '{person.Phonenumber}'");
                    }
                    command += String.Join(", ", commandParts) + $" Where Id={id}";
                }
                else
                {
                    command = $"Update Person SET Firstname='{person.Firstname}', Middlename='{person.Middlename}', Lastname='{person.Lastname}', Phonenumber='{person.Phonenumber}' Where Id={id}";
                }
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                s = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return s;

            }
        }
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Middlename { get; set; }
        public int? Phonenumber { get; set; }
        //  public DateTime DateofBirth { get; set; }
    }

}