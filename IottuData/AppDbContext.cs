using IottuModel;
using Microsoft.EntityFrameworkCore;

namespace IottuData;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MotoModel> Moto { get; set; }
}
