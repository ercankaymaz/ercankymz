using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[ComVisible(true)]
public readonly struct EventId
{
	public int Id { get; }

	public string Name { get; }

	public static implicit operator EventId(int i)
	{
		return new EventId(i);
	}

	public static bool operator ==(EventId left, EventId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(EventId left, EventId right)
	{
		return !left.Equals(right);
	}

	public EventId(int id, string name = null)
	{
		Id = id;
		Name = name;
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public override string ToString()
	{
		return Name ?? Id.ToString();
	}

	public bool Equals(EventId other)
	{
		return Id == other.Id;
	}

	public override bool Equals([NotNullWhen(true)] object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is EventId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Id;
	}
}
