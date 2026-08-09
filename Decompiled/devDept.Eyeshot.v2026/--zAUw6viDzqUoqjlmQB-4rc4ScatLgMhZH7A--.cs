using System;
using System.Collections.Generic;

internal sealed class _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D
{
	private sealed class _0023_003Dzr7l7tGBPv4wm
	{
		public _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D _0023_003DzxCZwjag_003D = new _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D();

		public double _0023_003DzEZoUiZU_003D;

		public _0023_003Dzr7l7tGBPv4wm(_0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D _0023_003Dz4ezcSpk_003D, double _0023_003DzuwH5j5s_003D)
		{
			_0023_003DzxCZwjag_003D = _0023_003Dz4ezcSpk_003D;
			_0023_003DzEZoUiZU_003D = _0023_003DzuwH5j5s_003D;
		}
	}

	private uint _0023_003Dz0PWDSoUUDTLZ;

	private uint _0023_003Dz7GFspnx_00249kdho0SOsA_003D_003D;

	private double _0023_003DziAco57s_003D;

	private double _0023_003Dz2Jz7Q6k_003D;

	private double _0023_003Dzh2oLjuA_003D;

	private double _0023_003Dz919NO9flZyW6;

	private List<_0023_003Dzr7l7tGBPv4wm> _0023_003DzesCM_YU_003D = new List<_0023_003Dzr7l7tGBPv4wm>();

	public _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D()
	{
		_0023_003DzMkd41wQ_003D(0u, 0.0, 0.0);
	}

	public _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D(uint _0023_003Dzm8FNTBVmbKew, double _0023_003DzAqOpw0w_003D, double _0023_003DzNnmvTM0_003D)
	{
		_0023_003DzMkd41wQ_003D(_0023_003Dzm8FNTBVmbKew, _0023_003DzAqOpw0w_003D, _0023_003DzNnmvTM0_003D);
	}

	public void _0023_003DzMkd41wQ_003D(uint _0023_003DzAXGlW_LgzcK9mwKo6g_003D_003D, double _0023_003DzAqOpw0w_003D, double _0023_003DzNnmvTM0_003D)
	{
		_0023_003Dz0PWDSoUUDTLZ = 0u;
		_0023_003Dz7GFspnx_00249kdho0SOsA_003D_003D = _0023_003DzAXGlW_LgzcK9mwKo6g_003D_003D;
		_0023_003DziAco57s_003D = (_0023_003Dz919NO9flZyW6 = _0023_003DzAqOpw0w_003D);
		_0023_003Dzh2oLjuA_003D = _0023_003DzNnmvTM0_003D;
		if (_0023_003DzAXGlW_LgzcK9mwKo6g_003D_003D != 0)
		{
			_0023_003Dz2Jz7Q6k_003D = _0023_003DzNnmvTM0_003D / (double)_0023_003DzAXGlW_LgzcK9mwKo6g_003D_003D;
		}
		else
		{
			_0023_003Dz2Jz7Q6k_003D = 0.0;
		}
	}

	public double _0023_003Dzx0bHtwY_003D()
	{
		int count = _0023_003DzesCM_YU_003D.Count;
		int num = 0;
		double num2 = Math.Min(_0023_003Dz0PWDSoUUDTLZ, _0023_003Dz7GFspnx_00249kdho0SOsA_003D_003D);
		uint num3 = 0u;
		while (num3 < count)
		{
			num2 += _0023_003DzesCM_YU_003D[num]._0023_003DzEZoUiZU_003D * _0023_003DzesCM_YU_003D[num]._0023_003DzxCZwjag_003D._0023_003Dzx0bHtwY_003D();
			num3++;
			num++;
		}
		num2 *= _0023_003Dz2Jz7Q6k_003D;
		num2 = Math.Min(num2, _0023_003Dzh2oLjuA_003D);
		num2 += _0023_003DziAco57s_003D;
		return _0023_003Dz919NO9flZyW6 = Math.Max(num2, _0023_003Dz919NO9flZyW6);
	}

	public void _0023_003DzCV56ZPw_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dz0PWDSoUUDTLZ += _0023_003Dzt_m8zV0_003D;
	}

	public void _0023_003DzOnQC6_0024o_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dz0PWDSoUUDTLZ = _0023_003Dzt_m8zV0_003D;
	}

	public _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D _0023_003DziEI7YSQPG6Mm(int _0023_003Dz437_00244ak_003D)
	{
		return _0023_003DzesCM_YU_003D[_0023_003Dz437_00244ak_003D]._0023_003DzxCZwjag_003D;
	}

	public _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D _0023_003DzhI4nAZ3tm4E6(double _0023_003Dz8oVvvC4_003D, uint _0023_003Dzm8FNTBVmbKew)
	{
		_0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D2 = new _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D(_0023_003Dzm8FNTBVmbKew, 0.0, 1.0);
		_0023_003DzesCM_YU_003D.Add(new _0023_003Dzr7l7tGBPv4wm(_0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D2, _0023_003Dz8oVvvC4_003D));
		return _0023_003DzAUw6viDzqUoqjlmQB_00244rc4ScatLgMhZH7A_003D_003D2;
	}

	public void _0023_003Dzsp2GL7L8hAmZ(_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzND9FFgomKFwJ)
	{
		for (uint num = 0u; num < _0023_003DzND9FFgomKFwJ._0023_003Dz14lzA48_003D(); num++)
		{
			_0023_003DzhI4nAZ3tm4E6(_0023_003DzND9FFgomKFwJ._0023_003DzYBaDcXE_003D(num), 1u);
		}
	}

	public void _0023_003DzqtU0YmwI5ZbG(uint _0023_003DzoMNiNRw_003D)
	{
		while (_0023_003DzesCM_YU_003D.Count > 0 && _0023_003DzoMNiNRw_003D-- != 0)
		{
			_0023_003DzesCM_YU_003D.RemoveAt(_0023_003DzesCM_YU_003D.Count - 1);
		}
	}

	public void _0023_003DzC6T31qc_003D()
	{
		while (_0023_003DzesCM_YU_003D.Count > 0)
		{
			_0023_003DzesCM_YU_003D.RemoveAt(_0023_003DzesCM_YU_003D.Count - 1);
		}
		_0023_003Dz0PWDSoUUDTLZ = _0023_003Dz7GFspnx_00249kdho0SOsA_003D_003D;
		_0023_003Dz919NO9flZyW6 = _0023_003DziAco57s_003D + _0023_003Dzh2oLjuA_003D;
	}

	public void _0023_003DzC6T31qc_003D(int _0023_003DzjdRIo2djDNeK)
	{
		_0023_003DziEI7YSQPG6Mm(_0023_003DzjdRIo2djDNeK)._0023_003DzC6T31qc_003D();
	}
}
