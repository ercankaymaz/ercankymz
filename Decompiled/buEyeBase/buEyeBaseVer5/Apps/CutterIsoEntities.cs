using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterIsoEntities : buSerilization
{
	public List<List<Entity>> InnerCenterEntities = new List<List<Entity>>();

	public List<List<Entity>> DirectionCenterEntities = new List<List<Entity>>();

	public List<List<Entity>> InnerPlotterCenterEntities = new List<List<Entity>>();

	public List<List<Entity>> InnerPlotterAuxCenterEntities = new List<List<Entity>>();

	public List<Entity> TextCenterEntities = new List<Entity>();

	public List<Entity> NotchCenterEntities = new List<Entity>();

	public List<Entity> DrillMainEntities = new List<Entity>();

	public List<Entity> DrillAuxEntities = new List<Entity>();

	public List<Entity> OutsideCenterEntities = new List<Entity>();

	public CutterIsoEntities()
	{
	}

	public CutterIsoEntities(CutterIsoEntities data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
}
