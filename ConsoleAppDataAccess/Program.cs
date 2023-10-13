using System.Data.SqlClient;
using System.Diagnostics;

namespace ConsoleAppDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");
            //using SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;");

            using (SqlConnection sqlConnection = new SqlConnection(@"Server =.\SQLExpress; Integrated Security=true; Database=TESTING1;"))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("select Firstname, lastname from Person", sqlConnection);

                Console.WriteLine("ExecuteScalar");
                object s = sqlCommand.ExecuteScalar();
                Console.WriteLine(s);

                Console.WriteLine("ExecuteReader");
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }


                sqlConnection.Close();
                //sqlConnection.Dispose();
            }

        }
    }
}