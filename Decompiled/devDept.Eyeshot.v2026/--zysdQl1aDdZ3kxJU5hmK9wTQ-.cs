internal sealed class _0023_003DzysdQl1aDdZ3kxJU5hmK9wTQ_003D
{
	public void _0023_003Dzz8DDgng_003D(bool _0023_003DzC7TsodzQc9bX, int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DznyzW66c_003D, ref int[] _0023_003DzWYPqg2E_003D, int _0023_003DzJQCT3MnavBui)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		double num5 = 0.0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = -1 - _0023_003DznyzW66c_003D + _0023_003DzVwzJWWz_0024BCSn;
		int num10 = -1 + _0023_003DzJQCT3MnavBui;
		if (_0023_003DzpGjKR04_003D <= 1)
		{
			return;
		}
		for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
		{
			_0023_003DzWYPqg2E_003D[num + num10] = -_0023_003DzWYPqg2E_003D[num + num10];
		}
		if (_0023_003DzC7TsodzQc9bX)
		{
			for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
			{
				if (_0023_003DzWYPqg2E_003D[num + num10] > 0)
				{
					continue;
				}
				num4 = num;
				_0023_003DzWYPqg2E_003D[num4 + num10] = -_0023_003DzWYPqg2E_003D[num4 + num10];
				num3 = _0023_003DzWYPqg2E_003D[num4 + num10];
				while (_0023_003DzWYPqg2E_003D[num3 + num10] <= 0)
				{
					num6 = num4 * _0023_003DznyzW66c_003D + num9;
					num7 = num3 * _0023_003DznyzW66c_003D + num9;
					for (num2 = 1; num2 <= _0023_003DzDtqAooE_003D; num2++)
					{
						num5 = _0023_003Dzyk2fsPo_003D[num2 + num6];
						_0023_003Dzyk2fsPo_003D[num2 + num6] = _0023_003Dzyk2fsPo_003D[num2 + num7];
						_0023_003Dzyk2fsPo_003D[num2 + num7] = num5;
					}
					_0023_003DzWYPqg2E_003D[num3 + num10] = -_0023_003DzWYPqg2E_003D[num3 + num10];
					num4 = num3;
					num3 = _0023_003DzWYPqg2E_003D[num3 + num10];
				}
			}
			return;
		}
		for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
		{
			if (_0023_003DzWYPqg2E_003D[num + num10] > 0)
			{
				continue;
			}
			_0023_003DzWYPqg2E_003D[num + num10] = -_0023_003DzWYPqg2E_003D[num + num10];
			for (num4 = _0023_003DzWYPqg2E_003D[num + num10]; num4 != num; num4 = _0023_003DzWYPqg2E_003D[num4 + num10])
			{
				num8 = num * _0023_003DznyzW66c_003D + num9;
				num6 = num4 * _0023_003DznyzW66c_003D + num9;
				for (num2 = 1; num2 <= _0023_003DzDtqAooE_003D; num2++)
				{
					num5 = _0023_003Dzyk2fsPo_003D[num2 + num8];
					_0023_003Dzyk2fsPo_003D[num2 + num8] = _0023_003Dzyk2fsPo_003D[num2 + num6];
					_0023_003Dzyk2fsPo_003D[num2 + num6] = num5;
				}
				_0023_003DzWYPqg2E_003D[num4 + num10] = -_0023_003DzWYPqg2E_003D[num4 + num10];
			}
		}
	}
}
