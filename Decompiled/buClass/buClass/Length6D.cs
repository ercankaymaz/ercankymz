using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Length6D : buSerilization
{
	public double dX = 0.0;

	public double dY = 0.0;

	public double dZ = 0.0;

	public double dA = 0.0;

	public double dB = 0.0;

	public double dC = 0.0;

	public static List<string> Captions = new List<string>();

	public Length6D()
	{
	}

	public Length6D(Length6D lengths)
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

	public Length6D(double dx, double dy, double dz)
	{
		dX = dx;
		dY = dy;
		dZ = dz;
	}

	public Length6D(double dx, double dy, double dz, double da, double db, double dc)
	{
		dX = dx;
		dY = dy;
		dZ = dz;
		dA = da;
		dB = db;
		dC = dc;
	}

	public override string ToString()
	{
		return "dX: " + dX.ToString("f4") + " ; dY: " + dY.ToString("f4") + " ; dZ: " + dZ.ToString("f4") + " ; dA: " + dA.ToString("f4") + " ; dB: " + dB.ToString("f4") + " ; dC: " + dC.ToString("f4");
	}

	public static Length6D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Length6D length6D = new Length6D();
			Value = Value.Replace("dX:", "");
			Value = Value.Replace("dY:", "");
			Value = Value.Replace("dZ:", "");
			Value = Value.Replace("dA:", "");
			Value = Value.Replace("dB:", "");
			Value = Value.Replace("dC:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				length6D.dX = double.Parse(array[0], provider);
				length6D.dY = double.Parse(array[1], provider);
				length6D.dZ = 0.0;
			}
			if (array.Length == 3)
			{
				length6D.dX = double.Parse(array[0], provider);
				length6D.dY = double.Parse(array[1], provider);
				length6D.dZ = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				length6D.dX = double.Parse(array[0], provider);
				length6D.dY = double.Parse(array[1], provider);
				length6D.dZ = double.Parse(array[2], provider);
				length6D.dA = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				length6D.dX = double.Parse(array[0], provider);
				length6D.dY = double.Parse(array[1], provider);
				length6D.dZ = double.Parse(array[2], provider);
				length6D.dA = double.Parse(array[3], provider);
				length6D.dB = double.Parse(array[4], provider);
			}
			if (array.Length == 6)
			{
				length6D.dX = double.Parse(array[0], provider);
				length6D.dY = double.Parse(array[1], provider);
				length6D.dZ = double.Parse(array[2], provider);
				length6D.dA = double.Parse(array[3], provider);
				length6D.dB = double.Parse(array[4], provider);
				length6D.dC = double.Parse(array[5], provider);
			}
			return length6D;
		}
		catch (Exception)
		{
			return new Length6D();
		}
	}

	public string ToDef()
	{
		return "dX: " + dX + " ; dY: " + dY + " ; dZ: " + dZ + " ; dA: " + dA + " ; dB: " + dB + " ; dC: " + dC;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "dX:" + dX.ToString("") + "; dY:" + dY.ToString("") + "; dZ:" + dZ.ToString("") + " ; dA: " + dA + " ; dB: " + dB + " ; dC: " + dC;
	}
}
