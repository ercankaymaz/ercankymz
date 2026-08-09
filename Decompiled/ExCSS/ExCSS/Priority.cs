using System;
using System.Runtime.InteropServices;

namespace ExCSS;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Pack = 1)]
public struct Priority : IEquatable<Priority>, IComparable<Priority>
{
	[FieldOffset(0)]
	private readonly byte _tags;

	[FieldOffset(1)]
	private readonly byte _classes;

	[FieldOffset(2)]
	private readonly byte _ids;

	[FieldOffset(3)]
	private readonly byte _inlines;

	[FieldOffset(0)]
	private readonly uint _priority;

	public static readonly Priority Zero;

	public static readonly Priority OneTag;

	public static readonly Priority OneClass;

	public static readonly Priority OneId;

	public static readonly Priority Inline;

	public byte Ids => _ids;

	public byte Tags => _tags;

	public byte Classes => _classes;

	public byte Inlines => _inlines;

	public Priority(uint priority)
	{
		_inlines = (_ids = (_classes = (_tags = 0)));
		_priority = priority;
	}

	public Priority(byte inlines, byte ids, byte classes, byte tags)
	{
		_priority = 0u;
		_inlines = inlines;
		_ids = ids;
		_classes = classes;
		_tags = tags;
	}

	public static Priority operator +(Priority a, Priority b)
	{
		return new Priority(a._priority + b._priority);
	}

	public static bool operator ==(Priority a, Priority b)
	{
		return a._priority == b._priority;
	}

	public static bool operator >(Priority a, Priority b)
	{
		return a._priority > b._priority;
	}

	public static bool operator >=(Priority a, Priority b)
	{
		return a._priority >= b._priority;
	}

	public static bool operator <(Priority a, Priority b)
	{
		return a._priority < b._priority;
	}

	public static bool operator <=(Priority a, Priority b)
	{
		return a._priority <= b._priority;
	}

	public static bool operator !=(Priority a, Priority b)
	{
		return a._priority != b._priority;
	}

	public bool Equals(Priority other)
	{
		return _priority == other._priority;
	}

	public override bool Equals(object obj)
	{
		if (obj is Priority)
		{
			return Equals((Priority)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)_priority;
	}

	public int CompareTo(Priority other)
	{
		if (!(this == other))
		{
			if (!(this > other))
			{
				return -1;
			}
			return 1;
		}
		return 0;
	}

	public override string ToString()
	{
		return $"({_inlines}, {_ids}, {_classes}, {_tags})";
	}

	static Priority()
	{
		Zero = new Priority(0u);
		OneTag = new Priority(0, 0, 0, 1);
		OneClass = new Priority(0, 0, 1, 0);
		OneId = new Priority(0, 1, 0, 0);
		Inline = new Priority(1, 0, 0, 0);
	}
}
