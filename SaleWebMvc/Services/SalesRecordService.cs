using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;

namespace SaleWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SaleWebMvcContext _context;
        public SalesRecordService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                minDate = minDate.Value.ToUniversalTime();
                result = result.Where(s => s.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                maxDate = maxDate.Value.ToUniversalTime();
                result = result.Where(s => s.Date <= maxDate.Value);
            }


            return await result.Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date.ToUniversalTime())
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                minDate = minDate.Value.ToUniversalTime();
                result = result.Where(s => s.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                maxDate = maxDate.Value.ToUniversalTime();
                result = result.Where(s => s.Date <= maxDate.Value);
            }


            return await result.Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date.ToUniversalTime())
                .GroupBy(s=> s.Seller.Department)
                .ToListAsync();
        }
    }
}
