using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Interface
{
    public class CarDto
    {
        public int Car_id { get; set; }
        public string Licenseplate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Carclass { get; set; }
        public bool Occupied { get; set; }
    }
}
