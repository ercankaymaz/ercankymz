using System;
using devDept.Serialization;

namespace devDept.Geometry;

public class Segment3D : ICloneable
{
	public Point3D P0;

	public Point3D P1;

	public bool IsPoint
	{
		get
		{
			if (P0 != P1)
			{
				return false;
			}
			return true;
		}
	}

	public Point3D MidPoint => Point3D.MidPoint(P0, P1);

	public double Length => Point3D.Distance(P0, P1);

	public double LengthSquared
	{
		get
		{
			double num = P1.X - P0.X;
			double num2 = P1.Y - P0.Y;
			double num3 = P1.Z - P0.Z;
			return num * num + num2 * num2 + num3 * num3;
		}
	}

	public Segment3D()
	{
		P0 = new Point3D();
		P1 = new Point3D();
	}

	public Segment3D(Point3D p0, Point3D p1)
	{
		P0 = p0;
		P1 = p1;
	}

	public Segment3D(Point3D p, Vector3D v)
	{
		P0 = p;
		P1 = p + v.AsPoint;
	}

	public Segment3D(Vector3D p1)
	{
		P0 = Point3D.Origin;
		P1 = new Point3D(p1.X, p1.Y, p1.Z);
	}

	public Segment3D(double x0, double y0, double z0, double x1, double y1, double z1)
	{
		P0 = new Point3D(x0, y0, z0);
		P1 = new Point3D(x1, y1, z1);
	}

	protected Segment3D(Segment3D another)
	{
		P0 = (Point3D)another.P0.Clone();
		P1 = (Point3D)another.P1.Clone();
	}

	public virtual object Clone()
	{
		return new Segment3D(this);
	}

	public void ExtendTo(Point3D extPt)
	{
		double num = Project(extPt);
		if (num > 1.0)
		{
			P1 = PointAt(num);
		}
		else if (num < 0.0)
		{
			P0 = PointAt(num);
		}
	}

	public bool IsOnAxis(Vector3D dir, Point3D center)
	{
		Point3D p = center + dir;
		Segment3D seg = new Segment3D(center, p);
		Point3D point3D = P0.ProjectTo(seg);
		Point3D point3D2 = P1.ProjectTo(seg);
		if (point3D.Equals(P0) && point3D2.Equals(P1))
		{
			return true;
		}
		return false;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		if (Math.Abs(plane.DistanceTo(P0)) > tol)
		{
			return false;
		}
		if (Math.Abs(plane.DistanceTo(P1)) > tol)
		{
			return false;
		}
		return true;
	}

	public double Project(Point3D pt)
	{
		Vector3D vector3D = Vector3D.Subtract(P1, P0);
		double lengthSquared = vector3D.LengthSquared;
		Point3D p = P0;
		Point3D p2 = P1;
		double result = 0.0;
		if (lengthSquared > 0.0)
		{
			result = ((!(pt.DistanceTo(p) <= pt.DistanceTo(p2))) ? (1.0 + Vector3D.Dot(pt - p2, vector3D) / lengthSquared) : (Vector3D.Dot(pt - p, vector3D) / lengthSquared));
		}
		return result;
	}

