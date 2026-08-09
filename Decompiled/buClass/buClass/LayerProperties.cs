using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class LayerProperties : buSerilization
{
	public bool isLock = false;

	public bool isVisible = false;

	public Color Color = Color.Black;

	public double Thickness = 1.0;

	public LayerProperties()
	{
	}

	public LayerProperties(LayerProperties data)
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
