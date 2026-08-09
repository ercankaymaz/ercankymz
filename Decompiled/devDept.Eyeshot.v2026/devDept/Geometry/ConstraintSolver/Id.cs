using System;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public struct Id
{
	public static readonly Id Null = new Id(0L, 0L);

	private long id;

	private long secondId;

	public long value => id;

	public long second => secondId;

	internal Id(long _0023_003Dz77g161c_003D, long _0023_003DzuwH5j5s_003D = 0L)
	{
		id = _0023_003Dz77g161c_003D;
		secondId = _0023_003DzuwH5j5s_003D;
	}

	public Id WithSecond(long s)
	{
		return new Id(value, s);
	}

	public Id WithoutSecond()
	{
		return new Id(value, 0L);
	}

	public static bool operator ==(Id a, Id b)
	{
		if (a.value == b.value)
		{
			return a.second == b.second;
		}
		return false;
	}

	public static bool operator !=(Id a, Id b)
	{
		if (a.value == b.value)
		{
			return a.second != b.second;
		}
		return true;
	}

	public override string ToString()
	{
		if (second == 0L)
		{
			return value.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817));
		}
		return value.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926862) + second.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817));
	}

	public override int GetHashCode()
	{
		return (int)value;
	}

	public override bool Equals(object obj)
	{
		Id id = (Id)obj;
		if (id == this)
		{
			return true;
		}
		if (value == id.value)
		{
			return second == id.second;
		}
		return false;
	}

	internal IdSurrogate _0023_003Dz_0024xHo97pGU7zE()
	{
		return new IdSurrogate(this);
	}
}
