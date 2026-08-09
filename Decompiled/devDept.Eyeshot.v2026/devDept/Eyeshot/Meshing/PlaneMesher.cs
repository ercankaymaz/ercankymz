using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public class PlaneMesher : Mesher, ICurveMesherCreator
{
	private sealed class _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D
	{
		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		public double[] _0023_003DzU7WRl9I_003D;

		internal IEnumerable<Point3D> _0023_003DzPUend6W_00243mmZvKIZaKrwln_0024wRZc7(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = _0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, _0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D], _0023_003DzU7WRl9I_003D[(_0023_003Dz437_00244ak_003D + 1) % _0023_003DzU7WRl9I_003D.Length]);
			return array.Take(array.Length - 1);
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<double[], bool> _0023_003Dzb1k3XlgLXpaOl9ZXog_003D_003D;

		public static Func<double, bool> _0023_003DznosxYbq8VSYMgMQrTQ_003D_003D;

		public static Func<double[], bool> _0023_003DzAEZyB3KzB4TV13wzNA_003D_003D;

		public static Func<IList<SizesOnCurve>, bool> _0023_003DzoAoPnkdvef9hk7unLQ_003D_003D;

		public static Func<LinearPath, IList<Point3D>> _0023_003Dz7_WZ05dEvqdpEzItLA_003D_003D;

		public static Func<ICurve, IEnumerable<ICurve>> _0023_003DzHK9rlnvkxlWNHKJTsA_003D_003D;

		public static Func<Polygon2D, int> _0023_003Dzy7nEv89xDomyXIe12g_003D_003D;

		public static Func<_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D, _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		public static Func<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D, _0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzJlv1wPLmULy96VL17A_003D_003D;

		internal bool _0023_003Dz5jnqioeyihOGYAKb9A_003D_003D(double[] _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D == null;
		}

		internal bool _0023_003DzYth6y4o9JkSDyVTs7Q_003D_003D(double[] _0023_003Dz77g161c_003D)
		{
			return _0023_003Dz77g161c_003D.Any(_0023_003DzJ5g3Rwo_003D._0023_003DzeMEVp9jjdvFKGwm29w_003D_003D);
		}

		internal bool _0023_003DzeMEVp9jjdvFKGwm29w_003D_003D(double _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D <= 0.0;
		}

		internal bool _0023_003DzciTB_uMGQH_0024nQOy3gQ_003D_003D(IList<SizesOnCurve> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D == null;
		}

		internal IList<Point3D> _0023_003DzTtcccF7kXD1KpzRxYw_003D_003D(LinearPath _0023_003DzHPC6WX8_003D)
		{
			return _0023_003DzHPC6WX8_003D.Vertices;
		}

		internal IEnumerable<ICurve> _0023_003DzHAkKd_0024xHHIheEuDo8Q_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.GetIndividualCurves().AsEnumerable();
		}

		internal int _0023_003DzKXA0L1CWIiw0raJ8anThtPm4_0024mJLSmBRTk0ddR4_003D(Polygon2D _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.Points.Length;
		}

		internal _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D _0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D(_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D _0023_003Dz77g161c_003D)
		{
			_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D obj = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(_0023_003Dz77g161c_003D._0023_003DzR216mFc_003D(), _0023_003Dz77g161c_003D._0023_003DzqJqZpJk_003D(), _0023_003Dz77g161c_003D._0023_003Dz8F8_002454umdoK7());
			obj._0023_003Dzbtz8t3g_003D(_0023_003Dz77g161c_003D._0023_003DzOq3xSxQ_003D());
			return obj;
		}

		internal _0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D _0023_003DzH_00247918Z8K21kNLuYXriWjm0_003D(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzNDQ_E88_003D)
		{
			return new _0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D(_0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(0), _0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(1), _0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(2));
		}
	}

	private sealed class _0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D
	{
		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		public IList<SizesOnCurve> _0023_003DzU7WRl9I_003D;

		internal IEnumerable<Point3D> _0023_003DzPUend6W_00243mmZvKIZaKrwln_0024wRZc7(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = _0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, _0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D].StartSize, _0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D].EndSize);
			return array.Take(array.Length - 1);
		}
	}

	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003DzKWjLAL76_0024Xb8wu9w4g_003D_003D(double _0023_003DzXrexKjY_003D)
		{
			_0023_003DzopRx0_MBcTQs.UpdateProgress(_0023_003DzXrexKjY_003D * 100.0 + 100.0, 200.0, _0023_003DzopRx0_MBcTQs.OrderElevationText, _0023_003DzmHS7frs_003D);
		}
	}

	private sealed class _0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D
	{
		public Region _0023_003Dz7revxoQ_003D;

		public double[][] _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D;

		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		internal bool _0023_003DzK2G81DF_0024kvJdlGZMYA_003D_003D(int _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz7revxoQ_003D.ContourList[_0023_003Dz437_00244ak_003D].GetIndividualCurves().Length > _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[_0023_003Dz437_00244ak_003D].Length;
		}

		internal List<Point3D> _0023_003Dzfil0q2kBo_0024eHGOTXug_003D_003D(ICurve _0023_003Dzt_m8zV0_003D, int _0023_003Dz437_00244ak_003D)
		{
			return new List<Point3D>(_0023_003DzopRx0_MBcTQs._0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(_0023_003Dzt_m8zV0_003D, _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[_0023_003Dz437_00244ak_003D]));
		}
	}

	private sealed class _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D
	{
		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		public double _0023_003Dz14lzA48_003D;

		internal IEnumerable<Point3D> _0023_003DzPUend6W_00243mmZvKIZaKrwln_0024wRZc7(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = _0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, _0023_003Dz14lzA48_003D, _0023_003Dz14lzA48_003D);
			return array.Take(array.Length - 1);
		}
	}

	private sealed class _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D
	{
		public int _0023_003DzwJ3QaGJFHQh4;

		public _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003DzgJ_l7DwRQ7chaVEZmg_003D_003D(double _0023_003DzXrexKjY_003D)
		{
			_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelled((int)(_0023_003DzXrexKjY_003D * 100.0), _0023_003DzwJ3QaGJFHQh4, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.SmoothingText + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990142) + Math.Ceiling(_0023_003DzXrexKjY_003D * (double)_0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzopRx0_MBcTQs.SmoothingPasses), _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzmHS7frs_003D, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003Dzjvn7P10_003D);
		}
	}

	private sealed class _0023_003DzoH1JppX2eWqjOJKuOA_003D_003D
	{
		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		public double _0023_003Dzqj8EArg_003D;

		internal List<Point3D> _0023_003Dz4vFG9Ak6kYV9p899kw_003D_003D(ICurve _0023_003Dzt_m8zV0_003D, int _0023_003Dz437_00244ak_003D)
		{
			return new List<Point3D>(_0023_003DzopRx0_MBcTQs._0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(_0023_003Dzt_m8zV0_003D, _0023_003Dzqj8EArg_003D));
		}
	}

	private sealed class _0023_003Dzox0VSrxN8k5RLVog7Q_003D_003D
	{
		public Region _0023_003Dz7revxoQ_003D;

		public IList<IList<SizesOnCurve>> _0023_003DzSrRL3Zr_fKWh;

		public PlaneMesher _0023_003DzopRx0_MBcTQs;

		internal bool _0023_003DzK2G81DF_0024kvJdlGZMYA_003D_003D(int _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz7revxoQ_003D.ContourList[_0023_003Dz437_00244ak_003D].GetIndividualCurves().Length > _0023_003DzSrRL3Zr_fKWh[_0023_003Dz437_00244ak_003D].Count;
		}

		internal List<Point3D> _0023_003DzblZHLxeh4kOIGOvZ6w_003D_003D(ICurve _0023_003Dzt_m8zV0_003D, int _0023_003Dz437_00244ak_003D)
		{
			return new List<Point3D>(_0023_003DzopRx0_MBcTQs._0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(_0023_003Dzt_m8zV0_003D, _0023_003DzSrRL3Zr_fKWh[_0023_003Dz437_00244ak_003D]));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003DzGdd8YJmpscYFTNEbFQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzRu1e5oVGFku1d2VVjUFJHcY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzG5rtE8Tt91Gp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly PolyRegion2D _0023_003DzK0MNppzQRP86LbcZlw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Plane _0023_003DznksI_0024l2L21KB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Point2D[] _0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Point2D[][] _0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IList<ICurve> _0023_003DzMdbIBLOu_0024QJcN6CeYQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HistogramData _0023_003DzuL92rAYngwme;

	public string OrderElevationText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRu1e5oVGFku1d2VVjUFJHcY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRu1e5oVGFku1d2VVjUFJHcY_003D = value;
		}
	}

	public PlaneMesher(PolyRegion2D polyRegion2D, double maxElementSize = 0.0, IList<Point2D> points = null, IList<IList<Point2D>> segments = null)
	{
		_0023_003DzRu1e5oVGFku1d2VVjUFJHcY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990117);
		_0023_003DzuL92rAYngwme = new HistogramData(0, 0, 0, 0.0, 0.0, 0.0, null);
		base._002Ector();
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D = polyRegion2D ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990112));
		if ((_0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList ?? throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990089), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990290)))[0].VertexCount < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990299), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990229));
		}
		_0023_003DznksI_0024l2L21KB = Plane.XY;
		_0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D = points?.ToArray();
		if (segments != null)
		{
			_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D = new Point2D[segments.Count][];
			for (int i = 0; i < _0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D.Length; i++)
			{
				_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D[i] = segments[i].ToArray();
			}
		}
		if (maxElementSize < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990210), maxElementSize, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990219));
		}
		_0023_003DzG5rtE8Tt91Gp = _0023_003DzE9AaPJVkbI2N(maxElementSize);
	}

	public PlaneMesher(Plane plane, IList<IList<Point3D>> contours, double maxElementSize = 0.0, IList<Point3D> points = null, IList<IList<Point3D>> segments = null)
	{
		this._002Ector(plane, maxElementSize, points, segments);
		if (plane == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989933));
		}
		if (contours == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989914));
		}
		if (contours.Count < 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990089), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989891));
		}
		if (contours[0].Count < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990299), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989904));
		}
		if (maxElementSize < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989881), maxElementSize, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990219));
		}
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D = new PolyRegion2D(plane, contours);
	}

	public PlaneMesher(Region region, double elementSize, IList<Point3D> points = null, IList<LinearPath> segments = null, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		_0023_003DzoH1JppX2eWqjOJKuOA_003D_003D _0023_003DzoH1JppX2eWqjOJKuOA_003D_003D2 = new _0023_003DzoH1JppX2eWqjOJKuOA_003D_003D
		{
			_0023_003Dzqj8EArg_003D = elementSize
		};
		this._002Ector(_0023_003DzoH1JppX2eWqjOJKuOA_003D_003D2._0023_003Dzqj8EArg_003D, quadratic, points, segments, region, materials);
		_0023_003DzoH1JppX2eWqjOJKuOA_003D_003D2._0023_003DzopRx0_MBcTQs = this;
		if (_0023_003DzoH1JppX2eWqjOJKuOA_003D_003D2._0023_003Dzqj8EArg_003D <= 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989862), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989871));
		}
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D = new PolyRegion2D(region?.Plane ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989839)), new List<IList<Point3D>>(region.ContourList.Select(_0023_003DzoH1JppX2eWqjOJKuOA_003D_003D2._0023_003Dz4vFG9Ak6kYV9p899kw_003D_003D)));
		if ((_0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList ?? throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990089), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990076)))[0].VertexCount < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990053), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989989));
		}
	}

	public PlaneMesher(Region region, double[][] sizeOnVertices, double maxElementSize = 0.0, IList<Point3D> points = null, IList<LinearPath> segments = null, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D CS_0024_003C_003E8__locals15 = new _0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D
		{
			_0023_003Dz7revxoQ_003D = region,
			_0023_003DzTsINDy8j6voWNHu1xQ_003D_003D = sizeOnVertices
		};
		this._002Ector(maxElementSize, quadratic, points, segments, CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D, materials);
		CS_0024_003C_003E8__locals15._0023_003DzopRx0_MBcTQs = this;
		if (CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989970));
		}
		if (CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989979));
		}
		if (CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D.Length < CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D.ContourList.Count)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989960), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990664));
		}
		if (CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz5jnqioeyihOGYAKb9A_003D_003D))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990641), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990623));
		}
		if (Enumerable.Range(0, CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D.ContourList.Count).Any((int _0023_003Dz437_00244ak_003D) => CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D.ContourList[_0023_003Dz437_00244ak_003D].GetIndividualCurves().Length > CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[_0023_003Dz437_00244ak_003D].Length))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990604));
		}
		if (CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzYth6y4o9JkSDyVTs7Q_003D_003D))
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990740), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990749));
		}
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D = new PolyRegion2D(CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D.Plane ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990428)), new List<IList<Point3D>>(CS_0024_003C_003E8__locals15._0023_003Dz7revxoQ_003D.ContourList.Select((ICurve _0023_003Dzt_m8zV0_003D, int _0023_003Dz437_00244ak_003D) => new List<Point3D>(CS_0024_003C_003E8__locals15._0023_003DzopRx0_MBcTQs._0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(_0023_003Dzt_m8zV0_003D, CS_0024_003C_003E8__locals15._0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[_0023_003Dz437_00244ak_003D])))));
		IList<Polygon2D> contourList = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList;
		if (contourList.Count == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990089), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990405));
		}
		if (contourList[0].VertexCount < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990053), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990386));
		}
	}

	public PlaneMesher(Region region, IList<IList<SizesOnCurve>> sizeOnEdges, double maxElementSize = 0.0, IList<Point3D> points = null, IList<LinearPath> segments = null, bool quadratic = false, MaterialKeyedCollection materials = null)
	{
		_0023_003Dzox0VSrxN8k5RLVog7Q_003D_003D CS_0024_003C_003E8__locals12 = new _0023_003Dzox0VSrxN8k5RLVog7Q_003D_003D
		{
			_0023_003Dz7revxoQ_003D = region,
			_0023_003DzSrRL3Zr_fKWh = sizeOnEdges
		};
		this._002Ector(maxElementSize, quadratic, points, segments, CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D, materials);
		CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs = this;
		if (CS_0024_003C_003E8__locals12._0023_003DzSrRL3Zr_fKWh == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990395));
		}
		if (CS_0024_003C_003E8__locals12._0023_003DzSrRL3Zr_fKWh.Count < CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D.ContourList.Count)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990376), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990564));
		}
		if (CS_0024_003C_003E8__locals12._0023_003DzSrRL3Zr_fKWh.Any((IList<SizesOnCurve> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D == null))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990573), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990519));
		}
		if (Enumerable.Range(0, CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D.ContourList.Count).Any((int _0023_003Dz437_00244ak_003D) => CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D.ContourList[_0023_003Dz437_00244ak_003D].GetIndividualCurves().Length > CS_0024_003C_003E8__locals12._0023_003DzSrRL3Zr_fKWh[_0023_003Dz437_00244ak_003D].Count))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990500));
		}
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D = new PolyRegion2D(CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D.Plane ?? throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991175)), new List<IList<Point3D>>(CS_0024_003C_003E8__locals12._0023_003Dz7revxoQ_003D.ContourList.Select(CS_0024_003C_003E8__locals12._0023_003DzblZHLxeh4kOIGOvZ6w_003D_003D)));
		IList<Polygon2D> contourList = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList;
		if (contourList.Count == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990089), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991156));
		}
		if (contourList[0].VertexCount < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990053), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991165));
		}
	}

	private PlaneMesher(double _0023_003DzXPG_a5Q_003D = 0.0, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D = false, IList<Point3D> _0023_003DzrdSL0CI_003D = null, IList<LinearPath> _0023_003DzKTAIrow_003D = null, Region _0023_003Dz7revxoQ_003D = null, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D = null)
	{
		this._002Ector(_0023_003Dz7revxoQ_003D?.Plane, _0023_003DzXPG_a5Q_003D, _0023_003DzrdSL0CI_003D, _0023_003DzKTAIrow_003D?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzTtcccF7kXD1KpzRxYw_003D_003D).ToList());
		if (_0023_003Dz7revxoQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991146));
		}
		if (_0023_003DzFwalihjMriJGyFaGGg_003D_003D)
		{
			Region region = (Region)_0023_003Dz7revxoQ_003D.Clone();
			region.TransformBy(new Align3D(_0023_003DznksI_0024l2L21KB, Plane.XY));
			_0023_003DzMdbIBLOu_0024QJcN6CeYQ_003D_003D = region.ContourList.SelectMany((ICurve _0023_003Dzt_m8zV0_003D) => _0023_003Dzt_m8zV0_003D.GetIndividualCurves().AsEnumerable()).ToList();
		}
		if (!string.IsNullOrEmpty(_0023_003Dz7revxoQ_003D.MaterialName) && _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D != null)
		{
			_0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D = _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D[_0023_003Dz7revxoQ_003D.MaterialName];
		}
	}

	private PlaneMesher(Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzXPG_a5Q_003D = 0.0, IList<Point3D> _0023_003DzrdSL0CI_003D = null, IList<IList<Point3D>> _0023_003DzKTAIrow_003D = null)
	{
		_0023_003DzRu1e5oVGFku1d2VVjUFJHcY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990117);
		_0023_003DzuL92rAYngwme = new HistogramData(0, 0, 0, 0.0, 0.0, 0.0, null);
		base._002Ector();
		_0023_003DznksI_0024l2L21KB = _0023_003Dzrgqz890sj_0024X9 ?? Plane.XY;
		if (_0023_003DzrdSL0CI_003D != null)
		{
			_0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D = new Point2D[_0023_003DzrdSL0CI_003D.Count];
			for (int i = 0; i < _0023_003DzrdSL0CI_003D.Count; i++)
			{
				_0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D[i] = _0023_003DznksI_0024l2L21KB.Project(_0023_003DzrdSL0CI_003D[i]);
			}
		}
		if (_0023_003DzKTAIrow_003D != null)
		{
			_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D = new Point2D[_0023_003DzKTAIrow_003D.Count][];
			for (int j = 0; j < _0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D.Length; j++)
			{
				_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D[j] = new Point2D[_0023_003DzKTAIrow_003D[j].Count];
				for (int k = 0; k < _0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D[j].Length; k++)
				{
					_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D[j][k] = _0023_003DznksI_0024l2L21KB.Project(_0023_003DzKTAIrow_003D[j][k]);
				}
			}
		}
		_0023_003DzG5rtE8Tt91Gp = _0023_003DzE9AaPJVkbI2N(_0023_003DzXPG_a5Q_003D);
	}

	internal _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003Dz1cTWX1fK2A6e()
	{
		return _0023_003DzGdd8YJmpscYFTNEbFQ_003D_003D;
	}

	internal void _0023_003Dze54GqHhPK1fE(_0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzGdd8YJmpscYFTNEbFQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual CurveMesher CreateCurveMesher(ICurve curve, SizesOnCurve sizes)
	{
		return new CurveMesher(curve, sizes);
	}

	private Point3D[] _0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(ICurve _0023_003DzHIRPH9g_003D, double _0023_003DzKV5V6WI_003D, double _0023_003Dz8SEdsjQ_003D)
	{
		CurveMesher curveMesher = CreateCurveMesher(_0023_003DzHIRPH9g_003D, new SizesOnCurve(_0023_003DzKV5V6WI_003D, _0023_003Dz8SEdsjQ_003D));
		curveMesher.DoWork();
		_0023_003DzuL92rAYngwme = Mesher.Merge(_0023_003DzuL92rAYngwme, curveMesher.Result.EdgeShapeQualities);
		return curveMesher.Result.Vertices;
	}

	private bool _0023_003Dzkus4arlOYPj6nTsSMdxR6L1F7HH8()
	{
		IList<Polygon2D> contourList = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList;
		int num = 0;
		double[] array = new double[contourList.Select((Polygon2D _0023_003Dzt_m8zV0_003D) => _0023_003Dzt_m8zV0_003D.Points.Length).Sum()];
		foreach (Polygon2D item in contourList)
		{
			_ = item.Points;
			int vertexCount = item.VertexCount;
			for (int num2 = 0; num2 < vertexCount; num2++)
			{
				array[num++] = item.Points[num2].DistanceTo(item.Points[(num2 + 1) % vertexCount]);
			}
		}
		return array._0023_003Dz1csYVDqc024RBRs4QIzJ3iBLKA88IM6ZOQ_003D_003D() > 0.4;
	}

	private int _0023_003Dz7XoCEEn9V2Rh(List<_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Point2D _0023_003DzlY77YgY_003D, double _0023_003Dzm0CYiiE_003D)
	{
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			if (new Point2D(_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2._0023_003DzR216mFc_003D(), _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2._0023_003DzqJqZpJk_003D()).DistanceTo(_0023_003DzlY77YgY_003D) < _0023_003Dzm0CYiiE_003D)
			{
				return i;
			}
		}
		return -1;
	}

	private static Dictionary<int, int> _0023_003Dzsc_0024PAC9C4azBoly9z0Q__iI_003D(ICollection<_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IEnumerable<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out Point3D[] _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, out IndexTriangle[] _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] array = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.ToArray();
		_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D = new Point3D[array.Length];
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			dictionary[array[i]._0023_003DzOq3xSxQ_003D()] = i;
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[i] = new Node(array[i]._0023_003DzR216mFc_003D(), array[i]._0023_003DzqJqZpJk_003D());
		}
		_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D[] array2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.ToArray();
		_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D = new IndexTriangle[array2.Length];
		for (int j = 0; j < array2.Length; j++)
		{
			_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D _0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D2 = array2[j];
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D[j] = new IndexTriangle(dictionary[_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D2._0023_003DzBYFHRMc_fmcG(0)], dictionary[_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D2._0023_003DzBYFHRMc_fmcG(1)], dictionary[_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D2._0023_003DzBYFHRMc_fmcG(2)]);
		}
		return dictionary;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D CS_0024_003C_003E8__locals12 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals12._0023_003DzmHS7frs_003D = progress;
		CS_0024_003C_003E8__locals12._0023_003Dzjvn7P10_003D = ct;
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzK0MNppzQRP86LbcZlw_003D_003D.UpdateBoundingRect();
		double num = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList[0].Size.Diagonal * 1E-12;
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(_0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList[0].Points.Length, _0023_003DzleEQ0oAjXGue: true);
		for (int i = 0; i < _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList.Count; i++)
		{
			Polygon2D polygon2D = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList[i];
			if (polygon2D.Points.Length >= 4)
			{
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(Utility._0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(polygon2D.Points, i + 1, null), i > 0);
			}
		}
		int num2 = _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList.Count + 1;
		int num3 = 0;
		foreach (Polygon2D contour in _0023_003DzK0MNppzQRP86LbcZlw_003D_003D.ContourList)
		{
			num3 += contour.VertexCount;
		}
		num2++;
		Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		if (_0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D != null)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzVSOJftKhCjOQUV0QZQ_003D_003D;
			foreach (Point2D point2D in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
			{
				if (((num3 > 0) ? _0023_003Dz7XoCEEn9V2Rh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL(), point2D, num) : (-1)) == -1)
				{
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point2D.X, point2D.Y, num2));
				}
			}
		}
		num2++;
		if (_0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D != null)
		{
			Point2D[][] array2 = _0023_003Dz1_0024AwA8MAQakuOGNyV7333bA_003D;
			foreach (Point2D[] array3 in array2)
			{
				Point2D point2D2 = array3[0];
				int num4 = _0023_003Dz7XoCEEn9V2Rh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL(), point2D2, num);
				if (num4 == -1)
				{
					num4 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point2D2.X, point2D2.Y, num2));
				}
				int index = num4;
				for (int k = 1; k < array3.Length; k++)
				{
					Point2D point2D3 = array3[k];
					int num5;
					if (k == array3.Length - 1)
					{
						num5 = ((point2D3.DistanceTo(point2D2) < num) ? num4 : ((num3 > 0) ? _0023_003Dz7XoCEEn9V2Rh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL(), point2D3, num) : (-1)));
						if (num5 == -1)
						{
							num5 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
						}
					}
					else
					{
						num5 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
					}
					if (num5 == _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count)
					{
						_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point2D3.X, point2D3.Y, num2));
					}
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzDugehDLz2Pg5().Add(new _0023_003Dz6aZVluM0HoQZHUo9pw_003D_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[index], _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[num5], num2));
					index = num5;
				}
			}
		}
		_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2 = new _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG();
		if (_0023_003DzG5rtE8Tt91Gp != 0.0)
		{
			_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2._0023_003Dz5Gco_0024AAkXvX9(30.0);
			_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2._0023_003DzQVPyw7rkOoIJ(1.8 * _0023_003DzG5rtE8Tt91Gp);
		}
		int count = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
		UpdateProgressAndCheckCancelled(0.0, 1.0, base.MeshingText, CS_0024_003C_003E8__locals12._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals12._0023_003Dzjvn7P10_003D);
		_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003DzH2EAWg0_003D;
		try
		{
			Utility._0023_003DzSo_0024hId75EgH2Tq2_LlOiSGU_003D(out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _, _0023_003DzFaMCED8PjsukeIy29w_003D_003D2, out _0023_003DzH2EAWg0_003D, _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2, _0023_003Dz1cTWX1fK2A6e());
		}
		catch (Exception ex)
		{
			log.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991123) + ex.Message);
			return;
		}
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2 = _0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D).ToArray();
		IEnumerable<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D2 = ((IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>)_0023_003DzH2EAWg0_003D._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D()).Select((Func<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D, _0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D>)((_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzNDQ_E88_003D) => new _0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D(_0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(0), _0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(1), _0023_003DzNDQ_E88_003D._0023_003DzBYFHRMc_fmcG(2))));
		bool flag2 = base.SmoothingPasses > 0 && _0023_003DzG5rtE8Tt91Gp > 0.0;
		bool flag3 = flag2 && _0023_003Dzkus4arlOYPj6nTsSMdxR6L1F7HH8();
		if (flag2 && !flag3)
		{
			_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2 = new _0023_003DzgiHw8indZJSI86jtbVyVuNg_003D();
			_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = CS_0024_003C_003E8__locals12;
			_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzwJ3QaGJFHQh4 = ((_0023_003DzMdbIBLOu_0024QJcN6CeYQ_003D_003D != null) ? 200 : 100);
			try
			{
				new _0023_003Dz7HUxBg1zsMeRaP20zYjjrGkExWf9J6K_0024Pm_fZSU_003D()._0023_003Dzy9tytiY8GrO9(_0023_003DzH2EAWg0_003D, base.SmoothingPasses, new Progress<double>(_0023_003DzgiHw8indZJSI86jtbVyVuNg_003D2._0023_003DzgJ_l7DwRQ7chaVEZmg_003D_003D));
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D2 = _0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().ToArray();
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D2 = _0023_003DzH2EAWg0_003D._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D();
			}
			catch (Exception ex2)
			{
				log.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991116) + ex2.Message);
			}
		}
		Point3D[] _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D;
		IndexTriangle[] _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D;
		Dictionary<int, int> dictionary = _0023_003Dzsc_0024PAC9C4azBoly9z0Q__iI_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D2, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D2, out _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, out _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D);
		if (flag2 && flag3)
		{
			int smoothingPasses = base.SmoothingPasses;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D;
			Utility._0023_003DzuUqGvvsHKivEIx6YuUoQZy0_003D(smoothingPasses, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D, count);
		}
		FemMesh femMesh;
		if (_0023_003DzMdbIBLOu_0024QJcN6CeYQ_003D_003D != null)
		{
			UpdateProgressAndCheckCancelled(1.0, 2.0, OrderElevationText, CS_0024_003C_003E8__locals12._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals12._0023_003Dzjvn7P10_003D);
			femMesh = Surface._0023_003DzqONH5KoLjeGW(null, new Mesh(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D), _0023_003DzMdbIBLOu_0024QJcN6CeYQ_003D_003D, new Progress<double>(delegate(double _0023_003DzXrexKjY_003D)
			{
				CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.UpdateProgress(_0023_003DzXrexKjY_003D * 100.0 + 100.0, 200.0, CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.OrderElevationText, CS_0024_003C_003E8__locals12._0023_003DzmHS7frs_003D);
			})).ConvertToFemMesh(_0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D, t6: true);
			UpdateProgressTo100(OrderElevationText, CS_0024_003C_003E8__locals12._0023_003DzmHS7frs_003D);
		}
		else
		{
			Element[] array4 = new Element[_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Length];
			for (int num6 = 0; num6 < _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Length; num6++)
			{
				IndexTriangle indexTriangle = _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D[num6];
				array4[num6] = new Tria3(dictionary[indexTriangle.V1], dictionary[indexTriangle.V2], dictionary[indexTriangle.V3], _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D);
			}
			femMesh = new FemMesh(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, array4);
		}
		if (femMesh != null)
		{
			if (_0023_003DznksI_0024l2L21KB != Plane.XY)
			{
				femMesh.TransformBy(new Align3D(Plane.XY, _0023_003DznksI_0024l2L21KB));
			}
			base.Result = femMesh;
			base.Result.ElementShapeQualities = _0023_003Dz3wn_0024EN2MWgTa();
			base.Result.EdgeShapeQualities = _0023_003DzuL92rAYngwme;
		}
	}

	private IEnumerable<Point3D> _0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(ICurve _0023_003Dz06A5WivSSyUp, double _0023_003Dz14lzA48_003D)
	{
		_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D CS_0024_003C_003E8__locals5 = new _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D();
		CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals5._0023_003Dz14lzA48_003D = _0023_003Dz14lzA48_003D;
		List<Point3D> source = _0023_003Dz06A5WivSSyUp.GetIndividualCurves().SelectMany(delegate(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, CS_0024_003C_003E8__locals5._0023_003Dz14lzA48_003D, CS_0024_003C_003E8__locals5._0023_003Dz14lzA48_003D);
			return array.Take(array.Length - 1);
		}).ToList();
		return source.Append(source.First());
	}

	private IEnumerable<Point3D> _0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(ICurve _0023_003Dz06A5WivSSyUp, double[] _0023_003DzU7WRl9I_003D)
	{
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D CS_0024_003C_003E8__locals6 = new _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D();
		CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals6._0023_003DzU7WRl9I_003D = _0023_003DzU7WRl9I_003D;
		List<Point3D> source = _0023_003Dz06A5WivSSyUp.GetIndividualCurves().SelectMany(delegate(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, CS_0024_003C_003E8__locals6._0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals6._0023_003DzU7WRl9I_003D[(_0023_003Dz437_00244ak_003D + 1) % CS_0024_003C_003E8__locals6._0023_003DzU7WRl9I_003D.Length]);
			return array.Take(array.Length - 1);
		}).ToList();
		return source.Append(source.First());
	}

	private IEnumerable<Point3D> _0023_003DzgghSnQmqbPw3Mrp33w_003D_003D(ICurve _0023_003Dz06A5WivSSyUp, IList<SizesOnCurve> _0023_003DzU7WRl9I_003D)
	{
		_0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D CS_0024_003C_003E8__locals5 = new _0023_003Dz3BafgYqox1FSLT5bP9Znyeo_003D();
		CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals5._0023_003DzU7WRl9I_003D = _0023_003DzU7WRl9I_003D;
		List<Point3D> source = _0023_003Dz06A5WivSSyUp.GetIndividualCurves().SelectMany(delegate(ICurve _0023_003DzHIRPH9g_003D, int _0023_003Dz437_00244ak_003D)
		{
			Point3D[] array = CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs._0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_0023_003DzHIRPH9g_003D, CS_0024_003C_003E8__locals5._0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D].StartSize, CS_0024_003C_003E8__locals5._0023_003DzU7WRl9I_003D[_0023_003Dz437_00244ak_003D].EndSize);
			return array.Take(array.Length - 1);
		}).ToList();
		return source.Append(source.First());
	}

	private static double _0023_003DzE9AaPJVkbI2N(double _0023_003DzTxqgzks_003D)
	{
		if (_0023_003DzTxqgzks_003D < 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991331), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302991344));
		}
		return 1.7320508075688772 * _0023_003DzTxqgzks_003D * _0023_003DzTxqgzks_003D / 4.0;
	}

	public static double EstimateSizeByNumber(int numberOfTris, Region reg)
	{
		if (reg.Triangles == null || reg.Triangles.Length == 0)
		{
			Utility.ComputeBoundingBox(reg.EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
			double deviation = new Size3D(boxMin, boxMax).Diagonal / 100.0;
			reg.Regen(deviation);
		}
		Point3D centroid;
		double num = reg.GetArea(out centroid) / (double)numberOfTris;
		return 2.0 * Math.Sqrt(num / 1.7320508075688772);
	}
}
