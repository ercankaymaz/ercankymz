using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Util;

namespace Poly2Tri.Utility;

public class Point2DList : IEnumerable, IEnumerable<Point2D>, IList<Point2D>, ICollection<Point2D>
{
	public enum WindingOrderType
	{
		Clockwise = 0,
		AntiClockwise = 1,
		Unknown = 2,
		Default = 1
	}

	[Flags]
	public enum PolygonError : uint
	{
		None = 0u,
		NotEnoughVertices = 1u,
		NotConvex = 2u,
		NotSimple = 4u,
		AreaTooSmall = 8u,
		SidesTooCloseToParallel = 0x10u,
		TooThin = 0x20u,
		Degenerate = 0x40u,
		Unknown = 0x40000000u
	}

	public const double LINEAR_SLOP = 0.005;

	protected readonly List<Point2D> MPoints = new List<Point2D>();

	private WindingOrderType windingOrderType_0 = WindingOrderType.Unknown;

	private Rect2D rect2D_0 = default(Rect2D);

	[CompilerGenerated]
	private double double_0;

	public Rect2D BoundingBox
	{
		get
		{
			return rect2D_0;
		}
		protected set
		{
			rect2D_0 = value;
		}
	}

	public WindingOrderType WindingOrder
	{
		get
		{
			return windingOrderType_0;
		}
		set
		{
			if (windingOrderType_0 == WindingOrderType.Unknown)
			{
				windingOrderType_0 = CalculateWindingOrder();
			}
			if (value != windingOrderType_0 && value != WindingOrderType.Unknown)
			{
				MPoints.Reverse();
			}
			windingOrderType_0 = value;
		}
	}

