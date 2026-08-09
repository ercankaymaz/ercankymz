using System;
using System.Diagnostics;
using devDept.Geometry;

internal readonly ref struct _0023_003DzJD6mO0RaAC7pnoL62TYBYLg_003D
{
	public readonly ref struct _0023_003DzQ7usAag_003D(double _0023_003Dzt_m8zV0_003D, bool _0023_003DzE3ZVbQdHkHzU, bool _0023_003DzNCZ1IBCMbSi4, bool _0023_003Dzul_00241f12osu0i)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzWWgGxds_003D = _0023_003Dzt_m8zV0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly bool _0023_003Dzmz1XoQzWZeWL = _0023_003DzE3ZVbQdHkHzU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly bool _0023_003Dzn8uC0NE_003D = _0023_003DzNCZ1IBCMbSi4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly bool _0023_003DzxzvkIcs_003D = _0023_003Dzul_00241f12osu0i;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly _0023_003Dz_KzT4L4nixMeueHlYGi6MyY_003D _0023_003DzGrL5WtI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly double _0023_003Dz_0024Jquo8Y_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly double _0023_003DzXBPjmW0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly double _0023_003DzshZYG54_003D;

	public _0023_003DzJD6mO0RaAC7pnoL62TYBYLg_003D(_0023_003Dz_KzT4L4nixMeueHlYGi6MyY_003D _0023_003DzCJkr8nY_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzAqOpw0w_003D, double _0023_003Dzk64JNOo_003D)
	{
		if (_0023_003Dzk64JNOo_003D <= _0023_003DzAqOpw0w_003D)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659709));
		}
		_0023_003DzshZYG54_003D = _0023_003Dzt_m8zV0_003D;
		_0023_003DzGrL5WtI_003D = _0023_003DzCJkr8nY_003D;
		_0023_003DzXBPjmW0_003D = _0023_003Dzk64JNOo_003D;
		_0023_003Dz_0024Jquo8Y_003D = _0023_003DzAqOpw0w_003D;
	}

	public Point2D _0023_003DzMEXpAaVkFlpl(double _0023_003DzNDQ_E88_003D)
	{
		if (_0023_003DzGrL5WtI_003D != 0)
		{
			return new Point2D(_0023_003DzshZYG54_003D, _0023_003DzNDQ_E88_003D);
		}
		return new Point2D(_0023_003DzNDQ_E88_003D, _0023_003DzshZYG54_003D);
	}

	internal _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzWNZugXZG2M27(double _0023_003DzNDQ_E88_003D)
	{
		if (_0023_003DzGrL5WtI_003D != 0)
		{
			return new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzshZYG54_003D, _0023_003DzNDQ_E88_003D);
		}
		return new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzNDQ_E88_003D, _0023_003DzshZYG54_003D);
	}

	public bool _0023_003Dz9h5MY_A_003D(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, double _0023_003Dzm0CYiiE_003D, out _0023_003DzQ7usAag_003D _0023_003DzwVvVdW0_003D)
	{
		if (_0023_003DzGrL5WtI_003D != 0)
		{
			return _0023_003Dzx8vFDJQ_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D, _0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D, _0023_003Dzm0CYiiE_003D, _0023_003Dzbu8BV15Qqzan: false, out _0023_003DzwVvVdW0_003D);
		}
		return _0023_003Dzx8vFDJQ_003D(_0023_003DzpilgH4E_003D, _0023_003Dz3YfTAqg_003D, _0023_003Dz8qV981c_003D, _0023_003DzRFb1SGo_003D, _0023_003Dzm0CYiiE_003D, _0023_003Dzbu8BV15Qqzan: true, out _0023_003DzwVvVdW0_003D);
	}

	private bool _0023_003Dzx8vFDJQ_003D(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, double _0023_003Dzm0CYiiE_003D, bool _0023_003Dzbu8BV15Qqzan, out _0023_003DzQ7usAag_003D _0023_003DzwVvVdW0_003D)
	{
		new Vector2D(_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D, _0023_003Dz8qV981c_003D - _0023_003DzpilgH4E_003D).Normalize();
		double second = _0023_003Dz8qV981c_003D;
		double first = _0023_003DzpilgH4E_003D;
		if (second < first)
		{
			Utility.Swap(ref first, ref second);
		}
		double second2 = _0023_003DzRFb1SGo_003D;
		double first2 = _0023_003Dz3YfTAqg_003D;
		if (second2 < first2)
		{
			Utility.Swap(ref first2, ref second2);
		}
		_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(0.0, _0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: false, _0023_003Dzul_00241f12osu0i: false);
		if (second < _0023_003Dz_0024Jquo8Y_003D - _0023_003Dzm0CYiiE_003D || first > _0023_003DzXBPjmW0_003D + _0023_003Dzm0CYiiE_003D)
		{
			return false;
		}
		if (second2 < _0023_003DzshZYG54_003D - _0023_003Dzm0CYiiE_003D || first2 > _0023_003DzshZYG54_003D + _0023_003Dzm0CYiiE_003D)
		{
			return false;
		}
		double num = _0023_003DzshZYG54_003D - _0023_003Dz3YfTAqg_003D;
		double num2 = _0023_003DzRFb1SGo_003D - _0023_003DzshZYG54_003D;
		if (num > _0023_003Dzm0CYiiE_003D)
		{
			if (num2 > _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003Dz9h5MY_A_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzRFb1SGo_003D, _0023_003DzpilgH4E_003D, _0023_003Dz8qV981c_003D, _0023_003Dzm0CYiiE_003D, out double _0023_003DzC1QabNg_003D))
				{
					_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzC1QabNg_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: false, _0023_003Dzul_00241f12osu0i: false);
					return true;
				}
				return false;
			}
			if (num2 >= 0.0 - _0023_003Dzm0CYiiE_003D && num2 <= _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003Dz9h5MY_A_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzRFb1SGo_003D, _0023_003DzpilgH4E_003D, _0023_003Dz8qV981c_003D, _0023_003Dzm0CYiiE_003D, out double _0023_003DzC1QabNg_003D2))
				{
					_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzC1QabNg_003D2, _0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: false, _0023_003Dzul_00241f12osu0i: true);
					return true;
				}
				return false;
			}
			return false;
		}
		if (num < 0.0 - _0023_003Dzm0CYiiE_003D)
		{
			if (num2 < 0.0 - _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003Dz9h5MY_A_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzRFb1SGo_003D, _0023_003DzpilgH4E_003D, _0023_003Dz8qV981c_003D, _0023_003Dzm0CYiiE_003D, out double _0023_003DzC1QabNg_003D3))
				{
					_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzC1QabNg_003D3, !_0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: false, _0023_003Dzul_00241f12osu0i: false);
					return true;
				}
				return false;
			}
			if (num2 >= 0.0 - _0023_003Dzm0CYiiE_003D && num2 <= _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003Dz9h5MY_A_003D(_0023_003Dz3YfTAqg_003D, _0023_003DzRFb1SGo_003D, _0023_003DzpilgH4E_003D, _0023_003Dz8qV981c_003D, _0023_003Dzm0CYiiE_003D, out double _0023_003DzC1QabNg_003D4))
				{
					_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzC1QabNg_003D4, !_0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: false, _0023_003Dzul_00241f12osu0i: true);
					return true;
				}
				return false;
			}
			return false;
		}
		if (_0023_003DzpilgH4E_003D >= _0023_003Dz_0024Jquo8Y_003D - _0023_003Dzm0CYiiE_003D && _0023_003DzpilgH4E_003D <= _0023_003DzXBPjmW0_003D + _0023_003Dzm0CYiiE_003D)
		{
			if (num2 > _0023_003Dzm0CYiiE_003D)
			{
				_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzpilgH4E_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: true, _0023_003Dzul_00241f12osu0i: false);
				return true;
			}
			if (num2 < 0.0 - _0023_003Dzm0CYiiE_003D)
			{
				_0023_003DzwVvVdW0_003D = new _0023_003DzQ7usAag_003D(_0023_003DzpilgH4E_003D, !_0023_003Dzbu8BV15Qqzan, _0023_003DzNCZ1IBCMbSi4: true, _0023_003Dzul_00241f12osu0i: false);
				return true;
			}
		}
		return false;
	}

	private bool _0023_003Dz9h5MY_A_003D(double _0023_003Dz3YfTAqg_003D, double _0023_003DzRFb1SGo_003D, double _0023_003DzpilgH4E_003D, double _0023_003Dz8qV981c_003D, double _0023_003Dzm0CYiiE_003D, out double _0023_003DzC1QabNg_003D)
	{
		_0023_003DzC1QabNg_003D = _0023_003DzpilgH4E_003D + (_0023_003DzshZYG54_003D - _0023_003Dz3YfTAqg_003D) * (_0023_003Dz8qV981c_003D - _0023_003DzpilgH4E_003D) / (_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D);
		if (_0023_003DzC1QabNg_003D >= _0023_003Dz_0024Jquo8Y_003D - _0023_003Dzm0CYiiE_003D)
		{
			return _0023_003DzC1QabNg_003D <= _0023_003DzXBPjmW0_003D + _0023_003Dzm0CYiiE_003D;
		}
		return false;
	}
}
