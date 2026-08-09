using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using devDept.Geometry;

internal class _0023_003DzqE2_rSbKEYOWg1YDTaU27fo_003D : _0023_003DzsbeHAAjCqCPR
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected double _0023_003Dz9NrCn_o_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<List<_0023_003DzmKBPh7nOT6nY>> _0023_003Dzcv8o5nO25OjS = new List<List<_0023_003DzmKBPh7nOT6nY>>();

	public _0023_003DzqE2_rSbKEYOWg1YDTaU27fo_003D()
	{
		_0023_003DzqBfSlyfgN_zy.Clear();
		_0023_003DzqBfSlyfgN_zy.Add(new _0023_003DzLyzqMfpc9q1g_00242mqMdoIBAo_003D());
		_0023_003DzqBfSlyfgN_zy.Add(new _0023_003DzLyzqMfpc9q1g_00242mqMdoIBAo_003D());
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DzdFPnQefUJPX5();
		_0023_003DzqBfSlyfgN_zy[1]._0023_003DzuTxqKb4dqyH9();
		_0023_003Dz9gtKlqaHSgER7ANluQ_003D_003D = 1u;
	}

	public override void Dispose()
	{
		_0023_003DzqBfSlyfgN_zy.Clear();
		base.Dispose();
	}

	public void _0023_003DzMFlIwko_003D(double _0023_003DzId5C3LA_003D)
	{
		_0023_003Dz9NrCn_o_003D = _0023_003DzId5C3LA_003D;
	}

	public override void _0023_003Dzc_0024pb7t4_003D()
	{
		_0023_003DzhkHkXLSiqog5I1_zlw_003D_003D();
		Parallel.For(0, 2, _0023_003DzBfD2h7Ok0B4BJSeObg_003D_003D);
		_0023_003DzeT9xI7i86Kv3O5yHjQ_003D_003D(_0023_003DzqBfSlyfgN_zy[0]._0023_003DzSglpqkz7rghu(), _0023_003DzqBfSlyfgN_zy[1]._0023_003DzSglpqkz7rghu());
	}

	public void _0023_003Dzz8DDgng_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003DzhkHkXLSiqog5I1_zlw_003D_003D();
		((_0023_003DzLyzqMfpc9q1g_00242mqMdoIBAo_003D)_0023_003DzqBfSlyfgN_zy[0])._0023_003Dzz8DDgng_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		((_0023_003DzLyzqMfpc9q1g_00242mqMdoIBAo_003D)_0023_003DzqBfSlyfgN_zy[1])._0023_003Dzz8DDgng_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		_0023_003DzeT9xI7i86Kv3O5yHjQ_003D_003D(_0023_003DzqBfSlyfgN_zy[0]._0023_003DzSglpqkz7rghu(), _0023_003DzqBfSlyfgN_zy[1]._0023_003DzSglpqkz7rghu());
	}

	public virtual void _0023_003DzzaquRm0_003D()
	{
		_0023_003DzhkHkXLSiqog5I1_zlw_003D_003D();
		_0023_003DzqBfSlyfgN_zy[0]._0023_003Dzc_0024pb7t4_003D();
		_0023_003DzqBfSlyfgN_zy[1]._0023_003Dzc_0024pb7t4_003D();
		_0023_003DzqDkigzfeXZCfo6bZmw_003D_003D(_0023_003DzqBfSlyfgN_zy[0]._0023_003DzSglpqkz7rghu(), _0023_003DzqBfSlyfgN_zy[1]._0023_003DzSglpqkz7rghu());
	}

	public List<List<_0023_003DzmKBPh7nOT6nY>> _0023_003DzLRqJOHw_003D()
	{
		return new List<List<_0023_003DzmKBPh7nOT6nY>>(_0023_003Dzcv8o5nO25OjS);
	}

	public override void _0023_003DznckkLRw_003D()
	{
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DznckkLRw_003D();
		_0023_003DzqBfSlyfgN_zy[1]._0023_003DznckkLRw_003D();
	}

	protected void _0023_003DzeT9xI7i86Kv3O5yHjQ_003D_003D(IList<_0023_003Dzi7XR59NGN6Cp> _0023_003DzQZT_0024QgDKtAVQ, IList<_0023_003Dzi7XR59NGN6Cp> _0023_003DzcEy0WMEw_0024la1)
	{
		_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_00249 _0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410 = new _0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_00249();
		foreach (_0023_003Dzi7XR59NGN6Cp item in _0023_003DzQZT_0024QgDKtAVQ)
		{
			_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410._0023_003DzQBJ0gJk_003D(item);
		}
		foreach (_0023_003Dzi7XR59NGN6Cp item2 in _0023_003DzcEy0WMEw_0024la1)
		{
			_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410._0023_003DzQBJ0gJk_003D(item2);
		}
		_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410._0023_003DzaCgY2eQ_003D();
		_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410._0023_003DzHxyb1LjWGoq4();
		_0023_003Dzcv8o5nO25OjS = new List<List<_0023_003DzmKBPh7nOT6nY>>(_0023_003Dzna3mLM5h7RpQxV0oHxkhCkACCW_002410._0023_003DzLRqJOHw_003D());
	}

	protected void _0023_003DzqDkigzfeXZCfo6bZmw_003D_003D(IList<_0023_003Dzi7XR59NGN6Cp> _0023_003DzQZT_0024QgDKtAVQ, IList<_0023_003Dzi7XR59NGN6Cp> _0023_003DzcEy0WMEw_0024la1)
	{
		_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK94 _0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95 = new _0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK94();
		foreach (_0023_003Dzi7XR59NGN6Cp item in _0023_003DzQZT_0024QgDKtAVQ)
		{
			_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95._0023_003DzQBJ0gJk_003D(item);
		}
		foreach (_0023_003Dzi7XR59NGN6Cp item2 in _0023_003DzcEy0WMEw_0024la1)
		{
			_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95._0023_003DzQBJ0gJk_003D(item2);
		}
		_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95._0023_003DzaCgY2eQ_003D();
		_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95._0023_003DzHxyb1LjWGoq4();
		_0023_003Dzcv8o5nO25OjS = new List<List<_0023_003DzmKBPh7nOT6nY>>(_0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK95._0023_003DzLRqJOHw_003D());
	}

	protected void _0023_003DzhkHkXLSiqog5I1_zlw_003D_003D()
	{
		double num = _0023_003DzzhSDYPa50tjn._0023_003DzyJk8r50_003D();
		double num2 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM._0023_003DzBJFJHwk_003D - num;
		double num3 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0._0023_003DzBJFJHwk_003D + num;
		double num4 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM._0023_003Dz40R7bAU_003D - num;
		double num5 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0._0023_003Dz40R7bAU_003D + num;
		int _0023_003DzpGjKR04_003D = (int)((num3 - num2) / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
		int _0023_003DzpGjKR04_003D2 = (int)((num5 - num4) / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
		List<double> list = _0023_003Dzz2EVo65odnjR(num2, num3, _0023_003DzpGjKR04_003D);
		foreach (double item in _0023_003Dzz2EVo65odnjR(num4, num5, _0023_003DzpGjKR04_003D2))
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y = new _0023_003DzmKBPh7nOT6nY(num2, item, _0023_003Dz9NrCn_o_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY = new _0023_003DzmKBPh7nOT6nY(num3, item, _0023_003Dz9NrCn_o_003D);
			_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D = new _0023_003Dzi7XR59NGN6Cp(_0023_003DzsiQjbwmUNI0y, _0023_003DzSElTn3BlQAJY);
			_0023_003DzqBfSlyfgN_zy[0]._0023_003DzEszHAa2jzlga(_0023_003DzhidJeNw_003D);
		}
		foreach (double item2 in list)
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y2 = new _0023_003DzmKBPh7nOT6nY(item2, num4, _0023_003Dz9NrCn_o_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY2 = new _0023_003DzmKBPh7nOT6nY(item2, num5, _0023_003Dz9NrCn_o_003D);
			_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D2 = new _0023_003Dzi7XR59NGN6Cp(_0023_003DzsiQjbwmUNI0y2, _0023_003DzSElTn3BlQAJY2);
			_0023_003DzqBfSlyfgN_zy[1]._0023_003DzEszHAa2jzlga(_0023_003DzhidJeNw_003D2);
		}
	}

	protected List<double> _0023_003Dzz2EVo65odnjR(double _0023_003DzAqOpw0w_003D, double _0023_003Dzk64JNOo_003D, int _0023_003DzpGjKR04_003D)
	{
		List<double> list = new List<double>();
		double num = (_0023_003Dzk64JNOo_003D - _0023_003DzAqOpw0w_003D) / (double)_0023_003DzpGjKR04_003D;
		double num2 = _0023_003DzAqOpw0w_003D;
		for (int i = 0; i < _0023_003DzpGjKR04_003D + 1; i++)
		{
			list.Add(num2);
			num2 += num;
		}
		return new List<double>(list);
	}

	protected List<double> _0023_003Dzz2EVo65odnjR(double _0023_003DzAqOpw0w_003D, double _0023_003Dzk64JNOo_003D, int _0023_003DzpGjKR04_003D, double _0023_003DzIrPGUnY_003D)
	{
		List<double> list = new List<double>();
		double num = _0023_003DzAqOpw0w_003D;
		for (int i = 0; i < _0023_003DzpGjKR04_003D + 1; i++)
		{
			list.Add(num);
			num += _0023_003DzIrPGUnY_003D;
		}
		return new List<double>(list);
	}

	internal int _0023_003DzUQIEiCaarANi(double _0023_003DzPXdo6aLYBSrx, out double _0023_003DzIrPGUnY_003D)
	{
		double num = _0023_003DzPXdo6aLYBSrx / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D;
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Truncate(num);
		int num4 = ((num - (double)num3 < _0023_003DzPXdo6aLYBSrx * 1E-06) ? num3 : num2);
		_0023_003DzIrPGUnY_003D = _0023_003DzPXdo6aLYBSrx / (double)num4;
		return num4;
	}

	private void _0023_003DzBfD2h7Ok0B4BJSeObg_003D_003D(int _0023_003Dz437_00244ak_003D)
	{
		_0023_003DzqBfSlyfgN_zy[_0023_003Dz437_00244ak_003D]._0023_003Dzc_0024pb7t4_003D();
	}
}
