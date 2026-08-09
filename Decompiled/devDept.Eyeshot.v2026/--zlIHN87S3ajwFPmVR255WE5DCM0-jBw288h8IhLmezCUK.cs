using System.Collections.Generic;
using System.Linq;

internal static class _0023_003DzlIHN87S3ajwFPmVR255WE5DCM0_0024jBw288h8IhLmezCUK
{
	public static void _0023_003Dzl2vWevE_003D<T>(this List<T> _0023_003DzcDEsV8s_003D, int _0023_003DzrKoFmJY_003D, T _0023_003Dzt_m8zV0_003D)
	{
		int count = _0023_003DzcDEsV8s_003D.Count;
		if (_0023_003DzrKoFmJY_003D < count)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzrKoFmJY_003D, count - _0023_003DzrKoFmJY_003D);
		}
		else if (_0023_003DzrKoFmJY_003D > count)
		{
			if (_0023_003DzrKoFmJY_003D > _0023_003DzcDEsV8s_003D.Capacity)
			{
				_0023_003DzcDEsV8s_003D.Capacity = _0023_003DzrKoFmJY_003D;
			}
			_0023_003DzcDEsV8s_003D.AddRange(Enumerable.Repeat(_0023_003Dzt_m8zV0_003D, _0023_003DzrKoFmJY_003D - count));
		}
	}

	public static void _0023_003Dzl2vWevE_003D<T>(this List<T> _0023_003DzcDEsV8s_003D, int _0023_003DzrKoFmJY_003D) where T : new()
	{
		_0023_003DzcDEsV8s_003D._0023_003Dzl2vWevE_003D(_0023_003DzrKoFmJY_003D, new T());
	}
}
