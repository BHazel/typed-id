/* TYPED ID EXAMPLE: BASIC USAGE
 * This example demonstrates how to create typed IDs, both UUID and Int ID,
 * how they can interconvert between their underlying ID types and how they
 * provide type safety.
 * 
 * The example code is split into 3 sections:
 * 1. UUID Examples
 * 2. Int ID Examples
 * 3. Type Safety
 */

// Import the BWHazel.Data namespace where the typed IDs reside.
using static System.Console;
using BWHazel.Data;
using BWHazel.Data.TypedId.Examples.BasicUsage;
using System;

WriteLine("*** TYPED ID EXAMPLE: BASIC USAGE ***");

// UUID EXAMPLES
WriteLine("* UUID Examples *");

// Create an ID using the NewId() method to generate an ID using a random GUID.
// The empty constructor can also be used for the same result.
Uuid<TestEntityA> idA1 = Uuid<TestEntityA>.NewId();

// Create an ID using the constructor with a specified GUID.
Guid guidA2 = Guid.NewGuid();
Uuid<TestEntityA> idA2 = new(guidA2);

// The typed ID overrides ToString() to return the underlying GUID value.
WriteLine(idA1);
WriteLine(idA2);

// Typed IDs and their underlying type can implicitly interconvert.
Guid idA1Guid = idA1;
Uuid<TestEntityA> idA2Uuid = guidA2;
WriteLine(idA1Guid);
WriteLine(idA2Uuid);

// Typed IDs can be compared using standard equality and inequality operators.
bool idA1EqualsIdA2 = idA1 == idA2;
bool idA1DoesNotEqualIdA2 = idA1 != idA2;
WriteLine(idA1EqualsIdA2);
WriteLine(idA1DoesNotEqualIdA2);

// Typed IDs and their underlying type can be compared with both equality and inequality operators.
// Either type can be on either side of the operation.
bool idA1GuidEqualsIdA1 = idA1Guid == idA1;
bool idA1EqualsIdA1Guid = idA1 == idA1Guid;
WriteLine(idA1GuidEqualsIdA1);
WriteLine(idA1EqualsIdA1Guid);

Guid randomGuid = Guid.NewGuid();
bool idA2DoesNotEqualRandomGuid = idA2 != randomGuid;
bool randomGuidDoesNotEqualIdA2 = randomGuid != idA2;
WriteLine(idA2DoesNotEqualRandomGuid);
WriteLine(randomGuidDoesNotEqualIdA2);

// INT ID EXAMPLES
WriteLine("* Int ID Examples *");

// Create an ID using the constructor with a specified int value.
Random random = new();
int intB1 = random.Next();
int intB2 = 10;
IntId<TestEntityB> idB1 = new IntId<TestEntityB>(intB1);
IntId<TestEntityB> idB2 = new IntId<TestEntityB>(intB2);

// As with the UUID typed ID, ToString() is overrideden to return the underlying int value.
WriteLine(idB1);
WriteLine(idB2);

// Typed IDs and their underlying type can implicitly interconvert.
int idB1int = idB1;
IntId<TestEntityB> idB2IntId = intB2;
WriteLine(idB1int);
WriteLine(idB2IntId);

// Typed IDs can be compared using standard equality and inequality operators.
bool idB1EqualsIdB2 = idB1 == idB2;
bool idB1DoesNotEqualIdB2 = idB1 != idB2;
WriteLine(idB1EqualsIdB2);
WriteLine(idB1DoesNotEqualIdB2);

// Typed IDs and their underlying type can be compared with both equality and inequality operators.
// Either type can be on either side of the operation.
bool idB1IntEqualsIdB1 = idB1int == idB1;
bool idB1EqualsIdB1Int = idB1 == idB1int;
WriteLine(idB1IntEqualsIdB1);
WriteLine(idB1EqualsIdB1Int);

int randomInt = random.Next();
bool idB2DoesNotEqualRandomInt = idB2 != randomInt;
bool randomIntDoesNotEqualIdB2 = randomInt != idB2;
WriteLine(idB2DoesNotEqualRandomInt);
WriteLine(randomIntDoesNotEqualIdB2);

// TYPE SAFETY EXAMPLES
// Please uncomment the code below to see how typed IDs provide type safety.

// The same typed ID but with different entities will result in a compile-time error.
// Uuid<TestEntityA> testUuidA = Uuid<TestEntityA>.NewId();
// Uuid<TestEntityB> testUuidB = testUuidA;
// testUuidA == testUuidB;

// Differnet typed IDs, regardless of entities, will result in a compile-time error.
// IntId<TestEntityA> testIndIdA = testUuidA;