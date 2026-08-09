using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeCircle : buShape
{
	public double Radius = 10.0;

	public buShapeCircle()
	{
		ShapeType = ShapeTypes.Circle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeCircle(double radius)
	{
		Radius = radius;
		ShapeType = ShapeTypes.Circle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeCircle(double radius, double depth)
	{
		Radius = radius;
		Depth = depth;
		ShapeType = ShapeTypes.Circle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeCircle(buShape data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		string text = "Circle | " + planeName.ToString() + " Rad: " + Radius.ToString("f2");
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
