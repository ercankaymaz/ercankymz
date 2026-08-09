using System;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class TpArcData
{
	public Point3D StartPoint = new Point3D();

	public Point3D EndPoint = new Point3D();

	public Point3D CenterPoint = new Point3D();

	public double Radius = 0.0;

	public double Length = 0.0;

	public double SweepAngle = 0.0;

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public bool isCW = false;

	public bool isReverse = false;

	public TpArcData()
	{
	}

	public TpArcData(TpArcData arc)
	{
		CenterPoint = buVector5.ToPoint3D(arc.CenterPoint);
		Radius = arc.Radius;
		SweepAngle = arc.SweepAngle;
		isCW = arc.isCW;
		StartAngle = arc.StartAngle;
		EndAngle = arc.EndAngle;
		StartPoint = buVector5.ToPoint3D(arc.StartPoint);
		EndPoint = buVector5.ToPoint3D(arc.EndPoint);
	}

	public TpArcData(Point3D Center, double Rad, double StartAng, double EndAng)
	{
		CenterPoint = buVector5.ToPoint3D(Center);
		Radius = Rad;
		StartAngle = StartAng;
		EndAngle = EndAng;
	}

	public TpArcData(Point3D Center, Point3D startPoint, Point3D endPoint)
	{
		CenterPoint = buVector5.ToPoint3D(Center);
		StartPoint = buVector5.ToPoint3D(startPoint);
		EndPoint = buVector5.ToPoint3D(endPoint);
	}

	public override string ToString()
	{
		return "Arc - Center : " + CenterPoint.ToString() + " , Rad : " + Radius + " , SA : " + StartAngle + " , EA : " + EndAngle;
	}
}
