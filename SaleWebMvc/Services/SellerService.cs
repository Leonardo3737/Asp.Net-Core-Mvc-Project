using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;
using SaleWebMvc.Services.Exceptions;

namespace SaleWebMvc.Services
{
    public class SellerService
    {
        private readonly SaleWebMvcContext _context;
        public SellerService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            obj.BirthDate = obj.BirthDate.ToUniversalTime();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int? Id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            _context.Seller.Remove(await FindByIdAsync(Id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(Seller obj)
        {
            if (!(await _context.Seller.AnyAsync(s => s.Id == obj.Id))) throw new NotFoundException("Id not found");
            try
            {
                obj.BirthDate = obj.BirthDate.ToUniversalTime();
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}