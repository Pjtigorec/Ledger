using Common.AccountModels;
using Common.Core;
using Common.Interfaces;
using System.Data.SqlClient;

namespace DataAccessLayer.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LedgerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool CheckLoginForRegister(string login)
        {
            string sqlExpression = "sp_CheckLoginForRegister";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                command.Parameters.Add(loginParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return false;
                }
                reader.Close();
            }

            return true;
        }

        public User RegisterNewUser(RegisterModel model)
        {
            return new User();
        }
    }
}
