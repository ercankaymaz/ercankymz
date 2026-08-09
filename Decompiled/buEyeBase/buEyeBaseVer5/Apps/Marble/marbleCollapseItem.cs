using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCollapseItem : buSerilization5
{
	public bool Enable = false;

	public double Offset = 0.0;

	public double Depth = 2.0;

	public double Step = 2.0;

	public int EntityIndex = -1;

	public int ID = -1;

	public int ItemID = -1;

	public int IndexInsideEntity = -1;

	public bool isOutsideEntity = false;

	public List<buEntity> refEntity = null;

	public List<buEntity> ContourEntity = null;

	public MarbleToolType ToolType = MarbleToolType.Milling;

	public OutsideInsideType Direction = OutsideInsideType.Inside;

	public Entity entSolid = null;

	public static List<string> Captions = new List<string>();

	public marbleCollapseItem()
	{
	}

	public marbleCollapseItem(marbleCollapseItem data)
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
		if (data.ContourEntity != null)
		{
			buEntity.Copy(data.ContourEntity, ref ContourEntity);
		}
		if (data.refEntity != null)
		{
			buEntity.Copy(data.refEntity, ref refEntity);
		}
	}

	public override string ToString()
	{
		return "Offset : " + Offset + " , Depth : " + Depth;
	}
}
