namespace Core.Entities;

public class Recipe : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationMinutes { get; set; }
    public int CookingMinutes { get; set; }
    public int Servings { get; set; }
    public RecipeType RecipeType { get; set; }
    public int RecipeTypeId { get; set; }
}