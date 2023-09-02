using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BWHazel.Data;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines extension methods for <see cref="PropertyBuilder{TProperty}"/> to support the <see cref="Uuid{T}"/> typed ID.
/// </summary>
public static class PropertyBuilderExtensionsForUuid
{
    /// <summary>
    /// Configures the property so the typed ID property value is converted to and from the database as a GUID.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="propertyBuilder">The <see cref="PropertyBuilder{TProperty}"/> instance.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public static PropertyBuilder<Uuid<T>> IsTypedUuid<T>(this PropertyBuilder<Uuid<T>> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            idToDb => idToDb.Value,
            idFromDb => new(idFromDb)
        );
    }
}