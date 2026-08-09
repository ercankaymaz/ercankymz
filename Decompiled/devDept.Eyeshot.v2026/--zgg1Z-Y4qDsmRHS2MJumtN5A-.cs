internal sealed class _0023_003Dzgg1Z_0024Y4qDsmRHS2MJumtN5A_003D
{
	private _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003Dz7xnyX74MWj2D;

	public _0023_003Dzgg1Z_0024Y4qDsmRHS2MJumtN5A_003D(_0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003Dzm528LhE7YyFj)
	{
		_0023_003Dz7xnyX74MWj2D = _0023_003Dzm528LhE7YyFj;
	}

	public _0023_003Dzgg1Z_0024Y4qDsmRHS2MJumtN5A_003D()
	{
		_0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D2 = new _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D();
		_0023_003Dz7xnyX74MWj2D = _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(int _0023_003Dzvru6xb3f6RhX, int _0023_003Dzl3DhHgI_003D, int _0023_003DzuDXXVQ_rsLSa, bool _0023_003DzDNBJhIE_003D, ref int _0023_003DzeruKsdRmGQOw, ref double _0023_003DzPUG_29FPBefL)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		num4 = 1;
		num = 1;
		while (true)
		{
			num5 = num4 * 2;
			if (num5 > -_0023_003DzuDXXVQ_rsLSa)
			{
				break;
			}
			num4 = num5;
			num++;
		}
		if (num4 == -_0023_003DzuDXXVQ_rsLSa)
		{
			num6 = num4;
		}
		else
		{
			num6 = num5;
			num++;
		}
		num2 = ((num6 + _0023_003DzuDXXVQ_rsLSa <= -num4 - _0023_003DzuDXXVQ_rsLSa) ? (2 * num6) : (2 * num4));
		_0023_003DzeruKsdRmGQOw = num2 + _0023_003DzuDXXVQ_rsLSa - 1;
		if (_0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(1 + num + _0023_003Dzl3DhHgI_003D, 2) == 1 && _0023_003Dzvru6xb3f6RhX == 2)
		{
			_0023_003DzeruKsdRmGQOw--;
		}
		if (_0023_003DzDNBJhIE_003D)
		{
			_0023_003DzeruKsdRmGQOw--;
		}
		num8 = 1.0 / (double)_0023_003Dzvru6xb3f6RhX;
		num10 = (double)_0023_003Dzvru6xb3f6RhX - 1.0;
		num9 = 0.0;
		for (num3 = 1; num3 <= _0023_003Dzl3DhHgI_003D; num3++)
		{
			num10 *= num8;
			if (num9 < 1.0)
			{
				num7 = num9;
			}
			num9 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num9, num10);
		}
		if (num9 >= 1.0)
		{
			num9 = num7;
		}
		for (num3 = 1; num3 <= _0023_003DzeruKsdRmGQOw; num3++)
		{
			num9 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num9 * (double)_0023_003Dzvru6xb3f6RhX, 0.0);
		}
		_0023_003DzPUG_29FPBefL = num9;
	}
}
