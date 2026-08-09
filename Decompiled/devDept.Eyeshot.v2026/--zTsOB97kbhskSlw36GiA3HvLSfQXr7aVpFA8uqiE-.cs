using System;

internal sealed class _0023_003DzTsOB97kbhskSlw36GiA3HvLSfQXr7aVpFA8uqiE_003D : _0023_003DzM8p3zPnjMMGo2qq76o8vgNaO1PjKgUDTGosMByI_003D
{
	private enum _0023_003DzCp025oNguDa9
	{
		MAX_N = 8
	}

	protected uint _0023_003DzOeGh1Js_003D;

	protected uint _0023_003DzwnuleXg_003D;

	protected double[] _0023_003Dz5hBSdSn0aC2X = new double[17];

	public _0023_003DzTsOB97kbhskSlw36GiA3HvLSfQXr7aVpFA8uqiE_003D(double _0023_003DzVGm4Uv_RWdSS = 1.0, uint _0023_003DzpGjKR04_003D = 0u)
	{
		_0023_003DzMkd41wQ_003D(_0023_003DzVGm4Uv_RWdSS, _0023_003DzpGjKR04_003D);
	}

	public void _0023_003DzMkd41wQ_003D(double _0023_003DzVGm4Uv_RWdSS, uint _0023_003DzpGjKR04_003D)
	{
		double num = 1.0;
		uint num2 = Convert.ToUInt32(_0023_003DzCp025oNguDa9.MAX_N);
		_0023_003DzOeGh1Js_003D = _0023_003DzpGjKR04_003D;
		_0023_003DzwnuleXg_003D = 0u;
		_0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzo6KAXJQ_003D(_0023_003Dz5hBSdSn0aC2X, 1.0);
		if (_0023_003DzpGjKR04_003D == 0)
		{
			return;
		}
		double num3 = (num = Math.Pow(_0023_003DzVGm4Uv_RWdSS, 1.0 / (double)_0023_003DzpGjKR04_003D));
		for (uint num4 = 1u; num4 <= num2; num4++)
		{
			_0023_003Dz5hBSdSn0aC2X[8 + num4] = num;
			_0023_003Dz5hBSdSn0aC2X[8 - num4] = 1.0 / num;
			if (num4 < _0023_003DzpGjKR04_003D)
			{
				num *= num3;
			}
		}
	}

	public double _0023_003DzXULhp_00248_003D(uint _0023_003Dzuz8BZRU_003D, uint _0023_003Dz0wAkCmM_003D)
	{
		if (_0023_003Dz0wAkCmM_003D > _0023_003Dzuz8BZRU_003D + _0023_003DzOeGh1Js_003D)
		{
			_0023_003Dz0wAkCmM_003D = _0023_003Dzuz8BZRU_003D + _0023_003DzOeGh1Js_003D;
		}
		else if (_0023_003Dz0wAkCmM_003D + _0023_003DzOeGh1Js_003D < _0023_003Dzuz8BZRU_003D)
		{
			_0023_003Dz0wAkCmM_003D = _0023_003Dzuz8BZRU_003D - _0023_003DzOeGh1Js_003D;
		}
		return _0023_003Dz5hBSdSn0aC2X[8 + _0023_003Dz0wAkCmM_003D - _0023_003Dzuz8BZRU_003D];
	}

	public override double _0023_003DzXULhp_00248_003D(_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzQQ6FBLg_003D, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzytDpi1c_003D)
	{
		return _0023_003DzXULhp_00248_003D(_0023_003DzQQ6FBLg_003D._0023_003DzmVsXTy4_003D(), _0023_003DzytDpi1c_003D._0023_003DzmVsXTy4_003D());
	}

	public void _0023_003Dz3qOqxSy3TjLS(uint _0023_003Dzuz8BZRU_003D)
	{
		_0023_003DzwnuleXg_003D = _0023_003Dzuz8BZRU_003D;
	}

	public override void _0023_003Dz3qOqxSy3TjLS(_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzQQ6FBLg_003D)
	{
		_0023_003Dz3qOqxSy3TjLS(_0023_003DzQQ6FBLg_003D._0023_003DzmVsXTy4_003D());
	}

	public double _0023_003DzXULhp_00248_003D(uint _0023_003Dz0wAkCmM_003D)
	{
		return _0023_003DzXULhp_00248_003D(_0023_003DzwnuleXg_003D, _0023_003Dz0wAkCmM_003D);
	}

	public override double _0023_003DzXULhp_00248_003D(_0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzytDpi1c_003D)
	{
		return _0023_003DzXULhp_00248_003D(_0023_003DzytDpi1c_003D._0023_003DzmVsXTy4_003D());
	}

	public override double _0023_003Dzj1VyO9rCq5WQ()
	{
		uint _0023_003Dz0wAkCmM_003D = ((!(_0023_003Dz5hBSdSn0aC2X[9] < 1.0)) ? (_0023_003DzwnuleXg_003D + _0023_003DzOeGh1Js_003D) : 0u);
		return _0023_003DzXULhp_00248_003D(_0023_003Dz0wAkCmM_003D);
	}
}
