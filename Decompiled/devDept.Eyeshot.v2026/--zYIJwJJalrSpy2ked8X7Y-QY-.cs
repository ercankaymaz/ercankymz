using System;
using System.Collections.Generic;

internal static class _0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D
{
	public static void _0023_003DzxlrG_0024xCp402A<T>(this List<T> _0023_003DzcDEsV8s_003D, T _0023_003DzPzO_0024GUk_003D)
	{
		int num = _0023_003DzcDEsV8s_003D.BinarySearch(_0023_003DzPzO_0024GUk_003D);
		if (num < 0)
		{
			num = ~num;
		}
		_0023_003DzcDEsV8s_003D.Insert(num, _0023_003DzPzO_0024GUk_003D);
	}

	public static void _0023_003DzxlrG_0024xCp402A<T>(this List<T> _0023_003DzcDEsV8s_003D, T _0023_003DzPzO_0024GUk_003D, out int _0023_003Dz437_00244ak_003D)
	{
		_0023_003Dz437_00244ak_003D = _0023_003DzcDEsV8s_003D.BinarySearch(_0023_003DzPzO_0024GUk_003D);
		if (_0023_003Dz437_00244ak_003D < 0)
		{
			_0023_003Dz437_00244ak_003D = ~_0023_003Dz437_00244ak_003D;
		}
		_0023_003DzcDEsV8s_003D.Insert(_0023_003Dz437_00244ak_003D, _0023_003DzPzO_0024GUk_003D);
	}

	public static bool _0023_003DzDGFTILcrZeCm<T>(this List<T> _0023_003DzcDEsV8s_003D, T _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003DzcDEsV8s_003D.BinarySearch(_0023_003DzPzO_0024GUk_003D) >= 0;
	}

	public static void _0023_003DzmSyvi00_003D<T>(ref T[] _0023_003DzTbDlaOM_003D, int _0023_003DzyzK8swU_003D, int _0023_003Dzfsn580w_003D)
	{
		if (_0023_003Dzfsn580w_003D > 0)
		{
			T[] array = new T[_0023_003DzTbDlaOM_003D.Length - _0023_003Dzfsn580w_003D];
			if (_0023_003DzyzK8swU_003D > 0)
			{
				Array.Copy(_0023_003DzTbDlaOM_003D, 0, array, 0, _0023_003DzyzK8swU_003D);
			}
			int num = _0023_003DzyzK8swU_003D + _0023_003Dzfsn580w_003D;
			if (num < _0023_003DzTbDlaOM_003D.Length)
			{
				Array.Copy(_0023_003DzTbDlaOM_003D, num, array, _0023_003DzyzK8swU_003D, _0023_003DzTbDlaOM_003D.Length - num);
			}
			_0023_003DzTbDlaOM_003D = array;
		}
	}
}
