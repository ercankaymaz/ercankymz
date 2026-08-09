using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class eSolid3D : eEntities
{
	public eSolid3D()
	{
		Triangles = new List<Triangle3D>();
	}

	public eSolid3D(eEntities ent)
	{
		if (ent.GetType() == typeof(eSolid3D))
		{
			Triangles = new List<Triangle3D>();
			for (int i = 0; i <= ((eSolid3D)ent).Triangles.Count - 1; i++)
			{
				Triangles.Add(new Triangle3D(((eSolid3D)ent).Triangles[i]));
				Vertice.Add(new Pnt3D(Triangles[i].FirstPoint));
				Vertice.Add(new Pnt3D(Triangles[i].SecondPoint));
				Vertice.Add(new Pnt3D(Triangles[i].ThirdPoint));
			}
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public eSolid3D(List<Triangle3D> triangles)
	{
		Triangles = new List<Triangle3D>();
		Vertice.Clear();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(triangles[i].ThirdPoint));
		}
		Update();
	}

	public eSolid3D(List<Triangle3D> triangles, Color Color)
	{
		Triangles = new List<Triangle3D>();
		Triangles.Clear();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(triangles[i].ThirdPoint));
		}
		dispColor = Color;
		Update();
	}

	public static eSolid3D DecodeSolid(List<string> Codes)
	{
		eSolid3D eSolid3D2 = new eSolid3D();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eSolid3D2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eSolid3D2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eSolid3D2.Update();
		return eSolid3D2;
	}
}
