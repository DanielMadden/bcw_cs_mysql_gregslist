using System;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{
  public class House
  {
    public string Id { get; } = Guid.NewGuid().ToString();
    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Price { get; set; }
    public string Image { get; set; } = "https://www.brickunderground.com/sites/default/files/styles/blog_primary_image/public/blog/images/022719_boisemain.jpg";

    // Parameterless constructor
    public House() { }

    // Parameter constructor
    public House(int bedrooms, int bathrooms, int year, int price, string image)
    {
      Bedrooms = bedrooms;
      Bathrooms = bathrooms;
      Year = year;
      Price = price;
      Image = image;
    }

    public House(House copy)
    {
      Id = copy.Id;
      Bedrooms = copy.Bedrooms;
      Bathrooms = copy.Bathrooms;
      Year = copy.Year;
      Price = copy.Price;
      Image = copy.Image;
    }

    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("bedrooms", out JsonElement newBedrooms)) { Bedrooms = newBedrooms.GetInt32(); }
      if (edits.TryGetProperty("bathrooms", out JsonElement newBathrooms)) { Bathrooms = newBathrooms.GetInt32(); }
      if (edits.TryGetProperty("year", out JsonElement newYear)) { Year = newYear.GetInt32(); }
      if (edits.TryGetProperty("price", out JsonElement newPrice)) { Price = newPrice.GetInt32(); }
      if (edits.TryGetProperty("image", out JsonElement newImage)) { Image = newImage.ToString(); }
    }
  }
}