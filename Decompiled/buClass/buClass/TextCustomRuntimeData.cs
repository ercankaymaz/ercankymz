using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class TextCustomRuntimeData : ShapeData
{
	public double Height = 30.0;

	public double CharSpace = 5.0;

	public double SpaceValue = 30.0;

	public string Text = "buCad";

	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public static List<string> Captions = new List<string>();

	public TextCustomRuntimeData()
	{
	}

	public TextCustomRuntimeData(TextCustomRuntimeData data)
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
