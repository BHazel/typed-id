namespace BWHazel.Data;

/// <summary>
/// Defines methods and properties for working with typed IDs.
/// </summary>
/// <typeparam name="T">The entity type this ID is associated with.</typeparam>
/// <typeparam name="U">The type of the underlying ID.</typeparam>
public interface IId<T, U>
{
    /// <summary>
    /// Gets or sets the ID value.
    /// </summary>
    U Value { get; set; }
}