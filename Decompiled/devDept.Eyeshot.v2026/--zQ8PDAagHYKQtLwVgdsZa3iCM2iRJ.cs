using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Geometry;

internal struct _0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ(Point3D _0023_003DzkYa2PI0_003D, double _0023_003Dzha0R9ro_003D)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D _0023_003DzpevenEk_003D = _0023_003DzkYa2PI0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003DzSVz6jiA_003D = _0023_003Dzha0R9ro_003D;

	public static _0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ _0023_003Dz7fUpAfUklwSQ(IEnumerable<Point3D> _0023_003DzrdSL0CI_003D)
	{
		double num = 0.0;
		List<Point3D> list = _0023_003DzrdSL0CI_003D.ToList();
		List<Point3D> list2 = new List<Point3D>(list.Count);
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(list[i]);
		}
		if (list.Count > 0)
		{
			double _0023_003DzETorJjE_003D = 0.0;
			_0023_003DzUT9zpXC7HugDTajIJ1wSkwNx6JJp(list2, 10000, out var _0023_003DzeUujDMs_003D, out _0023_003DzETorJjE_003D);
			return new _0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ(_0023_003DzeUujDMs_003D, _0023_003DzETorJjE_003D * (1.0 + num));
		}
		return default(_0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ);
	}

	public static _0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ _0023_003Dzcek2I6k_003D(IEnumerable<Vector3D> _0023_003Dz_nZTyqw_003D)
	{
		Point3D point3D2;
		Point3D point3D3;
		Point3D point3D = (point3D2 = (point3D3 = Point3D.MaxValue));
		Point3D point3D5;
		Point3D point3D6;
		Point3D point3D4 = (point3D5 = (point3D6 = Point3D.MinValue));
		foreach (Vector3D item in _0023_003Dz_nZTyqw_003D)
		{
			if (item.X < point3D.X)
			{
				point3D = item.AsPoint;
			}
			if (item.X > point3D4.X)
			{
				point3D4 = item.AsPoint;
			}
			if (item.Y < point3D2.Y)
			{
				point3D2 = item.AsPoint;
			}
			if (item.Y > point3D5.Y)
			{
				point3D5 = item.AsPoint;
			}
			if (item.Z < point3D3.Z)
			{
				point3D3 = item.AsPoint;
			}
			if (item.Z > point3D6.Z)
			{
				point3D6 = item.AsPoint;
			}
		}
		double num = Point3D.DistanceSquared(point3D4, point3D);
		double num2 = Point3D.DistanceSquared(point3D5, point3D2);
		double num3 = Point3D.DistanceSquared(point3D6, point3D3);
		Point3D point3D7 = point3D;
		Point3D point3D8 = point3D4;
		double num4 = num;
		if (num2 > num4)
		{
			num4 = num2;
			point3D7 = point3D2;
			point3D8 = point3D5;
		}
		if (num3 > num4)
		{
			point3D7 = point3D3;
			point3D8 = point3D6;
		}
		Point3D point3D9 = (point3D7 + point3D8) * 0.5;
		double num5 = Point3D.DistanceSquared(point3D8, point3D9);
		double num6 = Math.Sqrt(num5);
		foreach (Vector3D item2 in _0023_003Dz_nZTyqw_003D)
		{
			double num7 = Point3D.DistanceSquared(item2.AsPoint, point3D9);
			if (num7 > num5)
			{
				double num8 = Math.Sqrt(num7);
				num6 = (num6 + num8) * 0.5;
				num5 = num6 * num6;
				double num9 = num8 - num6;
				point3D9 = (num6 * point3D9 + num9 * item2) / num8;
			}
		}
		return new _0023_003DzQ8PDAagHYKQtLwVgdsZa3iCM2iRJ(point3D9, num6);
	}

	public static void _0023_003DzUT9zpXC7HugDTajIJ1wSkwNx6JJp(List<Point3D> _0023_003DzOnQC6_0024o_003D, int _0023_003DzdcIp_Hg_003D, out Point3D _0023_003DzeUujDMs_003D, out double _0023_003DzETorJjE_003D)
	{
		_0023_003DzeUujDMs_003D = _0023_003DzOnQC6_0024o_003D[0];
		_0023_003DzETorJjE_003D = 0.0;
		for (int i = 0; i < _0023_003DzdcIp_Hg_003D; i++)
		{
			int index = 0;
			double num = Point3D.Distance(_0023_003DzeUujDMs_003D, _0023_003DzOnQC6_0024o_003D[0]);
			for (int j = 1; j < _0023_003DzOnQC6_0024o_003D.Count; j++)
			{
				double num2 = Point3D.Distance(_0023_003DzeUujDMs_003D, _0023_003DzOnQC6_0024o_003D[j]);
				if (num2 > num)
				{
					index = j;
					num = num2;
				}
			}
			_0023_003DzETorJjE_003D = num;
			_0023_003DzeUujDMs_003D = new Point3D(_0023_003DzeUujDMs_003D.X + 1.0 / ((double)i + 1.0) * (_0023_003DzOnQC6_0024o_003D[index].X - _0023_003DzeUujDMs_003D.X), _0023_003DzeUujDMs_003D.Y + 1.0 / ((double)i + 1.0) * (_0023_003DzOnQC6_0024o_003D[index].Y - _0023_003DzeUujDMs_003D.Y), _0023_003DzeUujDMs_003D.Z + 1.0 / ((double)i + 1.0) * (_0023_003DzOnQC6_0024o_003D[index].Z - _0023_003DzeUujDMs_003D.Z));
		}
	}
}
