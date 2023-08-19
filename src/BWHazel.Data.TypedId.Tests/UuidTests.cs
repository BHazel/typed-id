using System;
using Shouldly;
using Xunit;

namespace BWHazel.Data.Tests;

/// <summary>
/// Tests the <see cref="Uuid{T}"/> struct.
/// </summary>
public class UuidTests
{
    [Fact]
    public void EmptyConstructor_ShouldGenerateUuidWithInitialisedGuid()
    {
        Uuid<TestEntity> id = new Uuid<TestEntity>();

        id.Value.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void ParameterisedConstructor_ShouldSetUuidToProvidedValue()
    {
        Guid guid = Guid.NewGuid();

        Uuid<TestEntity> id = new Uuid<TestEntity>(guid);

        id.Value.ShouldBe(guid);
    }

    [Fact]
    public void NewId_ShouldCreateNewUuidWithInitialisedValue()
    {
        Uuid<TestEntity> id = Uuid<TestEntity>.NewId();

        id.Value.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void Uuid_ShouldImplicitlyCovertToGuid()
    {
        Uuid<TestEntity> id = Uuid<TestEntity>.NewId();

        Guid guid = id;

        guid.ShouldBe(id.Value);
    }

    [Fact]
    public void Guid_ShouldImplicitlyConvertToUuid()
    {
        Guid guid = Guid.NewGuid();

        Uuid<TestEntity> id = guid;

        id.Value.ShouldBe(guid);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenTwoUuidsWithSameId()
    {
        Guid guid = Guid.NewGuid();
        Uuid<TestEntity> id1 = new Uuid<TestEntity>(guid);
        Uuid<TestEntity> id2 = new Uuid<TestEntity>(guid);

        bool isEqual = id1 == id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenTwoUuidsWithDifferentId()
    {
        Uuid<TestEntity> id1 = Uuid<TestEntity>.NewId();
        Uuid<TestEntity> id2 = Uuid<TestEntity>.NewId();

        bool isEqual = id1 == id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenTwoUuidsWithDifferentId()
    {
        Uuid<TestEntity> id1 = Uuid<TestEntity>.NewId();
        Uuid<TestEntity> id2 = Uuid<TestEntity>.NewId();

        bool isEqual = id1 != id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenTwoUuidsWithSameId()
    {
        Guid guid = Guid.NewGuid();
        Uuid<TestEntity> id1 = new Uuid<TestEntity>(guid);
        Uuid<TestEntity> id2 = new Uuid<TestEntity>(guid);

        bool isEqual = id1 != id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenGivenTwoUuidsWithSameId()
    {
        Guid guid = Guid.NewGuid();
        Uuid<TestEntity> id1 = new Uuid<TestEntity>(guid);
        Uuid<TestEntity> id2 = new Uuid<TestEntity>(guid);

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenGivenTwoUuidsWithDifferentId()
    {
        Uuid<TestEntity> id1 = Uuid<TestEntity>.NewId();
        Uuid<TestEntity> id2 = Uuid<TestEntity>.NewId();

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_ShoudlReturnGuidHashCode()
    {
        Guid guid = Guid.NewGuid();
        Uuid<TestEntity> id = new Uuid<TestEntity>(guid);

        int idHashCode = id.GetHashCode();

        int guidHashCode = guid.GetHashCode();
        idHashCode.ShouldBe(guidHashCode);
    }

    [Fact]
    public void ToString_ShouldReturnGuidString()
    {
        Guid guid = Guid.NewGuid();
        Uuid<TestEntity> id = new Uuid<TestEntity>(guid);

        string idString = id.ToString();

        string guidString = guid.ToString();
        idString.ShouldBe(guidString);
    }
}