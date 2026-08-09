using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolDisplay : buSerilization
{
	public SolidItemDisplay Solid = new SolidItemDisplay(Color.Red, 220, Color.DarkRed, 240);

	public SolidItemDisplay ToolCutSolid = new SolidItemDisplay(Color.DarkOrange, 220, Color.DarkRed, 240);

	public SolidItemDisplay ToolBodySolid = new SolidItemDisplay(Color.DarkOliveGreen, 220, Color.DarkRed, 240);

	public SolidItemDisplay HolderSolid = new SolidItemDisplay(Color.DarkGray, 220, Color.DarkRed, 240);

	public SolidItemDisplay ArborSolid = new SolidItemDisplay(Color.DarkSlateBlue, 220, Color.DarkRed, 240);

	public Color CamColor = Color.Red;

	public double CamThickness = 2.0;

	public Color PlungeColor = Color.Green;

	public double PlungeThickness = 2.0;

	public Color LeaveColor = Color.Gold;

	public double LeaveThickness = 2.0;

	public Color UpperCamColor = Color.Blue;

	public double UpperCamThickness = 2.0;

	public ToolDisplay()
	{
	}

	public ToolDisplay(ToolDisplay display)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(display, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		ToolBodySolid = new SolidItemDisplay(display.ToolBodySolid);
	}

	public override string ToString()
	{
		return "Tool Color: " + Solid.SkinColor.ToString() + " - Cam Color: " + CamColor.ToString() + " - Up Cam Color: " + UpperCamColor.ToString();
	}
}
