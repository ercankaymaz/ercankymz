using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PointerLine : buSerilization
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public bool Visible = false;

	public PointerLine()
	{
	}

	public PointerLine(PointerLine data)
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
