using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using System.Text.Json;
using System;

namespace gregslist.Services
{
  public class CarsService
  {
    public IEnumerable<Car> Get()
    {
      return FakeDB.Cars;
    }

    public Car GetById(string carId)
    {
      Car found = FakeDB.Cars.Find(car => car.Id == carId);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public Car Create(Car newCar)
    {
      FakeDB.Cars.Add(newCar);
      return newCar;
    }

    public Dictionary<string, Car> Edit(string carId, JsonElement carEdits)
    {
      int index = FakeDB.Cars.FindIndex(car => car.Id == carId);
      if (index == -1)
      {
        throw new Exception("Invalid Id");
      }
      Car foundCar = FakeDB.Cars[index];
      Car oldCar = new Car(foundCar);
      foundCar.Edit(carEdits);
      return new Dictionary<string, Car>(){
          {"Old:", oldCar},
          {"New:", foundCar}
      };
    }

    public Dictionary<string, Car> Delete(string carId)
    {
      Car foundCar = FakeDB.Cars.Find(car => car.Id == carId);
      if (foundCar == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Cars.Remove(foundCar);
      return new Dictionary<string, Car>(){
          {"Deleted:", foundCar}
      };
    }
  }
}