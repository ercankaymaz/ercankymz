using System;
using System.Collections.Generic;
using System.Linq;

internal static class _0023_003DzmzI0Qcjyx2Y4QYQER_jIi704DToO1apPLQ_003D_003D
{
	private sealed class _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D
	{
		public double _0023_003DzofrPP00_003D;

		internal double _0023_003DzjmNpYlLmOyoHOphuVw_003D_003D(double _0023_003Dz77g161c_003D)
		{
			return Math.Pow(_0023_003Dz77g161c_003D - _0023_003DzofrPP00_003D, 2.0);
		}
	}

	private sealed class _0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D
	{
		public double _0023_003DzofrPP00_003D;

		internal double _0023_003Dz9Wvkpn_0024P452GW_0024dKuw_003D_003D(double _0023_003Dz77g161c_003D)
		{
			return Math.Pow(_0023_003Dz77g161c_003D - _0023_003DzofrPP00_003D, 2.0);
		}
	}

	public static double _0023_003DzPG_00249Ca211XMg(this IEnumerable<double> _0023_003DzHSO_00246A0_003D)
	{
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2 = new _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D();
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzofrPP00_003D = _0023_003DzHSO_00246A0_003D.Average();
		return Math.Sqrt(_0023_003DzHSO_00246A0_003D.Average((Func<double, double>)_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzjmNpYlLmOyoHOphuVw_003D_003D));
	}

	public static double _0023_003Dz3GrFfNQ_003D(this IEnumerable<double> _0023_003DzHSO_00246A0_003D)
	{
		_0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D CS_0024_003C_003E8__locals2 = new _0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D();
		CS_0024_003C_003E8__locals2._0023_003DzofrPP00_003D = _0023_003DzHSO_00246A0_003D.Average();
		return _0023_003DzHSO_00246A0_003D.Average((double _0023_003Dz77g161c_003D) => Math.Pow(_0023_003Dz77g161c_003D - CS_0024_003C_003E8__locals2._0023_003DzofrPP00_003D, 2.0));
	}

	public static double _0023_003Dz1csYVDqc024RBRs4QIzJ3iBLKA88IM6ZOQ_003D_003D(this IEnumerable<double> _0023_003DzHSO_00246A0_003D)
	{
		return _0023_003DzHSO_00246A0_003D._0023_003DzPG_00249Ca211XMg() / _0023_003DzHSO_00246A0_003D.Average();
	}
}
