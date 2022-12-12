using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Ticket> Tickets { get; set; } //table
    public DbSet<Film> Films { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Cashier> Cashiers { get; set; }
}