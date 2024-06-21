using Microsoft.EntityFrameworkCore;
using Test2Apbd.Data;
using Test2Apbd.Entities;

namespace Test2Apbd.Service
{
    public class DbService : IDbService
    {
        private readonly ApplicationContext _context;
        public DbService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Character?> GetCharacterById(int id)
        {
            return await _context.Characters
                .Include(e => e.Backpacks)
                .ThenInclude(e => e.Item)
                .Include(e => e.CharacterTitles)
                .ThenInclude(e => e.Title)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
