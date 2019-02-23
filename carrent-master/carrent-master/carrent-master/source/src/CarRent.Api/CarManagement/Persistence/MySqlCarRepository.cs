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

        int car_id;
        String licenseplate;
        String brand;
        String model;
        int carclass;

        public MySqlCarRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }
        public IReadOnlyList<Car> GetAll()
        {
            List<Car> carlist = new List<Car>();
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

                        
                            car_id = (int)Convert.ToInt32(reader[0]);
                            licenseplate = reader[1].ToString();
                            brand = reader[2].ToString();
                            model = reader[3].ToString();
                            carclass = Convert.ToInt32(reader[4]);
                        
                        
                    }
                    Car c = new Car(car_id, licenseplate, brand, model, carclass); //carclass ist int
                    carlist.Add(c);
                }
                reader.Close();
                IReadOnlyList<Car> readcarlist = carlist;
                return readcarlist;



            }

        }


        public void writeCarIntoDB(Car car)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Car (licenseplate, brand, model, fk_carclass_id) VALUES ('" + car.Licenseplate + "', '" + car.Brand + "', '" + car.Model + "', " + car.Carclass + ")";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }


        public void ReserveCar(Car car)
        {
            _mySqlConnection.Open();

            var command = _mySqlConnection.CreateCommand();
            command.CommandText = "UPDATE car SET occupied = true WHERE car_id = " + car.Car_id + ";";
            command.ExecuteNonQuery();
            _mySqlConnection.Close();
        }


    }
}
