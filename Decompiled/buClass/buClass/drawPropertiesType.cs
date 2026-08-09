using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class drawPropertiesType : buSerilization
{
	public Color Color = Color.DarkGray;

	public float Thickness = 1f;

	public int Transperancy = 255;

	public drawingPattern Pattern = new drawingPattern();

	public static List<string> Captions = new List<string>();

	public drawPropertiesType()
	{
	}

	public drawPropertiesType(drawPropertiesType drawprop)
	{
		Color = drawprop.Color;
		Thickness = drawprop.Thickness;
		Pattern = new drawingPattern(drawprop.Pattern);
		Transperancy = drawprop.Transperancy;
	}

	public drawPropertiesType(Color color, float thickness)
	{
		Color = color;
		Thickness = thickness;
		Pattern = new drawingPattern();
	}

	public drawPropertiesType(Color color, float thickness, int transperancy)
	{
		Color = color;
		Thickness = thickness;
		Pattern = new drawingPattern();
		Transperancy = transperancy;
	}

	public drawPropertiesType(Color color, float thickness, drawingPattern pattern)
	{
		Color = color;
		Thickness = thickness;
		Pattern = new drawingPattern(pattern);
	}

	public drawPropertiesType(Color color, float thickness, drawingPattern pattern, int transperancy)
	{
		Color = color;
		Thickness = thickness;
		Pattern = new drawingPattern(pattern);
		Transperancy = transperancy;
	}

	public override string ToString()
	{
		return buStatics.ColorToString(Color, ColorConvertType.Html) + " - T : " + Thickness;
	}
}
