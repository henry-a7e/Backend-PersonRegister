using Microsoft.EntityFrameworkCore;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }

    }
}

