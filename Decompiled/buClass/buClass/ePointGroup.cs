using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class ePointGroup : eEntities
{
	public ePointGroup()
	{
	}

	public ePointGroup(List<Pnt3D> Points)
	{
		Vertice.Clear();
		Pnt3D.Copy(Points, ref Vertice);
		Update();
	}

	public ePointGroup(List<Pnt3D> Points, float Thickness, Color Clr)
	{
		Vertice.Clear();
		Pnt3D.Copy(Points, ref Vertice);
		dispThickness = Thickness;
		dispColor = Clr;
		Update();
	}

	public ePointGroup(eEntities ent)
	{
		if (ent.GetType() == typeof(ePointGroup))
		{
			Vertice.Clear();
			Pnt3D.Copy(ent.Vertice, ref Vertice);
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
		return "ePointGroup - Count :" + Vertice.Count;
	}
}
