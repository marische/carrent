using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Api.CarManagement.Domain;
using CarRent.Api.CarManagement.Interface;
using CarRent.Api.CarManagement.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        // GET: api/Car
        [HttpGet]
        public IEnumerable<CarDto> Get()
        {
            IReadOnlyList<Car> cars = carService.GetAll();
            return cars.Select(c => new CarDto {
                Car_id = c.Car_id,
                Licenseplate = c.Licenseplate,
                Brand = c.Brand,
                Model = c.Model,
                Carclass = c.Carclass,
                Occupied = c.Occupied
                });
        }

        /*
         * Car erstellen
         * (Im JSON einen neues Auto erstellen, dann POST-Call senden)
         * 
         * POST: api/Car
         * */
        [HttpPost]
        public void Post([FromBody] IReadOnlyList<CarDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {
                Car car = new Car(
                dto[i].Car_id,
                dto[i].Licenseplate,
                dto[i].Brand,
                dto[i].Model,
                dto[i].Carclass
                );
                
                carService.writeCarIntoDB(car);
            }
        }



        /*
         * Car reservieren
         * (Im JSON "Occupied" auf true setzten, dann PUT-Call senden)
         * 
         * PUT: api/Car/id
         * */
        [HttpPut("{id}")]
        public void Put([FromBody] IReadOnlyList<CarDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {

                Car car = new Car(
                dto[i].Car_id,
                dto[i].Licenseplate,
                dto[i].Brand,
                dto[i].Model,
                dto[i].Carclass
                );

                if (dto[i].Occupied == true)
                {
                    Console.WriteLine("Car already occupied");
                }

                carService.ReserveCar(car);

            }
        }

        // DELETE: api/Car/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            carService.DeleteCar(id);
        }
    }
}