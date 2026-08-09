using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Sets;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Polygon;

public class Contour : Point2DList, IEnumerable, IEnumerable<TriangulationPoint>, IList<TriangulationPoint>, ITriangulatable, ICollection<TriangulationPoint>
{
	[CompilerGenerated]
	private sealed class Class128
	{
		public bool bool_0;

		internal int method_0(Contour contour_0)
		{
			return contour_0.GetNumHoles(!bool_0);
		}
	}

	[CompilerGenerated]
	internal sealed class Class129
	{
		public Point2D point2D_0;

		internal bool method_0(Contour contour_0)
		{
			return !Class156.smethod_120(point2D_0, contour_0);
		}
	}

	internal readonly List<Contour> list_0 = new List<Contour>();

	internal ITriangulatable parent = null;

	public new TriangulationPoint this[int index]
	{
		get
		{
			return MPoints[index] as TriangulationPoint;
		}
		set
		{
			MPoints[index] = value;
		}
	}

	public IList<DelaunayTriangle> Triangles
	{
		get
		{
			throw new NotImplementedException("PolyHole.Triangles should never get called");
		}
	}

	public TriangulationMode TriangulationMode => parent.TriangulationMode;

	public bool DisplayFlipX
	{
		get
		{
			return parent.DisplayFlipX;
		}
		set
		{
		}
	}

	public bool DisplayFlipY
	{
		get
		{
			return parent.DisplayFlipY;
		}
		set
		{
		}
	}

	public float DisplayRotate
	{
		get
		{
			return parent.DisplayRotate;
		}
		set
		{
		}
	}

	public double Precision
	{
		get
		{
			return parent.Precision;
		}
		set
		{
		}
	}

	public double MinX => base.BoundingBox.MinX;

	public double MaxX => base.BoundingBox.MaxX;

	public double MinY => base.BoundingBox.MinY;

	public double MaxY => base.BoundingBox.MaxY;

	public Rect2D Bounds => base.BoundingBox;

	public Contour(ITriangulatable parent)
	{
		this.parent = parent;
	}

	public Contour(ITriangulatable parent, IList<TriangulationPoint> points, WindingOrderType windingOrder)
	{
		this.parent = parent;
		method_5(points, windingOrder);
	}

	IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
	{
		return MPoints.Cast<TriangulationPoint>().GetEnumerator();
	}

	public int IndexOf(TriangulationPoint p)
	{
		return MPoints.IndexOf(p);
	}

	public void Add(TriangulationPoint p)
	{
		Add(p, -1, bCalcWindingOrderAndEpsilon: true);
	}

	protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
	{
		TriangulationPoint triangulationPoint = ((p is TriangulationPoint) ? (p as TriangulationPoint) : new TriangulationPoint(p.X, p.Y));
		if (idx >= 0)
		{
			MPoints.Insert(idx, triangulationPoint);
		}
		else
		{
			MPoints.Add(triangulationPoint);
		}
		base.BoundingBox = base.BoundingBox.AddPoint(triangulationPoint);
		if (bCalcWindingOrderAndEpsilon)
		{
			if (base.WindingOrder == WindingOrderType.Unknown)
			{
				base.WindingOrder = CalculateWindingOrder();
			}
			base.Epsilon = CalculateEpsilon();
		}
	}

	protected override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
	{
		if (iter == null)
		{
			return;
		}
		if (base.WindingOrder == WindingOrderType.Unknown && base.Count == 0)
		{
			base.WindingOrder = windingOrder;
		}
		bool flag = base.WindingOrder != WindingOrderType.Unknown && windingOrder != WindingOrderType.Unknown && base.WindingOrder != windingOrder;
		bool flag2 = true;
		int count = MPoints.Count;
		iter.Reset();
		while (iter.MoveNext())
		{
			TriangulationPoint item = ((iter.Current is TriangulationPoint) ? (iter.Current as TriangulationPoint) : new TriangulationPoint(iter.Current.X, iter.Current.Y));
			if (flag2)
			{
				if (!flag)
				{
					MPoints.Add(item);
				}
				else
				{
					MPoints.Insert(count, item);
				}
			}
			else
			{
				flag2 = true;
				MPoints.Add(item);
			}
			base.BoundingBox = base.BoundingBox.AddPoint(iter.Current);
		}
		if (base.WindingOrder == WindingOrderType.Unknown && windingOrder == WindingOrderType.Unknown)
		{
			base.WindingOrder = CalculateWindingOrder();
		}
		base.Epsilon = CalculateEpsilon();
	}

