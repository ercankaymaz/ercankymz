using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Meshing;
using devDept.Geometry;

internal sealed class _0023_003DzUFi2Ad_0024Ytg090IOXdOGk2GfzslgJG2rZ6gDhwWs041Oxa_0024IdFQ_003D_003D : Mesher
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ICurve _0023_003DzlhS8HxeSpLWK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SizesOnCurve _0023_003DzS8tLEGM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dzw_0024xMPmM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D[] _0023_003DzwbbgHmo_003D;

	public _0023_003DzUFi2Ad_0024Ytg090IOXdOGk2GfzslgJG2rZ6gDhwWs041Oxa_0024IdFQ_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, SizesOnCurve _0023_003DzU7WRl9I_003D)
	{
		_0023_003DzlhS8HxeSpLWK = _0023_003Dz8fpRyMu9aKjE ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989460));
		_0023_003DzS8tLEGM_003D = _0023_003DzU7WRl9I_003D ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989469));
		_0023_003Dzw_0024xMPmM_003D = _0023_003DzS8tLEGM_003D.StartSize > _0023_003DzS8tLEGM_003D.EndSize;
		if (_0023_003DzS8tLEGM_003D.StartSize == _0023_003DzS8tLEGM_003D.EndSize)
		{
			_0023_003Dzw_0024xMPmM_003D = _0023_003DzGrL5WtI_003D(_0023_003DzlhS8HxeSpLWK.TangentAt(_0023_003DzlhS8HxeSpLWK.Domain.Mid));
		}
		if (_0023_003Dzw_0024xMPmM_003D)
		{
			_0023_003DzS8tLEGM_003D = _0023_003DzS8tLEGM_003D.Swap();
			_0023_003DzlhS8HxeSpLWK = (ICurve)_0023_003DzlhS8HxeSpLWK.Clone();
			_0023_003DzlhS8HxeSpLWK.Reverse();
		}
	}

	private double _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D()
	{
		return (double)base.SmoothingPasses / 50.0;
	}

	private static bool _0023_003DzGrL5WtI_003D(Vector3D _0023_003Dzrw_q2yI_003D)
	{
		if (!_0023_003Dzrw_q2yI_003D.IsUnit)
		{
			_0023_003Dzrw_q2yI_003D.Normalize();
		}
		if (_0023_003Dzrw_q2yI_003D.X != 0.0)
		{
			return _0023_003Dzrw_q2yI_003D.X > 0.0;
		}
		if (_0023_003Dzrw_q2yI_003D.Y != 0.0)
		{
			return _0023_003Dzrw_q2yI_003D.Y > 0.0;
		}
		return _0023_003Dzrw_q2yI_003D.Z > 0.0;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzwbbgHmo_003D = _0023_003DzfHSvFLY_003D(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	public Point3D[] _0023_003DzfHSvFLY_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] array = _0023_003Dz8XqXqDk4trJc(_0023_003DzmHS7frs_003D);
		if (array.Length > 2)
		{
			array = _0023_003DzlUynXNR2Uhgt(array);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return Array.Empty<Point3D>();
			}
			if (!_0023_003Dzy9tytiY8GrO9(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, array))
			{
				return Array.Empty<Point3D>();
			}
		}
		PointTangent[] array2 = new PointTangent[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = CurveMesher._0023_003DzMEXpAaVkFlpl(_0023_003DzlhS8HxeSpLWK, array[i]._0023_003DzmAHVzIc_003D);
		}
		if (_0023_003DzlhS8HxeSpLWK.IsClosed && array.Length < 4)
		{
			array2 = new PointTangent[4];
			for (int j = 0; j < 4; j++)
			{
				double _0023_003DzNDQ_E88_003D = _0023_003DzlhS8HxeSpLWK.Domain.ParameterAt((double)j / 3.0);
				array2[j] = CurveMesher._0023_003DzMEXpAaVkFlpl(_0023_003DzlhS8HxeSpLWK, _0023_003DzNDQ_E88_003D);
			}
		}
		if (_0023_003Dzw_0024xMPmM_003D)
		{
			Array.Reverse(array2);
			PointTangent[] array3 = array2;
			foreach (PointTangent pointTangent in array3)
			{
				Vector3D tangent = pointTangent.Tangent;
				tangent.Negate();
				pointTangent.Tangent = tangent;
			}
		}
		return array2.Cast<Point3D>().ToArray();
	}

	private _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] _0023_003Dz8XqXqDk4trJc(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		double _0023_003Dzjyaz_Vfaky9X = Utility._0023_003Dzjyaz_Vfaky9X;
		List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> list = new List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D>();
		double num = 0.0;
		double num2 = _0023_003DzlhS8HxeSpLWK.Length();
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2 = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzlhS8HxeSpLWK.PointAt(_0023_003DzlhS8HxeSpLWK.Domain.Low), 0.0, _0023_003DzlhS8HxeSpLWK.Domain.Low);
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3 = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzlhS8HxeSpLWK.PointAt(_0023_003DzlhS8HxeSpLWK.Domain.High), num2, _0023_003DzlhS8HxeSpLWK.Domain.High);
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D4 = _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2;
		while (num < (1.0 - _0023_003Dzjyaz_Vfaky9X) * num2)
		{
			list.Add(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D4);
			double num3 = _0023_003Dz4VsXesQ_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D4);
			num += num3;
			double num4 = _0023_003DzvWnyemjmd4sV(num, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3, num2);
			while (_0023_003DzlhS8HxeSpLWK.PointAt(num4).DistanceTo(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D4) < (1.0 - _0023_003Dzjyaz_Vfaky9X) * num3 && num < num2)
			{
				num += num3 / 100.0;
				num4 = _0023_003DzvWnyemjmd4sV(num, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3, num2);
			}
			_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D4 = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzlhS8HxeSpLWK.PointAt(num4), num, num4);
			UpdateProgress(num / num2, 1.0 + _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D(), base.MeshingText, _0023_003DzmHS7frs_003D);
		}
		list.Add(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3);
		return list.ToArray();
	}

	private bool _0023_003Dzy9tytiY8GrO9(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, IList<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> _0023_003DzrdSL0CI_003D)
	{
		double _0023_003Dz0cvP7b8_003D = _0023_003DzlhS8HxeSpLWK.Length();
		int smoothingPasses = base.SmoothingPasses;
		for (int i = 0; i < smoothingPasses; i++)
		{
			string text = base.SmoothingText + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) + (i + 1);
			double num = i;
			UpdateProgress(1.0 + num / (double)smoothingPasses * _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D(), 1.0 + _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D(), text, _0023_003DzmHS7frs_003D);
			for (int j = 1; j < _0023_003DzrdSL0CI_003D.Count - 1; j++)
			{
				double num2 = _0023_003Dz4VsXesQ_003D(_0023_003DzrdSL0CI_003D[j - 1]);
				double num3 = _0023_003Dz4VsXesQ_003D(_0023_003DzrdSL0CI_003D[j]);
				double num4 = _0023_003DzrdSL0CI_003D[j].DistanceTo(_0023_003DzrdSL0CI_003D[j - 1]);
				double num5 = _0023_003DzrdSL0CI_003D[j].DistanceTo(_0023_003DzrdSL0CI_003D[j + 1]);
				double num6 = (num4 - num2 - (num5 - num3)) / 2.0;
				double num7 = _0023_003DzrdSL0CI_003D[j]._0023_003Dz1DxA_0024lQYh5fg - num6;
				double num8 = _0023_003DzvWnyemjmd4sV(num7, _0023_003DzrdSL0CI_003D[j - 1], _0023_003DzrdSL0CI_003D[j + 1], _0023_003Dz0cvP7b8_003D);
				_0023_003DzrdSL0CI_003D[j] = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzlhS8HxeSpLWK.PointAt(num8), num7, num8);
				num += 1.0 / ((double)_0023_003DzrdSL0CI_003D.Count - 2.0);
			}
			UpdateProgress(1.0 + num / (double)smoothingPasses * _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D(), 1.0 + _0023_003DzX3Rmuke5NwdHChZmxvreMJG5BGmPqRZrAUv0BbA_003D(), text, _0023_003DzmHS7frs_003D);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return false;
			}
		}
		return true;
	}

	private double _0023_003DzvWnyemjmd4sV(double _0023_003Dz736ekIs_003D, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DzF7v9r2A_003D, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz8dK2uhU_003D, double _0023_003Dz0cvP7b8_003D)
	{
		double t;
		if (_0023_003DzlhS8HxeSpLWK is Curve curve)
		{
			curve.SubCurve(_0023_003DzF7v9r2A_003D._0023_003DzmAHVzIc_003D, _0023_003Dz8dK2uhU_003D._0023_003DzmAHVzIc_003D, out var sub);
			sub.GetParamFromLength(_0023_003Dz736ekIs_003D - _0023_003DzF7v9r2A_003D._0023_003Dz1DxA_0024lQYh5fg, _0023_003Dz0cvP7b8_003D, out t);
		}
		else
		{
			_0023_003DzlhS8HxeSpLWK.GetParamFromLength(_0023_003Dz736ekIs_003D, out t);
		}
		return t;
	}

	private double _0023_003Dz4VsXesQ_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DzjbqS1qE_003D)
	{
		double num = (_0023_003DzjbqS1qE_003D._0023_003DzmAHVzIc_003D - _0023_003DzlhS8HxeSpLWK.Domain.Low) / _0023_003DzlhS8HxeSpLWK.Domain.Length;
		return _0023_003DzS8tLEGM_003D.StartSize + (_0023_003DzS8tLEGM_003D.EndSize - _0023_003DzS8tLEGM_003D.StartSize) * num;
	}

	private double _0023_003Dz6GD7zF0_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DzjbqS1qE_003D, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1v6oPQk_003D)
	{
		double num = _0023_003DzjbqS1qE_003D.DistanceTo(_0023_003Dz1v6oPQk_003D);
		double num2 = _0023_003Dz4VsXesQ_003D(_0023_003DzjbqS1qE_003D);
		double num3 = _0023_003Dz4VsXesQ_003D(_0023_003Dz1v6oPQk_003D);
		return (Math.Abs(num2 - num) / num2 + Math.Abs(num3 - num) / num3) / 2.0;
	}

	private _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] _0023_003DzlUynXNR2Uhgt(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] _0023_003DzrdSL0CI_003D)
	{
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2 = _0023_003DzrdSL0CI_003D.Last();
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3 = _0023_003DzrdSL0CI_003D[^2];
		double num = _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003Dz1DxA_0024lQYh5fg - _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3._0023_003Dz1DxA_0024lQYh5fg;
		double _0023_003DzaUF77KfxjxOo = _0023_003DzlhS8HxeSpLWK.Length();
		double _0023_003Dz7R4nzv0_003D;
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] result = _0023_003Dz_jsXuB4_003D(_0023_003DzrdSL0CI_003D, _0023_003DzaUF77KfxjxOo, num / (double)(_0023_003DzrdSL0CI_003D.Length - 2), _0023_003DzXVItJ0IO9a8l: true, out _0023_003Dz7R4nzv0_003D);
		double _0023_003Dz7R4nzv0_003D2;
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] result2 = _0023_003Dz_jsXuB4_003D(_0023_003DzrdSL0CI_003D, _0023_003DzaUF77KfxjxOo, 0.0, _0023_003DzXVItJ0IO9a8l: false, out _0023_003Dz7R4nzv0_003D2);
		double num2 = (num - (_0023_003Dz4VsXesQ_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2) + _0023_003Dz4VsXesQ_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3)) / 2.0) / (double)(_0023_003DzrdSL0CI_003D.Length - 1);
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] array;
		double _0023_003Dz7R4nzv0_003D3;
		if (_0023_003DzrdSL0CI_003D[1]._0023_003Dz1DxA_0024lQYh5fg + num2 <= 0.0)
		{
			array = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[_0023_003DzrdSL0CI_003D.Length - 1];
			Array.Copy(_0023_003DzrdSL0CI_003D, array, array.Length);
			array[^1] = _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2;
			_0023_003Dz_jsXuB4_003D(array, _0023_003DzaUF77KfxjxOo, 0.0, _0023_003DzXVItJ0IO9a8l: false, out _0023_003Dz7R4nzv0_003D3);
		}
		else
		{
			array = _0023_003Dz_jsXuB4_003D(_0023_003DzrdSL0CI_003D, _0023_003DzaUF77KfxjxOo, num2, _0023_003DzXVItJ0IO9a8l: false, out _0023_003Dz7R4nzv0_003D3);
		}
		if (_0023_003Dz7R4nzv0_003D < Math.Min(_0023_003Dz7R4nzv0_003D2, _0023_003Dz7R4nzv0_003D3))
		{
			return result;
		}
		if (_0023_003Dz7R4nzv0_003D2 < _0023_003Dz7R4nzv0_003D3)
		{
			return result2;
		}
		return array;
	}

	private _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] _0023_003Dz_jsXuB4_003D(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] _0023_003DzrdSL0CI_003D, double _0023_003DzaUF77KfxjxOo, double _0023_003DzEEncnNQ_003D, bool _0023_003DzXVItJ0IO9a8l, out double _0023_003Dz7R4nzv0_003D)
	{
		_0023_003Dz7R4nzv0_003D = 0.0;
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[] array = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D[_0023_003DzrdSL0CI_003D.Length];
		array[0] = _0023_003DzrdSL0CI_003D[0];
		for (int i = 1; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			double num = _0023_003DzrdSL0CI_003D[i]._0023_003Dz1DxA_0024lQYh5fg + _0023_003DzEEncnNQ_003D * (double)i;
			_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DzF7v9r2A_003D = ((_0023_003DzEEncnNQ_003D < 0.0) ? _0023_003DzrdSL0CI_003D[i - 1] : _0023_003DzrdSL0CI_003D[i]);
			_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz8dK2uhU_003D = ((_0023_003DzEEncnNQ_003D < 0.0) ? _0023_003DzrdSL0CI_003D[i] : _0023_003DzrdSL0CI_003D[i + 1]);
			if (_0023_003DzEEncnNQ_003D != 0.0)
			{
				double num2 = _0023_003DzvWnyemjmd4sV(num, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzaUF77KfxjxOo);
				array[i] = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzlhS8HxeSpLWK.PointAt(num2), num, num2);
			}
			else
			{
				array[i] = _0023_003DzrdSL0CI_003D[i];
			}
			_0023_003Dz7R4nzv0_003D += _0023_003Dz6GD7zF0_003D(array[i], array[i - 1]);
		}
		array[^1] = _0023_003DzrdSL0CI_003D[^1];
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DzjbqS1qE_003D = array[^2];
		_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2 = array[^1];
		if (!_0023_003DzXVItJ0IO9a8l)
		{
			_0023_003Dz7R4nzv0_003D += _0023_003Dz6GD7zF0_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2);
		}
		else
		{
			array[^2] = _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2;
			Array.Resize(ref array, array.Length - 1);
		}
		_0023_003Dz7R4nzv0_003D /= array.Length - 1;
		return array;
	}
}
