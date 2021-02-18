using System.Collections.Generic;
using System;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;
using gregslist.db;
using System.Text.Json;
using gregslist.Services;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {

    private JobsService _jobsService;

    public JobsController(JobsService jobsService)
    {
      _jobsService = jobsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> GetAll()
    {
      try
      {
        return Ok(_jobsService.Get());
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{jobId}")]
    public ActionResult<IEnumerable<Job>> GetById(string jobId)
    {
      try
      {
        return Ok(_jobsService.GetById(jobId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<IEnumerable<Job>> Create([FromBody] Job newJob)
    {
      try
      {
        return Ok(_jobsService.Create(newJob));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{jobId}")]
    public ActionResult<IEnumerable<Job>> Edit(string jobId, [FromBody] JsonElement jobEdits)
    {
      try
      {
        return Ok(_jobsService.Edit(jobId, jobEdits));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{jobId}")]
    public ActionResult<IEnumerable<Job>> Delete(string jobId)
    {
      try
      {
        return Ok(_jobsService.Delete(jobId));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}