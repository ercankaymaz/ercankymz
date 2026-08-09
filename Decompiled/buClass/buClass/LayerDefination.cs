using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class LayerDefination : buSerilization
{
	public string Name = "Default";

	public double Thickness = 1.0;

	public Color Color = Color.Gray;

	public int Index = 0;

	public int Transperancy = 255;

	public LayerDefination()
	{
	}

	public LayerDefination(string name, double thickness, Color color, int index, int transperancy = 255)
	{
		Name = name;
		Thickness = thickness;
		Color = color;
		Index = index;
		Transperancy = transperancy;
	}

	public LayerDefination(LayerDefination data)
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
