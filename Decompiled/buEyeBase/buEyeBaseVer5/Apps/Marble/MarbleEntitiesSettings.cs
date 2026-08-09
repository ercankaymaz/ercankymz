using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleEntitiesSettings : buSerilization5
{
	public double ContourDeviationResolution = 0.05;

	public double LatheDeviationResolution = 0.05;

	public double ColumnsDeviationResolution = 0.05;

	public double EngravingDeviationResolution = 0.05;

	public double ProfileDeviationResolution = 0.05;

	public double SweepDeviationResolution = 0.05;

	public double SolidDeviationResolution = 0.05;

	public Color DimensionColor = Color.Lime;

	public double DimensionThickness = 3.0;

	public double DimensionTextHeight = 30.0;

	public static List<string> Captions = new List<string>();

	public MarbleEntitiesSettings()
	{
	}

	public MarbleEntitiesSettings(MarbleEntitiesSettings data)
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

	public static void Copy(MarbleEntitiesSettings Source, ref MarbleEntitiesSettings Target)
	{
		Target = new MarbleEntitiesSettings(Source);
	}

	public override string ToString()
	{
		return "ContourDeviationResolution: " + ContourDeviationResolution;
	}
}
