using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

internal class _0023_003DzJSv_IuScKRfn : IndexTriangle
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzoMNiNRw_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzURVICbg_003D = new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzbmrKN9c_003D;

	public _0023_003DzJSv_IuScKRfn()
	{
	}

	public _0023_003DzJSv_IuScKRfn(_0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D, _0023_003DzmKBPh7nOT6nY _0023_003Dzm4eSPQQ_003D)
	{
		_0023_003DzKPF5WrD3_zzc(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
		_0023_003DzUljhMvVRkDXg(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
	}

	public _0023_003DzJSv_IuScKRfn(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D)
	{
		Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D];
		Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D];
		Point3D point3D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZe6oCrQ_003D];
		_0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D = new _0023_003DzmKBPh7nOT6nY(point3D.X, point3D.Y, point3D.Z);
		_0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D = new _0023_003DzmKBPh7nOT6nY(point3D2.X, point3D2.Y, point3D2.Z);
		_0023_003DzmKBPh7nOT6nY _0023_003Dzm4eSPQQ_003D = new _0023_003DzmKBPh7nOT6nY(point3D3.X, point3D3.Y, point3D3.Z);
		_0023_003DzKPF5WrD3_zzc(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
		_0023_003DzUljhMvVRkDXg(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
	}

	public bool _0023_003DzMIlzu0CcUJDlPU5FgqxGvpA_003D(ref _0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D, ref _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D, double _0023_003DzMuQryCb5qjaH, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (_0023_003DzMuQryCb5qjaH <= _0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM._0023_003DzId5C3LA_003D || _0023_003DzMuQryCb5qjaH >= _0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0._0023_003DzId5C3LA_003D)
		{
			return false;
		}
		List<_0023_003DzmKBPh7nOT6nY> list = new List<_0023_003DzmKBPh7nOT6nY>();
		List<_0023_003DzmKBPh7nOT6nY> list2 = new List<_0023_003DzmKBPh7nOT6nY>();
		for (int i = 0; i < 3; i++)
		{
			int num = base[i];
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = new _0023_003DzmKBPh7nOT6nY(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num].X, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num].Y, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num].Z);
			if (_0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D <= _0023_003DzMuQryCb5qjaH)
			{
				list.Add(_0023_003DzmKBPh7nOT6nY2);
			}
			else
			{
				list2.Add(_0023_003DzmKBPh7nOT6nY2);
			}
		}
		if (list.Count != 1 && list.Count != 2)
		{
			foreach (_0023_003DzmKBPh7nOT6nY item in list2)
			{
				_ = item;
			}
			foreach (_0023_003DzmKBPh7nOT6nY item2 in list)
			{
				_ = item2;
			}
		}
		if (list.Count == 2)
		{
			double num2 = (_0023_003DzMuQryCb5qjaH - list2[0]._0023_003DzId5C3LA_003D) / (list[0]._0023_003DzId5C3LA_003D - list2[0]._0023_003DzId5C3LA_003D);
			double num3 = (_0023_003DzMuQryCb5qjaH - list2[0]._0023_003DzId5C3LA_003D) / (list[1]._0023_003DzId5C3LA_003D - list2[0]._0023_003DzId5C3LA_003D);
			_0023_003DzFj_0024IqDQ_003D = list2[0] + num2 * (list[0] - list2[0]);
			_0023_003DzjdeMMkk_003D = list2[0] + num3 * (list[1] - list2[0]);
			return true;
		}
		if (list.Count == 1)
		{
			double num4 = (_0023_003DzMuQryCb5qjaH - list2[0]._0023_003DzId5C3LA_003D) / (list[0]._0023_003DzId5C3LA_003D - list2[0]._0023_003DzId5C3LA_003D);
			double num5 = (_0023_003DzMuQryCb5qjaH - list2[1]._0023_003DzId5C3LA_003D) / (list[0]._0023_003DzId5C3LA_003D - list2[1]._0023_003DzId5C3LA_003D);
			_0023_003DzFj_0024IqDQ_003D = list2[0] + num4 * (list[0] - list2[0]);
			_0023_003DzjdeMMkk_003D = list2[1] + num5 * (list[0] - list2[1]);
			return true;
		}
		return false;
	}

	public _0023_003DzmKBPh7nOT6nY _0023_003Dzyo47DIATkQcD()
	{
		return new _0023_003DzmKBPh7nOT6nY((_0023_003DzoMNiNRw_003D._0023_003DzId5C3LA_003D < 0.0) ? (-1.0 * _0023_003DzoMNiNRw_003D) : _0023_003DzoMNiNRw_003D);
	}

	protected void _0023_003DzKPF5WrD3_zzc(_0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D, _0023_003DzmKBPh7nOT6nY _0023_003Dzm4eSPQQ_003D)
	{
		_0023_003DzmKBPh7nOT6nY obj = _0023_003DzFj_0024IqDQ_003D - _0023_003DzjdeMMkk_003D;
		_0023_003DzmKBPh7nOT6nY _0023_003DzB68dg9Q_003D = _0023_003DzFj_0024IqDQ_003D - _0023_003Dzm4eSPQQ_003D;
		_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = obj._0023_003DzpZFGz6w_003D(_0023_003DzB68dg9Q_003D);
		_0023_003DzmKBPh7nOT6nY2._0023_003Dzt_0024wZMac_003D();
		_0023_003DzoMNiNRw_003D = new _0023_003DzmKBPh7nOT6nY(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D);
	}

	protected void _0023_003DzUljhMvVRkDXg(_0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D, _0023_003DzmKBPh7nOT6nY _0023_003Dzm4eSPQQ_003D)
	{
		_0023_003DzURVICbg_003D._0023_003DzttBXI_0024c_003D();
		_0023_003DzURVICbg_003D._0023_003DzIhSuV5Y_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
	}
}
