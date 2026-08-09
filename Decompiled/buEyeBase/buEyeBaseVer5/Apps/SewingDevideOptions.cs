using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingDevideOptions : buSerilization5
{
	public double PointThickness = 5.0;

	public Color PointColor = Color.Blue;

	public string PointLayerName = "";

	public double DrawigThickness = 1.0;

	public Color DrawingColor = Color.Red;

	public string DrawingLayerName = "";

	public int StartIndex = -1;

	public int EndIndex = -1;

	public bool ProtectEntityStitchLen = false;

	public bool ApplyNewLenUpToEnd = false;

	public SewingDevideOptions()
	{
	}

	public SewingDevideOptions(SewingDevideOptions data)
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
