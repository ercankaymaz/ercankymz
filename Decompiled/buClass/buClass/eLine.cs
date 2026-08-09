using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class eLine : eEntities
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public eLine()
	{
	}

	public eLine(Pnt3D StartPoint, Pnt3D EndPoint)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		Update();
	}

	public eLine(Pnt3D StartPoint, Pnt3D EndPoint, float Thickness, Color Clr)
	{
		this.StartPoint = new Pnt3D(StartPoint);
		this.EndPoint = new Pnt3D(EndPoint);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public eLine(eEntities ent)
	{
		if (ent.GetType() == typeof(eLine))
		{
			StartPoint = new Pnt3D(((eLine)ent).StartPoint);
			EndPoint = new Pnt3D(((eLine)ent).EndPoint);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeLine(List<string> Codes)
	{
		eLine eLine2 = new eLine();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eLine2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eLine2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eLine2.Update();
		return eLine2;
	}

	public override string ToString()
	{
		return "eLine - SP : " + StartPoint.ToString(3) + " - EP : " + EndPoint.ToString(3) + " - Dir: " + camDirections;
	}
}
