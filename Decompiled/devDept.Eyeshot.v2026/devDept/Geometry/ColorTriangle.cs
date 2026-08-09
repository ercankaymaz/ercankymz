using System;
using System.Drawing;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class ColorTriangle : IndexTriangle, ITriangleSupportsColor
{
	public byte R { get; set; }

	public byte G { get; set; }

	public byte B { get; set; }

	public ColorTriangle()
	{
	}

	public ColorTriangle(int v1, int v2, int v3, Color color)
		: base(v1, v2, v3)
	{
		R = color.R;
		G = color.G;
		B = color.B;
	}

	public ColorTriangle(int v1, int v2, int v3, byte red, byte green, byte blue)
		: base(v1, v2, v3)
	{
		R = red;
		G = green;
		B = blue;
	}

	protected ColorTriangle(ColorTriangle another)
		: base(another)
	{
		R = another.R;
		G = another.G;
		B = another.B;
	}

	public override object Clone()
	{
		return new ColorTriangle(this);
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new ColorTriangleSurrogate(this);
	}
}
