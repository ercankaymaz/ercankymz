using System;

internal sealed class _0023_003Dze8RDFP8p4_0024Fo2WfxcNXiLSc_003D
{
	private _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz1iBohgL71bme;

	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	public _0023_003Dze8RDFP8p4_0024Fo2WfxcNXiLSc_003D(_0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003DzHDJXO07Z0oKC, _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k)
	{
		_0023_003Dz1iBohgL71bme = _0023_003DzHDJXO07Z0oKC;
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
	}

	public _0023_003Dze8RDFP8p4_0024Fo2WfxcNXiLSc_003D()
	{
		_0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2 = new _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D();
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003Dz1iBohgL71bme = _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2;
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
	}

	public double _0023_003Dzz8DDgng_003D(string _0023_003Dzy1tKBYQ_003D, int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D, ref double[] _0023_003DzUvl_D7g_003D, int _0023_003DzSiwxa0IjGuoh)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		int num7 = -1 + _0023_003DzSiwxa0IjGuoh;
		_0023_003Dzy1tKBYQ_003D = _0023_003Dzy1tKBYQ_003D.Substring(0, 1);
		if (Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D) == 0)
		{
			num5 = 0.0;
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911366)))
		{
			num5 = 0.0;
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					num5 = Math.Max(num5, Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]));
				}
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910999)) || _0023_003Dzy1tKBYQ_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388))
		{
			num5 = 0.0;
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num4 = 0.0;
				for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					num4 += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
				}
				num5 = Math.Max(num5, num4);
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911423)))
		{
			for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
			{
				_0023_003DzUvl_D7g_003D[num + num7] = 0.0;
			}
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzUvl_D7g_003D[num + num7] += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
				}
			}
			num5 = 0.0;
			for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
			{
				num5 = Math.Max(num5, _0023_003DzUvl_D7g_003D[num + num7]);
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911036)) || _0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911012)))
		{
			num3 = 0.0;
			num4 = 1.0;
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(_0023_003DzDtqAooE_003D, _0023_003DzE8QrneA_003D, 1 + num2 * _0023_003Dzs0UaYks_003D + num6, 1, ref num3, ref num4);
			}
			num5 = num3 * Math.Sqrt(num4);
		}
		return num5;
	}
}
