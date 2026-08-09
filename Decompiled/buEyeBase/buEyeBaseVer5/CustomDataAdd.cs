using System;
using System.Drawing;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class CustomDataAdd : buSerilization5
{
	public string Action = "";

	public double Radius = 0.0;

	public double HeadRadius = 0.0;

	public double MajorRadius = 0.0;

	public double MinorRadius = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Length = 0.0;

	public double Angle = 0.0;

	public int Side = 0;

	public Pnt3D Point = new Pnt3D();

	public string SceneName = "";

	public string ActionName = "";

	public string TextString = "";

	public Font TextFont = null;

	public string FileName = Application.StartupPath;

	public CustomDataAdd()
	{
	}

	public CustomDataAdd(string action, double rad, double width, double height)
	{
		Action = action;
		Radius = rad;
		Width = width;
		Height = height;
	}

	public CustomDataAdd(string action, double rad, double width, double height, double length, double angle)
	{
		Action = action;
		Radius = rad;
		Width = width;
		Height = height;
		Length = length;
		Angle = angle;
	}

	public CustomDataAdd(string action, double rad, double width, double height, double length, double angle, double majorrad, double minorrad, int side)
	{
		Action = action;
		Radius = rad;
		Width = width;
		Height = height;
		Length = length;
		Angle = angle;
		Side = side;
		MajorRadius = majorrad;
		MinorRadius = minorrad;
	}
}
