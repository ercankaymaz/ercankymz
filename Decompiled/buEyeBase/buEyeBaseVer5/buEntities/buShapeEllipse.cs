using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeEllipse : buShape
{
	public double RadiusX = 10.0;

	public double RadiusY = 10.0;

	public double Angle = 0.0;

	public buShapeEllipse()
	{
		ShapeType = ShapeTypes.Ellipse;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeEllipse(double radiusx, double radiusy)
	{
		RadiusX = radiusx;
		RadiusY = radiusy;
		ShapeType = ShapeTypes.Ellipse;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeEllipse(double radiusx, double radiusy, double depth, double angle)
	{
		RadiusX = radiusx;
		RadiusY = radiusy;
		Depth = depth;
		Angle = angle;
		ShapeType = ShapeTypes.Ellipse;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeEllipse(buShape data)
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
		string text = "Ellipse | " + planeName.ToString() + " XRad: " + RadiusX.ToString("f2") + " , YRad: " + RadiusY.ToString("f2");
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
