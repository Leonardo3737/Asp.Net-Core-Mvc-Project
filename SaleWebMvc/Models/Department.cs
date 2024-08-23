namespace SaleWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; }

        public Department() { }
        public Department(string name)
        {
            Name = name;
        }

        public void addSeller(Seller seller) 
        {
            Sellers.Add(seller);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.totalSales(initial, final));
        }
    }
}
