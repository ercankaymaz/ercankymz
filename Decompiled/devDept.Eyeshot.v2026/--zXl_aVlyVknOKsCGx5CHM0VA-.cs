using System;

internal sealed class _0023_003DzXl_aVlyVknOKsCGx5CHM0VA_003D
{
	private _0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D _0023_003Dz2DnLdTZ2C7WD;

	public _0023_003DzXl_aVlyVknOKsCGx5CHM0VA_003D(_0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D _0023_003Dz5mXDE7lKho5d)
	{
		_0023_003Dz2DnLdTZ2C7WD = _0023_003Dz5mXDE7lKho5d;
	}

	public _0023_003DzXl_aVlyVknOKsCGx5CHM0VA_003D()
	{
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003Dzm528LhE7YyFj = new _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D();
		_0023_003DzQ9CpKjyLGJVaqN_0024g8SfdU_Y_003D _0023_003Dz2b0cm7S0DBX = new _0023_003DzQ9CpKjyLGJVaqN_0024g8SfdU_Y_003D(_0023_003Dzm528LhE7YyFj);
		_0023_003DzSW_iG06uwSVUkdFx1ACOoOM_003D _0023_003DzAHX5TE0jHwu = new _0023_003DzSW_iG06uwSVUkdFx1ACOoOM_003D(_0023_003Dzm528LhE7YyFj);
		_0023_003Dzgg1Z_0024Y4qDsmRHS2MJumtN5A_003D _0023_003DzSrxHyoo06mj_0024 = new _0023_003Dzgg1Z_0024Y4qDsmRHS2MJumtN5A_003D(_0023_003Dzm528LhE7YyFj);
		_0023_003DzVxlkiBsYgpDisAbkKM0Oogc_003D _0023_003DzT2MhuyCqMhaK = new _0023_003DzVxlkiBsYgpDisAbkKM0Oogc_003D(_0023_003Dzm528LhE7YyFj, _0023_003Dz2b0cm7S0DBX, _0023_003DzAHX5TE0jHwu, _0023_003DzSrxHyoo06mj_0024);
		_0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D _0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D2 = new _0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D(_0023_003DzpZ9im0izpG3k, _0023_003DzT2MhuyCqMhaK);
		_0023_003Dz2DnLdTZ2C7WD = _0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(double _0023_003DzHit7vU4_003D, double _0023_003DzFmiij5k_003D, ref double _0023_003DzCnu19x8_003D, ref double _0023_003DzBjVnhdQ_003D, ref double _0023_003DzAYqOj_Y_003D)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		num6 = _0023_003Dz2DnLdTZ2C7WD._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911007));
		num3 = _0023_003Dz2DnLdTZ2C7WD._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911012));
		num7 = Math.Pow(_0023_003Dz2DnLdTZ2C7WD._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911084)), Convert.ToInt32(Math.Truncate(Math.Log(num6 / num3) / Math.Log(_0023_003Dz2DnLdTZ2C7WD._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911084))) / 2.0)));
		num8 = 1.0 / num7;
		if (_0023_003DzFmiij5k_003D == 0.0)
		{
			_0023_003DzCnu19x8_003D = 1.0;
			_0023_003DzBjVnhdQ_003D = 0.0;
			_0023_003DzAYqOj_Y_003D = _0023_003DzHit7vU4_003D;
			return;
		}
		if (_0023_003DzHit7vU4_003D == 0.0)
		{
			_0023_003DzCnu19x8_003D = 0.0;
			_0023_003DzBjVnhdQ_003D = 1.0;
			_0023_003DzAYqOj_Y_003D = _0023_003DzFmiij5k_003D;
			return;
		}
		num4 = _0023_003DzHit7vU4_003D;
		num5 = _0023_003DzFmiij5k_003D;
		num9 = Math.Max(Math.Abs(num4), Math.Abs(num5));
		if (num9 >= num8)
		{
			num = 0;
			do
			{
				num++;
				num4 *= num7;
				num5 *= num7;
				num9 = Math.Max(Math.Abs(num4), Math.Abs(num5));
			}
			while (num9 >= num8);
			_0023_003DzAYqOj_Y_003D = Math.Sqrt(Math.Pow(num4, 2.0) + Math.Pow(num5, 2.0));
			_0023_003DzCnu19x8_003D = num4 / _0023_003DzAYqOj_Y_003D;
			_0023_003DzBjVnhdQ_003D = num5 / _0023_003DzAYqOj_Y_003D;
			for (num2 = 1; num2 <= num; num2++)
			{
				_0023_003DzAYqOj_Y_003D *= num8;
			}
		}
		else if (num9 <= num7)
		{
			num = 0;
			do
			{
				num++;
				num4 *= num8;
				num5 *= num8;
				num9 = Math.Max(Math.Abs(num4), Math.Abs(num5));
			}
			while (num9 <= num7);
			_0023_003DzAYqOj_Y_003D = Math.Sqrt(Math.Pow(num4, 2.0) + Math.Pow(num5, 2.0));
			_0023_003DzCnu19x8_003D = num4 / _0023_003DzAYqOj_Y_003D;
			_0023_003DzBjVnhdQ_003D = num5 / _0023_003DzAYqOj_Y_003D;
			for (num2 = 1; num2 <= num; num2++)
			{
				_0023_003DzAYqOj_Y_003D *= num7;
			}
		}
		else
		{
			_0023_003DzAYqOj_Y_003D = Math.Sqrt(Math.Pow(num4, 2.0) + Math.Pow(num5, 2.0));
			_0023_003DzCnu19x8_003D = num4 / _0023_003DzAYqOj_Y_003D;
			_0023_003DzBjVnhdQ_003D = num5 / _0023_003DzAYqOj_Y_003D;
		}
		if (Math.Abs(_0023_003DzHit7vU4_003D) > Math.Abs(_0023_003DzFmiij5k_003D) && _0023_003DzCnu19x8_003D < 0.0)
		{
			_0023_003DzCnu19x8_003D = 0.0 - _0023_003DzCnu19x8_003D;
			_0023_003DzBjVnhdQ_003D = 0.0 - _0023_003DzBjVnhdQ_003D;
			_0023_003DzAYqOj_Y_003D = 0.0 - _0023_003DzAYqOj_Y_003D;
		}
	}
}
