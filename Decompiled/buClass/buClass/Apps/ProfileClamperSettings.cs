using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileClamperSettings : buSerilization
{
	public double MinDistanceFor2Clamper = 250.0;

	public double MaxDistanceFor2Clamper = 3000.0;

	public double MaxFreeDistanceForProfile = 400.0;

	public double ClamperWidth = 100.0;

	public double OperationMinDistance = 20.0;

	public double StartOffset = 50.0;

	public double EndOffset = 50.0;

	public ProfileClamperSettings()
	{
	}

	public ProfileClamperSettings(ProfileClamperSettings data)
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
