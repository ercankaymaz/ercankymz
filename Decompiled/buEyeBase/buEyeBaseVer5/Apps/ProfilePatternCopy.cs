using System;
using System.Reflection;
using buClass;
using buClass.Apps;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfilePatternCopy : buSerilization5
{
	public double Distance = 100.0;

	public double CutSpace = 2.0;

	public int Count = 1;

	public ProfilePatternCopy()
	{
	}

	public ProfilePatternCopy(double distance, double cutspace, int count)
	{
		Distance = distance;
		CutSpace = cutspace;
		Count = count;
	}

	public ProfilePatternCopy(ProfileDepth data)
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

	public override string ToString()
	{
		return "Distance : " + Distance + "  , Count: " + Count;
	}
}
