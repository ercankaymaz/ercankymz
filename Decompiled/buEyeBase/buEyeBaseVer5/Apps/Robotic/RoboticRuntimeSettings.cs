using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RoboticRuntimeSettings : buSerilization5
{
	public Pnt3D LeadInPoint = new Pnt3D();

	public Pnt3D LeadOutPoint = new Pnt3D();

	public Pnt3D SafeDistanceInPoint = new Pnt3D();

	public Pnt3D SafeDistanceOutPoint = new Pnt3D();

	public bool isFirst = false;

	public bool isLast = false;

	public RoboticRuntimeSettings()
	{
	}

	public RoboticRuntimeSettings(RoboticRuntimeSettings data)
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
