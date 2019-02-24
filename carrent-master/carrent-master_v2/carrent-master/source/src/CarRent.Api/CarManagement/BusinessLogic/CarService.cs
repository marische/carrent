using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Domain
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IReadOnlyList<Car> GetAll()
        {
            return carRepository.GetAll();
        }

        public void writeCarIntoDB(Car car)
        {
            carRepository.writeCarIntoDB(car);
        }

        public void ReserveCar(Car car)
        {
            carRepository.ReserveCar(car);
        }

        public void DeleteCar(int id)
        {
            carRepository.DeleteCar(id);
        }
    }
}
