using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCollapsePars : buSerilization5
{
	public bool Enable = false;

	public double Offset = 0.0;

	public double Depth = 2.0;

	public double Step = 2.0;

	public buEntity ContourEntity = null;

	public MarbleToolType ToolType = MarbleToolType.Milling;

	public OutsideInsideType Direction = OutsideInsideType.Outside;

	public static List<string> Captions = new List<string>();

	public marbleCollapsePars()
	{
	}

	public marbleCollapsePars(marbleCollapsePars data)
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
	}

	public override string ToString()
	{
		return "Enable : " + Enable + " , Offset : " + Offset + " , Depth : " + Depth;
	}
}
