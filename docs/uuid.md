# Typed UUID (`Uuid<T>`)

> Import the **BWHazel.Data** namespace.

The typed UUID, `Uuid<T>`, is a typed ID based on GUIDs.

## Creating Typed UUID IDs

There are 3 ways to create UUID based IDs:

* For a random GUID:
    * Call `Uuid<T>.NewId()`.
    * Use the empty constructor `new Uuid<T>()`.
* For a specified GUID:
    * Use the parameterised constructor: `new Uuid<T>(Guid.NewGuid())`.

## Examples

```csharp
// Create a new random UUID for type Entity.
Uuid<Entity> id = Uuid<Entity>.NewId();
Uuid<Entity> id = new();

// Create a UUID based on a specified GUID.
Guid guid = Guid.NewGuid();
Uuid<Entity> id = new(guid);

// Convert a GUID to a UUID.
Guid guid = Guid.NewGuid();
Uuid<Entity> id = guid;

// Convert a UUID to a GUID.
Uuid<Entity> id = Uuid<Entity>.NewId();
Guid guid = id;

// Compare two IDs.
Uuid<Entity> id1 = Uuid<Entity>.NewId();
Uuid<Entity> id2 = Uuid<Entity>.NewId();
bool areEqual = id1 == id2;
bool areNotEqual = id1 != id2;

// Compare an ID with a GUID.
Uuid<Entity> id = Uuid<Entity>.NewId();
Guid guid = Guid.NewGuid();
bool areEqual = id == guid;
bool areNotEqual = id != guid;

// Compare a GUID with an ID.
Guid guid = Guid.NewGuid();
Uuid<Entity> id = Uuid<Entity>.NewId();
bool areEqual = guid == id;
bool areNotEqual = guid != id;
```