using Common.Core;
using Common.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.Implementation
{
    public class LocationRepository : ILocationRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LedgerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Building GetBuilding(int id)
        {
            string sqlExpression = "sp_GetBuilding";
            Building building = new Building();

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
                        building.Id = int.Parse(reader["Id"].ToString());
                        building.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                    }
                }
                reader.Close();
            }
            return building;
        }

        public List<Building> GetBuildings()
        {
            string sqlExpression = "sp_GetBuildings";
            List<Building> buildings = new List<Building>();

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
                        Building building = new Building();

                        building.Id = int.Parse(reader["Id"].ToString());
                        building.Name = reader["Name"].ToString().Replace("  ", string.Empty);

                        buildings.Add(building);
                    }
                }
                reader.Close();
            }
            return buildings;
        }

        public Floot GetFloot(int id)
        {
            string sqlExpression = "sp_GetFloot";
            Floot floot = new Floot();

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
                        floot.Id = int.Parse(reader["Id"].ToString());
                        floot.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                        floot.BuildingId = int.Parse(reader["BuildingId"].ToString());
                    }
                }
                reader.Close();
            }
            return floot;
        }

        public List<Floot> GetFloots(int buildingId)
        {
            string sqlExpression = "sp_GetFloots";
            List<Floot> floots = new List<Floot>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@buildingId",
                    Value = buildingId
                };
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Floot floot = new Floot();

                        floot.Id = int.Parse(reader["Id"].ToString());
                        floot.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                        floot.BuildingId = int.Parse(reader["BuildingId"].ToString());

                        floots.Add(floot);
                    }
                }
                reader.Close();
            }
            return floots;
        }

        public Room GetRoom(int id)
        {
            string sqlExpression = "sp_GetRoom";
            Room room = new Room();

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
                        room.Id = int.Parse(reader["Id"].ToString());
                        room.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                        room.FlootId = int.Parse(reader["FlootId"].ToString());
                    }
                }
                reader.Close();
            }
            return room;
        }

        public int GetRoomId(string roomName)
        {
            string sqlExpression = "sp_GetRoomId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter roomNameParam = new SqlParameter
                {
                    ParameterName = "@roomName",
                    Value = roomName
                };
                command.Parameters.Add(roomNameParam);

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

        public List<Room> GetRooms(int flootId)
        {
            string sqlExpression = "sp_GetRooms";
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@flootId",
                    Value = flootId
                };
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Room room = new Room();

                        room.Id = int.Parse(reader["Id"].ToString());
                        room.Name = reader["Name"].ToString().Replace("  ", string.Empty);
                        room.FlootId = int.Parse(reader["FlootId"].ToString());

                        rooms.Add(room);
                    }
                }
                reader.Close();
            }
            return rooms;
        }
    }
}
