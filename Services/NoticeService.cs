using Microsoft.EntityFrameworkCore;
using SampleWebApplication1.Models;

namespace Services
{
    public class NoticeService
    {
        private readonly AppDbContext _context;

        public NoticeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NoticeViewModel> DetailsAsync(int? id)
        {
            if (id == null || _context.notices == null)
            {
                return null;
            }

            var notice = await _context.notices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return null;
            }

            return notice;
        }

        public async Task<IEnumerable<NoticeViewModel>> IndexAsinc()
        {
            return await _context.notices.ToListAsync();
        }

        public async Task CreateAsync(NoticeViewModel notice)
        {
            _context.Add(notice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (NoticeViewModel notice)
        {
            _context.Update(notice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }




    }
}