using System;
using System.Collections.Generic;
using System.Linq;

internal static class _0023_003DzjM7_jq0lEFV7P3nKIxo7A9A_003D
{
	public static ParallelQuery<TSource> _0023_003DzZLKOWsybRUkG<TSource>(this ParallelQuery<TSource> _0023_003Dzb7SPTpc_003D, Func<TSource, bool> _0023_003DzVHDUztc_003D)
	{
		if (_0023_003DzVHDUztc_003D != null)
		{
			return _0023_003Dzb7SPTpc_003D.Where(_0023_003DzVHDUztc_003D);
		}
		return _0023_003Dzb7SPTpc_003D;
	}

	public static IEnumerable<TSource> _0023_003DzZLKOWsybRUkG<TSource>(this IEnumerable<TSource> _0023_003Dzb7SPTpc_003D, Func<TSource, bool> _0023_003DzVHDUztc_003D)
	{
		if (_0023_003DzVHDUztc_003D != null)
		{
			return _0023_003Dzb7SPTpc_003D.Where(_0023_003DzVHDUztc_003D);
		}
		return _0023_003Dzb7SPTpc_003D;
	}
}
