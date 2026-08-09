using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class AdditionalData : buSerilization
{
	public int ImageIndex = 0;

	public AdditionalData()
	{
	}

	public AdditionalData(AdditionalData data)
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

	public override string ToString()
	{
		return "ImageIndex: " + ImageIndex;
	}
}
