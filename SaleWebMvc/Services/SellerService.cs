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

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.BirthDate = obj.BirthDate.ToUniversalTime();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int? Id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.Seller.Remove(FindById(Id));
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!(_context.Seller.Any(s => s.Id == obj.Id))) throw new NotFoundException("Id not found");
            try
            {
                obj.BirthDate = obj.BirthDate.ToUniversalTime();
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}