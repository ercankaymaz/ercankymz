using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class MaterialSkin : buSerilization
{
	public string Name = "";

	public Color MaterialColor = Color.Gray;

	public MaterialSkin()
	{
	}

	public MaterialSkin(string name, Color color)
	{
		Name = name;
		MaterialColor = color;
	}

	public MaterialSkin(MaterialSkin mat)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(mat, ref CopiedClass);
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
