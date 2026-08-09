using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class eSurfaceNull : eEntities
{
	public eSurfaceNull()
	{
		Triangles = new List<Triangle3D>();
	}

	public eSurfaceNull(eEntities ent)
	{
		if (ent.GetType() == typeof(eSurfaceNull))
		{
			Triangles = new List<Triangle3D>();
			for (int i = 0; i <= ((eSurfaceNull)ent).Triangles.Count - 1; i++)
			{
				Triangles.Add(new Triangle3D(((eSurfaceNull)ent).Triangles[i]));
				Vertice.Add(new Pnt3D(Triangles[i].FirstPoint));
				Vertice.Add(new Pnt3D(Triangles[i].SecondPoint));
				Vertice.Add(new Pnt3D(Triangles[i].ThirdPoint));
			}
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eSurfaceNull DecodeSolid(List<string> Codes)
	{
		eSurfaceNull eSurfaceNull2 = new eSurfaceNull();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eSurfaceNull2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eSurfaceNull2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eSurfaceNull2.Update();
		return eSurfaceNull2;
	}
}
