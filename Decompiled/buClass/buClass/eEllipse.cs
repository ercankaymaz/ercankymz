using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eEllipse : ePlaneEntities
{
	public double MajorRadius = 0.0;

	public double MinorRadius = 0.0;

	public double Angle = 0.0;

	public eEllipse()
	{
	}

	public eEllipse(Pnt3D CenterPoint, double MajorRadius, double MinorRadius, double Angle, WorkPlane Plane)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eEllipse(Pnt3D CenterPoint, double MajorRadius, double MinorRadius, double Angle, WorkPlane Plane, float Thickness, Color Color)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		this.MajorRadius = MajorRadius;
		this.MinorRadius = MinorRadius;
		this.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public eEllipse(eEntities ent)
	{
		if (ent.GetType() == typeof(eEllipse))
		{
			CenterPoint = new Pnt3D(((eEllipse)ent).CenterPoint);
			MajorRadius = ((eEllipse)ent).MajorRadius;
			MinorRadius = ((eEllipse)ent).MinorRadius;
			Angle = ((eEllipse)ent).Angle;
			Plane = new WorkPlane(((ePlaneEntities)ent).Plane);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeEllipse(List<string> Codes)
	{
		eEllipse eEllipse2 = new eEllipse();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eEllipse2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eEllipse2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eEllipse2.Update();
		return eEllipse2;
	}

	public override string ToString()
	{
		return "eEllipse - CP : " + CenterPoint.ToString(3) + " - Major Rad : " + MajorRadius.ToString("f3") + " - Minor Rad : " + MinorRadius.ToString("f3") + " - Angle : " + Angle.ToString("f3");
	}
}
