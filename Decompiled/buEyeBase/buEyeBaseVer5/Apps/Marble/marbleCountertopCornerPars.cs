using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCornerPars : buSerilization5
{
	public marbleCountertopCornerData Data = new marbleCountertopCornerData();

	public Entity CornerJointEntity = null;

	public buEntity CornerEntity = null;

	public List<Point3D> EntityPoints = new List<Point3D>();

	public Point3D CornerPoint = null;

	public static List<string> Captions = new List<string>();

	public marbleCountertopCornerPars()
	{
	}

	public marbleCountertopCornerPars(marbleCountertopCornerPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		Data = new marbleCountertopCornerData(data.Data);
		if (data.CornerEntity != null)
		{
			buEntity.Copy(data.CornerEntity, ref CornerEntity);
		}
	}

	public override string ToString()
	{
		return "Corner : " + Data.Enable + " , Width: " + Data.CornerWidth + " , Heigth: " + Data.CornerHeight;
	}
}
