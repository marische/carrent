using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Domain
{
    public class Car
    {
        private readonly string brand;

        public Car(string brand)
        {
            this.brand = brand;
        }

        public string Brand => brand;
    }
}
