using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class EntityShapeInfo : buSerilization5
{
	public string String = "";

	public string Data = "";

	public double Length = 0.0;

	public double Angle = 0.0;

	public double Direction = 0.0;

	public double Height = 0.0;

	public double Radius = 0.0;

	public double Width = 0.0;

	public double Depth = 0.0;

	public double HeadRadius = 0.0;

	public int Side = 0;

	public int Degree = 1;

	public entitySplineType CurveType = entitySplineType.BsplineQuadratic;

	public Point3D BasePoint = new Point3D();

	public EntityShapeInfo()
	{
	}

	public EntityShapeInfo(EntityShapeInfo data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		BasePoint = new Point3D(data.BasePoint.X, data.BasePoint.Y, data.BasePoint.Z);
	}

	public override string ToString()
	{
		return "Angle: " + Angle.ToString("f2");
	}
}
