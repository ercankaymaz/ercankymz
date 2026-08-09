using System;

internal sealed class _0023_003DzVwR3Ei12zCMO7DN92ervNqI_003D
{
	private _0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D _0023_003Dz2DnLdTZ2C7WD;

	public _0023_003DzVwR3Ei12zCMO7DN92ervNqI_003D(_0023_003Dz6LAuTGl0o3UU_aJQSAz0m7A_003D _0023_003Dz5mXDE7lKho5d)
	{
		_0023_003Dz2DnLdTZ2C7WD = _0023_003Dz5mXDE7lKho5d;
	}

	public _0023_003DzVwR3Ei12zCMO7DN92ervNqI_003D()
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

	public void _0023_003Dzz8DDgng_003D(int _0023_003DzAebOrkw_003D, int _0023_003DzGLwmegk_003D, ref double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, int _0023_003DzBmiQDfU_003D, ref double _0023_003Dzug0CzBWNLXq5, ref double _0023_003Dzkw6DW2x_jbrr, ref double _0023_003DzE0Vvfh69LUFt, ref double _0023_003Dzs7NKFeY_003D, ref double _0023_003DzPhxN6ym4gw7e, ref double _0023_003DzjpcQ0pSubuxt)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		int num7 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		if (_0023_003DzGLwmegk_003D - _0023_003DzAebOrkw_003D - 1 <= 0)
		{
			return;
		}
		num5 = _0023_003Dz2DnLdTZ2C7WD._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911071));
		num = 4 * _0023_003DzAebOrkw_003D + _0023_003DzBmiQDfU_003D - 3;
		num4 = _0023_003Dz8wjMonY_003D[num + 4 + num7];
		num3 = (_0023_003Dzug0CzBWNLXq5 = _0023_003Dz8wjMonY_003D[num + num7]);
		if (_0023_003DzBmiQDfU_003D == 0)
		{
			for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
			{
				_0023_003Dz8wjMonY_003D[num - 2 + num7] = num3 + _0023_003Dz8wjMonY_003D[num - 1 + num7];
				if (_0023_003Dz8wjMonY_003D[num - 2 + num7] == 0.0)
				{
					_0023_003Dz8wjMonY_003D[num + num7] = 0.0;
					num3 = (_0023_003Dzug0CzBWNLXq5 = _0023_003Dz8wjMonY_003D[num + 1 + num7]);
					num4 = 0.0;
				}
				else if (num5 * _0023_003Dz8wjMonY_003D[num + 1 + num7] < _0023_003Dz8wjMonY_003D[num - 2 + num7] && num5 * _0023_003Dz8wjMonY_003D[num - 2 + num7] < _0023_003Dz8wjMonY_003D[num + 1 + num7])
				{
					num6 = _0023_003Dz8wjMonY_003D[num + 1 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7];
					_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num - 1 + num7] * num6;
					num3 *= num6;
				}
				else
				{
					_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num + 1 + num7] * (_0023_003Dz8wjMonY_003D[num - 1 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
					num3 = _0023_003Dz8wjMonY_003D[num + 1 + num7] * (num3 / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
				}
				_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
				num4 = Math.Min(num4, _0023_003Dz8wjMonY_003D[num + num7]);
			}
		}
		else
		{
			for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
			{
				_0023_003Dz8wjMonY_003D[num - 3 + num7] = num3 + _0023_003Dz8wjMonY_003D[num + num7];
				if (_0023_003Dz8wjMonY_003D[num - 3 + num7] == 0.0)
				{
					_0023_003Dz8wjMonY_003D[num - 1 + num7] = 0.0;
					num3 = (_0023_003Dzug0CzBWNLXq5 = _0023_003Dz8wjMonY_003D[num + 2 + num7]);
					num4 = 0.0;
				}
				else if (num5 * _0023_003Dz8wjMonY_003D[num + 2 + num7] < _0023_003Dz8wjMonY_003D[num - 3 + num7] && num5 * _0023_003Dz8wjMonY_003D[num - 3 + num7] < _0023_003Dz8wjMonY_003D[num + 2 + num7])
				{
					num6 = _0023_003Dz8wjMonY_003D[num + 2 + num7] / _0023_003Dz8wjMonY_003D[num - 3 + num7];
					_0023_003Dz8wjMonY_003D[num - 1 + num7] = _0023_003Dz8wjMonY_003D[num + num7] * num6;
					num3 *= num6;
				}
				else
				{
					_0023_003Dz8wjMonY_003D[num - 1 + num7] = _0023_003Dz8wjMonY_003D[num + 2 + num7] * (_0023_003Dz8wjMonY_003D[num + num7] / _0023_003Dz8wjMonY_003D[num - 3 + num7]);
					num3 = _0023_003Dz8wjMonY_003D[num + 2 + num7] * (num3 / _0023_003Dz8wjMonY_003D[num - 3 + num7]);
				}
				_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
				num4 = Math.Min(num4, _0023_003Dz8wjMonY_003D[num - 1 + num7]);
			}
		}
		_0023_003DzjpcQ0pSubuxt = num3;
		_0023_003DzE0Vvfh69LUFt = _0023_003Dzug0CzBWNLXq5;
		num = 4 * (_0023_003DzGLwmegk_003D - 2) - _0023_003DzBmiQDfU_003D;
		num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
		_0023_003Dz8wjMonY_003D[num - 2 + num7] = _0023_003DzjpcQ0pSubuxt + _0023_003Dz8wjMonY_003D[num2 + num7];
		if (_0023_003Dz8wjMonY_003D[num - 2 + num7] == 0.0)
		{
			_0023_003Dz8wjMonY_003D[num + num7] = 0.0;
			_0023_003DzPhxN6ym4gw7e = _0023_003Dz8wjMonY_003D[num2 + 2 + num7];
			_0023_003Dzug0CzBWNLXq5 = _0023_003DzPhxN6ym4gw7e;
			num4 = 0.0;
		}
		else if (num5 * _0023_003Dz8wjMonY_003D[num2 + 2 + num7] < _0023_003Dz8wjMonY_003D[num - 2 + num7] && num5 * _0023_003Dz8wjMonY_003D[num - 2 + num7] < _0023_003Dz8wjMonY_003D[num2 + 2 + num7])
		{
			num6 = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7];
			_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num2 + num7] * num6;
			_0023_003DzPhxN6ym4gw7e = _0023_003DzjpcQ0pSubuxt * num6;
		}
		else
		{
			_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] * (_0023_003Dz8wjMonY_003D[num2 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
			_0023_003DzPhxN6ym4gw7e = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] * (_0023_003DzjpcQ0pSubuxt / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
		}
		_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003DzPhxN6ym4gw7e);
		_0023_003Dzkw6DW2x_jbrr = _0023_003Dzug0CzBWNLXq5;
		num += 4;
		num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
		_0023_003Dz8wjMonY_003D[num - 2 + num7] = _0023_003DzPhxN6ym4gw7e + _0023_003Dz8wjMonY_003D[num2 + num7];
		if (_0023_003Dz8wjMonY_003D[num - 2 + num7] == 0.0)
		{
			_0023_003Dz8wjMonY_003D[num + num7] = 0.0;
			_0023_003Dzs7NKFeY_003D = _0023_003Dz8wjMonY_003D[num2 + 2 + num7];
			_0023_003Dzug0CzBWNLXq5 = _0023_003Dzs7NKFeY_003D;
			num4 = 0.0;
		}
		else if (num5 * _0023_003Dz8wjMonY_003D[num2 + 2 + num7] < _0023_003Dz8wjMonY_003D[num - 2 + num7] && num5 * _0023_003Dz8wjMonY_003D[num - 2 + num7] < _0023_003Dz8wjMonY_003D[num2 + 2 + num7])
		{
			num6 = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7];
			_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num2 + num7] * num6;
			_0023_003Dzs7NKFeY_003D = _0023_003DzPhxN6ym4gw7e * num6;
		}
		else
		{
			_0023_003Dz8wjMonY_003D[num + num7] = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] * (_0023_003Dz8wjMonY_003D[num2 + num7] / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
			_0023_003Dzs7NKFeY_003D = _0023_003Dz8wjMonY_003D[num2 + 2 + num7] * (_0023_003DzPhxN6ym4gw7e / _0023_003Dz8wjMonY_003D[num - 2 + num7]);
		}
		_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003Dzs7NKFeY_003D);
		_0023_003Dz8wjMonY_003D[num + 2 + num7] = _0023_003Dzs7NKFeY_003D;
		_0023_003Dz8wjMonY_003D[4 * _0023_003DzGLwmegk_003D - _0023_003DzBmiQDfU_003D + num7] = num4;
	}
}
