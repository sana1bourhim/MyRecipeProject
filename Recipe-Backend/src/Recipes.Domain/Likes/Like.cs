using System;


namespace Domain.Likes;

public class Like
{
    public Guid Id { get;  set; } = Guid.NewGuid();
    public Guid RecipeId { get; set; }
    public Guid UserId { get;  set; }
    public Like()
    {
        
    }
    public Like(Guid recipeId, Guid userId)
    {
        RecipeId = recipeId;
        UserId = userId;
    }
}
