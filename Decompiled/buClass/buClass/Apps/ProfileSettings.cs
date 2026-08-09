using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileSettings : buSerilization
{
	public int MaterialTranspancy = 250;

	public Color SupportBlockZColor = Color.Yellow;

	public Color SupportBlockYColor = Color.Blue;

	public bool FindToolAuto = true;

	public ToolFindType FindToolType = ToolFindType.MostSmall;

	public ProfileYAxisDirection YDirection = ProfileYAxisDirection.NegativeDirection;

	public ProfileFindSurfaceType SurfaceFindType = ProfileFindSurfaceType.Top;

	public ProfileSettings()
	{
	}

	public ProfileSettings(ProfileSettings data)
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
