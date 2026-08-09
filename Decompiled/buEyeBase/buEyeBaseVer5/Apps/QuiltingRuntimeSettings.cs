using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class QuiltingRuntimeSettings : buSerilization5
{
	public SortSettings QuiltSortSettings = new SortSettings();

	public quiltingHeadType Heads = quiltingHeadType.Both;

	public QuiltingRuntimeSettings()
	{
	}

	public QuiltingRuntimeSettings(QuiltingRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		QuiltSortSettings = new SortSettings(data.QuiltSortSettings);
	}

	public static void Copy(QuiltingRuntimeSettings Source, ref QuiltingRuntimeSettings Target)
	{
		Target = new QuiltingRuntimeSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
