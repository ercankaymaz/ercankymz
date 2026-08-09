using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class ePoint : eEntities
{
	public Pnt3D StartPoint = new Pnt3D();

	public bool DrawAsCircle = false;

	public ePoint()
	{
	}

	public ePoint(Pnt3D StartPoint)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		Update();
	}

	public ePoint(Pnt3D StartPoint, float Thickness, Color Clr)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public ePoint(eEntities ent)
	{
		if (ent.GetType() == typeof(ePoint))
		{
			StartPoint = new Pnt3D(((ePoint)ent).StartPoint);
			DrawAsCircle = ((ePoint)ent).DrawAsCircle;
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodePoint(List<string> Codes)
	{
		ePoint ePoint2 = new ePoint();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, ePoint2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = ePoint2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		ePoint2.Update();
		return ePoint2;
	}

	public override string ToString()
	{
		return "ePoint - SP :" + StartPoint.ToString(3);
	}
}
