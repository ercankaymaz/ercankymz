using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class OsnapCoordinateCatch
{
	public bool Found = false;

	public bool Enable = true;

	public bool SnapFound = false;

	public bool OrthoFound = false;

	public bool OsnapFound = false;

	public bool TrackFound = false;

	public bool OverFound = false;

	public Point3D Point = new Point3D();

	public osnapType Type = osnapType.None;

	public osnapMethodType Method = osnapMethodType.None;

	public int UnderEntityIndex = -1;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Depth = 0.0;

	public double Thickness = 2.0;

	public Color Color = Color.Lime;

	public List<Point3D> CatchBasePoints = new List<Point3D>();

	public Point3D EntityPoint = new Point3D();

	public double DistanceToPoint = 0.0;

	public OsnapCoordinateCatch()
	{
	}

	public OsnapCoordinateCatch(OsnapCoordinateCatch Catch)
	{
		Found = Catch.Found;
		SnapFound = Catch.SnapFound;
		OrthoFound = Catch.OrthoFound;
		OsnapFound = Catch.OsnapFound;
		TrackFound = Catch.TrackFound;
		OverFound = Catch.OverFound;
		UnderEntityIndex = Catch.UnderEntityIndex;
		Point = new Point3D(Catch.Point.X, Catch.Point.Y, Catch.Point.Z);
		EntityPoint = new Point3D(Catch.EntityPoint.X, Catch.EntityPoint.Y, Catch.EntityPoint.Z);
		Type = Catch.Type;
		Method = Catch.Method;
		Width = Catch.Width;
		Height = Catch.Height;
		Depth = Catch.Depth;
		Thickness = Catch.Thickness;
		Color = Catch.Color;
	}
}
