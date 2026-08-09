using System.Drawing;

internal sealed class _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D
{
	private double _0023_003DzsrjgJk0_003D = 1.0;

	private double _0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D = 1.0;

	private double _0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D = 1.0;

	public _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D()
	{
	}

	public _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D(Color _0023_003Dzhpb8QNg_003D)
	{
		_0023_003DzQ9KxgLA_003D(_0023_003Dzhpb8QNg_003D.R, _0023_003Dzhpb8QNg_003D.G, _0023_003Dzhpb8QNg_003D.B);
	}

	public _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D(int _0023_003DzVwcUHuA_003D, int _0023_003Dzd9FpT63j6qEa, int _0023_003DzL0Y0zOsdsFbO)
	{
		_0023_003DzQ9KxgLA_003D(_0023_003DzVwcUHuA_003D, _0023_003Dzd9FpT63j6qEa, _0023_003DzL0Y0zOsdsFbO);
	}

	public _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D(double _0023_003DzsrjgJk0_003D, double _0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D, double _0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D)
	{
		_0023_003DzsutizBxkyxiU(_0023_003DzsrjgJk0_003D);
		_0023_003DzbZm3X2frzUyh(_0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D);
		_0023_003DzJRAeP5bZBG5K(_0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D);
	}

	public double _0023_003DzLMqv9GM4soxd()
	{
		return _0023_003DzsrjgJk0_003D * 240.0;
	}

	public void _0023_003DzsutizBxkyxiU(double _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzsrjgJk0_003D = _0023_003DzMUn_dRZUWv1d(_0023_003DzsLHxXyo_003D / 240.0);
	}

	public double _0023_003DzsIl6oYzOqXXH()
	{
		return _0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D * 240.0;
	}

	public void _0023_003DzbZm3X2frzUyh(double _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D = _0023_003DzMUn_dRZUWv1d(_0023_003DzsLHxXyo_003D / 240.0);
	}

	public double _0023_003DzKqZerAv9eSO7()
	{
		return _0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D * 240.0;
	}

	public void _0023_003DzJRAeP5bZBG5K(double _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D = _0023_003DzMUn_dRZUWv1d(_0023_003DzsLHxXyo_003D / 240.0);
	}

	private double _0023_003DzMUn_dRZUWv1d(double _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003DzsLHxXyo_003D < 0.0)
		{
			_0023_003DzsLHxXyo_003D = 0.0;
		}
		else if (_0023_003DzsLHxXyo_003D > 1.0)
		{
			_0023_003DzsLHxXyo_003D = 1.0;
		}
		return _0023_003DzsLHxXyo_003D;
	}

	public override string ToString()
	{
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589144), _0023_003DzLMqv9GM4soxd(), _0023_003DzsIl6oYzOqXXH(), _0023_003DzKqZerAv9eSO7());
	}

	public string _0023_003Dzd8DJbP5kyvr0()
	{
		Color color = this;
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589451), color.R, color.G, color.B);
	}

	public static implicit operator Color(_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D _0023_003DzPfo5iTw_JWjc)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if (_0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D != 0.0)
		{
			if (_0023_003DzPfo5iTw_JWjc._0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D == 0.0)
			{
				num = (num2 = (num3 = _0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D));
			}
			else
			{
				double num4 = _0023_003DzEjAUP_Aj9Agi(_0023_003DzPfo5iTw_JWjc);
				double _0023_003DzYvuU920_003D = 2.0 * _0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D - num4;
				num = _0023_003Dz38hH2HsiZVtc(_0023_003DzYvuU920_003D, num4, _0023_003DzPfo5iTw_JWjc._0023_003DzsrjgJk0_003D + 1.0 / 3.0);
				num2 = _0023_003Dz38hH2HsiZVtc(_0023_003DzYvuU920_003D, num4, _0023_003DzPfo5iTw_JWjc._0023_003DzsrjgJk0_003D);
				num3 = _0023_003Dz38hH2HsiZVtc(_0023_003DzYvuU920_003D, num4, _0023_003DzPfo5iTw_JWjc._0023_003DzsrjgJk0_003D - 1.0 / 3.0);
			}
		}
		return Color.FromArgb((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
	}

	private static double _0023_003Dz38hH2HsiZVtc(double _0023_003DzYvuU920_003D, double _0023_003DzOP7Rkwk_003D, double _0023_003DzQsFl_Y8_003D)
	{
		_0023_003DzQsFl_Y8_003D = _0023_003Dzjb83oqYcQ8UV(_0023_003DzQsFl_Y8_003D);
		if (_0023_003DzQsFl_Y8_003D < 1.0 / 6.0)
		{
			return _0023_003DzYvuU920_003D + (_0023_003DzOP7Rkwk_003D - _0023_003DzYvuU920_003D) * 6.0 * _0023_003DzQsFl_Y8_003D;
		}
		if (_0023_003DzQsFl_Y8_003D < 0.5)
		{
			return _0023_003DzOP7Rkwk_003D;
		}
		if (_0023_003DzQsFl_Y8_003D < 2.0 / 3.0)
		{
			return _0023_003DzYvuU920_003D + (_0023_003DzOP7Rkwk_003D - _0023_003DzYvuU920_003D) * (2.0 / 3.0 - _0023_003DzQsFl_Y8_003D) * 6.0;
		}
		return _0023_003DzYvuU920_003D;
	}

	private static double _0023_003Dzjb83oqYcQ8UV(double _0023_003DzQsFl_Y8_003D)
	{
		if (_0023_003DzQsFl_Y8_003D < 0.0)
		{
			_0023_003DzQsFl_Y8_003D += 1.0;
		}
		else if (_0023_003DzQsFl_Y8_003D > 1.0)
		{
			_0023_003DzQsFl_Y8_003D -= 1.0;
		}
		return _0023_003DzQsFl_Y8_003D;
	}

	private static double _0023_003DzEjAUP_Aj9Agi(_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D _0023_003DzPfo5iTw_JWjc)
	{
		if (_0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D < 0.5)
		{
			return _0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D * (1.0 + _0023_003DzPfo5iTw_JWjc._0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D);
		}
		return _0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D + _0023_003DzPfo5iTw_JWjc._0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D - _0023_003DzPfo5iTw_JWjc._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D * _0023_003DzPfo5iTw_JWjc._0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D;
	}

	public static implicit operator _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D(Color _0023_003Dzhpb8QNg_003D)
	{
		return new _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D
		{
			_0023_003DzsrjgJk0_003D = (double)_0023_003Dzhpb8QNg_003D.GetHue() / 360.0,
			_0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D = _0023_003Dzhpb8QNg_003D.GetBrightness(),
			_0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D = _0023_003Dzhpb8QNg_003D.GetSaturation()
		};
	}

	public void _0023_003DzQ9KxgLA_003D(int _0023_003DzVwcUHuA_003D, int _0023_003Dzd9FpT63j6qEa, int _0023_003DzL0Y0zOsdsFbO)
	{
		_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2 = Color.FromArgb(_0023_003DzVwcUHuA_003D, _0023_003Dzd9FpT63j6qEa, _0023_003DzL0Y0zOsdsFbO);
		_0023_003DzsrjgJk0_003D = _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2._0023_003DzsrjgJk0_003D;
		_0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D = _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2._0023_003Dz45SxpHhjmDXBW2eO6g_003D_003D;
		_0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D = _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2._0023_003Dz1w7Ex_0024dUDlqBHF8XHQ_003D_003D;
	}
}
