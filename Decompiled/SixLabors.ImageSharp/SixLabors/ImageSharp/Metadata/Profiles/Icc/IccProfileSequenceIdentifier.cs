using System;

namespace SixLabors.ImageSharp.Metadata.Profiles.Icc;

internal readonly struct IccProfileSequenceIdentifier(IccProfileId id, IccLocalizedString[] description) : IEquatable<IccProfileSequenceIdentifier>
{
	public IccProfileId Id { get; } = id;

	public IccLocalizedString[] Description { get; } = description ?? throw new ArgumentNullException("description");

	public bool Equals(IccProfileSequenceIdentifier other)
	{
		if (Id.Equals(other.Id))
		{
			return MemoryExtensions.SequenceEqual<IccLocalizedString>(MemoryExtensions.AsSpan<IccLocalizedString>(Description), (ReadOnlySpan<IccLocalizedString>)other.Description);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IccProfileSequenceIdentifier other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Description);
	}
}
