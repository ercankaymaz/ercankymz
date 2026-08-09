using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeFreeLines : buShape
{
	public double Width = 10.0;

	public double Height = 10.0;

	public buShapeFreeLines()
	{
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeLines(double width, double height)
	{
		Width = width;
		Height = height;
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeLines(double width, double height, double depth)
	{
		Width = width;
		Height = height;
		Depth = depth;
		ShapeType = ShapeTypes.FreeDraw;
		ShapeGroup = ShapeGroup.Shape;
	}

	public buShapeFreeLines(buShape data)
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
		string text = "Free Lines | " + planeName.ToString() + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		return text;
	}
}
