using System.Globalization;
using System.Runtime;

namespace System.ServiceModel.Channels;

internal struct SequenceRange
{
	public long Lower { get; }

	public long Upper { get; }

	public SequenceRange(long number)
		: this(number, number)
	{
	}

	public SequenceRange(long lower, long upper)
	{
		if (lower < 0)
		{
			throw Fx.AssertAndThrow("Argument lower cannot be negative.");
		}
		if (lower > upper)
		{
			throw Fx.AssertAndThrow("Argument upper cannot be less than argument lower.");
		}
		Lower = lower;
		Upper = upper;
	}

	public static bool operator ==(SequenceRange a, SequenceRange b)
	{
		if (a.Lower == b.Lower)
		{
			return a.Upper == b.Upper;
		}
		return false;
	}

	public static bool operator !=(SequenceRange a, SequenceRange b)
	{
		return !(a == b);
	}

	public bool Contains(long number)
	{
		if (number >= Lower)
		{
			return number <= Upper;
		}
		return false;
	}

	public bool Contains(SequenceRange range)
	{
		if (range.Lower >= Lower)
		{
			return range.Upper <= Upper;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is SequenceRange)
		{
			return this == (SequenceRange)obj;
		}
		return false;
	}

	public override int GetHashCode()
	{
		long num = Upper ^ (Upper - Lower);
		return (int)((num << 32) ^ (num >> 32));
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}-{1}", Lower, Upper);
	}
}
