using CinemaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Ticket> Tickets { get; set; } //table
}