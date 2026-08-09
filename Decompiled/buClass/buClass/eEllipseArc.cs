using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eEllipseArc : eEllipse
{
	public double StartAngle = 0.0;

	public double EndAngle = 0.0;

	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public eEllipseArc()
	{
	}

	public eEllipseArc(Pnt3D CenterPoint, double MajorRadius, double MinorRadius, double StartAngle, double EndAngle, double Angle, WorkPlane Plane)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		base.MajorRadius = MajorRadius;
		base.MinorRadius = MinorRadius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		base.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		Update();
	}

	public eEllipseArc(Pnt3D CenterPoint, double MajorRadius, double MinorRadius, double StartAngle, double EndAngle, double Angle, WorkPlane Plane, float Thickness, Color Color)
	{
		base.CenterPoint = new Pnt3D(CenterPoint);
		base.MajorRadius = MajorRadius;
		base.MinorRadius = MinorRadius;
		this.StartAngle = StartAngle;
		this.EndAngle = EndAngle;
		base.Angle = Angle;
		base.Plane = new WorkPlane(Plane);
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public eEllipseArc(eEntities ent)
	{
		if (ent.GetType() == typeof(eEllipseArc))
		{
			CenterPoint = new Pnt3D(((eEllipseArc)ent).CenterPoint);
			MajorRadius = ((eEllipseArc)ent).MajorRadius;
			MinorRadius = ((eEllipseArc)ent).MinorRadius;
			StartAngle = ((eEllipseArc)ent).StartAngle;
			EndAngle = ((eEllipseArc)ent).EndAngle;
			Angle = ((eEllipseArc)ent).Angle;
			Plane = new WorkPlane(((ePlaneEntities)ent).Plane);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeEllipseArc(List<string> Codes)
	{
		eEllipseArc eEllipseArc2 = new eEllipseArc();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eEllipseArc2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eEllipseArc2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eEllipseArc2.Update();
		return eEllipseArc2;
	}

	public override string ToString()
	{
		return "eEllipseArc - CP : " + CenterPoint.ToString(3) + " - Major Rad : " + MajorRadius.ToString("f3") + " - Minor Rad : " + MinorRadius.ToString("f3") + " - SA : " + StartAngle.ToString("f3") + " - EA : " + EndAngle.ToString("f3") + " - Angle : " + Angle.ToString("f3");
	}
}
