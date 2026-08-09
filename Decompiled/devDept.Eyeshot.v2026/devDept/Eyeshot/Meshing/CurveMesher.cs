using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public class CurveMesher : Mesher
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Point3D, Point3D> _0023_003DzskdGw1QC0siGYdWvOg_003D_003D;

		internal Point3D _0023_003DzA3XXiFeWBEVmPrcctD2_0024ueA_003D(Point3D _0023_003DzB68dg9Q_003D)
		{
			return new Node(_0023_003DzB68dg9Q_003D.X, _0023_003DzB68dg9Q_003D.Y, _0023_003DzB68dg9Q_003D.Z);
		}
	}

	private enum _0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D
	{

	}

	private sealed class _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D
	{
		public List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

		internal int _0023_003DqrvI0QMmK1Yqr1oOWNMLqZZToTI9qAUp_0024Halo6Z_3HRc_003D(int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D)
		{
			if (!(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D]._0023_003DzmAHVzIc_003D < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzmAHVzIc_003D))
			{
				return (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D]._0023_003DzmAHVzIc_003D != _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzmAHVzIc_003D) ? 1 : 0;
			}
			return -1;
		}

		internal _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003DznErM1XbFQmryNox3C4Sua9yZOBpi(int _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D];
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public double[] _0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D;

		public int[] _0023_003DzI1zpEBqLLdeB;

		internal Tuple<double, double, int> _0023_003Dzhin_0024FdF4JHuM7AwqxHNWO5Q_003D(int _0023_003Dz437_00244ak_003D)
		{
			return new Tuple<double, double, int>(_0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D[_0023_003Dz437_00244ak_003D], _0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D[_0023_003Dz437_00244ak_003D + 1], _0023_003DzI1zpEBqLLdeB[_0023_003Dz437_00244ak_003D]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ICurve _0023_003DzlhS8HxeSpLWK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SizesOnCurve _0023_003DzS8tLEGM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D _0023_003DzLEqxEMHz0Sa7sJHkih9qPK9taAz2MhMssA_003D_003D = (_0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D)1;

	public CurveMesher(ICurve curve, double size, MaterialKeyedCollection materials = null)
		: this(curve, new SizesOnCurve(size), materials)
	{
	}

	public CurveMesher(ICurve curve, SizesOnCurve sizes, MaterialKeyedCollection materials = null)
	{
		_0023_003DzlhS8HxeSpLWK = curve ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989536));
		_0023_003DzS8tLEGM_003D = sizes ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989513));
		if (!string.IsNullOrEmpty(((Entity)curve).MaterialName) && materials != null)
		{
			_0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D = materials[((Entity)curve).MaterialName];
		}
	}

	public CurveMesher(ICurve curve, double startSize, double endSize)
		: this(curve, new SizesOnCurve(startSize, endSize))
	{
	}

	private _0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D _0023_003DzhIhaxG8_0024lKFlD6CLLMY1soE_003D()
	{
		return _0023_003DzLEqxEMHz0Sa7sJHkih9qPK9taAz2MhMssA_003D_003D;
	}

	private void _0023_003DzwcZ_hpG8lAtIcApPU4C5PZA_003D(_0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzLEqxEMHz0Sa7sJHkih9qPK9taAz2MhMssA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual double DesiredSizeAt(double t)
	{
		if (!(Math.Abs(_0023_003DzS8tLEGM_003D.StartSize - _0023_003DzS8tLEGM_003D.EndSize) < 1E-12))
		{
			return _0023_003DzS8tLEGM_003D.StartSize + (_0023_003DzS8tLEGM_003D.EndSize - _0023_003DzS8tLEGM_003D.StartSize) * (t - _0023_003DzlhS8HxeSpLWK.Domain.Low) / _0023_003DzlhS8HxeSpLWK.Domain.Length;
		}
		return _0023_003DzS8tLEGM_003D.StartSize;
	}

	private protected HistogramData _0023_003DzzVYnA2Z_0024NrUE(IReadOnlyList<Point3D> _0023_003DzrdSL0CI_003D)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D CS_0024_003C_003E8__locals8 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		int num = _0023_003DzrdSL0CI_003D.Count - 1;
		if (num < 1)
		{
			return null;
		}
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = 0.0;
		CS_0024_003C_003E8__locals8._0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D = new double[12]
		{
			0.0, 0.01, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8,
			0.9, 1.0
		};
		Point3D point3D = _0023_003DzrdSL0CI_003D[0];
		_0023_003DzlhS8HxeSpLWK.ClosestPointTo(point3D, out var t);
		double num5 = DesiredSizeAt(t);
		CS_0024_003C_003E8__locals8._0023_003DzI1zpEBqLLdeB = new int[CS_0024_003C_003E8__locals8._0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D.Length - 1];
		int num6 = 0;
		while (num6 < num)
		{
			Point3D point3D2 = _0023_003DzrdSL0CI_003D[num6 + 1];
			_0023_003DzlhS8HxeSpLWK.ClosestPointTo(point3D, out var t2);
			double num7 = DesiredSizeAt(t2);
			if (num5 == 0.0 || num7 == 0.0)
			{
				num--;
			}
			else
			{
				double num8 = ((Math.Log(num5 / num7) < 1E-12) ? (point3D.DistanceTo(point3D2) / _0023_003DzS8tLEGM_003D.StartSize) : (point3D.DistanceTo(point3D2) * (num5 - num7) / Math.Log(num5 / num7)));
				if (num8 > num2)
				{
					num2 = num8;
				}
				if (num8 < num3)
				{
					num3 = num8;
				}
				num4 += num8;
				CS_0024_003C_003E8__locals8._0023_003DzI1zpEBqLLdeB[Mesher._0023_003Dzj2l6d_EETa_00248(num8)]++;
			}
			num6++;
			point3D = point3D2;
			num5 = num7;
		}
		if (num == 0)
		{
			return new HistogramData(0, 0, 0, 0.0, 0.0, 0.0, null);
		}
		return new HistogramData(num, 0, 0, num2, num3, num4 / (double)num, (from _0023_003Dz437_00244ak_003D in Enumerable.Range(0, CS_0024_003C_003E8__locals8._0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D.Length - 1)
			select new Tuple<double, double, int>(CS_0024_003C_003E8__locals8._0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals8._0023_003DzaPqGM2JK3cbE_F1WsA_003D_003D[_0023_003Dz437_00244ak_003D + 1], CS_0024_003C_003E8__locals8._0023_003DzI1zpEBqLLdeB[_0023_003Dz437_00244ak_003D])).ToArray());
	}

	private FemMesh _0023_003DzypgzGTCoWRC4(IReadOnlyList<Point3D> _0023_003DzrdSL0CI_003D)
	{
		Point3D[] array = ((IEnumerable<Point3D>)_0023_003DzrdSL0CI_003D).Select((Func<Point3D, Point3D>)((Point3D _0023_003DzB68dg9Q_003D) => new Node(_0023_003DzB68dg9Q_003D.X, _0023_003DzB68dg9Q_003D.Y, _0023_003DzB68dg9Q_003D.Z))).ToArray();
		int num = array.Length - 1;
		Element[] array2 = new Element[num];
		for (int num2 = 0; num2 < num; num2++)
		{
			array2[num2] = new Truss(num2, num2 + 1, _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D, 1.0);
		}
		return new FemMesh(array, array2)
		{
			EdgeShapeQualities = _0023_003DzzVYnA2Z_0024NrUE(_0023_003DzrdSL0CI_003D)
		};
	}

	private static PointTangent _0023_003Dz4YNHTcs_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz8fpRyMu9aKjE.Domain.Low);
	}

	private static PointTangent _0023_003DzSEK8RZc_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz8fpRyMu9aKjE.Domain.High);
	}

	internal static PointTangent _0023_003DzMEXpAaVkFlpl(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzNDQ_E88_003D)
	{
		Point3D point;
		Vector3D tangent;
		if (_0023_003Dz8fpRyMu9aKjE is Curve curve)
		{
			curve.EvaluateTangent(_0023_003DzNDQ_E88_003D, out point, out tangent);
		}
		else
		{
			point = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003DzNDQ_E88_003D);
			tangent = _0023_003Dz8fpRyMu9aKjE.TangentAt(_0023_003DzNDQ_E88_003D);
		}
		return new PointTangent(point.X, point.Y, point.Z, tangent.X, tangent.Y, tangent.Z);
	}

	private static void _0023_003Dz6o1GAiD340lZW72ZE59qEpQ_003D(ICurve _0023_003Dz8fpRyMu9aKjE, int _0023_003DzKV5V6WI_003D, int _0023_003Dz8SEdsjQ_003D, IList<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzvxHPuJA_003D)
	{
		if (_0023_003DzvxHPuJA_003D >= 1)
		{
			_0023_003DzvxHPuJA_003D--;
			_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzKV5V6WI_003D];
			_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz8SEdsjQ_003D];
			_0023_003Dz8fpRyMu9aKjE.GetLengthFromParam(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003DzmAHVzIc_003D, out var length);
			_0023_003Dz8fpRyMu9aKjE.GetLengthFromParam(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3._0023_003DzmAHVzIc_003D, out var length2);
			if (!(length2 - length <= Math.Max(_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003Dz1DxA_0024lQYh5fg, _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3._0023_003Dz1DxA_0024lQYh5fg) * 1.5))
			{
				double num = (_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003DzmAHVzIc_003D + _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3._0023_003DzmAHVzIc_003D) / 2.0;
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, num), _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003Dz1DxA_0024lQYh5fg + (_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D3._0023_003Dz1DxA_0024lQYh5fg - _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003Dz1DxA_0024lQYh5fg) * (num - _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D2._0023_003DzmAHVzIc_003D) / _0023_003Dz8fpRyMu9aKjE.Domain.Length, num));
				int num2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count - 1;
				_0023_003Dz6o1GAiD340lZW72ZE59qEpQ_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzKV5V6WI_003D, num2, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzvxHPuJA_003D);
				_0023_003Dz6o1GAiD340lZW72ZE59qEpQ_003D(_0023_003Dz8fpRyMu9aKjE, num2, _0023_003Dz8SEdsjQ_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzvxHPuJA_003D);
			}
		}
	}

	private List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> _0023_003DziWMlvGk12eeFO0lcuQ_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzKV5V6WI_003D, double _0023_003Dz8SEdsjQ_003D)
	{
		_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D CS_0024_003C_003E8__locals15 = new _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D();
		double num = _0023_003Dz8fpRyMu9aKjE.Length();
		CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D>
		{
			new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003Dz4YNHTcs_003D(_0023_003Dz8fpRyMu9aKjE), _0023_003DzKV5V6WI_003D, _0023_003Dz8fpRyMu9aKjE.Domain.Low),
			new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzSEK8RZc_003D(_0023_003Dz8fpRyMu9aKjE), _0023_003Dz8SEdsjQ_003D, _0023_003Dz8fpRyMu9aKjE.Domain.High)
		};
		_0023_003Dz6o1GAiD340lZW72ZE59qEpQ_003D(_0023_003Dz8fpRyMu9aKjE, 0, 1, CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D, 10);
		int count = CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		int num2 = count - 1;
		int[] array = Enumerable.Range(0, count).ToArray();
		Array.Sort(array, (int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D) => (!(CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D]._0023_003DzmAHVzIc_003D < CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzmAHVzIc_003D)) ? ((CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D]._0023_003DzmAHVzIc_003D != CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]._0023_003DzmAHVzIc_003D) ? 1 : 0) : (-1));
		double num3 = (_0023_003Dz8SEdsjQ_003D - _0023_003DzKV5V6WI_003D) / _0023_003Dz8fpRyMu9aKjE.Domain.Length;
		double num4 = _0023_003DzKV5V6WI_003D - num3 * _0023_003Dz8fpRyMu9aKjE.Domain.Low;
		if (count > 2)
		{
			for (int num5 = 0; num5 < Math.Min(base.SmoothingPasses, 2); num5++)
			{
				for (int num6 = 1; num6 < num2; num6++)
				{
					int index = array[num6 - 1];
					int index2 = array[num6];
					int index3 = array[num6 + 1];
					double num7 = (CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index]._0023_003DzmAHVzIc_003D + CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index3]._0023_003DzmAHVzIc_003D) / 2.0;
					CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index2] = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, num7), num3 * num7 + num4, num7);
				}
			}
		}
		int count2 = CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		if (count2 >= 3)
		{
			double t;
			if (count2 == 3)
			{
				_0023_003Dz8fpRyMu9aKjE.GetParamFromLength(_0023_003DzKV5V6WI_003D / (_0023_003DzKV5V6WI_003D + _0023_003Dz8SEdsjQ_003D) * num, out t);
			}
			else
			{
				_0023_003Dz8fpRyMu9aKjE.GetLengthFromParam(CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[count2 - 4]]._0023_003DzmAHVzIc_003D, out var length);
				_0023_003Dz8fpRyMu9aKjE.GetLengthFromParam(CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[count2 - 3]]._0023_003DzmAHVzIc_003D, out var length2);
				_0023_003Dz8fpRyMu9aKjE.GetParamFromLength((num - length) / 3.0 + length2, out t);
			}
			CS_0024_003C_003E8__locals15._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[count2 - 2]] = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, t), num3 * t + num4, t);
		}
		return array.Select(CS_0024_003C_003E8__locals15._0023_003DznErM1XbFQmryNox3C4Sua9yZOBpi).ToList();
	}

	private static Point3D[] _0023_003DzqUIIldnVKN12YKNkFA_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzKV5V6WI_003D, double _0023_003Dz8SEdsjQ_003D, Func<ICurve, double, double, List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D>> _0023_003DzxMOEQ9hJ_0024qKAbCpg_0024A_003D_003D)
	{
		List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D> list = new List<_0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D>
		{
			new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003Dz4YNHTcs_003D(_0023_003Dz8fpRyMu9aKjE), _0023_003DzKV5V6WI_003D)
		};
		if (_0023_003Dz8fpRyMu9aKjE.GetParamFromLength(_0023_003DzKV5V6WI_003D, _0023_003Dz8fpRyMu9aKjE.Length(), out var t) && _0023_003Dz8fpRyMu9aKjE.GetParamFromLength(_0023_003Dz8fpRyMu9aKjE.Length() - _0023_003Dz8SEdsjQ_003D, _0023_003Dz8fpRyMu9aKjE.Length(), out var t2) && t - _0023_003Dz8fpRyMu9aKjE.Domain.Min <= (t2 - _0023_003Dz8fpRyMu9aKjE.Domain.Min) * 1.5)
		{
			if ((t - _0023_003Dz8fpRyMu9aKjE.Domain.Min) * 1.5 <= t2 - _0023_003Dz8fpRyMu9aKjE.Domain.Min)
			{
				_0023_003Dz8fpRyMu9aKjE.SubCurve(t, t2, out var sub);
				double num = 2.0 * (_0023_003Dz8SEdsjQ_003D - _0023_003DzKV5V6WI_003D) / (_0023_003Dz8fpRyMu9aKjE.Domain.Length + t2 - t);
				double num2 = _0023_003DzKV5V6WI_003D - num * (_0023_003Dz8fpRyMu9aKjE.Domain.Low + t) / 2.0;
				list.AddRange(_0023_003DzxMOEQ9hJ_0024qKAbCpg_0024A_003D_003D(sub, num * t + num2, num * t2 + num2));
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(list[i], list[i]._0023_003Dz1DxA_0024lQYh5fg, list[i]._0023_003DzmAHVzIc_003D + t);
				}
			}
			else
			{
				list.Add(new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzMEXpAaVkFlpl(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz8fpRyMu9aKjE.Domain.ParameterAt(_0023_003DzKV5V6WI_003D / (_0023_003DzKV5V6WI_003D + _0023_003Dz8SEdsjQ_003D)))));
			}
		}
		list.Add(new _0023_003Dz1G8rgc_voCf6nOirhGMJMiBnELz4POL5NtxWiq4_003D(_0023_003DzSEK8RZc_003D(_0023_003Dz8fpRyMu9aKjE), _0023_003Dz8SEdsjQ_003D));
		return new List<Point3D>(list).ToArray();
	}

	private Point3D[] _0023_003Dzl786BJ03Hi_esDyw1OZgjoE_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		return _0023_003DzqUIIldnVKN12YKNkFA_003D_003D(_0023_003DzlhS8HxeSpLWK, _0023_003DzS8tLEGM_003D.StartSize, _0023_003DzS8tLEGM_003D.EndSize, _0023_003DziWMlvGk12eeFO0lcuQ_003D_003D);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		if (_0023_003DzlhS8HxeSpLWK == null)
		{
			base.Result = null;
			return;
		}
		Point3D[] array2 = _0023_003DzfHSvFLY_003D(progress, ct);
		if (array2.Length > 1)
		{
			base.Result = _0023_003DzypgzGTCoWRC4(array2);
		}
	}

	internal Point3D[] _0023_003DzfHSvFLY_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003DzS8tLEGM_003D.StartSize == 0.0 || _0023_003DzS8tLEGM_003D.EndSize == 0.0)
		{
			return new Point3D[2] { _0023_003DzlhS8HxeSpLWK.StartPoint, _0023_003DzlhS8HxeSpLWK.EndPoint };
		}
		switch (_0023_003DzhIhaxG8_0024lKFlD6CLLMY1soE_003D())
		{
		case (_0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D)0:
			return _0023_003Dzl786BJ03Hi_esDyw1OZgjoE_003D(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		case (_0023_003DzGuAF9tKGBr3A63R_z4qgm_c_003D)1:
		{
			_0023_003DzUFi2Ad_0024Ytg090IOXdOGk2GfzslgJG2rZ6gDhwWs041Oxa_0024IdFQ_003D_003D obj = new _0023_003DzUFi2Ad_0024Ytg090IOXdOGk2GfzslgJG2rZ6gDhwWs041Oxa_0024IdFQ_003D_003D(_0023_003DzlhS8HxeSpLWK, _0023_003DzS8tLEGM_003D);
			obj.MeshingText = base.MeshingText;
			obj.SmoothingText = base.SmoothingText;
			obj.SmoothingPasses = base.SmoothingPasses;
			obj.DoWork(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			return obj._0023_003DzwbbgHmo_003D;
		}
		default:
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989494));
		}
	}

	public static double EstimateSizeByNumber(int numberOfSegs, ICurve curve)
	{
		return curve.Length() / (double)numberOfSegs;
	}
}
