namespace BWHazel.Data;

/// <summary>
/// A typed-ID with an underlying ID of an integer type.
/// </summary>
/// <remarks>The underlying type is <see cref="int"/>.s</remarks>
public struct IntId<T> : IId<T, int>
{
    /// <summary>
    /// Initialises a new instance of the <see cref="IntId{T}"/> struct.
    /// </summary>
    /// <param name="id">The underlying ID.</param>
    public IntId(int id)
    {
        this.Value = id;
    }

    /// <summary>
    /// Gets or sets the ID value.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Implicitly converts a <see cref="IntId{T}"/> instance to the underlying ID type.
    /// </summary>
    /// <param name="typedId">The ID value.</param>
    public static implicit operator int(IntId<T> typedId) => typedId.Value;

    /// <summary>
    /// Implcitly converts an underlying ID type to a <see cref="IntId{T}"/>.
    /// </summary>
    /// <param name="id">A <see cref="IntId{T}"/>.</param>
    public static implicit operator IntId<T>(int id) => new(id);

    /// <summary>
    /// Determines whether two specified <see cref="IntId{T}"/> instances have the same value.
    /// </summary>
    /// <param name="id1">The first <see cref="IntId{T}"/> to compare.</param>
    /// <param name="id2">The second <see cref="IntId{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id1</c> is the same as the value of <c>id2</c>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(IntId<T> id1, IntId<T> id2) => id1.Value == id2.Value;

    /// <summary>
    /// Determines whether two specified <see cref="IntId{T}"/> instances do not have the same value.
    /// </summary>
    /// <param name="id1">The first <see cref="IntId{T}"/> to compare.</param>
    /// <param name="id2">The second <see cref="IntId{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id1</c> is not the same as the value of <c>id2</c>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(IntId<T> id1, IntId<T> id2) => id1.Value != id2.Value;

    /// <summary>
    /// Indicates whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => base.Equals(obj);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>The hash code for this instance.</returns>
    public override int GetHashCode() => this.Value.GetHashCode();

    /// <summary>
    /// Returns the underlying ID value as a string.
    /// </summary>
    /// <returns>The underlying ID value as a string.</returns>
    public override string ToString() => this.Value.ToString();
}
