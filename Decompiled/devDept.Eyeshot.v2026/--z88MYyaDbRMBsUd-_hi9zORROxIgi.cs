using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

internal readonly struct _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly List<int> _0023_003DzcrRI_CI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Point2D _0023_003DzZqSqKm8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Point2D _0023_003DztvD0Jdc_003D;

	public _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi(int _0023_003Dzu8sgotQ_003D)
	{
		_0023_003DzZqSqKm8_003D = new Point2D(0.0, 0.0);
		_0023_003DztvD0Jdc_003D = new Point2D(0.0, 0.0);
		_0023_003DzcrRI_CI_003D = new List<int>(_0023_003Dzu8sgotQ_003D);
	}

	public _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi(_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi _0023_003Dzl_0024MIsC0_003D)
	{
		_0023_003DzZqSqKm8_003D = (Point2D)_0023_003Dzl_0024MIsC0_003D._0023_003DzZqSqKm8_003D.Clone();
		_0023_003DztvD0Jdc_003D = (Point2D)_0023_003Dzl_0024MIsC0_003D._0023_003DztvD0Jdc_003D.Clone();
		_0023_003DzcrRI_CI_003D = new List<int>(_0023_003Dzl_0024MIsC0_003D._0023_003DzcrRI_CI_003D);
	}

	internal void _0023_003DzZH19a0bYlPkl(List<Point2D> _0023_003DzrdSL0CI_003D)
	{
		if (_0023_003DzcrRI_CI_003D.Count >= 1)
		{
			double min = _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[0]].X;
			double min2 = _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[0]].Y;
			double max = min;
			double max2 = min2;
			for (int i = 1; i < _0023_003DzcrRI_CI_003D.Count; i++)
			{
				Point2D point2D = _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[i]];
				Utility.UpdateMinMax(point2D.X, ref min, ref max);
				Utility.UpdateMinMax(point2D.Y, ref min2, ref max2);
			}
			_0023_003DzZqSqKm8_003D.X = min;
			_0023_003DzZqSqKm8_003D.Y = min2;
			_0023_003DztvD0Jdc_003D.X = max;
			_0023_003DztvD0Jdc_003D.Y = max2;
		}
	}

	internal pointStatusType _0023_003DzrfhmnHeX0Pzt(IList<Point2D> _0023_003DzrdSL0CI_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzZTe_0024jFG9ebLg, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		double _0023_003DzT2I49JGvQcku = _0023_003DzuMKQhOieejyEvhtVOw_003D_003D * _0023_003DzuMKQhOieejyEvhtVOw_003D_003D;
		if (_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D - _0023_003DzZqSqKm8_003D.X + _0023_003DzuMKQhOieejyEvhtVOw_003D_003D < 0.0 || _0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D - _0023_003DztvD0Jdc_003D.X - _0023_003DzuMKQhOieejyEvhtVOw_003D_003D > 0.0 || _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - _0023_003DzZqSqKm8_003D.Y + _0023_003DzuMKQhOieejyEvhtVOw_003D_003D < 0.0 || _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - _0023_003DztvD0Jdc_003D.Y - _0023_003DzuMKQhOieejyEvhtVOw_003D_003D > 0.0)
		{
			return pointStatusType.Outside;
		}
		int count = _0023_003DzcrRI_CI_003D.Count;
		for (int i = 0; i < count - 1; i++)
		{
			if (Utility._0023_003DzedEHTyqioyyN(_0023_003DzZTe_0024jFG9ebLg, _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[i]]._0023_003DzwY26hvo2cSE0(), _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[i + 1]]._0023_003DzwY26hvo2cSE0(), _0023_003DzT2I49JGvQcku))
			{
				return pointStatusType.Onto;
			}
		}
		int num = 0;
		int num2 = 0;
		int index = count - 1;
		while (num2 < count)
		{
			if (((_0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].Y <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[index]].Y) || (_0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[index]].Y <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].Y)) && _0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D < (_0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[index]].X - _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].X) * (_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].Y) / (_0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[index]].Y - _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].Y) + _0023_003DzrdSL0CI_003D[_0023_003DzcrRI_CI_003D[num2]].X)
			{
				num++;
			}
			index = num2++;
		}
		if ((num & 1) != 0)
		{
			return pointStatusType.Inside;
		}
		return pointStatusType.Outside;
	}
}
