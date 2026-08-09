using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class GrindingSettings : buSerilization
{
	public double EntityCathResolutionPersentage = 2.0;

	public double GlassThickness = 10.0;

	public OffsetCornerType OffsetCornerType = OffsetCornerType.Line;

	public GrindingSettings()
	{
	}

	public GrindingSettings(GrindingSettings data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
