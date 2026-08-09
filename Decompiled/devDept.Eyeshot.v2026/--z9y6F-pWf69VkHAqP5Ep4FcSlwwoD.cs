using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dz9y6F_0024pWf69VkHAqP5Ep4FcSlwwoD
{
	private sealed class _0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D
	{
		public Line _0023_003DzQ9zpGF0_003D;

		internal int _0023_003Dz7PfKBvG5SA9XsiKTCg_003D_003D(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D)
		{
			return (_0023_003DzFj_0024IqDQ_003D.AsVector - _0023_003DzQ9zpGF0_003D.StartPoint.AsVector).LengthSquared.CompareTo((_0023_003DzjdeMMkk_003D.AsVector - _0023_003DzQ9zpGF0_003D.StartPoint.AsVector).LengthSquared);
		}
	}

	private sealed class _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D
	{
		public Segment2D _0023_003DzSwfghCo_003D;

		internal int _0023_003DzVfdvZuTrLaSbKqOVAaNmTX8_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003DzjdeMMkk_003D)
		{
			return (_0023_003DzFj_0024IqDQ_003D.AsVector - _0023_003DzSwfghCo_003D.P0.AsVector).LengthSquared.CompareTo((_0023_003DzjdeMMkk_003D.AsVector - _0023_003DzSwfghCo_003D.P0.AsVector).LengthSquared);
		}
	}

	private sealed class _0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D
	{
		public Segment2D _0023_003DzSwfghCo_003D;

		internal int _0023_003DzmKbgj0VnI7viwgiJrZlLRrdDASWw7pIxuw_003D_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003DzjdeMMkk_003D)
		{
			return (_0023_003DzFj_0024IqDQ_003D.AsVector - _0023_003DzSwfghCo_003D.P0.AsVector).LengthSquared.CompareTo((_0023_003DzjdeMMkk_003D.AsVector - _0023_003DzSwfghCo_003D.P0.AsVector).LengthSquared);
		}
	}

	public static Tuple<Segment2D, bool>[] _0023_003Dz_0024VUbMK2T3M0s(Segment2D _0023_003DzSwfghCo_003D, PolyRegion2D _0023_003Dz8NCSYr_tA_0024I_0024, Comparison<Point2D> _0023_003DzZw5LunE_003D)
	{
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2 = new _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D();
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzSwfghCo_003D = _0023_003DzSwfghCo_003D;
		List<Tuple<Segment2D, bool>> list = new List<Tuple<Segment2D, bool>>();
		bool flag = false;
		List<Point2D> list2 = new List<Point2D>();
		foreach (Polygon2D contour in _0023_003Dz8NCSYr_tA_0024I_0024.ContourList)
		{
			list2.AddRange(contour.IntersecWithCrossAndT(_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzSwfghCo_003D));
		}
		list2.Add(_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzSwfghCo_003D.P0);
		list2.Add(_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzSwfghCo_003D.P1);
		if (list2.Count > 2)
		{
			if (_0023_003DzZw5LunE_003D == null)
			{
				list2.Sort(_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D2._0023_003DzVfdvZuTrLaSbKqOVAaNmTX8_003D);
			}
			else
			{
				list2.Sort(_0023_003DzZw5LunE_003D);
			}
		}
		Point2D point2D = list2[0];
		for (int i = 0; i < list2.Count - 1; i++)
		{
			if (!list2[i].Equals(list2[i + 1]))
			{
				bool flag2 = _0023_003Dz8NCSYr_tA_0024I_0024.IsPointInside((list2[i + 1] + list2[i]) / 2.0);
				if (i > 0 && flag != flag2)
				{
					list.Add(new Tuple<Segment2D, bool>(new Segment2D(point2D, list2[i]), flag));
					point2D = list2[i];
				}
				flag = flag2;
			}
		}
		if (point2D != null)
		{
			list.Add(new Tuple<Segment2D, bool>(new Segment2D(point2D, list2[list2.Count - 1]), flag));
		}
		return list.ToArray();
	}

	internal static Segment2D[] _0023_003DzrBa6h4XZWRQzuJ57ZYmUNw0_003D(Segment2D _0023_003DzSwfghCo_003D, IList<Polygon2D> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		_0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D _0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D2 = new _0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D();
		_0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D2._0023_003DzSwfghCo_003D = _0023_003DzSwfghCo_003D;
		List<Point2D> list = new List<Point2D>();
		foreach (Polygon2D item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			list.AddRange(item.IntersecWithCrossAndT(_0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D2._0023_003DzSwfghCo_003D));
		}
		if (list.Count > 1)
		{
			list.Sort(_0023_003Dzt_aMnATwWEk1aT9UuA_003D_003D2._0023_003DzmKbgj0VnI7viwgiJrZlLRrdDASWw7pIxuw_003D_003D);
		}
		List<Segment2D> list2 = new List<Segment2D>(list.Count / 2);
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (_0023_003DzFAlzEn_00246knfy(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, (list[i] + list[i + 1]) / 2.0))
			{
				list2.Add(new Segment2D(list[i], list[i + 1]));
			}
		}
		return list2.ToArray();
	}

	private static bool _0023_003DzFAlzEn_00246knfy(IList<Polygon2D> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Point2D _0023_003DzB68dg9Q_003D)
	{
		int num = 0;
		foreach (Polygon2D item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			pointStatusType pointStatusType2 = item.IsPointInside(_0023_003DzB68dg9Q_003D, item.Size.Diagonal);
			if (pointStatusType2 != pointStatusType.Outside && pointStatusType2 != pointStatusType.Undetermined)
			{
				num++;
			}
		}
		return num % 2 == 1;
	}

	public static Point3D[][] _0023_003DzOYxPx6FqLIHX(Point3D[] _0023_003DzdEvMFOw_003D, Region _0023_003Dz_SqBXz8_003D)
	{
		List<Point3D> list = new List<Point3D>();
		List<Point3D[]> list2 = new List<Point3D[]>();
		Point3D point3D = null;
		bool flag = false;
		for (int i = 0; i < _0023_003DzdEvMFOw_003D.Length - 1; i++)
		{
			_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D _0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2 = new _0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D();
			_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2._0023_003DzQ9zpGF0_003D = new Line(_0023_003DzdEvMFOw_003D[i].X, _0023_003DzdEvMFOw_003D[i].Y, _0023_003DzdEvMFOw_003D[i + 1].X, _0023_003DzdEvMFOw_003D[i + 1].Y);
			List<Point3D> list3 = new List<Point3D>();
			foreach (ICurve contour in _0023_003Dz_SqBXz8_003D.ContourList)
			{
				list3.AddRange(_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2._0023_003DzQ9zpGF0_003D.IntersectWith(contour));
			}
			list3.Add(_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2._0023_003DzQ9zpGF0_003D.StartPoint);
			list3.Add(_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2._0023_003DzQ9zpGF0_003D.EndPoint);
			if (list3.Count > 2)
			{
				list3.Sort(_0023_003Dz5TCmeWe6OB2sbMvDnA_003D_003D2._0023_003Dz7PfKBvG5SA9XsiKTCg_003D_003D);
			}
			for (int j = 0; j < list3.Count - 1; j++)
			{
				if (!list3[j].Equals(list3[j + 1]))
				{
					bool num = _0023_003Dz_SqBXz8_003D.IsPointInside(list3[j] + (list3[j + 1] - list3[j]) / 2.0);
					if (num)
					{
						list.Add(list3[j]);
						point3D = list3[j + 1];
					}
					else if (flag)
					{
						list.Add(list3[j]);
						list2.Add(list.ToArray());
						list.Clear();
					}
					flag = num;
				}
			}
		}
		if (list.Count > 0 && point3D != null)
		{
			if (list2.Count > 0 && point3D.Equals(list2[0][0]))
			{
				list2[0] = list.Concat(list2[0]).ToArray();
			}
			else
			{
				list.Add(point3D);
				list2.Add(list.ToArray());
			}
		}
		return list2.ToArray();
	}
}
