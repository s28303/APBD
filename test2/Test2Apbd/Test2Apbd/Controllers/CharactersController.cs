using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Test2Apbd.DTOs;
using Test2Apbd.Entities;
using Test2Apbd.Service;

namespace Test2Apbd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IDbService _dbService;

        public CharactersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{characterId}")]
        public async Task<IActionResult> GetCharacterData(int characterId)
        {
            var character = await _dbService.GetCharacterById(characterId);

            var characterDto = new GetCharacterDTO()
            {
                FirstName = character.FirstName,
                LastName = character.LastName,
                CurrentWeight = character.CurrentWeight,
                MaxWeight = character.MaxWeight,
                backpackItems = character.Backpacks.Select(ct => new GetItemsDto()
                {
                    ItemName = ct.Item.Name,
                    ItemWeight = ct.Item.Weight,
                    Amount = ct.Amount
                }).ToList(),
                Titles = character.CharacterTitles.Select(t => new GetTitleDto()
                {
                    Title = t.Title.Name,
                    AcquiredAt = t.AcquiredAt
                }).ToList()
            };

            return Ok(characterDto);
        }

        [HttpPost("{characterId}/backpacks")]
        public async Task<IActionResult> addNewItemToCharacter(int characterId, AddItemsDTO addItemsDto)
        {
            // check if item exists

            List<Backpack> backpacks = addItemsDto.AddItemsDto.Select(e => new Backpack()
            {
                CharacterId = characterId,
                ItemId = e.itemId,
                Amount = e.amount
            }).ToList();


            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _dbService.AddItemsToBackpack(backpacks);
                scope.Complete();
            }

            return Created("api/backpacks", backpacks);
        }
    }
}
