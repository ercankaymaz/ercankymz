using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutRuntimeSettings : buSerilization5
{
	public bool CollisionCheck = false;

	public bool StepRun = true;

	public int SimStep = 1;

	public PanelCutRuntimeSettings()
	{
	}

	public PanelCutRuntimeSettings(PanelCutRuntimeSettings data)
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
