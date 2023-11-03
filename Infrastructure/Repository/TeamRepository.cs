using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class TeamRepository : GenericRepository<Team>, ITeam
{
    private readonly FormulaContext _context;
    public TeamRepository(FormulaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
/*             .Include(p => p.tea)
 */            .ToListAsync();
    }

    public override async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams
/*             .Include(p => p.Teams)
 */            .FirstOrDefaultAsync(p => p.Id == id);
    }
}