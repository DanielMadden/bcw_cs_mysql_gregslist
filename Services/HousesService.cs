using System;
using System.Collections.Generic;
using System.Text.Json;
using gregslist.db;
using gregslist.Models;

namespace gregslist.Services
{
  public class HousesService
  {
    public IEnumerable<House> Get()
    {
      return FakeDB.Houses;
    }

    public House GetById(string houseId)
    {
      House found = FakeDB.Houses.Find(house => house.Id == houseId);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public House Create(House newHouse)
    {
      FakeDB.Houses.Add(newHouse);
      return newHouse;
    }

    public Dictionary<string, House> Edit(string houseId, JsonElement edits)
    {
      int index = FakeDB.Houses.FindIndex(house => house.Id == houseId);
      if (index == -1)
      {
        throw new Exception("Invalid Id");
      }
      House foundHouse = FakeDB.Houses[index];
      House oldHouse = new House(foundHouse);
      foundHouse.Edit(edits);
      return new Dictionary<string, House>() {
          {"Old:", oldHouse},
          {"New:", foundHouse}
      };
    }

    public Dictionary<string, House> Delete(string houseId)
    {
      House deleteHouse = FakeDB.Houses.Find(house => house.Id == houseId);
      if (deleteHouse == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Houses.Remove(deleteHouse);
      return new Dictionary<string, House>() {
          { "Deleted:", deleteHouse }
      };
    }
  }
}