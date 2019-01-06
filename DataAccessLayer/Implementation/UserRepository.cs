using Common.Core;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LedgerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<User> GetUsers()
        {
            string sqlExpression = "sp_GetUsers";
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();

                        user.Id = int.Parse(reader["Id"].ToString());
                        user.Login = reader["Login"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Role = reader["Role"].ToString();

                        users.Add(user);
                    }
                }
                reader.Close();
            }

            return users;
        }

        public User GetUserById(int id)
        {
            string sqlExpression = "sp_GetUserById";
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
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

        public void Create(User user)
        {
            string sqlExpression = "sp_CreateUser";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = user.Login
                };
                command.Parameters.Add(loginParam);

                SqlParameter emailparam = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = user.Email
                };
                command.Parameters.Add(emailparam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = user.Password
                };
                command.Parameters.Add(passwordParam);

                SqlParameter roleParam = new SqlParameter
                {
                    ParameterName = "@role",
                    Value = user.Role
                };
                command.Parameters.Add(roleParam);

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
