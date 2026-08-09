using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesSetting : buSerilization5
{
	public bool FindProblems = true;

	public bool FixProblems = false;

	public bool isSameMoreThanOneCheck = true;

	public bool isEntityLengthSmall = true;

	public bool isSmallGap = false;

	public bool isClosedEntities = false;

	public bool IntersectionEntities = false;

	public double SmallGapMinDistance = 0.001;

	public double SmallGapMaxDistance = 0.05;

	public double EntityLengthLimit = 0.01;

	public double IntersectionGap = 0.1;

	public AnalyseEntitiesSetting()
	{
	}

	public AnalyseEntitiesSetting(AnalyseEntitiesSetting data)
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
		return "isSameMoreThanOneCheck: " + isSameMoreThanOneCheck + " - isSmallGap: " + isSmallGap;
	}
}
