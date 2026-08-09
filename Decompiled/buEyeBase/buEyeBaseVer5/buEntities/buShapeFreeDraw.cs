using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeFreeDraw : buShape
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Angle = 0.0;

	public buShapeFreeDraw()
	{
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeDraw(double width, double height)
	{
		Width = width;
		Height = height;
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeDraw(double width, double height, double depth, double angle)
	{
		Width = width;
		Height = height;
		Depth = depth;
		Angle = angle;
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeDraw(buShape data)
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
		buEntity.Copy(data.entitiesShape, ref entitiesShape);
	}

	public override string ToString()
	{
		string text = "Free Draw | " + planeName.ToString() + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
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
