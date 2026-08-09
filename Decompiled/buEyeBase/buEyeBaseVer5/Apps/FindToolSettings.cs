using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class FindToolSettings
{
	public double Y1Y2ZoneSelectionLimit = 500.0;

	public planeBoxNames Plane = planeBoxNames.Top;

	public bool SetAsUsed = false;

	public bool IgnoreUsedInfo = false;

	public bool SelectVerticalTools = false;

	public bool SelectHorizontalTools = false;

	public int StartToolIndex = -1;

	public int MaxVerticalToolCount = -1;

	public FindToolSettings()
	{
	}

	public FindToolSettings(FindToolSettings data)
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
