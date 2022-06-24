using BestPractices.Core.UnitOfWorks;

namespace BestPractices.Repository.UnitOfWorks;

public class UnitOfWork:IUnitOfWork
{
    private AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}