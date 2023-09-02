using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Environment;

namespace BWHazel.Data.TypedId.Examples.EFCore;

/// <summary>
/// People database context.
/// </summary>
public class PeopleDbContext : DbContext
{
    /// <summary>
    /// The database name.
    /// </summary>
    public const string DatabaseName = "people.db";

    /// <summary>
    /// Gets the path to the database.
    /// </summary>
    public string DatabasePath { get; }

    /// <summary>
    /// Gets or sets the people.
    /// </summary>
    public DbSet<Person> People { get; set; }

    /// <summary>
    /// Gets or sets the addresses.
    /// </summary>
    public DbSet<Address> Addresses { get; set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="PeopleDbContext"/> class.
    /// </summary>
    public PeopleDbContext()
    {
        string myDocumentsFolderPath = GetFolderPath(SpecialFolder.MyDocuments);
        this.DatabasePath = Path.Join(myDocumentsFolderPath, DatabaseName);
    }

    /// <summary>
    /// Configures the database.
    /// </summary>
    /// <param name="optionsBuilder">The options builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={this.DatabasePath}");
    }

    /// <summary>
    /// Configures the model on its creation.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    /// <remarks>
    /// It is in this method all registrations of typed IDs need to be performed.
    /// <list type="bullet">
    /// <item><see cref="Uuid{T}"/> IDs should be registered using the <see cref="PropertyBuilderExtensionsForUuid.IsTypedUuid{T}(PropertyBuilder{Uuid{T}})"/> method.</item>
    /// <item><see cref="IntId{T}"/> IDs should be registered using the <see cref="PropertyBuilderExtensionsForIntId.IsTypedUuid{T}(PropertyBuilder{IntId{T}})"/> method.</item>
    /// </list>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use the IsTypedUuid() method for a property of type Uuid<T>.
        modelBuilder.Entity<Person>()
            .Property(person => person.Id)
            .IsTypedUuid();

        // All properties using typed IDs need to be registered.
        modelBuilder.Entity<Person>()
            .Property(person => person.AddressId)
            .IsTypedIntId();

        // Use the IsTypedIntId() method for a property of type IntId<T>.
        modelBuilder.Entity<Address>()
            .Property(address => address.Id)
            .IsTypedIntId();
    }
}
