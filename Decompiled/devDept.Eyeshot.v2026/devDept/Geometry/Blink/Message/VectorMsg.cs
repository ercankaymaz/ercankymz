using System.Drawing;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class VectorMsg : BlinkMsg
{
	public Vector2D Vector;

	public Point3D ApplicationPoint;

	public Color? Color;

	public string LayerName;

	public bool IsVector3D => Vector is Vector3D;

	public VectorMsg(Vector2D vector, Point3D applicationPoint, Color? color, string layerName)
	{
		Vector = vector;
		ApplicationPoint = applicationPoint;
		Color = color;
		LayerName = layerName;
	}

	internal VectorMsg()
	{
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new VectorMsgSurrogate(this);
	}
}
