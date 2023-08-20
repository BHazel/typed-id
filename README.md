# Typed ID

A library for strongly-typed IDs for your entities!

For examples please see the **Using Typed IDs** section below.

## Motivation

IDs provide a unique identifier for entity objects and are often based on GUIDs or integers, e.g.

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

## Using Typed IDs

A typed ID is a generic type which is associated with an entity.  The above example can be converted as below:

```csharp
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

And these typed IDs can be used in methods, as above:

```csharp
public bool IsAddressFor(Uuid<Person> personId, Uuid<Address> addressId) { }
```

So, if the person and address IDs were confused and passed into the method incorrectly, compiler error!

Additionally, each type can be implicitly interconverted between the underlying ID type.

## Supported Types

Currently the library supports the following ID types:

| ID Type | Typed ID |
|-|-|
| [GUID](docs/uuid.md) | `Uuid<T>` |
| [Integer](docs/intid.md) | `IntId<T>` |

## Installation

Typed ID can be installed from NuGet:

```sh
dotnet add package BWHazel.TypedId
```