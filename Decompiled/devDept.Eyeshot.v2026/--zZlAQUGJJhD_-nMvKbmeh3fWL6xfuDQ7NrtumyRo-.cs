using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;

internal sealed class _0023_003DzZlAQUGJJhD__0024nMvKbmeh3fWL6xfuDQ7NrtumyRo_003D
{
	public static T[] _0023_003Dz_IsqsVA_003D<T>(IList<T> _0023_003DzrdSL0CI_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D) where T : Point2D
	{
		if (_0023_003DzrdSL0CI_003D.Count < 3)
		{
			return _0023_003DzrdSL0CI_003D.ToArray();
		}
		T val = _0023_003DzrdSL0CI_003D.First();
		T val2 = _0023_003DzrdSL0CI_003D.Last();
		if (val is Point3D point3D)
		{
			if (Utility.Compare(val.X, val2.X) == 0 && Utility.Compare(val.Y, val2.Y) == 0 && Utility.Compare(point3D.Z, (val2 as Point3D).Z) == 0)
			{
				return _0023_003Dz8LqTtd78UqaZAnuGCQ_003D_003D(_0023_003DzrdSL0CI_003D.ToArray(), _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
			}
		}
		else if ((object)val != null && Utility.Compare(val.X, val2.X) == 0 && Utility.Compare(val.Y, val2.Y) == 0)
		{
			return _0023_003Dz8LqTtd78UqaZAnuGCQ_003D_003D(_0023_003DzrdSL0CI_003D.ToArray(), _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		}
		int num = 0;
		int num2 = _0023_003DzrdSL0CI_003D.Count - 1;
		List<int> list = new List<int> { num, num2 };
		if (typeof(Point3D).IsAssignableFrom(typeof(T)))
		{
			Point3D point3D2 = _0023_003DzrdSL0CI_003D[num] as Point3D;
			Point3D other = _0023_003DzrdSL0CI_003D[num2] as Point3D;
			while (point3D2.Equals(other))
			{
				num2--;
				other = _0023_003DzrdSL0CI_003D[num2] as Point3D;
			}
		}
		else
		{
			Point2D point2D = _0023_003DzrdSL0CI_003D[num];
			Point2D other2 = _0023_003DzrdSL0CI_003D[num2];
			while (point2D.Equals(other2))
			{
				num2--;
				other2 = _0023_003DzrdSL0CI_003D[num2];
			}
		}
		_0023_003Dz_IsqsVA_003D(_0023_003DzrdSL0CI_003D, num, num2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, list);
		List<T> list2 = new List<T>();
		list.Sort();
		foreach (int item in list)
		{
			list2.Add(_0023_003DzrdSL0CI_003D[item]);
		}
		return list2.ToArray();
	}

	private static void _0023_003Dz_IsqsVA_003D<T>(IList<T> _0023_003DzrdSL0CI_003D, int _0023_003Dz_65lZ6i_0024i4fH, int _0023_003DzmZ6d_0024RbCOla7, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, List<int> _0023_003Dzb5cVN8aTcpKp) where T : Point2D
	{
		double num = 0.0;
		int num2 = 0;
		if (typeof(Point3D).IsAssignableFrom(typeof(T)))
		{
			for (int i = _0023_003Dz_65lZ6i_0024i4fH; i < _0023_003DzmZ6d_0024RbCOla7; i++)
			{
				double num3 = _0023_003DzSD0F3P8jAx_0024TR_yT_0024wLo_0024FkssnDX(_0023_003DzrdSL0CI_003D[_0023_003Dz_65lZ6i_0024i4fH] as Point3D, _0023_003DzrdSL0CI_003D[_0023_003DzmZ6d_0024RbCOla7] as Point3D, _0023_003DzrdSL0CI_003D[i] as Point3D);
				if (num3 > num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		else
		{
			for (int j = _0023_003Dz_65lZ6i_0024i4fH; j < _0023_003DzmZ6d_0024RbCOla7; j++)
			{
				double num4 = _0023_003Dzvsw6qK7G5DsJeCNx2i5EdDq2gpAD(_0023_003DzrdSL0CI_003D[_0023_003Dz_65lZ6i_0024i4fH], _0023_003DzrdSL0CI_003D[_0023_003DzmZ6d_0024RbCOla7], _0023_003DzrdSL0CI_003D[j]);
				if (num4 > num)
				{
					num = num4;
					num2 = j;
				}
			}
		}
		if (num > _0023_003DzuMKQhOieejyEvhtVOw_003D_003D && num2 != 0)
		{
			_0023_003Dzb5cVN8aTcpKp.Add(num2);
			_0023_003Dz_IsqsVA_003D(_0023_003DzrdSL0CI_003D, _0023_003Dz_65lZ6i_0024i4fH, num2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dzb5cVN8aTcpKp);
			_0023_003Dz_IsqsVA_003D(_0023_003DzrdSL0CI_003D, num2, _0023_003DzmZ6d_0024RbCOla7, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dzb5cVN8aTcpKp);
		}
	}

	private static double _0023_003DzSD0F3P8jAx_0024TR_yT_0024wLo_0024FkssnDX(Point3D _0023_003DzrNyhm6g_003D, Point3D _0023_003DztY_anuo_003D, Point3D _0023_003DzlY77YgY_003D)
	{
		Segment3D segment3D = new Segment3D(_0023_003DzrNyhm6g_003D, _0023_003DztY_anuo_003D);
		double t = segment3D.ClosestPointTo(_0023_003DzlY77YgY_003D);
		Point3D b = segment3D.PointAt(t);
		return _0023_003DzlY77YgY_003D.DistanceTo(b);
	}

	private static double _0023_003Dzvsw6qK7G5DsJeCNx2i5EdDq2gpAD(Point2D _0023_003DzrNyhm6g_003D, Point2D _0023_003DztY_anuo_003D, Point2D _0023_003DzlY77YgY_003D)
	{
		Segment2D segment2D = new Segment2D(_0023_003DzrNyhm6g_003D, _0023_003DztY_anuo_003D);
		double t = segment2D.ClosestPointTo(_0023_003DzlY77YgY_003D);
		Point2D b = segment2D.PointAt(t);
		return _0023_003DzlY77YgY_003D.DistanceTo(b);
	}

	private static T[] _0023_003Dz8LqTtd78UqaZAnuGCQ_003D_003D<T>(T[] _0023_003Dzsuiz4uo_003D, double _0023_003Dzm0CYiiE_003D) where T : Point2D
	{
		int num = _0023_003Dzsuiz4uo_003D.Length;
		double num2 = 0.0;
		int num3 = 0;
		T val = _0023_003Dzsuiz4uo_003D[0];
		if (typeof(Point3D).IsAssignableFrom(typeof(T)))
		{
			for (int i = 1; i < num; i++)
			{
				double num4 = Point3D.DistanceSquared(val as Point3D, _0023_003Dzsuiz4uo_003D[i] as Point3D);
				if (num4 > num2)
				{
					num3 = i;
					num2 = num4;
				}
			}
		}
		else
		{
			for (int j = 1; j < num; j++)
			{
				double num5 = Point2D.DistanceSquared(val, _0023_003Dzsuiz4uo_003D[j]);
				if (num5 > num2)
				{
					num3 = j;
					num2 = num5;
				}
			}
		}
		T[] array = new T[num3 + 1];
		Array.Copy(_0023_003Dzsuiz4uo_003D, array, num3);
		array[num3] = (T)_0023_003Dzsuiz4uo_003D[num3].Clone();
		T[] array2 = _0023_003Dz_IsqsVA_003D(array, _0023_003Dzm0CYiiE_003D);
		T[] array3 = new T[num - num3];
		Array.Copy(_0023_003Dzsuiz4uo_003D, num3, array3, 0, array3.Length);
		T[] array4 = _0023_003Dz_IsqsVA_003D(array3, _0023_003Dzm0CYiiE_003D);
		T[] array5 = new T[array2.Length + array4.Length];
		Array.Copy(array2, 0, array5, 0, array2.Length);
		Array.Copy(array4, 0, array5, array2.Length, array4.Length);
		return array5;
	}
}
