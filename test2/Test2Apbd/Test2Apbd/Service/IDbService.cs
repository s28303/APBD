using Test2Apbd.Entities;

namespace Test2Apbd.Service
{
    public interface IDbService
    {
        Task<Character?> GetCharacterById(int id);
        Task AddItemsToBackpack(IEnumerable<Backpack> backpacks);
        Task<bool> DoesItemExists(int id);
    }
}
