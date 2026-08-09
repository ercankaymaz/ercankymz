using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferBothSidePars : buSerilization5
{
	public marbleChamferBothSideData DataChamfer = new marbleChamferBothSideData();

	public List<buEntity> RefEntities = new List<buEntity>();

	public Entity entSolid = null;

	public List<Entity> EntityAngleText = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public marbleChamferBothSidePars()
	{
	}

	public marbleChamferBothSidePars(marbleChamferBothSidePars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		return "Enable : " + DataChamfer.Enable + " , Top : " + DataChamfer.TopEnable + " , BottomEnable : " + DataChamfer.BottomEnable + " , TopAngle : " + DataChamfer.TopAngle + " , BottomAngle : " + DataChamfer.BottomAngle;
	}
}
