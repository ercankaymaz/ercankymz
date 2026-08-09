using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXRuntimeSettings : buSerilization5
{
	public bool SelectMode = false;

	public bool FromFileKeepRatio = true;

	public string pathFromFile = "C:\\";

	public double MaterialHeight = 800.0;

	public double MaterialWidth = 2000.0;

	public double MaterialDepth = 20.0;

	public int SimStep = 1;

	public ShapeRuntimeData ShapeDataParameters = new ShapeRuntimeData();

	public List<string> SequenceList = new List<string>();

	public Router3AXRuntimeSettings()
	{
	}

	public Router3AXRuntimeSettings(Router3AXRuntimeSettings data)
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
		ShapeDataParameters = new ShapeRuntimeData(data.ShapeDataParameters);
	}
}
