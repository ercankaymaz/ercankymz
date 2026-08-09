using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopTapPars : buSerilization5
{
	public marbleCountertopTapData Data = new marbleCountertopTapData();

	public buEntity ContourEntity = null;

	public buEntity CollapseEntity = null;

	public List<Entity> EntityAngleText = new List<Entity>();

	public List<Entity> EntityDimension = new List<Entity>();

	public List<Entity> EntityLocation = new List<Entity>();

	public List<Point3D> EntityPoints = new List<Point3D>();

	public static List<string> Captions = new List<string>();

	public marbleCountertopTapPars()
	{
	}

	public marbleCountertopTapPars(marbleCountertopTapPars data)
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
		Data = new marbleCountertopTapData(data.Data);
		if (data.ContourEntity != null)
		{
			buEntity.Copy(data.ContourEntity, ref ContourEntity);
		}
		if (data.CollapseEntity != null)
		{
			buEntity.Copy(data.CollapseEntity, ref CollapseEntity);
		}
	}

	public override string ToString()
	{
		return "TapDiameter : " + Data.Enable + Data.TapDiameter + " , PositionX : " + Data.PositionX + " , PositionY : " + Data.PositionY + " , Tool : " + Data.ToolType;
	}
}
