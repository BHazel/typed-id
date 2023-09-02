using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BWHazel.Data;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines extension methods for <see cref="PropertyBuilder{TProperty}"/> to support the <see cref="IntId{T}"/> typed ID.
/// </summary>
public static class PropertyBuilderExtensionsForIntId
{
    /// <summary>
    /// Configures the property so the typed ID property value is converted to and from the database as an integer.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="propertyBuilder">The <see cref="PropertyBuilder{TProperty}"/> instance.</param>
    /// <returns>The same builder instance so that multiple configuration calls can be chained.</returns>
    public static PropertyBuilder<IntId<T>> IsTypedIntId<T>(this PropertyBuilder<IntId<T>> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            idToDb => idToDb.Value,
            idFromDb => new(idFromDb)
        );
    }
}