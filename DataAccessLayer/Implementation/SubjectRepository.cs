using Common.Core;
using Common.Interfaces;
using Logs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LedgerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Subject> GetSubjects()
        {
            string sqlExpression = "sp_GetSubjects";
            List<Subject> subjects = new List<Subject>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject();

                            subject.Id = int.Parse(reader["Id"].ToString());
                            subject.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                            subject.InventoryNumber = reader["InventoryNumber"].ToString().Replace("  ", string.Empty);
                            subject.Description = reader["Description"].ToString().Replace("  ", string.Empty);
                            subject.StateId = int.Parse(reader["StateId"].ToString());
                            subject.RoomId = int.Parse(reader["RoomId"].ToString());

                            subjects.Add(subject);
                        }
                    }
                    reader.Close();
                    Logger.Log.Info("Стащили все объекты");
                }
                catch(ArgumentNullException ex)
                {
                    Logger.Log.Error("При попытке взять из бд все объекты - ArgumentNullException. Подробности: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("При попытке взять из бд все объекты - Exception. Подробности: " + ex.Message);
                }
            }
            return subjects;
        }

        public Subject GetSubjectById(int id)
        {
            string sqlExpression = "sp_GetSubjectById";
            Subject subject = new Subject();

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
                        subject.Id = int.Parse(reader["Id"].ToString());
                        subject.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                        subject.InventoryNumber = reader["InventoryNumber"].ToString().Replace("  ", string.Empty);
                        subject.Description = reader["Description"].ToString().Replace("  ", string.Empty);
                        subject.StateId = int.Parse(reader["StateId"].ToString());
                        subject.RoomId = int.Parse(reader["RoomId"].ToString());
                    }
                }
                reader.Close();
            }

            return subject;
        }

        public void Create(Subject subject)
        {
            string sqlExpression = "sp_CreateSubject";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = subject.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter inventoryNumberParam = new SqlParameter
                {
                    ParameterName = "@inventoryNumber",
                    Value = subject.InventoryNumber
                };
                command.Parameters.Add(inventoryNumberParam);
                SqlParameter descriptionParam = new SqlParameter
                {
                    ParameterName = "@description",
                    Value = subject.Description
                };
                command.Parameters.Add(descriptionParam);
                SqlParameter stateIdParam = new SqlParameter
                {
                    ParameterName = "@stateId",
                    Value = subject.StateId
                };
                command.Parameters.Add(stateIdParam);
                SqlParameter roomIdParam = new SqlParameter
                {
                    ParameterName = "@roomId",
                    Value = subject.RoomId
                };
                command.Parameters.Add(roomIdParam);

                try
                {
                    var reader = command.ExecuteReader();
                    reader.Close();
                    Logger.Log.Info("Создан объект");
                }
                catch(Exception ex)
                {
                    Logger.Log.Error("При попытки создать новую запись для объектов - Exception. Подробности: " + ex.Message);
                }
            }
        }

        public void Update(Subject subject)
        {
            string sqlExpression = "sp_UpdateSubject";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = subject.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = subject.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter inventoryNumberParam = new SqlParameter
                {
                    ParameterName = "@inventoryNumber",
                    Value = subject.InventoryNumber
                };
                command.Parameters.Add(inventoryNumberParam);
                SqlParameter descriptionParam = new SqlParameter
                {
                    ParameterName = "@description",
                    Value = subject.Description
                };
                command.Parameters.Add(descriptionParam);
                SqlParameter stateIdParam = new SqlParameter
                {
                    ParameterName = "@stateId",
                    Value = subject.StateId
                };
                command.Parameters.Add(stateIdParam);
                SqlParameter roomIdParam = new SqlParameter
                {
                    ParameterName = "@roomId",
                    Value = subject.RoomId
                };
                command.Parameters.Add(roomIdParam);
                

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "sp_DeleteSubject";

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

                reader.Close();
            }
        }

        public State GetSubjectState(int stateId)
        {
            string sqlExpression = "sp_GetSubjectState";
            State state = new State();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter stateIdParam = new SqlParameter
                {
                    ParameterName = "@stateId",
                    Value = stateId
                };
                command.Parameters.Add(stateIdParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        state.Id = int.Parse(reader["Id"].ToString());
                        state.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                    }
                }
                reader.Close();
            }
            return state;
        }

        public List<State> GetAllStates()
        {
            string sqlExpression = "sp_GetAllStates";
            List<State> states = new List<State>();

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
                        State state = new State();

                        state.Id = int.Parse(reader["Id"].ToString());
                        state.Name = reader["Name"].ToString().Replace("  ", string.Empty);

                        states.Add(state);
                    }
                }
                reader.Close();
            }

            return states;
        }

        public int GetStateId(string stateName)
        {
            string sqlExpression = "sp_GetStateId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter stateNameParam = new SqlParameter
                {
                    ParameterName = "@stateName",
                    Value = stateName
                };
                command.Parameters.Add(stateNameParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["Id"].ToString());
                    }
                }
                reader.Close();
            }

            return 0;
        }
    }
}
