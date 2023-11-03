using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class DriverRepository : GenericRepository<Driver>, IDriver
{
    private readonly FormulaContext _context;
    public DriverRepository(FormulaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers
/*             .Include(p => p.tea)
 */            .ToListAsync();
    }

    public override async Task<Driver> GetByIdAsync(int id)
    {
        return await _context.Drivers
/*             .Include(p => p.Drivers)
 */            .FirstOrDefaultAsync(p => p.Id == id);
    }
}