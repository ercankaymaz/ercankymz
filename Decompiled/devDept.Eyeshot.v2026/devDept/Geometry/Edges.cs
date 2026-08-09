using System;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

[Serializable]
internal sealed class Edges : ICloneable
{
	public readonly Point3D[] Points = new Point3D[4];

	public readonly bool[] Poles = new bool[4];

	public Edges()
	{
	}

	public Edges(Edges _0023_003Dzl_0024MIsC0_003D)
	{
		Points = Utility.DeepCopy(_0023_003Dzl_0024MIsC0_003D.Points);
		Array.Copy(_0023_003Dzl_0024MIsC0_003D.Poles, Poles, 0);
	}

	public Point3D _0023_003Dze5l_0024RiEBG8Fu()
	{
		return Points[0];
	}

	public void _0023_003DzvBU31wjltOH3(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		Points[0] = _0023_003DzPzO_0024GUk_003D;
	}

	public Point3D _0023_003Dz7Q8NCjwVr8CM()
	{
		return Points[1];
	}

	public void _0023_003DzyizGkkPbgIWm(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		Points[1] = _0023_003DzPzO_0024GUk_003D;
	}

	public Point3D _0023_003DzVa_0024oj2xEedri()
	{
		return Points[2];
	}

	public void _0023_003DzusxA4ZTGhQeL(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		Points[2] = _0023_003DzPzO_0024GUk_003D;
	}

	public Point3D _0023_003DzdeQouaJ8sRT8()
	{
		return Points[3];
	}

	public void _0023_003DznDPeDwCMZ8mn(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		Points[3] = _0023_003DzPzO_0024GUk_003D;
	}

	public void _0023_003DztGdcVOA_003D(Point4D[,] _0023_003DzFduYrbQ_003D, double? _0023_003DzamE_FYJFaj0ntV8BBA_003D_003D)
	{
		int length = _0023_003DzFduYrbQ_003D.GetLength(0);
		int length2 = _0023_003DzFduYrbQ_003D.GetLength(1);
		if (!_0023_003DzamE_FYJFaj0ntV8BBA_003D_003D.HasValue)
		{
			Utility._0023_003Dz61B8IYSGx6wG(_0023_003DzFduYrbQ_003D, length, length2, out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
			_0023_003DzamE_FYJFaj0ntV8BBA_003D_003D = new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D).Diagonal;
		}
		double _0023_003Dzm0CYiiE_003D = _0023_003DzamE_FYJFaj0ntV8BBA_003D_003D.Value * Utility._0023_003DzxhnLabVjXjPg;
		_0023_003DzIeJbpMqfbfPX(_0023_003DzFduYrbQ_003D, _0023_003DzFduYrbQ_003D.Num(dir: false) - 1, _0023_003DzCJkr8nY_003D: true, _0023_003Dzm0CYiiE_003D, out Points[0], out Poles[0]);
		_0023_003DzIeJbpMqfbfPX(_0023_003DzFduYrbQ_003D, _0023_003DzFduYrbQ_003D.Num() - 1, _0023_003DzCJkr8nY_003D: false, _0023_003Dzm0CYiiE_003D, out Points[1], out Poles[1]);
		_0023_003DzIeJbpMqfbfPX(_0023_003DzFduYrbQ_003D, 0, _0023_003DzCJkr8nY_003D: true, _0023_003Dzm0CYiiE_003D, out Points[2], out Poles[2]);
		_0023_003DzIeJbpMqfbfPX(_0023_003DzFduYrbQ_003D, 0, _0023_003DzCJkr8nY_003D: false, _0023_003Dzm0CYiiE_003D, out Points[3], out Poles[3]);
	}

	private static void _0023_003DzIeJbpMqfbfPX(Point4D[,] _0023_003DzFduYrbQ_003D, int _0023_003DzxuJqjrs_003D, bool _0023_003DzCJkr8nY_003D, double _0023_003Dzm0CYiiE_003D, out Point3D _0023_003DzlY77YgY_003D, out bool _0023_003Dze1scWeZz8n_c)
	{
		_0023_003DzlY77YgY_003D = null;
		_0023_003Dze1scWeZz8n_c = false;
		bool flag = true;
		int num = _0023_003DzFduYrbQ_003D.Num(_0023_003DzCJkr8nY_003D);
		Point3D point3D = _0023_003DzFduYrbQ_003D.Get(0, _0023_003DzxuJqjrs_003D, _0023_003DzCJkr8nY_003D).Euclid;
		for (int i = 1; i < num; i++)
		{
			Point3D euclid = _0023_003DzFduYrbQ_003D.Get(i, _0023_003DzxuJqjrs_003D, _0023_003DzCJkr8nY_003D).Euclid;
			if (Point3D.Distance(point3D, euclid) > _0023_003Dzm0CYiiE_003D)
			{
				flag = false;
				break;
			}
			point3D = euclid;
		}
		if (flag)
		{
			_0023_003DzlY77YgY_003D = point3D;
			_0023_003Dze1scWeZz8n_c = false;
			if (num > 2)
			{
				int v = ((_0023_003DzxuJqjrs_003D == 0) ? 1 : (_0023_003DzFduYrbQ_003D.Num(!_0023_003DzCJkr8nY_003D) - 2));
				Plane plane = new Plane(_0023_003DzFduYrbQ_003D.Get(0, v, _0023_003DzCJkr8nY_003D).Euclid, _0023_003DzFduYrbQ_003D.Get(1, v, _0023_003DzCJkr8nY_003D).Euclid, _0023_003DzFduYrbQ_003D.Get(2, v, _0023_003DzCJkr8nY_003D).Euclid);
				_0023_003Dze1scWeZz8n_c = Math.Abs(plane.DistanceTo(_0023_003DzlY77YgY_003D)) < _0023_003Dzm0CYiiE_003D;
			}
		}
	}

	public bool _0023_003Dzxiv0UU0_003D()
	{
		if (!(Points[0] != null) && !(Points[1] != null) && !(Points[2] != null))
		{
			return Points[3] != null;
		}
		return true;
	}

	public void _0023_003DzXnS5xBU_003D()
	{
		Utility.Swap(ref Points[1], ref Points[3]);
		Utility.Swap(ref Poles[1], ref Poles[3]);
	}

	public void _0023_003DzdFAzsx8_003D()
	{
		Utility.Swap(ref Points[0], ref Points[2]);
		Utility.Swap(ref Poles[0], ref Poles[2]);
	}

	public object Clone()
	{
		return new Edges(this);
	}
}
