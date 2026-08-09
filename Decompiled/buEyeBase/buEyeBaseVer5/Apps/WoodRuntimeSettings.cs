using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodRuntimeSettings : buSerilization5
{
	public bool SelectMode = false;

	public ShapeTypes ShapeType = ShapeTypes.Rectangle;

	public planeBoxNames LastPlane = planeBoxNames.Top;

	public MaterialCornerLocation LastCorner = MaterialCornerLocation.LeftBottom;

	public ShapeRuntimeData ShapeDataParameters = new ShapeRuntimeData();

	public WoodRuntimeSettings()
	{
	}

	public WoodRuntimeSettings(WoodRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
