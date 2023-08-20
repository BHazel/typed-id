# Typed Integer (`IntId<T>`)

The typed integer, `IntId<T>`, is a typed ID based on integers.

## Creating Typed UUID IDs

To create integer based IDs:

* Use the parameterised constructor using a specified integer: `new Uuid<T>(5)`.

## Examples

```csharp
// Create an ID based on a specified integer.
int number = 5;
IntId<Entity> id = new IntId<Entity>(number);

// Convert an integer to an ID.
int number = 5;
IntId<Entity> id = number;

// Convert an ID to an integer.
IntId<Entity> id = new IntId<Entity>(5);
int number = id;
```