using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzY3JYZnIqAm3qx7P9TQ_003D_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected double _0023_003Dz8uslNzRAwfBK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected _0023_003DzmKBPh7nOT6nY _0023_003DzCJkr8nY_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected _0023_003DzmKBPh7nOT6nY _0023_003DzeoY7iyo_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003DzmKBPh7nOT6nY> _0023_003DzoVbH05tuV7yD = new List<_0023_003DzmKBPh7nOT6nY>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003DzmKBPh7nOT6nY> _0023_003DzWvJ2kF0_003D = new List<_0023_003DzmKBPh7nOT6nY>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzURVICbg_003D = new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D();

	public virtual void Dispose()
	{
	}

	public void _0023_003DznS_0024gQS5avM3_(double _0023_003DzXrexKjY_003D)
	{
		_0023_003Dz8uslNzRAwfBK = _0023_003DzXrexKjY_003D;
	}

	public void _0023_003Dzrmn9dQY_003D(_0023_003DzmKBPh7nOT6nY _0023_003DzXrexKjY_003D)
	{
		_0023_003DzCJkr8nY_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzXrexKjY_003D);
	}

	public void _0023_003DzTK3p9PE_003D(_0023_003DzmKBPh7nOT6nY _0023_003DzXrexKjY_003D)
	{
		_0023_003DzeoY7iyo_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzXrexKjY_003D);
	}

	public void _0023_003Dzc_0024pb7t4_003D()
	{
		_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = _0023_003DzCJkr8nY_003D._0023_003DzU2U6sSJ82nfe();
		_0023_003DzmKBPh7nOT6nY2._0023_003Dz5nwUcfduVgzt();
		double num = (_0023_003DzURVICbg_003D._0023_003DzsVJSw85carf0 - _0023_003DzeoY7iyo_003D)._0023_003DzHX2sd2E_003D(_0023_003DzmKBPh7nOT6nY2);
		double num2 = (_0023_003DzURVICbg_003D._0023_003Dz2bkFrf_00246WSWM - _0023_003DzeoY7iyo_003D)._0023_003DzHX2sd2E_003D(_0023_003DzmKBPh7nOT6nY2);
		if (num < num2)
		{
			double num3 = num;
			num = num2;
			num2 = num3;
		}
		List<double> list = new List<double>();
		for (double num4 = num2; num4 <= num; num4 += _0023_003Dz8uslNzRAwfBK)
		{
			list.Add(num4);
			_0023_003DzWvJ2kF0_003D.Add(_0023_003DzeoY7iyo_003D + num4 * _0023_003DzmKBPh7nOT6nY2);
		}
	}

	public List<_0023_003DzmKBPh7nOT6nY> _0023_003DzJueHQtI_003D()
	{
		List<_0023_003DzmKBPh7nOT6nY> list = new List<_0023_003DzmKBPh7nOT6nY>();
		foreach (_0023_003DzmKBPh7nOT6nY item in _0023_003DzWvJ2kF0_003D)
		{
			list.Add(item);
		}
		return list;
	}

	public void _0023_003DzJh9c5dI_003D(_0023_003DzmKBPh7nOT6nY _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzoVbH05tuV7yD.Add(_0023_003DzB68dg9Q_003D);
		_0023_003DzURVICbg_003D._0023_003DzJh9c5dI_003D(_0023_003DzB68dg9Q_003D);
	}

	public override string ToString()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747364) + _0023_003DzoVbH05tuV7yD.Count + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165);
	}
}
