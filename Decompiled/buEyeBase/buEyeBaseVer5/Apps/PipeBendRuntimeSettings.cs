using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendRuntimeSettings : buSerilization5
{
	public string pathPipeBendJob = Application.StartupPath;

	public int SimStep = 1;

	public PipeBendRuntimeSettings()
	{
	}

	public PipeBendRuntimeSettings(PipeBendRuntimeSettings data)
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
