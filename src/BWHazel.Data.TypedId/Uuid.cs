using System;

namespace BWHazel.Data;

/// <summary>
/// A typed-ID with an underlying ID of a UUID type.
/// </summary>
/// <remarks>The underlying type is <see cref="Guid"/>.s</remarks>
public struct Uuid<T> : IId<T, Guid>
{
    private static readonly Func<Guid> factory = Guid.NewGuid;

    /// <summary>
    /// Initialises a new instance of the <see cref="Uuid{T}"/> struct.
    /// </summary>
    public Uuid()
        : this(factory())
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="Uuid{T}"/> struct.
    /// </summary>
    /// <param name="id">The underlying ID.</param>
    public Uuid(Guid id)
    {
        this.Value = id;
    }

    /// <summary>
    /// Gets or sets the ID value.
    /// </summary>
    public Guid Value { get; set; }

    /// <summary>
    /// Creates a new <see cref="Uuid{T}"/>.
    /// </summary>
    /// <returns>A new <see cref="Uuid{T}"/> with an initialised value.</returns>
    public static Uuid<T> NewId() => new Uuid<T>(factory());

    /// <summary>
    /// Implicitly converts a <see cref="Uuid{T}"/> instance to the underlying ID type.
    /// </summary>
    /// <param name="typedId">The ID value.</param>
    public static implicit operator Guid(Uuid<T> typedId) => typedId.Value;

    /// <summary>
    /// Implcitly converts an underlying ID type to a <see cref="Uuid{T}"/>.
    /// </summary>
    /// <param name="id">A <see cref="Uuid{T}"/>.</param>
    public static implicit operator Uuid<T>(Guid id) => new(id);

    /// <summary>
    /// Determines whether two specified <see cref="Uuid{T}"/> instances have the same value.
    /// </summary>
    /// <param name="id1">The first <see cref="Uuid{T}"/> to compare.</param>
    /// <param name="id2">The second <see cref="Uuid{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id1</c> is the same as the value of <c>id2</c>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Uuid<T> id1, Uuid<T> id2) => id1.Value == id2.Value;

    /// <summary>
    /// Determines whether two specified <see cref="Uuid{T}"/> instances do not have the same value.
    /// </summary>
    /// <param name="id1">The first <see cref="Uuid{T}"/> to compare.</param>
    /// <param name="id2">The second <see cref="Uuid{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id1</c> is not the same as the value of <c>id2</c>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Uuid<T> id1, Uuid<T> id2) => id1.Value != id2.Value;

    /// <summary>
    /// Determines whether a specified <see cref="Uuid{T}"/> and <see cref="Guid"/> instances have the same value.
    /// </summary>
    /// <param name="id">The <see cref="Uuid{T}"/> to compare.</param>
    /// <param name="guid">The <see cref="Guid"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id</c> is the same as the value of <c>guid</c>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Uuid<T> id, Guid guid) => id.Value == guid;

    /// <summary>
    /// Determines whether a specified <see cref="Uuid{T}"/> and <see cref="Guid"/> instances do not have the same value.
    /// </summary>
    /// <param name="id">The <see cref="Uuid{T}"/> to compare.</param>
    /// <param name="guid">The <see cref="Guid"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id</c> is not the same as the value of <c>guid</c>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Uuid<T> id, Guid guid) => id.Value != guid;

    /// <summary>
    /// Determines whether a specified <see cref="Guid"/> and <see cref="Uuid{T}"/> instances have the same value.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> to compare.</param>
    /// <param name="id">The <see cref="Uuid{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id</c> is the same as the value of <c>guid</c>; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Guid guid, Uuid<T> id) => guid == id.Value;

    /// <summary>
    /// Determines whether a specified <see cref="Guid"/> and <see cref="Uuid{T}"/> instances do not have the same value.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> to compare.</param>
    /// <param name="id">The <see cref="Uuid{T}"/> to compare.</param>
    /// <returns><c>true</c> if the value of <c>id</c> is not the same as the value of <c>guid</c>; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Guid guid, Uuid<T> id) => guid != id.Value;

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