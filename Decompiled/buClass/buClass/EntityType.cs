using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntityType : buSerilization
{
	public bool AllWireframes = true;

	public bool Line = true;

	public bool Polyline = true;

	public bool Arc = true;

	public bool Circle = true;

	public bool Ellipse = true;

	public bool Bspline = true;

	public bool Bezeir = true;

	public bool Point = true;

	public bool Picture = true;

	public bool Text = true;

	public bool Surface = true;

	public EntityType()
	{
	}

	public EntityType(bool AllWireframe)
	{
		AllWireframes = true;
		Line = true;
		Polyline = true;
		Arc = true;
		Circle = true;
		Ellipse = true;
		Bspline = true;
		Bezeir = true;
		Point = true;
		Picture = false;
		Text = false;
		Surface = false;
	}

	public EntityType(EntityType data)
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
