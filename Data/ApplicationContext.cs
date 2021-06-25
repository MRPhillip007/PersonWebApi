using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContex: DbContext
    {
        public DbSet<Person> Persons{get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString: @"server=localhost; user=andersen; database=PersonApi;", new MySqlServerVersion("8.0.25"));
        }


    }
}