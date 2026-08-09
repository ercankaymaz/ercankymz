using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolDrawMeshes : buSerilization, IDisposable
{
	public List<TriangleIndex> TrianglesIndexCutter = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeCutter = new List<Pnt3D>();

	public List<TriangleIndex> TrianglesIndexLength = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeLength = new List<Pnt3D>();

	public List<TriangleIndex> TrianglesIndexSphere = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeSphere = new List<Pnt3D>();

	public List<TriangleIndex> TrianglesIndexHolder = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeHolder = new List<Pnt3D>();

	public List<TriangleIndex> TrianglesIndexArbor = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeArbor = new List<Pnt3D>();

	public List<TriangleIndex> TrianglesIndexAgregate = new List<TriangleIndex>();

	public List<Pnt3D> TrianglesVerticeAgregate = new List<Pnt3D>();

	private bool Disposed = false;

	public ToolDrawMeshes()
	{
	}

	public ToolDrawMeshes(ToolDrawMeshes data)
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
		TrianglesIndexArbor.Clear();
		TrianglesIndexArbor = new List<TriangleIndex>();
		TriangleIndex.Copy(data.TrianglesIndexArbor, ref TrianglesIndexArbor);
		TrianglesIndexCutter.Clear();
		TrianglesIndexCutter = new List<TriangleIndex>();
		TriangleIndex.Copy(data.TrianglesIndexCutter, ref TrianglesIndexCutter);
		TrianglesIndexHolder.Clear();
		TrianglesIndexHolder = new List<TriangleIndex>();
		TriangleIndex.Copy(data.TrianglesIndexHolder, ref TrianglesIndexHolder);
		TrianglesIndexLength.Clear();
		TrianglesIndexLength = new List<TriangleIndex>();
		TriangleIndex.Copy(data.TrianglesIndexLength, ref TrianglesIndexLength);
		TrianglesIndexSphere.Clear();
		TrianglesIndexSphere = new List<TriangleIndex>();
		TriangleIndex.Copy(data.TrianglesIndexSphere, ref TrianglesIndexSphere);
		TrianglesVerticeArbor.Clear();
		TrianglesVerticeArbor = new List<Pnt3D>();
		Pnt3D.Copy(data.TrianglesVerticeArbor, ref TrianglesVerticeArbor);
		TrianglesVerticeCutter.Clear();
		TrianglesVerticeCutter = new List<Pnt3D>();
		Pnt3D.Copy(data.TrianglesVerticeCutter, ref TrianglesVerticeCutter);
		TrianglesVerticeHolder.Clear();
		TrianglesVerticeHolder = new List<Pnt3D>();
		Pnt3D.Copy(data.TrianglesVerticeHolder, ref TrianglesVerticeHolder);
		TrianglesVerticeLength.Clear();
		TrianglesVerticeLength = new List<Pnt3D>();
		Pnt3D.Copy(data.TrianglesVerticeLength, ref TrianglesVerticeLength);
		TrianglesVerticeSphere.Clear();
		TrianglesVerticeSphere = new List<Pnt3D>();
		Pnt3D.Copy(data.TrianglesVerticeSphere, ref TrianglesVerticeSphere);
	}

	~ToolDrawMeshes()
	{
		Dispose(disposing: false);
	}

	public void Clear()
	{
		TrianglesIndexCutter.Clear();
		TrianglesIndexArbor.Clear();
		TrianglesIndexHolder.Clear();
		TrianglesIndexLength.Clear();
		TrianglesIndexSphere.Clear();
		TrianglesVerticeArbor.Clear();
		TrianglesVerticeCutter.Clear();
		TrianglesVerticeHolder.Clear();
		TrianglesVerticeLength.Clear();
		TrianglesVerticeSphere.Clear();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (!Disposed)
		{
			if (disposing)
			{
				TrianglesIndexCutter.Clear();
				TrianglesIndexArbor.Clear();
				TrianglesIndexHolder.Clear();
				TrianglesIndexLength.Clear();
				TrianglesIndexSphere.Clear();
				TrianglesVerticeArbor.Clear();
				TrianglesVerticeCutter.Clear();
				TrianglesVerticeHolder.Clear();
				TrianglesVerticeLength.Clear();
				TrianglesVerticeSphere.Clear();
			}
			Disposed = true;
		}
	}
}
