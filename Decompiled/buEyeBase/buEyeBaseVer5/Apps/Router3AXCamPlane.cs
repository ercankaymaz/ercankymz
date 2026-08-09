using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXCamPlane : buSerilization5
{
	public buEntity entityPlaneBottom = null;

	public buEntity entityPlaneBottomText = null;

	public buEntity entityPlaneTop = null;

	public buEntity entityPlaneTopText = null;

	public buEntity entityPlaneClearance = null;

	public buEntity entityPlaneClearanceText = null;

	public buEntity entityPlaneRetract = null;

	public buEntity entityPlaneRetractText = null;

	public Router3AXCamPlane()
	{
	}

	public Router3AXCamPlane(Router3AXCamPlane data)
	{
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
		if (data.entityPlaneBottom != null)
		{
			buEntity.Copy(data.entityPlaneBottom, ref entityPlaneBottom);
		}
		if (data.entityPlaneBottomText != null)
		{
			buEntity.Copy(data.entityPlaneBottomText, ref entityPlaneBottomText);
		}
		if (data.entityPlaneTop != null)
		{
			buEntity.Copy(data.entityPlaneTop, ref entityPlaneTop);
		}
		if (data.entityPlaneTopText != null)
		{
			buEntity.Copy(data.entityPlaneTopText, ref entityPlaneTopText);
		}
		if (data.entityPlaneClearance != null)
		{
			buEntity.Copy(data.entityPlaneClearance, ref entityPlaneClearance);
		}
		if (data.entityPlaneClearanceText != null)
		{
			buEntity.Copy(data.entityPlaneClearanceText, ref entityPlaneClearanceText);
		}
		if (data.entityPlaneRetract != null)
		{
			buEntity.Copy(data.entityPlaneRetract, ref entityPlaneRetract);
		}
		if (data.entityPlaneRetractText != null)
		{
			buEntity.Copy(data.entityPlaneRetractText, ref entityPlaneRetractText);
		}
	}

	public static void Decode(List<string> AL, ref FoamBlock Item)
	{
	}

	public static ArrayList ToDef(FoamBlock refItem, int Space)
	{
		return new ArrayList();
	}
}
