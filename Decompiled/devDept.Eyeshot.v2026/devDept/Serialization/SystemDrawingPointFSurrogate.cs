using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingPointFSurrogate
{
	public float X;

	public float Y;

	public SystemDrawingPointFSurrogate(float x, float y)
	{
		X = x;
		Y = y;
	}

	public static implicit operator PointF(SystemDrawingPointFSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return new PointF(surrogate.X, surrogate.Y);
		}
		return PointF.Empty;
	}

	public static implicit operator SystemDrawingPointFSurrogate(PointF source)
	{
		return new SystemDrawingPointFSurrogate(source.X, source.Y);
	}
}
