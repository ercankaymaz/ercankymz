using System;

namespace devDept.Geometry;

[Serializable]
public struct IntInterval
{
	private int _start;

	private int _end;

	public int Start => _start;

	public int End => _end;

	public int Length => _end - _start + 1;

	public IntInterval(int start, int end)
	{
		if (end < start)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658310));
		}
		_start = start;
		_end = end;
	}

	public static bool Disjoint(IntInterval a, IntInterval b)
	{
		return !Overlapping(a, b);
	}

	public static bool Overlapping(IntInterval a, IntInterval b)
	{
		return Math.Min(a.End, b.End) >= Math.Max(a.Start, b.Start);
	}

	public static bool OverlappingOrAdjacent(IntInterval a, IntInterval b)
	{
		return Math.Min(a.End, b.End) >= Math.Max(a.Start, b.Start) - 1;
	}

	public bool OverlapsWith(IntInterval other)
	{
		return Overlapping(this, other);
	}

	public bool OverlapsWithOrAdjacentTo(IntInterval other)
	{
		return OverlappingOrAdjacent(this, other);
	}

	public static void Intersection(IntInterval a, IntInterval b, out IntInterval? i)
	{
		if (Disjoint(a, b))
		{
			i = null;
			return;
		}
		int start = Math.Max(a.Start, b.Start);
		int end = Math.Min(a.End, b.End);
		i = new IntInterval(start, end);
	}

	public static bool Contains(IntInterval a, IntInterval b)
	{
		if (Math.Min(a.Start, b.Start) == a.Start)
		{
			return Math.Max(a.End, b.End) == a.End;
		}
		return false;
	}

	public bool Contains(IntInterval other)
	{
		return Contains(this, other);
	}

	public static bool ContainsValue(IntInterval a, int v)
	{
		if (a.Start <= v)
		{
			return v <= a.End;
		}
		return false;
	}

	public bool ContainsValue(int v)
	{
		return ContainsValue(this, v);
	}

	public static void Union(IntInterval a, IntInterval b, out IntInterval u0, out IntInterval? u1)
	{
		if (OverlappingOrAdjacent(a, b))
		{
			int start = Math.Min(a.Start, b.Start);
			int end = Math.Max(a.End, b.End);
			u0 = new IntInterval(start, end);
			u1 = null;
		}
		else
		{
			u0 = a;
			u1 = b;
		}
	}

	public static void Difference(IntInterval a, IntInterval b, out IntInterval? d0, out IntInterval? d1)
	{
		if (Disjoint(a, b))
		{
			d0 = a;
			d1 = null;
			return;
		}
		d0 = (d1 = null);
		if (a.Start < b.Start)
		{
			d0 = new IntInterval(a.Start, b.Start - 1);
		}
		if (a.End > b.End)
		{
			IntInterval value = new IntInterval(b.End + 1, a.End);
			if (d0.HasValue)
			{
				d1 = value;
			}
			else
			{
				d0 = value;
			}
		}
	}

	public bool Equals(IntInterval other)
	{
		if (_start == other._start)
		{
			return _end == other._end;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is IntInterval other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _start ^ _end;
	}

	public static bool operator ==(IntInterval left, IntInterval right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(IntInterval left, IntInterval right)
	{
		return !left.Equals(right);
	}
}
