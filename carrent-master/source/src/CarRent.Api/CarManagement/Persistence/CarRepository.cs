using CarRent.Api.CarManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Persistence
{
    internal class CarRepository : ICarRepository
    {
        private readonly static IReadOnlyList<Car> inMemoryCars = new List<Car>
        {
            new Car("Audi"),
            new Car("Mercedes")
        };

        public IReadOnlyList<Car> GetAll()
        {
            return inMemoryCars;
        }
    }
}
