using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleControlColorSettings : buSerilization5
{
	public Color colorDataFocus = Color.LightGreen;

	public Color colorAxesDisable = Color.Red;

	public Color colorAxesNoHoming = Color.DarkOrange;

	public Color colorCoordinateColor = Color.Black;

	public static List<string> Captions = new List<string>();

	public MarbleControlColorSettings()
	{
	}

	public MarbleControlColorSettings(MarbleControlColorSettings data)
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

	public static void Copy(MarbleControlColorSettings Source, ref MarbleControlColorSettings Target)
	{
		Target = new MarbleControlColorSettings(Source);
	}

	public override string ToString()
	{
		return "colorDataFocus: " + colorDataFocus.ToString();
	}
}
