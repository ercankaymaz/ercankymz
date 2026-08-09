using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SurfaceFromProfileAndHeight : buSerilization
{
	public List<Pnt3D> ContourPoints = new List<Pnt3D>();

	public List<List<Pnt3D>> XDirPoints = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> YDirPoints = new List<List<Pnt3D>>();

	public eEntities ContourEntity = new eEntities();

	public List<eEntities> XDirEntities = new List<eEntities>();

	public List<eEntities> YDirEntities = new List<eEntities>();

	public double ZHeightValue = 0.0;

	public ZHeightProfileType ZType = ZHeightProfileType.Linear;

	public SurfaceFromProfileAndHeight()
	{
	}

	public SurfaceFromProfileAndHeight(SurfaceFromProfileAndHeight data)
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
		ContourPoints.Clear();
		ContourPoints = new List<Pnt3D>();
		Pnt3D.Copy(data.ContourPoints, ref ContourPoints);
		XDirPoints.Clear();
		XDirPoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.XDirPoints, ref XDirPoints);
		YDirPoints.Clear();
		YDirPoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.YDirPoints, ref YDirPoints);
		eEntities.CopyEntity(data.ContourEntity, ref ContourEntity);
		eEntities.CopyEntities(data.XDirEntities, ref XDirEntities);
		eEntities.CopyEntities(data.YDirEntities, ref YDirEntities);
	}
}
