using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoText : geoEntity
{
	public string TextString = "";

	public Pnt3D StartPoint = new Pnt3D();

	public double Height = 10.0;

	public double Angle = 0.0;

	public Font TextFont = new Font("Times New Roman", 12f);

	public geoText()
	{
	}

	public geoText(geoText text)
	{
		StartPoint = new Pnt3D(text.StartPoint);
		TextString = text.TextString;
		Height = text.Height;
		Color = text.Color;
		TextFont = new Font(text.TextFont.FontFamily, text.TextFont.Size, text.TextFont.Style);
		Angle = text.Angle;
		TypeDefination = text.TypeDefination;
		isText = text.isText;
	}

	public geoText(Pnt3D startpnt, string text, Font fnt, Color color, double height, double angle)
	{
		StartPoint = new Pnt3D(startpnt);
		TextString = text;
		Height = height;
		TextFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style);
		Color = color;
		Angle = angle;
	}

	public geoText(Pnt3D startpnt, string text, Font fnt, Color color, double height, double angle, int layer)
	{
		StartPoint = new Pnt3D(startpnt);
		TextString = text;
		Height = height;
		TextFont = new Font(fnt.FontFamily, fnt.Size, fnt.Style);
		Color = color;
		Angle = angle;
		Layer = layer;
	}

	public override string ToString()
	{
		return "[X:" + StartPoint.X.ToString("f3") + " Y:" + StartPoint.Y.ToString("f3") + " Z:" + StartPoint.Z.ToString("f3") + "] ; " + TextString;
	}
}
