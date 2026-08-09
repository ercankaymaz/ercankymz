using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D : _0023_003DzqE2_rSbKEYOWg1YDTaU27fo_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Geometry3D _0023_003DzDrKwE3hZ6YHg;

	public _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D()
	{
		_0023_003DzqBfSlyfgN_zy.Clear();
		_0023_003DzqBfSlyfgN_zy.Add(new _0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D());
		_0023_003DzqBfSlyfgN_zy.Add(new _0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D());
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DzdFPnQefUJPX5();
		_0023_003DzqBfSlyfgN_zy[1]._0023_003DzuTxqKb4dqyH9();
	}

	public void _0023_003Dz12p2jmUTCnCB(Setup _0023_003Dz9cS3uG0_003D, Geometry3D _0023_003Dz0y8dHgRbs7n3, _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_Bn_pNI_003D)
	{
		_0023_003DzDrKwE3hZ6YHg = _0023_003Dz0y8dHgRbs7n3;
		_0023_003Dz_0024KKopL9T7nzT = new _0023_003DzDS4a8SQ0SZSap4ac3A_003D_003D();
		_0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM = new _0023_003DzmKBPh7nOT6nY(_0023_003DzDrKwE3hZ6YHg.GetBoxMin(_0023_003Dz9cS3uG0_003D).X, _0023_003DzDrKwE3hZ6YHg.GetBoxMin(_0023_003Dz9cS3uG0_003D).Y, _0023_003DzDrKwE3hZ6YHg.GetBoxMin(_0023_003Dz9cS3uG0_003D).Z);
		_0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0 = new _0023_003DzmKBPh7nOT6nY(_0023_003DzDrKwE3hZ6YHg.GetBoxMax(_0023_003Dz9cS3uG0_003D).X, _0023_003DzDrKwE3hZ6YHg.GetBoxMax(_0023_003Dz9cS3uG0_003D).Y, _0023_003DzDrKwE3hZ6YHg.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z);
		foreach (_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D item in _0023_003DzqBfSlyfgN_zy)
		{
			item._0023_003Dz12p2jmUTCnCB(_0023_003Dz9cS3uG0_003D, _0023_003Dz0y8dHgRbs7n3, _0023_003Dz_Bn_pNI_003D);
		}
	}

	public void _0023_003DzmG2bu6MobTwJ(_0023_003Dzi7XR59NGN6Cp _0023_003DzKLzUdk0_003D)
	{
		_0023_003DzqBfSlyfgN_zy[1]._0023_003DzEszHAa2jzlga(_0023_003DzKLzUdk0_003D);
	}

	public void _0023_003DzV2pFhhR9Idxx(_0023_003Dzi7XR59NGN6Cp _0023_003DzaYZe3P8_003D)
	{
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DzEszHAa2jzlga(_0023_003DzaYZe3P8_003D);
	}

	public void _0023_003DzlRm6XLNSMLjYhgSAqQ_003D_003D(int _0023_003Dz437_00244ak_003D, double _0023_003Dz8ZbKIrg_003D)
	{
		if (_0023_003Dz437_00244ak_003D == 0)
		{
			double num = _0023_003DzzhSDYPa50tjn._0023_003DzyJk8r50_003D();
			double num2 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM._0023_003DzBJFJHwk_003D - num;
			double num3 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0._0023_003DzBJFJHwk_003D + num;
			double num4 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM._0023_003Dz40R7bAU_003D - num;
			double num5 = _0023_003Dz_0024KKopL9T7nzT._0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0._0023_003Dz40R7bAU_003D + num;
			int _0023_003DzoMNiNRw_003D = (int)((num3 - num2) / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
			int _0023_003DzoMNiNRw_003D2 = (int)((num5 - num4) / _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
			double[] array = _0023_003DzkyFASTPzdFgF(num2, num3, _0023_003DzoMNiNRw_003D);
			double[] array2 = _0023_003DzkyFASTPzdFgF(num4, num5, _0023_003DzoMNiNRw_003D2);
			foreach (double _0023_003DzFP3nEGM_003D in array2)
			{
				_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y = new _0023_003DzmKBPh7nOT6nY(num2, _0023_003DzFP3nEGM_003D, _0023_003Dz8ZbKIrg_003D);
				_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY = new _0023_003DzmKBPh7nOT6nY(num3, _0023_003DzFP3nEGM_003D, _0023_003Dz8ZbKIrg_003D);
				_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D = new _0023_003Dzi7XR59NGN6Cp(_0023_003DzsiQjbwmUNI0y, _0023_003DzSElTn3BlQAJY);
				_0023_003DzqBfSlyfgN_zy[0]._0023_003DzEszHAa2jzlga(_0023_003DzhidJeNw_003D);
			}
			array2 = array;
			foreach (double _0023_003DzEI2ExbQ_003D in array2)
			{
				_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y2 = new _0023_003DzmKBPh7nOT6nY(_0023_003DzEI2ExbQ_003D, num4, _0023_003Dz8ZbKIrg_003D);
				_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY2 = new _0023_003DzmKBPh7nOT6nY(_0023_003DzEI2ExbQ_003D, num5, _0023_003Dz8ZbKIrg_003D);
				_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D2 = new _0023_003Dzi7XR59NGN6Cp(_0023_003DzsiQjbwmUNI0y2, _0023_003DzSElTn3BlQAJY2);
				_0023_003DzqBfSlyfgN_zy[1]._0023_003DzEszHAa2jzlga(_0023_003DzhidJeNw_003D2);
			}
			return;
		}
		foreach (_0023_003DzsbeHAAjCqCPR item in _0023_003DzqBfSlyfgN_zy)
		{
			foreach (_0023_003Dzi7XR59NGN6Cp item2 in item._0023_003DzSglpqkz7rghu())
			{
				item2._0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D = _0023_003Dz8ZbKIrg_003D;
				item2._0023_003DzjdeMMkk_003D._0023_003DzId5C3LA_003D = _0023_003Dz8ZbKIrg_003D;
				foreach (_0023_003DznZQ9NSjF878u item3 in item2._0023_003DzhoegMB067LVL)
				{
					item3._0023_003DzpTJxen_zvfHAc4t8Kg_003D_003D = false;
					item3._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Clear();
					item3._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Clear();
				}
			}
		}
	}

	private double[] _0023_003DzkyFASTPzdFgF(double _0023_003DzAqOpw0w_003D, double _0023_003Dzk64JNOo_003D, int _0023_003DzoMNiNRw_003D)
	{
		double[] array = new double[_0023_003DzoMNiNRw_003D + 1];
		double num = (_0023_003Dzk64JNOo_003D - _0023_003DzAqOpw0w_003D) / (double)_0023_003DzoMNiNRw_003D;
		double num2 = _0023_003DzAqOpw0w_003D;
		for (int i = 0; i < _0023_003DzoMNiNRw_003D + 1; i++)
		{
			array[i] = num2;
			num2 += num;
		}
		return array;
	}

	public void _0023_003DzWQuPA6x8Dy0a()
	{
		_0023_003DzeT9xI7i86Kv3O5yHjQ_003D_003D(_0023_003DzqBfSlyfgN_zy[0]._0023_003DzSglpqkz7rghu(), _0023_003DzqBfSlyfgN_zy[1]._0023_003DzSglpqkz7rghu());
	}

	public Point3D[][] _0023_003DzfUw1SlQ_003D()
	{
		List<Point3D[]> list = new List<Point3D[]>(_0023_003Dzcv8o5nO25OjS.Count);
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			List<_0023_003DzmKBPh7nOT6nY> list2 = _0023_003Dzcv8o5nO25OjS[i];
			Point3D[] array = new Point3D[list2.Count + 1];
			for (int j = 0; j < list2.Count; j++)
			{
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = list2[j];
				array[j] = new Point3D(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D);
			}
			array[list2.Count] = (Point3D)array[0].Clone();
			Utility.ComputeBoundingRect(array, out var boxMin, out var boxMax);
			if (new Size2D(boxMin, boxMax).Min > 0.0)
			{
				list.Add(array);
			}
		}
		return list.ToArray();
	}

	public void _0023_003Dzz8DDgng_003D(double _0023_003Dzm0CYiiE_003D, ref int _0023_003DzuOMylKfpuJP0, double _0023_003DzLpcnctI_003D)
	{
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[0])._0023_003Dzz8DDgng_003D(_0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0);
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[1])._0023_003Dzz8DDgng_003D(_0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0);
	}

	public void _0023_003DzndU0T1PE_0024LNX(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D, double _0023_003Dzm0CYiiE_003D, double _0023_003DzLpcnctI_003D, ref int _0023_003DzuOMylKfpuJP0, List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D)
	{
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[0])._0023_003Dzz8DDgng_003D(_0023_003DzhidJeNw_003D, _0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0, _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D);
	}

	public void _0023_003DzndU0T1PE_0024LNX(double _0023_003Dzm0CYiiE_003D, double _0023_003DzLpcnctI_003D, ref int _0023_003DzuOMylKfpuJP0, List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D)
	{
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[0])._0023_003Dzz8DDgng_003D(_0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0, _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D);
	}

	public void _0023_003Dzg7iMJdLya4hW(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D, double _0023_003Dzm0CYiiE_003D, double _0023_003DzLpcnctI_003D, ref int _0023_003DzuOMylKfpuJP0, List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D)
	{
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[1])._0023_003Dzz8DDgng_003D(_0023_003DzhidJeNw_003D, _0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0, _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D);
	}

	public void _0023_003Dzg7iMJdLya4hW(double _0023_003Dzm0CYiiE_003D, double _0023_003DzLpcnctI_003D, ref int _0023_003DzuOMylKfpuJP0, List<_0023_003DzR0pHse6hl8ZsnAwb9Q_003D_003D> _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D)
	{
		((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[1])._0023_003Dzz8DDgng_003D(_0023_003Dzm0CYiiE_003D, _0023_003DzLpcnctI_003D, ref _0023_003DzuOMylKfpuJP0, _0023_003Dz4AwHXMX1qrQL8NZhYw_003D_003D);
	}

	public List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzC5ujV8QgrKmUwyGmiw_003D_003D()
	{
		return ((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[0])._0023_003DzSglpqkz7rghu();
	}

	public List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzFFdRlnUb7lMf7EOo0g_003D_003D()
	{
		return ((_0023_003Dzfgip9Dx0LnGQqxMD5ArXELD2drhOmlEwHGhmgyNYiXqfqrhfbw_003D_003D)_0023_003DzqBfSlyfgN_zy[1])._0023_003DzSglpqkz7rghu();
	}

	public _0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003DzXT4sGPyMpoH6()
	{
		return _0023_003DzzhSDYPa50tjn;
	}

	public void _0023_003DzJI1HPIONNrAbic39_g_003D_003D(double _0023_003DzId5C3LA_003D)
	{
		_0023_003Dz9NrCn_o_003D = _0023_003DzId5C3LA_003D;
		foreach (_0023_003Dzi7XR59NGN6Cp item in _0023_003DzqBfSlyfgN_zy[0]._0023_003DzSglpqkz7rghu())
		{
			item._0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D = _0023_003DzId5C3LA_003D;
			item._0023_003DzjdeMMkk_003D._0023_003DzId5C3LA_003D = _0023_003DzId5C3LA_003D;
			foreach (_0023_003DznZQ9NSjF878u item2 in item._0023_003DzhoegMB067LVL)
			{
				item2._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Clear();
				item2._0023_003DzpTJxen_zvfHAc4t8Kg_003D_003D = false;
			}
		}
		foreach (_0023_003Dzi7XR59NGN6Cp item3 in _0023_003DzqBfSlyfgN_zy[1]._0023_003DzSglpqkz7rghu())
		{
			item3._0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D = _0023_003DzId5C3LA_003D;
			item3._0023_003DzjdeMMkk_003D._0023_003DzId5C3LA_003D = _0023_003DzId5C3LA_003D;
			foreach (_0023_003DznZQ9NSjF878u item4 in item3._0023_003DzhoegMB067LVL)
			{
				item4._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Clear();
				item4._0023_003DzpTJxen_zvfHAc4t8Kg_003D_003D = false;
			}
		}
	}

	public void _0023_003Dzv9osLK4_003D(List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzmDH1fND8rUCN, List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzSYnbJHaKGdmw)
	{
		_0023_003DzqBfSlyfgN_zy[0]._0023_003DznckkLRw_003D();
		foreach (_0023_003Dzi7XR59NGN6Cp item in _0023_003DzmDH1fND8rUCN)
		{
			_0023_003DzqBfSlyfgN_zy[0]._0023_003DzEszHAa2jzlga(item);
		}
		_0023_003DzqBfSlyfgN_zy[1]._0023_003DznckkLRw_003D();
		foreach (_0023_003Dzi7XR59NGN6Cp item2 in _0023_003DzSYnbJHaKGdmw)
		{
			_0023_003DzqBfSlyfgN_zy[1]._0023_003DzEszHAa2jzlga(item2);
		}
	}
}
