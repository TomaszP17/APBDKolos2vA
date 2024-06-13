using KolosAPBD2a.Contexts;
using KolosAPBD2a.Exceptions;
using KolosAPBD2a.Models;
using KolosAPBD2a.RequestModels;
using KolosAPBD2a.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD2a.Services;

public class CharacterService(DatabaseContext context) : ICharacterService
{
    public async Task<GetCharacterResonseModel> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters
            .Where(e => e.Id == id)
            .Select(e => new GetCharacterResonseModel
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CurrentWeight = e.CurrentWeight,
                MaxWeight = e.MaxWeight,
                BackPackItems = e.BackPacks
                    .Where(bp => bp.CharacterId == id)
                    .Select(bp => new GetItemResponseModel
                    {
                        ItemName = bp.Item.Name,
                        ItemWeight = bp.Item.Weight,
                        Amount = bp.Amount
                    }).ToList(),
                Titles = e.CharacterTitles
                    .Where(ct => ct.CharacterId == id)
                    .Select(ct => new GetCharacterTitleResponseModel
                    {
                        Title = ct.Title.Name,
                        AquiredAt = ct.AcquiredAt
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"character with that id: {id} is not found");
        }
        
        return result;
    }

    public async Task<IEnumerable<GetBackPackResponseModel>> AddProductsToBackPack(CreateBackPackRequestModel data, int id)
    {
        var character = context.Characters
            .Include(c => c.BackPacks)
            .FirstOrDefault(e => e.Id == id);
    
    if (character is null)
    {
        throw new NotFoundException($"Character with that id: {id} does not exist");
    }

    var itemsFromData = data.ProductsId;

    var items = await context.Items
        .Where(i => itemsFromData.Contains(i.Id))
        .ToListAsync();

    if (items.Count != itemsFromData.Count)
    {
        throw new NotFoundException("Some items not found");
    }

    var sumOfWeight = items.Sum(item => item.Weight);

    var characterFreeWeight = character.MaxWeight - character.CurrentWeight;

    if (sumOfWeight > characterFreeWeight)
    {
        throw new TooBigWeightException("These items are too heavy for this character");
    }

    foreach (var productId in data.ProductsId)
    {
        var item = items.FirstOrDefault(it => it.Id == productId);

        if (item == null) continue;

        var characterBackPack = character.BackPacks.FirstOrDefault(bp => bp.ItemId == item.Id);

        if (characterBackPack != null)
        {
            characterBackPack.Amount += 1;
        }
        else
        {
            var newBackPack = new BackPack
            {
                CharacterId = id,
                ItemId = productId,
                Amount = 1
            };

            await context.BackPacks.AddAsync(newBackPack);
        }

        character.CurrentWeight += item.Weight;
    }

    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        throw new Exception("An error occurred while updating the database", ex);
    }

    return character.BackPacks.Select(bp => new GetBackPackResponseModel
    {
        Amount = bp.Amount,
        ItemId = bp.ItemId,
        CharacterId = bp.CharacterId
    }).ToList();
}

}