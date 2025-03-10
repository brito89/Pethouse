
using Microsoft.EntityFrameworkCore;
using PethouseAPI.Data;

namespace PethouseAPI.Data.Seed;

public class DataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Migrate()
    {
        await _context.Database.MigrateAsync();
    }
}