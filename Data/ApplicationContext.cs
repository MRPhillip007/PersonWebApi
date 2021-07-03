using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContex: DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options): base(options)
        {
            // Constructor
        }
        public DbSet<Person> Persons{get; set;}
        


    }
}