	private void method_5(IList<TriangulationPoint> ilist_0, WindingOrderType windingOrderType_1)
	{
		if (ilist_0 == null || ilist_0.Count < 1)
		{
			return;
		}
		if (base.WindingOrder == WindingOrderType.Unknown && base.Count == 0)
		{
			base.WindingOrder = windingOrderType_1;
		}
		int count = ilist_0.Count;
		bool flag = base.WindingOrder != WindingOrderType.Unknown && windingOrderType_1 != WindingOrderType.Unknown && base.WindingOrder != windingOrderType_1;
		for (int i = 0; i < count; i++)
		{
			int index = i;
			if (flag)
			{
				index = ilist_0.Count - i - 1;
			}
			Add(ilist_0[index], -1, bCalcWindingOrderAndEpsilon: false);
		}
		if (base.WindingOrder == WindingOrderType.Unknown)
		{
			base.WindingOrder = CalculateWindingOrder();
		}
		base.Epsilon = CalculateEpsilon();
	}

	public void Insert(int idx, TriangulationPoint p)
	{
		Add(p, idx, bCalcWindingOrderAndEpsilon: true);
	}

	public bool Remove(TriangulationPoint p)
	{
		return Remove((Point2D)p);
	}

	public bool Contains(TriangulationPoint p)
	{
		return MPoints.Contains(p);
	}

	public void CopyTo(TriangulationPoint[] array, int arrayIndex)
	{
		int num = Math.Min(base.Count, array.Length - arrayIndex);
		for (int i = 0; i < num; i++)
		{
			array[arrayIndex + i] = MPoints[i] as TriangulationPoint;
		}
	}

	public int GetNumHoles(bool parentIsHole)
	{
		return ((!parentIsHole) ? 1 : 0) + list_0.Sum((Contour contour_0) => contour_0.GetNumHoles(!parentIsHole));
	}

	public void GetActualHoles(bool parentIsHole, ref List<Contour> holes)
	{
		if (parentIsHole)
		{
			holes.Add(this);
		}
		foreach (Contour item in list_0)
		{
			item.GetActualHoles(!parentIsHole, ref holes);
		}
	}

	public List<Contour>.Enumerator GetHoleEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void InitializeHoles(ConstrainedPointSet cps)
	{
		InitializeHoles(list_0, this, cps);
		foreach (Contour item in list_0)
		{
			item.InitializeHoles(cps);
		}
	}

