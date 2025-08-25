using Domain.Recipes;
using Microsoft.AspNetCore.Mvc;
using Application.Recipes;
using Recipes.Application.Recipes.Commands;
using MediatR;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMediator _mediator;

    public RecipesController(IRecipeRepository recipeRepository, IMediator mediator)
    {
        _recipeRepository = recipeRepository;
        _mediator = mediator;
    }

  
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateRecipeDto dto)
    {
        string imageUrl = null;

        if (dto.Image != null && dto.Image.Length > 0)
        {
            // Générer un nom unique pour éviter les collisions
            var fileName = Guid.NewGuid() + Path.GetExtension(dto.Image.FileName);

            // Construire le chemin physique complet
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            // Créer le dossier si nécessaire
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            // Sauvegarder l'image
            await using var stream = new FileStream(filePath, FileMode.Create);
            await dto.Image.CopyToAsync(stream);

            // Stocker le chemin relatif pour que Angular puisse y accéder
            imageUrl = $"/images/{fileName}";
        }

        var recipe = new Recipe(dto.Title, dto.Description, dto.UserId, imageUrl);
        await _recipeRepository.AddAsync(recipe);

        return Ok(recipe.Id);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var recipes = await _recipeRepository.GetAllAsync();
        return Ok(recipes);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteRecipeCommand(id));
        return NoContent();
    }
}

public record CreateRecipeDto(string Title, string Description, Guid UserId, IFormFile Image);
