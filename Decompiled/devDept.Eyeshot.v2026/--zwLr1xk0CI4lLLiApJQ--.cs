using System;

internal sealed class _0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D
{
	public double _0023_003DzuwH5j5s_003D;

	public double _0023_003DzNDQ_E88_003D;

	public double _0023_003DztvjrCmmAAgXX;

	public _0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D()
	{
	}

	public _0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D(double _0023_003DzKnFrGh8_003D)
	{
		_0023_003DztvjrCmmAAgXX = _0023_003DzKnFrGh8_003D;
		_0023_003Dz0SLK7Iw_003D();
	}

	public _0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D(double _0023_003DzSRoMBwU_003D, double _0023_003Dz03DsKLQ_003D)
	{
		_0023_003DzuwH5j5s_003D = _0023_003DzSRoMBwU_003D;
		_0023_003DzNDQ_E88_003D = _0023_003Dz03DsKLQ_003D;
	}

	public void _0023_003DzJh3H_obOJy1A7mFikA_003D_003D(double _0023_003DzKnFrGh8_003D)
	{
		_0023_003DztvjrCmmAAgXX = _0023_003DzKnFrGh8_003D;
		_0023_003Dz0SLK7Iw_003D();
	}

	public _0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D _0023_003Dz_0024xXJldw_003D(_0023_003DzwLr1xk0CI4lLLiApJQ_003D_003D _0023_003DzpdeSbFA_003D)
	{
		_0023_003DzuwH5j5s_003D = _0023_003DzpdeSbFA_003D._0023_003DzuwH5j5s_003D;
		_0023_003DzNDQ_E88_003D = _0023_003DzpdeSbFA_003D._0023_003DzNDQ_E88_003D;
		_0023_003DztvjrCmmAAgXX = _0023_003DzpdeSbFA_003D._0023_003DztvjrCmmAAgXX;
		return this;
	}

	public bool _0023_003DzV8T1u4I_003D()
	{
		if (_0023_003Dz6huvP0yWdScitb7UJQ_003D_003D._0023_003Dzo5HYhFiPdo0F(_0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D - 1.0))
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083) + _0023_003DzuwH5j5s_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747561) + _0023_003DzNDQ_E88_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
	}

	private void _0023_003Dz0SLK7Iw_003D()
	{
		double num;
		for (num = _0023_003DztvjrCmmAAgXX; num > 4.0; num -= 4.0)
		{
		}
		for (; num < 0.0; num += 4.0)
		{
		}
		_0023_003DzuwH5j5s_003D = ((num < 2.0) ? (1.0 - num) : (num - 3.0));
		_0023_003DzNDQ_E88_003D = ((!(num < 3.0)) ? (num - 4.0) : ((num > 1.0) ? (2.0 - num) : num));
		double num2 = Math.Sqrt(_0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
		if (num2 != 0.0)
		{
			_0023_003DzuwH5j5s_003D /= num2;
			_0023_003DzNDQ_E88_003D /= num2;
		}
	}
}
