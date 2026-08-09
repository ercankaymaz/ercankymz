using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class CircularMotionSurrogate(Toolpath.CircularMotion circularMotion) : MotionSurrogate(circularMotion)
{
	public Point3D[] Points_V21;

	public Plane Plane;

	public double Radius;

	public Interval Angle = new Interval(0.0, Math.PI * 2.0);

	public double Depth;

	public Vector3D StartNormal;

	public Vector3D EndNormal;

	protected override Toolpath.Motion ConvertToObject()
	{
		Toolpath.CircularMotion circularMotion = new Toolpath.CircularMotion(Plane, Radius, (motionType)Code, Speed, Feed, CodeLine);
		CopyDataToObject(circularMotion);
		return circularMotion;
	}

	protected override void CopyDataFromObject(Toolpath.Motion obj)
	{
		Toolpath.CircularMotion circularMotion = (Toolpath.CircularMotion)obj;
		Plane = circularMotion.Plane;
		Radius = circularMotion.Radius;
		Angle = circularMotion.Angle;
		Depth = circularMotion.Depth;
		StartNormal = circularMotion.StartNormal;
		EndNormal = circularMotion.EndNormal;
		base.CopyDataFromObject(obj);
	}

	protected override void CopyDataToObject(Toolpath.Motion obj)
	{
		Toolpath.CircularMotion circularMotion = (Toolpath.CircularMotion)obj;
		circularMotion.Angle = Angle;
		circularMotion.Depth = Depth;
		circularMotion.StartNormal = StartNormal;
		circularMotion.EndNormal = EndNormal;
		base.CopyDataToObject(obj);
		if (base.Version < 22)
		{
			circularMotion.points = Points_V21;
		}
	}
}
