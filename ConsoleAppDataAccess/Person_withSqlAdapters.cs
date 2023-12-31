﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDataAccess
{
    public class Person_withSqlAdapters
    {
        public static int AddPerson_withDataAdapter(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                List<Person> person1 = new();
                //int s;

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

                SqlDataAdapter sqlDataAdapter = new(strCommand_interpolation, sqlConnection);

                DataSet ds = new();
                sqlDataAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataRowCollection rows = ds.Tables[0].Rows;
                    foreach (DataRow row in rows)
                    {
                        Person p = new();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["Lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);
                        person1.Add(p);
                    }
                }

                sqlConnection.Close();
                //sqlConnection.Dispose();
                return 1;
            }
        }
        public static List<Person> GetPersons_withDataAdapter()
        {

            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlDataAdapter sqlCommand = new("select Id, Firstname,Middlename, lastname,Phonenumber from Person", sqlConnection);

                DataSet ds = new();

                sqlCommand.Fill(ds);


                if (ds.Tables.Count > 0)
                {

                    DataRowCollection rows = ds.Tables[0].Rows;
                    foreach (DataRow row in rows)
                    {
                        Person p = new Person();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["Lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);
                        list.Add(p);


                        Console.WriteLine("{0} {1} {2} {3} {4}", p.Id, p.Firstname, p.Middlename, p.Lastname, p.Phonenumber);
                    }

                }

                Console.WriteLine();
                Console.WriteLine("From List");
                foreach (Person p in list)
                {
                    Console.WriteLine("{0} {1}", p.Firstname, p.Lastname);
                }
                return list;

                sqlConnection.Close();
            }


        }
        public async static Task<List<Person>> GetPersons_withDataAdapter(string name)
        {
            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                await sqlConnection.OpenAsync();

                SqlDataAdapter sqlDataAdapter = new(
                    $"select Id, Firstname,Middlename, lastname,Phonenumber from Person where Firstname like '%{name}%' or Lastname like '%{name}%'"
                    , sqlConnection);

                DataSet ds = new();
                sqlDataAdapter.Fill(ds);



                if (ds.Tables.Count > 0)
                {

                    DataRowCollection rows = ds.Tables[0].Rows;

                    foreach (DataRow row in rows)
                    {
                        Person p = new Person();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["Lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);
                        list.Add(p);
                        Console.WriteLine("{0},{1},{2},{3},{4}", p.Id, p.Firstname, p.Middlename, p.Lastname, p.Phonenumber);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("From List");
                foreach (Person p in list)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.Id, p.Firstname, p.Middlename, p.Lastname, p.Phonenumber);
                }
                return list;
                sqlConnection.Close();

            }



        }
        public async static Task<List<Person>> GetPersons_WithDataAdapter(string name)
        {
            List<Person> list = new List<Person>();
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {
                await sqlConnection.OpenAsync();

                string cmdText = $"select Id, Firstname ,Middlename, lastname,Phonenumber from Person where Firstname = '{name}'";

                SqlDataAdapter sqlDataAdapter = new(cmdText, sqlConnection);
                DataSet ds = new();
                sqlDataAdapter.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    DataRowCollection rows = ds.Tables[0].Rows;
                    foreach (DataRow row in rows)
                    {
                        Person p = new();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
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

        public static Person GetPerson_withDataAdapter(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLEXPRESS; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new($"select Id, Firstname, Middlename, lastname, Phonenumber from Person where Id ={id}", sqlConnection);

                DataSet ds = new();
                sqlDataAdapter.Fill(ds);






                if (ds.Tables.Count > 0)
                {
                    DataRowCollection rows = ds.Tables[0].Rows;
                    foreach (DataRow row in rows)
                    {
                        Person p = new Person();
                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["Lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);


                        Console.WriteLine("{0} {1} {2} {3} {4} ", p.Id, p.Firstname, p.Middlename, p.Lastname, p.Phonenumber);
                        return p;
                    }
                    sqlConnection.Close();


                }
                sqlConnection.Close();
            }

            return null;
        }

        public static int DeletePerson_withDataAdapter(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE= TESTING1");
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new($"Delete from person where Id={id}", sqlConnection);
                DataSet ds = new();

                int s = sqlDataAdapter.Fill(ds);

                if (s > 0)
                {
                    Console.WriteLine("One person deleted");

                }
                else
                {
                    Console.WriteLine("person not deleted");
                }
                sqlConnection.Close();
                return 1;
            }
        }

        public static async Task<int> UpdatePerson_withDataAdapter(Person person, int id, bool partialUpdate)
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
                SqlDataAdapter sqlDataAdapter = new(command, sqlConnection);
                DataSet ds = new();
                sqlDataAdapter.Fill(ds);


                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Person p = new();

                        p.Id = Convert.ToInt32(row["Id"]);
                        p.Firstname = Convert.ToString(row["Firstname"]);
                        p.Middlename = Convert.ToString(row["Middlename"]);
                        p.Lastname = Convert.ToString(row["Lastname"]);
                        p.Phonenumber = Convert.ToInt32(row["Phonenumber"]);

                        Console.WriteLine("{0},{1},{2},{3},{4}", p.Id, p.Firstname, p.Middlename, p.Lastname);

                    }
                }

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
