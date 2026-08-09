using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileDrawings : buSerilization5
{
	public Entity SolidEntity = null;

	public List<buEntity> OutterEntitites = new List<buEntity>();

	public List<List<buEntity>> InnerEntities = new List<List<buEntity>>();

	public List<Point3D> OutterPoints = new List<Point3D>();

	public List<List<Point3D>> InnerPoints = new List<List<Point3D>>();

	public ProfileDrawings()
	{
	}

	public ProfileDrawings(ProfileDrawings data)
	{
		if (data == null)
		{
			return;
		}
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		if (data.SolidEntity != null)
		{
			SolidEntity = buVector5.CopyEntities(data.SolidEntity);
		}
		if (data.OutterPoints != null)
		{
			OutterPoints.Clear();
			OutterPoints = new List<Point3D>();
			buVector5.ToPoint3D(data.OutterPoints, ref OutterPoints);
		}
		if (data.InnerPoints != null)
		{
			InnerPoints.Clear();
			InnerPoints = new List<List<Point3D>>();
			buVector5.ToPoint3D(data.InnerPoints, ref InnerPoints);
		}
		if (data.OutterEntitites != null)
		{
			OutterEntitites.Clear();
			OutterEntitites = new List<buEntity>();
			buEntity.Copy(data.OutterEntitites, ref OutterEntitites);
		}
		if (data.InnerEntities != null)
		{
			InnerEntities.Clear();
			InnerEntities = new List<List<buEntity>>();
			buEntity.Copy(data.InnerEntities, ref InnerEntities);
		}
	}
}
