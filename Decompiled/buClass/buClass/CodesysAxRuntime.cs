using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxRuntime : buSerilization
{
	public CodesysAxRuntimeActive Actual = new CodesysAxRuntimeActive();

	public CodesysAxRuntimeBool Bool = new CodesysAxRuntimeBool();

	public CodesysAxRuntimeInput Input = new CodesysAxRuntimeInput();

	public CodesysAxRuntimeMisc Misc = new CodesysAxRuntimeMisc();

	public CodesysAxRuntime()
	{
	}

	public CodesysAxRuntime(CodesysAxRuntime data)
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
		return Bool.ToString();
	}
}
