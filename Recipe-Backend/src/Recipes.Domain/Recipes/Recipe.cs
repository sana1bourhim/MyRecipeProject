using System;

namespace Domain.Recipes;

public class Recipe
{
    public Guid Id { get;  set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get;  set; }
    public Guid UserId { get; set; } = Guid.Empty; // auteur
    public string ImageUrl { get; set; } // URL ou chemin de l'image
    public Recipe()
    {
        UserId = Guid.NewGuid(); // génère un UserId fictif
    }


    public Recipe(string title, string description, Guid userId, string imageUrl = null)
    {
        Title = title;
        Description = description;
        UserId = userId;
        ImageUrl = imageUrl;
    }

    public void Update(string title, string description, string imageUrl = null)
    {
        Title = title;
        Description = description;
        if (imageUrl != null)
            ImageUrl = imageUrl;
    }
}
