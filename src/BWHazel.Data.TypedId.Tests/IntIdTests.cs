using System;
using Shouldly;
using Xunit;

namespace BWHazel.Data.Tests;

/// <summary>
/// Tests the <see cref="IntId{T}"/> struct.
/// </summary>
public class IntIdTests
{
    private readonly Random random = new Random();

    [Fact]
    public void ParameterisedConstructor_ShouldSetIntIdToProvidedValue()
    {
        int number = this.random.Next();

        IntId<TestEntity> id = new IntId<TestEntity>(number);

        id.Value.ShouldBe(number);
    }

    [Fact]
    public void Uuid_ShouldImplicitlyCovertToInt()
    {
        IntId<TestEntity> id = new IntId<TestEntity>(this.random.Next());

        int number = id;

        number.ShouldBe(id.Value);
    }

    [Fact]
    public void Int_ShouldImplicitlyConvertToUuid()
    {
        int number = this.random.Next();

        IntId<TestEntity> id = number;

        id.Value.ShouldBe(number);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenTwoUuidsWithSameId()
    {
        int number = this.random.Next();
        IntId<TestEntity> id1 = new IntId<TestEntity>(number);
        IntId<TestEntity> id2 = new IntId<TestEntity>(number);

        bool isEqual = id1 == id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenTwoUuidsWithDifferentId()
    {
        IntId<TestEntity> id1 = new IntId<TestEntity>(this.random.Next());
        IntId<TestEntity> id2 = new IntId<TestEntity>(this.random.Next());

        bool isEqual = id1 == id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenTwoUuidsWithDifferentId()
    {
        IntId<TestEntity> id1 = new IntId<TestEntity>(this.random.Next());
        IntId<TestEntity> id2 = new IntId<TestEntity>(this.random.Next());

        bool isEqual = id1 != id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenTwoUuidsWithSameId()
    {
        int number = this.random.Next();
        IntId<TestEntity> id1 = new IntId<TestEntity>(number);
        IntId<TestEntity> id2 = new IntId<TestEntity>(number);

        bool isEqual = id1 != id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenIntIdAndIntWithSameValue()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        bool isEqual = id == number;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenIntIdAndIntWithDifferentValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(this.random.Next());

        bool isEqual = id == number;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenIntIdAndIntWithDifferentValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(this.random.Next());

        bool isEqual = id != number;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenIntIdAndIntWithSameValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        bool isEqual = id != number;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenIntAndIntIdWithSameValue()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        bool isEqual = number == id;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenIntAndIntIdWithDifferentValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(this.random.Next());

        bool isEqual = number == id;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenIntAndIntIdWithDifferentValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(this.random.Next());

        bool isEqual = number != id;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenIntAndIntIdWithSameValues()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        bool isEqual = number != id;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenGivenTwoUuidsWithSameId()
    {
        int number = this.random.Next();
        IntId<TestEntity> id1 = new IntId<TestEntity>(number);
        IntId<TestEntity> id2 = new IntId<TestEntity>(number);

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenGivenTwoUuidsWithDifferentId()
    {
        IntId<TestEntity> id1 = new IntId<TestEntity>(this.random.Next());
        IntId<TestEntity> id2 = new IntId<TestEntity>(this.random.Next());

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_ShoudlReturnIntHashCode()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        int idHashCode = id.GetHashCode();

        int numberHashCode = number.GetHashCode();
        idHashCode.ShouldBe(numberHashCode);
    }

    [Fact]
    public void ToString_ShouldReturnIntString()
    {
        int number = this.random.Next();
        IntId<TestEntity> id = new IntId<TestEntity>(number);

        string idString = id.ToString();

        string numberString = number.ToString();
        idString.ShouldBe(numberString);
    }
}