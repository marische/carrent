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
            new Car(1, "AR 42226", "Subaru", "WRX STI", "Sedan"),
            new Car(2, "AR 42020", "Mitsubishi", "Lancer Evolution", "Sedan")
        };

        public IReadOnlyList<Car> GetAll()
        {
            return inMemoryCars;
        }
    }
}
