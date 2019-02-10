using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Domain
{
    public class Car
    {
        private readonly int car_id;
        private readonly string licenseplate;
        private readonly string brand;
        private readonly string model;
        private readonly string carclass;
        private readonly bool occupied;

        public Car(int car_id, string licenseplate, string brand, string model, String carclass)
        {
            this.car_id = car_id;
            this.licenseplate = licenseplate;
            this.brand = brand;
            this.model = model;
            this.carclass = carclass;
            occupied = false;
        }

        public int Car_id => car_id;
        public string Licenseplate => licenseplate;
        public string Brand => brand;
        public string Model => model;
        public string Carclass => carclass;
        public bool Occupied => occupied;
    }
}
