using Common.AccountModels;
using Common.Core;
using Common.Interfaces;
using System.Data.SqlClient;

namespace DataAccessLayer.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LedgerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User LoginUser(LoginModel model)
        {
            string sqlExpression = "sp_LoginUser";
            User user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = model.Login
                };
                command.Parameters.Add(loginParam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = model.Password
                };
                command.Parameters.Add(passwordParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User();
                        user.Id = int.Parse(reader["Id"].ToString());
                        user.Login = reader["Login"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Role = reader["Role"].ToString();
                    }
                }
                reader.Close();
            }

            return user;
        }
    }
}
