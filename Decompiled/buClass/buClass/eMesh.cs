using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class eMesh : eEntities
{
	public List<TriangleIndex> TriIndex = new List<TriangleIndex>();

	public eMesh()
	{
	}

	public eMesh(eEntities ent)
	{
		TriIndex.Clear();
		for (int i = 0; i <= ((eMesh)ent).TriIndex.Count - 1; i++)
		{
			TriIndex.Add(new TriangleIndex(((eMesh)ent).TriIndex[i]));
		}
		Vertice.Clear();
		Vertice = new List<Pnt3D>();
		for (int j = 0; j <= ent.Vertice.Count - 1; j++)
		{
			Vertice.Add(new Pnt3D(ent.Vertice[j]));
		}
		if (!(ent.GetType() == typeof(eMesh)))
		{
			return;
		}
		if (((eMesh)ent).Triangles != null)
		{
			if (Triangles == null)
			{
				Triangles = new List<Triangle3D>();
			}
			Triangles.Clear();
			Triangles = new List<Triangle3D>();
			for (int k = 0; k <= ((eMesh)ent).Triangles.Count - 1; k++)
			{
				Triangles.Add(new Triangle3D(((eMesh)ent).Triangles[k]));
				Vertice.Add(new Pnt3D(Triangles[k].FirstPoint));
				Vertice.Add(new Pnt3D(Triangles[k].SecondPoint));
				Vertice.Add(new Pnt3D(Triangles[k].ThirdPoint));
			}
		}
		eEntities.CopyBase(ent, this);
		Update();
	}

	public eMesh(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= trianglesindex.Count - 1; i++)
		{
			TriIndex.Add(new TriangleIndex(trianglesindex[i]));
		}
		for (int j = 0; j <= vertices.Count - 1; j++)
		{
			Vertice.Add(new Pnt3D(vertices[j]));
		}
		Update();
	}

	public eMesh(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices, Color Color)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= trianglesindex.Count - 1; i++)
		{
			TriIndex.Add(new TriangleIndex(trianglesindex[i]));
		}
		for (int j = 0; j <= vertices.Count - 1; j++)
		{
			Vertice.Add(new Pnt3D(vertices[j]));
		}
		dispColor = Color;
		Update();
	}

	public static eMesh DecodeMesh(List<string> Codes)
	{
		eMesh eMesh2 = new eMesh();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eMesh2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eMesh2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eMesh2.Update();
		return eMesh2;
	}
}
