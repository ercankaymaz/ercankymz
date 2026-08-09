using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class MeasureData
{
	public List<Point3D> Points = new List<Point3D>();

	public double Length = 0.0;

	public string Text = "";

	public Point3D PntText = new Point3D();

	public Color Color = Color.Red;

	public float Size = 2f;
}