	public double ClosestPointTo(Point3D pt)
	{
		double num = Project(pt);
		if (num < 0.0)
		{
			num = 0.0;
		}
		else if (num > 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public Point3D PointAt(double t)
	{
		double num = 1.0 - t;
		Point3D p = P0;
		Point3D p2 = P1;
		return new Point3D((p.X == p2.X) ? p.X : (num * p.X + t * p2.X), (p.Y == p2.Y) ? p.Y : (num * p.Y + t * p2.Y), (p.Z == p2.Z) ? p.Z : (num * p.Z + t * p2.Z));
	}

	public static implicit operator Vector3D(Segment3D s)
	{
		return new Vector3D(s.P1.X - s.P0.X, s.P1.Y - s.P0.Y, s.P1.Z - s.P0.Z);
	}

	public bool IntersectWith(Plane plane, out Point3D intPoint)
	{
		return _0023_003DzGKZuR_4q838u(plane.Equation, out intPoint, _0023_003Dz0ldn1DXnjGqH: true, _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D: false);
	}

	public bool IntersectWith(Plane plane, bool infinite, out Point3D intPoint)
	{
		return _0023_003DzGKZuR_4q838u(plane.Equation, out intPoint, _0023_003Dz0ldn1DXnjGqH: true, infinite);
	}

	public bool IntersectWith(PlaneEquation pe)
	{
		Point3D _0023_003DzPjm3jErOBm;
		return _0023_003DzGKZuR_4q838u(pe, out _0023_003DzPjm3jErOBm, _0023_003Dz0ldn1DXnjGqH: false, _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D: false);
	}

	public bool IntersectWith(PlaneEquation pe, bool infinite)
	{
		Point3D _0023_003DzPjm3jErOBm;
		return _0023_003DzGKZuR_4q838u(pe, out _0023_003DzPjm3jErOBm, _0023_003Dz0ldn1DXnjGqH: false, infinite);
	}

	public bool IntersectWith(PlaneEquation pe, out Point3D intPoint)
	{
		return _0023_003DzGKZuR_4q838u(pe, out intPoint, _0023_003Dz0ldn1DXnjGqH: true, _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D: false);
	}

	public bool IntersectWith(PlaneEquation pe, bool infinite, out Point3D intPoint)
	{
		return _0023_003DzGKZuR_4q838u(pe, out intPoint, _0023_003Dz0ldn1DXnjGqH: true, infinite);
	}

	internal bool _0023_003DzGKZuR_4q838u(PlaneEquation _0023_003Dz79R_0024VZY_003D, out Point3D _0023_003DzPjm3jErOBm64, bool _0023_003Dz0ldn1DXnjGqH, bool _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D)
	{
		double _0023_003DzheSR8QM7q9ya = Utility._0023_003DzheSR8QM7q9ya;
		_0023_003DzPjm3jErOBm64 = null;
		Vector3D vector3D = Vector3D.Subtract(P1, P0);
		double num = _0023_003Dz79R_0024VZY_003D * vector3D;
		if (Math.Abs(num) < 1E-15)
		{
			return false;
		}
		double num2 = (0.0 - _0023_003Dz79R_0024VZY_003D.ValueAt(P0)) / num;
		if (!_0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D && (num2 < 0.0 - _0023_003DzheSR8QM7q9ya || num2 > 1.0 + _0023_003DzheSR8QM7q9ya))
		{
			return false;
		}
		if (_0023_003Dz0ldn1DXnjGqH)
		{
			_0023_003DzPjm3jErOBm64 = P0 + num2 * vector3D;
		}
		return true;
	}

	public bool IntersectWith(Point3D p1, Point3D p2, Point3D p3, out Point3D intPoint)
	{
		return _0023_003DzGKZuR_4q838u(p1, p2, p3, _0023_003DzPpF_0024Cv0_003D: false, out intPoint);
	}

	private bool _0023_003DzGKZuR_4q838u(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, bool _0023_003DzPpF_0024Cv0_003D, out Point3D _0023_003DzPjm3jErOBm64)
	{
		double _0023_003DzuwH5j5s_003D;
		double _0023_003DzNDQ_E88_003D;
		return _0023_003DzGKZuR_4q838u(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D, _0023_003DzPpF_0024Cv0_003D, 0.0, 1.0, out _0023_003DzuwH5j5s_003D, out _0023_003DzNDQ_E88_003D, out _0023_003DzPjm3jErOBm64);
	}

	public bool IntersectWith(Point3D p1, Point3D p2, Point3D p3, bool ray, out Point3D intPoint, out double s, out double t)
	{
		return _0023_003DzGKZuR_4q838u(p1, p2, p3, ray, 0.0 - Utility._0023_003DzheSR8QM7q9ya, 1.0 + Utility._0023_003DzheSR8QM7q9ya, out s, out t, out intPoint);
	}

	private bool _0023_003DzGKZuR_4q838u(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, bool _0023_003DzPpF_0024Cv0_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, out double _0023_003DzuwH5j5s_003D, out double _0023_003DzNDQ_E88_003D, out Point3D _0023_003DzPjm3jErOBm64)
	{
		_0023_003DzuwH5j5s_003D = (_0023_003DzNDQ_E88_003D = -1.0);
		_0023_003DzPjm3jErOBm64 = null;
		Vector3D vector3D = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		Vector3D vector3D2 = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dzm4eSPQQ_003D);
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		if (vector3D3.LengthSquared < 1E-20)
		{
			return false;
		}
		Vector3D vector3D4 = new Vector3D(P0, P1);
		double num = vector3D3 * vector3D4;
		if (Math.Abs(num) < 1E-15)
		{
			return false;
		}
		Vector3D vector3D5 = new Vector3D(_0023_003DzFj_0024IqDQ_003D, P0);
		double num2 = (0.0 - vector3D3 * vector3D5) / num;
		if (num2 < 0.0)
		{
			return false;
		}
		if (!_0023_003DzPpF_0024Cv0_003D && num2 > 1.0)
		{
			return false;
		}
		_0023_003DzPjm3jErOBm64 = P0 + num2 * vector3D4;
		double num3 = vector3D * vector3D;
		double num4 = vector3D * vector3D2;
		double num5 = vector3D2 * vector3D2;
		Vector3D vector3D6 = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzPjm3jErOBm64);
		double num6 = vector3D6 * vector3D;
		double num7 = vector3D6 * vector3D2;
		double num8 = num4 * num4 - num3 * num5;
		_0023_003DzuwH5j5s_003D = (num4 * num7 - num5 * num6) / num8;
		if (_0023_003DzuwH5j5s_003D < _0023_003DzF7v9r2A_003D || _0023_003DzuwH5j5s_003D > _0023_003Dz8dK2uhU_003D)
		{
			return false;
		}
		_0023_003DzNDQ_E88_003D = (num4 * num6 - num3 * num7) / num8;
		if (_0023_003DzNDQ_E88_003D < _0023_003DzF7v9r2A_003D || _0023_003DzuwH5j5s_003D + _0023_003DzNDQ_E88_003D > _0023_003Dz8dK2uhU_003D)
		{
			return false;
		}
		return true;
	}

