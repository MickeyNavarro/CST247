using Activity1_3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1_3.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindByUser(UserModel user)
        {
            //assume that nothing is in the query 
            bool success = false; 

            //provide the wuery string with a parameter placeholder
            string queryString = "select * from dbo.Users where username = @username and password = @password";

            //create and open the connection in a using block. This ensures that all resources will be closed and disclosed when the code exists
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //create the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}