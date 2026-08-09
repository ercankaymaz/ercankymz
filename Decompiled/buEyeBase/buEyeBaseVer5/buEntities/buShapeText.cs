using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeText : buShape
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Angle = 0.0;

	public string TextString = "";

	public bool isWire = false;

	public Font TextFont = new Font("Arial", 10f);

	public buShapeText()
	{
		ShapeType = ShapeTypes.Text;
		ShapeGroup = ShapeGroup.Text;
	}

	public buShapeText(double width, double height, string textString)
	{
		Width = width;
		Height = height;
		TextString = textString;
		ShapeType = ShapeTypes.Text;
		ShapeGroup = ShapeGroup.Text;
	}

	public buShapeText(double width, double height, double depth, string textString, Font font, double angle)
	{
		Width = width;
		Height = height;
		Depth = depth;
		TextString = textString;
		Angle = angle;
		TextFont = new Font(font.Name, font.Size, font.Style);
		ShapeType = ShapeTypes.Text;
		ShapeGroup = ShapeGroup.Text;
	}

	public buShapeText(buShape data)
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
		TextFont = new Font(((buShapeText)data).TextFont.Name, ((buShapeText)data).TextFont.Size, ((buShapeText)data).TextFont.Style);
		buEntity.Copy(data.entitiesShape, ref entitiesShape);
	}

	public override string ToString()
	{
		string text = "Text | " + planeName.ToString() + " Text: " + TextString.ToString() + " , Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
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
