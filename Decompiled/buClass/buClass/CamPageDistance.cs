using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamPageDistance : buSerilization
{
	public bool Safe = true;

	public bool SafeSmall = false;

	public bool StepUp = false;

	public bool Air = false;

	public bool IncrementalSafe = false;

	public CamPageDistance()
	{
	}

	public CamPageDistance(CamPageDistance data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
