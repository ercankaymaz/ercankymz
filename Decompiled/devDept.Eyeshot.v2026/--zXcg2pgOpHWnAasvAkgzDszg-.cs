using System;

internal sealed class _0023_003DzXcg2pgOpHWnAasvAkgzDszg_003D
{
	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	private _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz1iBohgL71bme;

	public _0023_003DzXcg2pgOpHWnAasvAkgzDszg_003D(_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k, _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003DzHDJXO07Z0oKC)
	{
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
		_0023_003Dz1iBohgL71bme = _0023_003DzHDJXO07Z0oKC;
	}

	public _0023_003DzXcg2pgOpHWnAasvAkgzDszg_003D()
	{
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2 = new _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D();
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
		_0023_003Dz1iBohgL71bme = _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2;
	}

	public double _0023_003Dzz8DDgng_003D(string _0023_003Dzy1tKBYQ_003D, int _0023_003DzpGjKR04_003D, double[] _0023_003DzK_0024fbiW0_003D, int _0023_003Dzx0hyf0lftOUh, double[] _0023_003DzDNpeQO0_003D, int _0023_003DzyX5exFDtOeiC)
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = -1 + _0023_003Dzx0hyf0lftOUh;
		int num6 = -1 + _0023_003DzyX5exFDtOeiC;
		_0023_003Dzy1tKBYQ_003D = _0023_003Dzy1tKBYQ_003D.Substring(0, 1);
		if (_0023_003DzpGjKR04_003D <= 0)
		{
			num2 = 0.0;
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911366)))
		{
			num2 = Math.Abs(_0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num5]);
			for (num = 1; num <= _0023_003DzpGjKR04_003D - 1; num++)
			{
				num2 = Math.Max(num2, Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num5]));
				num2 = Math.Max(num2, Math.Abs(_0023_003DzDNpeQO0_003D[num + num6]));
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910999)) || _0023_003Dzy1tKBYQ_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388) || _0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911423)))
		{
			if (_0023_003DzpGjKR04_003D == 1)
			{
				num2 = Math.Abs(_0023_003DzK_0024fbiW0_003D[1 + num5]);
			}
			else
			{
				num2 = Math.Max(Math.Abs(_0023_003DzK_0024fbiW0_003D[1 + num5]) + Math.Abs(_0023_003DzDNpeQO0_003D[1 + num6]), Math.Abs(_0023_003DzDNpeQO0_003D[_0023_003DzpGjKR04_003D - 1 + num6]) + Math.Abs(_0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num5]));
				for (num = 2; num <= _0023_003DzpGjKR04_003D - 1; num++)
				{
					num2 = Math.Max(num2, Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num5]) + Math.Abs(_0023_003DzDNpeQO0_003D[num + num6]) + Math.Abs(_0023_003DzDNpeQO0_003D[num - 1 + num6]));
				}
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911036)) || _0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911012)))
		{
			num3 = 0.0;
			num4 = 1.0;
			if (_0023_003DzpGjKR04_003D > 1)
			{
				_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(_0023_003DzpGjKR04_003D - 1, _0023_003DzDNpeQO0_003D, _0023_003DzyX5exFDtOeiC, 1, ref num3, ref num4);
				num4 *= 2.0;
			}
			_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(_0023_003DzpGjKR04_003D, _0023_003DzK_0024fbiW0_003D, _0023_003Dzx0hyf0lftOUh, 1, ref num3, ref num4);
			num2 = num3 * Math.Sqrt(num4);
		}
		return num2;
	}
}
