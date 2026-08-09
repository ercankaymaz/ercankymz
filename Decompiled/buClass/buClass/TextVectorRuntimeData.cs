using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

public class TextVectorRuntimeData : ShapeData
{
	public double Height = 30.0;

	public string Text = "buCad";

	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public bool DrawAsCurve = true;

	public static List<string> Captions = new List<string>();

	public TextVectorRuntimeData()
	{
	}

	public TextVectorRuntimeData(TextVectorRuntimeData data)
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
