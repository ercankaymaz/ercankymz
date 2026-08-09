using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Contour3D : Machining3D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003Dzi7XR59NGN6Cp, bool> _0023_003Dzy7nEv89xDomyXIe12g_003D_003D;

		public static Func<_0023_003Dzi7XR59NGN6Cp, bool> _0023_003DzfXeuS1tbkOGAdf2Kdw_003D_003D;

		internal bool _0023_003Dz9UVuQ4duPdBHUUnGUA_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D._0023_003DzhoegMB067LVL.Count > 0;
		}

		internal bool _0023_003DzEKOi5XHPpmjc_brKtg_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D._0023_003DzhoegMB067LVL.Count > 0;
		}
	}

	public class SortedTupleBag<TKey, TValue> : SortedSet<Tuple<TKey, TValue>> where TKey : IComparable
	{
		private sealed class _0023_003Dzkkm_0024NAmqY6kL : Comparer<Tuple<TKey, TValue>>
		{
			public override int Compare(Tuple<TKey, TValue> _0023_003DzBJFJHwk_003D, Tuple<TKey, TValue> _0023_003Dz40R7bAU_003D)
			{
				if (_0023_003DzBJFJHwk_003D == null || _0023_003Dz40R7bAU_003D == null)
				{
					return 0;
				}
				if (!_0023_003DzBJFJHwk_003D.Item1.Equals(_0023_003Dz40R7bAU_003D.Item1))
				{
					return Comparer<TKey>.Default.Compare(_0023_003DzBJFJHwk_003D.Item1, _0023_003Dz40R7bAU_003D.Item1);
				}
				return 1;
			}
		}

		public SortedTupleBag()
			: base((IComparer<Tuple<TKey, TValue>>)new _0023_003Dzkkm_0024NAmqY6kL())
		{
		}

		public void Add(TKey key, TValue value)
		{
			Add(new Tuple<TKey, TValue>(key, value));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzTxUK7LxZDzTiQX30Xh1X170_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzzHQKX_00240_003D;

	public bool FlatAreaDetection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTxUK7LxZDzTiQX30Xh1X170_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTxUK7LxZDzTiQX30Xh1X170_003D = value;
		}
	}

	public Contour3D(Setup setup, EndMill cutter, Geometry3D geometry, Interval zRange, double stepDown)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		base.Tolerance = 0.05 * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, setup.Units);
		base.ComputingPassesText = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994863);
		double defaultCircularLeadRadius = GetDefaultCircularLeadRadius(cutter);
		base.LeadIn = new CircularLead(defaultCircularLeadRadius);
		base.LeadOut = new CircularLead(defaultCircularLeadRadius);
		pocketRamp = null;
		base.LeadInOpen = new StraightLead(GetDefaultStraightTangentLeadLength(cutter), perp: false);
	}

	public Contour3D(Setup setup, EndMill cutter, Geometry3D geometry, double[] zHeights)
		: this(setup, cutter, geometry, default(Interval), 0.0)
	{
		_0023_003DzzHQKX_00240_003D = zHeights;
	}

	public Contour3D(Setup setup, EndMill cutter, Geometry3D geometry, devDept.Eyeshot.Entities.Region boundary, Interval zRange, double stepDown)
		: this(setup, cutter, geometry, zRange, stepDown)
	{
		base.boundary = boundary;
	}

	public Contour3D(Setup setup, EndMill cutter, Geometry3D geometry, devDept.Eyeshot.Entities.Region boundary, double[] zHeights)
		: this(setup, cutter, geometry, default(Interval), 0.0)
	{
		base.boundary = boundary;
		_0023_003DzzHQKX_00240_003D = zHeights;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		PolyRegion2D boundaryPolyReg;
		Tuple<double, Point2D[][]>[] waterlines = GetWaterlines(null, progress, ct, out boundaryPolyReg);
		if (waterlines == null)
		{
			return;
		}
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] array = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[waterlines.Length][];
		if (boundary != null)
		{
			for (int i = 0; i < waterlines.Length; i++)
			{
				Point2D[][] item = waterlines[i].Item2;
				if (item.Length == 0)
				{
					continue;
				}
				double item2 = waterlines[i].Item1;
				List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
				devDept.Eyeshot.Entities.Region _0023_003Dz_SqBXz8_003D = boundaryPolyReg.ToRegion(Plane.XY);
				Point2D[][] array2 = item;
				foreach (Point2D[] array3 in array2)
				{
					List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list2 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>(item.Length);
					Polygon2D polygon2D = new Polygon2D(array3);
					polygon2D.UpdateBoundingRect();
					Point3D[] array4 = Machining.AddZ(array3, waterlines[i].Item1);
					if (boundaryPolyReg.IsPolygonInside(polygon2D))
					{
						list2.Add(new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(array4));
					}
					else
					{
						Point3D[][] array5 = _0023_003Dz9y6F_0024pWf69VkHAqP5Ep4FcSlwwoD._0023_003DzOYxPx6FqLIHX(array4, _0023_003Dz_SqBXz8_003D);
						foreach (Point3D[] array6 in array5)
						{
							Point3D[] array7 = array6;
							for (int l = 0; l < array7.Length; l++)
							{
								array7[l].Z = item2;
							}
							list2.Add(Machining._0023_003DzySfSteI_003D(array6) ? ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(array6)) : ((_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D)new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array6, _0023_003DzcaGByDs7xCqDXTICQFdDcOs_003D: true)));
						}
					}
					list.AddRange(list2.ToArray());
				}
				array[i] = list.ToArray();
			}
		}
		else
		{
			for (int m = 0; m < waterlines.Length; m++)
			{
				array[m] = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[waterlines[m].Item2.Length];
				for (int n = 0; n < waterlines[m].Item2.Length; n++)
				{
					array[m][n] = new _0023_003DzR3WVQCEzz65noi1VChQukA3MK1cC5qLbFFOoDLFLl4lyg2_0024DGA_003D_003D(Machining.AddZ(waterlines[m].Item2[n], waterlines[m].Item1));
				}
			}
		}
		if (base.CutDirectionMode == cutDirectionType.Climb)
		{
			_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] array8 = array;
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array9 in array8)
			{
				for (int k = 0; k < array9.Length; k++)
				{
					Array.Reverse(array9[k]._0023_003DzFsatqHw_003D);
				}
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(array, log, _0023_003DzoQcRoMY_003D: true, 0.0, _0023_003Dzbu8BV15Qqzan: false);
	}

	protected Tuple<double, Point2D[][]>[] ComputeWaterlines(double[] zhArray, PolyRegion2D boundaryPolyReg, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		if (zRange.IsDecreasing)
		{
			throw new EyeshotException(Stock._0023_003DzgrpqC0lGgmdj);
		}
		int num = zhArray.Length;
		Tuple<double, Point2D[][]>[] array = new Tuple<double, Point2D[][]>[num];
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D = _0023_003DzXT4sGPyMpoH6();
		double sampling = GetSampling();
		Point3D boxMin = geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D);
		Point3D boxMax = geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D);
		_0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_Bn_pNI_003D = new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D(boxMin.X, boxMax.X, boxMin.Y, boxMax.Y, 0.0, 0.0);
		_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2 = new _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D();
		_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003Dz12p2jmUTCnCB(_0023_003Dz9cS3uG0_003D, (Geometry3D)geometry, _0023_003Dz_Bn_pNI_003D);
		_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003DzePcMMDarrpwf(_0023_003Dzt_m8zV0_003D);
		_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003DztNBJE_4_003D(sampling);
		for (int i = 0; i < num; i++)
		{
			double num2 = zhArray[i];
			_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003DzlRm6XLNSMLjYhgSAqQ_003D_003D(i, num2);
			if (Machining.AreEqualZ(num2, boxMax.Z, tolerance) || num2 > boxMax.Z)
			{
				array[i] = Tuple.Create(num2, Array.Empty<Point2D[]>());
				continue;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int _0023_003DzuOMylKfpuJP = 0;
			if (i != 0 && array[i - 1] == null)
			{
				_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003Dzz8DDgng_003D(Math.Max(zhArray[i - 1] - zhArray[i], base.Tool.CornerRadius), tolerance, ref _0023_003DzuOMylKfpuJP);
			}
			else
			{
				_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003Dzz8DDgng_003D(tolerance, ref _0023_003DzuOMylKfpuJP, 0.0);
			}
			stopwatch.Stop();
			stopwatch.Reset();
			stopwatch.Start();
			_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003DzWQuPA6x8Dy0a();
			stopwatch.Stop();
			stopwatch.Reset();
			stopwatch.Start();
			Point3D[][] array2 = _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2._0023_003DzfUw1SlQ_003D();
			bool[] _0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D = _0023_003Dz7_lc7SdsNaGU(boundaryPolyReg, array2, null);
			Point3D[][] _0023_003DzOZ2FRneKbSLE = _0023_003DztC3moZ2T5iWU(array2, _0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D);
			Point3D[][] _0023_003DzN5thJ4k_003D = _0023_003DzOkynKKo_003D(_0023_003DzOZ2FRneKbSLE, _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D2, sampling, num2, ref _0023_003DzuOMylKfpuJP, _0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D);
			Point3D[][] loops = _0023_003DzIrCEdFA_003D(_0023_003DzN5thJ4k_003D);
			stopwatch.Stop();
			stopwatch.Reset();
			stopwatch.Start();
			Point3D[][] pts = Filter(loops);
			stopwatch.Stop();
			array[i] = Tuple.Create(num2, RemoveZ(pts));
			if (!UpdateProgressAndCheckCancelled(i, num, base.ComputingPassesText, progress, ct))
			{
				return null;
			}
		}
		return array;
	}

	protected Tuple<double, Point2D[][]>[] GetRawPasses(IProgress<ProgressChangedEventArgs> progress = null, CancellationToken ct = default(CancellationToken))
	{
		PolyRegion2D boundaryPolyReg;
		Tuple<double, Point2D[][]>[] waterlines = GetWaterlines(null, progress, ct, out boundaryPolyReg);
		if (waterlines == null)
		{
			return Array.Empty<Tuple<double, Point2D[][]>>();
		}
		return waterlines;
	}

	private static bool[] _0023_003Dz7_lc7SdsNaGU(PolyRegion2D _0023_003DzK_6VEOqEckkt, Point3D[][] _0023_003Dzcv8o5nO25OjS, WriteFileParams _0023_003DzYwiCXkk_003D)
	{
		bool[] array = new bool[_0023_003Dzcv8o5nO25OjS.Length];
		if (_0023_003DzK_6VEOqEckkt != null)
		{
			for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Length; i++)
			{
				Polygon2D polygon2D = new Polygon2D(_0023_003Dzcv8o5nO25OjS[i]);
				polygon2D.UpdateBoundingRect();
				if (_0023_003DzK_6VEOqEckkt.IsPolygonOutside(polygon2D))
				{
					array[i] = true;
				}
				else if (_0023_003DzYwiCXkk_003D != null)
				{
					_0023_003DzRCrpdGA_003D(_0023_003DzYwiCXkk_003D, new LinearPath(_0023_003Dzcv8o5nO25OjS[i]), Color.Magenta);
				}
			}
		}
		return array;
	}

	private static void _0023_003DzRCrpdGA_003D(WriteFileParams _0023_003DzYwiCXkk_003D, Entity _0023_003Dzs_0024uS8LA_003D, Color _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003DzYwiCXkk_003D != null)
		{
			_0023_003Dzs_0024uS8LA_003D.ColorMethod = colorMethodType.byEntity;
			_0023_003Dzs_0024uS8LA_003D.Color = _0023_003Dz1MMYB1g_003D;
			_0023_003DzYwiCXkk_003D.Entities.Add(_0023_003Dzs_0024uS8LA_003D);
		}
	}

	private int _0023_003Dzy73hhVPjFeoarTJOvQ_003D_003D(Point3D _0023_003DzvORV0oA_003D, Point3D[] _0023_003DzhPw9cbSpUpnU)
	{
		double num = double.MaxValue;
		int result = 0;
		for (int i = 0; i < _0023_003DzhPw9cbSpUpnU.Length; i++)
		{
			double num2 = Point2D.DistanceSquared(_0023_003DzvORV0oA_003D, _0023_003DzhPw9cbSpUpnU[i]);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	private Point3D[] _0023_003DziZ5ngG6_G8nz9lEMLg_003D_003D(int _0023_003Dz6_0Kdx0_003D, Point3D[] _0023_003Dzb7SPTpc_003D)
	{
		if (_0023_003Dz6_0Kdx0_003D == 0)
		{
			return _0023_003Dzb7SPTpc_003D;
		}
		Point3D[] array = new Point3D[_0023_003Dzb7SPTpc_003D.Length];
		Array.Copy(_0023_003Dzb7SPTpc_003D, _0023_003Dz6_0Kdx0_003D, array, 0, _0023_003Dzb7SPTpc_003D.Length - _0023_003Dz6_0Kdx0_003D);
		Array.Copy(_0023_003Dzb7SPTpc_003D, 1, array, _0023_003Dzb7SPTpc_003D.Length - _0023_003Dz6_0Kdx0_003D, _0023_003Dz6_0Kdx0_003D - 1);
		array[_0023_003Dzb7SPTpc_003D.Length - 1] = (Point3D)array[0].Clone();
		return array;
	}

	private Point3D[][] _0023_003DztC3moZ2T5iWU(Point3D[][] _0023_003DzN5thJ4k_003D, bool[] _0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D)
	{
		for (int i = 0; i < _0023_003DzN5thJ4k_003D.Length; i++)
		{
			if (!_0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D[i])
			{
				int num = _0023_003Dzy73hhVPjFeoarTJOvQ_003D_003D(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), _0023_003DzN5thJ4k_003D[i]);
				if (num > 0)
				{
					_0023_003DzN5thJ4k_003D[i] = _0023_003DziZ5ngG6_G8nz9lEMLg_003D_003D(num, _0023_003DzN5thJ4k_003D[i]);
				}
			}
		}
		return _0023_003DzN5thJ4k_003D;
	}

	private Point3D[][] _0023_003DzIrCEdFA_003D(Point3D[][] _0023_003DzN5thJ4k_003D)
	{
		SortedTupleBag<double, int> sortedTupleBag = new SortedTupleBag<double, int>();
		for (int i = 0; i < _0023_003DzN5thJ4k_003D.Length; i++)
		{
			double key = Point2D.DistanceSquared(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), _0023_003DzN5thJ4k_003D[i][0]);
			sortedTupleBag.Add(key, i);
		}
		Point3D[][] array = new Point3D[_0023_003DzN5thJ4k_003D.Length][];
		int num = 0;
		foreach (Tuple<double, int> item in sortedTupleBag)
		{
			array[num++] = _0023_003DzN5thJ4k_003D[item.Item2];
		}
		return array;
	}

	private Point3D[][] _0023_003DzOkynKKo_003D(Point3D[][] _0023_003DzOZ2FRneKbSLE, _0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D _0023_003Dz_0024l539Oo_003D, double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, double _0023_003Dz9NrCn_o_003D, ref int _0023_003DzuOMylKfpuJP0, bool[] _0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D)
	{
		Point3D[][] array = new Point3D[_0023_003DzOZ2FRneKbSLE.Length][];
		List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzSYnbJHaKGdmw = new List<_0023_003Dzi7XR59NGN6Cp>(_0023_003Dz_0024l539Oo_003D._0023_003DzFFdRlnUb7lMf7EOo0g_003D_003D());
		List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzmDH1fND8rUCN = new List<_0023_003Dzi7XR59NGN6Cp>(_0023_003Dz_0024l539Oo_003D._0023_003DzC5ujV8QgrKmUwyGmiw_003D_003D());
		for (int i = 0; i < _0023_003DzOZ2FRneKbSLE.Length; i++)
		{
			Point3D[] array2 = _0023_003DzOZ2FRneKbSLE[i];
			if (_0023_003DzHTBp2J_0024mj_raD_0024_0024gpw_003D_003D[i] || array2.Length < 3)
			{
				array[i] = array2;
				continue;
			}
			List<Point3D> list = new List<Point3D>(array2);
			double num = 0.0;
			WriteFileParams _0023_003DzYwiCXkk_003D = null;
			double _0023_003Dz0mZ4_0024fFWxsTX;
			int _0023_003DzdbIvGaME158A;
			do
			{
				_0023_003Dz0mZ4_0024fFWxsTX = 0.0;
				_0023_003DzdbIvGaME158A = 0;
				_0023_003Dz_0024l539Oo_003D._0023_003DznckkLRw_003D();
				_0023_003Dzf3HDD8GZgr5n7_b57g_003D_003D(_0023_003Dz_0024l539Oo_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, list, _0023_003Dz9NrCn_o_003D, ref _0023_003DzdbIvGaME158A, _0023_003DzYwiCXkk_003D);
				_0023_003Dz_0024l539Oo_003D._0023_003Dzz8DDgng_003D(tolerance, ref _0023_003DzuOMylKfpuJP0, 0.0);
				List<_0023_003Dzi7XR59NGN6Cp> list2 = _0023_003Dz_0024l539Oo_003D._0023_003DzFFdRlnUb7lMf7EOo0g_003D_003D();
				List<_0023_003Dzi7XR59NGN6Cp> list3 = _0023_003Dz_0024l539Oo_003D._0023_003DzC5ujV8QgrKmUwyGmiw_003D_003D();
				int num2 = list2.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz9UVuQ4duPdBHUUnGUA_003D_003D);
				int num3 = list3.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzEKOi5XHPpmjc_brKtg_003D_003D);
				if (num2 <= 0 && num3 <= 0)
				{
					break;
				}
				for (int j = 0; j < list.Count - 1; j++)
				{
					Segment2D segment2D = new Segment2D(list[j].X, list[j].Y, list[j + 1].X, list[j + 1].Y);
					Point2D point2D = null;
					Point2D point2D2 = null;
					foreach (_0023_003DzL5U7KER18MrmKIyoS1tLEAAF7FhiQcArArkXDb8_003D item in list2)
					{
						if (item._0023_003DzxcI8W_00248_003D(segment2D))
						{
							point2D = _0023_003DzdZMQDskek2iD(item, segment2D);
							break;
						}
					}
					foreach (_0023_003DzV2oSLtcAc39qqlMrcWLrfkiOffeoj3MRlQjciWdrVNGT item2 in list3)
					{
						if (item2._0023_003DzxcI8W_00248_003D(segment2D))
						{
							point2D2 = _0023_003DzdZMQDskek2iD(item2, segment2D);
							break;
						}
					}
					if (point2D != null)
					{
						list.Insert(j + 1, new Point3D(point2D.X, point2D.Y, _0023_003Dz9NrCn_o_003D));
						j++;
					}
					else if (point2D2 != null)
					{
						list.Insert(j + 1, new Point3D(point2D2.X, point2D2.Y, _0023_003Dz9NrCn_o_003D));
						j++;
					}
				}
				num = _0023_003DzIVQM0lpMxVDU(list, ref _0023_003Dz0mZ4_0024fFWxsTX);
			}
			while ((num > tolerance || _0023_003DzdbIvGaME158A > 0) && _0023_003Dz0mZ4_0024fFWxsTX < Utility.DegToRad(179.0));
			if (_0023_003Dz0mZ4_0024fFWxsTX > Utility.DegToRad(179.0))
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994827) + _0023_003Dz9NrCn_o_003D);
			}
			array[i] = list.ToArray();
		}
		_0023_003Dz_0024l539Oo_003D._0023_003Dzv9osLK4_003D(_0023_003DzmDH1fND8rUCN, _0023_003DzSYnbJHaKGdmw);
		return array;
	}

	private double _0023_003Dzf3HDD8GZgr5n7_b57g_003D_003D(_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D _0023_003Dz_0024l539Oo_003D, double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, IList<Point3D> _0023_003DzsSLPcz8_003D, double _0023_003Dz9NrCn_o_003D, ref int _0023_003DzdbIvGaME158A, WriteFileParams _0023_003DzYwiCXkk_003D)
	{
		double _0023_003Dz0nWlhAUlOe9N = 0.0;
		Point3D p = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 3];
		Point3D point3D = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 2];
		Point3D point3D2 = _0023_003DzsSLPcz8_003D[0];
		Point3D p2 = _0023_003DzsSLPcz8_003D[1];
		Segment2D _0023_003DzgPsOl1A_003D = new Segment2D(p, point3D);
		Segment2D _0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
		Segment2D _0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
		_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003Dz_0024l539Oo_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, _0023_003Dz9NrCn_o_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003DzdbIvGaME158A, _0023_003DzYwiCXkk_003D);
		Point3D p3 = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 2];
		point3D = _0023_003DzsSLPcz8_003D[0];
		point3D2 = _0023_003DzsSLPcz8_003D[1];
		p2 = _0023_003DzsSLPcz8_003D[2];
		_0023_003DzgPsOl1A_003D = new Segment2D(p3, point3D);
		_0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
		_0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
		_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003Dz_0024l539Oo_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, _0023_003Dz9NrCn_o_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003DzdbIvGaME158A, _0023_003DzYwiCXkk_003D);
		for (int i = 0; i < _0023_003DzsSLPcz8_003D.Count - 3; i++)
		{
			Point3D p4 = _0023_003DzsSLPcz8_003D[i];
			point3D = _0023_003DzsSLPcz8_003D[i + 1];
			point3D2 = _0023_003DzsSLPcz8_003D[i + 2];
			p2 = _0023_003DzsSLPcz8_003D[i + 3];
			_0023_003DzgPsOl1A_003D = new Segment2D(p4, point3D);
			_0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
			_0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
			_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003Dz_0024l539Oo_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, _0023_003Dz9NrCn_o_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003DzdbIvGaME158A, _0023_003DzYwiCXkk_003D);
		}
		return _0023_003Dz0nWlhAUlOe9N;
	}

	private double _0023_003DzIVQM0lpMxVDU(List<Point3D> _0023_003DzsSLPcz8_003D, ref double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		double _0023_003Dz0nWlhAUlOe9N = 0.0;
		Point3D p = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 3];
		Point3D point3D = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 2];
		Point3D point3D2 = _0023_003DzsSLPcz8_003D[0];
		Point3D p2 = _0023_003DzsSLPcz8_003D[1];
		Segment2D _0023_003DzgPsOl1A_003D = new Segment2D(p, point3D);
		Segment2D _0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
		Segment2D _0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
		_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003Dz0mZ4_0024fFWxsTX);
		Point3D p3 = _0023_003DzsSLPcz8_003D[_0023_003DzsSLPcz8_003D.Count - 2];
		point3D = _0023_003DzsSLPcz8_003D[0];
		point3D2 = _0023_003DzsSLPcz8_003D[1];
		p2 = _0023_003DzsSLPcz8_003D[2];
		_0023_003DzgPsOl1A_003D = new Segment2D(p3, point3D);
		_0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
		_0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
		_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003Dz0mZ4_0024fFWxsTX);
		for (int i = 0; i < _0023_003DzsSLPcz8_003D.Count - 3; i++)
		{
			Point3D p4 = _0023_003DzsSLPcz8_003D[i];
			point3D = _0023_003DzsSLPcz8_003D[i + 1];
			point3D2 = _0023_003DzsSLPcz8_003D[i + 2];
			p2 = _0023_003DzsSLPcz8_003D[i + 3];
			_0023_003DzgPsOl1A_003D = new Segment2D(p4, point3D);
			_0023_003DzD5YCi2M_003D = new Segment2D(point3D, point3D2);
			_0023_003Dz9_0024bIhS0_003D = new Segment2D(point3D2, p2);
			_0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9_0024bIhS0_003D, ref _0023_003Dz0nWlhAUlOe9N, ref _0023_003Dz0mZ4_0024fFWxsTX);
		}
		return _0023_003Dz0nWlhAUlOe9N;
	}

	private void _0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D _0023_003Dz_0024l539Oo_003D, double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, Segment2D _0023_003DzgPsOl1A_003D, Segment2D _0023_003DzD5YCi2M_003D, Segment2D _0023_003Dz9_0024bIhS0_003D, double _0023_003Dz9NrCn_o_003D, ref double _0023_003Dz0nWlhAUlOe9N, ref int _0023_003DzdbIvGaME158A, WriteFileParams _0023_003DzYwiCXkk_003D)
	{
		Vector2D vector2D = _0023_003DzgPsOl1A_003D;
		Vector2D vector2D2 = _0023_003DzD5YCi2M_003D;
		Vector2D vector2D3 = _0023_003Dz9_0024bIhS0_003D;
		if (_0023_003DzD5YCi2M_003D.Length < tolerance)
		{
			return;
		}
		vector2D.Normalize();
		vector2D2.Normalize();
		vector2D3.Normalize();
		double num = Vector2D.AngleBetween(vector2D, vector2D2);
		double num2 = Vector2D.AngleBetween(vector2D2, vector2D3);
		if (!(num > 1E-06) || !(num2 > 1E-06))
		{
			return;
		}
		double radius;
		double deviation2D = Utility.GetDeviation2D(_0023_003DzD5YCi2M_003D.P0, vector2D, _0023_003DzD5YCi2M_003D.P1, vector2D3, out radius);
		if (deviation2D > _0023_003Dz0nWlhAUlOe9N)
		{
			_0023_003Dz0nWlhAUlOe9N = deviation2D;
		}
		bool flag = Vector2D.AngleBetween(vector2D, vector2D3) > 0.7;
		if (flag)
		{
			_0023_003DzdbIvGaME158A++;
		}
		double _0023_003DzaQ_y9PQ_003D = _0023_003DzD5YCi2M_003D.P1.X - _0023_003DzD5YCi2M_003D.P0.X;
		double _0023_003DzD47R4_0_003D = _0023_003DzD5YCi2M_003D.P1.Y - _0023_003DzD5YCi2M_003D.P0.Y;
		if (deviation2D > tolerance || flag)
		{
			_0023_003DzxPWjxvbR5Yd62aBoB7efbGxtSEou(_0023_003Dz_0024l539Oo_003D, _0023_003DzD5YCi2M_003D, _0023_003Dz9NrCn_o_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D);
			if (_0023_003DzYwiCXkk_003D != null)
			{
				_0023_003DzRCrpdGA_003D(_0023_003DzYwiCXkk_003D, new devDept.Eyeshot.Entities.Point(_0023_003DzD5YCi2M_003D.MidPoint, 6f), (deviation2D > base.Tolerance) ? Color.Red : Color.Turquoise);
				_0023_003DzRCrpdGA_003D(_0023_003DzYwiCXkk_003D, new Line(_0023_003DzD5YCi2M_003D), Color.Green);
			}
		}
	}

	private void _0023_003DzdB7sqAkqfbm1IbZpVw_003D_003D(Segment2D _0023_003DzgPsOl1A_003D, Segment2D _0023_003DzD5YCi2M_003D, Segment2D _0023_003Dz9_0024bIhS0_003D, ref double _0023_003Dz0nWlhAUlOe9N, ref double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		if (_0023_003DzD5YCi2M_003D.Length < tolerance)
		{
			return;
		}
		Vector2D vector2D = _0023_003DzgPsOl1A_003D;
		Vector2D vector2D2 = _0023_003DzD5YCi2M_003D;
		Vector2D vector2D3 = _0023_003Dz9_0024bIhS0_003D;
		vector2D.Normalize();
		vector2D2.Normalize();
		vector2D3.Normalize();
		double num = Vector2D.AngleBetween(vector2D, vector2D2);
		double num2 = Vector2D.AngleBetween(vector2D2, vector2D3);
		if (num > _0023_003Dz0mZ4_0024fFWxsTX)
		{
			_0023_003Dz0mZ4_0024fFWxsTX = num;
		}
		if (num2 > _0023_003Dz0mZ4_0024fFWxsTX)
		{
			_0023_003Dz0mZ4_0024fFWxsTX = num2;
		}
		if (num > 1E-06 && num2 > 1E-06)
		{
			double radius;
			double deviation2D = Utility.GetDeviation2D(_0023_003DzD5YCi2M_003D.P0, vector2D, _0023_003DzD5YCi2M_003D.P1, vector2D3, out radius);
			if (deviation2D > _0023_003Dz0nWlhAUlOe9N)
			{
				_0023_003Dz0nWlhAUlOe9N = deviation2D;
			}
		}
	}

	private static Point2D _0023_003DzdZMQDskek2iD(_0023_003Dzi7XR59NGN6Cp _0023_003Dz1FOQgC8_003D, Segment2D _0023_003DzFDJdA7A_003D)
	{
		double num = double.MaxValue;
		Point2D result = null;
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003Dz1FOQgC8_003D._0023_003DzhoegMB067LVL)
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = _0023_003Dz1FOQgC8_003D._0023_003DzlY77YgY_003D(item._0023_003Dz6V_0024QadA_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = _0023_003Dz1FOQgC8_003D._0023_003DzlY77YgY_003D(item._0023_003DzCskoEKg_003D);
			Point2D point2D = new Point2D(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D);
			Point2D point2D2 = new Point2D(_0023_003DzmKBPh7nOT6nY3._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY3._0023_003Dz40R7bAU_003D);
			double num2 = Point2D.DistanceSquared(point2D, _0023_003DzFDJdA7A_003D.MidPoint);
			if (num2 < num)
			{
				num = num2;
				result = point2D;
			}
			double num3 = Point2D.DistanceSquared(point2D2, _0023_003DzFDJdA7A_003D.MidPoint);
			if (num3 < num)
			{
				num = num3;
				result = point2D2;
			}
		}
		return result;
	}

	private void _0023_003DzxPWjxvbR5Yd62aBoB7efbGxtSEou(_0023_003DzkJ16cR5A5G8JKWqzLP772EC8imYQGO3C4O_00245SjSSTI9YHVZYxw_003D_003D _0023_003Dz_0024l539Oo_003D, Segment2D _0023_003DzFDJdA7A_003D, double _0023_003Dz9NrCn_o_003D, double _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D)
	{
		Point2D midPoint = _0023_003DzFDJdA7A_003D.MidPoint;
		if (Math.Abs(_0023_003DzaQ_y9PQ_003D) > Math.Abs(_0023_003DzD47R4_0_003D))
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y = new _0023_003DzmKBPh7nOT6nY(midPoint.X, midPoint.Y - _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003Dz9NrCn_o_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY = new _0023_003DzmKBPh7nOT6nY(midPoint.X, midPoint.Y + _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, _0023_003Dz9NrCn_o_003D);
			_0023_003Dzi7XR59NGN6Cp _0023_003DzKLzUdk0_003D = new _0023_003DzL5U7KER18MrmKIyoS1tLEAAF7FhiQcArArkXDb8_003D(_0023_003DzsiQjbwmUNI0y, _0023_003DzSElTn3BlQAJY, _0023_003DzFDJdA7A_003D);
			_0023_003Dz_0024l539Oo_003D._0023_003DzmG2bu6MobTwJ(_0023_003DzKLzUdk0_003D);
		}
		else
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y2 = new _0023_003DzmKBPh7nOT6nY(midPoint.X - _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, midPoint.Y, _0023_003Dz9NrCn_o_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY2 = new _0023_003DzmKBPh7nOT6nY(midPoint.X + _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, midPoint.Y, _0023_003Dz9NrCn_o_003D);
			_0023_003Dzi7XR59NGN6Cp _0023_003DzaYZe3P8_003D = new _0023_003DzV2oSLtcAc39qqlMrcWLrfkiOffeoj3MRlQjciWdrVNGT(_0023_003DzsiQjbwmUNI0y2, _0023_003DzSElTn3BlQAJY2, _0023_003DzFDJdA7A_003D);
			_0023_003Dz_0024l539Oo_003D._0023_003DzV2pFhhR9Idxx(_0023_003DzaYZe3P8_003D);
		}
	}

	protected Tuple<double, Point2D[][]>[] GetWaterlines(devDept.Eyeshot.Entities.Region stock, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, out PolyRegion2D boundaryPolyReg)
	{
		_0023_003DzeALrgz3cdl82(progress);
		boundaryPolyReg = null;
		if (boundary != null)
		{
			devDept.Eyeshot.Entities.Region outerRegion = Machining.GetOuterRegion(cutter, boundary, stock, geometry, _0023_003Dz9cS3uG0_003D);
			boundaryPolyReg = new PolyRegion2D(outerRegion, tolerance);
			boundaryPolyReg.UpdateBoundingRect();
		}
		double[] flatZ = null;
		if (_0023_003DzzHQKX_00240_003D == null && zRange.Length != 0.0 && stepDown > 0.0)
		{
			_0023_003DzzHQKX_00240_003D = Machining3D.ComputeStepsZ(zRange, stepDown, FlatAreaDetection, _0023_003Dz9cS3uG0_003D, (Geometry3D)geometry, boundaryPolyReg, base.AxialStockToLeave, tolerance, out flatZ);
		}
		Tuple<double, Point2D[][]>[] array = ComputeWaterlines(_0023_003DzzHQKX_00240_003D, boundaryPolyReg, progress, ct);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (flatZ == null || !flatZ.Contains(array[i].Item1 - base.AxialStockToLeave - base.Tolerance))
				{
					array[i] = Tuple.Create(array[i].Item1 + base.AxialStockToLeave, array[i].Item2);
				}
			}
		}
		return array;
	}

	private void _0023_003DzeALrgz3cdl82(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		if (!((Geometry3D)geometry).IsReadyWaterline(_0023_003Dz9cS3uG0_003D))
		{
			StartContinuousAnimation(base.PreparingGeometryText, _0023_003DzmHS7frs_003D);
			((Geometry3D)geometry).PreProcessWaterline(_0023_003Dz9cS3uG0_003D);
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		}
	}
}
