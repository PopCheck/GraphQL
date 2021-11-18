using Microsoft.EntityFrameworkCore;
using MyShop.API.Context;
using MyShop.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.API.Repositories
{
    public class CustomerRepository
    {
        private readonly SqlDbContext sqlDbContext;

        public CustomerRepository(SqlDbContext context)
        {
            sqlDbContext = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await sqlDbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await sqlDbContext.Customer.FindAsync(id);
        }
    }
}
