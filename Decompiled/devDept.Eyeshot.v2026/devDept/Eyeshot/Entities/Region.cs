using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Diagnostic;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Region : PlanarEntity, IFace, ICloneable, ITriangles, ISelectableSubItems
{
	[Serializable]
	private sealed class _0023_003Dz0gv_0024OStsgorXtenq7g_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Region, new()
	{
		public static readonly _0023_003Dz0gv_0024OStsgorXtenq7g_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003Dz0gv_0024OStsgorXtenq7g_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<Region, _0023_003DzWWgGxds_003D> _0023_003DzCfr64VVAgICMYkoJJA_003D_003D;

		public static Func<Region, _0023_003DzWWgGxds_003D> _0023_003Dzh7lQX1lRmliNsKiClQ_003D_003D;

		public static Func<Region, _0023_003DzWWgGxds_003D> _0023_003DzBFEk3tnO_ngRADEL_0024Q_003D_003D;

		internal _0023_003DzWWgGxds_003D _0023_003DzrfwPFsYRaWYJiT3jlU4nb20_003D(Region _0023_003DzRpXgovo_003D)
		{
			return (_0023_003DzWWgGxds_003D)_0023_003DzRpXgovo_003D;
		}

		internal _0023_003DzWWgGxds_003D _0023_003DzIXAuatCO_002440f6nv2u15wKIA_003D(Region _0023_003DzRpXgovo_003D)
		{
			return (_0023_003DzWWgGxds_003D)_0023_003DzRpXgovo_003D;
		}

		internal _0023_003DzWWgGxds_003D _0023_003DzKrv_0024BkXCqlGzjn4biNkpAgk_003D(Region _0023_003DzRpXgovo_003D)
		{
			return (_0023_003DzWWgGxds_003D)_0023_003DzRpXgovo_003D;
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<ICurve, bool> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		public static Func<Region, IEnumerable<ICurve>> _0023_003DzoAoPnkdvef9hk7unLQ_003D_003D;

		public static Func<ICurve, bool> _0023_003Dz3drBrPKBm72cXkBR_0024w_003D_003D;

		internal bool _0023_003DzASXree_0024KkpdZosrvzGNt2kG3yTAU(ICurve _0023_003DzF_0024_0024uyUw_003D)
		{
			return _0023_003DzF_0024_0024uyUw_003D.Length() > 0.0;
		}

		internal IEnumerable<ICurve> _0023_003DzDARgan7cjUOx6_iPa18InsU_003D(Region _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D.ContourList;
		}

		internal bool _0023_003DzjQNKpiznuyqYoZWdqsbU0XKnTDHY(ICurve _0023_003DzBJFJHwk_003D)
		{
			return ((Entity)_0023_003DzBJFJHwk_003D)._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D();
		}
	}

	internal enum _0023_003Dz4Hw_002424_0024xhqb8
	{

	}

	private sealed class _0023_003DzBnyQC_0024NLx9TdnmN_002481BEOPg_003D : IComparer<_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D>
	{
		public int Compare(_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D _0023_003DzBJFJHwk_003D, _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D _0023_003Dz40R7bAU_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003DzF7v9r2A_003D.X < _0023_003Dz40R7bAU_003D._0023_003DzF7v9r2A_003D.X)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003DzF7v9r2A_003D.X > _0023_003Dz40R7bAU_003D._0023_003DzF7v9r2A_003D.X)
			{
				return 1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003DzF7v9r2A_003D.Y < _0023_003Dz40R7bAU_003D._0023_003DzF7v9r2A_003D.Y)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003DzF7v9r2A_003D.Y > _0023_003Dz40R7bAU_003D._0023_003DzF7v9r2A_003D.Y)
			{
				return 1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003Dz8dK2uhU_003D.X < _0023_003Dz40R7bAU_003D._0023_003Dz8dK2uhU_003D.X)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003Dz8dK2uhU_003D.X > _0023_003Dz40R7bAU_003D._0023_003Dz8dK2uhU_003D.X)
			{
				return 1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003Dz8dK2uhU_003D.Y < _0023_003Dz40R7bAU_003D._0023_003Dz8dK2uhU_003D.Y)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003Dz8dK2uhU_003D.Y > _0023_003Dz40R7bAU_003D._0023_003Dz8dK2uhU_003D.Y)
			{
				return 1;
			}
			return 0;
		}
	}

	private sealed class _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D
	{
		public ICurve _0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D;

		public ICurve _0023_003DzKNDGjaLz92D9grl4xg_003D_003D;

		public Point3D _0023_003DzF7v9r2A_003D;

		public Point3D _0023_003Dz8dK2uhU_003D;

		public _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D(ICurve _0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D, ICurve _0023_003DzKNDGjaLz92D9grl4xg_003D_003D)
		{
			this._0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D = _0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D;
			this._0023_003DzKNDGjaLz92D9grl4xg_003D_003D = _0023_003DzKNDGjaLz92D9grl4xg_003D_003D;
			_0023_003DzNKw2dpKrk09r();
		}

		private void _0023_003DzNKw2dpKrk09r()
		{
			Point3D[] vertices = ((Entity)_0023_003DzKNDGjaLz92D9grl4xg_003D_003D).Vertices;
			_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
			_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
			Utility.UpdateMinMax(null, vertices, vertices.Length, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}
	}

	internal List<ICurve> contourList;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static int _0023_003Dz_0024cJ7ql_R_22_ = 1;

	protected IndexLine[] edges;

	private IndexTriangle[] _triangles;

	protected EntityGraphicsData drawEdges;

	public List<ICurve> ContourList
	{
		get
		{
			return contourList;
		}
		set
		{
			contourList = value;
			_0023_003DztGdcVOA_003D(contourList, null, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: false, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool HasHoles => contourList.Count > 1;

	public IndexLine[] Edges
	{
		get
		{
			return edges;
		}
		set
		{
			edges = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public IndexTriangle[] Triangles
	{
		get
		{
			return _triangles;
		}
		set
		{
			_triangles = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	internal List<SelectionInfoSubItems> SubContoursSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public selectionFilterType SelectionMode { get; set; } = selectionFilterType.Entity;

	public Region(ICurve outer, Plane pln)
		: this(new ICurve[1] { outer }, pln, sortAndOrient: true)
	{
	}

	public Region()
	{
		base.entityNature = entityNatureType.Polygon;
		contourList = new List<ICurve>();
	}

	public Region(ICurve outer)
		: this(new ICurve[1] { outer }, null, sortAndOrient: true)
	{
	}

	protected Region(Region another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		contourList = new List<ICurve>(another.contourList.Count);
		for (int i = 0; i < another.contourList.Count; i++)
		{
			contourList.Add((ICurve)(keepTessellation ? ((Entity)another.contourList[i]).CloneWithTessellation() : ((Entity)another.contourList[i]).Clone()));
		}
		if (keepTessellation)
		{
			Triangles = Utility._0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(another.Triangles);
			Edges = new IndexLine[another.Edges.Length];
			for (int j = 0; j < another.Edges.Length; j++)
			{
				Edges[j] = (IndexLine)another.Edges[j].Clone();
			}
		}
	}

	public Region(ICurve outer, Plane pln, bool sortAndOrient = true)
		: this(new ICurve[1] { outer }, pln, sortAndOrient)
	{
	}

	public Region(params ICurve[] contours)
		: this(contours, null, sortAndOrient: true)
	{
	}

	public Region(IList<ICurve> contours)
		: this(contours, null, sortAndOrient: true)
	{
	}

	public Region(IList<ICurve> contours, Plane pln)
		: this(contours, pln, sortAndOrient: true)
	{
	}

	public Region(IList<ICurve> contours, Plane pln, bool sortAndOrient)
		: this()
	{
		_0023_003DztGdcVOA_003D(contours, pln, sortAndOrient, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false);
	}

	internal Region(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D)
		: this()
	{
		_0023_003DztGdcVOA_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, _0023_003Dzpyw2kZk_003D, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
	}

	protected internal Region(RegionSurrogate surrogate)
		: this(new List<ICurve>(), null, sortAndOrient: true)
	{
	}

	internal Region(GRegion _0023_003DzQwa1qM0_003D)
		: this(new List<ICurve>(), null, sortAndOrient: true)
	{
		contourList = GEntity.CreateEntitiesFromPrimitives(_0023_003DzQwa1qM0_003D.ContourList).Cast<ICurve>().ToList();
		base.Plane = _0023_003DzQwa1qM0_003D.Plane;
	}

	protected Region(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		contourList = (List<ICurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970856), typeof(List<ICurve>));
	}

	public static ICurve[] Pocket(ICurve curve, double offset, Vector3D planeNormal, bool useSharpConnection)
	{
		return _0023_003DzPY0EbD8XKxmhUGkbUA_003D_003D(new ICurve[1] { curve }, null, offset, useSharpConnection, planeNormal);
	}

	public ICurve[] Pocket(double offset, Vector3D planeNormal, bool useSharpConnection)
	{
		List<ICurve> list = new List<ICurve>(ContourList.Count);
		List<ICurve> list2 = new List<ICurve>(ContourList.Count);
		foreach (ICurve contour in ContourList)
		{
			if (Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(contour, base.Plane))
			{
				list2.Add(contour);
			}
			else
			{
				list.Add(contour);
			}
		}
		return _0023_003DzPY0EbD8XKxmhUGkbUA_003D_003D(list, list2, offset, useSharpConnection, planeNormal);
	}

	private static ICurve[] _0023_003DzPY0EbD8XKxmhUGkbUA_003D_003D(IList<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D, IList<ICurve> _0023_003DzWrYD5tnsrnGickDaSw_003D_003D, double _0023_003DzfBEBL_o_003D, bool _0023_003DzcM9W6B4hvS52, Vector3D _0023_003Dz2ouPUQ9dmipO)
	{
		List<ICurve> list = new List<ICurve>();
		bool flag = true;
		if (_0023_003DzfBEBL_o_003D == 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975532));
		}
		if (_0023_003DzfBEBL_o_003D > 0.0)
		{
			_0023_003DzfBEBL_o_003D *= -1.0;
		}
		int num = 0;
		while (flag)
		{
			num++;
			ICurve[] array = _0023_003Dz8Yo227Ly3Bza(_0023_003DzItZ6aEugTCY435PyVw_003D_003D, _0023_003DzWrYD5tnsrnGickDaSw_003D_003D, _0023_003DzfBEBL_o_003D * (double)num, _0023_003DzcM9W6B4hvS52, _0023_003Dz2ouPUQ9dmipO);
			if (array != null && array.Length != 0)
			{
				IEnumerable<ICurve> enumerable = array.Where((ICurve _0023_003DzF_0024_0024uyUw_003D) => _0023_003DzF_0024_0024uyUw_003D.Length() > 0.0);
				if (enumerable.Any())
				{
					list.AddRange(enumerable);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
		}
		return list.ToArray();
	}

	private static ICurve[] _0023_003Dz8Yo227Ly3Bza(IList<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D, IList<ICurve> _0023_003DzWrYD5tnsrnGickDaSw_003D_003D, double _0023_003DzXHEPT_MmHybu, bool _0023_003DzcM9W6B4hvS52, Vector3D _0023_003Dz2ouPUQ9dmipO)
	{
		Plane _0023_003DzlqZnaxrmezyK;
		return _0023_003Dz8Yo227Ly3Bza(_0023_003DzItZ6aEugTCY435PyVw_003D_003D, _0023_003DzWrYD5tnsrnGickDaSw_003D_003D, _0023_003DzXHEPT_MmHybu, _0023_003DzcM9W6B4hvS52, _0023_003Dz2ouPUQ9dmipO, out _0023_003DzlqZnaxrmezyK);
	}

	private static ICurve[] _0023_003Dz8Yo227Ly3Bza(IList<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D, IList<ICurve> _0023_003DzWrYD5tnsrnGickDaSw_003D_003D, double _0023_003DzXHEPT_MmHybu, bool _0023_003DzcM9W6B4hvS52, Vector3D _0023_003Dz2ouPUQ9dmipO, out Plane _0023_003DzlqZnaxrmezyK)
	{
		_0023_003DzlqZnaxrmezyK = new Plane(_0023_003Dz2ouPUQ9dmipO);
		Dictionary<ICurve, ICurve[]> dictionary = new Dictionary<ICurve, ICurve[]>();
		foreach (ICurve item in _0023_003DzItZ6aEugTCY435PyVw_003D_003D.Concat(_0023_003DzWrYD5tnsrnGickDaSw_003D_003D))
		{
			ICurve[] array = item.Offset(_0023_003DzXHEPT_MmHybu, _0023_003Dz2ouPUQ9dmipO, _0023_003DzcM9W6B4hvS52);
			if (array != null)
			{
				dictionary.Add(item, array);
			}
		}
		Dictionary<ICurve, List<ICurve>> dictionary2 = new Dictionary<ICurve, List<ICurve>>();
		foreach (ICurve item2 in _0023_003DzItZ6aEugTCY435PyVw_003D_003D)
		{
			dictionary2.Add(item2, new List<ICurve>());
			foreach (ICurve item3 in _0023_003DzWrYD5tnsrnGickDaSw_003D_003D)
			{
				if (Difference(new Region(item2), new Region(item3)).Length != 0)
				{
					dictionary2[item2].Add(item3);
				}
			}
		}
		List<Region> list = new List<Region>();
		foreach (ICurve key in dictionary2.Keys)
		{
			List<Region> list2 = new List<Region>();
			if (dictionary.TryGetValue(key, out var value))
			{
				ICurve[] array2 = value;
				foreach (ICurve outer in array2)
				{
					list2.Add(new Region(outer));
				}
			}
			foreach (ICurve item4 in dictionary2[key])
			{
				List<Region> list3 = new List<Region>();
				if (!dictionary.TryGetValue(item4, out var value2))
				{
					continue;
				}
				Region b = new Region(value2);
				foreach (Region item5 in list2)
				{
					list3.AddRange(Difference(item5, b));
				}
				list2 = list3;
			}
			list.AddRange(list2);
		}
		return Union(list.ToArray()).SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzDARgan7cjUOx6_iPa18InsU_003D).ToArray();
	}

	internal void _0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out ICurve _0023_003Dz_SqBXz8_003D, out IList<ICurve> _0023_003DzWaFlkhfmYCja)
	{
		_0023_003Dz_SqBXz8_003D = ContourList[0];
		_0023_003DzWaFlkhfmYCja = null;
		if (ContourList.Count > 1)
		{
			_0023_003DzWaFlkhfmYCja = new List<ICurve>();
			for (int i = 1; i < ContourList.Count; i++)
			{
				_0023_003DzWaFlkhfmYCja.Add(ContourList[i]);
			}
		}
	}

	private void _0023_003DztGdcVOA_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D)
	{
		base.entityNature = entityNatureType.Polygon;
		if (_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count == 0)
		{
			return;
		}
		contourList = new List<ICurve>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count);
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			contourList.Add(Utility._0023_003Dz5gQsf2mKW9NP2e0Zyw_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i], _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D));
		}
		double num = 1E-12;
		if (_0023_003Dzpyw2kZk_003D == null || _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D)
		{
			num = _0023_003DzMnn_sI1bfuYs(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out var _);
		}
		if (_0023_003Dzpyw2kZk_003D == null)
		{
			if (_0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D)
			{
				base.Plane = EstimatePlane(contourList, num);
			}
			else
			{
				base.Plane = EstimatePlane(new List<ICurve> { contourList[0] }, num);
			}
			if (!_0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D && Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(Utility._0023_003Dzm2WwrkTQN7Q4HSrEZQ_003D_003D(contourList[0].GetIndividualCurves()), base.Plane))
			{
				base.Plane.Flip();
			}
		}
		else
		{
			base.Plane = (Plane)_0023_003Dzpyw2kZk_003D.Clone();
		}
		if (_0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D)
		{
			_0023_003DzdFMOSey8Cxz2dU1ngA_003D_003D(num, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
		}
	}

	public void SortAndOrient()
	{
		double _0023_003DzccAR5G0_003D;
		double _0023_003Dzm0CYiiE_003D = _0023_003DzMnn_sI1bfuYs(contourList, out _0023_003DzccAR5G0_003D);
		_0023_003DzdFMOSey8Cxz2dU1ngA_003D_003D(_0023_003Dzm0CYiiE_003D, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false);
	}

	private void _0023_003DzdFMOSey8Cxz2dU1ngA_003D_003D(double _0023_003Dzm0CYiiE_003D, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D)
	{
		ICurve[] array = new ICurve[contourList.Count];
		for (int i = 0; i < contourList.Count; i++)
		{
			array[i] = Utility._0023_003Dz5gQsf2mKW9NP2e0Zyw_003D_003D(contourList[i], _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
		}
		_0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(_0023_003Dzm0CYiiE_003D);
		if (contourList.Count > 1)
		{
			int outerIndex = Utility.GetOuterIndex(contourList, _0023_003Dzm0CYiiE_003D);
			Utility.Swap(ref array[outerIndex], ref array[0]);
			ICurve value = contourList[0];
			contourList[0] = contourList[outerIndex];
			contourList[outerIndex] = value;
		}
		for (int j = 0; j < contourList.Count; j++)
		{
			bool flag = Utility.IsOrientedClockwise(((Entity)contourList[j]).Vertices);
			if ((j == 0 && flag) || (j > 0 && !flag))
			{
				array[j].Reverse();
			}
		}
		for (int k = 0; k < contourList.Count; k++)
		{
			contourList[k] = array[k];
		}
	}

	public static Plane EstimatePlane(IList<ICurve> contourList, double tol)
	{
		Plane plane = null;
		foreach (ICurve contour in contourList)
		{
			if (contour is CompositeCurve)
			{
				ICurve[] individualCurves = contour.GetIndividualCurves();
				foreach (ICurve curve in individualCurves)
				{
					if (curve is PlanarEntity)
					{
						plane = (Plane)((PlanarEntity)curve).Plane.Clone();
						break;
					}
				}
			}
			else if (contour is PlanarEntity)
			{
				plane = (Plane)((PlanarEntity)contour).Plane.Clone();
				break;
			}
			if (plane != null)
			{
				break;
			}
		}
		if (plane == null)
		{
			Entity entity = (Entity)contourList[0];
			entity.Regen(tol);
			if (_0023_003Dz0x9TUkZMkF9FMWTNDvpH7i4_003D(contourList[0], tol) && !((ICurve)entity).IsPlanar(tol, out plane))
			{
				plane = Utility.FitPlane(entity.Vertices);
			}
		}
		if (!(plane == null))
		{
			return plane;
		}
		return Plane.XY;
	}

	internal static double _0023_003DzMnn_sI1bfuYs(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out double _0023_003DzccAR5G0_003D)
	{
		List<Point3D> list = new List<Point3D>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count * 2);
		foreach (Entity item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			list.AddRange(item.EstimateBoundingBox(null, null));
		}
		Utility.ComputeBoundingBox(new Identity(), list, out var boxMin, out var boxMax);
		_0023_003DzccAR5G0_003D = new Size3D(boxMin, boxMax).Diagonal;
		return _0023_003DzccAR5G0_003D * Utility._0023_003Dzjyaz_Vfaky9X;
	}

	private static bool _0023_003Dz0x9TUkZMkF9FMWTNDvpH7i4_003D(ICurve _0023_003Dz06A5WivSSyUp, double _0023_003Dzm0CYiiE_003D)
	{
		Entity entity = (Entity)_0023_003Dz06A5WivSSyUp;
		if (_0023_003Dz06A5WivSSyUp.IsClosed && entity.Vertices.Length < 4)
		{
			int num = 0;
			while (entity.Vertices.Length < 4)
			{
				_0023_003Dzm0CYiiE_003D /= 10.0;
				entity.Regen(_0023_003Dzm0CYiiE_003D);
				if (num++ > 8)
				{
					return false;
				}
			}
		}
		return true;
	}

	private void _0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(double _0023_003Dzm0CYiiE_003D)
	{
		_0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(base.Plane, contourList, _0023_003Dzm0CYiiE_003D);
	}

	private static void _0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(Plane _0023_003Dzrgqz890sj_0024X9, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		foreach (Entity item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			item.Regen(_0023_003Dzm0CYiiE_003D);
			item.RegenMode = regenType.RegenAndCompile;
			if (((ICurve)item).IsClosed && item.Vertices.Length < 4)
			{
				_0023_003Dz0x9TUkZMkF9FMWTNDvpH7i4_003D((ICurve)item, _0023_003Dzm0CYiiE_003D);
			}
			_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(_0023_003Dzrgqz890sj_0024X9, item);
		}
	}

	private static void _0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Entity _0023_003DzvM_00244CJo_003D)
	{
		_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003DzvM_00244CJo_003D.Vertices);
	}

	private static void _0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 != Plane.XY)
		{
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
			{
				Point2D point2D = _0023_003Dzrgqz890sj_0024X9.Project(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = new Point3D(point2D.X, point2D.Y);
			}
		}
	}

	public ICurve[] Offset(double amount)
	{
		return Offset(amount, sharp: false);
	}

	public ICurve[] Offset(double amount, bool sharp)
	{
		List<ICurve> list = new List<ICurve>(ContourList.Count);
		List<ICurve> list2 = new List<ICurve>(ContourList.Count);
		foreach (ICurve contour in ContourList)
		{
			if (Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(contour, base.Plane))
			{
				list2.Add(contour);
			}
			else
			{
				list.Add(contour);
			}
		}
		return _0023_003Dz8Yo227Ly3Bza(list, list2, amount, sharp, base.Plane.AxisZ);
	}

	internal static void _0023_003DzQbafGYZlxDIJXjIhzg_003D_003D(ICurve[] _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out int _0023_003DzLFA2gNM_003D, out bool[] _0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D)
	{
		ICurve[] array = new ICurve[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length];
		_0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D = new bool[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length];
		Plane plane = null;
		List<Point3D> list = new List<Point3D>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length * 2);
		ICurve[] array2 = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D;
		for (int i = 0; i < array2.Length; i++)
		{
			Entity entity = (Entity)array2[i];
			list.AddRange(entity.EstimateBoundingBox(null, null));
		}
		Utility.ComputeBoundingBox(new Identity(), list, out var boxMin, out var boxMax);
		double num = new Size3D(boxMin, boxMax).Diagonal * 0.001;
		for (int j = 0; j < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length; j++)
		{
			Entity entity2 = (Entity)_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[j];
			array[j] = (ICurve)entity2.Clone();
		}
		array2 = array;
		for (int i = 0; i < array2.Length && !array2[i].IsPlanar(num / 10.0, out plane); i++)
		{
		}
		if (plane == null)
		{
			Entity obj = (Entity)array[0];
			obj.Regen(num);
			plane = Utility.FitPlane(obj.Vertices);
		}
		if (plane == null)
		{
			plane = Plane.XY;
		}
		if (plane.AxisZ != new Vector3D(0.0, 0.0, 1.0) && plane.AxisZ != new Vector3D(0.0, 0.0, -1.0))
		{
			Transformation transformation = new Transformation();
			transformation.Rotation(plane, Plane.XY);
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Entity entity3 = (Entity)array2[i];
				entity3.Regen(num);
				for (int k = 0; k < entity3.Vertices.Length; k++)
				{
					entity3.Vertices[k] = transformation * entity3.Vertices[k];
				}
			}
		}
		_0023_003DzLFA2gNM_003D = Utility.GetOuterIndex(array, num);
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Reset();
		stopwatch.Start();
		for (int l = 0; l < array.Length; l++)
		{
			((Entity)array[l]).Regen(num);
			if (Utility.PolygonOrientation(((Entity)array[l]).Vertices) < 0.0)
			{
				if (l == _0023_003DzLFA2gNM_003D)
				{
					_0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D[l] = false;
				}
				else
				{
					_0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D[l] = true;
				}
			}
			else if (l == _0023_003DzLFA2gNM_003D)
			{
				_0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D[l] = true;
			}
			else
			{
				_0023_003Dzup7z0_00248yU8sBdbCWNA_003D_003D[l] = false;
			}
		}
		stopwatch.Stop();
	}

	public override object Clone()
	{
		return new Region(this);
	}

	public override object CloneWithTessellation()
	{
		return new Region(this, RegenMode != regenType.RegenAndCompile);
	}

	public Mesh ConvertToMesh(double deviation, Mesh.natureType nature)
	{
		return ConvertToMesh<Mesh>(deviation, Math.PI / 6.0, nature);
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Plain, bool weld = true)
	{
		return ConvertToMesh<Mesh>(deviation, angle, nature);
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToSurface().ConvertToBrep(mergeFaces, mergeEdges);
	}

	public T ConvertToMesh<T>(double deviation = 0.0, double angle = 0.0, Mesh.natureType meshNature = Mesh.natureType.Plain) where T : Mesh, new()
	{
		if (deviation == 0.0)
		{
			if (_vertices == null)
			{
				if (IsCurved())
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964005));
				}
				Regen(new RegenParams(0.0, 0.0));
			}
			T val = new T();
			val._0023_003DztGdcVOA_003D(meshNature, Mesh.edgeStyleType.Free);
			val.Vertices = new Point3D[_vertices.Length];
			for (int i = 0; i < _vertices.Length; i++)
			{
				Point3D point3D = _vertices[i];
				val.Vertices[i] = Utility.CreateVertex(meshNature, point3D.X, point3D.Y, point3D.Z);
			}
			val.Triangles = new IndexTriangle[_triangles.Length];
			for (int j = 0; j < _triangles.Length; j++)
			{
				IndexTriangle indexTriangle = _triangles[j];
				val.Triangles[j] = Utility.CreateTriangle(meshNature, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
			}
			if (edges != null)
			{
				val.Edges = new IndexLine[edges.Length];
				for (int k = 0; k < edges.Length; k++)
				{
					val.Edges[k] = edges[k];
				}
			}
			val.CopyAttributes(this);
			return val;
		}
		Region obj = (Region)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToMesh<T>(0.0, 0.0, meshNature);
	}

	public Solid ConvertToSolid(double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			return ConvertToMesh().ConvertToSolid();
		}
		return ConvertToSolid<Solid>(tolerance);
	}

	public T ConvertToSolid<T>(double tolerance) where T : Solid, new()
	{
		List<ICurve> list = new List<ICurve>(contourList);
		list.RemoveAt(0);
		T val = Solid._0023_003DzranJPDlPiZC7<T>(contourList[0], list, tolerance);
		val.CopyAttributes(this);
		return val;
	}

	public PlanarSurface ConvertToSurface()
	{
		List<ICurve> list = new List<ICurve>(contourList);
		list.RemoveAt(0);
		PlanarSurface planarSurface = Surface.CreatePlanar(base.Plane, contourList[0], list, sortAndOrient: false);
		planarSurface.CopyAttributes(this);
		return planarSurface;
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < contourList.Count; i++)
		{
			list.Add(contourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return Surface._0023_003Dz1A9iP9WIToC5(rail, contourList[0], list, tol, _0023_003DzbErHvVw_003D: true, methodType);
	}

	public Brep SweepAsBrep(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep[] array = Brep._0023_003Dz1A9iP9WIToC5(rail, this, tol, _0023_003DzjepEGXc_003D: true, methodType);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Brep[] SweepAsBrep(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Brep._0023_003Dz1A9iP9WIToC5(rail, this, tol, merge, methodType);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < contourList.Count; i++)
		{
			list.Add(contourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return Mesh._0023_003Dz1A9iP9WIToC5<Mesh>(rail, contourList[0], list, tol, _0023_003DzbErHvVw_003D: true, methodType, natureType, _0023_003DzjepEGXc_003D: true)[0];
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < contourList.Count; i++)
		{
			list.Add(contourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return Mesh._0023_003Dz1A9iP9WIToC5<T>(rail, contourList[0], list, tol, _0023_003DzbErHvVw_003D: true, methodType, natureType, _0023_003DzjepEGXc_003D: true)[0];
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < contourList.Count; i++)
		{
			list.Add(contourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return Mesh._0023_003Dz1A9iP9WIToC5<Mesh>(rail, contourList[0], list, tol, _0023_003DzbErHvVw_003D: true, methodType, natureType, merge);
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < contourList.Count; i++)
		{
			list.Add(contourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return Mesh._0023_003Dz1A9iP9WIToC5<T>(rail, contourList[0], list, tol, _0023_003DzbErHvVw_003D: true, methodType, natureType, merge)[0];
	}

	private bool _0023_003DzkYsYyRRWyFqw(ICurve _0023_003Dz8EhW_0024omtFk2M, ICurve _0023_003DzWB5w2Msi2ASb)
	{
		if (_0023_003DzWB5w2Msi2ASb.StartPoint == _0023_003Dz8EhW_0024omtFk2M.EndPoint)
		{
			return true;
		}
		if (_0023_003DzWB5w2Msi2ASb.StartPoint.DistanceTo(_0023_003Dz8EhW_0024omtFk2M.EndPoint) <= 0.001)
		{
			return true;
		}
		return false;
	}

	private bool _0023_003Dz15uamlTDxReX(ICurve _0023_003DzQvaHyao_003D, ICurve _0023_003DzNyidyKE_003D)
	{
		if (Vector3D.AreCoincident(_0023_003DzQvaHyao_003D.TangentAt(0.0), _0023_003DzNyidyKE_003D.TangentAt(0.0)))
		{
			return true;
		}
		return false;
	}

	public override void Regen(RegenParams data)
	{
		List<Point3D> list = new List<Point3D>();
		foreach (Entity contour in contourList)
		{
			contour.Regen(data);
			list.AddRange(contour.Vertices);
		}
		_vertices = list.ToArray();
		UpdateBoundingBox(data);
		Point3D[] array = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(((Entity)contourList[0]).Vertices);
		_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(base.Plane, array);
		Point3D[][] array2 = new Point3D[contourList.Count - 1][];
		for (int i = 1; i < contourList.Count; i++)
		{
			array2[i - 1] = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(((Entity)contourList[i]).Vertices);
			_0023_003DzhKsL3PnP5CA1v8_0024c1w_003D_003D(base.Plane, array2[i - 1]);
		}
		Point2D[] vertices = null;
		int num = array.Length;
		if (num > 3 || contourList.Count > 1)
		{
			try
			{
				if (!Utility.Triangulate(array, array2, fixOrientation: false, checkValidity: true, out vertices, out _triangles))
				{
					Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
					_0023_003Dzs_MhYMunBcKFXkEiSVaj3_0_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref vertices, out _triangles);
				}
			}
			catch (Exception)
			{
				Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
				_0023_003Dzs_MhYMunBcKFXkEiSVaj3_0_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref vertices, out _triangles);
			}
		}
		else if (num > 2)
		{
			vertices = new Point2D[3];
			for (int j = 0; j < 3; j++)
			{
				vertices[j] = new Point2D(array[j].X, array[j].Y);
			}
			_triangles = new IndexTriangle[1]
			{
				new IndexTriangle(0, 1, 2)
			};
		}
		else
		{
			vertices = new Point2D[0];
			_triangles = new IndexTriangle[0];
		}
		_0023_003DzRPB8Ocs_003D(vertices);
		_0023_003Dz_00243BkrQa_0024lDIE();
		RegenMode = regenType.CompileOnly;
	}

	private void _0023_003Dzs_MhYMunBcKFXkEiSVaj3_0_003D(Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref Point2D[] _0023_003DzZ86NWzV6mlAE, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		_0023_003DzZ86NWzV6mlAE = new Point2D[2]
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]
		};
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[0];
	}

	private void _0023_003DzRPB8Ocs_003D(Point2D[] _0023_003DzZ86NWzV6mlAE)
	{
		_vertices = new Point3D[_0023_003DzZ86NWzV6mlAE.Length];
		if (_0023_003DzZ86NWzV6mlAE.Length != 0)
		{
			for (int i = 0; i < _0023_003DzZ86NWzV6mlAE.Length; i++)
			{
				_vertices[i] = base.Plane.PointAt(_0023_003DzZ86NWzV6mlAE[i].X, _0023_003DzZ86NWzV6mlAE[i].Y);
			}
		}
	}

	private static IList<Point2D> _0023_003DzAjvTF_0024wZzMN0keVuvw_003D_003D(IList<Point3D> _0023_003DzsSLPcz8_003D, Transformation _0023_003Dz9ZUzIX4xmsyA)
	{
		Point2D[] array = new Point2D[_0023_003DzsSLPcz8_003D.Count];
		for (int i = 0; i < _0023_003DzsSLPcz8_003D.Count; i++)
		{
			array[i] = _0023_003Dz9ZUzIX4xmsyA * _0023_003DzsSLPcz8_003D[i];
		}
		return array;
	}

	private static ICurve[] _0023_003DzgF2A6VG1DNgsTozDJI8ZfgY_003D(ICurve _0023_003Dz_SqBXz8_003D)
	{
		List<ICurve> list;
		if (_0023_003Dz_SqBXz8_003D is CompositeCurve)
		{
			CompositeCurve compositeCurve = (CompositeCurve)_0023_003Dz_SqBXz8_003D;
			Entity[] array = new Entity[compositeCurve.CurveList.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (Entity)compositeCurve.CurveList[i];
			}
			list = new List<ICurve>(array.Length);
			for (int j = 0; j < array.Length; j++)
			{
				list.AddRange(_0023_003DzgF2A6VG1DNgsTozDJI8ZfgY_003D((ICurve)array[j]));
			}
		}
		else
		{
			if (!(_0023_003Dz_SqBXz8_003D is LinearPath))
			{
				if (_0023_003Dz_SqBXz8_003D.Length() > 1E-12)
				{
					return new ICurve[1] { _0023_003Dz_SqBXz8_003D };
				}
				return new ICurve[0];
			}
			Line[] array2 = ((LinearPath)_0023_003Dz_SqBXz8_003D).ConvertToLines();
			List<ICurve> list2 = new List<ICurve>(array2.Length);
			for (int k = 0; k < array2.Length; k++)
			{
				if (array2[k].Length() > 1E-12)
				{
					list2.Add(array2[k]);
				}
			}
			list = list2;
		}
		return list.ToArray();
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return ((Entity)contourList[0]).EstimateBoundingBox(blocks, layers);
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Entity contour in contourList)
		{
			contour.TransformBy(xform);
		}
		base.TransformBy(xform);
	}

	[Obsolete("Use the PlaneMesher class instead.")]
	public Mesh Triangulate(double elementSize, int smoothingPasses = 4, IList<LinearPath> hardEdges = null)
	{
		return Utility.Triangulate(this, elementSize, smoothingPasses, hardEdges);
	}

	public override bool IsValid(StringBuilder log = null)
	{
		return _0023_003DzVah3ez1d4KfO(_0023_003DzWeim0UolVr6XqOBEml_00240oWU_003D: true, log);
	}

	internal bool _0023_003DzVah3ez1d4KfO(bool _0023_003DzWeim0UolVr6XqOBEml_00240oWU_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		if (contourList.Count < 1)
		{
			_0023_003DzqmF8XJ0_003D?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975738));
			return false;
		}
		if (_0023_003DzWeim0UolVr6XqOBEml_00240oWU_003D)
		{
			for (int i = 0; i < contourList.Count; i++)
			{
				if (!contourList[i].IsClosed)
				{
					_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975700), i));
					return false;
				}
			}
		}
		for (int j = 0; j < contourList.Count; j++)
		{
			Entity entity = (Entity)contourList[j];
			if (entity is CompositeCurve)
			{
				CompositeCurve compositeCurve = (CompositeCurve)entity;
				if (compositeCurve.CurveList.Count == 0)
				{
					_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975650), j));
					return false;
				}
				foreach (Entity curve in compositeCurve.CurveList)
				{
					if (!curve.IsValid(_0023_003DzqmF8XJ0_003D))
					{
						return false;
					}
				}
			}
			else if (!entity.IsValid(_0023_003DzqmF8XJ0_003D))
			{
				return false;
			}
		}
		Region region = (Region)Clone();
		double _0023_003DzccAR5G0_003D;
		double num = _0023_003DzMnn_sI1bfuYs(region.contourList, out _0023_003DzccAR5G0_003D);
		region._0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(num);
		if (ContourList.Count > 1 && Utility.GetOuterIndex(region.ContourList, num) != 0)
		{
			_0023_003DzqmF8XJ0_003D?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976369));
			return false;
		}
		for (int k = 0; k < region.contourList.Count; k++)
		{
			Point3D[] vertices = ((Entity)region.contourList[k]).Vertices;
			bool flag = Utility.IsOrientedClockwise(vertices);
			if ((k == 0 && flag) || (k > 0 && !flag))
			{
				_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976327), k));
				return false;
			}
			if (Utility.IsPolygonSelfIntersecting(vertices))
			{
				_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976258), k));
				return false;
			}
		}
		return base.IsValid(_0023_003DzqmF8XJ0_003D);
	}

	public bool IsPointOnContour(Point3D testPoint, double tol)
	{
		for (int i = 0; i < ContourList.Count; i++)
		{
			ICurve curve = ContourList[i];
			curve.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			if (i == 0)
			{
				if (!(testPoint.X >= boxMin.X - tol) || !(testPoint.X <= boxMax.X + tol) || !(testPoint.Y >= boxMin.Y - tol) || !(testPoint.Y <= boxMax.Y + tol) || !(testPoint.Z >= boxMin.Z - tol) || !(testPoint.Z <= boxMax.Z + tol))
				{
					return false;
				}
				curve.ClosestPointTo(testPoint, out var t);
				Point3D b = curve.PointAt(t);
				if (Point3D.Distance(testPoint, b) < tol)
				{
					return true;
				}
			}
			else if (testPoint.X >= boxMin.X - tol && testPoint.X <= boxMax.X + tol && testPoint.Y >= boxMin.Y - tol && testPoint.Y <= boxMax.Y + tol && testPoint.Z >= boxMin.Z - tol && testPoint.Z <= boxMax.Z + tol)
			{
				curve.ClosestPointTo(testPoint, out var t2);
				Point3D b2 = curve.PointAt(t2);
				if (Point3D.Distance(testPoint, b2) < tol)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsPointInside(Point2D testPoint)
	{
		return IsPointInside(base.Plane.PointAt(testPoint));
	}

	public bool IsPointInside(Point3D testPoint)
	{
		double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D = Utility.DegToRad(7.0);
		Line _0023_003DzQ9zpGF0_003D = _0023_003Dz5EJoAEf30zan(testPoint, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D);
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < ContourList.Count; i++)
		{
			ICurve curve = ContourList[i];
			curve.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			Point3D[] array2;
			if (i == 0)
			{
				if (((testPoint.X > boxMin.X && testPoint.X < boxMax.X) || (Utility.Compare(boxMin.X, boxMax.X) == 0 && Utility.Compare(testPoint.X, boxMin.X) == 0 && Utility.Compare(testPoint.X, boxMax.X) == 0)) && ((testPoint.Y > boxMin.Y && testPoint.Y < boxMax.Y) || (Utility.Compare(boxMin.Y, boxMax.Y) == 0 && Utility.Compare(testPoint.Y, boxMin.Y) == 0 && Utility.Compare(testPoint.Y, boxMax.Y) == 0)) && ((testPoint.Z > boxMin.Z && testPoint.Z < boxMax.Z) || (Utility.Compare(boxMin.Z, boxMax.Z) == 0 && Utility.Compare(testPoint.Z, boxMin.Z) == 0 && Utility.Compare(testPoint.Z, boxMax.Z) == 0)))
				{
					Point3D[] array = _0023_003DzIwuUsQbKIxbBdFtRrq8yNwAtjSm7(testPoint, curve, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzQ9zpGF0_003D, 0);
					if (array != null)
					{
						int num = 0;
						array2 = array;
						foreach (Point3D point3D in array2)
						{
							if (!point3D.Equals(testPoint))
							{
								list.Add(point3D);
								num++;
							}
						}
						if ((num & 1) == 1)
						{
							continue;
						}
					}
					return false;
				}
				return false;
			}
			if (((!(testPoint.X > boxMin.X) || !(testPoint.X < boxMax.X)) && (Utility.Compare(boxMin.X, boxMax.X) != 0 || Utility.Compare(testPoint.X, boxMin.X) != 0 || Utility.Compare(testPoint.X, boxMax.X) != 0)) || ((!(testPoint.Y > boxMin.Y) || !(testPoint.Y < boxMax.Y)) && (Utility.Compare(boxMin.Y, boxMax.Y) != 0 || Utility.Compare(testPoint.Y, boxMin.Y) != 0 || Utility.Compare(testPoint.Y, boxMax.Y) != 0)) || ((!(testPoint.Z > boxMin.Z) || !(testPoint.Z < boxMax.Z)) && (Utility.Compare(boxMin.Z, boxMax.Z) != 0 || Utility.Compare(testPoint.Z, boxMin.Z) != 0 || Utility.Compare(testPoint.Z, boxMax.Z) != 0)))
			{
				continue;
			}
			Point3D[] array3 = _0023_003DzIwuUsQbKIxbBdFtRrq8yNwAtjSm7(testPoint, curve, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzQ9zpGF0_003D, 0);
			int num2 = 0;
			array2 = array3;
			foreach (Point3D point3D2 in array2)
			{
				if (!point3D2.Equals(testPoint))
				{
					list.Add(point3D2);
					num2++;
				}
			}
			if ((num2 & 1) == 1)
			{
				return false;
			}
		}
		return true;
	}

	private Point3D[] _0023_003DzIwuUsQbKIxbBdFtRrq8yNwAtjSm7(Point3D _0023_003DzZTe_0024jFG9ebLg, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, Line _0023_003DzQ9zpGF0_003D, int _0023_003DzGZJjBjo_003D)
	{
		if (_0023_003DzGZJjBjo_003D > 100)
		{
			return null;
		}
		if (_0023_003DzQ9zpGF0_003D == null)
		{
			_0023_003DzQ9zpGF0_003D = _0023_003Dz5EJoAEf30zan(_0023_003DzZTe_0024jFG9ebLg, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D);
		}
		Point3D[] significantPointsOnICurve = Utility.GetSignificantPointsOnICurve(_0023_003Dz8fpRyMu9aKjE);
		bool flag = false;
		Point3D[] array = significantPointsOnICurve;
		foreach (Point3D point3D in array)
		{
			Segment3D segment3D = new Segment3D(_0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint);
			double num = segment3D.Project(point3D);
			if (num > -1E-12 && num < 1.000000000001 && Point3D.DistanceSquared(point3D, segment3D.PointAt(num)) < Utility._0023_003DzheSR8QM7q9ya)
			{
				if (!(Point3D.DistanceSquared(_0023_003DzZTe_0024jFG9ebLg, point3D) < 1E-12))
				{
					flag = true;
					break;
				}
				return new Point3D[1] { point3D };
			}
		}
		if (flag)
		{
			_0023_003DzGZJjBjo_003D++;
			return _0023_003DzIwuUsQbKIxbBdFtRrq8yNwAtjSm7(_0023_003DzZTe_0024jFG9ebLg, _0023_003Dz8fpRyMu9aKjE, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D + _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, null, _0023_003DzGZJjBjo_003D);
		}
		Point3D[] array2 = _0023_003DzVVl1HRTTYIl0TqqJ4w_003D_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dz8fpRyMu9aKjE);
		if (array2 != null && array2.Length != 0)
		{
			array = array2;
			foreach (Point3D point3D2 in array)
			{
				if (Vector3D.AreParallel(_0023_003Dz8fpRyMu9aKjE.TangentAt(((InterPoint)point3D2).s), _0023_003DzQ9zpGF0_003D.StartTangent))
				{
					_0023_003DzGZJjBjo_003D++;
					array2 = _0023_003DzIwuUsQbKIxbBdFtRrq8yNwAtjSm7(_0023_003DzZTe_0024jFG9ebLg, _0023_003Dz8fpRyMu9aKjE, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D + _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, null, _0023_003DzGZJjBjo_003D);
					break;
				}
			}
		}
		return array2;
	}

	private Point3D[] _0023_003DzVVl1HRTTYIl0TqqJ4w_003D_003D(Line _0023_003DzOGUeWbk_003D, ICurve _0023_003Dz06A5WivSSyUp)
	{
		List<ICurve> list = new List<ICurve>();
		if (_0023_003Dz06A5WivSSyUp is LinearPath)
		{
			list.AddRange(((LinearPath)_0023_003Dz06A5WivSSyUp).ConvertToLines());
		}
		else if (_0023_003Dz06A5WivSSyUp is CompositeCurve)
		{
			list.AddRange(((CompositeCurve)_0023_003Dz06A5WivSSyUp)._0023_003DzpoMoKemHyOl4());
		}
		else
		{
			list.Add(_0023_003Dz06A5WivSSyUp);
		}
		List<Point3D> list2 = new List<Point3D>();
		double num = 0.0;
		foreach (ICurve item in list)
		{
			Point3D[] array = _0023_003DzOGUeWbk_003D.IntersectWith(item);
			foreach (Point3D point3D in array)
			{
				((InterPoint)point3D).s += num - item.Domain.Low;
				list2.Add(point3D);
			}
			num += item.Domain.Length;
		}
		return list2.ToArray();
	}

	private Line _0023_003Dz5EJoAEf30zan(Point3D _0023_003DzZTe_0024jFG9ebLg, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D)
	{
		Vector3D vector3D = (Vector3D)base.Plane.AxisX.Clone();
		vector3D.TransformBy(new Rotation(_0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, base.Plane.AxisZ, Point3D.Origin));
		Segment3D segment3D = new Segment3D(_0023_003DzZTe_0024jFG9ebLg, _0023_003DzZTe_0024jFG9ebLg + vector3D);
		Point3D[] array = Utility._0023_003DzHgehaXbXsoae65o_R1WkC5o_003D(ContourList[0]);
		double num = double.MinValue;
		Point3D[] array2 = array;
		foreach (Point3D pt in array2)
		{
			double num2 = segment3D.Project(pt);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return new Line(_0023_003DzZTe_0024jFG9ebLg, _0023_003DzZTe_0024jFG9ebLg + num * vector3D);
	}

	internal bool _0023_003DzrfhmnHeX0Pzt(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzxH4ozIo_003D)
	{
		Point3D testPoint = base.Plane.PointAt(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		return IsPointInside(testPoint);
	}

	private static List<T> _0023_003DzNC7p9G80lhFN<T>(Region _0023_003Dz3FeGe_0024g_003D, Region _0023_003DzS34bGBo_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D) where T : Region, new()
	{
		return _0023_003DzNC7p9G80lhFN<T>(_0023_003Dz3FeGe_0024g_003D, _0023_003DzS34bGBo_003D, _0023_003DzwY9ClXw_003D, (_0023_003Dz4Hw_002424_0024xhqb8)2);
	}

	private static List<T> _0023_003DzNC7p9G80lhFN<T>(Region _0023_003Dz3FeGe_0024g_003D, Region _0023_003DzS34bGBo_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, _0023_003Dz4Hw_002424_0024xhqb8 _0023_003Dz5hhFr5g_003D) where T : Region, new()
	{
		if (_0023_003Dz5hhFr5g_003D == (_0023_003Dz4Hw_002424_0024xhqb8)2)
		{
			ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D;
			ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D;
			switch (_0023_003DzwY9ClXw_003D)
			{
			case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0:
				return _0023_003DzNXGCQkhQtRkNL5Wfh_0024VyMFYjbHwY_0024emHzlK8LSB2_0024jeLSLMuCLFLfYU_003D._0023_003DzrIsIvtI_003D(_0023_003Dz3FeGe_0024g_003D, _0023_003DzS34bGBo_003D, 0.1, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D).Select(_0023_003Dz0gv_0024OStsgorXtenq7g_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzrfwPFsYRaWYJiT3jlU4nb20_003D).ToList();
			case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2:
				return (from _0023_003DzRpXgovo_003D in _0023_003DzNXGCQkhQtRkNL5Wfh_0024VyMFYjbHwY_0024emHzlK8LSB2_0024jeLSLMuCLFLfYU_003D._0023_003DzoTH8BDg_003D(_0023_003Dz3FeGe_0024g_003D, _0023_003DzS34bGBo_003D, 0.1, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D)
					select (T)_0023_003DzRpXgovo_003D).ToList();
			case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)1:
				return (from _0023_003DzRpXgovo_003D in _0023_003DzNXGCQkhQtRkNL5Wfh_0024VyMFYjbHwY_0024emHzlK8LSB2_0024jeLSLMuCLFLfYU_003D._0023_003DzQ7usAag_003D(_0023_003Dz3FeGe_0024g_003D, _0023_003DzS34bGBo_003D, 0.1, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D)
					select (T)_0023_003DzRpXgovo_003D).ToList();
			}
		}
		double[] array = new double[_0023_003Dz3FeGe_0024g_003D.contourList.Count];
		double[] array2 = new double[_0023_003DzS34bGBo_003D.contourList.Count];
		for (int num = 0; num < _0023_003Dz3FeGe_0024g_003D.contourList.Count; num++)
		{
			array[num] = Utility._0023_003DzcWsuvoQfLK3L((Entity)_0023_003Dz3FeGe_0024g_003D.contourList[num]);
		}
		for (int num2 = 0; num2 < _0023_003DzS34bGBo_003D.contourList.Count; num2++)
		{
			array2[num2] = Utility._0023_003DzcWsuvoQfLK3L((Entity)_0023_003DzS34bGBo_003D.contourList[num2]);
		}
		if (Math.Abs(Math.Abs(Vector3D.Dot(_0023_003Dz3FeGe_0024g_003D.Plane.AxisZ, _0023_003DzS34bGBo_003D.Plane.AxisZ)) - 1.0) > Utility._0023_003DzxhnLabVjXjPg)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976469));
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003Dz3FeGe_0024g_003D.Plane, Plane.XY);
		_0023_003Dz3FeGe_0024g_003D._0023_003DzG8omomNI5M4e(transformation, array, out var _0023_003DzDAlzmkKXg2Fq, out var _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D, out var _0023_003DzmRO0U_3b8uUk, out var _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D, out var _0023_003DzItZ6aEugTCY435PyVw_003D_003D, out var _0023_003DzWrYD5tnsrnGickDaSw_003D_003D);
		_0023_003DzS34bGBo_003D._0023_003DzG8omomNI5M4e(transformation, array2, out var _0023_003DzDAlzmkKXg2Fq2, out var _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D2, out var _0023_003DzmRO0U_3b8uUk2, out var _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D2, out var _0023_003DzItZ6aEugTCY435PyVw_003D_003D2, out var _0023_003DzWrYD5tnsrnGickDaSw_003D_003D2);
		_0023_003Dz0wcqTpk_003D(_0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D);
		_0023_003Dz0wcqTpk_003D(_0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D2);
		_0023_003Dz0wcqTpk_003D(_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D);
		_0023_003Dz0wcqTpk_003D(_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D2);
		_0023_003Dz0wcqTpk_003D(_0023_003DzWrYD5tnsrnGickDaSw_003D_003D);
		_0023_003Dz0wcqTpk_003D(_0023_003DzWrYD5tnsrnGickDaSw_003D_003D2);
		Point2D _0023_003DzF7v9r2A_003D;
		Point2D _0023_003Dz8dK2uhU_003D;
		IntegerGrid _0023_003DzOSo8vaE_003D = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK._0023_003Dz_LrsyseLeNti(_0023_003Dz_0024cJ7ql_R_22_, new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> { _0023_003DzmRO0U_3b8uUk, _0023_003DzmRO0U_3b8uUk2 }, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzYkgRucGPvHIg = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.Plane, _0023_003DzDAlzmkKXg2Fq, _0023_003DzmRO0U_3b8uUk, _0023_003DzItZ6aEugTCY435PyVw_003D_003D, _0023_003DzOSo8vaE_003D);
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzXUjJnNL3eU8F = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.Plane, _0023_003DzDAlzmkKXg2Fq2, _0023_003DzmRO0U_3b8uUk2, _0023_003DzItZ6aEugTCY435PyVw_003D_003D2, _0023_003DzOSo8vaE_003D);
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D.Count);
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D2.Count);
		for (int num3 = 0; num3 < _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D.Count; num3++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.Plane, _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D[num3], _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D[num3], _0023_003DzWrYD5tnsrnGickDaSw_003D_003D[num3], _0023_003DzOSo8vaE_003D);
			list.Add(item);
		}
		for (int num4 = 0; num4 < _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D2.Count; num4++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item2 = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.Plane, _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D2[num4], _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D2[num4], _0023_003DzWrYD5tnsrnGickDaSw_003D_003D2[num4], _0023_003DzOSo8vaE_003D);
			list2.Add(item2);
		}
		double diagonal = new Size2D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D).Diagonal;
		return _0023_003DzDCDx01zD1wSe<T>(_0023_003DzYkgRucGPvHIg, list, _0023_003DzXUjJnNL3eU8F, list2, _0023_003Dz3FeGe_0024g_003D.Plane, _0023_003DzOSo8vaE_003D, _0023_003DzwY9ClXw_003D, diagonal);
	}

	internal void _0023_003DzG8omomNI5M4e(Transformation _0023_003DzMm1YBsyPIWTQ, double[] _0023_003DzUTSHHoU9mzsp, out IList<IList<Point3D>> _0023_003DzDAlzmkKXg2Fq, out IList<IList<IList<Point3D>>> _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D, out _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003DzmRO0U_3b8uUk, out IList<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D, out IList<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D, out IList<IList<ICurve>> _0023_003DzWrYD5tnsrnGickDaSw_003D_003D)
	{
		ICurve[] array = new ICurve[contourList.Count - 1];
		for (int i = 1; i < contourList.Count; i++)
		{
			array[i - 1] = (ICurve)contourList[i].Clone();
		}
		_0023_003Dz0sa9p8vGG_0024_0024N(_0023_003DzMm1YBsyPIWTQ, (ICurve)contourList[0].Clone(), _0023_003DzUTSHHoU9mzsp[0], out _0023_003DzItZ6aEugTCY435PyVw_003D_003D, out _0023_003DzDAlzmkKXg2Fq, out var _0023_003DzYxZZbrD9Me8i);
		_0023_003DzmRO0U_3b8uUk = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(_0023_003DzYxZZbrD9Me8i);
		_0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D = new IList<IList<Point3D>>[array.Length];
		_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D[array.Length];
		_0023_003DzWrYD5tnsrnGickDaSw_003D_003D = new IList<ICurve>[array.Length];
		for (int j = 0; j < _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D.Count; j++)
		{
			_0023_003Dz0sa9p8vGG_0024_0024N(_0023_003DzMm1YBsyPIWTQ, array[j], _0023_003DzUTSHHoU9mzsp[j + 1], out var _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D, out var _0023_003DzHXSVUTwh6gQ_0024, out _0023_003DzYxZZbrD9Me8i);
			_0023_003DzWrYD5tnsrnGickDaSw_003D_003D[j] = _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D;
			_0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D[j] = _0023_003DzHXSVUTwh6gQ_0024;
			_0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D[j] = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(_0023_003DzYxZZbrD9Me8i);
		}
	}

	internal static void _0023_003Dz0sa9p8vGG_0024_0024N(Transformation _0023_003DzMm1YBsyPIWTQ, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dzm0CYiiE_003D, out IList<ICurve> _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D, out IList<IList<Point3D>> _0023_003DzHXSVUTwh6gQ_0024, out IList<IList<Point2D>> _0023_003DzYxZZbrD9Me8i)
	{
		_0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D = _0023_003DzgF2A6VG1DNgsTozDJI8ZfgY_003D(_0023_003Dz8fpRyMu9aKjE);
		foreach (Entity item in _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D)
		{
			item.Regen(_0023_003Dzm0CYiiE_003D);
		}
		_0023_003DzHXSVUTwh6gQ_0024 = _0023_003DzV1HIIM6pGf4GyOuXoavdfzE_003D(_0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D);
		_0023_003DzYxZZbrD9Me8i = _0023_003DzmaGV7q_0024UuK6XePbjLZas78c_003D(_0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D, _0023_003DzMm1YBsyPIWTQ);
	}

	private static IList<IList<Point3D>> _0023_003DzV1HIIM6pGf4GyOuXoavdfzE_003D(IList<ICurve> _0023_003DzTj1oJWREOpXS)
	{
		IList<IList<Point3D>> list = new IList<Point3D>[_0023_003DzTj1oJWREOpXS.Count];
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = ((Entity)_0023_003DzTj1oJWREOpXS[i]).Vertices;
		}
		return list;
	}

	private static IList<IList<Point2D>> _0023_003DzmaGV7q_0024UuK6XePbjLZas78c_003D(IList<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D, Transformation _0023_003DzMm1YBsyPIWTQ)
	{
		IList<Point2D>[] array = new IList<Point2D>[_0023_003DzItZ6aEugTCY435PyVw_003D_003D.Count];
		for (int i = 0; i < _0023_003DzItZ6aEugTCY435PyVw_003D_003D.Count; i++)
		{
			array[i] = _0023_003DzAjvTF_0024wZzMN0keVuvw_003D_003D(((Entity)_0023_003DzItZ6aEugTCY435PyVw_003D_003D[i]).Vertices, _0023_003DzMm1YBsyPIWTQ);
		}
		return array;
	}

	private static List<T> _0023_003DzDCDx01zD1wSe<T>(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzYkgRucGPvHIg, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzXUjJnNL3eU8F, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D, Plane _0023_003Dzk536MKmgTmXR, IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, double _0023_003DzccAR5G0_003D) where T : Region, new()
	{
		Telemetry.Instance.AddUsage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976447), Telemetry.moduleType.Booleans);
		List<T> list = new List<T>();
		List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> list2 = null;
		double _0023_003DzZodlKT3VkP5N = _0023_003DzOSo8vaE_003D._0023_003DzPjCDi56G8VEg();
		switch (_0023_003DzwY9ClXw_003D)
		{
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)1:
			list2 = _0023_003DzKK3pUYhqE_002427(_0023_003DzYkgRucGPvHIg, _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D, _0023_003DzXUjJnNL3eU8F, _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D);
			break;
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0:
			list2 = _0023_003DzpTY3Aqknu1EJ(_0023_003DzYkgRucGPvHIg, _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D, _0023_003DzXUjJnNL3eU8F, _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D);
			break;
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2:
			list2 = _0023_003DzEd0_0024gXHsiY8i(_0023_003DzYkgRucGPvHIg, _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D, _0023_003DzXUjJnNL3eU8F, _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D);
			break;
		}
		for (int i = 0; i < list2.Count; i++)
		{
			IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list3 = list2[i];
			List<ICurve> list4 = new List<ICurve>(list3.Count);
			for (int j = 0; j < list3.Count; j++)
			{
				ICurve curve = _0023_003DzeZ7O7Q63sCoZHyFeRkPgfNPpZ1Jd(_0023_003Dzk536MKmgTmXR, list3[j], _0023_003DzccAR5G0_003D);
				if (curve != null)
				{
					list4.Add(curve);
				}
			}
			if (list4.Count > 0)
			{
				T val = new T();
				val.ContourList = list4;
				val.Plane = (Plane)_0023_003Dzk536MKmgTmXR.Clone();
				val.SortAndOrient();
				list.Add(val);
			}
		}
		return list;
	}

	internal static bool _0023_003DzlgkUJVvf16gK(_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzZTe_0024jFG9ebLg, IList<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003DzN57VxTE7ZsCw)
	{
		int count = _0023_003DzN57VxTE7ZsCw.Count;
		int num = 0;
		int num2 = 0;
		int index = count - 1;
		while (num2 < count)
		{
			if (((_0023_003DzN57VxTE7ZsCw[num2]._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DzN57VxTE7ZsCw[index]._0023_003DzvXOLtKg_003D) || (_0023_003DzN57VxTE7ZsCw[index]._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DzN57VxTE7ZsCw[num2]._0023_003DzvXOLtKg_003D)) && _0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D < (_0023_003DzN57VxTE7ZsCw[index]._0023_003Dzyk2fsPo_003D - _0023_003DzN57VxTE7ZsCw[num2]._0023_003Dzyk2fsPo_003D) * (_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - _0023_003DzN57VxTE7ZsCw[num2]._0023_003DzvXOLtKg_003D) / (_0023_003DzN57VxTE7ZsCw[index]._0023_003DzvXOLtKg_003D - _0023_003DzN57VxTE7ZsCw[num2]._0023_003DzvXOLtKg_003D) + _0023_003DzN57VxTE7ZsCw[num2]._0023_003Dzyk2fsPo_003D)
			{
				num++;
			}
			index = num2++;
		}
		return (num & 1) == 1;
	}

	internal static ICurve _0023_003DzeZ7O7Q63sCoZHyFeRkPgfNPpZ1Jd(Plane _0023_003Dzrgqz890sj_0024X9, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, double _0023_003DzxH4ozIo_003D)
	{
		List<ICurve> list = new List<ICurve>();
		LinkedListNode<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzfmsdmcfcBmDX> first = _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().First;
		if (first == null)
		{
			return null;
		}
		ICurve curve = first.Value._0023_003DzEemH6ZA_003D ?? first.Value._0023_003Dz4701yxQ2_0024axv;
		LinkedListNode<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzfmsdmcfcBmDX> linkedListNode2;
		LinkedListNode<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzfmsdmcfcBmDX> linkedListNode = (linkedListNode2 = first);
		first = first.Next;
		ICurve sub = null;
		bool flag = false;
		while (first != null)
		{
			ICurve curve2 = first.Value._0023_003DzEemH6ZA_003D ?? first.Value._0023_003Dz4701yxQ2_0024axv;
			linkedListNode2 = first;
			if (curve2 != curve || flag)
			{
				Point3D _0023_003Dz114WmwtBjoiC = linkedListNode.Value._0023_003Dz114WmwtBjoiC;
				Point3D _0023_003Dz114WmwtBjoiC2 = linkedListNode2.Value._0023_003Dz114WmwtBjoiC;
				bool flag2 = false;
				if (curve.IsClosed)
				{
					curve.Project(_0023_003Dz114WmwtBjoiC, out var t);
					curve.Project(_0023_003Dz114WmwtBjoiC2, out var t2);
					if (t > t2 && linkedListNode.Value._0023_003DzB62SYmA_003D)
					{
						if (!Utility.AreEqual(t, curve.Domain.Max, curve.Domain.Length))
						{
							curve.SubCurve(_0023_003Dz114WmwtBjoiC, curve.EndPoint, out sub);
							sub.EdgeIndex = curve.EdgeIndex;
							sub.FromBooleanIntersection = curve.FromBooleanIntersection;
							list.Add(sub);
						}
						if (!Utility.AreEqual(curve.Domain.Min, t2, curve.Domain.Length))
						{
							curve.SubCurve(curve.StartPoint, _0023_003Dz114WmwtBjoiC2, out sub);
							sub.EdgeIndex = curve.EdgeIndex;
							sub.FromBooleanIntersection = curve.FromBooleanIntersection;
							list.Add(sub);
						}
						flag2 = true;
					}
					else if (t < t2 && !linkedListNode.Value._0023_003DzB62SYmA_003D)
					{
						if (!Utility.AreEqual(t, curve.Domain.Max, curve.Domain.Length))
						{
							curve.SubCurve(curve.StartPoint, _0023_003Dz114WmwtBjoiC, out sub);
							sub.Reverse();
							sub.EdgeIndex = curve.EdgeIndex;
							sub.FromBooleanIntersection = curve.FromBooleanIntersection;
							list.Add(sub);
						}
						if (!Utility.AreEqual(curve.Domain.Min, t2, curve.Domain.Length))
						{
							curve.SubCurve(_0023_003Dz114WmwtBjoiC2, curve.EndPoint, out sub);
							sub.Reverse();
							sub.EdgeIndex = curve.EdgeIndex;
							sub.FromBooleanIntersection = curve.FromBooleanIntersection;
							list.Add(sub);
						}
						flag2 = true;
					}
				}
				if (!flag2 && !Point3D.AreEqual(_0023_003Dz114WmwtBjoiC, _0023_003Dz114WmwtBjoiC2, _0023_003DzxH4ozIo_003D))
				{
					curve.ClosestPointTo(_0023_003Dz114WmwtBjoiC, out var t3);
					curve.ClosestPointTo(_0023_003Dz114WmwtBjoiC2, out var t4);
					if (t3 > t4)
					{
						curve.SubCurve(t4, t3, out sub);
					}
					else
					{
						curve.SubCurve(t3, t4, out sub);
					}
					if (sub != null)
					{
						if (!linkedListNode.Value._0023_003DzB62SYmA_003D)
						{
							sub.Reverse();
						}
						sub.EdgeIndex = curve.EdgeIndex;
						sub.FromBooleanIntersection = curve.FromBooleanIntersection;
						list.Add(sub);
					}
				}
				linkedListNode = linkedListNode2;
				curve = curve2;
			}
			if (flag)
			{
				break;
			}
			first = first.Next;
			if (first == null)
			{
				first = _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().First;
				if (Point3D.AreEqual(linkedListNode.Value._0023_003Dz114WmwtBjoiC, first.Value._0023_003Dz114WmwtBjoiC, _0023_003DzxH4ozIo_003D))
				{
					break;
				}
				flag = true;
			}
		}
		if (list.Count == 0)
		{
			list.Add(curve);
		}
		ICurve curve3 = null;
		if (list.Count > 1)
		{
			curve3 = new CompositeCurve(list);
		}
		else if (list.Count == 1)
		{
			curve3 = list[0];
		}
		if (curve3 != null)
		{
			Entity entity = (Entity)curve3;
			double deviation = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzcWsuvoQfLK3L(entity);
			entity.Regen(deviation);
			if (entity.Vertices.Length > 3)
			{
				IList<IList<Point2D>> _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = null;
				Mesh._0023_003DzzgKMdKw_003D(entity._vertices, null, _0023_003Dzrgqz890sj_0024X9, out var _0023_003DzJB9yXb3atfkL, out _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
				if (!Utility.AreEqual(Utility.PolygonArea(_0023_003DzJB9yXb3atfkL), 0.0, entity.BoxSize.Diagonal))
				{
					return curve3;
				}
			}
		}
		return null;
	}

	private static List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> _0023_003DzpTY3Aqknu1EJ(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz0TQuX2w_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzCM7y44E_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzZodlKT3VkP5N, double _0023_003DzccAR5G0_003D)
	{
		List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> list = new List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>>();
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D;
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzrIsIvtI_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D));
		if (_0023_003DzOLHnb2M_003D == (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)0)
		{
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list3 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			list3.Add(_0023_003Dz0TQuX2w_003D);
			list3.AddRange(_0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D);
			list.Add(list3);
			list3 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			list3.Add(_0023_003DzCM7y44E_003D);
			list3.AddRange(_0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D);
			list.Add(list3);
			return list;
		}
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list4 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(list2.Count - 1);
		list4.AddRange(list2.GetRange(1, list2.Count - 1));
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list5 = _0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(_0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, _0023_003DzCM7y44E_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
		if (_0023_003DzOLHnb2M_003D == (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)2)
		{
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list6 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			list6.AddRange(_0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D);
			list6.Add(_0023_003DzCM7y44E_003D);
			list.Add(list6);
		}
		list5.AddRange(_0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(_0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D, _0023_003Dz0TQuX2w_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D));
		if (_0023_003DzOLHnb2M_003D == (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)2)
		{
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list7 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			list7.AddRange(_0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D);
			list7.Add(_0023_003Dz0TQuX2w_003D);
			list.Add(list7);
		}
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item = list2[0];
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list8 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list9 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		for (int i = 0; i < _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D.Count; i++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D[i];
			for (int j = 0; j < _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D.Count; j++)
			{
				_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D[j];
				if (_0023_003Dz_0024WkMNd__uiAK._0023_003Dz9h5MY_A_003D(_0023_003Dz_0024WkMNd__uiAK2))
				{
					list9.AddRange(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzQ7usAag_003D(_0023_003Dz_0024WkMNd__uiAK, _0023_003Dz_0024WkMNd__uiAK2, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D));
				}
			}
		}
		list8.AddRange(list5);
		list8.AddRange(list9);
		list8.AddRange(list4);
		list8.Add(item);
		list.Add(list8);
		return list;
	}

	private static List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzWaFlkhfmYCja, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_SqBXz8_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D, out _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		_0023_003DzOLHnb2M_003D = (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)0;
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
		{
			list.AddRange(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzoTH8BDg_003D(_0023_003DzWaFlkhfmYCja[i], _0023_003Dz_SqBXz8_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out var _0023_003DzOLHnb2M_003D2));
			if (_0023_003DzOLHnb2M_003D != (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)2)
			{
				_0023_003DzOLHnb2M_003D = _0023_003DzOLHnb2M_003D2;
			}
		}
		return list;
	}

	private static List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> _0023_003DzEd0_0024gXHsiY8i(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz0TQuX2w_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzCM7y44E_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzZodlKT3VkP5N, double _0023_003DzccAR5G0_003D)
	{
		List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> list = new List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>>();
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		list2.AddRange(_0023_003DzqbtBmDykfiyYWgGP1A_003D_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D));
		foreach (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item2 in list2)
		{
			item2._0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D = true;
		}
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list3 = _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D;
		list2.AddRange(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzoTH8BDg_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out var _0023_003DzOLHnb2M_003D));
		list3 = ((_0023_003DzOLHnb2M_003D != (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D)2) ? _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D : _0023_003DzoNwOCtUNC10XVFawHcwxKJ4_003D(_0023_003DzCM7y44E_003D, _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, list2, _0023_003DzOSo8vaE_003D, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D));
		int num = 0;
		foreach (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item3 in _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D)
		{
			num += item3._0023_003DzvRAdRPd11xUJ().Count;
		}
		int num2 = _0023_003Dz0TQuX2w_003D._0023_003DzvRAdRPd11xUJ().Count + _0023_003DzCM7y44E_003D._0023_003DzvRAdRPd11xUJ().Count + num;
		for (int i = 0; i < list2.Count; i++)
		{
			if (list2.Count > num2)
			{
				return new List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>>();
			}
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list4 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			bool _0023_003Dzxh9_ujyaVFe;
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> collection = ((!list2[i]._0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D) ? _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, list3, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D, _0023_003DzOSo8vaE_003D, out _0023_003Dzxh9_ujyaVFe) : _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D, _0023_003DzOSo8vaE_003D, out _0023_003Dzxh9_ujyaVFe));
			if (_0023_003Dzxh9_ujyaVFe)
			{
				i--;
				continue;
			}
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item = list2[i];
			list4.AddRange(collection);
			list4.Add(item);
			list.Add(list4);
		}
		return list;
	}

	private static List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzoNwOCtUNC10XVFawHcwxKJ4_003D(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzCM7y44E_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003Dzq9GqFE4_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzZodlKT3VkP5N, double _0023_003DzccAR5G0_003D)
	{
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		list.Add(_0023_003DzCM7y44E_003D);
		IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		for (int i = 0; i < _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D.Count; i++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D[i];
			bool flag = false;
			int num = list.Count;
			for (int j = 0; j < num; j++)
			{
				_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = list[j];
				if (_0023_003Dz_0024WkMNd__uiAK._0023_003Dz9h5MY_A_003D(_0023_003Dz_0024WkMNd__uiAK2))
				{
					flag = true;
					_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D;
					IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> collection = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzrIsIvtI_003D(_0023_003Dz_0024WkMNd__uiAK, _0023_003Dz_0024WkMNd__uiAK2, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
					list.RemoveAt(j);
					j--;
					num--;
					list.AddRange(collection);
				}
			}
			if (!flag)
			{
				list2.Add(_0023_003Dz_0024WkMNd__uiAK);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK3 = list[k];
			for (int l = 0; l < list.Count; l++)
			{
				if (k == l)
				{
					continue;
				}
				_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK4 = list[l];
				if (_0023_003Dz_0024WkMNd__uiAK3._0023_003Dzxbr8_0024Jk_003D(_0023_003Dz_0024WkMNd__uiAK4, _0023_003DzZodlKT3VkP5N))
				{
					_0023_003Dz_0024WkMNd__uiAK4._0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D = true;
					_0023_003Dzq9GqFE4_003D.Add(_0023_003Dz_0024WkMNd__uiAK4);
					list.RemoveAt(l);
					l--;
					if (k > l)
					{
						k--;
					}
				}
			}
		}
		list.AddRange(list2);
		return list;
	}

	private static List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzqbtBmDykfiyYWgGP1A_003D_003D(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_SqBXz8_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzX_Xr0FMcZgdl, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D)
	{
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		foreach (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item in _0023_003DzX_Xr0FMcZgdl)
		{
			list.AddRange(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzQ7usAag_003D(_0023_003Dz_SqBXz8_003D, item, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D));
		}
		return list;
	}

	private static List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> _0023_003DzKK3pUYhqE_002427(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz0TQuX2w_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzCM7y44E_003D, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzZodlKT3VkP5N, double _0023_003DzccAR5G0_003D)
	{
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzQ7usAag_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D));
		List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>> list2 = new List<IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>>();
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list3 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003DzD_0024pIqYoYniwmmPZfpw_003D_003D);
		list3.AddRange(_0023_003DzHBqfjdiJSyaiZFxjxA_003D_003D);
		for (int i = 0; i < list3.Count; i++)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = list3[i];
			for (int num = list3.Count - 1; num >= 0; num--)
			{
				if (i != num)
				{
					_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = list3[num];
					if (_0023_003Dz_0024WkMNd__uiAK._0023_003Dz9h5MY_A_003D(_0023_003Dz_0024WkMNd__uiAK2))
					{
						_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D;
						IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list4 = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzrIsIvtI_003D(_0023_003Dz_0024WkMNd__uiAK, _0023_003Dz_0024WkMNd__uiAK2, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
						for (int j = 0; j < list4.Count; j++)
						{
							for (int k = 0; k < list4.Count; k++)
							{
								if (j != k && list4[k]._0023_003Dzxbr8_0024Jk_003D(list4[j], _0023_003DzZodlKT3VkP5N))
								{
									list2.Add(new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK[1] { list4[j] });
									list4.RemoveAt(j);
									j--;
									break;
								}
							}
						}
						_0023_003Dz_0024WkMNd__uiAK = (list3[i] = list4[0]);
						if (list4.Count > 1)
						{
							list3[num] = list4[1];
							for (int l = 2; l < list4.Count; l++)
							{
								list3.Add(list4[l]);
							}
						}
						else
						{
							if (i > num)
							{
								i--;
							}
							list3.RemoveAt(num);
						}
					}
				}
			}
		}
		for (int m = 0; m < list.Count; m++)
		{
			bool _0023_003Dzxh9_ujyaVFe;
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> collection = _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list, m, list3, _0023_003DzZodlKT3VkP5N, _0023_003DzccAR5G0_003D, _0023_003DzOSo8vaE_003D, out _0023_003Dzxh9_ujyaVFe);
			if (_0023_003Dzxh9_ujyaVFe)
			{
				m--;
				continue;
			}
			List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list5 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
			list5.AddRange(collection);
			list5.Add(list[m]);
			list2.Add(list5);
		}
		return list2;
	}

	private static void _0023_003Dz0wcqTpk_003D<T>(IList<IList<IList<T>>> _0023_003DzWaFlkhfmYCja) where T : Point2D
	{
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
		{
			_0023_003DzWaFlkhfmYCja[i] = _0023_003Dz0wcqTpk_003D(_0023_003DzWaFlkhfmYCja[i]);
		}
	}

	private static void _0023_003Dz0wcqTpk_003D(IList<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D)
	{
		for (int i = 0; i < _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D.Count; i++)
		{
			IList<IList<Point2D>> _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D2 = _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D[i]._0023_003DzIeMEgGvdP3uT();
			_0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D[i]._0023_003DzNo9vCzZlIlCb(_0023_003Dz0wcqTpk_003D(_0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D2));
		}
	}

	private static IList<IList<T>> _0023_003Dz0wcqTpk_003D<T>(IList<IList<T>> _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D) where T : Point2D
	{
		List<IList<T>> list = new List<IList<T>>(_0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D);
		list.Reverse();
		for (int i = 0; i < list.Count; i++)
		{
			List<T> list2 = new List<T>(list[i]);
			list2.Reverse();
			list[i] = list2;
		}
		return list.ToArray();
	}

	private static void _0023_003Dz0wcqTpk_003D(IList<IList<ICurve>> _0023_003DzWaFlkhfmYCja)
	{
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
		{
			List<ICurve> list = new List<ICurve>(_0023_003DzWaFlkhfmYCja[i]);
			list.Reverse();
			for (int j = 0; j < list.Count; j++)
			{
				list[j].Reverse();
			}
			_0023_003DzWaFlkhfmYCja[i] = list.ToArray();
		}
	}

	private static List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003Dzq9GqFE4_003D, int _0023_003DzLFA2gNM_003D, IList<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzX_Xr0FMcZgdl, double _0023_003DzZodlKT3VkP5N, double _0023_003DzccAR5G0_003D, IntegerGrid _0023_003DzOSo8vaE_003D, out bool _0023_003Dzxh9_ujyaVFe4)
	{
		_0023_003Dzxh9_ujyaVFe4 = false;
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>();
		for (int num = _0023_003DzX_Xr0FMcZgdl.Count - 1; num >= 0; num--)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = _0023_003DzX_Xr0FMcZgdl[num];
			if (_0023_003Dzq9GqFE4_003D[_0023_003DzLFA2gNM_003D]._0023_003Dz9h5MY_A_003D(_0023_003Dz_0024WkMNd__uiAK))
			{
				_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D;
				List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzoTH8BDg_003D(_0023_003Dzq9GqFE4_003D[_0023_003DzLFA2gNM_003D], _0023_003Dz_0024WkMNd__uiAK, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D));
				foreach (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK item in list2)
				{
					item._0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D = _0023_003Dzq9GqFE4_003D[_0023_003DzLFA2gNM_003D]._0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D;
				}
				if (list2.Count <= 0)
				{
					_0023_003Dzq9GqFE4_003D.RemoveAt(_0023_003DzLFA2gNM_003D);
					_0023_003Dzxh9_ujyaVFe4 = true;
					return list;
				}
				_0023_003Dzq9GqFE4_003D[_0023_003DzLFA2gNM_003D] = list2[0];
				_0023_003Dzq9GqFE4_003D.AddRange(list2.GetRange(1, list2.Count - 1));
			}
		}
		for (int num2 = _0023_003DzX_Xr0FMcZgdl.Count - 1; num2 >= 0; num2--)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = _0023_003DzX_Xr0FMcZgdl[num2];
			if (_0023_003Dzq9GqFE4_003D[_0023_003DzLFA2gNM_003D]._0023_003Dzxbr8_0024Jk_003D(_0023_003Dz_0024WkMNd__uiAK2, _0023_003DzZodlKT3VkP5N))
			{
				list.Add(_0023_003Dz_0024WkMNd__uiAK2);
			}
		}
		return list;
	}

	public ICurve[] QuickOffset(double amount, cornerType ct, double tol)
	{
		return QuickOffset(amount, ct, 2.0, tol);
	}

	public ICurve[] QuickOffset(double amount, cornerType ct, double miterLimit, double tol)
	{
		ICurve[] array = new ICurve[contourList.Count];
		for (int i = 0; i < contourList.Count; i++)
		{
			Entity entity = (Entity)contourList[i];
			entity.Regen(tol);
			int num = entity._vertices.Length;
			Point3D[] array2 = new Point3D[num];
			for (int j = 0; j < num; j++)
			{
				Point2D point2D = base.Plane.Project(entity._vertices[j]);
				array2[j] = new Point3D(point2D.X, point2D.Y);
			}
			array[i] = new LinearPath(array2);
		}
		IntegerGrid _0023_003DzOSo8vaE_003D;
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = new Region(array, base.Plane, sortAndOrient: false)._0023_003DzeMYhs5Z_0024EcJ2(amount, ct, miterLimit, tol, out _0023_003DzOSo8vaE_003D);
		int count = list.Count;
		ICurve[] array3 = new ICurve[count];
		for (int k = 0; k < count; k++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list2 = list[k];
			int count2 = list2.Count;
			Point3D[] array4 = new Point3D[count2 + 1];
			for (int l = 0; l < count2; l++)
			{
				_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list2[l];
				_0023_003DzOSo8vaE_003D.ScaleToWorld((int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, (int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
				array4[l] = base.Plane.PointAt(x, y);
			}
			array4[count2] = (Point3D)array4[0].Clone();
			LinearPath linearPath = new LinearPath(array4);
			array3[k] = linearPath;
		}
		return array3;
	}

	internal List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzeMYhs5Z_0024EcJ2(double _0023_003DzYNjcavt9guh2, cornerType _0023_003Dzjvn7P10_003D, double _0023_003DzxGO8fYElkqEK, double _0023_003Dzm0CYiiE_003D, out IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		double[] array = new double[contourList.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dzm0CYiiE_003D;
		}
		_0023_003DzG8omomNI5M4e(new Identity(), array, out var _0023_003DzDAlzmkKXg2Fq, out var _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D, out var _0023_003DzmRO0U_3b8uUk, out var _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D, out var _0023_003DzItZ6aEugTCY435PyVw_003D_003D, out var _0023_003DzWrYD5tnsrnGickDaSw_003D_003D);
		_0023_003DzOSo8vaE_003D = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK._0023_003Dz_LrsyseLeNti(1, new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> { _0023_003DzmRO0U_3b8uUk }, out var _, out var _);
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>(contourList.Count);
		_0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(_0023_003DzOSo8vaE_003D, _0023_003DzDAlzmkKXg2Fq, _0023_003DzmRO0U_3b8uUk, _0023_003DzItZ6aEugTCY435PyVw_003D_003D, list);
		for (int j = 0; j < _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D.Count; j++)
		{
			IList<IList<Point3D>> _0023_003DzuKtlvJHGTK2s = _0023_003DztJa7MOF2kcB9VIwTYQ_003D_003D[j];
			_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz4Jv5_0024b5pgl6_0024 = _0023_003Dz0ClsFOELjbeYw_0024ehLA_003D_003D[j];
			_0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(_0023_003DzOSo8vaE_003D, _0023_003DzuKtlvJHGTK2s, _0023_003Dz4Jv5_0024b5pgl6_0024, _0023_003DzWrYD5tnsrnGickDaSw_003D_003D[j], list);
		}
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dz1erSizk_003D = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
		double _0023_003DzO1AkaTYvv61l = _0023_003DzOSo8vaE_003D._0023_003DzO1AkaTYvv61l;
		_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2 = null;
		switch (_0023_003Dzjvn7P10_003D)
		{
		default:
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2 = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(_0023_003DzxGO8fYElkqEK, 0.0);
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2._0023_003DzqUzJcXY_003D(list, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)2, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)0);
			break;
		case cornerType.Round:
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2 = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(_0023_003DzxGO8fYElkqEK, _0023_003Dzm0CYiiE_003D * _0023_003DzO1AkaTYvv61l);
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2._0023_003DzqUzJcXY_003D(list, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)1, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)0);
			break;
		case cornerType.Flat:
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2 = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(_0023_003DzxGO8fYElkqEK, 0.0);
			_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2._0023_003DzqUzJcXY_003D(list, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)0, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)0);
			break;
		}
		_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u2._0023_003Dz_IsqsVA_003D(ref _0023_003Dz1erSizk_003D, _0023_003DzYNjcavt9guh2 * _0023_003DzO1AkaTYvv61l);
		return _0023_003Dz1erSizk_003D;
	}

	internal ICurve[] _0023_003DzeMYhs5Z_0024EcJ2(double _0023_003DzYNjcavt9guh2, double _0023_003Dzm0CYiiE_003D, out IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = _0023_003DzeMYhs5Z_0024EcJ2(_0023_003DzYNjcavt9guh2, cornerType.Round, 2.0, _0023_003Dzm0CYiiE_003D, out _0023_003DzOSo8vaE_003D);
		int count = list.Count;
		ICurve[] array = new ICurve[count];
		for (int i = 0; i < count; i++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list2 = list[i];
			int count2 = list2.Count;
			Point3D[] array2 = new Point3D[count2 + 1];
			for (int j = 0; j < count2; j++)
			{
				_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list2[j];
				_0023_003DzOSo8vaE_003D.ScaleToWorld((int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, (int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
				array2[j] = new Point3D(x, y, base.Plane.Origin.Z);
			}
			array2[count2] = (Point3D)array2[0].Clone();
			LinearPath linearPath = new LinearPath(array2);
			array[i] = linearPath;
		}
		return array;
	}

	private void _0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(IntegerGrid _0023_003DzOSo8vaE_003D, IList<IList<Point3D>> _0023_003DzuKtlvJHGTK2s, _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz4Jv5_0024b5pgl6_0024, IList<ICurve> _0023_003DzbGVu3RzPQdW0, List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dznl3w87ObFuqU)
	{
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(base.Plane, _0023_003DzuKtlvJHGTK2s, _0023_003Dz4Jv5_0024b5pgl6_0024, _0023_003DzbGVu3RzPQdW0, _0023_003DzOSo8vaE_003D, _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D: true);
		List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list = new List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>(_0023_003Dz_0024WkMNd__uiAK._0023_003DzvRAdRPd11xUJ().Count);
		LinkedListNode<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003Dz_0024WkMNd__uiAK._0023_003DzvRAdRPd11xUJ().First;
		while (linkedListNode != null)
		{
			_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item = new _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D);
			list.Add(item);
			while (linkedListNode != null && linkedListNode.Value._0023_003Dzyk2fsPo_003D == item._0023_003Dzyk2fsPo_003D && linkedListNode.Value._0023_003DzvXOLtKg_003D == item._0023_003DzvXOLtKg_003D)
			{
				linkedListNode = linkedListNode.Next;
			}
		}
		_0023_003Dznl3w87ObFuqU.Add(list);
	}

	public ICurve[] Pocket(double amount)
	{
		return Pocket(amount, base.Plane.AxisZ, useSharpConnection: false);
	}

	[Obsolete("This method is deprecated.")]
	public ICurve[] Pocket(double amount, cornerType ct, double tol)
	{
		return Pocket(amount, ct, 2.0, tol);
	}

	[Obsolete("This method is deprecated.")]
	public ICurve[] Pocket(double amount, cornerType ct, double miterLimit, double tol)
	{
		List<ICurve> list = new List<ICurve>();
		if (amount <= 0.0)
		{
			return null;
		}
		int num = -1;
		while (true)
		{
			ICurve[] array = QuickOffset(amount * (double)num, ct, miterLimit, tol);
			num--;
			if (array == null || array.Length == 0)
			{
				break;
			}
			ICurve[] array2 = array;
			foreach (ICurve curve in array2)
			{
				((Entity)curve).EntityData = -(num + 1);
				list.Add(curve);
			}
		}
		return list.ToArray();
	}

	public static T[] Union<T>(T a, T b) where T : Region, new()
	{
		return _0023_003DzNC7p9G80lhFN<T>(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0).ToArray();
	}

	public static T[] Union<T>(T[] regions) where T : Region, new()
	{
		if (regions.Length <= 1)
		{
			return regions.ToArray();
		}
		List<T> list = new List<T>();
		bool[] array = new bool[regions.Length];
		int num = 0;
		bool flag = false;
		while (!flag)
		{
			T val = regions[num];
			array[num] = true;
			bool flag2;
			do
			{
				flag2 = false;
				for (int i = num + 1; i < regions.Length; i++)
				{
					if (!array[i])
					{
						T b = regions[i];
						T[] array2 = Union(val, b);
						if (array2.Length == 1)
						{
							val = array2[0];
							array[i] = true;
							flag2 = true;
						}
					}
				}
			}
			while (flag2);
			list.Add(val);
			flag = true;
			for (int j = num + 1; j < regions.Length; j++)
			{
				if (!array[j])
				{
					flag = false;
					num = j;
					break;
				}
			}
		}
		return list.ToArray();
	}

	public static T[] Difference<T>(T a, T b) where T : Region, new()
	{
		return _0023_003DzNC7p9G80lhFN<T>(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2).ToArray();
	}

	public static T Difference<T>(T a, params T[] b) where T : Region, new()
	{
		T val = a;
		for (int i = 0; i < b.Length; i++)
		{
			val = _0023_003DzNC7p9G80lhFN<T>(val, b[i], (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2).ToArray()[0];
		}
		return val;
	}

	public static T[] Intersection<T>(T a, T b) where T : Region, new()
	{
		return _0023_003DzNC7p9G80lhFN<T>(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)1).ToArray();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971351));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
		}
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975920) + GetPerimeter() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public double GetPerimeter()
	{
		double num = 0.0;
		foreach (ICurve contour in ContourList)
		{
			num += contour.Length();
		}
		return num;
	}

	public static bool Trim(Region original, IList<ICurve> curves, out Region[] result)
	{
		bool result2 = _0023_003DzS_0024pM1o19RjjX(original, curves, null, (_0023_003Dz4Hw_002424_0024xhqb8)2, out result);
		Region[] array = result;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].CopyAttributes(original);
		}
		return result2;
	}

	internal static bool _0023_003DzS_0024pM1o19RjjX(Region _0023_003Dz4wZe_0024Xg_003D, IList<ICurve> _0023_003DzTj1oJWREOpXS, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, _0023_003Dz4Hw_002424_0024xhqb8 _0023_003Dz6QZRidI_003D, out Region[] _0023_003DzOLHnb2M_003D)
	{
		if (_0023_003Dz6QZRidI_003D == (_0023_003Dz4Hw_002424_0024xhqb8)2)
		{
			_0023_003DzOLHnb2M_003D = _0023_003DzNXGCQkhQtRkNL5Wfh_0024VyMFYjbHwY_0024emHzlK8LSB2_0024jeLSLMuCLFLfYU_003D._0023_003Dz6PsRlFc_003D(_0023_003Dz4wZe_0024Xg_003D, _0023_003DzTj1oJWREOpXS.ToArray(), _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out var _, out var _, out var _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D);
			return _0023_003DzOLHnb2M_003D != null && _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D;
		}
		List<Region> list = new List<Region>();
		bool result = _0023_003DzqjMsto_lHr3U(_0023_003Dz4wZe_0024Xg_003D, _0023_003DzTj1oJWREOpXS, list);
		_0023_003DzOLHnb2M_003D = list.ToArray();
		return result;
	}

	private bool _0023_003Dz6PsRlFc_003D<T>(IList<ICurve> _0023_003DzTj1oJWREOpXS, out bool[] _0023_003DzH9i1lhU_003D, out T[] _0023_003DzACJ8of7_00247mab, out _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzOmuoKv8_003D _0023_003DzOmuoKv8_003D) where T : Region, new()
	{
		ICurve[] array = new ICurve[_0023_003DzTj1oJWREOpXS.Count];
		for (int i = 0; i < _0023_003DzTj1oJWREOpXS.Count; i++)
		{
			array[i] = (ICurve)_0023_003DzTj1oJWREOpXS[i].Clone();
		}
		ICurve[] array2 = new ICurve[contourList.Count];
		for (int j = 0; j < contourList.Count; j++)
		{
			array2[j] = (ICurve)contourList[j].Clone();
		}
		bool _0023_003DzMF8k7sk_003D;
		IList<ICurve> list = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzxIk9oLRZ3P_UYVarSg_003D_003D(array2, base.Plane, array, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0, out _0023_003DzMF8k7sk_003D, out _0023_003DzOmuoKv8_003D);
		bool flag = true;
		_0023_003DzH9i1lhU_003D = new bool[_0023_003DzTj1oJWREOpXS.Count];
		for (int k = 0; k < array.Length; k++)
		{
			Entity entity = (Entity)array[k];
			if (entity.EntityData != null && entity.EntityData.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976430))
			{
				_0023_003DzH9i1lhU_003D[k] = true;
				flag = false;
			}
		}
		_0023_003DzACJ8of7_00247mab = null;
		if (flag || list.Count == 0)
		{
			return false;
		}
		contourList.Clear();
		_0023_003DzACJ8of7_00247mab = _0023_003DzTi4x6Bn5EgGb<T>(list);
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	private T[] _0023_003DzTi4x6Bn5EgGb<T>(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D) where T : Region, new()
	{
		double _0023_003DzccAR5G0_003D;
		double _0023_003Dzm0CYiiE_003D = _0023_003DzMnn_sI1bfuYs(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out _0023_003DzccAR5G0_003D);
		List<ICurve> list = new List<ICurve>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count);
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			list.Add((ICurve)((Entity)_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i]).Clone());
		}
		_0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(base.Plane, list, _0023_003Dzm0CYiiE_003D);
		List<T> list2 = new List<T>();
		List<_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D> list3 = new List<_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D>();
		for (int j = 0; j < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; j++)
		{
			list3.Add(new _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[j], list[j]));
		}
		_0023_003DzBnyQC_0024NLx9TdnmN_002481BEOPg_003D comparer = new _0023_003DzBnyQC_0024NLx9TdnmN_002481BEOPg_003D();
		list3.Sort(comparer);
		while (list3.Count > 0)
		{
			_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2 = list3[0];
			List<ICurve> list4 = new List<ICurve>();
			list4.Add(_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2._0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D);
			list3.RemoveAt(0);
			Entity entity = (Entity)_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2._0023_003DzKNDGjaLz92D9grl4xg_003D_003D;
			for (int k = 0; k < list3.Count; k++)
			{
				Entity entity2 = (Entity)list3[k]._0023_003DzKNDGjaLz92D9grl4xg_003D_003D;
				bool flag = true;
				for (int l = 0; l < entity2.Vertices.Length; l++)
				{
					if (!Utility.PointInPolygon(entity2.Vertices[l], entity.Vertices))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list4.Add(list3[k]._0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D);
					list3.RemoveAt(k);
					k--;
				}
			}
			T val = new T();
			val._0023_003DztGdcVOA_003D(list4, base.Plane, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: true, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false);
			list2.Add(val);
		}
		if (list2.Count > 0)
		{
			contourList = list2[0].contourList;
			list2.RemoveAt(0);
		}
		return list2.ToArray();
	}

	private static Region[] _0023_003Dz2MEbiWMq4AMh(Region _0023_003Dz7revxoQ_003D, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		double _0023_003DzccAR5G0_003D;
		double _0023_003Dzm0CYiiE_003D = _0023_003DzMnn_sI1bfuYs(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out _0023_003DzccAR5G0_003D);
		List<ICurve> list = new List<ICurve>(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count);
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			list.Add((ICurve)((Entity)_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i]).Clone());
		}
		_0023_003DzeiGtncATiLgqI0LMh_kN3Qc_003D(_0023_003Dz7revxoQ_003D.Plane, list, _0023_003Dzm0CYiiE_003D);
		List<Region> list2 = new List<Region>();
		List<_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D> list3 = new List<_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D>();
		for (int j = 0; j < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; j++)
		{
			list3.Add(new _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[j], list[j]));
		}
		_0023_003DzBnyQC_0024NLx9TdnmN_002481BEOPg_003D comparer = new _0023_003DzBnyQC_0024NLx9TdnmN_002481BEOPg_003D();
		list3.Sort(comparer);
		while (list3.Count > 0)
		{
			_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D _0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2 = list3[0];
			List<ICurve> list4 = new List<ICurve>();
			list4.Add(_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2._0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D);
			list3.RemoveAt(0);
			Entity entity = (Entity)_0023_003DzNAE5ua4CzgPrmTw6xFAWuAk_003D2._0023_003DzKNDGjaLz92D9grl4xg_003D_003D;
			for (int k = 0; k < list3.Count; k++)
			{
				Entity entity2 = (Entity)list3[k]._0023_003DzKNDGjaLz92D9grl4xg_003D_003D;
				bool flag = true;
				for (int l = 0; l < entity2.Vertices.Length; l++)
				{
					if (!Utility.PointInPolygon(entity2.Vertices[l], entity.Vertices))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list4.Add(list3[k]._0023_003DzWHp0zgiVbRADQ4c_tQ_003D_003D);
					list3.RemoveAt(k);
					k--;
				}
			}
			list2.Add(new Region(list4));
		}
		if (list2.Count > 0)
		{
			_0023_003Dz7revxoQ_003D.contourList = list2[0].contourList;
			list2.RemoveAt(0);
		}
		return list2.ToArray();
	}

	private static bool _0023_003DzqjMsto_lHr3U<T>(T _0023_003DzFDwqpgU_003D, IList<ICurve> _0023_003DzTj1oJWREOpXS, List<T> _0023_003DzOLHnb2M_003D) where T : Region, new()
	{
		T val = (T)_0023_003DzFDwqpgU_003D.Clone();
		T _0023_003DzFDwqpgU_003D2 = (T)_0023_003DzFDwqpgU_003D.Clone();
		if (val._0023_003Dz6PsRlFc_003D<T>(_0023_003DzTj1oJWREOpXS, out var _0023_003DzH9i1lhU_003D, out var _0023_003DzACJ8of7_00247mab, out var _0023_003DzOmuoKv8_003D))
		{
			for (int i = 0; i < _0023_003DzH9i1lhU_003D.Length; i++)
			{
				if (!_0023_003DzH9i1lhU_003D[i])
				{
					continue;
				}
				List<ICurve> list = new List<ICurve>(_0023_003DzTj1oJWREOpXS.Count);
				List<ICurve> list2 = new List<ICurve>(_0023_003DzTj1oJWREOpXS.Count);
				for (int j = 0; j < _0023_003DzTj1oJWREOpXS.Count; j++)
				{
					if (!_0023_003DzH9i1lhU_003D[j])
					{
						list.Add(_0023_003DzTj1oJWREOpXS[j]);
						continue;
					}
					ICurve curve = (ICurve)_0023_003DzTj1oJWREOpXS[j].Clone();
					curve.Reverse();
					list2.Add(curve);
				}
				bool flag = true;
				if (list.Count > 0)
				{
					if (_0023_003DzqjMsto_lHr3U(val, list.ToArray(), _0023_003DzOLHnb2M_003D))
					{
						flag = false;
					}
					T[] array = _0023_003DzACJ8of7_00247mab;
					for (int k = 0; k < array.Length; k++)
					{
						_0023_003DzqjMsto_lHr3U(array[k], list.ToArray(), _0023_003DzOLHnb2M_003D);
					}
					List<T> list3 = new List<T>(1);
					_0023_003DzqjMsto_lHr3U(_0023_003DzFDwqpgU_003D2, list2, list3);
					List<T> list4 = new List<T>();
					for (int l = 0; l < list3.Count; l++)
					{
						list4.AddRange(_0023_003DzorRMj6zXvNF8(list3[l], _0023_003DzACJ8of7_00247mab));
					}
					list3 = list4;
					foreach (T item in list3)
					{
						_0023_003DzqjMsto_lHr3U(item, list.ToArray(), _0023_003DzOLHnb2M_003D);
					}
				}
				if (_0023_003DzOmuoKv8_003D != (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzOmuoKv8_003D)2 || flag)
				{
					_0023_003DzOLHnb2M_003D.Add(val);
				}
				_0023_003DzOLHnb2M_003D.AddRange(_0023_003DzACJ8of7_00247mab);
				return true;
			}
		}
		return false;
	}

	private static IEnumerable<T> _0023_003DzorRMj6zXvNF8<T>(T _0023_003Dz7revxoQ_003D, T[] _0023_003DznAREz44_pB8t) where T : Region, new()
	{
		List<T> list = new List<T>();
		list.Add(_0023_003Dz7revxoQ_003D);
		foreach (T b in _0023_003DznAREz44_pB8t)
		{
			List<T> list2 = new List<T>();
			for (int j = 0; j < list.Count; j++)
			{
				list2.AddRange(Difference(list[j], b));
			}
			list = list2;
		}
		return list;
	}

	internal ICurve[] _0023_003DzwDQ_0024Npy1FvS3TXOIuw_003D_003D()
	{
		List<ICurve> list = new List<ICurve>();
		foreach (ICurve contour in contourList)
		{
			list.AddRange(contour.GetIndividualCurves());
		}
		return list.ToArray();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), contourList.Count);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new RegionSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Triangles != null && Triangles.Length != 0 && Edges != null && Edges.Length != 0)
		{
			return ContourList.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzjQNKpiznuyqYoZWdqsbU0XKnTDHY);
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970856), contourList);
	}

	public void FlipNormal()
	{
		foreach (ICurve contour in contourList)
		{
			contour.Reverse();
		}
		if (base.Plane != null)
		{
			base.Plane.Flip();
		}
		Utility.FlipTriangles(_triangles);
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			return ConvertToSurface().Section(pln, tol);
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		double num5 = double.MinValue;
		double num6 = double.MinValue;
		ICurve[] individualCurves = contourList[0].GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			individualCurves[i].GetTightBBox(out var boxMin2, out var boxMax2);
			if (boxMin2.X < num)
			{
				num = boxMin2.X;
			}
			if (boxMax2.X > num4)
			{
				num4 = boxMax2.X;
			}
			if (boxMin2.Y < num2)
			{
				num2 = boxMin2.Y;
			}
			if (boxMax2.Y > num5)
			{
				num5 = boxMax2.Y;
			}
			if (boxMin2.Z < num3)
			{
				num3 = boxMin2.Z;
			}
			if (boxMax2.Z > num6)
			{
				num6 = boxMax2.Z;
			}
		}
		boxMin = new Point3D(num, num2, num3);
		boxMax = new Point3D(num4, num5, num6);
	}

	public override Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		return ExtrudeAsMesh<Mesh>(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public T ExtrudeAsMesh<T>(double amount, double deviation, double angle, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return ExtrudeAsMesh<T>(amount * base.Plane.AxisZ, deviation, angle, meshNature);
	}

	public new T ExtrudeAsMesh<T>(double amount, double deviation, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return ExtrudeAsMesh<T>(amount * base.Plane.AxisZ, deviation, Math.PI / 6.0, meshNature);
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double deviation, Mesh.natureType meshNature)
	{
		return ExtrudeAsMesh<Mesh>(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return ExtrudeAsMesh<Mesh>(amount, deviation, angle, meshNature);
	}

	public Mesh ExtrudeAsMesh(Interval amount, double deviation, Mesh.natureType meshNature)
	{
		return ExtrudeAsMesh<Mesh>(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public Mesh ExtrudeAsMesh(Interval amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return ExtrudeAsMesh<Mesh>(amount, deviation, angle, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature) where T : Mesh, new()
	{
		T val = ConvertToMesh<T>(deviation, angle, meshNature);
		if (val.Triangles.Length != 0)
		{
			val._0023_003DzW_hgTMMRD8msOf_0024FYw_003D_003D(amount, _0023_003Dz6psnhQEjSaf8: true, _0023_003DzoU94611OyOjnISw50Q_003D_003D: true);
		}
		return val;
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double deviation, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return ExtrudeAsMesh<T>(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public Mesh ExtrudeAsMesh<T>(Interval amount, double deviation, double angle, Mesh.natureType meshNature) where T : Mesh, new()
	{
		if (amount.IsDecreasing)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976407), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976113));
		}
		double high = amount.High;
		double low = amount.Low;
		if (Math.Abs(high) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			return ExtrudeAsMesh<T>(base.Plane.AxisZ * low, deviation, angle, meshNature);
		}
		if (Math.Abs(low) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			return ExtrudeAsMesh<T>(base.Plane.AxisZ * high, deviation, angle, meshNature);
		}
		Region obj = (Region)Clone();
		obj.Translate(base.Plane.AxisZ * low);
		Vector3D amount2 = (high - low) * base.Plane.AxisZ;
		return obj.ExtrudeAsMesh<T>(amount2, deviation, angle, meshNature);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		List<Surface> list = new List<Surface>(contourList.Count);
		bool flag = Vector3D.Dot(amount, base.Plane.AxisZ) < 1E-06;
		Surface surface = ConvertToSurface();
		Surface surface2 = (Surface)surface.Clone();
		surface2.Translate(amount);
		if (flag)
		{
			surface2.ReverseU();
		}
		else
		{
			surface.ReverseU();
		}
		list.Add(surface);
		list.Add(surface2);
		for (int i = 0; i < contourList.Count; i++)
		{
			ICurve curve = (ICurve)contourList[i].Clone();
			if (flag)
			{
				curve.Reverse();
			}
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				list.AddRange(individualCurves[j].ExtrudeAsSurface(amount));
			}
		}
		foreach (Surface item in list)
		{
			item.CopyAttributes(this);
		}
		return list.ToArray();
	}

	public new Surface[] ExtrudeAsSurface(double amount)
	{
		return ExtrudeAsSurface(amount * base.Plane.AxisZ);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return ExtrudeAsSurface(amount);
		}
		Vector3D obj = (Vector3D)amount.Clone();
		obj.Normalize();
		bool flag = Vector3D.Dot(amount, base.Plane.AxisZ) < 0.0;
		double num = Math.Sign(new Plane(N: Entity.GetClosestMainAxis(obj), P: Point3D.Origin).DistanceTo(amount.AsPoint));
		double offsetDistance = Entity.GetOffsetDistance(obj, amount, draftAngleInRadians);
		ICurve[] array = ((Region)Clone()).Offset(offsetDistance * num, sharp: true);
		List<Surface> list = new List<Surface>();
		Region region = (Region)Clone();
		region.Regen(tolerance);
		region.FlipNormal();
		list.Add(region.ConvertToSurface());
		List<ICurve> list2 = new List<ICurve>(array);
		list2.RemoveAt(0);
		Surface surface = Surface.CreatePlanar((Plane)base.Plane.Clone(), array[0], list2, sortAndOrient: false);
		surface.Translate(amount);
		list.Add(surface);
		List<ICurve> list3 = ContourList;
		for (int i = 0; i < array.Length; i++)
		{
			ICurve[] individualCurves = list3[i].GetIndividualCurves();
			ICurve[] individualCurves2 = array[i].GetIndividualCurves();
			int num2 = 0;
			for (int j = 0; j < individualCurves2.Length; j++)
			{
				Entity entity = (Entity)individualCurves2[j].Clone();
				entity.Translate(amount);
				if (entity.EntityData == null || entity.EntityData.ToString() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743))
				{
					list.Add(Surface.Ruled(individualCurves[num2], (ICurve)entity));
					num2++;
				}
			}
		}
		if (flag)
		{
			for (int k = 0; k < list.Count; k++)
			{
				list[k].ReverseU();
			}
		}
		foreach (Surface item in list)
		{
			item.CopyAttributes(this);
		}
		return list.ToArray();
	}

	public Surface[] ExtrudeAsSurface(double amount, double draftAngleInRadians, double tolerance)
	{
		return ExtrudeAsSurface(base.Plane.AxisZ * amount, draftAngleInRadians, tolerance);
	}

	public Brep ExtrudeAsBrep(double amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		return ExtrudeAsBrep(base.Plane.AxisZ * amount, angleInRadians, tolerance);
	}

	public Brep ExtrudeAsBrep(Interval amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (amount.IsDecreasing)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976407), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976126));
		}
		Region region = (Region)Clone();
		double high = amount.High;
		double low = amount.Low;
		if (Math.Abs(high) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			return ExtrudeAsBrep(base.Plane.AxisZ * low, 0.0 - angleInRadians);
		}
		if (Math.Abs(low) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			return ExtrudeAsBrep(base.Plane.AxisZ * high, angleInRadians);
		}
		if (Math.Abs(angleInRadians) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			Region obj = (Region)Clone();
			obj.Translate(base.Plane.AxisZ * low);
			Vector3D _0023_003DzYNjcavt9guh = (high - low) * base.Plane.AxisZ;
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(obj, _0023_003DzYNjcavt9guh, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: true, tolerance);
		}
		Brep brep = ExtrudeAsBrep(base.Plane.AxisZ * high, angleInRadians);
		Brep brep2 = ExtrudeAsBrep(base.Plane.AxisZ * low, 0.0 - angleInRadians);
		int num = 0;
		for (int i = 0; i < region.contourList.Count; i++)
		{
			int num2 = region.contourList[i].GetIndividualCurves().Length;
			num += num2;
		}
		int num3 = brep.Faces.Length - 2;
		List<Point3D> list = new List<Point3D>(brep.Vertices.Length + brep2.Vertices.Length);
		list.AddRange(brep.Vertices);
		List<Brep.Edge> list2 = new List<Brep.Edge>(brep.Edges.Length + brep2.Edges.Length);
		list2.AddRange(brep.Edges);
		List<Brep.Face> list3 = new List<Brep.Face>(brep.Faces.Length + brep2.Faces.Length);
		list3.AddRange(brep.Faces);
		list3.RemoveAt(num3);
		for (int j = 0; j < brep2.Vertices.Length; j++)
		{
			Brep.Vertex vertex = (Brep.Vertex)brep2.Vertices[j];
			int num4 = j;
			if (j >= num)
			{
				num4 = list.Count;
				list.Add(vertex);
			}
			else
			{
				((Brep.Vertex)brep.Vertices[j]).Parents = null;
				for (int k = 0; k < num; k++)
				{
					if (((Brep.Vertex)brep.Vertices[k]).Equals(vertex))
					{
						num4 = k;
						break;
					}
				}
			}
			for (int l = 0; l < vertex.Parents.Length; l++)
			{
				Brep.Edge edge = brep2.Edges[vertex.Parents[l]];
				if (edge.StartPointIndex == j && edge.Curve.StartPoint.Equals(vertex))
				{
					edge.StartPointIndex = num4;
				}
				if (edge.EndPointIndex == j && edge.Curve.EndPoint.Equals(vertex))
				{
					edge.EndPointIndex = num4;
				}
			}
			((Brep.Vertex)brep2.Vertices[j]).Parents = null;
		}
		for (int m = 0; m < brep2.Edges.Length; m++)
		{
			Brep.Edge edge2 = brep2.Edges[m];
			int curveIndex = m;
			if (m >= num)
			{
				curveIndex = list2.Count;
				list2.Add(edge2);
			}
			else
			{
				brep.Edges[m].Parents = null;
				for (int n = 0; n < num; n++)
				{
					Brep.Edge edge3 = brep.Edges[n];
					bool num5 = edge3.StartPointIndex == edge2.StartPointIndex && edge3.EndPointIndex == edge2.EndPointIndex;
					bool flag = edge3.StartPointIndex == edge2.EndPointIndex && edge3.EndPointIndex == edge2.StartPointIndex;
					if ((num5 || flag) && Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(edge3.Curve, edge2.Curve, out var _, 1.0) == 0)
					{
						curveIndex = n;
						break;
					}
				}
			}
			for (int num6 = 0; num6 < edge2.Parents.Length; num6++)
			{
				Brep.Face face = brep2.Faces[edge2.Parents[num6]];
				for (int num7 = 0; num7 < face.Loops.Length; num7++)
				{
					for (int num8 = 0; num8 < face.Loops[num7].Segments.Length; num8++)
					{
						Brep.OrientedEdge orientedEdge = face.Loops[num7].Segments[num8];
						bool sense = ((orientedEdge.CurveIndex < num) ? (!orientedEdge.Sense) : orientedEdge.Sense);
						if (orientedEdge.CurveIndex == m && brep2.Edges[orientedEdge.CurveIndex].Equals(edge2))
						{
							face.Loops[num7].Segments[num8] = new Brep.OrientedEdge(curveIndex, sense);
						}
					}
				}
			}
			brep2.Edges[m].Parents = null;
		}
		Brep.Edge[] array = brep.Edges;
		for (int num9 = 0; num9 < array.Length; num9++)
		{
			array[num9].Parents = null;
		}
		for (int num10 = 0; num10 < brep2.Faces.Length; num10++)
		{
			if (num10 != num3)
			{
				list3.Add(brep2.Faces[num10]);
			}
		}
		Brep brep3 = new Brep(list.ToArray(), list2.ToArray(), list3.ToArray(), null, tolerance);
		brep3.CopyAttributes(this);
		return brep3;
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		Region region = (Region)Clone();
		bool flag = Vector3D.Dot(amount, base.Plane.AxisZ) < 1E-06;
		if (Math.Abs(angleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, angleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(region, amount, flag, _0023_003DzbErHvVw_003D: true, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		if (flag)
		{
			region.FlipNormal();
			angleInRadians *= -1.0;
		}
		if (!Vector3D.AreParallel(vector3D, region.Plane.AxisZ))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976103));
		}
		for (int i = 0; i < contourList.Count; i++)
		{
			if (contourList[i] is Curve)
			{
				ICurve[] array = region.contourList[i].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
				Vector3D[] array2 = new Vector3D[2]
				{
					(Vector3D)contourList[i].StartTangent.Clone(),
					(Vector3D)contourList[i].EndTangent.Clone()
				};
				if (array.Length > 1 || !Vector3D.AreCoincident(array2[0], array2[1]))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964128));
				}
			}
		}
		Vector3D closestMainAxis = Entity.GetClosestMainAxis(vector3D);
		double num = Math.Sign(new Plane(Point3D.Origin, closestMainAxis).DistanceTo(amount.AsPoint));
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, angleInRadians);
		ICurve[] array3 = region.Offset(offsetDistance * num, sharp: true);
		int num2 = 0;
		for (int j = 0; j < region.contourList.Count; j++)
		{
			int num3 = region.contourList[j].GetIndividualCurves().Length;
			int num4 = array3[j].GetIndividualCurves().Length;
			if (num3 != num4)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964128));
			}
			num2 += num3;
		}
		Point3D[] array4 = new Point3D[num2 * 2];
		Brep.Edge[] array5 = new Brep.Edge[num2 * 3];
		Brep.OrientedEdge[][] array6 = new Brep.OrientedEdge[num2][];
		Brep.Loop[] array7 = new Brep.Loop[contourList.Count];
		Brep.Loop[] array8 = new Brep.Loop[contourList.Count];
		NurbsSurf[] array9 = new NurbsSurf[num2];
		Brep.Face[] array10 = new Brep.Face[num2 + 2];
		int num5 = 0;
		for (int k = 0; k < region.contourList.Count; k++)
		{
			ICurve[] individualCurves = region.ContourList[k].GetIndividualCurves();
			((Entity)array3[k]).Translate(amount);
			ICurve[] individualCurves2 = array3[k].GetIndividualCurves();
			int num6 = individualCurves.Length;
			Brep.OrientedEdge[] array11 = new Brep.OrientedEdge[num6];
			Brep.OrientedEdge[] array12 = new Brep.OrientedEdge[num6];
			for (int l = 0; l < num6; l++)
			{
				array4[num5 + l] = new Brep.Vertex(individualCurves[l].StartPoint.X, individualCurves[l].StartPoint.Y, individualCurves[l].StartPoint.Z);
				array4[num5 + num2 + l] = new Brep.Vertex(individualCurves2[l].StartPoint.X, individualCurves2[l].StartPoint.Y, individualCurves2[l].StartPoint.Z);
				array5[num5 + l] = new Brep.Edge((ICurve)individualCurves[l].Clone(), num5 + l, num5 + (l + 1) % num6);
				array5[num5 + num2 + l] = new Brep.Edge((ICurve)individualCurves2[l].Clone(), num5 + num2 + l, num2 + num5 + (l + 1) % num6);
				array5[num5 + num2 * 2 + l] = new Brep.Edge(new Line((Point3D)array4[num5 + l].Clone(), (Point3D)array4[num5 + num2 + l].Clone()), num5 + l, num5 + num2 + l);
				array6[num5 + l] = new Brep.OrientedEdge[4];
				array6[num5 + l][0] = new Brep.OrientedEdge(num5 + l);
				array6[num5 + l][1] = new Brep.OrientedEdge(num2 * 2 + num5 + (l + 1) % num6);
				array6[num5 + l][2] = new Brep.OrientedEdge(num5 + num2 + l, sense: false);
				array6[num5 + l][3] = new Brep.OrientedEdge(num5 + num2 * 2 + l, sense: false);
				array11[l] = new Brep.OrientedEdge(num5 + l);
				array12[l] = new Brep.OrientedEdge(num5 + num2 + l);
				Surface surface = Surface.Ruled(individualCurves[l], individualCurves2[l]);
				array9[num5 + l] = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints, num5 + l);
				array10[num5 + l] = new Brep.Face(array9[num5 + l], new Brep.Loop(array6[num5 + l]));
			}
			array7[k] = new Brep.Loop(array11, sense: false);
			array8[k] = new Brep.Loop(array12);
			num5 += num6;
		}
		PlanarSurf surface2 = new PlanarSurf((Point3D)array4[0].Clone(), (Vector3D)region.Plane.AxisZ.Clone(), (Vector3D)region.Plane.AxisX.Clone(), array10.Length - 2);
		PlanarSurf surface3 = new PlanarSurf((Point3D)array4[num2].Clone(), (Vector3D)region.Plane.AxisZ.Clone(), (Vector3D)region.Plane.AxisX.Clone(), array10.Length - 1);
		array10[^2] = new Brep.Face(surface2, array7, sense: false);
		array10[^1] = new Brep.Face(surface3, array8);
		Brep brep = new Brep(array4, array5, array10, null, tolerance);
		brep.CopyAttributes(this);
		return brep;
	}

	public Solid ExtrudeAsSolid(double x, double y, double z, double tolerance)
	{
		return ExtrudeAsSolid<Solid>(x, y, z, tolerance);
	}

	public T ExtrudeAsSolid<T>(double x, double y, double z, double tolerance) where T : Solid, new()
	{
		return ExtrudeAsSolid<T>(new Vector3D(x, y, z), tolerance);
	}

	public new Solid ExtrudeAsSolid(double amount, double tolerance)
	{
		return ExtrudeAsSolid<Solid>(amount, tolerance);
	}

	public new T ExtrudeAsSolid<T>(double amount, double tolerance) where T : Solid, new()
	{
		return ExtrudeAsSolid<T>(amount * base.Plane.AxisZ, tolerance);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return ExtrudeAsSolid<Solid>(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, RegenParams data)
	{
		return ExtrudeAsSolid<Solid>(amount, data);
	}

	public T ExtrudeAsSolid<T>(Vector3D amount, double tolerance) where T : Solid, new()
	{
		return Solid._0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(this, tolerance, amount);
	}

	public T ExtrudeAsSolid<T>(Vector3D amount, RegenParams data) where T : Solid, new()
	{
		return Solid._0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(this, data, amount);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return Solid.Sweep(rail, this, tolerance, sweepMethod);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return Solid.Sweep<T>(rail, this, tolerance, sweepMethod);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return Solid.Sweep(rail, this, tolerance, sweepMethod, merge);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return Solid.Sweep<T>(rail, this, tolerance, sweepMethod, merge);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return RevolveAsMesh(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return RevolveAsMesh<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return Mesh._0023_003DzZsKpvYbXHCDE<Mesh>(this, tolerance, startAngle, deltaAngle, axis, center, slices, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return Mesh._0023_003DzZsKpvYbXHCDE<T>(this, tolerance, startAngle, deltaAngle, axis, center, slices, meshNature);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		List<Surface> list = new List<Surface>(contourList.Count);
		bool num = Math.Abs(deltaAngle % (Math.PI * 2.0)) < 1E-06;
		Surface surface = ConvertToSurface();
		surface.Rotate(startAngle, axis, center);
		Surface surface2 = (Surface)surface.Clone();
		surface2.Rotate(deltaAngle, axis, center);
		Region region = (Region)Clone();
		region.Rotate(startAngle, axis, center);
		bool flag = Utility._0023_003Dzcgl1YHa2I1jhVm1Gy8K96dA_003D(region.contourList[0], region.Plane.AxisZ, axis, center);
		if (!num)
		{
			if (deltaAngle > 0.0 == flag)
			{
				surface.ReverseU();
			}
			else
			{
				surface2.ReverseU();
			}
			list.Add(surface);
			list.Add(surface2);
		}
		for (int i = 0; i < contourList.Count; i++)
		{
			ICurve curve = (ICurve)contourList[i].Clone();
			if (flag)
			{
				curve.Reverse();
			}
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				list.AddRange(individualCurves[j].RevolveAsSurface(startAngle, deltaAngle, axis, center));
			}
		}
		foreach (Surface item in list)
		{
			item.CopyAttributes(this);
		}
		return list.ToArray();
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return RevolveAsSurface(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, startAngle, deltaAngle, axis, center, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, intervalAngle, axis, center, tolerance);
	}

	public Brep RevolveAsBrep(double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, 0.0, deltaAngle, axis, center, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance) where T : Solid, new()
	{
		return RevolveAsSolid<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return RevolveAsSolid<Solid>(intervalAngle, axis, center, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance) where T : Solid, new()
	{
		return Solid._0023_003DzZsKpvYbXHCDE<T>(this, tolerance, startAngle, deltaAngle, axis, center, slices);
	}

	public T RevolveAsSolid<T>(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance) where T : Solid, new()
	{
		return Solid._0023_003DzZsKpvYbXHCDE<T>(this, tolerance, intervalAngle.Low, intervalAngle.Length, axis, center, slices);
	}

	public static Region CreateRectangle(double width, double height, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRectangle(width, height, centered), Plane.XY);
	}

	public static Region CreateRectangle(Plane sketchPlane, double width, double height, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRectangle(sketchPlane, width, height, centered), sketchPlane);
	}

	public static Region CreateRectangle(double x, double y, double width, double height, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRectangle(x, y, width, height, angle, centered), Plane.XY);
	}

	public static Region CreateRectangle(Plane sketchPlane, double x, double y, double width, double height, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRectangle(sketchPlane, x, y, width, height, angle, centered), sketchPlane);
	}

	public static Region CreateRoundedRectangle(double width, double height, double radius, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRoundedRectangle(width, height, radius, centered), Plane.XY);
	}

	public static Region CreateRoundedRectangle(Plane sketchPlane, double width, double height, double radius, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRoundedRectangle(sketchPlane, width, height, radius, centered), sketchPlane);
	}

	public static Region CreateRoundedRectangle(double x, double y, double width, double height, double radius, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRoundedRectangle(x, y, width, height, radius, angle, centered), Plane.XY);
	}

	public static Region CreateRoundedRectangle(Plane sketchPlane, double x, double y, double width, double height, double radius, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateRoundedRectangle(sketchPlane, x, y, width, height, radius, angle, centered), sketchPlane);
	}

	public static Region CreateCircle(double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(0.0, 0.0, 0.0, radius)
		}, Plane.XY);
	}

	public static Region CreateCircle(double x, double y, double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(x, y, 0.0, radius)
		}, Plane.XY);
	}

	public static Region CreateCircle(double x, double y, double z, double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(x, y, z, radius)
		}, Plane.XY);
	}

	public static Region CreateCircle(Plane sketchPlane, double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(sketchPlane, Point2D.Origin, radius)
		}, sketchPlane);
	}

	public static Region CreateCircle(Plane sketchPlane, double x, double y, double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(sketchPlane, new Point2D(x, y), radius)
		}, sketchPlane);
	}

	public static Region CreateCircle(Plane sketchPlane, Point2D center, double radius)
	{
		return new Region(new ICurve[1]
		{
			new Circle(sketchPlane, center, radius)
		}, sketchPlane);
	}

	public static Region CreateEllipse(double rx, double ry)
	{
		return new Region(new ICurve[1]
		{
			new Ellipse(0.0, 0.0, 0.0, rx, ry)
		}, Plane.XY);
	}

	public static Region CreateEllipse(double x, double y, double rx, double ry)
	{
		return new Region(new ICurve[1]
		{
			new Ellipse(x, y, 0.0, rx, ry)
		}, Plane.XY);
	}

	public static Region CreateEllipse(Plane sketchPlane, double rx, double ry)
	{
		return new Region(new ICurve[1]
		{
			new Ellipse(sketchPlane, Point2D.Origin, rx, ry)
		}, sketchPlane);
	}

	public static Region CreateEllipse(Plane sketchPlane, double x, double y, double rx, double ry)
	{
		return new Region(new ICurve[1]
		{
			new Ellipse(sketchPlane, new Point2D(x, y), rx, ry)
		}, sketchPlane);
	}

	public static Region CreateEllipse(Plane sketchPlane, Point2D center, double rx, double ry)
	{
		return new Region(new ICurve[1]
		{
			new Ellipse(sketchPlane, center, rx, ry)
		}, sketchPlane);
	}

	public static Region CreatePolygon(params Point2D[] points)
	{
		return new Region(new ICurve[1]
		{
			new LinearPath(Plane.XY, _0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(points))
		}, Plane.XY, sortAndOrient: true);
	}

	public static Region CreatePolygon(params Point3D[] points)
	{
		return new Region(new ICurve[1]
		{
			new LinearPath(_0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(points))
		});
	}

	public static Region CreatePolygon(Plane sketchPlane, params Point2D[] points)
	{
		return new Region(new LinearPath(sketchPlane, _0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(points.ToArray())), sketchPlane, true);
	}

	internal static T[] _0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D<T>(T[] _0023_003DzrdSL0CI_003D) where T : Point2D
	{
		if (_0023_003DzrdSL0CI_003D.First() == _0023_003DzrdSL0CI_003D.Last())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976041));
		}
		int num = _0023_003DzrdSL0CI_003D.Length;
		T[] array = new T[num + 1];
		Array.Copy(_0023_003DzrdSL0CI_003D, array, num);
		array[num] = (T)_0023_003DzrdSL0CI_003D[0].Clone();
		return array;
	}

	public static Region CreateSlot(double length, double radius, bool centered = false)
	{
		return new Region(CompositeCurve.CreateSlot(length, radius, centered), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateSlot(double x, double y, double length, double radius, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateSlot(x, y, length, radius, angle, centered), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateSlot(Plane sketchPlane, double length, double radius, bool centered = false)
	{
		return new Region(CompositeCurve.CreateSlot(sketchPlane, length, radius, centered), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateSlot(Plane sketchPlane, double x, double y, double length, double radius, double angle = 0.0, bool centered = false)
	{
		return new Region(CompositeCurve.CreateSlot(sketchPlane, x, y, length, radius, angle, centered), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(double angle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(angle, radius, slotRadius), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(double x, double y, double angle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(x, y, angle, radius, slotRadius), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(Plane sketchPlane, double angle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(sketchPlane, angle, radius, slotRadius), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(Plane sketchPlane, double x, double y, double angle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(sketchPlane, x, y, angle, radius, slotRadius), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(startAngle, deltaAngle, radius, slotRadius), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(x, y, startAngle, deltaAngle, radius, slotRadius), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(Plane sketchPlane, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(sketchPlane, startAngle, deltaAngle, radius, slotRadius), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateCircularSlot(Plane sketchPlane, double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		return new Region(CompositeCurve.CreateCircularSlot(sketchPlane, x, y, startAngle, deltaAngle, radius, slotRadius), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateHexagon(double radius, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreateHexagon(radius, inscribed), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateHexagon(double x, double y, double radius, double angle = 0.0, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreateHexagon(x, y, radius, angle, inscribed), Plane.XY, sortAndOrient: false);
	}

	public static Region CreateHexagon(Plane sketchPlane, double radius, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreateHexagon(sketchPlane, 0.0, 0.0, radius, 0.0, inscribed), sketchPlane, sortAndOrient: false);
	}

	public static Region CreateHexagon(Plane sketchPlane, double x, double y, double radius, double angle = 0.0, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreateHexagon(sketchPlane, x, y, radius, angle, inscribed), sketchPlane, sortAndOrient: false);
	}

	public static Region CreatePolygon(int sides, double radius, double angle, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreatePolygon(sides, radius, angle, inscribed), Plane.XY, sortAndOrient: false);
	}

	public static Region CreatePolygon(double x, double y, int sides, double radius, double angle = 0.0, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreatePolygon(x, y, sides, radius, angle, inscribed), Plane.XY, sortAndOrient: false);
	}

	public static Region CreatePolygon(Plane sketchPlane, int sides, double radius, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreatePolygon(sketchPlane, 0.0, 0.0, sides, radius, 0.0, inscribed), sketchPlane, sortAndOrient: false);
	}

	public static Region CreatePolygon(Plane sketchPlane, double x, double y, int sides, double radius, double angle = 0.0, bool inscribed = false)
	{
		return new Region(CompositeCurve.CreatePolygon(sketchPlane, x, y, sides, radius, angle, inscribed), sketchPlane, sortAndOrient: false);
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	private void _0023_003Dz_00243BkrQa_0024lDIE()
	{
		int[,] edgesWithoutDuplicates = Utility.GetEdgesWithoutDuplicates(_triangles, _vertices.Length);
		List<IndexLine> list = new List<IndexLine>();
		for (int i = 0; i < edgesWithoutDuplicates.GetLength(0); i++)
		{
			if (edgesWithoutDuplicates[i, 3] == -1)
			{
				list.Add(new IndexLine(edgesWithoutDuplicates[i, 0], edgesWithoutDuplicates[i, 1]));
			}
		}
		edges = list.ToArray();
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawEdges == null)
		{
			drawEdges = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		drawEdges?.Dispose();
		foreach (Entity contour in contourList)
		{
			contour.Dispose();
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzSrny2FmSPIa7();
		base.Compiling = true;
		data.RenderContext.Compile(drawData, DrawEntity, null);
		data.RenderContext.Compile(drawEdges, _0023_003DzxLlyy8S7CaNX, null);
		foreach (Entity contour in contourList)
		{
			contour.Compile(data);
		}
		base.Compiling = false;
		RegenMode = regenType.NotNeeded;
	}

	private void _0023_003DzxLlyy8S7CaNX(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzB8iS0QA_003D.DrawIndexLines(edges, _vertices);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		context.DrawTrianglesPlanar(_vertices, _triangles, base.Plane.AxisZ);
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (!data.ForceGray && !data.ParentSelected && data.Selected && SelectionMode != selectionFilterType.Entity)
		{
			_0023_003DzvlKUxGyxSiqWxFXLHIy6D_0024U_003D(data);
		}
		else
		{
			data.RenderContext.Draw(drawEdges);
		}
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		if (SelectionMode != selectionFilterType.Entity)
		{
			if (!data.IsDrawingForHalo)
			{
				Entity.SetEntityColorForSelection(data);
				Draw(data);
			}
		}
		else
		{
			base.DrawSelected(data);
		}
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		if (!data.ForceGray && !data.ParentSelected && data.Selected && SelectionMode != selectionFilterType.Entity)
		{
			Entity.SetEntityColorForSelection(data);
			Draw(data);
		}
		else
		{
			Draw(data);
		}
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.Selected && SelectionMode != selectionFilterType.Entity)
		{
			Entity.SetEntityColorForFace(data, data.InsideColor);
			base.DrawHiddenLines(data);
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	private void _0023_003DzvlKUxGyxSiqWxFXLHIy6D_0024U_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		bool flag = _0023_003DzELu0Pss_003D.Selected;
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, this, null, SubContoursSelectionInfo);
		if (selectionInfoSubItems != null)
		{
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			for (int i = 0; i < contourList.Count; i++)
			{
				if (selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
				{
					if (!flag)
					{
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness * _0023_003DzELu0Pss_003D.SelectionLineWeightScaleFactor);
						_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.WireSelectionColor);
						flag = true;
					}
				}
				else
				{
					if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary || _0023_003DzELu0Pss_003D.IsDrawingForHalo)
					{
						continue;
					}
					if (flag)
					{
						_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideColor);
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
						flag = false;
					}
				}
				((Entity)contourList[i]).Draw(_0023_003DzELu0Pss_003D);
			}
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		}
		else
		{
			if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary || _0023_003DzELu0Pss_003D.IsDrawingForHalo)
			{
				return;
			}
			Entity.SetEntityColorForSelection(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
			foreach (Entity contour in contourList)
			{
				contour.Draw(_0023_003DzELu0Pss_003D);
			}
		}
	}

	protected internal override void DrawForSelectionSubContours(DrawForSelectionParams data)
	{
		for (int i = 0; i < contourList.Count; i++)
		{
			ICurve curve = contourList[i];
			data.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedContour>(data, this, i);
			((Entity)curve).Draw(data);
			data.FalseColorIndex++;
		}
	}

	protected internal override void DrawForSelectionWireframe(DrawForSelectionParams data)
	{
		if (data.Isocurves)
		{
			base.DrawForSelectionWireframe(data);
		}
		else
		{
			DrawEdges(data);
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Utility.InsideOrCrossingFrustum(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility._0023_003DzuQDPXh1pHaNF4I3G_Evhw9Q_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		data.RenderContext.DrawNormals(new Point3D[1] { _vertices[0] }, base.Plane.AxisZ * normalLength);
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		ConvertToSurface()._0023_003Dz_0024_0024rGbexgW9YV(_0023_003Dza_SABTbwi5q2, _0023_003DzJO1FWlQ_003D, ref _0023_003DzyzK8swU_003D);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		return ConvertToSurface()._0023_003DzAKDLnmImamFN(_0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ, _0023_003DzsAi4oSk_003D);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity._0023_003Dzz3lsBX3i0Rg2(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public Mesh[] GetTessellation()
	{
		return new Mesh[1]
		{
			new Mesh(_vertices, _triangles)
		};
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return Utility.FindClosestTriangle(transf, seg, _vertices, _triangles).Values;
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, Vertices, _triangles, null, _0023_003DzbErHvVw_003D: false, 0.0);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		Draw(data);
	}

	public void ResetSelectionMode()
	{
		if (!IsAnySubContourSelected())
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	public bool IsAnySubContourSelected()
	{
		if (SelectionInfoSubItems.IsAnySelected(SubContoursSelectionInfo))
		{
			return true;
		}
		return false;
	}

	public void ClearSubContoursSelectionForAllInstances()
	{
		if (IsAnySubContourSelected())
		{
			isDirtyForFlattenTree = true;
		}
		SubContoursSelectionInfo.Clear();
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (SelectionMode == selectionFilterType.Entity)
		{
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		}
		bool flag = false;
		if (SelectionMode == selectionFilterType.Contour && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, SubContoursSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
		{
			flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
		}
		return flag;
	}

	protected internal void ClearSubContoursSelection(selectionStatusType selectionFlag)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(selectionFlag, this, SubContoursSelectionInfo);
		if (selectionFlag == selectionStatusType.Permanent && SelectionMode == selectionFilterType.Contour)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}
}
