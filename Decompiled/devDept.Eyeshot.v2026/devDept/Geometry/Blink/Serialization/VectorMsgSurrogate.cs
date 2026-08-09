using System.Drawing;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class VectorMsgSurrogate : BlinkMsgSurrogate
{
	public Vector2D Vector;

	public Point3D ApplicationPoint;

	public Color? Color;

	public string LayerName;

	public VectorMsgSurrogate(VectorMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		VectorMsg vectorMsg = new VectorMsg();
		CopyDataToObject(vectorMsg);
		return vectorMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		VectorMsg obj2 = (VectorMsg)obj;
		obj2.Vector = Vector;
		obj2.ApplicationPoint = ApplicationPoint;
		obj2.Color = Color;
		obj2.LayerName = LayerName;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		VectorMsg vectorMsg = (VectorMsg)obj;
		Vector = vectorMsg.Vector;
		ApplicationPoint = vectorMsg.ApplicationPoint;
		Color = vectorMsg.Color;
		LayerName = vectorMsg.LayerName;
	}
}
