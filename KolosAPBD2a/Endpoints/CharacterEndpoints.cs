using FluentValidation;
using KolosAPBD2a.Exceptions;
using KolosAPBD2a.RequestModels;
using KolosAPBD2a.Services;
using KolosAPBD2a.Validators;

namespace KolosAPBD2a.Endpoints;

public static class CharacterEndpoints
{
    public static void RegisterCharactersEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("characters");

        group.MapGet("{id:int}", async (int id, ICharacterService service) =>
        {
            try
            {
                return Results.Ok(await service.GetCharacterByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
        
        group.MapPost("{id:int}/backpacks", async (
            int id,
            CreateBackPackRequestModel data,
            ICharacterService service,
            IValidator<CreateBackPackRequestModel> validator) =>
        {
            var validate = await validator.ValidateAsync(data);
            if (!validate.IsValid)
            {
                return Results.ValidationProblem(validate.ToDictionary());
            }

            try
            {
                var backpacks = await service.AddProductsToBackPack(data, id);
                return Results.Ok(backpacks);
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (TooBigWeightException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}