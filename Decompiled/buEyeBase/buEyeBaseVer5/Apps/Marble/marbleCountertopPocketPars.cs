using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopPocketPars : buSerilization5
{
	public marbleCountertopPocketData Data = new marbleCountertopPocketData();

	public buEntity PocketEntity = null;

	public List<Point3D> EntityPoints = new List<Point3D>();

	public static List<string> Captions = new List<string>();

	public marbleCountertopPocketPars()
	{
	}

	public marbleCountertopPocketPars(marbleCountertopPocketPars data)
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
		Data = new marbleCountertopPocketData(data.Data);
		if (data.PocketEntity != null)
		{
			buEntity.Copy(data.PocketEntity, ref PocketEntity);
		}
	}

	public override string ToString()
	{
		return "Pocket : " + Data.Enable + "Dis: " + Data.PocketDistance + " , Width: " + Data.PocketWidth + " , Heigth: " + Data.PocketHeight;
	}
}
