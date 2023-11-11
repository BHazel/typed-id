using System.Text.Json;

namespace BWHazel.Data.TypedId.Examples.EFCore;

/// <summary>
/// Represents a telephone number.
/// </summary>
public class TelephoneNumber
{
    /// <summary>
    /// Gets or sets the ID.
    /// </summary>
    /// <remarks>
    /// Ensure when a typed ID is used as a primary key its generic type parameter is the same
    /// as the entity type.
    /// 
    /// Additionally, for this example the ID will store the telephone number.
    /// </remarks>
    public StringId<TelephoneNumber> Id { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Returns this instance as a JSON string.
    /// </summary>
    /// <returns>This instance as a JSON string.</returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}