	public bool IntersectWith(Point3D boxMin, Point3D boxMax, bool infinite = false)
	{
		Vector3D vector3D = new Vector3D(P0, P1);
		Vector3D vector3D2 = new Vector3D(1.0 / vector3D.X, 1.0 / vector3D.Y, 1.0 / vector3D.Z);
		int[] sign = new int[3]
		{
			(vector3D2.X < 0.0) ? 1 : 0,
			(vector3D2.Y < 0.0) ? 1 : 0,
			(vector3D2.Z < 0.0) ? 1 : 0
		};
		double t;
		double t2;
		if (infinite)
		{
			t = double.NegativeInfinity;
			t2 = double.PositiveInfinity;
		}
		else
		{
			t = Project(P0);
			t2 = Project(P1);
		}
		return IntersectWithInternal(sign, boxMin, boxMax, vector3D2, t, t2);
	}

	public bool IntersectWithInternal(int[] sign, Point3D boxMin, Point3D boxMax, Vector3D inv_direction, double t0, double t1)
	{
		Point3D p = P0;
		Point3D[] array = new Point3D[2] { boxMin, boxMax };
		double num = (array[sign[0]].X - p.X) * inv_direction.X;
		double num2 = (array[1 - sign[0]].X - p.X) * inv_direction.X;
		double num3 = (array[sign[1]].Y - p.Y) * inv_direction.Y;
		double num4 = (array[1 - sign[1]].Y - p.Y) * inv_direction.Y;
		if (num > num4 || num3 > num2)
		{
			return false;
		}
		if (num3 > num)
		{
			num = num3;
		}
		if (num4 < num2)
		{
			num2 = num4;
		}
		double num5 = (array[sign[2]].Z - p.Z) * inv_direction.Z;
		double num6 = (array[1 - sign[2]].Z - p.Z) * inv_direction.Z;
		if (num > num6 || num5 > num2)
		{
			return false;
		}
		if (num5 > num)
		{
			num = num5;
		}
		if (num6 < num2)
		{
			num2 = num6;
		}
		if (num < t1)
		{
			return num2 > t0;
		}
		return false;
	}

