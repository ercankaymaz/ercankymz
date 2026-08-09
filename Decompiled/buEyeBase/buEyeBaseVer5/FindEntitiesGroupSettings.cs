using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class FindEntitiesGroupSettings : buSerilization5
{
	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public SortingNextGroupFindRulesType NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public double SortResolution = 0.05;

	public ClockDirectionType ClockDirection = ClockDirectionType.CCW;

	public ClockDirectionType InsideClockDirection = ClockDirectionType.CCW;

	public FindEntitiesGroupSettings()
	{
	}

	public FindEntitiesGroupSettings(SortingIntersectionRulesType intersectionRules, SortingNextGroupFindRulesType nextFroupRules, double sortResolution, ClockDirectionType clockDirection, ClockDirectionType insideClockDirection)
	{
		IntersectionRules = intersectionRules;
		NextFroupRules = nextFroupRules;
		SortResolution = sortResolution;
		ClockDirection = clockDirection;
		InsideClockDirection = insideClockDirection;
	}

	public FindEntitiesGroupSettings(FindEntitiesGroupSettings data)
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

	public override string ToString()
	{
		return ClockDirection.ToString();
	}
}
