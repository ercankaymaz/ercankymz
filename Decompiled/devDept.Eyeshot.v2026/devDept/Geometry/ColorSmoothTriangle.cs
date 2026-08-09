using System;
using System.Drawing;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class ColorSmoothTriangle : SmoothTriangle, ITriangleSupportsColor
{
	public byte R { get; set; }

	public byte G { get; set; }

	public byte B { get; set; }

	public ColorSmoothTriangle()
	{
	}

	public ColorSmoothTriangle(int v1, int v2, int v3, Color color)
		: base(v1, v2, v3)
	{
		R = color.R;
		G = color.G;
		B = color.B;
	}

	public ColorSmoothTriangle(int v1, int v2, int v3, byte red, byte green, byte blue)
		: base(v1, v2, v3)
	{
		R = red;
		G = green;
		B = blue;
	}

	public ColorSmoothTriangle(int v1, int v2, int v3, int n1, int n2, int n3, Color color)
		: base(v1, v2, v3, n1, n2, n3)
	{
		R = color.R;
		G = color.G;
		B = color.B;
	}

	public ColorSmoothTriangle(int v1, int v2, int v3, int n1, int n2, int n3, byte red, byte green, byte blue)
		: base(v1, v2, v3, n1, n2, n3)
	{
		R = red;
		G = green;
		B = blue;
	}

	protected ColorSmoothTriangle(ColorSmoothTriangle another)
		: base(another)
	{
		R = another.R;
		G = another.G;
		B = another.B;
	}

	public override object Clone()
	{
		return new ColorSmoothTriangle(this);
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new ColorSmoothTriangleSurrogate(this);
	}
}
