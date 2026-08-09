using System;

internal sealed class _0023_003Dz5iZgNui9MSMk0a4iWHFB5KY_003D
{
	public void _0023_003Dzz8DDgng_003D(double _0023_003DzE8QrneA_003D, double _0023_003DzH9VU2k0_003D, double _0023_003DzshZYG54_003D, double _0023_003DzK_0024fbiW0_003D, ref double _0023_003Dzl3DhHgI_003D, ref double _0023_003DziDLVpbY_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (Math.Abs(_0023_003DzK_0024fbiW0_003D) < Math.Abs(_0023_003DzshZYG54_003D))
		{
			num = _0023_003DzK_0024fbiW0_003D / _0023_003DzshZYG54_003D;
			num2 = _0023_003DzshZYG54_003D + _0023_003DzK_0024fbiW0_003D * num;
			_0023_003Dzl3DhHgI_003D = (_0023_003DzE8QrneA_003D + _0023_003DzH9VU2k0_003D * num) / num2;
			_0023_003DziDLVpbY_003D = (_0023_003DzH9VU2k0_003D - _0023_003DzE8QrneA_003D * num) / num2;
		}
		else
		{
			num = _0023_003DzshZYG54_003D / _0023_003DzK_0024fbiW0_003D;
			num2 = _0023_003DzK_0024fbiW0_003D + _0023_003DzshZYG54_003D * num;
			_0023_003Dzl3DhHgI_003D = (_0023_003DzH9VU2k0_003D + _0023_003DzE8QrneA_003D * num) / num2;
			_0023_003DziDLVpbY_003D = (0.0 - _0023_003DzE8QrneA_003D + _0023_003DzH9VU2k0_003D * num) / num2;
		}
	}
}
