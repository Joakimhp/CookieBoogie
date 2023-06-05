namespace Core.Entities;

public class Recipe : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationMinutes { get; set; }
    public int CookingMinutes { get; set; }
}