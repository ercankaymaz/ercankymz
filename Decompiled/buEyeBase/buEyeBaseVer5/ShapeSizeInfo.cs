using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class ShapeSizeInfo : buSerilization5
{
	public Point3D MinBox = new Point3D();

	public Point3D MaxBox = new Point3D();

	public Point3D CenterPoint = new Point3D();

	public ShapeSizeInfo()
	{
	}

	public ShapeSizeInfo(ShapeSizeInfo data)
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
		MaxBox = new Point3D(data.MaxBox.X, data.MaxBox.Y, data.MaxBox.Z);
		MinBox = new Point3D(data.MinBox.X, data.MinBox.Y, data.MinBox.Z);
		CenterPoint = new Point3D(data.CenterPoint.X, data.CenterPoint.Y, data.CenterPoint.Z);
	}

	public override string ToString()
	{
		return "Min: " + MinBox.ToString() + " , MAx: " + MaxBox.ToString();
	}
}
