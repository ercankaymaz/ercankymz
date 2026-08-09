using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class TextVectorData : ShapeData
{
	public double Height = 30.0;

	public string Text = "buCad";

	public Font Font = new Font("Times New Roman", 30f);

	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public Pnt3D CenterPoint = new Pnt3D();

	public bool DrawAsCurve = true;

	public static List<string> Captions = new List<string>();

	public TextVectorData()
	{
	}

	public TextVectorData(TextVectorData data)
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
