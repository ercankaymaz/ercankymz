using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class ePolyline : eEntities
{
	public ePolyline()
	{
	}

	public ePolyline(List<Pnt3D> Vertices)
	{
		Vertice.Clear();
		for (int i = 0; i <= Vertices.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(Vertices[i]));
		}
		Update();
	}

	public ePolyline(List<Pnt3D> Vertices, float Thickness, Color Color)
	{
		Vertice.Clear();
		for (int i = 0; i <= Vertices.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(Vertices[i]));
		}
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public ePolyline(eEntities ent)
	{
		if (ent.GetType() == typeof(ePolyline))
		{
			Pnt3D.Copy(ent.Vertice, ref Vertice);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodePolyline(List<string> Codes)
	{
		ePolyline ePolyline2 = new ePolyline();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, ePolyline2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = ePolyline2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		ePolyline2.Update();
		return ePolyline2;
	}

	public override string ToString()
	{
		string text = "";
		if (Vertice.Count > 0)
		{
			text = "SP: " + Vertice[0].ToString(3) + " EP: " + Vertice[Vertice.Count - 1].ToString(3);
		}
		return "ePolyline - " + text + " Count : " + Vertice.Count;
	}
}
