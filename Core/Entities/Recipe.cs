namespace Core.Entities;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int preparationMinutes { get; set; }
    public int cookingMinutes { get; set; }
}