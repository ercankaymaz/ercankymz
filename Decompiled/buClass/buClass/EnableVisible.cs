using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EnableVisible : buSerilization
{
	public bool Enable = true;

	public bool Visible = true;

	public EnableVisible()
	{
	}

	public EnableVisible(bool enable, bool visible)
	{
		Enable = enable;
		Visible = visible;
	}

	public EnableVisible(EnableVisible data)
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
		return "Enable: " + Enable + " - Visible: " + Visible;
	}
}
