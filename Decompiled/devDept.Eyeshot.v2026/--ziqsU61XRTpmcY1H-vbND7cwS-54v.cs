using System;
using System.Collections.Generic;
using System.Globalization;

internal static class _0023_003DziqsU61XRTpmcY1H_0024vbND7cwS_002454v
{
	private static NumberFormatInfo _0023_003Dz0qLklfo_003D;

	static _0023_003DziqsU61XRTpmcY1H_0024vbND7cwS_002454v()
	{
		_0023_003Dz0qLklfo_003D = new NumberFormatInfo();
		_0023_003Dz0qLklfo_003D.NumberDecimalSeparator = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290);
	}

	public static double _0023_003DzR61OsnE_003D(this string _0023_003Dz_0024n2nrac_003D)
	{
		return double.Parse(_0023_003Dz_0024n2nrac_003D, _0023_003Dz0qLklfo_003D);
	}

	public static float _0023_003DzJLEszqI_003D(this string _0023_003Dz_0024n2nrac_003D)
	{
		return float.Parse(_0023_003Dz_0024n2nrac_003D, _0023_003Dz0qLklfo_003D);
	}

	public static string _0023_003Dz1eU15ZU_003D(this double _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003DzPzO_0024GUk_003D.ToString(_0023_003Dz0qLklfo_003D);
	}

	public static string _0023_003Dz1eU15ZU_003D(this float _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003DzPzO_0024GUk_003D.ToString(_0023_003Dz0qLklfo_003D);
	}

	public static void _0023_003DzzlWCyhw_003D<T>(this string _0023_003Dz_0024n2nrac_003D, ref T _0023_003DzbfrNXYE_003D)
	{
		_0023_003DzbfrNXYE_003D = (T)Enum.Parse(_0023_003DzbfrNXYE_003D.GetType(), _0023_003Dz_0024n2nrac_003D);
	}

	public static T _0023_003DzzlWCyhw_003D<T>(this string _0023_003Dz_0024n2nrac_003D)
	{
		return (T)Enum.Parse(typeof(T), _0023_003Dz_0024n2nrac_003D);
	}

	public static void _0023_003DzIAB23y8_003D<T>(this IEnumerable<T> _0023_003DzbfrNXYE_003D, Action<T> _0023_003DzaPWY5KY_003D)
	{
		foreach (T item in _0023_003DzbfrNXYE_003D)
		{
			_0023_003DzaPWY5KY_003D(item);
		}
	}

	public static void _0023_003DzhF_UisQ_003D<T>(ref T _0023_003DzjbqS1qE_003D, ref T _0023_003Dz1v6oPQk_003D)
	{
		T val = _0023_003DzjbqS1qE_003D;
		_0023_003DzjbqS1qE_003D = _0023_003Dz1v6oPQk_003D;
		_0023_003Dz1v6oPQk_003D = val;
	}
}
