using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public abstract class LeadBase
{
	public double? Feed;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzzoB9KyE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DztBLP1lrEn3wkg4KLIQ_003D_003D;

	public Toolpath.Motion[] Motions;

	public Point3D[] InterPoints
	{
		get
		{
			return _0023_003DztBLP1lrEn3wkg4KLIQ_003D_003D ?? _0023_003DzzoB9KyE_003D;
		}
		protected set
		{
			_0023_003DztBLP1lrEn3wkg4KLIQ_003D_003D = value;
		}
	}

	protected void Init(double tolerance)
	{
		List<Point3D> list = new List<Point3D>(Motions.Length + 1);
		Toolpath.Motion[] motions = Motions;
		foreach (Toolpath.Motion motion in motions)
		{
			if (list.Count > 0)
			{
				list.RemoveAt(list.Count - 1);
			}
			Point3D[] collection = motion._0023_003DzfHSvFLY_003D(tolerance);
			list.AddRange(collection);
		}
		_0023_003DzzoB9KyE_003D = list.ToArray();
	}

	protected void BuildAsLollipop(double radius, double distance)
	{
		Circle circle = new Circle(0.0, distance + radius, 0.0, radius);
		circle.Rotate(-Math.PI / 2.0, Vector3D.AxisZ, circle.Center);
		circle.Regen(new RegenParams(0.0, Math.PI / 8.0));
		if (distance == 0.0)
		{
			InterPoints = circle.Vertices;
			return;
		}
		InterPoints = new Point3D[circle.Vertices.Length + 1];
		InterPoints[0] = Point3D.Origin;
		Array.Copy(circle.Vertices, 0, InterPoints, 1, circle.Vertices.Length);
	}
}
