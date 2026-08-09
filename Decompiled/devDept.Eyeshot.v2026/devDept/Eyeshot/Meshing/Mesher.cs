using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public abstract class Mesher : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Tuple<double, double, int>, Tuple<double, double, int>, Tuple<double, double, int>> _0023_003DzrPVY8PGol6nwTtu1xA_003D_003D;

		internal Tuple<double, double, int> _0023_003DzB4q0hhccoQQhoQ8pgQ_003D_003D(Tuple<double, double, int> _0023_003DzBJFJHwk_003D, Tuple<double, double, int> _0023_003Dz40R7bAU_003D)
		{
			return new Tuple<double, double, int>(_0023_003DzBJFJHwk_003D.Item1, _0023_003DzBJFJHwk_003D.Item2, _0023_003DzBJFJHwk_003D.Item3 + _0023_003Dz40R7bAU_003D.Item3);
		}
	}

	private sealed class _0023_003DzzfenD6ngsni7RY41oYe4G5I_003D
	{
		public int[] _0023_003DzI1zpEBqLLdeB;

		internal Tuple<double, double, int> _0023_003Dzjj_0024NXtLBEM_0024vb0q5AQzCXtI_003D(int _0023_003Dz437_00244ak_003D)
		{
			return new Tuple<double, double, int>(_0023_003DzglmQxEhYnrFy0jQWGA_003D_003D[_0023_003Dz437_00244ak_003D], _0023_003DzglmQxEhYnrFy0jQWGA_003D_003D[_0023_003Dz437_00244ak_003D + 1], _0023_003DzI1zpEBqLLdeB[_0023_003Dz437_00244ak_003D]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected Material _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D = Material.Aluminium;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected bool _0023_003Dz0ed6dmFMTxDQWwqeBg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzl_0024mcIfg79p3vtAEFxrhNx_00249A8Db9 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989450);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0UO_00247U6MVRHKzu9_D4GvMGV_0024z6u5 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990201);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FemMesh _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected static readonly double[] _0023_003DzglmQxEhYnrFy0jQWGA_003D_003D = new double[12]
	{
		0.0, 0.01, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8,
		0.9, 1.0
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz5by21sOAd5zRiPsVsi5VNWM_003D = 10;

	public string MeshingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzl_0024mcIfg79p3vtAEFxrhNx_00249A8Db9;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzl_0024mcIfg79p3vtAEFxrhNx_00249A8Db9 = value;
		}
	}

	public string SmoothingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0UO_00247U6MVRHKzu9_D4GvMGV_0024z6u5;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0UO_00247U6MVRHKzu9_D4GvMGV_0024z6u5 = value;
		}
	}

	public int SmoothingPasses
	{
		get
		{
			return _0023_003Dz5by21sOAd5zRiPsVsi5VNWM_003D;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990168), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990145));
			}
			_0023_003Dz5by21sOAd5zRiPsVsi5VNWM_003D = value;
		}
	}

	public Material DefaultMaterial
	{
		get
		{
			return _0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D;
		}
		set
		{
			_0023_003Dzv2Pxl9dvjF66aL2_0024_A_003D_003D = value;
		}
	}

	public FemMesh Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = value;
		}
	}

	public string BlockName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D = value;
		}
	}

	private static double _0023_003DzObuEcWw_003D(int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double[][] _0023_003DzEfMn75CQnkXdfxYDuw_003D_003D)
	{
		double num = ((_0023_003Dz437_00244ak_003D < _0023_003DzTSeNR8Q_003D) ? _0023_003DzEfMn75CQnkXdfxYDuw_003D_003D[_0023_003DzTSeNR8Q_003D][_0023_003Dz437_00244ak_003D] : ((_0023_003Dz437_00244ak_003D == _0023_003DzTSeNR8Q_003D) ? 0.0 : _0023_003DzEfMn75CQnkXdfxYDuw_003D_003D[_0023_003Dz437_00244ak_003D][_0023_003DzTSeNR8Q_003D]));
		if (num >= 0.0)
		{
			return num;
		}
		if (_0023_003Dz437_00244ak_003D < _0023_003DzTSeNR8Q_003D)
		{
			return _0023_003DzEfMn75CQnkXdfxYDuw_003D_003D[_0023_003DzTSeNR8Q_003D][_0023_003Dz437_00244ak_003D] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D].DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]);
		}
		return _0023_003DzEfMn75CQnkXdfxYDuw_003D_003D[_0023_003Dz437_00244ak_003D][_0023_003DzTSeNR8Q_003D] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz437_00244ak_003D].DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTSeNR8Q_003D]);
	}

	private protected static int _0023_003Dzj2l6d_EETa_00248(double _0023_003DzuI5Ekdc_003D)
	{
		if (!(_0023_003DzuI5Ekdc_003D < 0.01))
		{
			return Math.Min(1 + (int)(_0023_003DzuI5Ekdc_003D * 10.0), 10);
		}
		return 0;
	}

	protected internal static HistogramData Merge(HistogramData a, HistogramData b)
	{
		if (a == null || a.TotalHits == 0)
		{
			return b;
		}
		if (b == null || b.TotalHits == 0)
		{
			return a;
		}
		Tuple<double, double, int>[] bins = a.Bins.Zip(b.Bins, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzB4q0hhccoQQhoQ8pgQ_003D_003D).ToArray();
		return new HistogramData(a.TotalHits + b.TotalHits, a.Larger + b.Larger, a.Smaller + b.Smaller, Math.Max(a.Max, b.Max), Math.Min(a.Min, b.Min), ((double)a.TotalHits * a.Mean + (double)b.TotalHits * b.Mean) / (double)(a.TotalHits + b.TotalHits), bins);
	}

	private protected HistogramData _0023_003Dz3wn_0024EN2MWgTa()
	{
		_0023_003DzzfenD6ngsni7RY41oYe4G5I_003D CS_0024_003C_003E8__locals3 = new _0023_003DzzfenD6ngsni7RY41oYe4G5I_003D();
		if (Result == null)
		{
			return null;
		}
		int num = 0;
		int num2 = Result.Vertices.Length;
		double num3 = double.MinValue;
		double num4 = double.MaxValue;
		double num5 = 0.0;
		double[][] array = new double[num2][];
		for (int i = 0; i < num2; i++)
		{
			double[] array2 = (array[i] = new double[i]);
			for (int j = 0; j < i; j++)
			{
				array2[j] = -1.0;
			}
		}
		CS_0024_003C_003E8__locals3._0023_003DzI1zpEBqLLdeB = new int[_0023_003DzglmQxEhYnrFy0jQWGA_003D_003D.Length - 1];
		Element[] elements = Result.Elements;
		foreach (Element element in elements)
		{
			double num6;
			if (!(element is Tria3 tria))
			{
				if (!(element is Tria6 tria2))
				{
					continue;
				}
				num6 = Triangle._0023_003DzAO_0024anLA_003D(Result.Vertices[tria2.Connection[0]], Result.Vertices[tria2.Connection[2]], Result.Vertices[tria2.Connection[4]], _0023_003DzObuEcWw_003D(tria2.Connection[0], tria2.Connection[2], Result.Vertices, array), _0023_003DzObuEcWw_003D(tria2.Connection[2], tria2.Connection[4], Result.Vertices, array), _0023_003DzObuEcWw_003D(tria2.Connection[4], tria2.Connection[0], Result.Vertices, array));
			}
			else
			{
				num6 = Triangle._0023_003DzAO_0024anLA_003D(Result.Vertices[tria.Connection[0]], Result.Vertices[tria.Connection[1]], Result.Vertices[tria.Connection[2]], _0023_003DzObuEcWw_003D(tria.Connection[0], tria.Connection[1], Result.Vertices, array), _0023_003DzObuEcWw_003D(tria.Connection[1], tria.Connection[2], Result.Vertices, array), _0023_003DzObuEcWw_003D(tria.Connection[2], tria.Connection[0], Result.Vertices, array));
			}
			num++;
			if (num6 > num3)
			{
				num3 = num6;
			}
			if (num6 < num4)
			{
				num4 = num6;
			}
			num5 += num6;
			CS_0024_003C_003E8__locals3._0023_003DzI1zpEBqLLdeB[_0023_003Dzj2l6d_EETa_00248(num6)]++;
		}
		return new HistogramData(num, 0, 0, num3, num4, num5 / (double)num, (from _0023_003Dz437_00244ak_003D in Enumerable.Range(0, _0023_003DzglmQxEhYnrFy0jQWGA_003D_003D.Length - 1)
			select new Tuple<double, double, int>(_0023_003DzglmQxEhYnrFy0jQWGA_003D_003D[_0023_003Dz437_00244ak_003D], _0023_003DzglmQxEhYnrFy0jQWGA_003D_003D[_0023_003Dz437_00244ak_003D + 1], CS_0024_003C_003E8__locals3._0023_003DzI1zpEBqLLdeB[_0023_003Dz437_00244ak_003D])).ToArray());
	}
}
