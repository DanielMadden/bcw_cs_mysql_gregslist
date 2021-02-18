using System.Collections.Generic;
using gregslist.db;
using gregslist.Models;
using System;
using System.Text.Json;

namespace gregslist.Services
{
  public class JobsService
  {
    public IEnumerable<Job> Get()
    {
      return FakeDB.Jobs;
    }

    public Job GetById(string jobId)
    {
      Job found = FakeDB.Jobs.Find(job => job.Id == jobId);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public Job Create(Job newJob)
    {
      FakeDB.Jobs.Add(newJob);
      return newJob;
    }

    public Dictionary<string, Job> Edit(string jobId, JsonElement jobEdits)
    {
      int index = FakeDB.Jobs.FindIndex(job => job.Id == jobId);
      if (index == -1)
      {
        throw new Exception("Invalid Id");
      }
      Job foundJob = FakeDB.Jobs[index];
      Job oldJob = new Job(foundJob);
      foundJob.Edit(jobEdits);
      return new Dictionary<string, Job>() {
          {"Old:", oldJob},
          {"New:", foundJob}
      };
    }

    public Dictionary<string, Job> Delete(string jobId)
    {
      Job deletedJob = FakeDB.Jobs.Find(job => job.Id == jobId);
      if (deletedJob == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Jobs.Remove(deletedJob);
      return new Dictionary<string, Job>(){
          {"Deleted:", deletedJob}
      };
    }
  }
}