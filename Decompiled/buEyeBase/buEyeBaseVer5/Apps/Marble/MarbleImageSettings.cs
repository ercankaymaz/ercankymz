using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleImageSettings : buSerilization5
{
	public double PixelToMmX = 3.0;

	public double PixelToMmY = 3.0;

	public bool SheetInnerMakeItHoleas3D = false;

	public static List<string> Captions = new List<string>();

	public MarbleImageSettings()
	{
	}

	public MarbleImageSettings(MarbleImageSettings data)
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

	public static void Copy(MarbleImageSettings Source, ref MarbleImageSettings Target)
	{
		Target = new MarbleImageSettings(Source);
	}

	public override string ToString()
	{
		return "PixelToMmX: " + PixelToMmX + " - PixelToMmY: " + PixelToMmY;
	}
}
