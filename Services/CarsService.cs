using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using System.Text.Json;
using System;
using gregslist.Repositories;

namespace gregslist.Services
{
  public class CarsService
  {
    private readonly CarRepository _repository;

    public CarsService(CarRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<Car> Get()
    {
      return _repository.GetAll();
    }

    public Car GetById(string carId)
    {
      return _repository.GetById(carId);
    }

    public Car Create(Car newCar)
    {
      return _repository.Create(newCar);
    }

    public Car Edit(string carId, JsonElement carEdits)
    {
      Car toEdit = _repository.GetById(carId);
      toEdit.Edit(carEdits);
      return _repository.Edit(toEdit);
    }

    public string Delete(string carId)
    {
      int deletedRows = _repository.Delete(carId);
      return deletedRows + " rows deleted";
    }
  }
}