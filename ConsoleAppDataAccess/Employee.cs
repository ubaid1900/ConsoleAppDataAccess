using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlTypes;
using ConsoleAppDataAccess;


namespace ConsoleAppEmpDataAccess
{

    public class Employee
    {
        public static List<Employee> GetEmployee()
        {
            List<Employee> list = new List<Employee>();
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE=Employeedb");

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select Id,Firstname,Middlename,Lastname,Phonenumber from Employee", sqlConnection);
            object s = sqlCommand.ExecuteScalar();
            Console.WriteLine("Executescalar");
            Console.WriteLine(s);

            SqlDataReader reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                Employee Emp = new Employee();
                Emp.Id = reader.GetInt32(0);
                Emp.Firstname = reader.GetString(1);
                Emp.Middlename = reader.GetString(2);
                Emp.Lastname = reader.GetString(3);
                Emp.Phonenumber = reader.GetInt32(4);
                list.Add(Emp);

                Console.WriteLine(@"{0}{1}{2}{3}{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
            }
            return list;


            sqlConnection.Close();
        }
        public static Employee GetEmployee(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY = TRUE; DATABASE=Employeedb");
            {
            sqlConnection.Open();
            
            SqlCommand sqlCommand = new SqlCommand($"Select Id,Firstname,Middlename,Lastname,phonenumber from Employee where Id={id}",sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {

                Employee emp = new Employee();
                    Console.WriteLine("iam in if function");
                emp.Id = reader.GetInt32(0);
                emp.Firstname = reader.GetString(1);
                emp.Middlename = reader.GetString(2);
                emp.Lastname = reader.GetString(3);
                emp.Phonenumber = reader.GetInt32(4);
                // list.Add(emp);

                sqlConnection.Close();
                return emp;
            }

            sqlConnection.Close();
            return null;
           // Console.WriteLine("{0}{1}{2}{3}{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));

            }


        }

        public static  AddPerson()
        {

            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE = Employeedb");
            {
                sqlConnection.Open();

               string strcommand ="insert into Employee values ('"
                    + Employee.Id +"','"
                    + Employee.Firtname +"','" +
                    + Employee.Middlename +"','"
                    + Employee.Lastname +"','"
                    + Employee.Phonenumber + "')";

                SqlCommand sqlCommand = new SqlCommand(strcommand, sqlConnection);
                Console.WriteLine("Execute Nonqurey");
                int s = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                //return s;
            }
        }

    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public int Phonenumber { get; set; }
}

}


