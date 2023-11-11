# Typed IDs with Entity Framework Core

> Import the **Microsoft.EntityFrameworkCore** namespace.

Typed IDs are seen as complex types by Entity Framework Core so need to be converted to their underlying types for persistence in a database.  Helper methods are included to configure this mapping when registering the typed IDs with a database context.

It should be noted that all usages of a typed ID need to be registered with the context, not just primary keys.

For example, the following two entity types use typed IDs:

```csharp
using BWHazel.Data;

public class EntityA
{
    public Uuid<EntityA> Id { get; set; }
    public IntId<EntityB> EntityBId { get; set; }
}

public class EntityB
{
    public IntId<EntityB> Id { get; set; }
}
```

These can be registered when creating the model in the database context:

```csharp
using Microsoft.EntityFrameworkCore;

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<EntityA>()
        .Property(entityA => entityA.Id)
        .IsTypedUuid();

    modelBuilder.Entity<EntityA>()
        .Property(entityA => entityA.EntityBId)
        .IsTypedIntId();

    modelBuilder.Entity<EntityB>()
        .Property(entityB => entityB.Id)
        .IsTypedIntId();
}
```

Each of the supported typed IDs has a helper method:

| Typed ID | Helper Method |
|-|-|
| `Uuid<T>` | `IsTypedUuid<T>()` |
| `IntId<T>` | `IsTypedIntId<T>()` |
| `StringId<T>` | `IsTypedStringId<T>()` |