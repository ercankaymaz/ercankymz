using System;
using System.Drawing;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointRGB : Point3D
{
	public byte R { get; set; }

	public byte G { get; set; }

	public byte B { get; set; }

	public PointRGB(double x, double y, double z, Color color)
		: base(x, y, z)
	{
		R = color.R;
		G = color.G;
		B = color.B;
	}

	public PointRGB(double x, double y, double z, byte red, byte green, byte blue)
		: base(x, y, z)
	{
		R = red;
		G = green;
		B = blue;
	}

	protected PointRGB(PointRGB another)
		: base(another)
	{
		R = another.R;
		G = another.G;
		B = another.B;
	}

	public override object Clone()
	{
		return new PointRGB(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659273), base.ToString(), R, G, B);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointRGBSurrogate(this);
	}
}
