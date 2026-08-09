using System.Drawing;
using devDept.Geometry;

namespace devDept.Graphics;

public class OutlineShaderParameters : ShaderParametersBase
{
	public Vector2D ViewportSize;

	public Vector2D ViewportSizeInv;

	public Color StartColor;

	public Color EndColor;

	public Color FillColorFront;

	public Color FillColorBack;

	public int ThicknessPolygons;

	public int ThicknessWires;

	public OutlineShaderParameters(RenderContextBase renderContext, Vector2D viewportSize, Color startColor, Color endColor, Color fillColorFront, Color fillColorBack, int thicknessPolygons, int thicknessWires)
		: base(renderContext)
	{
		ViewportSize = viewportSize;
		ViewportSizeInv = new Vector2D(1.0 / viewportSize.X, 1.0 / viewportSize.Y);
		StartColor = startColor;
		EndColor = endColor;
		FillColorFront = fillColorFront;
		FillColorBack = fillColorBack;
		ThicknessPolygons = thicknessPolygons;
		ThicknessWires = thicknessWires;
	}
}
