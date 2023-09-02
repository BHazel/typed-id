using System.Text.Json;

namespace BWHazel.Data.TypedId.Examples.EFCore;

/// <summary>
/// Represents an address.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the ID.
    /// </summary>
    /// <remarks>
    /// Ensure when a typed ID is used as a primary key its generic type parameter is the same
    /// as the entity type.
    /// </remarks>
    public IntId<Address> Id { get; init; }

    /// <summary>
    /// Gets or sets the building name and/or number.
    /// </summary>
    public string? BuildingNameNumber { get; set; }

    /// <summary>
    /// Gets or sets the street.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the post code.
    /// </summary>
    public string? PostCode { get; set; }

    /// <summary>
    /// Returns this instance as a JSON string.
    /// </summary>
    /// <returns>This instance as a JSON string.</returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
