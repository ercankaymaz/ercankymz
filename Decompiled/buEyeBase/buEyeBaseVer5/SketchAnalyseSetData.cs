using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class SketchAnalyseSetData : buSerilization5
{
	public double DefaultDepth = 0.0;

	public SketchAnalyseSetData()
	{
	}

	public SketchAnalyseSetData(double defaultDepth)
	{
		DefaultDepth = defaultDepth;
	}

	public SketchAnalyseSetData(SketchAnalyseSetData data)
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
		return DefaultDepth.ToString();
	}
}
