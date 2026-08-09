using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleDisplaySettings : buSerilization5
{
	public MarbleDisplayViewportSettings ViewportSettings = new MarbleDisplayViewportSettings();

	public bool ShowCamG1Entities = true;

	public bool ShowCamG0Entities = true;

	public bool ShowCamPlungeEntities = true;

	public bool ShowCamLeaveEntities = true;

	public bool ShowCamLeadInOutEntities = true;

	public bool ShowCamConnectionEntities = true;

	public bool DrawItemSizeEntities = true;

	public bool buttonColorSolidEnable = false;

	public bool PartMaterialSkinEnable = false;

	public bool WoodMaterialSkinEnable = true;

	public int ViewPanAmount = 15;

	public static List<string> Captions = new List<string>();

	public MarbleDisplaySettings()
	{
	}

	public MarbleDisplaySettings(MarbleDisplaySettings data)
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

	public static void Copy(MarbleDisplaySettings Source, ref MarbleDisplaySettings Target)
	{
		Target = new MarbleDisplaySettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
