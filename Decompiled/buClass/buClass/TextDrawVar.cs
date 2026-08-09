using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class TextDrawVar : buSerilization
{
	public double Height = 30.0;

	public string Text = "buCad";

	public Font Font = new Font("Times New Roman", 30f);

	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public static List<string> Captions = new List<string>();

	public TextDrawVar()
	{
	}

	public TextDrawVar(TextDrawVar data)
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
