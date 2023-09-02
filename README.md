# Typed ID

A library for strongly-typed IDs for your entities!

## Using Typed IDs

> Typed IDs are available in the **BWHazel.TypedId** NuGet package.

A typed ID is a generic type which is associated with an entity, for example with the `Person` and `Address` types below.  Notice how each of the IDs is tied to a specific entity type.

```csharp
using BWHazel.Data;

public class Person
{
    public Uuid<Person> PersonId { get; set; }
    public Uuid<Address> AddressId { get; set; }
}

public class Address
{
    public Uuid<Address> AddressId { get; set; }
}
```

These typed IDs can be used in methods:

```csharp
public bool IsAddressFor(Uuid<Person> personId, Uuid<Address> addressId) { }
```

These strongly typed IDs will ensure that IDs for different entities will not get confused.  For this example, if the `Person` and `Address` IDs were swapped in the method call then it would result in a compile-time error.

Additionally, each type can be implicitly interconverted between and comapred with the underlying ID type, for example the `Uuid<T>` type uses a GUID:

```csharp
Uuid<Person> personId = person.Id;
Guid personIdAsGuid = personId;

bool idEqualsGuid = personId == personIdAsGuid;
bool guidDoesNotEqualId = personIdAsGuid != personId;
```

## Supported Types

Currently the library supports the following ID types, all in the **BWHazel.Data** namespace.  Please see the detailed documentation, linked in the table below, for more examples.

| ID Type | Typed ID |
|-|-|
| [GUID](docs/uuid.md) | `Uuid<T>` |
| [Integer](docs/intid.md) | `IntId<T>` |

## Use with Entity Framework Core

> Entity Framework Core support for Typed IDs is available in the **BWHazel.TypedId.EntityFrameworkCore** NuGet package.

To use typed IDs in Entity Framework Core they need to be registered with database context when creating the model in the `DbContext.OnModelCreating()` method.  A helper method is provided to perform the correct mapping to database types for each typed ID in the **Microsoft.EntityFrameworkCoew** namespace.

Using the example `Person` and `Address` entities above this would look like the following.  Notice that all uses of a typed ID need to be registered.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>()
        .Property(person => person.PersonId)
        .IsTypedUuid();

    modelBuilder.Entity<Person>()
        .Property(person => person.AddressId)
        .IsTypedUuid();

    modelBuilder.Entity<Address>()
        .Property(address => address.AddressId)
        .IsTypedUuid();
}
```

For each supported typed ID type, the helper methods are:

| Typed ID | Helper Method |
|-|-|
| `Uuid<T>` | `IsTypedUuid<T>()` |
| `IntId<T>` | `IsTypedIntId<T>()` |

A more generic example can be seen [here](docs/ef-core.md).

## Example Programs

Example programs are included to demonstrate how to use Typed IDs and their Entity Framework Core support.

| Example | Functionality |
|-|-|
| [Basic Usage](examples/BWHazel.Data.TypedId.Examples.BasicUsage/README.md) | Creating typed IDs, how they interoperate with other typed IDs and underlying types and strong typing. |
| [Entity Framework Core](examples/BWHazel.Data.TypedId.Examples.EFCore/README.md) | Using typed IDs with Entity Framework Core. |

## Motivation

IDs provide a unique identifier for entity objects and are often based on GUIDs or integers, e.g. using the example above:

```csharp
public class Person
{
    public Guid PersonId { get; set; }
    public Guid AddressId { get; set; }
}

public class Address
{
    public Guid AddressId { get; set; }
}
```

However, this could result in runtime errors if the different IDs get confused, for example in the following method:

```csharp
public bool IsAddressFor(Guid personId, Guid addressId) { }
```

What if the person and address IDs were passed into the method in the wrong order?  As far as the compiler is concerned, no issue, but at runtime odd behaviour will result.

Hence, typed IDs!

## Installation

Typed ID and Entity Framework Core support can be installed from NuGet:

| Feature | NuGet Package |
|-|-|
| Typed ID | BWHazel.TypedId |
| Entity Framework Core Support | BWHazel.TypedId.EntityFrameworkCore |