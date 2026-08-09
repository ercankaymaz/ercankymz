using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolDrawVertices : buSerilization
{
	public List<Triangle3D> TrianglesCutter = new List<Triangle3D>();

	public List<Triangle3D> TrianglesLength = new List<Triangle3D>();

	public List<Triangle3D> TrianglesSphere = new List<Triangle3D>();

	public List<Triangle3D> TrianglesHolder = new List<Triangle3D>();

	public List<Triangle3D> TrianglesArbor = new List<Triangle3D>();

	public List<List<Pnt3D>> Vertices = new List<List<Pnt3D>>();

	public ToolDrawVertices()
	{
	}

	public ToolDrawVertices(ToolDrawVertices data)
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
		TrianglesHolder.Clear();
		TrianglesHolder = new List<Triangle3D>();
		Triangle3D.Copy(data.TrianglesHolder, ref TrianglesHolder);
		TrianglesCutter.Clear();
		TrianglesCutter = new List<Triangle3D>();
		Triangle3D.Copy(data.TrianglesCutter, ref TrianglesCutter);
		TrianglesArbor.Clear();
		TrianglesArbor = new List<Triangle3D>();
		Triangle3D.Copy(data.TrianglesArbor, ref TrianglesArbor);
		TrianglesLength.Clear();
		TrianglesLength = new List<Triangle3D>();
		Triangle3D.Copy(data.TrianglesLength, ref TrianglesLength);
		TrianglesSphere.Clear();
		TrianglesSphere = new List<Triangle3D>();
		Triangle3D.Copy(data.TrianglesSphere, ref TrianglesSphere);
		Vertices.Clear();
		Vertices = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.Vertices, ref Vertices);
	}
}
