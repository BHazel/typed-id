using Shouldly;
using Xunit;

namespace BWHazel.Data.Tests;

/// <summary>
/// Tests the <see cref="StringId{T}"/> struct.
/// </summary>
public class StringIdTests
{
    [Fact]
    public void ParameterisedConstructor_ShouldSetStringIdToProvidedValue()
    {
        string stringValue = "123";

        StringId<TestEntity> id = new(stringValue);

        id.Value.ShouldBe(stringValue);
    }

    [Fact]
    public void StringId_ShouldImplicitlyCovertToString()
    {
        StringId<TestEntity> id = new("123");

        string stringValue = id;

        stringValue.ShouldBe(id.Value);
    }

    [Fact]
    public void String_ShouldImplicitlyConvertToStringId()
    {
        string stringValue = "123";

        StringId<TestEntity> id = stringValue;

        id.Value.ShouldBe(stringValue);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenTwoStringIdsWithSameId()
    {
        string stringValue = "123";
        StringId<TestEntity> id1 = new(stringValue);
        StringId<TestEntity> id2 = new(stringValue);

        bool isEqual = id1 == id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenTwoStringIdsWithDifferentId()
    {
        StringId<TestEntity> id1 = new("123");
        StringId<TestEntity> id2 = new("456");

        bool isEqual = id1 == id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenTwoStringIdsWithDifferentId()
    {
        StringId<TestEntity> id1 = new("123");
        StringId<TestEntity> id2 = new("456");

        bool isEqual = id1 != id2;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenTwoStringIdsWithSameId()
    {
        string stringValue = "123";
        StringId<TestEntity> id1 = new(stringValue);
        StringId<TestEntity> id2 = new(stringValue);

        bool isEqual = id1 != id2;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenStringIdAndStringWithSameValue()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        bool isEqual = id == stringValue;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenStringIdAndIntWithDifferentValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new("456");

        bool isEqual = id == stringValue;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenStringIdAndStringWithDifferentValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new("456");

        bool isEqual = id != stringValue;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenStringIdAndStringWithSameValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        bool isEqual = id != stringValue;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenStringAndStringIdWithSameValue()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        bool isEqual = stringValue == id;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenStringAndStringIdWithDifferentValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new("456");

        bool isEqual = stringValue == id;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenStringAndStringIdWithDifferentValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new("456");

        bool isEqual = stringValue != id;

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenStringAndStringIdWithSameValues()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        bool isEqual = stringValue != id;

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenGivenTwoStringIdsWithSameId()
    {
        string stringValue = "123";
        StringId<TestEntity> id1 = new(stringValue);
        StringId<TestEntity> id2 = new(stringValue);

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenGivenTwoStringIdsWithDifferentId()
    {
        StringId<TestEntity> id1 = new("123");
        StringId<TestEntity> id2 = new("456");

        bool isEqual = id1.Equals(id2);

        isEqual.ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_ShoudlReturnStringHashCode()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        int idHashCode = id.GetHashCode();

        int numberHashCode = stringValue.GetHashCode();
        idHashCode.ShouldBe(numberHashCode);
    }

    [Fact]
    public void ToString_ShouldReturnString()
    {
        string stringValue = "123";
        StringId<TestEntity> id = new(stringValue);

        string idString = id.ToString();

        string numberString = stringValue.ToString();
        idString.ShouldBe(numberString);
    }
}