	public static bool Intersection(Segment3D segA, Segment3D segB, bool infinite, out Point3D pointOnA, out Point3D pointOnB)
	{
		double paramOnA;
		double paramOnB;
		return Intersection(segA, segB, infinite, out pointOnA, out pointOnB, out paramOnA, out paramOnB);
	}

	public static bool Intersection(Segment3D segA, Segment3D segB, bool infinite, out Point3D pointOnA, out Point3D pointOnB, out double paramOnA, out double paramOnB)
	{
		pointOnA = null;
		pointOnB = null;
		Point3D p = segA.P0;
		Point3D p2 = segA.P1;
		Point3D p3 = segB.P0;
		Point3D p4 = segB.P1;
		int num = 0;
		if (_0023_003DzRN5IJLBL3xPxyWDwZYWvX4Q_003D(p, p3, 0.0, 0.0, ref pointOnA, ref pointOnB, out paramOnA, out paramOnB))
		{
			num++;
		}
		if (_0023_003DzRN5IJLBL3xPxyWDwZYWvX4Q_003D(p2, p3, 1.0, 0.0, ref pointOnA, ref pointOnB, out paramOnA, out paramOnB))
		{
			num++;
		}
		if (_0023_003DzRN5IJLBL3xPxyWDwZYWvX4Q_003D(p, p4, 0.0, 1.0, ref pointOnA, ref pointOnB, out paramOnA, out paramOnB))
		{
			num++;
		}
		if (_0023_003DzRN5IJLBL3xPxyWDwZYWvX4Q_003D(p2, p4, 1.0, 1.0, ref pointOnA, ref pointOnB, out paramOnA, out paramOnB))
		{
			num++;
		}
		switch (num)
		{
		case 1:
		case 3:
		case 4:
			return true;
		case 2:
			return false;
		default:
		{
			double num2 = Vector3D.Dot(Vector3D.Cross(p4 - p3, p - p3), Vector3D.Cross(p2 - p, p4 - p3));
			double num3 = Vector3D.Dot(Vector3D.Cross(p2 - p, p - p3), Vector3D.Cross(p2 - p, p4 - p3));
			double num4 = Vector3D.Dot(Vector3D.Cross(p2 - p, p4 - p3), Vector3D.Cross(p2 - p, p4 - p3));
			if (Math.Abs(num4) > 0.0)
			{
				double num5 = num2 / num4;
				double num6 = num3 / num4;
				paramOnA = num5;
				paramOnB = num6;
				if (infinite)
				{
					pointOnA = p + num5 * (p2 - p);
					pointOnB = p3 + num6 * (p4 - p3);
					return true;
				}
				bool num7 = 0.0 <= num5 && num5 <= 1.0;
				bool flag = 0.0 <= num6 && num6 <= 1.0;
				if (num7 && flag)
				{
					pointOnA = p + num5 * (p2 - p);
					pointOnB = p3 + num6 * (p4 - p3);
					return true;
				}
				return false;
			}
			paramOnA = (paramOnB = 0.0);
			return false;
		}
		}
	}

