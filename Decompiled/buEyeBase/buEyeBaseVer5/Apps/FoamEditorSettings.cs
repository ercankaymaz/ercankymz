using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamEditorSettings : buSerilization5
{
	public bool ShowRightVirtualDrawing = false;

	public bool ShowBottomVirtualDrawing = false;

	public bool ShowBottomRightVirtualDrawing = false;

	public double RigthVirtualDrawingDistance = 20.0;

	public double BottomVirtualDrawingDistance = 20.0;

	public Color VirtualColor = Color.LightGreen;

	public FoamEditorSettings()
	{
	}

	public FoamEditorSettings(FoamEditorSettings data)
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
