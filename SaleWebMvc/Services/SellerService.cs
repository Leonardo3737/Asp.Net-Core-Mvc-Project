using SaleWebMvc.Data;
using SaleWebMvc.Models;

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
    }
}