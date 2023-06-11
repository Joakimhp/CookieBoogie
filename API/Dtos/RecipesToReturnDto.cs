namespace API.Dtos;

public class RecipesToReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationMinutes { get; set; }
    public int CookingMinutes { get; set; }
    public int Servings { get; set; }
    public string PictureUrl { get; set; }
    public string RecipeType { get; set; }
}