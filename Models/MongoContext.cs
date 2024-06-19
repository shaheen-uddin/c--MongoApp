
namespace MongoApp.Models;

using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDB.Driver;

public class MongoContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public static MongoContext Create(IMongoDatabase database) =>
     new(new DbContextOptionsBuilder<MongoContext>()
     .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
     .Options);

    public MongoContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().ToCollection("movies");
    }
}