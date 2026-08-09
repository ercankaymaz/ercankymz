using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileDepth : buSerilization
{
	public ProfileDepthModeType Type = ProfileDepthModeType.EachLayerStep;

	public double SafeMoveAbsolute = 100.0;

	public double SafeMoveRelative = 2.0;

	public bool SaveMoveAbsouluteEnable = false;

	public bool SaveMoveRelativeEnable = true;

	public ProfileDepth()
	{
	}

	public ProfileDepth(ProfileDepth data)
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
