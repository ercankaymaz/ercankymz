using System;
using System.Diagnostics;
using System.Globalization;

namespace devDept.Geometry.ConstraintSolver;

public class IdGenerator
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal long _0023_003Dzuxxvjv8_003D;

	internal void _0023_003DzRm7vplc_003D()
	{
		_0023_003Dzuxxvjv8_003D++;
	}

	public Id New()
	{
		return new Id(++_0023_003Dzuxxvjv8_003D, 0L);
	}

	public Id Create(long id)
	{
		_0023_003Dzuxxvjv8_003D = Math.Max(_0023_003Dzuxxvjv8_003D, id);
		return new Id(id, 0L);
	}

	public Id Create(string str)
	{
		long num = long.Parse(str, NumberStyles.HexNumber);
		_0023_003Dzuxxvjv8_003D = Math.Max(_0023_003Dzuxxvjv8_003D, num);
		return new Id(num, 0L);
	}

	public void Clear()
	{
		_0023_003Dzuxxvjv8_003D = 0L;
	}
}
