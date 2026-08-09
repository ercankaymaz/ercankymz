using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Sets;

public class PointSet : Point2DList, IEnumerable, IEnumerable<TriangulationPoint>, IList<TriangulationPoint>, ITriangulatable, ICollection<TriangulationPoint>
{
	private readonly Dictionary<uint, TriangulationPoint> dictionary_0 = new Dictionary<uint, TriangulationPoint>();

	[CompilerGenerated]
	private IList<DelaunayTriangle> ilist_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private float float_0;

	private double double_1 = 3.0;

	public IList<DelaunayTriangle> Triangles
	{
		[CompilerGenerated]
		get
		{
			return ilist_0;
		}
		[CompilerGenerated]
		private set
		{
			ilist_0 = value;
		}
	}

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

	public virtual TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

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

	protected PointSet(IEnumerable<TriangulationPoint> bounds)
	{
		foreach (TriangulationPoint bound in bounds)
		{
			Add(bound, -1, constrainToBounds: false);
			base.BoundingBox = base.BoundingBox.AddPoint(bound);
		}
		base.Epsilon = CalculateEpsilon();
		base.WindingOrder = WindingOrderType.Unknown;
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
		Add(p as TriangulationPoint, -1, constrainToBounds: false);
	}

	public virtual void Add(TriangulationPoint p)
	{
		Add(p, -1, constrainToBounds: false);
	}

	protected override void Add(Point2D p, int idx, bool constrainToBounds)
	{
		Add(p as TriangulationPoint, idx, constrainToBounds);
	}

	protected bool Add(TriangulationPoint p, int idx, bool constrainToBounds)
	{
		if (p != null)
		{
			if (constrainToBounds)
			{
				ConstrainPointToBounds(p);
			}
			if (!dictionary_0.ContainsKey(p.VertexCode))
			{
				dictionary_0.Add(p.VertexCode, p);
				if (idx >= 0)
				{
					MPoints.Insert(idx, p);
				}
				else
				{
					MPoints.Add(p);
				}
				return true;
			}
			return true;
		}
		return false;
	}

	protected override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
	{
		if (iter != null)
		{
			iter.Reset();
			while (iter.MoveNext())
			{
				Add(iter.Current);
			}
		}
	}

	public virtual bool AddRange(IEnumerable<TriangulationPoint> points)
	{
		bool flag = true;
		foreach (TriangulationPoint point in points)
		{
			flag = Add(point, -1, constrainToBounds: false) && flag;
		}
		return flag;
	}

	protected bool TryGetPoint(double x, double y, out TriangulationPoint p)
	{
		uint key = TriangulationPoint.CreateVertexCode(x, y, Precision);
		if (!dictionary_0.TryGetValue(key, out p))
		{
			return false;
		}
		return true;
	}

	public void Insert(int idx, TriangulationPoint item)
	{
		MPoints.Insert(idx, item);
	}

	public override bool Remove(Point2D p)
	{
		return MPoints.Remove(p);
	}

	public bool Remove(TriangulationPoint p)
	{
		return MPoints.Remove(p);
	}

	public override void RemoveAt(int idx)
	{
		if (idx >= 0 && idx < base.Count)
		{
			MPoints.RemoveAt(idx);
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

	protected bool ConstrainPointToBounds(Point2D p)
	{
		double x = p.X;
		double y = p.Y;
		p.X = Math.Max(MinX, p.X);
		p.X = Math.Min(MaxX, p.X);
		p.Y = Math.Max(MinY, p.Y);
		p.Y = Math.Min(MaxY, p.Y);
		return p.X != x || p.Y != y;
	}

	protected internal bool ConstrainPointToBounds(TriangulationPoint p)
	{
		double x = p.X;
		double y = p.Y;
		p.X = Math.Max(MinX, p.X);
		p.X = Math.Min(MaxX, p.X);
		p.Y = Math.Max(MinY, p.Y);
		p.Y = Math.Min(MaxY, p.Y);
		return p.X != x || p.Y != y;
	}

	public virtual void AddTriangle(DelaunayTriangle t)
	{
		Triangles.Add(t);
	}

	public void AddTriangles(IEnumerable<DelaunayTriangle> list)
	{
		foreach (DelaunayTriangle item in list)
		{
			AddTriangle(item);
		}
	}

	public void ClearTriangles()
	{
		Triangles.Clear();
	}

	protected virtual bool Initialize()
	{
		return true;
	}

	public virtual void Prepare(TriangulationContext tcx)
	{
		if (Triangles != null)
		{
			Triangles.Clear();
		}
		else
		{
			Triangles = new List<DelaunayTriangle>(base.Count);
		}
		tcx.Points.AddRange(this);
	}
}
