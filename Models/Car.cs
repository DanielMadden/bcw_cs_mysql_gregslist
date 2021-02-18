using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace gregslist.Models
{
  public class Car
  {
    public int Id { get; set; }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public int Price { get; set; }
    public string Image { get; set; } = "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8Mnx8Y2Fyc3xlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&w=1000&q=80";

    // Dictionary<string, dynamic> variables = new Dictionary<string, dynamic>();

    // Parameterless constructor
    public Car() { }

    // Parameter constructor
    public Car(string make, string model, int price, string image)
    {
      Make = make;
      Model = model;
      Price = price;
      Image = image;
    }

    // Clone constructor
    public Car(Car clone)
    {
      Id = clone.Id;
      Make = clone.Make;
      Model = clone.Model;
      Price = clone.Price;
      Image = clone.Image;
    }

    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("make", out JsonElement newMake)) { Make = newMake.ToString(); }
      if (edits.TryGetProperty("model", out JsonElement newModel)) { Model = newModel.ToString(); }
      if (edits.TryGetProperty("price", out JsonElement newPrice)) { Price = newPrice.GetInt32(); }
      if (edits.TryGetProperty("image", out JsonElement newImage)) { Image = newImage.ToString(); }
    }

  }
}