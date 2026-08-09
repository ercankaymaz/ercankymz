using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class BoxSize : buSerilization
{
	public Pnt3D MinPoint = new Pnt3D();

	public Pnt3D MaxPoint = new Pnt3D();

	public Vec3D Delta = new Vec3D();

	public BoxSize()
	{
	}

	public BoxSize(BoxSize box)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(box, ref CopiedClass);
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

	public BoxSize(Pnt3D PMin, Pnt3D PMax)
	{
		MinPoint = new Pnt3D(PMin);
		MaxPoint = new Pnt3D(PMax);
	}

	public override string ToString()
	{
		return "dX: " + Delta.X.ToString("f2") + " , dY: " + Delta.Y.ToString("f2") + " , dZ: " + Delta.Z.ToString("f2");
	}
}
