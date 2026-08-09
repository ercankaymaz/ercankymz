using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class DiameterDepthPoint : buSerilization5
{
	public Point3D Position = new Point3D();

	public double Diameter = 10.0;

	public double Depth = 4.0;

	public DiameterDepthPoint()
	{
	}

	public DiameterDepthPoint(Point3D position, double diameter, double depth)
	{
		Position = new Point3D(position.X, position.Y, position.Z);
		Depth = depth;
		Depth = depth;
		Diameter = diameter;
	}

	public DiameterDepthPoint(DiameterDepthPoint mat)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(mat, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Dia: " + Diameter + " , Depth: " + Depth;
	}
}
