using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PostCamProperties : buSerilization
{
	public double MinZOperationValue = -1000000.0;

	public double MaxZOperationValue = 1000000.0;

	public PostCamProperties()
	{
	}

	public PostCamProperties(PostCamProperties data)
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
}
