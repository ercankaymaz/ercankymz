using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EnableVisibleText : buSerilization
{
	public bool Enable = true;

	public bool Visible = true;

	public string Text = "";

	public EnableVisibleText()
	{
	}

	public EnableVisibleText(bool enable, bool visible, string text)
	{
		Enable = enable;
		Visible = visible;
		Text = text;
	}

	public EnableVisibleText(EnableVisibleText data)
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
