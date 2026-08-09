using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class Lipping : buSerilization
{
	public bool LeftEnable;

	public bool RightEnable;

	public Lipping()
	{
	}

	public Lipping(Lipping data)
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
		return "Left : " + LeftEnable + " ; Right : " + RightEnable;
	}
}