	private static bool _0023_003DzRN5IJLBL3xPxyWDwZYWvX4Q_003D(Point3D _0023_003DzE8QrneA_003D, Point3D _0023_003DzH9VU2k0_003D, double _0023_003DzEIRFC3KVph1l, double _0023_003DzfwrEh6Z7vCdt, ref Point3D _0023_003Dz7Wgd3kk1Nk21, ref Point3D _0023_003DzrmYHxUneyF7x, out double _0023_003DzhttfPbJrKS9Q, out double _0023_003Dz7MVhxaVQFgMF)
	{
		_0023_003DzhttfPbJrKS9Q = (_0023_003Dz7MVhxaVQFgMF = 0.0);
		if (Utility.AreEqual(_0023_003DzE8QrneA_003D.X, _0023_003DzH9VU2k0_003D.X, 1.0) && Utility.AreEqual(_0023_003DzE8QrneA_003D.Y, _0023_003DzH9VU2k0_003D.Y, 1.0) && Utility.AreEqual(_0023_003DzE8QrneA_003D.Z, _0023_003DzH9VU2k0_003D.Z, 1.0))
		{
			_0023_003Dz7Wgd3kk1Nk21 = _0023_003DzE8QrneA_003D;
			_0023_003DzrmYHxUneyF7x = _0023_003DzH9VU2k0_003D;
			_0023_003DzhttfPbJrKS9Q = _0023_003DzEIRFC3KVph1l;
			_0023_003Dz7MVhxaVQFgMF = _0023_003DzfwrEh6Z7vCdt;
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656886), P0, P1);
	}

	public static bool AreCollinear(Segment3D s1, Segment3D s2)
	{
		Vector3D vector3D = s1;
		Vector3D vector3D2 = s2;
		vector3D.Normalize();
		vector3D2.Normalize();
		if (Vector3D.AreParallel(vector3D, vector3D2))
		{
			Vector3D vector3D3 = new Vector3D(s1.P0, s2.P0);
			if (Utility.AreEqual(0.0, vector3D3.Length, 1.0))
			{
				return true;
			}
			if (Vector3D.Cross(vector3D3, vector3D).LengthSquared < 1E-12 * vector3D3.LengthSquared)
			{
				return true;
			}
		}
		return false;
	}

	public static bool AreOverlapping(Segment3D s1, Segment3D s2)
	{
		double num = 1E-12 * Math.Min(s1.Length, s2.Length);
		Vector3D vector3D = s1;
		Vector3D vector3D2 = s2;
		vector3D.Normalize();
		vector3D2.Normalize();
		if (!Vector3D.AreParallel(vector3D, vector3D2))
		{
			return false;
		}
		Point3D p = s1.P0;
		Point3D p2 = s1.P1;
		double num2 = s2.Project(p);
		double num3 = s2.Project(p2);
		if ((num2 < num && num3 < num) || (1.0 - num < num2 && 1.0 - num < num3))
		{
			return false;
		}
		if (Utility.Compare(s2.PointAt(num2).DistanceTo(p), 0.0, 1E-12) < 0)
		{
			return true;
		}
		return false;
	}

	public bool IntersectWith(Point3D boxMin, Point3D boxMax, out double t)
	{
		Vector3D vector3D = Vector3D.Subtract(P1, P0);
		vector3D.Normalize();
		Vector3D _0023_003DzHjQZ1_Aor1Dc = new Vector3D(1.0 / vector3D.X, 1.0 / vector3D.Y, 1.0 / vector3D.Z);
		return _0023_003DzDfB4fS0_003D(_0023_003DzHjQZ1_Aor1Dc, boxMin, boxMax, out t);
	}

	internal bool _0023_003DzDfB4fS0_003D(Vector3D _0023_003DzHjQZ1_Aor1Dc, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC, out double _0023_003DzNDQ_E88_003D)
	{
		double val = (_0023_003DzDPcjoBJLcqli.X - P0.X) * _0023_003DzHjQZ1_Aor1Dc.X;
		double val2 = (_0023_003Dz_0024N_0024yKptW9BoC.X - P0.X) * _0023_003DzHjQZ1_Aor1Dc.X;
		double val3 = (_0023_003DzDPcjoBJLcqli.Y - P0.Y) * _0023_003DzHjQZ1_Aor1Dc.Y;
		double val4 = (_0023_003Dz_0024N_0024yKptW9BoC.Y - P0.Y) * _0023_003DzHjQZ1_Aor1Dc.Y;
		double val5 = (_0023_003DzDPcjoBJLcqli.Z - P0.Z) * _0023_003DzHjQZ1_Aor1Dc.Z;
		double val6 = (_0023_003Dz_0024N_0024yKptW9BoC.Z - P0.Z) * _0023_003DzHjQZ1_Aor1Dc.Z;
		double num = Math.Max(Math.Max(Math.Min(val, val2), Math.Min(val3, val4)), Math.Min(val5, val6));
		double num2 = Math.Min(Math.Min(Math.Max(val, val2), Math.Max(val3, val4)), Math.Max(val5, val6));
		if (num2 < 0.0)
		{
			_0023_003DzNDQ_E88_003D = num2;
			return false;
		}
		if (num > num2)
		{
			_0023_003DzNDQ_E88_003D = num2;
			return false;
		}
		_0023_003DzNDQ_E88_003D = num;
		return true;
	}

	public virtual Segment3DSurrogate ConvertToSurrogate()
	{
		return new Segment3DSurrogate(this);
	}
}
