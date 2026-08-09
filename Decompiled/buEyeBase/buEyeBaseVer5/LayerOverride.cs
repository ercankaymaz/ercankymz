using System;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class LayerOverride : buSerilization5
{
	public string LayerOriginalName = "";

	public string LayerNewName = "";

	public string LayerExtraName = "";

	public Color LayerNewColor = Color.Blue;

	public LayerOverride()
	{
	}

	public LayerOverride(LayerOverride data)
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
}
