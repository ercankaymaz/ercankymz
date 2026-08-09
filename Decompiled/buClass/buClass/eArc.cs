using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eArc : eCircle
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D MiddlePoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public eArc()
	{
	}

	public eArc(Pnt3D CenterPoint, double Radius, double StartAngle, double EndAngle, WorkPlane Plane)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		base.Radius = Radius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eArc(Pnt3D CenterPoint, double Radius, double StartAngle, double EndAngle, WorkPlane Plane, float Thickness, Color Color)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		base.Radius = Radius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		dispThickness = Thickness;
		dispColor = Color;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eArc(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, WorkPlane Plane)
	{
		Pnt3D Center = new Pnt3D();
		double StartAngle = 0.0;
		double EndAngle = 0.0;
		double Radius = 0.0;
		List<Pnt3D> Vertices = new List<Pnt3D>();
		buStatics.Arc3Point(FirstPoint, SecondPoint, ThirdPoint, Plane, ref Center, ref Radius, ref StartAngle, ref EndAngle, ref Vertices);
		CenterPoint = new Pnt3D(Center);
		base.Radius = Radius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		base.Plane = Plane;
		Update();
	}

	public eArc(eEntities ent)
	{
		if (ent.GetType() == typeof(eArc))
		{
			CenterPoint = new Pnt3D(((eArc)ent).CenterPoint);
			Radius = ((eArc)ent).Radius;
			StartAngle = ((eArc)ent).StartAngle;
			EndAngle = ((eArc)ent).EndAngle;
			StartPoint = ((eArc)ent).StartPoint;
			MiddlePoint = ((eArc)ent).MiddlePoint;
			EndPoint = ((eArc)ent).EndPoint;
			Plane = new WorkPlane(((ePlaneEntities)ent).Plane);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeArc(List<string> Codes)
	{
		eArc eArc2 = new eArc();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eArc2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eArc2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eArc2.Update();
		return eArc2;
	}

	public override string ToString()
	{
		return "eArc - CP : " + CenterPoint.ToString(3) + " - Rad : " + Radius.ToString("f3") + " - SA : " + StartAngle.ToString("f3") + " - EA : " + EndAngle.ToString("f3");
	}
}
