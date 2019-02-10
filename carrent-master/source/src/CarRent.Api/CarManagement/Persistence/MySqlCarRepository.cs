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
            //_mySqlConnection = new MySqlConnection(connectionString);
           
            _mySqlConnection = new MySqlConnection("server=localhost;database=carrent;uid=root;password=D3He8Mn%a;");//database noch richtig angeben
        }
        public IReadOnlyList<Car> GetAll()
        {
            IReadOnlyList<Car> carlist = new List<Car>();
            _mySqlConnection.Open();
            using (_mySqlConnection.BeginTransaction())
            {
                var command = _mySqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM Car;";
                var reader = command.ExecuteReader();
                object[] dataRow = new object[reader.FieldCount];
                while (reader.Read())
                {
                    int cols = reader.GetValues(dataRow);
                    for (int i = 0; i < cols; i++)
                    {
                        {
                            //carlist.Add();
                        }
                                               
                        //Objekte in IReadOnlyList abfüllen


                    }

                }
                reader.Close();
                return carlist;



            }

        }
    }
}
