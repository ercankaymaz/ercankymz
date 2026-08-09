using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class LinearGradientBoolType : buSerilization
{
	public Color EnableFirstColor = Color.Green;

	public Color EnableSecondColor = Color.GreenYellow;

	public Color DisableFirstColor = Color.Tomato;

	public Color DisableSecondColor = Color.LightCoral;

	public double EnableAngle = 90.0;

	public double DisableAngle = 90.0;

	public LinearGradientBoolType()
	{
	}

	public LinearGradientBoolType(LinearGradientBoolType data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "EnableFirst: " + buStatics.ColorToString(EnableFirstColor, ColorConvertType.Html) + " - EnableSecond : " + buStatics.ColorToString(EnableSecondColor, ColorConvertType.Html);
	}
}
