using System;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(FakeDB.Cars);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{carId}")]
    public ActionResult<IEnumerable<Car>> GetById(string carId)
    {
      try
      {
        return Ok(FakeDB.Cars.Find(car => car.Id == carId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<IEnumerable<Car>> Create([FromBody] Car newCar)
    {
      try
      {
        FakeDB.Cars.Add(newCar);
        return Ok(newCar);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{carId}")]
    public ActionResult<IEnumerable<Car>> Delete(string carId)
    {
      try
      {
        Car foundCar = FakeDB.Cars.Find(car => car.Id == carId);
        FakeDB.Cars.Remove(foundCar);
        return Ok(foundCar);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]
    public ActionResult<IEnumerable<Dictionary<string, string>>> Edit(string carId, [FromBody] JsonElement carEdits)
    {
      try
      {
        int foundIndex = FakeDB.Cars.FindIndex(car => car.Id == carId);
        FakeDB.Cars[foundIndex].Edit(carEdits);
        return Ok(FakeDB.Cars[foundIndex]);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}