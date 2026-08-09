using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Curve : NurbsBase, ICurve, ICloneable, IMateable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Point3D, double> _0023_003Dz0OjxD9ZCm1LIzA_vYQ_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, Point3D> _0023_003Dzm5k9_2WgmyZGw7SyBQ_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, double> _0023_003Dzzc0NRe4y8lVb_DUYYg_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, Point3D> _0023_003DzZc3He_2ffDY0KjBpuA_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, double> _0023_003DzTwZZo1blWEqcKj0fOg_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, Point3D> _0023_003DzMOqZPetLuvBz2y_DfA_003D_003D;

		public static Func<Tuple<double, Point3D, Point3D>, double> _0023_003Dz51_0024QGmYUk7wsTS3FNg_003D_003D;

		internal double _0023_003DzJ_o6lAGHlRviLKG5nA_003D_003D(Point3D _0023_003Dz437_00244ak_003D)
		{
			return ((PointTangentU)_0023_003Dz437_00244ak_003D).U;
		}

		internal Point3D _0023_003Dz5yD2LPfayd5JKX2jY702QVg_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item2;
		}

		internal double _0023_003DzJ9lQT06PrYg21cWcZHYut54_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item1;
		}

		internal Point3D _0023_003DzXaHuqFD0Y55Kg8KHxE3SINc_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item3;
		}

		internal double _0023_003Dz7gFdTii0jcA1lgVA1GXYFKE_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item1;
		}

		internal Point3D _0023_003DzN9nCroz5nXE4zJLHCkC0CGM_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item3;
		}

		internal double _0023_003DzE82iZN2Ta7qzgU3fWTfkzFc_003D(Tuple<double, Point3D, Point3D> _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.Item1;
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static _0023_003DzjcmYKSSxrpyH _0023_003Dz_0024Lf7xgbDNlfX;
	}

	internal enum _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D
	{

	}

	internal delegate bool _0023_003DzXAaHt5piG_cE(ICurve _0023_003DzzmfUkNI_003D, double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, Region[] _0023_003DzblFyLI_0024bgqPg);

	private enum _0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D
	{

	}

	private delegate double _0023_003DzjcmYKSSxrpyH(double _0023_003DzjbqS1qE_003D, _0023_003Dzyq1EkI8_003D _0023_003DzcNU_0024mJM_003D);

	private sealed class _0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D
	{
		public ICurve[][] _0023_003DzgYclArUg9YyW;

		public Curve[] _0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D;

		public double _0023_003DzVvcDDAwNH6GS;

		public double _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D;

		public double _0023_003DzxbA7__gYkoBv;

		internal void _0023_003Dza199PsS2IEysIR8dxrG_0024cynZXYOA(int _0023_003Dz437_00244ak_003D)
		{
			_0023_003DzgYclArUg9YyW[_0023_003Dz437_00244ak_003D] = _0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D[_0023_003Dz437_00244ak_003D]._0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(_0023_003DzVvcDDAwNH6GS, _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, _0023_003DzxbA7__gYkoBv);
		}
	}

	private struct _0023_003Dzyq1EkI8_003D(Curve _0023_003DzzmfUkNI_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzgqZzIes_003D = 0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Curve _0023_003Dz8fpRyMu9aKjE = _0023_003DzzmfUkNI_003D;
	}

	public enum fitPointMethod
	{
		chordLength,
		squareRoot,
		uniform
	}

	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

	internal Point4D[] Pw;

	internal InitialPoint startIp;

	internal InitialPoint endIp;

	internal Brep.Face.tangentType onTangentType;

	internal int[] onTangentFaces;

	[NonSerialized]
	protected Point seam;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzbErHvVw_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = true;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Curve[] _0023_003DziGmJqeQcL0Lt;

	private Curve[] _discontinuities;

	private EntityGraphicsData drawCurvature;

	private bool _showCurvature;

	private float _hairScaleFactor;

	public int EdgeIndex
	{
		get
		{
			return _edgeIndex;
		}
		set
		{
			_edgeIndex = value;
		}
	}

	public bool FromBooleanIntersection
	{
		get
		{
			return _fromBooleanIntersection;
		}
		set
		{
			_fromBooleanIntersection = value;
		}
	}

	public Point3D StartPoint => Evaluate(Domain.Low);

	public Point3D EndPoint => Evaluate(Domain.High);

	public Interval Domain => new Interval(_0023_003DziP9fFuA_003D.Left(), _0023_003DziP9fFuA_003D.Right());

	public int Order => _0023_003DzB68dg9Q_003D + 1;

	public int Degree
	{
		get
		{
			return _0023_003DzB68dg9Q_003D;
		}
		set
		{
			_0023_003DzB68dg9Q_003D = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsClosed
	{
		get
		{
			if (geometricalAttributesDirty)
			{
				return Pw.First() == Pw.Last();
			}
			return _0023_003DzbErHvVw_003D;
		}
	}

	public bool IsRational => _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D;

	public Point4D[] ControlPoints
	{
		get
		{
			return Pw;
		}
		set
		{
			Pw = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double[] KnotVector
	{
		get
		{
			return _0023_003DziP9fFuA_003D;
		}
		set
		{
			_0023_003DziP9fFuA_003D = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsLine
	{
		get
		{
			if (Pw.Length == 2 && Degree == 1 && Pw[0].Euclid != Pw[1].Euclid)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsPoint
	{
		get
		{
			Point3D euclid = Pw[0].Euclid;
			for (int i = 1; i < Pw.Length; i++)
			{
				if (Pw[i].Euclid != euclid)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override regenType RegenMode
	{
		get
		{
			return base.RegenMode;
		}
		set
		{
			if (value == regenType.RegenAndCompile)
			{
				_0023_003Dz7roAELUN1jwt();
				_hairScaleFactor = 0f;
			}
			base.RegenMode = value;
		}
	}

	public Vector3D StartTangent
	{
		get
		{
			EvaluateTangent(Domain.Low, out var _, out var tangent);
			return tangent;
		}
	}

	public Vector3D EndTangent
	{
		get
		{
			EvaluateTangent(Domain.High, out var _, out var tangent);
			return tangent;
		}
	}

	public bool ShowCurvature
	{
		get
		{
			return _showCurvature;
		}
		set
		{
			_showCurvature = value;
		}
	}

	internal Curve()
		: base(entityNatureType.Wire)
	{
	}

	public Curve(int degree, double[] knotVector, Point4D[] ctrlPoints, bool checkKnotsAndCtrlPts = true)
		: this()
	{
		_0023_003DztGdcVOA_003D(degree, knotVector, ctrlPoints, checkKnotsAndCtrlPts);
	}

	internal Curve(int _0023_003DzU7eDCS_XZhhv, double _0023_003DzgqZzIes_003D, Vector3D[] _0023_003Dz1v6oPQk_003D)
		: this()
	{
		_0023_003DzB68dg9Q_003D = _0023_003DzU7eDCS_XZhhv;
		double[,] array = new double[_0023_003DzB68dg9Q_003D + 1, _0023_003DzB68dg9Q_003D + 1];
		for (int i = 0; i < _0023_003DzB68dg9Q_003D + 1; i++)
		{
			array[i, i] = Math.Pow(_0023_003DzgqZzIes_003D, i);
		}
		double[,] m = BezierToPowerMatrix(_0023_003DzB68dg9Q_003D);
		double[,] array2 = Matrix.Multiply(Matrix.Multiply(NurbsBase.PowerToBezierMatrix(_0023_003DzU7eDCS_XZhhv, m), array), new double[4, 3]
		{
			{
				_0023_003Dz1v6oPQk_003D[0].X,
				_0023_003Dz1v6oPQk_003D[0].Y,
				_0023_003Dz1v6oPQk_003D[0].Z
			},
			{
				_0023_003Dz1v6oPQk_003D[1].X,
				_0023_003Dz1v6oPQk_003D[1].Y,
				_0023_003Dz1v6oPQk_003D[1].Z
			},
			{
				_0023_003Dz1v6oPQk_003D[2].X,
				_0023_003Dz1v6oPQk_003D[2].Y,
				_0023_003Dz1v6oPQk_003D[2].Z
			},
			{
				_0023_003Dz1v6oPQk_003D[3].X,
				_0023_003Dz1v6oPQk_003D[3].Y,
				_0023_003Dz1v6oPQk_003D[3].Z
			}
		});
		Point4D point4D = new Point4D(array2[0, 0], array2[0, 1], array2[0, 2]);
		Point4D point4D2 = new Point4D(array2[1, 0], array2[1, 1], array2[1, 2]);
		Point4D point4D3 = new Point4D(array2[2, 0], array2[2, 1], array2[2, 2]);
		Point4D point4D4 = new Point4D(array2[3, 0], array2[3, 1], array2[3, 2]);
		Pw = new Point4D[4] { point4D, point4D2, point4D3, point4D4 };
		_0023_003DziP9fFuA_003D = new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
	}

	public Curve(int degree, params Point3D[] ctrlPoints)
		: this(degree, (IList<Point3D>)ctrlPoints)
	{
	}

	public Curve(int degree, IList<Point3D> ctrlPoints)
		: this()
	{
		_0023_003DzB68dg9Q_003D = ((ctrlPoints.Count > degree) ? degree : (ctrlPoints.Count - 1));
		_0023_003DziP9fFuA_003D = NurbsBase.UniformKnotVector(_0023_003DzB68dg9Q_003D, ctrlPoints.Count);
		Pw = new Point4D[ctrlPoints.Count];
		for (int i = 0; i < ctrlPoints.Count; i++)
		{
			Pw[i] = new Point4D(ctrlPoints[i]);
		}
		if (!IsValid())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963736));
		}
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
	}

	public Curve(Point3D P0, Vector3D T0, Point3D P1, Vector3D T1, Point3D P)
		: this()
	{
		_0023_003Dzyo7753mSx4U3jJ8VCw_003D_003D(P0, T0, P1, T1, P);
		if (Pw != null)
		{
			_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		}
	}

	protected Curve(Curve another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		Resize(another._0023_003DzMv2C5Tm1QMvc(), another._0023_003DzB68dg9Q_003D);
		_0023_003DzD_00245nWTrQrjSP(another.Pw, ref Pw);
		another._0023_003DziP9fFuA_003D.CopyTo(_0023_003DziP9fFuA_003D, 0);
		_0023_003DzB68dg9Q_003D = another._0023_003DzB68dg9Q_003D;
		_0023_003DzbErHvVw_003D = another._0023_003DzbErHvVw_003D;
		if (seam != null)
		{
			seam = (Point)another.seam.Clone();
		}
		_0023_003Dz1c2CfcL6J3Hu = another._0023_003Dz1c2CfcL6J3Hu;
		_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = another._0023_003DzjuYKWBBXI34x4GCzLw_003D_003D;
		geometricalAttributesDirty = false;
		EdgeIndex = another.EdgeIndex;
		startIp = another.startIp;
		endIp = another.endIp;
		onTangentType = another.onTangentType;
		onTangentFaces = another.onTangentFaces;
	}

	protected internal Curve(CurveSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetPw())
	{
	}

	internal Curve(GCurve _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.P, _0023_003DzQwa1qM0_003D.U, _0023_003DzQwa1qM0_003D.Pw)
	{
	}

	public Curve(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_0023_003DziP9fFuA_003D = (double[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963923), typeof(double[]));
		_0023_003DzB68dg9Q_003D = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963909));
		Pw = (Point4D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963892), typeof(Point4D[]));
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
	}

	internal static _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzRGcO5v1wS2S_(Curve _0023_003Dzfm4oGj8_003D, Curve _0023_003DzCVdPoWM_003D, out Point3D _0023_003DzDVubtvo_003D, out Point3D _0023_003DzFj_0024IqDQ_003D, out bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, double _0023_003DzN6G05Lg_003D)
	{
		_0023_003DzDVubtvo_003D = (_0023_003DzFj_0024IqDQ_003D = null);
		_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = false;
		double num = _0023_003Dzfm4oGj8_003D.Length();
		double num2 = _0023_003DzCVdPoWM_003D.Length();
		double num3 = Math.Min(num, num2);
		double num4 = num3 * 0.001 * _0023_003DzN6G05Lg_003D;
		double num5 = num3 * 0.001 * _0023_003DzN6G05Lg_003D;
		double _0023_003DzvV2ycYTc87Jx = num3 * 1E-05 * _0023_003DzN6G05Lg_003D;
		_0023_003Dzfm4oGj8_003D.ControlBoundingBox(num4, out var min, out var max);
		_0023_003DzCVdPoWM_003D.ControlBoundingBox(num4, out var min2, out var max2);
		if (!Utility.DoOverlapOrTouch(min, max, min2, max2))
		{
			return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
		}
		if (_0023_003DzN6G05Lg_003D >= 1.0)
		{
			_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D2 = _0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D);
			if (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D2 != 0)
			{
				_0023_003DzDVubtvo_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
				_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = true;
				return _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D2;
			}
		}
		bool flag = _0023_003DzH3_0024EYLXU4E0K(_0023_003Dzfm4oGj8_003D.StartPoint, _0023_003DzCVdPoWM_003D, num4, _0023_003DzvV2ycYTc87Jx);
		bool flag2 = _0023_003DzAkOxQFJKUMD9(_0023_003Dzfm4oGj8_003D.EndPoint, _0023_003DzCVdPoWM_003D, num4, _0023_003DzvV2ycYTc87Jx);
		bool flag3 = _0023_003DzAkOxQFJKUMD9(_0023_003DzCVdPoWM_003D.StartPoint, _0023_003Dzfm4oGj8_003D, num4, _0023_003DzvV2ycYTc87Jx);
		bool flag4 = _0023_003DzH3_0024EYLXU4E0K(_0023_003DzCVdPoWM_003D.EndPoint, _0023_003Dzfm4oGj8_003D, num4, _0023_003DzvV2ycYTc87Jx);
		if (Math.Abs(num2 - num) < num5 && Convert.ToByte(flag) + Convert.ToByte(flag2) + Convert.ToByte(flag3) + Convert.ToByte(flag4) > 1)
		{
			_0023_003DzDVubtvo_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
			_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
			_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = true;
			if (_0023_003Dzfm4oGj8_003D.IsClosed)
			{
				if (!Vector3D.AreCoincident(_0023_003Dzfm4oGj8_003D.StartTangent, _0023_003DzCVdPoWM_003D.StartTangent, 0.001))
				{
					return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4;
				}
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3;
			}
			if (flag && Vector3D.AreCoincident(_0023_003Dzfm4oGj8_003D.StartTangent, _0023_003DzCVdPoWM_003D.StartTangent, 0.001) && Vector3D.AreCoincident(_0023_003Dzfm4oGj8_003D.EndTangent, _0023_003DzCVdPoWM_003D.EndTangent, 0.001))
			{
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3;
			}
			if (flag3 && Vector3D.AreOpposite(_0023_003DzCVdPoWM_003D.StartTangent, _0023_003Dzfm4oGj8_003D.EndTangent, 0.001) && Vector3D.AreOpposite(_0023_003DzCVdPoWM_003D.EndTangent, _0023_003Dzfm4oGj8_003D.StartTangent, 0.001))
			{
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4;
			}
			_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = false;
			return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
		}
		int _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D = 0;
		bool? _0023_003Dz0bUvwzsjKPYK = null;
		bool flag5 = _0023_003Dz2i6z_pOo_0024Pgg(_0023_003Dzfm4oGj8_003D.StartPoint, _0023_003Dzfm4oGj8_003D.StartTangent, _0023_003DzCVdPoWM_003D, num4, 0.001, _0023_003DzvV2ycYTc87Jx, ref _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D, ref _0023_003Dz0bUvwzsjKPYK);
		bool flag6 = _0023_003Dz2i6z_pOo_0024Pgg(_0023_003Dzfm4oGj8_003D.EndPoint, _0023_003Dzfm4oGj8_003D.EndTangent, _0023_003DzCVdPoWM_003D, num4, 0.001, _0023_003DzvV2ycYTc87Jx, ref _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D, ref _0023_003Dz0bUvwzsjKPYK);
		bool flag7 = _0023_003Dz2i6z_pOo_0024Pgg(_0023_003DzCVdPoWM_003D.StartPoint, _0023_003DzCVdPoWM_003D.StartTangent, _0023_003Dzfm4oGj8_003D, num4, 0.001, _0023_003DzvV2ycYTc87Jx, ref _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D, ref _0023_003Dz0bUvwzsjKPYK);
		bool flag8 = _0023_003Dz2i6z_pOo_0024Pgg(_0023_003DzCVdPoWM_003D.EndPoint, _0023_003DzCVdPoWM_003D.EndTangent, _0023_003Dzfm4oGj8_003D, num4, 0.001, _0023_003DzvV2ycYTc87Jx, ref _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D, ref _0023_003Dz0bUvwzsjKPYK);
		bool flag9 = flag || flag4 || flag3 || flag2;
		_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = (flag9 && (flag5 || flag6 || flag7 || flag8)) || (flag5 && flag6 && !_0023_003Dzfm4oGj8_003D.IsClosed) || (flag7 && flag8 && !_0023_003DzCVdPoWM_003D.IsClosed);
		if (_0023_003Dz0bUvwzsjKPYK.HasValue)
		{
			if (flag9 && _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D == 1)
			{
				if (flag || flag4)
				{
					_0023_003DzDVubtvo_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
				}
				else if (flag3 || flag2)
				{
					_0023_003DzDVubtvo_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				}
				if (flag5)
				{
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
				}
				else if (flag6)
				{
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				}
				else if (flag7)
				{
					_0023_003DzFj_0024IqDQ_003D = _0023_003DzCVdPoWM_003D.StartPoint;
				}
				else
				{
					_0023_003DzFj_0024IqDQ_003D = _0023_003DzCVdPoWM_003D.EndPoint;
				}
				if (!_0023_003Dz0bUvwzsjKPYK.Value)
				{
					return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)2;
				}
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)1;
			}
			if (_0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D == 2)
			{
				if (flag7 && flag6)
				{
					_0023_003DzDVubtvo_003D = _0023_003DzCVdPoWM_003D.StartPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				}
				else if (flag7 && flag5)
				{
					_0023_003DzDVubtvo_003D = _0023_003DzCVdPoWM_003D.StartPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
				}
				else if (flag8 && flag5)
				{
					_0023_003DzDVubtvo_003D = _0023_003DzCVdPoWM_003D.EndPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
				}
				else if (flag8 && flag6)
				{
					_0023_003DzDVubtvo_003D = _0023_003DzCVdPoWM_003D.EndPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				}
				else if (flag5 && flag6)
				{
					_0023_003DzDVubtvo_003D = _0023_003Dzfm4oGj8_003D.StartPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003Dzfm4oGj8_003D.EndPoint;
				}
				else if (flag7 && flag8)
				{
					_0023_003DzDVubtvo_003D = _0023_003DzCVdPoWM_003D.StartPoint;
					_0023_003DzFj_0024IqDQ_003D = _0023_003DzCVdPoWM_003D.EndPoint;
				}
				if (!_0023_003Dz0bUvwzsjKPYK.Value)
				{
					return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)2;
				}
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)1;
			}
		}
		return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
	}

	private static bool _0023_003DzH3_0024EYLXU4E0K(Point3D _0023_003Dzl3DhHgI_003D, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D, double _0023_003DzvV2ycYTc87Jx)
	{
		Segment3D segment3D = new Segment3D(_0023_003Dz8fpRyMu9aKjE.Pw[0].Euclid, _0023_003Dz8fpRyMu9aKjE.Pw[1].Euclid);
		double num = segment3D.Project(_0023_003Dzl3DhHgI_003D);
		double num2 = Math.Abs(num) * segment3D.Length;
		double num3 = segment3D.PointAt(num).DistanceTo(_0023_003Dzl3DhHgI_003D);
		if (num2 < _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D && num3 < _0023_003DzvV2ycYTc87Jx)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzAkOxQFJKUMD9(Point3D _0023_003Dzl3DhHgI_003D, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D, double _0023_003DzvV2ycYTc87Jx)
	{
		int num = _0023_003Dz8fpRyMu9aKjE._0023_003DzMv2C5Tm1QMvc();
		Segment3D segment3D = new Segment3D(_0023_003Dz8fpRyMu9aKjE.Pw[num - 2].Euclid, _0023_003Dz8fpRyMu9aKjE.Pw[num - 1].Euclid);
		double num2 = segment3D.Project(_0023_003Dzl3DhHgI_003D);
		double num3 = Math.Abs(1.0 - num2) * segment3D.Length;
		double num4 = segment3D.PointAt(num2).DistanceTo(_0023_003Dzl3DhHgI_003D);
		if (num3 < _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D && num4 < _0023_003DzvV2ycYTc87Jx)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003Dz2i6z_pOo_0024Pgg(Point3D _0023_003Dzl3DhHgI_003D, Vector3D _0023_003DzlllF2to_003D, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D, double _0023_003Dzt8XmI7iY1z2c, double _0023_003DzvV2ycYTc87Jx, ref int _0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D, ref bool? _0023_003Dz0bUvwzsjKPYK)
	{
		if (_0023_003Dz8fpRyMu9aKjE.Project(_0023_003Dzl3DhHgI_003D, 1E-09 * _0023_003Dz8fpRyMu9aKjE.Length(), allowOutside: true, out var u) && !_0023_003DzH3_0024EYLXU4E0K(_0023_003Dzl3DhHgI_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D, _0023_003DzvV2ycYTc87Jx) && !_0023_003DzAkOxQFJKUMD9(_0023_003Dzl3DhHgI_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz7fKMTFwgA_8fwamjIg_003D_003D, _0023_003DzvV2ycYTc87Jx))
		{
			Vector3D[] array = _0023_003Dz8fpRyMu9aKjE.Evaluate(u, 1);
			Vector3D vector3D = array[0];
			Vector3D vector3D2 = array[1];
			vector3D2.Normalize();
			if (vector3D.AsPoint.DistanceTo(_0023_003Dzl3DhHgI_003D) < _0023_003DzvV2ycYTc87Jx && _0023_003Dz8fpRyMu9aKjE.Domain.Includes(u, testOpenInterval: true) && Vector3D.AreParallel(vector3D2, _0023_003DzlllF2to_003D, _0023_003Dzt8XmI7iY1z2c))
			{
				_0023_003DzO4SkehjrtaT9vdcM1SBa5zq6u6xXnzbsjA_003D_003D++;
				_0023_003Dz0bUvwzsjKPYK = Vector3D.AreCoincident(vector3D2, _0023_003DzlllF2to_003D, _0023_003Dzt8XmI7iY1z2c);
				return true;
			}
		}
		return false;
	}

	internal static _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzMAxShrbxTEQp(Curve _0023_003Dzfm4oGj8_003D, Curve _0023_003DzCVdPoWM_003D)
	{
		if (_0023_003Dzfm4oGj8_003D.Degree != _0023_003DzCVdPoWM_003D.Degree || _0023_003Dzfm4oGj8_003D.KnotVector.Length != _0023_003DzCVdPoWM_003D.KnotVector.Length || _0023_003Dzfm4oGj8_003D.ControlPoints.Length != _0023_003DzCVdPoWM_003D.ControlPoints.Length)
		{
			return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
		}
		int num = _0023_003Dzfm4oGj8_003D.ControlPoints.Length;
		for (int i = 0; i < num; i++)
		{
			if (!_0023_003Dzwz6CZyI_003D(_0023_003Dzfm4oGj8_003D.ControlPoints[i], _0023_003DzCVdPoWM_003D.ControlPoints[i]) && !_0023_003Dzwz6CZyI_003D(_0023_003Dzfm4oGj8_003D.ControlPoints[i], _0023_003DzCVdPoWM_003D.ControlPoints[num - i - 1]))
			{
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
			}
		}
		double num2 = ((_0023_003Dzfm4oGj8_003D.Domain.Length < _0023_003DzCVdPoWM_003D.Domain.Length) ? (_0023_003Dzfm4oGj8_003D.Domain.Length * Utility._0023_003DzxhnLabVjXjPg) : (_0023_003DzCVdPoWM_003D.Domain.Length * Utility._0023_003DzxhnLabVjXjPg));
		if (Math.Abs(_0023_003Dzfm4oGj8_003D.Domain.Length - _0023_003DzCVdPoWM_003D.Domain.Length) > num2)
		{
			return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
		}
		int num3 = _0023_003Dzfm4oGj8_003D.KnotVector.Length;
		for (int j = 0; j < num3; j++)
		{
			if (Math.Abs(_0023_003Dzfm4oGj8_003D.KnotVector[j] - _0023_003DzCVdPoWM_003D.KnotVector[j]) > num2 && Math.Abs(_0023_003Dzfm4oGj8_003D.KnotVector[j] + _0023_003DzCVdPoWM_003D.KnotVector[num3 - j - 1]) > num2)
			{
				return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0;
			}
		}
		if (_0023_003Dzwz6CZyI_003D(_0023_003Dzfm4oGj8_003D.ControlPoints[0], _0023_003DzCVdPoWM_003D.ControlPoints[0]) && _0023_003Dzwz6CZyI_003D(_0023_003Dzfm4oGj8_003D.ControlPoints[1], _0023_003DzCVdPoWM_003D.ControlPoints[1]))
		{
			return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5;
		}
		return (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6;
	}

	private static bool _0023_003Dzwz6CZyI_003D(Point4D _0023_003DzzheQawQ_003D, Point4D _0023_003DziFDFLZk_003D)
	{
		Point3D euclid = _0023_003DzzheQawQ_003D.Euclid;
		Point3D euclid2 = _0023_003DziFDFLZk_003D.Euclid;
		if (Utility.Compare(euclid.X, euclid2.X) == 0 && Utility.Compare(euclid.Y, euclid2.Y) == 0 && Utility.Compare(euclid.Z, euclid2.Z) == 0)
		{
			return true;
		}
		return false;
	}

	public static Curve LocalApproximation(IList<Point3D> Q, double err, out Vector3D[] tangents, bool cornerEnd = false)
	{
		int count = Q.Count;
		if (count == 2)
		{
			Line line = new Line(Q[0], Q[1]);
			Vector3D startTangent = line.StartTangent;
			tangents = new Vector3D[2] { startTangent, startTangent };
			return line.GetNurbsForm();
		}
		IList<PointTangent> list = new List<PointTangent>();
		tangents = _0023_003DzNAUUNSIVVPna006kuA_003D_003D(Q, _0023_003Dz47beYi4u2gFe: false, out var _, cornerEnd);
		for (int i = 0; i < count; i++)
		{
			list.Add(new PointTangent(Q[i].X, Q[i].Y, Q[i].Z, tangents[i].X, tangents[i].Y, tangents[i].Z));
		}
		int[] _0023_003DzOdWUsPilVdS;
		return _0023_003DzpYRsmT6eqQ4AbalM8XyzvVc_003D(list, err, out _0023_003DzOdWUsPilVdS);
	}

	public static Curve LocalApproximation(IList<PointTangent> Q, double err)
	{
		int[] _0023_003DzOdWUsPilVdS;
		return _0023_003DzpYRsmT6eqQ4AbalM8XyzvVc_003D(Q, err, out _0023_003DzOdWUsPilVdS);
	}

	internal static Curve _0023_003DzpYRsmT6eqQ4AbalM8XyzvVc_003D(IList<PointTangent> _0023_003DziDLVpbY_003D, double _0023_003DzEZdZXKE_003D, out int[] _0023_003DzOdWUsPilVdS7)
	{
		_0023_003DzOdWUsPilVdS7 = new int[0];
		_0023_003DziDLVpbY_003D = Utility.RemoveDuplicates(_0023_003DziDLVpbY_003D);
		foreach (PointTangent item in _0023_003DziDLVpbY_003D)
		{
			Vector3D tangent = item.Tangent;
			tangent.Normalize();
			item.Tx = tangent.X;
			item.Ty = tangent.Y;
			item.Tz = tangent.Z;
		}
		if (_0023_003DziDLVpbY_003D.Count < 2)
		{
			return null;
		}
		List<ICurve> list = new List<ICurve>();
		int num = _0023_003DziDLVpbY_003D.Count - 1;
		List<int> list2 = new List<int>();
		_0023_003DzlPrfzfc_003D(0, num, _0023_003DziDLVpbY_003D, _0023_003DzEZdZXKE_003D, list, list2);
		list2.Add(num);
		_0023_003DzOdWUsPilVdS7 = list2.ToArray();
		foreach (ICurve item2 in list)
		{
			((Curve)item2)._0023_003DziP9fFuA_003D.Scale(item2.Length());
		}
		Curve curve = Merge(list, clean: false);
		curve._0023_003DziP9fFuA_003D.Offset(0.0 - curve.Domain.Low);
		curve._0023_003DziP9fFuA_003D.Scale(1.0 / curve.Domain.High);
		return curve;
	}

	private static void _0023_003DzlPrfzfc_003D(int _0023_003DzfckFcQk_003D, int _0023_003DzExOxVZk_003D, IList<PointTangent> _0023_003DziDLVpbY_003D, double _0023_003DzDNpeQO0_003D, List<ICurve> _0023_003DzQxt4eQk_003D, List<int> _0023_003DzOoeJmwE9qE67)
	{
		Curve _0023_003DzzmfUkNI_003D;
		bool flag = _0023_003Dzf2cq69yJk9zn(_0023_003DzfckFcQk_003D, _0023_003DzExOxVZk_003D, _0023_003DziDLVpbY_003D, _0023_003DzDNpeQO0_003D, out _0023_003DzzmfUkNI_003D);
		if (flag)
		{
			_0023_003DzQxt4eQk_003D.Add(_0023_003DzzmfUkNI_003D);
			_0023_003DzOoeJmwE9qE67.Add(_0023_003DzfckFcQk_003D);
		}
		while (!flag)
		{
			_0023_003DzExOxVZk_003D = _0023_003DzfckFcQk_003D + (_0023_003DzExOxVZk_003D - _0023_003DzfckFcQk_003D) / 2;
			if (_0023_003DzExOxVZk_003D == _0023_003DzfckFcQk_003D)
			{
				break;
			}
			flag = _0023_003Dzf2cq69yJk9zn(_0023_003DzfckFcQk_003D, _0023_003DzExOxVZk_003D, _0023_003DziDLVpbY_003D, _0023_003DzDNpeQO0_003D, out _0023_003DzzmfUkNI_003D);
			if (flag)
			{
				_0023_003DzQxt4eQk_003D.Add(_0023_003DzzmfUkNI_003D);
				_0023_003DzOoeJmwE9qE67.Add(_0023_003DzfckFcQk_003D);
				_0023_003DzfckFcQk_003D = _0023_003DzExOxVZk_003D;
				_0023_003DzExOxVZk_003D = _0023_003DziDLVpbY_003D.Count - 1;
				_0023_003DzlPrfzfc_003D(_0023_003DzfckFcQk_003D, _0023_003DzExOxVZk_003D, _0023_003DziDLVpbY_003D, _0023_003DzDNpeQO0_003D, _0023_003DzQxt4eQk_003D, _0023_003DzOoeJmwE9qE67);
			}
		}
	}

	private static bool _0023_003Dzf2cq69yJk9zn(int _0023_003DzfckFcQk_003D, int _0023_003DzExOxVZk_003D, IList<PointTangent> _0023_003DziDLVpbY_003D, double _0023_003DzDNpeQO0_003D, out Curve _0023_003DzzmfUkNI_003D)
	{
		_0023_003DzzmfUkNI_003D = null;
		Point3D point3D = _0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D];
		Point3D point3D2 = _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D];
		Vector3D tangent = _0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D].Tangent;
		Vector3D tangent2 = _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D].Tangent;
		if (_0023_003DzExOxVZk_003D - _0023_003DzfckFcQk_003D == 1)
		{
			_0023_003DzzmfUkNI_003D = LocalInterpolation(new List<PointTangent>
			{
				_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D],
				_0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D]
			});
			if (_0023_003DzzmfUkNI_003D._0023_003DzMv2C5Tm1QMvc() == 4 && _0023_003DzzmfUkNI_003D.IsLinear(1E-12, out var _))
			{
				_0023_003DzzmfUkNI_003D = new Line(_0023_003DzzmfUkNI_003D.Pw[0], _0023_003DzzmfUkNI_003D.Pw[3]).GetNurbsForm();
			}
			return true;
		}
		int num = _0023_003DzExOxVZk_003D - _0023_003DzfckFcQk_003D;
		if (_0023_003Dz9Gs7ab0jJJ6ewHZtmA_003D_003D(_0023_003DzfckFcQk_003D, _0023_003DzExOxVZk_003D, _0023_003DziDLVpbY_003D, _0023_003DzDNpeQO0_003D))
		{
			_0023_003DzzmfUkNI_003D = new Curve(1, point3D, point3D2);
			return true;
		}
		double[] array = new double[num];
		double[] array2 = new double[num];
		double[] distances;
		double[] ub;
		double num2 = NurbsBase.ChordLengthParametrization(_0023_003DzfckFcQk_003D, _0023_003DzExOxVZk_003D + 1, _0023_003DziDLVpbY_003D, out distances, out ub);
		double num3 = num2 * 0.001;
		if (Point3D.AreEqual(point3D, point3D2, num2 * Utility._0023_003DzheSR8QM7q9ya))
		{
			return false;
		}
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		if (vector3D.IsZero)
		{
			return false;
		}
		vector3D.Normalize();
		if (tangent.IsZero || Vector3D.AreParallel(vector3D, tangent, Utility._0023_003DzxhnLabVjXjPg))
		{
			return false;
		}
		Plane plane = new Plane(point3D, vector3D, tangent);
		int i;
		for (i = 1; i < num; i++)
		{
			Point3D point3D3 = _0023_003DziDLVpbY_003D[i + _0023_003DzfckFcQk_003D];
			Vector3D tangent3 = _0023_003DziDLVpbY_003D[i + _0023_003DzfckFcQk_003D].Tangent;
			if (Math.Abs(plane.DistanceTo(point3D3)) < num3 && Vector3D.AreOrthogonal(tangent2, plane.AxisZ, 0.01))
			{
				NurbsBase._0023_003DzrYXEkm3JIzJSWz0OLBC4hoM_003D(_0023_003DzExOxVZk_003D + 1 - _0023_003DzfckFcQk_003D, distances, num2, out ub, _0023_003Dz0jndlI35hm2U: false);
				double num4 = ub[i];
				double num5 = 1.0 - num4;
				double num6 = num4;
				double num7 = num5 * num5;
				double num8 = num6 * num6;
				double num9 = num5 * num5 * num5;
				double num10 = num6 * num6 * num6;
				double[,] array3 = new double[6, 2];
				double[] array4 = new double[6];
				array3[0, 0] = 3.0 * num7 * num6 * tangent.X;
				array3[0, 1] = 3.0 * num5 * num8 * tangent2.X;
				array3[1, 0] = 3.0 * num7 * num6 * tangent.Y;
				array3[1, 1] = 3.0 * num5 * num8 * tangent2.Y;
				array3[2, 0] = 3.0 * num7 * num6 * tangent.Z;
				array3[2, 1] = 3.0 * num5 * num8 * tangent2.Z;
				array4[0] = point3D3.X - (num9 + 3.0 * num7 * num6) * point3D.X - (num10 + 3.0 * num5 * num8) * point3D2.X;
				array4[1] = point3D3.Y - (num9 + 3.0 * num7 * num6) * point3D.Y - (num10 + 3.0 * num5 * num8) * point3D2.Y;
				array4[2] = point3D3.Z - (num9 + 3.0 * num7 * num6) * point3D.Z - (num10 + 3.0 * num5 * num8) * point3D2.Z;
				Vector3D vector3D2 = Vector3D.Cross(tangent3, tangent);
				Vector3D vector3D3 = Vector3D.Cross(tangent3, tangent2);
				array3[3, 0] = num5 * (num5 - 2.0 * num6) * vector3D2.X;
				array3[3, 1] = num6 * (2.0 * num5 - num6) * vector3D3.X;
				array3[4, 0] = num5 * (num5 - 2.0 * num6) * vector3D2.Y;
				array3[4, 1] = num6 * (2.0 * num5 - num6) * vector3D3.Y;
				array3[5, 0] = num5 * (num5 - 2.0 * num6) * vector3D2.Z;
				array3[5, 1] = num6 * (2.0 * num5 - num6) * vector3D3.Z;
				Vector3D vector3D4 = Vector3D.Cross(tangent3, new Vector3D(point3D2, point3D));
				array4[3] = 2.0 * num5 * num6 * vector3D4.X;
				array4[4] = 2.0 * num5 * num6 * vector3D4.Y;
				array4[5] = 2.0 * num5 * num6 * vector3D4.Z;
				double[] array5 = NurbsBase._0023_003DzphmdrE9a2afe(array3, array4);
				double num11 = array5[0];
				double num12 = array5[1];
				if (!(num11 > 0.0) || !(num12 < 0.0))
				{
					return false;
				}
				array[i] = num11;
				array2[i] = num12;
			}
			else
			{
				if (!new Segment3D(point3D3, point3D3 + tangent2).IntersectWith(plane, infinite: true, out var intPoint))
				{
					return false;
				}
				Utility.Intersect3DLines(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D], new Vector3D(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D], _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D]), intPoint, tangent, out var _, out var _, out var i2);
				double num13 = i2.DistanceTo(_0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D]) / _0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D].DistanceTo(_0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D]);
				if (num13 < 0.0 || num13 > 1.0)
				{
					return false;
				}
				double num14 = _0023_003DzEcd8MvxmSL4c(num13);
				ub[i] = num14;
				if (ub[i] < 0.0 || ub[i] > 1.0)
				{
					return false;
				}
				double num15 = i2.DistanceTo(intPoint);
				double num16 = 0.0 - intPoint.DistanceTo(point3D3);
				array[i] = num15 / NurbsBase.Bernstain(1, 3, ub[i]);
				array2[i] = num16 / NurbsBase.Bernstain(2, 3, ub[i]);
			}
		}
		double num17 = 0.0;
		double num18 = 0.0;
		for (i = 1; i < num; i++)
		{
			num17 += array[i];
			num18 += array2[i];
		}
		num17 /= (double)(num - 1);
		num18 /= (double)(num - 1);
		if (num17 > num2 || num18 < 0.0 - num2)
		{
			return false;
		}
		Point3D point3D4 = point3D + num17 * tangent;
		Point3D point3D5 = point3D2 + num18 * tangent2;
		_0023_003DzzmfUkNI_003D = new Curve(3, point3D, point3D4, point3D5, point3D2);
		for (i = 1; i < num; i++)
		{
			double _0023_003Dz_eY3Y4c_003D = ub[i];
			double num19 = array[i] - num17;
			double num20 = array2[i] - num18;
			if (!((num19 * NurbsBase.Bernstain(1, 3, _0023_003Dz_eY3Y4c_003D) * _0023_003Dz_eY3Y4c_003D * tangent - num20 * NurbsBase.Bernstain(2, 3, _0023_003Dz_eY3Y4c_003D) * _0023_003Dz_eY3Y4c_003D * tangent2).Length < _0023_003DzDNpeQO0_003D))
			{
				if (!_0023_003DzzmfUkNI_003D._0023_003DzCAkKPyqtNt3E(_0023_003DziDLVpbY_003D[i + _0023_003DzfckFcQk_003D], ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzRpXgovo_003D, out var _))
				{
					return false;
				}
				if (_0023_003DzRpXgovo_003D.Length > _0023_003DzDNpeQO0_003D)
				{
					break;
				}
			}
		}
		if (i == num)
		{
			return true;
		}
		return false;
	}

	private static double _0023_003DzEcd8MvxmSL4c(double _0023_003DzpQXbb0QwKJ3S)
	{
		double num = 1.0 - _0023_003DzpQXbb0QwKJ3S;
		double num2 = 0.0;
		double num3 = 1.0;
		int num4 = 0;
		do
		{
			double num5 = NurbsBase.Bernstain(0, 3, num) + NurbsBase.Bernstain(1, 3, num) - _0023_003DzpQXbb0QwKJ3S;
			if (Math.Abs(num5) < 1E-15)
			{
				break;
			}
			double num6 = NurbsBase.BernstainDer(0, 3, num) + NurbsBase.BernstainDer(1, 3, num);
			double num7 = num - num5 / num6;
			if (num7 < num2)
			{
				num7 = num2;
			}
			else if (num7 > num3)
			{
				num7 = num3;
			}
			if (num == num7)
			{
				break;
			}
			num = num7;
		}
		while (num4++ < 8);
		if (double.IsNaN(num))
		{
			return 0.0;
		}
		return num;
	}

	private static bool _0023_003Dz9Gs7ab0jJJ6ewHZtmA_003D_003D(int _0023_003DzfckFcQk_003D, int _0023_003DzExOxVZk_003D, IList<PointTangent> _0023_003DziDLVpbY_003D, double _0023_003Dzm0CYiiE_003D)
	{
		if (Utility.Compare(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D].X, _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D].X) == 0 && Utility.Compare(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D].Y, _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D].Y) == 0 && Utility.Compare(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D].Z, _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D].Z) == 0 && _0023_003DzExOxVZk_003D - _0023_003DzfckFcQk_003D > 0)
		{
			return false;
		}
		Segment3D seg = new Segment3D(_0023_003DziDLVpbY_003D[_0023_003DzfckFcQk_003D], _0023_003DziDLVpbY_003D[_0023_003DzExOxVZk_003D]);
		for (int i = _0023_003DzfckFcQk_003D + 1; i < _0023_003DzExOxVZk_003D; i++)
		{
			if (_0023_003DziDLVpbY_003D[i].DistanceTo(seg) > _0023_003Dzm0CYiiE_003D)
			{
				return false;
			}
		}
		return true;
	}

	public static Curve GlobalApproximation(IList<Point3D> Q, int deg, double err)
	{
		NurbsBase.ChordLengthParametrization(Q, out var ub);
		Curve curve = new Curve();
		if (!curve._0023_003Dz_0024HIJaoDbAfVK9u6Npr7XGfw_003D(Q, ub, deg, err))
		{
			return null;
		}
		curve._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		return curve;
	}

	private bool _0023_003Dz_0024HIJaoDbAfVK9u6Npr7XGfw_003D(IList<Point3D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, int _0023_003Dz0Spp0TwHAwRx, double _0023_003DzDNpeQO0_003D)
	{
		double[] array = new double[_0023_003DziDLVpbY_003D.Count];
		_0023_003DzB68dg9Q_003D = 1;
		_0023_003DzMkhW6Qu763nq(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003DzB68dg9Q_003D, out _0023_003DziP9fFuA_003D, out Pw);
		double[] _0023_003Dz_0024xk5_0s_003D = new double[_0023_003DziDLVpbY_003D.Count];
		int num = _0023_003DzMv2C5Tm1QMvc();
		int num2 = 0;
		int i;
		Point4D[] _0023_003Dzl3DhHgI_003D;
		for (i = 1; i <= _0023_003Dz0Spp0TwHAwRx + 1; i++)
		{
			_0023_003DzQdGxoBEPmxMVbMywXQ_003D_003D(_0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D);
			num2 = _0023_003DzMv2C5Tm1QMvc();
			if (i == _0023_003Dz0Spp0TwHAwRx)
			{
				break;
			}
			if (i < _0023_003Dz0Spp0TwHAwRx)
			{
				Array.Resize(ref array, _0023_003DziP9fFuA_003D.Length * 2);
				array[0] = _0023_003DziP9fFuA_003D[0];
				int newSize = 1;
				for (int j = 1; j < _0023_003DziP9fFuA_003D.Length; j++)
				{
					if (_0023_003DziP9fFuA_003D[j] > _0023_003DziP9fFuA_003D[j - 1])
					{
						array[newSize++] = _0023_003DziP9fFuA_003D[j - 1];
					}
					array[newSize++] = _0023_003DziP9fFuA_003D[j];
				}
				array[newSize++] = _0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1];
				Array.Resize(ref array, newSize);
				if (_0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(_0023_003DziDLVpbY_003D, i + 1, array.Length - i - 1 - 1, _0023_003Dzf9Vy1JQ_003D, array, out _0023_003Dzl3DhHgI_003D))
				{
					Pw = _0023_003Dzl3DhHgI_003D;
					_0023_003DziP9fFuA_003D = array;
					_0023_003DzB68dg9Q_003D = i + 1;
				}
				else
				{
					DegreeElevate(1);
				}
			}
			else if (_0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(_0023_003DziDLVpbY_003D, i, _0023_003DzMv2C5Tm1QMvc(), _0023_003Dzf9Vy1JQ_003D, _0023_003DziP9fFuA_003D, out _0023_003Dzl3DhHgI_003D))
			{
				Pw = _0023_003Dzl3DhHgI_003D;
				_0023_003DzB68dg9Q_003D = i;
			}
			if (!_0023_003DzW_0024ImwZk_003D(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D))
			{
				return false;
			}
		}
		if (num == num2)
		{
			return true;
		}
		if (_0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(_0023_003DziDLVpbY_003D, i, num2, _0023_003Dzf9Vy1JQ_003D, _0023_003DziP9fFuA_003D, out _0023_003Dzl3DhHgI_003D))
		{
			Pw = _0023_003Dzl3DhHgI_003D;
		}
		if (!_0023_003DzW_0024ImwZk_003D(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D))
		{
			return false;
		}
		_0023_003DzQdGxoBEPmxMVbMywXQ_003D_003D(_0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D);
		return true;
	}

	internal bool _0023_003DzcA1ZK8zsvSo06Hca4KXj4M4_003D(IList<Point4D> _0023_003DziDLVpbY_003D, double[] _0023_003DzqybiIyI_003D, int _0023_003Dz0Spp0TwHAwRx, double _0023_003DzDNpeQO0_003D)
	{
		double[] _0023_003Dzf9Vy1JQ_003D = (double[])_0023_003DzqybiIyI_003D.Clone();
		double[] array = new double[_0023_003DziDLVpbY_003D.Count];
		_0023_003DzB68dg9Q_003D = 1;
		_0023_003DzGre_rgEVRLbu(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003DzB68dg9Q_003D, out _0023_003DziP9fFuA_003D, out Pw);
		double[] _0023_003Dz_0024xk5_0s_003D = new double[_0023_003DziDLVpbY_003D.Count];
		int num = _0023_003DzMv2C5Tm1QMvc();
		int num2 = 0;
		int i;
		Point4D[] _0023_003Dzl3DhHgI_003D;
		for (i = 1; i <= _0023_003Dz0Spp0TwHAwRx + 1; i++)
		{
			_0023_003DzQdGxoBEPmxMVbMywXQ_003D_003D(_0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D);
			num2 = _0023_003DzMv2C5Tm1QMvc();
			if (i == _0023_003Dz0Spp0TwHAwRx)
			{
				break;
			}
			if (i < _0023_003Dz0Spp0TwHAwRx)
			{
				Array.Resize(ref array, _0023_003DziP9fFuA_003D.Length * 2);
				array[0] = _0023_003DziP9fFuA_003D[0];
				int newSize = 1;
				for (int j = 1; j < _0023_003DziP9fFuA_003D.Length; j++)
				{
					if (_0023_003DziP9fFuA_003D[j] > _0023_003DziP9fFuA_003D[j - 1])
					{
						array[newSize++] = _0023_003DziP9fFuA_003D[j - 1];
					}
					array[newSize++] = _0023_003DziP9fFuA_003D[j];
				}
				array[newSize++] = _0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1];
				Array.Resize(ref array, newSize);
				if (_0023_003DzMIUJHcl1qJ_z0_qquw_003D_003D(_0023_003DziDLVpbY_003D, i + 1, array.Length - i - 1 - 1, _0023_003Dzf9Vy1JQ_003D, array, out _0023_003Dzl3DhHgI_003D))
				{
					Pw = _0023_003Dzl3DhHgI_003D;
					_0023_003DziP9fFuA_003D = array;
					_0023_003DzB68dg9Q_003D = i + 1;
				}
				else
				{
					DegreeElevate(1);
				}
			}
			else if (_0023_003DzMIUJHcl1qJ_z0_qquw_003D_003D(_0023_003DziDLVpbY_003D, i, _0023_003DzMv2C5Tm1QMvc(), _0023_003Dzf9Vy1JQ_003D, _0023_003DziP9fFuA_003D, out _0023_003Dzl3DhHgI_003D))
			{
				Pw = _0023_003Dzl3DhHgI_003D;
				_0023_003DzB68dg9Q_003D = i;
			}
			if (!_0023_003DzmTppyWF7d1m7(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D))
			{
				return false;
			}
		}
		if (num == num2)
		{
			return true;
		}
		if (_0023_003DzMIUJHcl1qJ_z0_qquw_003D_003D(_0023_003DziDLVpbY_003D, i, num2, _0023_003Dzf9Vy1JQ_003D, _0023_003DziP9fFuA_003D, out _0023_003Dzl3DhHgI_003D))
		{
			Pw = _0023_003Dzl3DhHgI_003D;
		}
		if (!_0023_003DzmTppyWF7d1m7(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D))
		{
			return false;
		}
		_0023_003DzQdGxoBEPmxMVbMywXQ_003D_003D(_0023_003Dzf9Vy1JQ_003D, _0023_003Dz_0024xk5_0s_003D, _0023_003DzDNpeQO0_003D);
		return true;
	}

	private static void _0023_003DzMkhW6Qu763nq(IList<Point3D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, int _0023_003DzB68dg9Q_003D, out double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzl3DhHgI_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		_0023_003Dzl3DhHgI_003D = new Point4D[count];
		_0023_003DziP9fFuA_003D = new double[count + _0023_003DzB68dg9Q_003D + 1];
		_0023_003DziP9fFuA_003D[0] = 0.0;
		_0023_003DzB68dg9Q_003D = 1;
		for (int i = 0; i < _0023_003Dzf9Vy1JQ_003D.Length; i++)
		{
			_0023_003DziP9fFuA_003D[i + _0023_003DzB68dg9Q_003D] = _0023_003Dzf9Vy1JQ_003D[i];
		}
		_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1] = 1.0;
		for (int j = 0; j < count; j++)
		{
			_0023_003Dzl3DhHgI_003D[j] = new Point4D(_0023_003DziDLVpbY_003D[j]);
		}
	}

	private static void _0023_003DzGre_rgEVRLbu(IList<Point4D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, int _0023_003DzB68dg9Q_003D, out double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzl3DhHgI_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		_0023_003Dzl3DhHgI_003D = new Point4D[count];
		_0023_003DziP9fFuA_003D = new double[count + _0023_003DzB68dg9Q_003D + 1];
		_0023_003DziP9fFuA_003D[0] = 0.0;
		_0023_003DzB68dg9Q_003D = 1;
		for (int i = 0; i < _0023_003Dzf9Vy1JQ_003D.Length; i++)
		{
			_0023_003DziP9fFuA_003D[i + _0023_003DzB68dg9Q_003D] = _0023_003Dzf9Vy1JQ_003D[i];
		}
		_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1] = 1.0;
		for (int j = 0; j < count; j++)
		{
			_0023_003Dzl3DhHgI_003D[j] = (Point4D)_0023_003DziDLVpbY_003D[j].Clone();
		}
	}

	private bool _0023_003DzW_0024ImwZk_003D(IList<Point3D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003Dz_0024xk5_0s_003D, double _0023_003DzDNpeQO0_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		for (int i = 0; i < count; i++)
		{
			double _0023_003Dz_eY3Y4c_003D = _0023_003Dzf9Vy1JQ_003D[i];
			if (!_0023_003DzCAkKPyqtNt3E(_0023_003DziDLVpbY_003D[i], ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out var _, out var _))
			{
				return false;
			}
			Point3D a = PointAt(_0023_003Dz_eY3Y4c_003D);
			_0023_003Dz_0024xk5_0s_003D[i] = Point3D.Distance(a, _0023_003DziDLVpbY_003D[i]);
			if (_0023_003Dz_0024xk5_0s_003D[i] > _0023_003DzDNpeQO0_003D)
			{
				return false;
			}
			_0023_003Dzf9Vy1JQ_003D[i] = _0023_003Dz_eY3Y4c_003D;
			if (i < count - 1)
			{
				_0023_003Dz_eY3Y4c_003D = (_0023_003Dzf9Vy1JQ_003D[i] + _0023_003Dzf9Vy1JQ_003D[i + 1]) / 2.0;
				a = PointAt(_0023_003Dz_eY3Y4c_003D);
				_0023_003Dz_0024xk5_0s_003D[i] = Point3D.Distance(a, Point3D.MidPoint(_0023_003DziDLVpbY_003D[i], _0023_003DziDLVpbY_003D[i + 1]));
				if (_0023_003Dz_0024xk5_0s_003D[i] > _0023_003DzDNpeQO0_003D * 10.0)
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool _0023_003DzmTppyWF7d1m7(IList<Point4D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003Dz_0024xk5_0s_003D, double _0023_003DzDNpeQO0_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		for (int i = 0; i < count; i++)
		{
			double _0023_003Dz_eY3Y4c_003D = _0023_003Dzf9Vy1JQ_003D[i];
			if (!_0023_003DzCAkKPyqtNt3E(_0023_003DziDLVpbY_003D[i], ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out var _, out var _))
			{
				return false;
			}
			Point3D a = PointAt(_0023_003Dz_eY3Y4c_003D);
			_0023_003Dz_0024xk5_0s_003D[i] = Point3D.Distance(a, _0023_003DziDLVpbY_003D[i]);
			if (_0023_003Dz_0024xk5_0s_003D[i] > _0023_003DzDNpeQO0_003D)
			{
				return false;
			}
			_0023_003Dzf9Vy1JQ_003D[i] = _0023_003Dz_eY3Y4c_003D;
			if (i < count - 1)
			{
				_0023_003Dz_eY3Y4c_003D = (_0023_003Dzf9Vy1JQ_003D[i] + _0023_003Dzf9Vy1JQ_003D[i + 1]) / 2.0;
				a = PointAt(_0023_003Dz_eY3Y4c_003D);
				if (Point3D.Distance(a, (_0023_003DziDLVpbY_003D[i] + _0023_003DziDLVpbY_003D[i + 1]) / 2.0) > _0023_003DzDNpeQO0_003D * 10.0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public static Curve LeastSquares(IList<Point3D> Q, int p, int n)
	{
		NurbsBase.ChordLengthParametrization(Q, out var ub);
		if (_0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(Q, p, n, ub, out var knotVector, out var _0023_003Dzl3DhHgI_003D))
		{
			return new Curve(p, knotVector, _0023_003Dzl3DhHgI_003D);
		}
		return null;
	}

	private static bool _0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(IList<Point3D> _0023_003DziDLVpbY_003D, int _0023_003DzB68dg9Q_003D, int _0023_003DzoMNiNRw_003D, double[] _0023_003Dzf9Vy1JQ_003D, out double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzl3DhHgI_003D)
	{
		_0023_003DziP9fFuA_003D = new double[_0023_003DzoMNiNRw_003D + _0023_003DzB68dg9Q_003D + 1];
		for (int i = 0; i < _0023_003DziP9fFuA_003D.Length; i++)
		{
			_0023_003DziP9fFuA_003D[i] = 1.0;
		}
		double num = (double)_0023_003DziDLVpbY_003D.Count / (double)_0023_003DzoMNiNRw_003D;
		for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
		{
			_0023_003DziP9fFuA_003D[j] = 0.0;
		}
		for (int j = 1; j < _0023_003DzoMNiNRw_003D - _0023_003DzB68dg9Q_003D; j++)
		{
			_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + j] = 0.0;
			for (int k = j; k < j + _0023_003DzB68dg9Q_003D; k++)
			{
				int num2 = (int)((double)k * num);
				double num3 = (double)k * num - (double)num2;
				int num4 = (int)((double)(k - 1) * num);
				_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + j] += num3 * _0023_003Dzf9Vy1JQ_003D[num4] + (1.0 - num3) * _0023_003Dzf9Vy1JQ_003D[num2];
			}
			_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + j] /= _0023_003DzB68dg9Q_003D;
		}
		return _0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(_0023_003DziDLVpbY_003D, _0023_003DzB68dg9Q_003D, _0023_003DzoMNiNRw_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003DziP9fFuA_003D, out _0023_003Dzl3DhHgI_003D);
	}

	private static bool _0023_003Dzswb7YZUv9Aune5hoxw_003D_003D(IList<Point3D> _0023_003DziDLVpbY_003D, int _0023_003DzB68dg9Q_003D, int _0023_003DzoMNiNRw_003D, double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzl3DhHgI_003D)
	{
		_0023_003Dzl3DhHgI_003D = null;
		int count = _0023_003DziDLVpbY_003D.Count;
		Point3D[] array = new Point3D[_0023_003DzoMNiNRw_003D];
		Point3D[] array2 = new Point3D[count];
		Equation[] array3 = new Equation[count];
		for (int i = 0; i < count; i++)
		{
			int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzoMNiNRw_003D - 1, _0023_003DzB68dg9Q_003D, _0023_003Dzf9Vy1JQ_003D[i]);
			double[] array4 = _0023_003DziP9fFuA_003D.BasisFuns(num, _0023_003Dzf9Vy1JQ_003D[i], _0023_003DzB68dg9Q_003D);
			array3[i] = new Equation(_0023_003DzB68dg9Q_003D + 1);
			for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
			{
				array3[i].Add(num - _0023_003DzB68dg9Q_003D + j, array4[j]);
			}
			Point3D point3D = Point3D.Origin;
			Coefficient coefficient = array3[i][_0023_003DzoMNiNRw_003D - 1];
			if (coefficient.Pos != -1)
			{
				point3D = coefficient.Val * _0023_003DziDLVpbY_003D[count - 1];
			}
			array2[i] = _0023_003DziDLVpbY_003D[i] - array3[i][0].Val * _0023_003DziDLVpbY_003D[0] - point3D;
		}
		for (int k = 0; k < _0023_003DzoMNiNRw_003D; k++)
		{
			array[k] = new Point3D();
			for (int l = 0; l < count; l++)
			{
				Coefficient coefficient2 = array3[l][k];
				if (coefficient2.Pos != -1)
				{
					Point3D[] array5 = array;
					int num2 = k;
					array5[num2] += coefficient2.Val * array2[l];
				}
			}
			Point3D point3D2 = array[k];
			if (Math.Abs(point3D2.X) < 1E-12 && Math.Abs(point3D2.Y) < 1E-12 && Math.Abs(point3D2.Z) < 1E-12)
			{
				return false;
			}
		}
		_0023_003Dzl3DhHgI_003D = new Point4D[_0023_003DzoMNiNRw_003D];
		double[,] _0023_003DzH9VU2k0_003D = new double[_0023_003DzoMNiNRw_003D - 2, 3];
		for (int m = 1; m < _0023_003DzoMNiNRw_003D - 1; m++)
		{
			Point3D point3D3 = array[m];
			_0023_003DzH9VU2k0_003D[m - 1, 0] = point3D3.X;
			_0023_003DzH9VU2k0_003D[m - 1, 1] = point3D3.Y;
			_0023_003DzH9VU2k0_003D[m - 1, 2] = point3D3.Z;
		}
		if (_0023_003DzoMNiNRw_003D - 2 > 4 && _0023_003DzoMNiNRw_003D > _0023_003DzB68dg9Q_003D + 1)
		{
			Equation[] array6 = new Equation[count - 2];
			Array.Copy(array3, 1, array6, 0, count - 2);
			Equation[] array7 = array6;
			foreach (Equation equation in array7)
			{
				equation.RemoveAt(_0023_003DzoMNiNRw_003D - 1);
				equation.RemoveAt(0);
			}
			if (!NurbsBase._0023_003DzhrvLkG8qVgMc7JLCgw_003D_003D(Matrix.Multiply(Matrix.Transpose(_0023_003DzoMNiNRw_003D - 2, count - 2, array6), array6, _0023_003DzB68dg9Q_003D + _0023_003DzB68dg9Q_003D + 1), ref _0023_003DzH9VU2k0_003D, _0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D))
			{
				return false;
			}
		}
		else
		{
			double[,] array8 = _0023_003DzDDc8OhoSnZ9g(array3, 1, 1, count - 2, _0023_003DzoMNiNRw_003D - 2);
			if (!NurbsBase._0023_003DzcpymVWGKJIjE(Matrix.Multiply(Matrix.Transpose(array8), array8), ref _0023_003DzH9VU2k0_003D))
			{
				return false;
			}
		}
		for (int n = 0; n < _0023_003DzoMNiNRw_003D - 2; n++)
		{
			_0023_003Dzl3DhHgI_003D[n + 1] = new Point4D(_0023_003DzH9VU2k0_003D[n, 0], _0023_003DzH9VU2k0_003D[n, 1], _0023_003DzH9VU2k0_003D[n, 2]);
		}
		_0023_003Dzl3DhHgI_003D[0] = new Point4D(_0023_003DziDLVpbY_003D[0]);
		_0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D - 1] = new Point4D(_0023_003DziDLVpbY_003D[count - 1]);
		return true;
	}

	private static bool _0023_003DzMIUJHcl1qJ_z0_qquw_003D_003D(IList<Point4D> _0023_003DziDLVpbY_003D, int _0023_003DzB68dg9Q_003D, int _0023_003DzoMNiNRw_003D, double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzl3DhHgI_003D)
	{
		_0023_003Dzl3DhHgI_003D = null;
		int count = _0023_003DziDLVpbY_003D.Count;
		Point4D[] array = new Point4D[_0023_003DzoMNiNRw_003D];
		Point4D[] array2 = new Point4D[count];
		Equation[] array3 = new Equation[count];
		for (int i = 0; i < count; i++)
		{
			int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzoMNiNRw_003D - 1, _0023_003DzB68dg9Q_003D, _0023_003Dzf9Vy1JQ_003D[i]);
			double[] array4 = _0023_003DziP9fFuA_003D.BasisFuns(num, _0023_003Dzf9Vy1JQ_003D[i], _0023_003DzB68dg9Q_003D);
			array3[i] = new Equation(_0023_003DzB68dg9Q_003D + 1);
			for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
			{
				array3[i].Add(num - _0023_003DzB68dg9Q_003D + j, array4[j]);
			}
			Point4D point4D = new Point4D(0.0, 0.0, 0.0, 0.0);
			Coefficient coefficient = array3[i][_0023_003DzoMNiNRw_003D - 1];
			if (coefficient.Pos != -1)
			{
				point4D = coefficient.Val * _0023_003DziDLVpbY_003D[count - 1];
			}
			array2[i] = _0023_003DziDLVpbY_003D[i] - array3[i][0].Val * _0023_003DziDLVpbY_003D[0] - point4D;
		}
		for (int k = 0; k < _0023_003DzoMNiNRw_003D; k++)
		{
			array[k] = new Point4D();
			for (int l = 0; l < count; l++)
			{
				Coefficient coefficient2 = array3[l][k];
				if (coefficient2.Pos != -1)
				{
					Point4D[] array5 = array;
					int num2 = k;
					array5[num2] += coefficient2.Val * array2[l];
				}
			}
			Point4D point4D2 = array[k];
			if (Math.Abs(point4D2.X) < 1E-12 && Math.Abs(point4D2.Y) < 1E-12 && Math.Abs(point4D2.Z) < 1E-12)
			{
				return false;
			}
		}
		_0023_003Dzl3DhHgI_003D = new Point4D[_0023_003DzoMNiNRw_003D];
		double[,] _0023_003DzH9VU2k0_003D = new double[_0023_003DzoMNiNRw_003D - 2, 4];
		for (int m = 1; m < _0023_003DzoMNiNRw_003D - 1; m++)
		{
			Point4D point4D3 = array[m];
			_0023_003DzH9VU2k0_003D[m - 1, 0] = point4D3.X;
			_0023_003DzH9VU2k0_003D[m - 1, 1] = point4D3.Y;
			_0023_003DzH9VU2k0_003D[m - 1, 2] = point4D3.Z;
			_0023_003DzH9VU2k0_003D[m - 1, 3] = point4D3.W;
		}
		if (_0023_003DzoMNiNRw_003D - 2 > 4)
		{
			Equation[] array6 = new Equation[count - 2];
			Array.Copy(array3, 1, array6, 0, count - 2);
			Equation[] array7 = array6;
			foreach (Equation equation in array7)
			{
				equation.RemoveAt(_0023_003DzoMNiNRw_003D - 1);
				equation.RemoveAt(0);
			}
			if (!NurbsBase._0023_003DzhrvLkG8qVgMc7JLCgw_003D_003D(Matrix.Multiply(Matrix.Transpose(_0023_003DzoMNiNRw_003D - 2, count - 2, array6), array6, _0023_003DzB68dg9Q_003D + _0023_003DzB68dg9Q_003D + 1), ref _0023_003DzH9VU2k0_003D, _0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D))
			{
				return false;
			}
		}
		else
		{
			double[,] array8 = _0023_003DzDDc8OhoSnZ9g(array3, 1, 1, count - 2, _0023_003DzoMNiNRw_003D - 2);
			if (!NurbsBase._0023_003DzcpymVWGKJIjE(Matrix.Multiply(Matrix.Transpose(array8), array8), ref _0023_003DzH9VU2k0_003D))
			{
				return false;
			}
		}
		for (int n = 0; n < _0023_003DzoMNiNRw_003D - 2; n++)
		{
			_0023_003Dzl3DhHgI_003D[n + 1] = new Point4D(_0023_003DzH9VU2k0_003D[n, 0], _0023_003DzH9VU2k0_003D[n, 1], _0023_003DzH9VU2k0_003D[n, 2], _0023_003DzH9VU2k0_003D[n, 3]);
		}
		_0023_003Dzl3DhHgI_003D[0] = (Point4D)_0023_003DziDLVpbY_003D[0].Clone();
		_0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D - 1] = (Point4D)_0023_003DziDLVpbY_003D[count - 1].Clone();
		return true;
	}

	private static double[,] _0023_003DzDDc8OhoSnZ9g(Equation[] _0023_003DzpGjKR04_003D, int _0023_003Dz90qRVXE_003D, int _0023_003DzvbSuAQQ_003D, int _0023_003DzJsijztM_003D, int _0023_003Dz8jQyqcVmW7sN)
	{
		double[,] array = new double[_0023_003DzJsijztM_003D, _0023_003Dz8jQyqcVmW7sN];
		for (int i = 0; i < _0023_003DzJsijztM_003D; i++)
		{
			for (int j = 0; j < _0023_003Dz8jQyqcVmW7sN; j++)
			{
				Coefficient coefficient = _0023_003DzpGjKR04_003D[i + _0023_003Dz90qRVXE_003D][j + _0023_003DzvbSuAQQ_003D];
				if (coefficient.Pos != -1)
				{
					array[i, j] = coefficient.Val;
				}
			}
		}
		return array;
	}

	private void _0023_003DzQdGxoBEPmxMVbMywXQ_003D_003D(double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003Dz_0024xk5_0s_003D, double _0023_003DzDNpeQO0_003D)
	{
		double[] array = new double[_0023_003DziP9fFuA_003D.Length];
		int[] array2 = new int[_0023_003DziP9fFuA_003D.Length];
		int[] array3 = new int[_0023_003DziP9fFuA_003D.Length];
		int[] array4 = new int[_0023_003DziP9fFuA_003D.Length];
		double[] array5 = new double[_0023_003Dzf9Vy1JQ_003D.Length];
		double[] array6 = new double[_0023_003Dzf9Vy1JQ_003D.Length];
		double num = 1E+20;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = num;
		}
		int num2 = 1;
		for (int j = _0023_003DzB68dg9Q_003D + 1; j < _0023_003DzMv2C5Tm1QMvc(); j++)
		{
			if (_0023_003DziP9fFuA_003D[j] < _0023_003DziP9fFuA_003D[j + 1])
			{
				array[j] = _0023_003DzRbkn2XlfEr8d(j, num2);
				array2[j] = num2;
				num2 = 1;
			}
			else
			{
				array[j] = num;
				array2[j] = 1;
				num2++;
			}
		}
		array3[0] = 0;
		for (int k = 0; k < array4.Length; k++)
		{
			array4[k] = _0023_003Dzf9Vy1JQ_003D.Length - 1;
		}
		for (int l = 0; l < _0023_003Dzf9Vy1JQ_003D.Length; l++)
		{
			int num3 = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dzf9Vy1JQ_003D[l]);
			if (array3[num3] == 0)
			{
				array3[num3] = l;
			}
			if (l + 1 < _0023_003Dzf9Vy1JQ_003D.Length)
			{
				array4[num3] = l + 1;
			}
		}
		while (true)
		{
			int num4 = _0023_003DzKtIwiUk_003D(array);
			if (array[num4] == num)
			{
				break;
			}
			int num5 = num4;
			int num6 = Math.Max(num5 - _0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D + 1);
			int num7 = Math.Min(num5 + _0023_003DzB68dg9Q_003D - array2[num5 + _0023_003DzB68dg9Q_003D] + 1, _0023_003DzFNjygTLTZtF3());
			num6 = array3[num6];
			num7 = array4[num7];
			bool flag = true;
			for (int m = num6; m <= num7; m++)
			{
				num2 = array2[num5];
				if ((_0023_003DzB68dg9Q_003D + num2) % 2 == 0)
				{
					double u = _0023_003Dzf9Vy1JQ_003D[m];
					int num8 = (_0023_003DzB68dg9Q_003D + num2) / 2;
					array5[m] = _0023_003DziP9fFuA_003D.OneBasisFun(num5 - num8, u, _0023_003DzB68dg9Q_003D) * array[num5];
				}
				else
				{
					double u = _0023_003Dzf9Vy1JQ_003D[m];
					int num8 = (_0023_003DzB68dg9Q_003D + num2 + 1) / 2;
					double num9 = (_0023_003DziP9fFuA_003D[num5] - _0023_003DziP9fFuA_003D[num5 - num8 + 1]) / (_0023_003DziP9fFuA_003D[num5 - num8 + _0023_003DzB68dg9Q_003D + 2] - _0023_003DziP9fFuA_003D[num5 - num8 + 1]);
					array5[m] = (1.0 - num9) * _0023_003DziP9fFuA_003D.OneBasisFun(num5 - num8 + 1, u, _0023_003DzB68dg9Q_003D) * array[num5];
				}
				array6[m] = array5[m] + _0023_003Dz_0024xk5_0s_003D[m];
				if (array6[m] > _0023_003DzDNpeQO0_003D)
				{
					flag = false;
					array[num5] = num;
					break;
				}
			}
			if (flag)
			{
				RemoveKnot(num5, array2[num5], 1);
				for (int n = num6; n <= num7; n++)
				{
					_0023_003Dz_0024xk5_0s_003D[n] = array6[n];
				}
				if (_0023_003DzMv2C5Tm1QMvc() <= _0023_003DzB68dg9Q_003D + 1)
				{
					break;
				}
				num6 = array3[num5 - _0023_003DzB68dg9Q_003D - 1];
				num7 = array4[num5 - array2[num5]];
				int num10 = -1;
				for (int num8 = num6; num8 <= num7; num8++)
				{
					int num11 = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dzf9Vy1JQ_003D[num8]);
					if (num11 != num10)
					{
						array3[num11] = num8;
					}
					if (num8 + 1 < _0023_003Dzf9Vy1JQ_003D.Length)
					{
						array4[num11] = num8 + 1;
					}
					num10 = num11;
				}
				for (int num8 = num5 - array2[num5] + 1; num8 < array3.Length - 1; num8++)
				{
					array3[num8] = array3[num8 + 1];
					array4[num8] = array4[num8 + 1];
				}
				Array.Resize(ref array3, array3.Length - 1);
				Array.Resize(ref array4, array4.Length - 1);
				num6 = Math.Max(num5 - _0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D + 1);
				num7 = Math.Min(num5 + _0023_003DzB68dg9Q_003D - array2[num5] + 1, _0023_003DzMv2C5Tm1QMvc());
				num2 = array2[num6];
				for (int num12 = num6; num12 <= num7; num12++)
				{
					if (_0023_003DziP9fFuA_003D[num12] < _0023_003DziP9fFuA_003D[num12 + 1])
					{
						array[num12] = _0023_003DzRbkn2XlfEr8d(num12, num2);
						array2[num12] = num2;
						num2 = 1;
					}
					else
					{
						array[num12] = num;
						array2[num12] = 1;
						num2++;
					}
				}
				for (int num13 = num7 + 1; num13 < array.Length - 1; num13++)
				{
					array[num13] = array[num13 + 1];
					array2[num13] = array2[num13 + 1];
				}
				Array.Resize(ref array, array.Length - 1);
			}
			else
			{
				array[num5] = num;
			}
		}
	}

	private double _0023_003DzRbkn2XlfEr8d(int _0023_003DzRpXgovo_003D, int _0023_003DzuwH5j5s_003D)
	{
		Point4D[] array = new Point4D[_0023_003DziP9fFuA_003D.Length];
		int num = _0023_003DzB68dg9Q_003D + 1;
		int num2 = _0023_003DzRpXgovo_003D - _0023_003DzuwH5j5s_003D;
		int num3 = _0023_003DzRpXgovo_003D - _0023_003DzB68dg9Q_003D;
		int num4 = num3 - 1;
		double num5 = _0023_003DziP9fFuA_003D[_0023_003DzRpXgovo_003D];
		array[0] = Pw[num4];
		array[num2 + 1 - num4] = Pw[num2 + 1];
		int num6 = num3;
		int num7 = num2;
		int num8 = 1;
		int num9 = num2 - num4;
		double num10;
		while (num7 - num6 > 0)
		{
			num10 = (num5 - _0023_003DziP9fFuA_003D[num6]) / (_0023_003DziP9fFuA_003D[num6 + num] - _0023_003DziP9fFuA_003D[num6]);
			double num11 = (num5 - _0023_003DziP9fFuA_003D[num7]) / (_0023_003DziP9fFuA_003D[num7 + num] - _0023_003DziP9fFuA_003D[num7]);
			array[num8] = (Pw[num6] - (1.0 - num10) * array[num8 - 1]) / num10;
			array[num9] = (Pw[num7] - num11 * array[num9 + 1]) / (1.0 - num11);
			num6++;
			num8++;
			num7--;
			num9--;
		}
		if (num7 - num6 < 0)
		{
			return Point3D.Distance(array[num8 - 1].Euclid, array[num9 + 1].Euclid);
		}
		num10 = (num5 - _0023_003DziP9fFuA_003D[num6]) / (_0023_003DziP9fFuA_003D[num6 + num] - _0023_003DziP9fFuA_003D[num6]);
		return Point3D.Distance(Pw[num6].Euclid, num10 * array[num8 + 1].Euclid + (1.0 - num10) * array[num8 - 1].Euclid);
	}

	private static int _0023_003DzKtIwiUk_003D(double[] _0023_003DzBJFJHwk_003D)
	{
		double num = _0023_003DzBJFJHwk_003D[0];
		int result = 0;
		for (int i = 1; i < _0023_003DzBJFJHwk_003D.Length; i++)
		{
			if (_0023_003DzBJFJHwk_003D[i] <= num)
			{
				num = _0023_003DzBJFJHwk_003D[i];
				result = i;
			}
		}
		return result;
	}

	internal void _0023_003DztGdcVOA_003D(int _0023_003DzU7eDCS_XZhhv, double[] _0023_003DztnKSw31yt72w, Point4D[] _0023_003DzR6JvypoMiEFQ, bool _0023_003DzWxVR7QlgFJPMS8zPFDWgWrA_003D)
	{
		_0023_003DzB68dg9Q_003D = _0023_003DzU7eDCS_XZhhv;
		_0023_003DziP9fFuA_003D = _0023_003DztnKSw31yt72w;
		Pw = _0023_003DzR6JvypoMiEFQ;
		if (_0023_003DzWxVR7QlgFJPMS8zPFDWgWrA_003D)
		{
			_0023_003DzuL_LPVTkh9VUKHTtUA_003D_003D();
			if (!_0023_003DzvVdETPB7voZ1kV79v9ITN2E_003D())
			{
				_0023_003Dzk3yIHV6nlnGsZ9OfCiA_0024pcU_003D();
				if (!_0023_003DzvVdETPB7voZ1kV79v9ITN2E_003D())
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963736));
				}
			}
			_0023_003DziP9fFuA_003D.IsClamped(_0023_003DzB68dg9Q_003D, _0023_003DzMv2C5Tm1QMvc(), out var start, out var end);
			_0023_003DzVYTmBrsvAaT9(!start, !end);
			if (_0023_003DzMv2C5Tm1QMvc() > _0023_003DzB68dg9Q_003D + 1)
			{
				_0023_003Dz1xLAiqQTtpny();
			}
		}
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
	}

	private void _0023_003Dzk3yIHV6nlnGsZ9OfCiA_0024pcU_003D()
	{
		int num = 0;
		for (int i = 0; i < _0023_003DziP9fFuA_003D.Length - 1; i++)
		{
			if (i > 0 && i < _0023_003DziP9fFuA_003D.Length - 2)
			{
				num = ((_0023_003DziP9fFuA_003D[i] != _0023_003DziP9fFuA_003D[i + 1]) ? 1 : (num + 1));
				if (num > _0023_003DzB68dg9Q_003D)
				{
					RemoveKnot(i + 1, num, 1);
					num--;
					i--;
				}
			}
		}
	}

	private void _0023_003DzuL_LPVTkh9VUKHTtUA_003D_003D()
	{
		int num = _0023_003DziP9fFuA_003D.Length;
		int num2 = _0023_003DziP9fFuA_003D.Multiplicity(0);
		if (num2 > _0023_003DzB68dg9Q_003D + 1)
		{
			int num3 = num2 - _0023_003DzB68dg9Q_003D - 1;
			double[] array = new double[num - num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003DziP9fFuA_003D[i + num3];
			}
			if (Pw.Length == num - _0023_003DzB68dg9Q_003D - 1)
			{
				Point4D[] array2 = new Point4D[Pw.Length - num3];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = Pw[j + num3];
				}
				Pw = array2;
			}
			_0023_003DziP9fFuA_003D = array;
		}
		num = _0023_003DziP9fFuA_003D.Length;
		int num4 = _0023_003DziP9fFuA_003D.Multiplicity(num - 1);
		if (num4 <= _0023_003DzB68dg9Q_003D + 1)
		{
			return;
		}
		int num5 = num4 - _0023_003DzB68dg9Q_003D - 1;
		double[] array3 = new double[num - num5];
		for (int k = 0; k < num - num5; k++)
		{
			array3[k] = _0023_003DziP9fFuA_003D[k];
		}
		if (Pw.Length == num - _0023_003DzB68dg9Q_003D - 1)
		{
			Point4D[] array4 = new Point4D[Pw.Length - num5];
			for (int l = 0; l < Pw.Length - num5; l++)
			{
				array4[l] = Pw[l];
			}
			Pw = array4;
		}
		_0023_003DziP9fFuA_003D = array3;
	}

	private void _0023_003DzWHWSACGCisBAIzqPyQ_003D_003D()
	{
		double minDist = _0023_003DziP9fFuA_003D.MinAcceptableKnotDistance(_0023_003DzB68dg9Q_003D);
		int num;
		do
		{
			num = _0023_003DziP9fFuA_003D.Length;
			if (_0023_003DziP9fFuA_003D.GetFirstSimilarKnotIndex(_0023_003DzB68dg9Q_003D, minDist, out var index, out var mult))
			{
				double[] array = (double[])_0023_003DziP9fFuA_003D.Clone();
				_0023_003DziP9fFuA_003D = array;
				Point4D[] _0023_003DzaoQTclc_003D = new Point4D[_0023_003DzMv2C5Tm1QMvc()];
				_0023_003DzD_00245nWTrQrjSP(Pw, ref _0023_003DzaoQTclc_003D);
				RemoveKnot(index, mult, mult);
				break;
			}
		}
		while (num != _0023_003DziP9fFuA_003D.Length);
	}

	private void _0023_003Dz1xLAiqQTtpny()
	{
		List<Point4D> list = new List<Point4D>();
		list.Add(Pw[0]);
		Point4D point4D = null;
		for (int i = 0; i < _0023_003DzFNjygTLTZtF3(); i++)
		{
			Point4D point4D2 = Pw[i];
			Point4D point4D3 = Pw[i + 1];
			if (Point4D.Distance(point4D2, point4D3) != 0.0)
			{
				list.Add(point4D3);
				point4D = point4D2;
			}
			else
			{
				if (i >= _0023_003DzFNjygTLTZtF3() - 1)
				{
					continue;
				}
				int j = i + 2;
				bool flag = false;
				for (; j != _0023_003DzFNjygTLTZtF3() + 1; j++)
				{
					if (flag)
					{
						break;
					}
					Point4D point4D4 = Pw[j];
					if (Point4D.Distance(point4D2, point4D4) == 0.0)
					{
						continue;
					}
					Line l = null;
					if (point4D != null)
					{
						l = new Line(point4D.Euclid, point4D2);
					}
					Line l2 = new Line(point4D2, point4D4.Euclid);
					if (point4D != null && !Line.AreCollinear(l, l2))
					{
						for (int k = i + 1; k <= j; k++)
						{
							list.Add(Pw[k]);
						}
						point4D = point4D2;
					}
					else
					{
						list.Add(point4D4);
						point4D = point4D2;
					}
					flag = true;
				}
				i = j - 2;
			}
		}
		if (list.Count == _0023_003DzMv2C5Tm1QMvc())
		{
			return;
		}
		List<ICurve> list2 = new List<ICurve>();
		Curve[] array = Decompose();
		foreach (Curve curve in array)
		{
			if (curve.Length() > 1E-12)
			{
				list2.Add(curve);
			}
		}
		if (list2.Count > 0)
		{
			Curve curve2 = Merge(list2, clean: false);
			if (curve2.Pw.Length < Pw.Length)
			{
				_0023_003DzB68dg9Q_003D = curve2._0023_003DzB68dg9Q_003D;
				_0023_003DziP9fFuA_003D = curve2._0023_003DziP9fFuA_003D;
				Pw = curve2.Pw;
			}
		}
	}

	private static void _0023_003DzD_00245nWTrQrjSP(Point4D[] _0023_003Dzb7SPTpc_003D, ref Point4D[] _0023_003DzaoQTclc_003D)
	{
		int length = _0023_003Dzb7SPTpc_003D.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			_0023_003DzaoQTclc_003D[i] = (Point4D)_0023_003Dzb7SPTpc_003D[i].Clone();
		}
	}

	public override object Clone()
	{
		return new Curve(this);
	}

	public override object CloneWithTessellation()
	{
		return new Curve(this, RegenMode != regenType.RegenAndCompile);
	}

	public void Resize(int n, int deg)
	{
		_0023_003DzB68dg9Q_003D = deg;
		Pw = new Point4D[n];
		_0023_003DziP9fFuA_003D = new double[n + _0023_003DzB68dg9Q_003D + 1];
	}

	public void ResizeKeep(int n, int deg)
	{
		_0023_003DzB68dg9Q_003D = deg;
		Array.Resize(ref Pw, n);
		Array.Resize(ref _0023_003DziP9fFuA_003D, n + _0023_003DzB68dg9Q_003D + 1);
	}

	internal void _0023_003DzFwon_0024wAfXM7284XT2w_003D_003D(double[] _0023_003DzqUVO1mk_003D)
	{
		double[] array = new double[_0023_003DzqUVO1mk_003D.Length];
		bool flag = false;
		int num;
		int num2;
		int newSize = (num = (num2 = 0));
		while (!flag)
		{
			if (Math.Abs(_0023_003DzqUVO1mk_003D[num2] - _0023_003DziP9fFuA_003D[num]) < 1E-12)
			{
				num2++;
				num++;
			}
			else
			{
				array[newSize++] = _0023_003DzqUVO1mk_003D[num2];
				num2++;
			}
			flag = num >= _0023_003DziP9fFuA_003D.Length || num2 >= _0023_003DzqUVO1mk_003D.Length;
		}
		Array.Resize(ref array, newSize);
		if (array.Length != 0)
		{
			RefineKnotVector(array);
		}
	}

	public static Curve Merge(ICurve cl, ICurve cu)
	{
		return Merge(new ICurve[2] { cl, cu });
	}

	private static Curve _0023_003DzMK9imxf2r5mQEF8wJA_003D_003D(Curve _0023_003Dz6V_0024QadA_003D, Curve _0023_003DzCskoEKg_003D, bool _0023_003DzYmu4LDs_003D)
	{
		if (!Utility.AreEqual(_0023_003Dz6V_0024QadA_003D.Domain.High, _0023_003DzCskoEKg_003D.Domain.Low, _0023_003Dz6V_0024QadA_003D.Domain.Length))
		{
			double low = _0023_003DzCskoEKg_003D.Domain.Low;
			for (int i = 0; i < _0023_003DzCskoEKg_003D._0023_003DziP9fFuA_003D.Length; i++)
			{
				_0023_003DzCskoEKg_003D._0023_003DziP9fFuA_003D[i] += _0023_003Dz6V_0024QadA_003D.Domain.High - low;
			}
		}
		Curve curve = new Curve();
		curve.Resize(_0023_003Dz6V_0024QadA_003D._0023_003DzMv2C5Tm1QMvc() - 1 + _0023_003DzCskoEKg_003D._0023_003DzMv2C5Tm1QMvc(), _0023_003Dz6V_0024QadA_003D._0023_003DzB68dg9Q_003D);
		for (int j = 0; j < _0023_003Dz6V_0024QadA_003D._0023_003DzMv2C5Tm1QMvc() - 1; j++)
		{
			curve.Pw[j] = _0023_003Dz6V_0024QadA_003D.Pw[j];
		}
		for (int k = _0023_003Dz6V_0024QadA_003D._0023_003DzMv2C5Tm1QMvc() - 1; k < curve._0023_003DzMv2C5Tm1QMvc(); k++)
		{
			curve.Pw[k] = _0023_003DzCskoEKg_003D.Pw[k - _0023_003Dz6V_0024QadA_003D._0023_003DzMv2C5Tm1QMvc() + 1];
		}
		for (int l = 0; l < _0023_003Dz6V_0024QadA_003D._0023_003DziP9fFuA_003D.Length - 1; l++)
		{
			curve._0023_003DziP9fFuA_003D[l] = _0023_003Dz6V_0024QadA_003D._0023_003DziP9fFuA_003D[l];
		}
		for (int m = _0023_003Dz6V_0024QadA_003D._0023_003DziP9fFuA_003D.Length - 1; m < curve._0023_003DziP9fFuA_003D.Length; m++)
		{
			curve._0023_003DziP9fFuA_003D[m] = _0023_003DzCskoEKg_003D._0023_003DziP9fFuA_003D[m - _0023_003Dz6V_0024QadA_003D._0023_003DziP9fFuA_003D.Length + curve._0023_003DzB68dg9Q_003D + 2];
		}
		if (_0023_003DzYmu4LDs_003D)
		{
			Size3D size3D = curve.ControlBoundingBox();
			curve.RemoveKnots(size3D.Diagonal * Utility._0023_003Dzjyaz_Vfaky9X);
		}
		curve._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		return curve;
	}

	public static Curve Merge(IList<ICurve> curves)
	{
		return Merge(curves, clean: true);
	}

	public static Curve Merge(IList<ICurve> curves, bool clean, bool resetDomain = true)
	{
		List<Curve> list = new List<Curve>(curves.Count);
		int num = 0;
		foreach (ICurve curf in curves)
		{
			if (!(curf.Length() < 1E-12))
			{
				Curve curve = ((curf is Curve) ? ((Curve)curf.Clone()) : curf.GetNurbsForm());
				if (resetDomain)
				{
					curve._0023_003DziP9fFuA_003D.Offset(0.0 - curve.Domain.Low);
				}
				list.Add(curve);
				if (num < curve._0023_003DzB68dg9Q_003D)
				{
					num = curve._0023_003DzB68dg9Q_003D;
				}
			}
		}
		foreach (Curve item in list)
		{
			if (item._0023_003DzB68dg9Q_003D < num)
			{
				item.DegreeElevate(num - item._0023_003DzB68dg9Q_003D);
			}
		}
		Curve curve2 = list[0];
		for (int i = 1; i < list.Count; i++)
		{
			Curve _0023_003DzCskoEKg_003D = list[i];
			curve2 = _0023_003DzMK9imxf2r5mQEF8wJA_003D_003D(curve2, _0023_003DzCskoEKg_003D, clean);
		}
		return curve2;
	}

	public bool SplitAt(double u, out ICurve lower, out ICurve upper)
	{
		if (u > Domain.Low && !Utility.AreEqual(u, Domain.Low, Domain.Length) && u < Domain.High && !Utility.AreEqual(u, Domain.High, Domain.Length))
		{
			double minKnotDist = _0023_003DziP9fFuA_003D.MinAcceptableKnotDistance(_0023_003DzB68dg9Q_003D);
			_0023_003DziP9fFuA_003D.FindSpanMult(ref u, _0023_003DzB68dg9Q_003D, minKnotDist, out var k, out var s);
			if (_0023_003DzB68dg9Q_003D - s == -1)
			{
				lower = null;
				upper = null;
				return false;
			}
			double[] array = new double[_0023_003DzB68dg9Q_003D - s];
			int i;
			for (i = 0; i < array.Length; i++)
			{
				array[i] = u;
			}
			Curve curve = (Curve)Clone();
			if (array.Length != 0)
			{
				curve.RefineKnotVector(array);
			}
			curve._0023_003DziP9fFuA_003D.FindSpanMult(u, _0023_003DzB68dg9Q_003D, out k, out s);
			k -= _0023_003DzB68dg9Q_003D;
			Curve curve2 = new Curve();
			curve2.Resize(curve.Pw.Length - k, _0023_003DzB68dg9Q_003D);
			i = curve._0023_003DzMv2C5Tm1QMvc() - 1;
			int num = curve2._0023_003DzMv2C5Tm1QMvc() - 1;
			while (num >= 0)
			{
				curve2.Pw[num] = (Point4D)curve.Pw[i].Clone();
				num--;
				i--;
			}
			i = curve._0023_003DziP9fFuA_003D.Length - 1;
			num = curve2._0023_003DziP9fFuA_003D.Length - 1;
			while (num >= 0)
			{
				curve2._0023_003DziP9fFuA_003D[num] = curve._0023_003DziP9fFuA_003D[i];
				num--;
				i--;
			}
			curve2._0023_003DziP9fFuA_003D[0] = curve2._0023_003DziP9fFuA_003D[1];
			curve.ResizeKeep(k + 1, _0023_003DzB68dg9Q_003D);
			curve._0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D + 1] = curve._0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D];
			curve._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
			curve2._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
			curve2.EdgeIndex = EdgeIndex;
			curve2.FromBooleanIntersection = FromBooleanIntersection;
			lower = curve;
			upper = curve2;
			((Entity)lower).CopyAttributes(this);
			((Entity)upper).CopyAttributes(this);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	private void _0023_003DzBEmNb94_003D()
	{
		double u = _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D];
		_0023_003DziP9fFuA_003D.FindSpanMult(u, _0023_003DzB68dg9Q_003D, out var k, out var _);
		k -= _0023_003DzB68dg9Q_003D;
		Curve curve = new Curve();
		curve.Resize(_0023_003DzMv2C5Tm1QMvc() - k, _0023_003DzB68dg9Q_003D);
		int num = _0023_003DzMv2C5Tm1QMvc() - 1;
		int num2 = curve._0023_003DzMv2C5Tm1QMvc() - 1;
		while (num2 >= 0)
		{
			curve.Pw[num2] = (Point4D)Pw[num].Clone();
			num2--;
			num--;
		}
		num = _0023_003DziP9fFuA_003D.Length - 1;
		num2 = curve._0023_003DziP9fFuA_003D.Length - 1;
		while (num2 >= 0)
		{
			curve._0023_003DziP9fFuA_003D[num2] = _0023_003DziP9fFuA_003D[num];
			num2--;
			num--;
		}
		curve._0023_003DziP9fFuA_003D[0] = curve._0023_003DziP9fFuA_003D[1];
		_0023_003DziP9fFuA_003D = curve._0023_003DziP9fFuA_003D;
		Pw = curve.Pw;
	}

	private void _0023_003Dz_Ezzqlk_003D()
	{
		double u = _0023_003DziP9fFuA_003D[_0023_003DzMv2C5Tm1QMvc()];
		_0023_003DziP9fFuA_003D.FindSpanMult(u, _0023_003DzB68dg9Q_003D, out var k, out var _);
		Curve curve = (Curve)Clone();
		k -= _0023_003DzB68dg9Q_003D;
		curve.ResizeKeep(k + 1, _0023_003DzB68dg9Q_003D);
		curve._0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D + 1] = curve._0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D];
		_0023_003DziP9fFuA_003D = curve._0023_003DziP9fFuA_003D;
		Pw = curve.Pw;
	}

	public virtual bool SubCurve(double uStart, double uEnd, out ICurve sub)
	{
		sub = null;
		if (!Circle._0023_003DzJUU5L0s5zlzq(IsClosed, Domain.Low, Domain.High, Domain.Length, ref uStart, ref uEnd))
		{
			return false;
		}
		ICurve upper;
		if (uStart > Domain.Low && !Utility._0023_003DzuW42NHK3HaLL(uStart, Domain.Low, Domain.Length))
		{
			if (!SplitAt(uStart, out var _, out upper))
			{
				return false;
			}
		}
		else
		{
			upper = this;
		}
		if (uEnd < Domain.High && !Utility._0023_003DzuW42NHK3HaLL(uEnd, Domain.High, Domain.Length))
		{
			if (!((Curve)upper).SplitAt(uEnd, out var lower2, out var _))
			{
				return false;
			}
			sub = lower2;
		}
		else
		{
			sub = upper;
		}
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	public virtual bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		sub = null;
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		if (SubCurve(t, t2, out var sub2))
		{
			sub = sub2;
			return true;
		}
		return false;
	}

	public ICurve[] GetIndividualCurves()
	{
		return new ICurve[1] { this };
	}

	public Curve[] SplitAtDiscontinuities(bool speedChange)
	{
		Curve curve = (Curve)Clone();
		Curve _0023_003DzWQkHZg1gwsuM = null;
		List<Curve> list = new List<Curve>();
		for (int i = 1; i < curve._0023_003DziP9fFuA_003D.Length; i++)
		{
			if (curve._0023_003DziP9fFuA_003D[i - 1] == curve._0023_003DziP9fFuA_003D[i])
			{
				continue;
			}
			curve._0023_003DziP9fFuA_003D.FindSpanMult(curve._0023_003DziP9fFuA_003D[i], curve._0023_003DzB68dg9Q_003D, out var k, out var s);
			if (s == curve._0023_003DzB68dg9Q_003D && _0023_003Dzm_002467cql83pi7(k, curve, speedChange, 1.1))
			{
				curve._0023_003Dz6FU3i3VDkaNvS1Iafw_003D_003D(k, out var _0023_003Dzj9kq7RRev6fS, out _0023_003DzWQkHZg1gwsuM);
				_0023_003Dzj9kq7RRev6fS.CopyAttributes(this);
				_0023_003DzWQkHZg1gwsuM.CopyAttributes(this);
				_0023_003Dzj9kq7RRev6fS._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
				_0023_003DzWQkHZg1gwsuM._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
				if (this is TrimCurve)
				{
					list.Add(_0023_003Dzj9kq7RRev6fS.GetTrimCurve());
				}
				else
				{
					list.Add(_0023_003Dzj9kq7RRev6fS);
				}
				curve = _0023_003DzWQkHZg1gwsuM;
				i = 0;
			}
		}
		if (_0023_003DzWQkHZg1gwsuM != null)
		{
			_0023_003DzWQkHZg1gwsuM._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
			if (this is TrimCurve)
			{
				list.Add(_0023_003DzWQkHZg1gwsuM.GetTrimCurve());
			}
			else
			{
				list.Add(_0023_003DzWQkHZg1gwsuM);
			}
			return list.ToArray();
		}
		if (list.Count > 0)
		{
			return list.ToArray();
		}
		return new Curve[1] { this };
	}

	private static bool _0023_003Dzm_002467cql83pi7(int _0023_003DzN6G05Lg_003D, Curve _0023_003Dz8fpRyMu9aKjE, bool _0023_003DzQQqyjZIQxWuPGdcfVw_003D_003D, double _0023_003Dzniu7ZipTGeP6)
	{
		Interval interval = new Interval(_0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D[_0023_003DzN6G05Lg_003D - _0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D], _0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D[_0023_003DzN6G05Lg_003D]);
		Interval interval2 = new Interval(_0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D[_0023_003DzN6G05Lg_003D], _0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D[_0023_003DzN6G05Lg_003D + _0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D]);
		Vector3D obj = (Vector3D)_0023_003Dz8fpRyMu9aKjE.Evaluate(interval.High - interval.Length * 1E-09, 1)[1].Clone();
		double length = obj.Length;
		obj.Normalize();
		Vector3D vector3D = (Vector3D)_0023_003Dz8fpRyMu9aKjE.Evaluate(interval2.Low, 1)[1].Clone();
		double length2 = vector3D.Length;
		vector3D.Normalize();
		if (Math.Abs(Vector3D.Dot(obj, vector3D) - 1.0) > Utility._0023_003Dzjyaz_Vfaky9X)
		{
			return true;
		}
		if (_0023_003DzQQqyjZIQxWuPGdcfVw_003D_003D && Math.Max(length, length2) / Math.Min(length, length2) > _0023_003Dzniu7ZipTGeP6)
		{
			return true;
		}
		return false;
	}

	internal void _0023_003Dzj12UrcVzpdm69cC9wcXWshYi0RL9(List<Curve> _0023_003DzTj1oJWREOpXS, int _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D, double _0023_003DzJZgKl_0024PuDaYi)
	{
		if (_0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D > _0023_003DzB68dg9Q_003D)
		{
			throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963879), _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D, _0023_003DzB68dg9Q_003D));
		}
		double num = Math.Cos(_0023_003DzJZgKl_0024PuDaYi);
		int j;
		int m;
		bool flag = _0023_003DziP9fFuA_003D.FindMultipleKnots(_0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D - _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D + 1, out j, out m);
		if (!flag)
		{
			flag = _0023_003DzDlKVkyqd4UD8(1E-18, out j, out m);
		}
		if (flag)
		{
			if (m < _0023_003DzB68dg9Q_003D)
			{
				InsertKnot(_0023_003DziP9fFuA_003D[j], _0023_003DzB68dg9Q_003D);
				j += _0023_003DzB68dg9Q_003D - m;
			}
			if (_0023_003DzJZgKl_0024PuDaYi <= 0.0 || _0023_003DzH0pjSO_k8siOM2O4uA_003D_003D(Pw, j - _0023_003DzB68dg9Q_003D) < num)
			{
				_0023_003Dz6FU3i3VDkaNvS1Iafw_003D_003D(j, out var _0023_003Dzj9kq7RRev6fS, out var _0023_003DzWQkHZg1gwsuM);
				_0023_003Dzj9kq7RRev6fS._0023_003Dzj12UrcVzpdm69cC9wcXWshYi0RL9(_0023_003DzTj1oJWREOpXS, _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D, _0023_003DzJZgKl_0024PuDaYi);
				_0023_003DzWQkHZg1gwsuM._0023_003Dzj12UrcVzpdm69cC9wcXWshYi0RL9(_0023_003DzTj1oJWREOpXS, _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D, _0023_003DzJZgKl_0024PuDaYi);
				return;
			}
		}
		_0023_003DzTj1oJWREOpXS.Add(this);
	}

	private bool _0023_003DzDlKVkyqd4UD8(double _0023_003DzT2I49JGvQcku, out int _0023_003DzN6G05Lg_003D, out int _0023_003DzkKfJheA_003D)
	{
		int num = _0023_003DzQL_MgZsyInTs(Pw, 0, 1, _0023_003DzT2I49JGvQcku);
		int num2 = _0023_003DzQL_MgZsyInTs(Pw, Pw.Length - 1, -1, _0023_003DzT2I49JGvQcku);
		int num3 = 0;
		for (int i = num; i <= num2; i++)
		{
			if ((Pw[i + 1]._0023_003Dz53cmpTHe6Yih() - Pw[i]._0023_003Dz53cmpTHe6Yih())._0023_003DzEi_F9g8kJ9d2() <= _0023_003DzT2I49JGvQcku)
			{
				num3++;
			}
			else if (num3 != 0)
			{
				_0023_003DzN6G05Lg_003D = (2 * i + _0023_003DzB68dg9Q_003D + 1 - num3) / 2;
				_0023_003DzkKfJheA_003D = _0023_003DziP9fFuA_003D.Multiplicity(ref _0023_003DzN6G05Lg_003D);
				if (_0023_003DzN6G05Lg_003D > _0023_003DzB68dg9Q_003D && _0023_003DzN6G05Lg_003D < _0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D && _0023_003DzkKfJheA_003D + num3 >= _0023_003DzB68dg9Q_003D)
				{
					return true;
				}
				num3 = 0;
			}
		}
		_0023_003DzN6G05Lg_003D = 0;
		_0023_003DzkKfJheA_003D = 0;
		return false;
	}

	private int _0023_003DzQL_MgZsyInTs(Point4D[] _0023_003DzFduYrbQ_003D, int _0023_003DzyzK8swU_003D, int _0023_003Dzryar1ZU_003D, double _0023_003DzT2I49JGvQcku)
	{
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzFduYrbQ_003D[_0023_003DzyzK8swU_003D]._0023_003Dz53cmpTHe6Yih();
		double num = 0.0;
		while (num <= _0023_003DzT2I49JGvQcku && (_0023_003DzyzK8swU_003D += _0023_003Dzryar1ZU_003D) >= 0 && _0023_003DzyzK8swU_003D < _0023_003DzFduYrbQ_003D.Length)
		{
			num = (_0023_003DzFduYrbQ_003D[_0023_003DzyzK8swU_003D]._0023_003Dz53cmpTHe6Yih() - _0023_003Dz1v6oPQk_003D)._0023_003DzEi_F9g8kJ9d2();
		}
		return _0023_003DzyzK8swU_003D;
	}

	public Curve[] SplitAtDiscontinuities(int smoothness = 1, double minAngle = 0.0)
	{
		List<Curve> list = new List<Curve>();
		((Curve)Clone())._0023_003Dzj12UrcVzpdm69cC9wcXWshYi0RL9(list, smoothness, minAngle);
		return list.ToArray();
	}

	private static double _0023_003DzH0pjSO_k8siOM2O4uA_003D_003D(Point4D[] _0023_003DzFduYrbQ_003D, int _0023_003Dz437_00244ak_003D)
	{
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzjbqS1qE_003D = _0023_003DzFduYrbQ_003D[_0023_003Dz437_00244ak_003D]._0023_003Dz53cmpTHe6Yih();
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzjbqS1qE_003D2 = _0023_003DzjbqS1qE_003D - _0023_003DzFduYrbQ_003D[_0023_003Dz437_00244ak_003D - 1]._0023_003Dz53cmpTHe6Yih();
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = _0023_003DzFduYrbQ_003D[_0023_003Dz437_00244ak_003D + 1]._0023_003Dz53cmpTHe6Yih() - _0023_003DzjbqS1qE_003D;
		if (_0023_003DzjbqS1qE_003D2._0023_003DzbV1eOjg_003D() == 0.0 || _0023_003Dz1v6oPQk_003D._0023_003DzbV1eOjg_003D() == 0.0)
		{
			return 1.0;
		}
		return _0023_003DzjbqS1qE_003D2 * _0023_003Dz1v6oPQk_003D;
	}

	internal void _0023_003Dz6FU3i3VDkaNvS1Iafw_003D_003D(int _0023_003DznjBEFEfYeNG_, out Curve _0023_003Dzj9kq7RRev6fS, out Curve _0023_003DzWQkHZg1gwsuM)
	{
		double num = _0023_003DziP9fFuA_003D[_0023_003DznjBEFEfYeNG_];
		_0023_003Dzj9kq7RRev6fS = new Curve();
		_0023_003DzWQkHZg1gwsuM = new Curve();
		_0023_003Dzj9kq7RRev6fS.Resize(_0023_003DznjBEFEfYeNG_ - _0023_003DzB68dg9Q_003D + 1, _0023_003DzB68dg9Q_003D);
		_0023_003DzWQkHZg1gwsuM.Resize(_0023_003DzMv2C5Tm1QMvc() - _0023_003DznjBEFEfYeNG_ + _0023_003DzB68dg9Q_003D, _0023_003DzB68dg9Q_003D);
		for (int i = 0; i < _0023_003Dzj9kq7RRev6fS._0023_003DzMv2C5Tm1QMvc(); i++)
		{
			_0023_003Dzj9kq7RRev6fS.Pw[i] = (Point4D)Pw[i].Clone();
		}
		for (int j = 0; j < _0023_003DzWQkHZg1gwsuM._0023_003DzMv2C5Tm1QMvc(); j++)
		{
			_0023_003DzWQkHZg1gwsuM.Pw[j] = (Point4D)Pw[j + _0023_003DznjBEFEfYeNG_ - _0023_003DzB68dg9Q_003D].Clone();
		}
		Array.Copy(_0023_003DziP9fFuA_003D, 0, _0023_003Dzj9kq7RRev6fS._0023_003DziP9fFuA_003D, 0, _0023_003Dzj9kq7RRev6fS._0023_003DzMv2C5Tm1QMvc());
		Array.Copy(_0023_003DziP9fFuA_003D, _0023_003DznjBEFEfYeNG_ + 1, _0023_003DzWQkHZg1gwsuM._0023_003DziP9fFuA_003D, _0023_003DzB68dg9Q_003D + 1, _0023_003DzWQkHZg1gwsuM._0023_003DzMv2C5Tm1QMvc());
		for (int k = 0; k <= _0023_003DzB68dg9Q_003D; k++)
		{
			_0023_003Dzj9kq7RRev6fS._0023_003DziP9fFuA_003D[_0023_003Dzj9kq7RRev6fS._0023_003DzMv2C5Tm1QMvc() + k] = num;
			_0023_003DzWQkHZg1gwsuM._0023_003DziP9fFuA_003D[k] = num;
		}
	}

	internal void _0023_003DzVYTmBrsvAaT9(bool _0023_003DzAqOpw0w_003D, bool _0023_003Dzk64JNOo_003D)
	{
		if (_0023_003DzAqOpw0w_003D && _0023_003Dzk64JNOo_003D && Utility.AreEqual(_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D], _0023_003DziP9fFuA_003D[_0023_003DzMv2C5Tm1QMvc()], _0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1] - _0023_003DziP9fFuA_003D[0]))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963736));
		}
		if (_0023_003DzAqOpw0w_003D)
		{
			InsertKnot(_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D], _0023_003DzB68dg9Q_003D);
			_0023_003DzBEmNb94_003D();
		}
		if (_0023_003Dzk64JNOo_003D)
		{
			InsertKnot(_0023_003DziP9fFuA_003D[_0023_003DzMv2C5Tm1QMvc()], _0023_003DzB68dg9Q_003D);
			_0023_003Dz_Ezzqlk_003D();
		}
	}

	public override void Regen(RegenParams data)
	{
		_vertices = null;
		if (_0023_003DzB68dg9Q_003D > 1)
		{
			bool flag = true;
			for (int i = 0; i < Pw.Length - 1; i++)
			{
				double num = Math.Max(Pw[i].MaximumCoordinate, Pw[i + 1].MaximumCoordinate);
				if (Pw[i].Euclid.DistanceTo(Pw[i + 1].Euclid) / num > 1E-12)
				{
					flag = false;
					_vertices = _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(this, data.Deviation, data.Angle);
					break;
				}
			}
			if (flag)
			{
				_vertices = new Point3D[1]
				{
					new PointTangentU(Pw[0].Euclid.X, Pw[0].Euclid.Y, Pw[0].Euclid.Z, 0.0, 0.0, 0.0, Domain.Left)
				};
			}
		}
		else if (_0023_003DzMv2C5Tm1QMvc() > 2)
		{
			_vertices = new Point3D[Pw.Length];
			for (int j = 0; j < Pw.Length - 1; j++)
			{
				Vector3D vector3D = new Vector3D(Pw[j], Pw[j + 1]);
				vector3D.Normalize();
				Point3D euclid = Pw[j].Euclid;
				_vertices[j] = new PointTangentU(euclid.X, euclid.Y, euclid.Z, vector3D.X, vector3D.Y, vector3D.Z, _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + j]);
			}
			Vector3D tangent = ((PointTangent)_vertices[Pw.Length - 2]).Tangent;
			Point3D euclid2 = Pw[Pw.Length - 1].Euclid;
			_vertices[Pw.Length - 1] = new PointTangentU(euclid2.X, euclid2.Y, euclid2.Z, tangent.X, tangent.Y, tangent.Z, _0023_003DziP9fFuA_003D.Last());
		}
		else
		{
			Point3D startPoint = StartPoint;
			Point3D endPoint = EndPoint;
			Vector3D vector3D2 = new Vector3D(startPoint, endPoint);
			vector3D2.Normalize();
			_vertices = new Point3D[2]
			{
				new PointTangentU(startPoint.X, startPoint.Y, startPoint.Z, vector3D2.X, vector3D2.Y, vector3D2.Z, Domain.Left),
				new PointTangentU(endPoint.X, endPoint.Y, endPoint.Z, vector3D2.X, vector3D2.Y, vector3D2.Z, Domain.Right)
			};
		}
		base.Regen(data);
	}

	internal void _0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(RegenParams _0023_003DzELu0Pss_003D, int _0023_003DzgyNPRm1lVYUG)
	{
		_vertices = new Point3D[_0023_003DzgyNPRm1lVYUG + 1];
		for (int i = 0; i < _0023_003DzgyNPRm1lVYUG + 1; i++)
		{
			double num = Domain.Low + (double)i * Domain.Length / (double)_0023_003DzgyNPRm1lVYUG;
			Point3D point3D = PointAt(num);
			Vector3D vector3D = TangentAt(num);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
	}

	internal void _0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(RegenParams _0023_003DzELu0Pss_003D, List<double> _0023_003DzHSO_00246A0_003D, double _0023_003Dz7pAiRvw_003D, double _0023_003DzqU35YqE_003D)
	{
		List<Point3D> list = new List<Point3D>();
		list.Add(new PointTangent(StartPoint.X, StartPoint.Y, StartPoint.Z, StartTangent.X, StartTangent.Y, StartTangent.Z));
		double num = _0023_003Dz7pAiRvw_003D;
		if (_0023_003Dz7pAiRvw_003D > _0023_003DzqU35YqE_003D)
		{
			_0023_003DzHSO_00246A0_003D.Reverse();
			num = _0023_003DzqU35YqE_003D;
		}
		new Interval(_0023_003Dz7pAiRvw_003D, _0023_003DzqU35YqE_003D);
		for (int i = 0; i < _0023_003DzHSO_00246A0_003D.Count; i++)
		{
			double num2 = (_0023_003DzHSO_00246A0_003D[i] - num) / Math.Abs(_0023_003DzqU35YqE_003D - _0023_003Dz7pAiRvw_003D);
			if (_0023_003Dz7pAiRvw_003D > _0023_003DzqU35YqE_003D)
			{
				num2 = 1.0 - num2;
			}
			if (!(Math.Abs(num2 - _0023_003DzqU35YqE_003D) < Utility._0023_003DzheSR8QM7q9ya) && !(Math.Abs(num2 - _0023_003Dz7pAiRvw_003D) < Utility._0023_003DzheSR8QM7q9ya))
			{
				double num3 = Domain.ParameterAt(num2);
				Point3D point3D = PointAt(num3);
				Vector3D vector3D = TangentAt(num3);
				list.Add(new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z));
			}
		}
		list.Add(new PointTangent(EndPoint.X, EndPoint.Y, EndPoint.Z, EndTangent.X, EndTangent.Y, EndTangent.Z));
		_vertices = list.ToArray();
	}

	public virtual void Reverse()
	{
		Point4D[] array = new Point4D[_0023_003DzMv2C5Tm1QMvc()];
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			array[i] = (Point4D)Pw[i].Clone();
		}
		int num = _0023_003DzMv2C5Tm1QMvc() - 1;
		for (int j = 0; j < _0023_003DzMv2C5Tm1QMvc(); j++)
		{
			Pw[num] = array[j];
			num--;
		}
		_0023_003DziP9fFuA_003D.Reverse();
		InitialPoint initialPoint = startIp;
		startIp = endIp;
		endIp = initialPoint;
		_0023_003Dz7roAELUN1jwt();
		RegenMode = regenType.RegenAndCompile;
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		_0023_003Dz7roAELUN1jwt();
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			Pw[i].TransformBy(xform);
		}
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (Pw == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964545));
			return false;
		}
		for (int i = 0; i < Pw.Length; i++)
		{
			if (Pw[i] == null || !Pw[i].IsValid())
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964518), i));
				return false;
			}
		}
		if (_0023_003DziP9fFuA_003D == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964496));
			return false;
		}
		if (!_0023_003DziP9fFuA_003D.IsValid(_0023_003DzB68dg9Q_003D, _0023_003DzMv2C5Tm1QMvc(), log))
		{
			return false;
		}
		if (_0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D + 1 != _0023_003DziP9fFuA_003D.Length)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964719));
			return false;
		}
		return true;
	}

	private bool _0023_003DzvVdETPB7voZ1kV79v9ITN2E_003D()
	{
		if (Pw == null || _0023_003DziP9fFuA_003D == null)
		{
			return false;
		}
		if (!_0023_003DziP9fFuA_003D.IsValid(_0023_003DzB68dg9Q_003D))
		{
			return false;
		}
		if (_0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D + 1 != _0023_003DziP9fFuA_003D.Length)
		{
			return false;
		}
		return true;
	}

	public Curve GetNurbsForm()
	{
		return this;
	}

	public ICurve[] ConvertToArcsAndLines()
	{
		double epsDs = Utility._0023_003DzxhnLabVjXjPg * ControlLength();
		double epsLc = 0.0001 * ControlBoundingBox().Diagonal;
		ICurve[] array = ConvertToArcsAndLines(epsDs, epsLc, 0.01);
		ICurve[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			((Entity)array2[i]).CopyAttributes(this);
		}
		return array;
	}

	internal ICurve[] _0023_003DzPv3t3HnYpvENqzdrlg_003D_003D(double[] _0023_003Dzjm85u4E_003D)
	{
		double num = ControlLength();
		List<double> list = new List<double>(2 * _0023_003Dzjm85u4E_003D.Length);
		for (int i = 0; i < _0023_003Dzjm85u4E_003D.Length; i++)
		{
			list.Add(_0023_003Dzjm85u4E_003D[i]);
			double num2 = Domain.Max - _0023_003Dzjm85u4E_003D[i];
			if (i == _0023_003Dzjm85u4E_003D.Length - 1 && Math.Abs(num2) > 1E-12)
			{
				list.Add(_0023_003Dzjm85u4E_003D[i] + num2 / 2.0);
			}
			else if (i < _0023_003Dzjm85u4E_003D.Length - 1)
			{
				list.Add(_0023_003Dzjm85u4E_003D[i] + (_0023_003Dzjm85u4E_003D[i + 1] - _0023_003Dzjm85u4E_003D[i]) / 2.0);
			}
		}
		List<ICurve> list2 = new List<ICurve>();
		if (!Utility._0023_003DzftzqUl9H6tLy(this, list, list2))
		{
			list2.Add(this);
		}
		double diagonal = ControlBoundingBox().Diagonal;
		double num3 = 1E-06 * num;
		double num4 = 1E-06 * diagonal;
		double epsAt = 0.01;
		int num5 = ((!(Math.Abs(list[0] - Domain.Min) < 1E-12)) ? 1 : 0);
		List<ICurve> list3 = new List<ICurve>();
		for (int j = 0; j < list2.Count; j++)
		{
			Curve nurbsForm = list2[j].GetNurbsForm();
			double epsDs = num3;
			double epsLc = num4;
			ICurve[] array = nurbsForm.ConvertToArcsAndLines(epsDs, epsLc, epsAt);
			if (j % 2 != num5 && array[^1] is Arc arc)
			{
				array[^1] = new Arc(nurbsForm.EndPoint, arc.MidPoint, arc.StartPoint, flip: false);
				array[^1].Reverse();
			}
			list3.AddRange(array);
		}
		if (list3.Count > 1 && list3[list3.Count - 1] is Arc arc2)
		{
			list3[list3.Count - 1] = new Arc(EndPoint, arc2.MidPoint, arc2.StartPoint, flip: false);
			list3[list3.Count - 1].Reverse();
		}
		return list3.ToArray();
	}

	public ICurve[] ConvertToArcsAndLines(double epsDs, double epsLc, double epsAt)
	{
		_0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D CS_0024_003C_003E8__locals18 = new _0023_003DzsjmdJiMn6lCOSZovnXv6Z3w_003D();
		CS_0024_003C_003E8__locals18._0023_003DzVvcDDAwNH6GS = epsDs;
		CS_0024_003C_003E8__locals18._0023_003DzxbA7__gYkoBv = epsAt;
		List<ICurve> list = new List<ICurve>();
		CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D = Decompose();
		CS_0024_003C_003E8__locals18._0023_003DzgYclArUg9YyW = new ICurve[CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D.Length][];
		CS_0024_003C_003E8__locals18._0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D = epsLc * epsLc;
		if (CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D.Length == 1)
		{
			return CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D[0]._0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(CS_0024_003C_003E8__locals18._0023_003DzVvcDDAwNH6GS, CS_0024_003C_003E8__locals18._0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzxbA7__gYkoBv);
		}
		Parallel.For(0, CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D.Length, delegate(int _0023_003Dz437_00244ak_003D)
		{
			CS_0024_003C_003E8__locals18._0023_003DzgYclArUg9YyW[_0023_003Dz437_00244ak_003D] = CS_0024_003C_003E8__locals18._0023_003Dzl3vb6BBnjBLoKZKKlAXQWgI_003D[_0023_003Dz437_00244ak_003D]._0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(CS_0024_003C_003E8__locals18._0023_003DzVvcDDAwNH6GS, CS_0024_003C_003E8__locals18._0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzxbA7__gYkoBv);
		});
		ICurve[][] _0023_003DzgYclArUg9YyW = CS_0024_003C_003E8__locals18._0023_003DzgYclArUg9YyW;
		foreach (ICurve[] collection in _0023_003DzgYclArUg9YyW)
		{
			list.AddRange(collection);
		}
		return list.ToArray();
	}

	private ICurve[] _0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(double _0023_003DzVvcDDAwNH6GS, double _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, double _0023_003DzxbA7__gYkoBv)
	{
		if (_0023_003Dz736ekIs_003D() < 0.001)
		{
			return new ICurve[1]
			{
				new Line(Pw[0].Euclid, Pw[Pw.Length - 1].Euclid)
			};
		}
		if (TryGetArc(out var arc))
		{
			return new ICurve[1] { arc };
		}
		if (TryGetLine(out var ln))
		{
			return new ICurve[1] { ln };
		}
		List<ICurve> list = new List<ICurve>();
		ICurve _0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D;
		switch (_0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(out _0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D, _0023_003DzVvcDDAwNH6GS, _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, _0023_003DzxbA7__gYkoBv))
		{
		case (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)1:
		case (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)2:
			list.Add(_0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D);
			break;
		case (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)0:
		{
			SplitAt(Domain.Mid, out var lower, out var upper);
			if (lower != null)
			{
				list.AddRange(lower.GetNurbsForm()._0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(_0023_003DzVvcDDAwNH6GS, _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, _0023_003DzxbA7__gYkoBv));
			}
			if (upper != null)
			{
				list.AddRange(upper.GetNurbsForm()._0023_003DzJ9VEr7PeerAbSXvxmJ_b4ag_003D(_0023_003DzVvcDDAwNH6GS, _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, _0023_003DzxbA7__gYkoBv));
			}
			break;
		}
		}
		return list.ToArray();
	}

	private _0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D _0023_003Dzh7hGHKctKQZFDBseCg_003D_003D(out ICurve _0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D, double _0023_003DzVvcDDAwNH6GS, double _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D, double _0023_003DzxbA7__gYkoBv)
	{
		_0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D = null;
		double num = _0023_003Dz736ekIs_003D();
		Point3D startPoint = StartPoint;
		Point3D endPoint = EndPoint;
		Line line = new Line((Point3D)startPoint.Clone(), (Point3D)endPoint.Clone());
		if (num < _0023_003DzVvcDDAwNH6GS)
		{
			_0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D = line;
			return (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)1;
		}
		Point3D point3D = PointAt(Domain.Mid);
		Vector3D startTangent = StartTangent;
		Vector3D endTangent = EndTangent;
		if (Vector3D.AreParallel(startTangent, endTangent))
		{
			if (num - Point3D.Distance(startPoint, endPoint) < _0023_003DzVvcDDAwNH6GS && Point3D.DistanceSquared(point3D, line.MidPoint) < _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D)
			{
				_0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D = line;
				return (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)1;
			}
			return (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)0;
		}
		Vector3D vector3D = (Vector3D)startTangent.Clone();
		Vector3D vector3D2 = (Vector3D)endTangent.Clone();
		vector3D.Normalize();
		vector3D2.Normalize();
		Plane plane = new Plane(startPoint, point3D, endPoint);
		Line line2 = new Line(Point3D.Origin, Vector3D.Cross(vector3D, plane.AxisZ).AsPoint);
		Line line3 = new Line(Point3D.Origin, Vector3D.Cross(vector3D2, plane.AxisZ).AsPoint);
		line2.TransformBy(new Translation(startPoint.AsVector));
		line3.TransformBy(new Translation(endPoint.AsVector));
		Segment3D segA = new Segment3D(line2.StartPoint, line2.EndPoint);
		Segment3D segB = new Segment3D(line3.StartPoint, line3.EndPoint);
		if (Segment3D.Intersection(segA, segB, infinite: true, out var pointOnA, out var _) && pointOnA != startPoint && pointOnA != endPoint)
		{
			Arc arc = new Arc(pointOnA, startPoint, endPoint);
			if (Point3D.DistanceSquared(point3D, arc.MidPoint) < _0023_003DzPR1H_w8brRcLJNqtbQ_003D_003D && num - arc.Length() < _0023_003DzVvcDDAwNH6GS && Vector3D.AreCoincident(arc.EndTangent, endTangent, _0023_003DzxbA7__gYkoBv))
			{
				_0023_003Dz6IJZEqFRJcrPoXctWO5HG2E_003D = arc;
				return (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)2;
			}
		}
		return (_0023_003DzXzDCcu8qMSOV1kptQHSO8Ek_003D)0;
	}

	public double Length()
	{
		if (_0023_003DzMv2C5Tm1QMvc() == 2 && _0023_003DzB68dg9Q_003D == 1)
		{
			return Pw[0].DistanceTo(Pw[1]);
		}
		double num = 0.0;
		Curve[] array = Decompose();
		foreach (Curve curve in array)
		{
			num += curve._0023_003Dz736ekIs_003D();
		}
		return num;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.Append(IsValid() ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964652) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964667));
		stringBuilder.Append(IsClosed ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964611) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964631));
		stringBuilder.Append(IsRational ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964325) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964337));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964309));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendLine(string.Concat(str3: IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var _) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964049) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964069), str0: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963339), str1: Utility._0023_003DzheSR8QM7q9ya.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425)), str2: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964092)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956065) + StartPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956056) + EndPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964292) + _0023_003DzB68dg9Q_003D);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964276) + _0023_003DzMv2C5Tm1QMvc());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964242) + Domain.Low.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964238) + Domain.High.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963264) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp = false)
	{
		Curve nurbsForm = GetNurbsForm();
		Plane plane2;
		Segment3D line;
		Curve _0023_003Dz6nnnQo75Qjsf;
		if (planeNormal == null)
		{
			if (!IsPlanar(Utility._0023_003DzxhnLabVjXjPg, out var plane))
			{
				return Array.Empty<ICurve>();
			}
			planeNormal = plane.AxisZ;
		}
		else if ((!IsPlanar(Utility._0023_003DzxhnLabVjXjPg, out plane2) || !Vector3D.AreParallel(plane2.AxisZ, planeNormal / planeNormal.Length)) && !IsLinear(Utility._0023_003DzxhnLabVjXjPg, out line))
		{
			return new ICurve[1] { nurbsForm._0023_003Dz3JJdLbUPbfbS(amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf) };
		}
		List<ICurve> list = new List<ICurve>();
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		double num = new Size3D(boxMin, boxMax).Diagonal * 1E-05;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		Curve[] array = SplitAtDiscontinuities();
		List<ICurve> list2 = new List<ICurve>();
		Curve[] array2 = array;
		foreach (Curve curve in array2)
		{
			if (curve.IsLinear(num, out line))
			{
				Curve curve2 = (Curve)curve.Clone();
				Vector3D vector3D = Vector3D.Cross(curve.StartTangent, planeNormal);
				vector3D.Normalize();
				curve2.Translate(amount * vector3D);
				list2.Add(curve2);
			}
			else
			{
				list2.Add(curve._0023_003Dz3JJdLbUPbfbS(amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf));
			}
		}
		List<ICurve> list3 = new List<ICurve>();
		List<Region> list4 = new List<Region>();
		for (int j = 0; j < list2.Count; j++)
		{
			if (j == 0)
			{
				if (IsClosed)
				{
					list3.AddRange(nurbsForm._0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(list2.Last(), list2[0], array[0].StartPoint, amount, planeNormal, sharp, num, list4));
				}
			}
			else
			{
				list3.AddRange(nurbsForm._0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(list2[j - 1], list2[j], array[j].StartPoint, amount, planeNormal, sharp, num, list4));
			}
			if (list2[j] is Line || list2[j] is Arc)
			{
				list3.Add(list2[j]);
				continue;
			}
			Point3D[] source = _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(list2[j].GetNurbsForm(), 0.0, Math.PI);
			nurbsForm._0023_003DzpMCmhFs8nshmeFe5OQ_003D_003D(amount, num, source.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzJ_o6lAGHlRviLKG5nA_003D_003D).ToArray(), list2[j], list3, planeNormal, new Region[0], nurbsForm._0023_003DzQhzLqGmR4kjmOmQDvoMDSKg_003D);
		}
		if (((Entity)list3[0]).EntityData != null && (int)((Entity)list3[0]).EntityData == 0)
		{
			ICurve item = list3[0];
			list3.Add(item);
			list3.RemoveAt(0);
		}
		List<double>[] array3 = new List<double>[list3.Count];
		for (int k = 0; k < array3.Length; k++)
		{
			array3[k] = new List<double>();
		}
		for (int l = 0; l < list3.Count; l++)
		{
			ICurve curve3 = list3[l];
			for (int m = l + 1; m < list3.Count; m++)
			{
				ICurve curve4 = list3[m];
				foreach (InterPoint item2 in curve3.IntersectWith(curve4).Cast<InterPoint>().ToList())
				{
					if (item2.u > curve3.Domain.Left && item2.u < curve3.Domain.Right)
					{
						array3[l].Add(item2.u);
					}
					if (item2.s > curve4.Domain.Left && item2.s < curve4.Domain.Right)
					{
						array3[m].Add(item2.s);
					}
				}
				list3[l] = curve3;
			}
		}
		if (!IsClosed)
		{
			Circle circle = new Circle(new Plane(planeNormal), StartPoint, Math.Abs(amount));
			Circle circle2 = new Circle(new Plane(planeNormal), EndPoint, Math.Abs(amount));
			Curve curve5 = nurbsForm._0023_003Dz3JJdLbUPbfbS(0.0 - amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf);
			for (int n = 0; n < list3.Count; n++)
			{
				ICurve curve6 = list3[n];
				foreach (InterPoint item3 in circle.IntersectWith(curve6).Cast<InterPoint>().ToList())
				{
					if (item3.s > curve6.Domain.Left && item3.s < curve6.Domain.Right)
					{
						array3[n].Add(item3.s);
					}
				}
				foreach (InterPoint item4 in circle2.IntersectWith(curve6).Cast<InterPoint>().ToList())
				{
					if (item4.s > curve6.Domain.Left && item4.s < curve6.Domain.Right)
					{
						array3[n].Add(item4.s);
					}
				}
				foreach (InterPoint item5 in curve5.IntersectWith(curve6).Cast<InterPoint>().ToList())
				{
					if (item5.s > curve6.Domain.Left && item5.s < curve6.Domain.Right)
					{
						array3[n].Add(item5.s);
					}
				}
			}
		}
		for (int num2 = 0; num2 < array3.Length; num2++)
		{
			ICurve _0023_003DzVZvuR8GIx2bc = list3[num2];
			array3[num2].Sort();
			nurbsForm._0023_003DzpMCmhFs8nshmeFe5OQ_003D_003D(amount, num, array3[num2].ToArray(), _0023_003DzVZvuR8GIx2bc, list, planeNormal, list4.ToArray(), nurbsForm._0023_003DzNWrznGBi9wJN);
		}
		if (list.Count > 0)
		{
			list = Utility.CleanDuplicates(list).ToList();
			List<List<ICurve>> list5 = new List<List<ICurve>>();
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				if (((Entity)list[num3]).EntityData != null)
				{
					((Entity)list[num3]).EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
				}
				bool flag = false;
				foreach (List<ICurve> item6 in list5)
				{
					if (Point3D.DistanceSquared(item6.Last().EndPoint, list[num3].StartPoint) < num * num)
					{
						if (sharp && list[num3] is Line && item6.Last() is Line && (((Entity)list[num3]).EntityData != null || ((Entity)item6.Last()).EntityData != null) && Vector3D.AreCoincident(list[num3].EndTangent, item6.Last().EndTangent))
						{
							item6[item6.Count - 1] = new Line(item6.Last().StartPoint, list[num3].EndPoint);
						}
						else if (list[num3] is Circle || list[num3] is Line || item6.Last() is Circle || item6.Last() is Line)
						{
							item6.Add(list[num3]);
						}
						else
						{
							item6[item6.Count - 1] = Merge(new List<ICurve>
							{
								item6.Last(),
								list[num3]
							}, clean: true, resetDomain: false);
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list5.Add(new List<ICurve> { list[num3] });
				}
			}
			ICurve[] array4 = new ICurve[list5.Count];
			for (int num4 = 0; num4 < array4.Length; num4++)
			{
				array4[num4] = Utility.SmartAdd(list5[num4]);
			}
			return array4;
		}
		return Array.Empty<ICurve>();
	}

	internal List<ICurve> _0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(ICurve _0023_003Dzfm4oGj8_003D, ICurve _0023_003DzCVdPoWM_003D, Point3D _0023_003DzcXkiOibhYRCo, double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, bool _0023_003DzalFofRO0Igsv, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, List<Region> _0023_003DzblFyLI_0024bgqPg)
	{
		List<ICurve> list = new List<ICurve>();
		if (_0023_003DzalFofRO0Igsv)
		{
			if (Point3D.DistanceSquared(_0023_003Dzfm4oGj8_003D.EndPoint, _0023_003DzCVdPoWM_003D.StartPoint) > _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D * _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				Segment3D segA = new Segment3D(_0023_003Dzfm4oGj8_003D.EndPoint, _0023_003Dzfm4oGj8_003D.EndPoint + _0023_003Dzfm4oGj8_003D.EndTangent);
				Segment3D segB = new Segment3D(_0023_003DzCVdPoWM_003D.StartPoint, _0023_003DzCVdPoWM_003D.StartPoint + _0023_003DzCVdPoWM_003D.StartTangent);
				if (Segment3D.Intersection(segA, segB, infinite: true, out var pointOnA, out var pointOnB, out var paramOnA, out var paramOnB) && (paramOnA > 0.0 || paramOnB < 0.0))
				{
					Line line = new Line(_0023_003Dzfm4oGj8_003D.EndPoint, pointOnA);
					Line line2 = new Line(pointOnB, _0023_003DzCVdPoWM_003D.StartPoint);
					_0023_003DzblFyLI_0024bgqPg.Add(new Region(new CompositeCurve(line, line2, new Line(line2.EndPoint, _0023_003DzcXkiOibhYRCo), new Line(_0023_003DzcXkiOibhYRCo, line.StartPoint))));
					line.EntityData = _0023_003DzblFyLI_0024bgqPg.Count - 1;
					list.Add(line);
					line2.EntityData = _0023_003DzblFyLI_0024bgqPg.Count - 1;
					list.Add(line2);
				}
			}
		}
		else
		{
			Arc arc = null;
			if (Point3D.DistanceSquared(_0023_003Dzfm4oGj8_003D.EndPoint, _0023_003DzCVdPoWM_003D.StartPoint) > _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D * _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				Vector3D vector3D = new Vector3D(_0023_003DzcXkiOibhYRCo, _0023_003Dzfm4oGj8_003D.EndPoint);
				Plane plane = new Plane(_0023_003DzcXkiOibhYRCo, vector3D, Vector3D.Cross(vector3D, _0023_003Dz2ouPUQ9dmipO));
				Point2D point2D = plane.Project(_0023_003Dzfm4oGj8_003D.EndPoint);
				Point2D point2D2 = plane.Project(_0023_003DzCVdPoWM_003D.StartPoint);
				double num = Vector2D.SignedAngleBetween(point2D.AsVector, point2D2.AsVector);
				arc = new Arc(plane, plane.Origin, Math.Abs(_0023_003DzYNjcavt9guh2), 0.0, num);
				if (Math.Abs(Math.Abs(num) - Math.PI) < 1E-12 && !_0023_003DzNWrznGBi9wJN(arc, _0023_003DzYNjcavt9guh2, _0023_003Dz2ouPUQ9dmipO, Array.Empty<Region>()))
				{
					arc = new Arc(plane, plane.Origin, Math.Abs(_0023_003DzYNjcavt9guh2), 0.0, 0.0 - num);
				}
			}
			if (arc != null)
			{
				list.Add(arc);
			}
		}
		return list;
	}

	public Region OffsetToRegion(double amount, bool sharp)
	{
		if (IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane))
		{
			ICurve[] array = Offset(amount, plane.AxisZ, sharp);
			ICurve curve = ((array != null) ? array[0] : null);
			ICurve curve2 = (ICurve)Clone();
			if (amount > 0.0)
			{
				curve2.Reverse();
			}
			else
			{
				curve.Reverse();
			}
			if (IsClosed)
			{
				return new Region(new ICurve[2] { curve2, curve }, plane);
			}
			Line line = new Line(curve.EndPoint, curve2.StartPoint);
			Line line2 = new Line(curve2.EndPoint, curve.StartPoint);
			Region region = new Region(new CompositeCurve(new ICurve[4] { line, curve2, line2, curve }, sortAndOrient: false), plane, sortAndOrient: false);
			region.CopyAttributes(this);
			return region;
		}
		return null;
	}

	public Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		return _0023_003DzDGV7AEB1_5Oo486HnA_003D_003D(this, length);
	}

	internal static Point3D[] _0023_003DzDGV7AEB1_5Oo486HnA_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz736ekIs_003D)
	{
		double num = _0023_003Dz8fpRyMu9aKjE.Length();
		double num2 = num / _0023_003Dz736ekIs_003D;
		int num3 = (int)Math.Ceiling(num2);
		int num4 = (int)Math.Truncate(num2);
		int num5 = ((num2 - (double)num4 < _0023_003Dz736ekIs_003D * Utility._0023_003DzxhnLabVjXjPg) ? num4 : num3);
		double t;
		if (_0023_003Dz8fpRyMu9aKjE.IsClosed && num5 < 3)
		{
			double num6 = num / 3.0;
			_0023_003Dz8fpRyMu9aKjE.GetParamFromLength(num6, out t);
			Point3D point3D = _0023_003Dz8fpRyMu9aKjE.PointAt(t);
			_0023_003Dz8fpRyMu9aKjE.GetParamFromLength(num6 * 2.0, out t);
			Point3D point3D2 = _0023_003Dz8fpRyMu9aKjE.PointAt(t);
			return new Point3D[4] { _0023_003Dz8fpRyMu9aKjE.StartPoint, point3D, point3D2, _0023_003Dz8fpRyMu9aKjE.EndPoint };
		}
		if (num5 < 2)
		{
			return new Point3D[2] { _0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz8fpRyMu9aKjE.EndPoint };
		}
		Point3D[] array = new Point3D[num5 + 1];
		double num7 = num / (double)num5;
		if (_0023_003Dz8fpRyMu9aKjE is Curve)
		{
			Vector3D[] array2 = ((Curve)_0023_003Dz8fpRyMu9aKjE).Evaluate(_0023_003Dz8fpRyMu9aKjE.Domain.Low, 1);
			array[0] = new PointTangent(array2[0].X, array2[0].Y, array2[0].Z, array2[1].X, array2[1].Y, array2[1].Z);
		}
		else
		{
			array[0] = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.Low);
		}
		for (int i = 1; i < num5 + 1; i++)
		{
			_0023_003Dz8fpRyMu9aKjE.GetParamFromLength((double)i * num7, out t);
			if (_0023_003Dz8fpRyMu9aKjE is Curve)
			{
				Vector3D[] array3 = ((Curve)_0023_003Dz8fpRyMu9aKjE).Evaluate(t, 1);
				array[i] = new PointTangent(array3[0].X, array3[0].Y, array3[0].Z, array3[1].X, array3[1].Y, array3[1].Z);
			}
			else
			{
				array[i] = _0023_003Dz8fpRyMu9aKjE.PointAt(t);
			}
		}
		return array;
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		return GetPointsByLength(length);
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		if (_0023_003DzB68dg9Q_003D == 1)
		{
			ControlBoundingBox(out boxMin, out boxMax);
		}
		else
		{
			_0023_003DzsI4cshiY2dMCzaiiuPPsUu4_003D(out boxMin, out boxMax);
		}
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		double num = double.MaxValue;
		closestPointOnFirst = null;
		closestPointOnSecond = null;
		Curve[] array = SplitAtDiscontinuities(speedChange: false);
		foreach (Curve a in array)
		{
			if (curve is CompositeCurve)
			{
				ICurve[] individualCurves = curve.GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					Curve[] array2 = individualCurves[j].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
					foreach (Curve b in array2)
					{
						MinimumDistance minimumDistance = new MinimumDistance(a, b);
						minimumDistance.DoWork();
						if (minimumDistance.Result.Length < num)
						{
							num = minimumDistance.Result.Length;
							closestPointOnFirst = new Point3D[1] { minimumDistance.Result.P0 };
							closestPointOnSecond = new Point3D[1] { minimumDistance.Result.P1 };
						}
					}
				}
				continue;
			}
			Curve[] array3 = curve.GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
			foreach (Curve b2 in array3)
			{
				MinimumDistance minimumDistance2 = new MinimumDistance(a, b2);
				minimumDistance2.DoWork();
				if (minimumDistance2.Result.Length < num)
				{
					num = minimumDistance2.Result.Length;
					closestPointOnFirst = new Point3D[1] { minimumDistance2.Result.P0 };
					closestPointOnSecond = new Point3D[1] { minimumDistance2.Result.P1 };
				}
			}
		}
		return num;
	}

	public bool IsLinear(double tol, out Segment3D line)
	{
		if (Pw.Length == 2)
		{
			line = new Segment3D(Pw[0].Euclid, Pw[1].Euclid);
			return true;
		}
		int num = Pw.Length;
		line = null;
		if (IsClosed || num < 2)
		{
			return false;
		}
		if (tol <= 0.0)
		{
			tol = 1E-12;
		}
		double num2 = double.MinValue;
		Segment3D segment3D = null;
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc() - 1; i++)
		{
			Segment3D segment3D2 = new Segment3D(Pw[i].Euclid, Pw[i + 1].Euclid);
			double lengthSquared = segment3D2.LengthSquared;
			if (lengthSquared > num2)
			{
				segment3D = segment3D2;
				num2 = lengthSquared;
			}
		}
		if (segment3D != null)
		{
			if (segment3D.IsPoint)
			{
				return false;
			}
			double num3 = tol * tol;
			Point4D[] pw = Pw;
			for (int j = 0; j < pw.Length; j++)
			{
				Point3D euclid = pw[j].Euclid;
				double t = segment3D.Project(euclid);
				if (Point3D.DistanceSquared(euclid, segment3D.PointAt(t)) > num3)
				{
					return false;
				}
			}
		}
		line = new Segment3D(StartPoint, EndPoint);
		return true;
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = null;
		bool flag = false;
		EvaluateTangent(Domain.Low, out var point, out var tangent);
		if (IsLinear(tol, out var _))
		{
			Line line2 = new Line(point, EndPoint);
			if (!line2.InPlane(out plane, tol))
			{
				line2.InPlane(out plane, 0.0);
			}
			flag = true;
		}
		else if (_0023_003DzMv2C5Tm1QMvc() >= 3)
		{
			Point3D q = point;
			Point3D r = point;
			double num = 0.0;
			int num2 = _0023_003DzMv2C5Tm1QMvc() / 64;
			if (num2 < 1)
			{
				num2 = 1;
			}
			for (int i = 1; i < _0023_003DzMv2C5Tm1QMvc(); i += num2)
			{
				Point3D euclid = Pw[i].Euclid;
				for (int j = i + num2; j < _0023_003DzMv2C5Tm1QMvc(); j += num2)
				{
					Point3D euclid2 = Pw[j].Euclid;
					double length = Vector3D.Cross(Vector3D.Subtract(euclid, point), Vector3D.Subtract(euclid2, point)).Length;
					if (length > num)
					{
						num = length;
						q = euclid;
						r = euclid2;
					}
				}
			}
			Plane plane2 = new Plane();
			if (plane2.CreateFromPoints(point, q, r))
			{
				Vector2D vector2D = new Vector2D(tangent * plane2.AxisX, tangent * plane2.AxisY);
				if (vector2D.Normalize())
				{
					if (Math.Abs(vector2D.Y) <= 1.490116119385E-08)
					{
						vector2D.X = ((vector2D.X >= 0.0) ? 1.0 : (-1.0));
						vector2D.Y = 0.0;
					}
					else if (Math.Abs(vector2D.X) <= 1.490116119385E-08)
					{
						vector2D.Y = ((vector2D.Y >= 0.0) ? 1.0 : (-1.0));
						vector2D.X = 0.0;
					}
					tangent = plane2.AxisX;
					Vector3D axisY = plane2.AxisY;
					Vector3D x = vector2D.X * tangent + vector2D.Y * axisY;
					Vector3D y = vector2D.X * axisY - vector2D.Y * tangent;
					plane2 = new Plane(plane2.Origin, x, y);
				}
				flag = IsInPlane(plane2, tol);
				if (flag)
				{
					if (!IsClosed)
					{
						plane = plane2;
					}
					else
					{
						if (Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(this, plane2))
						{
							plane2.Flip();
						}
						plane = plane2;
					}
				}
			}
		}
		return flag;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		bool flag = IsValid();
		int num = 0;
		while (flag && num < _0023_003DzMv2C5Tm1QMvc())
		{
			Point3D euclid = Pw[num].Euclid;
			if (Math.Abs(plane.DistanceTo(euclid)) > tol)
			{
				flag = false;
				break;
			}
			num++;
		}
		return flag;
	}

	internal int _0023_003DzKxlE1oQ_003D()
	{
		return _0023_003DziP9fFuA_003D.SpanCount(_0023_003DzB68dg9Q_003D, _0023_003DzMv2C5Tm1QMvc());
	}

	internal int _0023_003Dz85p_8V2nSlkt(int _0023_003Dz437_00244ak_003D)
	{
		return _0023_003DziP9fFuA_003D.Multiplicity(_0023_003Dz437_00244ak_003D);
	}

	public override Size3D ControlBoundingBox()
	{
		Utility._0023_003Dz61B8IYSGx6wG(Pw, _0023_003DzMv2C5Tm1QMvc(), out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
		return new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
	}

	public override void ControlBoundingBox(out Point3D min, out Point3D max)
	{
		Utility._0023_003Dz61B8IYSGx6wG(Pw, _0023_003DzMv2C5Tm1QMvc(), out min, out max);
	}

	public double ControlLength()
	{
		double num = 0.0;
		double[] array = new double[_0023_003DzMv2C5Tm1QMvc() - 1];
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc() - 1; i++)
		{
			array[i] = Point3D.Distance(Pw[i].Euclid, Pw[i + 1].Euclid);
			num += array[i];
		}
		return num;
	}

	public double ControlLengthSquared()
	{
		double num = 0.0;
		double[] array = new double[_0023_003DzMv2C5Tm1QMvc() - 1];
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc() - 1; i++)
		{
			array[i] = Point3D.DistanceSquared(Pw[i].Euclid, Pw[i + 1].Euclid);
			num += array[i];
		}
		return num;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new CurveSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963923), _0023_003DziP9fFuA_003D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963909), _0023_003DzB68dg9Q_003D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963892), Pw);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[4]
			{
				StartPoint,
				Evaluate(Domain.Low + Domain.Length / 3.0),
				Evaluate(Domain.Low + 2.0 * Domain.Length / 3.0),
				EndPoint
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public TrimCurve GetTrimCurve()
	{
		TrimCurve trimCurve = new TrimCurve();
		trimCurve._0023_003DzB68dg9Q_003D = _0023_003DzB68dg9Q_003D;
		trimCurve._0023_003DziP9fFuA_003D = _0023_003DziP9fFuA_003D;
		trimCurve.Pw = Pw;
		trimCurve._0023_003DzbErHvVw_003D = _0023_003DzbErHvVw_003D;
		trimCurve._0023_003Dz1c2CfcL6J3Hu = _0023_003Dz1c2CfcL6J3Hu;
		trimCurve._0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D;
		trimCurve.EdgeIndex = EdgeIndex;
		trimCurve.FromBooleanIntersection = FromBooleanIntersection;
		geometricalAttributesDirty = false;
		if (_vertices != null)
		{
			int num = _vertices.Length;
			trimCurve._vertices = new Point3D[num];
			for (int i = 0; i < num; i++)
			{
				trimCurve._vertices[i] = (Point3D)_vertices[i].Clone();
			}
		}
		return trimCurve;
	}

	internal TrimCurve _0023_003DzmGgqdRaHiXdg(ICurve _0023_003DzTx2aqr8_003D)
	{
		TrimCurve trimCurve = GetTrimCurve();
		trimCurve.Edge = _0023_003DzTx2aqr8_003D;
		if (_0023_003DzTx2aqr8_003D != null && _0023_003DzTx2aqr8_003D.EdgeIndex != -1 && EdgeIndex == -1)
		{
			((ICurve)trimCurve).EdgeIndex = _0023_003DzTx2aqr8_003D.EdgeIndex;
		}
		if (_0023_003DzTx2aqr8_003D != null && _0023_003DzTx2aqr8_003D.FromBooleanIntersection)
		{
			trimCurve.FromBooleanIntersection = true;
		}
		trimCurve.EntityData = EntityData;
		return trimCurve;
	}

	internal TrimCurve _0023_003DzmGgqdRaHiXdg(ICurve _0023_003DzTx2aqr8_003D, int _0023_003DzZ69zp6t_0024u9OB)
	{
		TrimCurve trimCurve = GetTrimCurve();
		trimCurve.Edge = _0023_003DzTx2aqr8_003D;
		trimCurve.Index = _0023_003DzZ69zp6t_0024u9OB;
		trimCurve.EntityData = EntityData;
		return trimCurve;
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		if (deviation == 0.0)
		{
			return _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D();
		}
		Curve obj = (Curve)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToLinearPath();
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(amount, tolerance, meshNature);
	}

	public Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(amount, tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		Mesh[] array = _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		T[] array = _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		return _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, merge);
	}

	public T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, merge);
	}

	public Surface[] ExtrudeAsSurface(Line line)
	{
		return ExtrudeAsSurface(line.Direction);
	}

	public Surface[] ExtrudeAsSurface(double dx, double dy, double dz)
	{
		return ExtrudeAsSurface(new Vector3D(dx, dy, dz));
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = _0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		return new Surface[1] { Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve) };
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		ICurve[] array = GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
		if (array.Length > 1)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964471));
		}
		if (IsClosed)
		{
			Vector3D[] array2 = new Vector3D[2]
			{
				(Vector3D)StartTangent.Clone(),
				(Vector3D)EndTangent.Clone()
			};
			if (!Vector3D.AreCoincident(array2[0], array2[1]))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964471));
			}
		}
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = _0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Point3D[] array4;
		Brep.Edge[] array5;
		if (IsClosed)
		{
			Point3D[] array3 = new Brep.Vertex[2];
			array4 = array3;
			array5 = new Brep.Edge[3];
		}
		else
		{
			Point3D[] array3 = new Brep.Vertex[4];
			array4 = array3;
			array5 = new Brep.Edge[4];
		}
		array4[0] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.StartPoint.X, _0023_003Dz6nnnQo75Qjsf.StartPoint.Y, _0023_003Dz6nnnQo75Qjsf.StartPoint.Z);
		array4[1] = new Brep.Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
		if (!IsClosed)
		{
			array4[2] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.EndPoint.X, _0023_003Dz6nnnQo75Qjsf.EndPoint.Y, _0023_003Dz6nnnQo75Qjsf.EndPoint.Z);
			array4[3] = new Brep.Vertex(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
		}
		int num = 2;
		if (IsClosed)
		{
			num = 0;
		}
		array5[0] = new Brep.Edge((ICurve)_0023_003Dz6nnnQo75Qjsf.Clone(), 0, num);
		array5[1] = new Brep.Edge((ICurve)curve.Clone(), 1, 1 + num);
		array5[2] = new Brep.Edge(new Line((Point3D)array4[0].Clone(), (Point3D)array4[1].Clone()), 0, 1);
		if (!IsClosed)
		{
			array5[3] = new Brep.Edge(new Line((Point3D)array4[2].Clone(), (Point3D)array4[3].Clone()), 2, 3);
		}
		Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
		{
			new Brep.OrientedEdge(0),
			new Brep.OrientedEdge(IsClosed ? 2 : 3),
			new Brep.OrientedEdge(1, sense: false),
			new Brep.OrientedEdge(2, sense: false)
		};
		Surface surface = Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve);
		NurbsSurf surface2 = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		return new Brep(array4, array5, new Brep.Face[1]
		{
			new Brep.Face(surface2, new Brep.Loop(segments))
		});
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return RevolveAsSurface(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return RevolveAsSurface(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, startAngle, deltaAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, intervalAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dz789GXCk_003D(rail, tol, methodType);
	}

	public Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep[] array = Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, _0023_003DzjepEGXc_003D: true, methodType);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, merge, methodType);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz), tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval interval, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(interval.Low, interval.Length, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval interval, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(interval.Low, interval.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		Solid[] array = _0023_003DzggPwIWi3oqtM(rail, tol, _0023_003DzjepEGXc_003D: true, sweepMethod);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003DzggPwIWi3oqtM(rail, tol, merge, sweepMethod);
	}

	public void WriteCSharp(TextWriter tw, int index)
	{
		tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964448), index, Pw.Length));
		Point4D[] pw = Pw;
		foreach (Point4D point4D in pw)
		{
			tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964393), point4D.X, point4D.Y, point4D.Z, point4D.W));
		}
		tw.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964365));
		tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965112), index, _0023_003DziP9fFuA_003D.Length));
		double[] array = _0023_003DziP9fFuA_003D;
		foreach (double num in array)
		{
			tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930916), num));
		}
		tw.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964365));
		tw.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965088), _0023_003DzB68dg9Q_003D, index, index));
	}

	private protected override void _0023_003Dz7roAELUN1jwt()
	{
		base._0023_003Dz7roAELUN1jwt();
		_0023_003DziGmJqeQcL0Lt = null;
		_discontinuities = null;
	}

	internal Curve _0023_003Dz3JJdLbUPbfbS(double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, bool _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D, out Curve _0023_003Dz6nnnQo75Qjsf)
	{
		_0023_003Dz2ouPUQ9dmipO = -1.0 * (Vector3D)_0023_003Dz2ouPUQ9dmipO.Clone();
		_0023_003Dz6nnnQo75Qjsf = null;
		List<Tuple<double, Point3D, Point3D>> list = new List<Tuple<double, Point3D, Point3D>>();
		list.Add(new Tuple<double, Point3D, Point3D>(Domain.Low, null, null));
		for (int i = _0023_003DzB68dg9Q_003D + 1; i < _0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 1; i++)
		{
			if (_0023_003DziP9fFuA_003D[i + 1] - _0023_003DziP9fFuA_003D[i] > 1E-12)
			{
				list.Add(new Tuple<double, Point3D, Point3D>(_0023_003DziP9fFuA_003D[i], null, null));
				for (; _0023_003DziP9fFuA_003D[i + 1] - _0023_003DziP9fFuA_003D[i] < 1E-12; i++)
				{
				}
			}
		}
		if (list.Count < 3)
		{
			_0023_003Dz_wl_0024XyFgnPR_0024R9XeF85usbk_003D(Domain, list);
		}
		list.Add(new Tuple<double, Point3D, Point3D>(Domain.High, null, null));
		_ = ControlBoundingBox().Diagonal;
		_ = Utility._0023_003DzxhnLabVjXjPg;
		Curve curve;
		int num;
		do
		{
			for (int j = 0; j < list.Count; j++)
			{
				if (!(list[j].Item2 != null) || !(list[j].Item3 != null))
				{
					EvaluateTangent(list[j].Item1, out var point, out var tangent);
					if (!tangent.Normalize())
					{
						return null;
					}
					Vector3D vector3D = Vector3D.Cross(_0023_003Dz2ouPUQ9dmipO, tangent);
					if (!vector3D.Normalize())
					{
						return null;
					}
					Point3D item = point + vector3D * _0023_003DzYNjcavt9guh2;
					list[j] = new Tuple<double, Point3D, Point3D>(list[j].Item1, new Point3D(point.X, point.Y, point.Z), item);
				}
			}
			if (_0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D)
			{
				_0023_003Dz6nnnQo75Qjsf = _0023_003DzxfgL9OaoOs_L(list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz5yD2LPfayd5JKX2jY702QVg_003D).ToArray(), list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzJ9lQT06PrYg21cWcZHYut54_003D).ToArray(), 3);
				curve = _0023_003DzxfgL9OaoOs_L(list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzXaHuqFD0Y55Kg8KHxE3SINc_003D).ToArray(), list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7gFdTii0jcA1lgVA1GXYFKE_003D).ToArray(), 3);
				num = _0023_003DziPhQCo5zBYNt(curve, _0023_003Dz2ouPUQ9dmipO, list);
				if (num <= 0)
				{
					num = _0023_003DziPhQCo5zBYNt(_0023_003Dz6nnnQo75Qjsf, _0023_003Dz2ouPUQ9dmipO, list);
				}
			}
			else
			{
				curve = _0023_003DzxfgL9OaoOs_L(list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzN9nCroz5nXE4zJLHCkC0CGM_003D).ToArray(), list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzE82iZN2Ta7qzgU3fWTfkzFc_003D).ToArray(), 3);
				num = _0023_003DziPhQCo5zBYNt(curve, _0023_003Dz2ouPUQ9dmipO, list);
			}
		}
		while (num > 0 && list.Count < (_0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 1) * 1000);
		return curve;
	}

	internal void _0023_003DzpMCmhFs8nshmeFe5OQ_003D_003D(double _0023_003DzYNjcavt9guh2, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, double[] _0023_003Dz7xoPAyTl_0024zAJ, ICurve _0023_003DzVZvuR8GIx2bc, List<ICurve> _0023_003DzpIZC_0024x5EiUBN, Vector3D _0023_003Dz2ouPUQ9dmipO, Region[] _0023_003DzblFyLI_0024bgqPg, _0023_003DzXAaHt5piG_cE _0023_003DzWB1umEPXUHic)
	{
		double num = 0.0;
		for (int i = 0; i < _0023_003Dz7xoPAyTl_0024zAJ.Length; i++)
		{
			_0023_003DzVZvuR8GIx2bc.SplitAt(_0023_003Dz7xoPAyTl_0024zAJ[i] - num, out var lower, out var upper);
			if (lower != null && upper != null && ((Entity)_0023_003DzVZvuR8GIx2bc).EntityData != null)
			{
				((Entity)lower).EntityData = ((Entity)_0023_003DzVZvuR8GIx2bc).EntityData;
				((Entity)upper).EntityData = ((Entity)_0023_003DzVZvuR8GIx2bc).EntityData;
			}
			if (lower != null && _0023_003DzWB1umEPXUHic(lower, _0023_003DzYNjcavt9guh2, _0023_003Dz2ouPUQ9dmipO, _0023_003DzblFyLI_0024bgqPg) && lower.Length() > _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
			{
				_0023_003DzpIZC_0024x5EiUBN.Add(lower);
			}
			if (upper != null)
			{
				_0023_003DzVZvuR8GIx2bc = upper;
				if (_0023_003DzVZvuR8GIx2bc is Line)
				{
					num += lower.Domain.High;
				}
			}
		}
		if (_0023_003DzWB1umEPXUHic(_0023_003DzVZvuR8GIx2bc, _0023_003DzYNjcavt9guh2, _0023_003Dz2ouPUQ9dmipO, _0023_003DzblFyLI_0024bgqPg) && _0023_003DzVZvuR8GIx2bc.Length() > _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D / 2.0)
		{
			_0023_003DzpIZC_0024x5EiUBN.Add(_0023_003DzVZvuR8GIx2bc);
		}
	}

	internal bool _0023_003DzNWrznGBi9wJN(ICurve _0023_003DzVZvuR8GIx2bc, double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, Region[] _0023_003DzblFyLI_0024bgqPg)
	{
		object entityData = ((Entity)_0023_003DzVZvuR8GIx2bc).EntityData;
		Point3D point3D = _0023_003DzVZvuR8GIx2bc.PointAt(_0023_003DzVZvuR8GIx2bc.Domain.Mid);
		if (_0023_003DzVsK2rrKozoPt(_0023_003DzblFyLI_0024bgqPg, _0023_003DzVZvuR8GIx2bc, point3D, (entityData == null) ? (-1) : ((int)entityData)))
		{
			return false;
		}
		ClosestPointTo(point3D, out var t);
		Point3D point3D2 = PointAt(t);
		if (_0023_003DzVZvuR8GIx2bc is Line && entityData != null)
		{
			if (Point3D.Distance(point3D, point3D2) > Math.Abs(_0023_003DzYNjcavt9guh2) - Utility._0023_003DzxhnLabVjXjPg)
			{
				Vector3D vector3D = -Math.Sign(_0023_003DzYNjcavt9guh2) * Vector3D.Cross(TangentAt(t), _0023_003Dz2ouPUQ9dmipO);
				vector3D.Normalize();
				Vector3D vector3D2 = new Vector3D(point3D, point3D2);
				vector3D2.Normalize();
				if (!Vector3D.AreOpposite(vector3D, vector3D2))
				{
					return true;
				}
			}
		}
		else if (_0023_003DzVZvuR8GIx2bc is Line)
		{
			if (Math.Abs(Point3D.Distance(point3D, point3D2) - Math.Abs(_0023_003DzYNjcavt9guh2)) < Utility._0023_003DzheSR8QM7q9ya)
			{
				return true;
			}
		}
		else if (_0023_003DzVZvuR8GIx2bc is Circle)
		{
			if (Math.Abs(Point3D.Distance(point3D, point3D2) - Math.Abs(_0023_003DzYNjcavt9guh2)) < 1E-05 * _0023_003DzVZvuR8GIx2bc.Length())
			{
				return true;
			}
		}
		else if (Math.Abs(_0023_003DzVZvuR8GIx2bc.Domain.Mid - t) < 0.01 * _0023_003DzVZvuR8GIx2bc.Domain.Length)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzVsK2rrKozoPt(Region[] _0023_003DzblFyLI_0024bgqPg, ICurve _0023_003DzVZvuR8GIx2bc, Point3D _0023_003DzB68dg9Q_003D, int _0023_003Dz7zEc_h0_003D)
	{
		for (int i = 0; i < _0023_003DzblFyLI_0024bgqPg.Length; i++)
		{
			if (i != _0023_003Dz7zEc_h0_003D && (!(_0023_003DzVZvuR8GIx2bc is Line _0023_003DzOGUeWbk_003D) || !_0023_003Dz3JmDuJ2Z8MXz(_0023_003DzOGUeWbk_003D, _0023_003DzblFyLI_0024bgqPg[i])) && _0023_003DzblFyLI_0024bgqPg[i].IsPointInside(_0023_003DzB68dg9Q_003D))
			{
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003Dz3JmDuJ2Z8MXz(Line _0023_003DzOGUeWbk_003D, Region _0023_003DzpwNEYBU_003D)
	{
		ICurve[] individualCurves = _0023_003DzpwNEYBU_003D.ContourList[0].GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(_0023_003DzOGUeWbk_003D, individualCurves[i], out var _, 1.0) != -1)
			{
				_0023_003DzOGUeWbk_003D.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965040);
				return true;
			}
		}
		return false;
	}

	internal bool _0023_003DzQhzLqGmR4kjmOmQDvoMDSKg_003D(ICurve _0023_003DzVZvuR8GIx2bc, double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, Region[] _0023_003DzblFyLI_0024bgqPg)
	{
		Vector3D vector3D = Evaluate(_0023_003DzVZvuR8GIx2bc.Domain.Mid, 2)[2];
		vector3D.Normalize();
		Vector3D vector3D2 = new Vector3D(PointAt(_0023_003DzVZvuR8GIx2bc.Domain.Mid), _0023_003DzVZvuR8GIx2bc.PointAt(_0023_003DzVZvuR8GIx2bc.Domain.Mid));
		vector3D2.Normalize();
		if (Vector3D.AngleBetween(vector3D, vector3D2) > Math.PI / 2.0 || 1.0 / Curvature(_0023_003DzVZvuR8GIx2bc.Domain.Mid) > Math.Abs(_0023_003DzYNjcavt9guh2))
		{
			return true;
		}
		return false;
	}

	private void _0023_003Dz_wl_0024XyFgnPR_0024R9XeF85usbk_003D(Interval _0023_003DzhbkBViI_003D, List<Tuple<double, Point3D, Point3D>> _0023_003Dzr7tgnwG7XK6N)
	{
		double num = _0023_003DzhbkBViI_003D.Length / 3.0;
		double num2 = _0023_003DzhbkBViI_003D.Low + num;
		double num3 = _0023_003DzhbkBViI_003D.Low + 2.0 * num;
		bool flag = false;
		bool flag2 = false;
		foreach (Tuple<double, Point3D, Point3D> item in _0023_003Dzr7tgnwG7XK6N)
		{
			if (Math.Abs(item.Item1 - num2) < Utility._0023_003DzheSR8QM7q9ya)
			{
				flag = true;
			}
			if (Math.Abs(item.Item1 - num3) < Utility._0023_003DzheSR8QM7q9ya)
			{
				flag2 = true;
			}
		}
		if (flag)
		{
			_0023_003Dzr7tgnwG7XK6N.Add(new Tuple<double, Point3D, Point3D>(num3, null, null));
		}
		else if (flag2)
		{
			_0023_003Dzr7tgnwG7XK6N.Add(new Tuple<double, Point3D, Point3D>(num2, null, null));
		}
		else
		{
			_0023_003Dzr7tgnwG7XK6N.Add(new Tuple<double, Point3D, Point3D>(num2, null, null));
			_0023_003Dzr7tgnwG7XK6N.Add(new Tuple<double, Point3D, Point3D>(num3, null, null));
		}
		_0023_003Dzr7tgnwG7XK6N.Sort();
	}

	private int _0023_003DziPhQCo5zBYNt(Curve _0023_003Dzt_m8zV0_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, List<Tuple<double, Point3D, Point3D>> _0023_003Dz0OALM00_003D)
	{
		int num = 0;
		int num2 = _0023_003Dz0OALM00_003D.Count;
		for (int i = 0; i < num2 - 1; i++)
		{
			double num3 = 0.49 * _0023_003Dz0OALM00_003D[i].Item1 + 0.51 * _0023_003Dz0OALM00_003D[i + 1].Item1;
			if (!(_0023_003Dz0OALM00_003D[i + 1].Item1 - _0023_003Dz0OALM00_003D[i].Item1 < _0023_003Dzt_m8zV0_003D.Domain.Length * 0.001) && _0023_003Dz2YrctH8nER8h(_0023_003Dzt_m8zV0_003D, _0023_003Dz2ouPUQ9dmipO, num3))
			{
				_0023_003Dz0OALM00_003D.Insert(i + 1, new Tuple<double, Point3D, Point3D>(num3, null, null));
				num2++;
				i++;
				num++;
			}
		}
		return num;
	}

	private bool _0023_003Dz2YrctH8nER8h(Curve _0023_003Dzt_m8zV0_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003Dz_eY3Y4c_003D)
	{
		EvaluateTangent(_0023_003Dz_eY3Y4c_003D, out var point, out var tangent);
		_0023_003Dzt_m8zV0_003D.EvaluateTangent(_0023_003Dz_eY3Y4c_003D, out point, out var tangent2);
		Vector3D vector3D = Vector3D.Cross(tangent, _0023_003Dz2ouPUQ9dmipO);
		vector3D.Normalize();
		Vector3D vector3D2 = Vector3D.Cross(tangent2, _0023_003Dz2ouPUQ9dmipO);
		vector3D2.Normalize();
		if (Vector3D.AngleBetween(vector3D, vector3D2) > 1E-05)
		{
			return true;
		}
		return false;
	}

	internal bool _0023_003Dzm71foRyaO8wv(double _0023_003DzXrexKjY_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003Dzm0CYiiE_003D, out Curve _0023_003Dzx8HrkQY_003D)
	{
		_0023_003Dz2ouPUQ9dmipO = -1.0 * (Vector3D)_0023_003Dz2ouPUQ9dmipO.Clone();
		_0023_003Dzx8HrkQY_003D = null;
		int num = _0023_003DzB68dg9Q_003D + 1;
		int num2 = 2 * num;
		Curve[] array = Decompose();
		double high = Domain.High;
		Vector3D _0023_003DzIS3LzEk_003D;
		double num3 = _0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(high, _0023_003DzXrexKjY_003D, _0023_003Dz2ouPUQ9dmipO, out _0023_003DzIS3LzEk_003D);
		_ = Domain.Low;
		Curve[] array2 = array;
		foreach (Curve curve in array2)
		{
			double num4 = curve.Domain.Length / (double)num2;
			for (double num5 = curve.Domain.Low; num5 <= curve.Domain.High; num5 += num4)
			{
				double num6 = curve._0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(num5, _0023_003DzXrexKjY_003D, _0023_003Dz2ouPUQ9dmipO, out _0023_003DzIS3LzEk_003D);
				if (num6 > num3)
				{
					num3 = num6;
				}
			}
		}
		int num7 = (int)Math.Sqrt(num3 / (8.0 * _0023_003Dzm0CYiiE_003D)) + 1;
		if (num7 < num)
		{
			num7 = num;
		}
		List<PointTangent> list = new List<PointTangent>(num7 * array.Length + 1);
		array2 = array;
		Vector3D _0023_003DzIS3LzEk_003D2;
		Vector3D vector3D;
		Vector3D vector3D2;
		foreach (Curve curve2 in array2)
		{
			double num8 = curve2.Domain.Length / (double)num7;
			double num5 = curve2.Domain.Low;
			for (int j = 0; j < num7; j++)
			{
				vector3D = curve2.TangentAt(num5);
				if (!vector3D.Normalize())
				{
					return false;
				}
				vector3D2 = Vector3D.Cross(_0023_003Dz2ouPUQ9dmipO, vector3D);
				if (!vector3D2.Normalize())
				{
					return false;
				}
				Point3D point3D = curve2.PointAt(num5) + _0023_003DzXrexKjY_003D * vector3D2;
				curve2._0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(num5, _0023_003DzXrexKjY_003D, _0023_003Dz2ouPUQ9dmipO, out _0023_003DzIS3LzEk_003D2);
				list.Add(new PointTangent(point3D.X, point3D.Y, point3D.Z, _0023_003DzIS3LzEk_003D2.X, _0023_003DzIS3LzEk_003D2.Y, _0023_003DzIS3LzEk_003D2.Z));
				num5 += num8;
			}
		}
		vector3D = TangentAt(high);
		if (!vector3D.Normalize())
		{
			return false;
		}
		vector3D2 = Vector3D.Cross(_0023_003Dz2ouPUQ9dmipO, vector3D);
		if (!vector3D2.Normalize())
		{
			return false;
		}
		Point3D point3D2 = PointAt(high) + _0023_003DzXrexKjY_003D * vector3D2;
		_0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(high, _0023_003DzXrexKjY_003D, _0023_003Dz2ouPUQ9dmipO, out _0023_003DzIS3LzEk_003D2);
		list.Add(new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, _0023_003DzIS3LzEk_003D2.X, _0023_003DzIS3LzEk_003D2.Y, _0023_003DzIS3LzEk_003D2.Z));
		_0023_003Dzx8HrkQY_003D = CubicSplineInterpolation(list);
		_0023_003Dzx8HrkQY_003D.RemoveKnots(_0023_003Dzm0CYiiE_003D * 0.0001);
		_0023_003Dzx8HrkQY_003D.RemoveKnots(_0023_003Dzm0CYiiE_003D * 0.01);
		_0023_003Dzx8HrkQY_003D.RemoveKnots(_0023_003Dzm0CYiiE_003D);
		return true;
	}

	public bool TryGetArc(out Circle arc)
	{
		arc = null;
		double num = ControlBoundingBox().Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (num < 1E-12)
		{
			return false;
		}
		return _0023_003DzGjwEw01_0024nbyN(num, out arc);
	}

	private bool _0023_003Dzi7cRltPRqdge(double _0023_003Dzm0CYiiE_003D, out Circle _0023_003DzN4MDZ_0024c_003D)
	{
		_0023_003DzN4MDZ_0024c_003D = null;
		if (_0023_003DzB68dg9Q_003D == 2 && Pw.Length > 2 && IsPlanar(_0023_003Dzm0CYiiE_003D, out var _))
		{
			Point3D euclid = Pw[0].Euclid;
			Point3D euclid2 = Pw[1].Euclid;
			Point3D euclid3 = Pw[2].Euclid;
			switch (Pw.Length)
			{
			case 3:
			{
				if (!_0023_003DzKQciY6f_iXGL())
				{
					break;
				}
				Vector3D vector3D = new Vector3D(euclid, euclid2);
				Vector3D vector3D2 = new Vector3D(euclid3, euclid2);
				if (Math.Abs(vector3D.Length - vector3D2.Length) < _0023_003Dzm0CYiiE_003D)
				{
					Point3D center = euclid + new Vector3D(euclid2, euclid3);
					double num = vector3D.Length;
					Plane plane2 = new Plane(center, vector3D2, vector3D);
					try
					{
						_0023_003DzN4MDZ_0024c_003D = new Arc(plane2, Point2D.Origin, num, 0.0, Math.PI / 2.0);
						return true;
					}
					catch (Exception)
					{
						return false;
					}
				}
				break;
			}
			case 5:
			{
				if (!_0023_003DzKQciY6f_iXGL())
				{
					break;
				}
				Point3D euclid4 = Pw[3].Euclid;
				Vector3D vector3D5 = new Vector3D(euclid, euclid2);
				Vector3D vector3D6 = new Vector3D(euclid2, euclid4);
				if (Math.Abs(2.0 * vector3D5.Length - vector3D6.Length) < _0023_003Dzm0CYiiE_003D)
				{
					Point3D center = euclid + new Vector3D(euclid2, euclid3);
					double num = new Vector3D(euclid, euclid2).Length;
					Plane plane2 = new Plane(center, new Vector3D(euclid4, euclid2), new Vector3D(euclid, euclid2));
					try
					{
						_0023_003DzN4MDZ_0024c_003D = new Arc(plane2, Point2D.Origin, num, 0.0, Math.PI);
						return true;
					}
					catch (Exception)
					{
						return false;
					}
				}
				break;
			}
			case 9:
			{
				if (!_0023_003DzKQciY6f_iXGL())
				{
					break;
				}
				Point3D euclid4 = Pw[3].Euclid;
				Point3D euclid5 = Pw[5].Euclid;
				Vector3D vector3D3 = new Vector3D(euclid2, euclid4);
				Vector3D vector3D4 = new Vector3D(euclid4, euclid5);
				if (Math.Abs(vector3D3.Length - vector3D4.Length) < _0023_003Dzm0CYiiE_003D)
				{
					Point3D center = new Segment3D(euclid2, euclid5).MidPoint;
					Point3D euclid6 = Pw[7].Euclid;
					Plane plane2 = new Plane(euclid5, euclid6, euclid4);
					double num = new Vector3D(center, euclid).Length;
					try
					{
						_0023_003DzN4MDZ_0024c_003D = new Circle(plane2, center, num);
						return true;
					}
					catch (Exception)
					{
						return false;
					}
				}
				break;
			}
			case 7:
				if (_0023_003DzBSTPIAgCHkhX())
				{
					Point3D euclid4 = Pw[3].Euclid;
					double length = new Segment3D(euclid2, euclid4).Length;
					double num = length * 1.7320508075688772 / 6.0;
					double num2 = length * 0.8660254037844386;
					Plane plane2 = new Plane(euclid4, euclid, euclid2);
					Point3D center = plane2.PointAt(num2 - num, 0.0);
					try
					{
						_0023_003DzN4MDZ_0024c_003D = new Circle(plane2, center, num);
						return true;
					}
					catch (Exception)
					{
						return false;
					}
				}
				break;
			}
		}
		return false;
	}

	private bool _0023_003DzKQciY6f_iXGL()
	{
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			if (i % 2 == 0)
			{
				if (Math.Abs(Pw[i].W - 1.0) > Utility._0023_003DzxhnLabVjXjPg)
				{
					return false;
				}
			}
			else if (Math.Abs(Pw[i].W - 0.7071067811865476) > Utility._0023_003DzxhnLabVjXjPg)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DzBSTPIAgCHkhX()
	{
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			if (i % 2 == 0)
			{
				if (Math.Abs(Pw[i].W - 1.0) > Utility._0023_003DzxhnLabVjXjPg)
				{
					return false;
				}
			}
			else if (Math.Abs(Pw[i].W - 0.5) > Utility._0023_003DzxhnLabVjXjPg)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DzGjwEw01_0024nbyN(double _0023_003Dzm0CYiiE_003D, out Circle _0023_003DzN4MDZ_0024c_003D)
	{
		_0023_003DzN4MDZ_0024c_003D = null;
		bool num = Degree == 2;
		int num2 = ControlPoints.Length;
		bool flag = num2 == 3 || num2 == 5 || num2 == 7 || num2 == 9;
		if (num && flag && _0023_003DznCB4omY8RAYUdPokK2K9Sb0_003D() && IsPlanar(_0023_003Dzm0CYiiE_003D, out var _))
		{
			if (_0023_003DziAO235toId3R(out var _0023_003Dz9AIuhIUWJIvt))
			{
				if (!_0023_003DznLDL3h2D3a5_A00_0024sgq2G2VOZA5rzWOplA_003D_003D(out var _0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, out var _0023_003DzbUvT9Pc_003D, out var _0023_003DzEGKj_0024SNUUihi) || !IsInPlane(_0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, Utility._0023_003Dzjyaz_Vfaky9X))
				{
					return false;
				}
				return _0023_003DzzG21RPuqyUhJ(num2, _0023_003Dz9AIuhIUWJIvt, _0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzEGKj_0024SNUUihi, out _0023_003DzN4MDZ_0024c_003D);
			}
			return false;
		}
		return false;
	}

	private bool _0023_003DznLDL3h2D3a5_A00_0024sgq2G2VOZA5rzWOplA_003D_003D(out Plane _0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, out Point3D _0023_003DzbUvT9Pc_003D, out double _0023_003DzEGKj_0024SNUUihi)
	{
		Point3D euclid = ControlPoints[0].Euclid;
		Point3D euclid2 = ControlPoints[1].Euclid;
		Point3D euclid3 = ControlPoints[2].Euclid;
		Vector3D a = new Vector3D(euclid, euclid2);
		Vector3D vector3D = new Vector3D(euclid2, euclid3);
		Vector3D b = Vector3D.Cross(a, vector3D);
		Vector3D vector3D2 = Vector3D.Cross(a, b);
		Vector3D vector3D3 = Vector3D.Cross(vector3D, b);
		Segment3D segA = new Segment3D(euclid, euclid + vector3D2);
		Segment3D segB = new Segment3D(euclid3, euclid3 + vector3D3);
		if (Segment3D.Intersection(segA, segB, infinite: true, out _0023_003DzbUvT9Pc_003D, out var _))
		{
			_0023_003DzEGKj_0024SNUUihi = _0023_003DzbUvT9Pc_003D.DistanceTo(euclid);
			Vector3D vector3D4 = new Vector3D(_0023_003DzbUvT9Pc_003D, euclid);
			Vector3D vector3D5 = new Vector3D(_0023_003DzbUvT9Pc_003D, euclid2);
			vector3D4.Normalize();
			vector3D5 -= Vector3D.Dot(vector3D4, vector3D5) * vector3D4;
			_0023_003DzwwbxM1HP2_SRqORo3A_003D_003D = new Plane(_0023_003DzbUvT9Pc_003D, vector3D4, vector3D5);
			return true;
		}
		_0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzwwbxM1HP2_SRqORo3A_003D_003D = null;
		return false;
	}

	private bool _0023_003DznCB4omY8RAYUdPokK2K9Sb0_003D()
	{
		double w = ControlPoints[1].W;
		for (int i = 0; i < ControlPoints.Length; i++)
		{
			if (i < ControlPoints.Length - 1 && Math.Abs(ControlPoints[i].W - ControlPoints[i + 1].W) < Utility._0023_003DzheSR8QM7q9ya)
			{
				return false;
			}
			if (i % 2 == 0 && Math.Abs(ControlPoints[i].W - 1.0) > Utility._0023_003DzheSR8QM7q9ya)
			{
				return false;
			}
			if (i % 2 == 1 && Math.Abs(ControlPoints[i].W - w) > Utility._0023_003DzheSR8QM7q9ya)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DziAO235toId3R(out double _0023_003Dz9AIuhIUWJIvt)
	{
		_0023_003Dz9AIuhIUWJIvt = 0.0;
		double num = ControlPoints[0].Euclid.DistanceTo(ControlPoints[1].Euclid);
		if (ControlPoints[1].W < 0.0 || ControlPoints[1].W > 1.0)
		{
			return false;
		}
		_0023_003Dz9AIuhIUWJIvt = Math.Acos(ControlPoints[1].W);
		for (int i = 0; i < ControlPoints.Length - 2; i++)
		{
			Vector3D vector3D = new Vector3D(ControlPoints[i].Euclid, ControlPoints[i + 1].Euclid);
			Vector3D vector3D2 = new Vector3D(ControlPoints[i + 1].Euclid, ControlPoints[i + 2].Euclid);
			if (Math.Abs(num - vector3D2.Length) > Utility._0023_003DzxhnLabVjXjPg)
			{
				return false;
			}
			vector3D.Normalize();
			vector3D2.Normalize();
			double num2 = Vector3D.AngleBetween(vector3D, vector3D2);
			if (i % 2 == 0 && Math.Abs(num2 - 2.0 * _0023_003Dz9AIuhIUWJIvt) > 1E-07)
			{
				return false;
			}
			if (i % 2 == 1 && Math.Abs(num2) > 1E-07)
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003DzzG21RPuqyUhJ(int _0023_003DzhLarGFWfbTy5, double _0023_003Dz9AIuhIUWJIvt, Plane _0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzEGKj_0024SNUUihi, out Circle _0023_003DzN4MDZ_0024c_003D)
	{
		_0023_003DzN4MDZ_0024c_003D = null;
		int num = (_0023_003DzhLarGFWfbTy5 - 1) / 2;
		double num2 = 2.0 * _0023_003Dz9AIuhIUWJIvt * (double)num;
		double num3 = 0.5 * (double)(num - 1) * Math.PI;
		double num4 = 0.5 * (double)num * Math.PI;
		try
		{
			if (_0023_003DzhLarGFWfbTy5 == 9)
			{
				Point3D euclid = ControlPoints[0].Euclid;
				Point3D euclid2 = ControlPoints[1].Euclid;
				Point3D euclid3 = ControlPoints[3].Euclid;
				Point3D euclid4 = ControlPoints[5].Euclid;
				if (Point3D.Distance(euclid, ControlPoints[8]) < Utility._0023_003DzheSR8QM7q9ya)
				{
					_0023_003DzbUvT9Pc_003D = new Segment3D(euclid2, euclid4).MidPoint;
					Point3D euclid5 = Pw[7].Euclid;
					Plane plane = new Plane(euclid4, euclid5, euclid3);
					_0023_003DzEGKj_0024SNUUihi = new Vector3D(_0023_003DzbUvT9Pc_003D, euclid).Length;
					_0023_003DzN4MDZ_0024c_003D = new Circle(plane, _0023_003DzbUvT9Pc_003D, _0023_003DzEGKj_0024SNUUihi);
					if (Math.Abs(num2 - Math.PI * 2.0) > 1E-12)
					{
						return false;
					}
					return true;
				}
			}
			if (num2 >= num4 + 1E-12 || num2 <= num3 - 1E-12)
			{
				return false;
			}
			_0023_003DzN4MDZ_0024c_003D = new Arc(_0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzEGKj_0024SNUUihi, 0.0, num2);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool TryGetLine(out Line ln)
	{
		ln = null;
		if (_0023_003DzB68dg9Q_003D == 1 && Pw.Length == 2)
		{
			ln = new Line(Pw[0].Euclid, Pw[1].Euclid);
			return true;
		}
		return false;
	}

	private bool _0023_003DzydtNcfCnCvWE(double _0023_003Dzm0CYiiE_003D, out Point _0023_003DzlY77YgY_003D)
	{
		_0023_003DzlY77YgY_003D = new Point(Pw[0].Euclid);
		double num = _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D;
		for (int i = 1; i < Pw.Length; i++)
		{
			if (Point3D.DistanceSquared(Pw[i].Euclid, _0023_003DzlY77YgY_003D.Position) < num)
			{
				return false;
			}
		}
		return true;
	}

	public ICurve Promote()
	{
		if (TryGetLine(out var ln))
		{
			return ln;
		}
		if (TryGetArc(out var arc))
		{
			return arc;
		}
		return null;
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		ControlBoundingBox(out boxMin, out boxMax);
	}

	private void _0023_003DzsI4cshiY2dMCzaiiuPPsUu4_003D(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		Curve[] array = Decompose();
		int num = array.Length;
		Point3D[] array2 = new Point3D[num + 1];
		for (int i = 0; i < num; i++)
		{
			array2[i] = array[i].StartPoint;
		}
		array2[num] = array[num - 1].EndPoint;
		Utility.ComputeBoundingBox(array2, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
		if (_0023_003DzB68dg9Q_003D == 2 && !IsRational)
		{
			for (int j = 0; j < num; j++)
			{
				Curve curve = array[j];
				if (!Utility.IsPointInside(curve.Pw[1], _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, 0.0, testOpenIntervals: false))
				{
					curve._0023_003DzyVc7hyYdWrqBONtEuw_003D_003D(out var _0023_003DzDPcjoBJLcqli2, out var _0023_003Dz_0024N_0024yKptW9BoC2);
					Utility.UpdateMinMaxQuick(_0023_003DzDPcjoBJLcqli2, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					Utility.UpdateMinMaxQuick(_0023_003Dz_0024N_0024yKptW9BoC2, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
				}
			}
			return;
		}
		if (_0023_003DzB68dg9Q_003D == 3 && !IsRational)
		{
			for (int k = 0; k < num; k++)
			{
				Curve curve2 = array[k];
				if (!Utility.IsPointInside(curve2.Pw[1], _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, 0.0, testOpenIntervals: false) || !Utility.IsPointInside(curve2.Pw[2], _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, 0.0, testOpenIntervals: false))
				{
					curve2._0023_003DzbaUfrTOp8dvHI7MhAA_003D_003D(out var _0023_003DzDPcjoBJLcqli3, out var _0023_003Dz_0024N_0024yKptW9BoC3);
					Utility.UpdateMinMaxQuick(_0023_003DzDPcjoBJLcqli3, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					Utility.UpdateMinMaxQuick(_0023_003Dz_0024N_0024yKptW9BoC3, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
				}
			}
			return;
		}
		for (int l = 0; l < num; l++)
		{
			Curve curve3 = array[l];
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int m = 1; m < curve3.Pw.Length - 1; m++)
			{
				if (!Utility._0023_003DztviBgZeNYLdetGSTLA_003D_003D(curve3.Pw[m].Euclid, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, out var _0023_003Dz8bomyDE_003D, out var _0023_003DzOp7aOCA_003D, out var _0023_003DzuaZo_0024Qs_003D))
				{
					flag = flag || !_0023_003Dz8bomyDE_003D;
					flag2 = flag2 || !_0023_003DzOp7aOCA_003D;
					flag3 = flag3 || !_0023_003DzuaZo_0024Qs_003D;
				}
				if (flag && flag2 && flag3)
				{
					break;
				}
			}
			if (flag || flag2 || flag3)
			{
				Point3D _0023_003DzDPcjoBJLcqli4 = (Point3D)_0023_003DzDPcjoBJLcqli.Clone();
				Point3D _0023_003Dz_0024N_0024yKptW9BoC4 = (Point3D)_0023_003Dz_0024N_0024yKptW9BoC.Clone();
				if (curve3.IsRational || curve3._0023_003DzB68dg9Q_003D > 3)
				{
					curve3._0023_003DzoF8a0CsKnJqh(flag, flag2, flag3, ref _0023_003DzDPcjoBJLcqli4, ref _0023_003Dz_0024N_0024yKptW9BoC4);
				}
				else if (_0023_003DzB68dg9Q_003D == 2)
				{
					curve3._0023_003DzyVc7hyYdWrqBONtEuw_003D_003D(out _0023_003DzDPcjoBJLcqli4, out _0023_003Dz_0024N_0024yKptW9BoC4);
				}
				else
				{
					curve3._0023_003DzbaUfrTOp8dvHI7MhAA_003D_003D(out _0023_003DzDPcjoBJLcqli4, out _0023_003Dz_0024N_0024yKptW9BoC4);
				}
				Utility.UpdateMinMaxQuick(_0023_003DzDPcjoBJLcqli4, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
				Utility.UpdateMinMaxQuick(_0023_003Dz_0024N_0024yKptW9BoC4, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
			}
		}
	}

	private void _0023_003DzbaUfrTOp8dvHI7MhAA_003D_003D(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		Point3D point3D = Pw[0];
		Point3D point3D2 = Pw[1];
		Point3D point3D3 = Pw[2];
		Point3D point3D4 = Pw[3];
		_0023_003DzDPcjoBJLcqli = new Point3D(Math.Min(point3D.X, point3D4.X), Math.Min(point3D.Y, point3D4.Y), Math.Min(point3D.Z, point3D4.Z));
		_0023_003Dz_0024N_0024yKptW9BoC = new Point3D(Math.Max(point3D.X, point3D4.X), Math.Max(point3D.Y, point3D4.Y), Math.Max(point3D.Z, point3D4.Z));
		Point3D point3D5 = point3D2 - point3D;
		Point3D point3D6 = point3D - 2.0 * point3D2 + point3D3;
		Point3D point3D7 = 3.0 * point3D2 - 3.0 * point3D3 + point3D4 - point3D;
		Point3D point3D8 = new Point3D(point3D6.X * point3D6.X, point3D6.Y * point3D6.Y, point3D6.Z * point3D6.Z) - new Point3D(point3D7.X * point3D5.X, point3D7.Y * point3D5.Y, point3D7.Z * point3D5.Z);
		if (!(point3D8.X > 0.0) && !(point3D8.Y > 0.0) && !(point3D8.Z > 0.0))
		{
			return;
		}
		Point3D point3D9 = new Point3D(Math.Sqrt(Math.Abs(point3D8.X)), Math.Sqrt(Math.Abs(point3D8.Y)), Math.Sqrt(Math.Abs(point3D8.Z)));
		Point3D point3D10 = new Point3D(Utility.Clamp((0.0 - point3D6.X - point3D9.X) / point3D7.X, 0.0, 1.0), Utility.Clamp((0.0 - point3D6.Y - point3D9.Y) / point3D7.Y, 0.0, 1.0), Utility.Clamp((0.0 - point3D6.Z - point3D9.Z) / point3D7.Z, 0.0, 1.0));
		Point3D point3D11 = new Point3D(1.0 - point3D10.X, 1.0 - point3D10.Y, 1.0 - point3D10.Z);
		Point3D point3D12 = new Point3D(Utility.Clamp((0.0 - point3D6.X + point3D9.X) / point3D7.X, 0.0, 1.0), Utility.Clamp((0.0 - point3D6.Y + point3D9.Y) / point3D7.Y, 0.0, 1.0), Utility.Clamp((0.0 - point3D6.Z + point3D9.Z) / point3D7.Z, 0.0, 1.0));
		Point3D point3D13 = new Point3D(1.0 - point3D12.X, 1.0 - point3D12.Y, 1.0 - point3D12.Z);
		Point3D point3D14 = new Point3D(point3D11.X * point3D11.X * point3D11.X * point3D.X, point3D11.Y * point3D11.Y * point3D11.Y * point3D.Y, point3D11.Z * point3D11.Z * point3D11.Z * point3D.Z);
		Point3D point3D15 = new Point3D(point3D11.X * point3D11.X * point3D10.X * point3D2.X, point3D11.Y * point3D11.Y * point3D10.Y * point3D2.Y, point3D11.Z * point3D11.Z * point3D10.Z * point3D2.Z);
		Point3D point3D16 = new Point3D(point3D11.X * point3D10.X * point3D10.X * point3D3.X, point3D11.Y * point3D10.Y * point3D10.Y * point3D3.Y, point3D11.Z * point3D10.Z * point3D10.Z * point3D3.Z);
		Point3D point3D17 = new Point3D(point3D10.X * point3D10.X * point3D10.X * point3D4.X, point3D10.Y * point3D10.Y * point3D10.Y * point3D4.Y, point3D10.Z * point3D10.Z * point3D10.Z * point3D4.Z);
		Point3D point3D18 = point3D14 + 3.0 * point3D15 + 3.0 * point3D16 + point3D17;
		Point3D point3D19 = new Point3D(point3D13.X * point3D13.X * point3D13.X * point3D.X, point3D13.Y * point3D13.Y * point3D13.Y * point3D.Y, point3D13.Z * point3D13.Z * point3D13.Z * point3D.Z);
		Point3D point3D20 = new Point3D(point3D13.X * point3D13.X * point3D12.X * point3D2.X, point3D13.Y * point3D13.Y * point3D12.Y * point3D2.Y, point3D13.Z * point3D13.Z * point3D12.Z * point3D2.Z);
		Point3D point3D21 = new Point3D(point3D13.X * point3D12.X * point3D12.X * point3D3.X, point3D13.Y * point3D12.Y * point3D12.Y * point3D3.Y, point3D13.Z * point3D12.Z * point3D12.Z * point3D3.Z);
		Point3D point3D22 = new Point3D(point3D12.X * point3D12.X * point3D12.X * point3D4.X, point3D12.Y * point3D12.Y * point3D12.Y * point3D4.Y, point3D12.Z * point3D12.Z * point3D12.Z * point3D4.Z);
		Point3D point3D23 = point3D19 + 3.0 * point3D20 + 3.0 * point3D21 + point3D22;
		if (double.IsNaN(point3D18.X) || double.IsNaN(point3D18.Y) || double.IsNaN(point3D18.Z) || double.IsNaN(point3D23.X) || double.IsNaN(point3D23.Y) || double.IsNaN(point3D23.Z))
		{
			_0023_003DzoF8a0CsKnJqh(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
			return;
		}
		if (point3D8.X > 0.0)
		{
			_0023_003DzDPcjoBJLcqli.X = Math.Min(_0023_003DzDPcjoBJLcqli.X, Math.Min(point3D18.X, point3D23.X));
			_0023_003Dz_0024N_0024yKptW9BoC.X = Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.X, Math.Max(point3D18.X, point3D23.X));
		}
		if (point3D8.Y > 0.0)
		{
			_0023_003DzDPcjoBJLcqli.Y = Math.Min(_0023_003DzDPcjoBJLcqli.Y, Math.Min(point3D18.Y, point3D23.Y));
			_0023_003Dz_0024N_0024yKptW9BoC.Y = Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.Y, Math.Max(point3D18.Y, point3D23.Y));
		}
		if (point3D8.Z > 0.0)
		{
			_0023_003DzDPcjoBJLcqli.Z = Math.Min(_0023_003DzDPcjoBJLcqli.Z, Math.Min(point3D18.Z, point3D23.Z));
			_0023_003Dz_0024N_0024yKptW9BoC.Z = Math.Max(_0023_003Dz_0024N_0024yKptW9BoC.Z, Math.Max(point3D18.Z, point3D23.Z));
		}
	}

	private void _0023_003DzyVc7hyYdWrqBONtEuw_003D_003D(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		Point3D point3D = Pw[0];
		Point3D point3D2 = Pw[1];
		Point3D point3D3 = Pw[2];
		_0023_003DzDPcjoBJLcqli = new Point3D(Math.Min(point3D.X, point3D3.X), Math.Min(point3D.Y, point3D3.Y), Math.Min(point3D.Z, point3D3.Z));
		_0023_003Dz_0024N_0024yKptW9BoC = new Point3D(Math.Max(point3D.X, point3D3.X), Math.Max(point3D.Y, point3D3.Y), Math.Max(point3D.Z, point3D3.Z));
		if (point3D2.X < _0023_003DzDPcjoBJLcqli.X || point3D2.Y < _0023_003DzDPcjoBJLcqli.X || point3D2.Z < _0023_003DzDPcjoBJLcqli.X || point3D2.X > _0023_003Dz_0024N_0024yKptW9BoC.X || point3D2.Y > _0023_003Dz_0024N_0024yKptW9BoC.X || point3D2.Z > _0023_003Dz_0024N_0024yKptW9BoC.X)
		{
			Point3D point3D4 = point3D - 2.0 * point3D2 + point3D3;
			Point3D point3D5 = new Point3D(Utility.Clamp((point3D.X - point3D2.X) / point3D4.X, 0.0, 1.0), Utility.Clamp((point3D.Y - point3D2.Y) / point3D4.Y, 0.0, 1.0), Utility.Clamp((point3D.Z - point3D2.Z) / point3D4.Z, 0.0, 1.0));
			Point3D point3D6 = new Point3D(1.0 - point3D5.X, 1.0 - point3D5.Y, 1.0 - point3D5.Z);
			Point3D point3D7 = new Point3D(point3D6.X * point3D6.X * point3D.X, point3D6.Y * point3D6.Y * point3D.Y, point3D6.Z * point3D6.Z * point3D.Z);
			Point3D point3D8 = new Point3D(point3D6.X * point3D5.X * point3D2.X, point3D6.Y * point3D5.Y * point3D2.Y, point3D6.Z * point3D5.Z * point3D2.Z);
			Point3D point3D9 = new Point3D(point3D5.X * point3D5.X * point3D3.X, point3D5.Y * point3D5.Y * point3D3.Y, point3D5.Z * point3D5.Z * point3D3.Z);
			Point3D p = point3D7 + 2.0 * point3D8 + point3D9;
			Utility.UpdateMinMaxQuick(p, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
			Utility.UpdateMinMaxQuick(p, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		}
	}

	private void _0023_003DzoF8a0CsKnJqh(out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzF7v9r2A_003D = new Point3D();
		_0023_003Dz8dK2uhU_003D = new Point3D();
		_0023_003DzoF8a0CsKnJqh(_0023_003DzTgUlxWI_003D: true, _0023_003DzX0c00W0_003D: true, _0023_003DzKJmWAdQ_003D: true, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
	}

	private void _0023_003DzoF8a0CsKnJqh(bool _0023_003DzTgUlxWI_003D, bool _0023_003DzX0c00W0_003D, bool _0023_003DzKJmWAdQ_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D)
	{
		if (_0023_003DzTgUlxWI_003D)
		{
			_0023_003DznKJi7_zELV0K1gh6dg_003D_003D(this, (Utility._0023_003DzwhtOFTk_003D)0, out _0023_003DzF7v9r2A_003D.X, out _0023_003Dz8dK2uhU_003D.X);
		}
		if (_0023_003DzX0c00W0_003D)
		{
			_0023_003DznKJi7_zELV0K1gh6dg_003D_003D(this, (Utility._0023_003DzwhtOFTk_003D)1, out _0023_003DzF7v9r2A_003D.Y, out _0023_003Dz8dK2uhU_003D.Y);
		}
		if (_0023_003DzKJmWAdQ_003D)
		{
			_0023_003DznKJi7_zELV0K1gh6dg_003D_003D(this, (Utility._0023_003DzwhtOFTk_003D)2, out _0023_003DzF7v9r2A_003D.Z, out _0023_003Dz8dK2uhU_003D.Z);
		}
	}

	private void _0023_003DznKJi7_zELV0K1gh6dg_003D_003D(Curve _0023_003Dzx63Fsgc_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D, out double _0023_003DzF7v9r2A_003D, out double _0023_003Dz8dK2uhU_003D)
	{
		Vector3D vector3D = _0023_003DzxuJqjrs_003D switch
		{
			(Utility._0023_003DzwhtOFTk_003D)0 => new Vector3D(1.0, 0.0, 0.0), 
			(Utility._0023_003DzwhtOFTk_003D)1 => new Vector3D(0.0, 1.0, 0.0), 
			(Utility._0023_003DzwhtOFTk_003D)2 => new Vector3D(0.0, 0.0, 1.0), 
			_ => new Vector3D(1.0, 0.0, 0.0), 
		};
		List<double> list = new List<double>();
		list.Add(_0023_003DziNhQ61ZeuzX1(_0023_003DzxuJqjrs_003D, _0023_003Dzx63Fsgc_003D.StartPoint));
		list.Add(_0023_003DziNhQ61ZeuzX1(_0023_003DzxuJqjrs_003D, _0023_003Dzx63Fsgc_003D.EndPoint));
		Point3D point3D = new Point3D();
		int num = _0023_003DzB68dg9Q_003D + 3;
		double num2 = Domain.Length / (double)num;
		for (int i = 0; i < num + 1; i++)
		{
			double u = Domain.Low + (double)i * num2;
			double num3 = u;
			double num4 = Domain.Low + (double)(i + 1) * num2;
			bool flag = false;
			if (Utility.AngleMinimizer(this, vector3D, 10, 1E-06, ref u) && u != Domain.Low && u != Domain.High)
			{
				point3D = Evaluate(u);
				list.Add(_0023_003DziNhQ61ZeuzX1(_0023_003DzxuJqjrs_003D, point3D));
				if (u > num3 && u < num4)
				{
					flag = true;
				}
			}
			if (i < num && !flag)
			{
				u = _0023_003DzzjYUdnnhQ4Jx(vector3D, this, num3, num4, Domain.Length * 1E-06);
				if (!double.IsNaN(u))
				{
					point3D = Evaluate(u);
					list.Add(_0023_003DziNhQ61ZeuzX1(_0023_003DzxuJqjrs_003D, point3D));
				}
			}
		}
		list.Sort();
		_0023_003DzF7v9r2A_003D = list[0];
		_0023_003Dz8dK2uhU_003D = list[list.Count - 1];
	}

	private static double _0023_003DziNhQ61ZeuzX1(Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzKQZDpjLBi5CS)
	{
		double result = 0.0;
		switch (_0023_003DzxuJqjrs_003D)
		{
		case (Utility._0023_003DzwhtOFTk_003D)0:
			result = _0023_003DzKQZDpjLBi5CS.X;
			break;
		case (Utility._0023_003DzwhtOFTk_003D)1:
			result = _0023_003DzKQZDpjLBi5CS.Y;
			break;
		case (Utility._0023_003DzwhtOFTk_003D)2:
			result = _0023_003DzKQZDpjLBi5CS.Z;
			break;
		}
		return result;
	}

	private void _0023_003DzMS9ikBmo6cVMfokXfA_003D_003D(Curve _0023_003Dzx63Fsgc_003D, Line _0023_003DzOGUeWbk_003D, out double _0023_003DzF7v9r2A_003D, out double _0023_003Dz8dK2uhU_003D)
	{
		Segment3D segment3D = new Segment3D(_0023_003DzOGUeWbk_003D.StartPoint, _0023_003DzOGUeWbk_003D.EndPoint);
		Vector3D direction = _0023_003DzOGUeWbk_003D.Direction;
		double length = direction.Length;
		Vector3D vector3D = (Vector3D)direction.Clone();
		vector3D.Normalize();
		List<double> list = new List<double>();
		list.Add(segment3D.Project(_0023_003Dzx63Fsgc_003D.StartPoint));
		list.Add(segment3D.Project(_0023_003Dzx63Fsgc_003D.EndPoint));
		Point3D point3D = new Point3D();
		int num = _0023_003DzB68dg9Q_003D + 3;
		double num2 = Domain.Length / (double)num;
		for (int i = 0; i < num + 1; i++)
		{
			double _0023_003Dz_eY3Y4c_003D = Domain.Low + (double)i * num2;
			double num3 = _0023_003Dz_eY3Y4c_003D;
			double num4 = Domain.Low + (double)(i + 1) * num2;
			bool flag = false;
			if (_0023_003DzTxc3TYEQJ07wgE1bolWnwqo_003D(direction, length, ref _0023_003Dz_eY3Y4c_003D, 30, 1E-09, this) && _0023_003Dz_eY3Y4c_003D != Domain.Low && _0023_003Dz_eY3Y4c_003D != Domain.High)
			{
				point3D = Evaluate(_0023_003Dz_eY3Y4c_003D);
				double item = segment3D.Project(point3D);
				list.Add(item);
				if (_0023_003Dz_eY3Y4c_003D > num3 && _0023_003Dz_eY3Y4c_003D < num4)
				{
					flag = true;
				}
			}
			if (i < num && !flag)
			{
				_0023_003Dz_eY3Y4c_003D = _0023_003DzzjYUdnnhQ4Jx(vector3D, this, num3, num4, Domain.Length * 1E-06);
				if (!double.IsNaN(_0023_003Dz_eY3Y4c_003D))
				{
					point3D = Evaluate(_0023_003Dz_eY3Y4c_003D);
					double item2 = segment3D.Project(point3D);
					list.Add(item2);
				}
			}
		}
		list.Sort();
		_0023_003DzF7v9r2A_003D = list[0];
		_0023_003Dz8dK2uhU_003D = list[list.Count - 1];
	}

	internal bool _0023_003DzTxc3TYEQJ07wgE1bolWnwqo_003D(Vector3D _0023_003DzXrexKjY_003D, double _0023_003DzjrGkmLA_003D, ref double _0023_003Dz_eY3Y4c_003D, int _0023_003DzcYxYLpypbh1h, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Curve _0023_003Dz8fpRyMu9aKjE)
	{
		int num = 10;
		double t = _0023_003Dz8fpRyMu9aKjE.Domain.t0;
		double t2 = _0023_003Dz8fpRyMu9aKjE.Domain.t1;
		for (int i = 0; i < num; i++)
		{
			Vector3D[] array = _0023_003Dz8fpRyMu9aKjE.Evaluate(_0023_003Dz_eY3Y4c_003D, 2);
			_ = array[0];
			Vector3D vector3D = array[1];
			Vector3D vector3D2 = array[2];
			double num2 = 0.0;
			if (_0023_003DzjrGkmLA_003D != 0.0)
			{
				num2 = Math.Abs(vector3D * _0023_003DzXrexKjY_003D) / (vector3D.Length * _0023_003DzjrGkmLA_003D);
			}
			if (num2 < 1E-06)
			{
				return true;
			}
			double num3 = vector3D * _0023_003DzXrexKjY_003D;
			double num4 = vector3D2 * _0023_003DzXrexKjY_003D + vector3D * vector3D;
			double num5 = _0023_003Dz_eY3Y4c_003D - num3 / num4;
			if (num5 < t)
			{
				num5 = t;
			}
			if (num5 > t2)
			{
				num5 = t2;
			}
			if (num5 - _0023_003Dz_eY3Y4c_003D == 0.0)
			{
				return false;
			}
			_0023_003Dz_eY3Y4c_003D = num5;
		}
		return false;
	}

	private double _0023_003DzzjYUdnnhQ4Jx(Vector3D _0023_003Dz5HTW5o4_0024hama, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz3YfTAqg_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz7ax6DF3ykf6J)
	{
		double _0023_003DztnI8CIs_003D = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(_0023_003Dz3YfTAqg_003D), _0023_003Dz5HTW5o4_0024hama);
		double _0023_003Dzr_0024FR0SY_003D = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(_0023_003DzRFb1SGo_003D), _0023_003Dz5HTW5o4_0024hama);
		if ((_0023_003DztnI8CIs_003D > 0.0 && _0023_003Dzr_0024FR0SY_003D > 0.0) || (_0023_003DztnI8CIs_003D < 0.0 && _0023_003Dzr_0024FR0SY_003D < 0.0))
		{
			if (Math.Abs(_0023_003DztnI8CIs_003D) < Utility._0023_003DzheSR8QM7q9ya)
			{
				if (_0023_003Dz3YfTAqg_003D == _0023_003Dz8fpRyMu9aKjE.Domain.Low)
				{
					_0023_003Dz_KI5YDDRYTmIyZpd3g_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzRFb1SGo_003D, _0023_003Dz5HTW5o4_0024hama, _0023_003Dzr_0024FR0SY_003D, ref _0023_003Dz3YfTAqg_003D, ref _0023_003DztnI8CIs_003D);
				}
			}
			else
			{
				if (!(Math.Abs(_0023_003Dzr_0024FR0SY_003D) < Utility._0023_003DzheSR8QM7q9ya))
				{
					return double.NaN;
				}
				if (_0023_003DzRFb1SGo_003D == _0023_003Dz8fpRyMu9aKjE.Domain.High)
				{
					_0023_003DzPJerAgcyhwfTbUcU0Q_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz3YfTAqg_003D, _0023_003Dz5HTW5o4_0024hama, _0023_003DztnI8CIs_003D, ref _0023_003DzRFb1SGo_003D, ref _0023_003Dzr_0024FR0SY_003D);
				}
			}
		}
		if (Math.Abs(_0023_003DztnI8CIs_003D) < 1E-12)
		{
			if (_0023_003Dz3YfTAqg_003D != _0023_003Dz8fpRyMu9aKjE.Domain.Low)
			{
				return _0023_003Dz3YfTAqg_003D;
			}
			if (!_0023_003Dz_KI5YDDRYTmIyZpd3g_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzRFb1SGo_003D, _0023_003Dz5HTW5o4_0024hama, _0023_003Dzr_0024FR0SY_003D, ref _0023_003Dz3YfTAqg_003D, ref _0023_003DztnI8CIs_003D))
			{
				return _0023_003Dz3YfTAqg_003D;
			}
		}
		if (Math.Abs(_0023_003Dzr_0024FR0SY_003D) < 1E-12)
		{
			if (_0023_003DzRFb1SGo_003D != _0023_003Dz8fpRyMu9aKjE.Domain.High)
			{
				return _0023_003DzRFb1SGo_003D;
			}
			if (!_0023_003DzPJerAgcyhwfTbUcU0Q_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz3YfTAqg_003D, _0023_003Dz5HTW5o4_0024hama, _0023_003DztnI8CIs_003D, ref _0023_003DzRFb1SGo_003D, ref _0023_003Dzr_0024FR0SY_003D))
			{
				return _0023_003DzRFb1SGo_003D;
			}
		}
		double num;
		double num2;
		if (_0023_003DztnI8CIs_003D < 0.0)
		{
			num = _0023_003Dz3YfTAqg_003D;
			num2 = _0023_003DzRFb1SGo_003D;
		}
		else
		{
			num2 = _0023_003Dz3YfTAqg_003D;
			num = _0023_003DzRFb1SGo_003D;
		}
		double num3 = 0.5 * (_0023_003Dz3YfTAqg_003D + _0023_003DzRFb1SGo_003D);
		double num4 = Math.Abs(_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D);
		double num5 = num4;
		double num6 = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(num3), _0023_003Dz5HTW5o4_0024hama);
		Vector3D[] array = _0023_003Dz8fpRyMu9aKjE.Evaluate(num3, 2);
		Vector3D vector3D = array[1];
		double num7 = array[2] * _0023_003Dz5HTW5o4_0024hama + vector3D * vector3D;
		for (int i = 1; i <= 100; i++)
		{
			if (((num3 - num2) * num7 - num6) * ((num3 - num) * num7 - num6) >= 0.0 || Math.Abs(2.0 * num6) > Math.Abs(num4 * num7) || Math.Abs(num6) < 0.12)
			{
				num4 = num5;
				num5 = 0.5 * (num2 - num);
				num3 = num + num5;
				if (num == num3)
				{
					return num3;
				}
			}
			else
			{
				num4 = num5;
				num5 = num6 / num7;
				double num8 = num3;
				num3 -= num5;
				if (num8 == num3)
				{
					return num3;
				}
			}
			if (Math.Abs(num5) < _0023_003Dz7ax6DF3ykf6J)
			{
				return num3;
			}
			num6 = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(num3), _0023_003Dz5HTW5o4_0024hama);
			Vector3D[] array2 = _0023_003Dz8fpRyMu9aKjE.Evaluate(num3, 2);
			vector3D = array2[1];
			num7 = array2[2] * _0023_003Dz5HTW5o4_0024hama + vector3D * vector3D;
			if (num6 < 0.0)
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		return 0.0;
	}

	private static bool _0023_003DzPJerAgcyhwfTbUcU0Q_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz3YfTAqg_003D, Vector3D _0023_003DzRZmqfkw_003D, double _0023_003DztnI8CIs_003D, ref double _0023_003DzRFb1SGo_003D, ref double _0023_003Dzr_0024FR0SY_003D)
	{
		double num = _0023_003DzRFb1SGo_003D - (_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D) / 100.0;
		double num2 = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(num), _0023_003DzRZmqfkw_003D);
		if (num2 * _0023_003DztnI8CIs_003D < 0.0)
		{
			_0023_003DzRFb1SGo_003D = num;
			_0023_003Dzr_0024FR0SY_003D = num2;
			return true;
		}
		return false;
	}

	private static bool _0023_003Dz_KI5YDDRYTmIyZpd3g_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzRFb1SGo_003D, Vector3D _0023_003DzRZmqfkw_003D, double _0023_003Dzr_0024FR0SY_003D, ref double _0023_003Dz3YfTAqg_003D, ref double _0023_003DztnI8CIs_003D)
	{
		double num = _0023_003Dz3YfTAqg_003D + (_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D) / 100.0;
		double num2 = Vector3D.Dot(_0023_003Dz8fpRyMu9aKjE.TangentAt(num), _0023_003DzRZmqfkw_003D);
		if (num2 * _0023_003Dzr_0024FR0SY_003D < 0.0)
		{
			_0023_003Dz3YfTAqg_003D = num;
			_0023_003DztnI8CIs_003D = num2;
			return true;
		}
		return false;
	}

	internal bool _0023_003Dzwgr9T_H7WkW7(Vector3D _0023_003DzxuJqjrs_003D)
	{
		Plane _0023_003Dz2vgDKG9RfVBd = new Plane(Point3D.Origin, _0023_003DzxuJqjrs_003D);
		if (_0023_003DzsWVwkjD8T_OI5a86hw_003D_003D(_0023_003Dz2vgDKG9RfVBd))
		{
			return true;
		}
		Plane _0023_003Dz2vgDKG9RfVBd2 = new Plane(Point3D.Origin, new Vector3D(0.0 - _0023_003DzxuJqjrs_003D.X, 0.0 - _0023_003DzxuJqjrs_003D.Y, 0.0 - _0023_003DzxuJqjrs_003D.Z));
		if (_0023_003DzsWVwkjD8T_OI5a86hw_003D_003D(_0023_003Dz2vgDKG9RfVBd2))
		{
			return true;
		}
		return false;
	}

	private bool _0023_003DzsWVwkjD8T_OI5a86hw_003D_003D(Plane _0023_003Dz2vgDKG9RfVBd)
	{
		Vector2D[] array = new Vector2D[_0023_003DzMv2C5Tm1QMvc() - 1];
		Align3D xform = new Align3D(_0023_003Dz2vgDKG9RfVBd, Plane.XY);
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc() - 1; i++)
		{
			Vector3D vector3D = Vector3D.Subtract(Pw[i + 1].Euclid, Pw[i].Euclid);
			vector3D.TransformBy(xform);
			vector3D.Normalize();
			array[i] = vector3D;
		}
		List<Vector2D>[] array2 = new List<Vector2D>[4]
		{
			new List<Vector2D>(),
			new List<Vector2D>(),
			new List<Vector2D>(),
			new List<Vector2D>()
		};
		int num = -1;
		double num2 = 0.0;
		for (int j = 0; j < _0023_003DzMv2C5Tm1QMvc() - 1; j++)
		{
			Vector2D vector2D = array[j];
			double num3 = 0.0;
			if (j == 0)
			{
				num2 = Utility.ArcTanProblem(vector2D.X, vector2D.Y);
			}
			else
			{
				num3 = Utility.ArcTanProblem(vector2D.X, vector2D.Y) - num2;
			}
			double num4 = Math.Abs(num3);
			if ((num4 - Math.PI / 18.0 < 0.0 && num4 + Math.PI / 18.0 > 0.0) || (num4 - Math.PI / 18.0 < Math.PI / 2.0 && num4 + Math.PI / 18.0 > Math.PI / 2.0) || (num4 - Math.PI / 18.0 < Math.PI && num4 + Math.PI / 18.0 > Math.PI) || (num4 - Math.PI / 18.0 < Math.PI * 3.0 / 4.0 && num4 + Math.PI / 18.0 > Math.PI * 3.0 / 4.0))
			{
				continue;
			}
			if (num3 > 4.71238898038469)
			{
				if (j > 0 && num != 3 && array2[3].Count > 0)
				{
					return true;
				}
				array2[3].Add(array[j]);
				num = 3;
			}
			else if (num3 > Math.PI)
			{
				if (j > 0 && num != 2 && array2[2].Count > 0)
				{
					return true;
				}
				array2[2].Add(array[j]);
				num = 2;
			}
			else if (num3 > Math.PI / 2.0)
			{
				if (j > 0 && num != 1 && array2[1].Count > 0)
				{
					return true;
				}
				array2[1].Add(array[j]);
				num = 1;
			}
			else if (num3 > 0.0)
			{
				if (j > 0 && num != 0 && array2[0].Count > 0)
				{
					return true;
				}
				array2[0].Add(array[j]);
				num = 0;
			}
		}
		return false;
	}

	private bool _0023_003DzhmWDS88lixp2(List<Vector2D>[] _0023_003DzzmUhQIKXGZHz2wfUjw_003D_003D)
	{
		if (_0023_003DzzmUhQIKXGZHz2wfUjw_003D_003D[0].Count > 0 && _0023_003DzzmUhQIKXGZHz2wfUjw_003D_003D[1].Count > 0 && _0023_003DzzmUhQIKXGZHz2wfUjw_003D_003D[2].Count > 0)
		{
			return _0023_003DzzmUhQIKXGZHz2wfUjw_003D_003D[3].Count > 0;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965023), _0023_003DzB68dg9Q_003D, _0023_003DzMv2C5Tm1QMvc());
	}

	internal static Curve _0023_003DzjskCC03_0024QfdOWxBa4xnG9BQ_003D(Curve _0023_003Dz8fpRyMu9aKjE, double[] _0023_003DzqwviRkx2ZO2T, double[] _0023_003DzImxkawk_003D, int _0023_003DzO_0024iiQ4U_003D)
	{
		Curve curve = (Curve)_0023_003Dz8fpRyMu9aKjE.Clone();
		double[] knotVector = curve.KnotVector;
		int degree = curve.Degree;
		if (_0023_003DzqwviRkx2ZO2T.Length != _0023_003DzImxkawk_003D.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965238));
		}
		if (_0023_003DzqwviRkx2ZO2T.Length < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965198));
		}
		if (_0023_003DzqwviRkx2ZO2T.Length == 2)
		{
			if (knotVector.Left() != 0.0)
			{
				knotVector.Offset(0.0 - knotVector.Left());
			}
			knotVector.Scale((_0023_003DzImxkawk_003D[1] - _0023_003DzImxkawk_003D[0]) / (_0023_003DzqwviRkx2ZO2T[1] - _0023_003DzqwviRkx2ZO2T[0]));
			if (_0023_003DzImxkawk_003D[0] != 0.0)
			{
				knotVector.Offset(_0023_003DzImxkawk_003D[0]);
			}
			return curve;
		}
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _0023_003DzqwviRkx2ZO2T.Length; i++)
		{
			list.Add(new Point3D(_0023_003DzqwviRkx2ZO2T[i], 0.0, 0.0));
		}
		Curve curve2 = _0023_003DzxfgL9OaoOs_L(list, _0023_003DzImxkawk_003D, _0023_003DzO_0024iiQ4U_003D);
		double[] knotVector2 = curve2.KnotVector;
		List<double> list2 = new List<double>();
		List<double> list3 = new List<double>(list2.Count + 2);
		double num = double.MaxValue;
		for (int j = _0023_003DzO_0024iiQ4U_003D + 1; j < knotVector2.Length - _0023_003DzO_0024iiQ4U_003D - 1; j++)
		{
			if (Math.Abs(num - knotVector2[j]) > Utility._0023_003DzheSR8QM7q9ya)
			{
				list2.Add(knotVector2[j]);
				num = list2.Last();
				double x = curve2.PointAt(num).X;
				list3.Add(x);
			}
		}
		List<double> list4 = new List<double>();
		num = double.MaxValue;
		for (int k = degree + 1; k < knotVector.Length - degree - 1; k++)
		{
			if (Math.Abs(num - knotVector[k]) > Utility._0023_003DzheSR8QM7q9ya)
			{
				list4.Add(knotVector[k]);
				num = list4.Last();
			}
		}
		List<double> list5 = new List<double>();
		foreach (double item in list4)
		{
			list5.AddRange(Enumerable.Repeat(item, degree - NurbsBase.Multiplicity(knotVector, item)).ToArray());
		}
		foreach (double item2 in list3)
		{
			if (NurbsBase.Multiplicity(knotVector, item2) == 0)
			{
				list5.AddRange(Enumerable.Repeat(item2, degree).ToArray());
			}
		}
		if (list5.Count > 0)
		{
			list5.Sort();
			curve.RefineKnotVector(list5.ToArray());
		}
		double[] knotVector3 = curve.KnotVector;
		List<double> list6 = new List<double>();
		num = double.MaxValue;
		for (int l = 0; l < knotVector3.Length; l++)
		{
			if (Math.Abs(num - knotVector3[l]) > Utility._0023_003DzheSR8QM7q9ya)
			{
				list6.Add(knotVector3[l]);
				num = list6.Last();
			}
		}
		List<double> list7 = new List<double>();
		for (int m = 0; m < list6.Count; m++)
		{
			curve2._0023_003DzKWdaQi8_003D(new Point3D(list6[m], 0.0, 0.0), _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzNDQ_E88_003D);
			if (m == 0 || m == list6.Count - 1)
			{
				list7.Add(_0023_003DzNDQ_E88_003D);
			}
			list7.AddRange(Enumerable.Repeat(_0023_003DzNDQ_E88_003D, degree * _0023_003DzO_0024iiQ4U_003D));
		}
		List<double> list8 = new List<double>();
		num = double.MaxValue;
		for (int n = 0; n < list7.Count; n++)
		{
			if (num != list7[n])
			{
				list8.Add(list7[n]);
				num = list8.Last();
			}
		}
		List<Point4D> list9 = new List<Point4D>();
		double num2 = curve.Domain.Length / 1000.0;
		double num3 = curve2.Domain.Length / 1000.0;
		int num4 = (degree * _0023_003DzO_0024iiQ4U_003D + 1) / 2;
		int num5 = degree * _0023_003DzO_0024iiQ4U_003D - (degree * _0023_003DzO_0024iiQ4U_003D + 1) / 2 - 1;
		for (int num6 = 0; num6 < list6.Count - 1; num6++)
		{
			double num7 = list6[num6];
			double num8 = list6[num6 + 1];
			double num9 = list8[num6];
			double num10 = list8[num6 + 1];
			Point4D[] _0023_003DzslYbsU0_003D = curve._0023_003Dzo_00246rHrTov6fX(num7 + num2, num4);
			Point4D[] _0023_003DzyUMnoIk_003D = curve._0023_003Dzo_00246rHrTov6fX(num8 - num2, num5);
			Point4D[] _0023_003DzCOc1LMQ_003D = curve2._0023_003Dzo_00246rHrTov6fX(num9 + num3, num4);
			Point4D[] _0023_003DzqbYd9U4_003D = curve2._0023_003Dzo_00246rHrTov6fX(num10 - num3, num5);
			Point4D[] array = _0023_003DzZ6wb3fsdiUWc(new Point4D[2]
			{
				curve.ControlPoints[degree * num6],
				curve.ControlPoints[degree * num6 + degree]
			}, degree * _0023_003DzO_0024iiQ4U_003D, num10 - num9, _0023_003DzslYbsU0_003D, _0023_003DzyUMnoIk_003D, _0023_003DzCOc1LMQ_003D, _0023_003DzqbYd9U4_003D, num4, num5);
			list9.AddRange(array.Take(array.Length - 1));
		}
		list9.Add(curve.ControlPoints.Last());
		Curve curve3 = new Curve(degree * _0023_003DzO_0024iiQ4U_003D, list7.ToArray(), list9.ToArray());
		for (int num11 = list8.Count - 2; num11 > 0; num11--)
		{
			int r = (num11 + 1) * degree * _0023_003DzO_0024iiQ4U_003D;
			int num12 = NurbsBase.Multiplicity(knotVector2, list8[num11]);
			int num13 = NurbsBase.Multiplicity(knotVector, curve2.PointAt(list8[num11]).X);
			if (num12 == 0)
			{
				if (degree - num13 != 0)
				{
					curve3.RemoveKnot(r, degree * _0023_003DzO_0024iiQ4U_003D, degree - num13);
				}
			}
			else if (num13 == 0)
			{
				if (_0023_003DzO_0024iiQ4U_003D - num12 != 0)
				{
					curve3.RemoveKnot(r, degree * _0023_003DzO_0024iiQ4U_003D, _0023_003DzO_0024iiQ4U_003D - num12);
				}
			}
			else
			{
				curve3.RemoveKnot(r, degree * _0023_003DzO_0024iiQ4U_003D, Math.Min(degree - num13, _0023_003DzO_0024iiQ4U_003D - num12));
			}
		}
		return curve3;
	}

	internal static Curve _0023_003DzaExJd8itBklLXeJNnXfim4o_003D(Curve _0023_003Dz8fpRyMu9aKjE, double[] _0023_003DzqwviRkx2ZO2T, double[] _0023_003DzImxkawk_003D, int _0023_003Dz8lc6uO0_003D, int _0023_003DzbU0rLpQ_003D)
	{
		if (_0023_003DzqwviRkx2ZO2T.Length != _0023_003DzImxkawk_003D.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965238));
		}
		if (_0023_003DzqwviRkx2ZO2T.Length < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965198));
		}
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _0023_003DzqwviRkx2ZO2T.Length; i++)
		{
			list.Add(new Point3D(_0023_003DzqwviRkx2ZO2T[i], 0.0, 0.0));
		}
		Curve curve = _0023_003DzxfgL9OaoOs_L(list, _0023_003DzImxkawk_003D, 1);
		List<double> list2 = _0023_003DzImxkawk_003D.ToList();
		for (int j = 0; j < _0023_003Dz8lc6uO0_003D - _0023_003DzImxkawk_003D.Length; j++)
		{
			int num = 1;
			double num2 = list2[1] - list2[0];
			for (int k = 2; k < list2.Count; k++)
			{
				if (list2[k] - list2[k - 1] > num2)
				{
					num2 = list2[k] - list2[k - 1];
					num = k;
				}
			}
			list2.Insert(num, (list2[num] + list2[num - 1]) / 2.0);
		}
		Point3D[] array = new Point3D[list2.Count];
		for (int l = 0; l < list2.Count; l++)
		{
			double x = curve.PointAt(list2[l]).X;
			array[l] = _0023_003Dz8fpRyMu9aKjE.PointAt(x);
		}
		return _0023_003DzxfgL9OaoOs_L(array, list2.ToArray(), _0023_003DzbU0rLpQ_003D);
	}

	private static Point4D[] _0023_003DzZ6wb3fsdiUWc(Point4D[] _0023_003Dzl3DhHgI_003D, int _0023_003DzzRK_Lv8_003D, double _0023_003Dz83c_0024fKuAp2aJ, Point4D[] _0023_003DzslYbsU0_003D, Point4D[] _0023_003DzyUMnoIk_003D, Point4D[] _0023_003DzCOc1LMQ_003D, Point4D[] _0023_003DzqbYd9U4_003D, int _0023_003Dza2xQUQQ_003D, int _0023_003DzFAH4xII_003D)
	{
		Point4D[] array = new Point4D[_0023_003Dza2xQUQQ_003D];
		for (int i = 1; i <= _0023_003Dza2xQUQQ_003D; i++)
		{
			array[i - 1] = new Point4D();
			for (int j = 1; j <= i; j++)
			{
				foreach (int[] item in _0023_003DzEK1pdW_0024yb6e1_0024stnjA_003D_003D(i, j))
				{
					double num = _0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(i);
					for (int k = 0; k < i; k++)
					{
						num *= Math.Pow(_0023_003DzCOc1LMQ_003D[k + 1].X, item[k]) / ((double)_0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(item[k]) * Math.Pow(_0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(k + 1), item[k]));
					}
					Point4D[] array2 = array;
					int num2 = i - 1;
					array2[num2] += _0023_003DzslYbsU0_003D[j] * num;
				}
			}
		}
		Point4D[] array3 = new Point4D[_0023_003DzFAH4xII_003D];
		for (int l = 1; l <= _0023_003DzFAH4xII_003D; l++)
		{
			array3[l - 1] = new Point4D();
			for (int m = 1; m <= l; m++)
			{
				foreach (int[] item2 in _0023_003DzEK1pdW_0024yb6e1_0024stnjA_003D_003D(l, m))
				{
					double num3 = _0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(l);
					for (int n = 0; n < l; n++)
					{
						num3 *= Math.Pow(_0023_003DzqbYd9U4_003D[n + 1].X, item2[n]) / ((double)_0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(item2[n]) * Math.Pow(_0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(n + 1), item2[n]));
					}
					Point4D[] array2 = array3;
					int num2 = l - 1;
					array2[num2] += _0023_003DzyUMnoIk_003D[m] * num3;
				}
			}
		}
		Point4D[] array4 = new Point4D[_0023_003DzzRK_Lv8_003D + 1];
		array4[0] = _0023_003Dzl3DhHgI_003D[0];
		for (int num4 = 1; num4 <= _0023_003Dza2xQUQQ_003D; num4++)
		{
			array4[num4] = new Point4D();
			double num5 = 1.0;
			Point4D[] array2;
			int num2;
			for (int num6 = 0; num6 < num4; num6++)
			{
				num5 *= _0023_003Dz83c_0024fKuAp2aJ / (double)(_0023_003DzzRK_Lv8_003D - num6);
				double num7 = NurbsBase._0023_003Dz_0024Ad3BZI_003D(num4, num6);
				if ((num4 + num6 - 1) % 2 == 0)
				{
					array2 = array4;
					num2 = num4;
					array2[num2] += num7 * array4[num6];
				}
				else
				{
					array2 = array4;
					num2 = num4;
					array2[num2] -= num7 * array4[num6];
				}
			}
			array2 = array4;
			num2 = num4;
			array2[num2] += num5 * array[num4 - 1];
		}
		array4[_0023_003DzzRK_Lv8_003D] = _0023_003Dzl3DhHgI_003D.Last();
		for (int num8 = 1; num8 <= _0023_003DzFAH4xII_003D; num8++)
		{
			array4[_0023_003DzzRK_Lv8_003D - num8] = new Point4D();
			double num9 = 1.0;
			for (int num10 = 0; num10 < num8; num10++)
			{
				num9 *= _0023_003Dz83c_0024fKuAp2aJ / (double)(_0023_003DzzRK_Lv8_003D - num10);
				double num11 = NurbsBase._0023_003Dz_0024Ad3BZI_003D(num8, num10);
				if ((num8 + num10 - 1) % 2 == 0)
				{
					Point4D[] array2 = array4;
					int num2 = _0023_003DzzRK_Lv8_003D - num8;
					array2[num2] += num11 * array4[_0023_003DzzRK_Lv8_003D - num10];
				}
				else
				{
					Point4D[] array2 = array4;
					int num2 = _0023_003DzzRK_Lv8_003D - num8;
					array2[num2] -= num11 * array4[_0023_003DzzRK_Lv8_003D - num10];
				}
			}
			if (num8 % 2 == 0)
			{
				Point4D[] array2 = array4;
				int num2 = _0023_003DzzRK_Lv8_003D - num8;
				array2[num2] += num9 * array3[num8 - 1];
			}
			else
			{
				Point4D[] array2 = array4;
				int num2 = _0023_003DzzRK_Lv8_003D - num8;
				array2[num2] -= num9 * array3[num8 - 1];
			}
		}
		return array4;
	}

	private static int _0023_003DzcG4Ac4aGRyvATrPQepH4zMFQj__0024927Us_0024Q_003D_003D(int _0023_003DzoMNiNRw_003D)
	{
		int num = 1;
		for (int i = 1; i <= _0023_003DzoMNiNRw_003D; i++)
		{
			num *= i;
		}
		return num;
	}

	private static List<List<int>> _0023_003DzalBrw8HoNijToAB4LDj04_0024M_003D(int _0023_003DzoMNiNRw_003D, int _0023_003DzTSeNR8Q_003D)
	{
		List<List<int>> list = new List<List<int>>();
		_0023_003DzQnMsl0OcFN4zFRDmBw_003D_003D(new List<int>(), _0023_003DzTSeNR8Q_003D, _0023_003DzoMNiNRw_003D, list);
		return list;
	}

	private static void _0023_003DzQnMsl0OcFN4zFRDmBw_003D_003D(List<int> _0023_003Dz_0024rCU7PtE9Cc4, int _0023_003DzRuoMq1XVLUrj, int _0023_003DzoMNiNRw_003D, List<List<int>> _0023_003DzZE9fb_0024M_003D)
	{
		if (_0023_003Dz_0024rCU7PtE9Cc4.Count == _0023_003DzoMNiNRw_003D)
		{
			if (_0023_003DzRuoMq1XVLUrj == 0)
			{
				_0023_003DzZE9fb_0024M_003D.Add(new List<int>(_0023_003Dz_0024rCU7PtE9Cc4));
			}
			return;
		}
		for (int i = 0; i <= _0023_003DzRuoMq1XVLUrj; i++)
		{
			_0023_003Dz_0024rCU7PtE9Cc4.Add(i);
			_0023_003DzQnMsl0OcFN4zFRDmBw_003D_003D(_0023_003Dz_0024rCU7PtE9Cc4, _0023_003DzRuoMq1XVLUrj - i, _0023_003DzoMNiNRw_003D, _0023_003DzZE9fb_0024M_003D);
			_0023_003Dz_0024rCU7PtE9Cc4.RemoveAt(_0023_003Dz_0024rCU7PtE9Cc4.Count - 1);
		}
	}

	private static List<int[]> _0023_003DzEK1pdW_0024yb6e1_0024stnjA_003D_003D(int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D)
	{
		List<int[]> list = new List<int[]>();
		foreach (List<int> item in _0023_003DzalBrw8HoNijToAB4LDj04_0024M_003D(_0023_003Dz437_00244ak_003D, _0023_003DzTSeNR8Q_003D))
		{
			double num = 0.0;
			for (int i = 0; i < item.Count; i++)
			{
				double num2 = item[i];
				num += num2 * (double)(i + 1);
			}
			if (num == (double)_0023_003Dz437_00244ak_003D)
			{
				list.Add(item.ToArray());
			}
		}
		return list;
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(this, parents);
	}

	public Point3D PointAt(double u)
	{
		return Evaluate(u);
	}

	public Point3D Evaluate(double u)
	{
		if (_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D)
		{
			return _0023_003DzqCGqOmEw7DcU(u);
		}
		return _0023_003DzO2DiIZ7Eau6b(u);
	}

	private Point3D _0023_003DzqCGqOmEw7DcU(double _0023_003Dz_eY3Y4c_003D)
	{
		int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[] array = _0023_003DziP9fFuA_003D.BasisFuns(num, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D);
		Point4D point4D = new Point4D();
		for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
		{
			point4D += array[i] * Pw[num - _0023_003DzB68dg9Q_003D + i];
		}
		return point4D.Euclid;
	}

	private Point3D _0023_003DzO2DiIZ7Eau6b(double _0023_003Dz_eY3Y4c_003D)
	{
		int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[] array = _0023_003DziP9fFuA_003D.BasisFuns(num, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D);
		Point3D point3D = new Point3D();
		for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
		{
			Point3D point3D2 = Pw[num - _0023_003DzB68dg9Q_003D + i];
			double num2 = array[i];
			point3D.X += num2 * point3D2.X;
			point3D.Y += num2 * point3D2.Y;
			point3D.Z += num2 * point3D2.Z;
		}
		return point3D;
	}

	public Vector3D[] Evaluate(double u, int d)
	{
		if (_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D)
		{
			return _0023_003Dzx2I3uxIqme0nRwVxYQ_003D_003D(u, d);
		}
		return _0023_003DzfLAJp1YiWCMFHcaN8g_003D_003D(u, d);
	}

	private Vector3D[] _0023_003Dzx2I3uxIqme0nRwVxYQ_003D_003D(double _0023_003Dz_eY3Y4c_003D, int _0023_003DzXrexKjY_003D)
	{
		Vector3D[] array = new Vector3D[_0023_003DzXrexKjY_003D + 1];
		int num = Math.Min(_0023_003DzXrexKjY_003D, _0023_003DzB68dg9Q_003D);
		int num2 = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[,] array2 = _0023_003DziP9fFuA_003D.DersBasisFuns(num2, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D, num);
		int num3 = num2 - _0023_003DzB68dg9Q_003D;
		double[] array3 = new double[_0023_003DzXrexKjY_003D + 1];
		for (int i = 0; i <= _0023_003DzXrexKjY_003D; i++)
		{
			_0023_003DzFKwzf8H4YdULHGmd9sQ1YwA_003D _0023_003DzjbqS1qE_003D = default(_0023_003DzFKwzf8H4YdULHGmd9sQ1YwA_003D);
			if (i <= num)
			{
				for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
				{
					_0023_003DzjbqS1qE_003D += array2[i, j] * Pw[num3 + j]._0023_003DzooidtLbos_0024Ev();
				}
			}
			array3[i] = _0023_003DzjbqS1qE_003D._0023_003DzxmoHVeQ_003D;
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzjbqS1qE_003D2 = new _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D(_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D, _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D, _0023_003DzjbqS1qE_003D._0023_003Dz8wjMonY_003D);
			for (int k = 1; k <= i; k++)
			{
				_0023_003DzjbqS1qE_003D2 -= NurbsBase._0023_003Dz_0024Ad3BZI_003D(i, k) * array3[k] * array[i - k]._0023_003Dz53cmpTHe6Yih();
			}
			array[i] = new Vector3D(_0023_003DzjbqS1qE_003D2._0023_003Dzyk2fsPo_003D / array3[0], _0023_003DzjbqS1qE_003D2._0023_003DzvXOLtKg_003D / array3[0], _0023_003DzjbqS1qE_003D2._0023_003Dz8wjMonY_003D / array3[0]);
		}
		return array;
	}

	private Vector3D[] _0023_003DzfLAJp1YiWCMFHcaN8g_003D_003D(double _0023_003Dz_eY3Y4c_003D, int _0023_003DzXrexKjY_003D)
	{
		int num = Math.Min(_0023_003DzXrexKjY_003D, _0023_003DzB68dg9Q_003D);
		int num2 = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[,] array = _0023_003DziP9fFuA_003D.DersBasisFuns(num2, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D, num);
		Vector3D[] array2 = new Vector3D[_0023_003DzXrexKjY_003D + 1];
		for (int i = 0; i < _0023_003DzXrexKjY_003D + 1; i++)
		{
			array2[i] = new Vector3D();
		}
		int num3 = num2 - _0023_003DzB68dg9Q_003D;
		for (int j = 0; j <= num; j++)
		{
			Vector3D _0023_003Dz77g161c_003D = array2[j];
			for (int k = 0; k <= _0023_003DzB68dg9Q_003D; k++)
			{
				_0023_003Dz77g161c_003D._0023_003DzPJNpNF4_003D(array[j, k] * ((Point3D)Pw[num3 + k])._0023_003Dz53cmpTHe6Yih());
			}
		}
		return array2;
	}

	internal Point4D _0023_003Dzo_00246rHrTov6fX(double _0023_003Dz_eY3Y4c_003D)
	{
		int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[] array = _0023_003DziP9fFuA_003D.BasisFuns(num, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D);
		Point4D result = new Point4D();
		for (int num2 = _0023_003DzB68dg9Q_003D; num2 >= 0; num2--)
		{
			result += array[num2] * Pw[num - _0023_003DzB68dg9Q_003D + num2];
		}
		return result;
	}

	internal Point4D[] _0023_003Dzo_00246rHrTov6fX(double _0023_003Dz_eY3Y4c_003D, int _0023_003DzXrexKjY_003D)
	{
		int num = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzFNjygTLTZtF3(), _0023_003DzB68dg9Q_003D, _0023_003Dz_eY3Y4c_003D);
		double[,] array = _0023_003DziP9fFuA_003D.DersBasisFuns(num, _0023_003Dz_eY3Y4c_003D, _0023_003DzB68dg9Q_003D, _0023_003DzXrexKjY_003D);
		Point4D[] array2 = new Point4D[_0023_003DzXrexKjY_003D + 1];
		for (int i = 0; i <= _0023_003DzXrexKjY_003D; i++)
		{
			Point4D point4D = new Point4D();
			for (int num2 = _0023_003DzB68dg9Q_003D; num2 >= 0; num2--)
			{
				point4D += array[i, num2] * Pw[num - _0023_003DzB68dg9Q_003D + num2];
			}
			array2[i] = point4D;
		}
		return array2;
	}

	public double Curvature(double u)
	{
		Vector3D[] array = Evaluate(u, 2);
		Vector3D vector3D = array[1];
		Vector3D b = array[2];
		Vector3D vector3D2 = Vector3D.Cross(vector3D, b);
		double length = vector3D.Length;
		return vector3D2.Length / (length * length * length);
	}

	internal double _0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003DzXrexKjY_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, out Vector3D _0023_003DzIS3LzEk_003D)
	{
		Vector3D[] array = Evaluate(_0023_003Dz_eY3Y4c_003D, 3);
		Vector3D vector3D = array[1];
		Vector3D vector3D2 = array[2];
		Vector3D b = array[3];
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		double length = vector3D.Length;
		double num = length * length * length;
		double num2 = vector3D3.Length / num;
		Vector3D vector3D4 = (Vector3D)vector3D3.Clone();
		vector3D4.Normalize();
		double num3 = -Math.Sign(vector3D4 * _0023_003Dz2ouPUQ9dmipO);
		Vector3D vector3D5 = Vector3D.Cross(vector3D, b);
		double num4 = (length * length * vector3D5 * vector3D4 - 3.0 * vector3D * vector3D2 * vector3D3 * vector3D4) / (num * length * length);
		double num5 = 1.0 + num3 * num2 * _0023_003DzXrexKjY_003D;
		_0023_003DzIS3LzEk_003D = num5 * vector3D;
		return (num5 * vector3D2 + num3 * num4 * _0023_003DzXrexKjY_003D * vector3D).Length;
	}

	public Vector3D NormalAt(double u)
	{
		_0023_003DzfSoiFiPSG81U(u, out var _0023_003DzZbOaTIM_003D);
		return _0023_003DzZbOaTIM_003D;
	}

	internal bool _0023_003DzfSoiFiPSG81U(double _0023_003Dz_eY3Y4c_003D, out Vector3D _0023_003DzZbOaTIM_003D)
	{
		Vector3D[] array = Evaluate(_0023_003Dz_eY3Y4c_003D, 2);
		Vector3D vector3D = array[1];
		Vector3D vector3D2 = array[2];
		_0023_003DzZbOaTIM_003D = vector3D2 - vector3D2 * vector3D / (vector3D * vector3D) * vector3D;
		return _0023_003DzZbOaTIM_003D.Normalize();
	}

	public Vector3D TangentAt(double t)
	{
		EvaluateTangent(t, out var _, out var tangent);
		return tangent;
	}

	public bool EvaluateTangent(double t, out Point3D point, out Vector3D tangent)
	{
		bool flag = true;
		Vector3D[] array = Evaluate(t, 1);
		point = array[0].AsPoint;
		tangent = array[1];
		if (!tangent.Normalize())
		{
			array = Evaluate(t, 2);
			point = array[0].AsPoint;
			Vector3D vector3D = array[2];
			tangent = vector3D;
			flag = tangent.Normalize();
			if (flag)
			{
				Interval interval = new Interval(Domain.Low, Domain.High);
				if (interval.IsIncreasing && _0023_003DzBwgbAi13lwEN(t, out var _0023_003Dzevnms_0024g_003D, out var _0023_003DzS2VXf_A_003D))
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = t;
					int num4 = 0;
					if ((t < interval.t1 && num4 >= 0) || t == interval.t0)
					{
						num = _0023_003DzS2VXf_A_003D - t;
						if (num <= 0.0 || t + num > interval.ParameterAt(0.1))
						{
							return flag;
						}
					}
					else if ((t > interval.t0 && num4 < 0) || t == interval.t1)
					{
						num = _0023_003Dzevnms_0024g_003D - t;
						if (num >= 0.0 || t + num < interval.ParameterAt(0.9))
						{
							return flag;
						}
					}
					int num5 = 0;
					int num6 = 0;
					int num7 = 3;
					int num8 = 0;
					while (num8 < num7)
					{
						num3 = t + num;
						if (num3 == t)
						{
							break;
						}
						array = Evaluate(num3, 2);
						Vector3D vector3D2 = array[1];
						Vector3D vector3D3 = array[2];
						double num9 = vector3D2 * vector3D3;
						if (num9 > num2)
						{
							break;
						}
						if (num9 < num2)
						{
							num5++;
						}
						else
						{
							num6++;
						}
						num8++;
						num *= 0.5;
					}
					if (num5 > 0 && num7 == num5 + num6)
					{
						tangent.Negate();
					}
				}
			}
		}
		return flag;
	}

	private bool _0023_003DzBwgbAi13lwEN(double _0023_003DzNDQ_E88_003D, out double _0023_003Dzevnms_0024g_003D, out double _0023_003DzS2VXf_A_003D)
	{
		_0023_003Dzevnms_0024g_003D = 0.0;
		_0023_003DzS2VXf_A_003D = 0.0;
		bool result = false;
		Interval interval = new Interval(Domain.Low, Domain.High);
		if (interval.IsIncreasing)
		{
			result = _0023_003DzBwgbAi13lwEN(interval.t0, interval.t1, _0023_003DzNDQ_E88_003D, out _0023_003Dzevnms_0024g_003D, out _0023_003DzS2VXf_A_003D);
		}
		return result;
	}

	private static bool _0023_003DzBwgbAi13lwEN(double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, double _0023_003DzNDQ_E88_003D, out double _0023_003Dzz8huGZM4jf6u, out double _0023_003Dza1KrESqvUNjP)
	{
		_0023_003Dzz8huGZM4jf6u = 0.0;
		_0023_003Dza1KrESqvUNjP = 0.0;
		bool num = _0023_003DzDSaZWik_003D < _0023_003DzsK_Xndk_003D;
		if (num)
		{
			if (_0023_003DzNDQ_E88_003D < _0023_003DzDSaZWik_003D)
			{
				_0023_003DzNDQ_E88_003D = _0023_003DzDSaZWik_003D;
			}
			else if (_0023_003DzNDQ_E88_003D > _0023_003DzsK_Xndk_003D)
			{
				_0023_003DzNDQ_E88_003D = _0023_003DzsK_Xndk_003D;
			}
			double num2 = (_0023_003DzsK_Xndk_003D - _0023_003DzDSaZWik_003D) * 8.0 * 1.490116119385E-08 + (Math.Abs(_0023_003DzDSaZWik_003D) + Math.Abs(_0023_003DzsK_Xndk_003D)) * 2.220446049250313E-16;
			if (num2 >= _0023_003DzsK_Xndk_003D - _0023_003DzDSaZWik_003D)
			{
				num2 = 0.5 * (_0023_003DzsK_Xndk_003D - _0023_003DzDSaZWik_003D);
			}
			double num3 = _0023_003DzNDQ_E88_003D - num2;
			double num4 = _0023_003DzNDQ_E88_003D + num2;
			_0023_003Dzz8huGZM4jf6u = num3;
			_0023_003Dza1KrESqvUNjP = num4;
		}
		return num;
	}

	internal bool _0023_003Dz9V15q_0Tnbjf()
	{
		int num = 1;
		for (int i = _0023_003DzB68dg9Q_003D + 1; i < _0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 1; i++)
		{
			num = ((_0023_003DziP9fFuA_003D[i] != _0023_003DziP9fFuA_003D[i + 1]) ? 1 : (num + 1));
			if (num == _0023_003DzB68dg9Q_003D)
			{
				return true;
			}
		}
		return false;
	}

	private new TabulatedSurface[] _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(Vector3D _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D)
	{
		if (_0023_003Dz9V15q_0Tnbjf())
		{
			return _0023_003Dzn0S0DRomaTI7VdAJYw_003D_003D(this, _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D);
		}
		return new TabulatedSurface[1] { _0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, this) };
	}

	internal TabulatedSurface _0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(Vector3D _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz_Gzfs9c_003D: true);
	}

	internal TabulatedSurface _0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(Vector3D _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, ICurve _0023_003Dz8fpRyMu9aKjE, bool _0023_003Dz_Gzfs9c_003D)
	{
		Point4D[,] array = new Point4D[_0023_003DzMv2C5Tm1QMvc(), 2];
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			array[i, 0] = (Point4D)Pw[i].Clone();
			double w = Pw[i].W;
			array[i, 1] = new Point4D((Pw[i].X / w + _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.X) * w, (Pw[i].Y / w + _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Y) * w, (Pw[i].Z / w + _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Z) * w, w);
		}
		double length = _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Length;
		double[] uKnotVector = (double[])_0023_003DziP9fFuA_003D.Clone();
		Vector3D theGeneratrix = _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D;
		ICurve theDirectrix = _0023_003Dz8fpRyMu9aKjE;
		if (_0023_003Dz_Gzfs9c_003D)
		{
			theGeneratrix = (Vector3D)_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Clone();
			theDirectrix = (ICurve)_0023_003Dz8fpRyMu9aKjE.Clone();
		}
		return new TabulatedSurface(_0023_003DzB68dg9Q_003D, uKnotVector, 1, new double[4] { 0.0, 0.0, length, length }, array, theGeneratrix, theDirectrix)
		{
			ColorMethod = ColorMethod,
			Color = Color,
			LayerName = LayerName
		};
	}

	private static TabulatedSurface[] _0023_003Dzn0S0DRomaTI7VdAJYw_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, Vector3D _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D)
	{
		ICurve[] array = _0023_003Dz8fpRyMu9aKjE.SplitAtDiscontinuities(speedChange: true);
		ICurve[] array2 = array;
		TabulatedSurface[] array3 = new TabulatedSurface[array2.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			Curve nurbsForm = array2[i].GetNurbsForm();
			array3[i] = nurbsForm._0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, nurbsForm);
		}
		return array3;
	}

	private Surface[] _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(double _0023_003DzpjSkdJn4nx2K, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		if (_0023_003Dz9V15q_0Tnbjf())
		{
			return _0023_003DzfwYtkKmz75NMHRlHBA_003D_003D(this, _0023_003DzpjSkdJn4nx2K, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
		Surface surface = _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003DzpjSkdJn4nx2K, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, this);
		if (surface != null)
		{
			return new Surface[1] { surface };
		}
		return new Surface[0];
	}

	private new Surface[] _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003Dzu66CAuDRFcaC, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		if (_0023_003Dz9V15q_0Tnbjf())
		{
			return _0023_003DzfwYtkKmz75NMHRlHBA_003D_003D(this, _0023_003Dz3veEI49c6b6Q, _0023_003Dzu66CAuDRFcaC, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
		Surface surface = _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003Dzu66CAuDRFcaC, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, this);
		if (surface != null)
		{
			return new Surface[1] { surface };
		}
		return null;
	}

	internal Surface _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(double _0023_003DzpjSkdJn4nx2K, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(0.0, _0023_003DzpjSkdJn4nx2K, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz8fpRyMu9aKjE);
	}

	internal Surface _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003Dzu66CAuDRFcaC, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003Dzu66CAuDRFcaC, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz_Gzfs9c_003D: true);
	}

	internal Surface _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003Dzu66CAuDRFcaC, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, ICurve _0023_003Dz8fpRyMu9aKjE, bool _0023_003Dz_Gzfs9c_003D)
	{
		if (Math.Abs(_0023_003Dzu66CAuDRFcaC) < Utility._0023_003DzxhnLabVjXjPg)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965143), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965123));
		}
		Interval interval = Utility.FixRevAngle(_0023_003Dz3veEI49c6b6Q, _0023_003Dzu66CAuDRFcaC);
		Vector3D vector3D = _0023_003DzxuJqjrs_003D;
		if (_0023_003Dz_Gzfs9c_003D)
		{
			vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		}
		vector3D.Normalize();
		int num = 0;
		num = ((Math.Abs(interval.Length) <= Math.PI / 2.0) ? 1 : ((Math.Abs(interval.Length) <= Math.PI) ? 2 : ((!(Math.Abs(interval.Length) <= 4.71238898038469)) ? 4 : 3)));
		double num2 = interval.Length / (double)num;
		int num3 = 2 * num;
		double num4 = Math.Cos(num2 / 2.0);
		double num5 = 0.0;
		double[] array = new double[num + 1];
		double[] array2 = new double[num + 1];
		for (int i = 1; i <= num; i++)
		{
			num5 += num2;
			array[i] = Math.Cos(num5);
			array2[i] = Math.Sin(num5);
		}
		Point3D point3D = new Point3D();
		Point4D[,] array3 = new Point4D[num3 + 1, Pw.Length];
		Segment3D segment3D = new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + vector3D);
		int j;
		for (j = 0; j < Pw.Length; j++)
		{
			double w = Pw[j].W;
			point3D.X = Pw[j].X / w;
			point3D.Y = Pw[j].Y / w;
			point3D.Z = Pw[j].Z / w;
			Point3D point3D2 = point3D.ProjectTo(segment3D);
			Vector3D vector3D2 = Vector3D.Subtract(point3D, point3D2);
			double length = vector3D2.Length;
			Vector3D vector3D3 = new Vector3D();
			if (length > 0.0)
			{
				vector3D2.Normalize();
			}
			else
			{
				vector3D2 = new Vector3D();
			}
			vector3D3 = Vector3D.Cross(vector3D, vector3D2);
			array3[0, j] = (Point4D)Pw[j].Clone();
			Transformation xform = new Rotation(interval.t0, vector3D, _0023_003DzbUvT9Pc_003D);
			array3[0, j].TransformBy(xform);
			Vector3D t = vector3D3;
			int num6 = 0;
			for (int k = 1; k <= num; k++)
			{
				Point3D point3D3 = new Point3D(point3D2.X + length * array[k] * vector3D2.X + length * array2[k] * vector3D3.X, point3D2.Y + length * array[k] * vector3D2.Y + length * array2[k] * vector3D3.Y, point3D2.Z + length * array[k] * vector3D2.Z + length * array2[k] * vector3D3.Z);
				array3[num6 + 2, j] = new Point4D(w * point3D3.X, w * point3D3.Y, w * point3D3.Z, w);
				array3[num6 + 2, j].TransformBy(xform);
				Vector3D vector3D4 = (0.0 - array2[k]) * vector3D2 + array[k] * vector3D3;
				Point3D i2;
				if (point3D != point3D3)
				{
					if (Utility.Intersect3DLines(point3D, t, point3D3, vector3D4, out var _, out var _, out i2) == 1)
					{
						return null;
					}
				}
				else
				{
					i2 = point3D;
				}
				array3[num6 + 1, j] = new Point4D(num4 * w * i2.X, num4 * w * i2.Y, num4 * w * i2.Z, num4 * w);
				array3[num6 + 1, j].TransformBy(xform);
				num6 += 2;
				if (k < num)
				{
					point3D = point3D3;
					t = vector3D4;
				}
			}
		}
		double _0023_003Dz9ulfqf0M07_0024x;
		Vector3D vector3D5 = _0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(segment3D, out _0023_003Dz9ulfqf0M07_0024x);
		if (_0023_003Dz9ulfqf0M07_0024x == double.MinValue)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964835));
		}
		j = 2 * num + 1;
		double[] array4 = new double[num3 + 4];
		double num7 = Math.Abs(interval.Length);
		for (int l = 0; l < 3; l++)
		{
			array4[l] = 0.0;
			array4[l + j] = num7;
		}
		switch (num)
		{
		case 2:
			array4[3] = (array4[4] = 0.5 * num7);
			break;
		case 3:
			array4[3] = (array4[4] = 1.0 / 3.0 * num7);
			array4[5] = (array4[6] = 2.0 / 3.0 * num7);
			break;
		case 4:
			array4[3] = (array4[4] = 0.25 * num7);
			array4[5] = (array4[6] = 0.5 * num7);
			array4[7] = (array4[8] = 0.75 * num7);
			break;
		}
		array4.Offset(interval.t0);
		if (vector3D5.IsZero)
		{
			return null;
		}
		Plane plane = new Plane(_0023_003DzbUvT9Pc_003D, vector3D5, vector3D);
		double num8 = 0.0;
		for (int m = 0; m < Pw.Length - 1; m++)
		{
			num8 += Pw[m].Euclid.DistanceTo(Pw[m + 1].Euclid);
		}
		double tol = Math.Max(_0023_003Dz9ulfqf0M07_0024x, num8) * Utility._0023_003DzxhnLabVjXjPg;
		if (!IsInPlane(plane, tol))
		{
			return new Surface(2, array4, _0023_003DzB68dg9Q_003D, (double[])_0023_003DziP9fFuA_003D.Clone(), array3)
			{
				ColorMethod = ColorMethod,
				Color = Color,
				LayerName = LayerName
			};
		}
		double[] vKnotVector = (double[])_0023_003DziP9fFuA_003D.Clone();
		ICurve generatrix = _0023_003Dz8fpRyMu9aKjE;
		if (_0023_003Dz_Gzfs9c_003D)
		{
			generatrix = (ICurve)_0023_003Dz8fpRyMu9aKjE.Clone();
		}
		RevolvedSurface revolvedSurface;
		if (_0023_003Dz8fpRyMu9aKjE is Line)
		{
			Line line = (Line)_0023_003Dz8fpRyMu9aKjE;
			Point2D p = plane.Project(line.StartPoint);
			Point2D p2 = plane.Project(line.EndPoint);
			Vector2D vector2D = new Vector2D(p, p2);
			double num9 = Math.Atan2(vector2D.X, vector2D.Y);
			double x = plane.Project(_0023_003Dz8fpRyMu9aKjE.StartPoint).X;
			double x2 = plane.Project(_0023_003Dz8fpRyMu9aKjE.EndPoint).X;
			plane.Origin = _0023_003Dz8fpRyMu9aKjE.StartPoint.ProjectTo(segment3D);
			if (Math.Abs(num9) < Utility._0023_003DzxhnLabVjXjPg || Math.PI - Math.Abs(num9) < Utility._0023_003DzxhnLabVjXjPg)
			{
				revolvedSurface = new CylindricalSurface(2, array4, _0023_003DzB68dg9Q_003D, vKnotVector, array3, generatrix, x, plane);
			}
			else
			{
				Utility.Intersect3DLines(_0023_003DzbUvT9Pc_003D, _0023_003DzxuJqjrs_003D, line.StartPoint, line.Tangent, out var _, out var _, out var i3);
				if (x2 > x)
				{
					plane.Origin = _0023_003Dz8fpRyMu9aKjE.EndPoint.ProjectTo(segment3D);
				}
				revolvedSurface = new ConicalSurface(2, array4, _0023_003DzB68dg9Q_003D, vKnotVector, array3, generatrix, Math.Max(x, x2), plane, num9, i3);
			}
		}
		else if (_0023_003Dz8fpRyMu9aKjE is Circle)
		{
			Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
			plane.Origin = circle.Center.ProjectTo(segment3D);
			Point2D point2D = plane.Project(circle.Center);
			if (Math.Abs(point2D.X) < circle.Diameter * Utility._0023_003DzheSR8QM7q9ya)
			{
				revolvedSurface = new SphericalSurface(2, array4, _0023_003DzB68dg9Q_003D, vKnotVector, array3, generatrix, circle.Radius, plane);
			}
			else
			{
				if (!(circle is Arc))
				{
					generatrix = new Arc(circle.Plane, Point2D.Origin, circle.Radius, 0.0, Math.PI * 2.0);
				}
				revolvedSurface = new ToroidalSurface(2, array4, _0023_003DzB68dg9Q_003D, vKnotVector, array3, generatrix, point2D.X, circle.Radius, plane);
			}
		}
		else
		{
			revolvedSurface = new RevolvedSurface(2, array4, _0023_003DzB68dg9Q_003D, vKnotVector, array3, generatrix, plane);
		}
		revolvedSurface.ColorMethod = ColorMethod;
		revolvedSurface.Color = Color;
		revolvedSurface.LayerName = LayerName;
		return revolvedSurface;
	}

	internal Vector3D _0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(Segment3D _0023_003DzU6QO949msgio, out double _0023_003Dz9ulfqf0M07_0024x)
	{
		_0023_003Dz9ulfqf0M07_0024x = double.MinValue;
		Vector3D result = new Vector3D();
		for (int i = 0; i < 5; i++)
		{
			Point3D point3D = PointAt(Domain.ParameterAt((double)i / 4.0));
			Point3D b = point3D.ProjectTo(_0023_003DzU6QO949msgio);
			Vector3D vector3D = Vector3D.Subtract(point3D, b);
			double length = vector3D.Length;
			if (length > _0023_003Dz9ulfqf0M07_0024x)
			{
				_0023_003Dz9ulfqf0M07_0024x = length;
				vector3D.Normalize();
				result = (Vector3D)vector3D.Clone();
			}
		}
		return result;
	}

	private static Surface[] _0023_003DzfwYtkKmz75NMHRlHBA_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzpjSkdJn4nx2K, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		ICurve[] individualCurves = _0023_003Dz8fpRyMu9aKjE.GetIndividualCurves();
		List<Surface> list = new List<Surface>(individualCurves.Length);
		for (int i = 0; i < individualCurves.Length; i++)
		{
			Curve curve = (Curve)individualCurves[i];
			try
			{
				list.Add(curve._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003DzpjSkdJn4nx2K, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, curve));
			}
			catch (Exception)
			{
			}
		}
		return list.ToArray();
	}

	private static Surface[] _0023_003DzfwYtkKmz75NMHRlHBA_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz3veEI49c6b6Q, double _0023_003Dzu66CAuDRFcaC, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		ICurve[] array = _0023_003Dz8fpRyMu9aKjE.SplitAtDiscontinuities(speedChange: true);
		ICurve[] array2 = array;
		List<Surface> list = new List<Surface>(array2.Length);
		for (int i = 0; i < array2.Length; i++)
		{
			Curve nurbsForm = array2[i].GetNurbsForm();
			Surface surface = nurbsForm._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003Dzu66CAuDRFcaC, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, nurbsForm);
			if (surface != null)
			{
				list.Add(surface);
			}
		}
		return list.ToArray();
	}

	private Surface[] _0023_003Dz789GXCk_003D(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D)
	{
		return SweepAsSurface(_0023_003DzHgrHIfhYCh4p, _0023_003Dzm0CYiiE_003D);
	}

	public static bool Trim(ICurve C1, ICurve C2, bool flip1, bool flip2)
	{
		Point3D[] array = C1.IntersectWith(C2);
		if (array.Length != 0)
		{
			InterPoint interPoint = (InterPoint)array[0];
			C1.TrimAt(interPoint.u, flip1);
			C2.TrimAt(interPoint.s, flip2);
			return true;
		}
		return false;
	}

	public static bool Fillet(ICurve C1, ICurve C2, double radius, bool flip1, bool flip2, bool trim1, bool trim2, out Arc fillet)
	{
		return Fillet(C1, C2, null, radius, flip1, flip2, trim1, trim2, out fillet);
	}

	public static bool Fillet(ICurve C1, ICurve C2, Vector3D planeNormal, double radius, bool flip1, bool flip2, bool trim1, bool trim2, out Arc fillet)
	{
		bool _0023_003DzxarKE0_b7mfP;
		bool _0023_003DzJzDd5JWc4Zih;
		return _0023_003DzPBKz88Xf9aEE(C1, C2, planeNormal, radius, flip1, flip2, trim1, trim2, out fillet, out _0023_003DzxarKE0_b7mfP, out _0023_003DzJzDd5JWc4Zih);
	}

	internal static bool _0023_003DzPBKz88Xf9aEE(ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003DzEGKj_0024SNUUihi, bool _0023_003DztMfmrg831haV, bool _0023_003DzJ3tTnH9nlIDz, bool _0023_003DzR7z_0024HyI_003D, bool _0023_003DzHBg2_aY_003D, out Arc _0023_003Dzxt7paKBusKOo, out bool _0023_003DzxarKE0_b7mfP, out bool _0023_003DzJzDd5JWc4Zih)
	{
		_0023_003Dzxt7paKBusKOo = null;
		_0023_003DzxarKE0_b7mfP = false;
		_0023_003DzJzDd5JWc4Zih = false;
		if (_0023_003DzytDpi1c_003D is Line _0023_003DziMjqlCo_003D && _0023_003Dzn8t0_00249E_003D is Line _0023_003DzI4dRPW0_003D)
		{
			return _0023_003Dzh1tohAQ0tEDwVFL2tg_003D_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003Dz2ouPUQ9dmipO, _0023_003DzEGKj_0024SNUUihi, _0023_003DztMfmrg831haV, _0023_003DzJ3tTnH9nlIDz, _0023_003DzR7z_0024HyI_003D, _0023_003DzHBg2_aY_003D, out _0023_003Dzxt7paKBusKOo, out _0023_003DzxarKE0_b7mfP, out _0023_003DzJzDd5JWc4Zih);
		}
		Curve curve = ((_0023_003DzytDpi1c_003D is Curve) ? ((Curve)_0023_003DzytDpi1c_003D.Clone()) : _0023_003DzytDpi1c_003D.GetNurbsForm());
		Curve curve2 = ((_0023_003Dzn8t0_00249E_003D is Curve) ? ((Curve)_0023_003Dzn8t0_00249E_003D.Clone()) : _0023_003Dzn8t0_00249E_003D.GetNurbsForm());
		curve.ControlBoundingBox(out var min, out var max);
		curve2.ControlBoundingBox(out var min2, out var max2);
		double diagonal = new Size3D(min, max).Diagonal;
		double diagonal2 = new Size3D(min2, max2).Diagonal;
		double num = Math.Min(diagonal, diagonal2);
		double num2 = num * 0.001;
		if (_0023_003Dz2ouPUQ9dmipO == null && !_0023_003DzGGa1wnhE55SRoVs2Aac8QII_003D(_0023_003DzytDpi1c_003D, _0023_003Dzn8t0_00249E_003D, num2, out _0023_003Dz2ouPUQ9dmipO))
		{
			return false;
		}
		Plane plane = new Plane(curve.StartPoint, _0023_003Dz2ouPUQ9dmipO);
		if (!_0023_003DzytDpi1c_003D.IsInPlane(plane, num2) || !_0023_003Dzn8t0_00249E_003D.IsInPlane(plane, num2))
		{
			return false;
		}
		if (_0023_003DztMfmrg831haV)
		{
			curve.Reverse();
		}
		if (_0023_003DzJ3tTnH9nlIDz)
		{
			curve2.Reverse();
		}
		Point3D[] array = Utility._0023_003DzQ7usAag_003D(curve, curve2, 0.0, num, _0023_003DzRn5G27jw1CX8cwaOeA_003D_003D: false, _0023_003DzEGKj_0024SNUUihi, _0023_003Dz2ouPUQ9dmipO);
		if (array.Length != 0)
		{
			InterPoint interPoint = (InterPoint)array[0];
			Point3D point3D = curve.PointAt(interPoint.u);
			Point3D point3D2 = curve2.PointAt(interPoint.s);
			_0023_003Dzxt7paKBusKOo = new Arc(interPoint, point3D, point3D2);
			Vector3D vector3D = curve.TangentAt(interPoint.u);
			if (_0023_003DztMfmrg831haV)
			{
				vector3D *= -1.0;
			}
			Vector3D vector3D2 = curve2.TangentAt(interPoint.s);
			if (_0023_003DzJ3tTnH9nlIDz)
			{
				vector3D2 *= -1.0;
			}
			if (vector3D * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
			{
				if (_0023_003DzR7z_0024HyI_003D && !_0023_003DzytDpi1c_003D.TrimBy(point3D, flipSide: false))
				{
					_0023_003DzxarKE0_b7mfP = true;
				}
				if (_0023_003DzHBg2_aY_003D)
				{
					if (vector3D2 * _0023_003Dzxt7paKBusKOo.EndTangent >= 0.0)
					{
						if (!_0023_003Dzn8t0_00249E_003D.TrimBy(point3D2, flipSide: true))
						{
							_0023_003DzJzDd5JWc4Zih = true;
						}
					}
					else if (!_0023_003Dzn8t0_00249E_003D.TrimBy(point3D2, flipSide: false))
					{
						_0023_003DzJzDd5JWc4Zih = true;
					}
				}
			}
			else
			{
				_0023_003Dzxt7paKBusKOo.Reverse();
				if (_0023_003DzR7z_0024HyI_003D && !_0023_003DzytDpi1c_003D.TrimBy(point3D, flipSide: true))
				{
					_0023_003DzxarKE0_b7mfP = true;
				}
				if (_0023_003DzHBg2_aY_003D)
				{
					if (vector3D2 * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
					{
						if (!_0023_003Dzn8t0_00249E_003D.TrimBy(point3D2, flipSide: false))
						{
							_0023_003DzJzDd5JWc4Zih = true;
						}
					}
					else if (!_0023_003Dzn8t0_00249E_003D.TrimBy(point3D2, flipSide: true))
					{
						_0023_003DzJzDd5JWc4Zih = true;
					}
				}
			}
			return true;
		}
		return false;
	}

	private static bool _0023_003Dzh1tohAQ0tEDwVFL2tg_003D_003D(Line _0023_003DziMjqlCo_003D, Line _0023_003DzI4dRPW0_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003DzEGKj_0024SNUUihi, bool _0023_003DztMfmrg831haV, bool _0023_003DzJ3tTnH9nlIDz, bool _0023_003DzR7z_0024HyI_003D, bool _0023_003DzHBg2_aY_003D, out Arc _0023_003Dzxt7paKBusKOo, out bool _0023_003DzxarKE0_b7mfP, out bool _0023_003DzJzDd5JWc4Zih)
	{
		_0023_003Dzxt7paKBusKOo = null;
		_0023_003DzxarKE0_b7mfP = false;
		_0023_003DzJzDd5JWc4Zih = false;
		if (_0023_003Dz2ouPUQ9dmipO == null && !_0023_003DzGGa1wnhE55SRoVs2Aac8QII_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, out _0023_003Dz2ouPUQ9dmipO))
		{
			return false;
		}
		Vector3D vector3D = (Vector3D)_0023_003Dz2ouPUQ9dmipO.Clone();
		vector3D.Negate();
		Line line = (Line)_0023_003DziMjqlCo_003D.Clone();
		Line line2 = (Line)_0023_003DzI4dRPW0_003D.Clone();
		if (_0023_003DztMfmrg831haV)
		{
			line.Reverse();
		}
		if (_0023_003DzJ3tTnH9nlIDz)
		{
			line2.Reverse();
		}
		Vector3D tangent = line.Tangent;
		Vector3D tangent2 = line2.Tangent;
		Plane plane = new Plane(_0023_003DziMjqlCo_003D.StartPoint, vector3D);
		Vector3D vector3D2 = Vector3D.Cross(tangent, vector3D);
		vector3D2.Normalize();
		Vector3D vector3D3 = Vector3D.Cross(tangent2, vector3D);
		vector3D3.Normalize();
		Point3D p = line.StartPoint + _0023_003DzEGKj_0024SNUUihi * vector3D2;
		Point3D p2 = line.EndPoint + _0023_003DzEGKj_0024SNUUihi * vector3D2;
		Point3D p3 = line2.StartPoint + _0023_003DzEGKj_0024SNUUihi * vector3D3;
		Point3D p4 = line2.EndPoint + _0023_003DzEGKj_0024SNUUihi * vector3D3;
		double[] array = new double[3];
		plane.Project(p, out var s, out var t);
		plane.Project(p2, out var s2, out var t2);
		plane.Project(p3, out var s3, out var t3);
		plane.Project(p4, out var s4, out var t4);
		_0023_003Dz3gDqXOUFJiUcM_0024X5zg_003D_003D._0023_003Dzh5EZUSHeFDvX(s, t, s2, t2, s3, t3, s4, t4, ref array);
		Point3D point3D = plane.PointAt(array[1], array[2]);
		line.Project(point3D, out var t5);
		Point3D point3D2 = line.PointAt(t5);
		if (!point3D2.IsOnCurve(line, Utility._0023_003DzxhnLabVjXjPg))
		{
			return false;
		}
		line2.Project(point3D, out var t6);
		Point3D point3D3 = line2.PointAt(t6);
		if (!point3D3.IsOnCurve(line2, Utility._0023_003DzxhnLabVjXjPg))
		{
			return false;
		}
		if (point3D == point3D2 || point3D == point3D3)
		{
			return false;
		}
		_0023_003Dzxt7paKBusKOo = new Arc(point3D, point3D2, point3D3);
		if (_0023_003DztMfmrg831haV)
		{
			tangent.Negate();
		}
		if (_0023_003DzJ3tTnH9nlIDz)
		{
			tangent2.Negate();
		}
		if (tangent * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
		{
			if (_0023_003DzR7z_0024HyI_003D && !_0023_003DziMjqlCo_003D.TrimBy(point3D2, flipSide: false))
			{
				_0023_003DzxarKE0_b7mfP = true;
			}
			if (_0023_003DzHBg2_aY_003D)
			{
				if (tangent2 * _0023_003Dzxt7paKBusKOo.EndTangent >= 0.0)
				{
					if (!_0023_003DzI4dRPW0_003D.TrimBy(point3D3, flipSide: true))
					{
						_0023_003DzJzDd5JWc4Zih = true;
					}
				}
				else if (!_0023_003DzI4dRPW0_003D.TrimBy(point3D3, flipSide: false))
				{
					_0023_003DzJzDd5JWc4Zih = true;
				}
			}
		}
		else
		{
			_0023_003Dzxt7paKBusKOo.Reverse();
			if (_0023_003DzR7z_0024HyI_003D && !_0023_003DziMjqlCo_003D.TrimBy(point3D2, flipSide: true))
			{
				_0023_003DzxarKE0_b7mfP = true;
			}
			if (_0023_003DzHBg2_aY_003D)
			{
				if (tangent2 * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
				{
					if (!_0023_003DzI4dRPW0_003D.TrimBy(point3D3, flipSide: false))
					{
						_0023_003DzJzDd5JWc4Zih = true;
					}
				}
				else if (!_0023_003DzI4dRPW0_003D.TrimBy(point3D3, flipSide: true))
				{
					_0023_003DzJzDd5JWc4Zih = true;
				}
			}
		}
		return true;
	}

	private static bool _0023_003DzGGa1wnhE55SRoVs2Aac8QII_003D(ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D, double _0023_003DzHIoSuMBqJmo9CITGnA_003D_003D, out Vector3D _0023_003Dz2ouPUQ9dmipO)
	{
		if (_0023_003DzytDpi1c_003D is PlanarEntity)
		{
			_0023_003Dz2ouPUQ9dmipO = ((PlanarEntity)_0023_003DzytDpi1c_003D).Plane.AxisZ;
			return true;
		}
		if (_0023_003Dzn8t0_00249E_003D is PlanarEntity)
		{
			_0023_003Dz2ouPUQ9dmipO = ((PlanarEntity)_0023_003Dzn8t0_00249E_003D).Plane.AxisZ;
			return true;
		}
		if (_0023_003DzytDpi1c_003D is CompositeCurve)
		{
			foreach (ICurve curve3 in ((CompositeCurve)_0023_003DzytDpi1c_003D).CurveList)
			{
				if (curve3 is PlanarEntity)
				{
					_0023_003Dz2ouPUQ9dmipO = ((PlanarEntity)curve3).Plane.AxisZ;
					return true;
				}
			}
		}
		if (_0023_003Dzn8t0_00249E_003D is CompositeCurve)
		{
			foreach (ICurve curve4 in ((CompositeCurve)_0023_003Dzn8t0_00249E_003D).CurveList)
			{
				if (curve4 is PlanarEntity)
				{
					_0023_003Dz2ouPUQ9dmipO = ((PlanarEntity)curve4).Plane.AxisZ;
					return true;
				}
			}
		}
		_0023_003Dz2ouPUQ9dmipO = Vector3D.Cross(_0023_003DzytDpi1c_003D.StartTangent, _0023_003Dzn8t0_00249E_003D.StartTangent);
		if (Utility.AreEqual(_0023_003Dz2ouPUQ9dmipO.LengthSquared, 0.0, 1.0))
		{
			Curve curve = ((_0023_003DzytDpi1c_003D is Curve) ? ((Curve)_0023_003DzytDpi1c_003D) : _0023_003DzytDpi1c_003D.GetNurbsForm());
			Curve curve2 = ((_0023_003Dzn8t0_00249E_003D is Curve) ? ((Curve)_0023_003Dzn8t0_00249E_003D) : _0023_003Dzn8t0_00249E_003D.GetNurbsForm());
			if (curve.ControlPoints.Length > 2)
			{
				Vector3D a = new Vector3D(curve.ControlPoints[0].Euclid, curve.ControlPoints[1].Euclid);
				Vector3D b = new Vector3D(curve.ControlPoints[1].Euclid, curve.ControlPoints[2].Euclid);
				_0023_003Dz2ouPUQ9dmipO = Vector3D.Cross(a, b);
			}
			else
			{
				if (curve2.ControlPoints.Length <= 2)
				{
					return false;
				}
				Vector3D a2 = new Vector3D(curve2.ControlPoints[0].Euclid, curve2.ControlPoints[1].Euclid);
				Vector3D b2 = new Vector3D(curve2.ControlPoints[1].Euclid, curve2.ControlPoints[2].Euclid);
				_0023_003Dz2ouPUQ9dmipO = Vector3D.Cross(a2, b2);
			}
			if (Utility.AreEqual(_0023_003Dz2ouPUQ9dmipO.LengthSquared, 0.0, 1.0))
			{
				if (_0023_003DzytDpi1c_003D.IsPlanar(_0023_003DzHIoSuMBqJmo9CITGnA_003D_003D, out var plane) && _0023_003Dzn8t0_00249E_003D.IsInPlane(plane, _0023_003DzHIoSuMBqJmo9CITGnA_003D_003D))
				{
					_0023_003Dz2ouPUQ9dmipO = plane.AxisZ;
					return true;
				}
				if (_0023_003Dzn8t0_00249E_003D.IsPlanar(_0023_003DzHIoSuMBqJmo9CITGnA_003D_003D, out plane) && _0023_003DzytDpi1c_003D.IsInPlane(plane, _0023_003DzHIoSuMBqJmo9CITGnA_003D_003D))
				{
					_0023_003Dz2ouPUQ9dmipO = plane.AxisZ;
					return true;
				}
			}
		}
		_0023_003Dz2ouPUQ9dmipO.Normalize();
		return true;
	}

	private static bool _0023_003DzGGa1wnhE55SRoVs2Aac8QII_003D(Line _0023_003DziMjqlCo_003D, Line _0023_003DzI4dRPW0_003D, out Vector3D _0023_003Dz2ouPUQ9dmipO)
	{
		Vector3D startTangent = _0023_003DziMjqlCo_003D.StartTangent;
		Vector3D startTangent2 = _0023_003DzI4dRPW0_003D.StartTangent;
		if (Vector3D.AreParallel(startTangent, startTangent2))
		{
			_0023_003Dz2ouPUQ9dmipO = null;
			return false;
		}
		_0023_003Dz2ouPUQ9dmipO = Vector3D.Cross(startTangent, startTangent2);
		_0023_003Dz2ouPUQ9dmipO.Normalize();
		return true;
	}

	public static bool Chamfer(ICurve C1, ICurve C2, double distance, bool flip1, bool flip2, bool trim1, bool trim2, out Line chamfer)
	{
		return Chamfer(C1, C2, null, distance, flip1, flip2, trim1, trim2, out chamfer);
	}

	public static bool Chamfer(ICurve C1, ICurve C2, Vector3D planeNormal, double distance, bool flip1, bool flip2, bool trim1, bool trim2, out Line chamfer)
	{
		bool _0023_003DzxarKE0_b7mfP;
		bool _0023_003DzJzDd5JWc4Zih;
		return _0023_003DzIiP18cNbYFuU(C1, C2, planeNormal, distance, flip1, flip2, trim1, trim2, out chamfer, out _0023_003DzxarKE0_b7mfP, out _0023_003DzJzDd5JWc4Zih);
	}

	internal static bool _0023_003DzIiP18cNbYFuU(ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003DzYUMqwZQ_003D, bool _0023_003DztMfmrg831haV, bool _0023_003DzJ3tTnH9nlIDz, bool _0023_003DzR7z_0024HyI_003D, bool _0023_003DzHBg2_aY_003D, out Line _0023_003DzTcFGbxcG1Gf9, out bool _0023_003DzxarKE0_b7mfP, out bool _0023_003DzJzDd5JWc4Zih)
	{
		_0023_003DzTcFGbxcG1Gf9 = null;
		Arc _0023_003Dzxt7paKBusKOo;
		bool num = _0023_003DzPBKz88Xf9aEE(_0023_003DzytDpi1c_003D, _0023_003Dzn8t0_00249E_003D, _0023_003Dz2ouPUQ9dmipO, _0023_003DzYUMqwZQ_003D, _0023_003DztMfmrg831haV, _0023_003DzJ3tTnH9nlIDz, _0023_003DzR7z_0024HyI_003D, _0023_003DzHBg2_aY_003D, out _0023_003Dzxt7paKBusKOo, out _0023_003DzxarKE0_b7mfP, out _0023_003DzJzDd5JWc4Zih);
		if (num)
		{
			_0023_003DzTcFGbxcG1Gf9 = new Line(_0023_003Dzxt7paKBusKOo.StartPoint, _0023_003Dzxt7paKBusKOo.EndPoint);
		}
		return num;
	}

	public int InsertKnot(double u, int r)
	{
		_0023_003DziP9fFuA_003D.FindSpanMult(u, _0023_003DzB68dg9Q_003D, out var k, out var s);
		if (r + s > _0023_003DzB68dg9Q_003D)
		{
			r = _0023_003DzB68dg9Q_003D - s;
		}
		if (r <= 0)
		{
			return 0;
		}
		int num = _0023_003DzMv2C5Tm1QMvc();
		int num2 = num + _0023_003DzB68dg9Q_003D + 1;
		Array.Resize(ref Pw, _0023_003DzMv2C5Tm1QMvc() + r);
		Array.Copy(Pw, k - s, Pw, k - s + r, num - k + s);
		Pw[k - s] = (Point4D)Pw[k - s].Clone();
		for (int i = 1; i <= r; i++)
		{
			int num3 = k - _0023_003DzB68dg9Q_003D + i - 1;
			_0023_003DzFKwzf8H4YdULHGmd9sQ1YwA_003D _0023_003DzjbqS1qE_003D = Pw[num3++]._0023_003DzooidtLbos_0024Ev();
			while (num3 <= k - s)
			{
				double _0023_003Dz1v6oPQk_003D = (u - _0023_003DziP9fFuA_003D[num3]) / (_0023_003DziP9fFuA_003D[num3 + _0023_003DzB68dg9Q_003D - i + 1] - _0023_003DziP9fFuA_003D[num3]);
				_0023_003DzFKwzf8H4YdULHGmd9sQ1YwA_003D _0023_003DzjbqS1qE_003D2 = Pw[num3]._0023_003DzooidtLbos_0024Ev();
				_0023_003DzFKwzf8H4YdULHGmd9sQ1YwA_003D _0023_003DzY5pSLwI_003D = _0023_003Dz1v6oPQk_003D * _0023_003DzjbqS1qE_003D2 + ILSpyHelper_AsRefReadOnly(1.0 - _0023_003Dz1v6oPQk_003D) * _0023_003DzjbqS1qE_003D;
				Pw[num3]._0023_003Dz6oTiXS0_003D(in _0023_003DzY5pSLwI_003D);
				num3++;
				_0023_003DzjbqS1qE_003D = _0023_003DzjbqS1qE_003D2;
			}
			if (i < r)
			{
				Pw[k + r - s - i] = (Point4D)Pw[num3 - 1].Clone();
			}
		}
		Array.Resize(ref _0023_003DziP9fFuA_003D, _0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D + 1);
		Array.Copy(_0023_003DziP9fFuA_003D, k + 1, _0023_003DziP9fFuA_003D, k + 1 + r, num2 - k - 1);
		for (int j = 1; j <= r; j++)
		{
			_0023_003DziP9fFuA_003D[k + j] = u;
		}
		RegenMode = regenType.RegenAndCompile;
		return r;
		static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
		{
			//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
			return ref temp;
		}
	}

	public bool InsertKnot(Point3D ctrlPoint, int r)
	{
		if (_0023_003DzKWdaQi8_003D(ctrlPoint, _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzNDQ_E88_003D))
		{
			NurbsBase._0023_003Dzy_0024hwVn0_003D(ref _0023_003DzNDQ_E88_003D, _0023_003DziP9fFuA_003D, Domain.Length);
			if (InsertKnot(_0023_003DzNDQ_E88_003D, r) != 0)
			{
				return true;
			}
		}
		RegenMode = regenType.RegenAndCompile;
		return false;
	}

	public bool AddControlPoint(Point3D ctrlPoint)
	{
		double num = ControlBoundingBox().Diagonal * Utility._0023_003DzheSR8QM7q9ya;
		Point3D b = null;
		double num2 = double.MaxValue;
		int num3 = -1;
		for (int i = 1; i < ControlPoints.Length; i++)
		{
			Segment3D segment3D = new Segment3D(ControlPoints[i - 1].Euclid, ControlPoints[i].Euclid);
			if (segment3D.Length > num)
			{
				double num4 = segment3D.Project(ctrlPoint);
				double num5 = ctrlPoint.DistanceTo(segment3D);
				if (num4 > -1E-09 && num4 < 1.000000001 && num5 < num2)
				{
					num2 = num5;
					b = segment3D.PointAt(num4);
					num3 = i;
				}
			}
		}
		if (num3 == -1)
		{
			return false;
		}
		Point4D point4D = ControlPoints[num3 - 1];
		Point3D euclid = point4D.Euclid;
		Point4D point4D2 = ControlPoints[num3];
		double num6 = point4D.W * euclid.DistanceTo(b) / (point4D.W * euclid.DistanceTo(b) + point4D2.W * point4D2.Euclid.DistanceTo(b));
		double num7 = _0023_003DziP9fFuA_003D[num3];
		double _0023_003Dz_eY3Y4c_003D = num7 + num6 * (_0023_003DziP9fFuA_003D[num3 + _0023_003DzB68dg9Q_003D] - num7);
		NurbsBase._0023_003Dzy_0024hwVn0_003D(ref _0023_003Dz_eY3Y4c_003D, _0023_003DziP9fFuA_003D, Domain.Length);
		if (InsertKnot(_0023_003Dz_eY3Y4c_003D, 1) != 0)
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public void RefineKnotVector(double[] X)
	{
		int num = _0023_003DzFNjygTLTZtF3();
		int num2 = num + _0023_003DzB68dg9Q_003D + 1;
		int num3 = X.Length - 1;
		Curve curve = (Curve)Clone();
		Resize(num3 + 1 + num + 1, _0023_003DzB68dg9Q_003D);
		int num4 = curve._0023_003DziP9fFuA_003D.FindSpan(num, _0023_003DzB68dg9Q_003D, X[0]);
		int num5 = curve._0023_003DziP9fFuA_003D.FindSpan(num, _0023_003DzB68dg9Q_003D, X[num3]);
		num5++;
		Point4D[] pw = Pw;
		double[] array = _0023_003DziP9fFuA_003D;
		for (int i = 0; i <= num4 - _0023_003DzB68dg9Q_003D; i++)
		{
			pw[i] = (Point4D)curve.Pw[i].Clone();
		}
		for (int j = num5 - 1; j <= num; j++)
		{
			pw[j + num3 + 1] = (Point4D)curve.Pw[j].Clone();
		}
		for (int k = 0; k <= num4; k++)
		{
			array[k] = curve._0023_003DziP9fFuA_003D[k];
		}
		for (int l = num5 + _0023_003DzB68dg9Q_003D; l <= num2; l++)
		{
			array[l + num3 + 1] = curve._0023_003DziP9fFuA_003D[l];
		}
		int num6 = num5 + _0023_003DzB68dg9Q_003D - 1;
		int num7 = num5 + _0023_003DzB68dg9Q_003D + num3;
		for (int num8 = num3; num8 >= 0; num8--)
		{
			while (X[num8] <= curve._0023_003DziP9fFuA_003D[num6] && num6 > num4)
			{
				pw[num7 - _0023_003DzB68dg9Q_003D - 1] = curve.Pw[num6 - _0023_003DzB68dg9Q_003D - 1];
				array[num7] = curve._0023_003DziP9fFuA_003D[num6];
				num7--;
				num6--;
			}
			pw[num7 - _0023_003DzB68dg9Q_003D - 1] = pw[num7 - _0023_003DzB68dg9Q_003D];
			for (int m = 1; m <= _0023_003DzB68dg9Q_003D; m++)
			{
				int num9 = num7 - _0023_003DzB68dg9Q_003D + m;
				double num10 = array[num7 + m] - X[num8];
				if (Math.Abs(num10) == 0.0)
				{
					pw[num9 - 1] = (Point4D)pw[num9].Clone();
					continue;
				}
				num10 /= array[num7 + m] - curve._0023_003DziP9fFuA_003D[num6 - _0023_003DzB68dg9Q_003D + m];
				pw[num9 - 1] = num10 * pw[num9 - 1] + (1.0 - num10) * pw[num9];
			}
			array[num7] = X[num8];
			num7--;
		}
		RegenMode = regenType.RegenAndCompile;
	}

	public void DegreeElevate(int t)
	{
		if (t <= 0)
		{
			return;
		}
		int num = _0023_003DzFNjygTLTZtF3() + _0023_003DzB68dg9Q_003D + 1;
		int num2 = _0023_003DzB68dg9Q_003D + t;
		int num3 = num2 / 2;
		double[,] array = new double[_0023_003DzB68dg9Q_003D + t + 1, _0023_003DzB68dg9Q_003D + 1];
		Point4D[] array2 = new Point4D[_0023_003DzB68dg9Q_003D + 1];
		Point4D[] array3 = new Point4D[_0023_003DzB68dg9Q_003D + t + 1];
		Point4D[] array4 = new Point4D[_0023_003DzB68dg9Q_003D - 1];
		double[] array5 = new double[_0023_003DzB68dg9Q_003D - 1];
		array[0, 0] = (array[num2, _0023_003DzB68dg9Q_003D] = 1.0);
		for (int i = 1; i <= num3; i++)
		{
			double num4 = 1.0 / NurbsBase._0023_003Dz_0024Ad3BZI_003D(num2, i);
			int num5 = Math.Min(_0023_003DzB68dg9Q_003D, i);
			for (int j = Math.Max(0, i - t); j <= num5; j++)
			{
				array[i, j] = num4 * NurbsBase._0023_003Dz_0024Ad3BZI_003D(_0023_003DzB68dg9Q_003D, j) * NurbsBase._0023_003Dz_0024Ad3BZI_003D(t, i - j);
			}
		}
		for (int i = num3 + 1; i < num2; i++)
		{
			int num5 = Math.Min(_0023_003DzB68dg9Q_003D, i);
			for (int j = Math.Max(0, i - t); j <= num5; j++)
			{
				array[i, j] = array[num2 - i, _0023_003DzB68dg9Q_003D - j];
			}
		}
		Curve curve = new Curve();
		curve.Resize(_0023_003DzMv2C5Tm1QMvc() + _0023_003DzMv2C5Tm1QMvc() * t, num2);
		int num6 = num2;
		int num7 = num2 + 1;
		int num8 = -1;
		int num9 = _0023_003DzB68dg9Q_003D;
		int k = _0023_003DzB68dg9Q_003D + 1;
		int num10 = 1;
		double num11 = Domain.Low;
		Point4D[] pw = curve.Pw;
		double[] array6 = curve._0023_003DziP9fFuA_003D;
		pw[0] = Pw[0];
		for (int i = 0; i <= num2; i++)
		{
			array6[i] = num11;
		}
		for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
		{
			array2[i] = Pw[i];
		}
		while (k < num)
		{
			int i = k;
			for (; k < num && _0023_003DziP9fFuA_003D[k] == _0023_003DziP9fFuA_003D[k + 1]; k++)
			{
			}
			int num12 = k - i + 1;
			num6 += num12 + t;
			double num13 = _0023_003DziP9fFuA_003D[k];
			int num14 = num8;
			num8 = _0023_003DzB68dg9Q_003D - num12;
			int num15 = ((num14 <= 0) ? 1 : ((num14 + 2) / 2));
			int num16 = ((num8 <= 0) ? num2 : (num2 - (num8 + 1) / 2));
			if (num8 > 0)
			{
				double num17 = num13 - num11;
				for (int num18 = _0023_003DzB68dg9Q_003D; num18 > num12; num18--)
				{
					array5[num18 - num12 - 1] = num17 / (_0023_003DziP9fFuA_003D[num9 + num18] - num11);
				}
				for (int j = 1; j <= num8; j++)
				{
					int num19 = num8 - j;
					int num20 = num12 + j;
					for (int num18 = _0023_003DzB68dg9Q_003D; num18 >= num20; num18--)
					{
						array2[num18] = array5[num18 - num20] * array2[num18] + (1.0 - array5[num18 - num20]) * array2[num18 - 1];
					}
					array4[num19] = array2[_0023_003DzB68dg9Q_003D];
				}
			}
			for (i = num15; i <= num2; i++)
			{
				array3[i] = new Point4D();
				int num5 = Math.Min(_0023_003DzB68dg9Q_003D, i);
				for (int j = Math.Max(0, i - t); j <= num5; j++)
				{
					Point4D[] array7 = array3;
					int num21 = i;
					array7[num21] += array[i, j] * array2[j];
				}
			}
			if (num14 > 1)
			{
				int num22 = num7 - 2;
				int num23 = num7;
				double num24 = num13 - num11;
				double num25 = (num13 - array6[num7 - 1]) / num24;
				for (int l = 1; l < num14; l++)
				{
					i = num22;
					int j = num23;
					int num26 = j - num7 + 1;
					while (j - i > l)
					{
						if (i < num10)
						{
							double num27 = (num13 - array6[i]) / (num11 - array6[i]);
							pw[i] = num27 * pw[i] + (1.0 - num27) * pw[i - 1];
						}
						if (j >= num15)
						{
							if (j - l <= num7 - num2 + num14)
							{
								double num28 = (num13 - array6[j - l]) / num24;
								array3[num26] = num28 * array3[num26] + (1.0 - num28) * array3[num26 + 1];
							}
							else
							{
								array3[num26] = num25 * array3[num26] + (1.0 - num25) * array3[num26 + 1];
							}
						}
						i++;
						j--;
						num26--;
					}
					num22--;
					num23++;
				}
			}
			if (num9 != _0023_003DzB68dg9Q_003D)
			{
				for (i = 0; i < num2 - num14; i++)
				{
					array6[num7] = num11;
					num7++;
				}
			}
			for (int j = num15; j <= num16; j++)
			{
				pw[num10] = array3[j];
				num10++;
			}
			if (k < num)
			{
				for (int j = 0; j < num8; j++)
				{
					array2[j] = array4[j];
				}
				for (int j = num8; j <= _0023_003DzB68dg9Q_003D; j++)
				{
					array2[j] = Pw[k - _0023_003DzB68dg9Q_003D + j];
				}
				num9 = k;
				k++;
				num11 = num13;
			}
			else
			{
				for (i = 0; i <= num2; i++)
				{
					array6[num7 + i] = num13;
				}
			}
		}
		curve.ResizeKeep(num6 - num2, num2);
		Pw = curve.Pw;
		_0023_003DziP9fFuA_003D = curve._0023_003DziP9fFuA_003D;
		_0023_003DzB68dg9Q_003D = curve._0023_003DzB68dg9Q_003D;
		RegenMode = regenType.RegenAndCompile;
	}

	public void DegreeReduction(int t, out double maxError)
	{
		if (_0023_003DzB68dg9Q_003D - t <= 1)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964803));
		}
		maxError = 0.0;
		for (int i = 0; i < t; i++)
		{
			int num = _0023_003DzB68dg9Q_003D - 1;
			int num2 = num + 1;
			int num3 = -1;
			int num4 = _0023_003DzB68dg9Q_003D;
			int j = _0023_003DzB68dg9Q_003D + 1;
			int num5 = 1;
			int num6 = _0023_003DzFNjygTLTZtF3() + _0023_003DzB68dg9Q_003D + 1;
			int num7 = num6 - NurbsBase._0023_003DzV5xO_7_KG_6g6UfMSw_003D_003D(_0023_003DziP9fFuA_003D) + 1;
			int num8 = num7 - num - 1;
			double[] array = new double[num7];
			Point4D[] array2 = new Point4D[num8];
			Point4D[] array3 = new Point4D[_0023_003DzB68dg9Q_003D + 1];
			double[] array4 = new double[num6];
			array2[0] = Pw[0];
			for (int k = 0; k <= num; k++)
			{
				array[k] = _0023_003DziP9fFuA_003D[0];
			}
			for (int l = 0; l <= _0023_003DzB68dg9Q_003D; l++)
			{
				array3[l] = Pw[l];
			}
			for (int m = 0; m < num6; m++)
			{
				array4[m] = 0.0;
			}
			while (j < num6)
			{
				int num9 = j;
				for (; j < num6 && Math.Abs(_0023_003DziP9fFuA_003D[j] - _0023_003DziP9fFuA_003D[j + 1]) < 1E-12; j++)
				{
				}
				int num10 = j - num9 + 1;
				int num11 = num3;
				num3 = _0023_003DzB68dg9Q_003D - num10;
				int num12 = ((num11 <= 0) ? 1 : ((num11 + 2) / 2));
				Point4D[] array5 = new Point4D[_0023_003DzB68dg9Q_003D - 1];
				if (num3 > 0)
				{
					double num13 = _0023_003DziP9fFuA_003D[j] - _0023_003DziP9fFuA_003D[num4];
					double[] array6 = new double[_0023_003DzB68dg9Q_003D - 1];
					for (int num14 = _0023_003DzB68dg9Q_003D; num14 > num10; num14--)
					{
						array6[num14 - num10 - 1] = num13 / (_0023_003DziP9fFuA_003D[num4 + num14] - _0023_003DziP9fFuA_003D[num4]);
					}
					for (int n = 1; n <= num3; n++)
					{
						int num15 = num3 - n;
						int num16 = num10 + n;
						for (int num17 = _0023_003DzB68dg9Q_003D; num17 >= num16; num17--)
						{
							array3[num17] = array6[num17 - num16] * array3[num17] + (1.0 - array6[num17 - num16]) * array3[num17 - 1];
						}
						array5[num15] = array3[_0023_003DzB68dg9Q_003D];
					}
				}
				double _0023_003DzKSmCpOiVsEKZ;
				Point4D[] array7 = _0023_003DzHLd4IK_KoL7r(array3, out _0023_003DzKSmCpOiVsEKZ);
				array4[num4] += _0023_003DzKSmCpOiVsEKZ;
				if (num11 > 0)
				{
					int num18 = num2;
					int num19 = num2;
					for (int num20 = 0; num20 < num11; num20++)
					{
						num9 = num18;
						int num21 = num19;
						int num22 = num21 - num2;
						while (num21 - num9 > num20)
						{
							double num23 = (_0023_003DziP9fFuA_003D[num4] - array[num9 - 1]) / (_0023_003DziP9fFuA_003D[j] - array[num9 - 1]);
							double num24 = (_0023_003DziP9fFuA_003D[num4] - array[num21 - num20 - 1]) / (_0023_003DziP9fFuA_003D[j] - array[num21 - num20 - 1]);
							array2[num9 - 1] = (array2[num9 - 1] - (1.0 - num23) * array2[num9 - 2]) / num23;
							array7[num22] = (array7[num22] - num24 * array7[num22 + 1]) / (1.0 - num24);
							num9++;
							num21--;
							num22--;
						}
						double num25;
						if (num21 - num9 < num20)
						{
							num25 = Point4D.Distance(array2[num9 - 2], array7[num22 + 1]);
						}
						else
						{
							double num26 = (_0023_003DziP9fFuA_003D[num4] - array[num9 - 1]) / (_0023_003DziP9fFuA_003D[j] - array[num9 - 1]);
							Point4D b = num26 * array7[num22 + 1] + (1.0 - num26) * array2[num9 - 2];
							num25 = Point4D.Distance(array2[num9 - 1], b);
						}
						int num27 = num4 + num11 - num20;
						int num28 = (2 * _0023_003DzB68dg9Q_003D - num20 + 1) / 2;
						for (int num29 = num27 - num28; num29 <= num4; num29++)
						{
							array4[num29] += num25;
						}
						num18--;
						num19++;
					}
					num5 = num9 - 1;
				}
				if (num4 != _0023_003DzB68dg9Q_003D)
				{
					for (num9 = 0; num9 < num - num11; num9++)
					{
						array[num2] = _0023_003DziP9fFuA_003D[num4];
						num2++;
					}
				}
				for (num9 = num12; num9 <= num; num9++)
				{
					array2[num5] = array7[num9];
					num5++;
				}
				if (j < num6)
				{
					for (num9 = 0; num9 < num3; num9++)
					{
						array3[num9] = array5[num9];
					}
					for (num9 = num3; num9 <= _0023_003DzB68dg9Q_003D; num9++)
					{
						array3[num9] = Pw[j - _0023_003DzB68dg9Q_003D + num9];
					}
					num4 = j;
					j++;
				}
				else
				{
					for (num9 = 0; num9 <= num; num9++)
					{
						array[num2 + num9] = _0023_003DziP9fFuA_003D[j];
					}
				}
			}
			_0023_003DzB68dg9Q_003D = num;
			_0023_003DziP9fFuA_003D = array;
			Pw = array2;
			double num30 = array4.Max();
			if (num30 > maxError)
			{
				maxError = num30;
			}
		}
	}

	private static Point4D[] _0023_003DzHLd4IK_KoL7r(Point4D[] _0023_003DziDLVpbY_003D, out double _0023_003DzKSmCpOiVsEKZ)
	{
		int num = _0023_003DziDLVpbY_003D.Length - 1;
		int num2 = (num - 1) / 2;
		Point4D[] array = new Point4D[num];
		if (num % 2 == 0)
		{
			array[0] = _0023_003DziDLVpbY_003D[0];
			for (int i = 1; i <= num2; i++)
			{
				double num3 = (double)i / (double)num;
				array[i] = (_0023_003DziDLVpbY_003D[i] - num3 * array[i - 1]) / (1.0 - num3);
			}
			array[num - 1] = _0023_003DziDLVpbY_003D[num];
			for (int num4 = num - 2; num4 >= num2 + 1; num4--)
			{
				double num5 = ((double)num4 + 1.0) / (double)num;
				array[num4] = (_0023_003DziDLVpbY_003D[num4 + 1] - (1.0 - num5) * array[num4 + 1]) / num5;
			}
			_0023_003DzKSmCpOiVsEKZ = Point4D.Distance(_0023_003DziDLVpbY_003D[num2 + 1], (array[num2] + array[num2 + 1]) / 2.0);
		}
		else
		{
			array[0] = _0023_003DziDLVpbY_003D[0];
			for (int j = 1; j <= num2 - 1; j++)
			{
				double num6 = (double)j / (double)num;
				array[j] = (_0023_003DziDLVpbY_003D[j] - num6 * array[j - 1]) / (1.0 - num6);
			}
			array[num - 1] = _0023_003DziDLVpbY_003D[num];
			for (int num7 = num - 2; num7 >= num2 + 1; num7--)
			{
				double num8 = ((double)num7 + 1.0) / (double)num;
				array[num7] = (_0023_003DziDLVpbY_003D[num7 + 1] - (1.0 - num8) * array[num7 + 1]) / num8;
			}
			double num9 = (double)num2 / (double)num;
			double num10 = ((double)num2 + 1.0) / (double)num;
			Point4D point4D = (_0023_003DziDLVpbY_003D[num2] - num9 * array[num2 - 1]) / (1.0 - num9);
			Point4D point4D2 = (_0023_003DziDLVpbY_003D[num2 + 1] - (1.0 - num10) * array[num2 + 1]) / num10;
			array[num2] = (point4D + point4D2) / 2.0;
			_0023_003DzKSmCpOiVsEKZ = Point4D.Distance(point4D, point4D2);
		}
		return array;
	}

	public void Rebuild(int pointCount)
	{
		Rebuild(_0023_003DzB68dg9Q_003D, pointCount);
	}

	public void Rebuild(int d, int n)
	{
		double num = 1.0 / (double)(n - 1);
		double[] array = new double[n];
		Point3D[] array2 = new Point3D[n];
		for (int i = 0; i < n; i++)
		{
			array[i] = num * (double)i;
			array2[i] = PointAt(array[i] * Domain.Length + Domain.Low);
		}
		_0023_003DzxfgL9OaoOs_L(array2, array, d);
	}

	public Curve[] Decompose()
	{
		if (IsLine)
		{
			return new Curve[1] { (Curve)Clone() };
		}
		double[] array = new double[_0023_003DzB68dg9Q_003D + 1];
		int num = _0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D;
		int num2 = _0023_003DzB68dg9Q_003D;
		int i = _0023_003DzB68dg9Q_003D + 1;
		int num3 = 0;
		List<Curve> list = new List<Curve>(num);
		for (int j = 0; j < num; j++)
		{
			Curve curve = new Curve();
			curve.Resize(_0023_003DzB68dg9Q_003D + 1, _0023_003DzB68dg9Q_003D);
			curve._0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D;
			list.Add(curve);
		}
		for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
		{
			list[num3].Pw[j] = (Point4D)Pw[j].Clone();
		}
		while (i < num)
		{
			int j = i;
			for (; i < num && _0023_003DziP9fFuA_003D[i + 1] == _0023_003DziP9fFuA_003D[i]; i++)
			{
			}
			int num4 = i - j + 1;
			if (num4 < _0023_003DzB68dg9Q_003D)
			{
				double num5 = _0023_003DziP9fFuA_003D[i] - _0023_003DziP9fFuA_003D[num2];
				for (int num6 = _0023_003DzB68dg9Q_003D; num6 > num4; num6--)
				{
					array[num6 - num4 - 1] = num5 / (_0023_003DziP9fFuA_003D[num2 + num6] - _0023_003DziP9fFuA_003D[num2]);
				}
				int num7 = _0023_003DzB68dg9Q_003D - num4;
				for (int num6 = 1; num6 <= num7; num6++)
				{
					int num8 = num7 - num6;
					int num9 = num4 + num6;
					for (int num10 = _0023_003DzB68dg9Q_003D; num10 >= num9; num10--)
					{
						double num11 = array[num10 - num9];
						list[num3].Pw[num10] = num11 * list[num3].Pw[num10] + (1.0 - num11) * list[num3].Pw[num10 - 1];
					}
					if (i < num)
					{
						list[num3 + 1].Pw[num8] = list[num3].Pw[_0023_003DzB68dg9Q_003D];
					}
				}
			}
			num3++;
			if (i < num)
			{
				for (j = _0023_003DzB68dg9Q_003D - num4; j <= _0023_003DzB68dg9Q_003D; j++)
				{
					list[num3].Pw[j] = (Point4D)Pw[i - _0023_003DzB68dg9Q_003D + j].Clone();
				}
				num2 = i;
				i++;
			}
		}
		double num12 = Domain.Low;
		double num13 = 0.0;
		double[] array2 = new double[2 * (_0023_003DzB68dg9Q_003D + 1)];
		int num14 = 0;
		for (int j = 1; j < _0023_003DziP9fFuA_003D.Length; j++)
		{
			if (_0023_003DziP9fFuA_003D[j] > _0023_003DziP9fFuA_003D[j - 1])
			{
				num13 = _0023_003DziP9fFuA_003D[j];
				num14 = j;
				break;
			}
		}
		for (int num6 = 0; num6 < num3; num6++)
		{
			for (int j = 0; j < array2.Length / 2; j++)
			{
				array2[j] = num12;
			}
			for (int j = array2.Length / 2; j < array2.Length; j++)
			{
				array2[j] = num13;
			}
			list[num6]._0023_003DziP9fFuA_003D = (double[])array2.Clone();
			num12 = num13;
			for (int j = num14 + 1; j < _0023_003DziP9fFuA_003D.Length; j++)
			{
				if (_0023_003DziP9fFuA_003D[j] > _0023_003DziP9fFuA_003D[j - 1])
				{
					num13 = _0023_003DziP9fFuA_003D[j];
					num14 = j;
					break;
				}
			}
		}
		list.RemoveRange(num3, list.Count - num3);
		return list.ToArray();
	}

	public int RemoveKnot(int r, int s, int num)
	{
		if (r < _0023_003DzB68dg9Q_003D + 1 || r > _0023_003DzFNjygTLTZtF3())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964754));
		}
		int num2 = _0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D + 1;
		int num3 = _0023_003DzB68dg9Q_003D + 1;
		int num4 = (2 * r - s - _0023_003DzB68dg9Q_003D) / 2;
		int num5 = r - s;
		int num6 = r - _0023_003DzB68dg9Q_003D;
		Point4D[] array = new Point4D[2 * _0023_003DzB68dg9Q_003D + 1];
		double num7 = _0023_003DziP9fFuA_003D[r];
		int i;
		int num10;
		int num9;
		for (i = 0; i < num; i++)
		{
			int num8 = num6 - 1;
			array[0] = (Point4D)Pw[num8].Clone();
			array[num5 + 1 - num8] = (Point4D)Pw[num5 + 1].Clone();
			num9 = num6;
			num10 = num5;
			int num11 = 1;
			int num12 = num5 - num8;
			while (num10 - num9 > i)
			{
				double num13 = (num7 - _0023_003DziP9fFuA_003D[num9]) / (_0023_003DziP9fFuA_003D[num9 + num3 + i] - _0023_003DziP9fFuA_003D[num9]);
				double num14 = (num7 - _0023_003DziP9fFuA_003D[num10 - i]) / (_0023_003DziP9fFuA_003D[num10 + num3] - _0023_003DziP9fFuA_003D[num10 - i]);
				array[num11] = (Pw[num9] - (1.0 - num13) * array[num11 - 1]) / num13;
				array[num12] = (Pw[num10] - num14 * array[num12 + 1]) / (1.0 - num14);
				num9++;
				num11++;
				num10--;
				num12--;
			}
			num9 = num6;
			num10 = num5;
			while (num10 - num9 > i)
			{
				Pw[num9] = (Point4D)array[num9 - num8].Clone();
				Pw[num10] = (Point4D)array[num10 - num8].Clone();
				num9++;
				num10--;
			}
			num6--;
			num5++;
		}
		if (i == 0)
		{
			return i;
		}
		for (int j = r + 1; j < num2; j++)
		{
			_0023_003DziP9fFuA_003D[j - i] = _0023_003DziP9fFuA_003D[j];
		}
		num10 = num4;
		num9 = num10;
		for (int j = 1; j < i; j++)
		{
			if (j % 2 == 1)
			{
				num9++;
			}
			else
			{
				num10--;
			}
		}
		for (int j = num9 + 1; j < _0023_003DzMv2C5Tm1QMvc(); j++)
		{
			Pw[num10++] = Pw[j];
		}
		ResizeKeep(Pw.Length - i, _0023_003DzB68dg9Q_003D);
		RegenMode = regenType.RegenAndCompile;
		return i;
	}

	public int RemoveKnot(int r, int s, int num, double tol)
	{
		if (r < _0023_003DzB68dg9Q_003D + 1 || r > _0023_003DzFNjygTLTZtF3())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964754));
		}
		if (IsRational)
		{
			double num2 = double.MaxValue;
			double num3 = double.MinValue;
			Point4D[] pw = Pw;
			foreach (Point4D point4D in pw)
			{
				if (point4D.W < num2)
				{
					num2 = point4D.W;
				}
				Point3D euclid = point4D.Euclid;
				double num4 = Math.Sqrt(euclid.X * euclid.X + euclid.Y * euclid.Y + euclid.Z * euclid.Z);
				if (num4 > num3)
				{
					num3 = num4;
				}
			}
			tol = tol * num2 / (1.0 + num3);
		}
		int num5 = _0023_003DzMv2C5Tm1QMvc() + _0023_003DzB68dg9Q_003D + 1;
		int num6 = _0023_003DzB68dg9Q_003D + 1;
		int num7 = (2 * r - s - _0023_003DzB68dg9Q_003D) / 2;
		int num8 = r - s;
		int num9 = r - _0023_003DzB68dg9Q_003D;
		Point4D[] array = new Point4D[2 * _0023_003DzB68dg9Q_003D + 1];
		double num10 = _0023_003DziP9fFuA_003D[r];
		int j;
		int num13;
		int num12;
		for (j = 0; j < num; j++)
		{
			int num11 = num9 - 1;
			array[0] = (Point4D)Pw[num11].Clone();
			array[num8 + 1 - num11] = (Point4D)Pw[num8 + 1].Clone();
			num12 = num9;
			num13 = num8;
			int num14 = 1;
			int num15 = num8 - num11;
			bool flag = false;
			while (num13 - num12 > j)
			{
				double num16 = (num10 - _0023_003DziP9fFuA_003D[num12]) / (_0023_003DziP9fFuA_003D[num12 + num6 + j] - _0023_003DziP9fFuA_003D[num12]);
				double num17 = (num10 - _0023_003DziP9fFuA_003D[num13 - j]) / (_0023_003DziP9fFuA_003D[num13 + num6] - _0023_003DziP9fFuA_003D[num13 - j]);
				array[num14] = (Pw[num12] - (1.0 - num16) * array[num14 - 1]) / num16;
				array[num15] = (Pw[num13] - num17 * array[num15 + 1]) / (1.0 - num17);
				num12++;
				num14++;
				num13--;
				num15--;
			}
			if (num13 - num12 < j)
			{
				if (Point4D.Distance(array[num14 - 1], array[num15 - 1]) <= tol)
				{
					flag = true;
				}
			}
			else
			{
				double num16 = (num10 - _0023_003DziP9fFuA_003D[num12]) / (_0023_003DziP9fFuA_003D[num12 + num6 + j] - _0023_003DziP9fFuA_003D[num12]);
				if (Point4D.Distance(Pw[num12], num16 * array[num14 + j + 1] + (1.0 - num16) * array[num14 - 1]) <= tol)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
			num12 = num9;
			num13 = num8;
			while (num13 - num12 > j)
			{
				Pw[num12] = (Point4D)array[num12 - num11].Clone();
				Pw[num13] = (Point4D)array[num13 - num11].Clone();
				num12++;
				num13--;
			}
			num9--;
			num8++;
		}
		if (j == 0)
		{
			return j;
		}
		for (int k = r + 1; k < num5; k++)
		{
			_0023_003DziP9fFuA_003D[k - j] = _0023_003DziP9fFuA_003D[k];
		}
		num13 = num7;
		num12 = num13;
		for (int k = 1; k < j; k++)
		{
			if (k % 2 == 1)
			{
				num12++;
			}
			else
			{
				num13--;
			}
		}
		for (int k = num12 + 1; k < _0023_003DzMv2C5Tm1QMvc(); k++)
		{
			Pw[num13++] = Pw[k];
		}
		ResizeKeep(Pw.Length - j, _0023_003DzB68dg9Q_003D);
		RegenMode = regenType.RegenAndCompile;
		return j;
	}

	public int RemoveKnots(double tol)
	{
		Point4D[] pw = Pw;
		double[] array = _0023_003DziP9fFuA_003D;
		int num = array.Length - 1;
		if (IsRational)
		{
			double num2 = double.MaxValue;
			double num3 = double.MinValue;
			Point4D[] pw2 = Pw;
			foreach (Point4D point4D in pw2)
			{
				if (point4D.W < num2)
				{
					num2 = point4D.W;
				}
				Point3D euclid = point4D.Euclid;
				double num4 = Math.Sqrt(euclid.X * euclid.X + euclid.Y * euclid.Y + euclid.Z * euclid.Z);
				if (num4 > num3)
				{
					num3 = num4;
				}
			}
			tol = tol * num2 / (1.0 + num3);
		}
		int num5 = _0023_003DzB68dg9Q_003D + 1;
		int num6 = num - num5;
		if (num6 < num5)
		{
			return 0;
		}
		double num7 = array[num6];
		int num8 = 0;
		double num9 = array[num5];
		int j;
		for (j = num5; num9 == array[j + 1]; j++)
		{
		}
		int num10 = j - _0023_003DzB68dg9Q_003D;
		int num11 = (2 * j - num10 - _0023_003DzB68dg9Q_003D) / 2;
		int num12 = j - num10;
		int num13 = num10;
		int num14 = j;
		int num15 = num14 + 1;
		Point4D[] array2 = new Point4D[2 * _0023_003DzB68dg9Q_003D + 1];
		int k;
		int num17;
		int l;
		while (true)
		{
			int num18;
			for (k = 0; k < num10; k++)
			{
				int num16 = num13 - 1;
				array2[0] = (Point4D)pw[num16].Clone();
				array2[num12 + 1 - num16] = (Point4D)pw[num12 + 1].Clone();
				num17 = num13;
				num18 = num12;
				int num19 = num13 - num16;
				int num20 = num12 - num16;
				bool flag = false;
				while (num18 - num17 > k)
				{
					double num21 = (num9 - array[num17]) / (array[num17 + num5 + num8 + k] - array[num17]);
					double num22 = (num9 - array[num18 - k]) / (array[num18 + num5 + num8] - array[num18 - k]);
					array2[num19] = (pw[num17++] - (1.0 - num21) * array2[num19 - 1]) / num21;
					array2[num20] = (pw[num18--] - num22 * array2[num20 + 1]) / (1.0 - num22);
					num19++;
					num20--;
				}
				if (num18 - num17 < k)
				{
					if (Point4D.Distance(array2[num19 - 1], array2[num20 + 1]) <= tol)
					{
						flag = true;
					}
				}
				else
				{
					double num21 = (num9 - array[num17]) / (array[num17 + num5 + num8 + k] - array[num17]);
					if (Point4D.Distance(pw[num17], num21 * array2[num19 + k + 1] + (1.0 - num21) * array2[num19 - 1]) <= tol)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					break;
				}
				num17 = num13;
				num18 = num12;
				while (num18 - num17 > k)
				{
					pw[num17] = (Point4D)array2[num17 - num16].Clone();
					pw[num18] = (Point4D)array2[num18 - num16].Clone();
					num17++;
					num18--;
				}
				num13--;
				num12++;
			}
			if (k > 0)
			{
				num18 = num11;
				num17 = num18;
				for (l = 1; l < k; l++)
				{
					if (l % 2 == 1)
					{
						num17++;
					}
					else
					{
						num18--;
					}
				}
				for (l = num17 + 1; l <= num14; l++)
				{
					pw[num18++] = pw[l];
				}
			}
			else
			{
				num18 = num14 + 1;
			}
			if (num9 == num7)
			{
				break;
			}
			int num23 = (num17 = j - k + 1);
			l = j + num8 + 1;
			num9 = array[l];
			while (num9 == array[l])
			{
				array[num17++] = array[l++];
			}
			num10 = num17 - num23;
			j = num17 - 1;
			num8 += k;
			for (l = 0; l < num10; l++)
			{
				pw[num18++] = pw[num15++];
			}
			num14 = num18 - 1;
			num11 = (2 * j - _0023_003DzB68dg9Q_003D - num10) / 2;
			num12 = j - num10;
			num13 = j - _0023_003DzB68dg9Q_003D;
		}
		num8 += k;
		num17 = num6 + 1;
		l = num17 - num8;
		for (int num18 = 1; num18 <= num5; num18++)
		{
			array[l++] = array[num17++];
		}
		ResizeKeep(Pw.Length - num8, _0023_003DzB68dg9Q_003D);
		RegenMode = regenType.RegenAndCompile;
		return num8;
	}

	private void _0023_003DzpIGvI76vhm1J(Point3D _0023_003DzapZc0IQ_003D, Vector3D _0023_003Dz7ec6VOg_003D, Point3D _0023_003Dz_fdaZUE_003D, Vector3D _0023_003DzksZEoqg_003D, Point3D _0023_003Dzl3DhHgI_003D, out Point3D _0023_003DzZFWF0AM_003D, ref double _0023_003DzYjEUfgY_003D)
	{
		Vector3D t = Vector3D.Subtract(_0023_003Dz_fdaZUE_003D, _0023_003DzapZc0IQ_003D);
		double s2;
		double t4;
		Point3D i;
		if (Utility.Intersect3DLines(_0023_003DzapZc0IQ_003D, _0023_003Dz7ec6VOg_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzksZEoqg_003D, out var _, out var _, out _0023_003DzZFWF0AM_003D) == 0)
		{
			Vector3D t3 = Vector3D.Subtract(_0023_003Dzl3DhHgI_003D, _0023_003DzZFWF0AM_003D);
			Utility.Intersect3DLines(_0023_003DzZFWF0AM_003D, t3, _0023_003DzapZc0IQ_003D, t, out s2, out t4, out i);
			double num = Math.Sqrt(t4 / (1.0 - t4));
			double num2 = num / (1.0 + num);
			double num3 = (1.0 - num2) * (1.0 - num2) * (Vector3D.Subtract(_0023_003Dzl3DhHgI_003D, _0023_003DzapZc0IQ_003D) * Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003Dzl3DhHgI_003D)) + num2 * num2 * (Vector3D.Subtract(_0023_003Dzl3DhHgI_003D, _0023_003Dz_fdaZUE_003D) * Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003Dzl3DhHgI_003D));
			double num4 = 2.0 * num2 * (1.0 - num2) * (Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003Dzl3DhHgI_003D) * Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003Dzl3DhHgI_003D));
			_0023_003DzYjEUfgY_003D = num3 / num4;
		}
		else
		{
			_0023_003DzYjEUfgY_003D = 0.0;
			Utility.Intersect3DLines(_0023_003Dzl3DhHgI_003D, _0023_003Dz7ec6VOg_003D, _0023_003DzapZc0IQ_003D, t, out s2, out t4, out i);
			double num5 = Math.Sqrt(t4 / (1.0 - t4));
			double num6 = num5 / (1.0 + num5);
			double num7 = 2.0 * num6 * (1.0 - num6);
			num7 = (0.0 - s2) * (1.0 - num7) / num7;
			_0023_003DzZFWF0AM_003D = num7 * _0023_003Dz7ec6VOg_003D.AsPoint;
		}
	}

	private void _0023_003Dzyo7753mSx4U3jJ8VCw_003D_003D(Point3D _0023_003DzapZc0IQ_003D, Vector3D _0023_003Dz7ec6VOg_003D, Point3D _0023_003Dz_fdaZUE_003D, Vector3D _0023_003DzksZEoqg_003D, Point3D _0023_003Dzl3DhHgI_003D)
	{
		double _0023_003DzYjEUfgY_003D = 0.0;
		_0023_003DzpIGvI76vhm1J(_0023_003DzapZc0IQ_003D, _0023_003Dz7ec6VOg_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzksZEoqg_003D, _0023_003Dzl3DhHgI_003D, out var _0023_003DzZFWF0AM_003D, ref _0023_003DzYjEUfgY_003D);
		if (_0023_003DzYjEUfgY_003D <= -1.0)
		{
			return;
		}
		int num;
		if (_0023_003DzYjEUfgY_003D >= 1.0)
		{
			num = 1;
		}
		else
		{
			Vector3D vector3D = Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003DzapZc0IQ_003D);
			Vector3D vector3D2 = Vector3D.Subtract(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D);
			vector3D.Normalize();
			vector3D2.Normalize();
			double num2 = Vector3D.AngleBetween(vector3D, vector3D2);
			num = ((_0023_003DzYjEUfgY_003D > Utility._0023_003DzxhnLabVjXjPg && num2 > Math.PI / 3.0) ? 1 : ((!(_0023_003DzYjEUfgY_003D < 0.0 - Utility._0023_003DzxhnLabVjXjPg) || !(num2 > Math.PI / 2.0)) ? 2 : 4));
		}
		int num3 = 2 * num;
		int num4 = 2 * num + 1;
		_0023_003DzB68dg9Q_003D = 2;
		_0023_003DziP9fFuA_003D = new double[num4 + 3];
		for (int i = 0; i < 3; i++)
		{
			_0023_003DziP9fFuA_003D[i] = 0.0;
			_0023_003DziP9fFuA_003D[i + num4] = 1.0;
		}
		Pw = new Point4D[num3 + 1];
		Pw[0] = new Point4D(_0023_003DzapZc0IQ_003D.X, _0023_003DzapZc0IQ_003D.Y, _0023_003DzapZc0IQ_003D.Z);
		Pw[num3] = new Point4D(_0023_003Dz_fdaZUE_003D.X, _0023_003Dz_fdaZUE_003D.Y, _0023_003Dz_fdaZUE_003D.Z);
		if (num == 1)
		{
			Pw[1] = _0023_003DzYjEUfgY_003D * new Point4D(_0023_003DzZFWF0AM_003D.X, _0023_003DzZFWF0AM_003D.Y, _0023_003DzZFWF0AM_003D.Z);
			return;
		}
		_0023_003Dz94j2HxGH_0024zQm(_0023_003DzapZc0IQ_003D, _0023_003DzZFWF0AM_003D, _0023_003DzYjEUfgY_003D, _0023_003Dz_fdaZUE_003D, _0023_003Dzl3DhHgI_003D, _0023_003Dz7ec6VOg_003D, _0023_003DzksZEoqg_003D, out var _0023_003DzfWhMsW4_003D, out var _0023_003DzR58imxw_003D, out var _0023_003DzALKvlmM_003D, out var _0023_003Dz7XLH9n0_003D);
		if (num == 2)
		{
			Pw[2] = new Point4D(_0023_003DzR58imxw_003D.X, _0023_003DzR58imxw_003D.Y, _0023_003DzR58imxw_003D.Z);
			Pw[1] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzfWhMsW4_003D.X, _0023_003DzfWhMsW4_003D.Y, _0023_003DzfWhMsW4_003D.Z);
			Pw[3] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzALKvlmM_003D.X, _0023_003DzALKvlmM_003D.Y, _0023_003DzALKvlmM_003D.Z);
			_0023_003DziP9fFuA_003D[3] = (_0023_003DziP9fFuA_003D[4] = 0.5);
			return;
		}
		Pw[4] = new Point4D(_0023_003DzR58imxw_003D.X, _0023_003DzR58imxw_003D.Y, _0023_003DzR58imxw_003D.Z);
		_0023_003DzYjEUfgY_003D = _0023_003Dz7XLH9n0_003D;
		Point3D _0023_003DzfWhMsW4_003D2 = new Point3D();
		Point3D _0023_003DzR58imxw_003D2 = new Point3D();
		Point3D _0023_003DzALKvlmM_003D2 = new Point3D();
		_0023_003Dz94j2HxGH_0024zQm(_0023_003DzapZc0IQ_003D, _0023_003DzfWhMsW4_003D, _0023_003DzYjEUfgY_003D, _0023_003DzR58imxw_003D, _0023_003Dzl3DhHgI_003D, _0023_003Dz7ec6VOg_003D, _0023_003DzksZEoqg_003D, out _0023_003DzfWhMsW4_003D2, out _0023_003DzR58imxw_003D2, out _0023_003DzALKvlmM_003D2, out _0023_003Dz7XLH9n0_003D);
		Pw[2] = new Point4D(_0023_003DzR58imxw_003D2.X, _0023_003DzR58imxw_003D2.Y, _0023_003DzR58imxw_003D2.Z);
		Pw[1] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzfWhMsW4_003D2.X, _0023_003DzfWhMsW4_003D2.Y, _0023_003DzfWhMsW4_003D2.Z);
		Pw[3] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzALKvlmM_003D2.X, _0023_003DzALKvlmM_003D2.Y, _0023_003DzALKvlmM_003D2.Z);
		_0023_003Dz94j2HxGH_0024zQm(_0023_003DzR58imxw_003D, _0023_003DzALKvlmM_003D, _0023_003DzYjEUfgY_003D, _0023_003Dz_fdaZUE_003D, _0023_003Dzl3DhHgI_003D, _0023_003Dz7ec6VOg_003D, _0023_003DzksZEoqg_003D, out _0023_003DzfWhMsW4_003D2, out _0023_003DzR58imxw_003D2, out _0023_003DzALKvlmM_003D2, out _0023_003Dz7XLH9n0_003D);
		Pw[6] = new Point4D(_0023_003DzR58imxw_003D2.X, _0023_003DzR58imxw_003D2.Y, _0023_003DzR58imxw_003D2.Z);
		Pw[5] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzfWhMsW4_003D2.X, _0023_003DzfWhMsW4_003D2.Y, _0023_003DzfWhMsW4_003D2.Z);
		Pw[7] = _0023_003Dz7XLH9n0_003D * new Point4D(_0023_003DzALKvlmM_003D2.X, _0023_003DzALKvlmM_003D2.Y, _0023_003DzALKvlmM_003D2.Z);
		for (int j = 0; j < 2; j++)
		{
			_0023_003DziP9fFuA_003D[j + 3] = 0.25;
			_0023_003DziP9fFuA_003D[j + 5] = 0.5;
			_0023_003DziP9fFuA_003D[j + 7] = 0.75;
		}
	}

	private void _0023_003Dz94j2HxGH_0024zQm(Point3D _0023_003DzapZc0IQ_003D, Point3D _0023_003DzZFWF0AM_003D, double _0023_003DzYjEUfgY_003D, Point3D _0023_003Dz_fdaZUE_003D, Point3D _0023_003Dzl3DhHgI_003D, Vector3D _0023_003Dz7ec6VOg_003D, Vector3D _0023_003DzksZEoqg_003D, out Point3D _0023_003DzfWhMsW4_003D, out Point3D _0023_003DzR58imxw_003D, out Point3D _0023_003DzALKvlmM_003D, out double _0023_003Dz7XLH9n0_003D)
	{
		if (Utility.Intersect3DLines(_0023_003DzapZc0IQ_003D, _0023_003Dz7ec6VOg_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzksZEoqg_003D, out var _, out var _, out var i) == 0)
		{
			_0023_003DzfWhMsW4_003D = (_0023_003DzapZc0IQ_003D + _0023_003DzYjEUfgY_003D * _0023_003DzZFWF0AM_003D) / (1.0 + _0023_003DzYjEUfgY_003D);
			_0023_003DzALKvlmM_003D = (_0023_003DzYjEUfgY_003D * _0023_003DzZFWF0AM_003D + _0023_003Dz_fdaZUE_003D) / (1.0 + _0023_003DzYjEUfgY_003D);
			_0023_003DzR58imxw_003D = 0.5 * (_0023_003DzfWhMsW4_003D + _0023_003DzALKvlmM_003D);
			_0023_003Dz7XLH9n0_003D = Math.Sqrt((1.0 + _0023_003DzYjEUfgY_003D) / 2.0);
			return;
		}
		Vector3D t2 = Vector3D.Subtract(_0023_003Dz_fdaZUE_003D, _0023_003DzapZc0IQ_003D);
		Utility.Intersect3DLines(_0023_003Dzl3DhHgI_003D, _0023_003Dz7ec6VOg_003D, _0023_003DzapZc0IQ_003D, t2, out var s2, out var t3, out i);
		double num = Math.Sqrt(t3 / (1.0 - t3));
		double num2 = num / (1.0 + num);
		double num3 = 2.0 * num2 * (1.0 - num2);
		num3 = (0.0 - s2) * (1.0 - num3) / num3;
		Vector3D vector3D = num3 * _0023_003Dz7ec6VOg_003D;
		_0023_003DzfWhMsW4_003D = _0023_003DzapZc0IQ_003D + vector3D;
		_0023_003DzALKvlmM_003D = _0023_003Dz_fdaZUE_003D + vector3D;
		_0023_003DzR58imxw_003D = 0.5 * (_0023_003DzfWhMsW4_003D + _0023_003DzALKvlmM_003D);
		_0023_003Dz7XLH9n0_003D = 0.7071067811865476;
	}

	internal void _0023_003Dz2r9Ujfm8VxAN(double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		double num = Math.Cos(_0023_003Dz0mZ4_0024fFWxsTX);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzjbqS1qE_003D = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		int num2 = 0;
		while (num2 < Pw.Length - 1)
		{
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dz1v6oPQk_003D = Pw[num2 + 1]._0023_003Dz53cmpTHe6Yih() - Pw[num2]._0023_003Dz53cmpTHe6Yih();
			if (_0023_003Dz1v6oPQk_003D._0023_003DzEi_F9g8kJ9d2() > 1E-12)
			{
				_0023_003Dz1v6oPQk_003D._0023_003DzbV1eOjg_003D();
				if (num2 >= 1 && !(_0023_003DzjbqS1qE_003D._0023_003DzEi_F9g8kJ9d2() < 1E-12) && !(_0023_003DzjbqS1qE_003D * _0023_003Dz1v6oPQk_003D > num))
				{
					RemoveControlPoint(num2--);
					_0023_003Dz1v6oPQk_003D = Pw[num2 + 1]._0023_003Dz53cmpTHe6Yih() - Pw[num2]._0023_003Dz53cmpTHe6Yih();
					_0023_003Dz1v6oPQk_003D._0023_003DzbV1eOjg_003D();
				}
			}
			num2++;
			_0023_003DzjbqS1qE_003D = _0023_003Dz1v6oPQk_003D;
		}
	}

	public void RemoveControlPoint(int i)
	{
		if (Pw.Length >= 3)
		{
			_0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D._0023_003DzmSyvi00_003D(ref Pw, i, 1);
			if (_0023_003DziP9fFuA_003D.Length == (_0023_003DzB68dg9Q_003D + 1) * 2)
			{
				_0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D._0023_003DzmSyvi00_003D(ref _0023_003DziP9fFuA_003D, _0023_003DzB68dg9Q_003D, 2);
				_0023_003DzB68dg9Q_003D--;
			}
			else
			{
				int _0023_003DzyzK8swU_003D = Math.Max(_0023_003DzB68dg9Q_003D + 1, Math.Min(_0023_003DzB68dg9Q_003D + i, _0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 2));
				_0023_003DzYIJwJJalrSpy2ked8X7Y_0024QY_003D._0023_003DzmSyvi00_003D(ref _0023_003DziP9fFuA_003D, _0023_003DzyzK8swU_003D, 1);
			}
			regenMode = regenType.RegenAndCompile;
		}
	}

	public static Curve GlobalInterpolation(IList<Point3D> Q, int deg)
	{
		double[] _0023_003Dz_0024aMC_00244k_003D;
		double[] array;
		return _0023_003DzxfgL9OaoOs_L(Q, deg, out _0023_003Dz_0024aMC_00244k_003D, out array);
	}

	private static Curve _0023_003DzxfgL9OaoOs_L(IList<Point3D> _0023_003DziDLVpbY_003D, int _0023_003DzbU0rLpQ_003D, out double[] _0023_003Dz_0024aMC_00244k_003D, out double[] _0023_003DziP9fFuA_003D)
	{
		if (_0023_003DzbU0rLpQ_003D <= 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964985), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964966));
		}
		if (_0023_003DzbU0rLpQ_003D >= _0023_003DziDLVpbY_003D.Count)
		{
			_0023_003DzbU0rLpQ_003D = _0023_003DziDLVpbY_003D.Count - 1;
		}
		int count = _0023_003DziDLVpbY_003D.Count;
		new Curve().Resize(count, _0023_003DzbU0rLpQ_003D);
		_0023_003DziP9fFuA_003D = new double[count + _0023_003DzbU0rLpQ_003D + 1];
		NurbsBase.ChordLengthParametrization(_0023_003DziDLVpbY_003D, out _0023_003Dz_0024aMC_00244k_003D);
		NurbsBase._0023_003DzP0A53cFshwnVQKkCf4TpIss_003D(_0023_003Dz_0024aMC_00244k_003D, _0023_003DzbU0rLpQ_003D, ref _0023_003DziP9fFuA_003D);
		return _0023_003DzxfgL9OaoOs_L(_0023_003DziDLVpbY_003D, _0023_003Dz_0024aMC_00244k_003D, _0023_003DziP9fFuA_003D, _0023_003DzbU0rLpQ_003D);
	}

	private static Curve _0023_003DzxfgL9OaoOs_L(IList<Point3D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, int _0023_003DzbU0rLpQ_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		if (_0023_003DzbU0rLpQ_003D >= count)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964933));
		}
		new Curve().Resize(count, _0023_003DzbU0rLpQ_003D);
		double[] _0023_003DzS8ZrGyU_003D = new double[count + _0023_003DzbU0rLpQ_003D + 1];
		NurbsBase._0023_003DzP0A53cFshwnVQKkCf4TpIss_003D(_0023_003Dzf9Vy1JQ_003D, _0023_003DzbU0rLpQ_003D, ref _0023_003DzS8ZrGyU_003D);
		return _0023_003DzxfgL9OaoOs_L(_0023_003DziDLVpbY_003D, _0023_003Dzf9Vy1JQ_003D, _0023_003DzS8ZrGyU_003D, _0023_003DzbU0rLpQ_003D);
	}

	internal static Curve _0023_003DzxfgL9OaoOs_L(IList<Point3D> _0023_003DziDLVpbY_003D, double[] _0023_003Dz_0024aMC_00244k_003D, double[] _0023_003DzS8ZrGyU_003D, int _0023_003DzbU0rLpQ_003D)
	{
		if (_0023_003DzbU0rLpQ_003D <= 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965620), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964966));
		}
		if (_0023_003DzbU0rLpQ_003D >= _0023_003DziDLVpbY_003D.Count)
		{
			_0023_003DzbU0rLpQ_003D = _0023_003DziDLVpbY_003D.Count - 1;
		}
		int count = _0023_003DziDLVpbY_003D.Count;
		int n = count - 1;
		int num = _0023_003DzbU0rLpQ_003D - 1;
		int num2 = _0023_003DzbU0rLpQ_003D - 1;
		int num3 = num + num2 + 1;
		double[,] array = new double[count, num3];
		for (int i = 1; i < count - 1; i++)
		{
			int num4 = _0023_003DzS8ZrGyU_003D.FindSpan(n, _0023_003DzbU0rLpQ_003D, _0023_003Dz_0024aMC_00244k_003D[i]);
			double[] array2 = _0023_003DzS8ZrGyU_003D.BasisFuns(num4, _0023_003Dz_0024aMC_00244k_003D[i], _0023_003DzbU0rLpQ_003D);
			for (int j = 0; j <= _0023_003DzbU0rLpQ_003D; j++)
			{
				int num5 = num4 - i - _0023_003DzbU0rLpQ_003D + j;
				if (num + num5 >= 0 && num + num5 < num3)
				{
					array[i, num + num5] = array2[j];
				}
			}
		}
		array[0, num] = 1.0;
		array[count - 1, num] = 1.0;
		double[,] _0023_003DzH9VU2k0_003D = new double[count, 3];
		for (int k = 0; k < count; k++)
		{
			_0023_003DzH9VU2k0_003D[k, 0] = _0023_003DziDLVpbY_003D[k].X;
			_0023_003DzH9VU2k0_003D[k, 1] = _0023_003DziDLVpbY_003D[k].Y;
			_0023_003DzH9VU2k0_003D[k, 2] = _0023_003DziDLVpbY_003D[k].Z;
		}
		NurbsBase._0023_003DzhrvLkG8qVgMc7JLCgw_003D_003D(array, ref _0023_003DzH9VU2k0_003D, num, num2);
		Point4D[] array3 = new Point4D[count];
		for (int l = 0; l < count; l++)
		{
			array3[l] = new Point4D(_0023_003DzH9VU2k0_003D[l, 0], _0023_003DzH9VU2k0_003D[l, 1], _0023_003DzH9VU2k0_003D[l, 2]);
		}
		return new Curve(_0023_003DzbU0rLpQ_003D, _0023_003DzS8ZrGyU_003D, array3);
	}

	internal static Curve _0023_003DzxfN9JuqI1RtQ(IList<Point4D> _0023_003DziDLVpbY_003D, double[] _0023_003Dzf9Vy1JQ_003D, double[] _0023_003DzS8ZrGyU_003D, int _0023_003DzbU0rLpQ_003D)
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		int n = count - 1;
		int num = _0023_003DzbU0rLpQ_003D - 1;
		int num2 = _0023_003DzbU0rLpQ_003D - 1;
		int num3 = num + num2 + 1;
		double[,] array = new double[count, num3];
		for (int i = 1; i < count - 1; i++)
		{
			int num4 = _0023_003DzS8ZrGyU_003D.FindSpan(n, _0023_003DzbU0rLpQ_003D, _0023_003Dzf9Vy1JQ_003D[i]);
			double[] array2 = _0023_003DzS8ZrGyU_003D.BasisFuns(num4, _0023_003Dzf9Vy1JQ_003D[i], _0023_003DzbU0rLpQ_003D);
			for (int j = 0; j <= _0023_003DzbU0rLpQ_003D; j++)
			{
				int num5 = num4 - i - _0023_003DzbU0rLpQ_003D + j;
				if (num + num5 >= 0 && num + num5 < num3)
				{
					array[i, num + num5] = array2[j];
				}
			}
		}
		array[0, num] = 1.0;
		array[count - 1, num] = 1.0;
		double[,] _0023_003DzH9VU2k0_003D = new double[count, 4];
		for (int k = 0; k < count; k++)
		{
			_0023_003DzH9VU2k0_003D[k, 0] = _0023_003DziDLVpbY_003D[k].X;
			_0023_003DzH9VU2k0_003D[k, 1] = _0023_003DziDLVpbY_003D[k].Y;
			_0023_003DzH9VU2k0_003D[k, 2] = _0023_003DziDLVpbY_003D[k].Z;
			_0023_003DzH9VU2k0_003D[k, 3] = _0023_003DziDLVpbY_003D[k].W;
		}
		NurbsBase._0023_003DzhrvLkG8qVgMc7JLCgw_003D_003D(array, ref _0023_003DzH9VU2k0_003D, num, num2);
		Point4D[] array3 = new Point4D[count];
		for (int l = 0; l < count; l++)
		{
			array3[l] = new Point4D(_0023_003DzH9VU2k0_003D[l, 0], _0023_003DzH9VU2k0_003D[l, 1], _0023_003DzH9VU2k0_003D[l, 2], _0023_003DzH9VU2k0_003D[l, 3]);
		}
		return new Curve(_0023_003DzbU0rLpQ_003D, _0023_003DzS8ZrGyU_003D, array3);
	}

	internal bool _0023_003Dz0bvIEbl1U1sdVlk4SQ_003D_003D(IList<Point3D> _0023_003DziDLVpbY_003D, IList<Vector3D> _0023_003DzK_0024fbiW0_003D, int _0023_003DzXrexKjY_003D, bool _0023_003DzrZaaBA4_003D, double _0023_003DzjbqS1qE_003D)
	{
		_0023_003DzB68dg9Q_003D = _0023_003DzXrexKjY_003D;
		int num = 2 * _0023_003DziDLVpbY_003D.Count;
		Resize(num, _0023_003DzB68dg9Q_003D);
		double[] ub = new double[_0023_003DziDLVpbY_003D.Count];
		double num2 = NurbsBase.ChordLengthParametrization(_0023_003DziDLVpbY_003D, out ub);
		if (_0023_003DzrZaaBA4_003D)
		{
			num2 *= _0023_003DzjbqS1qE_003D;
		}
		switch (_0023_003DzB68dg9Q_003D)
		{
		case 2:
		{
			for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
			{
				_0023_003DziP9fFuA_003D[i] = 0.0;
				_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1 - i] = 1.0;
			}
			for (int i = 0; i < ub.Length - 1; i++)
			{
				_0023_003DziP9fFuA_003D[2 * i + _0023_003DzB68dg9Q_003D] = ub[i];
				_0023_003DziP9fFuA_003D[2 * i + _0023_003DzB68dg9Q_003D + 1] = (ub[i] + ub[i + 1]) / 2.0;
			}
			_0023_003DziP9fFuA_003D[3] = ub[1] / 2.0;
			_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 2] = (ub[^2] + 1.0) / 2.0;
			break;
		}
		case 3:
		{
			for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
			{
				_0023_003DziP9fFuA_003D[i] = 0.0;
				_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1 - i] = 1.0;
			}
			for (int i = 1; i < ub.Length - 1; i++)
			{
				_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 2 * i - 1] = (2.0 * ub[i] + ub[i + 1]) / 3.0;
				_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 2 * i] = (ub[i] + 2.0 * ub[i + 1]) / 3.0;
			}
			_0023_003DziP9fFuA_003D[4] = ub[1] / 2.0;
			_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 2] = (ub[^2] + 1.0) / 2.0;
			break;
		}
		default:
		{
			double[] array = new double[2 * _0023_003DziDLVpbY_003D.Count];
			for (int i = 0; i < ub.Length - 1; i++)
			{
				array[2 * i] = ub[i];
				array[2 * i + 1] = (ub[i] + ub[i + 1]) / 2.0;
			}
			array[^2] = (array[^1] + array[^3]) / 2.0;
			NurbsBase._0023_003DzP0A53cFshwnVQKkCf4TpIss_003D(array, _0023_003DzB68dg9Q_003D, ref _0023_003DziP9fFuA_003D);
			break;
		}
		}
		double[,] array2 = new double[num, num];
		for (int i = 1; i < _0023_003DziDLVpbY_003D.Count - 1; i++)
		{
			int num3 = _0023_003DziP9fFuA_003D.FindSpan(num, _0023_003DzB68dg9Q_003D, ub[i]);
			double[] array3 = _0023_003DziP9fFuA_003D.BasisFuns(num3, ub[i], _0023_003DzB68dg9Q_003D);
			double[,] array4 = _0023_003DziP9fFuA_003D.DersBasisFuns(num3, ub[i], _0023_003DzB68dg9Q_003D, 1);
			for (int j = 0; j <= _0023_003DzB68dg9Q_003D; j++)
			{
				array2[2 * i, num3 - _0023_003DzB68dg9Q_003D + j] = array3[j];
				array2[2 * i + 1, num3 - _0023_003DzB68dg9Q_003D + j] = array4[1, j];
			}
		}
		array2[0, 0] = 1.0;
		array2[1, 0] = -1.0;
		array2[1, 1] = 1.0;
		array2[num - 2, num - 2] = -1.0;
		array2[num - 2, num - 1] = 1.0;
		array2[num - 1, num - 1] = 1.0;
		double[,] _0023_003DzH9VU2k0_003D = new double[num, 3];
		for (int i = 0; i < _0023_003DziDLVpbY_003D.Count; i++)
		{
			_0023_003DzH9VU2k0_003D[2 * i, 0] = _0023_003DziDLVpbY_003D[i].X;
			_0023_003DzH9VU2k0_003D[2 * i, 1] = _0023_003DziDLVpbY_003D[i].Y;
			_0023_003DzH9VU2k0_003D[2 * i, 2] = _0023_003DziDLVpbY_003D[i].Z;
			_0023_003DzH9VU2k0_003D[2 * i + 1, 0] = _0023_003DzK_0024fbiW0_003D[i].X;
			_0023_003DzH9VU2k0_003D[2 * i + 1, 1] = _0023_003DzK_0024fbiW0_003D[i].Y;
			_0023_003DzH9VU2k0_003D[2 * i + 1, 2] = _0023_003DzK_0024fbiW0_003D[i].Z;
			if (_0023_003DzrZaaBA4_003D)
			{
				_0023_003DzH9VU2k0_003D[2 * i + 1, 0] *= num2;
				_0023_003DzH9VU2k0_003D[2 * i + 1, 1] *= num2;
				_0023_003DzH9VU2k0_003D[2 * i + 1, 2] *= num2;
			}
		}
		double num4 = _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 1] / (double)_0023_003DzB68dg9Q_003D;
		double num5 = (1.0 - _0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - _0023_003DzB68dg9Q_003D - 2]) / (double)_0023_003DzB68dg9Q_003D;
		_0023_003DzH9VU2k0_003D[1, 0] = num4 * _0023_003DzK_0024fbiW0_003D[0].X;
		_0023_003DzH9VU2k0_003D[1, 1] = num4 * _0023_003DzK_0024fbiW0_003D[0].Y;
		_0023_003DzH9VU2k0_003D[1, 2] = num4 * _0023_003DzK_0024fbiW0_003D[0].Z;
		_0023_003DzH9VU2k0_003D[num - 2, 0] = num5 * _0023_003DzK_0024fbiW0_003D[_0023_003DzK_0024fbiW0_003D.Count - 1].X;
		_0023_003DzH9VU2k0_003D[num - 2, 1] = num5 * _0023_003DzK_0024fbiW0_003D[_0023_003DzK_0024fbiW0_003D.Count - 1].Y;
		_0023_003DzH9VU2k0_003D[num - 2, 2] = num5 * _0023_003DzK_0024fbiW0_003D[_0023_003DzK_0024fbiW0_003D.Count - 1].Z;
		if (_0023_003DzrZaaBA4_003D)
		{
			_0023_003DzH9VU2k0_003D[1, 0] *= num2;
			_0023_003DzH9VU2k0_003D[1, 1] *= num2;
			_0023_003DzH9VU2k0_003D[1, 2] *= num2;
			_0023_003DzH9VU2k0_003D[num - 2, 0] *= num2;
			_0023_003DzH9VU2k0_003D[num - 2, 1] *= num2;
			_0023_003DzH9VU2k0_003D[num - 2, 2] *= num2;
		}
		_0023_003DzH9VU2k0_003D[num - 1, 0] = _0023_003DziDLVpbY_003D[_0023_003DziDLVpbY_003D.Count - 1].X;
		_0023_003DzH9VU2k0_003D[num - 1, 1] = _0023_003DziDLVpbY_003D[_0023_003DziDLVpbY_003D.Count - 1].Y;
		_0023_003DzH9VU2k0_003D[num - 1, 2] = _0023_003DziDLVpbY_003D[_0023_003DziDLVpbY_003D.Count - 1].Z;
		if (!NurbsBase._0023_003DzcpymVWGKJIjE(array2, ref _0023_003DzH9VU2k0_003D))
		{
			return false;
		}
		for (int i = 0; i < num; i++)
		{
			Pw[i] = new Point4D(_0023_003DzH9VU2k0_003D[i, 0], _0023_003DzH9VU2k0_003D[i, 1], _0023_003DzH9VU2k0_003D[i, 2]);
		}
		Pw[0] = new Point4D(_0023_003DziDLVpbY_003D[0]);
		Pw[Pw.Length - 1] = new Point4D(_0023_003DziDLVpbY_003D[_0023_003DziDLVpbY_003D.Count - 1]);
		return true;
	}

	public static Curve LocalInterpolation(IList<Point3D> Q, bool cornerFlag, bool cornerEndFlag = false)
	{
		Q = Utility.RemoveDuplicates(Q);
		int count = Q.Count;
		if (count < 2)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965629), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965571));
		}
		if (count == 2)
		{
			return new Line(Q[0], Q[1]).GetNurbsForm();
		}
		Vector3D[] _0023_003DzO_0024iiQ4U_003D;
		Vector3D[] _0023_003DzWWgGxds_003D = _0023_003DzNAUUNSIVVPna006kuA_003D_003D(Q, cornerFlag, out _0023_003DzO_0024iiQ4U_003D, cornerEndFlag);
		_0023_003DzrJs82hX704T3(Q, count, _0023_003DzO_0024iiQ4U_003D, _0023_003DzWWgGxds_003D, out var _0023_003Dzu76y2KE_003D, out var knotVector);
		return new Curve(3, knotVector, _0023_003Dzu76y2KE_003D);
	}

	internal static Vector3D[] _0023_003DzNAUUNSIVVPna006kuA_003D_003D<R>(IList<R> _0023_003DziDLVpbY_003D, bool _0023_003Dz47beYi4u2gFe, out Vector3D[] _0023_003DzO_0024iiQ4U_003D, bool _0023_003DzLDNx6SxG_Y_0024_0024) where R : Point3D
	{
		int count = _0023_003DziDLVpbY_003D.Count;
		bool num = _0023_003DziDLVpbY_003D[0] == _0023_003DziDLVpbY_003D[count - 1];
		_0023_003DzO_0024iiQ4U_003D = new Vector3D[count + 3];
		Vector3D[] array = new Vector3D[count];
		if (num && !_0023_003DzLDNx6SxG_Y_0024_0024)
		{
			_0023_003DzO_0024iiQ4U_003D[0] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[count - 2], _0023_003DziDLVpbY_003D[count - 3]);
			_0023_003DzO_0024iiQ4U_003D[1] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[count - 1], _0023_003DziDLVpbY_003D[count - 2]);
			for (int i = 1; i < count; i++)
			{
				_0023_003DzO_0024iiQ4U_003D[i + 1] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[i], _0023_003DziDLVpbY_003D[i - 1]);
			}
			_0023_003DzO_0024iiQ4U_003D[count + 1] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[1], _0023_003DziDLVpbY_003D[0]);
			_0023_003DzO_0024iiQ4U_003D[count + 2] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[2], _0023_003DziDLVpbY_003D[1]);
		}
		else
		{
			for (int j = 1; j < count; j++)
			{
				_0023_003DzO_0024iiQ4U_003D[j + 1] = Vector3D.Subtract(_0023_003DziDLVpbY_003D[j], _0023_003DziDLVpbY_003D[j - 1]);
			}
			if (2.0 * _0023_003DzO_0024iiQ4U_003D[2].LengthSquared > _0023_003DzO_0024iiQ4U_003D[3].LengthSquared)
			{
				_0023_003DzO_0024iiQ4U_003D[1] = 2.0 * _0023_003DzO_0024iiQ4U_003D[2] - _0023_003DzO_0024iiQ4U_003D[3];
				_0023_003DzO_0024iiQ4U_003D[0] = 2.0 * _0023_003DzO_0024iiQ4U_003D[1] - _0023_003DzO_0024iiQ4U_003D[2];
			}
			else
			{
				double num2 = _0023_003DzO_0024iiQ4U_003D[3].Length / _0023_003DzO_0024iiQ4U_003D[2].Length;
				_0023_003DzO_0024iiQ4U_003D[1] = 2.0 * num2 * _0023_003DzO_0024iiQ4U_003D[2] - _0023_003DzO_0024iiQ4U_003D[3];
				_0023_003DzO_0024iiQ4U_003D[0] = 2.0 * _0023_003DzO_0024iiQ4U_003D[1] - num2 * _0023_003DzO_0024iiQ4U_003D[2];
			}
			if (2.0 * _0023_003DzO_0024iiQ4U_003D[count].LengthSquared > _0023_003DzO_0024iiQ4U_003D[count - 1].LengthSquared)
			{
				_0023_003DzO_0024iiQ4U_003D[count + 1] = 2.0 * _0023_003DzO_0024iiQ4U_003D[count] - _0023_003DzO_0024iiQ4U_003D[count - 1];
				_0023_003DzO_0024iiQ4U_003D[count + 2] = 2.0 * _0023_003DzO_0024iiQ4U_003D[count + 1] - _0023_003DzO_0024iiQ4U_003D[count];
			}
			else
			{
				double num3 = _0023_003DzO_0024iiQ4U_003D[count - 1].Length / _0023_003DzO_0024iiQ4U_003D[count].Length;
				_0023_003DzO_0024iiQ4U_003D[count + 1] = 2.0 * num3 * _0023_003DzO_0024iiQ4U_003D[count] - _0023_003DzO_0024iiQ4U_003D[count - 1];
				_0023_003DzO_0024iiQ4U_003D[count + 2] = 2.0 * _0023_003DzO_0024iiQ4U_003D[count + 1] - num3 * _0023_003DzO_0024iiQ4U_003D[count];
			}
		}
		for (int k = 0; k < count; k++)
		{
			double length = Vector3D.Cross(_0023_003DzO_0024iiQ4U_003D[k], _0023_003DzO_0024iiQ4U_003D[k + 1]).Length;
			double length2 = Vector3D.Cross(_0023_003DzO_0024iiQ4U_003D[k + 2], _0023_003DzO_0024iiQ4U_003D[k + 3]).Length;
			double num4 = ((length + length2 != 0.0) ? (length / (length + length2)) : ((!_0023_003Dz47beYi4u2gFe) ? 0.5 : 1.0));
			array[k] = (1.0 - num4) * _0023_003DzO_0024iiQ4U_003D[k + 1] + num4 * _0023_003DzO_0024iiQ4U_003D[k + 2];
			if (!array[k].Normalize())
			{
				array[k].Zero();
			}
		}
		return array;
	}

	private static void _0023_003DzrJs82hX704T3(IList<PointTangent> _0023_003DziDLVpbY_003D, int _0023_003DzoMNiNRw_003D, out Point4D[] _0023_003Dzu76y2KE_003D, out double[] _0023_003DziP9fFuA_003D)
	{
		_0023_003DziP9fFuA_003D = new double[_0023_003DzoMNiNRw_003D * 2 + 4];
		_0023_003DziP9fFuA_003D[0] = (_0023_003DziP9fFuA_003D[1] = (_0023_003DziP9fFuA_003D[2] = (_0023_003DziP9fFuA_003D[3] = 0.0)));
		int num = 4;
		Point3D[] array = new Point3D[_0023_003DzoMNiNRw_003D * 2];
		array[0] = _0023_003DziDLVpbY_003D[0];
		int num2 = 1;
		for (int i = 0; i < _0023_003DzoMNiNRw_003D - 1; i++)
		{
			Vector3D vector3D = _0023_003DziDLVpbY_003D[i].Tangent + _0023_003DziDLVpbY_003D[i + 1].Tangent;
			double num3 = 16.0 - vector3D * vector3D;
			Vector3D vector3D2 = Vector3D.Subtract(_0023_003DziDLVpbY_003D[i + 1], _0023_003DziDLVpbY_003D[i]);
			double num4 = 12.0 * vector3D2 * vector3D;
			double num5 = -36.0 * vector3D2.LengthSquared;
			double num6 = (0.0 - num4 + Math.Sqrt(num4 * num4 - 4.0 * num3 * num5)) / (2.0 * num3) / 3.0;
			array[num2++] = _0023_003DziDLVpbY_003D[i] + num6 * _0023_003DziDLVpbY_003D[i].Tangent;
			array[num2++] = _0023_003DziDLVpbY_003D[i + 1] - num6 * _0023_003DziDLVpbY_003D[i + 1].Tangent;
			vector3D = Vector3D.Subtract(_0023_003DziDLVpbY_003D[i], array[num2 - 2]);
			double num7 = _0023_003DziP9fFuA_003D[num - 1] + 3.0 * vector3D.Length;
			_0023_003DziP9fFuA_003D[num++] = num7;
			_0023_003DziP9fFuA_003D[num++] = num7;
		}
		array[num2] = _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1];
		num -= 2;
		double num8 = 1.0 / _0023_003DziP9fFuA_003D[num];
		for (int j = 4; j < num; j++)
		{
			_0023_003DziP9fFuA_003D[j] *= num8;
		}
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num] = 1.0;
		_0023_003Dzu76y2KE_003D = new Point4D[array.Length];
		for (int k = 0; k < _0023_003Dzu76y2KE_003D.Length; k++)
		{
			_0023_003Dzu76y2KE_003D[k] = new Point4D(array[k]);
		}
	}

	private static void _0023_003DzrJs82hX704T3(IList<Point3D> _0023_003DziDLVpbY_003D, int _0023_003DzoMNiNRw_003D, Vector3D[] _0023_003DzO_0024iiQ4U_003D, Vector3D[] _0023_003DzWWgGxds_003D, out Point4D[] _0023_003Dzu76y2KE_003D, out double[] _0023_003DziP9fFuA_003D)
	{
		_0023_003DziP9fFuA_003D = new double[_0023_003DzoMNiNRw_003D * 2 + 4];
		_0023_003DziP9fFuA_003D[0] = (_0023_003DziP9fFuA_003D[1] = (_0023_003DziP9fFuA_003D[2] = (_0023_003DziP9fFuA_003D[3] = 0.0)));
		int num = 4;
		Point3D[] array = new Point3D[_0023_003DzoMNiNRw_003D * 2];
		array[0] = _0023_003DziDLVpbY_003D[0];
		int num2 = 1;
		for (int i = 0; i < _0023_003DzoMNiNRw_003D - 1; i++)
		{
			Vector3D vector3D = _0023_003DzWWgGxds_003D[i] + _0023_003DzWWgGxds_003D[i + 1];
			double num3 = 16.0 - vector3D * vector3D;
			double num4 = _0023_003DzO_0024iiQ4U_003D[i + 2] * vector3D;
			double num5 = 12.0 * num4;
			double num6 = -36.0 * _0023_003DzO_0024iiQ4U_003D[i + 2].LengthSquared;
			double num7 = (0.0 - num5 + Math.Sqrt(num5 * num5 - 4.0 * num3 * num6)) / (2.0 * num3) / 3.0;
			array[num2++] = _0023_003DziDLVpbY_003D[i] + num7 * _0023_003DzWWgGxds_003D[i];
			array[num2++] = _0023_003DziDLVpbY_003D[i + 1] - num7 * _0023_003DzWWgGxds_003D[i + 1];
			vector3D = Vector3D.Subtract(_0023_003DziDLVpbY_003D[i], array[num2 - 2]);
			num4 = vector3D.Length;
			double num8 = _0023_003DziP9fFuA_003D[num - 1] + 3.0 * num4;
			_0023_003DziP9fFuA_003D[num++] = num8;
			_0023_003DziP9fFuA_003D[num++] = num8;
		}
		array[num2] = _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1];
		num -= 2;
		double num9 = 1.0 / _0023_003DziP9fFuA_003D[num];
		for (int j = 4; j < num; j++)
		{
			_0023_003DziP9fFuA_003D[j] *= num9;
		}
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num++] = 1.0;
		_0023_003DziP9fFuA_003D[num] = 1.0;
		_0023_003Dzu76y2KE_003D = new Point4D[array.Length];
		for (int k = 0; k < _0023_003Dzu76y2KE_003D.Length; k++)
		{
			_0023_003Dzu76y2KE_003D[k] = new Point4D(array[k]);
		}
	}

	private static Curve _0023_003DzMkc2S2xIGSt_00242qze_0024w8UTbPaoayM(Point3D _0023_003DzAqOpw0w_003D, Vector3D _0023_003Dz3xnhcWA6ExeQ, Point3D _0023_003Dzk64JNOo_003D, Vector3D _0023_003DzZRQZPkw1E3os)
	{
		double[] knotVector = new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
		Point3D[] array = new Point3D[4]
		{
			_0023_003DzAqOpw0w_003D,
			_0023_003DzAqOpw0w_003D + _0023_003Dz3xnhcWA6ExeQ / 3.0,
			_0023_003Dzk64JNOo_003D - _0023_003DzZRQZPkw1E3os / 3.0,
			_0023_003Dzk64JNOo_003D
		};
		Point4D[] array2 = new Point4D[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = new Point4D(array[i]);
		}
		return new Curve(3, knotVector, array2);
	}

	public static Curve LocalInterpolation(IList<PointTangent> Q)
	{
		if (Q.Count < 2)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965629), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965584));
		}
		int count = Q.Count;
		foreach (PointTangent item in Q)
		{
			Vector3D tangent = item.Tangent;
			tangent.Normalize();
			item.Tx = tangent.X;
			item.Ty = tangent.Y;
			item.Tz = tangent.Z;
		}
		_0023_003DzrJs82hX704T3(Q, count, out var _0023_003Dzu76y2KE_003D, out var knotVector);
		return new Curve(3, knotVector, _0023_003Dzu76y2KE_003D);
	}

	private static double[] _0023_003Dzfu4Ct7hv1ONLa1lGSg_003D_003D<T>(IList<T> _0023_003DziDLVpbY_003D, int _0023_003DzB68dg9Q_003D, int _0023_003DzoMNiNRw_003D, fitPointMethod _0023_003DzJTQziP0_003D) where T : Point3D
	{
		double _0023_003DzH1SwwS4_003D;
		return _0023_003DzJTQziP0_003D switch
		{
			fitPointMethod.chordLength => _0023_003DzjjMC_0024_00248_003D(_0023_003DziDLVpbY_003D, _0023_003DzoMNiNRw_003D, out _0023_003DzH1SwwS4_003D, _0023_003Dz0jndlI35hm2U: false), 
			fitPointMethod.squareRoot => _0023_003DzjjMC_0024_00248_003D(_0023_003DziDLVpbY_003D, _0023_003DzoMNiNRw_003D, out _0023_003DzH1SwwS4_003D, _0023_003Dz0jndlI35hm2U: true), 
			fitPointMethod.uniform => NurbsBase.UniformKnotVector(_0023_003DzB68dg9Q_003D, _0023_003DzoMNiNRw_003D + 2), 
			_ => _0023_003DzjjMC_0024_00248_003D(_0023_003DziDLVpbY_003D, _0023_003DzoMNiNRw_003D, out _0023_003DzH1SwwS4_003D, _0023_003Dz0jndlI35hm2U: false), 
		};
	}

	private static double _0023_003DzSBwPifzya_eB<R>(IList<R> _0023_003DziDLVpbY_003D) where R : Point3D
	{
		double num = 0.0;
		for (int i = 0; i < _0023_003DziDLVpbY_003D.Count - 1; i++)
		{
			num += _0023_003DziDLVpbY_003D[i].DistanceTo(_0023_003DziDLVpbY_003D[i + 1]);
		}
		return num;
	}

	public static Curve NaturalCubicSplineInterpolation(IList<Point3D> Q, fitPointMethod method, Vector3D startTang = null, Vector3D endTang = null)
	{
		Q = Utility.RemoveDuplicates(Q);
		int count = Q.Count;
		if (count < 2)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965629), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965561));
		}
		double[] array = _0023_003Dzfu4Ct7hv1ONLa1lGSg_003D_003D(Q, 3, count, method);
		Point3D[] array2 = new Point3D[count + 2];
		array2[0] = Q[0];
		for (int i = 1; i < count - 1; i++)
		{
			array2[i + 1] = Q[i];
		}
		array2[count + 1] = Q[count - 1];
		if (startTang != null || endTang != null)
		{
			if (startTang != null && endTang != null)
			{
				return CubicSplineInterpolation(Q, startTang, endTang);
			}
			double num = _0023_003DzSBwPifzya_eB(Q);
			if (startTang != null)
			{
				array2[1] = array2[0] + num * (array[4] / 3.0) * startTang;
			}
			if (endTang != null)
			{
				array2[count] = (0.0 - num) * ((1.0 - array[count + 1]) / 3.0) * endTang + Q[count - 1];
			}
		}
		_0023_003DzF8PljSVDAmTs(Q, count, array2, array, out var _0023_003Dzu76y2KE_003D, startTang, endTang);
		return new Curve(3, array, _0023_003Dzu76y2KE_003D);
	}

	public static Curve CubicSplineInterpolation<R>(IList<R> Q, bool cornerEnd = false) where R : Point3D
	{
		Q = Utility.RemoveDuplicates(Q);
		int count = Q.Count;
		if (count < 4)
		{
			if (count < 2)
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965629), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965542));
			}
			return LocalInterpolation((IList<Point3D>)Q, cornerFlag: false);
		}
		double _0023_003DzH1SwwS4_003D;
		double[] array = _0023_003DzjjMC_0024_00248_003D(Q, count, out _0023_003DzH1SwwS4_003D, _0023_003Dz0jndlI35hm2U: false);
		Vector3D[] _0023_003DzO_0024iiQ4U_003D;
		Vector3D[] array2 = _0023_003DzNAUUNSIVVPna006kuA_003D_003D(Q, _0023_003Dz47beYi4u2gFe: false, out _0023_003DzO_0024iiQ4U_003D, cornerEnd);
		Vector3D vector3D = _0023_003DzH1SwwS4_003D * array2[0];
		Vector3D vector3D2 = _0023_003DzH1SwwS4_003D * array2[count - 1];
		Point3D[] array3 = new Point3D[count + 2];
		array3[0] = Q[0];
		array3[1] = array3[0] + array[4] / 3.0 * vector3D;
		for (int i = 1; i < count - 1; i++)
		{
			array3[i + 1] = Q[i];
		}
		array3[count] = (0.0 - (1.0 - array[count + 1]) / 3.0) * vector3D2 + Q[count - 1];
		array3[count + 1] = Q[count - 1];
		return _0023_003DzBfyqFUlu8SJd(Q, count, array3, array);
	}

	public static Curve CubicSplineInterpolation(IList<Point3D> Q, Vector3D startTang, Vector3D endTang)
	{
		int count = Q.Count;
		if (count < 2)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965629), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965551));
		}
		if (count == 2)
		{
			return _0023_003DzMkc2S2xIGSt_00242qze_0024w8UTbPaoayM(Q[0], startTang, Q[1], endTang);
		}
		double _0023_003DzH1SwwS4_003D;
		double[] array = _0023_003DzjjMC_0024_00248_003D(Q, count, out _0023_003DzH1SwwS4_003D, _0023_003Dz0jndlI35hm2U: false);
		Point3D[] array2 = new Point3D[count + 2];
		array2[0] = Q[0];
		array2[1] = array2[0] + _0023_003DzH1SwwS4_003D * (array[4] / 3.0) * startTang;
		for (int i = 1; i < count - 1; i++)
		{
			array2[i + 1] = Q[i];
		}
		array2[count] = (0.0 - _0023_003DzH1SwwS4_003D) * ((1.0 - array[count + 1]) / 3.0) * endTang + Q[count - 1];
		array2[count + 1] = Q[count - 1];
		return _0023_003DzBfyqFUlu8SJd(Q, count, array2, array);
	}

	private static double[] _0023_003DzjjMC_0024_00248_003D<T>(IList<T> _0023_003DziDLVpbY_003D, int _0023_003DzoMNiNRw_003D, out double _0023_003DzH1SwwS4_003D, bool _0023_003Dz0jndlI35hm2U) where T : Point3D
	{
		_0023_003DzH1SwwS4_003D = NurbsBase.ChordLengthParametrization(_0023_003DziDLVpbY_003D, out var ub, _0023_003Dz0jndlI35hm2U);
		double[] array = new double[_0023_003DzoMNiNRw_003D + 6];
		Array.Copy(ub, 0, array, 3, ub.Length);
		for (int i = _0023_003DzoMNiNRw_003D + 3; i < _0023_003DzoMNiNRw_003D + 6; i++)
		{
			array[i] = 1.0;
		}
		return array;
	}

	private static Curve _0023_003DzBfyqFUlu8SJd<T>(IList<T> _0023_003DziDLVpbY_003D, int _0023_003DzoMNiNRw_003D, Point3D[] _0023_003Dzl3DhHgI_003D, double[] _0023_003DziP9fFuA_003D) where T : Point3D
	{
		int degree = 3;
		Point4D[] array = new Point4D[_0023_003Dzl3DhHgI_003D.Length];
		for (int i = 0; i < _0023_003Dzl3DhHgI_003D.Length; i++)
		{
			array[i] = new Point4D(_0023_003Dzl3DhHgI_003D[i]);
		}
		_0023_003DzO03NUVe9m_0024IXQ2_0024mvpj_3YA_003D(_0023_003DzoMNiNRw_003D - 1, _0023_003DziDLVpbY_003D, _0023_003DziP9fFuA_003D, array);
		return new Curve(degree, _0023_003DziP9fFuA_003D, array);
	}

	private static int _0023_003DzF8PljSVDAmTs<T>(IList<T> _0023_003DziDLVpbY_003D, int _0023_003DzoMNiNRw_003D, Point3D[] _0023_003Dzl3DhHgI_003D, double[] _0023_003DziP9fFuA_003D, out Point4D[] _0023_003Dzu76y2KE_003D, Vector3D _0023_003DzNNrLHQq8COjS, Vector3D _0023_003DzhsbZLoZ7m44t) where T : Point3D
	{
		int result = 3;
		_0023_003Dzu76y2KE_003D = new Point4D[_0023_003Dzl3DhHgI_003D.Length];
		_0023_003Dzu76y2KE_003D[0] = new Point4D(_0023_003Dzl3DhHgI_003D[0]);
		if (_0023_003DzNNrLHQq8COjS != null)
		{
			_0023_003Dzu76y2KE_003D[1] = new Point4D(_0023_003Dzl3DhHgI_003D[1]);
		}
		_0023_003Dzu76y2KE_003D[_0023_003DzoMNiNRw_003D + 1] = new Point4D(_0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1]);
		if (_0023_003DzhsbZLoZ7m44t != null)
		{
			_0023_003Dzu76y2KE_003D[_0023_003DzoMNiNRw_003D] = new Point4D(_0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D]);
		}
		int num = Convert.ToInt32(_0023_003DzNNrLHQq8COjS != null);
		int num2 = Convert.ToInt32(_0023_003DzhsbZLoZ7m44t != null);
		double[,] array = _0023_003Dzt8e6WVO4xNcYUgNd0g_003D_003D(_0023_003DziDLVpbY_003D, _0023_003Dzl3DhHgI_003D, num, num2, _0023_003DzoMNiNRw_003D, result, _0023_003DziP9fFuA_003D);
		for (int i = 1; i < _0023_003DzoMNiNRw_003D + 1 - num - num2; i++)
		{
			_0023_003Dzu76y2KE_003D[i + num] = new Point4D(array[i - 1, 0], array[i - 1, 1], array[i - 1, 2], 1.0);
		}
		return result;
	}

	private static double[,] _0023_003Dzt8e6WVO4xNcYUgNd0g_003D_003D<T>(IList<T> _0023_003DziDLVpbY_003D, Point3D[] _0023_003Dzl3DhHgI_003D, int _0023_003DzAddCv_o_003D, int _0023_003Dz9iVQ96E_003D, int _0023_003DzoMNiNRw_003D, int _0023_003DzB68dg9Q_003D, double[] _0023_003DziP9fFuA_003D) where T : Point3D
	{
		double[,] _0023_003DzH9VU2k0_003D = new double[_0023_003DzoMNiNRw_003D - _0023_003DzAddCv_o_003D - _0023_003Dz9iVQ96E_003D, 3];
		int num = _0023_003DziP9fFuA_003D.Length;
		if (_0023_003DzAddCv_o_003D > 0)
		{
			int i = _0023_003DziP9fFuA_003D.FindSpan(_0023_003DzoMNiNRw_003D + 2, 3, _0023_003DziP9fFuA_003D[4]);
			double[] array = _0023_003DziP9fFuA_003D.BasisFuns(i, _0023_003DziP9fFuA_003D[4], 3);
			_0023_003DzH9VU2k0_003D[0, 0] = _0023_003DziDLVpbY_003D[1].X - array[0] * _0023_003Dzl3DhHgI_003D[1].X;
			_0023_003DzH9VU2k0_003D[0, 1] = _0023_003DziDLVpbY_003D[1].Y - array[0] * _0023_003Dzl3DhHgI_003D[1].Y;
			_0023_003DzH9VU2k0_003D[0, 2] = _0023_003DziDLVpbY_003D[1].Z - array[0] * _0023_003Dzl3DhHgI_003D[1].Z;
		}
		else
		{
			_0023_003DzH9VU2k0_003D[0, 0] = (0.0 - _0023_003DziDLVpbY_003D[0].X) / _0023_003DziP9fFuA_003D[1 + _0023_003DzB68dg9Q_003D];
			_0023_003DzH9VU2k0_003D[0, 1] = (0.0 - _0023_003DziDLVpbY_003D[0].Y) / _0023_003DziP9fFuA_003D[1 + _0023_003DzB68dg9Q_003D];
			_0023_003DzH9VU2k0_003D[0, 2] = (0.0 - _0023_003DziDLVpbY_003D[0].Z) / _0023_003DziP9fFuA_003D[1 + _0023_003DzB68dg9Q_003D];
		}
		for (int j = 1; j < _0023_003DzoMNiNRw_003D - 1 - _0023_003Dz9iVQ96E_003D; j++)
		{
			_0023_003DzH9VU2k0_003D[j, 0] = _0023_003DziDLVpbY_003D[j + _0023_003DzAddCv_o_003D].X;
			_0023_003DzH9VU2k0_003D[j, 1] = _0023_003DziDLVpbY_003D[j + _0023_003DzAddCv_o_003D].Y;
			_0023_003DzH9VU2k0_003D[j, 2] = _0023_003DziDLVpbY_003D[j + _0023_003DzAddCv_o_003D].Z;
		}
		int num2 = _0023_003DzH9VU2k0_003D.GetLength(0) - 1;
		if (_0023_003Dz9iVQ96E_003D > 0)
		{
			double[] array = _0023_003DziP9fFuA_003D.BasisFuns(_0023_003DziP9fFuA_003D.FindSpan(_0023_003DzoMNiNRw_003D + 2, 3, _0023_003DziP9fFuA_003D[_0023_003DzoMNiNRw_003D - 2 + 3]), _0023_003DziP9fFuA_003D[_0023_003DzoMNiNRw_003D - 2 + 3], 3);
			_0023_003DzH9VU2k0_003D[num2, 0] = _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 2].X - array[2] * _0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D].X;
			_0023_003DzH9VU2k0_003D[num2, 1] = _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 2].Y - array[2] * _0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D].Y;
			_0023_003DzH9VU2k0_003D[num2, 2] = _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 2].Z - array[2] * _0023_003Dzl3DhHgI_003D[_0023_003DzoMNiNRw_003D].Z;
		}
		else
		{
			_0023_003DzH9VU2k0_003D[num2, 0] = (0.0 - _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1].X) / (1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 2]);
			_0023_003DzH9VU2k0_003D[num2, 1] = (0.0 - _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1].Y) / (1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 2]);
			_0023_003DzH9VU2k0_003D[num2, 2] = (0.0 - _0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1].Z) / (1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 2]);
		}
		double[,] array2 = new double[_0023_003DzoMNiNRw_003D - _0023_003DzAddCv_o_003D - _0023_003Dz9iVQ96E_003D, _0023_003DzoMNiNRw_003D - _0023_003DzAddCv_o_003D - _0023_003Dz9iVQ96E_003D];
		if (_0023_003DzAddCv_o_003D == 0)
		{
			array2[0, 0] = (0.0 - (_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 1] + _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 2])) / (_0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 1] * _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 2]);
			array2[0, 1] = 1.0 / _0023_003DziP9fFuA_003D[_0023_003DzB68dg9Q_003D + 2];
		}
		int length = array2.GetLength(0);
		for (int k = 1 - _0023_003DzAddCv_o_003D; k < length; k++)
		{
			double[] array = _0023_003DziP9fFuA_003D.BasisFuns(_0023_003DziP9fFuA_003D.FindSpan(_0023_003DzoMNiNRw_003D + 2, 3, _0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D + _0023_003DzAddCv_o_003D]), _0023_003DziP9fFuA_003D[k + _0023_003DzB68dg9Q_003D + _0023_003DzAddCv_o_003D], 3);
			if (k > 0)
			{
				array2[k, k - 1] = array[0];
			}
			array2[k, k] = array[1];
			if (k + 1 < array2.GetLength(0))
			{
				array2[k, k + 1] = array[2];
			}
		}
		if (_0023_003Dz9iVQ96E_003D == 0)
		{
			array2[length - 1, length - 2] = 1.0 / (1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 3]);
			array2[length - 1, length - 1] = (0.0 - (2.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 2] - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 3])) / ((1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 2]) * (1.0 - _0023_003DziP9fFuA_003D[num - _0023_003DzB68dg9Q_003D - 3]));
		}
		NurbsBase._0023_003DzcpymVWGKJIjE(array2, ref _0023_003DzH9VU2k0_003D);
		return _0023_003DzH9VU2k0_003D;
	}

	private static void _0023_003DzO03NUVe9m_0024IXQ2_0024mvpj_3YA_003D<T>(int _0023_003DzoMNiNRw_003D, IList<T> _0023_003DziDLVpbY_003D, double[] _0023_003DziP9fFuA_003D, Point4D[] _0023_003Dzu76y2KE_003D) where T : Point3D
	{
		Point4D[] array = new Point4D[_0023_003DzoMNiNRw_003D];
		for (int i = 3; i < _0023_003DzoMNiNRw_003D; i++)
		{
			array[i] = new Point4D(_0023_003DziDLVpbY_003D[i - 1]);
		}
		double[] array2 = _0023_003DziP9fFuA_003D.BasisFuns(4, _0023_003DziP9fFuA_003D[4], 3);
		double num = array2[1];
		_0023_003Dzu76y2KE_003D[2] = (new Point4D(_0023_003DziDLVpbY_003D[1]) - array2[0] * _0023_003Dzu76y2KE_003D[1]) / num;
		double[] array3 = new double[_0023_003DzoMNiNRw_003D + 1];
		for (int j = 3; j < _0023_003DzoMNiNRw_003D; j++)
		{
			array3[j] = array2[2] / num;
			array2 = _0023_003DziP9fFuA_003D.BasisFuns(j + 2, _0023_003DziP9fFuA_003D[j + 2], 3);
			num = array2[1] - array2[0] * array3[j];
			_0023_003Dzu76y2KE_003D[j] = (array[j] - array2[0] * _0023_003Dzu76y2KE_003D[j - 1]) / num;
		}
		array3[_0023_003DzoMNiNRw_003D] = array2[2] / num;
		array2 = _0023_003DziP9fFuA_003D.BasisFuns(_0023_003DzoMNiNRw_003D + 2, _0023_003DziP9fFuA_003D[_0023_003DzoMNiNRw_003D + 2], 3);
		num = ((_0023_003DzoMNiNRw_003D == 2) ? array2[1] : (array2[1] - array2[0] * array3[_0023_003DzoMNiNRw_003D]));
		_0023_003Dzu76y2KE_003D[_0023_003DzoMNiNRw_003D] = (new Point4D(_0023_003DziDLVpbY_003D[_0023_003DzoMNiNRw_003D - 1]) - array2[2] * _0023_003Dzu76y2KE_003D[_0023_003DzoMNiNRw_003D + 1] - array2[0] * _0023_003Dzu76y2KE_003D[_0023_003DzoMNiNRw_003D - 1]) / num;
		for (int num2 = _0023_003DzoMNiNRw_003D - 1; num2 >= 2; num2--)
		{
			int num3 = num2;
			_0023_003Dzu76y2KE_003D[num3] -= array3[num2 + 1] * _0023_003Dzu76y2KE_003D[num2 + 1];
		}
	}

	private static double _0023_003Dz2tcTJoP2tr6U(Curve _0023_003DzytDpi1c_003D, Curve _0023_003Dzn8t0_00249E_003D, double _0023_003DzatyvRdw_003D, ref double _0023_003Dz5IEEoYE_003D, ref int _0023_003Dz2UIYKULnzSwn, ref int _0023_003DzjYU6egfiOYUJ)
	{
		_0023_003DzatyvRdw_003D = _0023_003DzytDpi1c_003D.Domain.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[_0023_003Dz2UIYKULnzSwn]);
		_0023_003Dz2UIYKULnzSwn++;
		if (_0023_003Dz2UIYKULnzSwn > _0023_003DzjYU6egfiOYUJ + 2)
		{
			_0023_003Dz5IEEoYE_003D = _0023_003Dzn8t0_00249E_003D.Domain.ParameterAt(NurbsBase._0023_003Dzhn3YS1oCYpgh[_0023_003DzjYU6egfiOYUJ]);
			_0023_003DzjYU6egfiOYUJ++;
		}
		return _0023_003DzatyvRdw_003D;
	}

	public static bool LineCurveBisection(Line line, ICurve curve, Plane plane, out InterPoint[] ip, bool reverse = false)
	{
		double num = 1E-09;
		ip = null;
		Line line2 = (Line)line.Clone();
		Vector3D vector3D = Vector3D.Cross(plane.AxisZ, Vector3D.AxisZ);
		double num2 = Vector3D.Dot(plane.AxisZ, Vector3D.AxisZ);
		double angleInRadians;
		if (num2 > 1.0 - num)
		{
			angleInRadians = 0.0;
			vector3D = Vector3D.AxisX;
		}
		else if (num2 < -1.0 + num)
		{
			angleInRadians = Math.PI;
			vector3D = Vector3D.AxisX;
		}
		else
		{
			double length = vector3D.Length;
			double x = Vector3D.Dot(plane.AxisZ, Vector3D.AxisZ);
			angleInRadians = Math.Atan2(length, x);
		}
		Transformation transformation = Transformation.CreateRotation(angleInRadians, vector3D);
		line2.TransformBy(transformation);
		Transformation transformation2 = Transformation.CreateRotation(0.0 - line2.Tangent.AngleInXY, Vector3D.AxisZ);
		line2.TransformBy(transformation2);
		Vector3D asVector = line2.StartPoint.AsVector;
		asVector.Negate();
		Transformation transformation3 = Transformation.CreateTranslation(asVector);
		line2.TransformBy(transformation3);
		Transformation xform = transformation3 * (transformation2 * transformation);
		Curve nurbsForm = ((ICurve)curve.Clone()).GetNurbsForm();
		nurbsForm.TransformBy(xform);
		nurbsForm.Regen(new RegenParams(0.0, Math.PI / 18.0));
		Curve nurbsForm2 = curve.GetNurbsForm();
		List<double[]> list = new List<double[]>();
		List<InterPoint> list2 = new List<InterPoint>(list.Count);
		bool flag = Math.Abs(nurbsForm.Vertices[0].Y) < num;
		if (flag)
		{
			InterPoint item = _0023_003DzMg4P2nPx6kiR3j6n683xQY8_003D(nurbsForm, line2, nurbsForm2, line, ((PointTangentU)nurbsForm.Vertices[0]).U, reverse);
			list2.Add(item);
		}
		bool flag2 = nurbsForm.Vertices[0].Y > 0.0;
		for (int i = 1; i < nurbsForm.Vertices.Length; i++)
		{
			bool flag3 = nurbsForm.Vertices[i].Y > 0.0;
			bool flag4 = Math.Abs(nurbsForm.Vertices[i].Y) < num;
			if (flag4)
			{
				InterPoint item2 = _0023_003DzMg4P2nPx6kiR3j6n683xQY8_003D(nurbsForm, line2, nurbsForm2, line, ((PointTangentU)nurbsForm.Vertices[i]).U, reverse);
				list2.Add(item2);
			}
			else if (flag2 != flag3 && !flag)
			{
				list.Add(new double[2]
				{
					((PointTangentU)nurbsForm.Vertices[i - 1]).U,
					((PointTangentU)nurbsForm.Vertices[i]).U
				});
			}
			flag2 = flag3;
			flag = flag4;
		}
		for (int j = 0; j < list.Count; j++)
		{
			double num3 = _0023_003DzOz36ECnYk3szZd4BQJpQ1go_003D(line2, nurbsForm, list[j][0], list[j][1], num);
			if (!double.IsNaN(num3))
			{
				InterPoint item3 = _0023_003DzMg4P2nPx6kiR3j6n683xQY8_003D(nurbsForm, line2, nurbsForm2, line, num3, reverse);
				list2.Add(item3);
			}
		}
		ip = list2.ToArray();
		if (ip != null)
		{
			return true;
		}
		return false;
	}

	internal static InterPoint _0023_003DzMg4P2nPx6kiR3j6n683xQY8_003D(Curve _0023_003DzNNT3508Bet6H, Line _0023_003DzHSdw4lnSEJ26, Curve _0023_003Dzyx_00247RPgsA7nU, Line _0023_003DzQ9zpGF0_003D, double _0023_003DzuwH5j5s_003D, bool _0023_003DzEXLcE10_003D)
	{
		Point3D point = _0023_003DzNNT3508Bet6H.PointAt(_0023_003DzuwH5j5s_003D);
		_0023_003DzHSdw4lnSEJ26.Project(point, out var t);
		Vector3D[] array = _0023_003Dzyx_00247RPgsA7nU.Evaluate(_0023_003DzuwH5j5s_003D, 1);
		Point3D point3D = _0023_003DzQ9zpGF0_003D.PointAt(t);
		array[1].Normalize();
		if (_0023_003DzEXLcE10_003D)
		{
			return _0023_003DzrctcHQEXUzqK(array[0], point3D.AsVector, _0023_003DzuwH5j5s_003D, t, array[1], _0023_003DzQ9zpGF0_003D.Tangent);
		}
		return _0023_003DzrctcHQEXUzqK(point3D.AsVector, array[0], t, _0023_003DzuwH5j5s_003D, _0023_003DzQ9zpGF0_003D.Tangent, array[1]);
	}

	internal static double _0023_003DzOz36ECnYk3szZd4BQJpQ1go_003D(Line _0023_003DzQ9zpGF0_003D, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz3YfTAqg_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz7ax6DF3ykf6J)
	{
		double y = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz3YfTAqg_003D).Y;
		double y2 = _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003DzRFb1SGo_003D).Y;
		if (y * y2 > 0.0)
		{
			return double.NaN;
		}
		if (y == 0.0)
		{
			return _0023_003Dz3YfTAqg_003D;
		}
		if (y2 == 0.0)
		{
			return _0023_003DzRFb1SGo_003D;
		}
		double num;
		double num2;
		if (y < 0.0)
		{
			num = _0023_003Dz3YfTAqg_003D;
			num2 = _0023_003DzRFb1SGo_003D;
		}
		else
		{
			num = _0023_003DzRFb1SGo_003D;
			num2 = _0023_003Dz3YfTAqg_003D;
		}
		double num3 = Math.Abs(_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D);
		for (int i = 0; i < 100; i++)
		{
			num3 = 0.5 * (num2 - num);
			double num4 = num + num3;
			Point3D point3D = _0023_003Dz8fpRyMu9aKjE.PointAt(num4);
			double y3 = point3D.Y;
			if (Math.Abs(y3) < _0023_003Dz7ax6DF3ykf6J || Math.Abs(num3) < _0023_003Dz7ax6DF3ykf6J)
			{
				_0023_003DzQ9zpGF0_003D.Project(point3D, out var t);
				_0023_003DzQ9zpGF0_003D.PointAt(t);
				if (t > _0023_003DzQ9zpGF0_003D.Domain.Left && t < _0023_003DzQ9zpGF0_003D.Domain.Right)
				{
					return num4;
				}
				return double.NaN;
			}
			if (y3 < 0.0)
			{
				num = num4;
			}
			else
			{
				num2 = num4;
			}
		}
		return double.NaN;
	}

	internal static bool _0023_003DzUhQEKrRzaznj(Curve _0023_003DzytDpi1c_003D, Curve _0023_003Dzn8t0_00249E_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, out InterPoint _0023_003DzqoHxF0k_003D, double _0023_003DzccAR5G0_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzfBEBL_o_003D, Vector3D _0023_003DzQqOWrmM_003D)
	{
		bool isClosed = _0023_003DzytDpi1c_003D.IsClosed;
		double low = _0023_003DzytDpi1c_003D.Domain.Low;
		double high = _0023_003DzytDpi1c_003D.Domain.High;
		bool isClosed2 = _0023_003Dzn8t0_00249E_003D.IsClosed;
		double low2 = _0023_003Dzn8t0_00249E_003D.Domain.Low;
		double high2 = _0023_003Dzn8t0_00249E_003D.Domain.High;
		_0023_003DzqoHxF0k_003D = null;
		int i = 0;
		Tuple<double, double>[] array = new Tuple<double, double>[8];
		double rLen = 0.0;
		Vector3D vector3D = null;
		Vector3D vector3D2 = null;
		Vector3D _0023_003DzIS3LzEk_003D = null;
		Vector3D _0023_003DzIS3LzEk_003D2 = null;
		double num = 1.0;
		for (; i < 41; i++)
		{
			Vector3D[] array2 = ((_0023_003DzytDpi1c_003D.EntityData == null || !(_0023_003DzytDpi1c_003D.EntityData is IEvaluable)) ? _0023_003DzytDpi1c_003D.Evaluate(_0023_003Dz_eY3Y4c_003D, 1) : ((IEvaluable)_0023_003DzytDpi1c_003D.EntityData).Evaluate(_0023_003Dz_eY3Y4c_003D, 1));
			Vector3D[] array3 = ((_0023_003Dzn8t0_00249E_003D.EntityData == null || !(_0023_003Dzn8t0_00249E_003D.EntityData is IEvaluable)) ? _0023_003Dzn8t0_00249E_003D.Evaluate(_0023_003DzuwH5j5s_003D, 1) : ((IEvaluable)_0023_003Dzn8t0_00249E_003D.EntityData).Evaluate(_0023_003DzuwH5j5s_003D, 1));
			vector3D = array2[0];
			Vector3D vector3D3 = array2[1];
			vector3D2 = array3[0];
			Vector3D vector3D4 = array3[1];
			double length = vector3D3.Length;
			double length2 = vector3D4.Length;
			if (double.IsNaN(length) || double.IsInfinity(length) || length < 2.220446049250313E-16 || double.IsNaN(length2) || double.IsInfinity(length2) || length2 < 2.220446049250313E-16)
			{
				return false;
			}
			_0023_003DzIS3LzEk_003D = vector3D3;
			_0023_003DzIS3LzEk_003D2 = vector3D4;
			Vector3D vector3D5 = new Vector3D();
			Vector3D vector3D6 = new Vector3D();
			if (_0023_003DzfBEBL_o_003D != 0.0)
			{
				vector3D5 = Vector3D.Cross(_0023_003DzQqOWrmM_003D, vector3D3);
				vector3D6 = Vector3D.Cross(_0023_003DzQqOWrmM_003D, vector3D4);
				vector3D5.Normalize();
				vector3D6.Normalize();
				_0023_003DzytDpi1c_003D._0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(_0023_003Dz_eY3Y4c_003D, _0023_003DzfBEBL_o_003D, _0023_003DzQqOWrmM_003D, out _0023_003DzIS3LzEk_003D);
				_0023_003Dzn8t0_00249E_003D._0023_003DzTZ5OXa7wFkb381BkxA_003D_003D(_0023_003DzuwH5j5s_003D, _0023_003DzfBEBL_o_003D, _0023_003DzQqOWrmM_003D, out _0023_003DzIS3LzEk_003D2);
				length = _0023_003DzIS3LzEk_003D.Length;
				length2 = _0023_003DzIS3LzEk_003D2.Length;
				vector3D += vector3D5 * _0023_003DzfBEBL_o_003D;
				vector3D2 += vector3D6 * _0023_003DzfBEBL_o_003D;
			}
			_0023_003DzIS3LzEk_003D.Normalize();
			_0023_003DzIS3LzEk_003D2.Normalize();
			if (Utility.PointCoincidence(vector3D, vector3D2, _0023_003DzccAR5G0_003D, out var _, out rLen))
			{
				if (Vector3D.AreParallel(_0023_003DzIS3LzEk_003D, _0023_003DzIS3LzEk_003D2, Utility._0023_003Dzjyaz_Vfaky9X) && _0023_003DzscA8U9UU7P2p(_0023_003DzytDpi1c_003D, _0023_003Dzn8t0_00249E_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzX0qX_IwWxysi, out var _0023_003DzqoHxF0k_003D2, _0023_003DzccAR5G0_003D))
				{
					_0023_003DzqoHxF0k_003D = _0023_003DzqoHxF0k_003D2;
					return true;
				}
				_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzIS3LzEk_003D, _0023_003DzIS3LzEk_003D2);
				return true;
			}
			double[,] array4 = new double[4, 2];
			array4[0, 0] = _0023_003DzIS3LzEk_003D.X;
			array4[1, 0] = _0023_003DzIS3LzEk_003D.Y;
			array4[2, 0] = _0023_003DzIS3LzEk_003D.Z;
			array4[0, 1] = 0.0 - _0023_003DzIS3LzEk_003D2.X;
			array4[1, 1] = 0.0 - _0023_003DzIS3LzEk_003D2.Y;
			array4[2, 1] = 0.0 - _0023_003DzIS3LzEk_003D2.Z;
			double[] array5 = new double[4]
			{
				vector3D2.X - vector3D.X,
				vector3D2.Y - vector3D.Y,
				vector3D2.Z - vector3D.Z,
				0.0
			};
			if (_0023_003DzfBEBL_o_003D != 0.0)
			{
				Vector3D vector3D7 = Vector3D.Cross(vector3D5, vector3D6);
				vector3D7.Normalize();
				array4[3, 0] = vector3D7 * _0023_003DzIS3LzEk_003D;
				array5[3] = 0.5 * vector3D7 * (vector3D2 - vector3D);
			}
			double[] array6;
			try
			{
				array6 = NurbsBase._0023_003DzphmdrE9a2afe(array4, array5);
			}
			catch (Exception)
			{
				return false;
			}
			double num2 = _0023_003Dz_eY3Y4c_003D + num * (array6[0] / length);
			double num3 = _0023_003DzuwH5j5s_003D + num * (array6[1] / length2);
			double length3 = ((num2 - _0023_003Dz_eY3Y4c_003D) * _0023_003DzIS3LzEk_003D).Length;
			double length4 = ((num3 - _0023_003DzuwH5j5s_003D) * _0023_003DzIS3LzEk_003D2).Length;
			bool num4 = Utility.ParametersDontChangeSignificantly(length3, _0023_003DzccAR5G0_003D);
			bool flag = Utility.ParametersDontChangeSignificantly(length4, _0023_003DzccAR5G0_003D);
			if (num4 && flag)
			{
				if (_0023_003DzfBEBL_o_003D == 0.0 && rLen <= _0023_003DzX0qX_IwWxysi)
				{
					_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzIS3LzEk_003D, _0023_003DzIS3LzEk_003D2);
					return true;
				}
				return false;
			}
			if (isClosed)
			{
				if (num2 < low)
				{
					num2 = high - (low - num2);
				}
				else if (num2 > high)
				{
					num2 = low + (num2 - high);
				}
			}
			else if (num2 < low)
			{
				num2 = low;
			}
			else if (num2 > high)
			{
				num2 = high;
			}
			_0023_003Dz_eY3Y4c_003D = num2;
			if (isClosed2)
			{
				if (num3 < low2)
				{
					num3 = high2 - (low2 - num3);
				}
				else if (num3 > high2)
				{
					num3 = low2 + (num3 - high2);
				}
			}
			else if (num3 < low2)
			{
				num3 = low2;
			}
			else if (num3 > high2)
			{
				num3 = high2;
			}
			_0023_003DzuwH5j5s_003D = num3;
			Tuple<double, double> tuple = new Tuple<double, double>(_0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D);
			int num5 = -1;
			for (int j = 0; j < array.Length && array[j] != null; j++)
			{
				if (Math.Abs(array[j].Item1 - tuple.Item1) / _0023_003DzccAR5G0_003D < 1E-12 && Math.Abs(array[j].Item2 - tuple.Item2) / _0023_003DzccAR5G0_003D < 1E-12)
				{
					num5 = j;
					break;
				}
			}
			if (num5 != -1)
			{
				if (num < 0.1)
				{
					break;
				}
				num /= 2.0;
			}
			Utility.RotateRight(array);
			array[0] = tuple;
		}
		if (rLen <= _0023_003DzX0qX_IwWxysi)
		{
			_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, _0023_003DzIS3LzEk_003D, _0023_003DzIS3LzEk_003D2);
		}
		return false;
	}

	internal static bool _0023_003DzscA8U9UU7P2p(Curve _0023_003DzytDpi1c_003D, Curve _0023_003Dzn8t0_00249E_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, double _0023_003DzX0qX_IwWxysi, out InterPoint _0023_003DzqoHxF0k_003D, double _0023_003DzccAR5G0_003D)
	{
		int num = 40;
		bool isClosed = _0023_003DzytDpi1c_003D.IsClosed;
		double low = _0023_003DzytDpi1c_003D.Domain.Low;
		double high = _0023_003DzytDpi1c_003D.Domain.High;
		bool isClosed2 = _0023_003Dzn8t0_00249E_003D.IsClosed;
		double low2 = _0023_003Dzn8t0_00249E_003D.Domain.Low;
		double high2 = _0023_003Dzn8t0_00249E_003D.Domain.High;
		_0023_003DzqoHxF0k_003D = null;
		int i = 0;
		Tuple<double, double>[] array = new Tuple<double, double>[8];
		double rLen = 0.0;
		Vector3D vector3D = null;
		Vector3D vector3D2 = null;
		Vector3D vector3D3 = null;
		Vector3D vector3D4 = null;
		for (; i < num; i++)
		{
			Vector3D[] array2 = ((_0023_003DzytDpi1c_003D.EntityData == null || !(_0023_003DzytDpi1c_003D.EntityData is IEvaluable)) ? _0023_003DzytDpi1c_003D.Evaluate(_0023_003Dz_eY3Y4c_003D, 2) : ((IEvaluable)_0023_003DzytDpi1c_003D.EntityData).Evaluate(_0023_003Dz_eY3Y4c_003D, 2));
			Vector3D[] array3 = ((_0023_003Dzn8t0_00249E_003D.EntityData == null || !(_0023_003Dzn8t0_00249E_003D.EntityData is IEvaluable)) ? _0023_003Dzn8t0_00249E_003D.Evaluate(_0023_003DzuwH5j5s_003D, 2) : ((IEvaluable)_0023_003Dzn8t0_00249E_003D.EntityData).Evaluate(_0023_003DzuwH5j5s_003D, 2));
			vector3D = array2[0];
			Vector3D vector3D5 = array2[1];
			Vector3D vector3D6 = array2[2];
			vector3D2 = array3[0];
			Vector3D vector3D7 = array3[1];
			Vector3D vector3D8 = array3[2];
			double length = vector3D5.Length;
			double length2 = vector3D7.Length;
			if (double.IsNaN(length) || double.IsInfinity(length) || length < 2.220446049250313E-16 || double.IsNaN(length2) || double.IsInfinity(length2) || length2 < 2.220446049250313E-16)
			{
				return false;
			}
			vector3D3 = (Vector3D)vector3D5.Clone();
			vector3D4 = (Vector3D)vector3D7.Clone();
			new Vector3D();
			new Vector3D();
			vector3D3.Normalize();
			vector3D4.Normalize();
			if (Utility.PointCoincidence(vector3D, vector3D2, _0023_003DzccAR5G0_003D, out var _, out rLen, 1E-12) && Vector3D.AreParallel(vector3D3, vector3D4, 1E-14))
			{
				_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, vector3D3, vector3D4);
				return true;
			}
			double[,] array4 = new double[6, 2];
			double[] array5 = new double[6];
			array4[0, 0] = vector3D3.X;
			array4[1, 0] = vector3D3.Y;
			array4[2, 0] = vector3D3.Z;
			array4[0, 1] = 0.0 - vector3D4.X;
			array4[1, 1] = 0.0 - vector3D4.Y;
			array4[2, 1] = 0.0 - vector3D4.Z;
			array5[0] = vector3D2.X - vector3D.X;
			array5[1] = vector3D2.Y - vector3D.Y;
			array5[2] = vector3D2.Z - vector3D.Z;
			double num2 = Vector3D.Dot(vector3D5, vector3D6);
			double num3 = Vector3D.Dot(vector3D7, vector3D8);
			Vector3D vector3D9 = Vector3D.Cross((vector3D6 * length * length - vector3D5 * num2) / (length * length * length), vector3D7 / length2);
			Vector3D b = (vector3D8 * length2 * length2 - vector3D7 * num3) / (length2 * length2 * length2);
			Vector3D vector3D10 = Vector3D.Cross(vector3D5 / length, b);
			array4[3, 0] = vector3D9.X;
			array4[4, 0] = vector3D9.Y;
			array4[5, 0] = vector3D9.Z;
			array4[3, 1] = vector3D10.X;
			array4[4, 1] = vector3D10.Y;
			array4[5, 1] = vector3D10.Z;
			Vector3D vector3D11 = Vector3D.Cross(vector3D4, vector3D3);
			array5[3] = vector3D11.X;
			array5[4] = vector3D11.Y;
			array5[5] = vector3D11.Z;
			double[] array6;
			try
			{
				array6 = NurbsBase._0023_003DzphmdrE9a2afe(array4, array5);
			}
			catch (Exception)
			{
				return false;
			}
			double num4 = _0023_003Dz_eY3Y4c_003D + array6[0];
			double num5 = _0023_003DzuwH5j5s_003D + array6[1];
			double length3 = ((num4 - _0023_003Dz_eY3Y4c_003D) * vector3D3).Length;
			double length4 = ((num5 - _0023_003DzuwH5j5s_003D) * vector3D4).Length;
			bool num6 = Utility.ParametersDontChangeSignificantly(length3, _0023_003DzccAR5G0_003D);
			bool flag = Utility.ParametersDontChangeSignificantly(length4, _0023_003DzccAR5G0_003D);
			if (num6 && flag)
			{
				if (rLen <= _0023_003DzX0qX_IwWxysi)
				{
					_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, vector3D3, vector3D4);
					return true;
				}
				return false;
			}
			if (isClosed)
			{
				if (num4 < low)
				{
					num4 = high - (low - num4);
				}
				else if (num4 > high)
				{
					num4 = low + (num4 - high);
				}
			}
			else if (num4 < low)
			{
				num4 = low;
			}
			else if (num4 > high)
			{
				num4 = high;
			}
			_0023_003Dz_eY3Y4c_003D = num4;
			if (isClosed2)
			{
				if (num5 < low2)
				{
					num5 = high2 - (low2 - num5);
				}
				else if (num5 > high2)
				{
					num5 = low2 + (num5 - high2);
				}
			}
			else if (num5 < low2)
			{
				num5 = low2;
			}
			else if (num5 > high2)
			{
				num5 = high2;
			}
			_0023_003DzuwH5j5s_003D = num5;
			Tuple<double, double> tuple = new Tuple<double, double>(_0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D);
			if (Array.IndexOf(array, tuple) != -1)
			{
				break;
			}
			Utility.RotateRight(array);
			array[0] = tuple;
		}
		if (rLen <= _0023_003DzX0qX_IwWxysi)
		{
			_0023_003DzqoHxF0k_003D = _0023_003DzrctcHQEXUzqK(vector3D, vector3D2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, vector3D3, vector3D4);
		}
		return false;
	}

	private static InterPoint _0023_003DzrctcHQEXUzqK(Vector3D _0023_003DzFj_0024IqDQ_003D, Vector3D _0023_003DzjdeMMkk_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, Vector3D _0023_003Dzmuv_0024bE4_003D, Vector3D _0023_003Dz8Q5Cqbg_003D)
	{
		Vector3D vector3D = (_0023_003DzFj_0024IqDQ_003D + _0023_003DzjdeMMkk_003D) / 2.0;
		InterPoint interPoint = new InterPoint(vector3D.X, vector3D.Y, vector3D.Z, _0023_003Dz_eY3Y4c_003D, 0.0, _0023_003DzuwH5j5s_003D, 0.0);
		if (Vector3D.AreParallel(_0023_003Dzmuv_0024bE4_003D, _0023_003Dz8Q5Cqbg_003D, Utility._0023_003Dzjyaz_Vfaky9X))
		{
			interPoint.IsTangent = true;
			interPoint.Tangent = (_0023_003Dzmuv_0024bE4_003D + _0023_003Dz8Q5Cqbg_003D) / 2.0;
		}
		return interPoint;
	}

	internal static void _0023_003Dz61B8IYSGx6wG(IEnumerable<ICurve> _0023_003DzTj1oJWREOpXS, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		Point3D point3D = new Point3D();
		foreach (ICurve _0023_003DzTj1oJWREOpX in _0023_003DzTj1oJWREOpXS)
		{
			ICurve[] individualCurves = _0023_003DzTj1oJWREOpX.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve nurbsForm = individualCurves[i].GetNurbsForm();
				for (int j = 0; j < nurbsForm._0023_003DzMv2C5Tm1QMvc(); j++)
				{
					Point4D point4D = nurbsForm.Pw[j];
					point3D.X = point4D.X / point4D.W;
					point3D.Y = point4D.Y / point4D.W;
					point3D.Z = point4D.Z / point4D.W;
					if (point3D.X < _0023_003DzF7v9r2A_003D.X)
					{
						_0023_003DzF7v9r2A_003D.X = point3D.X;
					}
					if (point3D.X > _0023_003Dz8dK2uhU_003D.X)
					{
						_0023_003Dz8dK2uhU_003D.X = point3D.X;
					}
					if (point3D.Y < _0023_003DzF7v9r2A_003D.Y)
					{
						_0023_003DzF7v9r2A_003D.Y = point3D.Y;
					}
					if (point3D.Y > _0023_003Dz8dK2uhU_003D.Y)
					{
						_0023_003Dz8dK2uhU_003D.Y = point3D.Y;
					}
					if (point3D.Z < _0023_003DzF7v9r2A_003D.Z)
					{
						_0023_003DzF7v9r2A_003D.Z = point3D.Z;
					}
					if (point3D.Z > _0023_003Dz8dK2uhU_003D.Z)
					{
						_0023_003Dz8dK2uhU_003D.Z = point3D.Z;
					}
				}
			}
		}
	}

	internal static void _0023_003Dz61B8IYSGx6wG(IEnumerable<ICurve> _0023_003DzTj1oJWREOpXS, Plane _0023_003DzjMyoFdQ_003D, out Point2D _0023_003DzF7v9r2A_003D, out Point2D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzF7v9r2A_003D = Point2D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point2D.MinValue;
		foreach (ICurve _0023_003DzTj1oJWREOpX in _0023_003DzTj1oJWREOpXS)
		{
			ICurve[] individualCurves = _0023_003DzTj1oJWREOpX.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve nurbsForm = individualCurves[i].GetNurbsForm();
				for (int j = 0; j < nurbsForm._0023_003DzMv2C5Tm1QMvc(); j++)
				{
					Point4D point4D = nurbsForm.Pw[j];
					Point2D point2D = _0023_003DzjMyoFdQ_003D.Project(point4D.Euclid);
					if (point2D.X < _0023_003DzF7v9r2A_003D.X)
					{
						_0023_003DzF7v9r2A_003D.X = point2D.X;
					}
					if (point2D.X > _0023_003Dz8dK2uhU_003D.X)
					{
						_0023_003Dz8dK2uhU_003D.X = point2D.X;
					}
					if (point2D.Y < _0023_003DzF7v9r2A_003D.Y)
					{
						_0023_003DzF7v9r2A_003D.Y = point2D.Y;
					}
					if (point2D.Y > _0023_003Dz8dK2uhU_003D.Y)
					{
						_0023_003Dz8dK2uhU_003D.Y = point2D.Y;
					}
				}
			}
		}
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		return Utility.Intersection(this, C2, maxGap, computeParameters);
	}

	public static bool MinimumDistance(Curve F, Curve G, ref double u, ref double s, out double distance)
	{
		return MinimumDistance(F, G, allowOutside: true, ref u, ref s, out distance);
	}

	public static bool MinimumDistance(Curve F, Curve G, bool allowOutside, ref double u, ref double s, out double distance)
	{
		bool isClosed = F.IsClosed;
		double low = F.Domain.Low;
		double high = F.Domain.High;
		bool isClosed2 = G.IsClosed;
		double low2 = G.Domain.Low;
		double high2 = G.Domain.High;
		int num = 0;
		distance = 0.0;
		do
		{
			Vector3D[] array = F.Evaluate(u, 2);
			Vector3D vector3D = array[0];
			Vector3D vector3D2 = array[1];
			Vector3D vector3D3 = array[2];
			Vector3D[] array2 = G.Evaluate(s, 2);
			Vector3D vector3D4 = array2[0];
			Vector3D vector3D5 = array2[1];
			Vector3D obj = array2[2];
			Vector3D vector3D6 = vector3D4 - vector3D;
			Vector3D vector3D7 = vector3D - vector3D4;
			distance = vector3D7.Length;
			if (Utility.Solve2x2(obj * vector3D6 + vector3D5 * vector3D5, 0.0 - vector3D5 * vector3D2, 0.0 - vector3D2 * vector3D5, vector3D3 * vector3D7 + vector3D2 * vector3D2, 0.0 - vector3D5 * vector3D6, 0.0 - vector3D2 * vector3D7, out var x_addr, out var y_addr, out var _) != 2)
			{
				return false;
			}
			double num2 = u + y_addr;
			double num3 = s + x_addr;
			if (isClosed)
			{
				if (num2 < low)
				{
					num2 = high - (low - num2);
				}
				else if (num2 > high)
				{
					num2 = low + (num2 - high);
				}
			}
			else if (!allowOutside)
			{
				if (num2 < low)
				{
					num2 = low;
				}
				else if (num2 > high)
				{
					num2 = high;
				}
			}
			if (isClosed2)
			{
				if (num3 < low2)
				{
					num3 = high2 - (low2 - num3);
				}
				else if (num3 > high2)
				{
					num3 = low2 + (num3 - high2);
				}
			}
			else if (!allowOutside)
			{
				if (num3 < low2)
				{
					num3 = low2;
				}
				else if (num3 > high2)
				{
					num3 = high2;
				}
			}
			double length = (y_addr * vector3D2).Length;
			double length2 = (x_addr * vector3D5).Length;
			double length3 = F.Domain.Length;
			double length4 = G.Domain.Length;
			if ((Utility.ParametersDontChangeSignificantly(length, length3) && Utility.ParametersDontChangeSignificantly(length2, length4)) || distance < 1E-12)
			{
				return true;
			}
			u = num2;
			s = num3;
		}
		while (num++ < 32);
		return false;
	}

	public BoundingCone ComputeBoundingCone()
	{
		Vector3D[] array = ComputeHodograph(_0023_003DzB68dg9Q_003D, Pw);
		if (array == null)
		{
			return null;
		}
		return NurbsBase.ComputeConeFromVectors(array);
	}

	private static double _0023_003DzbzgxJgU_003D(double _0023_003DzjbqS1qE_003D, _0023_003Dzyq1EkI8_003D _0023_003DzcNU_0024mJM_003D)
	{
		return _0023_003DzcNU_0024mJM_003D._0023_003Dz8fpRyMu9aKjE._0023_003Dz9yG9ZEk_003D(_0023_003DzjbqS1qE_003D);
	}

	private double _0023_003Dz9yG9ZEk_003D(double _0023_003Dz_eY3Y4c_003D)
	{
		return Evaluate(_0023_003Dz_eY3Y4c_003D, 1)[1].Length;
	}

	internal double _0023_003Dz736ekIs_003D()
	{
		int num = 55;
		double _0023_003DzezTples_003D = 1E-06;
		if (_0023_003DzpugXdEauu4S6 == null)
		{
			_0023_003DzpugXdEauu4S6 = new double[num];
			_0023_003Dzx6R3pGE2FVDTWBiMuw_003D_003D(_0023_003DzpugXdEauu4S6);
		}
		_0023_003Dzyq1EkI8_003D _0023_003DzyIxzFss_003D = new _0023_003Dzyq1EkI8_003D(this);
		double num2 = 0.0;
		for (int i = _0023_003DzB68dg9Q_003D; i < Pw.Length; i++)
		{
			if (!(_0023_003DziP9fFuA_003D[i] >= _0023_003DziP9fFuA_003D[i + 1]))
			{
				_0023_003DzyIxzFss_003D._0023_003DzgqZzIes_003D = i;
				num2 += _0023_003DzuQVVKHmPr0O_(_0023_003DzbzgxJgU_003D, _0023_003DzyIxzFss_003D, _0023_003DziP9fFuA_003D[i], _0023_003DziP9fFuA_003D[i + 1], _0023_003DzezTples_003D, _0023_003DzpugXdEauu4S6, out var _);
			}
		}
		return num2;
	}

	private double _0023_003DzuQVVKHmPr0O_(_0023_003DzjcmYKSSxrpyH _0023_003DzhidJeNw_003D, _0023_003Dzyq1EkI8_003D _0023_003DzyIxzFss_003D, double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzezTples_003D, double[] _0023_003DzAvn2b38_003D, out double _0023_003DzEZdZXKE_003D)
	{
		int num = _0023_003DzAvn2b38_003D.Length - 1;
		double num2 = 10.0;
		double num3 = 0.5 * (_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D);
		double num4 = 2.0 * _0023_003DzAvn2b38_003D[num];
		double num5 = num3 * _0023_003DzAvn2b38_003D[num];
		_0023_003DzAvn2b38_003D[0] = 0.5 * _0023_003DzhidJeNw_003D(_0023_003DzjbqS1qE_003D, _0023_003DzyIxzFss_003D);
		_0023_003DzAvn2b38_003D[3] = 0.5 * _0023_003DzhidJeNw_003D(_0023_003Dz1v6oPQk_003D, _0023_003DzyIxzFss_003D);
		_0023_003DzAvn2b38_003D[2] = _0023_003DzhidJeNw_003D(_0023_003DzjbqS1qE_003D + num5, _0023_003DzyIxzFss_003D);
		_0023_003DzAvn2b38_003D[4] = _0023_003DzhidJeNw_003D(_0023_003Dz1v6oPQk_003D - num5, _0023_003DzyIxzFss_003D);
		_0023_003DzAvn2b38_003D[1] = _0023_003DzhidJeNw_003D(_0023_003DzjbqS1qE_003D + num3, _0023_003DzyIxzFss_003D);
		double num6 = 0.5 * (Math.Abs(_0023_003DzAvn2b38_003D[0]) + Math.Abs(_0023_003DzAvn2b38_003D[1]) + Math.Abs(_0023_003DzAvn2b38_003D[2]) + Math.Abs(_0023_003DzAvn2b38_003D[3]) + Math.Abs(_0023_003DzAvn2b38_003D[4]));
		_0023_003DzAvn2b38_003D[0] += _0023_003DzAvn2b38_003D[3];
		_0023_003DzAvn2b38_003D[2] += _0023_003DzAvn2b38_003D[4];
		double num7 = _0023_003DzAvn2b38_003D[0] + _0023_003DzAvn2b38_003D[1] + _0023_003DzAvn2b38_003D[2];
		double num8 = _0023_003DzAvn2b38_003D[0] * _0023_003DzAvn2b38_003D[num - 1] + _0023_003DzAvn2b38_003D[1] * _0023_003DzAvn2b38_003D[num - 2] + _0023_003DzAvn2b38_003D[2] * _0023_003DzAvn2b38_003D[num - 3];
		double num9 = num6 * Math.Sqrt(_0023_003DzezTples_003D);
		num6 *= _0023_003DzezTples_003D;
		double num10 = 0.25;
		int num11 = 2;
		int num12 = num - 5;
		double num17;
		do
		{
			double num13 = num8;
			double num14 = num7;
			num5 = num3 * _0023_003DzAvn2b38_003D[num12 + 1];
			double num15 = 0.0;
			num8 = _0023_003DzAvn2b38_003D[0] * _0023_003DzAvn2b38_003D[num12];
			for (int i = 1; i <= num11; i++)
			{
				num5 += num15;
				num15 += num4 * (num3 - num5);
				double num16 = _0023_003DzhidJeNw_003D(_0023_003DzjbqS1qE_003D + num5, _0023_003DzyIxzFss_003D) + _0023_003DzhidJeNw_003D(_0023_003Dz1v6oPQk_003D - num5, _0023_003DzyIxzFss_003D);
				num7 += num16;
				num8 += _0023_003DzAvn2b38_003D[i] * _0023_003DzAvn2b38_003D[num12 - i] + num16 * _0023_003DzAvn2b38_003D[num12 - i - num11];
				_0023_003DzAvn2b38_003D[i + num11] = num16;
			}
			num4 = 2.0 * _0023_003DzAvn2b38_003D[num12 + 1];
			_0023_003DzEZdZXKE_003D = num2 * (double)num11 * Math.Abs(num8 - num13);
			num10 *= 0.25;
			num17 = num10 * Math.Abs(num7 - 2.0 * num14);
			num11 *= 2;
			num12 -= num11 + 2;
		}
		while ((_0023_003DzEZdZXKE_003D > num9 || num17 > num6) && num12 > 4 * num11);
		num8 *= _0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D;
		if (_0023_003DzEZdZXKE_003D > num9 || num17 > num6)
		{
			_0023_003DzEZdZXKE_003D *= 0.0 - Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D);
		}
		else
		{
			_0023_003DzEZdZXKE_003D = num6 * Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D);
		}
		return num8;
	}

	public Curve[] GetBezierSegments()
	{
		if (_0023_003DziGmJqeQcL0Lt == null)
		{
			_0023_003DziGmJqeQcL0Lt = Decompose();
		}
		return _0023_003DziGmJqeQcL0Lt;
	}

	internal bool _0023_003DzCAkKPyqtNt3E(Point3D _0023_003Dzl3DhHgI_003D, ref double _0023_003Dz_eY3Y4c_003D, bool _0023_003Dz0ZT3gEddQ5QD, out Vector3D _0023_003DzRpXgovo_003D, out Vector3D _0023_003DzZtNE5qE_003D)
	{
		double low = Domain.Low;
		double high = Domain.High;
		int num = 0;
		do
		{
			Vector3D[] array = Evaluate(_0023_003Dz_eY3Y4c_003D, 2);
			Vector3D vector3D = array[0];
			_0023_003DzZtNE5qE_003D = array[1];
			Vector3D vector3D2 = array[2];
			_0023_003DzRpXgovo_003D = new Vector3D(_0023_003Dzl3DhHgI_003D, vector3D.AsPoint);
			double num2 = _0023_003DzZtNE5qE_003D * _0023_003DzRpXgovo_003D;
			double num3 = vector3D2 * _0023_003DzRpXgovo_003D + _0023_003DzZtNE5qE_003D * _0023_003DzZtNE5qE_003D;
			double num4 = _0023_003Dz_eY3Y4c_003D - num2 / num3;
			if (_0023_003DzbErHvVw_003D)
			{
				if (num4 < low)
				{
					num4 = high - (low - num4);
				}
				else if (num4 > high)
				{
					num4 = low + (num4 - high);
				}
			}
			else if (!_0023_003Dz0ZT3gEddQ5QD)
			{
				if (num4 < low)
				{
					num4 = low;
				}
				else if (num4 > high)
				{
					num4 = high;
				}
			}
			if (_0023_003Dz_eY3Y4c_003D == num4)
			{
				break;
			}
			_0023_003Dz_eY3Y4c_003D = num4;
		}
		while (num++ < 8);
		if (double.IsNaN(_0023_003Dz_eY3Y4c_003D))
		{
			return false;
		}
		Point3D p = PointAt(_0023_003Dz_eY3Y4c_003D);
		_0023_003DzRpXgovo_003D = new Vector3D(_0023_003Dzl3DhHgI_003D, p);
		return true;
	}

	private bool _0023_003DzhM2gxPHDylsG(double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, Vector3D _0023_003DzEhNz45XYBLWZ, Vector3D _0023_003DzZtNE5qE_003D)
	{
		if (_0023_003DzEhNz45XYBLWZ.Length < _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D)
		{
			return true;
		}
		_0023_003DzEhNz45XYBLWZ.Normalize();
		if (_0023_003DzZtNE5qE_003D.Normalize() && Math.Abs(_0023_003DzZtNE5qE_003D * _0023_003DzEhNz45XYBLWZ) < 1E-05)
		{
			return true;
		}
		return false;
	}

	public void ClosestPointTo(Point3D point, out double t)
	{
		t = Domain.Low;
		double num = ControlBoundingBox().Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		if (_discontinuities == null)
		{
			_discontinuities = SplitAtDiscontinuities(speedChange: false);
		}
		List<double> list = new List<double>();
		Curve[] discontinuities = _discontinuities;
		foreach (Curve curve in discontinuities)
		{
			curve._0023_003DzKWdaQi8_003D(point, num, _0023_003Dz0ZT3gEddQ5QD: false, _0023_003Dz9CpiaFH50TBX: false, out t);
			double num2 = Point3D.DistanceSquared(point, PointAt(t));
			double num3 = Point3D.DistanceSquared(point, curve.EndPoint);
			if (num3 < num2)
			{
				if (Point3D.DistanceSquared(point, curve.StartPoint) <= num3)
				{
					list.Add(curve.Domain.Low);
				}
				else
				{
					list.Add(curve.Domain.High);
				}
			}
			else if (Point3D.DistanceSquared(point, curve.StartPoint) <= num2)
			{
				list.Add(curve.Domain.Low);
			}
			else
			{
				list.Add(t);
			}
		}
		double num4 = double.MaxValue;
		foreach (double item in list)
		{
			double num5 = Point3D.DistanceSquared(point, PointAt(item));
			if (num5 < num4)
			{
				num4 = num5;
				t = item;
			}
		}
	}

	public bool Project(Point3D point, out double t)
	{
		return _0023_003DzKWdaQi8_003D(point, _0023_003Dz0ZT3gEddQ5QD: true, out t);
	}

	internal bool _0023_003DzKWdaQi8_003D(Point3D _0023_003DzlY77YgY_003D, bool _0023_003Dz0ZT3gEddQ5QD, out double _0023_003DzNDQ_E88_003D)
	{
		double num = ControlBoundingBox().Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		return Project(_0023_003DzlY77YgY_003D, num, _0023_003Dz0ZT3gEddQ5QD, out _0023_003DzNDQ_E88_003D);
	}

	public bool Project(Point3D P, double coincTol, bool allowOutside, double prevU, out double u)
	{
		if (_0023_003DzCAkKPyqtNt3E(P, ref prevU, allowOutside, out var _0023_003DzRpXgovo_003D, out var _0023_003DzZtNE5qE_003D) && _0023_003DzhM2gxPHDylsG(coincTol, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D))
		{
			u = prevU;
			return true;
		}
		return Project(P, coincTol, allowOutside, out u);
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
		geometricalAttributesDirty = false;
		if (IsLine)
		{
			_0023_003DzbErHvVw_003D = false;
		}
		else
		{
			double num = ControlBoundingBox().Diagonal * Utility._0023_003DzheSR8QM7q9ya;
			_0023_003DzbErHvVw_003D = true;
			if (Point3D.Distance(Pw[0].Euclid, Pw[_0023_003DzMv2C5Tm1QMvc() - 1].Euclid) > num)
			{
				_0023_003DzbErHvVw_003D = false;
			}
			if (_0023_003DzbErHvVw_003D)
			{
				seam = new Point(Pw[0].Euclid);
			}
		}
		_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = false;
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			if (Math.Abs(Pw[i].W - 1.0) > Utility._0023_003DzheSR8QM7q9ya)
			{
				_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = true;
				break;
			}
		}
	}

	public virtual bool Project(Point3D P, double coincTol, bool allowOutside, out double u)
	{
		return _0023_003DzKWdaQi8_003D(P, coincTol, allowOutside, _0023_003Dz9CpiaFH50TBX: true, out u);
	}

	internal bool _0023_003DzKWdaQi8_003D(Point3D _0023_003Dzl3DhHgI_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, bool _0023_003Dz0ZT3gEddQ5QD, bool _0023_003Dz9CpiaFH50TBX, out double _0023_003Dz_eY3Y4c_003D)
	{
		if (_0023_003Dz1c2CfcL6J3Hu == (_0023_003DzKmXuOEFfAuxU)0)
		{
			_0023_003Dzg9a_0024NCpFCNWQ();
		}
		_0023_003Dz_eY3Y4c_003D = Domain.Low;
		Vector3D _0023_003DzRpXgovo_003D = null;
		Vector3D _0023_003DzZtNE5qE_003D = null;
		bool flag = false;
		switch (_0023_003Dz1c2CfcL6J3Hu)
		{
		case (_0023_003DzKmXuOEFfAuxU)1:
			_0023_003Dz_eY3Y4c_003D = Domain.Low + Domain.Length / 2.0;
			if (_0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out _0023_003DzRpXgovo_003D, out _0023_003DzZtNE5qE_003D) && _0023_003Dz9CpiaFH50TBX)
			{
				flag = _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D);
				if (!flag && _0023_003Dz0ZT3gEddQ5QD)
				{
					_0023_003Dz_eY3Y4c_003D = Domain.Low + Domain.Length / 2.0;
					_0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: true, out _0023_003DzRpXgovo_003D, out _0023_003DzZtNE5qE_003D);
					flag = _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D);
				}
			}
			break;
		case (_0023_003DzKmXuOEFfAuxU)2:
		case (_0023_003DzKmXuOEFfAuxU)3:
		{
			if (_0023_003DziGmJqeQcL0Lt == null)
			{
				_0023_003DziGmJqeQcL0Lt = Decompose();
			}
			double num = double.MaxValue;
			double num2 = 0.0;
			int num3 = _0023_003DziGmJqeQcL0Lt.Length;
			Curve[] array = new Curve[num3];
			double[] array2 = new double[num3];
			for (int i = 0; i < num3; i++)
			{
				array[i] = _0023_003DziGmJqeQcL0Lt[i];
				array[i].ControlBoundingBox(out var min, out var max);
				array2[i] = Utility._0023_003DzQE8nI0jAYt2jnSOq09fppKo_003D(_0023_003Dzl3DhHgI_003D, min, max);
			}
			Array.Sort(array2, array);
			for (int j = 0; j < num3 && !(num < array2[j]); j++)
			{
				Curve curve = array[j];
				for (int k = 0; k < 5; k++)
				{
					_0023_003Dz_eY3Y4c_003D = curve.Domain.Low + (double)k * curve.Domain.Length / 4.0;
					if (!curve._0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzRpXgovo_003D2, out var _0023_003DzZtNE5qE_003D2))
					{
						continue;
					}
					double lengthSquared = _0023_003DzRpXgovo_003D2.LengthSquared;
					if (!(lengthSquared < num))
					{
						continue;
					}
					if (_0023_003Dz9CpiaFH50TBX)
					{
						if (_0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D2, _0023_003DzZtNE5qE_003D2))
						{
							num = lengthSquared;
							num2 = _0023_003Dz_eY3Y4c_003D;
							_0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D2;
							_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D2;
						}
					}
					else
					{
						num = lengthSquared;
						num2 = _0023_003Dz_eY3Y4c_003D;
						_0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D2;
						_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D2;
					}
				}
			}
			if (_0023_003DzRpXgovo_003D != null)
			{
				_0023_003Dz_eY3Y4c_003D = num2;
				if (_0023_003Dz9CpiaFH50TBX)
				{
					flag = _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D);
				}
			}
			if (!flag && _0023_003Dz0ZT3gEddQ5QD)
			{
				Curve curve2 = _0023_003DziGmJqeQcL0Lt[0];
				for (int l = 0; l < 5; l++)
				{
					_0023_003Dz_eY3Y4c_003D = curve2.Domain.Low + (double)l * curve2.Domain.Length / 4.0;
					if (curve2._0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: true, out var _0023_003DzRpXgovo_003D3, out var _0023_003DzZtNE5qE_003D3))
					{
						double num4 = _0023_003DzRpXgovo_003D3.LengthSquared;
						if (_0023_003Dz_eY3Y4c_003D > curve2.Domain.High)
						{
							num4 = double.MaxValue;
						}
						if (num4 < num && _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D3, _0023_003DzZtNE5qE_003D3))
						{
							num = num4;
							num2 = _0023_003Dz_eY3Y4c_003D;
							_0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D3;
							_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D3;
						}
					}
				}
				Curve curve3 = _0023_003DziGmJqeQcL0Lt[num3 - 1];
				for (int m = 0; m < 5; m++)
				{
					_0023_003Dz_eY3Y4c_003D = curve3.Domain.Low + (double)m * curve3.Domain.Length / 4.0;
					if (curve3._0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: true, out var _0023_003DzRpXgovo_003D4, out var _0023_003DzZtNE5qE_003D4))
					{
						double num5 = _0023_003DzRpXgovo_003D4.LengthSquared;
						if (_0023_003Dz_eY3Y4c_003D < curve3.Domain.Low)
						{
							num5 = double.MaxValue;
						}
						if (num5 < num && _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D4, _0023_003DzZtNE5qE_003D4))
						{
							num = num5;
							num2 = _0023_003Dz_eY3Y4c_003D;
							_0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D4;
							_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D4;
						}
					}
				}
			}
			if (_0023_003DzRpXgovo_003D != null)
			{
				_0023_003Dz_eY3Y4c_003D = num2;
				if (_0023_003Dz9CpiaFH50TBX)
				{
					flag = _0023_003DzhM2gxPHDylsG(_0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D);
				}
			}
			break;
		}
		}
		if (!flag && _0023_003Dz9CpiaFH50TBX)
		{
			_0023_003Dz_eY3Y4c_003D = Domain.Low;
		}
		return flag;
	}

	public Curve ProjectOn(Plane plane)
	{
		Curve curve = (Curve)Clone();
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			Point4D point4D = Pw[i];
			plane.Project(point4D.Euclid, out var s, out var t);
			Point3D point3D = plane.PointAt(s, t);
			double w = point4D.W;
			curve.Pw[i] = new Point4D(point3D.X * w, point3D.Y * w, point3D.Z * w, w);
		}
		return curve;
	}

	public Curve Drop(Plane curvePlane)
	{
		Curve curve = (Curve)Clone();
		for (int i = 0; i < _0023_003DzMv2C5Tm1QMvc(); i++)
		{
			Point4D point4D = Pw[i];
			curvePlane.Project(point4D.Euclid, out var s, out var t);
			double w = point4D.W;
			curve.Pw[i] = new Point4D(s * w, t * w, 0.0, w);
		}
		return curve;
	}

	internal bool _0023_003Dzq0jqnCQBLyxVkzA_Tg_003D_003D(Point3D _0023_003Dzl3DhHgI_003D, bool _0023_003Dz0ZT3gEddQ5QD, out double _0023_003Dz_eY3Y4c_003D)
	{
		double num = ControlBoundingBox().Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		if (_0023_003Dz1c2CfcL6J3Hu == (_0023_003DzKmXuOEFfAuxU)0)
		{
			_0023_003Dzg9a_0024NCpFCNWQ();
		}
		_0023_003Dz_eY3Y4c_003D = Domain.Low;
		Vector3D vector3D = null;
		Vector3D _0023_003DzZtNE5qE_003D = null;
		bool flag = false;
		double num2 = double.MaxValue;
		switch (_0023_003Dz1c2CfcL6J3Hu)
		{
		case (_0023_003DzKmXuOEFfAuxU)1:
			Project(_0023_003Dzl3DhHgI_003D, num, _0023_003Dz0ZT3gEddQ5QD, out _0023_003Dz_eY3Y4c_003D);
			break;
		case (_0023_003DzKmXuOEFfAuxU)2:
		case (_0023_003DzKmXuOEFfAuxU)3:
		{
			if (_0023_003DziGmJqeQcL0Lt == null)
			{
				_0023_003DziGmJqeQcL0Lt = Decompose();
			}
			num2 = double.MaxValue;
			double num3 = 0.0;
			int num4 = _0023_003DziGmJqeQcL0Lt.Length;
			for (int i = 0; i < num4; i++)
			{
				Curve curve = _0023_003DziGmJqeQcL0Lt[i];
				bool flag2 = i == 0 || i == num4 - 1;
				for (int j = 0; j < 5; j++)
				{
					_0023_003Dz_eY3Y4c_003D = curve.Domain.Low + (double)j * curve.Domain.Length / 4.0;
					double num5 = double.MaxValue;
					if (!curve._0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: false, out var _0023_003DzRpXgovo_003D, out var _0023_003DzZtNE5qE_003D2))
					{
						continue;
					}
					num5 = _0023_003DzRpXgovo_003D.LengthSquared;
					if (num5 < num2 && _0023_003DzhM2gxPHDylsG(num, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D2))
					{
						num2 = num5;
						num3 = _0023_003Dz_eY3Y4c_003D;
						vector3D = _0023_003DzRpXgovo_003D;
						_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D2;
					}
					if (_0023_003Dz0ZT3gEddQ5QD && flag2 && curve._0023_003DzCAkKPyqtNt3E(_0023_003Dzl3DhHgI_003D, ref _0023_003Dz_eY3Y4c_003D, _0023_003Dz0ZT3gEddQ5QD: true, out _0023_003DzRpXgovo_003D, out _0023_003DzZtNE5qE_003D2))
					{
						num5 = _0023_003DzRpXgovo_003D.LengthSquared;
						if (num5 < num2 && _0023_003DzhM2gxPHDylsG(num, _0023_003DzRpXgovo_003D, _0023_003DzZtNE5qE_003D2))
						{
							num2 = num5;
							num3 = _0023_003Dz_eY3Y4c_003D;
							vector3D = _0023_003DzRpXgovo_003D;
							_0023_003DzZtNE5qE_003D = _0023_003DzZtNE5qE_003D2;
						}
					}
				}
			}
			if (vector3D != null)
			{
				_0023_003Dz_eY3Y4c_003D = num3;
				flag = _0023_003DzhM2gxPHDylsG(num, vector3D, _0023_003DzZtNE5qE_003D);
			}
			break;
		}
		}
		if (!flag)
		{
			_0023_003Dz_eY3Y4c_003D = Domain.Low;
		}
		return flag;
	}

	private Stack<PointU> _0023_003DzPRtz8vk_003D(int _0023_003DzNwvwyPc_003D)
	{
		int num = _0023_003DziP9fFuA_003D.Length;
		Stack<PointU> stack = new Stack<PointU>();
		Point3D point3D;
		for (int i = 0; i < num - 1; i++)
		{
			double num2 = _0023_003DziP9fFuA_003D[i];
			double num3 = _0023_003DziP9fFuA_003D[i + 1];
			if (num2 != num3)
			{
				for (int j = 0; j < _0023_003DzNwvwyPc_003D; j++)
				{
					double u = num2 + (double)j * (num3 - num2) / (double)_0023_003DzNwvwyPc_003D;
					point3D = Evaluate(u);
					stack.Push(new PointU(point3D.X, point3D.Y, point3D.Z, u));
				}
			}
		}
		point3D = Evaluate(Domain.High);
		stack.Push(new PointU(point3D.X, point3D.Y, point3D.Z, Domain.High));
		return stack;
	}

	private void _0023_003Dzg9a_0024NCpFCNWQ()
	{
		if (IsLine)
		{
			_0023_003Dz1c2CfcL6J3Hu = (_0023_003DzKmXuOEFfAuxU)1;
		}
		else if (_0023_003DzB68dg9Q_003D != 1 && !_0023_003Dz977XuKK3I_0024G4sodTXA_003D_003D())
		{
			_0023_003Dz1c2CfcL6J3Hu = (_0023_003DzKmXuOEFfAuxU)2;
		}
		else
		{
			_0023_003Dz1c2CfcL6J3Hu = (_0023_003DzKmXuOEFfAuxU)3;
		}
	}

	private bool _0023_003Dz977XuKK3I_0024G4sodTXA_003D_003D()
	{
		_0023_003DzBy2vXGf5_0024GmU(2, out var _0023_003Dzmq9AN6TJfglp);
		return _0023_003Dzmq9AN6TJfglp > 2.0;
	}

	private void _0023_003DzBy2vXGf5_0024GmU(int _0023_003DzNwvwyPc_003D, out double _0023_003Dzmq9AN6TJfglp)
	{
		int num = _0023_003DziP9fFuA_003D.Length;
		double _0023_003DzF7v9r2A_003D = double.MaxValue;
		double _0023_003Dz8dK2uhU_003D = double.MinValue;
		for (int i = 0; i < num - 1; i++)
		{
			double num2 = _0023_003DziP9fFuA_003D[i];
			double num3 = _0023_003DziP9fFuA_003D[i + 1];
			if (num2 != num3)
			{
				for (int j = 0; j < _0023_003DzNwvwyPc_003D; j++)
				{
					double _0023_003Dz_eY3Y4c_003D = num2 + (double)j * (num3 - num2) / (double)_0023_003DzNwvwyPc_003D;
					_0023_003DzNKw2dpKrk09r(_0023_003Dz_eY3Y4c_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
				}
			}
		}
		_0023_003DzNKw2dpKrk09r(Domain.High, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
		_0023_003Dzmq9AN6TJfglp = _0023_003Dz8dK2uhU_003D / _0023_003DzF7v9r2A_003D;
	}

	private void _0023_003DzNKw2dpKrk09r(double _0023_003Dz_eY3Y4c_003D, ref double _0023_003DzF7v9r2A_003D, ref double _0023_003Dz8dK2uhU_003D)
	{
		double length = Evaluate(_0023_003Dz_eY3Y4c_003D, 1)[1].Length;
		if (length < _0023_003DzF7v9r2A_003D)
		{
			_0023_003DzF7v9r2A_003D = length;
		}
		if (length > _0023_003Dz8dK2uhU_003D)
		{
			_0023_003Dz8dK2uhU_003D = length;
		}
	}

	public static Curve Drop(Plane pln, ICurve curve)
	{
		Curve nurbsForm = curve.GetNurbsForm();
		Curve curve2 = new Curve
		{
			_0023_003DzB68dg9Q_003D = nurbsForm._0023_003DzB68dg9Q_003D,
			_0023_003DziP9fFuA_003D = nurbsForm._0023_003DziP9fFuA_003D,
			Pw = new Point4D[nurbsForm.Pw.Length]
		};
		for (int i = 0; i < nurbsForm.Pw.Length; i++)
		{
			Point4D point4D = nurbsForm.Pw[i];
			Point3D euclid = point4D.Euclid;
			pln.Project(euclid, out var s, out var t);
			curve2.Pw[i] = new Point4D(s * point4D.W, t * point4D.W, 0.0, point4D.W);
		}
		curve2._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		return curve2;
	}

	internal int _0023_003DzMv2C5Tm1QMvc()
	{
		return Pw.Length;
	}

	internal int _0023_003DzFNjygTLTZtF3()
	{
		return Pw.Length - 1;
	}

	private double _0023_003Dzm7hk_bhOAzGdKdeJyw_003D_003D(Point3D _0023_003DzB68dg9Q_003D)
	{
		int num = Pw.Length - 1;
		double num2 = Pw[num].Euclid.DistanceTo(_0023_003DzB68dg9Q_003D);
		int num3 = _0023_003DziP9fFuA_003D.Length;
		double num4 = _0023_003DziP9fFuA_003D[num3 - 1] + num2 / ControlLength();
		for (int i = num3 - Order + 1; i < num3; i++)
		{
			_0023_003DziP9fFuA_003D[i] = num4;
		}
		return num4;
	}

	public bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		if (curveEnd)
		{
			_0023_003DzZgzRhc8MBjXS(pt);
		}
		else
		{
			Reverse();
			_0023_003DzZgzRhc8MBjXS(pt);
			Reverse();
		}
		RegenMode = regenType.RegenAndCompile;
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		return true;
	}

	internal void _0023_003DzZgzRhc8MBjXS(Point3D _0023_003DzMlCq3wk_003D)
	{
		double num = _0023_003Dzm7hk_bhOAzGdKdeJyw_003D_003D(_0023_003DzMlCq3wk_003D);
		_0023_003DzUF6xqDUS98KDfZkh4w_003D_003D(_0023_003DzMlCq3wk_003D);
		Array.Resize(ref _0023_003DziP9fFuA_003D, _0023_003DziP9fFuA_003D.Length + 1);
		_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1] = num;
	}

	private double _0023_003Dzm7hk_bhOAzGdKdeJyw_003D_003D(double _0023_003DzNDQ_E88_003D)
	{
		int num = _0023_003DziP9fFuA_003D.Length;
		for (int i = num - Order + 1; i < num; i++)
		{
			_0023_003DziP9fFuA_003D[i] = _0023_003DzNDQ_E88_003D;
		}
		return _0023_003DzNDQ_E88_003D;
	}

	private void _0023_003DzUF6xqDUS98KDfZkh4w_003D_003D(Point3D _0023_003DzlY77YgY_003D)
	{
		int num = Pw.Length - 1;
		for (int i = 0; i <= _0023_003DzB68dg9Q_003D - 2; i++)
		{
			for (int num2 = i; num2 >= 0; num2--)
			{
				double num3 = (_0023_003DziP9fFuA_003D[num + 1] - _0023_003DziP9fFuA_003D[num - num2]) / (_0023_003DziP9fFuA_003D[num - num2 + i + 2] - _0023_003DziP9fFuA_003D[num - num2]);
				Pw[num - num2] = (Pw[num - num2] - (1.0 - num3) * Pw[num - num2 - 1]) / num3;
			}
		}
		Array.Resize(ref Pw, Pw.Length + 1);
		double w = ((_0023_003DzlY77YgY_003D is Point4D point4D) ? point4D.W : 1.0);
		Pw[Pw.Length - 1] = new Point4D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003DzlY77YgY_003D.Z, w);
	}

	public bool ExtendAt(double t)
	{
		if (t > Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length) && t < Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			return false;
		}
		Point3D _0023_003DzLMo0v2w_003D = PointAt(t);
		if (t > Domain.High)
		{
			_0023_003Dzd_juMJZRb8zm(t, _0023_003DzLMo0v2w_003D);
		}
		else if (t < Domain.Low)
		{
			Reverse();
			_0023_003Dzd_juMJZRb8zm(0.0 - t, _0023_003DzLMo0v2w_003D);
			Reverse();
		}
		RegenMode = regenType.RegenAndCompile;
		_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		return true;
	}

	internal void _0023_003Dzd_juMJZRb8zm(double _0023_003DzNDQ_E88_003D, Point3D _0023_003DzLMo0v2w_003D)
	{
		_0023_003Dzm7hk_bhOAzGdKdeJyw_003D_003D(_0023_003DzNDQ_E88_003D);
		_0023_003DzUF6xqDUS98KDfZkh4w_003D_003D(_0023_003DzLMo0v2w_003D);
		Array.Resize(ref _0023_003DziP9fFuA_003D, _0023_003DziP9fFuA_003D.Length + 1);
		_0023_003DziP9fFuA_003D[_0023_003DziP9fFuA_003D.Length - 1] = _0023_003DzNDQ_E88_003D;
	}

	public bool TrimBy(Point3D limit, bool flipSide)
	{
		ClosestPointTo(limit, out var t);
		bool num = TrimAt(t, flipSide);
		if (num)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return num;
	}

	public bool TrimAt(double u, bool flipSide)
	{
		if (SplitAt(u, out var lower, out var upper))
		{
			if (flipSide)
			{
				Pw = ((Curve)upper).Pw;
				_0023_003DziP9fFuA_003D = ((Curve)upper)._0023_003DziP9fFuA_003D;
				_0023_003DzB68dg9Q_003D = ((Curve)upper)._0023_003DzB68dg9Q_003D;
				RegenMode = regenType.RegenAndCompile;
				_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
				return true;
			}
			Pw = ((Curve)lower).Pw;
			_0023_003DziP9fFuA_003D = ((Curve)lower)._0023_003DziP9fFuA_003D;
			_0023_003DzB68dg9Q_003D = ((Curve)lower)._0023_003DzB68dg9Q_003D;
			RegenMode = regenType.RegenAndCompile;
			_0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool GetParamFromLength(double length, out double t)
	{
		double curveLength = Length();
		return GetParamFromLength(length, curveLength, out t);
	}

	public bool GetParamFromLength(double length, double curveLength, out double t)
	{
		double low = Domain.Low;
		double high = Domain.High;
		double length2 = Domain.Length;
		if (Utility.AreEqual(length, 0.0, curveLength))
		{
			t = low;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = high;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = low;
			return false;
		}
		t = low + length2 / 2.0;
		if (_0023_003DzcUx5Y7fq28Sc(length, curveLength, ref t))
		{
			return true;
		}
		t = low + length2 / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(length, curveLength, ref t))
		{
			return true;
		}
		t = low + length2 * 3.0 / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(length, curveLength, ref t))
		{
			return true;
		}
		t = low + length2 / 8.0;
		if (_0023_003DzcUx5Y7fq28Sc(length, curveLength, ref t))
		{
			return true;
		}
		t = low + length2 * 7.0 / 8.0;
		if (_0023_003DzcUx5Y7fq28Sc(length, curveLength, ref t))
		{
			return true;
		}
		double _0023_003Dz_eY3Y4c_003D = low + length;
		if (_0023_003Dz_eY3Y4c_003D < high && _0023_003DzcUx5Y7fq28Sc(length, curveLength, ref _0023_003Dz_eY3Y4c_003D))
		{
			t = _0023_003Dz_eY3Y4c_003D;
			return true;
		}
		Curve curve = _0023_003Dz9LD5KXcQZf1qkCSvpOqzmhfp5fP3();
		if (curve._0023_003DzE4qAu7M72lYZ7N4Rny6_002459WDhTRDQTOkvmg_Mow_003D(length, out var _0023_003DzNDQ_E88_003D))
		{
			Point3D point = curve.PointAt(_0023_003DzNDQ_E88_003D);
			ClosestPointTo(point, out t);
			return true;
		}
		return false;
	}

	public bool GetParamsFromLength(double[] lengths, out double[] ts)
	{
		ts = new double[lengths.Length];
		bool result = true;
		double num = Length();
		double low = Domain.Low;
		double high = Domain.High;
		double length = Domain.Length;
		for (int i = 0; i < lengths.Length; i++)
		{
			double num2 = lengths[i];
			if (Utility.AreEqual(num2, 0.0, num))
			{
				ts[i] = low;
				continue;
			}
			if (Utility.AreEqual(num2, num, num))
			{
				ts[i] = high;
				continue;
			}
			if (num2 < 0.0 || num2 > num)
			{
				ts[i] = low;
				continue;
			}
			if (i != 0)
			{
				ts[i] = ts[i - 1];
				if (_0023_003DzcUx5Y7fq28Sc(num2, num, ref ts[i]))
				{
					continue;
				}
			}
			ts[i] = low + length / 2.0;
			if (_0023_003DzcUx5Y7fq28Sc(num2, num, ref ts[i]))
			{
				continue;
			}
			ts[i] = low + length / 4.0;
			if (_0023_003DzcUx5Y7fq28Sc(num2, num, ref ts[i]))
			{
				continue;
			}
			ts[i] = low + length * 3.0 / 4.0;
			if (_0023_003DzcUx5Y7fq28Sc(num2, num, ref ts[i]))
			{
				continue;
			}
			double _0023_003Dz_eY3Y4c_003D = low + num2;
			if (_0023_003Dz_eY3Y4c_003D < high && _0023_003DzcUx5Y7fq28Sc(num2, num, ref _0023_003Dz_eY3Y4c_003D))
			{
				ts[i] = _0023_003Dz_eY3Y4c_003D;
				continue;
			}
			Curve curve = _0023_003Dz9LD5KXcQZf1qkCSvpOqzmhfp5fP3();
			if (curve._0023_003DzE4qAu7M72lYZ7N4Rny6_002459WDhTRDQTOkvmg_Mow_003D(num2, out var _0023_003DzNDQ_E88_003D))
			{
				Point3D point = curve.PointAt(_0023_003DzNDQ_E88_003D);
				ClosestPointTo(point, out ts[i]);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		if (Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			length = 0.0;
			return true;
		}
		if (Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			length = Length();
			return true;
		}
		if (t < Domain.Low || t > Domain.High)
		{
			length = 0.0;
			return false;
		}
		if (SplitAt(t, out var lower, out var _))
		{
			length = lower.Length();
			return true;
		}
		length = 0.0;
		return false;
	}

	private bool _0023_003DzcUx5Y7fq28Sc(double _0023_003Dz736ekIs_003D, double _0023_003Dz7BpDAQWBUk7E, ref double _0023_003Dz_eY3Y4c_003D)
	{
		double low = Domain.Low;
		double high = Domain.High;
		int num = 0;
		do
		{
			Vector3D vector3D = Evaluate(_0023_003Dz_eY3Y4c_003D, 1)[1];
			double num2 = 0.0;
			if (!Utility.AreEqual(low, _0023_003Dz_eY3Y4c_003D, Domain.Length))
			{
				if (!SubCurve(low, _0023_003Dz_eY3Y4c_003D, out var sub))
				{
					return false;
				}
				if (sub != null)
				{
					num2 = sub.Length();
				}
			}
			double num3 = num2 - _0023_003Dz736ekIs_003D;
			if (Utility.AreEqual(0.0, num3, 1.0))
			{
				return true;
			}
			double length = vector3D.Length;
			double num4 = _0023_003Dz_eY3Y4c_003D - num3 / length;
			if (_0023_003DzbErHvVw_003D)
			{
				if (num4 < low)
				{
					num4 = high - (low - num4);
				}
				else if (num4 > high)
				{
					num4 = low + (num4 - high);
				}
			}
			else if (num4 < low)
			{
				num4 = low;
			}
			else if (num4 > high)
			{
				num4 = high;
			}
			if (_0023_003Dz_eY3Y4c_003D == num4)
			{
				break;
			}
			_0023_003Dz_eY3Y4c_003D = num4;
		}
		while (num++ < 10);
		if (double.IsNaN(_0023_003Dz_eY3Y4c_003D))
		{
			_0023_003Dz_eY3Y4c_003D = 0.0;
		}
		if (SubCurve(low, _0023_003Dz_eY3Y4c_003D, out var sub2) && Utility.AreEqual(sub2.Length() - _0023_003Dz736ekIs_003D, 0.0, _0023_003Dz7BpDAQWBUk7E * 1000.0))
		{
			return true;
		}
		return false;
	}

	private Curve _0023_003Dz9LD5KXcQZf1qkCSvpOqzmhfp5fP3()
	{
		Curve[] array = Decompose();
		foreach (Curve curve in array)
		{
			double num = curve.Length();
			curve.KnotVector.Offset(0.0 - curve.Domain.Low);
			curve.KnotVector.Scale(num / curve.Domain.High);
		}
		return Merge(array);
	}

	internal bool _0023_003DzE4qAu7M72lYZ7N4Rny6_002459WDhTRDQTOkvmg_Mow_003D(double _0023_003Dz736ekIs_003D, out double _0023_003DzNDQ_E88_003D)
	{
		double _0023_003Dz7BpDAQWBUk7E = Length();
		double low = Domain.Low;
		double high = Domain.High;
		double length = Domain.Length;
		_0023_003DzNDQ_E88_003D = low + _0023_003Dz736ekIs_003D;
		if (_0023_003DzNDQ_E88_003D < high && _0023_003DzcUx5Y7fq28Sc(_0023_003Dz736ekIs_003D, _0023_003Dz7BpDAQWBUk7E, ref _0023_003DzNDQ_E88_003D))
		{
			return true;
		}
		_0023_003DzNDQ_E88_003D = low + length / 2.0;
		if (_0023_003DzcUx5Y7fq28Sc(_0023_003Dz736ekIs_003D, _0023_003Dz7BpDAQWBUk7E, ref _0023_003DzNDQ_E88_003D))
		{
			return true;
		}
		_0023_003DzNDQ_E88_003D = low + length / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(_0023_003Dz736ekIs_003D, _0023_003Dz7BpDAQWBUk7E, ref _0023_003DzNDQ_E88_003D))
		{
			return true;
		}
		_0023_003DzNDQ_E88_003D = low + length * 3.0 / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(_0023_003Dz736ekIs_003D, _0023_003Dz7BpDAQWBUk7E, ref _0023_003DzNDQ_E88_003D))
		{
			return true;
		}
		return false;
	}

	public bool TrimBy(Plane pln, double tol, bool flipSide)
	{
		ControlBoundingBox(out var min, out var max);
		Surface _0023_003DzF7GfYSI_003D = Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(pln, min, max);
		Point3D[] array = new _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D()._0023_003DzQ7usAag_003D(this, _0023_003DzF7GfYSI_003D, pln, new Size3D(min, max).Diagonal);
		if (array.Length != 0)
		{
			InterPoint interPoint = (InterPoint)array[0];
			TrimAt(interPoint.u, flipSide);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public Point3D[] IntersectWith(Plane pln, double tol)
	{
		ControlBoundingBox(out var min, out var max);
		Surface _0023_003DzF7GfYSI_003D = Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(pln, min, max);
		return new _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D()._0023_003DzQ7usAag_003D(this, _0023_003DzF7GfYSI_003D, pln, new Size3D(min, max).Diagonal);
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		ClosestPointTo(pt, out var t);
		if (SplitAt(t, out lower, out upper))
		{
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(IList<Point3D> points, out ICurve[] segments)
	{
		bool result = Utility._0023_003Dz01EVtoUdEn9B(this, points, out segments);
		ICurve[] array = segments;
		for (int i = 0; i < array.Length; i++)
		{
			((Entity)array[i]).CopyAttributes(this);
		}
		return result;
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawCurvature == null)
		{
			drawCurvature = renderContext.CreateEntityGraphicsData(this);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003DzmbgnoPnzjNU7(data);
		if (_0023_003DzvRue7ps_003D)
		{
			_0023_003DzzpUV1ZQ_003D(data);
		}
	}

	private void _0023_003DzmbgnoPnzjNU7(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawWire(_0023_003DzELu0Pss_003D);
		if (_showCurvature && _hairScaleFactor != 0f)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawCurvature);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		_0023_003DzmbgnoPnzjNU7(data);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		base.Compiling = true;
		CompileWire(data);
		drawCurvature.Dispose();
		if (_hairScaleFactor != 0f)
		{
			data.RenderContext.Compile(drawCurvature, DrawCurvature, data);
		}
		base.Compiling = false;
		RegenMode = regenType.NotNeeded;
	}

	protected void DrawCurvature(RenderContextBase renderContext, object myParams)
	{
		Point3D[] array = new Point3D[_vertices.Length * 2];
		int num = 0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			PointTangentU pointTangentU = (PointTangentU)_vertices[i];
			array[num++] = pointTangentU;
			array[num++] = pointTangentU + NormalAt(pointTangentU.U) * pointTangentU.plotValue * _hairScaleFactor;
		}
		renderContext.DrawLines(array);
	}

	private void _0023_003DzheC2jz5Zq8f_0024(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzB8iS0QA_003D.DrawLineStrip(_vertices);
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		Utility.DrawArrowOnView(data, EndTangent, EndPoint);
	}

	internal override void _0023_003DzfbUXMcWg3bvT(RenderContextBase _0023_003DzQdnFby4_003D)
	{
		Point3D[] array = new Point3D[ControlPoints.Length];
		for (int i = 0; i < ControlPoints.Length; i++)
		{
			array[i] = ControlPoints[i].Euclid;
		}
		_0023_003DzQdnFby4_003D.DrawLineStrip(array);
	}

	internal override void _0023_003Dzp7j_tCs_FYVt(RenderContextBase _0023_003DzQdnFby4_003D)
	{
		_0023_003DzQdnFby4_003D.PushShader();
		_0023_003DzQdnFby4_003D.SetShader(shaderType.NoLightsThickPoints);
		_0023_003DzQdnFby4_003D.SetPointSize(4f, setShader: false);
		Point3D[] array = new Point3D[ControlPoints.Length];
		for (int i = 0; i < ControlPoints.Length; i++)
		{
			array[i] = ControlPoints[i].Euclid;
		}
		_0023_003DzQdnFby4_003D.DrawPoints(array);
		_0023_003DzQdnFby4_003D.PopShader();
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	public void ComputeCurvatureGraph(IWorkspace workspace, float scaleFactor)
	{
		if (scaleFactor == 0f)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965532), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965746));
		}
		_hairScaleFactor = scaleFactor;
		if (Vertices == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965755));
		}
		for (int i = 0; i < Vertices.Length; i++)
		{
			PointTangentU pointTangentU = (PointTangentU)Vertices[i];
			pointTangentU.plotValue = (float)Curvature(pointTangentU.U);
		}
		Compile(new CompileParams(workspace));
	}

	public override void Dispose()
	{
		base.Dispose();
		drawCurvature?.Dispose();
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		if (this is TrimCurve trimCurve)
		{
			return ((Entity)trimCurve.Edge)._0023_003DzuAMveDQA6vvk();
		}
		Plane plane;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003Dz9lwBHA7NoLh_0024_1EVuspU6hmh4G7BX3ZcrScNn8k_003D(Degree, KnotVector, ControlPoints, 0, IsPlanar(1E-06, out plane), IsClosed, Convert.ToInt32(IsRational), _0023_003DzzBglnhwdR3VArgpYbQ_003D_003D: false, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 };
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2;
		if (IsRational)
		{
			List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> list = new List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>();
			for (int i = 0; i < ControlPoints.Length; i++)
			{
				Point4D point4D = ControlPoints[i];
				list.Add(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(point4D.X / point4D.W, point4D.Y / point4D.W, point4D.Z / point4D.W, point4D.W));
			}
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = new _0023_003DzlTuiosIOWNUlDu2Nkw_003D_003D(Degree, new List<double>(KnotVector), list);
		}
		else
		{
			List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> list2 = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
			for (int j = 0; j < ControlPoints.Length; j++)
			{
				Point4D point4D2 = ControlPoints[j];
				list2.Add(new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(new double[4]
				{
					point4D2.X / point4D2.W,
					point4D2.Y / point4D2.W,
					point4D2.Z / point4D2.W,
					point4D2.W
				}));
			}
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = new _0023_003DzftHpHlHtau7xOtLO93_0024IggA_003D(Degree, new List<double>(KnotVector), list2);
		}
		_0023_003DzYe_6EnQecc8d(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 };
	}
}
