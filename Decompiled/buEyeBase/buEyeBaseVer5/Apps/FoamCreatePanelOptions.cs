using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamCreatePanelOptions : buSerilization5
{
	public bool DrawAll = false;

	public bool DeleteSort = false;

	public bool DeleteTool = false;

	public bool DrawPreview = false;

	public FoamCreatePanelOptions()
	{
	}

	public FoamCreatePanelOptions(bool drawall, bool deletesort, bool deletetool, bool drawpreview)
	{
		DrawAll = drawall;
		DeleteSort = deletesort;
		DeleteTool = deletetool;
		DrawPreview = drawpreview;
	}

	public FoamCreatePanelOptions(FoamCreatePanelOptions data)
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
