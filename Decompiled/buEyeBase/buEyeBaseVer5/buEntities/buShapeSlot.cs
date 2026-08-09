using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeSlot : buShape
{
	public double Diameter = 10.0;

	public double Length = 6.0;

	public double Angle = 0.0;

	public buShapeSlot()
	{
		ShapeType = ShapeTypes.Slot;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeSlot(double diameter, double length)
	{
		Diameter = diameter;
		Length = length;
		ShapeType = ShapeTypes.Slot;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeSlot(double diameter, double length, double depth, double angle)
	{
		Diameter = diameter;
		Length = length;
		Angle = angle;
		Depth = depth;
		ShapeType = ShapeTypes.Slot;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeSlot(buShape data)
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
		string text = "Slot | " + planeName.ToString() + " Len: " + Length + " , Dia: " + Diameter.ToString("f2");
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
