using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ColorDrawType : buSerilization5
{
	public double Thickess;

	public Color Color = Color.DarkGray;

	public int Transperancy = 255;

	public ColorDrawType()
	{
	}

	public ColorDrawType(ColorDrawType data)
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

	public ColorDrawType(Color color, int transperancy, double thickness)
	{
		Color = color;
		Transperancy = transperancy;
		Thickess = thickness;
	}

	public override string ToString()
	{
		return buImage5.ColorToString(Color, ColorConvertType.Html) + " - Thickness : " + Thickess + " - Transperancy : " + Transperancy;
	}
}
