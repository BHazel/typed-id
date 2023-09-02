using System.Text.Json;

namespace BWHazel.Data.TypedId.Examples.EFCore;

/// <summary>
/// Represents a person.
/// </summary>
public class Person
{
    /// <summary>
    /// Gets or sets the ID.
    /// </summary>
    /// <remarks>
    /// Ensure when a typed ID is used as a primary key its generic type parameter is the same
    /// as the entity type.
    /// </remarks>
    public Uuid<Person> Id { get; init; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address ID.
    /// </summary>
    /// <remarks>
    /// When using typed IDs for reference keys, ensure the correct type ID and entity type
    /// parameter are the same as the reference entity.
    /// </remarks>
    public IntId<Address> AddressId { get; set; }

    /// <summary>
    /// Returns this instance as a JSON string.
    /// </summary>
    /// <returns>This instance as a JSON string.</returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
