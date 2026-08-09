using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class QuiltingProgramSettings : buSerilization5
{
	public double CornerAngle = 30.0;

	public bool SharpCornerEnable = false;

	public bool DevideOnlyLines = true;

	public double DevideLength = 0.0;

	public double HeadDistance = 1000.0;

	public double RoundCorner = 0.0;

	public double ClosedPatternEndExtentLength = 0.0;

	public double OpenPatternEndExtentLength = 0.0;

	public quiltingSortType SortType = quiltingSortType.FirstDoubleHeadThenSingleHead;

	public quiltingDirectionType MiddleDirection = quiltingDirectionType.FirstHorizontal;

	public double MiddleDirectionCompareAngle = 1.0;

	public bool StartFromMiddle = true;

	public static List<string> Captions = new List<string>();

	public QuiltingProgramSettings()
	{
	}

	public QuiltingProgramSettings(QuiltingProgramSettings data)
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

	public static void Copy(QuiltingProgramSettings Source, ref QuiltingProgramSettings Target)
	{
		Target = new QuiltingProgramSettings(Source);
	}

	public override string ToString()
	{
		return "CornerAngle : " + CornerAngle;
	}
}
