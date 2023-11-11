# Typed Integer (`IntId<T>`)

> Import the **BWHazel.Data** namespace.

The typed integer, `IntId<T>`, is a typed ID based on integers.

## Creating Typed Integer IDs

To create integer based IDs:

* Use the parameterised constructor using a specified integer: `new IntId<T>(5)`.

## Examples

```csharp
// Create an ID based on a specified integer.
int number = 5;
IntId<Entity> id = new(number);

// Convert an integer to an ID.
int number = 5;
IntId<Entity> id = number;

// Convert an ID to an integer.
IntId<Entity> id = new(5);
int number = id;

// Compare two IDs.
IntId<Entity> id1 = new(5);
IntId<Entity> id2 = new(5);
bool areEqual = id1 == id2;
bool areNotEqual = id1 != id2;

// Compare an ID with an integer.
IntId<Entity> id = new(5);
int number = 10;
bool areEqual = id == number;
bool areNotEqual = id != number;

// Compare an integer with an ID.
int number = 10;
IntId<Entity> id = new(5);
bool areEqual = number == id;
bool areNotEqual = number != id;
```