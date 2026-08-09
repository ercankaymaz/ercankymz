using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeKeyHole : buShape
{
	public double HeadDiameter = 10.0;

	public double Diameter = 10.0;

	public double Length = 6.0;

	public double Angle = 0.0;

	public buShapeKeyHole()
	{
		ShapeType = ShapeTypes.KeyHole;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeKeyHole(double headdiameter, double diameter, double length)
	{
		HeadDiameter = headdiameter;
		Diameter = diameter;
		Length = length;
		ShapeType = ShapeTypes.KeyHole;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeKeyHole(double headdiameter, double diameter, double length, double depth, double angle)
	{
		HeadDiameter = headdiameter;
		Diameter = diameter;
		Length = length;
		Depth = depth;
		Angle = angle;
		ShapeType = ShapeTypes.KeyHole;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeKeyHole(buShape data)
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
		string text = "KeyHole | " + planeName.ToString() + " Len: " + Length + " , HeadDia: " + HeadDiameter.ToString("f2") + " , Dia: " + Diameter.ToString("f2");
		if (Angle != 0.0)
		{
			text = text + " , Ang: " + Angle.ToString("f2");
		}
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
