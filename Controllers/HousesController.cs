using System;
using System.Collections.Generic;
using System.Text.Json;
using gregslist.db;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(FakeDB.Houses);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{houseId}")]
    public ActionResult<IEnumerable<House>> GetById(string houseId)
    {
      try
      {
        return Ok(FakeDB.Houses.Find(house => house.Id == houseId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<IEnumerable<House>> Create([FromBody] House newHouse)
    {
      try
      {
        FakeDB.Houses.Add(newHouse);
        return Ok(newHouse);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{houseId}")]
    public ActionResult<IEnumerable<House>> Edit(string houseId, [FromBody] JsonElement edits)
    {
      try
      {
        int index = FakeDB.Houses.FindIndex(house => house.Id == houseId);
        House foundHouse = FakeDB.Houses[index];
        House oldHouse = new House(foundHouse);
        foundHouse.Edit(edits);
        return Ok(new Dictionary<string, House>() {
          {"Old:", oldHouse},
          {"New:", foundHouse}
        });
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{houseId}")]
    public ActionResult<IEnumerable<House>> Delete(string houseId)
    {
      try
      {
        House deleteHouse = FakeDB.Houses.Find(house => house.Id == houseId);
        FakeDB.Houses.Remove(deleteHouse);
        return Ok(new Dictionary<string, House>() {
          { "Deleted:", deleteHouse }
        });
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}