using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public abstract class Machining : WorkUnit
{
	private protected sealed class _0023_003Dz0wzeWOGJZnQF : Point3D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ICurve _0023_003Dz68bspubRg5a7;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzQu508mcPiFnj;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dzb8JguMU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz0u7IH4E_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int[] _0023_003Dzg_0024_0024HtRw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int[] _0023_003DzwUbaHtM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int[] _0023_003DzMqZZWVg_003D;

		public _0023_003Dz0wzeWOGJZnQF(Point3D _0023_003DzlY77YgY_003D, ICurve _0023_003DzaTmo4gMdLDIvZ_COUw7mxgs_003D, bool _0023_003Dz01ItpmNP8rlW, bool _0023_003DzCJkr8nY_003D)
			: base(_0023_003DzlY77YgY_003D)
		{
			_0023_003Dz68bspubRg5a7 = _0023_003DzaTmo4gMdLDIvZ_COUw7mxgs_003D;
			_0023_003DzaTmo4gMdLDIvZ_COUw7mxgs_003D?.Project(this, out _0023_003DzQu508mcPiFnj);
			_0023_003Dzb8JguMU_003D = _0023_003Dz01ItpmNP8rlW;
			_0023_003Dz0u7IH4E_003D = _0023_003DzCJkr8nY_003D;
			_0023_003DzwUbaHtM_003D = new int[2] { -1, -1 };
			_0023_003Dzg_0024_0024HtRw_003D = new int[2] { -1, -1 };
			_0023_003DzMqZZWVg_003D = new int[2] { -1, -1 };
		}

		public _0023_003Dz0wzeWOGJZnQF(Point3D _0023_003DzlY77YgY_003D, ICurve _0023_003DzaTmo4gMdLDIvZ_COUw7mxgs_003D, double _0023_003DzebV_0024Ttc_003D, bool _0023_003Dz01ItpmNP8rlW, bool _0023_003DzCJkr8nY_003D, int[] _0023_003Dziidc4_0024c_003D, int[] _0023_003Dz09EWsmU_003D, int[] _0023_003DzrSnGkp0_003D)
			: base(_0023_003DzlY77YgY_003D)
		{
			_0023_003Dz68bspubRg5a7 = _0023_003DzaTmo4gMdLDIvZ_COUw7mxgs_003D;
			_0023_003DzQu508mcPiFnj = _0023_003DzebV_0024Ttc_003D;
			_0023_003Dzb8JguMU_003D = _0023_003Dz01ItpmNP8rlW;
			_0023_003Dz0u7IH4E_003D = _0023_003DzCJkr8nY_003D;
			_0023_003DzwUbaHtM_003D = _0023_003Dziidc4_0024c_003D?.ToArray();
			_0023_003Dzg_0024_0024HtRw_003D = _0023_003Dz09EWsmU_003D?.ToArray();
			_0023_003DzMqZZWVg_003D = _0023_003DzrSnGkp0_003D?.ToArray();
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Toolpath.Motion[][], IEnumerable<Toolpath.Motion[]>> _0023_003Dzi9g4M9xuhTmzCBl8Lg_003D_003D;

		public static Func<Toolpath.Motion[], IEnumerable<Toolpath.Motion>> _0023_003Dz2VQcCla42nyE5bVn2w_003D_003D;

		public static Predicate<IList<Line>> _0023_003Dz5IcUKau5JqzkB_yJiw_003D_003D;

		public static Func<IList<Point3D[]>, int> _0023_003DzorTco1QMddGv7MNh9w_003D_003D;

		public static Func<List<Tuple<Point3D[], Point3D[]>>, Tuple<Point3D[], Point3D[]>[]> _0023_003DzgTtYpfG3F6GOYiFYlA_003D_003D;

		public static Func<List<Point3D>, Point3D[]> _0023_003DzsW0uNWm4_0024_6PMNLiCQ_003D_003D;

		public static Func<Line, Point3D[]> _0023_003Dzq2R9ubPqYE01l89flw_003D_003D;

		public static Func<IList<Line>, Point3D[][]> _0023_003DzQoIyPPL_tvZM231Wdw_003D_003D;

		public static Func<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003Dze9C0W7IzRd18rkxCAA_003D_003D;

		public static Func<(Point3D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D), Point3D> _0023_003Dzv83ITtTo8t4_b_0024LSdg_003D_003D;

		internal IEnumerable<Toolpath.Motion[]> _0023_003DzI_0024yQirfjsdFuWQrLx7pxHlgl4CYG(Toolpath.Motion[][] _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}

		internal IEnumerable<Toolpath.Motion> _0023_003DzRiPmS8kBo6S18De6019QMfHUASkE(Toolpath.Motion[] _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}

		internal bool _0023_003Dz4h3netlJN_isIryqCVujKKY_003D(IList<Line> _0023_003DzkKfJheA_003D)
		{
			return _0023_003DzkKfJheA_003D.Count == 0;
		}

		internal int _0023_003DzFxQmJZSvfxKtdLG51Pvv_0024Bo_003D(IList<Point3D[]> _0023_003DzcDEsV8s_003D)
		{
			return _0023_003DzcDEsV8s_003D.Count;
		}

		internal Tuple<Point3D[], Point3D[]>[] _0023_003DzA2Y_j0o9EfPr1XN22GoITCI_003D(List<Tuple<Point3D[], Point3D[]>> _0023_003Dzsuiz4uo_003D)
		{
			return _0023_003Dzsuiz4uo_003D.ToArray();
		}

		internal Point3D[] _0023_003DzOTjWAht1L3IJN1EabLmC7H0_003D(List<Point3D> _0023_003DzcDEsV8s_003D)
		{
			return _0023_003DzcDEsV8s_003D.ToArray();
		}

		internal Point3D[][] _0023_003Dz9ufd_OhdVUc_0024hTla_YgE0L8_003D(IList<Line> _0023_003DzcDEsV8s_003D)
		{
			return _0023_003DzcDEsV8s_003D.Select((Line _0023_003DzQ9zpGF0_003D) => new Point3D[2] { _0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint }).ToArray();
		}

		internal Point3D[] _0023_003Dzl4Tgqzy4Qr_0024HVvrNazR0ErA_003D(Line _0023_003DzQ9zpGF0_003D)
		{
			return new Point3D[2] { _0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint };
		}

		internal _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzvo2ykBBS1rC6Qt_j_0024AWtnuYf_bq4(Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Item1;
		}

		internal Point3D _0023_003DzzvIm_0024kBZdsb9dNjY_XDYVlJJRjrk((Point3D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D) _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D.Item1;
		}
	}

	private sealed class _0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D
	{
		public Vector3D _0023_003DzBzWQcUMjtjAy;

		internal int _0023_003DzHEhfDQtobGNUEGayxA_003D_003D(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D)
		{
			return Vector3D.Dot(_0023_003DzFj_0024IqDQ_003D, _0023_003DzBzWQcUMjtjAy).CompareTo(Vector3D.Dot(_0023_003DzjdeMMkk_003D, _0023_003DzBzWQcUMjtjAy));
		}
	}

	internal enum _0023_003DzdHAEsWFt2rbg
	{

	}

	private sealed class _0023_003DzfEmmg0JhADLtN1eEqJZFBuA_003D
	{
		public IList<Point3D[]> _0023_003DzcDEsV8s_003D;

		public int _0023_003DzTSeNR8Q_003D;

		public Func<_0023_003Dz0wzeWOGJZnQF, bool> _0023_003DzzaljjvyD9N9t;

		public Func<_0023_003Dz0wzeWOGJZnQF, double> _0023_003DzdT8kPTzaWkIC;

		public Func<_0023_003Dz0wzeWOGJZnQF, bool> _0023_003Dz9R7N_9BeE3W4;

		public Func<_0023_003Dz0wzeWOGJZnQF, bool> _0023_003DzlrnbHTMW4VTg;

		internal bool _0023_003DzVRjWQZ9V9n4uJPDrREpH1AY_003D(_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D)
		{
			return _0023_003DzHPC6WX8_003D._0023_003Dz68bspubRg5a7 == ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7;
		}

		internal double _0023_003DziRbEB8TtAmltEY3P57mwdqY_003D(_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D)
		{
			return _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(_0023_003DzHPC6WX8_003D._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7.Domain.High);
		}

		internal bool _0023_003DzeqRoBw_0024sCD_3jGl7ip9rfbg_003D(_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D)
		{
			return _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(_0023_003DzHPC6WX8_003D._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7.Domain.High) < 0.0;
		}

		internal bool _0023_003DzlTvGYa4oEMT1AB_0024bTDUMQ8c_003D(_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D)
		{
			return _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(_0023_003DzHPC6WX8_003D._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D][_0023_003DzcDEsV8s_003D[_0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7.Domain.High) < 0.0;
		}
	}

	private sealed class _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D
	{
		public int _0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D;

		public double _0023_003DzVOaALZGxGitqkc5v8Q_003D_003D;

		public int _0023_003Dzi18jddkUzvPl97oz_uZpeyQ_003D;

		public double _0023_003DzEGKj_0024SNUUihi;

		public devDept.Eyeshot.Entities.Region _0023_003DzFDwqpgU_003D;

		internal void _0023_003DzXxTv0tYDZL6FX01VgQ_003D_003D(Line _0023_003DzUBZd570_003D)
		{
			if (_0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D % 2 == 0)
			{
				_0023_003DzUBZd570_003D.Translate(new Vector3D(2.0 * _0023_003DzVOaALZGxGitqkc5v8Q_003D_003D * (double)_0023_003Dzi18jddkUzvPl97oz_uZpeyQ_003D, 1.5 * _0023_003DzEGKj_0024SNUUihi * (double)_0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D, _0023_003DzFDwqpgU_003D.BoxMin.Z));
			}
			else
			{
				_0023_003DzUBZd570_003D.Translate(new Vector3D(2.0 * _0023_003DzVOaALZGxGitqkc5v8Q_003D_003D * (double)_0023_003Dzi18jddkUzvPl97oz_uZpeyQ_003D + (double)Math.Sign((double)_0023_003Dzi18jddkUzvPl97oz_uZpeyQ_003D + 0.5) * _0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, 1.5 * _0023_003DzEGKj_0024SNUUihi * (double)_0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D, _0023_003DzFDwqpgU_003D.BoxMin.Z));
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private cutDirectionType _0023_003DzgjjlW4rI1nyGBaUBFqJI2wQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzF2xcAz1I8Yid3obdPCFymFNrDAgSSdDo6A_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995305);

	protected EndMill cutter;

	protected Color tessellationColor = Color.DarkOrchid;

	protected GeometryBase geometry;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Toolpath _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzljIINR0udPhCcaaeDF_HD3s_003D;

	protected double stepOver;

	protected double stepDown;

	protected Interval zRange;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzWnGrJ407tsUBDfwbuGn_0024yRb9rfLX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzpoZknoM_0024CpBQbo884t7DF4qIR_qp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Lead _0023_003DzZnwnlnbOZCOlsWRAonPzkos_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Lead _0023_003Dza5pPIiq8jJFiieRyh5p0NCo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Lead _0023_003DzNuruOezTv_0024aT1raWPxNBSdA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Lead _0023_003DzWQ7J86fU7Toi6Bq1Mwt2MvDKjQ0G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Ramp _0023_003DzihoMf3HLbrT3LTUB1sSGcOY_003D;

	protected double tolerance;

	protected Ramp pocketRamp;

	public Ramp OpenContoursRamp;

	protected Ramp fallbackRamp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzx9hQv8LGOi2V;

	protected const string ComputingOffsetsText = "Computing offsets...";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzDOhy2axZcCW3uVD72j_gWiI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected Setup _0023_003Dz9cS3uG0_003D;

	protected double DefaultHelixRampAngle = 0.05;

	public cutDirectionType CutDirectionMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzgjjlW4rI1nyGBaUBFqJI2wQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzgjjlW4rI1nyGBaUBFqJI2wQ_003D = value;
		}
	}

	public string ComputingPassesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF2xcAz1I8Yid3obdPCFymFNrDAgSSdDo6A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzF2xcAz1I8Yid3obdPCFymFNrDAgSSdDo6A_003D_003D = value;
		}
	}

	public EndMill Tool => cutter;

	public Entity[] Tessellation => geometry?.GetTessellation(_0023_003Dz9cS3uG0_003D, tessellationColor);

	public Entity ClearancePlane => GetClearancePlane(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995412));

	public Entity RetractPlane => GetRetractPlane(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995398));

	public Entity TopPlane => GetTopPlane(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995382));

	public Entity BottomPlane => GetBottomPlane(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995362));

	public Toolpath Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
	}

	public double RadialStockToLeave
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzljIINR0udPhCcaaeDF_HD3s_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzljIINR0udPhCcaaeDF_HD3s_003D = value;
		}
	}

	public double StepOver => stepOver;

	public double StepDown => stepDown;

	public double RetractHeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWnGrJ407tsUBDfwbuGn_0024yRb9rfLX;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWnGrJ407tsUBDfwbuGn_0024yRb9rfLX = value;
		}
	}

	public double ClearanceHeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpoZknoM_0024CpBQbo884t7DF4qIR_qp;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpoZknoM_0024CpBQbo884t7DF4qIR_qp = value;
		}
	}

	public double Speed
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D = value;
		}
	}

	public double Feed
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D = value;
		}
	}

	public Lead LeadIn
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZnwnlnbOZCOlsWRAonPzkos_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZnwnlnbOZCOlsWRAonPzkos_003D = value;
		}
	}

	public Lead LeadOut
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dza5pPIiq8jJFiieRyh5p0NCo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dza5pPIiq8jJFiieRyh5p0NCo_003D = value;
		}
	}

	public Lead LeadInOpen
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNuruOezTv_0024aT1raWPxNBSdA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzNuruOezTv_0024aT1raWPxNBSdA_003D = value;
		}
	}

	public Lead LeadOutOpen
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWQ7J86fU7Toi6Bq1Mwt2MvDKjQ0G;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWQ7J86fU7Toi6Bq1Mwt2MvDKjQ0G = value;
		}
	}

	public virtual Ramp Ramp
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzihoMf3HLbrT3LTUB1sSGcOY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzihoMf3HLbrT3LTUB1sSGcOY_003D = value;
		}
	}

	public double Tolerance
	{
		get
		{
			return tolerance;
		}
		set
		{
			if (value > 0.0)
			{
				tolerance = value;
				_0023_003Dzx9hQv8LGOi2V = tolerance / 10.0;
			}
		}
	}

	protected Machining(Setup setup, EndMill cutter, GeometryBase geometry)
		: this(setup, cutter, geometry, default(Interval), 0.0)
	{
	}

	protected Machining(Setup setup, EndMill cutter, GeometryBase geometry, Interval zRange, double stepDown)
	{
		_0023_003Dz9cS3uG0_003D = setup;
		this.geometry = geometry;
		this.geometry._0023_003DztGdcVOA_003D(setup);
		this.cutter = cutter;
		if (!cutter.IsBull() && !cutter.IsBall() && !cutter.IsFlat())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995267));
		}
		this.stepDown = stepDown;
		this.zRange = zRange;
		if (zRange.IsDecreasing)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995442));
		}
		Speed = cutter.Speed;
		Feed = cutter.Feed;
		Tolerance = 0.01 * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, setup.Units);
		EstimateSafetyHeights();
		double defaultRampClearanceHeight = GetDefaultRampClearanceHeight(cutter);
		OpenContoursRamp = new PlungeRamp(defaultRampClearanceHeight);
		fallbackRamp = new PlungeRamp(defaultRampClearanceHeight);
		pocketRamp = OpenContoursRamp;
		Ramp = OpenContoursRamp;
		LeadIn = new StraightLead(GetDefaultStraightTangentLeadLength(cutter), perp: false);
	}

	internal void _0023_003DzijhYAd8_003D(Toolpath _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private protected _0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003DzXT4sGPyMpoH6()
	{
		double _0023_003DzGcl_0024E9o_003D = geometry.GetBoxSize(_0023_003Dz9cS3uG0_003D).Z * 1.1;
		if (cutter._0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.ball)
		{
			return new _0023_003DzJA0CTAQQStwjoW3h5BJ2j2I_003D(cutter.Diameter + 2.0 * RadialStockToLeave, _0023_003DzGcl_0024E9o_003D);
		}
		if (cutter._0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.bull)
		{
			return new _0023_003Dz0t5Y4F98h5VKXTV0f5KBl_0024o_003D(cutter.Diameter + 2.0 * RadialStockToLeave, cutter.CornerRadius + RadialStockToLeave, _0023_003DzGcl_0024E9o_003D);
		}
		return new _0023_003DzIllBES2_0024wdU5qrD4Q_0024wUWMk_003D(cutter.Diameter + 2.0 * RadialStockToLeave, _0023_003DzGcl_0024E9o_003D);
	}

	private void _0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(Toolpath.Motion[][][] _0023_003DzySVR620_003D, double _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D)
	{
		List<Toolpath.Motion> list = new List<Toolpath.Motion>();
		if (_0023_003DzDOhy2axZcCW3uVD72j_gWiI_003D)
		{
			list.AddRange(_0023_003DzySVR620_003D.SelectMany((Toolpath.Motion[][] _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D).SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzRiPmS8kBo6S18De6019QMfHUASkE));
			_0023_003DzijhYAd8_003D(new Toolpath(list, cutter.Number)
			{
				Transformation = _0023_003Dz9cS3uG0_003D.Transformation
			});
			return;
		}
		Point3D point3D = null;
		int num = _0023_003DzySVR620_003D.Length;
		for (int num2 = 0; num2 < num; num2++)
		{
			Toolpath.Motion[][] array = _0023_003DzySVR620_003D[num2];
			if (array == null || array.Length < 1)
			{
				continue;
			}
			int num3 = array.Length;
			for (int num4 = 0; num4 < num3; num4++)
			{
				Toolpath.Motion[] array2 = array[num4];
				Point3D point3D2 = (Point3D)array2[0].StartPoint.Clone();
				Point3D point3D3 = new Point3D(point3D2.X, point3D2.Y, RetractHeight);
				Point3D point3D4 = null;
				if (_0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D > 0.0)
				{
					point3D4 = new Point3D(point3D3.X, point3D3.Y, point3D2.Z + _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D);
				}
				if (point3D != null)
				{
					list.Add(new Toolpath.LinearMotion((Point3D)point3D.Clone(), (Point3D)point3D3.Clone(), motionType.G00, Speed, Feed, string.Empty));
					if (_0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D == 0.0)
					{
						list.Add(new Toolpath.LinearMotion((Point3D)point3D3.Clone(), point3D2, motionType.G00, Speed, Feed, string.Empty));
					}
					else
					{
						list.Add(new Toolpath.LinearMotion((Point3D)point3D3.Clone(), (Point3D)point3D4.Clone(), motionType.G00, Speed, Feed, string.Empty));
						list.Add(new Toolpath.LinearMotion((Point3D)point3D4.Clone(), point3D2, motionType.G01, Speed, Feed, string.Empty));
					}
				}
				else
				{
					Point3D point3D5 = new Point3D(point3D2.X, point3D2.Y, ClearanceHeight);
					if (_0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D == 0.0)
					{
						list.Add(new Toolpath.LinearMotion(point3D5, point3D2, motionType.G00, Speed, Feed, string.Empty));
					}
					else
					{
						list.Add(new Toolpath.LinearMotion(point3D5, (Point3D)point3D4.Clone(), motionType.G00, Speed, Feed, string.Empty));
						list.Add(new Toolpath.LinearMotion((Point3D)point3D4.Clone(), point3D2, motionType.G01, Speed, Feed, string.Empty));
					}
				}
				list.AddRange(array2);
				if (num4 < num3 - 1)
				{
					Point3D endPoint = array2.Last().EndPoint;
					point3D = new Point3D(endPoint.X, endPoint.Y, RetractHeight);
					list.Add(new Toolpath.LinearMotion((Point3D)endPoint.Clone(), point3D, motionType.G00, Speed, Feed, string.Empty));
				}
			}
			if (num2 < num - 1)
			{
				Point3D endPoint2 = list.Last().EndPoint;
				point3D = new Point3D(endPoint2.X, endPoint2.Y, RetractHeight);
				list.Add(new Toolpath.LinearMotion((Point3D)endPoint2.Clone(), point3D, motionType.G00, Speed, Feed, string.Empty));
			}
		}
		if (list.Count > 0)
		{
			Point3D endPoint3 = list.Last().EndPoint;
			point3D = new Point3D(endPoint3.X, endPoint3.Y, ClearanceHeight);
			list.Add(new Toolpath.LinearMotion((Point3D)endPoint3.Clone(), point3D, motionType.G00, Speed, Feed, string.Empty));
		}
		Toolpath toolpath = new Toolpath(list, cutter.Number);
		toolpath.Transformation = _0023_003Dz9cS3uG0_003D.Transformation;
		_0023_003DzijhYAd8_003D(toolpath);
	}

	protected void EstimateSafetyHeights(Stock stock = null)
	{
		double num = ((stock == null) ? ((geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z - geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D).Z) / 10.0) : (stock.RangeZ.Length / 10.0));
		if (num == 0.0)
		{
			num = zRange.Length / 10.0;
		}
		RetractHeight = zRange.Max + num * 2.0;
		ClearanceHeight = zRange.Max + num * 5.0;
	}

	protected static devDept.Eyeshot.Entities.Region GetOuterRegion(EndMill cutter, devDept.Eyeshot.Entities.Region stock, Point2D geomBoxMin, Point2D geomBoxMax, double tol, bool offset = false)
	{
		devDept.Eyeshot.Entities.Region region = devDept.Eyeshot.Entities.Region.CreateRectangle(geomBoxMin.X, geomBoxMin.Y, geomBoxMax.X - geomBoxMin.X, geomBoxMax.Y - geomBoxMin.Y);
		devDept.Eyeshot.Entities.Region region2 = stock ?? region;
		if (region2.Plane.Origin.Z != 0.0)
		{
			region2.Translate(0.0, 0.0, 0.0 - region2.Plane.Origin.Z);
		}
		double amount = cutter.Diameter / 2.0;
		region2.Regen(tol);
		if (offset)
		{
			devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(region2.Offset(amount, sharp: true), Plane.XY);
			region3.Regen(tol);
			return region3;
		}
		return region2;
	}

	protected static devDept.Eyeshot.Entities.Region GetOuterRegion(EndMill cutter, devDept.Eyeshot.Entities.Region boundary, devDept.Eyeshot.Entities.Region stock, GeometryBase geometry, Setup setup)
	{
		devDept.Eyeshot.Entities.Region region = devDept.Eyeshot.Entities.Region.CreateRectangle(geometry.GetBoxMin(setup).X, geometry.GetBoxMin(setup).Y, geometry.GetBoxMax(setup).X - geometry.GetBoxMin(setup).X, geometry.GetBoxMax(setup).Y - geometry.GetBoxMin(setup).Y);
		if (boundary != null && stock != null)
		{
			devDept.Eyeshot.Entities.Region[] array = devDept.Eyeshot.Entities.Region.Intersection(boundary, stock);
			if (array.Length != 0)
			{
				return GetTransformedBoundary(array[0], setup);
			}
		}
		return GetTransformedBoundary(boundary ?? stock ?? region, setup);
	}

	public Entity GetRetractPlane(Point3D min, Point3D max, string name = "Retract: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(RetractHeight, name, min, max, Color.DarkKhaki, contentAlignment.TopRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetClearancePlane(Point3D min, Point3D max, string name = "Clearance: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(ClearanceHeight, name, min, max, Color.OrangeRed, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetBottomPlane(Point3D min, Point3D max, string name = "Bottom: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.Low, name, min, max, Color.Blue, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetTopPlane(Point3D min, Point3D max, string name = "Top: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.High, name, min, max, Color.DodgerBlue, contentAlignment.BottomLeft);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetRetractPlane(string name = "Retract: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(RetractHeight, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), Color.DarkKhaki, contentAlignment.TopRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetRetractPlane(Color color, string name = "Retract: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(RetractHeight, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), color, contentAlignment.TopRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetClearancePlane(string name = "Clearance: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(ClearanceHeight, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), Color.OrangeRed, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetClearancePlane(Color color, string name = "Clearance: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(ClearanceHeight, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), color, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetBottomPlane(string name = "Bottom: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.Low, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), Color.Blue, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetBottomPlane(Color color, string name = "Bottom: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.Low, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), color, contentAlignment.BottomRight);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetTopPlane(string name = "Top: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.High, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), Color.DodgerBlue, contentAlignment.BottomLeft);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	public Entity GetTopPlane(Color color, string name = "Top: ")
	{
		MachiningPlane machiningPlane = new MachiningPlane(zRange.High, name, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), color, contentAlignment.BottomLeft);
		machiningPlane.Units = _0023_003Dz9cS3uG0_003D.Units;
		machiningPlane.TransformBy(_0023_003Dz9cS3uG0_003D.Transformation);
		return machiningPlane;
	}

	protected static double[] ComputeStepsZ(double minZ, double maxZ, double stepDown, double tol, double axialStockToLeave)
	{
		if (stepDown <= 0.0)
		{
			return new double[1] { minZ };
		}
		List<double> list = new List<double>();
		int num = 1;
		while (true)
		{
			double num2 = maxZ - (double)num * stepDown;
			if (!(num2 > minZ + tol))
			{
				break;
			}
			list.Add(num2 - axialStockToLeave);
			num++;
		}
		list.Add(minZ - axialStockToLeave);
		return list.ToArray();
	}

	internal static List<_0023_003Dz3ORRwnUaVbd8> _0023_003Dz7VChRYh7zEAu(devDept.Eyeshot.Entities.Region _0023_003DzFDwqpgU_003D, double _0023_003Dz6pajdGM_003D, double _0023_003Dz8uslNzRAwfBK)
	{
		List<IList<Line>> list = _0023_003DzIBirOvc_003D(_0023_003DzFDwqpgU_003D, _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK, (_0023_003DzdHAEsWFt2rbg)0, null);
		List<_0023_003Dz3ORRwnUaVbd8> list2 = new List<_0023_003Dz3ORRwnUaVbd8>(list.Count);
		foreach (IList<Line> item in list)
		{
			_0023_003Dz3ORRwnUaVbd8 _0023_003Dz3ORRwnUaVbd9 = new _0023_003Dz3ORRwnUaVbd8();
			foreach (Line item2 in item)
			{
				_0023_003Dz3ORRwnUaVbd9._0023_003DzGkfwiw0_003D(new _0023_003DzOQm_OJkhw_0024vS(new _0023_003DzmKBPh7nOT6nY(item2.StartPoint.X, item2.StartPoint.Y), new _0023_003DzmKBPh7nOT6nY(item2.EndPoint.X, item2.EndPoint.Y)));
			}
			list2.Add(_0023_003Dz3ORRwnUaVbd9);
		}
		return list2;
	}

	internal static List<IList<Line>> _0023_003DzIBirOvc_003D(devDept.Eyeshot.Entities.Region _0023_003DzFDwqpgU_003D, double _0023_003Dz6pajdGM_003D, double _0023_003Dz8uslNzRAwfBK, _0023_003DzdHAEsWFt2rbg _0023_003DzVTN8X_RiGktX, Point3D _0023_003Dz7uOrsVV7yn6Y)
	{
		if (_0023_003Dz8uslNzRAwfBK <= 0.0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995375));
		}
		if (Math.Abs(_0023_003Dz6pajdGM_003D) >= Math.PI * 2.0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995044));
		}
		if (_0023_003Dz6pajdGM_003D > Math.PI)
		{
			_0023_003Dz6pajdGM_003D -= Math.PI * 2.0;
		}
		else if (_0023_003Dz6pajdGM_003D > Math.PI / 2.0)
		{
			_0023_003Dz6pajdGM_003D -= Math.PI;
		}
		if (_0023_003Dz6pajdGM_003D < -Math.PI)
		{
			_0023_003Dz6pajdGM_003D += Math.PI * 2.0;
		}
		else if (_0023_003Dz6pajdGM_003D < -Math.PI / 2.0)
		{
			_0023_003Dz6pajdGM_003D += Math.PI;
		}
		_0023_003DzFDwqpgU_003D.GetTightBBox(out var boxMin, out var boxMax);
		Point2D point2D = ((_0023_003Dz6pajdGM_003D < 0.0) ? new Point2D(boxMin.X, boxMin.Y) : new Point2D(boxMax.X, boxMin.Y));
		Vector2D axisX = Vector2D.AxisX;
		axisX.TransformBy(new Rotation(_0023_003Dz6pajdGM_003D + Math.PI / 2.0, Vector3D.AxisZ));
		int num = 0;
		if (_0023_003Dz7uOrsVV7yn6Y != null)
		{
			Line line = new Line(0.0, 0.0, 1.0, 0.0);
			line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ);
			line.Translate(_0023_003Dz7uOrsVV7yn6Y.X, _0023_003Dz7uOrsVV7yn6Y.Y);
			Vector2D asVector = (point2D - point2D.ProjectTo(new Segment2D(line.StartPoint, line.EndPoint))).AsVector;
			double num2 = asVector.Length % _0023_003Dz8uslNzRAwfBK;
			double num3 = -1.0 * ((Vector2D.Dot(asVector, axisX) > 0.0) ? num2 : (_0023_003Dz8uslNzRAwfBK - num2));
			point2D += num3 * axisX;
			num = (int)Math.Round(point2D.DistanceTo(new Segment2D(line.StartPoint, line.EndPoint)) / _0023_003Dz8uslNzRAwfBK);
			if (_0023_003Dz6pajdGM_003D < 0.0)
			{
				boxMin.X = point2D.X;
				boxMin.Y = point2D.Y;
			}
			else
			{
				boxMax.X = point2D.X;
				boxMin.Y = point2D.Y;
			}
		}
		double num4 = Math.Cos(Math.Abs(_0023_003Dz6pajdGM_003D)) * (boxMax.Y - boxMin.Y);
		double num5 = Math.Sin(Math.Abs(_0023_003Dz6pajdGM_003D)) * (boxMax.X - boxMin.X);
		double num6 = Math.Cos(Math.Abs(_0023_003Dz6pajdGM_003D)) * (boxMax.X - boxMin.X);
		double num7 = Math.Sin(Math.Abs(_0023_003Dz6pajdGM_003D)) * (boxMax.Y - boxMin.Y);
		double num8 = num4 + num5;
		double x = num6 + num7;
		double dx = 0.0 - ((_0023_003Dz6pajdGM_003D < 0.0) ? num7 : num6);
		Line line2 = new Line(0.0, 0.0, x, 0.0);
		line2.Translate(dx, 0.0);
		line2.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ);
		line2.Translate(point2D.X, point2D.Y);
		List<IList<Line>> list = new List<IList<Line>>();
		bool flag = Vector3D.Cross(line2.Tangent, new Vector3D(axisX.X, axisX.Y, 0.0)).Z < 0.0;
		flag = ((num % 2 == 0) ? flag : (!flag));
		if (_0023_003DzVTN8X_RiGktX == (_0023_003DzdHAEsWFt2rbg)1 || _0023_003DzVTN8X_RiGktX == (_0023_003DzdHAEsWFt2rbg)2)
		{
			flag = !flag;
		}
		for (double num9 = 0.0; num9 <= num8; num9 += _0023_003Dz8uslNzRAwfBK)
		{
			Line line3 = (Line)line2.Clone();
			line3.Translate(axisX.X * num9, axisX.Y * num9);
			if (_0023_003DzVTN8X_RiGktX == (_0023_003DzdHAEsWFt2rbg)2 && flag)
			{
				line3.Reverse();
			}
			bool _0023_003Dz0u7IH4E_003D = Vector3D.Dot(Vector3D.Cross(line3.Tangent, new Vector3D(axisX.X, axisX.Y)), _0023_003DzFDwqpgU_003D.Plane.AxisZ) > 0.0;
			IList<Line> list2 = AppendLine(line3, _0023_003DzFDwqpgU_003D);
			if (list2.Count > 0 || _0023_003Dz7uOrsVV7yn6Y != null)
			{
				flag = !flag;
			}
			foreach (Line item in list2)
			{
				if (item.StartPoint is _0023_003Dz0wzeWOGJZnQF _0023_003Dz0wzeWOGJZnQF2)
				{
					_0023_003Dz0wzeWOGJZnQF2._0023_003Dz0u7IH4E_003D = _0023_003Dz0u7IH4E_003D;
				}
				if (item.EndPoint is _0023_003Dz0wzeWOGJZnQF _0023_003Dz0wzeWOGJZnQF3)
				{
					_0023_003Dz0wzeWOGJZnQF3._0023_003Dz0u7IH4E_003D = _0023_003Dz0u7IH4E_003D;
				}
			}
			list.Add(list2);
		}
		list.RemoveAll(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz4h3netlJN_isIryqCVujKKY_003D);
		return list;
	}

	public static LinearPath[] BuildHexHatch(devDept.Eyeshot.Entities.Region reg, double radius)
	{
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2 = new _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D();
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi = radius;
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D = reg;
		List<ICurve> contourList = _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.ContourList;
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D = Math.Cos(Utility.DegToRad(30.0)) * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi;
		List<Line> list = new List<Line>();
		List<Line> list2 = new List<Line>();
		List<Line> list3 = new List<Line>();
		list3.Add(new Line(new Point3D(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, (0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi) / 2.0, 0.0), new Point3D(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi / 2.0, 0.0)));
		list3.Add(new Line(new Point3D(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi / 2.0, 0.0), new Point3D(0.0, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi, 0.0)));
		list3.Add(new Line(new Point3D(0.0, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi, 0.0), new Point3D(0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi / 2.0, 0.0)));
		list3.Add(new Line(new Point3D(0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi / 2.0, 0.0), new Point3D(0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, (0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi) / 2.0, 0.0)));
		list3.Add(new Line(new Point3D(0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, (0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi) / 2.0, 0.0), new Point3D(0.0, 0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi, 0.0)));
		list3.Add(new Line(new Point3D(0.0, 0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi, 0.0), new Point3D(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, (0.0 - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi) / 2.0, 0.0)));
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003Dzi18jddkUzvPl97oz_uZpeyQ_003D = (int)(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.X / (2.0 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D));
		_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D = (int)(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.Y / (1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi));
		list3.ForEach(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzXxTv0tYDZL6FX01VgQ_003D_003D);
		int num = (int)((_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMax.X - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.X) / (2.0 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D)) + 3;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < list3.Count; j++)
			{
				if (j != 0 || i == num - 1)
				{
					Line line = (Line)list3[j].Clone();
					line.Translate((double)(i * 2) * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, 0.0);
					list2.Add(line);
				}
			}
		}
		int num2 = (int)((_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMax.Y - _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.Y) / (1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi)) + 3;
		for (int k = 0; k < num2; k++)
		{
			for (int l = 0; l < list2.Count; l++)
			{
				int index = ((k % 2 != 0) ? (list2.Count - 1 - l) : l);
				if ((list2[index].StartPoint.Y == 1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi * (double)_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D + _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi && k != num2 - 1 && (list2[index].StartPoint.X != list2[2].StartPoint.X || k % 2 != 1)) || (list2[index].EndPoint.Y == 1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi * (double)_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzwmZ51trGs4OIt6N9mHJZZmk_003D + _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi && k != num2 - 1 && (list2[index].StartPoint.X != list2[list2.Count - 1].EndPoint.X || k % 2 != 0)))
				{
					continue;
				}
				Line line2 = (Line)list2[index].Clone();
				if (k % 2 == 0)
				{
					line2.Translate(0.0, (double)k * 1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi);
				}
				else
				{
					line2.Translate(_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzVOaALZGxGitqkc5v8Q_003D_003D, (double)k * 1.5 * _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzEGKj_0024SNUUihi);
				}
				line2.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
				if (boxMax.X < _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.X || boxMin.X > _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMax.X || boxMax.Y < _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMin.Y || boxMin.Y > _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.BoxMax.Y)
				{
					continue;
				}
				bool flag = false;
				foreach (ICurve item in contourList)
				{
					Point3D[] array = line2.IntersectWith(item);
					if (array.Length == 0)
					{
						continue;
					}
					flag = true;
					Line line3 = new Line(line2.StartPoint, array[0]);
					if (_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.IsPointInside(line3.MidPoint))
					{
						list.Add(line3);
					}
					for (int m = 0; m < array.Length - 1; m++)
					{
						Line line4 = new Line(array[m], array[m + 1]);
						if (_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.IsPointInside(line4.MidPoint))
						{
							list.Add(line4);
						}
					}
					Line line5 = new Line(array[^1], line2.EndPoint);
					if (_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.IsPointInside(line5.MidPoint))
					{
						list.Add(line5);
					}
				}
				if (!flag && (_0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.IsPointInside(line2.StartPoint) || _0023_003DztY60y8Vi2PrfvwwOnAKXFe0_003D2._0023_003DzFDwqpgU_003D.IsPointInside(line2.EndPoint)))
				{
					list.Add(line2);
				}
			}
		}
		LinearPath[] array2 = new LinearPath[list.Count];
		for (int n = 0; n < list.Count; n++)
		{
			array2[n] = list[n].ConvertToLinearPath();
		}
		return array2;
	}

	internal static double _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(double _0023_003Dz8SEdsjQ_003D, double _0023_003DzKV5V6WI_003D, double _0023_003DzxH4ozIo_003D)
	{
		double num = Math.Min(_0023_003DzKV5V6WI_003D, _0023_003Dz8SEdsjQ_003D);
		double num2 = Math.Min(_0023_003DzxH4ozIo_003D - _0023_003DzKV5V6WI_003D, _0023_003DzxH4ozIo_003D - _0023_003Dz8SEdsjQ_003D);
		double num3 = Math.Min(Math.Abs(_0023_003Dz8SEdsjQ_003D - _0023_003DzKV5V6WI_003D), num + num2);
		if ((_0023_003Dz8SEdsjQ_003D > _0023_003DzKV5V6WI_003D) ^ (num + num2 < Math.Abs(_0023_003Dz8SEdsjQ_003D - _0023_003DzKV5V6WI_003D)))
		{
			return num3;
		}
		return 0.0 - num3;
	}

	internal static Tuple<Point3D[], Point3D[]>[][] _0023_003DzTGXzB_0Mfoxq(IList<IList<Point3D[]>> _0023_003DzyIUKu5w_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		Tuple<Point3D[], Point3D[]>[][] array = new Tuple<Point3D[], Point3D[]>[_0023_003DzyIUKu5w_003D.Count][];
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
		{
			array[i] = new Tuple<Point3D[], Point3D[]>[_0023_003DzyIUKu5w_003D[i].Count];
			for (int j = 0; j < _0023_003DzyIUKu5w_003D[i].Count; j++)
			{
				Point3D[] array2 = _0023_003DzyIUKu5w_003D[i][j];
				Point3D[] item = null;
				if (j == _0023_003DzyIUKu5w_003D[i].Count - 1 && i < _0023_003DzyIUKu5w_003D.Count - 1 && array2.Length != 0 && _0023_003DzyIUKu5w_003D[i + 1].Count > 0)
				{
					item = new Point3D[2]
					{
						array2[^1],
						_0023_003DzyIUKu5w_003D[i + 1][0][0]
					};
				}
				array[i][j] = new Tuple<Point3D[], Point3D[]>(array2, item);
			}
		}
		return array;
	}

	internal static Tuple<Point3D[], Point3D[]>[][] _0023_003Dz2NOuDBhF9Cmo(IList<IList<Point3D[]>> _0023_003DzyIUKu5w_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		Tuple<Point3D[], Point3D[]>[][] array = new Tuple<Point3D[], Point3D[]>[_0023_003DzyIUKu5w_003D.Count][];
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
		{
			array[i] = new Tuple<Point3D[], Point3D[]>[_0023_003DzyIUKu5w_003D[i].Count];
			for (int j = 0; j < _0023_003DzyIUKu5w_003D[i].Count; j++)
			{
				Point3D[] item = _0023_003DzyIUKu5w_003D[i][j];
				array[i][j] = new Tuple<Point3D[], Point3D[]>(item, null);
			}
		}
		return array;
	}

	private static void _0023_003Dz7_00245MgbAhKwFs(IList<IList<Point3D[]>> _0023_003DzyIUKu5w_003D)
	{
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
		{
			for (int j = 0; j < _0023_003DzyIUKu5w_003D[i].Count; j++)
			{
				((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[i][j][0])._0023_003DzwUbaHtM_003D = new int[2] { i, j };
				((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[i][j][_0023_003DzyIUKu5w_003D[i][j].Length - 1])._0023_003DzwUbaHtM_003D = new int[2] { i, j };
			}
		}
	}

	internal static Tuple<Point3D[], Point3D[]>[][] _0023_003DzR8z_z2zqncJX(IList<IList<Point3D[]>> _0023_003DzyIUKu5w_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		_0023_003Dz7_00245MgbAhKwFs(_0023_003DzyIUKu5w_003D);
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
		{
			_0023_003DzfEmmg0JhADLtN1eEqJZFBuA_003D CS_0024_003C_003E8__locals45 = new _0023_003DzfEmmg0JhADLtN1eEqJZFBuA_003D();
			CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D = _0023_003DzyIUKu5w_003D[i];
			CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D = 0;
			while (CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D < CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D.Count())
			{
				if (((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7 != null)
				{
					List<_0023_003Dz0wzeWOGJZnQF> list = new List<_0023_003Dz0wzeWOGJZnQF>();
					for (int j = CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D; j < CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D.Count(); j++)
					{
						list.Add((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[i][j][0]);
					}
					if (i < _0023_003DzyIUKu5w_003D.Count - 1)
					{
						for (int k = 0; k < _0023_003DzyIUKu5w_003D[i + 1].Count(); k++)
						{
							list.Add((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[i + 1][k][0]);
						}
					}
					list = list.Where(CS_0024_003C_003E8__locals45._0023_003DzVRjWQZ9V9n4uJPDrREpH1AY_003D).ToList();
					list = list.OrderBy(CS_0024_003C_003E8__locals45._0023_003DziRbEB8TtAmltEY3P57mwdqY_003D).ToList();
					_0023_003Dz0wzeWOGJZnQF _0023_003Dz0wzeWOGJZnQF2 = null;
					if (((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz0u7IH4E_003D)
					{
						_0023_003Dz0wzeWOGJZnQF[] array = list.SkipWhile((_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D) => _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(_0023_003DzHPC6WX8_003D._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7.Domain.High) < 0.0).ToArray();
						if (array.Length != 0)
						{
							_0023_003Dz0wzeWOGJZnQF2 = array[0];
						}
					}
					else
					{
						_0023_003Dz0wzeWOGJZnQF[] array2 = list.TakeWhile((_0023_003Dz0wzeWOGJZnQF _0023_003DzHPC6WX8_003D) => _0023_003DzQCnT45xDfDFupb9bqA_003D_003D(_0023_003DzHPC6WX8_003D._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzQu508mcPiFnj, ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dz68bspubRg5a7.Domain.High) < 0.0).ToArray();
						if (array2.Length != 0)
						{
							_0023_003Dz0wzeWOGJZnQF2 = array2.Last();
						}
					}
					if (_0023_003Dz0wzeWOGJZnQF2 != null && (_0023_003Dz0wzeWOGJZnQF2._0023_003DzwUbaHtM_003D[0] != ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][0])._0023_003DzwUbaHtM_003D[0] || _0023_003Dz0wzeWOGJZnQF2._0023_003DzwUbaHtM_003D[1] != ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][0])._0023_003DzwUbaHtM_003D[1]))
					{
						((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003Dzg_0024_0024HtRw_003D = _0023_003Dz0wzeWOGJZnQF2._0023_003DzwUbaHtM_003D;
						_0023_003Dz0wzeWOGJZnQF2._0023_003DzMqZZWVg_003D = ((_0023_003Dz0wzeWOGJZnQF)CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D][CS_0024_003C_003E8__locals45._0023_003DzcDEsV8s_003D[CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D].Length - 1])._0023_003DzwUbaHtM_003D;
					}
				}
				CS_0024_003C_003E8__locals45._0023_003DzTSeNR8Q_003D++;
			}
		}
		List<Point3D[]> list2 = new List<Point3D[]>();
		for (int num = 0; num < _0023_003DzyIUKu5w_003D.Count; num++)
		{
			for (int num2 = 0; num2 < _0023_003DzyIUKu5w_003D[num].Count; num2++)
			{
				if (((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[num][num2][0])._0023_003DzMqZZWVg_003D[0] == -1)
				{
					list2.Add(_0023_003DzyIUKu5w_003D[num][num2]);
				}
			}
		}
		List<Tuple<Point3D[], Point3D[]>>[] array3 = new List<Tuple<Point3D[], Point3D[]>>[list2.Count];
		int num3 = _0023_003DzyIUKu5w_003D.Select((IList<Point3D[]> _0023_003DzcDEsV8s_003D) => _0023_003DzcDEsV8s_003D.Count).Sum();
		for (int num4 = 0; num4 < array3.Length; num4++)
		{
			Point3D[] array4 = list2[num4];
			array3[num4] = new List<Tuple<Point3D[], Point3D[]>>();
			int num5 = 0;
			while (((_0023_003Dz0wzeWOGJZnQF)array4[^1])._0023_003Dzg_0024_0024HtRw_003D[0] != -1 && num5 < num3)
			{
				_0023_003Dz0wzeWOGJZnQF _0023_003Dz0wzeWOGJZnQF3 = (_0023_003Dz0wzeWOGJZnQF)array4[^1];
				if (_0023_003Dz0wzeWOGJZnQF3._0023_003DzwUbaHtM_003D[0] != ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[0]][_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[1]][0])._0023_003DzMqZZWVg_003D[0] || _0023_003Dz0wzeWOGJZnQF3._0023_003DzwUbaHtM_003D[1] != ((_0023_003Dz0wzeWOGJZnQF)_0023_003DzyIUKu5w_003D[_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[0]][_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[1]][0])._0023_003DzMqZZWVg_003D[1])
				{
					break;
				}
				Point3D[] array5 = _0023_003DzyIUKu5w_003D[_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[0]][_0023_003Dz0wzeWOGJZnQF3._0023_003Dzg_0024_0024HtRw_003D[1]];
				ICurve curve = null;
				if ((_0023_003Dz0wzeWOGJZnQF3._0023_003Dz0u7IH4E_003D && !_0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D) || (!_0023_003Dz0wzeWOGJZnQF3._0023_003Dz0u7IH4E_003D && _0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D))
				{
					curve = _0023_003DzX2qknxcgMnPa(_0023_003Dz0wzeWOGJZnQF3._0023_003Dz68bspubRg5a7, _0023_003Dz0wzeWOGJZnQF3, array5[0], _0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D);
					if (_0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D)
					{
						curve.Reverse();
					}
				}
				else
				{
					curve = _0023_003DzX2qknxcgMnPa(_0023_003Dz0wzeWOGJZnQF3._0023_003Dz68bspubRg5a7, array5[0], _0023_003Dz0wzeWOGJZnQF3, _0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D);
					if (!_0023_003Dz0wzeWOGJZnQF3._0023_003Dzb8JguMU_003D)
					{
						curve.Reverse();
					}
				}
				((Entity)curve).Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				array3[num4].Add(new Tuple<Point3D[], Point3D[]>(array4, ((Entity)curve).Vertices));
				array4 = array5;
				num5++;
			}
			array3[num4].Add(new Tuple<Point3D[], Point3D[]>(array4, null));
		}
		return array3.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzA2Y_j0o9EfPr1XN22GoITCI_003D).ToArray();
	}

	private static Point3D[][] _0023_003Dzz9WRByjL7XiA(IList<IList<Tuple<Point3D[], Point3D[]>>> _0023_003DzWFELMytNNPze)
	{
		double num = 1E-24;
		List<Point3D>[] array = new List<Point3D>[_0023_003DzWFELMytNNPze.Count];
		for (int i = 0; i < _0023_003DzWFELMytNNPze.Count; i++)
		{
			array[i] = new List<Point3D>();
			for (int j = 0; j < _0023_003DzWFELMytNNPze[i].Count; j++)
			{
				if (array[i].Count > 0 && Point3D.DistanceSquared(_0023_003DzWFELMytNNPze[i][j].Item1[0], array[i][array[i].Count - 1]) < num)
				{
					array[i].AddRange(_0023_003DzWFELMytNNPze[i][j].Item1.Skip(1));
				}
				else
				{
					array[i].AddRange(_0023_003DzWFELMytNNPze[i][j].Item1);
				}
				if (j < _0023_003DzWFELMytNNPze[i].Count - 1)
				{
					array[i].AddRange(_0023_003DzWFELMytNNPze[i][j].Item2.Skip(1));
				}
			}
		}
		return array.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzOTjWAht1L3IJN1EabLmC7H0_003D).ToArray();
	}

	public static Point3D[][] BuildSmartHatch(devDept.Eyeshot.Entities.Region reg, double angle, double stepOver, double deviation, Point3D basePoint = null)
	{
		if (reg == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994997));
		}
		reg.Regen(deviation);
		return _0023_003Dzz9WRByjL7XiA(_0023_003DzR8z_z2zqncJX((from _0023_003DzcDEsV8s_003D in _0023_003DzIBirOvc_003D(reg, angle, stepOver, (_0023_003DzdHAEsWFt2rbg)2, basePoint)
			select _0023_003DzcDEsV8s_003D.Select((Line _0023_003DzQ9zpGF0_003D) => new Point3D[2] { _0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint }).ToArray()).ToArray(), deviation));
	}

	internal static Point3D[][] _0023_003DzEl883OY_003D(devDept.Eyeshot.Entities.Region _0023_003DzFDwqpgU_003D, double _0023_003Dz6pajdGM_003D, double _0023_003Dz8uslNzRAwfBK, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		if (_0023_003DzFDwqpgU_003D == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994997));
		}
		List<List<Point3D>> list = new List<List<Point3D>>();
		_0023_003DzFDwqpgU_003D.Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
		List<IList<Line>> list2 = _0023_003DzIBirOvc_003D(_0023_003DzFDwqpgU_003D, _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK, (_0023_003DzdHAEsWFt2rbg)0, null);
		int num = 0;
		list.Add(new List<Point3D>());
		for (int i = 0; i < list2.Count; i++)
		{
			if (i % 2 != 0)
			{
				foreach (Line item in list2[i])
				{
					item.Reverse();
				}
				if (i > 0 && list2[i].Count != 0 && list2[i - 1].Count != 0)
				{
					ICurve curve = _0023_003DzX2qknxcgMnPa((ICurve)_0023_003DzFDwqpgU_003D.ContourList[0].Clone(), (Point3D)list2[i - 1][list2[i - 1].Count - 1].EndPoint.Clone(), (Point3D)list2[i][list2[i].Count - 1].StartPoint.Clone(), _0023_003DzeFgvav_PY92dnWAOVg_003D_003D: false);
					if (curve.IntersectWith(new Line((Point3D)list2[i][list2[i].Count - 1].StartPoint.Clone(), (Point3D)list2[i][0].EndPoint.Clone())).Length > 1 || curve.IntersectWith(new Line((Point3D)list2[i - 1][list2[i - 1].Count - 1].EndPoint.Clone(), (Point3D)list2[i - 1][0].StartPoint.Clone())).Length > 1)
					{
						num++;
						list.Add(new List<Point3D>());
					}
					else
					{
						((Entity)curve).Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
						if (((Entity)curve).Vertices.Length > 2)
						{
							for (int j = 1; j < ((Entity)curve).Vertices.Length - 1; j++)
							{
								list[num].Add(((Entity)curve).Vertices[j]);
							}
						}
					}
				}
				if (list2[i].Count > 1)
				{
					for (int num2 = list2[i].Count - 1; num2 >= 0; num2--)
					{
						list[num].Add(list2[i][num2].StartPoint);
						list[num].Add(list2[i][num2].EndPoint);
						if (num2 > 0)
						{
							num++;
							list.Add(new List<Point3D>());
						}
					}
				}
				else if (list2[i].Count == 1)
				{
					list[num].Add(list2[i][0].StartPoint);
					list[num].Add(list2[i][0].EndPoint);
				}
				continue;
			}
			if (i > 0 && list2[i].Count != 0 && list2[i - 1].Count != 0)
			{
				ICurve curve2 = _0023_003DzX2qknxcgMnPa((ICurve)_0023_003DzFDwqpgU_003D.ContourList[0].Clone(), (Point3D)list2[i][0].StartPoint.Clone(), (Point3D)list2[i - 1][0].EndPoint.Clone(), _0023_003DzeFgvav_PY92dnWAOVg_003D_003D: false);
				curve2.Reverse();
				if (curve2.IntersectWith(new Line((Point3D)list2[i][list2[i].Count - 1].EndPoint.Clone(), (Point3D)list2[i][0].StartPoint.Clone())).Length > 1 || curve2.IntersectWith(new Line((Point3D)list2[i - 1][list2[i - 1].Count - 1].StartPoint.Clone(), (Point3D)list2[i - 1][0].EndPoint.Clone())).Length > 1)
				{
					num++;
					list.Add(new List<Point3D>());
				}
				else
				{
					((Entity)curve2).Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
					if (((Entity)curve2).Vertices.Length > 2)
					{
						for (int k = 1; k < ((Entity)curve2).Vertices.Length - 1; k++)
						{
							list[num].Add(((Entity)curve2).Vertices[k]);
						}
					}
				}
			}
			if (list2[i].Count > 1)
			{
				for (int l = 0; l < list2[i].Count; l++)
				{
					list[num].Add(list2[i][l].StartPoint);
					list[num].Add(list2[i][l].EndPoint);
					if (l < list2[i].Count - 1)
					{
						num++;
						list.Add(new List<Point3D>());
					}
				}
			}
			else if (list2[i].Count == 1)
			{
				list[num].Add(list2[i][0].StartPoint);
				list[num].Add(list2[i][0].EndPoint);
			}
		}
		Point3D[][] array = new Point3D[list.Count][];
		for (int m = 0; m < list.Count; m++)
		{
			array[m] = list[m].ToArray();
		}
		return array;
	}

	protected internal static IList<Line> AppendLine(Line line, devDept.Eyeshot.Entities.Region reg)
	{
		_0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D _0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D2 = new _0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D();
		Line line2 = (Line)line.Clone();
		line2.Translate(0.0, 0.0, reg.BoxMin.Z);
		List<Line> list = new List<Line>();
		List<Point3D> list2 = new List<Point3D>();
		list2.Add((Point3D)line2.StartPoint.Clone());
		List<ICurve> contourList = reg.ContourList;
		for (int i = 0; i < contourList.Count; i++)
		{
			ICurve curve = contourList[i];
			Point3D[] array = line2.IntersectWith(curve);
			for (int j = 0; j < array.Length; j++)
			{
				_0023_003Dz0wzeWOGJZnQF item = new _0023_003Dz0wzeWOGJZnQF((Point3D)array[j].Clone(), curve, i > 0, _0023_003DzCJkr8nY_003D: false);
				list2.Add(item);
			}
		}
		list2.Add((Point3D)line2.EndPoint.Clone());
		_0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D2._0023_003DzBzWQcUMjtjAy = line2.Tangent;
		list2.Sort(_0023_003DzRMEhnopy5nQNn0kzsbM5xsc_003D2._0023_003DzHEhfDQtobGNUEGayxA_003D_003D);
		if (Point3D.Distance(list2[0], list2[1]) < reg.BoxSize.Diagonal * 1E-05)
		{
			list2.RemoveAt((list2[0] is _0023_003Dz0wzeWOGJZnQF) ? 1 : 0);
		}
		if (Point3D.Distance(list2[list2.Count - 2], list2[list2.Count - 1]) < reg.BoxSize.Diagonal * 1E-05)
		{
			list2.RemoveAt((list2[list2.Count - 2] is _0023_003Dz0wzeWOGJZnQF) ? (list2.Count - 1) : (list2.Count - 2));
		}
		for (int k = 0; k < list2.Count - 1; k++)
		{
			list.Add(new Line(list2[k], list2[k + 1]));
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num = 0;
		for (int l = 0; l < list.Count; l++)
		{
			foreach (ICurve contour in reg.contourList)
			{
				contour.ClosestPointTo(list[l].StartPoint, out var t);
				contour.ClosestPointTo(list[l].MidPoint, out var t2);
				if (!(Point3D.Distance(list[l].StartPoint, contour.PointAt(t)) < Utility._0023_003DzheSR8QM7q9ya))
				{
					continue;
				}
				Vector3D direction = line.Direction;
				direction.Normalize();
				double num2 = contour.Domain.Length * 0.0001;
				double num3 = ((t - num2 < contour.Domain.Low) ? (contour.Domain.High - num2) : (t - num2));
				double num4 = ((t + num2 > contour.Domain.High) ? (contour.Domain.Low + num2) : (t + num2));
				Vector3D asVector = (contour.PointAt(num3) - line.StartPoint).AsVector;
				Vector3D asVector2 = (contour.PointAt(num4) - line.StartPoint).AsVector;
				asVector.Normalize();
				asVector2.Normalize();
				double z = Vector3D.Cross(direction, asVector).Z;
				double z2 = Vector3D.Cross(direction, asVector2).Z;
				if (Point3D.Distance(list[l].MidPoint, contour.PointAt(t2)) < Utility._0023_003DzheSR8QM7q9ya)
				{
					if (contour is CompositeCurve compositeCurve)
					{
						foreach (ICurve curve2 in compositeCurve.CurveList)
						{
							if (curve2.IsLinear(1E-12, out var line3) && line3.IsOnAxis(direction, list[l].StartPoint))
							{
								Vector3D asVector3 = (line3.P1 - line3.P0).AsVector;
								asVector3.Normalize();
								double num5 = Vector3D.Dot(direction, asVector3);
								if ((num5 > 0.0 && Point3D.Distance(list[l].StartPoint, line3.P0) < Utility._0023_003DzheSR8QM7q9ya) || (num5 < 0.0 && Point3D.Distance(list[l].StartPoint, line3.P1) < Utility._0023_003DzheSR8QM7q9ya))
								{
									flag3 = true;
									break;
								}
							}
							else if (curve2 is LinearPath { Domain: var domain } linearPath && ((domain._0023_003DzNoPt9TsyzDMJ(num3) && Vector3D.AreParallel(linearPath.TangentAt(num3), list[l].StartTangent)) || (linearPath.Domain._0023_003DzNoPt9TsyzDMJ(num4) && Vector3D.AreParallel(linearPath.TangentAt(num4), list[l].StartTangent))))
							{
								flag3 = true;
								break;
							}
						}
					}
					if (contour is LinearPath linearPath2 && (Vector3D.AreParallel(linearPath2.TangentAt(num4), list[l].StartTangent) || Vector3D.AreParallel(linearPath2.TangentAt(num3), list[l].StartTangent)))
					{
						flag3 = true;
					}
				}
				if (z * z2 > 0.0)
				{
					flag2 = true;
				}
			}
			if (!flag3)
			{
				if (flag4 || num == 0)
				{
					flag = ((!reg.IsPointOnContour(list[l].MidPoint, reg.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg) && !reg.IsPointInside(list[l].MidPoint)) ? (num % 2 == 1) : ((num & 1) == 0));
				}
				else if (flag2)
				{
					flag = !flag;
				}
				if ((flag && num % 2 == 1) || (!flag && num % 2 == 0))
				{
					list.RemoveAt(l);
					l--;
				}
			}
			flag4 = flag3;
			flag3 = false;
			flag2 = false;
			num++;
		}
		for (int m = 0; m < list.Count - 1; m++)
		{
			if (Point3D.Distance(list[m].EndPoint, list[m + 1].StartPoint) < 1E-12)
			{
				list[m + 1].StartPoint = list[m].StartPoint;
				list.RemoveAt(m);
				m--;
			}
		}
		return list;
	}

	private static ICurve _0023_003DzX2qknxcgMnPa(ICurve _0023_003Dzt_m8zV0_003D, Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, bool _0023_003DzeFgvav_PY92dnWAOVg_003D_003D)
	{
		ICurve curve = (ICurve)_0023_003Dzt_m8zV0_003D.Clone();
		if (_0023_003DzeFgvav_PY92dnWAOVg_003D_003D)
		{
			curve.Reverse();
		}
		if (curve is Circle circle)
		{
			curve = new Arc(circle.Plane, circle.Center, circle.Radius, Math.PI * 2.0);
		}
		List<ICurve> list = new List<ICurve>();
		curve.ClosestPointTo(_0023_003DzFj_0024IqDQ_003D, out var t);
		curve.ClosestPointTo(_0023_003DzjdeMMkk_003D, out var t2);
		if (t > t2 && t2 != 0.0 && t != curve.Domain.High)
		{
			ICurve curve2 = (ICurve)curve.Clone();
			ICurve curve3 = (ICurve)curve.Clone();
			curve2.TrimAt(t2, flipSide: false);
			curve3.Reverse();
			curve3.ClosestPointTo(_0023_003DzFj_0024IqDQ_003D, out t);
			curve3.TrimAt(t, flipSide: false);
			curve3.Reverse();
			list.AddRange(curve3.GetIndividualCurves());
			list.AddRange(curve2.GetIndividualCurves());
		}
		else
		{
			ICurve curve4 = (ICurve)curve.Clone();
			curve4.ClosestPointTo(_0023_003DzjdeMMkk_003D, out t2);
			curve4.TrimAt(t2, flipSide: false);
			curve4.Reverse();
			curve4.ClosestPointTo(_0023_003DzFj_0024IqDQ_003D, out t);
			curve4.TrimAt(t, flipSide: false);
			curve4.Reverse();
			list.AddRange(curve4.GetIndividualCurves());
		}
		if (_0023_003DzeFgvav_PY92dnWAOVg_003D_003D)
		{
			list.Reverse();
			foreach (ICurve item in list)
			{
				item.Reverse();
			}
		}
		return new CompositeCurve(list);
	}

	protected double GetDefaultHelixRampRadius(EndMill cutter)
	{
		return cutter.Diameter * 0.4;
	}

	protected double GetDefaultRampClearanceHeight(EndMill cutter)
	{
		return cutter.Diameter * 0.1;
	}

	protected double GetDefaultCircularLeadRadius(EndMill cutter)
	{
		return cutter.Diameter / 10.0;
	}

	protected double GetDefaultStraightTangentLeadLength(EndMill cutter)
	{
		return cutter.Diameter * 0.6;
	}

	private Dictionary<double, List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>> _0023_003DzjQ4hkC44Ob6b(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> _0023_003DzosMf4QgVa5ec)
	{
		Dictionary<double, List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>> dictionary = new Dictionary<double, List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>>();
		for (int i = 0; i < _0023_003DzosMf4QgVa5ec.Count; i++)
		{
			if (_0023_003DzosMf4QgVa5ec[i] == null)
			{
				continue;
			}
			for (int j = 0; j < _0023_003DzosMf4QgVa5ec[i].Length; j++)
			{
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 = _0023_003DzosMf4QgVa5ec[i][j];
				double key = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003Dz2_OZI5A_003D();
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = new List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>();
					dictionary.Add(key, value);
				}
				value.Add(new Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2, (i, j)));
			}
		}
		return dictionary;
	}

	internal void _0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> _0023_003DzosMf4QgVa5ec, StringBuilder _0023_003DzqmF8XJ0_003D, bool _0023_003DzoQcRoMY_003D, double _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		if (_0023_003Dzbu8BV15Qqzan)
		{
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item5 in _0023_003DzosMf4QgVa5ec)
			{
				for (int i = 0; i < item5.Length; i++)
				{
					item5[i]._0023_003Dz46iWwIQ_003D = true;
				}
			}
		}
		if (_0023_003DzoQcRoMY_003D)
		{
			_0023_003Dz8p5ICJLcWpKqPN8BbQ_003D_003D(_0023_003DzosMf4QgVa5ec);
		}
		if (LeadIn == null && Ramp == null && LeadInOpen == null)
		{
			_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(_0023_003DzosMf4QgVa5ec.Select(_0023_003Dz6bI1gXwSjmYxsoZqzg_003D_003D).ToArray(), _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D);
			return;
		}
		Toolpath.Motion[][][] array = new Toolpath.Motion[_0023_003DzosMf4QgVa5ec.Count][][];
		InitLeads();
		Dictionary<double, List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>> dictionary = _0023_003DzjQ4hkC44Ob6b(_0023_003DzosMf4QgVa5ec);
		double num = ((zRange.Length != 0.0 && stepDown > 0.0) ? zRange.High : RetractHeight);
		foreach (KeyValuePair<double, List<Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)>>> item6 in dictionary)
		{
			double levHeight = Math.Abs(num - item6.Key);
			num = item6.Key;
			InitRamps(levHeight);
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list = item6.Value.Select((Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Item1).ToList();
			_0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_0024 _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_00242 = new _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_0024(list, this, geometry, _0023_003Dz9cS3uG0_003D, _0023_003DzqmF8XJ0_003D);
			foreach (Tuple<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D, (int, int)> item7 in item6.Value)
			{
				(int, int) item = item7.Item2;
				int item2 = item.Item1;
				int item3 = item.Item2;
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D item4 = item7.Item1;
				if (item4._0023_003Dz46iWwIQ_003D)
				{
					Array.Reverse(item4._0023_003DzFsatqHw_003D);
				}
				if (array[item2] == null)
				{
					array[item2] = new Toolpath.Motion[_0023_003DzosMf4QgVa5ec[item2].Length][];
				}
				int _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D = list.IndexOf(item4);
				Lead _0023_003DzOm40_LfQ2mOP = null;
				Lead _0023_003Dzl8Gmj76S15XO = null;
				if (!(item4 is _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7) || pocketRamp == null)
				{
					if (item4 is _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D && LeadInOpen != null)
					{
						_0023_003DzOm40_LfQ2mOP = LeadInOpen;
						_0023_003Dzl8Gmj76S15XO = LeadOutOpen;
					}
					else if (LeadIn != null)
					{
						_0023_003DzOm40_LfQ2mOP = LeadIn;
						_0023_003Dzl8Gmj76S15XO = LeadOut;
					}
				}
				Ramp _0023_003Dz7A1N3G1lY62A = Ramp;
				if (Ramp != null)
				{
					if (item4 is _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 && pocketRamp != null)
					{
						_0023_003Dz7A1N3G1lY62A = pocketRamp;
					}
					else if (item4 is _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D && OpenContoursRamp != null)
					{
						_0023_003Dz7A1N3G1lY62A = OpenContoursRamp;
					}
				}
				array[item2][item3] = _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_00242._0023_003DzFnWY1A6cHJ79(_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, _0023_003DzOm40_LfQ2mOP, _0023_003Dzl8Gmj76S15XO, _0023_003Dz7A1N3G1lY62A, fallbackRamp, _0023_003DzABRv2QAQiuFt: true);
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(array, _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D);
	}

	private void _0023_003Dz8p5ICJLcWpKqPN8BbQ_003D_003D(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> _0023_003DzySVR620_003D)
	{
		for (int i = 0; i < _0023_003DzySVR620_003D.Count; i++)
		{
			_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array = _0023_003DzySVR620_003D[i];
			if (array == null || array.Length < 1)
			{
				continue;
			}
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list = array.ToList();
			List<(Point3D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)> list2 = new List<(Point3D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)>();
			List<IndexLine> list3 = new List<IndexLine>();
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D item in list)
			{
				if (item != null && (!(item is _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i8) || _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i8._0023_003DzrDz685g1xhyc()))
				{
					list2.Add((item._0023_003DzFsatqHw_003D[0], item));
					if (!_0023_003DzySfSteI_003D(item._0023_003DzFsatqHw_003D))
					{
						list3.Add(new IndexLine(list2.Count - 1, list2.Count));
						list2.Add((item._0023_003DzFsatqHw_003D[item._0023_003DzFsatqHw_003D.Length - 1], item));
					}
				}
			}
			int[] array2 = _0023_003DzVss84oikfBMVUb36Rd_00247Di0iyxUN._0023_003DzboSI9t_0024bnGwt(list2.Select(((Point3D, _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D) _0023_003DzbfrNXYE_003D) => _0023_003DzbfrNXYE_003D.Item1).ToList(), list3, 0.5);
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list4 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>(array.Length);
			int[] array3 = array2;
			foreach (int index in array3)
			{
				if (!list4.Contains(list2[index].Item2))
				{
					list4.Add(list2[index].Item2);
				}
			}
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D item2 in list)
			{
				if (item2 is _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i9 && !_0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i9._0023_003DzrDz685g1xhyc())
				{
					list4.Add(_0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i9);
				}
			}
			_0023_003DzySVR620_003D[i] = list4.ToArray();
		}
	}

	protected void InitLeads()
	{
		LeadIn?.Init(tolerance, leadIn: true);
		if (LeadOut != LeadIn)
		{
			LeadOut?.Init(tolerance, leadIn: false);
		}
		LeadInOpen?.Init(tolerance, leadIn: true);
		if (LeadInOpen != LeadOutOpen)
		{
			LeadOutOpen?.Init(tolerance, leadIn: false);
		}
	}

	protected void InitRamps(double levHeight)
	{
		Ramp?.Init(_0023_003Dzx9hQv8LGOi2V, levHeight);
		pocketRamp?.Init(_0023_003Dzx9hQv8LGOi2V, levHeight);
		OpenContoursRamp?.Init(_0023_003Dzx9hQv8LGOi2V, levHeight);
		fallbackRamp.Init(_0023_003Dzx9hQv8LGOi2V, levHeight);
	}

	private static bool _0023_003Dz6QH8iAk_003D(IList<Point3D> _0023_003DzrdSL0CI_003D, out int _0023_003DzhNQLY4s_003D)
	{
		Point3D other = _0023_003DzrdSL0CI_003D[0];
		for (int i = 1; i < _0023_003DzrdSL0CI_003D.Count; i++)
		{
			if (_0023_003DzrdSL0CI_003D[i].EqualsExact(other))
			{
				_0023_003DzhNQLY4s_003D = i;
				return true;
			}
		}
		_0023_003DzhNQLY4s_003D = -1;
		return false;
	}

	internal static bool _0023_003Dz6QH8iAk_003D(IList<Point3D> _0023_003DzrdSL0CI_003D)
	{
		int _0023_003DzhNQLY4s_003D;
		return _0023_003Dz6QH8iAk_003D(_0023_003DzrdSL0CI_003D, out _0023_003DzhNQLY4s_003D);
	}

	internal static bool _0023_003DzySfSteI_003D(Point3D[] _0023_003Dz06A5WivSSyUp)
	{
		if (_0023_003Dz06A5WivSSyUp.Length > 1)
		{
			return _0023_003Dz06A5WivSSyUp[^1].EqualsExact(_0023_003Dz06A5WivSSyUp[0]);
		}
		return false;
	}

	public static string GetUnitsAbbreviation(linearUnitsType units)
	{
		if (units != linearUnitsType.Millimeters)
		{
			return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994950);
		}
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994957);
	}

	public static bool AreEqualZ(double a, double b, double tol)
	{
		return Math.Abs(a - b) < tol;
	}

	internal static Point3D[][] _0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(IList<ICurve> _0023_003DzTj1oJWREOpXS, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		Point3D[][] array = new Point3D[_0023_003DzTj1oJWREOpXS.Count][];
		for (int i = 0; i < _0023_003DzTj1oJWREOpXS.Count; i++)
		{
			((Entity)_0023_003DzTj1oJWREOpXS[i]).Regen(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
			array[i] = ((Entity)_0023_003DzTj1oJWREOpXS[i]).Vertices;
		}
		return array;
	}

	internal static _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003DzN5thJ4k_003D, double _0023_003DzId5C3LA_003D)
	{
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[_0023_003DzN5thJ4k_003D.Count];
		for (int i = 0; i < _0023_003DzN5thJ4k_003D.Count; i++)
		{
			array[i] = (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)_0023_003DzN5thJ4k_003D[i].Clone();
			Point3D[] _0023_003DzFsatqHw_003D = array[i]._0023_003DzFsatqHw_003D;
			for (int j = 0; j < _0023_003DzFsatqHw_003D.Length; j++)
			{
				_0023_003DzFsatqHw_003D[j].Z = _0023_003DzId5C3LA_003D;
			}
		}
		return array;
	}

	private Toolpath.Motion[][] _0023_003Dz6bI1gXwSjmYxsoZqzg_003D_003D(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003Dz9BM_0024JJOnfyrP)
	{
		return _0023_003Dz9BM_0024JJOnfyrP.Select(_0023_003DzHMW6mL7445aFGunBoCdidUJYGwOM).ToArray();
	}

	internal bool _0023_003Dz3Nvs8_cCJ6ILXXWi_0024A_003D_003D(Point3D[][][] _0023_003Dzok56giLKxWwG, double[] _0023_003DzzHQKX_00240_003D, devDept.Eyeshot.Entities.Region _0023_003DzGadhx2d8Tqqo, bool _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D, bool _0023_003DzEhhBjW8RDfjn, double _0023_003DzfBEBL_o_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, out List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> _0023_003Dzv4JjFfZcrMCwC_0024knuA_003D_003D)
	{
		PolyRegion2D polyRegion2D = null;
		devDept.Eyeshot.Entities.Region stock = null;
		if (_0023_003DzGadhx2d8Tqqo != null)
		{
			stock = GetTransformedBoundary(_0023_003DzGadhx2d8Tqqo, _0023_003Dz9cS3uG0_003D);
			polyRegion2D = new PolyRegion2D(GetOuterRegion(cutter, stock, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), tolerance, _0023_003DzEhhBjW8RDfjn), tolerance);
		}
		ComputingPassesText = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870);
		_0023_003Dzv4JjFfZcrMCwC_0024knuA_003D_003D = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		bool _0023_003DzEXLcE10_003D = CutDirectionMode == cutDirectionType.Conventional;
		for (int i = 0; i < _0023_003Dzok56giLKxWwG.Length; i++)
		{
			Point3D[][] array = _0023_003Dzok56giLKxWwG[i];
			double num = _0023_003DzzHQKX_00240_003D[i];
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
			if (array.Length != 0)
			{
				List<PolyRegion2D> list2 = new List<PolyRegion2D>();
				if (polyRegion2D == null)
				{
					LinearPath[] array2 = new LinearPath[array.Length];
					for (int j = 0; j < array.Length; j++)
					{
						array2[j] = new LinearPath(array[j]);
					}
					devDept.Eyeshot.Entities.Region[] array3 = Utility.DetectRegionsFromContours(array2);
					foreach (devDept.Eyeshot.Entities.Region region in array3)
					{
						PolyRegion2D polyRegion2D2 = new PolyRegion2D();
						for (int l = 0; l < region.ContourList.Count; l++)
						{
							polyRegion2D2.ContourList.Add(new Polygon2D(((LinearPath)region.ContourList[l]).Vertices));
						}
						list2.Add(polyRegion2D2);
					}
				}
				else
				{
					list2 = _0023_003Dzx2MRA9ApKHD9(polyRegion2D, array);
				}
				foreach (PolyRegion2D item in list2)
				{
					devDept.Eyeshot.Entities.Region region2 = item.ToRegion(Plane.XY);
					list.Add(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(region2, _0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(region2.ContourList, tolerance), cutter, stepOver, _0023_003DzfBEBL_o_003D, num, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D, _0023_003DzEXLcE10_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D));
				}
			}
			else if (_0023_003DzGadhx2d8Tqqo != null)
			{
				if (!AreEqualZ(num, geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z, tolerance) && !(num > geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z))
				{
					continue;
				}
				devDept.Eyeshot.Entities.Region outerRegion = GetOuterRegion(cutter, stock, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), tolerance);
				Point3D[][] _0023_003DzBLGbisU_003D = _0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(outerRegion.ContourList, tolerance);
				list.Add(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(outerRegion, _0023_003DzBLGbisU_003D, cutter, stepOver, _0023_003DzfBEBL_o_003D, num, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D, _0023_003DzEXLcE10_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D));
			}
			_0023_003Dzv4JjFfZcrMCwC_0024knuA_003D_003D.AddRange(list);
			if (!UpdateProgressAndCheckCancelled(i, _0023_003Dzok56giLKxWwG.Length, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return true;
			}
		}
		return false;
	}

	internal bool _0023_003DzW3dseMxxH7Ha(Point2D[][] _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D, double[] _0023_003DzzHQKX_00240_003D, double _0023_003Dz6pajdGM_003D, double _0023_003Dz8uslNzRAwfBK, double _0023_003DzfBEBL_o_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, out List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D)
	{
		LinearPath[] array = new LinearPath[_0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new LinearPath(Plane.XY, _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D[i]);
		}
		ComputingPassesText = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870);
		_0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		List<devDept.Eyeshot.Entities.Region> list = new List<devDept.Eyeshot.Entities.Region>();
		devDept.Eyeshot.Entities.Region[] array2 = Utility.DetectRegionsFromContours(array);
		foreach (devDept.Eyeshot.Entities.Region region in array2)
		{
			list.AddRange(Utility.DetectRegionsFromContours(region.QuickOffset(_0023_003DzfBEBL_o_003D, cornerType.Miter, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)));
		}
		devDept.Eyeshot.Entities.Region[] array3 = list.ToArray();
		for (int k = 0; k < array3.Length; k++)
		{
			switch (CutDirectionMode)
			{
			case cutDirectionType.Climb:
			{
				array3[k].Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				List<IList<Line>> list4 = _0023_003DzIBirOvc_003D(array3[k], _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK, (_0023_003DzdHAEsWFt2rbg)0, null);
				List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list5 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
				foreach (IList<Line> item2 in list4)
				{
					foreach (Line item3 in item2)
					{
						list5.Add(new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(new Point3D[2]
						{
							(Point3D)item3.StartPoint.Clone(),
							(Point3D)item3.EndPoint.Clone()
						}));
					}
				}
				_0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D.Add(list5.ToArray());
				break;
			}
			case cutDirectionType.Conventional:
			{
				array3[k].Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				List<IList<Line>> list2 = _0023_003DzIBirOvc_003D(array3[k], _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK, (_0023_003DzdHAEsWFt2rbg)0, null);
				foreach (IList<Line> item4 in list2)
				{
					item4.Reverse();
					foreach (Line item5 in item4)
					{
						item5.Reverse();
					}
				}
				List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list3 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
				foreach (IList<Line> item6 in list2)
				{
					foreach (Line item7 in item6)
					{
						list3.Add(new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(new Point3D[2]
						{
							(Point3D)item7.StartPoint.Clone(),
							(Point3D)item7.EndPoint.Clone()
						}));
					}
				}
				_0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D.Add(list3.ToArray());
				break;
			}
			case cutDirectionType.Mixed:
			{
				Point3D[][] array4 = BuildSmartHatch(array3[k], _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				_0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D[] array5 = new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D[array4.Length];
				for (int l = 0; l < array4.Length; l++)
				{
					array5[l] = new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array4[l]);
				}
				List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> obj = _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D;
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item = array5;
				obj.Add(item);
				break;
			}
			}
			if (!UpdateProgressAndCheckCancelled(k, array3.Length, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				return true;
			}
		}
		return false;
	}

	protected static devDept.Eyeshot.Entities.Region GetTransformedBoundary(devDept.Eyeshot.Entities.Region reg, Setup setup)
	{
		devDept.Eyeshot.Entities.Region region = reg;
		if (reg != null && !setup._0023_003DzylonwpI_003D.IsIdentity())
		{
			region = (devDept.Eyeshot.Entities.Region)reg.Clone();
			region.TransformBy(setup._0023_003DzylonwpI_003D);
		}
		return region;
	}

	private static List<PolyRegion2D> _0023_003Dzx2MRA9ApKHD9(PolyRegion2D _0023_003DzRLfsyKQJ4vkv51Wy6g_003D_003D, Point3D[][] _0023_003DzfNi7d4A_003D)
	{
		PolyRegion2D polyRegion2D = new PolyRegion2D();
		foreach (Point3D[] points in _0023_003DzfNi7d4A_003D)
		{
			polyRegion2D.ContourList.Add(new Polygon2D(points));
		}
		PolyRegion2D[] array = PolyRegion2D.Difference(_0023_003DzRLfsyKQJ4vkv51Wy6g_003D_003D, polyRegion2D);
		List<ICurve> list = new List<ICurve>(array.Length);
		PolyRegion2D[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			foreach (Polygon2D contour in array2[i].ContourList)
			{
				list.Add(new LinearPath(Plane.XY, contour.Points));
			}
		}
		devDept.Eyeshot.Entities.Region[] array3 = Utility.DetectRegionsFromContours(list, Plane.XY);
		array = new PolyRegion2D[array3.Length];
		for (int j = 0; j < array3.Length; j++)
		{
			array[j] = new PolyRegion2D(array3[j]);
		}
		return new List<PolyRegion2D>(array);
	}

	protected internal Tuple<double, PolyRegion2D[]>[] GetRawPasses(Tuple<double, Point2D[][]>[] levels, PolyRegion2D boundaryPolyReg, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		Tuple<double, PolyRegion2D[]>[] array = new Tuple<double, PolyRegion2D[]>[levels.Length];
		bool flag = true;
		for (int i = 0; i < levels.Length; i++)
		{
			Tuple<double, Point2D[][]> tuple = levels[i];
			if (tuple.Item2.Length == 0 && flag)
			{
				PolyRegion2D[] item = ((boundaryPolyReg == null) ? new PolyRegion2D[0] : new PolyRegion2D[1] { boundaryPolyReg });
				array[i] = Tuple.Create(levels[i].Item1, item);
				continue;
			}
			flag = false;
			ICurve[] array2 = new ICurve[tuple.Item2.Length];
			for (int j = 0; j < tuple.Item2.Length; j++)
			{
				array2[j] = new LinearPath(Plane.XY, tuple.Item2[j]);
			}
			devDept.Eyeshot.Entities.Region[] array3 = Utility.DetectRegionsFromContours(array2, Plane.XY);
			PolyRegion2D[] array4 = new PolyRegion2D[array3.Length];
			for (int k = 0; k < array3.Length; k++)
			{
				array4[k] = FromRegion(array3[k]);
			}
			PolyRegion2D[] item2 = ((boundaryPolyReg != null) ? _0023_003DzorRMj6zXvNF8(boundaryPolyReg, array4).ToArray() : array4);
			array[i] = Tuple.Create(levels[i].Item1, item2);
		}
		return array;
	}

	protected internal static PolyRegion2D FromRegion(devDept.Eyeshot.Entities.Region region)
	{
		List<Polygon2D> list = new List<Polygon2D>();
		for (int i = 0; i < region.ContourList.Count; i++)
		{
			List<Point2D> list2 = new List<Point2D>();
			LinearPath linearPath = (LinearPath)region.ContourList[i];
			for (int j = 0; j < linearPath.Vertices.Length; j++)
			{
				list2.Add(linearPath.Vertices[j]);
			}
			list.Add(new Polygon2D(list2));
		}
		return new PolyRegion2D(list);
	}

	protected Point2D[] RemoveZ(Point3D[] pts)
	{
		int num = pts.Length;
		Point2D[] array = new Point2D[num];
		for (int i = 0; i < num; i++)
		{
			Point3D point3D = pts[i];
			array[i] = new Point2D(point3D.X, point3D.Y);
		}
		return array;
	}

	protected Point2D[][] RemoveZ(Point3D[][] pts)
	{
		int num = pts.Length;
		Point2D[][] array = new Point2D[num][];
		for (int i = 0; i < num; i++)
		{
			Point3D[] pts2 = pts[i];
			array[i] = RemoveZ(pts2);
		}
		return array;
	}

	public static Point3D[] AddZ(Point2D[] pts, double zh)
	{
		int num = pts.Length;
		Point3D[] array = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			Point2D point2D = pts[i];
			array[i] = new Point3D(point2D.X, point2D.Y, zh);
		}
		return array;
	}

	public static Point3D[][] AddZ(Point2D[][] pts, double zh)
	{
		int num = pts.Length;
		Point3D[][] array = new Point3D[num][];
		for (int i = 0; i < num; i++)
		{
			Point2D[] pts2 = pts[i];
			array[i] = AddZ(pts2, zh);
		}
		return array;
	}

	internal static PolyRegion2D[] _0023_003DzorRMj6zXvNF8(PolyRegion2D _0023_003Dz7revxoQ_003D, PolyRegion2D[] _0023_003DznAREz44_pB8t)
	{
		List<PolyRegion2D> list = new List<PolyRegion2D>();
		list.Add(_0023_003Dz7revxoQ_003D);
		foreach (PolyRegion2D b in _0023_003DznAREz44_pB8t)
		{
			List<PolyRegion2D> list2 = new List<PolyRegion2D>();
			for (int j = 0; j < list.Count; j++)
			{
				list2.AddRange(PolyRegion2D.Difference(list[j], b));
			}
			list = list2;
		}
		return list.ToArray();
	}

	private Toolpath.Motion[] _0023_003DzHMW6mL7445aFGunBoCdidUJYGwOM(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003DzBJFJHwk_003D)
	{
		return _0023_003DzBJFJHwk_003D._0023_003DzRwuOq0Upg_0024zq(Speed, Feed, 0);
	}
}
