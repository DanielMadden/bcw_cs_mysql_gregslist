using System.Collections.Generic;
using System.Data;
using Dapper;
using gregslist.Models;

namespace gregslist.Repositories
{
  public class CarRepository
  {
    public readonly IDbConnection _db;

    public CarRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Car> GetAll()
    {
      string sql = "SELECT * FROM cars;";
      return _db.Query<Car>(sql);
    }

    public Car GetById(string id)
    {
      string sql = "SELECT * FROM cars WHERE id = @id";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });
    }

    public Car Create(Car newCar)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, price, image)
      VALUES
      (@Make, @Model, @Price, @Image);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCar);
      string sqlReturn = "SELECT * FROM cars WHERE id = @id;";
      return _db.QueryFirstOrDefault<Car>(sqlReturn, new { id });
    }

    public int Delete(string id)
    {
      string sql = "DELETE FROM cars WHERE id = @id";
      return _db.Execute(sql, new { id });
    }

    public Car Edit(Car newCar)
    {
      string sql = @"
      UPDATE cars
      SET
        make = @Make,
        model = @Model,
        price = @Price,
        image = @Image
      WHERE id = @Id;
      SELECT * FROM cars WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Car>(sql, newCar);
    }
  }
}