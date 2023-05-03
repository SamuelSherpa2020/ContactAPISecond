using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactAPI.Data;

public class ContactApiDbContext:DbContext
{
    public ContactApiDbContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Contact> Contacts { get; set; }
}
