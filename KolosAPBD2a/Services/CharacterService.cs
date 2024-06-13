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

    public async Task AddProductsToBackPack(CreateBackPackRequestModel data, int id)
    {
        var characterId = await context.Characters
            .Where(c => c.Id == id).FirstOrDefaultAsync();
        if (characterId is null)
        {
            throw new NotFoundException($"Character with that id: {id} does not exists");
        }

        var itemsFromData = data.ProductsId.ToList();

        var items = await context.Items
            .Where(i => itemsFromData.Contains(i.Id))
            .ToListAsync();

        if (items.Count != itemsFromData.Count)
        {
            throw new NotFoundException("Not found some item");
        }

        var sumOfWeight = 0;
        for (int i = 0; i < items.Count(); i++)
        {
            sumOfWeight += items[i].Weight * data.ProductsId.Count(id => id == items[i].Id);
        }
        
        
    }
}