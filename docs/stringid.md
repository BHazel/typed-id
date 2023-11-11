# Typed String (`StringId<T>`)

> Import the **BWHazel.Data** namespace.

The typed string, `StringId<T>`, is a typed ID based on strings.

## Creating Typed String IDs

To create string based IDs:

* Use the parameterised constructor using a specified string: `new StringId<T>("123")`.

## Examples

```csharp
// Create an ID based on a specified string.
string stringValue = "123";
StringId<Entity> id = new(stringValue);

// Convert a string to an ID.
string stringValue = "123";
StringId<Entity> id = stringValue;

// Convert an ID to a string.
StringId<Entity> id = new("123");
string stringValue = id;

// Compare two IDs.
StringId<Entity> id1 = new("123");
StringId<Entity> id2 = new("123");
bool areEqual = id1 == id2;
bool areNotEqual = id1 != id2;

// Compare an ID with a string.
StringId<Entity> id = new("123");
string stringValue = "456";
bool areEqual = id == stringValue;
bool areNotEqual = id != stringValue;

// Compare a string with an ID.
string stringValue = "123";
StringId<Entity> id = new("456");
bool areEqual = stringValue == id;
bool areNotEqual = stringValue != id;
```