using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public struct JET_LGPOS : IEquatable<JET_LGPOS>, IComparable<JET_LGPOS>, INullableJetStruct
{
	private ushort offset;

	private ushort sector;

	private int generation;

	public int ib
	{
		[DebuggerStepThrough]
		get
		{
			return offset;
		}
		set
		{
			offset = checked((ushort)value);
		}
	}

	public int isec
	{
		[DebuggerStepThrough]
		get
		{
			return sector;
		}
		set
		{
			sector = checked((ushort)value);
		}
	}

	public int lGeneration
	{
		[DebuggerStepThrough]
		get
		{
			return generation;
		}
		set
		{
			generation = value;
		}
	}

	public bool HasValue => lGeneration != 0;

	public static bool operator ==(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return !(lhs == rhs);
	}

	public static bool operator <(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return lhs.CompareTo(rhs) < 0;
	}

	public static bool operator >(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return lhs.CompareTo(rhs) > 0;
	}

	public static bool operator <=(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return lhs.CompareTo(rhs) <= 0;
	}

	public static bool operator >=(JET_LGPOS lhs, JET_LGPOS rhs)
	{
		return lhs.CompareTo(rhs) >= 0;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_LGPOS(0x{0:X},{1:X},{2:X})", lGeneration, isec, ib);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_LGPOS)obj);
	}

	public override int GetHashCode()
	{
		return generation ^ (sector << 16) ^ offset;
	}

	public bool Equals(JET_LGPOS other)
	{
		if (generation == other.generation && sector == other.sector)
		{
			return offset == other.offset;
		}
		return false;
	}

	public int CompareTo(JET_LGPOS other)
	{
		int num = generation.CompareTo(other.generation);
		if (num == 0)
		{
			num = sector.CompareTo(other.sector);
		}
		if (num == 0)
		{
			num = offset.CompareTo(other.offset);
		}
		return num;
	}
}
