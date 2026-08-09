using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapePolygon : buShape
{
	public double Radius = 10.0;

	public int Side = 6;

	public double Angle = 0.0;

	public buShapePolygon()
	{
		ShapeType = ShapeTypes.Polygon;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapePolygon(double radius, int side)
	{
		Radius = radius;
		Side = side;
		ShapeType = ShapeTypes.Polygon;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapePolygon(double radius, int side, double depth, double angle)
	{
		Radius = radius;
		Side = side;
		Depth = depth;
		Angle = angle;
		ShapeType = ShapeTypes.Polygon;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapePolygon(buShape data)
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
		string text = "Polygon | " + planeName.ToString() + " Side: " + Side + " , Rad: " + Radius.ToString("f2");
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
