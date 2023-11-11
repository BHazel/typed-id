using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BWHazel.Data;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines extension methods for <see cref="PropertyBuilder{TProperty}"/> to support the <see cref="StringId{T}"/> typed ID.
/// </summary>
public static class PropertyBuilderExtensionsForStringId
{
    /// <summary>
    /// Configures the property so the typed ID property value is converted to and from the database as a string.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="propertyBuilder">The <see cref="PropertyBuilder{TProperty}"/> instance.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public static PropertyBuilder<StringId<T>> IsTypedStringId<T>(this PropertyBuilder<StringId<T>> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            idToDb => idToDb.Value,
            idFromDb => new(idFromDb)
        );
    }
}