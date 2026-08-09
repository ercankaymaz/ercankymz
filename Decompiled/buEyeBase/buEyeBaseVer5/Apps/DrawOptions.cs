using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrawOptions : buSerilization5
{
	public bool DrawAll = false;

	public bool DeleteStock = false;

	public bool DeleteTool = false;

	public bool DeletePlane = false;

	public bool DrawPreview = false;

	public DrawOptions()
	{
	}

	public DrawOptions(bool drawall, bool deletestock = false, bool deletetool = false, bool drawpreview = true)
	{
		DrawAll = drawall;
		DeleteStock = deletestock;
		DeleteTool = deletetool;
		DrawPreview = drawpreview;
	}

	public DrawOptions(DrawOptions data)
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
