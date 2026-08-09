using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerOffsetValues : buSerilization
{
	public double LeftOffset = 0.0;

	public double RightOffset = 0.0;

	public DiemakerOffsetApplyType ApplyType = DiemakerOffsetApplyType.Left;

	public static List<string> Captions = new List<string>();

	public DiemakerOffsetValues()
	{
	}

	public DiemakerOffsetValues(DiemakerOffsetValues data)
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

	public static void Copy(DiemakerOffsetValues Source, ref DiemakerOffsetValues Target)
	{
		Target = new DiemakerOffsetValues(Source);
	}

	public override string ToString()
	{
		return "LeftOffset : " + LeftOffset + " - RightOffset : " + RightOffset + " - ApplyType : " + ApplyType;
	}
}
