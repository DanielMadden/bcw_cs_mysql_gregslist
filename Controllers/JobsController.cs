using System.Collections.Generic;
using System;
using gregslist.Models;
using Microsoft.AspNetCore.Mvc;
using gregslist.db;
using System.Text.Json;

namespace gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Job>> GetAll()
    {
      try
      {
        return Ok(FakeDB.Jobs);
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
        return Ok(FakeDB.Jobs.Find(job => job.Id == jobId));
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
        FakeDB.Jobs.Add(newJob);
        return Ok(newJob);
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
        int index = FakeDB.Jobs.FindIndex(job => job.Id == jobId);
        Job foundJob = FakeDB.Jobs[index];
        Job oldJob = new Job(foundJob);
        foundJob.Edit(jobEdits);
        return Ok(new Dictionary<string, Job>() {
          {"Old:", oldJob},
          {"New:", foundJob}
        });
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
        Job deletedJob = FakeDB.Jobs.Find(job => job.Id == jobId);
        FakeDB.Jobs.Remove(deletedJob);
        return Ok(new Dictionary<string, Job>(){
          {"Deleted:", deletedJob}
        });
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}