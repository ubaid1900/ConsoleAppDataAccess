using ConsoleAppDataAccess;
using System.Data.SqlClient;
using System.Diagnostics;


namespace ConsoleAppEmpDataAccess
{

    public class Employee
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE=Employeedb");

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select Id,Firstname,Middlename,Lastname,Phonenumber from Employee", sqlConnection);
            object s = sqlCommand.ExecuteScalar();
            Console.WriteLine("Executescalar");
            Console.WriteLine(s);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Console.WriteLine("Execute reader");
            while (reader.Read())
            {
                Employee Emp = new Employee();
                Emp.Id = reader.GetInt32(0);
                Emp.Firstname = reader.GetString(1);
                Emp.Middlename = reader.GetString(2);
                Emp.Lastname = reader.GetString(3);
                Emp.Phonenumber = reader.GetInt32(4);
                list.Add(Emp);

                Console.WriteLine(@"{0} {1} {2} {3} {4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
            }
            return list;


            sqlConnection.Close();
        }
        public static Employee GetEmployee(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY = TRUE; DATABASE=Employeedb");
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"Select Id,Firstname,Middlename,Lastname,phonenumber from Employee where Id={id}", sqlConnection);

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
        public static int AddEmployee(Employee employee)
        {

            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY= TRUE; DATABASE = Employeedb");
            {
                sqlConnection.Open();

                /* string strcommand ="insert into Employee values ('"
                      + employee.Id +"','"
                      + employee.Firstname +"','" 
                      + employee.Middlename +"','"
                      + employee.Lastname +"','"
                      + employee.Phonenumber + "')";

                  SqlCommand sqlCommand = new SqlCommand(strcommand, sqlConnection);
                string strcommand_format = string.Format("insert into Employee values('{0}','{1}','{2}','{3}','{4}')", employee.Id, employee.Firstname, employee.Middlename, employee.Lastname, employee.Phonenumber);

                SqlCommand sqlCommand = new SqlCommand(strcommand_format, sqlConnection);*/

                string strcommand_interpolation = $"Insert into Employee values('{employee.Id}','{employee.Firstname}','{employee.Middlename}','{employee.Lastname}','{employee.Phonenumber}')";
                SqlCommand sqlCommand = new SqlCommand(strcommand_interpolation, sqlConnection);
                Console.WriteLine("ExecuteNonqurey");
                int s = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                return s;
            }

        }
        public static int DeleteEmployee(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY=TRUE; DATABASE = Employeedb");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"Delete from employee where Id={id}", sqlConnection);
            int s = sqlCommand.ExecuteNonQuery();
            if (s > 1)
            {
                Console.WriteLine(" one Employee deleted");
            }
            else
            {
                Console.WriteLine("Employee not deleted");
            }

            sqlConnection.Close();
            return s;
        }

        public static async Task< int> UpdateEmployee(int Id ,Employee employee, bool PartialUpdate)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; INTEGRATED SECURITY = TRUE; DATABASE=Employeedb");
            {
                await sqlConnection.OpenAsync();
                List<string> commandparts = new();
                int s;
                string command = "Update employee SET ";

                if (PartialUpdate)
                {
                    if (!string.IsNullOrWhiteSpace(employee.Firstname))
                    {
                        commandparts.Add($"Firstname = '{employee.Firstname}'");
                    }

                    if (!string.IsNullOrWhiteSpace(employee.Middlename))
                    {
                        commandparts.Add($"Middlename = '{employee.Middlename}'");

                    }
                    if (!string.IsNullOrWhiteSpace(employee.Lastname))
                    {
                        commandparts.Add($"Lastname = '{employee.Lastname}'");

                    }
                    if (employee.Phonenumber>0)
                    {
                        commandparts.Add($"Phonenumber = '{employee.Phonenumber}'");

                    }

                    command+= string.Join(", ", commandparts) + $"Where Id= {Id}";
                }

                else
                {
                    command = $"Update Employee SET Firstname = '{employee.Firstname}',Middlename = '{employee.Middlename}',Lastname = '{employee.Lastname}',Phonenumber = '{employee.Phonenumber}' Where Id={Id}"; 
                }

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                s = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return s;
            }
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
    }

}


