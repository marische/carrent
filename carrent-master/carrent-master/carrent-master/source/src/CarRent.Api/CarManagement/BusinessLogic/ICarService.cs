﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CarManagement.Domain
{
    public interface ICarService
    {
        IReadOnlyList<Car> GetAll();
        void writeCarIntoDB(Car car);
        void ReserveCar(Car car);

    }

}
