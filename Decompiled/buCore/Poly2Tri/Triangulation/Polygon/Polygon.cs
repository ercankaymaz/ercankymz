using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon;

public class Polygon : Point2DList, IEnumerable, IEnumerable<TriangulationPoint>, IList<TriangulationPoint>, ITriangulatable, ICollection<TriangulationPoint>
{
	private readonly Dictionary<uint, TriangulationPoint> dictionary_0 = new Dictionary<uint, TriangulationPoint>();

	private List<DelaunayTriangle> list_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private float float_0;

	private double double_1 = 3.0;

	[CompilerGenerated]
	private List<Polygon> list_1;

	private PolygonPoint polygonPoint_0;

	public IList<TriangulationPoint> Points => this;

	public IList<DelaunayTriangle> Triangles => list_0;

	public TriangulationMode TriangulationMode => TriangulationMode.Polygon;

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool DisplayFlipX
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool DisplayFlipY
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public float DisplayRotate
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public double Precision
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double MinX => base.BoundingBox.MinX;

	public double MaxX => base.BoundingBox.MaxX;

	public double MinY => base.BoundingBox.MinY;

	public double MaxY => base.BoundingBox.MaxY;

	public Rect2D Bounds => base.BoundingBox;

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

	[SpecialName]
	[CompilerGenerated]
	private List<Polygon> method_5()
	{
		return list_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_6(List<Polygon> list_2)
	{
		list_1 = list_2;
	}

	private Polygon(IList<PolygonPoint> ilist_0)
	{
		if (ilist_0.Count < 3)
		{
			throw new ArgumentException("List has fewer than 3 points", "points");
		}
		method_7(ilist_0, WindingOrderType.Unknown);
	}

	public Polygon(IEnumerable<PolygonPoint> points)
		: this((points as IList<PolygonPoint>) ?? points.ToArray())
	{
	}

	public Polygon(params PolygonPoint[] points)
		: this((IList<PolygonPoint>)points)
	{
	}

	IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
	{
		return MPoints.Cast<TriangulationPoint>().GetEnumerator();
	}

	public int IndexOf(TriangulationPoint p)
	{
		return MPoints.IndexOf(p);
	}

	public override void Add(Point2D p)
	{
		Add(p, -1, bCalcWindingOrderAndEpsilon: true);
	}

	public void Add(TriangulationPoint p)
	{
		Add(p, -1, bCalcWindingOrderAndEpsilon: true);
	}

	public void Add(PolygonPoint p)
	{
		Add(p, -1, bCalcWindingOrderAndEpsilon: true);
	}

	protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
	{
		if (!(p is TriangulationPoint triangulationPoint) || dictionary_0.ContainsKey(triangulationPoint.VertexCode))
		{
			return;
		}
		dictionary_0.Add(triangulationPoint.VertexCode, triangulationPoint);
		base.Add(p, idx, bCalcWindingOrderAndEpsilon);
		if (p is PolygonPoint polygonPoint)
		{
			polygonPoint.Previous = polygonPoint_0;
			if (polygonPoint_0 != null)
			{
				polygonPoint.Next = polygonPoint_0.Next;
				polygonPoint_0.Next = polygonPoint;
			}
			polygonPoint_0 = polygonPoint;
		}
	}

	private void method_7(IList<PolygonPoint> ilist_0, WindingOrderType windingOrderType_1)
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

	public void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder)
	{
		if (points == null || points.Count < 1)
		{
			return;
		}
		if (base.WindingOrder == WindingOrderType.Unknown && base.Count == 0)
		{
			base.WindingOrder = windingOrder;
		}
		int count = points.Count;
		bool flag = base.WindingOrder != WindingOrderType.Unknown && windingOrder != WindingOrderType.Unknown && base.WindingOrder != windingOrder;
		for (int i = 0; i < count; i++)
		{
			int index = i;
			if (flag)
			{
				index = points.Count - i - 1;
			}
			Add(points[index], -1, bCalcWindingOrderAndEpsilon: false);
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
		return base.Remove(p);
	}

	public void RemovePoint(PolygonPoint p)
	{
		PolygonPoint next = p.Next;
		PolygonPoint previous = p.Previous;
		previous.Next = next;
		next.Previous = previous;
		MPoints.Remove(p);
		base.BoundingBox = default(Rect2D);
		foreach (Point2D mPoint in MPoints)
		{
			base.BoundingBox = base.BoundingBox.AddPoint(mPoint);
		}
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

	public void AddHole(Polygon poly)
	{
		if (method_5() == null)
		{
			method_6(new List<Polygon>());
		}
		method_5().Add(poly);
	}

	public void AddTriangle(DelaunayTriangle t)
	{
		list_0.Add(t);
	}

	public void AddTriangles(IEnumerable<DelaunayTriangle> list)
	{
		list_0.AddRange(list);
	}

	public void ClearTriangles()
	{
		if (list_0 != null)
		{
			list_0.Clear();
		}
	}

	public bool IsPointInside(TriangulationPoint p)
	{
		return PolygonUtil.PointInPolygon2D(this, p);
	}

	public void Prepare(TriangulationContext tcx)
	{
		if (list_0 != null)
		{
			list_0.Clear();
		}
		else
		{
			list_0 = new List<DelaunayTriangle>(MPoints.Count);
		}
		for (int i = 0; i < MPoints.Count - 1; i++)
		{
			tcx.NewConstraint(this[i], this[i + 1]);
		}
		tcx.NewConstraint(this[0], this[base.Count - 1]);
		tcx.Points.AddRange(this);
		if (method_5() == null)
		{
			return;
		}
		foreach (Polygon item in method_5())
		{
			for (int j = 0; j < item.MPoints.Count - 1; j++)
			{
				tcx.NewConstraint(item[j], item[j + 1]);
			}
			tcx.NewConstraint(item[0], item[item.Count - 1]);
			tcx.Points.AddRange(item);
		}
	}
}
