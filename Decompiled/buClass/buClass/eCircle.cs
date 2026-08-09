using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eCircle : ePlaneEntities
{
	public double Radius = 0.0;

	public eCircle()
	{
	}

	public eCircle(Pnt3D CenterPoint, double Radius, WorkPlane Plane)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.Radius = Radius;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eCircle(Pnt3D CenterPoint, double Radius, WorkPlane Plane, float Thickness, Color Color)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.Radius = Radius;
		dispThickness = Thickness;
		dispColor = Color;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eCircle(eEntities ent)
	{
		if (ent.GetType() == typeof(eCircle))
		{
			CenterPoint = new Pnt3D(((eCircle)ent).CenterPoint);
			Radius = ((eCircle)ent).Radius;
			Plane = new WorkPlane(((ePlaneEntities)ent).Plane);
			Update();
			eEntities.CopyBase(ent, this);
		}
	}

	public static eEntities DecodeCircle(List<string> Codes)
	{
		eCircle eCircle2 = new eCircle();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eCircle2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eCircle2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eCircle2.Update();
		return eCircle2;
	}

	public override string ToString()
	{
		return "eCircle - CP : " + CenterPoint.ToString(3) + " - Rad : " + Radius.ToString("f3");
	}
}
