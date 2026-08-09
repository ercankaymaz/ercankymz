using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingRectangleFSurrogate
{
	public float X;

	public float Y;

	public float Width;

	public float Height;

	public SystemDrawingRectangleFSurrogate(float x, float y, float width, float height)
	{
		X = x;
		Y = y;
		Width = width;
		Height = height;
	}

	public static implicit operator RectangleF(SystemDrawingRectangleFSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return new RectangleF(surrogate.X, surrogate.Y, surrogate.Width, surrogate.Height);
		}
		return RectangleF.Empty;
	}

	public static implicit operator SystemDrawingRectangleFSurrogate(RectangleF source)
	{
		return new SystemDrawingRectangleFSurrogate(source.X, source.Y, source.Width, source.Height);
	}
}
