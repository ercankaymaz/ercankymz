using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class MouseKeyboardConfigration : buSerilization
{
	public mouseButtons Button = mouseButtons.None;

	public modifierKeys Key = modifierKeys.None;

	public MouseKeyboardConfigration()
	{
	}

	public MouseKeyboardConfigration(mouseButtons Button, modifierKeys Key)
	{
		this.Key = Key;
		this.Button = Button;
	}

	public MouseKeyboardConfigration(MouseKeyboardConfigration data)
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
		return "Button : " + Button.ToString() + " ;  Key : " + Key;
	}
}
