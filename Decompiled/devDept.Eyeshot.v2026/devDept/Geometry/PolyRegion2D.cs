using System;
using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public class PolyRegion2D
{
	public IList<Polygon2D> ContourList;

	public PolyRegion2D()
		: this(Plane.XY, new List<IList<Point3D>>(), sortAndOrient: false)
	{
	}

	public PolyRegion2D(Plane plane, IList<IList<Point3D>> contourList)
		: this(plane, contourList, sortAndOrient: false)
	{
	}

	public PolyRegion2D(Plane plane, IList<IList<Point3D>> contourList, bool sortAndOrient)
	{
		List<Polygon2D> list = new List<Polygon2D>(contourList.Count);
		for (int i = 0; i < contourList.Count; i++)
		{
			Polygon2D polygon2D = new Polygon2D(contourList[i].Count);
			for (int j = 0; j < contourList[i].Count; j++)
			{
				polygon2D[j] = plane.Project(contourList[i][j]);
			}
			list.Add(polygon2D);
		}
		_0023_003DztGdcVOA_003D(list, sortAndOrient);
	}

	public PolyRegion2D(IList<Polygon2D> contourList)
		: this(contourList, sortAndOrient: false)
	{
	}

	public PolyRegion2D(IList<Polygon2D> contourList, bool sortAndOrient)
	{
		_0023_003DztGdcVOA_003D(contourList, sortAndOrient);
	}

	public PolyRegion2D(Region region, double deviation = 0.0, double angle = Math.PI / 6.0)
	{
		ContourList = new List<Polygon2D>(region.contourList.Count);
		Plane plane = region.Plane;
		plane.Origin = region.Plane.PointAt(region.Plane.Project(Point3D.Origin));
		foreach (ICurve contour in region.ContourList)
		{
			Entity entity = (Entity)contour;
			if (deviation != 0.0)
			{
				entity = (Entity)contour.Clone();
				entity.Regen(new RegenParams(deviation, angle));
			}
			int num = entity.Vertices.Length;
			Point2D[] array = new Point2D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = plane.Project(entity.Vertices[i]);
			}
			ContourList.Add(new Polygon2D(array));
		}
	}

	protected PolyRegion2D(PolyRegion2D another)
	{
		ContourList = new List<Polygon2D>(another.ContourList.Count);
		foreach (Polygon2D contour in another.ContourList)
		{
			ContourList.Add((Polygon2D)contour.Clone());
		}
	}

	[Obsolete("Use the dedicated constructor instead.")]
	public static PolyRegion2D FromRegion(Region region, Plane plane, double deviation)
	{
		List<Polygon2D> list = new List<Polygon2D>();
		for (int i = 0; i < region.ContourList.Count; i++)
		{
			List<Point2D> list2 = new List<Point2D>();
			Entity entity = (Entity)region.ContourList[i];
			if (deviation != 0.0 || entity.Vertices == null)
			{
				entity.Regen(deviation);
			}
			for (int j = 0; j < entity.Vertices.Length; j++)
			{
				list2.Add(plane.Project(entity.Vertices[j]));
			}
			list.Add(new Polygon2D(list2));
		}
		return new PolyRegion2D(list);
	}

	public void UpdateBoundingRect()
	{
		foreach (Polygon2D contour in ContourList)
		{
			contour.UpdateBoundingRect();
		}
	}

	public Region ToRegion(Plane plane)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < ContourList.Count; i++)
		{
			LinearPath item = new LinearPath(plane, ContourList[i].Points);
			list.Add(item);
		}
		return new Region(list, plane, sortAndOrient: false);
	}

	private void _0023_003DztGdcVOA_003D(IList<Polygon2D> _0023_003DzfiBtPtOJuTYGM5yQGg_003D_003D, bool _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D)
	{
		ContourList = _0023_003DzfiBtPtOJuTYGM5yQGg_003D_003D;
		if (_0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D)
		{
			SortAndOrient();
		}
	}

	public void SortAndOrient(IList<ICurve> parentContours = null)
	{
		if (ContourList.Count > 1)
		{
			int outerIndex = Utility.GetOuterIndex(ContourList);
			Polygon2D value = ContourList[0];
			ContourList[0] = ContourList[outerIndex];
			ContourList[outerIndex] = value;
			if (parentContours != null)
			{
				ICurve value2 = parentContours[0];
				parentContours[0] = parentContours[outerIndex];
				parentContours[outerIndex] = value2;
			}
		}
		for (int i = 0; i < ContourList.Count; i++)
		{
			bool flag = ContourList[i].IsOrientedClockwise();
			if ((i == 0 && flag) || (i > 0 && !flag))
			{
				ContourList[i].Reverse();
				parentContours?[i].Reverse();
			}
		}
	}

	private static double _0023_003DzMnn_sI1bfuYs(IList<IList<Point2D>> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out double _0023_003DzccAR5G0_003D)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			Utility.UpdateMinMax(null, _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i], _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].Count, maxValue, minValue);
		}
		_0023_003DzccAR5G0_003D = new Size2D(maxValue, minValue).Diagonal;
		return _0023_003DzccAR5G0_003D * 0.001;
	}

	private static List<PolyRegion2D> _0023_003DzNC7p9G80lhFN(PolyRegion2D _0023_003Dz3FeGe_0024g_003D, PolyRegion2D _0023_003DzS34bGBo_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, Point2D _0023_003DzqidD6PV3d4F_0024, Point2D _0023_003Dz9wTFiDxLFmC4)
	{
		List<IList<Point2D>> list = new List<IList<Point2D>>();
		list.Add(_0023_003Dz3FeGe_0024g_003D.ContourList[0].Points);
		List<IList<Point2D>> list2 = new List<IList<Point2D>>();
		list2.Add(_0023_003DzS34bGBo_003D.ContourList[0].Points);
		if (_0023_003DzqidD6PV3d4F_0024 == null || _0023_003Dz9wTFiDxLFmC4 == null)
		{
			_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK._0023_003Dzzg08ZSAHPR69(new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D[2]
			{
				new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(list),
				new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(list2)
			}, out _0023_003DzqidD6PV3d4F_0024, out _0023_003Dz9wTFiDxLFmC4);
		}
		IntegerGrid _0023_003DzOSo8vaE_003D = new IntegerGrid(524288, _0023_003DzqidD6PV3d4F_0024, _0023_003Dz9wTFiDxLFmC4);
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzYkgRucGPvHIg = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.ContourList[0].Points, _0023_003DzOSo8vaE_003D);
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzXUjJnNL3eU8F = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003DzS34bGBo_003D.ContourList[0].Points, _0023_003DzOSo8vaE_003D);
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list3 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003Dz3FeGe_0024g_003D.ContourList.Count - 1);
		List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> list4 = new List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK>(_0023_003DzS34bGBo_003D.ContourList.Count - 1);
		for (int i = 1; i < _0023_003Dz3FeGe_0024g_003D.ContourList.Count; i++)
		{
			list3.Add(new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003Dz3FeGe_0024g_003D.ContourList[i].Points, _0023_003DzOSo8vaE_003D));
		}
		for (int j = 1; j < _0023_003DzS34bGBo_003D.ContourList.Count; j++)
		{
			list4.Add(new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(_0023_003DzS34bGBo_003D.ContourList[j].Points, _0023_003DzOSo8vaE_003D));
		}
		return _0023_003DzpeAGXAyxMfTFgHrkYg_003D_003D(_0023_003DzYkgRucGPvHIg, list3, _0023_003DzXUjJnNL3eU8F, list4, _0023_003DzOSo8vaE_003D, _0023_003DzwY9ClXw_003D);
	}

	internal static List<PolyRegion2D> _0023_003DzpeAGXAyxMfTFgHrkYg_003D_003D(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzYkgRucGPvHIg, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003DzXUjJnNL3eU8F, List<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK> _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D)
	{
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>(_0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D.Count + 1);
		list.Add(_0023_003DzNiAnSbTBniTWTPvRv7PsR2I_003D(_0023_003DzYkgRucGPvHIg));
		for (int i = 0; i < _0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D.Count; i++)
		{
			list.Add(_0023_003DzNiAnSbTBniTWTPvRv7PsR2I_003D(_0023_003Dzj6TheTJh4I9O7mXKkw_003D_003D[i]));
		}
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list2 = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>(_0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D.Count + 1);
		list2.Add(_0023_003DzNiAnSbTBniTWTPvRv7PsR2I_003D(_0023_003DzXUjJnNL3eU8F));
		for (int j = 0; j < _0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D.Count; j++)
		{
			list2.Add(_0023_003DzNiAnSbTBniTWTPvRv7PsR2I_003D(_0023_003DzpEvYnX0ST5Dgdg9eLQ_003D_003D[j]));
		}
		_0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D2 = new _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D();
		_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27 _0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28 = new _0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27();
		_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28._0023_003DzqUzJcXY_003D(list, (_0023_003DzzqdpaCyKHWJkaZ1yiW3ZswY_003D)0, _0023_003DzbErHvVw_003D: true);
		_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28._0023_003DzqUzJcXY_003D(list2, (_0023_003DzzqdpaCyKHWJkaZ1yiW3ZswY_003D)1, _0023_003DzbErHvVw_003D: true);
		switch (_0023_003DzwY9ClXw_003D)
		{
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)1:
			_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28._0023_003Dz_IsqsVA_003D((_0023_003Dzz0mnvqLCLeOOMt7p2BgDqoE_003D)0, _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D2);
			break;
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0:
			_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28._0023_003Dz_IsqsVA_003D((_0023_003Dzz0mnvqLCLeOOMt7p2BgDqoE_003D)1, _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D2);
			break;
		case (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2:
			_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC28._0023_003Dz_IsqsVA_003D((_0023_003Dzz0mnvqLCLeOOMt7p2BgDqoE_003D)2, _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D2);
			break;
		}
		return _0023_003DzVt8pi8rEShLogtq_0024nA_003D_003D(_0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D2, _0023_003DzOSo8vaE_003D);
	}

	private static List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003DzNiAnSbTBniTWTPvRv7PsR2I_003D(_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz3tJbBMkDD6sl6naslA_003D_003D)
	{
		List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list = new List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>(_0023_003Dz3tJbBMkDD6sl6naslA_003D_003D._0023_003DzvRAdRPd11xUJ().Count);
		for (LinkedListNode<_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003Dz3tJbBMkDD6sl6naslA_003D_003D._0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			list.Add(new _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D));
		}
		return list;
	}

	private static List<PolyRegion2D> _0023_003DzVt8pi8rEShLogtq_0024nA_003D_003D(_0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D _0023_003Dz1erSizk_003D, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		List<PolyRegion2D> list = new List<PolyRegion2D>();
		foreach (_0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D item in _0023_003Dz1erSizk_003D._0023_003DzTSAXx7Mw5HqJkcM_Ig_003D_003D())
		{
			if (item._0023_003Dz9F8fnNOO8jM7())
			{
				continue;
			}
			List<Point2D> points = _0023_003DzGZg47TarvenL(item._0023_003DzKwncrZxD0Js4MVkxuw_003D_003D(), _0023_003DzOSo8vaE_003D);
			List<Polygon2D> list2 = new List<Polygon2D>();
			list2.Add(new Polygon2D(points));
			List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list3 = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
			foreach (_0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D item2 in item._0023_003DzRKMRAyavcXgJ8AG4HA_003D_003D())
			{
				list3.Add(item2._0023_003DzKwncrZxD0Js4MVkxuw_003D_003D());
			}
			foreach (Polygon2D item3 in _0023_003DzrFfWONkHqBDdqm1xbw_003D_003D(list3, _0023_003DzOSo8vaE_003D))
			{
				list2.Add(item3);
			}
			list.Add(new PolyRegion2D(list2));
		}
		return list;
	}

	private static List<Point2D> _0023_003DzGZg47TarvenL(List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003DznBqMmF4ogISB, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		List<Point2D> list = new List<Point2D>();
		foreach (_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item in _0023_003DznBqMmF4ogISB)
		{
			_0023_003DzOSo8vaE_003D.ScaleToWorld((int)item._0023_003Dzyk2fsPo_003D, (int)item._0023_003DzvXOLtKg_003D, out var x, out var y);
			list.Add(new Point2D(x, y));
		}
		list.Add((Point2D)list[0].Clone());
		return list;
	}

	private static List<Polygon2D> _0023_003DzrFfWONkHqBDdqm1xbw_003D_003D(List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzS4iocdj1PPN7, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		List<Polygon2D> list = new List<Polygon2D>();
		for (int i = 0; i < _0023_003DzS4iocdj1PPN7.Count; i++)
		{
			list.Add(new Polygon2D(_0023_003DzGZg47TarvenL(_0023_003DzS4iocdj1PPN7[i], _0023_003DzOSo8vaE_003D)));
		}
		return list;
	}

	public static PolyRegion2D[] Union(PolyRegion2D a, PolyRegion2D b, Point2D domainMin = null, Point2D domainMax = null)
	{
		return _0023_003DzNC7p9G80lhFN(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)0, domainMin, domainMax).ToArray();
	}

	public static PolyRegion2D[] Intersection(PolyRegion2D a, PolyRegion2D b, Point2D domainMin = null, Point2D domainMax = null)
	{
		return _0023_003DzNC7p9G80lhFN(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)1, domainMin, domainMax).ToArray();
	}

	public static PolyRegion2D[] Difference(PolyRegion2D a, PolyRegion2D b, Point2D domainMin = null, Point2D domainMax = null)
	{
		return _0023_003DzNC7p9G80lhFN(a, b, (_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz4JAfHNw_003D)2, domainMin, domainMax).ToArray();
	}

	public bool IsPointInside(Point2D point)
	{
		if (!ContourList[0].IsPointInside(point))
		{
			return false;
		}
		for (int i = 1; i < ContourList.Count; i++)
		{
			if (ContourList[i].IsPointInside(point))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsPolygonInside(Polygon2D poly)
	{
		Polygon2D polygon2D = ContourList[0];
		if (!Utility.DoOverlap(polygon2D.Min, polygon2D.Max, poly.Min, poly.Max))
		{
			return false;
		}
		int num = poly.Points.Length;
		int num2 = 0;
		for (int i = 0; i < num - 1; i++)
		{
			if (IsPointInside(poly[i]))
			{
				num2++;
			}
		}
		if (num2 == num - 1)
		{
			return !_0023_003DzZMJf4oLvwCSA(poly);
		}
		return false;
	}

	public bool IsPolygonOutside(Polygon2D poly)
	{
		Polygon2D polygon2D = ContourList[0];
		if (!Utility.DoOverlap(polygon2D.Min, polygon2D.Max, poly.Min, poly.Max))
		{
			return true;
		}
		int num = poly.Points.Length;
		int num2 = 0;
		for (int i = 0; i < num - 1; i++)
		{
			if (!IsPointInside(poly[i]))
			{
				num2++;
			}
		}
		if (num2 == num - 1)
		{
			return !_0023_003DzZMJf4oLvwCSA(poly);
		}
		return false;
	}

	private bool _0023_003DzZMJf4oLvwCSA(Polygon2D _0023_003DzIgxVOZM_003D)
	{
		foreach (Polygon2D contour in ContourList)
		{
			for (int i = 0; i < contour.Points.Length - 1; i++)
			{
				Segment2D segment = new Segment2D(contour[i], contour[i + 1]);
				if (_0023_003DzIgxVOZM_003D.IntersectWith(segment))
				{
					return true;
				}
			}
		}
		return false;
	}

	public Polygon2D[] Offset(double amount, double miterLimit = 2.0)
	{
		IntegerGrid _0023_003DzOSo8vaE_003D;
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list = _0023_003DzQt4oWxJKViCV(amount, miterLimit, out _0023_003DzOSo8vaE_003D);
		int count = list.Count;
		Polygon2D[] array = new Polygon2D[count];
		for (int i = 0; i < count; i++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list2 = list[i];
			int count2 = list2.Count;
			Point2D[] array2 = new Point2D[count2 + 1];
			for (int j = 0; j < count2; j++)
			{
				_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list2[j];
				_0023_003DzOSo8vaE_003D.ScaleToWorld((int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, (int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
				array2[j] = new Point2D(x, y);
			}
			array2[count2] = (Point2D)array2[0].Clone();
			Polygon2D polygon2D = new Polygon2D(array2);
			if (Math.Sign(_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27._0023_003Dz0B52BHY_003D(list2)) != Math.Sign(Utility.PolygonArea(ContourList[i].Points)))
			{
				list2.Reverse();
			}
			array[i] = polygon2D;
		}
		return array;
	}

	private List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzQt4oWxJKViCV(double _0023_003DzYNjcavt9guh2, double _0023_003DzxGO8fYElkqEK, out IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D2 = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(new List<IList<Point2D>> { ContourList[0].Points });
		IList<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> list = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D[ContourList.Count - 1];
		for (int i = 1; i < ContourList.Count; i++)
		{
			list[i - 1] = new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(new List<IList<Point2D>> { ContourList[i].Points });
		}
		_0023_003DzOSo8vaE_003D = _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK._0023_003Dz_LrsyseLeNti(1, new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> { _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D2 }, out var _, out var _);
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list2 = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>(ContourList.Count);
		_0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D2, list2, _0023_003DzOSo8vaE_003D);
		foreach (_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D item in list)
		{
			_0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(item, list2, _0023_003DzOSo8vaE_003D);
		}
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dz1erSizk_003D = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
		double _0023_003DzO1AkaTYvv61l = _0023_003DzOSo8vaE_003D._0023_003DzO1AkaTYvv61l;
		_0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u obj = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(_0023_003DzxGO8fYElkqEK, 0.0);
		obj._0023_003DzqUzJcXY_003D(list2, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)2, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)0);
		obj._0023_003Dz_IsqsVA_003D(ref _0023_003Dz1erSizk_003D, _0023_003DzYNjcavt9guh2 * _0023_003DzO1AkaTYvv61l);
		return _0023_003Dz1erSizk_003D;
	}

	private void _0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz06A5WivSSyUp, List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dznl3w87ObFuqU, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(Plane.XY, null, _0023_003Dz06A5WivSSyUp, null, _0023_003DzOSo8vaE_003D, _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D: true);
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

	public bool IsPointInside(Point2D point, double domainSize)
	{
		if (ContourList[0].IsPointInside(point, domainSize) == pointStatusType.Outside)
		{
			return false;
		}
		for (int i = 1; i < ContourList.Count; i++)
		{
			if (ContourList[i].IsPointInside(point, domainSize) == pointStatusType.Inside || ContourList[i].IsPointInside(point, domainSize) == pointStatusType.Onto)
			{
				return false;
			}
		}
		return true;
	}

	public polygonStatusType IsBoxInside(Point2D min, Point2D max, double inflate)
	{
		return IsBoxInside(new Point2D(min.X - inflate, min.Y - inflate), new Point2D(max.X + inflate, max.Y + inflate));
	}

	public polygonStatusType IsBoxInside(Point2D min, Point2D max)
	{
		Polygon2D polygon2D = ContourList[0];
		if (!Utility._0023_003DzGBcHaJW_L4SQ(polygon2D.Min, polygon2D.Max, min, max, out var _0023_003Dzsc0Foo8_003D, out var _))
		{
			return polygonStatusType.Out;
		}
		if (_0023_003Dzsc0Foo8_003D)
		{
			return polygonStatusType.Over;
		}
		for (int i = 1; i < ContourList.Count; i++)
		{
			switch (ContourList[i].IsBoxInside(min, max))
			{
			case polygonStatusType.On:
			case polygonStatusType.Over:
				return polygonStatusType.On;
			case polygonStatusType.In:
				return polygonStatusType.Out;
			}
		}
		return polygon2D.IsBoxInside(min, max);
	}

	public PolyRegion2D Clone()
	{
		return new PolyRegion2D(this);
	}

	public void TransformBy(Transformation xform)
	{
		bool hasReflection = xform.HasReflection;
		foreach (Polygon2D contour in ContourList)
		{
			Point2D[] points = contour.Points;
			for (int i = 0; i < points.Length; i++)
			{
				points[i].TransformBy(xform);
			}
			if (hasReflection)
			{
				contour.Reverse();
			}
		}
	}
}
