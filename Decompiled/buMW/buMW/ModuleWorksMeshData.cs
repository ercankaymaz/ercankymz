using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buMW;

[Serializable]
public class ModuleWorksMeshData : buSerilization
{
	public List<TriangleIndex> Triangles = new List<TriangleIndex>();

	public List<Pnt3D> Vertices = new List<Pnt3D>();

	public List<Pnt3D> Normals = new List<Pnt3D>();

	public ModuleWorksMeshData()
	{
	}

	public ModuleWorksMeshData(ModuleWorksMeshData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		Normals.Clear();
		Vertices.Clear();
		Triangles.Clear();
		Pnt3D.Copy(data.Normals, ref Normals);
		Pnt3D.Copy(data.Vertices, ref Vertices);
		for (int j = 0; j <= data.Triangles.Count - 1; j++)
		{
			TriangleIndex item = new TriangleIndex(data.Triangles[j].V1, data.Triangles[j].V2, data.Triangles[j].V3);
			Triangles.Add(item);
		}
	}

	public ModuleWorksMeshData(List<Pnt3D> vertices, List<TriangleIndex> triangles, List<Pnt3D> normals)
	{
		Normals.Clear();
		Vertices.Clear();
		Triangles.Clear();
		Pnt3D.Copy(normals, ref Normals);
		Pnt3D.Copy(vertices, ref Vertices);
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			TriangleIndex item = new TriangleIndex(triangles[i].V1, triangles[i].V2, triangles[i].V3);
			Triangles.Add(item);
		}
	}
}
