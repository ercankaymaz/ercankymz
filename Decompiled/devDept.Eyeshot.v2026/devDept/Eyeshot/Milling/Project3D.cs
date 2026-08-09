using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Project3D : Machining3D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Tuple<Point3D[], Point3D[]>[], IEnumerable<Tuple<Point3D[], Point3D[]>>> _0023_003DzJlv1wPLmULy96VL17A_003D_003D;

		public static Func<Tuple<Point3D[], Point3D[]>[], IEnumerable<Tuple<Point3D[], Point3D[]>>> _0023_003DzL00DvdMUt6LebWRr0A_003D_003D;

		public static Func<Tuple<Point3D[], Point3D[]>[], IEnumerable<Tuple<Point3D[], Point3D[]>>> _0023_003Dz9psv4fOfrMf_WAYtLg_003D_003D;

		public static Func<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[], IEnumerable<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		public static Func<Dictionary<int, Point3D[][]>> _0023_003Dzt_0024Tb3v15OQhHkGmfXQ_003D_003D;

		internal IEnumerable<Tuple<Point3D[], Point3D[]>> _0023_003DzH_00247918Z8K21kNLuYXriWjm0_003D(Tuple<Point3D[], Point3D[]>[] _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D;
		}

		internal IEnumerable<Tuple<Point3D[], Point3D[]>> _0023_003Dzr4xCDB0xZSzo8HSY2rOjKKI_003D(Tuple<Point3D[], Point3D[]>[] _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D;
		}

		internal IEnumerable<Tuple<Point3D[], Point3D[]>> _0023_003DzETAjO915pnjCj9krCglFxC0_003D(Tuple<Point3D[], Point3D[]>[] _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D;
		}

		internal IEnumerable<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D;
		}

		internal Dictionary<int, Point3D[][]> _0023_003DzdabsFFtE7qeEGlDy_0024_0024BZJMk_003D()
		{
			return new Dictionary<int, Point3D[][]>();
		}
	}

	private sealed class _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D
	{
		public Project3D _0023_003DzopRx0_MBcTQs;

		public _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzWngxRrg_003D;

		public _0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dz76Ya4vc_003D;

		public double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D;

		public List<IList<Line>> _0023_003DzPZOwdb1GfpHX;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public Point3D[][][] _0023_003DzyZlWguvcpRpK;

		internal Dictionary<int, Point3D[][]> _0023_003DzYXSeSIqoId0SwA0j1HVlAfE_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, Dictionary<int, Point3D[][]> _0023_003DzN5thJ4k_003D)
		{
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2 = new _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D();
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003Dz12p2jmUTCnCB(_0023_003DzopRx0_MBcTQs._0023_003Dz9cS3uG0_003D, (Geometry3D)_0023_003DzopRx0_MBcTQs.geometry, _0023_003DzWngxRrg_003D);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzMFlIwko_003D(_0023_003DzopRx0_MBcTQs.zRange.Low);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzePcMMDarrpwf(_0023_003Dz76Ya4vc_003D);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DztNBJE_4_003D(_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
			Stopwatch _0023_003DzjQHiWpw_003D = new Stopwatch();
			Point3D[][] array = new Point3D[0][];
			int num = 0;
			foreach (Line item in _0023_003DzPZOwdb1GfpHX[_0023_003Dz437_00244ak_003D])
			{
				_0023_003Dz3ORRwnUaVbd8 _0023_003Dz3ORRwnUaVbd9 = new _0023_003Dz3ORRwnUaVbd8();
				_0023_003Dz3ORRwnUaVbd9._0023_003DzGkfwiw0_003D(new _0023_003DzOQm_OJkhw_0024vS(new _0023_003DzmKBPh7nOT6nY(item.StartPoint.X, item.StartPoint.Y), new _0023_003DzmKBPh7nOT6nY(item.EndPoint.X, item.EndPoint.Y)));
				Point3D[][] array2 = _0023_003DzopRx0_MBcTQs._0023_003DzRwjCiYE_003D(_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2, _0023_003Dz3ORRwnUaVbd9, _0023_003DzjQHiWpw_003D);
				if (item.StartPoint is _0023_003Dz0wzeWOGJZnQF && item.EndPoint is _0023_003Dz0wzeWOGJZnQF)
				{
					_0023_003DzopRx0_MBcTQs._0023_003DzfeK9ScgXRl_0024_0024((_0023_003Dz0wzeWOGJZnQF)item.StartPoint, (_0023_003Dz0wzeWOGJZnQF)item.EndPoint, array2);
				}
				Array.Resize(ref array, num + array2.Length);
				Array.Copy(array2, 0, array, num, array2.Length);
				num = array.Length;
			}
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ComputingPassesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			_0023_003DzN5thJ4k_003D.Add(_0023_003Dz437_00244ak_003D, array);
			return _0023_003DzN5thJ4k_003D;
		}

		internal void _0023_003DzuMB0ujGJOPxWK0d_Ug_0024m3ZY_003D(Dictionary<int, Point3D[][]> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzyZlWguvcpRpK)
			{
				foreach (KeyValuePair<int, Point3D[][]> item in _0023_003DzBJFJHwk_003D)
				{
					_0023_003DzyZlWguvcpRpK[item.Key] = item.Value;
				}
			}
		}
	}

	private sealed class _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D
	{
		public Project3D _0023_003DzopRx0_MBcTQs;

		public _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzWngxRrg_003D;

		public _0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dz76Ya4vc_003D;

		public double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D;

		public Tuple<Point3D[], Point3D[]>[] _0023_003DzWFELMytNNPze;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		internal void _0023_003DzqmbQfPOBqnHwyrbtCg_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2 = new _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D();
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003Dz12p2jmUTCnCB(_0023_003DzopRx0_MBcTQs._0023_003Dz9cS3uG0_003D, (Geometry3D)_0023_003DzopRx0_MBcTQs.geometry, _0023_003DzWngxRrg_003D);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzMFlIwko_003D(_0023_003DzopRx0_MBcTQs.zRange.Low);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzePcMMDarrpwf(_0023_003Dz76Ya4vc_003D);
			_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DztNBJE_4_003D(_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
			Stopwatch _0023_003DzjQHiWpw_003D = new Stopwatch();
			Point3D[] array = new Point3D[0];
			int num = 0;
			if (_0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2 != null)
			{
				for (int i = 0; i < _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2.Length - 1; i++)
				{
					_0023_003Dz3ORRwnUaVbd8 _0023_003Dz3ORRwnUaVbd9 = new _0023_003Dz3ORRwnUaVbd8();
					_0023_003Dz3ORRwnUaVbd9._0023_003DzGkfwiw0_003D(new _0023_003DzOQm_OJkhw_0024vS(new _0023_003DzmKBPh7nOT6nY(_0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i].X, _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i].Y), new _0023_003DzmKBPh7nOT6nY(_0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i + 1].X, _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i + 1].Y)));
					Point3D[][] array2 = _0023_003DzopRx0_MBcTQs._0023_003DzRwjCiYE_003D(_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2, _0023_003Dz3ORRwnUaVbd9, _0023_003DzjQHiWpw_003D);
					if (array2.Length == 1 && Point2D.DistanceSquared(array2[0][0], _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i]) < 1E-12 && Point2D.DistanceSquared(array2[0][array2[0].Length - 1], _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2[i + 1]) < 1E-12)
					{
						if (i < _0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item2.Length - 2)
						{
							Array.Resize(ref array, num + array2[0].Length - 1);
							Array.Copy(array2[0], 0, array, num, array2[0].Length - 1);
							num = array.Length;
						}
						else
						{
							Array.Resize(ref array, num + array2[0].Length);
							Array.Copy(array2[0], 0, array, num, array2[0].Length);
							num = array.Length;
						}
						continue;
					}
					array = null;
					break;
				}
				_0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D] = new Tuple<Point3D[], Point3D[]>(_0023_003DzWFELMytNNPze[_0023_003Dz437_00244ak_003D].Item1, array);
			}
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ProjectingLinksText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	protected double vertLeadAmount;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<IList<Line>> _0023_003DzJ_vfUqI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAW1iI0byIkg37k4cyQT5oPQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzJk9a_0024Rmsl_0024KchM33BkfWyAa6MaCw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_0024zsSa9MWFN0oSLExdQegFEFFO26K7MilKQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995641);

	public bool ContactOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAW1iI0byIkg37k4cyQT5oPQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAW1iI0byIkg37k4cyQT5oPQ_003D = value;
		}
	}

	public double StayDownDistance
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJk9a_0024Rmsl_0024KchM33BkfWyAa6MaCw;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJk9a_0024Rmsl_0024KchM33BkfWyAa6MaCw = value;
		}
	}

	public string ProjectingLinksText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024zsSa9MWFN0oSLExdQegFEFFO26K7MilKQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024zsSa9MWFN0oSLExdQegFEFFO26K7MilKQ_003D_003D = value;
		}
	}

	private protected Project3D(Setup _0023_003Dz9cS3uG0_003D, EndMill _0023_003DzzhSDYPa50tjn, Geometry3D _0023_003DzyXmKbtw_003D, double _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D)
		: base(_0023_003Dz9cS3uG0_003D, _0023_003DzzhSDYPa50tjn, _0023_003DzyXmKbtw_003D)
	{
		_0023_003DzJ_vfUqI_003D = null;
		_0023_003DztGdcVOA_003D(_0023_003Dz9cS3uG0_003D, _0023_003DzzhSDYPa50tjn, _0023_003DzyXmKbtw_003D, _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D);
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, IList<Point3D> pattern, double verticalLeadAmount)
		: this(setup, cutter, geometry, new List<IList<Point3D>> { pattern }, verticalLeadAmount)
	{
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, IList<Point3D> pattern, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, new List<IList<Point3D>> { pattern }, verticalLeadAmount, zLow)
	{
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, LinearPath pattern, double verticalLeadAmount)
		: this(setup, cutter, geometry, new Point3D[1][] { pattern.Vertices }, verticalLeadAmount)
	{
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, LinearPath pattern, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, new Point3D[1][] { pattern.Vertices }, verticalLeadAmount, zLow)
	{
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, IList<IList<Point3D>> pattern, double verticalLeadAmount)
		: base(setup, cutter, geometry)
	{
		_0023_003DztGdcVOA_003D(setup, cutter, geometry, verticalLeadAmount);
		Line[][] array = new Line[pattern.Count][];
		for (int i = 0; i < pattern.Count; i++)
		{
			IList<Point3D> list = pattern[i];
			int count = list.Count;
			Line[] array2 = new Line[count - 1];
			for (int j = 0; j < count - 1; j++)
			{
				Point3D point3D = list[j];
				Point3D point3D2 = list[j + 1];
				Line line = new Line((Point3D)point3D.Clone(), (Point3D)point3D2.Clone());
				line.TransformBy(setup._0023_003DzylonwpI_003D);
				line.StartPoint.Z = 0.0;
				line.EndPoint.Z = 0.0;
				array2[j] = line;
			}
			array[i] = array2;
		}
		_0023_003DzJ_vfUqI_003D = new List<IList<Line>>(array);
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, IList<IList<Point3D>> pattern, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, pattern, verticalLeadAmount)
	{
		zRange = InitRangeZ(setup, geometry, zLow);
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, IList<Point3D> pattern, double verticalLeadAmount)
		: this(setup, cutter, geometry, pattern, verticalLeadAmount)
	{
		base.boundary = boundary;
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, IList<Point3D> pattern, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, pattern, verticalLeadAmount)
	{
		base.boundary = boundary;
		zRange = InitRangeZ(setup, geometry, zLow);
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, IList<IList<Point3D>> pattern, double verticalLeadAmount)
		: this(setup, cutter, geometry, pattern, verticalLeadAmount)
	{
		base.boundary = boundary;
	}

	public Project3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, IList<IList<Point3D>> pattern, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, pattern, verticalLeadAmount)
	{
		base.boundary = boundary;
		zRange = InitRangeZ(setup, geometry, zLow);
	}

	private void _0023_003DztGdcVOA_003D(Setup _0023_003Dz9cS3uG0_003D, EndMill _0023_003DzzhSDYPa50tjn, Geometry3D _0023_003DzyXmKbtw_003D, double _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D)
	{
		base.Tolerance = 0.01;
		vertLeadAmount = _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D;
		base.LeadIn = null;
		OpenContoursRamp = null;
		pocketRamp = null;
		Ramp = null;
		zRange = new Interval(_0023_003DzyXmKbtw_003D.GetBoxMin(_0023_003Dz9cS3uG0_003D).Z, _0023_003DzyXmKbtw_003D.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z + _0023_003DzyXmKbtw_003D.GetBoxSize(_0023_003Dz9cS3uG0_003D).Z * 0.1);
		EstimateSafetyHeights();
		StayDownDistance = _0023_003DzzhSDYPa50tjn.Diameter;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		int[] startIndices;
		Region[] actualRegions;
		Point3D[][][] rawPasses = GetRawPasses(progress, ct, out startIndices, out actualRegions);
		if (rawPasses == null)
		{
			return;
		}
		Point3D[][][][] array = new Point3D[startIndices.Length][][][];
		for (int i = 0; i < startIndices.Length; i++)
		{
			int num = ((i + 1 < startIndices.Length) ? startIndices[i + 1] : rawPasses.Length) - startIndices[i];
			array[i] = new Point3D[num][][];
			Array.Copy(rawPasses, startIndices[i], array[i], 0, num);
		}
		bool flag = boundary != null;
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		for (int j = 0; j < array.Length; j++)
		{
			Tuple<Point3D[], Point3D[]>[] array2 = ((base.CutDirectionMode != cutDirectionType.Mixed) ? Machining._0023_003Dz2NOuDBhF9Cmo(array[j], base.Tolerance).SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzETAjO915pnjCj9krCglFxC0_003D).ToArray() : ((!flag) ? Machining._0023_003DzTGXzB_0Mfoxq(array[j], base.Tolerance).SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzr4xCDB0xZSzo8HSY2rOjKKI_003D).ToArray() : Machining._0023_003DzR8z_z2zqncJX(array[j], base.Tolerance).SelectMany((Tuple<Point3D[], Point3D[]>[] _0023_003DzuwH5j5s_003D) => _0023_003DzuwH5j5s_003D).ToArray()));
			if (base.CutDirectionMode == cutDirectionType.Mixed && flag && !_0023_003Dzcpx6Mgo_003D(progress, ct, array2, actualRegions[j]))
			{
				list = null;
				break;
			}
			List<List<Point3D>> list2 = new List<List<Point3D>>();
			for (int num2 = 0; num2 < array2.Length; num2++)
			{
				list2.Add(array2[num2].Item1.ToList());
				if (array2[num2].Item2 != null && Point3D.Distance(array2[num2].Item2.LastOrDefault(), array2[num2].Item2[0]) < StayDownDistance)
				{
					list2.Add(array2[num2].Item2.ToList());
				}
			}
			List<Point3D> list3 = new List<Point3D>();
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list4 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
			for (int num3 = 0; num3 < array2.Length; num3++)
			{
				IEnumerable<Point3D> collection;
				if (list3.Count != 0)
				{
					collection = array2[num3].Item1.Skip(1);
				}
				else
				{
					IEnumerable<Point3D> item = array2[num3].Item1;
					collection = item;
				}
				list3.AddRange(collection);
				if (array2[num3].Item2 != null && Point3D.Distance(array2[num3].Item2.LastOrDefault(), array2[num3].Item2[0]) < StayDownDistance)
				{
					list3.AddRange(array2[num3].Item2.Skip(1));
					continue;
				}
				list4.Add(new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(list3.ToArray()));
				list3.Clear();
			}
			list.Add(list4.ToArray());
		}
		if (list != null)
		{
			_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[1][] { list.SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D).ToArray() }, log, _0023_003DzoQcRoMY_003D: false, vertLeadAmount, _0023_003Dzbu8BV15Qqzan: false);
		}
	}

	protected Point3D[][][] GetRawPasses(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, out int[] startIndices, out Region[] actualRegions)
	{
		_0023_003DzeALrgz3cdl82(progress);
		Region transformedBoundary = Machining.GetTransformedBoundary(boundary, _0023_003Dz9cS3uG0_003D);
		Region[] array;
		if (transformedBoundary != null)
		{
			array = ((base.BoundaryOffset != 0.0) ? Utility.DetectRegionsFromContours(transformedBoundary.QuickOffset(base.BoundaryOffset, cornerType.Miter, tolerance)) : new Region[1] { transformedBoundary });
		}
		else
		{
			Point3D boxMin = geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D);
			Point3D boxMax = geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D);
			double num = base.BoundaryOffset;
			if (ContactOnly)
			{
				num = _0023_003DzXT4sGPyMpoH6()._0023_003DzIkPRXYA_003D();
			}
			array = new Region[1] { Region.CreateRectangle(boxMin.X - num, boxMin.Y - num, boxMax.X - boxMin.X + 2.0 * num, boxMax.Y - boxMin.Y + 2.0 * num) };
		}
		actualRegions = array;
		startIndices = new int[array.Length];
		int num2 = 0;
		Point3D[][][] array2 = new Point3D[num2][][];
		for (int i = 0; i < array.Length; i++)
		{
			startIndices[i] = num2;
			Point3D[][][] array3 = _0023_003DzjEoNmqYxgLhQ(array[i], ct, progress);
			if (array3 == null)
			{
				return null;
			}
			Array.Resize(ref array2, num2 + array3.Length);
			Array.Copy(array3, 0, array2, num2, array3.Length);
			num2 = array2.Length;
		}
		return array2;
	}

	private void _0023_003DzfeK9ScgXRl_0024_0024(_0023_003Dz0wzeWOGJZnQF _0023_003DzAqOpw0w_003D, _0023_003Dz0wzeWOGJZnQF _0023_003Dzk64JNOo_003D, Point3D[][] _0023_003DzkSAMv1c_003D)
	{
		if (_0023_003DzkSAMv1c_003D.Length == 0)
		{
			return;
		}
		int[] array = new int[2] { -1, -1 };
		for (int i = 0; i < _0023_003DzkSAMv1c_003D.Length; i++)
		{
			_0023_003DzkSAMv1c_003D[i][0] = new _0023_003Dz0wzeWOGJZnQF(_0023_003DzkSAMv1c_003D[i].First(), null, 0.0, _0023_003Dz01ItpmNP8rlW: false, _0023_003DzCJkr8nY_003D: false, array, array, array);
			_0023_003DzkSAMv1c_003D[i][_0023_003DzkSAMv1c_003D[i].Length - 1] = new _0023_003Dz0wzeWOGJZnQF(_0023_003DzkSAMv1c_003D[i][_0023_003DzkSAMv1c_003D[i].Length - 1], null, 0.0, _0023_003Dz01ItpmNP8rlW: false, _0023_003DzCJkr8nY_003D: false, array, array, array);
		}
		if (!(_0023_003DzkSAMv1c_003D[0][0] == null) && !(_0023_003DzkSAMv1c_003D[^1][_0023_003DzkSAMv1c_003D[^1].Length - 1] == null))
		{
			if (Point2D.DistanceSquared(_0023_003DzAqOpw0w_003D, _0023_003DzkSAMv1c_003D[0][0]) < 1E-12)
			{
				_0023_003DzkSAMv1c_003D[0][0] = new _0023_003Dz0wzeWOGJZnQF(_0023_003DzkSAMv1c_003D[0][0], _0023_003DzAqOpw0w_003D._0023_003Dz68bspubRg5a7, _0023_003DzAqOpw0w_003D._0023_003DzQu508mcPiFnj, _0023_003DzAqOpw0w_003D._0023_003Dzb8JguMU_003D, _0023_003DzAqOpw0w_003D._0023_003Dz0u7IH4E_003D, _0023_003DzAqOpw0w_003D._0023_003DzwUbaHtM_003D, _0023_003DzAqOpw0w_003D._0023_003Dzg_0024_0024HtRw_003D, _0023_003DzAqOpw0w_003D._0023_003DzMqZZWVg_003D);
			}
			if (Point2D.DistanceSquared(_0023_003Dzk64JNOo_003D, _0023_003DzkSAMv1c_003D[^1][_0023_003DzkSAMv1c_003D[^1].Length - 1]) < 1E-12)
			{
				_0023_003DzkSAMv1c_003D[^1][_0023_003DzkSAMv1c_003D[^1].Length - 1] = new _0023_003Dz0wzeWOGJZnQF(_0023_003DzkSAMv1c_003D.LastOrDefault().LastOrDefault(), _0023_003Dzk64JNOo_003D._0023_003Dz68bspubRg5a7, _0023_003Dzk64JNOo_003D._0023_003DzQu508mcPiFnj, _0023_003Dzk64JNOo_003D._0023_003Dzb8JguMU_003D, _0023_003Dzk64JNOo_003D._0023_003Dz0u7IH4E_003D, _0023_003Dzk64JNOo_003D._0023_003DzwUbaHtM_003D, _0023_003Dzk64JNOo_003D._0023_003Dzg_0024_0024HtRw_003D, _0023_003Dzk64JNOo_003D._0023_003DzMqZZWVg_003D);
			}
		}
	}

	private protected virtual List<IList<Line>> _0023_003DzMYW_00247MY_003D(Region _0023_003DzFDwqpgU_003D)
	{
		List<IList<Line>> list = new List<IList<Line>>(_0023_003DzJ_vfUqI_003D.Count);
		foreach (IList<Line> item in _0023_003DzJ_vfUqI_003D)
		{
			foreach (Line item2 in item)
			{
				list.Add(Machining.AppendLine(item2, _0023_003DzFDwqpgU_003D));
			}
		}
		return list;
	}

	private Point3D[][][] _0023_003DzjEoNmqYxgLhQ(Region _0023_003DzFDwqpgU_003D, CancellationToken _0023_003Dzjvn7P10_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D CS_0024_003C_003E8__locals18 = new _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D();
		CS_0024_003C_003E8__locals18._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals18._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals18._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		CS_0024_003C_003E8__locals18._0023_003DzWngxRrg_003D = _0023_003Dz_4v_5eUz7tD_0024(_0023_003DzFDwqpgU_003D);
		CS_0024_003C_003E8__locals18._0023_003DzPZOwdb1GfpHX = _0023_003DzMYW_00247MY_003D(_0023_003DzFDwqpgU_003D);
		CS_0024_003C_003E8__locals18._0023_003DzyZlWguvcpRpK = new Point3D[CS_0024_003C_003E8__locals18._0023_003DzPZOwdb1GfpHX.Count][][];
		CS_0024_003C_003E8__locals18._0023_003Dz9JZgoew_003D = CS_0024_003C_003E8__locals18._0023_003DzPZOwdb1GfpHX.Count;
		CS_0024_003C_003E8__locals18._0023_003Dz76Ya4vc_003D = _0023_003DzXT4sGPyMpoH6();
		CS_0024_003C_003E8__locals18._0023_003DzPqXWTst3YPlWn9JngQ_003D_003D = GetSampling();
		CS_0024_003C_003E8__locals18._0023_003Dz8If0AEk_003D = true;
		ResetProgressParallel();
		Parallel.For(0, CS_0024_003C_003E8__locals18._0023_003Dz9JZgoew_003D, () => new Dictionary<int, Point3D[][]>(), CS_0024_003C_003E8__locals18._0023_003DzYXSeSIqoId0SwA0j1HVlAfE_003D, delegate(Dictionary<int, Point3D[][]> _0023_003DzBJFJHwk_003D)
		{
			lock (CS_0024_003C_003E8__locals18._0023_003DzyZlWguvcpRpK)
			{
				foreach (KeyValuePair<int, Point3D[][]> item in _0023_003DzBJFJHwk_003D)
				{
					CS_0024_003C_003E8__locals18._0023_003DzyZlWguvcpRpK[item.Key] = item.Value;
				}
			}
		});
		if (!CS_0024_003C_003E8__locals18._0023_003Dz8If0AEk_003D)
		{
			return null;
		}
		return _0023_003DzJKePfk0_003D(CS_0024_003C_003E8__locals18._0023_003DzyZlWguvcpRpK);
	}

	private protected virtual Point3D[][][] _0023_003DzJKePfk0_003D(Point3D[][][] _0023_003DzyZlWguvcpRpK)
	{
		List<Point3D[][]> list = new List<Point3D[][]>(_0023_003DzyZlWguvcpRpK.Length);
		List<Point3D> list2 = new List<Point3D>();
		Point3D point3D = null;
		foreach (Point3D[][] array in _0023_003DzyZlWguvcpRpK)
		{
			if (array.Length == 1)
			{
				Point3D[] array2 = array[0];
				if (point3D != null && array2[0].DistanceTo(point3D) > base.Tolerance / 100.0)
				{
					_0023_003DzZ5SVRngC58jS(list2, list);
				}
				list2.AddRange(array2);
				point3D = array2.Last();
			}
			else
			{
				_0023_003DzZ5SVRngC58jS(list2, list);
			}
		}
		if (list.Count == 0 && list2.Count > 0)
		{
			_0023_003DzZ5SVRngC58jS(list2, list);
		}
		return list.ToArray();
	}

	private static void _0023_003DzZ5SVRngC58jS(List<Point3D> _0023_003Dz9BM_0024JJOnfyrP, List<Point3D[][]> _0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D)
	{
		if (_0023_003Dz9BM_0024JJOnfyrP.Count > 0)
		{
			Point3D[] array = Utility.RemoveDuplicates(_0023_003Dz9BM_0024JJOnfyrP.ToArray());
			_0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.Add(new Point3D[1][] { array });
		}
		_0023_003Dz9BM_0024JJOnfyrP.Clear();
	}

	private _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_4v_5eUz7tD_0024(Region _0023_003DzFDwqpgU_003D)
	{
		Point3D boxMin = geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D);
		Point3D boxMax = geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D);
		double _0023_003DzEGKj_0024SNUUihi = cutter._0023_003DzEGKj_0024SNUUihi;
		_0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D2 = new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D(boxMin.X - _0023_003DzEGKj_0024SNUUihi, boxMax.X + _0023_003DzEGKj_0024SNUUihi, boxMin.Y - _0023_003DzEGKj_0024SNUUihi, boxMax.Y + _0023_003DzEGKj_0024SNUUihi, 0.0, 0.0);
		if (_0023_003DzFDwqpgU_003D != null)
		{
			_0023_003DzFDwqpgU_003D.Regen(base.Tolerance);
			return new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D(_0023_003DzFDwqpgU_003D.BoxMin.X - _0023_003DzEGKj_0024SNUUihi, _0023_003DzFDwqpgU_003D.BoxMax.X + _0023_003DzEGKj_0024SNUUihi, _0023_003DzFDwqpgU_003D.BoxMin.Y - _0023_003DzEGKj_0024SNUUihi, _0023_003DzFDwqpgU_003D.BoxMax.Y + _0023_003DzEGKj_0024SNUUihi, 0.0, 0.0);
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995603));
	}

	private bool _0023_003Dzcpx6Mgo_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, Tuple<Point3D[], Point3D[]>[] _0023_003DzWFELMytNNPze, Region _0023_003DzFDwqpgU_003D)
	{
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2 = new _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D();
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzWFELMytNNPze = _0023_003DzWFELMytNNPze;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzWngxRrg_003D = _0023_003Dz_4v_5eUz7tD_0024(_0023_003DzFDwqpgU_003D);
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz9JZgoew_003D = _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzWFELMytNNPze.Length;
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz76Ya4vc_003D = _0023_003DzXT4sGPyMpoH6();
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzPqXWTst3YPlWn9JngQ_003D_003D = GetSampling();
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz8If0AEk_003D = true;
		ResetProgressParallel();
		Parallel.For(0, _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz9JZgoew_003D, _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003DzqmbQfPOBqnHwyrbtCg_003D_003D);
		if (!_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D2._0023_003Dz8If0AEk_003D)
		{
			return false;
		}
		return true;
	}

	private _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] _0023_003DzasjgHn0_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] _0023_003DzosMf4QgVa5ec, _0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dz76Ya4vc_003D, double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzWngxRrg_003D)
	{
		Stopwatch _0023_003DzjQHiWpw_003D = new Stopwatch();
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2 = new _0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D();
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003Dz12p2jmUTCnCB(_0023_003Dz9cS3uG0_003D, (Geometry3D)geometry, _0023_003DzWngxRrg_003D);
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzMFlIwko_003D(zRange.Low);
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DzePcMMDarrpwf(_0023_003Dz76Ya4vc_003D);
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2._0023_003DztNBJE_4_003D(_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D);
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 = null;
		for (int i = 0; i < _0023_003DzosMf4QgVa5ec.Length; i++)
		{
			_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array = _0023_003DzosMf4QgVa5ec[i];
			if (array.Length != 0 && _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 != null)
			{
				Point3D point3D = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D.Last();
				Point3D point3D2 = array.First()._0023_003DzFsatqHw_003D.First();
				if (point3D2.DistanceTo(point3D) < StayDownDistance)
				{
					_0023_003Dz3ORRwnUaVbd8 _0023_003Dz3ORRwnUaVbd9 = new _0023_003Dz3ORRwnUaVbd8();
					_0023_003Dz3ORRwnUaVbd9._0023_003DzGkfwiw0_003D(new _0023_003DzOQm_OJkhw_0024vS(new _0023_003DzmKBPh7nOT6nY(point3D.X, point3D.Y, 0.0), new _0023_003DzmKBPh7nOT6nY(point3D2.X, point3D2.Y, 0.0)));
					int destinationIndex;
					if (boundary != null)
					{
						Point3D[][] source = _0023_003DzRwjCiYE_003D(_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D2, _0023_003Dz3ORRwnUaVbd9, _0023_003DzjQHiWpw_003D);
						destinationIndex = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D.Length;
						Array.Resize(ref _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D.Length + source.First().Length - 2);
						Array.Copy(source.First(), 1, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D, destinationIndex, source.First().Length - 2);
					}
					destinationIndex = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D.Length;
					Array.Resize(ref _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D.Length + array.First()._0023_003DzFsatqHw_003D.Length);
					Array.Copy(array.First()._0023_003DzFsatqHw_003D, 0, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D, destinationIndex, array.First()._0023_003DzFsatqHw_003D.Length);
					array = array.Skip(1).ToArray();
				}
			}
			if (array.Length != 0)
			{
				list.Add(array);
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 = array.Last();
			}
		}
		return list.ToArray();
	}

	private Point3D[][] _0023_003DzRwjCiYE_003D(_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D _0023_003DzJZRuYCI_003D, _0023_003Dz3ORRwnUaVbd8 _0023_003Dzsuiz4uo_003D, Stopwatch _0023_003DzjQHiWpw_003D)
	{
		_0023_003DzJZRuYCI_003D._0023_003Dz3gkATJs_003D(_0023_003Dzsuiz4uo_003D);
		_0023_003DzjQHiWpw_003D.Start();
		_0023_003DzJZRuYCI_003D._0023_003Dzc_0024pb7t4_003D();
		_0023_003DzjQHiWpw_003D.Stop();
		_0023_003DzjQHiWpw_003D.Reset();
		_0023_003DzjQHiWpw_003D.Start();
		Point3D[][] loops = _0023_003DzOkynKKo_003D(_0023_003DzJZRuYCI_003D);
		_0023_003DzjQHiWpw_003D.Stop();
		Point3D[][] array = Filter(loops);
		if (base.AxialStockToLeave != 0.0)
		{
			Machining3D.TranslateZ(array, base.AxialStockToLeave, zRange);
		}
		return array;
	}

	private void _0023_003DzeALrgz3cdl82(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		if (!((Geometry3D)geometry).IsReadyParallel(_0023_003Dz9cS3uG0_003D))
		{
			StartContinuousAnimation(base.PreparingGeometryText, _0023_003DzmHS7frs_003D);
			((Geometry3D)geometry).PreProcessParallel(_0023_003Dz9cS3uG0_003D);
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		}
	}

	private _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzimNgll4pKaCU(Point3D[][] _0023_003Dz4wZe_0024Xg_003D, int _0023_003DzyzK8swU_003D)
	{
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[_0023_003Dz4wZe_0024Xg_003D.Length];
		switch (base.CutDirectionMode)
		{
		case cutDirectionType.Mixed:
			if (_0023_003DzyzK8swU_003D % 2 == 0)
			{
				Array.Reverse(_0023_003Dz4wZe_0024Xg_003D);
			}
			break;
		case cutDirectionType.Conventional:
			Array.Reverse(_0023_003Dz4wZe_0024Xg_003D);
			break;
		}
		for (int i = 0; i < _0023_003Dz4wZe_0024Xg_003D.Length; i++)
		{
			Point3D[] array2 = _0023_003Dz4wZe_0024Xg_003D[i];
			Point3D[] array3 = new Point3D[array2.Length];
			Array.Copy(array2, array3, array2.Length);
			switch (base.CutDirectionMode)
			{
			case cutDirectionType.Mixed:
				if (_0023_003DzyzK8swU_003D % 2 == 0)
				{
					Array.Reverse(array3);
				}
				break;
			case cutDirectionType.Conventional:
				Array.Reverse(array3);
				break;
			}
			array[i] = new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array3);
		}
		return array;
	}

	private Point3D[][] _0023_003DzOkynKKo_003D(_0023_003Dz0JIgxQpsDZbf4VcHqAU5fWMiju_002491cqPddYjL6mvFLQrvgwmrA_003D_003D _0023_003DzJZRuYCI_003D)
	{
		double num = tolerance / 10.0;
		List<Point3D[]> list = new List<Point3D[]>();
		List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>[] array = _0023_003DzJZRuYCI_003D._0023_003DzZ_0024UxBO0_003D();
		foreach (List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list2 in array)
		{
			if (list2.Count == 0)
			{
				return new Point3D[0][];
			}
			List<List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>> _0023_003DzeBYSlNMCbCXU = new List<List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>>();
			if (list2.Count < 2)
			{
				return _0023_003Dz_0024Rdm0IlbQ41g(list2, _0023_003DzeBYSlNMCbCXU);
			}
			Point3D point3D = _0023_003Dz9QtlNO41v2Ii(list2[1], list2[0]);
			list2.Insert(0, new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(point3D.X, point3D.Y, point3D.Z));
			int count = list2.Count;
			Point3D point3D2 = _0023_003Dz9QtlNO41v2Ii(list2[count - 2], list2[count - 1]);
			list2.Add(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(point3D2.X, point3D2.Y, point3D2.Z));
			IComparer<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> comparer = new _0023_003DzMn5FdlH2gRxO_wf5tJwbjW0RFRCwmZS5cRJ6bqo_003D(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(list2[0]));
			int _0023_003DzdbIvGaME158A;
			double num2;
			do
			{
				_0023_003DzdbIvGaME158A = 0;
				List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list3 = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>();
				_0023_003Dzf3HDD8GZgr5n7_b57g_003D_003D(list2, list3, num, ref _0023_003DzdbIvGaME158A);
				_0023_003DzJZRuYCI_003D._0023_003Dzz8DDgng_003D(list3);
				list2.AddRange(list3);
				list2.Sort(comparer);
				num2 = _0023_003DzIVQM0lpMxVDU(list2, num);
			}
			while (num2 > num || _0023_003DzdbIvGaME158A > 0);
			List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list4 = list2.Skip(1).ToList();
			List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzHYmYZsf3SBHG = list4.Take(list4.Count - 1).ToList();
			list.AddRange(_0023_003Dz_0024Rdm0IlbQ41g(_0023_003DzHYmYZsf3SBHG, _0023_003DzeBYSlNMCbCXU));
		}
		return list.ToArray();
	}

	private double _0023_003Dzf3HDD8GZgr5n7_b57g_003D_003D(List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzHYmYZsf3SBHG, List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003Dzu3HnrL5Wj25N, double _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, ref int _0023_003DzdbIvGaME158A)
	{
		double _0023_003Dz0nWlhAUlOe9N = 0.0;
		double _0023_003DzId5C3LA_003D = Math.Max(((Geometry3D)geometry).GetBoxMin(_0023_003Dz9cS3uG0_003D).Z, zRange.Low);
		if (_0023_003DzHYmYZsf3SBHG.Count == 4)
		{
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2 = _0023_003DzHYmYZsf3SBHG[1];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3 = _0023_003DzHYmYZsf3SBHG[2];
			Segment3D segment3D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzId5C3LA_003D);
			_0023_003Dzu3HnrL5Wj25N.Add(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(segment3D.MidPoint.X, segment3D.MidPoint.Y, _0023_003DzId5C3LA_003D));
		}
		else if (_0023_003DzHYmYZsf3SBHG.Count == 5)
		{
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4 = _0023_003DzHYmYZsf3SBHG[1];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5 = _0023_003DzHYmYZsf3SBHG[2];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D6 = _0023_003DzHYmYZsf3SBHG[3];
			Segment3D segment3D2 = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzId5C3LA_003D);
			Segment3D segment3D3 = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D6._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D6._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D6._0023_003DzId5C3LA_003D);
			_0023_003Dzu3HnrL5Wj25N.Add(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(segment3D2.MidPoint.X, segment3D2.MidPoint.Y, _0023_003DzId5C3LA_003D));
			_0023_003Dzu3HnrL5Wj25N.Add(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(segment3D3.MidPoint.X, segment3D3.MidPoint.Y, _0023_003DzId5C3LA_003D));
		}
		else
		{
			for (int i = 0; i < _0023_003DzHYmYZsf3SBHG.Count - 3; i++)
			{
				_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D7 = _0023_003DzHYmYZsf3SBHG[i];
				_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8 = _0023_003DzHYmYZsf3SBHG[i + 1];
				_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9 = _0023_003DzHYmYZsf3SBHG[i + 2];
				_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D10 = _0023_003DzHYmYZsf3SBHG[i + 3];
				Segment3D _0023_003DzgPsOl1A_003D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D7._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D7._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D7._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003DzId5C3LA_003D);
				Segment3D _0023_003DzD5YCi2M_003D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D8._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003DzId5C3LA_003D);
				Segment3D _0023_003Dz9_0024bIhS0_003D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D9._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D10._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D10._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D10._0023_003DzId5C3LA_003D);
				_0023_003Dz2qWw7fGUBCjCrYWsZQ_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, _0023_003Dzu3HnrL5Wj25N, _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003DzdbIvGaME158A);
			}
		}
		return _0023_003Dz0nWlhAUlOe9N;
	}

	private double _0023_003DzIVQM0lpMxVDU(IList<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzHYmYZsf3SBHG, double _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D)
	{
		double num = 0.0;
		for (int i = 0; i < _0023_003DzHYmYZsf3SBHG.Count - 3; i++)
		{
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2 = _0023_003DzHYmYZsf3SBHG[i];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3 = _0023_003DzHYmYZsf3SBHG[i + 1];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4 = _0023_003DzHYmYZsf3SBHG[i + 2];
			_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5 = _0023_003DzHYmYZsf3SBHG[i + 3];
			Segment3D _0023_003DzgPsOl1A_003D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzId5C3LA_003D);
			Segment3D segment3D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D3._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzId5C3LA_003D);
			Segment3D _0023_003Dz9_0024bIhS0_003D = new Segment3D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D4._0023_003DzId5C3LA_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzBJFJHwk_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003Dz40R7bAU_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D5._0023_003DzId5C3LA_003D);
			if (_0023_003DzyD9D8wRCNkcJ(_0023_003DzgPsOl1A_003D, segment3D, _0023_003Dz9_0024bIhS0_003D, _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, out var _0023_003DzffqPLNQ_003D, out var _0023_003DzZe6oCrQ_003D))
			{
				double radius;
				double deviation = Utility.GetDeviation(segment3D.P0, _0023_003DzffqPLNQ_003D, segment3D.P1, _0023_003DzZe6oCrQ_003D, out radius);
				if (deviation > num)
				{
					num = deviation;
				}
			}
		}
		return num;
	}

	private Point3D[][] _0023_003Dz_0024Rdm0IlbQ41g(List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzHYmYZsf3SBHG, List<List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>> _0023_003DzeBYSlNMCbCXU)
	{
		_0023_003DzeBYSlNMCbCXU.Add(_0023_003DzHYmYZsf3SBHG);
		if (ContactOnly)
		{
			_0023_003DzeBYSlNMCbCXU.Clear();
			List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>();
			for (int i = 0; i < _0023_003DzHYmYZsf3SBHG.Count; i++)
			{
				_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2 = _0023_003DzHYmYZsf3SBHG[i];
				if (_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2._0023_003DzLQVT3gk_003D._0023_003DzEKSHIVc_003D != _0023_003DzhlVU0X_0024wSO4i.NONE)
				{
					list.Add(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D2);
				}
				else if (list.Count > 0)
				{
					_0023_003DzeBYSlNMCbCXU.Add(list);
					list = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>();
				}
			}
			if (list.Count > 0)
			{
				_0023_003DzeBYSlNMCbCXU.Add(list);
			}
		}
		List<Point3D[]> list2 = new List<Point3D[]>(_0023_003DzeBYSlNMCbCXU.Count);
		foreach (List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> item in _0023_003DzeBYSlNMCbCXU)
		{
			Point3D[] array = new Point3D[item.Count];
			for (int j = 0; j < item.Count; j++)
			{
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = item[j];
				array[j] = new Point3D(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D);
			}
			list2.Add(array);
		}
		return list2.ToArray();
	}

	private static Point3D _0023_003Dz9QtlNO41v2Ii(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003Dz1v6oPQk_003D)
	{
		Point3D p = new Point3D(_0023_003DzjbqS1qE_003D._0023_003DzBJFJHwk_003D, _0023_003DzjbqS1qE_003D._0023_003Dz40R7bAU_003D, _0023_003DzjbqS1qE_003D._0023_003DzId5C3LA_003D);
		Point3D point3D = new Point3D(_0023_003Dz1v6oPQk_003D._0023_003DzBJFJHwk_003D, _0023_003Dz1v6oPQk_003D._0023_003Dz40R7bAU_003D, _0023_003Dz1v6oPQk_003D._0023_003DzId5C3LA_003D);
		Vector2D vector2D = new Vector2D(p, point3D);
		vector2D.Normalize();
		Point3D point3D2 = point3D + new Vector3D(vector2D.X, vector2D.Y);
		point3D2.Z = _0023_003Dz1v6oPQk_003D._0023_003DzId5C3LA_003D;
		return point3D2;
	}

	private void _0023_003Dz2qWw7fGUBCjCrYWsZQ_003D_003D(Segment3D _0023_003DzgPsOl1A_003D, Segment3D _0023_003DzD5YCi2M_003D, Segment3D _0023_003Dz9_0024bIhS0_003D, List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003Dzu3HnrL5Wj25N, double _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, ref double _0023_003Dz0nWlhAUlOe9N, ref int _0023_003DzdbIvGaME158A)
	{
		if (_0023_003DzyD9D8wRCNkcJ(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, out var _0023_003DzffqPLNQ_003D, out var _0023_003DzZe6oCrQ_003D))
		{
			double radius;
			double deviation = Utility.GetDeviation(_0023_003DzD5YCi2M_003D.P0, _0023_003DzffqPLNQ_003D, _0023_003DzD5YCi2M_003D.P1, _0023_003DzZe6oCrQ_003D, out radius);
			if (deviation > _0023_003Dz0nWlhAUlOe9N)
			{
				_0023_003Dz0nWlhAUlOe9N = deviation;
			}
			bool flag = Vector3D.AngleBetween(_0023_003DzffqPLNQ_003D, _0023_003DzZe6oCrQ_003D) > 0.7 || Vector3D.AreCoincident(_0023_003DzffqPLNQ_003D, _0023_003DzZe6oCrQ_003D);
			if (flag)
			{
				_0023_003DzdbIvGaME158A++;
			}
			if (deviation > _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D || flag)
			{
				_0023_003Dzu3HnrL5Wj25N.Add(new _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D(_0023_003DzD5YCi2M_003D.MidPoint.X, _0023_003DzD5YCi2M_003D.MidPoint.Y, zRange.Low));
			}
		}
	}

	private static bool _0023_003DzyD9D8wRCNkcJ(Segment3D _0023_003DzgPsOl1A_003D, Segment3D _0023_003DzD5YCi2M_003D, Segment3D _0023_003Dz9_0024bIhS0_003D, double _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D, out Vector3D _0023_003DzffqPLNQ_003D, out Vector3D _0023_003DzZe6oCrQ_003D)
	{
		_0023_003DzffqPLNQ_003D = (_0023_003DzZe6oCrQ_003D = null);
		double num = _0023_003DzD5YCi2M_003D.P1.X - _0023_003DzD5YCi2M_003D.P0.X;
		double num2 = _0023_003DzD5YCi2M_003D.P1.Y - _0023_003DzD5YCi2M_003D.P0.Y;
		if (Math.Sqrt(num * num + num2 * num2) < _0023_003DzkWJTTFlsejnQS7_PCg_003D_003D)
		{
			return false;
		}
		_0023_003DzffqPLNQ_003D = _0023_003DzgPsOl1A_003D;
		Vector3D vector3D = _0023_003DzD5YCi2M_003D;
		_0023_003DzZe6oCrQ_003D = _0023_003Dz9_0024bIhS0_003D;
		_0023_003DzffqPLNQ_003D.Normalize();
		vector3D.Normalize();
		_0023_003DzZe6oCrQ_003D.Normalize();
		double num3 = Vector3D.AngleBetween(_0023_003DzffqPLNQ_003D, vector3D);
		double num4 = Vector3D.AngleBetween(vector3D, _0023_003DzZe6oCrQ_003D);
		if (num3 > 1E-06)
		{
			return num4 > 1E-06;
		}
		return false;
	}

	protected static Interval InitRangeZ(Setup setup, Geometry3D geometry, double zLow)
	{
		return new Interval(zLow, geometry.GetBoxMax(setup).Z + geometry.GetBoxSize(setup).Z * 0.1);
	}
}