	public static void InitializeHoles(List<Contour> holes, ITriangulatable parent, ConstrainedPointSet cps)
	{
		int num = holes.Count;
		int i;
		for (i = 0; i < num; i++)
		{
			int num2 = i + 1;
			while (num2 < num)
			{
				if (!PolygonUtil.PolygonsAreSame2D(holes[i], holes[num2]))
				{
					num2++;
					continue;
				}
				holes.RemoveAt(num2);
				num--;
			}
		}
		i = 0;
		while (i < num)
		{
			bool flag = true;
			int num3 = i + 1;
			while (num3 < num)
			{
				if (!PolygonUtil.PolygonContainsPolygon(holes[i], holes[i].Bounds, holes[num3], holes[num3].Bounds, runIntersectionTest: false))
				{
					if (PolygonUtil.PolygonContainsPolygon(holes[num3], holes[num3].Bounds, holes[i], holes[i].Bounds, runIntersectionTest: false))
					{
						Class156.smethod_183(holes[num3], holes[i]);
						holes.RemoveAt(i);
						num--;
						flag = false;
						break;
					}
					if (!PolygonUtil.PolygonsIntersect2D(holes[i], holes[i].Bounds, holes[num3], holes[num3].Bounds))
					{
						num3++;
						continue;
					}
					PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
					if (!polygonOperationContext.Init(PolygonUtil.PolyOperation.Union | PolygonUtil.PolyOperation.Intersect, holes[i], holes[num3]))
					{
						if (polygonOperationContext.Error != PolygonUtil.PolyUnionError.Poly1InsidePoly2)
						{
							throw new Exception("PolygonOperationContext.Init had an error during initialization");
						}
						Class156.smethod_183(holes[num3], holes[i]);
						holes.RemoveAt(i);
						num--;
						flag = false;
						break;
					}
					if (PolygonUtil.PolygonOperation(polygonOperationContext) != PolygonUtil.PolyUnionError.None)
					{
						throw new Exception("PolygonOperation had an error!");
					}
					Point2DList union = polygonOperationContext.Union;
					Point2DList intersect = polygonOperationContext.Intersect;
					Contour contour = new Contour(parent);
					contour.AddRange(union);
					contour.WindingOrder = WindingOrderType.AntiClockwise;
					int num4 = Class156.smethod_130(holes[i]);
					for (int j = 0; j < num4; j++)
					{
						Class156.smethod_183(contour, Class156.smethod_127(j, holes[i]));
					}
					num4 = Class156.smethod_130(holes[num3]);
					for (int k = 0; k < num4; k++)
					{
						Class156.smethod_183(contour, Class156.smethod_127(k, holes[num3]));
					}
					Contour contour2 = new Contour(contour);
					contour2.AddRange(intersect);
					contour2.WindingOrder = WindingOrderType.AntiClockwise;
					Class156.smethod_183(contour, contour2);
					holes[i] = contour;
					holes.RemoveAt(num3);
					num--;
					num3 = i + 1;
				}
				else
				{
					Class156.smethod_183(holes[i], holes[num3]);
					holes.RemoveAt(num3);
					num--;
				}
			}
			if (flag)
			{
				i++;
			}
		}
		num = holes.Count;
		for (i = 0; i < num; i++)
		{
			int count = holes[i].Count;
			for (int l = 0; l < count; l++)
			{
				int index = holes[i].NextIndex(l);
				uint constraintCode = TriangulationConstraint.CalculateContraintCode(holes[i][l], holes[i][index]);
				if (!cps.TryGetConstraint(constraintCode, out var tc))
				{
					tc = new TriangulationConstraint(holes[i][l], holes[i][index]);
					cps.AddConstraint(tc);
				}
				if (holes[i][l].VertexCode != tc.P.VertexCode)
				{
					if (holes[i][index].VertexCode == tc.P.VertexCode)
					{
						holes[i][index] = tc.P;
					}
				}
				else
				{
					holes[i][l] = tc.P;
				}
				if (holes[i][l].VertexCode != tc.Q.VertexCode)
				{
					if (holes[i][index].VertexCode == tc.Q.VertexCode)
					{
						holes[i][index] = tc.Q;
					}
				}
				else
				{
					holes[i][l] = tc.Q;
				}
			}
		}
	}

	public void Prepare(TriangulationContext tcx)
	{
		throw new NotImplementedException("PolyHole.Prepare should never get called");
	}

	public void AddTriangle(DelaunayTriangle t)
	{
		throw new NotImplementedException("PolyHole.AddTriangle should never get called");
	}

	public void AddTriangles(IEnumerable<DelaunayTriangle> list)
	{
		throw new NotImplementedException("PolyHole.AddTriangles should never get called");
	}

	public void ClearTriangles()
	{
		throw new NotImplementedException("PolyHole.ClearTriangles should never get called");
	}

	public Point2D FindPointInContour()
	{
		if (base.Count >= 3)
		{
			Point2D centroid = GetCentroid();
			if (!Class156.smethod_120(centroid, this))
			{
				Random random = new Random();
				do
				{
					centroid.X = random.NextDouble() * (MaxX - MinX) + MinX;
					centroid.Y = random.NextDouble() * (MaxY - MinY) + MinY;
				}
				while (!Class156.smethod_120(centroid, this));
				return centroid;
			}
			return centroid;
		}
		return null;
	}
}
