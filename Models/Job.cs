using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace gregslist.Models
{
  public class Job
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public string Title { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public int Wage { get; set; }
    [Required]
    public string Description { get; set; }
    public string Image { get; set; } = "https://welpmagazine.com/wp-content/uploads/2020/11/1559674671-2023.jpg";

    // Constructor: Empty
    public Job() { }
    // Constructor: Parameters
    public Job(string title, string company, int wage, string description, string image)
    {
      Title = title;
      Company = company;
      Wage = wage;
      Description = description;
      Image = image;
    }
    // Constructor: Clone
    public Job(Job clone)
    {
      Id = clone.Id;
      Title = clone.Title;
      Company = clone.Company;
      Wage = clone.Wage;
      Description = clone.Description;
      Image = clone.Image;
    }
    // Edit Job
    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("title", out JsonElement newTitle)) { Title = newTitle.ToString(); }
      if (edits.TryGetProperty("company", out JsonElement newCompany)) { Company = newCompany.ToString(); }
      if (edits.TryGetProperty("wage", out JsonElement newWage)) { Wage = newWage.GetInt32(); }
      if (edits.TryGetProperty("description", out JsonElement newDescription)) { Description = newDescription.ToString(); }
      if (edits.TryGetProperty("image", out JsonElement newImage)) { Image = newImage.ToString(); }
    }
  }
}