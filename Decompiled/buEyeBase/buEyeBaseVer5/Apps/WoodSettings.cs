using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodSettings : buSerilization5
{
	public bool ShowOperationButton = false;

	public double MaterialHeight = 800.0;

	public double MaterialWidth = 2000.0;

	public double MaterialDepth = 20.0;

	public Color colorPanel = Color.Tan;

	public Color colorOperation = Color.Blue;

	public Color colorOperationDisable = Color.DarkGray;

	public bool FromFileKeepRatio = true;

	public string pathFromFile = "C:\\";

	public WoodSettings()
	{
	}

	public WoodSettings(WoodSettings data)
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
}
