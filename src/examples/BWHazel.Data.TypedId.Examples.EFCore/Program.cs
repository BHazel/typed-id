﻿/* TYPED ID EXAMPLE: ENTITY FRAMEWORK CORE
 * This example demonstrates how to use typed IDs with Entity Framework
 * Core, by adding typed IDs to entities and how to register the typed IDs
 * with a database context.
 * 
 * Please see the Person.cs, Address.cs and TelephoneNumber.cs files for
 * examples on how to add typed IDs to entities.
 */

// Import the BWHazel.Data and Microsoft.EntityFrameworkCore namespaces for
// the typed ID types and registration methods for Entity Framework Core.
using System;
using System.Linq;
using BWHazel.Data;
using BWHazel.Data.TypedId.Examples.EFCore;
using static System.Console;

WriteLine("*** TYPED ID EXAMPLE: ENTITY FRAMEWORK CORE ***");

WriteLine("* Initialise the Database *");
PeopleDbContext peopleDbContext = new();
peopleDbContext.Database.EnsureCreated();

WriteLine("* Create Entity Instances *");
Random random = new();

// Create a new Address instance using the constructor for IntId<T> for its ID.
Address joeBloggsAddress = new()
{
    Id = new(random.Next()),
    BuildingNameNumber = "10 Sample House",
    Street = "Test Street",
    City = "Demostead",
    Country = "United Kingdom",
    PostCode = "ZZ1 4PQ"
};

// Create a new TelephoneNumber instance using the constructor for StringId<T> for its ID.
TelephoneNumber joeBloggsTelephoneNumber = new()
{
    Id = new("020 1234 5678"),
    Description = "Home"
};

// Create a new Person instance using the NewId() method for Uuid<T> for its ID.
Person joeBloggsPerson = new()
{
    Id = Uuid<Person>.NewId(),
    Name = "Joe Bloggs",
    AddressId = joeBloggsAddress.Id,
    TelephoneNumberId = joeBloggsTelephoneNumber.Id
};

WriteLine($"Person: {joeBloggsPerson}");
WriteLine($"Address: {joeBloggsAddress}");
WriteLine($"Telephone Number: {joeBloggsTelephoneNumber}");

WriteLine("* Add Entities to Database *");
peopleDbContext.Add(joeBloggsPerson);
peopleDbContext.Add(joeBloggsAddress);
peopleDbContext.Add(joeBloggsTelephoneNumber);
await peopleDbContext.SaveChangesAsync();

WriteLine("* Retrieve Entities from Database *");
Person? joeBloggsPersonFromDatabase = peopleDbContext.People
    .Where(person => person.Id == joeBloggsPerson.Id)
    .FirstOrDefault();

Address? joeBloggsAddressFromDatabase = peopleDbContext.Addresses
    .Where(address => address.Id == joeBloggsPerson.AddressId)
    .FirstOrDefault();

TelephoneNumber? joeBloggsTelephoneNumberFromDatabase = peopleDbContext.TelephoneNumbers
    .Where(telephoneNumber => telephoneNumber.Id == joeBloggsPerson.TelephoneNumberId)
    .FirstOrDefault();

WriteLine($"Person from Database: {joeBloggsPersonFromDatabase}");
WriteLine($"Address from Database: {joeBloggsAddressFromDatabase}");
WriteLine($"Telephone Number from Database: {joeBloggsTelephoneNumberFromDatabase}");