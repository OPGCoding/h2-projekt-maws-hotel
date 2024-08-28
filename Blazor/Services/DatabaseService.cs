using Blazor.Components.Pages;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blazor.Services
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public class Room
        {
            public int Id { get; set; }
            public bool CurrentlyBooked { get; set; }
            public float Price { get; set; }
            public int DigitalKey { get; set; }
            public int Type { get; set; }
            public string Photos { get; set; }
        }

        public List<Room> GetRoomsFromSql(string sql)
        {
            List<Room> allRooms = new List<Room>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allRooms.Add(new Room
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                CurrentlyBooked = Convert.ToBoolean(reader["currently_booked"]),
                                Price = Convert.ToSingle(reader["price"]),
                                DigitalKey = Convert.ToInt32(reader["digital_key"]),
                                Type = Convert.ToInt32(reader["type"]),
                                Photos = reader["photos"].ToString(),
                            });
                        }
                    }
                }
            }
            return allRooms;
        }


        public int ExecuteSql(string sql)
        {

            var rowsaffected = -1;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        rowsaffected = Convert.ToInt32(result);
                    }
                }
            }
            return rowsaffected;
        }
    }

    

}