	public double Epsilon
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		protected set
		{
			double_0 = value;
		}
	}

	public Point2D this[int index]
	{
		get
		{
			return MPoints[index];
		}
		set
		{
			MPoints[index] = value;
		}
	}

	public int Count => MPoints.Count;

	public virtual bool IsReadOnly => false;

	public Point2DList()
	{
		Epsilon = 1E-12;
	}

	private Point2DList(int int_0)
		: this()
	{
		MPoints.Capacity = int_0;
	}

	public Point2DList(Point2DList l)
		: this()
	{
		int count = l.Count;
		for (int i = 0; i < count; i++)
		{
			MPoints.Add(l[i]);
		}
		rect2D_0 = l.BoundingBox;
		Epsilon = l.Epsilon;
		windingOrderType_0 = l.WindingOrder;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Count; i++)
		{
			stringBuilder.Append(this[i]);
			if (i < Count - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<Point2D>)this).GetEnumerator();
	}

	IEnumerator<Point2D> IEnumerable<Point2D>.GetEnumerator()
	{
		return MPoints.GetEnumerator();
	}

	public void Clear()
	{
		MPoints.Clear();
		rect2D_0 = default(Rect2D);
		Epsilon = 1E-12;
		windingOrderType_0 = WindingOrderType.Unknown;
	}

	public int IndexOf(Point2D p)
	{
		return MPoints.IndexOf(p);
	}

	public virtual void Add(Point2D p)
	{
		Add(p, -1, bCalcWindingOrderAndEpsilon: true);
	}

	protected virtual void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
	{
		if (idx >= 0)
		{
			MPoints.Insert(idx, p);
		}
		else
		{
			MPoints.Add(p);
		}
		BoundingBox = BoundingBox.AddPoint(p);
		if (bCalcWindingOrderAndEpsilon)
		{
			if (windingOrderType_0 == WindingOrderType.Unknown)
			{
				windingOrderType_0 = CalculateWindingOrder();
			}
			Epsilon = CalculateEpsilon();
		}
	}

	public void AddRange(Point2DList l)
	{
		AddRange(l.MPoints.GetEnumerator(), l.WindingOrder);
	}

	public void AddRange(IEnumerable<Point2D> items)
	{
		AddRange(items.GetEnumerator(), WindingOrderType.Unknown);
	}

	protected virtual void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
	{
		if (iter == null)
		{
			return;
		}
		if (windingOrderType_0 == WindingOrderType.Unknown && Count == 0)
		{
			windingOrderType_0 = windingOrder;
		}
		bool flag = WindingOrder != WindingOrderType.Unknown && windingOrder != WindingOrderType.Unknown && WindingOrder != windingOrder;
		bool flag2 = true;
		int count = MPoints.Count;
		iter.Reset();
		while (iter.MoveNext())
		{
			if (flag2)
			{
				if (!flag)
				{
					MPoints.Add(iter.Current);
				}
				else
				{
					MPoints.Insert(count, iter.Current);
				}
			}
			else
			{
				flag2 = true;
				MPoints.Add(iter.Current);
			}
			BoundingBox = BoundingBox.AddPoint(iter.Current);
		}
		if (windingOrderType_0 == WindingOrderType.Unknown && windingOrder == WindingOrderType.Unknown)
		{
			windingOrderType_0 = CalculateWindingOrder();
		}
		Epsilon = CalculateEpsilon();
	}

	public virtual void Insert(int idx, Point2D item)
	{
		Add(item, idx, bCalcWindingOrderAndEpsilon: true);
	}

	public virtual bool Remove(Point2D p)
	{
		if (!MPoints.Remove(p))
		{
			return false;
		}
		method_0();
		Epsilon = CalculateEpsilon();
		return true;
	}

	public virtual void RemoveAt(int idx)
	{
		if (idx >= 0 && idx < Count)
		{
			MPoints.RemoveAt(idx);
			method_0();
			Epsilon = CalculateEpsilon();
		}
	}

	public void RemoveRange(int idxStart, int count)
	{
		if (idxStart >= 0 && idxStart < Count && count != 0)
		{
			MPoints.RemoveRange(idxStart, count);
			method_0();
			Epsilon = CalculateEpsilon();
		}
	}

	public bool Contains(Point2D p)
	{
		return MPoints.Contains(p);
	}

	public void CopyTo(Point2D[] array, int arrayIndex)
	{
		int num = Math.Min(Count, array.Length - arrayIndex);
		for (int i = 0; i < num; i++)
		{
			array[arrayIndex + i] = MPoints[i];
		}
	}

	private void method_0()
	{
		rect2D_0 = default(Rect2D);
		foreach (Point2D mPoint in MPoints)
		{
			BoundingBox = BoundingBox.AddPoint(mPoint);
		}
	}

	public double CalculateEpsilon()
	{
		return Math.Max(Math.Min(BoundingBox.Width, BoundingBox.Height) * 0.0010000000474974513, 1E-12);
	}

	public WindingOrderType CalculateWindingOrder()
	{
		double num = method_1();
		if (!(num < 0.0))
		{
			if (!(num > 0.0))
			{
				return WindingOrderType.Unknown;
			}
			return WindingOrderType.AntiClockwise;
		}
		return WindingOrderType.Clockwise;
	}

	public int NextIndex(int index)
	{
		if (index != Count - 1)
		{
			return index + 1;
		}
		return 0;
	}

	public int PreviousIndex(int index)
	{
		if (index != 0)
		{
			return index - 1;
		}
		return Count - 1;
	}

	private double method_1()
	{
		double num = 0.0;
		for (int i = 0; i < Count; i++)
		{
			int index = (i + 1) % Count;
			num += this[i].X * this[index].Y;
			num -= this[i].Y * this[index].X;
		}
		return num / 2.0;
	}

	private double method_2()
	{
		double num = 0.0;
		for (int i = 0; i < Count; i++)
		{
			int index = (i + 1) % Count;
			num += this[i].X * this[index].Y;
			num -= this[i].Y * this[index].X;
		}
		num /= 2.0;
		return (num >= 0.0) ? num : (0.0 - num);
	}

	public Point2D GetCentroid()
	{
		Point2D point2D = new Point2D();
		double num = 0.0;
		Point2D point2D2 = new Point2D();
		for (int i = 0; i < Count; i++)
		{
			Point2D point2D3 = point2D2;
			Point2D point2D4 = this[i];
			Point2D point2D5 = ((i + 1 >= Count) ? this[0] : this[i + 1]);
			Point2D lhs = point2D4 - point2D3;
			Point2D rhs = point2D5 - point2D3;
			double num2 = Point2D.Cross(lhs, rhs);
			double num3 = 0.5 * num2;
			num += num3;
			point2D += num3 * (1.0 / 3.0) * (point2D3 + point2D4 + point2D5);
		}
		return point2D * (1.0 / num);
	}

	public void Translate(Point2D vector)
	{
		for (int i = 0; i < Count; i++)
		{
			this[i] += vector;
		}
	}

	public void Scale(Point2D value)
	{
		for (int i = 0; i < Count; i++)
		{
			this[i] *= value;
		}
	}

	public void Rotate(double radians)
	{
		double num = Math.Cos(radians);
		double num2 = Math.Sin(radians);
		foreach (Point2D mPoint in MPoints)
		{
			double x = mPoint.X;
			mPoint.X = x * num - mPoint.Y * num2;
			mPoint.Y = x * num2 + mPoint.Y * num;
		}
	}

	private bool method_3()
	{
		if (Count >= 3)
		{
			for (int i = 0; i < Count; i++)
			{
				int index = PreviousIndex(i);
				if (!MPoints[index].Equals(MPoints[i], Epsilon))
				{
					int index2 = PreviousIndex(index);
					Orientation orientation = TriangulationUtil.Orient2d(MPoints[index2], MPoints[index], MPoints[i]);
					if (orientation == Orientation.Collinear)
					{
						return true;
					}
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public bool IsConvex()
	{
		bool flag = false;
		for (int i = 0; i < Count; i++)
		{
			int index = ((i != 0) ? (i - 1) : (Count - 1));
			int index2 = i;
			int index3 = ((i != Count - 1) ? (i + 1) : 0);
			double num = this[index2].X - this[index].X;
			double num2 = this[index2].Y - this[index].Y;
			double num3 = this[index3].X - this[index2].X;
			double num4 = this[index3].Y - this[index2].Y;
			double num5 = num * num4 - num3 * num2;
			bool flag2 = num5 >= 0.0;
			if (i != 0)
			{
				if (flag != flag2)
				{
					return false;
				}
			}
			else
			{
				flag = flag2;
			}
		}
		return true;
	}

	private bool method_4()
	{
		for (int i = 0; i < Count; i++)
		{
			int index = NextIndex(i);
			for (int j = i + 1; j < Count; j++)
			{
				int index2 = NextIndex(j);
				Point2D pIntersectionPt = null;
				if (TriangulationUtil.LinesIntersect2D(MPoints[i], MPoints[index], MPoints[j], MPoints[index2], ref pIntersectionPt, Epsilon))
				{
					return false;
				}
			}
		}
		return true;
	}

	public PolygonError CheckPolygon()
	{
		PolygonError polygonError = PolygonError.None;
		if (Count >= 3 && Count <= 100000)
		{
			if (method_3())
			{
				polygonError |= PolygonError.Degenerate;
			}
			if (!method_4())
			{
				polygonError |= PolygonError.NotSimple;
			}
			if (method_2() < 1E-12)
			{
				polygonError |= PolygonError.AreaTooSmall;
			}
			if ((polygonError & PolygonError.NotSimple) != PolygonError.NotSimple)
			{
				bool flag = false;
				if (WindingOrder == WindingOrderType.Clockwise)
				{
					WindingOrder = WindingOrderType.AntiClockwise;
					flag = true;
				}
				Point2D[] array = new Point2D[Count];
				Point2DList point2DList = new Point2DList(Count);
				for (int i = 0; i < Count; i++)
				{
					point2DList.Add(new Point2D(this[i].X, this[i].Y));
					int index = i;
					int index2 = NextIndex(i);
					Point2D lhs = new Point2D(this[index2].X - this[index].X, this[index2].Y - this[index].Y);
					array[i] = Point2D.Perpendicular(lhs, 1.0);
					array[i].Normalize();
				}
				for (int j = 0; j < Count; j++)
				{
					int num = PreviousIndex(j);
					double a = Point2D.Cross(array[num], array[j]);
					a = MathUtil.Clamp(a, -1.0, 1.0);
					float value = (float)Math.Asin(a);
					if ((double)Math.Abs(value) <= 1.0 / (90.0 * Math.PI))
					{
						polygonError |= PolygonError.SidesTooCloseToParallel;
						break;
					}
				}
				if (flag)
				{
					WindingOrder = WindingOrderType.Clockwise;
				}
			}
			return polygonError;
		}
		return polygonError | PolygonError.NotEnoughVertices;
	}

	public static string GetErrorString(PolygonError error)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		if (error != PolygonError.None)
		{
			if ((error & PolygonError.NotEnoughVertices) == PolygonError.NotEnoughVertices)
			{
				stringBuilder.AppendFormat("NotEnoughVertices: must have between 3 and {0} vertices.\n", 100000);
			}
			if ((error & PolygonError.NotConvex) == PolygonError.NotConvex)
			{
				stringBuilder.AppendFormat("NotConvex: Polygon is not convex.\n");
			}
			if ((error & PolygonError.NotSimple) == PolygonError.NotSimple)
			{
				stringBuilder.AppendFormat("NotSimple: Polygon is not simple (i.e. it intersects itself).\n");
			}
			if ((error & PolygonError.AreaTooSmall) == PolygonError.AreaTooSmall)
			{
				stringBuilder.AppendFormat("AreaTooSmall: Polygon's area is too small.\n");
			}
			if ((error & PolygonError.SidesTooCloseToParallel) == PolygonError.SidesTooCloseToParallel)
			{
				stringBuilder.AppendFormat("SidesTooCloseToParallel: Polygon's sides are too close to parallel.\n");
			}
			if ((error & PolygonError.TooThin) == PolygonError.TooThin)
			{
				stringBuilder.AppendFormat("TooThin: Polygon is too thin or core shape generation would move edge past centroid.\n");
			}
			if ((error & PolygonError.Degenerate) == PolygonError.Degenerate)
			{
				stringBuilder.AppendFormat("Degenerate: Polygon is degenerate (contains collinear points or duplicate coincident points).\n");
			}
			if ((error & PolygonError.Unknown) == PolygonError.Unknown)
			{
				stringBuilder.AppendFormat("Unknown: Unknown Polygon error!.\n");
			}
		}
		else
		{
			stringBuilder.AppendFormat("No errors.\n");
		}
		return stringBuilder.ToString();
	}

	public void RemoveDuplicateNeighborPoints()
	{
		int num = Count;
		int num2 = num - 1;
		int num3 = 0;
		while (num > 1 && num3 < num)
		{
			if (!MPoints[num2].Equals(MPoints[num3]))
			{
				num2 = NextIndex(num2);
				num3++;
				continue;
			}
			int index = Math.Max(num2, num3);
			MPoints.RemoveAt(index);
			num--;
			if (num2 >= num)
			{
				num2 = num - 1;
			}
		}
	}

	public void Simplify(double bias = 0.0)
	{
		if (Count < 3)
		{
			return;
		}
		int num = 0;
		int num2 = Count;
		double num3 = bias * bias;
		while (num < num2 && num2 >= 3)
		{
			int index = PreviousIndex(num);
			int index2 = NextIndex(num);
			Point2D point2D = this[index];
			Point2D point2D2 = this[num];
			Point2D pc = this[index2];
			if (!((point2D - point2D2).MagnitudeSquared() <= num3))
			{
				Orientation orientation = TriangulationUtil.Orient2d(point2D, point2D2, pc);
				if (orientation != Orientation.Collinear)
				{
					num++;
					continue;
				}
				RemoveAt(num);
				num2--;
			}
			else
			{
				RemoveAt(num);
				num2--;
			}
		}
	}

	public void MergeParallelEdges(double tolerance)
	{
		if (Count <= 3)
		{
			return;
		}
		bool[] array = new bool[Count];
		int num = Count;
		for (int i = 0; i < Count; i++)
		{
			int index = ((i != 0) ? (i - 1) : (Count - 1));
			int index2 = i;
			int index3 = ((i != Count - 1) ? (i + 1) : 0);
			double num2 = this[index2].X - this[index].X;
			double num3 = this[index2].Y - this[index].Y;
			double num4 = this[index3].Y - this[index2].X;
			double num5 = this[index3].Y - this[index2].Y;
			double num6 = Math.Sqrt(num2 * num2 + num3 * num3);
			double num7 = Math.Sqrt(num4 * num4 + num5 * num5);
			if ((num6 <= 0.0 || num7 <= 0.0) && num > 3)
			{
				array[i] = true;
				num--;
			}
			num2 /= num6;
			num3 /= num6;
			num4 /= num7;
			num5 /= num7;
			double value = num2 * num5 - num4 * num3;
			double num8 = num2 * num4 + num3 * num5;
			if (Math.Abs(value) >= tolerance || !(num8 > 0.0) || num <= 3)
			{
				array[i] = false;
				continue;
			}
			array[i] = true;
			num--;
		}
		if (num == Count || num == 0)
		{
			return;
		}
		int num9 = 0;
		Point2DList point2DList = new Point2DList(this);
		Clear();
		for (int j = 0; j < point2DList.Count; j++)
		{
			if (!array[j] && num != 0 && num9 != num)
			{
				if (num9 >= num)
				{
					throw new Exception("Point2DList::MergeParallelEdges - currIndex[ " + num9 + "] >= newNVertices[" + num + "]");
				}
				MPoints.Add(point2DList[j]);
				BoundingBox = BoundingBox.AddPoint(point2DList[j]);
				num9++;
			}
		}
		windingOrderType_0 = CalculateWindingOrder();
		Epsilon = CalculateEpsilon();
	}

	public void ProjectToAxis(Point2D axis, out double min, out double max)
	{
		max = (min = Point2D.Dot(axis, this[0]));
		for (int i = 0; i < Count; i++)
		{
			double num = Point2D.Dot(this[i], axis);
			if (!(num < min))
			{
				if (num > max)
				{
					max = num;
				}
			}
			else
			{
				min = num;
			}
		}
	}
}
