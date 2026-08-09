using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeRectangle : buShape
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Angle = 0.0;

	public double Radius = 0.0;

	public double Chamfer = 0.0;

	public buShapeRectangle()
	{
		ShapeType = ShapeTypes.Rectangle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeRectangle(double width, double height)
	{
		Width = width;
		Height = height;
		ShapeType = ShapeTypes.Rectangle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeRectangle(double width, double height, double radius, double chamfer, double depth, double angle)
	{
		Width = width;
		Height = height;
		Radius = radius;
		Chamfer = chamfer;
		Depth = depth;
		Angle = angle;
		ShapeType = ShapeTypes.Rectangle;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeRectangle(buShape data)
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
		string text = "Rectangle | " + planeName.ToString() + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
		if (Radius > 0.0)
		{
			text = text + " , Rad: " + Radius.ToString("f2");
		}
		if (Chamfer > 0.0)
		{
			text = text + " , Chamfer: " + Chamfer.ToString("f2");
		}
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

	public string ToStr()
	{
		string text = "Rectangle | " + planeName.ToString() + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
		if (Radius > 0.0)
		{
			text = text + " , Rad: " + Radius.ToString("f2");
		}
		if (Chamfer > 0.0)
		{
			text = text + " , Chamfer: " + Chamfer.ToString("f2");
		}
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
