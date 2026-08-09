using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class Ruler : buSerilization
{
	public bool Enable = false;

	public double Width = 20.0;

	public double Height = 20.0;

	public double BigTickThickness = 2.0;

	public double SmallTickThickness = 2.0;

	public double BigTickLength = 20.0;

	public double SmallTickLength = 5.0;

	public int TotalTickCount = 20;

	public int BigTickCount = 5;

	public Color BigTickColor = Color.Black;

	public Color SmallTickColor = Color.DarkGray;

	public Color RulerColor = Color.White;

	public byte Transparancy = 100;

	public Color TextColor = Color.Black;

	public Color MoveCursorColor = Color.Red;

	public double MoveCursorThickness = 2.0;

	public static List<string> Captions = new List<string>();

	public Ruler()
	{
	}

	public Ruler(Ruler data)
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

	public Ruler(bool enable)
	{
		Enable = enable;
	}

	public Ruler(bool Enable_, double Width_, double Height_, int TotalTickCount_, int BigTickCount_, Color BigTickColor_, Color SmallTickColor_, Color RulerColor_, byte Transparancy_, Color TextColor_, double BigTickLength_, double SmallTickLength_, Color MoveCursorColor_, double MoveCursorThickness_, double BigTickThickness_, double SmallTickThickness_)
	{
		Enable = Enable_;
		Width = Width_;
		Height = Height_;
		TotalTickCount = TotalTickCount_;
		BigTickColor = BigTickColor_;
		BigTickCount = BigTickCount_;
		SmallTickColor = SmallTickColor_;
		RulerColor = RulerColor_;
		Transparancy = Transparancy_;
		TextColor = TextColor_;
		SmallTickLength = SmallTickLength_;
		BigTickLength = BigTickLength_;
		MoveCursorColor = MoveCursorColor_;
		MoveCursorThickness = MoveCursorThickness_;
		BigTickThickness = BigTickThickness_;
		SmallTickThickness = SmallTickThickness_;
	}

	public override string ToString()
	{
		return "Enable : " + Enable;
	}
}
