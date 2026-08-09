using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleScreenCaptureSettings : buSerilization5
{
	public int SC1Left = 0;

	public int SC1Top = 0;

	public int SC1Width = 1920;

	public int SC1Height = 1080;

	public bool SC1AutoSave = false;

	public bool SC1Enable = true;

	public int SC2Left = 0;

	public int SC2Top = 0;

	public int SC2Width = 1920;

	public int SC2Height = 1080;

	public bool SC2AutoSave = false;

	public bool SC2Enable = true;

	public int SC3Left = 0;

	public int SC3Top = 0;

	public int SC3Width = 1920;

	public int SC3Height = 1080;

	public bool SC3AutoSave = false;

	public bool SC3Enable = true;

	public int SC4Left = 0;

	public int SC4Top = 0;

	public int SC4Width = 1920;

	public int SC4Height = 1080;

	public bool SC4AutoSave = false;

	public bool SC4Enable = true;

	public int SC5Left = 0;

	public int SC5Top = 0;

	public int SC5Width = 1920;

	public int SC5Height = 1080;

	public bool SC5AutoSave = false;

	public bool SC5Enable = true;

	public MarbleScreenCaptureSettings()
	{
	}

	public MarbleScreenCaptureSettings(MarbleScreenCaptureSettings data)
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

	public static void Copy(MarbleScreenCaptureSettings Source, ref MarbleScreenCaptureSettings Target)
	{
		Target = new MarbleScreenCaptureSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
