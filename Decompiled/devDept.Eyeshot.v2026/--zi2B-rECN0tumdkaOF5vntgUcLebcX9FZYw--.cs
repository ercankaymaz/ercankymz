using System;

internal class _0023_003Dzi2B_0024rECN0tumdkaOF5vntgUcLebcX9FZYw_003D_003D
{
	public static double _0023_003DzXULhp_00248_003D(double _0023_003DzEWLeis8_003D, double _0023_003DzAGmW1Zo_003D, double _0023_003DziDbNDXw_003D, bool _0023_003Dztgl2Ti8_003D)
	{
		double num = _0023_003Dz55WWMaY0DAVyV3cZOg_003D_003D(_0023_003DzAGmW1Zo_003D, _0023_003DziDbNDXw_003D);
		_0023_003DzEWLeis8_003D = ((_0023_003Dztgl2Ti8_003D && _0023_003DzEWLeis8_003D > num) ? (num / _0023_003DzEWLeis8_003D) : ((!(num > 0.0)) ? 0.0 : (_0023_003DzEWLeis8_003D / num)));
		return _0023_003DzEWLeis8_003D;
	}

	public static double _0023_003Dz55WWMaY0DAVyV3cZOg_003D_003D(double _0023_003DzAGmW1Zo_003D, double _0023_003DziDbNDXw_003D)
	{
		if (_0023_003DzAGmW1Zo_003D > _0023_003DziDbNDXw_003D)
		{
			_0023_003DzMdkihsQJa2bf._0023_003DzhF_UisQ_003D(ref _0023_003DzAGmW1Zo_003D, ref _0023_003DziDbNDXw_003D);
		}
		double num = (_0023_003DziDbNDXw_003D - _0023_003DzAGmW1Zo_003D) / _0023_003DzAGmW1Zo_003D;
		double num2;
		if (num < 0.1)
		{
			num *= 0.5;
			num2 = 1.0 + num * (1.0 - 1.0 / 3.0 * num * (1.0 - num * (1.0 - 1.2666666666666666 * num)));
		}
		else
		{
			num2 = num / Math.Log(num + 1.0);
		}
		return num2 * _0023_003DzAGmW1Zo_003D;
	}

	public static double _0023_003DzAD7iW_URaj3fUZIagg_003D_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003DzAGmW1Zo_003D, double _0023_003DziDbNDXw_003D)
	{
		return _0023_003DzAGmW1Zo_003D + _0023_003Dz_eY3Y4c_003D * (_0023_003DziDbNDXw_003D - _0023_003DzAGmW1Zo_003D);
	}

	public static double _0023_003DzXSJhwt4_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003DzAGmW1Zo_003D, double _0023_003DziDbNDXw_003D)
	{
		double num = _0023_003DziDbNDXw_003D / _0023_003DzAGmW1Zo_003D;
		double num2;
		if (num > 1.001 || num < 0.999)
		{
			num2 = (Math.Pow(num, _0023_003Dz_eY3Y4c_003D) - 1.0) / (num - 1.0);
		}
		else
		{
			double num3 = num - 1.0;
			num2 = _0023_003Dz_eY3Y4c_003D * (1.0 + (_0023_003Dz_eY3Y4c_003D - 1.0) * (0.5 * num3) * (1.0 + (_0023_003Dz_eY3Y4c_003D - 2.0) * (num3 / 3.0) * (1.0 + (_0023_003Dz_eY3Y4c_003D - 3.0) * (0.25 * num3))));
		}
		if (0.0 <= _0023_003Dz_eY3Y4c_003D && _0023_003Dz_eY3Y4c_003D <= 1.0)
		{
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			if (num2 > 1.0)
			{
				num2 = 1.0;
			}
		}
		return num2;
	}

	public static uint _0023_003Dz5kG2rZXu2r7b(double _0023_003Dz9JZgoew_003D, uint _0023_003Dz6_0024CzTNlTaA6J)
	{
		uint num = _0023_003Dz6_0024CzTNlTaA6J * (Convert.ToUInt32(_0023_003Dz9JZgoew_003D) / _0023_003Dz6_0024CzTNlTaA6J);
		if ((double)(num * (num + _0023_003Dz6_0024CzTNlTaA6J)) < _0023_003Dz9JZgoew_003D * _0023_003Dz9JZgoew_003D)
		{
			num += _0023_003Dz6_0024CzTNlTaA6J;
		}
		return num;
	}
}
