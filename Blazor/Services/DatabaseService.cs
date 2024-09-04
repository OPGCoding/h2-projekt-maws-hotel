using Blazor.Components.Pages;
using DomainModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

        public class Booking
        {
            public int Id { get; set; }

            public DateTime DateStart { get; set; }

            public DateTime DateEnd { get; set; }

            public int ProfileId { get; set; }

            public int RoomId { get; set; }
        }
        public class Profile
        {
            public int Id { get; set; } // Maps to the "id" column
            public string Name { get; set; } // Maps to the "name" column
            public string Email { get; set; } // Maps to the "email" column
            public string Password { get; set; } // Maps to the "password" column
            public DateTime? Birthday { get; set; } // Maps to the "birthday" column
            public string Address { get; set; } // Maps to the "address" column
            public string PhoneNumber { get; set; } // Maps to the "phone_number" column
            public bool Administrator { get; set; } // Maps to the "administrator" column
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
        public List<Booking> GetBookingsFromSql(string sql)
        {
            List<Booking> allBookings = new List<Booking>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allBookings.Add(new Booking
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                DateStart = Convert.ToDateTime(reader["date_start"]),
                                DateEnd = Convert.ToDateTime(reader["date_end"]),
                                ProfileId = Convert.ToInt32(reader["profile_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"])
                            });
                        }
                    }
                }
            }
            return allBookings;
        }

        public List<Profile> GetProfilesFromSql(string sql)
        {
            var allProfiles = new List<Profile>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allProfiles.Add(new Profile
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Email = reader["email"].ToString(),
                                Password = reader["password"].ToString(),
                                Birthday = reader["birthday"] != DBNull.Value ? Convert.ToDateTime(reader["birthday"]) : (DateTime?)null,
                                Address = reader["address"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString(),
                                Administrator = Convert.ToBoolean(reader["administrator"])
                            });
                        }
                    }
                }
            }

            return allProfiles;
        }

        public void UpdateProfile(Profile profile)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE profile SET 
                                    name = @name, 
                                    email = @email, 
                                    birthday = @birthday, 
                                    address = @address, 
                                    phone_number = @phone_number, 
                                    administrator = @administrator 
                                    WHERE id = @id";

                    command.Parameters.AddWithValue("@name", profile.Name);
                    command.Parameters.AddWithValue("@id", profile.Id);
                    command.Parameters.AddWithValue("@email", profile.Email);
                    command.Parameters.AddWithValue("@birthday", profile.Birthday);
                    command.Parameters.AddWithValue("@address", profile.Address);
                    command.Parameters.AddWithValue("@phone_number", profile.PhoneNumber);
                    command.Parameters.AddWithValue("@administrator", profile.Administrator);

                    command.ExecuteNonQuery();
                }
            }
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



