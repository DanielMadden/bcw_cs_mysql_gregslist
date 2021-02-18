using System;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using gregslist.Services;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {

    private readonly CarsService _carsService;
    public CarsController(CarsService carsService)
    {
      _carsService = carsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(_carsService.Get());
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{carId}")]
    public ActionResult<Car> GetById(string carId)
    {
      try
      {
        return Ok(_carsService.GetById(carId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        return Ok(_carsService.Create(newCar));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]
    public ActionResult<Dictionary<string, Car>> Edit(string carId, [FromBody] JsonElement carEdits)
    {
      try
      {
        return Ok(_carsService.Edit(carId, carEdits));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{carId}")]
    public ActionResult<Dictionary<string, Car>> Delete(string carId)
    {
      try
      {
        return Ok(_carsService.Delete(carId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}