using System;
using System.Collections.Generic;
using System.Text.Json;
using gregslist.db;
using gregslist.Models;
using gregslist.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    private HousesService _housesService;

    public HousesController(HousesService housesService)
    {
      _housesService = housesService;
    }


    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(_housesService.Get());
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
        return Ok(_housesService.GetById(houseId));
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
        return Ok(_housesService.Create(newHouse));
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
        return Ok(_housesService.Edit(houseId, edits));
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
        return Ok(_housesService.Delete(houseId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}