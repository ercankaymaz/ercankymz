using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCavityPars : buSerilization5
{
	public marbleCountertopCavityData Data = new marbleCountertopCavityData();

	public List<buEntity> LineEntities = null;

	public List<buEntity> SlotEntities = null;

	public List<Entity> EntityAngleText = new List<Entity>();

	public List<Entity> EntityDimension = new List<Entity>();

	public List<Entity> EntityLocation = new List<Entity>();

	public List<Point3D> EntityPoints = new List<Point3D>();

	public List<Entity> entitySolidCavity = null;

	public static List<string> Captions = new List<string>();

	public marbleCountertopCavityPars()
	{
	}

	public marbleCountertopCavityPars(marbleCountertopCavityPars data)
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
		if (data.LineEntities != null)
		{
			buEntity.Copy(data.LineEntities, ref LineEntities);
		}
	}

	public override string ToString()
	{
		return "Enable : " + Data.Enable + " , Length : " + Data.CavityLength + " , Depth : " + Data.CavityDepth + " , Tool : " + Data.ToolType;
	}
}
