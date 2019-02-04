using CarRent.Api.CarManagement.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Persistence
{
    public class MySqlCarRepository : ICarRepository
    {
        private MySqlConnection _mySqlConnection;

        public MySqlCarRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);

        }
        public IReadOnlyList<Car> GetAll()
        {
            _mySqlConnection.Open();
            using (_mySqlConnection.BeginTransaction())
            {
                var command = _mySqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM cars;";
                var reader = command.ExecuteReader();
                while(reader.get)
            }
                
        }
    }
}
