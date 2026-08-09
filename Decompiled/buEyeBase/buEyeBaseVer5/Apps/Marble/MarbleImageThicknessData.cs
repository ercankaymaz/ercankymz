using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleImageThicknessData : buSerilization5
{
	public double XOffset = 0.0;

	public double YOffset = 0.0;

	public double DeltaWidth = 0.0;

	public double DeltaHeight = 0.0;

	public double Thickness = 0.0;

	public string Explanation = "";

	public MarbleImageThicknessData()
	{
	}

	public MarbleImageThicknessData(MarbleImageThicknessData data)
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

	public MarbleImageThicknessData(double xoffset, double yoffset, double deltawidth, double deltaheight, double thickness, string explain)
	{
		XOffset = xoffset;
		YOffset = yoffset;
		DeltaWidth = deltawidth;
		DeltaHeight = deltaheight;
		Thickness = thickness;
		Explanation = explain;
	}
}
