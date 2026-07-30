using KittenRs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KittenRs.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    DbContext(options)
{

    public virtual DbSet<PostModel> Posts { get; set; } = default!;

}