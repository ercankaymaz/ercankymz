using System;

internal sealed class _0023_003DzMcZTdpNsDJoBwDD8eWbrvus_003D
{
	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	public _0023_003DzMcZTdpNsDJoBwDD8eWbrvus_003D(_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k)
	{
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
	}

	public _0023_003DzMcZTdpNsDJoBwDD8eWbrvus_003D()
	{
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(string _0023_003Dzw5jlr_0024DM5PEE, int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D, ref double[] _0023_003DzH9VU2k0_003D, int _0023_003DzPB8Mb17HTSO6, int _0023_003DzHh03WyA_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		int num6 = -1 - _0023_003DzHh03WyA_003D + _0023_003DzPB8Mb17HTSO6;
		_0023_003Dzw5jlr_0024DM5PEE = _0023_003Dzw5jlr_0024DM5PEE.Substring(0, 1);
		if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
		{
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num3 = num2 * _0023_003DzHh03WyA_003D + num6;
				num4 = num2 * _0023_003Dzs0UaYks_003D + num5;
				for (num = 1; num <= Math.Min(num2, _0023_003DzDtqAooE_003D); num++)
				{
					_0023_003DzH9VU2k0_003D[num + num3] = _0023_003DzE8QrneA_003D[num + num4];
				}
			}
			return;
		}
		if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911431)))
		{
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num3 = num2 * _0023_003DzHh03WyA_003D + num6;
				num4 = num2 * _0023_003Dzs0UaYks_003D + num5;
				for (num = num2; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzH9VU2k0_003D[num + num3] = _0023_003DzE8QrneA_003D[num + num4];
				}
			}
			return;
		}
		for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
		{
			num3 = num2 * _0023_003DzHh03WyA_003D + num6;
			num4 = num2 * _0023_003Dzs0UaYks_003D + num5;
			for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
			{
				_0023_003DzH9VU2k0_003D[num + num3] = _0023_003DzE8QrneA_003D[num + num4];
			}
		}
	}
}
