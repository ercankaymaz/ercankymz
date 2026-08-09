using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class SortResolutionSet : buSerilization5
{
	public double GapDistance = 0.02;

	public double SortResolution = 0.05;

	public double MinProfileFilterLength = 0.0;

	public bool ConnectSmallGap = true;

	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public SortResolutionSet()
	{
	}

	public SortResolutionSet(SortResolutionSet data)
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
