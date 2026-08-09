using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Polygon;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Sets;

public class ConstrainedPointSet : PointSet
{
	internal readonly Dictionary<uint, TriangulationConstraint> dictionary_1 = new Dictionary<uint, TriangulationConstraint>();

	private readonly List<Contour> list_0 = new List<Contour>();

	public override TriangulationMode TriangulationMode => TriangulationMode.Constrained;

	public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds)
		: base(bounds)
	{
		method_6();
	}

	public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds, IEnumerable<TriangulationConstraint> constraints)
		: base(bounds)
	{
		method_6();
		Class156.smethod_200(this, constraints);
	}

	public ConstrainedPointSet(IList<TriangulationPoint> bounds, ICollection<int> indices)
		: base(bounds)
	{
		method_6();
		List<TriangulationConstraint> list = new List<TriangulationConstraint>();
		for (int i = 0; i < indices.Count; i += 2)
		{
			TriangulationConstraint item = new TriangulationConstraint(bounds[i], bounds[i + 1]);
			list.Add(item);
		}
		Class156.smethod_200(this, (IEnumerable<TriangulationConstraint>)list);
	}

	private void method_6()
	{
		if (!TryGetPoint(base.MinX, base.MinY, out var p))
		{
			p = new TriangulationPoint(base.MinX, base.MinY);
			Add(p);
		}
		if (!TryGetPoint(base.MaxX, base.MinY, out var p2))
		{
			p2 = new TriangulationPoint(base.MaxX, base.MinY);
			Add(p2);
		}
		if (!TryGetPoint(base.MaxX, base.MaxY, out var p3))
		{
			p3 = new TriangulationPoint(base.MaxX, base.MaxY);
			Add(p3);
		}
		if (!TryGetPoint(base.MinX, base.MaxY, out var p4))
		{
			p4 = new TriangulationPoint(base.MinX, base.MaxY);
			Add(p4);
		}
		TriangulationConstraint tc = new TriangulationConstraint(p, p2);
		AddConstraint(tc);
		TriangulationConstraint tc2 = new TriangulationConstraint(p2, p3);
		AddConstraint(tc2);
		TriangulationConstraint tc3 = new TriangulationConstraint(p3, p4);
		AddConstraint(tc3);
		TriangulationConstraint tc4 = new TriangulationConstraint(p4, p);
		AddConstraint(tc4);
	}

	public override void Add(Point2D p)
	{
		Add(p as TriangulationPoint, -1, constrainToBounds: true);
	}

	public override void Add(TriangulationPoint p)
	{
		Add(p, -1, constrainToBounds: true);
	}

	public override bool AddRange(IEnumerable<TriangulationPoint> points)
	{
		bool flag = true;
		foreach (TriangulationPoint point in points)
		{
			flag = Add(point, -1, constrainToBounds: true) && flag;
		}
		return flag;
	}

	public bool AddHole(List<TriangulationPoint> points)
	{
		if (points != null)
		{
			List<Contour> list = new List<Contour>();
			int num = 0;
			Contour item = new Contour(this, points, WindingOrderType.Unknown);
			list.Add(item);
			if (MPoints.Count > 1)
			{
				int count = list[num].Count;
				for (int i = 0; i < count; i++)
				{
					ConstrainPointToBounds(list[num][i]);
				}
			}
			while (num < list.Count)
			{
				list[num].RemoveDuplicateNeighborPoints();
				list[num].WindingOrder = WindingOrderType.AntiClockwise;
				bool flag = true;
				PolygonError polygonError = list[num].CheckPolygon();
				while (flag && polygonError != PolygonError.None)
				{
					if ((polygonError & PolygonError.NotEnoughVertices) != PolygonError.NotEnoughVertices)
					{
						if ((polygonError & PolygonError.NotSimple) != PolygonError.NotSimple)
						{
							if ((polygonError & PolygonError.Degenerate) != PolygonError.Degenerate)
							{
								if ((polygonError & PolygonError.AreaTooSmall) == PolygonError.AreaTooSmall || (polygonError & PolygonError.SidesTooCloseToParallel) == PolygonError.SidesTooCloseToParallel || (polygonError & PolygonError.TooThin) == PolygonError.TooThin || (polygonError & PolygonError.Unknown) == PolygonError.Unknown)
								{
									flag = false;
								}
							}
							else
							{
								list[num].Simplify(base.Epsilon);
								polygonError = list[num].CheckPolygon();
							}
							continue;
						}
						IEnumerable<Point2DList> enumerable = PolygonUtil.SplitComplexPolygon(list[num], list[num].Epsilon);
						list.RemoveAt(num);
						foreach (Point2DList item3 in enumerable)
						{
							Contour contour = new Contour(this);
							contour.AddRange(item3);
							list.Add(contour);
						}
						polygonError = list[num].CheckPolygon();
					}
					else
					{
						flag = false;
					}
				}
				if (flag || list[num].Count == 2)
				{
					num++;
				}
				else
				{
					list.RemoveAt(num);
				}
			}
			bool result = true;
			num = 0;
			while (num < list.Count)
			{
				int count2 = list[num].Count;
				if (count2 >= 2)
				{
					if (count2 != 2)
					{
						Contour item2 = new Contour(this, list[num], WindingOrderType.Unknown)
						{
							WindingOrder = WindingOrderType.AntiClockwise
						};
						list_0.Add(item2);
					}
					else
					{
						uint key = TriangulationConstraint.CalculateContraintCode(list[num][0], list[num][1]);
						if (!dictionary_1.TryGetValue(key, out var value))
						{
							value = new TriangulationConstraint(list[num][0], list[num][1]);
							AddConstraint(value);
						}
					}
					num++;
				}
				else
				{
					num++;
					result = false;
				}
			}
			return result;
		}
		return false;
	}

	public void AddConstraint(TriangulationConstraint tc)
	{
		if (tc != null && tc.P != null && tc.Q != null && !dictionary_1.ContainsKey(tc.ConstraintCode))
		{
			if (!TryGetPoint(tc.P.X, tc.P.Y, out var p))
			{
				Add(tc.P);
			}
			else
			{
				tc.P = p;
			}
			if (!TryGetPoint(tc.Q.X, tc.Q.Y, out p))
			{
				Add(tc.Q);
			}
			else
			{
				tc.Q = p;
			}
			dictionary_1.Add(tc.ConstraintCode, tc);
		}
	}

	public bool TryGetConstraint(uint constraintCode, out TriangulationConstraint tc)
	{
		return dictionary_1.TryGetValue(constraintCode, out tc);
	}

	public int GetNumConstraints()
	{
		return dictionary_1.Count;
	}

	public Dictionary<uint, TriangulationConstraint>.Enumerator GetConstraintEnumerator()
	{
		return dictionary_1.GetEnumerator();
	}

	public int GetNumHoles()
	{
		return list_0.Sum((Contour contour_0) => contour_0.GetNumHoles(parentIsHole: false));
	}

	public Contour GetHole(int idx)
	{
		if (idx >= 0 && idx < list_0.Count)
		{
			return list_0[idx];
		}
		return null;
	}

	public int GetActualHoles(out List<Contour> holes)
	{
		holes = new List<Contour>();
		foreach (Contour item in list_0)
		{
			item.GetActualHoles(parentIsHole: false, ref holes);
		}
		return holes.Count;
	}

	private void method_7()
	{
		Contour.InitializeHoles(list_0, this, this);
		foreach (Contour item in list_0)
		{
			item.InitializeHoles(this);
		}
	}

	protected override bool Initialize()
	{
		method_7();
		return base.Initialize();
	}

	public override void Prepare(TriangulationContext tcx)
	{
		if (Initialize())
		{
			base.Prepare(tcx);
			Dictionary<uint, TriangulationConstraint>.Enumerator enumerator = dictionary_1.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TriangulationConstraint value = enumerator.Current.Value;
				tcx.NewConstraint(value.P, value.Q);
			}
		}
	}

	public override void AddTriangle(DelaunayTriangle t)
	{
		base.Triangles.Add(t);
	}
}
