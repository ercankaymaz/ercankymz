using System;

internal sealed class _0023_003Dzh_0024w5Ffg429ZqS5YRTTuqNpk_003D
{
	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	public _0023_003Dzh_0024w5Ffg429ZqS5YRTTuqNpk_003D(_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k)
	{
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
	}

	public _0023_003Dzh_0024w5Ffg429ZqS5YRTTuqNpk_003D()
	{
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(string _0023_003Dzw5jlr_0024DM5PEE, int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, double _0023_003DztKROdcY_003D, double _0023_003Dzvru6xb3f6RhX, ref double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		_0023_003Dzw5jlr_0024DM5PEE = _0023_003Dzw5jlr_0024DM5PEE.Substring(0, 1);
		if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
		{
			for (num2 = 2; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num3 = num2 * _0023_003Dzs0UaYks_003D + num4;
				for (num = 1; num <= Math.Min(num2 - 1, _0023_003DzDtqAooE_003D); num++)
				{
					_0023_003DzE8QrneA_003D[num + num3] = _0023_003DztKROdcY_003D;
				}
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911431)))
		{
			for (num2 = 1; num2 <= Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D); num2++)
			{
				num3 = num2 * _0023_003Dzs0UaYks_003D + num4;
				for (num = num2 + 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzE8QrneA_003D[num + num3] = _0023_003DztKROdcY_003D;
				}
			}
		}
		else
		{
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num3 = num2 * _0023_003Dzs0UaYks_003D + num4;
				for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzE8QrneA_003D[num + num3] = _0023_003DztKROdcY_003D;
				}
			}
		}
		for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D); num++)
		{
			_0023_003DzE8QrneA_003D[num + num * _0023_003Dzs0UaYks_003D + num4] = _0023_003Dzvru6xb3f6RhX;
		}
	}
}
