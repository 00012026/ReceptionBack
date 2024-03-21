using Reception_system.DAL;
using Reception_system.Model;
using Microsoft.EntityFrameworkCore;


namespace Reception_system.Repositories
{
    public class VisitorRepository : IVisitorRepository<Visitor>
    {
        private readonly ReceptionDbContext _context;
        public VisitorRepository(ReceptionDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Visitor entity)
        {
            await _context.Visitors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a2dl = await _context.Visitors.FindAsync(id);
            if (a2dl != null)
            {
                _context.Visitors.Remove(a2dl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Visitor>> GetAllAsync()
        {
            return await _context.Visitors.ToArrayAsync();
        }

        public async Task<Visitor> GetByIDAsync(int id)
        {
            return await _context.Visitors.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Visitor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
