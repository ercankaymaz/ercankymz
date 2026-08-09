using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Length3D : buSerilization
{
	public double dX = 0.0;

	public double dY = 0.0;

	public double dZ = 0.0;

	public static List<string> Captions = new List<string>();

	public Length3D()
	{
	}

	public Length3D(Length3D lengths)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(lengths, ref CopiedClass);
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

	public Length3D(double dx, double dy, double dz)
	{
		dX = dx;
		dY = dy;
		dZ = dz;
	}

	public override string ToString()
	{
		return "dX: " + dX.ToString("f4") + " ; dY: " + dY.ToString("f4") + " ; dZ: " + dZ.ToString("f4");
	}

	public static Length3D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Length3D length3D = new Length3D();
			Value = Value.Replace("dX:", "");
			Value = Value.Replace("dY:", "");
			Value = Value.Replace("dZ:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				length3D.dX = double.Parse(array[0], provider);
				length3D.dY = double.Parse(array[1], provider);
				length3D.dZ = 0.0;
			}
			if (array.Length > 2)
			{
				length3D.dX = double.Parse(array[0], provider);
				length3D.dY = double.Parse(array[1], provider);
				length3D.dZ = double.Parse(array[2], provider);
			}
			return length3D;
		}
		catch (Exception)
		{
			return new Length3D();
		}
	}

	public string ToDef()
	{
		return "dX: " + dX + " ; dY: " + dY + " ; dZ: " + dZ;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "dX:" + dX.ToString("") + "; dY:" + dY.ToString("") + "; dZ:" + dZ.ToString("");
	}
}
