using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class GrindingVacuum : buSerilization
{
	public double Diameter = 10.0;

	public double Height = 10.0;

	public double Thickness = 10.0;

	public Pnt3D Position = new Pnt3D();

	public int ID = 0;

	public GrindingVacuum()
	{
	}

	public GrindingVacuum(double diameter, double height, double thickness, Pnt3D position, int id)
	{
		Diameter = diameter;
		Height = height;
		Thickness = thickness;
		ID = id;
		Position = new Pnt3D(position);
	}

	public GrindingVacuum(GrindingVacuum data)
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
