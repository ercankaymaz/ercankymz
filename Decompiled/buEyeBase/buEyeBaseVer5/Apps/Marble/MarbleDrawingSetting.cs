using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleDrawingSetting : buSerilization5
{
	public double SolidOnlineDrawDeviation = 5.0;

	public double WireframeOnlineDrawZOffset = 2.0;

	public double DirectionArrowZOffset = 2.0;

	public double DirectionArrowWidth = 40.0;

	public double DirectionArrowHeight = 16.0;

	public bool CamLeavePlungeAsArrowDraw = true;

	public double CamArrowConeLength = 5.0;

	public double CamArrowBodyDiameter = 2.0;

	public double CamArrowConeDiameter = 3.0;

	public bool DrawMaterialDimension = false;

	public static List<string> Captions = new List<string>();

	public MarbleDrawingSetting()
	{
	}

	public MarbleDrawingSetting(MarbleDrawingSetting data)
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

	public static void Copy(MarbleDrawingSetting Source, ref MarbleDrawingSetting Target)
	{
		Target = new MarbleDrawingSetting(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
