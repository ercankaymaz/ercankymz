using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eUpperLine : eLine
{
	public eUpperLine()
	{
	}

	public eUpperLine(Pnt3D StartPoint, Pnt3D EndPoint)
	{
		base.StartPoint = new Pnt3D(StartPoint);
		base.EndPoint = new Pnt3D(EndPoint);
		Update();
	}

	public eUpperLine(Pnt3D StartPoint, Pnt3D EndPoint, float Thickness, Color Clr)
	{
		base.StartPoint = new Pnt3D(StartPoint);
		base.EndPoint = new Pnt3D(EndPoint);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public eUpperLine(eEntities ent)
	{
		if (ent.GetType() == typeof(eUpperLine))
		{
			StartPoint = new Pnt3D(((eUpperLine)ent).StartPoint);
			EndPoint = new Pnt3D(((eUpperLine)ent).EndPoint);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodeUpperLine(List<string> Codes)
	{
		eUpperLine eUpperLine2 = new eUpperLine();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eUpperLine2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eUpperLine2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eUpperLine2.Update();
		return eUpperLine2;
	}

	public override string ToString()
	{
		return "eUpperLine - SP : " + StartPoint.ToString(3) + " - EP : " + EndPoint.ToString(3);
	}
}
