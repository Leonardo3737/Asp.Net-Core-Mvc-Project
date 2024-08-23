using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebMvc.Models;
using SaleWebMvc.Models.Enums;

namespace SaleWebMvc.Data
{
    public class SeedingService
    {
        private SaleWebMvcContext _context;

        public SeedingService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public void seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;
            }

            #region <------- Datas --------->

            Department d1 = new Department("Computers");
            Department d2 = new Department("Eletronics");
            Department d3 = new Department("Fashion");
            Department d4 = new Department("Books");

            Seller s1 = new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21).ToUniversalTime(), 1000.0, d1);
            Seller s2 = new Seller("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31).ToUniversalTime(), 3500.0, d2);
            Seller s3 = new Seller("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15).ToUniversalTime(), 2200.0, d1);
            Seller s4 = new Seller("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30).ToUniversalTime(), 3000.0, d4);
            Seller s5 = new Seller("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9).ToUniversalTime(), 4000.0, d3);
            Seller s6 = new Seller("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4).ToUniversalTime(), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(new DateTime(2018, 09, 25).ToUniversalTime(), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(new DateTime(2018, 09, 4).ToUniversalTime(), 7000.0, SaleStatus.Billed, s5);
            SalesRecord r3 = new SalesRecord(new DateTime(2018, 09, 13).ToUniversalTime(), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord r4 = new SalesRecord(new DateTime(2018, 09, 1).ToUniversalTime(), 8000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(new DateTime(2018, 09, 21).ToUniversalTime(), 3000.0, SaleStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(new DateTime(2018, 09, 15).ToUniversalTime(), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(new DateTime(2018, 09, 28).ToUniversalTime(), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(new DateTime(2018, 09, 11).ToUniversalTime(), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord(new DateTime(2018, 09, 14).ToUniversalTime(), 11000.0, SaleStatus.Pending, s6);
            SalesRecord r10 = new SalesRecord(new DateTime(2018, 09, 7).ToUniversalTime(), 9000.0, SaleStatus.Billed, s6);
            SalesRecord r11 = new SalesRecord(new DateTime(2018, 09, 13).ToUniversalTime(), 6000.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(new DateTime(2018, 09, 25).ToUniversalTime(), 7000.0, SaleStatus.Pending, s3);
            SalesRecord r13 = new SalesRecord(new DateTime(2018, 09, 29).ToUniversalTime(), 10000.0, SaleStatus.Billed, s4);
            SalesRecord r14 = new SalesRecord(new DateTime(2018, 09, 4).ToUniversalTime(), 3000.0, SaleStatus.Billed, s5);
            SalesRecord r15 = new SalesRecord(new DateTime(2018, 09, 12).ToUniversalTime(), 4000.0, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(new DateTime(2018, 10, 5).ToUniversalTime(), 2000.0, SaleStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(new DateTime(2018, 10, 1).ToUniversalTime(), 12000.0, SaleStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(new DateTime(2018, 10, 24).ToUniversalTime(), 6000.0, SaleStatus.Billed, s3);
            SalesRecord r19 = new SalesRecord(new DateTime(2018, 10, 22).ToUniversalTime(), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(new DateTime(2018, 10, 15).ToUniversalTime(), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(new DateTime(2018, 10, 17).ToUniversalTime(), 9000.0, SaleStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(new DateTime(2018, 10, 24).ToUniversalTime(), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(new DateTime(2018, 10, 19).ToUniversalTime(), 11000.0, SaleStatus.Canceled, s2);
            SalesRecord r24 = new SalesRecord(new DateTime(2018, 10, 12).ToUniversalTime(), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r25 = new SalesRecord(new DateTime(2018, 10, 31).ToUniversalTime(), 7000.0, SaleStatus.Billed, s3);
            SalesRecord r26 = new SalesRecord(new DateTime(2018, 10, 6).ToUniversalTime(), 5000.0, SaleStatus.Billed, s4);
            SalesRecord r27 = new SalesRecord(new DateTime(2018, 10, 13).ToUniversalTime(), 9000.0, SaleStatus.Pending, s1);
            SalesRecord r28 = new SalesRecord(new DateTime(2018, 10, 7).ToUniversalTime(), 4000.0, SaleStatus.Billed, s3);
            SalesRecord r29 = new SalesRecord(new DateTime(2018, 10, 23).ToUniversalTime(), 12000.0, SaleStatus.Billed, s5);
            SalesRecord r30 = new SalesRecord(new DateTime(2018, 10, 12).ToUniversalTime(), 5000.0, SaleStatus.Billed, s2);

            #endregion

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
