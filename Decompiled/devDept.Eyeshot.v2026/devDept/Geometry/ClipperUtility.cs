using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace devDept.Geometry;

public class ClipperUtility
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u _0023_003DzIH54RY_00240U6p8stAr1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dznl3w87ObFuqU;

	public ClipperUtility(double miterLimit = 2.0, double arcTolerance = 0.25)
	{
		_0023_003DzIH54RY_00240U6p8stAr1w_003D_003D = new _0023_003DzJG_8PX5kpBAt_0024CBM82XGhO9XW88u(miterLimit, arcTolerance);
		_0023_003Dznl3w87ObFuqU = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
	}

	private void _0023_003DzqUzJcXY_003D(List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzCULckQQ_003D)
	{
		_0023_003DzIH54RY_00240U6p8stAr1w_003D_003D._0023_003DzqUzJcXY_003D(_0023_003DzCULckQQ_003D, (_0023_003Dz5nKwufsJUZoRBmnCJySV3Co_003D)1, (_0023_003DzSeuDV6qEG_t7CCQHDy_pEY8_003D)0);
	}

	public void AddContour(IntegerGrid grid, Point2D[] stroke)
	{
		_0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK = new _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D._0023_003Dz_0024WkMNd__uiAK(stroke, grid);
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

	public Point3D[][] Execute(double delta, IntegerGrid grid, double zh, bool reverse)
	{
		_0023_003DzqUzJcXY_003D(_0023_003Dznl3w87ObFuqU);
		List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dz1erSizk_003D = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
		_0023_003DzIH54RY_00240U6p8stAr1w_003D_003D._0023_003Dz_IsqsVA_003D(ref _0023_003Dz1erSizk_003D, delta);
		int count = _0023_003Dz1erSizk_003D.Count;
		Point3D[][] array = new Point3D[count][];
		for (int i = 0; i < count; i++)
		{
			List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list = _0023_003Dz1erSizk_003D[i];
			int count2 = list.Count;
			Point3D[] array2 = new Point3D[count2 + 1];
			for (int j = 0; j < count2; j++)
			{
				_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list[j];
				grid.ScaleToWorld((int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, (int)_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
				array2[j] = new Point3D(x, y, zh);
			}
			array2[count2] = (Point3D)array2[0].Clone();
			if (reverse)
			{
				Array.Reverse(array2);
			}
			array[i] = array2;
		}
		_0023_003Dznl3w87ObFuqU = new List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>>();
		return array;
	}

	public static Point2D[] RemoveDuplicates(IList<Point3D> intersectionPoints, Point2D min, Point2D max)
	{
		IntegerGrid integerGrid = new IntegerGrid(2048, min, max);
		HashSet<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> hashSet = new HashSet<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>();
		List<Point2D> list = new List<Point2D>();
		for (int i = 0; i < intersectionPoints.Count; i++)
		{
			PointSection pointSection = (PointSection)intersectionPoints[i];
			integerGrid.ScaleToGrid(pointSection.X, pointSection.Y, out int gridX, out int gridY);
			if (hashSet.Add(new _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(gridX, gridY)))
			{
				integerGrid.ScaleToWorld(gridX, gridY, out var x, out var y);
				list.Add(new PointSection(x, y, 0.0, pointSection.plotValue));
			}
		}
		return list.ToArray();
	}
}
