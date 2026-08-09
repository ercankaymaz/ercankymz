using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class PlungeRamp : Ramp
{
	public PlungeRamp(double clearanceHeight)
		: base(clearanceHeight)
	{
	}

	public override void Init(double tolerance, double layerHeight)
	{
		Point3D point3D = new Point3D(0.0, 0.0, layerHeight + ClearanceHeight);
		Motions = new Toolpath.Motion[1]
		{
			new Toolpath.LinearMotion(point3D, Point3D.Origin, motionType.G01, 0.0, 0.0, string.Empty)
			{
				Approach = approachType.Ramp
			}
		};
		base.InterPoints = Array.Empty<Point3D>();
		base.Init(tolerance, layerHeight);
	}
}
